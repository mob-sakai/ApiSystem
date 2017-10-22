using UnityEngine;
using System;
using System.Collections.Generic;
using Mobcast.Coffee.Api;


namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// UNIXタイム←→DateTime(UTC)変換ユーティリティクラス
	/// </summary>
	public static class ApiTimeUtil
	{
		/// <summary>
		/// UNIXエポックDateTime
		/// </summary>
		public static readonly DateTime UNIX_EPOCH_DATE_TIME = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		/// <summary>
		/// ローカル時間(Utc).
		/// SetServerTimeを呼び出すたびにサーバー時間と同期し、精度を高めます.
		/// ゲーム起動後の累積経過時間を利用するため、ゲームのバックグラウンド遷移や端末の時間調整に影響を受けません.
		/// ※本来であれば、NTPや到着遅延も考慮すべき.
		/// </summary>
		public static DateTime UtcNow { get { return UNIX_EPOCH_DATE_TIME.AddSeconds(diffTime + Time.realtimeSinceStartup); } }

		static long diffTime = DateTime.UtcNow.ToUnixTime();

		/// <summary>
		/// DateTime(UTC)を、UNIXタイムに変換
		/// </summary>
		public static long ToUnixTime(this DateTime dateTime)
		{
			return (long)(dateTime.ToUniversalTime() - UNIX_EPOCH_DATE_TIME).TotalSeconds;
		}

		/// <summary>
		/// DateTime(UTC)を、UNIXタイムに変換
		/// </summary>
		public static long ToUnixTime(this DateTime dateTime, TimeZoneCode timeZoneCode)
		{
			var info = TimeZoneInfo.Utc;
			CodeConvertion.timeZoneInfoMap.TryGetValue (timeZoneCode, out info);
			return (long)((dateTime.ToUniversalTime() - UNIX_EPOCH_DATE_TIME).TotalSeconds - info.BaseUtcOffset.TotalSeconds);
		}

		/// <summary>
		/// UNIXタイムを、DateTime(UTC)に変換
		/// </summary>
		/// <param name="unixTime">UNIXタイム</param>
		/// <returns>変換したDateTime</returns>
		public static DateTime ToDateTime(this long unixTime)
		{
			return UNIX_EPOCH_DATE_TIME.AddSeconds(unixTime);
		}

		/// <summary>
		/// 指定UNIXTIMEを、指定タイムゾーンコードのDateTimeに変換
		/// </summary>
		/// <param name="unixTime">UNIXTIME</param>
		/// <param name="timeZoneCode">変換するタイムゾーンコード</param>
		/// <returns></returns>
		public static DateTime ToDateTime(this long unixTime, TimeZoneCode timeZoneCode)
		{
			var info = TimeZoneInfo.Utc;
			CodeConvertion.timeZoneInfoMap.TryGetValue (timeZoneCode, out info);
			return ToDateTime(unixTime).AddSeconds(info.BaseUtcOffset.TotalSeconds);
		}

		/// <summary>
		/// サーバー時間を設定.
		/// </summary>
		/// <param name="dateTime">Date time.</param>
		public static void SetServerTime(long dateTime)
		{
			diffTime = dateTime - (long)Time.realtimeSinceStartup;
		}
	}
}
