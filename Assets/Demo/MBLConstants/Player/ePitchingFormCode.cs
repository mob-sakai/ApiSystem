using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 投球フォームコード
/// </summary>
public enum ePitchingFormCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID			= -1,

	/// <summary>
	/// オーバースロー
	/// </summary>
	OVERARM			= 0,

	/// <summary>
	/// スリークォーター
	/// </summary>
	THREE_QUARTER	= 1,

	/// <summary>
	/// サイドスロー
	/// </summary>
	SIDEARM			= 2,

	/// <summary>
	/// アンダースロー
	/// </summary>
	UNDERARM		= 3,
}
