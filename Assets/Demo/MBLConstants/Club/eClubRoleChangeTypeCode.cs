using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/// <summary>
/// 役職変更種別コード
/// </summary>
public enum eClubRoleChangeTypeCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// 昇格
	/// </summary>
	PROMOTE		= 0,

	/// <summary>
	/// 降格
	/// </summary>
	DEMOTE		= 1,
}