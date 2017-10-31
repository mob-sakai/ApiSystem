using UnityEngine;
using System.Collections.Generic;
using MsgPack.Serialization;
using Mobcast.Coffee.Api;

/// <summary>
/// 友達招待報酬種別コード
/// </summary>
public enum eInviteFriendRewardKindCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID					= -1,

	/// <summary>
	/// クリスタル
	/// </summary>
	CRYSTAL					= 0,

	/// <summary>
	/// ゴールド
	/// </summary>
	GOLD					= 1,

	/// <summary>
	/// SRパック
	/// </summary>
	PLAYER_PACK_SUPER_RARE	= 2,

	/// <summary>
	/// URパック
	/// </summary>
	PLAYER_PACK_ULTRA_RARE	= 3,

	/// <summary>
	/// SR選手
	/// </summary>
	PLAYER_SUPER_RARE		= 4,

	/// <summary>
	/// UR選手
	/// </summary>
	PLAYER_ULTRA_RARE		= 5,
}

