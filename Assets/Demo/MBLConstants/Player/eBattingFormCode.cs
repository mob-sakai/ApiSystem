using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 打撃フォームコード
/// </summary>
public enum eBattingFormCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID			= -1,

	/// <summary>
	/// スタンダード
	/// </summary>
	STANDARD		= 0,

	/// <summary>
	/// オープンスタンス
	/// </summary>
	OPEN_STANCE		= 1,

	/// <summary>
	/// 神主
	/// </summary>
	KANNUSHI		= 2,

	/// <summary>
	/// クラウチング
	/// </summary>
	CROUCHING		= 3,

	/// <summary>
	/// 振り子
	/// </summary>
	PENDULUM		= 4,

	/// <summary>
	/// バスター
	/// </summary>
	BASTARD			= 5,

	/// <summary>
	/// 一本足
	/// </summary>
	ONE_LEG			= 6,
}
