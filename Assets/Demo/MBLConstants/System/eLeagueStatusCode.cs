using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// リーグステータスコード
/// </summary>
public enum eLeagueStatusCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// 閉鎖
	/// </summary>
	CLOSE		= 0,

	/// <summary>
	/// 開放
	/// </summary>
	OPEN		= 1,
}
