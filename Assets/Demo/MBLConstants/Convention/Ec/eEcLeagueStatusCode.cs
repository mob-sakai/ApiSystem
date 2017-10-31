using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 運営大会：リーグステータスコード
/// </summary>
public enum eEcLeagueStatusCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID = -1,

	/// <summary>
	/// 開放
	/// </summary>
	OPEN = 0,

	/// <summary>
	/// 試合中
	/// </summary>
	MATCH = 1,

	/// <summary>
	/// 終了
	/// </summary>
	CLOSE = 2,
}
