using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// メッセージ種別コード
/// </summary>
public enum eClubMessageTypeCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID						=-1,

	/// <summary>
	/// 発言
	/// </summary>
	MESSAGE						= 0,

	/// <summary>
	/// 球会作成
	/// </summary>
	CREATE_CLUB					= 1,

	/// <summary>
	/// 入会申請
	/// </summary>
	ENTRY_REQUEST				= 2,

	/// <summary>
	/// 入会申請承認
	/// </summary>
	ENTRY_REQUEST_APPROVE		= 3,

	/// <summary>
	/// 入会申請否認
	/// </summary>
	ENTRY_REQUEST_DENIAL		= 4,

	/// <summary>
	/// 入会
	/// </summary>
	MEMBER_ENTRY				= 5,

	/// <summary>
	/// 退会
	/// </summary>
	MEMBER_LEAVE				= 6,

	/// <summary>
	/// 除名
	/// </summary>
	MEMBER_EXPULSION			= 7,

	/// <summary>
	/// 昇格
	/// </summary>
	MEMBER_PROMOTE				= 8,

	/// <summary>
	/// 降格
	/// </summary>
	MEMBER_DEMOTE				= 9,							   

	/// <summary>
	/// 設定変更
	/// </summary>
	CONFIGURATION_CHANGE		= 10,

	/// <summary>
	/// リーダー変更
	/// </summary>
	LEADER_CHANGE				= 11,

	/// <summary>
	/// シェア(公式戦)
	/// </summary>
	SHARE_REGULAR_MATCH			= 12,

	/// <summary>
	/// トレード
	/// </summary>
	TRADE_START					= 13,

	/// <summary>
	/// トレードキャンセル
	/// </summary>
	TRADE_CANCEL				= 14,

	/// <summary>
	/// トレード成立
	/// </summary>
	TRADE_COMPLETE				= 15,

	/// <summary>
	/// エール
	/// </summary>
	YELL						= 16,

	/// <summary>
	/// 練習試合
	/// </summary>
	PRACTICE_MATCH				= 17,

	/// <summary>
	/// シェア(練習試合)
	/// </summary>
	SHARE_PRACTICE_MATCH		= 18,

	/// <summary>
	/// お返し可能エール
	/// </summary>
	REPLYABLE_YELL				= 19,

	/// <summary>
	/// エールのお返し
	/// </summary>
	REPLY_YELL					= 20,

	/// <summary>
	/// 球会ミッション達成
	/// </summary>
	CLUB_MISSION_ACHIEVE		= 21,

}
