using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// プラットフォームコード
	/// </summary>
	public enum PlatformCode
	{
		/// <summary>
		/// 不正値
		/// </summary>
		INVALID = -1,

		/// <summary>
		/// iPhone
		/// </summary>
		IPHONE = 0,

		/// <summary>
		/// Android
		/// </summary>
		ANDROID = 1,

		/// <summary>
		/// その他
		/// </summary>
		UNKNOWN = 99,
	}
}
