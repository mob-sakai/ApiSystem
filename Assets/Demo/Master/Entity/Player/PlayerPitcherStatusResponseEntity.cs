using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// 選手データ：投手能力データ
/// </summary>
[Serializable]
public class PlayerPitcherStatusResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// 期数
	/// </summary>
	[SerializeField][MessagePackMember (0)]
	private int season = new int ();

	/// <summary>
	/// 球威
	/// </summary>
	[SerializeField][MessagePackMember (1)]
	private int arm = new int ();

	/// <summary>
	/// 変化球
	/// </summary>
	[SerializeField][MessagePackMember (2)]
	private int breakingBall = new int ();

	/// <summary>
	/// 制球
	/// </summary>
	[SerializeField][MessagePackMember (3)]
	private int control = new int ();

	/// <summary>
	/// スタミナ
	/// </summary>
	[SerializeField][MessagePackMember (4)]
	private int stamina = new int ();

	/// <summary>
	/// 守備
	/// </summary>
	[SerializeField][MessagePackMember (5)]
	private int fielding = new int ();
	#endregion

	#region public properties
	/// <summary>
	/// 期数
	/// </summary>
	public int Season { get; private set; }

	/// <summary>
	/// 球威
	/// </summary>
	public int Arm { get; private set; }

	/// <summary>
	/// 変化球
	/// </summary>
	public int BreakingBall { get; private set; }

	/// <summary>
	/// 制球
	/// </summary>
	public int Control { get; private set; }

	/// <summary>
	/// スタミナ
	/// </summary>
	public int Stamina { get; private set; }

	/// <summary>
	/// 守備
	/// </summary>
	public int Fielding { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		Season			= season;
		Arm				= arm;
		BreakingBall	= breakingBall;
		Control			= control;
		Stamina			= stamina;
		Fielding		= fielding;
	}
}
