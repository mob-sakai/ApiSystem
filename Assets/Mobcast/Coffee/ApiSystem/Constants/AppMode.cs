using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// アプリケーションサービスモード
	/// </summary>
	public enum AppMode
	{
		/// <summary>
		/// 不正値
		/// </summary>
		INVALID,

		/// <summary>
		/// サービス中
		/// </summary>
		SERVICE,

		/// <summary>
		/// 臨時メンテナンス
		/// </summary>
		MAINTENANCE,

		/// <summary>
		/// 定期メンテナンス
		/// </summary>
		SCHEDULED_MAINTENANCE,

		/// <summary>
		/// 緊急メンテナンス
		/// </summary>
		EXTRA_MAINTENANCE
	}
}
