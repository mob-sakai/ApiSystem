using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// 選手データ：守備適正
/// </summary>
[Serializable]
public class PositionMatchResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// ポジションコード値
	/// </summary>
	[SerializeField][MessagePackMember (0)]
	private int position = new int ();

	/// <summary>
	/// 守備適正コード値
	/// </summary>
	[SerializeField][MessagePackMember (1)]
	private int parameterMatch = new int ();
	#endregion

	#region public properties
	/// <summary>
	/// ポジションコード
	/// </summary>
	public ePositionCode PositionCode{ get; private set; }

	/// <summary>
	/// 守備適正コード
	/// </summary>
	public eParameterMatchCode ParameterMatchCode { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		PositionCode		= (ePositionCode)position;
		ParameterMatchCode	= (eParameterMatchCode)parameterMatch;
	}
}
