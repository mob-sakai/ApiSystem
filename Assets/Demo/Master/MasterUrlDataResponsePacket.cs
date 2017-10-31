using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// レスポンスパケット：URL管理データ
/// </summary>
[Serializable]
public class MasterUrlDataResponsePacket : ApiResponsePacket
{
	/// <summary>
	/// このクラスのプロパティのMessagePack-IDの開始ID
	/// </summary>
	private const int START_MSG_PACK_MEMBER_ID = ApiResponsePacket.START_SUBCLASS_MSG_PACK_MEMBER_ID;

	#region private properties
	/// <summary>
	/// URL管理データ
	/// </summary>
	[SerializeField][MessagePackMember (START_MSG_PACK_MEMBER_ID + 0)]
	private UrlResponseEntity url = new UrlResponseEntity ();
	#endregion

	#region public properties
	/// <summary>
	/// URL管理データ
	/// </summary>
	public UrlResponseEntity Url { get; private set; }
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

		Url	= url.DeserializeOrDefault(header);
	}
}

