using System;
using Mobcast.Coffee.Api;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// レスポンスエンティティ：カードレアリティ別移籍金限度額
/// </summary>
[Serializable]
public class MarketPriceResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// 移籍金限度額：ノーマル
	/// </summary>
	[SerializeField][MessagePackMember(0)]
	private MarketPriceItemResponseEntity normalMarketPriceItem = new MarketPriceItemResponseEntity ();

	/// <summary>
	/// 移籍金限度額：レア
	/// </summary>
	[SerializeField][MessagePackMember(1)]
	private MarketPriceItemResponseEntity rareMarketPriceItem = new MarketPriceItemResponseEntity ();

	/// <summary>
	/// 移籍金限度額：スーパーレア
	/// </summary>
	[SerializeField][MessagePackMember(2)]
	private MarketPriceItemResponseEntity superRareMarketPriceItem = new MarketPriceItemResponseEntity ();

	/// <summary>
	/// 移籍金限度額：ウルトラレア
	/// </summary>
	[SerializeField][MessagePackMember(3)]
	private MarketPriceItemResponseEntity ultraRareMarketPriceItem = new MarketPriceItemResponseEntity ();
	#endregion

	#region public properties
	/// <summary>
	/// 移籍金限度額：ノーマル
	/// </summary>
	public MarketPriceItemResponseEntity NormalMarketPriceItem { get; private set; }

	/// <summary>
	/// 移籍金限度額：レア
	/// </summary>
	public MarketPriceItemResponseEntity RareMarketPriceItem { get; private set; }

	/// <summary>
	/// 移籍金限度額：スーパーレア
	/// </summary>
	public MarketPriceItemResponseEntity SuperRareMarketPriceItem { get; private set; }

	/// <summary>
	/// 移籍金限度額：ウルトラレア
	/// </summary>
	public MarketPriceItemResponseEntity UltraRareMarketPriceItem { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		NormalMarketPriceItem		= normalMarketPriceItem.DeserializeOrDefault(header);
		RareMarketPriceItem			= rareMarketPriceItem.DeserializeOrDefault(header);
		SuperRareMarketPriceItem	= superRareMarketPriceItem.DeserializeOrDefault(header);
		UltraRareMarketPriceItem	= ultraRareMarketPriceItem.DeserializeOrDefault(header);
	}
}

