using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// システムエラーコード
	///       1 - 89999 : アプリケーション用エラーコード
	///   90000 - 90099 : システムエラーコード
	///   90100 - 99999 : 共通エラーコード
	/// </summary>
	public enum SystemErrorCode
	{
		/// <summary>
		/// エラーなし
		/// </summary>
		NONE			= 0,

		/// <summary>
		/// 未定義エラー、不明なエラー
		/// </summary>
		UNKNOWN			= 90000,

		/// <summary>
		/// 致命的なエラー
		/// </summary>
		FATAL			= 90001,

		/// <summary>
		/// サーバーエラー
		/// </summary>
		SERVER_ERROR	= 90002,

		/// <summary>
		/// デバッグ環境でのみ動く処理を、本番環境で動かそうとした
		/// </summary>
		NOT_DEBUG		= 90003,

		/// <summary>
		/// 奨励されないLockModeやLockOptionsを指定した
		/// </summary>
		DB_LOCKMODE		= 90004,

		/// <summary>
		/// SlaveのDBにアクセスしているのにupdateやinsertしようとした
		/// </summary>
		DB_UPDATE_SLAVE	= 90005,

		/// <summary>
		/// DBTypes使用宣言時の誤り
		/// </summary>
		DB_TYPE			= 90006,

		/// <summary>
		/// タイムアウト
		/// </summary>
		TIMEOUT			= 90007,
	}
}
