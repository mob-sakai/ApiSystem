using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// メンバータイプコード
/// </summary>
public enum eMemberTypeCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// スタメン
	/// </summary>
	REGULAR		= 0,

	/// <summary>
	/// 控え
	/// </summary>
	RESERVE		= 1,

	/// <summary>
	/// 先発
	/// </summary>
	STARTER		= 2,

	/// <summary>
	/// 中継ぎ
	/// </summary>
	SET_UPPER	= 3,

	/// <summary>
	/// 抑え
	/// </summary>
	CLOSER		= 4,

	/// <summary>
	/// ファーム
	/// </summary>
	FARM		= 5,
}
