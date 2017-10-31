using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// リーグランクコード
/// チームの所属ランクにも使用
/// </summary>
public enum eLeagueRankCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// ビギナー
	/// </summary>
	BEGINNER	= 0,

	/// <summary>
	/// ブロンズ
	/// </summary>
	BRONZE		= 1,

	/// <summary>
	/// シルバー
	/// </summary>
	SILVER		= 2,

	/// <summary>
	/// ゴールド
	/// </summary>
	GOLD		= 3,

	/// <summary>
	/// プラチナ
	/// </summary>
	PLATINUM	= 4,

	/// <summary>
	/// ダイアモンド
	/// </summary>
	DIAMOND 	= 5,

	/// <summary>
	/// レジェンド
	/// </summary>
	LEGEND		= 6,
}
