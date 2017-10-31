using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// カードレアリティコード
/// </summary>
public enum eCardRarityCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID			= -1,

	/// <summary>
	/// ノーマル
	/// </summary>
	NORMAL			= 0,

	/// <summary>
	/// レア
	/// </summary>
	RARE			= 1,

	/// <summary>
	/// スーパーレア
	/// </summary>
	SUPER_RARE		= 2,

	/// <summary>
	/// ウルトラレア
	/// </summary>
	ULTRA_RARE		= 3,
}
