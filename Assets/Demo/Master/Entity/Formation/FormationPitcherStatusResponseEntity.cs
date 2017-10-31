using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// オーダーデータ：投手能力
/// </summary>
[Serializable]
public class FormationPitcherStatusResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// 打順コード値
	/// </summary>
	[SerializeField][MessagePackMember (0)]
	private int battingOrder = new int ();

	/// <summary>
	/// 球威能力の必要有無
	/// </summary>
	[SerializeField][MessagePackMember (1)]
	private bool arm = new bool ();

	/// <summary>
	/// 変化球能力の必要有無
	/// </summary>
	[SerializeField][MessagePackMember (2)]
	private bool breakingBall = new bool ();

	/// <summary>
	/// 制球能力の必要有無
	/// </summary>
	[SerializeField][MessagePackMember (3)]
	private bool control = new bool ();

	/// <summary>
	/// スタミナ能力の必要有無
	/// </summary>
	[SerializeField][MessagePackMember (4)]
	private bool stamina = new bool ();

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
	/// 球威能力の必要有無
	/// </summary>
	public bool Arm { get; private set; }

	/// <summary>
	/// 変化球能力の必要有無
	/// </summary>
	public bool BreakingBall { get; private set; }

	/// <summary>
	/// 制球能力の必要有無
	/// </summary>
	public bool Control { get; private set; }

	/// <summary>
	/// スタミナ能力の必要有無
	/// </summary>
	public bool Stamina { get; private set; }

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
		Arm					= arm;
		BreakingBall		= breakingBall;
		Control				= control;
		Stamina				= stamina;
		Fielding			= fielding;
		HandedMatchCode		= (eHandedMatchCode)handedMatch;
	}
}
