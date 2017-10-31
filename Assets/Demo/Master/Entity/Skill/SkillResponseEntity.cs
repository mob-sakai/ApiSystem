using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// 特性データ
/// </summary>
[Serializable]
public class SkillResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// 特性ID
	/// </summary>
	[SerializeField][MessagePackMember (0)]
	private int skillId = new int ();

	/// <summary>
	/// 特性レアリティコード値
	/// </summary>
	[SerializeField][MessagePackMember (1)]
	private int skillRarity = new int ();

	/// <summary>
	/// 特性名
	/// </summary>
	[SerializeField][MessagePackMember (2)]
	private string skillName = string.Empty;

	/// <summary>
	/// 説明
	/// </summary>
	[SerializeField][MessagePackMember (3)]
	private string description = string.Empty;
	#endregion

	#region public properties
	/// <summary>
	/// 特性ID
	/// </summary>
	public int SkillId { get; private set; }

	/// <summary>
	/// 特性レアリティコード
	/// </summary>
	public eSkillRarityCode SkillRarityCode;

	/// <summary>
	/// 特性名
	/// </summary>
	public string SkillName { get; private set; }

	/// <summary>
	/// 説明
	/// </summary>
	public string Description { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
		SkillId			= skillId;
		SkillRarityCode	= (eSkillRarityCode)skillRarity;
		SkillName		= skillName;
		Description		= description;
	}
}
