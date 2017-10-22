using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using MsgPack.Serialization;
using UnityEditor;

namespace MsgPack.Editor
{
	public static class MsgPackGenerateSerializer
	{
		const string kAssemblyName = "GeneratedMsgPackSerializer";
		const string kDllFileName = kAssemblyName + ".dll";
		const string kMdbFileName = kDllFileName + ".mdb";

		[MenuItem ("MsgPack/Generate Serializer/To Assembly")]
		public static void ToAssembly ()
		{
			Generate (true, SerializationMethod.Array);
		}

		[MenuItem ("MsgPack/Generate Serializer/To Source Code(Map)")]
		public static void ToSourceCodeMap ()
		{
			Generate (false, SerializationMethod.Map);
		}

		[MenuItem ("MsgPack/Generate Serializer/To Source Code(Array)")]
		public static void ToSourceCodeArray ()
		{
			Generate (false, SerializationMethod.Array);
		}

		/// <summary>
		/// Generate serializers.
		/// </summary>
		public static void Generate (bool assembly, SerializationMethod method = SerializationMethod.Array)
		{
			// Collect types to generate serializer.
			var types = CollectSerializableTypes ();

			// Output directory.
			var output = AssetDatabase.FindAssets (kAssemblyName)
			.Select (x => AssetDatabase.GUIDToAssetPath (x))
			.FirstOrDefault ();

			if (output != null && (File.Exists (output) || Directory.Exists (output)))
				output = Path.GetDirectoryName (output);
			else
				output = "Assets";

			// Generate
			var sb = new StringBuilder ();
			sb.AppendFormat ("## Generate MsgPackSerializer for following types to {0}.\n", Path.Combine (output, kAssemblyName));
			UnityEngine.Debug.Log (types.Aggregate (sb, (a, b) => a.AppendFormat ("  > {0}\n", b.Name)));

			if (assembly) {
				// Generate to assembly.
				SerializerGenerator.GenerateAssembly (
				
					new SerializerAssemblyGenerationConfiguration () {
						OutputDirectory = output,
						AssemblyName = new AssemblyName (kAssemblyName),
						EnumSerializationMethod = EnumSerializationMethod.ByUnderlyingValue,
						Namespace = kAssemblyName,
					},
					types
				);

				// Delete mdb file.
				var mdb = Path.Combine (output, kMdbFileName);
				if (File.Exists (mdb))
					File.Delete (mdb);
			} else {
				// Generate to source codes.
				SerializerGenerator.GenerateSerializerSourceCodes (
					new SerializerCodeGenerationConfiguration () {
						OutputDirectory = output,
						Namespace = kAssemblyName,
						SerializationMethod = method,
						EnumSerializationMethod = EnumSerializationMethod.ByUnderlyingValue,
					},
					types
				);
			}
			AssetDatabase.Refresh ();
		}

		public static Type[] CollectSerializableTypes ()
		{
			return Assembly.LoadFrom ("Library/ScriptAssemblies/Assembly-CSharp.dll").GetTypes ()
			.Where (type =>
				type.IsPublic
			&& !type.IsAbstract
			&& !type.IsInterface
			&& type.GetMembers (BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
					.Any (m => m.GetCustomAttributes (typeof(MessagePackMemberAttribute), true).Length != 0)
			)
			.ToArray ();
		}
	}
}