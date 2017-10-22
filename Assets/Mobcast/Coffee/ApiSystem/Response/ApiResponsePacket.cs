using System;
using MsgPack.Serialization;
using UnityEngine;
using Mobcast.Coffee.Api;
using System.Collections.Generic;

namespace Mobcast.Coffee.Api
{
	public interface IResponsePacket
	{
		/// <summary>
		/// デシリアライズに伴う処理を実行します.
		/// ResponsePacketContextを利用したタイムゾーンや言語の変換を追加できます.
		/// デシリアライズ結果がエラー扱いとしたい場合、APIExeption例外をスローするか、Info.codeを0以外に設定してください.
		/// </summary>
		/// <param name="header">Apiレスポンスヘッダ.</param>
		void OnAfterDeserialize (ApiResponseMeta header);
	}

	public static class IResponsePacketExtentions
	{
		/// <summary>
		/// デシリアライズに伴う処理を実行します.
		/// ResponsePacketContextを利用したタイムゾーンや言語の変換を追加できます.
		/// オブジェクト自体がnullである場合でも、例外を発生させません.
		/// </summary>
		/// <param name="self">処理対象パケット</param>
		/// <param name="header">パケットコンテキスト</param>
		public static T DeserializeOrDefault<T> (this T self, ApiResponseMeta header)
			where T : IResponsePacket
		{
			if (self == null)
				return default(T);
			self.OnAfterDeserialize (header);
			return self;
		}

		/// <summary>
		/// デシリアライズに伴う処理を実行します.
		/// ResponsePacketContextを利用したタイムゾーンや言語の変換を追加できます.
		/// オブジェクト自体がnullである場合でも、例外を発生させません.
		/// </summary>
		/// <param name="self">処理対象パケットリスト</param>
		/// <param name="header">パケットコンテキスト</param>
		public static List<T> DeserializeOrDefault<T> (this List<T> self, ApiResponseMeta header)
			where T : IResponsePacket
		{
			if (self == null)
				return default(List<T>);
			self.ForEach (x => x.DeserializeOrDefault (header));
			return self;
		}
	}

	/// <summary>
	/// APIレスポンスパケット
	/// </summary>
	[Serializable]
	public abstract class ApiResponsePacket : IResponsePacket
	{
		/// <summary>
		/// このクラスのプロパティのMessagePack-IDの開始ID
		/// </summary>
		private const int START_MSG_PACK_MEMBER_ID = 0;

		/// <summary>
		/// このクラスのプロパティ数
		/// </summary>
		private const int NUM_PROPERTY_ID = 1;

		/// <summary>
		/// サブクラスのプロパティのMessagePack-IDの開始ID
		/// </summary>
		public const int START_SUBCLASS_MSG_PACK_MEMBER_ID = START_MSG_PACK_MEMBER_ID + NUM_PROPERTY_ID;

		#region private properties

		/// <summary>
		/// APIレスポンス基本情報
		/// </summary>
		[SerializeField][MessagePackMember (START_MSG_PACK_MEMBER_ID + 0)]
		ApiResponseInfoEntity info = new ApiResponseInfoEntity ();

		#endregion

		#region public properties

		/// <summary>
		/// APIレスポンス基本情報
		/// </summary>
		public ApiResponseInfoEntity Info{ get{return info;} }

		#endregion

		/// <summary>
		/// デシリアライズに伴う処理を実行します.
		/// ResponsePacketContextを利用したタイムゾーンや言語の変換を追加できます.
		/// デシリアライズ結果がエラー扱いとしたい場合、APIExeption例外をスローするか、Info.codeを0以外に設定してください.
		/// </summary>
		/// <param name="header">Apiレスポンスヘッダ.</param>
		public virtual void OnAfterDeserialize (ApiResponseMeta header)
		{
			Info.DeserializeOrDefault (header);
		}
	}
}
