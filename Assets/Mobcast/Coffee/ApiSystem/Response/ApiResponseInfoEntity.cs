using System;
using MsgPack.Serialization;
using UnityEngine;
using Mobcast.Coffee.Api;


namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// APIレスポンス基本情報エンティティ
	/// </summary>
	[Serializable]
	public class ApiResponseInfoEntity : IResponsePacket
	{
		#region private properties

		/// <summary>
		/// API処理結果(0:正常、その他:エラー)
		/// </summary>
		[MessagePackMember (0)]
		[SerializeField]
		public ApiErrorCode code;

		/// <summary>
		/// API処理結果メッセージ(エラー時のみ)
		/// </summary>
		[MessagePackMember (1)]
		[SerializeField]
		public string msg;

		/// <summary>
		/// エラー時のCSトラッキング用
		/// </summary>
		[MessagePackMember (2)]
		[SerializeField]
		public string requestId;

		/// <summary>
		/// 新しいセッションIDか
		/// </summary>
		[MessagePackMember (3)]
		[SerializeField]
		public bool isNewSession;

		/// <summary>
		/// セッションID
		/// </summary>
		[MessagePackMember (4)]
		[SerializeField]
		public string sessionId;

		/// <summary>
		/// トークン
		/// </summary>
		[MessagePackMember (5)]
		[SerializeField]
		public string token;

		/// <summary>
		/// サーバー日時(UNIXTIME)
		/// </summary>
		[MessagePackMember (6)]
		[SerializeField]
		public long serverTime;


		/// <summary>
		/// リトライ信号.
		/// </summary>
		[MessagePackMember (7)]
		[SerializeField]
		public bool isRetrySignal;


		#endregion

		#region public properties

		/// <summary>
		/// エラーかどうか.
		/// </summary>
		public bool IsError{ get { return code != ApiErrorCode.NONE; } }

		/// <summary>
		/// API処理結果(0:正常、その他:エラー)
		/// </summary>
		public ApiErrorCode Code{ get{return code;} }

		/// <summary>
		/// API処理結果メッセージ(エラー時のみ)
		/// </summary>
		public string Msg{ get{return msg;} }

		/// <summary>
		/// エラー時のCSトラッキング用
		/// </summary>
		public string RequestId{ get{return requestId;} }

		/// <summary>
		/// 新しいセッションIDか
		/// </summary>
		public bool IsNewSession{ get{return isNewSession;} }

		/// <summary>
		/// セッションID
		/// </summary>
		public string SessionId{ get{return sessionId;} }

		/// <summary>
		/// トークン
		/// </summary>
		public string Token{ get{return token;} }

		/// <summary>
		/// サーバー日時(UNIXTIME)
		/// </summary>
		public DateTime ServerDateTime{ get; protected set; }

		/// <summary>
		/// リトライ信号.
		/// </summary>
		public bool IsRetrySignal{ get{return isRetrySignal;} }

		#endregion

		/// <summary>
		/// デシリアライズに伴う処理を実行します.
		/// ResponsePacketContextを利用したタイムゾーンや言語の変換を追加できます.
		/// デシリアライズ結果がエラー扱いとしたい場合、APIExeption例外をスローするか、Info.codeを0以外に設定してください.
		/// </summary>
		/// <param name="header">Apiレスポンスヘッダ.</param>
		public void OnAfterDeserialize (ApiResponseMeta header)
		{
			ServerDateTime = serverTime.ToDateTime (header.timeZoneCode);
		}
	}
}
