using System;
using System.Linq;
using System.Collections.Generic;
using Mobcast.Coffee.Api;

namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// API関連定数定義クラス
	/// </summary>
	public sealed class ApiConstants
	{
		/// <summary>
		/// デフォルトタイムアウト(sec)
		/// </summary>
		public const float DEFAULT_TIMEOUT = 10.0f;

		/// <summary>
		/// [ヘッダーKey]タイムゾーンコード 
		/// </summary>
		public const string HEADER_KEY_TIME_ZONE_CODE = "time-zone-code";

		/// <summary>
		/// [ヘッダーKey]言語コード 
		/// </summary>
		public const string HEADER_KEY_LANGUAGE_CODE = "language-code";

		/// <summary>
		/// [ヘッダーKey]プラットフォームコード
		/// </summary>
		public const string HEADER_KEY_PLATFORM = "platform";

		/// <summary>
		/// [ヘッダーKey]ユニークユーザーID
		/// </summary>
		public const string HEADER_KEY_UID = "uid";

		/// <summary>
		/// [ヘッダーKEY]パケットシリアライズプロトコル
		/// </summary>
		public const string HEADER_KEY_PACKET_PROTOCOL = "packet-protocol";

		/// <summary>
		/// [ヘッダーKey]アプリID
		/// </summary>
		public const string HEADER_KEY_APP_ID = "app-id";

		/// <summary>
		/// [ヘッダーKey]アプリのバージョン
		/// </summary>
		public const string HEADER_KEY_APP_VERSION = "app-version";

		/// <summary>
		/// [ヘッダーKey]マスタデータのバージョン
		/// </summary>
		public const string HEADER_KEY_MASTER_DATA_VERSION = "master-data-version";

		/// <summary>
		/// [ヘッダーKey]リソースのバージョン
		/// </summary>
		public const string HEADER_KEY_RESOURCE_VERSION = "resource-version";

		/// <summary>
		/// [ヘッダーKey]コンテンツタイプ.
		/// </summary>
		public const string HEADER_KEY_CONTENT_TYPE = "Content-Type";

		/// <summary>
		/// [ヘッダーKey]暗号化
		/// </summary>
		public const string HEADER_KEY_PACKET_ENCRYPT = "packet-encrypt";

		/// <summary>
		/// [ヘッダーKey]プレイヤーID
		/// </summary>
		public const string HEADER_KEY_PLAYER_ID = "player-id";

		/// <summary>
		/// [ヘッダーKey]ユーザートークン
		/// </summary>
		public const string HEADER_KEY_USER_TOKEN = "user-token";

		/// <summary>
		/// [ヘッダーKey]SessionID
		/// </summary>
		public const string HEADER_KEY_SESSION_ID = "session-id";

		/// <summary>
		/// [ヘッダーKey]Token
		/// </summary>
		public const string HEADER_KEY_TOKEN = "token";

		/// <summary>
		/// [ヘッダーKey][Debug]強制エラーフラグ(true/false)
		/// </summary>
		public const string HEADER_KEY_DEBUG_ERROR_CODE = "debug-error-code";

		/// <summary>
		/// [ヘッダーKey][Debug]レスポンス遅延
		/// </summary>
		public const string HEADER_KEY_DEBUG_RESPONSE_DELAY = "debug-response-delay";

		//-------- packet protcol --------
		/// <summary>
		/// APIパケットシリアライズプロトコル名：json
		/// </summary>
		public const string	PROTOCOL_NAME_JSON		= "json";

		/// <summary>
		/// APIパケットシリアライズプロトコル名：msg-pack
		/// </summary>
		public const string	PROTOCOL_NAME_MSG_PACK	= "msg-pack";

		/// <summary>
		/// [ヘッダーKey]コンテンツタイプ(bytes).
		/// </summary>
		public const string CONTENT_TYPE_BYTES = "application/octet-stream";

		/// <summary>
		/// [ヘッダーKey]コンテンツタイプ(text).
		/// </summary>
		public const string CONTENT_TYPE_TEXT = "text/plain";

		/// <summary>
		/// [ヘッダーKey]コンテンツタイプ(json).
		/// </summary>
		public const string CONTENT_TYPE_JSON = "application/json;charset=UTF-8";

		//-------- packet encrypt --------
		/// <summary>
		/// 暗号化OFF
		/// </summary>
		public const string ENCRYPT_OFF			= "off";

		/// <summary>
		/// /暗号化ON
		/// </summary>
		public const string ENCRYPT_ON			= "on";
	}
}
