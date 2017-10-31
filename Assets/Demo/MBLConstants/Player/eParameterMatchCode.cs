using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 適正コード
/// 打順、守備、投手の各適正値コード
/// </summary>
public enum eParameterMatchCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// 未経験
	/// </summary>
	BEGINNER	= 0,

	/// <summary>
	/// 少し経験あり
	/// </summary>
	AVERAGE		= 1,

	/// <summary>
	/// 経験豊富
	/// </summary>
	EXPERT		= 2,
}
