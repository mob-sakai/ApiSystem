using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// レスポンスパケット：友達招待機能ステータス
/// </summary>
[Serializable]
public class MasterInviteFriendStatusResponsePacket : ApiResponsePacket
{
	/// <summary>
	/// このクラスのプロパティのMessagePack-IDの開始ID
	/// </summary>
	private const int START_MSG_PACK_MEMBER_ID = ApiResponsePacket.START_SUBCLASS_MSG_PACK_MEMBER_ID;

	#region private properties
	/// <summary>
	/// 友達招待機能ステータスコード値
	/// </summary>
	[SerializeField][MessagePackMember(START_MSG_PACK_MEMBER_ID + 0)]
	private int status;
	#endregion

	#region public properties
	/// <summary>
	/// 友達招待機能ステータスコード
	/// </summary>
	public eInviteFriendEnableStatusCode InviteFriendEnableStatusCode { get; private set; }
	#endregion

	public override void OnAfterDeserialize(ApiResponseMeta header)
	{
		base.OnAfterDeserialize(header);

		InviteFriendEnableStatusCode = (eInviteFriendEnableStatusCode)status;
	}
}

