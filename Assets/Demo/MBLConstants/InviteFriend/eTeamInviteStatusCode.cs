using UnityEngine;
using System.Collections.Generic;
using MsgPack.Serialization;
using Mobcast.Coffee.Api;

/// <summary>
/// 友達招待ステータスコード
/// </summary>
public enum eTeamInviteStatusCode {
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID			= -1,

	/// <summary>
	/// 未完了
	/// </summary>
	INCOMPLETE		= 0,

	/// <summary>
	/// 被招待者の友達招待成立条件達成(チュートリアル完了)
	/// </summary>
	TASK_COMPLETE	= 1,

	/// <summary>
	/// 友達招待完了
	/// </summary>
	ALL_COMPLETE	= 2,
}

