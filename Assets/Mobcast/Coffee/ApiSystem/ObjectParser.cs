using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using MsgPack.Serialization;

namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// ResponsePacketパーサー
	/// </summary>
	/// <typeparam name="T">デシリアライズするレスポンスパケットクラス</typeparam>
	public static class ObjectParser
	{
		/// <summary>
		/// AES用暗号・復号化オブジェクト(Rijndael:ラインダールアルゴリズム)を返します.
		/// </summary>
		static RijndaelManaged mob {
			get {
				if (_mob == null) {
					_mob = new RijndaelManaged ();
					_mob.BlockSize = 128;
					_mob.KeySize = 128;
					_mob.Padding = PaddingMode.ISO10126;
					_mob.Mode = CipherMode.CBC;
				}
				return _mob;
			}	
		}

		static RijndaelManaged _mob;

		/// <summary>
		/// バイト配列を暗号化します.
		/// </summary>
		public static byte[] Encrypt (byte[] data, string key, string iv)
		{
			using (var memoryStream = new MemoryStream ()) {
				mob.Key = Encoding.UTF8.GetBytes (key);
				mob.IV = Encoding.UTF8.GetBytes (iv);
				using (ICryptoTransform encryptor = mob.CreateEncryptor ()) {
					var cryptStream = new CryptoStream (memoryStream, encryptor, CryptoStreamMode.Write);

					cryptStream.Write (data, 0, data.Length);
					cryptStream.FlushFinalBlock ();
				}
				return memoryStream.ToArray ();
			}
		}

		/// <summary>
		/// バイト配列を復号化します.
		/// </summary>
		/// <param name="data">復号化対象データ</param>
		public static byte[] Decrypt (byte[] data, string key, string iv)
		{
			var decryptData = new byte[data.Length];
			using (var memoryStream = new MemoryStream (data)) {
				mob.Key = Encoding.UTF8.GetBytes (key);
				mob.IV = Encoding.UTF8.GetBytes (iv);
				using (ICryptoTransform decryptor = mob.CreateDecryptor ()) {
					var cryptStream = new CryptoStream (memoryStream, decryptor, CryptoStreamMode.Read);
					cryptStream.Read (decryptData, 0, decryptData.Length);
				}
			}

			return decryptData;
		}

		/// <summary>
		/// 指定オブジェクトをシリアライズし、バイト配列に変換します.
		/// ApiHeaderは変換に必要な情報(パケットプロトコルタイプ、暗号化の有無)が格納されています.
		/// </summary>
		/// <param name="data">APIレスポンスデータ</param>
		public static byte[] SerializeToJson<T> (T data)
		{
			return Encoding.UTF8.GetBytes (JsonUtility.ToJson(data));
		}

		/// <summary>
		/// 指定オブジェクトをシリアライズし、バイト配列に変換します.
		/// ApiHeaderは変換に必要な情報(パケットプロトコルタイプ、暗号化の有無)が格納されています.
		/// </summary>
		/// <param name="data">APIレスポンスデータ</param>
		public static byte[] SerializeToMsgPack<T> (T data)
		{
			return MessagePackSerializer.Get<T> ().PackSingleObject(data);
		}

		/// <summary>
		/// バイト配列をデシリアライズし、ApiResponsePacketに変換します.
		/// ApiHeaderは変換に必要な情報(パケットプロトコルタイプ、暗号化の有無)が格納されています.
		/// デシリアライズ結果がエラー扱いの場合はApiException例外がスローされます.
		/// </summary>
		/// <param name="data">APIレスポンスデータ</param>
		/// <param name="header">レスポンスヘッダ</param>
		/// <returns>ResponsePacketオブジェクト</returns>
		public static T DeserializeFromJson<T> (byte[] data)
		{
			return JsonUtility.FromJson<T>(Encoding.UTF8.GetString (data));
		}

		/// <summary>
		/// バイト配列をデシリアライズし、ApiResponsePacketに変換します.
		/// ApiHeaderは変換に必要な情報(パケットプロトコルタイプ、暗号化の有無)が格納されています.
		/// デシリアライズ結果がエラー扱いの場合はApiException例外がスローされます.
		/// </summary>
		/// <param name="data">APIレスポンスデータ</param>
		/// <param name="header">レスポンスヘッダ</param>
		/// <returns>ResponsePacketオブジェクト</returns>
		public static T DeserializeFromMsgPack<T> (byte[] data)
		{
			return MessagePackSerializer.Get<T> ().UnpackSingleObject(data);
		}
	}
}