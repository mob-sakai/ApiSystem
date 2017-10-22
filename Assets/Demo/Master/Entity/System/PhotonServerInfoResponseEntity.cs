using System;
using System.Collections.Generic;
using MsgPack.Serialization;
using Mobcast.Coffee.Api;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// レスポンスデータ：photonサーバ情報
/// </summary>
[Serializable]
public  class PhotonServerInfoResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// photonサーバーコード値
	/// </summary>
	[SerializeField][MessagePackMember(0)]
	private int photonServer = new int ();

	/// <summary>
	/// ホスト名
	/// </summary>
	[SerializeField][MessagePackMember(1)]
	private string hostName = string.Empty;

	/// <summary>
	/// ポート番号
	/// </summary>
	[SerializeField][MessagePackMember(2)]
	private int port = new int ();

	/// <summary>
	/// Photonアプリケーション名
	/// </summary>
	[SerializeField][MessagePackMember(3)]
	private string applicationName = string.Empty;

	/// <summary>
	/// Photonピア名
	/// </summary>
	[SerializeField][MessagePackMember(4)]
	private string peerName = string.Empty;

	/// <summary>
	/// チャンネルサフィックス
	/// </summary>
	[SerializeField][MessagePackMember(5)]
	private string channelSuffix = string.Empty;
	#endregion

	#region public properties
	/// <summary>
	/// photonサーバーコード
	/// </summary>
	public int PhotonServerCode { get; private set; }

	/// <summary>
	/// ホスト名
	/// </summary>
	public string HostName { get; private set; }

	/// <summary>
	/// ポート番号
	/// </summary>
	public int Port { get; private set; }

	/// <summary>
	/// Photonアプリケーション名
	/// </summary>
	public string ApplicationName { get; private set; }

	/// <summary>
	/// Photonピア名
	/// </summary>
	public string PeerName { get; private set; }

	/// <summary>
	/// チャンネルサフィックス
	/// </summary>
	public string ChannelSuffix { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		PhotonServerCode	= (int)photonServer;
		HostName			= hostName;
		Port				= port;
		ApplicationName		= applicationName;
		PeerName			= peerName;
		ChannelSuffix		= channelSuffix;
	}
}

