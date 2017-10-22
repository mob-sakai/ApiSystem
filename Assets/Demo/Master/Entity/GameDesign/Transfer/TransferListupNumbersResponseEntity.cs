using System;
using System.Collections.Generic;
using MsgPack.Serialization;
using Mobcast.Coffee.Api;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// レスポンスエンティティ：移籍ゲームデザインデータ：リーグ別移籍選手リスト数
/// </summary>
[Serializable]
public  class TransferListupNumbersResponseEntity : IResponsePacket {
	#region private properties
	/// <summary>
	/// 移籍選手リスト数：ビギナー
	/// </summary>
	[SerializeField][MessagePackMember(0)]
	private int beginnerListupNumber = new int ();

	/// <summary>
	/// 移籍選手リスト数：ブロンズ
	/// </summary>
	[SerializeField][MessagePackMember(1)]
	private int bronzeListupNumber = new int ();

	/// <summary>
	/// 移籍選手リスト数：シルバー
	/// </summary>
	[SerializeField][MessagePackMember(2)]
	private int silverListupNumber = new int ();

	/// <summary>
	/// 移籍選手リスト数：ゴールド
	/// </summary>
	[SerializeField][MessagePackMember(3)]
	private int goldListupNumber = new int ();

	/// <summary>
	/// 移籍選手リスト数：プラチナ
	/// </summary>
	[SerializeField][MessagePackMember(4)]
	private int platinumListupNumber = new int ();

	/// <summary>
	/// 移籍選手リスト数：ダイアモンド
	/// </summary>
	[SerializeField][MessagePackMember(5)]
	private int diamondListupNumber = new int ();

	/// <summary>
	/// 移籍選手リスト数：レジェンド
	/// </summary>
	[SerializeField][MessagePackMember(6)]
	private int legendListupNumber = new int ();

	/// <summary>
	/// 移籍リストのリストアップ数
	/// </summary>
	[SerializeField][MessagePackMember(7)]
	private int listupNumber = new int ();
	#endregion

	#region public properties
	/// <summary>
	/// 移籍選手リスト数：ビギナー
	/// </summary>
	public int BeginnerListupNumber { get; private set; }

	/// <summary>
	/// 移籍選手リスト数：ブロンズ
	/// </summary>
	public int BronzeListupNumber { get; private set; }

	/// <summary>
	/// 移籍選手リスト数：シルバー
	/// </summary>
	public int SilverListupNumber { get; private set; }

	/// <summary>
	/// 移籍選手リスト数：ゴールド
	/// </summary>
	public int GoldListupNumber { get; private set; }

	/// <summary>
	/// 移籍選手リスト数：プラチナ
	/// </summary>
	public int PlatinumListupNumber { get; private set; }

	/// <summary>
	/// 移籍選手リスト数：ダイアモンド
	/// </summary>
	public int DiamondListupNumber { get; private set; }

	/// <summary>
	/// 移籍選手リスト数：レジェンド
	/// </summary>
	public int LegendListupNumber { get; private set; }

	/// <summary>
	/// 移籍リストのリストアップ数
	/// </summary>
	public int ListupNumber { get; private set; }
	#endregion
	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		BeginnerListupNumber	= beginnerListupNumber;
		BronzeListupNumber		= bronzeListupNumber;
		SilverListupNumber		= silverListupNumber;
		GoldListupNumber		= goldListupNumber;
		PlatinumListupNumber	= platinumListupNumber;
		DiamondListupNumber		= diamondListupNumber;
		LegendListupNumber		= legendListupNumber;
		ListupNumber			= listupNumber;
	}

}

