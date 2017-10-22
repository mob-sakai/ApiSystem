using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// リクエストパケット：URL管理データ取得
/// </summary>
[Serializable]
public class MasterUrlDataRequestPacket:ApiRequest<MasterUrlDataRequestPacket, MasterUrlDataResponsePacket>
{
	/// <summary>
	/// URL
	/// </summary>
	public override string url{ get { return "https://api.sand.mbl.mobcast.io/" + "mbl/api/master/url"; } }

	/// <summary>
	/// リクエストメソッド
	/// </summary>
	public override bool usePostMethod{ get { return false; } }

	public MasterUrlDataRequestPacket()
	{
	}
}
