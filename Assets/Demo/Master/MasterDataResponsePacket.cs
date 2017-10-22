using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// レスポンスパケット：マスターデータ
/// </summary>
[Serializable]
public class MasterDataResponsePacket : ApiResponsePacket
{
	/// <summary>
	/// このクラスのプロパティのMessagePack-IDの開始ID
	/// </summary>
	private const int START_MSG_PACK_MEMBER_ID = ApiResponsePacket.START_SUBCLASS_MSG_PACK_MEMBER_ID;

	#region private properties
	/// <summary>
	/// 選手データリスト
	/// </summary>
	[SerializeField][MessagePackMember (START_MSG_PACK_MEMBER_ID + 0)]
	private List<PlayerResponseEntity> playerList = new List<PlayerResponseEntity> ();

	/// <summary>
	/// オーダーデータリスト
	/// </summary>
	[SerializeField][MessagePackMember (START_MSG_PACK_MEMBER_ID + 1)]
	private List<FormationResponseEntity> formationList = new List<FormationResponseEntity> ();

	/// <summary>
	/// 特性データリスト
	/// </summary>
	[SerializeField][MessagePackMember (START_MSG_PACK_MEMBER_ID + 2)]
	private List<SkillResponseEntity> skillList = new List<SkillResponseEntity> ();

	/// <summary>
	/// URL管理データ
	/// </summary>
	[SerializeField][MessagePackMember (START_MSG_PACK_MEMBER_ID + 3)]
	private UrlResponseEntity url = new UrlResponseEntity ();

	/// <summary>
	/// ゲームデザインデータ
	/// </summary>
	[SerializeField][MessagePackMember (START_MSG_PACK_MEMBER_ID + 4)]
	private GameDesignResponseEntity gameDesign = new GameDesignResponseEntity ();

	/// <summary>
	/// photonサーバ情報リスト
	/// </summary>
	[SerializeField][MessagePackMember (START_MSG_PACK_MEMBER_ID + 5)]
	private List<PhotonServerInfoResponseEntity> photonServerInfoList = new List<PhotonServerInfoResponseEntity> ();
	#endregion

	#region public properties
	/// <summary>
	/// 選手データリスト
	/// </summary>
	public List<PlayerResponseEntity> PlayerList { get; private set; }

	/// <summary>
	/// オーダーデータリスト
	/// </summary>
	public List<FormationResponseEntity> FormationList { get; private set; }

	/// <summary>
	/// 特性データリスト
	/// </summary>
	public List<SkillResponseEntity> SkillList { get; private set; }

	/// <summary>
	/// URL管理データ
	/// </summary>
	public UrlResponseEntity Url { get; private set; }

	/// <summary>
	/// ゲームデザインデータ
	/// </summary>
	public GameDesignResponseEntity GameDesign { get; private set; }

	/// <summary>
	/// photonサーバ情報リスト
	/// </summary>
	public List<PhotonServerInfoResponseEntity> PhotonServerInfoList { get; private set; }
	#endregion

	/// <summary>
	/// デシリアライズに伴う処理を実行します.
	/// ResponsePacketContextを利用したタイムゾーンや言語の変換を追加できます.
	/// デシリアライズ結果がエラー扱いとしたい場合、APIExeption例外をスローするか、Info.codeを0以外に設定してください.
	/// </summary>
	/// <param name="header">Apiレスポンスヘッダ.</param>
	public override void OnAfterDeserialize (ApiResponseMeta header)
	{
		base.OnAfterDeserialize (header);

		PlayerList				= playerList.DeserializeOrDefault(header);
		FormationList			= formationList.DeserializeOrDefault(header);
		SkillList				= skillList.DeserializeOrDefault(header);
		Url						= url.DeserializeOrDefault(header);
		GameDesign				= gameDesign.DeserializeOrDefault(header);
		PhotonServerInfoList	= photonServerInfoList.DeserializeOrDefault(header);
	}
}

