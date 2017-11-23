using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using System;
using MsgPack;

/// <summary>
/// Cacheable download handler.
/// </summary>
public abstract class DecryptableDownloadHandler : DownloadHandlerScript
{
	public MemoryStream outputStream { get; private set; }
	public StringBuilder outputStringBuilder { get; private set; }
	ICryptoTransform m_Decryptor;
	CryptoStream m_CryptoStream;

	internal DecryptableDownloadHandler(byte[] preallocateBuffer, string key, string iv, bool toText)
			: base(preallocateBuffer)
		{
		//this.m_WebRequest = www;
		outputStream = new MemoryStream(preallocateBuffer.Length);

		var aes = new RijndaelManaged();
		aes.BlockSize = 128;
		aes.KeySize = 128;
		aes.Padding = PaddingMode.ISO10126;
		aes.Mode = CipherMode.CBC;
		aes.Key = Encoding.UTF8.GetBytes(key);
		aes.IV = Encoding.UTF8.GetBytes(iv);
		m_Decryptor = aes.CreateDecryptor();
		m_CryptoStream = new CryptoStream(outputStream, m_Decryptor, CryptoStreamMode.Write);
	}

	protected override void ReceiveContentLength(int contentLength)
	{
		outputStream.SetLength(contentLength);
	}

	/// <summary>
	/// Callback, invoked when the data property is accessed.
	/// </summary>
	protected override byte[] GetData()
	{
		return outputStream.ToArray();
	}

	/// <summary>
	/// Callback, invoked as data is received from the remote server.
	/// </summary>
	protected override bool ReceiveData(byte[] data, int dataLength)
	{
		m_CryptoStream.Write(data, 0, dataLength);

		outputStream.Position = 0;
		outputStringBuilder.Append(Encoding.UTF8.GetString(outputStream.ToArray()));
		outputStream.SetLength(0);
		//m_Stream.Write(data, 0, dataLength);
		return true;
	}

	/// <summary>
	/// Callback, invoked when all data has been received from the remote server.
	/// </summary>
	protected override void CompleteContent()
	{
		m_CryptoStream.FlushFinalBlock();
		//isDone = true;
	}

	/// <summary>
	/// Signals that this [DownloadHandler] is no longer being used, and should clean up any resources it is using.
	/// </summary>
	public new void Dispose()
	{
		base.Dispose();

		if (m_CryptoStream != null)
		{
			m_CryptoStream.Dispose();
			m_CryptoStream = null;
		}
		if (outputStream != null)
		{
			outputStream.Dispose();
			outputStream = null;
		}
	}
}