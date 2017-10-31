using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// オーダーデータ
/// </summary>
[Serializable]
public class FormationResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// オーダーID
	/// </summary>
	[SerializeField][MessagePackMember (0)]
	private int formationId = new int ();

	/// <summary>
	/// オーダー名
	/// </summary>
	[SerializeField][MessagePackMember (1)]
	private string formationName = string.Empty;

	/// <summary>
	/// キャッチコピー
	/// </summary>
	[SerializeField][MessagePackMember (2)]
	private string catchCopy = string.Empty;

	/// <summary>
	/// 説明
	/// </summary>
	[SerializeField][MessagePackMember (3)]
	private string description = string.Empty;

	/// <summary>
	/// 打撃力
	/// </summary>
	[SerializeField][MessagePackMember (4)]
	private int batting = new int ();

	/// <summary>
	/// 投手力
	/// </summary>
	[SerializeField][MessagePackMember (5)]
	private int pitching = new int ();

	/// <summary>
	/// 守備力
	/// </summary>
	[SerializeField][MessagePackMember (6)]
	private int fielding = new int ();

	/// <summary>
	/// 走力
	/// </summary>
	[SerializeField][MessagePackMember (7)]
	private int running = new int ();

	/// <summary>
	/// [レギュラー野手のみ] ポジションデータリスト
	/// </summary>
	[SerializeField][MessagePackMember (8)]
	private List<FormationPositionResponseEntity> formationPositionList = new List<FormationPositionResponseEntity> ();

	/// <summary>
	/// [レギュラー野手のみ] 野手能力リスト
	/// </summary>
	[SerializeField][MessagePackMember (9)]
	private List<FormationFielderStatusResponseEntity> formationFielderStatusList = new List<FormationFielderStatusResponseEntity> ();

	/// <summary>
	/// [投手のみ] 投手能力リスト
	/// </summary>
	[SerializeField][MessagePackMember (10)]
	private List<FormationPitcherStatusResponseEntity> formationPitcherStatusList = new List<FormationPitcherStatusResponseEntity> ();

	/// <summary>
	/// [レギュラー野手、投手] モデル選手データリスト
	/// </summary>
	[SerializeField][MessagePackMember (11)]
	private List<ModelPlayerResponseEntity> modelPlayerList = new List<ModelPlayerResponseEntity> ();

	/// <summary>
	/// キーポジションデータリスト
	/// </summary>
	[SerializeField][MessagePackMember (12)]
	private List<KeyPositionResponseEntity> keyPositionList = new List<KeyPositionResponseEntity> ();
	#endregion

	#region public properties
	/// <summary>
	/// オーダーID
	/// </summary>
	public int FormationId { get; private set; }

	/// <summary>
	/// オーダー名
	/// </summary>
	public string FormationName { get; private set; }

	/// <summary>
	/// キャッチコピー
	/// </summary>
	public string CatchCopy { get; private set; }

	/// <summary>
	/// 説明
	/// </summary>
	public string Description { get; private set; }

	/// <summary>
	/// 打撃力
	/// </summary>
	public int Batting { get; private set; }

	/// <summary>
	/// 投手力
	/// </summary>
	public int Pitching { get; private set; }

	/// <summary>
	/// 守備力
	/// </summary>
	public int Fielding { get; private set; }

	/// <summary>
	/// 走力
	/// </summary>
	public int Running { get; private set; }

	/// <summary>
	/// [レギュラー野手のみ] ポジションデータマップ
	/// </summary>
	public Dictionary<eBattingOrderCode, FormationPositionResponseEntity> FormationPositionMap { get; private set; }

	/// <summary>
	/// [レギュラー野手のみ] 野手能力マップ
	/// </summary>
	public Dictionary<eBattingOrderCode, FormationFielderStatusResponseEntity> FormationFielderStatusMap { get; private set; }

	/// <summary>
	/// [投手のみ] 投手能力マップ
	/// </summary>
	public Dictionary<eBattingOrderCode, FormationPitcherStatusResponseEntity> FormationPitcherStatusMap { get; private set; }

	/// <summary>
	/// [レギュラー野手、投手] モデル選手データマップ
	/// </summary>
	public Dictionary<eBattingOrderCode, ModelPlayerResponseEntity> ModelPlayerMap { get; private set; }

	/// <summary>
	/// キーポジションデータマップ
	/// </summary>
	public Dictionary<eBattingOrderCode, KeyPositionResponseEntity> KeyPositionMap { get; private set; }

	/// <summary>
	/// キーポジションデータリスト
	/// </summary>
	public List<KeyPositionResponseEntity> KeyPositionList { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		FormationId					= formationId;
		FormationName				= formationName;
		CatchCopy					= catchCopy;
		Description					= description;
		Batting						= batting;
		Pitching					= pitching;
		Fielding					= fielding;
		Running						= running;
		FormationPositionMap		= MakeFormationPositionMap(formationPositionList, header);
		FormationFielderStatusMap	= MakeFormationFielderStatusMap(formationFielderStatusList, header);
		FormationPitcherStatusMap	= MakeFormationPitcherStatusMap(formationPitcherStatusList, header);
		ModelPlayerMap				= MakeModelPlayerMap(modelPlayerList, header);
		KeyPositionMap				= MakeKeyPositionMap(keyPositionList, header);
		KeyPositionList				= keyPositionList.DeserializeOrDefault(header);
	}

	private Dictionary<eBattingOrderCode, FormationPositionResponseEntity> MakeFormationPositionMap(List<FormationPositionResponseEntity> formationPositionList, ApiResponseMeta header)
	{
		Dictionary<eBattingOrderCode, FormationPositionResponseEntity> formationPositionMap = new Dictionary<eBattingOrderCode, FormationPositionResponseEntity>();

		formationPositionList.ForEach((FormationPositionResponseEntity formationPositionResponseEntity) =>
		{
				formationPositionResponseEntity.DeserializeOrDefault(header);
				formationPositionMap[formationPositionResponseEntity.BattingOrderCode] = formationPositionResponseEntity;
		});

		return formationPositionMap;
	}

	private Dictionary<eBattingOrderCode, FormationFielderStatusResponseEntity> MakeFormationFielderStatusMap(List<FormationFielderStatusResponseEntity> formationFielderStatusList, ApiResponseMeta header)
	{
		Dictionary<eBattingOrderCode, FormationFielderStatusResponseEntity> formationFielderStatusMap = new Dictionary<eBattingOrderCode, FormationFielderStatusResponseEntity>();

		formationFielderStatusList.ForEach((FormationFielderStatusResponseEntity formationFielderStatusResponseEntity) =>
		{
				formationFielderStatusResponseEntity.DeserializeOrDefault(header);
				formationFielderStatusMap[formationFielderStatusResponseEntity.BattingOrderCode] = formationFielderStatusResponseEntity;
		});

		return formationFielderStatusMap;
	}

	private Dictionary<eBattingOrderCode, FormationPitcherStatusResponseEntity> MakeFormationPitcherStatusMap(List<FormationPitcherStatusResponseEntity> formationPitcherStatusList, ApiResponseMeta header)
	{
		Dictionary<eBattingOrderCode, FormationPitcherStatusResponseEntity> formationPitcherStatusMap = new Dictionary<eBattingOrderCode, FormationPitcherStatusResponseEntity>();

		formationPitcherStatusList.ForEach((FormationPitcherStatusResponseEntity formationPitcherStatusResponseEntity) =>
		{
				formationPitcherStatusResponseEntity.DeserializeOrDefault(header);
				formationPitcherStatusMap[formationPitcherStatusResponseEntity.BattingOrderCode] = formationPitcherStatusResponseEntity;
		});

		return formationPitcherStatusMap;
	}

	private Dictionary<eBattingOrderCode, ModelPlayerResponseEntity> MakeModelPlayerMap(List<ModelPlayerResponseEntity> modelPlayerList, ApiResponseMeta header)
	{
		Dictionary<eBattingOrderCode, ModelPlayerResponseEntity> modelPlayerResponseEntityMap = new Dictionary<eBattingOrderCode, ModelPlayerResponseEntity>();

		modelPlayerList.ForEach((ModelPlayerResponseEntity modelPlayerResponseEntity) =>
		{
				modelPlayerResponseEntity.DeserializeOrDefault(header);
				modelPlayerResponseEntityMap[modelPlayerResponseEntity.BattingOrderCode] = modelPlayerResponseEntity;
		});

		return modelPlayerResponseEntityMap;
	}

	private Dictionary<eBattingOrderCode, KeyPositionResponseEntity> MakeKeyPositionMap(List<KeyPositionResponseEntity> keyPositionList, ApiResponseMeta header)
	{
		Dictionary<eBattingOrderCode, KeyPositionResponseEntity> keyPositionResponseEntityMap = new Dictionary<eBattingOrderCode, KeyPositionResponseEntity>();

		keyPositionList.ForEach((KeyPositionResponseEntity keyPositionResponseEntity) =>
		{
				keyPositionResponseEntity.DeserializeOrDefault(header);
				keyPositionResponseEntityMap[keyPositionResponseEntity.BattingOrderCode] = keyPositionResponseEntity;
		});

		return keyPositionResponseEntityMap;
	}
}
