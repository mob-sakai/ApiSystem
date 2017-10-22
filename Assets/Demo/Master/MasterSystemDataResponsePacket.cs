using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// レスポンスパケット：システム系データ
/// </summary>
[Serializable]
public class MasterSystemDataResponsePacket : ApiResponsePacket
{
	/// <summary>
	/// このクラスのプロパティのMessagePack-IDの開始ID
	/// </summary>
	private const int START_MSG_PACK_MEMBER_ID = ApiResponsePacket.START_SUBCLASS_MSG_PACK_MEMBER_ID;

	#region private properties
	/// <summary>
	/// URL管理データ
	/// </summary>
	[SerializeField][MessagePackMember(START_MSG_PACK_MEMBER_ID + 0)]
	private UrlResponseEntity url;

	/// <summary>
	/// インフォメーションデータ
	/// </summary>
	[SerializeField][MessagePackMember(START_MSG_PACK_MEMBER_ID + 1)]
	private InformationResponseEntity information;
	#endregion

	#region public properties
	/// <summary>
	/// URL管理データ
	/// </summary>
	public UrlResponseEntity Url { get; private set; }

	/// <summary>
	/// インフォメーションデータ
	/// </summary>
	public InformationResponseEntity Information { get; private set; }
	#endregion

	public override void OnAfterDeserialize(ApiResponseMeta header)
	{
		base.OnAfterDeserialize(header);

		Url			= url.DeserializeOrDefault(header);
		Information	= information.DeserializeOrDefault(header);
	}
}

