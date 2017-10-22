using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// 選手データ：打順適正
/// </summary>
[Serializable]
public class BattingOrderMatchResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// 打順コード値
	/// </summary>
	[SerializeField][MessagePackMember (0)]
	private int battingOrder = new int ();

	/// <summary>
	/// 打順適正コード値
	/// </summary>
	[SerializeField][MessagePackMember (1)]
	private int parameterMatch = new int ();
	#endregion

	#region public properties
	/// <summary>
	/// 打順コード
	/// </summary>
	public int BattingOrderCode { get; private set; }

	/// <summary>
	/// 打順適正コード
	/// </summary>
	public int ParameterMatchCode { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		BattingOrderCode	= (int)battingOrder;
		ParameterMatchCode	= (int)parameterMatch;
	}
}
