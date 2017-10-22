using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// 血液型コード
	/// </summary>
	public enum BloodTypeCode
	{
		/// <summary>
		/// 不正値
		/// </summary>
		INVALID	= -1,

		/// <summary>
		/// 不明
		/// </summary>
		UNKNOWN	= 0,

		/// <summary>
		/// A
		/// </summary>
		A		= 1,

		/// <summary>
		/// B
		/// </summary>
		B		= 2,

		/// <summary>
		/// O
		/// </summary>
		O		= 3,

		/// <summary>
		/// AB
		/// </summary>
		AB		= 4,
	}
}
