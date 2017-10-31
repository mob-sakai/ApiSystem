using UnityEngine;
using System.Collections.Generic;
using MsgPack.Serialization;
using Mobcast.Coffee.Api;

/// <summary>
/// エージェントタイプコード
/// </summary>
public enum eAgentTypeCode {
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// ノーマル
	/// </summary>
	NORMAL		= 0,

	/// <summary>
	/// プレミアム
	/// </summary>
	PREMIUM		= 1,

	/// <summary>
	/// レジェンド
	/// </summary>
	LEGEND 		= 2,

	/// <summary>
	/// その他
	/// </summary>
	OTHERS 		= 99,
}

