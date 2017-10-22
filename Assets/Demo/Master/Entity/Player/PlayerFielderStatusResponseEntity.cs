using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// 選手データ：野手能力データ
/// </summary>
[Serializable]
public class PlayerFielderStatusResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// 期数
	/// </summary>
	[SerializeField][MessagePackMember (0)]
	private int season = new int ();

	/// <summary>
	/// ミート
	/// </summary>
	[SerializeField][MessagePackMember (1)]
	private int meet = new int ();

	/// <summary>
	/// パワー
	/// </summary>
	[SerializeField][MessagePackMember (2)]
	private int power = new int ();

	/// <summary>
	/// 走力
	/// </summary>
	[SerializeField][MessagePackMember (3)]
	private int run = new int ();

	/// <summary>
	/// 肩力
	/// </summary>
	[SerializeField][MessagePackMember (4)]
	private int arm = new int ();

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
	/// ミート
	/// </summary>
	public int Meet { get; private set; }

	/// <summary>
	/// パワー
	/// </summary>
	public int Power { get; private set; }

	/// <summary>
	/// 走力
	/// </summary>
	public int Run { get; private set; }

	/// <summary>
	/// 肩力
	/// </summary>
	public int Arm { get; private set; }

	/// <summary>
	/// 守備
	/// </summary>
	public int Fielding { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		Season		= season;
		Meet		= meet;
		Power		= power;
		Run			= run;
		Arm			= arm;
		Fielding	= fielding;
	}
}
