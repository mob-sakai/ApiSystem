using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// レスポンスデータ：インフォメーションデータ
/// </summary>
[Serializable]
public  class InformationResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// エージェントインフォメーションアイテム
	/// </summary>
	[SerializeField][MessagePackMember(0)]
	private InformationItemResponseEntity agentInformationItem;

	/// <summary>
	/// オーダーカードインフォメーションアイテム
	/// </summary>
	[SerializeField][MessagePackMember(1)]
	private InformationItemResponseEntity formationInformationItem;

	/// <summary>
	/// チームインフォメーションアイテム
	/// </summary>
	[SerializeField][MessagePackMember(2)]
	private InformationItemResponseEntity teamInformationItem;

	/// <summary>
	/// リーグインフォメーションアイテム
	/// </summary>
	[SerializeField][MessagePackMember(3)]
	private InformationItemResponseEntity leagueInformationItem;

	/// <summary>
	/// クラブインフォメーションアイテム
	/// </summary>
	[SerializeField][MessagePackMember(4)]
	private InformationItemResponseEntity clubInformationItem;

	/// <summary>
	/// 移籍インフォメーションアイテム
	/// </summary>
	[SerializeField][MessagePackMember(5)]
	private InformationItemResponseEntity transferInformationItem;
	#endregion

	#region public properties
	/// <summary>
	/// エージェントインフォメーションアイテム
	/// </summary>
	public InformationItemResponseEntity AgentInformationItem { get; private set; }

	/// <summary>
	/// オーダーカードインフォメーションアイテム
	/// </summary>
	public InformationItemResponseEntity FormationInformationItem { get; private set; }

	/// <summary>
	/// チームインフォメーションアイテム
	/// </summary>
	public InformationItemResponseEntity TeamInformationItem { get; private set; }

	/// <summary>
	/// リーグインフォメーションアイテム
	/// </summary>
	public InformationItemResponseEntity LeagueInformationItem { get; private set; }

	/// <summary>
	/// クラブインフォメーションアイテム
	/// </summary>
	public InformationItemResponseEntity ClubInformationItem { get; private set; }

	/// <summary>
	/// 移籍インフォメーションアイテム
	/// </summary>
	public InformationItemResponseEntity TransferInformationItem { get; private set; }

	/// <summary>
	/// ショップインフォメーションアイテム
	/// </summary>
	public InformationItemResponseEntity ShopInformationItem { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		AgentInformationItem		= agentInformationItem.DeserializeOrDefault(header);
		FormationInformationItem	= formationInformationItem.DeserializeOrDefault(header);
		TeamInformationItem			= teamInformationItem.DeserializeOrDefault(header);
		LeagueInformationItem		= leagueInformationItem.DeserializeOrDefault(header);
		ClubInformationItem			= clubInformationItem.DeserializeOrDefault(header);
		TransferInformationItem		= transferInformationItem.DeserializeOrDefault(header);
	}
}

