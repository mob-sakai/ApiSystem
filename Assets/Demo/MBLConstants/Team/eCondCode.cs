using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 調子コード
/// </summary>
public enum eCondCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// 絶不調
	/// </summary>
	WORST		= 0,

	/// <summary>
	/// 不調
	/// </summary>
	BAD			= 1,

	/// <summary>
	/// 普通
	/// </summary>
	NORMAL		= 2,

	/// <summary>
	/// 好調
	/// </summary>
	GOOD		= 3,

	/// <summary>
	/// 絶好調
	/// </summary>
	BEST		= 4,
}
