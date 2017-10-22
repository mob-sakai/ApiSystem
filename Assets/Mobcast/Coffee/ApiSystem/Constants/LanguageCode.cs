using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// 言語コード
	/// </summary>
	/// <remarks>
	/// ISO 639-1 の２文字コードを連結した数字をコードの値としています
	/// <example>
	/// AR : ar -> a:0x61 r:0x72 → 0x6172
	/// </example>
	/// </remarks>
	public enum LanguageCode
	{
		/// <summary>
		/// 不正値
		/// </summary>
		INVALID = -1,

		/// <summary>
		/// アラビア語
		/// </summary>
		AR = 0x6172,
		/// <summary>
		/// ブルガリア語
		/// </summary>
		BG = 0x6267,
		/// <summary>
		/// カタルニア語
		/// </summary>
		CA = 0x6361,
		/// <summary>
		/// チェコ語
		/// </summary>
		CS = 0x6373,
		/// <summary>
		/// デンマーク語
		/// </summary>
		DA = 0x6461,
		/// <summary>
		/// ドイツ語
		/// </summary>
		DE = 0x6465,
		/// <summary>
		/// ギリシャ語
		/// </summary>
		EL = 0x656C,
		/// <summary>
		/// 英語
		/// </summary>
		EN = 0x656E,
		/// <summary>
		/// スペイン語
		/// </summary>
		ES = 0x6573,
		/// <summary>
		/// フィンランド語
		/// </summary>
		FI = 0x6669,
		/// <summary>
		/// フランス語
		/// </summary>
		FR = 0x6672,
		/// <summary>
		/// ヘブライ語
		/// </summary>
		HE = 0x6865,
		/// <summary>
		/// ハンガリー語
		/// </summary>
		HU = 0x6875,
		/// <summary>
		/// アイスランド語
		/// </summary>
		IS = 0x6973,
		/// <summary>
		/// イタリア語
		/// </summary>
		IT = 0x6974,
		/// <summary>
		/// 日本語
		/// </summary>
		JA = 0x6A61,
		/// <summary>
		/// 韓国語
		/// </summary>
		KO = 0x6B6F,
		/// <summary>
		/// オランダ語
		/// </summary>
		NL = 0x6E6C,
		/// <summary>
		/// ノルウェー語
		/// </summary>
		NO = 0x6E6F,
		/// <summary>
		/// ポーランド語
		/// </summary>
		PL = 0x706C,
		/// <summary>
		/// ポルトガル語
		/// </summary>
		PT = 0x7074,
		/// <summary>
		/// ロマンシュ語
		/// </summary>
		RM = 0x726D,
		/// <summary>
		/// ルーマニア語
		/// </summary>
		RO = 0x726F,
		/// <summary>
		/// ロシア語
		/// </summary>
		RU = 0x7275,
		/// <summary>
		/// クロアチア語
		/// </summary>
		HR = 0x6872,
		/// <summary>
		/// スロバキア語
		/// </summary>
		SK = 0x736B,
		/// <summary>
		/// アルバニア語
		/// </summary>
		SQ = 0x7371,
		/// <summary>
		/// スウェーデン語
		/// </summary>
		SV = 0x7376,
		/// <summary>
		/// タイ語
		/// </summary>
		TH = 0x7468,
		/// <summary>
		/// トルコ語
		/// </summary>
		TR = 0x7472,
		/// <summary>
		/// ウルドゥー語
		/// </summary>
		UR = 0x7572,
		/// <summary>
		/// インドネシア語
		/// </summary>
		ID = 0x6964,
		/// <summary>
		/// ウクライナ語
		/// </summary>
		UK = 0x756B,
		/// <summary>
		/// ベラルーシ語
		/// </summary>
		BE = 0x6265,
		/// <summary>
		/// スロベニア語
		/// </summary>
		SL = 0x736C,
		/// <summary>
		/// エストニア語
		/// </summary>
		ET = 0x6574,
		/// <summary>
		/// ラトビア語
		/// </summary>
		LV = 0x6C76,
		/// <summary>
		/// リトアニア語
		/// </summary>
		LT = 0x6C74,
		/// <summary>
		/// タジク語
		/// </summary>
		TG = 0x7467,
		/// <summary>
		/// ペルシャ語
		/// </summary>
		FA = 0x6661,
		/// <summary>
		/// ベトナム語
		/// </summary>
		VI = 0x7669,
		/// <summary>
		/// アルメニア語
		/// </summary>
		HY = 0x6879,
		/// <summary>
		/// アゼルバイジャン語
		/// </summary>
		AZ = 0x617A,
		/// <summary>
		/// バスク語
		/// </summary>
		EU = 0x6575,
		/// <summary>
		/// マケドニア語 (FYROM)
		/// </summary>
		MK = 0x6D6B,
		/// <summary>
		/// セツワナ語
		/// </summary>
		TN = 0x746E,
		/// <summary>
		/// コサ語
		/// </summary>
		XH = 0x7868,
		/// <summary>
		/// ズールー語
		/// </summary>
		ZU = 0x7A75,
		/// <summary>
		/// アフリカーンス語
		/// </summary>
		AF = 0x6166,
		/// <summary>
		/// グルジア語
		/// </summary>
		KA = 0x6B61,
		/// <summary>
		/// フェロー語
		/// </summary>
		FO = 0x666F,
		/// <summary>
		/// ヒンディー語
		/// </summary>
		HI = 0x6869,
		/// <summary>
		/// マルタ語
		/// </summary>
		MT = 0x6D74,
		/// <summary>
		/// サーミ語 (北)
		/// </summary>
		SE = 0x7365,
		/// <summary>
		/// アイルランド語
		/// </summary>
		GA = 0x6761,
		/// <summary>
		/// マレー語
		/// </summary>
		MS = 0x6D73,
		/// <summary>
		/// カザフ語
		/// </summary>
		KK = 0x6B6B,
		/// <summary>
		/// キルギス語
		/// </summary>
		KY = 0x6B79,
		/// <summary>
		/// スワヒリ語
		/// </summary>
		SW = 0x7377,
		/// <summary>
		/// トルクメン語
		/// </summary>
		TK = 0x746B,
		/// <summary>
		/// ウズベク語
		/// </summary>
		UZ = 0x757A,
		/// <summary>
		/// タタール語
		/// </summary>
		TT = 0x7474,
		/// <summary>
		/// ベンガル語
		/// </summary>
		BN = 0x626E,
		/// <summary>
		/// パンジャブ語
		/// </summary>
		PA = 0x7061,
		/// <summary>
		/// グジャラート語
		/// </summary>
		GU = 0x6775,
		/// <summary>
		/// オリヤー語
		/// </summary>
		OR = 0x6F72,
		/// <summary>
		/// タミール語
		/// </summary>
		TA = 0x7461,
		/// <summary>
		/// テルグ語
		/// </summary>
		TE = 0x7465,
		/// <summary>
		/// カナラ語
		/// </summary>
		KN = 0x6B6E,
		/// <summary>
		/// マラヤーラム語
		/// </summary>
		ML = 0x6D6C,
		/// <summary>
		/// アッサム語
		/// </summary>
		AS = 0x6173,
		/// <summary>
		/// マラーティー語
		/// </summary>
		MR = 0x6D72,
		/// <summary>
		/// サンスクリット語
		/// </summary>
		SA = 0x7361,
		/// <summary>
		/// モンゴル語
		/// </summary>
		MN = 0x6D6E,
		/// <summary>
		/// チベット語
		/// </summary>
		BO = 0x626F,
		/// <summary>
		/// ウェールズ語
		/// </summary>
		CY = 0x6379,
		/// <summary>
		/// クメール語
		/// </summary>
		KM = 0x6B6D,
		/// <summary>
		/// ラオス語
		/// </summary>
		LO = 0x6C6F,
		/// <summary>
		/// ガリシア語
		/// </summary>
		GL = 0x676C,
		/// <summary>
		/// シンハラ語
		/// </summary>
		SI = 0x7369,
		/// <summary>
		/// イヌクティトット語
		/// </summary>
		IU = 0x6975,
		/// <summary>
		/// アムハラ語
		/// </summary>
		AM = 0x616D,
		/// <summary>
		/// ネパール語
		/// </summary>
		NE = 0x6E65,
		/// <summary>
		/// フリジア語
		/// </summary>
		FY = 0x6679,
		/// <summary>
		/// パシュトゥー語
		/// </summary>
		PS = 0x7073,
		/// <summary>
		/// フィリピノ語
		/// </summary>
		TL = 0x746C,
		/// <summary>
		/// ディヘビ語
		/// </summary>
		DV = 0x6476,
		/// <summary>
		/// ハウサ語
		/// </summary>
		HA = 0x6861,
		/// <summary>
		/// ヨルバ語
		/// </summary>
		YO = 0x796F,
		/// <summary>
		/// バシュキール語
		/// </summary>
		BA = 0x6261,
		/// <summary>
		/// ルクセングルグ語
		/// </summary>
		LB = 0x6C62,
		/// <summary>
		/// グリーンランド語
		/// </summary>
		KL = 0x6B6C,
		/// <summary>
		/// イボ語
		/// </summary>
		IG = 0x6967,
		/// <summary>
		/// イ語
		/// </summary>
		II = 0x6969,
		/// <summary>
		/// ブルトン語
		/// </summary>
		BR = 0x6272,
		/// <summary>
		/// ウイグル語
		/// </summary>
		UG = 0x7567,
		/// <summary>
		/// マオリ語
		/// </summary>
		MI = 0x6D69,
		/// <summary>
		/// オクシタン語
		/// </summary>
		OC = 0x6F63,
		/// <summary>
		/// コルシカ語
		/// </summary>
		CO = 0x636F,
		/// <summary>
		/// キニヤルワンダ語
		/// </summary>
		RW = 0x7277,
		/// <summary>
		/// ウォロフ語
		/// </summary>
		WO = 0x776F,
		/// <summary>
		/// スコットランド ゲール語
		/// </summary>
		GD = 0x6764,
		/// <summary>
		/// 中国語
		/// </summary>
		ZH = 0x7A68,
		/// <summary>
		/// ノルウェー語 (ニーノシュク)
		/// </summary>
		NN = 0x6E6E,
		/// <summary>
		/// ボスニア語
		/// </summary>
		BS = 0x6273,
		/// <summary>
		/// ノルウェー語 (ブークモール)
		/// </summary>
		NB = 0x6E62,
		/// <summary>
		/// セルビア語
		/// </summary>
		SR = 0x7372,

		/// <summary>
		/// 不明
		/// </summary>
		XX = 0xFFFF,
	}
}
