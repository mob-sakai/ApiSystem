using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 試合タイプコード
/// </summary>
public enum eMatchTypeCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID			= -1,

	/// <summary>
	/// リーグ戦
	/// </summary>
	REGULAR			= 0,

	/// <summary>
	/// 練習試合
	/// </summary>
	PRACTICE		= 1,

	/// <summary>
	/// チュートリアル試合
	/// </summary>
	TUTORIAL		= 2,

	/// <summary>
	/// 運営大会
	/// </summary>
	EC				= 3,
}
