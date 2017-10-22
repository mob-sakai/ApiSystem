using Mobcast.Coffee.Api;
using System;
using UnityEngine;
using MsgPack.Serialization;

namespace Mobcast.Coffee.Api
{
	public interface IRequestPacket
	{
		/// <summary>APIリクエストURL.</summary>
		string url{ get; }

		/// <summary>リトライ回数.</summary>
		int retryCount{ get; }

		/// <summary>タイムアウト(秒).</summary>
		int timeout{ get; }

		/// <summary>PostMethodを利用するか.</summary>
		bool usePostMethod{ get; }

		/// <summary>レスポンスオブジェクト.</summary>
		object responseObject{ get; }
	}


	/// <summary>
	/// APIリクエスト.
	/// </summary>
	public abstract class ApiRequest<TRequest, TResponse> : IRequestPacket
		where TResponse: IResponsePacket
		where TRequest: ApiRequest<TRequest, TResponse>
	{
		/// <summary>
		/// このクラスのプロパティのMessagePack-IDの開始ID
		/// </summary>
		private const int START_MSG_PACK_MEMBER_ID = 0;

		/// <summary>
		/// このクラスのプロパティ数
		/// </summary>
		private const int NUM_PROPERTY_ID = 0;

		/// <summary>
		/// サブクラスのプロパティのMessagePack-IDの開始ID
		/// </summary>
		public const int START_SUBCLASS_MSG_PACK_MEMBER_ID = START_MSG_PACK_MEMBER_ID + NUM_PROPERTY_ID;

		/// <summary>APIリクエストURL.</summary>
		public abstract string url{ get; }

		/// <summary>リトライ回数.</summary>
		public virtual int retryCount{ get { return 3; } }

		/// <summary>タイムアウト(秒).</summary>
		public virtual int timeout{ get { return 60; } }

		/// <summary>PostMethodを利用するか.</summary>
		public virtual bool usePostMethod{ get { return false; } }


		/// <summary>
		/// レスポンスキャッシュ.
		/// 最後に成功したリクエストのレスポンスパケットを保持します.
		/// </summary>
		public static TResponse leatestResponse{ get; private set; }

		public TResponse response{ get; private set; }

		public object responseObject{ get{ return response;} }


		/// <summary>
		/// リクエストを実行します.
		/// </summary>
		/// <param name="onSuccess">成功時コールバック.</param>
		/// <param name="onError">失敗時コールバック.</param>
		public ApiOperation Request (Action<TResponse> onSuccess = null, Action<WebRequestErrorException> onError = null)
		{
			return ApiManager.Request<TRequest,TResponse> (this as TRequest, onSuccess, onError);
		}

		public virtual void UpdateResponse(TResponse resObj)
		{
			leatestResponse =resObj;
			response =resObj;
		}
	}
}