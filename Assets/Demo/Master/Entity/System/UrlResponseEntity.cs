using System;
using Mobcast.Coffee.Api;
using System.Collections.Generic;
using MsgPack.Serialization;
using UnityEngine;

#pragma warning disable 649

/// <summary>
/// レスポンスデータ：URL管理データ
/// </summary>
[Serializable]
public  class UrlResponseEntity : IResponsePacket
{
	#region private properties
	/// <summary>
	/// お知らせURL
	/// </summary>
	[SerializeField][MessagePackMember(0)]
	private string noticeUrl = string.Empty;

	/// <summary>
	/// 利用規約(terms of service)URL
	/// </summary>
	[SerializeField][MessagePackMember(1)]
	private string tosUrl = string.Empty;

	/// <summary>
	/// 資金決済法に基づく表示(Payment Services Act)URL
	/// </summary>
	[SerializeField][MessagePackMember(2)]
	private string psaUrl = string.Empty;

	/// <summary>
	/// 特定商取引法に基づく表示(Specified Commercial Transactions)URL
	/// </summary>
	[SerializeField][MessagePackMember(3)]
	private string sctUrl = string.Empty;

	/// <summary>
	/// プライバシーポリシーURL
	/// </summary>
	[SerializeField][MessagePackMember(4)]
	private string privacyPolicyUrl = string.Empty;

	/// <summary>
	/// クレジットURL
	/// </summary>
	[SerializeField][MessagePackMember(5)]
	private string creditUrl = string.Empty;

	/// <summary>
	/// コピーライトURL
	/// </summary>
	[SerializeField][MessagePackMember(6)]
	private string copyRightUrl = string.Empty;

	/// <summary>
	/// サポートURL
	/// </summary>
	[SerializeField][MessagePackMember(7)]
	private string supportUrl = string.Empty;

	/// <summary>
	/// ヘルプURL
	/// </summary>
	[SerializeField][MessagePackMember(8)]
	private string helpUrl = string.Empty;

	/// <summary>
	/// ストアレビューURL
	/// </summary>
	[SerializeField][MessagePackMember(9)]
	private string reviewUrl = string.Empty;

	/// <summary>
	/// 公式サイトURL
	/// </summary>
	[SerializeField][MessagePackMember(10)]
	private string officialSiteUrl = string.Empty;

	/// <summary>
	/// 公式TWIITER URL
	/// </summary>
	[SerializeField][MessagePackMember(11)]
	private string officialTwitterUrl = string.Empty;

	/// <summary>
	/// 公式LINE URL
	/// </summary>
	[SerializeField][MessagePackMember(12)]
	private string officialLineUrl = string.Empty;

	/// <summary>
	/// 公式Facebook URL
	/// </summary>
	[SerializeField][MessagePackMember(13)]
	private string officialFacebookUrl = string.Empty;

	/// <summary>
	/// TwitterアプリUrlScheme
	/// </summary>
	[SerializeField][MessagePackMember(14)]
	private string officialTwitterUrlScheme = string.Empty;

	/// <summary>
	/// facebookアプリUrlScheme
	/// </summary>
	[SerializeField][MessagePackMember(15)]
	private string officialFacebookUrlScheme = string.Empty;

	/// <summary>
	/// LINEアプリUrlScheme
	/// </summary>
	[SerializeField][MessagePackMember(16)]
	private string officialLineUrlScheme = string.Empty;

	/// <summary>
	/// 遊び方URL
	/// </summary>
	[SerializeField][MessagePackMember(17)]
	private string howToUrl = string.Empty;
	#endregion

	#region public properties
	/// <summary>
	/// お知らせURL
	/// </summary>
	[MessagePackIgnore]
	public string NoticeUrl { get; private set; }

	/// <summary>
	/// 利用規約(terms of service)URL
	/// </summary>
	[MessagePackIgnore]
	public string TosUrl { get; private set; }

	/// <summary>
	/// 資金決済法に基づく表示(Payment Services Act)URL
	/// </summary>
	[MessagePackIgnore]
	public string PsaUrl { get; private set; }

	/// <summary>
	/// 特定商取引法に基づく表示(Specified Commercial Transactions)URL
	/// </summary>
	[MessagePackIgnore]
	public string SctUrl { get; private set; }

	/// <summary>
	/// プライバシーポリシーURL
	/// </summary>
	[MessagePackIgnore]
	public string PrivacyPolicyUrl { get; private set; }

	/// <summary>
	/// クレジットURL
	/// </summary>
	[MessagePackIgnore]
	public string CreditUrl { get; private set; }

	/// <summary>
	/// コピーライトURL
	/// </summary>
	[MessagePackIgnore]
	public string CopyRightUrl { get; private set; }

	/// <summary>
	/// サポートURL
	/// </summary>
	[MessagePackIgnore]
	public string SupportUrl { get; private set; }

	/// <summary>
	/// ヘルプURL
	/// </summary>
	[MessagePackIgnore]
	public string HelpUrl { get; private set; }

	/// <summary>
	/// ストアレビューURL
	/// </summary>
	[MessagePackIgnore]
	public string ReviewUrl { get; private set; }

	/// <summary>
	/// 公式サイトURL
	/// </summary>
	[MessagePackIgnore]
	public string OfficialSiteUrl { get; private set; }

	/// <summary>
	/// 公式TWIITER URL
	/// </summary>
	[MessagePackIgnore]
	public string OfficialTwitterUrl { get; private set; }

	/// <summary>
	/// 公式LINE URL
	/// </summary>
	[MessagePackIgnore]
	public string OfficialLineUrl { get; private set; }

	/// <summary>
	/// 公式Facebook URL
	/// </summary>
	[MessagePackIgnore]
	public string OfficialFacebookUrl { get; private set; }

	/// <summary>
	/// TwitterアプリUrlScheme
	/// </summary>
	[MessagePackIgnore]
	public string OfficialTwitterUrlScheme { get; private set; }

	/// <summary>
	/// facebookアプリUrlScheme
	/// </summary>
	[MessagePackIgnore]
	public string OfficialFacebookUrlScheme { get; private set; }

	/// <summary>
	/// LINEアプリUrlScheme
	/// </summary>
	[MessagePackIgnore]
	public string OfficialLineUrlScheme { get; private set; }

	/// <summary>
	/// 遊び方URL
	/// </summary>
	[MessagePackIgnore]
	public string HowToUrl { get; private set; }
	#endregion

	public void OnAfterDeserialize(ApiResponseMeta header)
	{
//		NoticeUrl					= noticeUrl;
//		TosUrl						= tosUrl;
//		PsaUrl						= psaUrl;
//		SctUrl						= sctUrl;
//		PrivacyPolicyUrl			= privacyPolicyUrl;
//		CreditUrl					= creditUrl;
//		CopyRightUrl				= copyRightUrl;
//		SupportUrl					= supportUrl;
//		HelpUrl						= helpUrl;
//		ReviewUrl					= reviewUrl;
//		OfficialSiteUrl				= officialSiteUrl;
//		OfficialTwitterUrl			= officialTwitterUrl;
//		OfficialLineUrl				= officialLineUrl;
//		OfficialFacebookUrl			= officialFacebookUrl;
//		OfficialTwitterUrlScheme	= officialTwitterUrlScheme;
//		OfficialLineUrlScheme		= officialLineUrlScheme;
//		OfficialFacebookUrlScheme	= officialFacebookUrlScheme;
//		HowToUrl					= howToUrl;
	}
}

