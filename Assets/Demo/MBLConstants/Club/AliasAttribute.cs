using System;
using System.Reflection;

/// <summary>
/// Alias attribute.
/// </summary>
/// <example>
/// <code>
/// enum TestEnum{
/// 	[Alias("AliasName1")]enumNameA,
/// 	enumNameB,
/// }
/// 
/// Debub.Log(TestEnum.enumNameA.Tostring());	// enumNameA.
/// Debub.Log(TestEnum.enumNameA.GetAlias());	// AliasName1.
/// Debub.Log(TestEnum.enumNameB.Tostring());	// enumNameB.
/// Debub.Log(TestEnum.enumNameB.GetAlias());	// enumNameB.
/// </code>
/// </example>
[AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public class AliasAttribute : Attribute
{
	public string alias { get; private set; }
	public AliasAttribute(string alias){this.alias = alias;}
	
}

public static class AliasAttributeExtention
{
	/// <summary>
	/// Gets the alias.
	/// </summary>
	public static string GetAlias(this Enum value){
		AliasAttribute[] attributes = (AliasAttribute[])value.GetType()
			.GetField(value.ToString())
			.GetCustomAttributes(typeof(AliasAttribute), false);
		return 0 < attributes.Length ? attributes[0].alias : value.ToString();
	}
}