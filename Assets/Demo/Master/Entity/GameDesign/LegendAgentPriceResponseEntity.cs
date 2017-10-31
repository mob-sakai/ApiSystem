using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649


/// <summary>
/// * レスポンスエンティティ：カードレアリティ別レジェンドエージェント価格
/// </summary>
[Serializable]
public class LegendAgentPriceResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// レジェンドエージェント価格：ノーマル
	/// </summary>
	[SerializeField][MessagePackMember(0)]
	private int normalPrice = new int ();
	/// <summary>
	/// レジェンドエージェント価格：レア
	/// </summary>
	[SerializeField][MessagePackMember(1)]
	private int rarePrice = new int ();

	/// <summary>
	/// レジェンドエージェント価格：スーパーレア
	/// </summary>
	[SerializeField][MessagePackMember(2)]
	private int superRarePrice = new int ();

	/// <summary>
	/// レジェンドエージェント価格：ウルトラレア
	/// </summary>
	[SerializeField][MessagePackMember(3)]
	private int ultraRarePrice = new int ();

	/// <summary>
	/// レジェンドエージェント価格：特性ボーナススーパーレア
	/// </summary>
	[SerializeField][MessagePackMember(4)]
	private int skillBonusSuperRarePrice = new int ();

	/// <summary>
	/// レジェンドエージェント価格：特性ボーナスウルトラレア
	/// </summary>
	[SerializeField][MessagePackMember(5)]
	private int skillBonusUltraRarePrice = new int ();
	#endregion

	#region public properties
	/// <summary>
	/// レジェンドエージェント価格：ノーマル
	/// </summary>
	public int NormalPrice { get; private set; }

	/// <summary>
	/// レジェンドエージェント価格：レア
	/// </summary>
	public int RarePrice { get; private set; }

	/// <summary>
	/// レジェンドエージェント価格：スーパーレア
	/// </summary>
	public int SuperRarePrice { get; private set; }

	/// <summary>
	/// レジェンドエージェント価格：ウルトラレア
	/// </summary>
	public int UltraRarePrice { get; private set; }

	/// <summary>
	/// レジェンドエージェント価格：特性ボーナススーパーレア
	/// </summary>
	public int SkillBonusSuperRarePrice { get; private set; }

	/// <summary>
	/// レジェンドエージェント価格：特性ボーナスウルトラレア
	/// </summary>
	public int SkillBonusUltraRarePrice { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		NormalPrice					= normalPrice;
		RarePrice					= rarePrice;
		SuperRarePrice				= superRarePrice;
		UltraRarePrice				= ultraRarePrice;
		SkillBonusSuperRarePrice	= skillBonusSuperRarePrice;
		SkillBonusUltraRarePrice	= skillBonusUltraRarePrice;
	}
}
