using System;
using System.Collections.Generic;
using MsgPack.Serialization;
using Mobcast.Coffee.Api;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// レスポンスエンティティ：移籍ゲームデザインデータ
/// </summary>
[Serializable]
public  class TransferGameDesignResponseEntity : IResponsePacket {
	#region private properties
	/// <summary>
	/// リーグ別移籍選手リスト数
	/// </summary>
	[SerializeField][MessagePackMember(0)]
	private TransferListupNumbersResponseEntity transferListupNumbers = new TransferListupNumbersResponseEntity ();

	/// <summary>
	/// 移籍金限度額
	/// </summary>
	[SerializeField][MessagePackMember(1)]
	private MarketPriceResponseEntity marketPrice = new MarketPriceResponseEntity ();

	/// <summary>
	/// 移籍機能開放条件(トロフィー数)
	/// </summary>
	[SerializeField][MessagePackMember(2)]
	private int requirementTrophy = new int ();

	/// <summary>
	/// 移籍登録スロット3開放条件(リーグランクコード値)
	/// </summary>
	[SerializeField][MessagePackMember(3)]
	private int slot3RequirementLeagueRank = new int ();

	/// <summary>
	/// 移籍登録スロット4開放条件(リーグランクコード値)
	/// </summary>
	[SerializeField][MessagePackMember(4)]
	private int slot4RequirementLeagueRank = new int ();

	/// <summary>
	/// 移籍登録有効時間(秒)
	/// </summary>
	[SerializeField][MessagePackMember(5)]
	private int registrationPeriodSec = new int ();

	/// <summary>
	/// 移籍スロット再利用時間(秒)
	/// </summary>
	[SerializeField][MessagePackMember(6)]
	private int registrationIntervalSec = new int ();

	/// <summary>
	/// 移籍金手数料(%)
	/// </summary>
	[SerializeField][MessagePackMember(7)]
	private int commissionRate = new int ();

	/// <summary>
	/// 移籍リスト有効時間(秒)
	/// </summary>
	[SerializeField][MessagePackMember(8)]
	private int listupPeriodSec = new int ();

	/// <summary>
	/// シーズン中の最大契約数
	/// </summary>
	[SerializeField][MessagePackMember(9)]
	private int useLimit = new int ();
	#endregion

	#region public properties
	/// <summary>
	/// リーグ別移籍選手リスト数
	/// </summary>
	public TransferListupNumbersResponseEntity TransferListupNumbers { get; private set; }

	/// <summary>
	/// 移籍金限度額
	/// </summary>
	public MarketPriceResponseEntity MarketPrice { get; private set; }

	/// <summary>
	/// 移籍機能開放条件(トロフィー数)
	/// </summary>
	public int RequirementTrophy { get; private set; }

	/// <summary>
	/// 移籍登録スロット3開放条件(リーグランクコード)
	/// </summary>
	public eLeagueRankCode Slot3RequirementLeagueRank { get; private set; }

	/// <summary>
	/// 移籍登録スロット4開放条件(リーグランクコード)
	/// </summary>
	public eLeagueRankCode Slot4RequirementLeagueRank { get; private set; }

	/// <summary>
	/// 移籍登録有効時間(秒)
	/// </summary>
	public int RegistrationPeriodSec { get; private set; }

	/// <summary>
	/// 移籍スロット再利用時間(秒)
	/// </summary>
	public int RegistrationIntervalSec { get; private set; }

	/// <summary>
	/// 移籍金手数料(%)
	/// </summary>
	public int CommissionRate { get; private set; }

	/// <summary>
	/// 移籍リスト有効時間(秒)
	/// </summary>
	public int ListupPeriodSec { get; private set; }

	/// <summary>
	/// シーズン中の最大契約数
	/// </summary>
	public int UseLimit { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		TransferListupNumbers		= transferListupNumbers.DeserializeOrDefault(header);
		MarketPrice					= marketPrice.DeserializeOrDefault(header);
		RequirementTrophy			= requirementTrophy;
		Slot3RequirementLeagueRank = (eLeagueRankCode)slot3RequirementLeagueRank;
		Slot4RequirementLeagueRank = (eLeagueRankCode)slot4RequirementLeagueRank;
		RegistrationPeriodSec		= registrationPeriodSec;
		RegistrationIntervalSec		= registrationIntervalSec;
		CommissionRate				= commissionRate;
		ListupPeriodSec				= listupPeriodSec;
		UseLimit					= useLimit;
	}

}

