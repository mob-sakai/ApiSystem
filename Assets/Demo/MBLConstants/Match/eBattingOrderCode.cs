using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 打順コード
/// </summary>
public enum eBattingOrderCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	//---- スタメン打順 ----
	/// <summary>
	/// １番
	/// </summary>
	REGULAR_1ST	=  0,

	/// <summary>
	/// ２番
	/// </summary>
	REGULAR_2ND	=  1,

	/// <summary>
	/// ３番
	/// </summary>
	REGULAR_3RD	=  2,

	/// <summary>
	/// ４番
	/// </summary>
	REGULAR_4TH	=  3,

	/// <summary>
	/// ５番
	/// </summary>
	REGULAR_5TH	=  4,

	/// <summary>
	/// ６番
	/// </summary>
	REGULAR_6TH	=  5,

	/// <summary>
	/// ７番
	/// </summary>
	REGULAR_7TH	=  6,

	/// <summary>
	/// ８番
	/// </summary>
	REGULAR_8TH	=  7,

	/// <summary>
	/// ９番
	/// </summary>
	REGULAR_9TH	=  8,

	//---- 控え野手 ----
	/// <summary>
	/// 控え１
	/// </summary>
	RESERVE_1	=  9,

	/// <summary>
	/// 控え２
	/// </summary>
	RESERVE_2	= 10,

	/// <summary>
	/// 控え３
	/// </summary>
	RESERVE_3	= 11,

	/// <summary>
	/// 控え４
	/// </summary>
	RESERVE_4	= 12,

	//---- 先発ピッチャー ----
	/// <summary>
	/// 先発１
	/// </summary>
	STARTER_1	= 13,

	/// <summary>
	/// 先発２
	/// </summary>
	STARTER_2	= 14,

	/// <summary>
	/// 先発３
	/// </summary>
	STARTER_3	= 15,

	//---- 中継ぎピッチャー ----
	/// <summary>
	/// 中継ぎ１
	/// </summary>
	SET_UPPER_1	= 16,

	/// <summary>
	/// 中継ぎ２
	/// </summary>
	SET_UPPER_2	= 17,

	/// <summary>
	/// 中継ぎ３
	/// </summary>
	SET_UPPER_3	= 18,

	//---- 抑えピッチャー ----
	/// <summary>
	/// 抑え
	/// </summary>
	CLOSER		= 19,
}
