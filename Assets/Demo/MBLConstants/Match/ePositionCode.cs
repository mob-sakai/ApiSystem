using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// ポジションコード
/// </summary>
public enum ePositionCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// 投手
	/// </summary>
	P			= 0,

	/// <summary>
	/// 捕手
	/// </summary>
	C			= 1,

	/// <summary>
	/// ファースト
	/// </summary>
	FB			= 2,

	/// <summary>
	/// セカンド
	/// </summary>
	SB			= 3,

	/// <summary>
	/// サード
	/// </summary>
	TB			= 4,

	/// <summary>
	/// ショートストップ
	/// </summary>
	SS			= 5,

	/// <summary>
	/// レフト
	/// </summary>
	LF			= 6,

	/// <summary>
	/// センター
	/// </summary>
	CF			= 7,

	/// <summary>
	/// ライト
	/// </summary>
	RF			= 8,

	/// <summary>
	/// 指名打者
	/// </summary>
	DH			= 9,
}
