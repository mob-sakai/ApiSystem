using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// タイムゾーン
	/// cf:RFC2822
	/// </summary>
	public enum TimeZoneCode
	{
		/// <summary>
		/// 不正値
		/// </summary>
		INVALID	= -1,

		/// <summary>
		/// グリニッジ標準時
		/// </summary>
		GMT		= 0,

		/// <summary>
		/// 国際標準時
		/// </summary>
		UTC		= 1,

		/// <summary>
		/// ヨーロッパ中央時間	GMT+1:00
		/// </summary>
		CET		= 2,

		/// <summary>
		/// 東ヨーロッパ時間	GMT+2:00
		/// </summary>
		EET		= 3,

		/// <summary>
		/// (アラブ) エジプト標準時間	GMT+2:00
		/// </summary>
		ART		= 4,

		/// <summary>
		/// 東アフリカ時間	GMT+3:00
		/// </summary>
		EAT		= 5,

		/// <summary>
		/// 中東時間	GMT+3:30
		/// </summary>
		MET		= 6,

		/// <summary>
		/// 近東時間	GMT+4:00
		/// </summary>
		NET		= 7,

		/// <summary>
		/// パキスタン・ラホール時間	GMT+5:00
		/// </summary>
		PLT		= 8,

		/// <summary>
		/// インド標準時	GMT+5:30
		/// </summary>
		IST		= 9,

		/// <summary>
		/// バングラデシュ標準時	GMT+6:00
		/// </summary>
		BST		= 10,

		/// <summary>
		/// ベトナム標準時	GMT+7:00
		/// </summary>
		VST		= 11,

		/// <summary>
		/// 中国台湾時間	GMT+8:00
		/// </summary>
		CTT		= 12,

		/// <summary>
		/// 日本標準時	GMT+9:00
		/// </summary>
		JST		= 13,

		/// <summary>
		/// オーストラリア中央時間	GMT+9:30
		/// </summary>
		ACT		= 14,

		/// <summary>
		/// オーストラリア東部時間	GMT+10:00
		/// </summary>
		AET		= 15,

		/// <summary>
		/// ソロモン諸島標準時	GMT+11:00
		/// </summary>
		SST		= 16,

		/// <summary>
		/// ニュージーランド標準時	GMT+12:00
		/// </summary>
		NST		= 17,

		/// <summary>
		/// ミッドウェー標準時	GMT-11:00
		/// </summary>
		MIT		= 18,

		/// <summary>
		/// ハワイ標準時	GMT-10:00
		/// </summary>
		HST		= 19,

		/// <summary>
		/// アラスカ標準時	GMT-9:00
		/// </summary>
		AST		= 20,

		/// <summary>
		/// 太平洋標準時 (米国およびカナダ)	GMT-8:00
		/// </summary>
		PST		= 21,

		/// <summary>
		/// フェニックス標準時	GMT-7:00
		/// </summary>
		PNT		= 22,

		/// <summary>
		/// 山地標準時 (米国およびカナダ)	GMT-7:00
		/// </summary>
		MST		= 23,

		/// <summary>
		/// 中部標準時 (米国およびカナダ)	GMT-6:00
		/// </summary>
		CST		= 24,

		/// <summary>
		/// 東部標準時 (米国およびカナダ)	GMT-5:00
		/// </summary>
		EST		= 25,

		/// <summary>
		/// インディアナ東部標準時	GMT-5:00
		/// </summary>
		IET		= 26,

		/// <summary>
		/// プエルトリコおよび米領バージン諸島時間	GMT-4:00
		/// </summary>
		PRT		= 27,

		/// <summary>
		/// カナダ・ニューファウンドランド島時間	GMT-3:30
		/// </summary>
		CNT		= 28,

		/// <summary>
		/// アルゼンチン標準時	GMT-3:00
		/// </summary>
		AGT		= 29,

		/// <summary>
		/// ブラジル東部時間	GMT-3:00
		/// </summary>
		BET		= 30,

		/// <summary>
		/// 中央アフリカ時間	GMT-1:00
		/// </summary>
		CAT		= 31
	}
}
