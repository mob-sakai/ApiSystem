using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 大会：選手条件タイプコード
/// </summary>
public enum eConventionPlayerRuleTypeCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID = -1,

	/// <summary>
	/// なし
	/// </summary>
	NONE = 0,

	/// <summary>
	/// レアリティ指定
	/// </summary>
	CARD_RARITY = 1,

	/// <summary>
	/// カードID指定
	/// </summary>
	PLAYER = 2,

	/// <summary>
	/// ナレッジID指定
	/// </summary>
	PLAYER_KNOWLEDGE = 3,
}
