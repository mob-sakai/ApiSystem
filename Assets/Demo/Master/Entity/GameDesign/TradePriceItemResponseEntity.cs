using System;
using Mobcast.Coffee.Api;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// レスポンスエンティティ：トレード限度額
/// </summary>
[Serializable]
public class TradePriceItemResponseEntity : IResponsePacket {

	#region private properties
	/// <summary>
	/// トレード限度額最小値
	/// </summary>
	[SerializeField][MessagePackMember(0)]
	private int minPrice = new int ();

	/// <summary>
	/// トレード限度額最大値
	/// </summary>
	[SerializeField][MessagePackMember(1)]
	private int maxPrice = new int ();
	#endregion

	#region public properties
	/// <summary>
	/// トレード限度額最小値
	/// </summary>
	public int MinPrice { get; private set; }

	/// <summary>
	/// トレード限度額最大値
	/// </summary>
	public int MaxPrice { get; private set; }
	#endregion


	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		MinPrice = minPrice;
		MaxPrice = maxPrice;
	}
}

