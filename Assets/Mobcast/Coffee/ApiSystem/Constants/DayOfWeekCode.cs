using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobcast.Coffee.Api;

namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// 曜日コード
	/// Javaのjava.util.Calendarに合わせてあります
	/// </summary>
	public enum DayOfWeekCode
	{
		/// <summary>
		/// 不正値
		/// </summary>
		INVALID = -1,

		/// <summary>
		/// 日曜日
		/// </summary>
		SUNDAY = 1,

		/// <summary>
		/// 月曜日
		/// </summary>
		MONDAY = 2,

		/// <summary>
		/// 火曜日
		/// </summary>
		TUESDAY = 3,

		/// <summary>
		/// 水曜日
		/// </summary>
		WEDNESDAY = 4,

		/// <summary>
		/// 木曜日
		/// </summary>
		THURSDAY = 5,

		/// <summary>
		/// 金曜日
		/// </summary>
		FRIDAY = 6,

		/// <summary>
		/// 土曜日
		/// </summary>
		SATURDAY = 7,
	}
}
