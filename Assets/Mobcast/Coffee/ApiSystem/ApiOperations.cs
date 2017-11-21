using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Networking;
using Object = UnityEngine.Object;
using System.Text;
using System.Net;

namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// Asset operation.
	/// </summary>
	public class ApiOperation : CustomYieldInstruction, IDisposable
	{
		protected const string kLog = "[ApiManager] ";

		IRequestPacket m_RequestPacket;

		ApiRequestMeta m_RequestMeta;

		byte[] m_Data;

		UnityWebRequest m_webRequest;

		/// <summary>Error message.</summary>
		public string error { get; set; }

		int m_TriableCount;
		float m_StartableTime;
		int m_NetworkTimeout;

		public event System.Action<UnityWebRequest, IRequestPacket> onNetworkEnd;
		public System.Action onSuccess;

		public override bool keepWaiting { get { return m_webRequest != null || 0 < m_TriableCount; } }

		public ApiOperation(IRequestPacket apiRequest, ApiRequestMeta requestMeta, byte[] data, int retryCount, int networkTimeout)
		{
			m_RequestPacket = apiRequest;
			m_RequestMeta = requestMeta;
			m_Data = data;
			m_NetworkTimeout = networkTimeout;
			m_TriableCount = Mathf.Max(0, retryCount) + 1;
			m_StartableTime = 0;
			Debug.LogFormat("[ApiOperation] Api通信をキューに追加<{0}>  : url = {1}", apiRequest.GetType(), apiRequest.url);
		}

		public bool UpdateAndNeedKeep()
		{
			// 開始ディレイ
			if (0 < m_StartableTime - Time.realtimeSinceStartup)
			{
				return true;
			}

			// 通信前なのでsend.
			if (m_webRequest == null)
			{

				//WebRequest生成.
				m_webRequest = m_RequestPacket.usePostMethod
					? new UnityWebRequest(m_RequestPacket.url, UnityWebRequest.kHttpVerbPOST, new DownloadHandlerBuffer(), new UploadHandlerRaw(m_Data))
					: UnityWebRequest.Get(m_RequestPacket.url);

				// リクエストヘッダを設定.
				var reqHeaders = m_RequestMeta.ToDictionary();
				foreach (var pair in reqHeaders)
				{
					if (!string.IsNullOrEmpty(pair.Value))
						m_webRequest.SetRequestHeader(pair.Key, pair.Value);
				}

				m_TriableCount--;
				m_StartableTime = Time.realtimeSinceStartup;
				#if UNITY_5_6_OR_NEWER
				m_webRequest.timeout = m_NetworkTimeout;
				#endif

				m_webRequest.Send();
				Debug.LogFormat("[ApiOperation] Api通信開始<{0}> : url = {1}\nRequestHeaders = {2}\n\nBody = {3}"
					, m_RequestPacket.GetType()
					, m_webRequest.url
					, Dump(reqHeaders)
					, m_Data != null ? Encoding.UTF8.GetString(m_Data) : ""
				);
			}

			// 通信中...
			if (!m_webRequest.isDone && (Time.realtimeSinceStartup - m_StartableTime) < (m_NetworkTimeout + 1))
			{
				return true;
			}

			// 通信完了.
			if (m_webRequest.isDone)
			{
				if (!string.IsNullOrEmpty(m_webRequest.error))
				{
					error = m_webRequest.error;
				}
				else if ((HttpStatusCode)m_webRequest.responseCode != HttpStatusCode.OK)
				{
					error = "error: " + m_webRequest.responseCode;
				}
			}
			// タイムアウト.
			else
			{
				error = "Timeout";
			}

			// 失敗したがリトライ可能ならリトライ.
			bool success = string.IsNullOrEmpty(error);
			if (!success && 0 < m_TriableCount)
			{
				Debug.LogWarningFormat("[ApiOperation] Api通信をリトライ(残りトライ回数 = {0}, 経過時間 = {1})<{2}> : url = {3}\nstatus = {4}, error = {5}"
					, m_TriableCount
					, Time.realtimeSinceStartup - m_StartableTime
					, m_RequestPacket.GetType()
					, m_webRequest.url
					, m_webRequest.responseCode
					, error
				);
				
				// 一応Webリクエストをキャンセル
				m_webRequest.Abort();
				m_webRequest.Dispose();
				m_webRequest = null;
				
				// ディレイさせてから再実行.
				m_StartableTime = Time.realtimeSinceStartup + 1;
				return true;
			}

			try
			{
				//レスポンスロガー.
				Debug.LogFormat("[ApiOperation] Api通信完了(成功 = {0}, 経過時間 = {1})<{2}> : url = {3}, status = {4}\nResponseHeaders = {5}\n\nBody = {6}"
					, success
					, Time.realtimeSinceStartup - m_StartableTime
					, m_RequestPacket.GetType()
					, m_webRequest.url
					, m_webRequest.responseCode
					, Dump(m_webRequest.GetResponseHeaders())
					, m_webRequest.downloadHandler.text
				);

				onNetworkEnd(m_webRequest, m_RequestPacket);
			}
			catch (System.Exception ex)
			{
				Debug.LogErrorFormat("[ApiOperation] Api通信 失敗(コールバックエラー)<{0}> : {1}", m_RequestPacket.GetType(), ex);
				error = ex.Message;
			}

			Debug.LogFormat("[ApiOperation] 処理完了(経過時間 = {0})<{1}>"
				, Time.realtimeSinceStartup - m_StartableTime
				, m_RequestPacket.GetType()
			);
			return false;
		}

		public void Dispose()
		{
			if (m_webRequest != null)
			{
				m_webRequest.Abort();
				m_webRequest.Dispose();
			}
			m_webRequest = null;
			onNetworkEnd = null;
		}

		static string Dump(Dictionary<string,string> dic)
		{
			if (dic == null || dic.Count == 0)
				return string.Empty;
			
			return dic.Aggregate(new StringBuilder(), (a, b) => a.AppendFormat("[{0}:{1}], ", b.Key, b.Value), a => a.ToString());
		}
	}
}