using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 加入条件タイプコード
/// </summary>
public enum eClubEntryConditionCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID = -1,

	/// <summary>
	/// 加入受け付け停止
	/// </summary>
	STOP = 0,

	/// <summary>
	/// 申請制
	/// </summary>
	APPLICATION = 1,

	/// <summary>
	/// 誰でもOK
	/// </summary>
	ANYONE = 2,
}