using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// フィールドコード
/// </summary>
public enum eFieldCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID			= -1,

	/// <summary>
	/// 投手
	/// </summary>
	PITCHER			= 0,

	/// <summary>
	/// 捕手
	/// </summary>
	CATCHER			= 1,

	/// <summary>
	/// 内野手
	/// </summary>
	INFIELDER		= 2,

	/// <summary>
	/// 外野手
	/// </summary>
	OUTFIELDER		= 3,

	/// <summary>
	/// 指名打者
	/// </summary>
	DH				= 4,
}
