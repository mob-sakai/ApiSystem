using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// ランキング変動コード
/// </summary>
public enum eRankingSwingCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// 上昇
	/// </summary>
	UP			= 0,

	/// <summary>
	/// 下降
	/// </summary>
	DOWN		= 1,

	/// <summary>
	/// 変わらず
	/// </summary>
	EVEN		= 2,

	/// <summary>
	/// 順位未確定（まだ順位が付いていない）
	/// </summary>
	NONE		= 3,
}
