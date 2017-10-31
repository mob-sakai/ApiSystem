using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 出塁種類コード
/// </summary>
public enum eHitTypeCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/*---------------- 失策 ----------------*/
	/// <summary>
	/// 投失
	/// </summary>
	ERR_P		=  0,

	/// <summary>
	/// 捕失
	/// </summary>
	ERR_C		=  1,

	/// <summary>
	/// 一失
	/// </summary>
	ERR_FB		=  2,

	/// <summary>
	/// 二失
	/// </summary>
	ERR_SB		=  3,

	/// <summary>
	/// 三失
	/// </summary>
	ERR_TB		=  4,

	/// <summary>
	/// 遊失
	/// </summary>
	ERR_SS		=  5,

	/// <summary>
	/// 左失
	/// </summary>
	ERR_LF		=  6,

	/// <summary>
	/// 中失
	/// </summary>
	ERR_CF		=  7,

	/// <summary>
	/// 右失
	/// </summary>
	ERR_RF		=  8,

	/*---------------- 内野安打 ----------------*/
	/// <summary>
	/// 投安
	/// </summary>
	HIT_P		=  9,

	/// <summary>
	/// 捕安
	/// </summary>
	HIT_C		= 10,

	/// <summary>
	/// 一安
	/// </summary>
	HIT_FB		= 11,

	/// <summary>
	/// 二安
	/// </summary>
	HIT_SB		= 12,

	/// <summary>
	/// 三安
	/// </summary>
	HIT_TB		= 13,

	/// <summary>
	/// 遊安
	/// </summary>
	HIT_SS		= 14,

	/*---------------- 安打 ----------------*/
	/// <summary>
	/// 左安
	/// </summary>
	HIT_LF		= 15,

	/// <summary>
	/// 中安
	/// </summary>
	HIT_CF		= 16,

	/// <summary>
	/// 右安
	/// </summary>
	HIT_RF		= 17,

	/*---------------- 二塁打 ----------------*/
	/// <summary>
	/// 左二
	/// </summary>
	DOUBLE_LF	= 18,

	/// <summary>
	/// 中二
	/// </summary>
	DOUBLE_CF	= 19,

	/// <summary>
	/// 右二
	/// </summary>
	DOUBLE_RF	= 20,

	/*---------------- 三塁打 ----------------*/
	/// <summary>
	/// 左三
	/// </summary>
	TRIPLE_LF	= 21,

	/// <summary>
	/// 中三
	/// </summary>
	TRIPLE_CF	= 22,

	/// <summary>
	/// 右三
	/// </summary>
	TRIPLE_RF	= 23,

	/*---------------- 本塁打 ----------------*/
	/// <summary>
	/// 左本
	/// </summary>
	HR_LF		= 24,

	/// <summary>
	/// 中本
	/// </summary>
	HR_CF		= 25,

	/// <summary>
	/// 右本
	/// </summary>
	HR_RF		= 26,

	/*---------------- 四球 ----------------*/
	/// <summary>
	/// 四球
	/// </summary>
	BB			= 27,

	/*---------------- 死球 ----------------*/
	/// <summary>
	/// 死球
	/// </summary>
	HBP			= 28,

	/*---------------- 敬遠 ----------------*/
	/// <summary>
	/// 敬遠
	/// </summary>
	IBB			= 29,
}
