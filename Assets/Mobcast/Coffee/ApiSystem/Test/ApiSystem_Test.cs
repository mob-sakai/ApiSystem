using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Mobcast.Coffee.Api;
using MsgPack.Serialization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Mobcast.Coffee.Api.Test
{
	public class ApiTest : MonoBehaviour
	{
		const string kPrefsKey = "ApiTest_Header";

		[Header ("ヘッダー")]
		public GameObject headerItem_Enum;
		public GameObject headerItem_String;
		public GameObject headerItem_Bool;

		/// <summary>
		/// API一覧ドロップダウン.
		/// </summary>
		[Header ("リクエスト")]
		public Dropdown dropdownApiList;

		/// <summary>
		/// APIリクエストボディ(json構文).
		/// </summary>
		public InputField requestBody;

		/// <summary>
		/// レスポンスヘッダ表示先.
		/// </summary>
		[Header ("レスポンス")]
		public InputField responseHeader;

		/// <summary>
		/// レスポンスボディ表示先.
		/// </summary>
		public InputField responseBody;

		/// <summary>
		/// レスポンスボディ表示先.
		/// </summary>
		public InputField responseBodyJson;

		/// <summary>
		/// レスポンスパケットオブジェクト表示先.
		/// </summary>
		public InputField responsePacket;

		protected virtual Type requestMetaType{ get { return typeof(ApiRequestMeta); } }

		protected virtual string freeToken{ get { return "free-pass-token"; } }

		/// <summary>
		/// API一覧.
		/// </summary>
		readonly Type[] apiRequestTypes = typeof(ApiRequest<,>).Assembly.GetTypes ()
			.Where (x => x.IsClass && x.BaseType != null && x.BaseType.IsGenericType && x.BaseType.GetGenericTypeDefinition () == typeof(ApiRequest<,>))
			.ToArray ();

		protected virtual void Start ()
		{
			//APIメタデータ初期化.
			ApiRequestMeta rm = JsonUtility.FromJson (PlayerPrefs.GetString (kPrefsKey, "{}"), requestMetaType) as ApiRequestMeta;
			ApiManager.Initialize (rm);

			//リクエストヘッダーアイテムを追加.
			headerItem_Enum.SetActive (false); 
			headerItem_String.SetActive (false);
			headerItem_Bool.SetActive (false);

			//Enum要素を追加
			RegisterEnum (ApiConstants.HEADER_KEY_CONTENT_TYPE, () => rm.contentTypeCode, v => rm.contentTypeCode = v);
			RegisterEnum (ApiConstants.HEADER_KEY_PACKET_PROTOCOL, () => rm.packetProtocolCode, v => rm.packetProtocolCode = v);
			RegisterEnum (ApiConstants.HEADER_KEY_PACKET_ENCRYPT, () => rm.packetEncryptCode, v => rm.packetEncryptCode = v);
			RegisterEnum (ApiConstants.HEADER_KEY_LANGUAGE_CODE, () => rm.languageCode, v => rm.languageCode = v);
			RegisterEnum (ApiConstants.HEADER_KEY_PLATFORM, () => rm.platformCode, v => rm.platformCode = v);

			//string要素を追加
			RegisterString (ApiConstants.HEADER_KEY_SESSION_ID, () => rm.sessionId, v => rm.sessionId = v);
			RegisterString (ApiConstants.HEADER_KEY_PLAYER_ID, () => rm.playerId, v => rm.playerId = v);
			RegisterString (ApiConstants.HEADER_KEY_APP_VERSION, () => rm.appVersion, v => rm.appVersion = v);
			RegisterString (ApiConstants.HEADER_KEY_APP_ID, () => rm.appId, v => rm.appId = v);
			RegisterString (ApiConstants.HEADER_KEY_UID, () => rm.uid, v => rm.uid = v, "Reset", () => {
				rm.uid = Guid.NewGuid ().ToString ();
				rm.playerId = "-1";
			});
			RegisterString (ApiConstants.HEADER_KEY_TOKEN, () => rm.token, v => rm.token = v, "Free", () => rm.token = freeToken);

			//デバッグ用
			RegisterString (ApiConstants.HEADER_KEY_DEBUG_ERROR_CODE,
				rm.debugErrorCode.ToString,
				v => {
					int value;
					if (int.TryParse (v, out value))
						rm.debugErrorCode = value;
				});

			RegisterString (ApiConstants.HEADER_KEY_DEBUG_RESPONSE_DELAY,
				rm.debugResponseDelay.ToString,
				v => {
					int value;
					if (int.TryParse (v, out value))
						rm.debugResponseDelay = value;
				});

			//ApiRequest名の一覧をドロップダウンに追加.
			dropdownApiList.ClearOptions ();
			dropdownApiList.AddOptions (apiRequestTypes.Select (x => x.Name).ToList ());
			dropdownApiList.onValueChanged.Invoke (0);
		}

		public void OnValueChanged_Dropdown (int index)
		{
			requestBody.text = JsonUtility.ToJson (Activator.CreateInstance (apiRequestTypes [index]), true);
		}

		public void OnClick_Request ()
		{
			//リクエストボディを元に、オブジェクトを生成
			var request = JsonUtility.FromJson (requestBody.text, apiRequestTypes [dropdownApiList.value]);

			//リクエストを実行.
			var operation = apiRequestTypes [dropdownApiList.value]
			.GetMethod ("Request", BindingFlags.Instance | BindingFlags.Public)
			.Invoke (request, new object[]{ null, null }) as ApiOperation;
		
			PlayerPrefs.SetString (kPrefsKey, JsonUtility.ToJson (ApiManager.requestMeta));

			operation.onNetworkEnd += (web, req) => {
				ApiRequestMeta rm = ApiManager.requestMeta;

				// * UID/PIDの自動保存
				PlayerPrefs.SetString (kPrefsKey, JsonUtility.ToJson (ApiManager.requestMeta));

				//レスポンスヘッダ
				var header = web.GetResponseHeaders ();
				responseHeader.text = (header == null) ? ""
								: header.Select (pair => pair.Key + " : " + pair.Value).Aggregate ((a, b) => a + "\n" + b);
			
				//レスポンスボディ.
				string body = !string.IsNullOrEmpty (web.error)
				? web.error
				: web.downloadHandler != null
					? web.downloadHandler.text
					: "no-response";
				responseBody.text = body.Substring (0, Mathf.Min (15000, body.Length));

				//レスポンスボディのJson.
				var data = web.downloadHandler.data;
				{
					if (rm.packetEncryptCode == PacketEncryptCode.ON && rm.packetProtocolCode == PacketProtocolCode.JSON)
						data = Convert.FromBase64String (Encoding.UTF8.GetString (data));

					// 暗号化指定されている場合は復号化.
					if (rm.packetEncryptCode == PacketEncryptCode.ON)
						data = ObjectParser.Decrypt (data, rm.key, rm.iv);
				}
				string bodyJson = ApiManager.ToJson (data, rm.packetProtocolCode == PacketProtocolCode.JSON);
				responseBodyJson.text = bodyJson.Substring (0, Mathf.Min (15000, bodyJson.Length));

				//レスポンスパケットオブジェクト表示先.
				string obj = (req.responseObject != null) ? JsonUtility.ToJson (req.responseObject, true) : "null";
				responsePacket.text = obj.Substring (0, Mathf.Min (15000, obj.Length));

				//出力
				if (string.IsNullOrEmpty (operation.error)) {
					File.WriteAllBytes (Path.Combine (Application.dataPath, "../Temp/ApiLog_ResponseBody.byte"), web.downloadHandler.data);
					File.WriteAllText (Path.Combine (Application.dataPath, "../Temp/ApiLog_ResponseBodyJson.txt"), bodyJson);
					File.WriteAllText (Path.Combine (Application.dataPath, "../Temp/ApiLog_ResponsePacket.txt"), obj);
				}
			};
		}


		/// <summary>
		/// ヘッダー要素をインスタンス化.
		/// </summary>
		protected GameObject Instantiate (GameObject prefab, string title)
		{
			//string要素をインスタンス化
			var go = UnityEngine.Object.Instantiate (prefab, prefab.transform.parent) as GameObject;
			go.SetActive (true);
			go.name = title;

			//ヘッダー要素のタイトルを変更
			go.GetComponentInChildren<Text> ().text = title;
			return go;
		}

		/// <summary>
		/// ヘッダー要素にstringを追加.
		/// setterとgetterにより、変数やプロパティなどに紐付けできます.
		/// </summary>
		/// <param name="title">要素タイトル.</param>
		/// <param name="getter">getter.</param>
		/// <param name="setter">setter.</param>
		protected void RegisterEnum<T> (string title, Func<T> getter, Action<T> setter)
		{
			//ヘッダー要素をインスタンス化
			var go = Instantiate (headerItem_Enum, title);

			//ドロップダウンにEnum要素を全て追加
			Dropdown d = go.GetComponentInChildren<Dropdown> ();
			var keys = Enum.GetNames (typeof(T)).ToList ();
			var values = Enum.GetValues (typeof(T)).Cast<T> ().ToList ();
			d.ClearOptions ();
			d.AddOptions (keys);
			d.value = values.FindIndex (x => x.Equals (getter ()));
			d.onValueChanged.AddListener (i => setter (values [i]));
		}


		/// <summary>
		/// ヘッダー要素にstringを追加.
		/// setterとgetterにより、変数やプロパティなどに紐付けできます.
		/// </summary>
		/// <param name="title">要素タイトル.</param>
		/// <param name="getter">getter.</param>
		/// <param name="setter">setter.</param>
		/// <param name="buttonName">ボタン名.</param>
		/// <param name="buttonAction">ボタンアクション.</param>
		protected void RegisterString (string title, Func<string> getter, UnityAction<string> setter, string buttonName = null, UnityAction buttonAction = null)
		{
			//ヘッダー要素をインスタンス化
			var go = Instantiate (headerItem_String, title);

			//inputFieldにsetterとgetterを紐付ける
			InputField input = go.GetComponentInChildren<InputField> ();
			input.text = getter ();
			input.onValueChanged.AddListener (setter);

			//ボタンを有効化.
			bool activeButton = !string.IsNullOrEmpty (buttonName);
			Button button = go.GetComponentInChildren<Button> ();
			button.gameObject.SetActive (activeButton);

			//ボタンコールバックを設定.
			if (activeButton) {
				button.onClick.AddListener (buttonAction);
				button.onClick.AddListener (() => input.text = getter ());
				button.GetComponentInChildren<Text> ().text = buttonName;
			}
		}


		/// <summary>
		/// ヘッダー要素にboolを追加.
		/// setterとgetterにより、変数やプロパティなどに紐付けできます.
		/// </summary>
		/// <param name="title">要素タイトル.</param>
		/// <param name="getter">getter.</param>
		/// <param name="setter">setter.</param>
		protected void RegisterBool (string title, Func<bool> getter, UnityAction<bool> setter)
		{
			//ヘッダー要素をインスタンス化
			var go = Instantiate (headerItem_Bool, title);

			//トグルにsetterとgetterを紐づける
			Toggle toggle = go.GetComponentInChildren<Toggle> ();
			toggle.isOn = getter ();
			toggle.onValueChanged.AddListener (setter);
		}


		public void RevealInFinder (string path)
		{
#if UNITY_EDITOR
			FileInfo fi = new FileInfo (Path.Combine (Application.dataPath, path));
			if (fi.Exists) {
				UnityEditor.EditorUtility.RevealInFinder (fi.FullName);
			} else if (Directory.Exists (fi.DirectoryName)) {
				UnityEditor.EditorUtility.RevealInFinder (fi.DirectoryName);
			}
#endif
		}
	}


	/// <summary>
	/// エコーテスト.
	/// リクエストしたbodyをそのまま返します.
	/// MsgPackを含む、シリアライズ・デシリアライズテストに利用できます.
	/// </summary>
	[Serializable]
	public class EchoRequestResponsePacket : ApiRequest<EchoRequestResponsePacket,EchoRequestResponsePacket>, IResponsePacket
	{
		public override string url{ get { return "https://api.sand.mbl.mobcast.io/mbl/api/debug/echo"; } }

		public override bool usePostMethod{ get { return true; } }

		public void OnAfterDeserialize (ApiResponseMeta header)
		{
		}

		[Serializable]
		public class EchoObject
		{
			[MessagePackMember (0)]
			[SerializeField]
			public ApiErrorCode code;

			[MessagePackMember (2)]
			[SerializeField]
			public string msg;

			[MessagePackMember (2)]
			[SerializeField]
			public long requestId;

			[MessagePackMember (3)]
			[SerializeField]
			public bool isNewSession;
		}

		[MessagePackMember (0)]
		[SerializeField]
		public string message;

		[MessagePackMember (1)]
		[SerializeField]
		public EchoObject nestedObject = new EchoObject ();

		[MessagePackMember (2)]
		[SerializeField]
		public bool flag;

		[MessagePackMember (3)]
		[SerializeField]
		public List<EchoObject> listedObject = new List<EchoObject> () {
			new EchoObject (){ requestId = 1 },
			new EchoObject (){ requestId = 2 }
		};
	}
}