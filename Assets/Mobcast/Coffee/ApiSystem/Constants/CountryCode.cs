﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// 国コード
	/// 基本的に、ISO 3166-1 alpha-2に準拠したコードになっています<br/>
	/// 以下は独自実装コード<br/>
	/// イングランド	: 1000<br/>
	/// 北アイルランド	: 1001<br/>
	/// スコットランド	: 1002<br/>
	/// ウェールズ		: 1003<br/>
	/// なし			: 9999<br/>
	/// </summary>
	public enum CountryCode
	{
		/** 不正値 */
		INVALID = -1,

		/** アイスランド */
		IS = 352,

		/** アイルランド */
		IE = 372,

		/** アゼルバイジャン */
		AZ = 31,

		/** アフガニスタン */
		AF = 4,

		/** アメリカ合衆国 */
		US = 840,

		/** アメリカ領ヴァージン諸島 */
		VI = 850,

		/** アメリカ領サモア */
		AS = 16,

		/** アラブ首長国連邦 */
		AE = 784,

		/** アルジェリア */
		DZ = 12,

		/** アルゼンチン */
		AR = 32,

		/** アルバ */
		AW = 533,

		/** アルバニア */
		AL = 8,

		/** アルメニア */
		AM = 51,

		/** アンギラ */
		AI = 660,

		/** アンゴラ */
		AO = 24,

		/** アンティグア・バーブーダ */
		AG = 28,

		/** アンドラ */
		AD = 20,

		/** イエメン */
		YE = 887,

		/** イギリス */
		GB = 826,

		/** イギリス領インド洋地域 */
		IO = 86,

		/** イギリス領ヴァージン諸島 */
		VG = 92,

		/** イスラエル */
		IL = 376,

		/** イタリア */
		IT = 380,

		/** イラク */
		IQ = 368,

		/** イラン */
		IR = 364,

		/** インド */
		IN = 356,

		/** インドネシア */
		ID = 360,

		/** ウォリス・フツナ */
		WF = 876,

		/** ウガンダ */
		UG = 800,

		/** ウクライナ */
		UA = 804,

		/** ウズベキスタン */
		UZ = 860,

		/** ウルグアイ */
		UY = 858,

		/** エクアドル */
		EC = 218,

		/** エジプト */
		EG = 818,

		/** エストニア */
		EE = 233,

		/** エチオピア */
		ET = 231,

		/** エリトリア */
		ER = 232,

		/** エルサルバドル */
		SV = 222,

		/** オーストラリア */
		AU = 36,

		/** オーストリア */
		AT = 40,

		/** オーランド諸島 */
		AX = 248,

		/** オマーン */
		OM = 512,

		/** オランダ */
		NL = 528,

		/** ガーナ */
		GH = 288,

		/** カーボベルデ */
		CV = 132,

		/** ガーンジー */
		GG = 831,

		/** ガイアナ */
		GY = 328,

		/** カザフスタン */
		KZ = 398,

		/** カタール */
		QA = 634,

		/** 合衆国領有小離島 */
		UM = 581,

		/** カナダ */
		CA = 124,

		/** ガボン */
		GA = 266,

		/** カメルーン */
		CM = 120,

		/** ガンビア */
		GM = 270,

		/** カンボジア */
		KH = 116,

		/** 北マリアナ諸島 */
		MP = 580,

		/** ギニア */
		GN = 324,

		/** ギニアビサウ */
		GW = 624,

		/** キプロス */
		CY = 196,

		/** キューバ */
		CU = 192,

		/** キュラソー */
		CW = 531,

		/** ギリシャ */
		GR = 300,

		/** キリバス */
		KI = 296,

		/** キルギス */
		KG = 417,

		/** グアテマラ */
		GT = 320,

		/** グアドループ */
		GP = 312,

		/** グアム */
		GU = 316,

		/** クウェート */
		KW = 414,

		/** クック諸島 	 */
		CK = 184,

		/** グリーンランド */
		GL = 304,

		/** クリスマス島 */
		CX = 162,

		/** グルジア */
		GE = 268,

		/** グレナダ */
		GD = 308,

		/** クロアチア */
		HR = 191,

		/** ケイマン諸島 */
		KY = 136,

		/** ケニア */
		KE = 404,

		/** コートジボワール */
		CI = 384,

		/** ココス諸島 */
		CC = 166,

		/** コスタリカ */
		CR = 188,

		/** コモロ */
		KM = 174,

		/** コロンビア */
		CO = 170,

		/** コンゴ共和国 */
		CG = 178,

		/** コンゴ民主共和国 */
		CD = 180,

		/** サウジアラビア */
		SA = 682,

		/** サウスジョージア・サウスサンドウィッチ諸島 */
		GS = 239,

		/** サモア */
		WS = 882,

		/** サントメ・プリンシペ */
		ST = 678,

		/** サン・バルテルミー島 */
		BL = 652,

		/** ザンビア */
		ZM = 894,

		/** サンピエール島・ミクロン島 */
		PM = 666,

		/** サンマリノ */
		SM = 674,

		/** サン・マルタン島 */
		MF = 663,

		/** シエラレオネ */
		SL = 694,

		/** ジブチ */
		DJ = 262,

		/** ジブラルタル */
		GI = 292,

		/** ジャージー */
		JE = 832,

		/** ジャマイカ */
		JM = 388,

		/** シリア */
		SY = 760,

		/** シンガポール */
		SG = 702,

		/** シント・マールテン島 */
		SX = 534,

		/** ジンバブエ */
		ZW = 716,

		/** スイス */
		CH = 756,

		/** スウェーデン */
		SE = 752,

		/** スーダン */
		SD = 729,

		/** スヴァールバル諸島およびヤンマイエン島 */
		SJ = 744,

		/** スペイン */
		ES = 724,

		/** スリナム */
		SR = 740,

		/** スリランカ */
		LK = 144,

		/** スロバキア */
		SK = 703,

		/** スロベニア */
		SI = 705,

		/** スワジランド */
		SZ = 748,

		/** セーシェル */
		SC = 690,

		/** 赤道ギニア */
		GQ = 226,

		/** セネガル */
		SN = 686,

		/** セルビア */
		RS = 688,

		/** セントクリストファー・ネイビス */
		KN = 659,

		/** セントビンセント・グレナディーン */
		VC = 670,

		/** セントヘレナ・アセンションおよびトリスタン・ダ・クーニャ */
		SH = 654,

		/** セントルシア */
		LC = 662,

		/** ソマリア */
		SO = 706,

		/** ソロモン諸島 */
		SB = 90,

		/** タークス・カイコス諸島 */
		TC = 796,

		/** タイ */
		TH = 764,

		/** 大韓民国 */
		KR = 410,

		/** 台湾 */
		TW = 158,

		/** タジキスタン */
		TJ = 762,

		/** タンザニア */
		TZ = 834,

		/** チェコ */
		CZ = 203,

		/** チャド */
		TD = 148,

		/** 中央アフリカ */
		CF = 140,

		/** 中華人民共和国 */
		CN = 156,

		/** チュニジア */
		TN = 788,

		/** 朝鮮民主主義人民共和国 */
		KP = 408,

		/** チリ */
		CL = 152,

		/** ツバル */
		TV = 798,

		/** デンマーク */
		DK = 208,

		/** ドイツ */
		DE = 276,

		/** トーゴ */
		TG = 768,

		/** トケラウ */
		TK = 772,

		/** ドミニカ共和国 */
		DO = 214,

		/** ドミニカ国 */
		DM = 212,

		/** トリニダード・トバゴ */
		TT = 780,

		/** トルクメニスタン */
		TM = 795,

		/** トルコ */
		TR = 792,

		/** トンガ */
		TO = 776,

		/** ナイジェリア */
		NG = 566,

		/** ナウル */
		NR = 520,

		/** ナミビア */
		NA = 516,

		/** 南極 */
		AQ = 10,

		/** ニウエ */
		NU = 570,

		/** ニカラグア */
		NI = 558,

		/** ニジェール */
		NE = 562,

		/** 日本 */
		JP = 392,

		/** 西サハラ */
		EH = 732,

		/** ニューカレドニア */
		NC = 540,

		/** ニュージーランド */
		NZ = 554,

		/** ネパール */
		NP = 524,

		/** ノーフォーク島 */
		NF = 574,

		/** ノルウェー */
		NO = 578,

		/** ハード島とマクドナルド諸島 */
		HM = 334,

		/** バーレーン */
		BH = 48,

		/** ハイチ */
		HT = 332,

		/** パキスタン */
		PK = 586,

		/** バチカン */
		VA = 336,

		/** パナマ */
		PA = 591,

		/** バヌアツ */
		VU = 548,

		/** バハマ */
		BS = 44,

		/** パプアニューギニア */
		PG = 598,

		/** バミューダ諸島 */
		BM = 60,

		/** パラオ */
		PW = 585,

		/** パラグアイ */
		PY = 600,

		/** バルバドス */
		BB = 52,

		/** パレスチナ */
		PS = 275,

		/** ハンガリー */
		HU = 348,

		/** バングラデシュ */
		DB = 50,

		/** 東ティモール */
		TL = 626,

		/** ピトケアン */
		PN = 612,

		/** フィジー */
		FJ = 242,

		/** フィリピン */
		PH = 608,

		/** フィンランド */
		FI = 246,

		/** ブータン */
		BT = 64,

		/** ブーベ島 */
		BV = 74,

		/** プエルトリコ */
		PR = 630,

		/** フェロー諸島 */
		FO = 234,

		/** フォークランド諸島 */
		FK = 238,

		/** ブラジル */
		BR = 76,

		/** フランス */
		FR = 250,

		/** フランス領ギアナ */
		GF = 254,

		/** フランス領ポリネシア */
		PF = 258,

		/** フランス領南方・南極地域 */
		TF = 260,

		/** ブルガリア */
		BG = 100,

		/** ブルキナファソ */
		BF = 854,

		/** ブルネイ */
		BN = 96,

		/** ブルンジ */
		BI = 108,

		/** ベトナム */
		VN = 704,

		/** ベナン */
		BJ = 204,

		/** ベネズエラ */
		VE = 862,

		/** ベラルーシ */
		BY = 112,

		/** ベリーズ */
		BZ = 84,

		/** ペルー */
		PE = 604,

		/** ベルギー */
		BE = 56,

		/** ポーランド */
		PL = 616,

		/** ボスニア・ヘルツェゴビナ */
		BA = 70,

		/** ボツワナ */
		BW = 72,

		/** ボネール、シント・ユースタティウスおよびサバ */
		BQ = 535,

		/** ボリビア */
		BO = 68,

		/** ポルトガル */
		PT = 620,

		/** 香港 */
		HK = 344,

		/** ホンジュラス */
		HN = 340,

		/** マーシャル諸島 */
		MH = 584,

		/** マカオ */
		MO = 446,

		/** マケドニア共和国 */
		MK = 807,

		/** マダガスカル */
		MG = 450,

		/** マヨット */
		YT = 175,

		/** マラウイ */
		MW = 454,

		/** マリ */
		ML = 466,

		/** マルタ */
		MT = 470,

		/** マルティニーク */
		MQ = 474,

		/** マレーシア */
		MY = 458,

		/** マン島 */
		IM = 833,

		/** ミクロネシア連邦 */
		FM = 583,

		/** 南アフリカ */
		ZA = 710,

		/** 南スーダン */
		SS = 728,

		/** ミャンマー */
		MM = 104,

		/** メキシコ */
		MX = 484,

		/** モーリシャス */
		MU = 480,

		/** モーリタニア */
		MR = 478,

		/** モザンビーク */
		MZ = 508,

		/** モナコ */
		MC = 492,

		/** モルディブ */
		MV = 462,

		/** モルドバ */
		MD = 498,

		/** モロッコ */
		MA = 504,

		/** モンゴル */
		MN = 496,

		/** モンテネグロ */
		ME = 499,

		/** モントセラト */
		MS = 500,

		/** ヨルダン */
		JO = 400,

		/** ラオス */
		LA = 418,

		/** ラトビア */
		LV = 428,

		/** リトアニア */
		LT = 440,

		/** リビア */
		LY = 434,

		/** リヒテンシュタイン */
		LI = 438,

		/** リベリア */
		LR = 430,

		/** ルーマニア */
		RO = 642,

		/** ルクセンブルク */
		LU = 442,

		/** ルワンダ */
		RW = 646,

		/** レソト */
		LS = 426,

		/** レバノン */
		LB = 422,

		/** レユニオン */
		RE = 638,

		/** ロシア */
		RU = 643,

		// 以下は独自実装コード
		/** イングランド */
		GB_EN = 1000,

		/** 北アイルランド */
		GB_NI = 1001,

		/** スコットランド */
		GB_SC = 1002,

		/** ウェールズ */
		GB_WA = 1003,

		/** なし */
		NONE = 9999,
	}
}