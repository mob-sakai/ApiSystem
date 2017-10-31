using UnityEngine;
using System.Collections.Generic;
using MsgPack.Serialization;
using Mobcast.Coffee.Api;

/// <summary>
/// エージェント依頼状態コード
/// </summary>
public enum eAgentStatusCode {
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// 依頼なし
	/// </summary>
	NONE		= 0,

	/// <summary>
	/// リストアップ
	/// </summary>
	LIST_UP		= 1,

}

