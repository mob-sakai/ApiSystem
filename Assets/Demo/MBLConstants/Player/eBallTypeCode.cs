using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 球種コード
/// </summary>
public enum eBallTypeCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID			= -1,

	/// <summary>
	/// ストレート
	/// </summary>
	STRAIGHT		= 0,

	/// <summary>
	/// カーブ
	/// </summary>
	CURVE			= 1,

	/// <summary>
	/// スライダー
	/// </summary>
	SLIDER			= 2,

	/// <summary>
	/// シュート
	/// </summary>
	SHOOT			= 3,

	/// <summary>
	/// シンカー
	/// </summary>
	SINKER			= 4,

	/// <summary>
	/// スクリュー
	/// </summary>
	SCREW			= 5,

	/// <summary>
	/// チェンジアップ
	/// </summary>
	CHANGEUP		= 6,

	/// <summary>
	/// フォーク
	/// </summary>
	FORK			= 7,
}
