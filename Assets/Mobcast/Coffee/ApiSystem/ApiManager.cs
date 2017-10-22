using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using System.IO;
using MsgPack.Serialization;

namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// APIマネージャ.
	/// </summary>
	public class ApiManager : MonoSingleton<ApiManager>
	{
		/// <summary>
		/// APIリクエストのメタ情報です.
		/// リクエストヘッダへ、自動的に追加されます.
		/// </summary>
		public static ApiRequestMeta requestMeta{ get; protected set; }

		/// <summary>
		/// APIレスポンスのメタ情報です.
		/// </summary>
		public static ApiResponseMeta responseMeta{ get; protected set; }

		/// <summary>
		/// 通信がビジー中かどうかを返します.
		/// </summary>
		public static bool isBusy{ get { return 0 != m_InProgressOperations.Count; } }

		/// <summary>
		/// 通信オペレーション.
		/// </summary>
		public static List<ApiOperation> m_InProgressOperations = new List<ApiOperation> ();

		static readonly StringBuilder s_Json = new StringBuilder();

		void Update ()
		{
			// Update in-progress operations
			for (int i = 0; i < m_InProgressOperations.Count;) {
				var operation = m_InProgressOperations [i];
				if (operation.Update ())
					return;

				operation.Dispose ();
				m_InProgressOperations.RemoveAt (i);
			}
		}

		/// <summary>
		/// リクエストメタデータを利用してAPIマネージャを初期化します.
		/// リクエストメタデータには、ユーザーデータや言語など、APIに必要なデータが含まれます.
		/// </summary>
		public static void Initialize (ApiRequestMeta meta)
		{
			requestMeta = meta;
			responseMeta = new ApiResponseMeta ();
		}

		/// <summary>
		/// リクエストを実行します.
		/// </summary>
		/// <param name="apiRequest">APIリクエストオブジェクト.</param>
		/// <param name="onSuccess">On success.</param>
		/// <param name="onError">On error.</param>
		/// <typeparam name="TRequest">The 1st type parameter.</typeparam>
		/// <typeparam name="TResponse">The 2nd type parameter.</typeparam>
		public static ApiOperation Request<TRequest,TResponse> (TRequest apiRequest, Action<TResponse> onSuccess = null, Action<WebRequestErrorException> onError = null)
			where TResponse: IResponsePacket
			where TRequest: ApiRequest<TRequest,TResponse>
		{
			// 新しいoperationを生成.
			byte[] data = apiRequest.usePostMethod ? Serialize<TRequest> (apiRequest) : null;
			var op = new ApiOperation (apiRequest, requestMeta, data);
			op.onNetworkEnd += (req, obj) => {

				// webエラーの場合、エラー判定.
				if(!string.IsNullOrEmpty(op.error))
				{
					var reqEx = new WebRequestErrorException(req.responseCode, op.error);
					Debug.LogErrorFormat ("[ApiOperation] Api通信 失敗(レスポンスエラー:{0})<{1}> : {2}", reqEx.StatusCode, apiRequest.GetType(), reqEx);
					if (onError != null)
						onError (reqEx);
					return;
				}
					

				// レスポンスメタデータを更新.
				responseMeta.FromDictionary (req.GetResponseHeaders ());

				// パケットのデシリアライズを実行.
				TResponse res = Deserialize<TResponse> (req.downloadHandler.data);
				res.OnAfterDeserialize (responseMeta);

				// リクエストメタデータのセッション情報を更新.
				ApiResponsePacket apiResponsePacket = res as ApiResponsePacket;
				if (apiResponsePacket != null)
				{
					// レスポンス内部パケットエラーの場合、エラー判定.
					if(apiResponsePacket.Info.Code != ApiErrorCode.NONE)
					{
						var reqEx = new WebRequestErrorException((long)apiResponsePacket.Info.Code, apiResponsePacket.Info.Msg);
						Debug.LogErrorFormat ("[ApiOperation] Api通信 失敗(パケットエラー:{0})<{1}> : {2}", reqEx.StatusCode, apiRequest.GetType(), reqEx);
						op.error = reqEx.Message;
						if (onError != null)
							onError (reqEx);
						return;
					}

					requestMeta.UpdateSession (apiResponsePacket.Info);
					ApiTimeUtil.SetServerTime(apiResponsePacket.Info.serverTime);
				}

				apiRequest.UpdateResponse (res);

				if (onSuccess != null) {
					onSuccess (res);
				}
			};
			
			m_InProgressOperations.Add (op);
			return op;
		}

		/// <summary>
		/// 指定オブジェクトをシリアライズし、バイト配列に変換します.
		/// ApiHeaderは変換に必要な情報(パケットプロトコルタイプ、暗号化の有無)が格納されています.
		/// </summary>
		/// <param name="data">APIレスポンスデータ</param>
		/// <returns>ResponsePacketオブジェクト</returns>
		static byte[] Serialize<T> (T obj)
		{
			// MsgPackの場合はMsgPackパーサー、Jsonの場合はJsonUtilityを使ってシリアライズ.
			byte[] data = requestMeta.packetProtocolCode == PacketProtocolCode.MSG_PACK
				? ObjectParser.SerializeToMsgPack (obj)
				: ObjectParser.SerializeToJson (obj);

			Debug.LogFormat ("シリアライズデータ({2}) : {0}\n{1}", typeof(T), ToJson (data, requestMeta.packetProtocolCode == PacketProtocolCode.JSON), requestMeta.packetProtocolCode);

			// 暗号化指定されている場合は暗号化.
			if (requestMeta.packetEncryptCode == PacketEncryptCode.ON)
				data = ObjectParser.Encrypt (data, requestMeta.key, requestMeta.iv);

			//TODO: JSON BASE64変換不要なら外す.
			// JSON BASE64変換
			if (requestMeta.packetEncryptCode == PacketEncryptCode.ON && requestMeta.packetProtocolCode == PacketProtocolCode.JSON)
				data = Encoding.UTF8.GetBytes (Convert.ToBase64String (data));
			
			return data;
		}

		/// <summary>
		/// バイト配列をデシリアライズし、ApiResponsePacketに変換します.
		/// ApiHeaderは変換に必要な情報(パケットプロトコルタイプ、暗号化の有無)が格納されています.
		/// デシリアライズ結果がエラー扱いの場合はApiException例外がスローされます.
		/// </summary>
		/// <param name="data">APIレスポンスデータ</param>
		/// <returns>ResponsePacketオブジェクト</returns>
		static T Deserialize<T> (byte[] data)
		{
			//TODO: JSON BASE64変換不要なら外す.
			// JSON BASE64変換
			if (requestMeta.packetEncryptCode == PacketEncryptCode.ON && requestMeta.packetProtocolCode == PacketProtocolCode.JSON)
				data = Convert.FromBase64String (Encoding.UTF8.GetString (data));

			// 暗号化指定されている場合は復号化.
			if (requestMeta.packetEncryptCode == PacketEncryptCode.ON)
				data = ObjectParser.Decrypt (data, requestMeta.key, requestMeta.iv);

			Debug.LogFormat ("デシリアライズデータ({2}) : {0}\n{1}", typeof(T), ToJson (data, requestMeta.packetProtocolCode == PacketProtocolCode.JSON), requestMeta.packetProtocolCode);

			// MsgPackの場合はMsgPackパーサー、Jsonの場合はJsonUtilityを使ってデシリアライズ.
			T obj = requestMeta.packetProtocolCode == PacketProtocolCode.MSG_PACK
				? ObjectParser.DeserializeFromMsgPack<T> (data)
				: ObjectParser.DeserializeFromJson<T> (data);

			return obj;
		}
		
		public static string ToJson (byte[] data, bool isJson)
		{
			s_Json.Length = 0;
			s_Json.Append(
				isJson
				? Encoding.UTF8.GetString(data)
				: MessagePackSerializer.UnpackMessagePackObject (data)
			);

			if(5000 < s_Json.Length)
			{
				s_Json.Length = 5000;
				s_Json.Append("...");
			}
			return s_Json.ToString();
		}
	}

	[Serializable]
	public class WebRequestErrorException : Exception
	{
		public readonly string Text;

		public readonly HttpStatusCode StatusCode;

		public WebRequestErrorException (long responseCode, string text)
		{
			this.Text = text; 
			this.StatusCode = (HttpStatusCode)responseCode;
		}

		public override string ToString ()
		{
			return string.Format ("{0} : {1}", StatusCode, Text);
		}

		public override string Message { get { return ToString (); } }
	}
}