using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 試合ステータスコード
/// </summary>
public enum eMatchStatusCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID			= -1,

	/// <summary>
	/// 試合処理前
	/// </summary>
	BEFORE			= 0,

	/// <summary>
	/// 試合処理後
	/// </summary>
	AFTER			= 1,

	/// <summary>
	/// 試合処理後(調子変動済み)
	/// </summary>
	AFTER2			= 2,

	/// <summary>
	/// 試合集計後
	/// </summary>
	TOTAL			= 3,
}
