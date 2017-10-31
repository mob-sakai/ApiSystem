using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// メールタイプコード
/// </summary>
public enum eMailTypeCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID = -1,

	/// <summary>
	/// 通常
	/// </summary>
	NORMAL = 0,

	/// <summary>
	/// 球会招待
	/// </summary>
	CLUB_INVITE = 1,

	/// <summary>
	/// 球会除名
	/// </summary>
	CLUB_EXPULSION = 2,

	/// <summary>
	/// 移籍成立
	/// </summary>
	TRANSFER = 3,
}
