using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// パケット暗号化形式コード
	/// </summary>
	public enum PacketEncryptCode
	{
		/// <summary>
		/// 不正値
		/// </summary>
		INVALID	= -1,

		/// <summary>
		/// 暗号化OFF
		/// </summary>
		OFF		= 0,

		/// <summary>
		/// 暗号化ON
		/// </summary>
		ON		= 1,
	}
}
