using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 運営大会：チームステータスコード
/// </summary>
public enum eEcTeamStatusCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID = -1,

	/// <summary>
	/// エントリー
	/// </summary>
	ENTRY = 0,

	/// <summary>
	/// 試合中
	/// </summary>
	MATCH = 1,

	/// <summary>
	/// 結果未確認
	/// </summary>
	UNCONFIRMED = 2,

	/// <summary>
	/// 結果確認済み
	/// </summary>
	CONFIRMED = 3,

	/// <summary>
	/// 中止
	/// </summary>
	CANCEL = 4,
}