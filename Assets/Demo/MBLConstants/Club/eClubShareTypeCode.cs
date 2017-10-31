using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// シェア種別コード
/// </summary>
public enum eClubShareTypeCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID = -1,

	/// <summary>
	/// 公式戦
	/// </summary>
	REGULAR_MATCH = 0,

	/// <summary>
	/// 練習試合
	/// </summary>
	PRACTICE_MATCH = 1, 
}