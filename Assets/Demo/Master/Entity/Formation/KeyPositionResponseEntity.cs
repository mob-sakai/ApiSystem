using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// オーダーデータ：キーポジション
/// </summary>
[Serializable]
public class KeyPositionResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// 打順コード値
	/// </summary>
	[SerializeField][MessagePackMember (0)]
	private int battingOrder = new int ();

	/// <summary>
	/// 説明
	/// </summary>
	[SerializeField][MessagePackMember (1)]
	private string description = string.Empty;
	#endregion

	#region public properties
	/// <summary>
	/// 打順コード
	/// </summary>
	public eBattingOrderCode BattingOrderCode { get; private set; }

	/// <summary>
	/// 説明
	/// </summary>
	public string Description { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		BattingOrderCode	= (eBattingOrderCode)battingOrder;
		Description			= description;
	}
}
