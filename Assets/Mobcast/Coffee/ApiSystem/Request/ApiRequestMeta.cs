using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using Mobcast.Coffee.Api;
using System.Text;

namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// APIリクエストメタデータ.
	/// API通信におけるメタデータを管理します.
	/// </summary>
	[System.Serializable]
	public class ApiRequestMeta : ApiResponseMeta, ISerializationCallbackReceiver
	{

		/// <summary>
		/// プラットフォーム.
		/// </summary>
		public PlatformCode platformCode { get { return m_Platform; } set { m_Platform = value; } }

		[SerializeField] PlatformCode m_Platform = PlatformCode.UNKNOWN;

		/// <summary>
		/// AES Key.
		/// </summary>
		public string key { get { return m_Key; } set { m_Key = value; } }

		[SerializeField] string m_Key;

		/// <summary>
		/// AES IV.
		/// </summary>
		public string iv { get { return m_IV; } private set { m_IV = value; } }

		[SerializeField] string m_IV;

		/// <summary>
		/// AES Key.
		/// </summary>
		public string uid {
			get { return m_Uid; }
			set {
				m_Uid = value;

				//ivを自動的に更新.
				if (value == null)
					value = "";

				value = value.PadRight (8, '0');

				int maxSize = value.Length;
				int half = maxSize - (maxSize / 2);

				iv = new StringBuilder (16)
					.Append (value.Substring (half - 4, 4)) 
					.Append (value.Substring (0, 4))
					.Append (value.Substring (maxSize - 4, 4))
					.Append (value.Substring (half - 2, 4))
					.ToString ();
			}
		}
		[SerializeField] string m_Uid;

		/// <summary>
		/// プレイヤーID.
		/// </summary>
		public string playerId { get { return m_PlayerId; } set { m_PlayerId = value; } }
		[SerializeField] string m_PlayerId;

		/// <summary>
		/// アプリID.
		/// </summary>
		public string appId { get { return m_AppId; } set { m_AppId = value; } }
		[SerializeField] string m_AppId;

		/// <summary>
		/// アプリバージョン
		/// </summary>
		public string appVersion { get { return m_AppVersion; } set { m_AppVersion = value; } }
		[SerializeField] string m_AppVersion;

		/// <summary>
		/// マスタデータバージョン
		/// </summary>
		public string masterDataVersion { get { return m_MasterDataVersion; } set { m_MasterDataVersion = value; } }
		[SerializeField] string m_MasterDataVersion;

		/// <summary>
		/// リソースバージョン
		/// </summary>
		public string resourceVersion { get { return m_ResourceVersion; } set { m_ResourceVersion = value; } }
		[SerializeField] string m_ResourceVersion;

		/// <summary>
		/// エラー時のCSトラッキング用リクエストID
		/// </summary>
		public string requestId { get; set; }

		/// <summary>
		/// セッションID
		/// </summary>
		public string sessionId { get { return m_SessionId; } set { m_SessionId = value; } }
		[SerializeField] string m_SessionId;

		/// <summary>
		/// トークン
		/// </summary>
		public string token { get { return m_Token; } set { m_Token = value; } }
		[SerializeField] string m_Token;

		readonly Dictionary<string,string> headers = new Dictionary<string, string> ();


		#region debug-feature

		/// <summary>
		/// [debug] 強制エラーコード.
		/// </summary>
		public int debugErrorCode { get { return m_DebugErrorCode; } set { m_DebugErrorCode = value; } }
		[SerializeField] int m_DebugErrorCode;


		/// <summary>
		/// [debug] 応答遅延.
		/// </summary>
		public int debugResponseDelay { get { return m_DebugResponseDelay; } set { m_DebugResponseDelay = value; } }
		[SerializeField] int m_DebugResponseDelay;

		#endregion  debug-feature

		/// <summary>
		/// セッション情報を更新します.
		/// </summary>
		/// <param name="info">Info.</param>
		public void UpdateSession (ApiResponseInfoEntity info)
		{
			if (info.IsNewSession) {
				sessionId = info.SessionId;
			}
			if (!string.IsNullOrEmpty(info.Token)){
				token = info.Token;
			}
		}

		/// <summary>
		/// Dictionaryに変換します.
		/// </summary>
		public virtual Dictionary<string,string> ToDictionary ()
		{
			string value = string.Empty;
			headers.Clear ();

			// コンテンツタイプコード
			if(CodeConvertion.ContentTypeNameMap.TryGetValue(contentTypeCode, out value))
				headers [ApiConstants.HEADER_KEY_CONTENT_TYPE] = value;

			// 言語コード
			if(CodeConvertion.languageNameMap.TryGetValue(languageCode, out value))
				headers [ApiConstants.HEADER_KEY_LANGUAGE_CODE] = value;

			//プラットフォーム
			if(CodeConvertion.platformNameMap.TryGetValue(platformCode, out value))
				headers [ApiConstants.HEADER_KEY_PLATFORM] = value;

			//アプリID
			headers [ApiConstants.HEADER_KEY_APP_ID] = appId;

			//アプリバージョン
			headers [ApiConstants.HEADER_KEY_APP_VERSION] = appVersion;

			//マスタデータバージョン
			headers [ApiConstants.HEADER_KEY_MASTER_DATA_VERSION] = masterDataVersion;

			//リソースバージョン
			headers [ApiConstants.HEADER_KEY_RESOURCE_VERSION] = resourceVersion;

			//パケットプロトコル
			if(CodeConvertion.PacketProtocolNameMap.TryGetValue(packetProtocolCode, out value))
				headers [ApiConstants.HEADER_KEY_PACKET_PROTOCOL] = value;

			//パケット暗号化
			if(CodeConvertion.PacketEncryptNameMap.TryGetValue(packetEncryptCode, out value))
				headers [ApiConstants.HEADER_KEY_PACKET_ENCRYPT] = value;

			//uid
			headers [ApiConstants.HEADER_KEY_UID] = uid;

			//プレイヤーID
			headers [ApiConstants.HEADER_KEY_PLAYER_ID] = playerId;

			//セッションID
			headers [ApiConstants.HEADER_KEY_SESSION_ID] = sessionId;

			//アクセストークン
			headers [ApiConstants.HEADER_KEY_TOKEN] = token;


			#region debug-feature

			// [debug] 強制エラーコード.
			if (0 < debugErrorCode)
				headers [ApiConstants.HEADER_KEY_DEBUG_ERROR_CODE] = debugErrorCode.ToString();

			// [debug] 応答遅延.
			if (0 < debugResponseDelay)
				headers [ApiConstants.HEADER_KEY_DEBUG_RESPONSE_DELAY] = debugResponseDelay.ToString ();

			#endregion


			return headers;
		}

		public virtual void OnBeforeSerialize ()
		{
		}

		public virtual void OnAfterDeserialize ()
		{
			uid = m_Uid;
		}
	}
}