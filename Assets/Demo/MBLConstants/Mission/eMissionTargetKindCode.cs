using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// ミッション達成条件種類コード
/// </summary>
public enum eMissionTargetKindCode 
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID = -1,

	/// <summary>
	/// 通算ログイン日数
	/// </summary>
	TOTAL_LOGIN = 0,

	/// <summary>
	/// オーダーカード収集
	/// </summary>
	FORMATION_COLLECTION = 1,

	/// <summary>
	/// 選手カード収集
	/// </summary>
	PLAYER_COLLECTION = 2,

	/// <summary>
	/// 通算勝利回数
	/// </summary>
	TOTAL_WINS = 3,

	/// <summary>
	/// 通算優勝回数
	/// </summary>
	TOTAL_VICTORIES = 4,

	/// <summary>
	/// レジェンドリーグ優勝回数
	/// </summary>
	TOTAL_LEGEND_VICTORIES = 5,

	/// <summary>
	/// 最多獲得トロフィー数
	/// </summary>
	BEST_TROPHY_COUNT = 6,

	/// <summary>
	/// 通算首位打者獲得数
	/// </summary>
	TOTAL_AVG_LEADER = 7,

	/// <summary>
	/// 通算打点王獲得数
	/// </summary>
	TOTAL_RBI_LEADER = 8,

	/// <summary>
	/// 通算本塁王獲得数
	/// </summary>
	TOTAL_HR_LEADER = 9,

	/// <summary>
	/// 通算盗塁王獲得数
	/// </summary>
	TOTAL_SB_LEADER = 10,

	/// <summary>
	/// 通算最優秀防御率獲得数
	/// </summary>
	TOTAL_ERA_LEADER = 11,

	/// <summary>
	/// 通算最多勝獲得数
	/// </summary>
	TOTAL_MOST_WINS = 12,

	/// <summary>
	/// 通算セーブ王獲得数
	/// </summary>
	TOTAL_SV_LEADER = 13,

	/// <summary>
	/// 通算奪三振王獲得数
	/// </summary>
	TOTAL_SO_LEADER = 14,

	/// <summary>
	/// 通算投手三冠王獲得数
	/// </summary>
	TOTAL_PITCHER_TRIPLE_CROWN = 15,

	/// <summary>
	/// 通算打撃三冠王獲得数
	/// </summary>
	TOTAL_BATTER_TRIPLE_CROWN = 16,

	/// <summary>
	/// 通算ノーヒットノーラン達成数
	/// </summary>
	TOTAL_NO_HIT_NO_RUN = 17,

	/// <summary>
	/// 通算完全試合達成数
	/// </summary>
	TOTAL_PERFECT_GAME = 18,

	/// <summary>
	/// リーグランク到達
	/// </summary>
	BEST_LEAGUE_RANK = 19,

	/// <summary>
	/// 球会に入会
	/// </summary>
	CLUB_ENTRY = 20,

	/// <summary>
	/// 移籍登録
	/// </summary>
	TRANSFER_ENTRY = 21,

	/// <summary>
	/// レビュー投稿：APP STORE
	/// </summary>
	POST_REVIEW_APP_STORE = 22,

	/// <summary>
	/// レビュー投稿：GOOGLE PLAY
	/// </summary>
	POST_REVIEW_GOOGLE_PLAY = 23,

	/// <summary>
	/// SNS投稿：Twitter
	/// </summary>
	POST_SNS_TWITTER = 24,

	/// <summary>
	/// SNS投稿：LINE
	/// </summary>
	POST_SNS_LINE = 25,

	/// <summary>
	/// SNS投稿：Facebook
	/// </summary>
	POST_SNS_FACEBOOK = 26,

	/// <summary>
	/// サイト遷移
	/// </summary>
	SITE_TRANSITION = 27,

	/// <summary>
	/// シーズンログイン日数
	/// </summary>
	SEASON_LOGIN = 1001,

	/// <summary>
	/// シーズンチーム本塁打数
	/// </summary>
	SEASON_TEAM_HR = 1002,

	/// <summary>
	/// シーズンチーム盗塁数
	/// </summary>
	SEASON_TEAM_SB = 1003,

	/// <summary>
	/// シーズンチーム奪三振数
	/// </summary>
	SEASON_TEAM_SO = 1004,

	/// <summary>
	/// シーズンチーム得点数
	/// </summary>
	SEASON_TEAM_SCORE = 1005,

	/// <summary>
	/// 首位打者獲得
	/// </summary>
	SEASON_AVG_LEADER = 1006,

	/// <summary>
	/// 打点王獲得
	/// </summary>
	SEASON_RBI_LEADER = 1007,

	/// <summary>
	/// 本塁打王獲得
	/// </summary>
	SEASON_HR_LEADER = 1008,

	/// <summary>
	/// 盗塁王獲得
	/// </summary>
	SEASON_SB_LEADER = 1009,

	/// <summary>
	/// 最優秀防御率獲得
	/// </summary>
	SEASON_ERA_LEADER = 1010,

	/// <summary>
	/// 最多勝獲得
	/// </summary>
	SEASON_MOST_WINS = 1011,

	/// <summary>
	/// セーブ王獲得
	/// </summary>
	SEASON_SV_LEADER = 1012,

	/// <summary>
	/// 奪三振王獲得
	/// </summary>
	SEASON_SO_LEADER = 1013,

	/// <summary>
	/// リーグ優勝
	/// </summary>
	SEASON_VICTORY = 1014,
}
