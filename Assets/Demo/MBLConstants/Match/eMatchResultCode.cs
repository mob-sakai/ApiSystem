using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 試合結果コード
/// </summary>
public enum eMatchResultCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// 勝ち
	/// </summary>
	WIN			=  0,

	/// <summary>
	/// 負け
	/// </summary>
	LOSE		=  1,

	/// <summary>
	/// 引き分け
	/// </summary>
	DRAW		=  2,

	/// <summary>
	/// 試合前
	/// </summary>
	BEFORE		=  3,

	/// <summary>
	/// 試合後
	/// </summary>
	AFTER		=  4,

	/// <summary>
	/// 試合中
	/// </summary>
	DURING		=  5,

	/// <summary>
	/// 勝敗つかず
	/// </summary>
	NONE		= 99,
}
