using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobcast.Coffee.Api
{
	/// <summary>
	/// コンテンツタイプコード
	/// </summary>
	public enum ContentTypeCode
	{
		/// <summary>
		/// 不正値
		/// </summary>
		INVALID = -1,

		/// <summary>
		/// application/json;charset=UTF-8
		/// </summary>
		JSON_UTF8=0,

		/// <summary>
		/// application/octet-stream
		/// </summary>
		OCTET_STREAM=1,
	}
}
