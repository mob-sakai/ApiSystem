using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// インフォメーション種類コード
/// </summary>
public enum eInformationKindCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// エージェント
	/// </summary>
	AGENT		= 0,

	/// <summary>
	/// オーダーカード
	/// </summary>
	FORMATION	= 1,

	/// <summary>
	/// チーム
	/// </summary>
	TEAM		= 2,

	/// <summary>
	/// リーグ
	/// </summary>
	LEAGUE		= 3,

	/// <summary>
	/// 球会
	/// </summary>
	CLUB		= 4,

	/// <summary>
	/// 移籍
	/// </summary>
	TRANSFER	= 5,

	/// <summary>
	/// 大会
	/// </summary>
	TOURNAMENT	= 6,

	/// <summary>
	/// UIDialogInformationのインフォメーション要素に引数の値を使う場合.
	/// </summary>
	USEARGUMENTVALUE = 99,
}
