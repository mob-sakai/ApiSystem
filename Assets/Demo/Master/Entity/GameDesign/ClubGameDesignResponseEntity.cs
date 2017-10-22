using System;
using UnityEngine;
using System.Collections.Generic;
using MsgPack.Serialization;
using Mobcast.Coffee.Api;

/// <summary>
/// レスポンスエンティティ：球会ゲームデザインデータ
/// </summary>
[Serializable]
public class ClubGameDesignResponseEntity : IResponsePacket {

	#region private properties
	/// <summary>
	/// 球会機能開放条件(トロフィー数) 
	/// </summary>
	[SerializeField][MessagePackMember(0)]
	private int requirement = new int ();

	/// <summary>
	/// 球会設立費用(ゴールド)
	/// </summary>
	[SerializeField][MessagePackMember(1)]
	private int foundationCostGold = new int ();

	/// <summary>
	/// 球会メンバー最大数
	/// </summary>
	[SerializeField][MessagePackMember(2)]
	private int maxMember = new int ();

	/// <summary>
	/// 練習試合実行回数
	/// </summary>
	[SerializeField][MessagePackMember(3)]
	private int practiceMatchLimit = new int ();

	/// <summary>
	/// 練習試合インターバル時間(秒)
	/// </summary>
	[SerializeField][MessagePackMember(4)]
	private int practiceMatchIntervalPeriod = new int ();

	/// <summary>
	/// エール実行回数
	/// </summary>
	[SerializeField][MessagePackMember(5)]
	private int yellLimit = new int ();

	/// <summary>
	/// エールインターバル時間(秒)
	/// </summary>
	[SerializeField][MessagePackMember(6)]
	private int yellIntervalPeriod = new int ();

	/// <summary>
	/// シーズン中の移籍獲得最大数
	/// </summary>
	[SerializeField][MessagePackMember(7)]
	private int tradeUseLimit = new int ();

	/// <summary>
	/// トレード選手獲得インターバル時間(秒)
	/// </summary>
	[SerializeField][MessagePackMember(8)]
	private int tradeIntervalPeriod = new int ();

	/// <summary>
	/// トレード限度額：ノーマル
	/// </summary>
	[SerializeField][MessagePackMember(9)]
	private TradePriceItemResponseEntity normalTradePriceItem = new TradePriceItemResponseEntity ();

	/// <summary>
	/// トレード限度額：レア
	/// </summary>
	[SerializeField][MessagePackMember(10)]
	private TradePriceItemResponseEntity rareTradePriceItem = new TradePriceItemResponseEntity ();

	/// <summary>
	/// トレード限度額：スーパーレア
	/// </summary>
	[SerializeField][MessagePackMember(11)]
	private TradePriceItemResponseEntity superRareTradePriceItem = new TradePriceItemResponseEntity ();

	/// <summary>
	/// トレード限度額：ウルトラレア
	/// </summary>
	[SerializeField][MessagePackMember(12)]
	private TradePriceItemResponseEntity ultraRareTradePriceItem = new TradePriceItemResponseEntity ();
	#endregion
	#region private properties
	/// <summary>
	/// 球会機能開放条件(トロフィー数) 
	/// </summary>
	public int Requirement { get; private set; }

	/// <summary>
	/// 球会設立費用(ゴールド)
	/// </summary>
	public int FoundationCostGold { get; private set; }

	/// <summary>
	/// 球会メンバー最大数
	/// </summary>
	public int MaxMember { get; private set; }

	/// <summary>
	/// 練習試合実行回数
	/// </summary>
	public int PracticeMatchLimit { get; private set; }

	/// <summary>
	/// 練習試合インターバル時間(秒)
	/// </summary>
	public int PracticeMatchIntervalPeriod { get; private set; }

	/// <summary>
	/// エール実行回数
	/// </summary>
	public int YellLimit { get; private set; }

	/// <summary>
	/// エールインターバル時間(秒)
	/// </summary>
	public int YellIntervalPeriod { get; private set; }

	/// <summary>
	/// シーズン中の移籍獲得最大数
	/// </summary>
	public int TradeUseLimit { get; private set; }

	/// <summary>
	/// トレード選手獲得インターバル時間(秒)
	/// </summary>
	public int TradeIntervalPeriod { get; private set; }

	/// <summary>
	/// トレード限度額：ノーマル
	/// </summary>
	public TradePriceItemResponseEntity NormalTradePriceItem { get; private set; }

	/// <summary>
	/// トレード限度額：レア
	/// </summary>
	public TradePriceItemResponseEntity RareTradePriceItem { get; private set; }

	/// <summary>
	/// トレード限度額：スーパーレア
	/// </summary>
	public TradePriceItemResponseEntity SuperRareTradePriceItem { get; private set; }

	/// <summary>
	/// トレード限度額：ウルトラレア
	/// </summary>
	public TradePriceItemResponseEntity UltraRareTradePriceItem { get; private set; }
	#endregion


	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		Requirement = requirement;
		FoundationCostGold = foundationCostGold;
		MaxMember = maxMember;
		PracticeMatchLimit = practiceMatchLimit;
		PracticeMatchIntervalPeriod = practiceMatchIntervalPeriod;
		YellLimit = yellLimit;
		YellIntervalPeriod = yellIntervalPeriod;
		TradeUseLimit = tradeUseLimit;
		TradeIntervalPeriod = tradeIntervalPeriod;
		NormalTradePriceItem = normalTradePriceItem.DeserializeOrDefault(header);
		RareTradePriceItem = rareTradePriceItem.DeserializeOrDefault(header);
		SuperRareTradePriceItem = superRareTradePriceItem.DeserializeOrDefault(header);
		UltraRareTradePriceItem = ultraRareTradePriceItem.DeserializeOrDefault(header);
	}

}

