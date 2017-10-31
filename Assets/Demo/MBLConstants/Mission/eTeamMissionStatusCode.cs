using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// チームミッション状態コード
/// </summary>
public enum eTeamMissionStatusCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID = -1,

	/// <summary>
	/// 新規
	/// </summary>
	NEW = 0,

	/// <summary>
	/// 確認済み
	/// </summary>
	CHECKED = 1,

	/// <summary>
	/// クリア
	/// </summary>
	CLEAR = 2,

	/// <summary>
	/// 完了（報酬獲得済み）
	/// </summary>
	COMPLETED = 3,
}
