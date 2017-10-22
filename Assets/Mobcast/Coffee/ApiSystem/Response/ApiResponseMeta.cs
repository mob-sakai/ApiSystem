using UnityEngine;
using System.Collections.Generic;
using Mobcast.Coffee.Api;

namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// APIメタデータ.
	/// API通信におけるメタデータを管理します.
	/// </summary>
	[System.Serializable]
	public class ApiResponseMeta
	{
		/// <summary>
		/// コンテンツタイプコード
		/// </summary>
		public ContentTypeCode contentTypeCode { get { return m_ContentTypeCode; } set { m_ContentTypeCode = value; } }

		[SerializeField] ContentTypeCode m_ContentTypeCode = ContentTypeCode.JSON_UTF8;

		/// <summary>
		/// 言語コード
		/// </summary>
		public LanguageCode languageCode { get { return m_LanguageCode; } set { m_LanguageCode = value; } }

		[SerializeField] LanguageCode m_LanguageCode = LanguageCode.EN;

		/// <summary>
		/// タイムゾーンコード
		/// </summary>
		public TimeZoneCode timeZoneCode { get { return m_TimeZoneCode; } set { m_TimeZoneCode = value; } }

		[SerializeField] TimeZoneCode m_TimeZoneCode = TimeZoneCode.UTC;

		/// <summary>
		/// パケット暗号化コード.
		/// </summary>
		public PacketEncryptCode packetEncryptCode { get { return m_PacketEncryptCode; } set { m_PacketEncryptCode = value; } }

		[SerializeField] PacketEncryptCode m_PacketEncryptCode = PacketEncryptCode.OFF;

		/// <summary>
		/// パケットプロトコルコード.
		/// </summary>
		public PacketProtocolCode packetProtocolCode { get { return m_PacketProtocolCode; } set { m_PacketProtocolCode = value; } }

		[SerializeField] PacketProtocolCode m_PacketProtocolCode = PacketProtocolCode.JSON;


		/// <summary>
		/// Dictionaryに変換します.
		/// </summary>
		public virtual void FromDictionary (Dictionary<string,string> headers)
		{
			string header;

			// コンテンツタイプコード
			ContentTypeCode contentTypeCode;
			if (headers.TryGetValue (ApiConstants.HEADER_KEY_CONTENT_TYPE, out header) && CodeConvertion.ContentTypeCodeMap.TryGetValue (header, out contentTypeCode))
			{
				this.contentTypeCode = contentTypeCode;
			}

			// パケット暗号化形式コード
			PacketEncryptCode packetEncryptCode;
			if (headers.TryGetValue (ApiConstants.HEADER_KEY_PACKET_ENCRYPT, out header) && CodeConvertion.PacketEncryptCodeMap.TryGetValue (header, out packetEncryptCode))
			{
				this.packetEncryptCode = packetEncryptCode;
			}

			// タイムゾーンコード
			TimeZoneCode timeZoneCode;
			if (headers.TryGetValue (ApiConstants.HEADER_KEY_TIME_ZONE_CODE, out header) && CodeConvertion.timeZoneCodeMap.TryGetValue (header, out timeZoneCode))
			{
				this.timeZoneCode = timeZoneCode;
			}

			// 言語コード
			LanguageCode languageCode;
			if (headers.TryGetValue (ApiConstants.HEADER_KEY_LANGUAGE_CODE, out header) && CodeConvertion.languageCodeMap.TryGetValue (header, out languageCode))
			{
				this.languageCode = languageCode;
			}

			// パケットプロトコルコード
			PacketProtocolCode packetProtocolCode;
			if (headers.TryGetValue (ApiConstants.HEADER_KEY_PACKET_PROTOCOL, out header) && CodeConvertion.PacketProtocolCodeMap.TryGetValue (header, out packetProtocolCode))
			{
				this.packetProtocolCode = packetProtocolCode;
			}
		}
	}
}