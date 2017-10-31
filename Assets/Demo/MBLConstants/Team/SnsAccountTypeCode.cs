using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// SNSアカウントタイプコード
/// </summary>
public enum eSnsAccountTypeCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// googleアカウント
	/// </summary>
	GOOGLE		= 0,

	/// <summary>
	/// Twitterアカウント
	/// </summary>
	TWITTER		= 1,
}
