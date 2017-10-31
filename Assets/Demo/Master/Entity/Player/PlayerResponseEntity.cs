using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// 選手データ
/// </summary>
[Serializable]
public class PlayerResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// 選手ID
	/// </summary>
	[SerializeField][MessagePackMember (0)]
	private int playerId = new int ();

	/// <summary>
	/// 姓
	/// </summary>
	[SerializeField][MessagePackMember (1)]
	private string familyName = string.Empty;

	/// <summary>
	/// 名
	/// </summary>
	[SerializeField][MessagePackMember (2)]
	private string firstName = string.Empty;

	/// <summary>
	/// 姓(ふりがな)
	/// </summary>
	[SerializeField][MessagePackMember (3)]
	private string familyNameRuby = string.Empty;

	/// <summary>
	/// 名(ふりがな)
	/// </summary>
	[SerializeField][MessagePackMember (4)]
	private string firstNameRuby = string.Empty;

	/// <summary>
	/// 表記パターン１
	/// </summary>
	[SerializeField][MessagePackMember (5)]
	private string displayName1 = string.Empty;

	/// <summary>
	/// 表記パターン２
	/// </summary>
	[SerializeField][MessagePackMember (6)]
	private string displayName2 = string.Empty;

	/// <summary>
	/// 表記パターン３
	/// </summary>
	[SerializeField][MessagePackMember (7)]
	private string displayName3 = string.Empty;

	/// <summary>
	/// ふりがな表記1
	/// </summary>
	[SerializeField][MessagePackMember (8)]
	private string displayRuby1 = string.Empty;

	/// <summary>
	/// 選手ナレッジID
	/// </summary>
	[SerializeField][MessagePackMember (9)]
	private int playerKnowledgeId = new int ();

	/// <summary>
	/// ライセンスコード値
	/// </summary>
	[SerializeField][MessagePackMember (10)]
	private int license = new int ();

	/// <summary>
	/// レアリティコード値
	/// </summary>
	[SerializeField][MessagePackMember (11)]
	private int cardRarity = new int ();

	/// <summary>
	/// フィールドコード値
	/// </summary>
	[SerializeField][MessagePackMember (12)]
	private int field = new int ();

	/// <summary>
	/// 利き投げコード値
	/// </summary>
	[SerializeField][MessagePackMember (13)]
	private int pitchHandedType = new int ();

	/// <summary>
	/// 利き打ちコード値
	/// </summary>
	[SerializeField][MessagePackMember (14)]
	private int hitHandedType = new int ();

	/// <summary>
	/// 投球フォームコード値
	/// </summary>
	[SerializeField][MessagePackMember (15)]
	private int pitchingForm = new int ();

	/// <summary>
	/// 打撃フォームコード値
	/// </summary>
	[SerializeField][MessagePackMember (16)]
	private int battingForm = new int ();

	/// <summary>
	/// [野手のみ] 打順適正リスト
	/// </summary>
	[SerializeField][MessagePackMember (17)]
	private List<BattingOrderMatchResponseEntity> battingOrderMatchList = new List<BattingOrderMatchResponseEntity> ();

	/// <summary>
	/// [野手のみ] 守備適正コード値リスト
	/// </summary>
	[SerializeField][MessagePackMember (18)]
	private List<PositionMatchResponseEntity> positionMatchList = new List<PositionMatchResponseEntity> ();

	/// <summary>
	/// [投手のみ] 投手適正コード値リスト
	/// </summary>
	[SerializeField][MessagePackMember (19)]
	private List<PitchMatchResponseEntity> pitchMatchList = new List<PitchMatchResponseEntity> ();

	/// <summary>
	/// [野手のみ] 期数ごとの野手能力値リスト
	/// </summary>
	[SerializeField][MessagePackMember (20)]
	private List<PlayerFielderStatusResponseEntity> playerFielderStatusList = new List<PlayerFielderStatusResponseEntity> ();

	/// <summary>
	/// [投手のみ] 期数ごとの投手能力値リスト
	/// </summary>
	[SerializeField][MessagePackMember (21)]
	private List<PlayerPitcherStatusResponseEntity> playerPitcherStatusList = new List<PlayerPitcherStatusResponseEntity> ();

	/// <summary>
	/// [投手のみ] 球種コード値リスト
	/// </summary>
	[SerializeField][MessagePackMember (22)]
	private List<int> ballTypeList = new List<int> ();

	/// <summary>
	/// [投手のみ] 最高球速(km/s)
	/// </summary>
	[SerializeField][MessagePackMember (23)]
	private int maxSpeed = new int ();

	/// <summary>
	/// 特性データリスト
	/// </summary>
	[SerializeField][MessagePackMember (24)]
	private List<SkillResponseEntity> skillList = new List<SkillResponseEntity> ();

	/// <summary>
	/// 自由契約価格
	/// </summary>
	[SerializeField][MessagePackMember (25)]
	private int price = new int ();

	/// <summary>
	/// キャッチコピー
	/// </summary>
	[SerializeField][MessagePackMember (26)]
	private string catchCopy = string.Empty;

	/// <summary>
	/// 説明
	/// </summary>
	[SerializeField][MessagePackMember (27)]
	private string description = string.Empty;

	/// <summary>
	/// 移籍・トレード不可フラグ
	/// </summary>
	[SerializeField][MessagePackMember (28)]
	private bool isDisableTrading = new bool();
	#endregion

	#region public properties
	/// <summary>
	/// 選手ID
	/// </summary>
	public int PlayerId { get; private set; }

	/// <summary>
	/// 姓
	/// </summary>
	public string FamilyName { get; private set; }

	/// <summary>
	/// 名
	/// </summary>
	public string FirstName { get; private set; }

	/// <summary>
	/// 姓(ふりがな)
	/// </summary>
	public string FamilyNameRuby { get; private set; }

	/// <summary>
	/// 名(ふりがな)
	/// </summary>
	public string FirstNameRuby { get; private set; }

	/// <summary>
	/// 表記パターン１（フルネーム）
	/// </summary>
	public string DisplayName1 { get; private set; }

	/// <summary>
	/// 表記パターン２（略語）
	/// </summary>
	public string DisplayName2 { get; private set; }

	/// <summary>
	/// 表記パターン３（ニックネーム）
	/// </summary>
	public string DisplayName3 { get; private set; }

	/// <summary>
	/// ふりがな表記1
	/// </summary>
	public string DisplayRuby1 { get; private set; }

	/// <summary>
	/// 選手ナレッジID
	/// </summary>
	public int PlayerKnowledgeId { get; private set; }

	/// <summary>
	/// ライセンスコード
	/// </summary>
	public eLicenseCode LicenseCode { get; private set; }

	/// <summary>
	/// レアリティコード
	/// </summary>
	public eCardRarityCode CardRarityCode { get; private set; }

	/// <summary>
	/// フィールドコード
	/// </summary>
	public eFieldCode FieldCode { get; private set; }

	/// <summary>
	/// 利き投げコード
	/// </summary>
	public eHandedTypeCode PitchHandedTypeCode { get; private set; }

	/// <summary>
	/// 利き打ちコード
	/// </summary>
	public eHandedTypeCode HitHandedTypeCode { get; private set; }

	/// <summary>
	/// 投球フォームコード
	/// </summary>
	public ePitchingFormCode PitchingFormCode { get; private set; }

	/// <summary>
	/// 打撃フォームコード
	/// </summary>
	public eBattingFormCode BattingFormCode { get; private set; }

	/// <summary>
	/// [野手のみ] 打順適正マップ
	/// </summary>
	public Dictionary<eBattingOrderCode, BattingOrderMatchResponseEntity> BattingOrderMatchMap { get; private set; }

	/// <summary>
	/// [野手のみ] 守備適正コード値マップ
	/// </summary>
	public Dictionary<ePositionCode, PositionMatchResponseEntity> PositionMatchMap { get; private set; }

	/// <summary>
	/// [投手のみ] 投手適正コード値マップ
	/// </summary>
	public Dictionary<eMemberTypeCode, PitchMatchResponseEntity> PitchMatchMap { get; private set; }

	/// <summary>
	/// [野手のみ] 期数ごとの野手能力値マップ
	/// </summary>
	public Dictionary<int, PlayerFielderStatusResponseEntity> PlayerFielderStatusMap { get; private set; }

	/// <summary>
	/// [投手のみ] 期数ごとの投手能力値マップ
	/// </summary>
	public Dictionary<int, PlayerPitcherStatusResponseEntity> PlayerPitcherStatusMap { get; private set; }

	/// <summary>
	/// [投手のみ] 球種コードリスト
	/// </summary>
	public List<eBallTypeCode> BallTypeCodeList { get; private set; }

	/// <summary>
	/// [投手のみ] 最高球速(km/s)
	/// </summary>
	public int MaxSpeed { get; private set; }

	/// <summary>
	/// 特性データリスト
	/// </summary>
	public List<SkillResponseEntity> SkillList { get; private set; }

	/// <summary>
	/// 自由契約価格
	/// </summary>
	public int Price { get; private set; }

	/// <summary>
	/// キャッチコピー
	/// </summary>
	public string CatchCopy { get; private set; }

	/// <summary>
	/// 説明
	/// </summary>
	public string Description { get; private set; }

	/// <summary>
	/// 移籍・トレード不可フラグ
	/// </summary>
	public bool IsDisableTrading { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		PlayerId				= playerId;
		FamilyName				= familyName;
		FirstName				= firstName;
		FamilyNameRuby			= familyNameRuby;
		FirstNameRuby			= firstNameRuby;
		DisplayName1			= displayName1;
		DisplayName2			= displayName2;
		DisplayName3			= displayName3;
		DisplayRuby1			= displayRuby1;
		PlayerKnowledgeId		= playerKnowledgeId;
		LicenseCode				= (eLicenseCode)license;
		CardRarityCode			= (eCardRarityCode)cardRarity;
		FieldCode				= (eFieldCode)field;
		PitchHandedTypeCode		= (eHandedTypeCode)pitchHandedType;
		HitHandedTypeCode		= (eHandedTypeCode)hitHandedType;
		PitchingFormCode		= (ePitchingFormCode)pitchingForm;
		BattingFormCode			= (eBattingFormCode)battingForm;
		BattingOrderMatchMap	= makeBattingOrderMatchMap(battingOrderMatchList, header);
		PositionMatchMap		= makePositionMatchMap(positionMatchList, header);
		PitchMatchMap			= makePitchMatchMap(pitchMatchList, header);
		PlayerFielderStatusMap	= makePlayerFielderStatusMap(playerFielderStatusList, header);
		PlayerPitcherStatusMap	= makePlayerPitcherStatusMap(playerPitcherStatusList, header);
		BallTypeCodeList		= MakeBallTypeCodeList(ballTypeList);
		MaxSpeed				= maxSpeed;
		SkillList				= skillList.DeserializeOrDefault(header);
		Price					= price;
		CatchCopy				= catchCopy;
		Description				= description;
		IsDisableTrading		= isDisableTrading;
	}

	private Dictionary<eBattingOrderCode, BattingOrderMatchResponseEntity> makeBattingOrderMatchMap(List<BattingOrderMatchResponseEntity> battingOrderMatchList, ApiResponseMeta header)
	{
		Dictionary<eBattingOrderCode, BattingOrderMatchResponseEntity> battingOrderMatchMap = new Dictionary<eBattingOrderCode, BattingOrderMatchResponseEntity>();

		battingOrderMatchList.ForEach((BattingOrderMatchResponseEntity battingOrderMatchResponseEntity) =>
		{
				battingOrderMatchResponseEntity.DeserializeOrDefault(header);
				battingOrderMatchMap[battingOrderMatchResponseEntity.BattingOrderCode] = battingOrderMatchResponseEntity;
		});

		return battingOrderMatchMap;
	}

	private Dictionary<ePositionCode, PositionMatchResponseEntity> makePositionMatchMap(List<PositionMatchResponseEntity> positionMatchList, ApiResponseMeta header)
	{
		Dictionary<ePositionCode, PositionMatchResponseEntity> positionMatchMap = new Dictionary<ePositionCode, PositionMatchResponseEntity>();

		positionMatchList.ForEach((PositionMatchResponseEntity positionMatchResponseEntity) =>
		{
				positionMatchResponseEntity.DeserializeOrDefault(header);
				positionMatchMap[positionMatchResponseEntity.PositionCode] = positionMatchResponseEntity;
		});

		return positionMatchMap;
	}

	private Dictionary<eMemberTypeCode, PitchMatchResponseEntity> makePitchMatchMap(List<PitchMatchResponseEntity> pitchMatchList, ApiResponseMeta header)
	{
		Dictionary<eMemberTypeCode, PitchMatchResponseEntity> pitchMatchMap = new Dictionary<eMemberTypeCode, PitchMatchResponseEntity>();

		pitchMatchList.ForEach((PitchMatchResponseEntity pitchMatchResponseEntity) =>
		{
				pitchMatchResponseEntity.DeserializeOrDefault(header);
				pitchMatchMap[pitchMatchResponseEntity.MemberTypeCode] = pitchMatchResponseEntity;
		});

		return pitchMatchMap;
	}

	private Dictionary<int, PlayerFielderStatusResponseEntity> makePlayerFielderStatusMap(List<PlayerFielderStatusResponseEntity> playerFielderStatusList, ApiResponseMeta header)
	{
		Dictionary<int, PlayerFielderStatusResponseEntity> playerFielderStatusMap = new Dictionary<int, PlayerFielderStatusResponseEntity>();

		playerFielderStatusList.ForEach((PlayerFielderStatusResponseEntity playerFielderStatusResponseEntity) =>
		{
				playerFielderStatusResponseEntity.DeserializeOrDefault(header);
				playerFielderStatusMap[playerFielderStatusResponseEntity.Season] = playerFielderStatusResponseEntity;
		});

		return playerFielderStatusMap;
	}

	private Dictionary<int, PlayerPitcherStatusResponseEntity> makePlayerPitcherStatusMap(List<PlayerPitcherStatusResponseEntity> playerPitcherStatusList, ApiResponseMeta header)
	{
		Dictionary<int, PlayerPitcherStatusResponseEntity> playerPitcherStatusMap = new Dictionary<int, PlayerPitcherStatusResponseEntity>();

		playerPitcherStatusList.ForEach((PlayerPitcherStatusResponseEntity playerPitcherStatusResponseEntity) =>
		{
				playerPitcherStatusResponseEntity.DeserializeOrDefault(header);
				playerPitcherStatusMap[playerPitcherStatusResponseEntity.Season] = playerPitcherStatusResponseEntity;
		});

		return playerPitcherStatusMap;
	}

	private List<eBallTypeCode> MakeBallTypeCodeList(List<int> ballTypeList)
	{
		List<eBallTypeCode> ballTypeCodeList = new List<eBallTypeCode>();

		ballTypeList.ForEach((int ballType) =>
		{
			ballTypeCodeList.Add((eBallTypeCode)ballType);
		});

		return ballTypeCodeList;
	}
}
