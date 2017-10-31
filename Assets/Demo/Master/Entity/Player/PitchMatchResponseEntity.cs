using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// 選手データ：投手適正
/// </summary>
[Serializable]
public class PitchMatchResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// メンバータイプコード値
	/// </summary>
	[SerializeField][MessagePackMember (0)]
	private int memberType = new int ();

	/// <summary>
	/// 投手適正コード値
	/// </summary>
	[SerializeField][MessagePackMember (1)]
	private int parameterMatch = new int ();
	#endregion

	#region public properties
	/// <summary>
	/// メンバータイプコード
	/// </summary>
	public eMemberTypeCode MemberTypeCode { get; private set; }

	/// <summary>
	/// 投手適正コード
	/// </summary>
	public eParameterMatchCode ParameterMatchCode { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		MemberTypeCode		= (eMemberTypeCode)memberType;
		ParameterMatchCode	= (eParameterMatchCode)parameterMatch;
	}
}
