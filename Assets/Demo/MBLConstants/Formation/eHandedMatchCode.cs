using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 左右(投打)適正コード
/// </summary>
public enum eHandedMatchCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// なし
	/// </summary>
	NONE		= 0,

	/// <summary>
	/// 右
	/// </summary>
	RIGHT		= 1,

	/// <summary>
	/// 左
	/// </summary>
	LEFT		= 2,
}
