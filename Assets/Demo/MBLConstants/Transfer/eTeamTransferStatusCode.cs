using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// チーム移籍機能開放状態コード
/// </summary>
public enum eTeamTransferStatusCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// 使用不可
	/// </summary>
	CLOSE		= 0,

	/// <summary>
	/// 使用可能
	/// </summary>
	OPEN		= 1,
}
