using System;

namespace MsgPack.Serialization
{
	// Dummy MessagePackMemberAttribute.
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	public class MessagePackMemberAttribute : Attribute
	{
		public MessagePackMemberAttribute(int _) { }
	}
	
	public class MessagePackSerializer
	{
		public static MessagePackSerializer Get(Type t) { return null; }
		public byte[] PackSingleObject(object o) { return null; }
		public object UnpackSingleObject(byte[] b) { return null; }
		public static object UnpackMessagePackObject(byte[] b) { return null; }
	}
}