using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// パケットシリアライズ形式コード
	/// </summary>
	public enum PacketProtocolCode
	{
		/// <summary>
		/// 不正値
		/// </summary>
		INVALID		= -1,

		/// <summary>
		/// JSON形式
		/// </summary>
		JSON		= 0,

		/// <summary>
		/// message-pack形式
		/// </summary>
		MSG_PACK	= 1,
	}
}
