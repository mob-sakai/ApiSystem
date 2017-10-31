using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// メール状態コード
/// </summary>
public enum eMailStatusCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID = -1,

	/// <summary>
	/// 未読
	/// </summary>
	UNREAD = 0,

	/// <summary>
	/// 既読
	READ = 1,

	/// <summary>
	/// 削除済み
	/// </summary>
	DELETE = 2,
}
