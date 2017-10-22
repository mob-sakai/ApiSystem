using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// レスポンスデータ：インフォメーション要素データ
/// </summary>
[Serializable]
public  class InformationElementResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// タイトル
	/// </summary>
	[SerializeField][MessagePackMember(0)]
	private string title;

	/// <summary>
	/// 本文
	/// </summary>
	[SerializeField][MessagePackMember(1)]
	private string description;
	#endregion

	#region public properties
	/// <summary>
	/// タイトル
	/// </summary>
	public string Title { get; private set; }

	/// <summary>
	/// 本文
	/// </summary>
	public string Description { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		Title		= title;
		Description	= description;
	}
}

