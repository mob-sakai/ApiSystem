using Mobcast.Coffee.Api;
using System;
using UnityEngine;
using MsgPack.Serialization;

namespace Mobcast.Coffee.Api
{
	public interface IRequestPacket
	{
		/// <summary>APIリクエストURL.</summary>
		string url { get; }

		/// <summary>PostMethodを利用するか.</summary>
		bool usePostMethod { get; }

		/// <summary>レスポンスオブジェクト.</summary>
		object responseObject { get; }

		/// <summary>リクエストメタデータ.Api毎にオーバーロードが可能です.デフォルトでは、ApiManager.requestMetaを利用します.</summary>
		ApiRequestMeta meta { get; }
	}


	/// <summary>
	/// APIリクエスト.
	/// </summary>
	public abstract class ApiRequest<TRequest, TResponse> : IRequestPacket
		where TResponse: class, IResponsePacket
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
		public abstract string url { get; }

		/// <summary>PostMethodを利用するか.</summary>
		public virtual bool usePostMethod { get { return false; } }

		/// <summary>リクエストメタデータ.Api毎にオーバーロードが可能です.デフォルトでは、ApiManager.requestMetaを利用します.</summary>
		public virtual ApiRequestMeta meta { get { return ApiManager.requestMeta; } }

		/// <summary>
		/// レスポンスキャッシュ.
		/// 最後に成功したリクエストのレスポンスパケットを保持します.
		/// </summary>
		public static TResponse leatestResponse { get; private set; }

		public TResponse response { get; private set; }

		public object responseObject { get { return response; } }

		/// <summary>
		/// リクエストを実行します.
		/// </summary>
		/// <param name="onSuccess">成功時コールバック.</param>
		/// <param name="onError">失敗時コールバック.</param>
		public ApiOperation Request(Action<TResponse> onSuccess = null, Action<WebRequestErrorException> onError = null)
		{
			return ApiManager.Request<TRequest,TResponse>(this as TRequest, onSuccess, onError);
		}

		public virtual void UpdateResponse(TResponse resObj)
		{
			leatestResponse = resObj;
			response = resObj;
		}
	}
}