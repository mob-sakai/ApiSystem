using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// ストック状態コード
/// </summary>
public enum eStockStatusCode
{
	/// <summary>
	/// 不正値
	/// </summary>
	INVALID		= -1,

	/// <summary>
	/// 空
	/// </summary>
	EMPTY		= 0,

	/// <summary>
	/// ストック中
	/// </summary>
	STAY		= 1,

	/// <summary>
	/// 移籍登録中
	/// </summary>
	ON_SALE		= 2,

	/// <summary>
	/// トレード中
	/// </summary>
	ON_TRADE	= 3,
}
