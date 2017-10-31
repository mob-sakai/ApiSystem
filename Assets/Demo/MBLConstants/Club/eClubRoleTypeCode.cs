using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/// <summary>
/// 球会役職コード
/// </summary>
public enum eClubRoleTypeCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		=-1,

	/// <summary>
	/// リーダー
	/// </summary>
	LEADER		= 0,

	/// <summary>
	/// 副リーダ
	/// </summary>
	SUB_LEADER	= 1,

	/// <summary>
	/// ベテラン 
	/// </summary>
	EXPERT		= 2,

	/// <summary>
	/// メンバー
	/// </summary>
	MEMBER		= 3,
}
