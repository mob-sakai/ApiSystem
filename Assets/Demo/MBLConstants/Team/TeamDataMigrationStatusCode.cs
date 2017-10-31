using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// チームデータ引継状態コード
/// </summary>
public enum eTeamDataMigrationStatusCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// データ引き継ぎ設定なし
	/// </summary>
	NONE		= 0,

	/// <summary>
	/// データ引継ぎ設定あり
	/// </summary>
	CONFIGURE	= 1,

	/// <summary>
	/// データ引継ぎ完了
	/// </summary>
	FINISH		= 2,
}
