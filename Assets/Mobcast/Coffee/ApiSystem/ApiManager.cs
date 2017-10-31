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
using UnityEngine.Profiling;

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
		public static ApiRequestMeta requestMeta { get; protected set; }

		/// <summary>
		/// APIレスポンスのメタ情報です.
		/// </summary>
		public static ApiResponseMeta responseMeta { get; protected set; }

		/// <summary>
		/// 通信がビジー中かどうかを返します.
		/// </summary>
		public static bool isBusy { get { return 0 != instance.m_InProgressOperations.Count; } }

		/// <summary>
		/// 現在通信中のオペレーション.
		/// </summary>
		List<ApiOperation> m_InProgressOperations = new List<ApiOperation>();

		/// <summary>
		/// オペレーションリトライ回数.
		/// ネットワーク接続エラー等に対するリトライ回数を設定します.
		/// </summary>
		protected virtual int retryCount { get { return 3; } }

		/// <summary>
		/// ネットワークタイムアウト(秒)
		/// </summary>
		protected virtual int networkTimeout { get { return 10; } }

		static RijndaelManaged s_Aes;
		static ICryptoTransform s_Encryptor;
		static ICryptoTransform s_Decryptor;

		void Update()
		{
			if (m_InProgressOperations.Count == 0)
				return;

			var operation = m_InProgressOperations[0];
			if (operation.UpdateAndNeedKeep())
				return;

			operation.Dispose();
			m_InProgressOperations.RemoveAt(0);
		}

		/// <summary>
		/// リクエストメタデータを利用してAPIマネージャを初期化します.
		/// リクエストメタデータには、ユーザーデータや言語など、APIに必要なデータが含まれます.
		/// </summary>
		public static void Initialize(ApiRequestMeta meta)
		{
			requestMeta = meta;
			responseMeta = new ApiResponseMeta();
			instance.OnInitialize();
		}

		/// <summary>
		/// 暗号化キーと初期ベクトルを設定します.
		/// IVの変更が必要な場合、このメソッドを利用してください.
		/// </summary>
		public static void SetCryptoInfo(string key, string iv)
		{
			s_Aes = new RijndaelManaged();
			s_Aes.BlockSize = 128;
			s_Aes.KeySize = 128;
			s_Aes.Padding = PaddingMode.ISO10126;
			s_Aes.Mode = CipherMode.CBC;
			s_Aes.Key = Encoding.UTF8.GetBytes(key);
			s_Aes.IV = Encoding.UTF8.GetBytes(iv);

			if (s_Encryptor != null)
			{
				s_Encryptor.Dispose();
				s_Decryptor.Dispose();
			}

			s_Encryptor = s_Aes.CreateEncryptor();
			s_Decryptor = s_Aes.CreateDecryptor();
		}

		/// <summary>
		/// 初期化コールバック.
		/// </summary>
		protected virtual void OnInitialize()
		{
		}

		/// <summary>
		/// エラーコールバック.
		/// 503エラー時はメンテンナンス画面を出す等、プロジェクト毎の処理を追加してください.
		/// コールバック内で例外をスローすることで、ApiOperationのエラーコールバックをスルーできます.
		/// </summary>
		protected virtual void OnError(WebRequestErrorException ex)
		{
		}

		/// <summary>
		/// リクエストを実行します.
		/// </summary>
		/// <param name="apiRequest">APIリクエストオブジェクト.</param>
		/// <param name="onSuccessCallback">On success.</param>
		/// <param name="onErrorCallback">On error.</param>
		/// <typeparam name="TRequest">The 1st type parameter.</typeparam>
		/// <typeparam name="TResponse">The 2nd type parameter.</typeparam>
		public static ApiOperation Request<TRequest,TResponse>(TRequest apiRequest, Action<TResponse> onSuccessCallback = null, Action<WebRequestErrorException> onErrorCallback = null)
			where TResponse: class, IResponsePacket
			where TRequest: ApiRequest<TRequest,TResponse>
		{
			// 新しいoperationを生成. postメソッドの場合、送信するbyte配列を生成.
			byte[] data = apiRequest.usePostMethod ? Serialize(apiRequest) : null;
			var op = new ApiOperation(apiRequest, requestMeta, data, instance.retryCount, instance.networkTimeout);
			
			// ネットワーク処理完了 コールバック.
			// ネットワークリクエストが失敗/成功した時にコールされます.
			// レスポンスコードやエラーメッセージによって、オペレーションコールバックをこーるします.
			op.onNetworkEnd += (req, obj) =>
			{

				// webエラーの場合、エラー判定.
				if (!string.IsNullOrEmpty(op.error))
				{
					var reqEx = new WebRequestErrorException(req.responseCode, op.error);
					Debug.LogErrorFormat("[ApiOperation] Api通信 失敗(ステータス:{0})<{1}> : {2}", reqEx.StatusCode, apiRequest.GetType(), reqEx);
					
					// APIマネージャー側 エラーコールバック
					instance.OnError(reqEx);
					
					// オペレーション側 エラーコールバック
					if (onErrorCallback != null)
						onErrorCallback(reqEx);
					return;
				}
					

				// レスポンスメタデータを更新.
				responseMeta.FromDictionary(req.GetResponseHeaders());

				// パケットのデシリアライズを実行.
				TResponse res = Deserialize(req.downloadHandler.data, typeof(TResponse)) as TResponse;
				res.OnAfterDeserialize(responseMeta);

				// リクエストメタデータのセッション情報を更新.
				ApiResponsePacket apiResponsePacket = res as ApiResponsePacket;
				if (apiResponsePacket != null)
				{
					// レスポンス内部パケットエラーの場合、エラー判定.
					if (apiResponsePacket.Info.Code != ApiErrorCode.NONE)
					{
						var reqEx = new WebRequestErrorException((long)apiResponsePacket.Info.Code, apiResponsePacket.Info.Msg);
						Debug.LogErrorFormat("[ApiOperation] Api通信 失敗(内部パケットエラー:{0})<{1}> : {2}", reqEx.StatusCode, apiRequest.GetType(), reqEx);
						op.error = reqEx.Message;
						
						// APIマネージャー側エラーコールバック
						instance.OnError(reqEx);
					
						// オペレーション側 エラーコールバック
						if (onErrorCallback != null)
							onErrorCallback(reqEx);
						return;
					}

					requestMeta.UpdateSession(apiResponsePacket.Info);
					ApiTimeUtil.SetServerTime(apiResponsePacket.Info.serverTime);
				}

				apiRequest.UpdateResponse(res);
				
				// オペレーション側 成功コールバック
				if (onSuccessCallback != null)
				{
					onSuccessCallback(res);
				}
			};

			// オペレーションをキューに追加.
			instance.m_InProgressOperations.Add(op);
			return op;
		}

		/// <summary>
		/// 指定オブジェクトをシリアライズし、バイト配列に変換します.
		/// ApiHeaderは変換に必要な情報(パケットプロトコルタイプ、暗号化の有無)が格納されています.
		/// </summary>
		/// <param name="data">APIレスポンスデータ</param>
		/// <returns>ResponsePacketオブジェクト</returns>
		public static byte[] Serialize(object obj)
		{
			Type type = obj.GetType();
			Profiler.BeginSample("Serialize" + type.Name);
			
			// MsgPackの場合はMsgPackパーサー、Jsonの場合はJsonUtilityを使ってシリアライズ.
			Profiler.BeginSample("Object Parse");
			byte[] data = requestMeta.packetProtocolCode == PacketProtocolCode.MSG_PACK
				? MessagePackSerializer.Get(type).PackSingleObject(obj)
				: Encoding.UTF8.GetBytes(JsonUtility.ToJson(obj));
			Profiler.EndSample();

			Debug.LogFormat("シリアライズデータ({2}) : {0}\n{1}", type, ToReadableText(data, requestMeta.packetProtocolCode == PacketProtocolCode.JSON), requestMeta.packetProtocolCode);

			// 暗号化指定されている場合はAES暗号化.
			if (requestMeta.packetEncryptCode == PacketEncryptCode.ON)
			{
				data = Encrypt(data);
			}

			//TODO: JSON BASE64変換不要なら外す.
			// JSON BASE64変換
			if (requestMeta.packetEncryptCode == PacketEncryptCode.ON && requestMeta.packetProtocolCode == PacketProtocolCode.JSON)
			{
				Profiler.BeginSample("Convert Base64");
				data = Encoding.UTF8.GetBytes(Convert.ToBase64String(data));
				Profiler.EndSample();
			}
			
			Profiler.EndSample();
			return data;
		}

		/// <summary>
		/// バイト配列をデシリアライズし、ApiResponsePacketに変換します.
		/// ApiHeaderは変換に必要な情報(パケットプロトコルタイプ、暗号化の有無)が格納されています.
		/// デシリアライズ結果がエラー扱いの場合はApiException例外がスローされます.
		/// </summary>
		/// <param name="data">APIレスポンスデータ</param>
		/// <returns>ResponsePacketオブジェクト</returns>
		public static object Deserialize(byte[] data, System.Type type)
		{
			Profiler.BeginSample("Deserialize" + type.Name);
			//TODO: JSON BASE64変換不要なら外す.
			// JSON BASE64変換
			if (requestMeta.packetEncryptCode == PacketEncryptCode.ON && requestMeta.packetProtocolCode == PacketProtocolCode.JSON)
			{
				Debug.LogFormat("Base64({0}) : {1}", type, Encoding.UTF8.GetString(data));

				Profiler.BeginSample("Convert Base64");
				data = Convert.FromBase64String(Encoding.UTF8.GetString(data));
				Profiler.EndSample();
			}

			// 暗号化指定されている場合はAES復号化.
			if (requestMeta.packetEncryptCode == PacketEncryptCode.ON)
			{
				data = Decrypt(data);
			}

			Debug.LogFormat("デシリアライズデータ({2}) : {0}\n{1}", type, ToReadableText(data, requestMeta.packetProtocolCode == PacketProtocolCode.JSON), requestMeta.packetProtocolCode);

			// MsgPackの場合はMsgPackパーサー、Jsonの場合はJsonUtilityを使ってデシリアライズ.
			Profiler.BeginSample("Object Parse");
			object obj = requestMeta.packetProtocolCode == PacketProtocolCode.MSG_PACK
				? MessagePackSerializer.Get(type).UnpackSingleObject(data)
				: JsonUtility.FromJson(Encoding.UTF8.GetString(data), type);
			Profiler.EndSample();
				
			Profiler.EndSample();
			return obj;
		}

		public static byte[] Encrypt(byte[] data)
		{
			Profiler.BeginSample("Encrypt");
			data = s_Encryptor.TransformFinalBlock(data, 0, data.Length);
			Profiler.EndSample();
			return data;
		}

		public static byte[] Decrypt(byte[] data)
		{
			Profiler.BeginSample("Decrypt");
			data = s_Decryptor.TransformFinalBlock(data, 0, data.Length);
			Profiler.EndSample();
			return data;
		}

		public static string ToReadableText(byte[] data, bool isJson)
		{
			string txt = isJson
				? Encoding.UTF8.GetString(data)
				: MessagePackSerializer.UnpackMessagePackObject(data).ToString();
				
			int length = Mathf.Clamp(txt.Length, 0, 5000);
			
			return new StringBuilder(length).Append(txt, 0, length).ToString();
		}
	}

	[Serializable]
	public class WebRequestErrorException : Exception
	{
		public readonly string Text;

		public readonly HttpStatusCode StatusCode;

		public WebRequestErrorException(long responseCode, string text)
		{
			this.Text = text; 
			this.StatusCode = (HttpStatusCode)responseCode;
		}

		public override string ToString()
		{
			return string.Format("{0} : {1}", StatusCode, Text);
		}

		public override string Message { get { return ToString(); } }
	}
}