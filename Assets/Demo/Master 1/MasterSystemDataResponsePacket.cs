using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// リクエストパケット：システム系データ取得
/// </summary>
[Serializable]
public class MasterSystemDataRequestPacket:ApiRequest<MasterSystemDataRequestPacket, MasterSystemDataResponsePacket>
{
	/// <summary>
	/// URL
	/// </summary>
	public override string url{ get { return "https://api.sand.mbl.mobcast.io/" + "mbl/api/master/system"; } }

	/// <summary>
	/// リクエストメソッド
	/// </summary>
	public override bool usePostMethod{ get { return false; } }

	public MasterSystemDataRequestPacket()
	{
	}
}
