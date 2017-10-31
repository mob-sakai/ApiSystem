using UnityEngine;
using System.Collections.Generic;
using MsgPack.Serialization;
using Mobcast.Coffee.Api;

/// <summary>
/// 友達招待機能ステータスコード
/// </summary>
public enum eInviteFriendEnableStatusCode {
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// 機能が無効
	/// </summary>
	DISABLE		= 0,

	/// <summary>
	/// 報酬無効
	/// </summary>
	NO_REWARD	= 1,

	/// <summary>
	/// 有効
	/// </summary>
	ENABLE		= 2,
}

