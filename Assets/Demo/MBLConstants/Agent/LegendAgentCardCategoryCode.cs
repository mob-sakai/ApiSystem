using UnityEngine;
using System.Collections.Generic;
using MsgPack.Serialization;
using Mobcast.Coffee.Api;

/// <summary>
/// レジェンドエージェントカードカテゴリコード
/// </summary>
public enum eLegendAgentCardCategoryCode {
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID					= -1,

	/// <summary>
	/// ノーマル
	/// </summary>
	NORMAL					= 0,

	/// <summary>
	/// レア
	/// </summary>
	RARE					= 1,

	/// <summary>
	/// スーパーレア
	/// </summary>
	SUPER_RARE				= 2,

	/// <summary>
	/// ウルトラレア
	/// </summary>
	ULTRA_RARE				= 3,

	/// <summary>
	/// 特性ボーナススーパーレア
	/// </summary>
	SKILL_BONUS_SUPER_RARE	= 4,

	/// <summary>
	/// 特性ボーナスウルトラレア
	/// </summary>
	SKILL_BONUS_ULTRA_RARE	= 5,
}

