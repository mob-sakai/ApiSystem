using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobcast.Coffee.Api;

namespace Mobcast.Coffee.Api
{
	public static class CodeConvertion
	{
		/// <summary>
		/// PacketEncrypt名 -> PacketEncryptCode変換マップ.
		/// </summary>
		public static readonly Dictionary<string, PacketEncryptCode> PacketEncryptCodeMap = new Dictionary<string, PacketEncryptCode>() {
			{ "on",	    PacketEncryptCode.ON },
			{ "off",	PacketEncryptCode.OFF }
		};

		/// <summary>
		/// PacketEncryptCode -> PacketEncrypt名変換マップ.
		/// </summary>
		public static readonly Dictionary<PacketEncryptCode, string> PacketEncryptNameMap = PacketEncryptCodeMap.ToDictionary(p=>p.Value,p=>p.Key);


		/// <summary>
		/// PacketProtocol名 -> PacketProtocolCode変換マップ.
		/// </summary>
		public static readonly Dictionary<string, PacketProtocolCode> PacketProtocolCodeMap = new Dictionary<string, PacketProtocolCode>() {
			{ "json",   	PacketProtocolCode.JSON },
			{ "msg-pack",	PacketProtocolCode.MSG_PACK }
		};

		/// <summary>
		/// PacketProtocolCode -> PacketProtocol名変換マップ.
		/// </summary>
		public static readonly Dictionary<PacketProtocolCode,string> PacketProtocolNameMap = PacketProtocolCodeMap.ToDictionary(p=>p.Value,p=>p.Key);


		/// <summary>
		/// PacketProtocol名 -> PacketProtocolCode変換マップ.
		/// </summary>
		public static readonly Dictionary<string, ContentTypeCode> ContentTypeCodeMap = new Dictionary<string, ContentTypeCode>() {
			{ "application/json;charset=UTF-8",     ContentTypeCode.JSON_UTF8 },
			{ "application/octet-stream",   	    ContentTypeCode.OCTET_STREAM },
		};
		
		/// <summary>
		/// PacketProtocolCode -> PacketProtocol名変換マップ.
		/// </summary>
		public static readonly Dictionary<ContentTypeCode,string> ContentTypeNameMap = ContentTypeCodeMap.ToDictionary(p=>p.Value,p=>p.Key);


		/// <summary>
		/// TimeZone名 -> TimeZoneCode変換マップ.
		/// </summary>
		public static readonly Dictionary<string, TimeZoneCode> timeZoneCodeMap = Enum.GetValues(typeof(TimeZoneCode))
				.Cast<TimeZoneCode>()
				.ToDictionary(x => x.ToString());
		
		/// <summary>
		/// TimeZoneCode -> TimeZone名変換マップ.
		/// </summary>
		public static readonly Dictionary<TimeZoneCode, string> timeZoneNameMap = timeZoneCodeMap.ToDictionary(p=>p.Value,p=>p.Key);

		/// <summary>
		/// Language名 -> LanguageCode変換マップ.
		/// </summary>
		public static readonly Dictionary<string, LanguageCode> languageCodeMap = Enum.GetValues(typeof(LanguageCode))
				.Cast<LanguageCode>()
				.ToDictionary(x => x.ToString().ToLower());

		/// <summary>
		/// LanguageCode -> Language名変換マップ.
		/// </summary>
		public static readonly Dictionary<LanguageCode, string> languageNameMap = languageCodeMap.ToDictionary(p=>p.Value,p=>p.Key);

		/// <summary>
		/// PlatformCode -> Platform名変換マップ.
		/// </summary>
		public static Dictionary<PlatformCode, string> platformNameMap = new Dictionary<PlatformCode, string>() {
			{ PlatformCode.INVALID,	"INVALID" },
			{ PlatformCode.IPHONE,	"iPhone" },
			{ PlatformCode.ANDROID,	"Android" },
			{ PlatformCode.UNKNOWN,	"Unknown" }
		};

		/// <summary>
		/// TimeZoneCode -> TimeZoneInfo変換マップ.
		/// </summary>
		public static Dictionary<TimeZoneCode, TimeZoneInfo> timeZoneInfoMap = new Dictionary<TimeZoneCode, TimeZoneInfo>() {
			{ TimeZoneCode.GMT,	TimeZoneInfo.CreateCustomTimeZone("GMT", new TimeSpan(0, 0, 0), "GMT Standard Time", "GMT") },
			{ TimeZoneCode.UTC,	TimeZoneInfo.CreateCustomTimeZone("UTC", new TimeSpan(0, 0, 0), "UTC", "UTC") },
			{ TimeZoneCode.CET,	TimeZoneInfo.CreateCustomTimeZone("CET", new TimeSpan(1, 0, 0), "(UTC+1:00) W. Europe Standard Time", "CET") },
			{ TimeZoneCode.EET,	TimeZoneInfo.CreateCustomTimeZone("EET", new TimeSpan(2, 0, 0), "(UTC+2:00) E. Europe Standard Time", "EET") },
			{ TimeZoneCode.ART,	TimeZoneInfo.CreateCustomTimeZone("ART", new TimeSpan(2, 0, 0), "(UTC+2:00) Egypt Standard Time", "ART") },
			{ TimeZoneCode.EAT,	TimeZoneInfo.CreateCustomTimeZone("EAT", new TimeSpan(3, 0, 0), "(UTC+3:00) E. Africa Standard Time", "EAT") },
			{ TimeZoneCode.MET,	TimeZoneInfo.CreateCustomTimeZone("MET", new TimeSpan(3, 30, 0), "(UTC+3:30) Iran Standard Time", "MET") },
			{ TimeZoneCode.NET,	TimeZoneInfo.CreateCustomTimeZone("NET", new TimeSpan(4, 0, 0), "(UTC+4:00) Arabian Standard Time", "NET") },
			{ TimeZoneCode.PLT,	TimeZoneInfo.CreateCustomTimeZone("PLT", new TimeSpan(5, 0, 0), "(UTC+5:00) Pakistan Standard Time", "PLT") },
			{ TimeZoneCode.IST,	TimeZoneInfo.CreateCustomTimeZone("IST", new TimeSpan(5, 30, 0), "(UTC+5:30) India Standard Time", "IST") },
			{ TimeZoneCode.BST,	TimeZoneInfo.CreateCustomTimeZone("BST", new TimeSpan(6, 0, 0), "(UTC+6:00) Bangladesh Standard Time", "BST") },
			{ TimeZoneCode.VST,	TimeZoneInfo.CreateCustomTimeZone("VST", new TimeSpan(7, 0, 0), "(UTC+7:00) SE Asia Standard Time", "VST") },
			{ TimeZoneCode.CTT,	TimeZoneInfo.CreateCustomTimeZone("CTT", new TimeSpan(8, 0, 0), "(UTC+8:00) China Standard Time", "CTT") },
			{ TimeZoneCode.JST,	TimeZoneInfo.CreateCustomTimeZone("JST", new TimeSpan(9, 0, 0), "(UTC+9:00) Tokyo Standard Time", "JST") },
			{ TimeZoneCode.ACT,	TimeZoneInfo.CreateCustomTimeZone("ACT", new TimeSpan(9, 30, 0), "(UTC+9:30) AUS Central Standard Time", "ACT") },
			{ TimeZoneCode.AET,	TimeZoneInfo.CreateCustomTimeZone("AET", new TimeSpan(10, 0, 0), "(UTC+10:00) AUS Eastern Standard Time", "AET") },
			{ TimeZoneCode.SST,	TimeZoneInfo.CreateCustomTimeZone("SST", new TimeSpan(11, 0, 0), "(UTC+11:00) Central Pacific Standard Time",	"SST") },
			{ TimeZoneCode.NST,	TimeZoneInfo.CreateCustomTimeZone("NST", new TimeSpan(12, 0, 0), "(UTC+12:00) New Zealand Standard Time", "NST") },
			{ TimeZoneCode.MIT,	TimeZoneInfo.CreateCustomTimeZone("MIT", new TimeSpan(-11, 0, 0), "(UTC-11:00) UTC-11", "MIT") },
			{ TimeZoneCode.HST,	TimeZoneInfo.CreateCustomTimeZone("HST", new TimeSpan(-10, 0, 0), "(UTC-10:00) Hawaiian Standard Time", "HST") },
			{ TimeZoneCode.AST,	TimeZoneInfo.CreateCustomTimeZone("AST", new TimeSpan(-9, 0, 0), "(UTC-9:00) Alaskan Standard Time", "AST") },
			{ TimeZoneCode.PST,	TimeZoneInfo.CreateCustomTimeZone("PST", new TimeSpan(-8, 0, 0), "(UTC-8:00) Pacific Standard Time", "PST") },
			{ TimeZoneCode.PNT,	TimeZoneInfo.CreateCustomTimeZone("PNT", new TimeSpan(-7, 0, 0), "(UTC-7:00) US Mountain Standard Time", "PNT") },
			{ TimeZoneCode.MST,	TimeZoneInfo.CreateCustomTimeZone("MST", new TimeSpan(-7, 0, 0), "(UTC-7:00) Mountain Standard Time", "MST") },
			{ TimeZoneCode.CST,	TimeZoneInfo.CreateCustomTimeZone("CST", new TimeSpan(-6, 0, 0), "(UTC-6:00) Central Standard Time", "CST") },
			{ TimeZoneCode.EST,	TimeZoneInfo.CreateCustomTimeZone("EST", new TimeSpan(-5, 0, 0), "(UTC-5:00) Eastern Standard Time", "EST") },
			{ TimeZoneCode.IET,	TimeZoneInfo.CreateCustomTimeZone("IET", new TimeSpan(-5, 0, 0), "(UTC-5:00) US Eastern Standard Time", "IET") },
			{ TimeZoneCode.PRT,	TimeZoneInfo.CreateCustomTimeZone("PRT", new TimeSpan(-4, 0, 0), "(UTC-4:00) Atlantic Standard Time", "PRT") },
			{ TimeZoneCode.CNT,	TimeZoneInfo.CreateCustomTimeZone("CNT", new TimeSpan(-3, 30, 0), "(UTC-3:30) Newfoundland Standard Time", "CNT") },
			{ TimeZoneCode.AGT,	TimeZoneInfo.CreateCustomTimeZone("AGT", new TimeSpan(-3, 0, 0), "(UTC-3:00) Argentina Standard Time", "AGT") },
			{ TimeZoneCode.BET,	TimeZoneInfo.CreateCustomTimeZone("BET", new TimeSpan(-3, 0, 0), "(UTC-3:00) E. South America Standard Time",	"BET") },
			{ TimeZoneCode.CAT, TimeZoneInfo.CreateCustomTimeZone("CAT", new TimeSpan(1, 0, 0), "(UTC-1:00) Cape Verde Standard Time", "CAT") },
		};
	}
}
