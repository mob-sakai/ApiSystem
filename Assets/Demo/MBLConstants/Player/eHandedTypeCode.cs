using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 利き腕コード
/// </summary>
public enum eHandedTypeCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID			= -1,

	/// <summary>
	/// 右利き
	/// </summary>
	RIGHT			= 0,

	/// <summary>
	/// 左利き
	/// </summary>
	LEFT			= 1,

	/// <summary>
	/// 両利き
	/// </summary>
	BOTH			= 2,
}
