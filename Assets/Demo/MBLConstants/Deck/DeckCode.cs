using UnityEngine;
using System.Collections.Generic;
using MsgPack.Serialization;
using Mobcast.Coffee.Api;

/// <summary>
/// デッキコード
/// </summary>
public enum eDeckCode {
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// 公式戦
	/// </summary>
	REGULAR		= 0,

	/// <summary>
	/// 大会
	/// </summary>
	CONVENTION	= 1,

	/// <summary>
	/// 予約
	/// </summary>
	RESERVE2	= 2,
}

