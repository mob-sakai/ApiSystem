using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// ライセンス(許諾)コード
/// </summary>
public enum eLicenseCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID			= -1,

	/// <summary>
	/// 未許諾
	/// </summary>
	NO_LICENSE		= 0,

	/// <summary>
	/// 許諾
	/// </summary>
	UNDER_LICENSE	= 1,
}
