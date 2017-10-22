using System;
using MsgPack.Serialization;
using Mobcast.Coffee.Api;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// レスポンスエンティティ：ゲームデザインデータ
/// </summary>
[Serializable]
public class GameDesignResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// 移籍金限度額
	/// </summary>
	[SerializeField][MessagePackMember(0)]
	private MarketPriceResponseEntity marketPrice = new MarketPriceResponseEntity ();

	/// <summary>
	/// 球会ゲームデザイン
	/// </summary>
	[SerializeField][MessagePackMember(1)]
	private ClubGameDesignResponseEntity clubGameDesign = new ClubGameDesignResponseEntity ();

	/// <summary>
	/// カードレアリティ別レジェンドエージェント価格
	/// </summary>
	[SerializeField][MessagePackMember(2)]
	private LegendAgentPriceResponseEntity legendAgentPrice = new LegendAgentPriceResponseEntity ();

	/// <summary>
	/// 移籍ゲームデザイン
	/// </summary>
	[SerializeField][MessagePackMember(3)]
	private TransferGameDesignResponseEntity transferGameDesign = new TransferGameDesignResponseEntity ();
	#endregion

	#region public properties
	/// <summary>
	/// 移籍金限度額
	/// </summary>
	public MarketPriceResponseEntity MarketPrice { get; private set; }

	/// <summary>
	/// 球会ゲームデザイン
	/// </summary>
	public ClubGameDesignResponseEntity ClubGameDesign { get; private set; }

	/// <summary>
	/// カードレアリティ別レジェンドエージェント価格
	/// </summary>
	public LegendAgentPriceResponseEntity LegendAgentPrice { get; private set; }

	/// <summary>
	/// 移籍ゲームデザイン
	/// </summary>
	public TransferGameDesignResponseEntity TransferGameDesign { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		MarketPrice			= marketPrice.DeserializeOrDefault(header);
		ClubGameDesign		= clubGameDesign.DeserializeOrDefault(header);
		LegendAgentPrice	= legendAgentPrice.DeserializeOrDefault(header);
		TransferGameDesign	= transferGameDesign.DeserializeOrDefault(header);
	}
}

