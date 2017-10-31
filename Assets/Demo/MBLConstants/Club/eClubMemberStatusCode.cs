using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 球会メンバー状態コード
/// </summary>
public enum eClubMemberStatusCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		=-1,

	/// <summary>
	/// 退会
	/// </summary>
	OUT			= 0,

	/// <summary>
	/// 所属中
	/// </summary>
	ACTIVE		= 1,
}										 
