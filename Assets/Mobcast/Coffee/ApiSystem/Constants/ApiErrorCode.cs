using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// APIリクエストエラーコード
	///   内訳は、SystemErrorCodeを参照
	/// </summary>
	public enum ApiErrorCode
	{
		/// <summary>
		/// エラーなし
		/// </summary>
		NONE						= SystemErrorCode.NONE,

		/// <summary>
		/// 致命的なエラー
		/// </summary>
		FATAL						= 90100,

		/// <summary>
		/// パラメータ不足
		/// </summary>
		INVALID_PARAM				= 90101,

		/// <summary>
		/// 不正なパケット
		/// </summary>
		INVALID_PACKET				= 90102,

		/// <summary>
		/// 不正なパケット値
		/// </summary>
		INVALID_PACKET_VARIABLE		= 90103,

		/// <summary>
		/// 不正なIP
		/// </summary>
		INVALID_IP					= 90104,

		/// <summary>
		/// Sessionエラー
		/// </summary>
		SESSION						= 90105,

		/// <summary>
		/// Session取得エラー
		/// </summary>
		SESSION_GET_ERROR			= 90106,

		/// <summary>
		/// Session保存エラー
		/// </summary>
		SESSION_SET_ERROR			= 90107,

		/// <summary>
		/// Session取得エラー(再ログイン)
		/// </summary>
		SESSION_EMPTY				= 90108,

		/// <summary>
		/// Tokenエラー
		/// </summary>
		TOKEN						= 90109,

		/// <summary>
		/// Pidエラー
		/// </summary>
		ILLEGAL_PID_ACCESS			= 90110,
	}
}
