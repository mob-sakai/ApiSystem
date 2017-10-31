using UnityEngine;
using System.Collections.Generic;
using MsgPack.Serialization;
using Mobcast.Coffee.Api;

/// <summary>
/// 獲得人数リセット方式コード
/// </summary>
public enum eAgentResetTypeCode {
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// リセット無し
	/// </summary>
	NONE		= 0,

	/// <summary>
	/// 期毎リセット
	/// </summary>
	SEASON		= 1
}

