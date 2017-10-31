using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 運営大会：セクションステータスコード
/// </summary>
public enum eEcSectionStatusCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID = -1,

	/// <summary>
	/// 開放
	/// </summary>
	OPEN = 0,

	/// <summary>
	/// 試合中
	/// </summary>
	MATCH = 1,

	/// <summary>
	/// 終了
	/// </summary>
	CLOSE = 2,

	/// <summary>
	/// 中止
	/// </summary>
	CANCEL = 3,

	/// <summary>
	/// 払い戻し中
	/// </summary>
	PAYBACK = 4,

	/// <summary>
	/// 削除
	/// </summary>
	DELETE = 5,
}
