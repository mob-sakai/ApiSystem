using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 報酬種別コード
/// </summary>
public enum eRewardKindCode
{
	// NOTE: int値を変更しないようお願いします.

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
	/// 選手
	/// </summary>
	PLAYER = 2,

	/// <summary>
	/// オーダー
	/// </summary>
	FORMATION = 3,

	/// <summary>
	/// 選手カードパック
	/// </summary>
	PLAYER_PACK = 4,

	/// <summary>
	/// エージェントポイント
	/// </summary>
	AGENT_POINT = 5,

	/// <summary>
	/// トロフィー
	/// </summary>
	TROPHY = 6,

	/// <summary>
	/// エンブレム(チームアイコン)
	/// </summary>
	EMBLEM = 7,
}
