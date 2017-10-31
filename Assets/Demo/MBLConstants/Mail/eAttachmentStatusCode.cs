using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 添付物状態コード
/// </summary>
public enum eAttachmentStatusCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID = -1,

	/// <summary>
	/// 添付物なし
	/// </summary>
	NONE = 0,

	/// <summary>
	/// 添付物あり
	/// </summary>
	ATTACH = 1,

	/// <summary>
	/// 添付物獲得済み
	/// </summary>
	ACQUIRE = 2,

	/// <summary>
	/// 球会招待承認
	/// </summary>
	CLUB_INVITE_APPROVE = 10,

	/// <summary>
	/// 球会招待拒否
	/// </summary>
	CLUB_INVITE_DENIAL = 11,

	/// <summary>
	/// 球会招待期限切れ
	/// </summary>
	CLUB_INVITE_EXPIRED = 12,
}
