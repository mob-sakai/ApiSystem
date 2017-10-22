using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// オーダーデータ：守備位置
/// </summary>
[Serializable]
public class FormationPositionResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// 打順コード値
	/// </summary>
	[SerializeField][MessagePackMember (0)]
	private int battingOrder = new int ();

	/// <summary>
	/// ポジションコード値
	/// </summary>
	[SerializeField][MessagePackMember (1)]
	private int position = new int ();
	#endregion

	#region public properties
	/// <summary>
	/// 打順コード
	/// </summary>
	public int BattingOrderCode { get; private set; }

	/// <summary>
	/// ポジションコード
	/// </summary>
	public int PositionCode { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		BattingOrderCode	= (int)battingOrder;
		PositionCode		= (int)position;
	}
}
