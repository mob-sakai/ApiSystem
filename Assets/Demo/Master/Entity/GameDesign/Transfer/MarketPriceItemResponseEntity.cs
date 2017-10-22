using System;
using Mobcast.Coffee.Api;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// レスポンスエンティティ：移籍金限度額
/// </summary>
[Serializable]
public class MarketPriceItemResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// 移籍金ゴールド最小値
	/// </summary>
	[SerializeField][MessagePackMember(0)]
	private int minPrice = new int ();

	/// <summary>
	/// 移籍金ゴールド最大値
	/// </summary>
	[SerializeField][MessagePackMember(1)]
	private int maxPrice = new int ();
	#endregion

	#region public properties
	/// <summary>
	/// 移籍金ゴールド最小値
	/// </summary>
	public int MinPrice { get; private set; }

	/// <summary>
	/// 移籍金ゴールド最大値
	/// </summary>
	public int MaxPrice { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		MinPrice = minPrice;
		MaxPrice = maxPrice;
	}
}

