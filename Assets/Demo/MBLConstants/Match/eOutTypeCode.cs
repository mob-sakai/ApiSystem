using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// アウト種類コード
/// </summary>
public enum eOutTypeCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID				= -1,

	/*---------------- 空振三振 ----------------*/
	/// <summary>
	/// 空振三振
	/// </summary>
	SWING_STRIKE		=  0,

	/*---------------- 見逃三振 ----------------*/
	/// <summary>
	/// 見逃三振
	/// </summary>
	CALLED_STRIKE		=  1,

	/*---------------- 内野ゴロ ----------------*/
	/// <summary>
	/// 投ゴ
	/// </summary>
	GROUND_P			=  2,

	/// <summary>
	/// 捕ゴ
	/// </summary>
	GROUND_C			=  3,

	/// <summary>
	/// 一ゴ
	/// </summary>
	GROUND_FB			=  4,

	/// <summary>
	/// 二ゴ
	/// </summary>
	GROUND_SB			=  5,

	/// <summary>
	/// 三ゴ
	/// </summary>
	GROUND_TB			=  6,

	/// <summary>
	/// 遊ゴ
	/// </summary>
	GROUND_SS			=  7,

	/*---------------- ライナー ----------------*/
	/// <summary>
	/// 投直
	/// </summary>
	LINER_P				=  8,

	/// <summary>
	/// 捕直
	/// </summary>
	LINER_C				=  9,

	/// <summary>
	/// 一直
	/// </summary>
	LINER_FB			= 10,

	/// <summary>
	/// 二直
	/// </summary>
	LINER_SB			= 11,

	/// <summary>
	/// 三直
	/// </summary>
	LINER_TB			= 12,

	/// <summary>
	/// 遊直
	/// </summary>
	LINER_SS			= 13,

	/// <summary>
	/// 左直
	/// </summary>
	LINER_LF			= 14,

	/// <summary>
	/// 中直
	/// </summary>
	LINER_CF			= 15,

	/// <summary>
	/// 右直
	/// </summary>
	LINER_RF			= 16,

	/*---------------- 内野フライ ----------------*/
	/// <summary>
	/// 投飛
	/// </summary>
	FLY_P				= 17,

	/// <summary>
	/// 捕飛
	/// </summary>
	FLY_C				= 18,

	/// <summary>
	/// 一飛
	/// </summary>
	FLY_FB				= 19,

	/// <summary>
	/// 二飛
	/// </summary>
	FLY_SB				= 20,

	/// <summary>
	/// 三飛
	/// </summary>
	FLY_TB				= 21,

	/// <summary>
	/// 遊飛
	/// </summary>
	FLY_SS				= 22,

	/*---------------- 外野フライ ----------------*/
	/// <summary>
	/// 左飛
	/// </summary>
	FLY_LF				= 23,

	/// <summary>
	/// 中飛
	/// </summary>
	FLY_CF				= 24,

	/// <summary>
	/// 右飛
	/// </summary>
	FLY_RF				= 25,

	/*---------------- 内野ファウルフライ ----------------*/
	/// <summary>
	/// 投邪
	/// </summary>
	FOUL_FLY_P			= 26,

	/// <summary>
	/// 捕邪
	/// </summary>
	FOUL_FLY_C			= 27,

	/// <summary>
	/// 一邪
	/// </summary>
	FOUL_FLY_FB			= 28,

	/// <summary>
	/// 二邪
	/// </summary>
	FOUL_FLY_SB			= 29,

	/// <summary>
	/// 三邪
	/// </summary>
	FOUL_FLY_TB			= 30,

	/// <summary>
	/// 遊邪
	/// </summary>
	FOUL_FLY_SS			= 31,

	/*---------------- 外野ファウルフライ ----------------*/
	/// <summary>
	/// 左邪
	/// </summary>
	FOUL_FLY_LF			= 32,

	/// <summary>
	/// 中邪
	/// </summary>
	FOUL_FLY_CF			= 33,

	/// <summary>
	/// 右邪
	/// </summary>
	FOUL_FLY_RF			= 34,

	/*---------------- ダブルプレー ----------------*/
	/// <summary>
	/// 投併
	/// </summary>
	DOBULE_PLAY_P		= 35,

	/// <summary>
	/// 捕併
	/// </summary>
	DOBULE_PLAY_C		= 36,

	/// <summary>
	/// 一併
	/// </summary>
	DOBULE_PLAY_FB		= 37,

	/// <summary>
	/// 二併
	/// </summary>
	DOBULE_PLAY_SB		= 38,

	/// <summary>
	/// 三併
	/// </summary>
	DOBULE_PLAY_TB		= 39,

	/// <summary>
	/// 遊併
	/// </summary>
	DOBULE_PLAY_SS		= 40,

	/// <summary>
	/// 左併
	/// </summary>
	DOBULE_PLAY_LF		= 41,

	/// <summary>
	/// 中併
	/// </summary>
	DOBULE_PLAY_CF		= 42,

	/// <summary>
	/// 右併
	/// </summary>
	DOBULE_PLAY_RF		= 43,

	/*---------------- 犠打 ----------------*/
	/// <summary>
	/// 投儀
	/// </summary>
	SAC_P				= 44,

	/// <summary>
	/// 捕儀
	/// </summary>
	SAC_C				= 45,

	/// <summary>
	/// 一儀
	/// </summary>
	SAC_FB				= 46,

	/// <summary>
	/// 二儀
	/// </summary>
	SAC_SB				= 47,

	/// <summary>
	/// 三儀
	/// </summary>
	SAC_TB				= 48,

	/// <summary>
	/// 遊儀
	/// </summary>
	SAC_SS				= 49,

	/// <summary>
	/// 左犠飛
	/// </summary>
	SF_LF				= 50,

	/// <summary>
	/// 中犠飛
	/// </summary>
	SF_CF				= 51,

	/// <summary>
	/// 右犠飛
	/// </summary>
	SF_RF				= 52,
}
