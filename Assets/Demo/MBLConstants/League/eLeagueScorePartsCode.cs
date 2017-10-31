
/// <summary>
/// LeagueRankingScorePartsで用いるスコアの表示タイプ.
/// </summary>
public enum eLeagueScorePartsCode
{
	/// <summary> 初期値. </summary>
	[AliasAttribute ("")]Default = -1,
	/// <summary> 勝利数. </summary>
	[AliasAttribute ("勝")]Win,
	/// <summary> 敗北数. </summary>
	[AliasAttribute ("負")]Lose,
	/// <summary> 引き分け数. </summary>
	[AliasAttribute ("分")]Draw,
	/// <summary> 勝率. </summary>
	[AliasAttribute ("勝率")]WinAverage,
	/// <summary> ゲーム差. </summary>
	[AliasAttribute ("差")]GameBehind,
	/// <summary> 得点. </summary>
	[AliasAttribute ("得点")]FielderR,
	/// <summary> 失点. </summary>
	[AliasAttribute ("失点")]PitcherR,
	/// <summary> 打率. </summary>
	[AliasAttribute ("打率")]BattingAverage,
	/// <summary> 防御率. </summary>
	[AliasAttribute ("防御率")]EarnedRunAverage,
	/// <summary> 本塁打. </summary>
	[AliasAttribute ("本塁打")]HomeRun,
	/// <summary> 盗塁. </summary>
	[AliasAttribute ("盗塁")]StolenBases,
//	/// <summary> セーブ数. </summary>
//	[AliasAttribute ("セーブ")]Saves,
	/// <summary> 奪三振数. </summary>
	[AliasAttribute ("奪三振")]StrikeOuts,
	/// <summary> 安打. </summary>
	[AliasAttribute ("安打")]Hit,
	/// <summary> 打点. </summary>
	[AliasAttribute ("打点")]Rbi,
}
