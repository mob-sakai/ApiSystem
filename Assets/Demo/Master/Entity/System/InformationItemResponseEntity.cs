using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// レスポンスデータ：インフォメーションアイテムデータ
/// </summary>
[Serializable]
public  class InformationItemResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// インフォメーション種類コード値
	/// </summary>
	[SerializeField][MessagePackMember(0)]
	private int informationKind;

	/// <summary>
	/// タイトル
	/// </summary>
	[SerializeField][MessagePackMember(1)]
	private string title;

	/// <summary>
	/// インフォメーション要素データリスト
	/// </summary>
	[SerializeField][MessagePackMember(2)]
	private List<InformationElementResponseEntity> informationElementList;
	#endregion

	#region public properties
	/// <summary>
	/// インフォメーション種類コード
	/// </summary>
	public eInformationKindCode InformationKindCode { get; private set; }

	/// <summary>
	/// タイトル
	/// </summary>
	public string Title { get; private set; }

	/// <summary>
	/// インフォメーション要素データリスト
	/// </summary>
	public List<InformationElementResponseEntity> InformationElementList { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		InformationKindCode		= (eInformationKindCode)informationKind;
		Title					= title;
		InformationElementList	= informationElementList.DeserializeOrDefault(header);
	}
}

