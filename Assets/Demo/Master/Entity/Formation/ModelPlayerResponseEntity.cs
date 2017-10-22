using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// オーダーデータ：モデル選手
/// </summary>
[Serializable]
public class ModelPlayerResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// 打順コード値
	/// </summary>
	[SerializeField][MessagePackMember (0)]
	private int battingOrder = new int ();

	/// <summary>
	/// 選手ナレッジID
	/// </summary>
	[SerializeField][MessagePackMember (1)]
	private int playerKnowledgeId = new int ();
	#endregion

	#region public properties
	/// <summary>
	/// 打順コード
	/// </summary>
	public int BattingOrderCode { get; private set; }

	/// <summary>
	/// 選手ナレッジID
	/// </summary>
	public int PlayerKnowledgeId { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		BattingOrderCode	= (int)battingOrder;
		PlayerKnowledgeId	= playerKnowledgeId;
	}
}
