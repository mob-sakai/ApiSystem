using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// オーダーデータ：野手能力
/// </summary>
[Serializable]
public class FormationFielderStatusResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// 打順コード値
	/// </summary>
	[SerializeField][MessagePackMember (0)]
	private int battingOrder = new int ();

	/// <summary>
	/// ミート能力の必要有無
	/// </summary>
	[SerializeField][MessagePackMember (1)]
	private bool meet = new bool ();

	/// <summary>
	/// パワー能力の必要有無
	/// </summary>
	[SerializeField][MessagePackMember (2)]
	private bool power = new bool ();

	/// <summary>
	/// 走力能力の必要有無
	/// </summary>
	[SerializeField][MessagePackMember (3)]
	private bool run = new bool ();

	/// <summary>
	/// 肩力能力の必要有無
	/// </summary>
	[SerializeField][MessagePackMember (4)]
	private bool arm = new bool ();

	/// <summary>
	/// 守備能力の必要有無
	/// </summary>
	[SerializeField][MessagePackMember (5)]
	private bool fielding = new bool ();

	/// <summary>
	/// 左右(投打)適正コード値
	/// </summary>
	[SerializeField][MessagePackMember (6)]
	private int handedMatch = new int ();
	#endregion

	#region public properties
	/// <summary>
	/// 打順コード
	/// </summary>
	public eBattingOrderCode BattingOrderCode { get; private set; }

	/// <summary>
	/// ミート能力の必要有無
	/// </summary>
	public bool Meet { get; private set; }

	/// <summary>
	/// パワー能力の必要有無
	/// </summary>
	public bool Power { get; private set; }

	/// <summary>
	/// 走力能力の必要有無
	/// </summary>
	public bool Run { get; private set; }

	/// <summary>
	/// 肩力能力の必要有無
	/// </summary>
	public bool Arm { get; private set; }

	/// <summary>
	/// 守備能力の必要有無
	/// </summary>
	public bool Fielding { get; private set; }

	/// <summary>
	/// 左右(投打)適正コード
	/// </summary>
	public eHandedMatchCode HandedMatchCode { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		BattingOrderCode	= (eBattingOrderCode)battingOrder;
		Meet				= meet;
		Power				= power;
		Run					= run;
		Arm					= arm;
		Fielding			= fielding;
		HandedMatchCode		= (eHandedMatchCode)handedMatch;
	}
}
