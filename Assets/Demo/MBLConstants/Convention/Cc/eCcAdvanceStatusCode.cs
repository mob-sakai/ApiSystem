using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// チャンピオンカップ進出状態コード
/// </summary>
public enum eCcAdvanceStatusCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID = -1,

	/// <summary>
	/// 敗退
	/// </summary>
	DEFEATED = 0,

	/// <summary>
	/// 進出
	/// </summary>
	ADVANCED = 1,
}
