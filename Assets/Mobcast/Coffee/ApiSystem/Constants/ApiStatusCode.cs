using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// APIレスポンスのHTTPステータスコード
	/// </summary>
	public enum ApiStatusCode
	{
		/// <summary>
		/// OK
		/// </summary>
		OK					= 200,

		/// <summary>
		/// クライアントエラー
		/// </summary>
		CLIENET_ERROR		= 400,

		/// <summary>
		/// サーバーエラー
		/// </summary>
		SERVER_ERROR		= 500,

		/// <summary>
		/// メンテナンス
		/// </summary>
		SERVICE_UNAVAILABLE	= 503,
	}
}
