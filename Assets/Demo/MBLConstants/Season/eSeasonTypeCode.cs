using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// シーズンタイプコード
/// </summary>
public enum eSeasonTypeCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// 今シーズン
	/// </summary>
	NOW			=  0,

	/// <summary>
	/// 昨シーズン
	/// </summary>
	LAST		=  1,
}
