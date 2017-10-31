using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 大会：種目タイプコード
/// </summary>
public enum eConventionItemTypeCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID = -1,

	/// <summary>
	/// 勝敗
	/// </summary>
	WIN = 0,

	/// <summary>
	/// 本塁打
	/// </summary>
	FIELDER_HR = 1,

	/// <summary>
	/// 打点
	/// </summary>
	FIELDER_RBI = 2,

	/// <summary>
	/// 打撃
	/// </summary>
	FIELDER_H = 3,

	/// <summary>
	/// 盗塁
	/// </summary>
	FIELDER_SB = 4,

	/// <summary>
	/// 奪三振
	/// </summary>
	PITCHER_SO = 5,

	/// <summary>
	/// 種目総合（通算チーム成績用）
	/// </summary>
	TOTAL = 99,
}
