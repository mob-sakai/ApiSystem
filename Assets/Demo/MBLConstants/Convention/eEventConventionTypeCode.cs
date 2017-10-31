using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 運営大会タイプコード
/// </summary>
public enum eEventConventionTypeCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID = -1,

	/// <summary>
	/// 通常運営大会
	/// </summary>
	NORMAL = 0,

	/// <summary>
	/// CC１回戦
	/// </summary>
	CC_ROUND1 = 1,

	/// <summary>
	/// CC２回戦
	/// </summary>
	CC_ROUND2 = 2,

	/// <summary>
	/// CC決勝戦
	/// </summary>
	CC_FINAL = 3,
}
