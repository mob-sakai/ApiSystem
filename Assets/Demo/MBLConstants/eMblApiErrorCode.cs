using UnityEngine;
using System.Collections.Generic;
using MsgPack.Serialization;
using Mobcast.Coffee.Api;

/// <summary>
/// MBL API用エラーコード
/// </summary>
public enum eMblApiErrorCode {
	//---------------- 汎用(1000番台) ----------------
	/// <summary>
	/// 汎用エラー
	/// </summary>
	ERROR								= 1000,

	/// <summary>
	/// 日付が変わりました
	/// </summary>
	CROSS_DATE_TIME						= 1001,

	//---------------- APIパラメータ系(1100番台) ----------------
	/// <summary>
	/// パラメータ不足
	/// </summary>
	INVALID_PARAM						= 1100,

	/// <summary>
	/// 不正なパケット
	/// </summary>
	INVALID_PACKET						= 1101,

	/// <summary>
	/// 不正なパケット値
	/// </summary>
	INVALID_PACKET_VARIABLE				= 1102,

	/// <summary>
	/// 不正なIP
	/// </summary>
	INVALID_IP							= 1103,

	//---------------- 管理画面系(1200番台) ----------------
	/// <summary>
	/// アカウントが見つからない
	/// </summary>
	ADMIN_ACCOUNT_NOT_FOUND				= 1200,

	/// <summary>
	/// パスワードが不正
	/// </summary>
	ADMIN_PASSWORD_INVALID				= 1201,

	/// <summary>
	/// アカウントが存在する
	/// </summary>
	ADMIN_ACCOUNT_EXIST					= 1202,

	/// <summary>
	/// ログインしていない
	/// </summary>
	ADMIN_NOT_LOGIN						= 1203,

	/// <summary>
	/// 権限不足
	/// </summary>
	ADMIN_LACK_PERMISSION				= 1204,

	/// <summary>
	/// スケジュールが不正
	/// </summary>
	ADMIN_INVALID_SCHEDULE				= 1205,

	/// <summary>
	/// メール送信対象が不正
	/// </summary>
	ADMIN_INVALID_MAIL_TARGET			= 1206,

	/// <summary>
	/// メンテナンススケジュールが見つからない,
	/// </summary>
	ADMIN_MANTENACE_SCHEDULE_NOT_FOUND	= 1208,

	/// <summary>
	/// 報酬種別が不正
	/// </summary>
	ADMIN_INVALID_REWARD_KIND			= 1209,

	/// <summary>
	/// 数量が不正
	/// </summary>
	ADMIN_INVALID_AMOUNT				= 1210,

	/// <summary>
	/// 選手IDが不正
	/// </summary>
	ADMIN_INVALID_PLAYER_ID				= 1211,

	/// <summary>
	/// スキルIDが不正
	/// </summary>
	ADMIN_INVALID_SKILL_ID				= 1212,

	/// <summary>
	/// オーダーIDが不正
	/// </summary>
	ADMIN_INVALID_FORMATION_ID			= 1213,

	//選手パックIDが不正
	ADMIN_INVALID_PLAYER_PACK_ID		= 1214,

	/// <summary>
	/// エンブレムIDが不正
	/// </summary>
	ADMIN_INVALID_EMBLEM_ID				= 1215,

	/// <summary>
	/// 管理用報酬データ追加失敗
	/// </summary>
	ADMIN_FAIL_TO_ADD_ADMIN_REWARD		= 1216,

	/// <summary>
	/// 管理用報酬データが見つからない
	/// </summary>
	ADMIN_ADMIN_REWARD_NOT_FOUND		= 1217,

	/// <summary>
	/// 報酬名が不正
	/// </summary>
	ADMIN_INVALID_REWARD_NAME			= 1218,

	/// <summary>
	/// マスターバージョンが不正
	/// </summary>
	ADMIN_INVALID_MASTER_VERTION		= 1219,

	/// <summary>
	/// 管理用メールデータ追加失敗
	/// </summary>
	ADMIN_FAIL_TO_ADD_MAIL				= 1220,

	/// <summary>
	/// 管理用メールデータが見つからない
	/// </summary>
	ADMIN_MAIL_NOT_FOUND				= 1221,

	/// <summary>
	/// 管理用メールステータスコード値が不正
	/// </summary>
	ADMIN_INVALID_MAIL_STATUS			= 1222,

	/// <summary>
	/// 管理用メールタイトルが不正
	/// </summary>
	ADMIN_INVALID_MAIL_TITLE			= 1223,

	/// <summary>
	/// 管理用メールメッセージが不正
	/// </summary>
	ADMIN_INVALID_MAIL_MESSAGE			= 1224,

	/// <summary>
	/// 管理用メール送信日時が不正
	/// </summary>
	ADMIN_INVALID_MAIL_DELIVERY			= 1225,

	/// <summary>
	/// 管理用メール受取期限が不正
	/// </summary>
	ADMIN_INVALID_MAIL_DEADLINE			= 1226,

	/// <summary>
	/// チームが見つからない
	/// </summary>
	ADMIN_TEAM_NOT_FOUND				= 1227,

	/// <summary>
	/// アカウントを削除できない
	/// </summary>
	ADMIN_ACCOUNT_NOT_DELETE			= 1228,

	/// <summary>
	/// セッションを削除できない
	/// </summary>
	ADMIN_SESSION_NOT_DELETE			= 1229,

	/// <summary>
	/// チーム名に禁止ワードが含まれている
	/// </summary>
	ADMIN_INVALID_TEAM_NAME				= 1230,

	/// <summary>
	/// コメントに禁止ワードが含まれている
	/// </summary>
	ADMIN_INVALID_COMMENT				= 1231,

	/// <summary>
	/// チーム名が長すぎる
	/// </summary>
	ADMIN_TEAM_NAME_OVERFLOW			= 1232,

	//---------------- 登録系(1300番台) ----------------
	/// <summary>
	/// 登録エラー
	/// </summary>
	FAILED_REGIST_TEAM					= 1300,

	/// <summary>
	/// 登録済み
	/// </summary>
	TEAM_ALREADY_REGIST					= 1301,

	/// <summary>
	/// 空きリージョンなし
	/// </summary>
	REGIST_REGION_NOT_FOUND				= 1302,

	/// <summary>
	/// 未来の誕生日
	/// </summary>
	FUTURE_BIRTH_DAY					= 1303,

	/// <summary>
	/// 招待チームが存在しません
	/// </summary>
	PARENT_TEAM_NOT_FOUND				= 1304,

	//---------------- チーム系(1400番台) ----------------
	/// <summary>
	/// チームが見つからない
	/// </summary>
	TEAM_NOT_FOUND						= 1400,

	/// <summary>
	/// uidが不整合
	/// </summary>
	UID_MISMATCH						= 1401,

	/// <summary>
	/// 不正なチーム名
	/// </summary>
	INVALID_TEAM_NAME					= 1402,

	/// <summary>
	/// チーム名が長すぎ
	/// </summary>
	TEAM_NAME_OVERFLOW					= 1403,

	/// <summary>
	/// オーダー未所持
	/// </summary>
	FORMATION_NOT_GAIN					= 1404,

	/// <summary>
	/// チーム選手が見つからない
	/// </summary>
	PLAYER_NOT_FOUND					= 1405,

	/// <summary>
	/// ストック選手が見つからない
	/// </summary>
	STOCK_PLAYER_NOT_FOUND				= 1406,

	/// <summary>
	/// ストック選手がストック中以外の状態
	/// </summary>
	STOCK_PLAYER_NOT_FREE				= 1407,

	/// <summary>
	/// ストック選手スロットに空きがない
	/// </summary>
	STOCK_PLAYER_SLOT_NOT_EMPTY			= 1408,

	/// <summary>
	/// ストック選手のデータ交換に失敗
	/// </summary>
	STOCK_PLAYER_SWITCH_FAILED			= 1409,

	/// <summary>
	/// チーム選手の空きがない
	/// </summary>
	NO_TEAM_PLAYER_SPACE				= 1410,

	/// <summary>
	/// 入れ替え選手がおかしい
	/// </summary>
	IN_OUT_PLAYER_MISMATCH				= 1411,

	/// <summary>
	/// 不正なコメント
	/// </summary>
	INVALID_COMMENT						= 1412,

	/// <summary>
	/// アカウント停止
	/// </summary>
	ACCOUNT_STOP						= 1413,

	/// <summary>
	/// アカウント停止(期間限定)
	/// </summary>
	LIMITED_ACCOUNT_STOP				= 1414,

	/// <summary>
	/// チーム名変更回数制限
	/// </summary>
	LACK_OF_NAMING_RIGHT				= 1415,

	/// <summary>
	/// チームエンブレム未所持
	/// </summary>
	TEAM_EMBLEM_NOT_GAIN				= 1416,

	/// <summary>
	/// すでに同一選手がいる
	/// </summary>
	DUPLICATE_PLAYER_KNOWLEDGE			= 1417,

	/// <summary>
	/// ディープリンクコードがすでに使用されている
	/// </summary>
	DEEP_LINK_ALREADY_USED				= 1418,

	/// <summary>
	/// ディープリンクを獲得済み
	/// </summary>
	DEEP_LINK_ALREADY_GAINED			= 1419,

	/// <summary>
	/// ストック選手が登録できる状態にありません
	/// </summary>
	STOCK_PLAYER_NOT_STAY				= 1420,

	//---------------- ショップ系(1500番台) ----------------
	/// <summary>
	/// エージェントが使用できない
	/// </summary>
	AGENT_NOT_OPEN						= 1500,

	/// <summary>
	/// エージェントから選手を獲得できない
	/// </summary>
	AGENT_SIGN_FAILED					= 1501,

	/// <summary>
	/// クリスタルが不足
	/// </summary>
	AGENT_LACK_OF_CRYSTAL				= 1502,

	/// <summary>
	/// ゴールドが不足
	/// </summary>
	AGENT_LACK_OF_GOLD					= 1503,

	/// <summary>
	/// 獲得回数上限
	/// </summary>
	AGENT_USE_LIMIT						= 1504,

	/// <summary>
	/// 獲得選手がリストアップに見つからない
	/// </summary>
	AGENT_LIST_UP_PLAYER_NOT_FOUND		= 1505,

	/// <summary>
	/// ストックに空きがない
	/// </summary>
	AGENT_STOCK_FULL					= 1506,

	/// <summary>
	/// 獲得不可オーダー
	/// </summary>
	AGENT_UNACQUIRED_FORMATION			= 1507,

	/// <summary>
	/// エージェントポイントが不足
	/// </summary>
	AGENT_LACK_OF_AGENT_POINT			= 1508,

	/// <summary>
	/// オーダーショップが使用できない
	/// </summary>
	FORMATION_SHOP_NOT_OPEN				= 1509,

	/// <summary>
	/// クリスタルショップが使用できない
	/// </summary>
	CRYSTAL_SHOP_NOT_OPEN				= 1510,

	/// <summary>
	/// クリスタルショップの使用上限
	/// </summary>
	CRYSTAL_SHOP_USE_LIMIT				= 1511,

	/// <summary>
	/// ゴールドショップが使用できない
	/// </summary>
	GOLD_SHOP_NOT_OPEN					= 1512,

	/// <summary>
	/// ゴールドショップの使用上限
	/// </summary>
	GOLD_SHOP_USE_LIMIT					= 1513,

	/// <summary>
	/// ワンタイムセールが使用できない
	/// </summary>
	ONE_TIME_SALE_NOT_OPEN				= 1514,

	/// <summary>
	/// ワンタイムセールの使用上限
	/// </summary>
	ONE_TIME_SALE_USE_LIMIT				= 1515,

	/// <summary>
	/// エージェントの有効期限が過ぎている
	/// </summary>
	AGENT_LIMIT_DATE					= 1516,

	/// <summary>
	/// 18歳以下は月額3000円までしか購入できません
	/// </summary>
	SHOP_AGE_LIMIT						= 1517,

	//---------------- ミッション系(1600番台) ----------------
	/// <summary>
	/// ミッション報酬獲得不可
	/// </summary>
	MISSION_UNGRANTABLE_REWARD			= 1600,

	/// <summary>
	/// エラーが発生しました(エラーコード : 1601)
	/// </summary>
	INVALID_REWARD_DATA					= 1601,

	//---------------- 球会系(1700番台) ----------------
	/// <summary>
	/// 球会作成条件(トロフィー数)を満たしていない
	/// </summary>
	CLUB_CREATE_TROPHY_CONDITION_FAILED				= 1700,

	/// <summary>
	/// 設立期間制限
	/// </summary>
	CLUB_CREATE_INTERVAL_FAILED						= 1701,

	/// <summary>
	/// すでにほかの球会に所属している
	/// </summary>
	CLUB_CREATE_OTHER_CLUB_MEMBER					= 1702,

	/// <summary>
	/// 球会名が未入力
	/// </summary>
	CLUB_NAME_EMPTY									= 1703,

	/// <summary>
	/// 球会名が長すぎる
	/// </summary>
	CLUB_NAME_OVERFLOW								= 1704,

	/// <summary>
	/// 球会名に不正な文字が入っている
	/// </summary>
	CLUB_NAME_TABOO									= 1705,

	/// <summary>
	/// 不正な球会名
	/// </summary>
	INVALID_CLUB_NAME								= 1706,

	/// <summary>
	/// 球会説明が未入力
	/// </summary>
	CLUB_COMMENT_EMPTY								= 1707,

	/// <summary>
	/// 球会説明が長すぎる
	/// </summary>
	CLUB_COMMENT_OVERFLOW							= 1708,

	/// <summary>
	/// 球会説明に不正な文字が入っている
	/// </summary>
	CLUB_COMMENT_TABOO								= 1709,

	/// <summary>
	/// 不正な球会説明
	/// </summary>
	INVALID_CLUB_COMMENT							= 1710,

	/// <summary>
	/// 不正なトロフィー条件
	/// </summary>
	INVALID_TROPHY_LIMIT							= 1711,

	/// <summary>
	/// 不正な加入条件
	/// </summary>
	INVALID_ENTRY_CONDTION							= 1712,

	/// <summary>
	/// ゴールドが不足
	/// </summary>
	CLUB_CREATE_LACK_OF_GOLD						= 1713,

	/// <summary>
	/// 球会に所属していない
	/// </summary>
	CLUB_NOT_BELONG									= 1714,

	/// <summary>
	/// 解散条件を満たしていない
	/// </summary>
	CLUB_CLOSE_CONDITION_FAILED						= 1715,

	/// <summary>
	/// 球会が見つからない
	/// </summary>
	CLUB_NOT_FOUND									= 1716,

	/// <summary>
	/// すでに球会に所属している
	/// </summary>
	CLUB_ENTRY_ALREADY_CLUB_MEMBER					= 1717,

	/// <summary>
	/// 入会条件を満たしていない
	/// </summary>
	CLUB_ENTRY_CONDITION_FAILED						= 1718,

	/// <summary>
	/// 球会メンバーがいっぱい
	/// </summary>
	CLUB_MEMBER_FULL								= 1719,

	/// <summary>
	/// メッセージが入力されていない
	/// </summary>
	CLUB_CHAT_MESSAGE_EMPTY							= 1720,

	/// <summary>
	/// 権限がない
	/// </summary>
	CLUB_PERMISSION_DENIED							= 1721,

	/// <summary>
	/// 入会申請上限
	/// </summary>
	CLUB_ENTRY_REQUEST_FULL							= 1722,

	/// <summary>
	/// 入会申請メッセージが長すぎる
	/// </summary>
	CLUB_ENTRY_REQUEST_MESSAGE_OVERFLOW				= 1723,

	/// <summary>
	/// 入会条件を満たしていない
	/// </summary>
	CLUB_ENTRY_REQUEST_CONDITION_FAILED				= 1724,

	/// <summary>
	/// すでに申請している
	/// </summary>
	CLUB_ENTRY_REQUEST_ALREADY_SEND					= 1725,

	/// <summary>
	/// すでに球会に所属している
	/// </summary>
	CLUB_ENTRY_REQUEST_ALREADY_CLUB_MEMBER			= 1726,

	/// <summary>
	/// 自分を除名できない
	/// </summary>
	CLUB_CAN_NOT_EXPULSION_MYSELF					= 1727,

	/// <summary>
	/// 同じ球会に所属していない
	/// </summary>
	CLUB_NOT_SAME									= 1728,

	/// <summary>
	/// 不正な入会申請ID
	/// </summary>
	INVALID_CLUB_ENTRY_REQUEST_ID					= 1729,

	/// <summary>
	/// 不正な返答コード
	/// </summary>
	INVALID_CLUB_REPLY								= 1730,

	/// <summary>
	/// 有効な入会申請が見つからない
	/// </summary>
	CLUB_ENTRY_REQUEST_NOT_FOUND					= 1731,

	/// <summary>
	/// すでに球会に所属している
	/// </summary>
	CLUB_ENTRY_REQUEST_REPLY_ALREADY_CLUB_MEMBER	= 1732,

	/// <summary>
	/// 不正な球会ID
	/// </summary>
	INVALID_CLUB_ID									= 1733,

	/// <summary>
	/// 自分の役職を変更できない
	/// </summary>
	CLUB_CAN_NOT_ROLE_CHANGE_MYSELF					= 1734,

	/// <summary>
	/// 不正な役職変更種別
	/// </summary>
	INVALID_ROLE_CHANGE_TYPE						= 1735,

	/// <summary>
	/// 昇格できない
	/// </summary>
	CLUB_MEMBER_PROMOTE_FAILED						= 1736,

	/// <summary>
	/// 降格できない
	/// </summary>
	CLUB_MEMBER_DEMOTE_FAILED						= 1737,

	/// <summary>
	/// 自分を招待できない
	/// </summary>
	CLUB_CAN_NOT_INVITE_MYSELF						= 1738,

	/// <summary>
	/// すでに球会に所属している
	/// </summary>
	CLUB_INVIT_ALREADY_CLUB_MEMBER					= 1739,

	/// <summary>
	/// トロフィーが不足
	/// </summary>
	CLUB_INVIT_TROPHY_CONDITION_FAILED				= 1740,

	/// <summary>
	/// 不正な招待ID
	/// </summary>
	INVALID_CLUB_INVITE_ID							= 1741,

	/// <summary>
	/// 有効な障害が見つからない
	/// </summary>
	CLUB_INVITE_NOT_FOUND							= 1742,

	/// <summary>
	/// すでに球会に所属している
	/// </summary>
	CLUB_INVITE_REPLY_ALREADY_CLUB_MEMBER			= 1743,

	/// <summary>
	/// トレード回数制限
	/// </summary>
	CLUB_TRADE_COUNT_LIMIT							= 1744,

	/// <summary>
	/// トレード料金が指定価格帯を外れている
	/// </summary>
	CLUB_TRADE_PRICE_OUT_OF_RANGE					= 1745,

	/// <summary>
	/// 不正なトレードID
	/// </summary>
	INVALID_TRADE_ID								= 1746,

	/// <summary>
	/// トレードが見つからない
	/// </summary>
	CLUB_TRADE_NOT_FOUND							= 1747,

	/// <summary>
	/// シーズン中のトレード回数制限
	/// </summary>
	CLUB_TRADE_GET_COUNT_LIMIT						= 1748,

	/// <summary>
	/// トレードインターバル中
	/// </summary>
	CLUB_TRADE_INTERVAL								= 1749,

	/// <summary>
	/// 自分のトレード
	/// </summary>
	CLUB_TRADE_NOT_COMPLETE_MY_OWN					= 1750,

	/// <summary>
	/// 不正な役職コード
	/// </summary>
	INVALID_ROLE_TYPE_CODE							= 1751,

	/// <summary>
	/// リーダー変更できない
	/// </summary>
	CLUB_CAN_NOT_LEADER_CHANGE						= 1752,

	/// <summary>
	/// 自分にエールできない
	/// </summary>
	CLUB_CAN_NOT_YELL_MYSELF						= 1753,

	/// <summary>
	/// エール回数制限
	/// </summary>
	CLUB_YELL_COUNT_LIMIT							= 1754,

	/// <summary>
	/// エールインターバル中
	/// </summary>
	CLUB_YELL_INTERVAL								= 1755,

	/// <summary>
	/// 1日の中で同じ人へは送れない
	/// </summary>
	INVALID_CLUB_YELL_TARGET						= 1756,

	/// <summary>
	/// シェアする試合が見つからない
	/// </summary>
	CLUB_SHARE_MATCH_NOT_FOUND						= 1757,

	/// <summary>
	/// 不正な検索条件
	/// </summary>
	INVALID_CLUB_SEARCH_CONDITION					= 1758,
	
	/// <summary>
	/// すでに招待している
	/// </summary>
	ALREADY_INVITE									= 1760,

	/// <summary>
	/// メッセージに不正な文字が入っている
	/// </summary>
	CLUB_CHAT_MESSAGE_TABOO							= 1761,

	/// <summary>
	/// メッセージに禁止ワードが含まれています
	/// </summary>
	CLUB_ENTRY_REQUEST_MESSAGE_TABOO				= 1762,

	/// <summary>
	/// ゴールドが不足しています
	/// </summary>
	TRADE_COMPLETE_LACK_OF_GOLD						= 1763,

	/// <summary>
	/// お返しできるエールがありません
	/// </summary>
	REPLYABLE_CLUB_YELL_NOT_EXIST					= 1764,

	/// <summary>
	/// 1日に送れるエールのお返し数が上限に達しています
	/// </summary>
	REPLY_CLUB_YELL_COUNT_LIMIT						= 1765,

	/// <summary>
	/// トレード不可の選手
	/// </summary>
	CLUB_PLAYER_NOT_TRADABLE						= 1766,

	//---------------- チュートリアル系(1800番台) ----------------
	/// <summary>
	/// 不正なチュートリアル進行
	/// </summary>
	INVALID_TUTORIAL_STEP				= 1800,

	/// <summary>
	/// チュートリアル完了済み
	/// </summary>
	TUTORIAL_CMOPLETED					= 1801,

	//---------------- 編成系(1900番台) ----------------
	/// <summary>
	/// 不正なデッキ
	/// </summary>
	INVALID_DECK = 1901,

	//---------------- メール系(2000番台) ----------------
	/// <summary>
	/// 添付が獲得できない
	/// </summary>
	MAIL_UNACQUIRED_ATTACHMENT		= 2000,

	/// <summary>
	/// メールが削除できない
	/// </summary>
	MAIL_CAN_NOT_DELETE				= 2001,

	/// <summary>
	/// メールが見つからない
	/// </summary>
	MAIL_NOT_FOUND					= 2002,

	//---------------- 移籍系(2100番台) ----------------
	/// <summary>
	/// スロットが空いていない
	/// </summary>
	TRANSFER_PLAYER_SLOT_NOT_EMPTY		= 2100,

	/// <summary>
	/// 登録状態でない
	/// </summary>
	TRANSFER_PLAYER_SLOT_NOT_REGIST		= 2101,

	/// <summary>
	/// 期限切れ
	/// </summary>
	TRANSFER_EXPIRE						= 2102,

	/// <summary>
	/// 契約状態でない
	/// </summary>
	TRANSFER_NOT_SIGN					= 2103,

	/// <summary>
	/// 移籍機能が開放されていない
	/// </summary>
	TRANSFER_NOT_OPEN					= 2104,

	/// <summary>
	/// スロットが開放されていない
	/// </summary>
	TRANSFER_SLOT_NOT_OPEN				= 2105,

	/// <summary>
	/// スロットが使用中
	/// </summary>
	TRANSFER_SLOT_IN_USE				= 2106,

	/// <summary>
	/// ストック選手が見つからない
	/// </summary>
	TRANSFER_STOCK_PLAYER_NOT_FOUND		= 2107,

	/// <summary>
	/// ストック選手がストック以外の状態
	/// </summary>
	TRANSFER_STOCK_PLAYER_NOT_STAY		= 2108,

	/// <summary>
	/// 移籍金が限度額範囲外
	/// </summary>
	TRANSFER_PRICE_OUT_OF_RANGE			= 2109,

	/// <summary>
	/// 移籍選手が見つからない
	/// </summary>
	TRANSFER_PLAYER_NOT_FOUND			= 2110,

	/// <summary>
	/// シーズン移籍回数上限
	/// </summary>
	TRANSFER_SEASON_SIGN_LIMIT			= 2111,

	/// <summary>
	/// ストックに空きがない
	/// </summary>
	TRANSFER_NO_STOCK_SPACE				= 2112,

	/// <summary>
	/// 売約済み等で契約不可
	/// </summary>
	TRANSFER_SOLD_OUT					= 2113,

	/// <summary>
	/// 所持ゴールド不足
	/// </summary>
	TRANSFER_LACK_OF_GOLD				= 2114,

	/// <summary>
	/// クリアできない
	/// </summary>
	TRANSFER_CAN_NOT_CLEAR_SLOT			= 2115,

	/// <summary>
	/// すでに登録済み
	/// </summary>
	TRANSFER_DUPLICATE_ENTRY			= 2116,

	/// <summary>
	/// この選手は移籍登録できません
	/// </summary>
	TRANSFER_PLAYER_NOT_TRADABLE		= 2117,

	//---------------- 課金系(2200番台) ----------------
	/// <summary>
	/// 課金：不明なエラー
	/// </summary>
	CURRENCY_FATAL_ERROR				= 2200,

	/// <summary>
	/// 課金：パラメータエラー
	/// </summary>
	CURRENCY_VALIDATION_ERROR			= 2201,

	//---------------- 試合情報系(2300番台) ----------------
	/// <summary>
	/// 試合が見つからない
	/// </summary>
	MATCH_DETAIL_MATCH_NOT_FOUND		= 2300,

	/// <summary>
	/// シリーズが見つからない
	/// </summary>
	MATCH_SCORE_SERIES_NOT_FOUND		= 2301,

	//---------------- データ引継(2400番台) ----------------
	/// <summary>
	/// データ引継設定がない
	/// </summary>
	TEAM_DATA_MIGRATION_NOT_CONFIGURE			= 2400,

	/// <summary>
	/// すでにデータ引継設定済
	/// </summary>
	TEAM_DATA_MIGRATION_ALREADY_COFIGURE		= 2401,

	/// <summary>
	/// データ引継データが見つからない
	/// </summary>
	TEAM_DATA_MIGRATION_NOT_FOUND				= 2402,

	/// <summary>
	/// google verify security error
	/// </summary>
	TEAM_DATA_MIGRATION_GOOGLE_VERIFY_ERROR1	= 2403,

	/// <summary>
	///  google verify IO error
	/// </summary>
	TEAM_DATA_MIGRATION_GOOGLE_VERIFY_ERROR2	= 2404,

	/// <summary>
	/// google verify error
	/// </summary>
	TEAM_DATA_MIGRATION_GOOGLE_VERIFY_ERROR3	= 2405,

	/// <summary>
	/// 不正なID Token
	/// </summary>
	TEAM_DATA_MIGRATION_INVALID_GOOGLE_ID_TOKEN	= 2406,

	/// <summary>
	/// データ引継の設定回数が上限に達しています
	/// </summary>
	TEAM_DATA_MIGRATION_LACK_OF_MIGRATION_RIGHT	= 2407,

	//---------------- 運営大会系(2500番台) ----------------

	/// <summary>
	/// セクションが見つからない
	/// </summary>
	EC_NO_SECTION_DATA						= 2500,

	/// <summary>
	/// セクションが開放されていない
	/// </summary>
	EC_SECTION_NOT_OPEN						= 2501,

	/// <summary>
	/// クリスタルが足りない
	/// </summary>
	EC_LACK_OF_CRYSTAL						= 2502,

	/// <summary>
	/// ゴールドが足りない
	/// </summary>
	EC_LACK_OF_GOLD							= 2503,

	/// <summary>
	/// 既にエントリーしている
	/// </summary>
	DUPLICATE_EC_ENTRY						= 2504,

	/// <summary>
	/// セクションは試合中である
	/// </summary>
	EC_SECTION_MATCH						= 2505,

	/// <summary>
	/// セクションは終了している
	/// </summary>
	EC_SECTION_CLOSE						= 2506,

	/// <summary>
	/// セクションの状態が異常
	/// </summary>
	INVALID_EC_STATUS						= 2507,

	/// <summary>
	/// そのセクションにはエントリーしていない
	/// </summary>
	EC_SECTION_NO_ENTRY						= 2508,

	/// <summary>
	/// セクションにデッキ情報が無い
	/// </summary>
	EC_SECTION_NO_DECK						= 2509,

	/// <summary>
	/// セクションに選手情報が無い
	/// </summary>
	EC_SECTION_NO_PLAYER					= 2510,

	/// <summary>
	/// この大会は終了していません
	/// </summary>
	EC_SECTION_NOT_CLOSE					= 2511,

	/// <summary>
	/// エラーが発生しました(エラーコード : 2512)
	/// </summary>
	EC_NO_LEAGUE_DATA						= 2512,

	/// <summary>
	/// この大会は終了していません
	/// </summary>
	EC_LEAGUE_NOT_CLOSE						= 2513,

	/// <summary>
	/// 参加条件のリーグランクを満たしていません(エラーコード : 2514)
	/// </summary>
	EC_UNMATCH_LEAGUE_RANK					= 2514,

	/// <summary>
	/// 参加条件のオーダーを満たしていません(エラーコード : 2515)
	/// </summary>
	EC_UNMATCH_FORMATION					= 2515,

	/// <summary>
	/// 参加条件の選手を満たしていません(エラーコード : 2516)
	/// </summary>
	EC_UNMATCH_PLAYER						= 2516,

	/// <summary>
	/// エントリー時間外です(エラーコード : 2517)
	/// </summary>
	EC_FAILED_ENTRY_OUT_SCHEDULE			= 2517,

	//---------------- 友達招待(2600番台) ----------------
	/// <summary>
	/// エラーが発生しました(エラーコード : 2600)
	/// </summary>
	INVITE_FRIEND_ALREADY_COMPLE		= 2600,

	/// <summary>
	/// エラーが発生しました(エラーコード : 2601)
	/// </summary>
	INVITE_FRIEND_URL_BUILD_FAILED		= 2601,

	//---------------- 課金(100000番台以上) ----------------
	PURCHASE_ERROR = 100000,
}