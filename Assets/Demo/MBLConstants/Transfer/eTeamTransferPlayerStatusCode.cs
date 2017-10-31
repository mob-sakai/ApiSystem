using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// チーム移籍選手状態コード
/// </summary>
public enum eTeamTransferPlayerStatusCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// ロック状態(使用不可)
	/// </summary>
	LOCK		= 0,

	/// <summary>
	/// 空き
	/// </summary>
	EMPTY		= 1,

	/// <summary>
	/// 登録中
	/// </summary>
	REGIST		= 2,

	/// <summary>
	/// 契約成立(ゴールド未受領)
	/// </summary>
	SIGN		= 3,

	/// <summary>
	/// 契約成立(ゴールド受領)
	/// </summary>
	CLOSE		= 4,

	/// <summary>
	/// 有効期限切れ
	/// </summary>
	EXPIRE		= 5,

	/// <summary>
	/// 自身が購入
	/// </summary>
	BOUGHT		= 98,

	/// <summary>
	/// 売約済み
	/// </summary>
	SOLD_OUT	= 99
}
