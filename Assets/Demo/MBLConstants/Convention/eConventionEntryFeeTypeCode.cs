using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 大会：参加費タイプコード
/// </summary>
public enum eConventionEntryFeeTypeCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID = -1,

	/// <summary>
	/// クリスタル
	/// </summary>
	CRYSTAL = 0,

	/// <summary>
	/// ゴールド
	/// </summary>
	GOLD = 1,

	/// <summary>
	/// 無料
	/// </summary>
	FREE = 99,
}
