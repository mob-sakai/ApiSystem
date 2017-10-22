using UnityEngine;
using UnityEditor;
using System;
using MsgPack.Serialization;
using System.IO;

namespace MsgPack.Editor
{
	public class MsgPackViewer : EditorWindow
	{
		[MenuItem ("MsgPack/MsgPack Viewer")]
		static void OpenFromMenu ()
		{
			GetWindow<MsgPackViewer> ();
		}


		static readonly string kPrefsKey = typeof(MsgPackViewer).Name + "_FilePath";

		public Type targetType;
		string targetTypeQualifiedName;

		bool autoConvert = true;
		string json = "";
		string error = "";
		byte[] bytes = new byte[0];
		string msgpackBinary = "";
		string msgpackJson = "";
		Vector2 scrollPosition;
		SerializationContext serializationContext = new SerializationContext ();

		MessagePackSerializer serializer { get { return MessagePackSerializer.Get (targetType, serializationContext); } }

		void OnEnable ()
		{
			titleContent.text = "MsgPack Viewer";
			if (!string.IsNullOrEmpty (targetTypeQualifiedName)) {
				targetType = Type.GetType (targetTypeQualifiedName);
			}
		}

		void OnTypeChanged (Type type)
		{
			error = "";
			try {
				targetType = type;
				targetTypeQualifiedName = type.AssemblyQualifiedName;
				OnJsonChanged (JsonUtility.ToJson (JsonUtility.FromJson ("{}", type), true), autoConvert);
			} catch (Exception ex) {
				error = ex.Message;
			}

			EditorApplication.delayCall += () => GUIUtility.keyboardControl = 0;
		}

		void OnMessagePackChanged (byte[] msgPack, bool convertToJson)
		{
			error = "";
			try {
				bytes = msgPack;
				msgpackBinary = BitConverter.ToString (bytes).Replace ("-", " ");
				msgpackJson = MessagePackSerializer.UnpackMessagePackObject (bytes).ToString ();

				if (convertToJson)
					json = JsonUtility.ToJson (serializer.UnpackSingleObject (bytes), true);
			} catch (Exception ex) {
				error = ex.Message;
			}
		}

		void OnJsonChanged (string newjson, bool convertToMessagePack)
		{
			error = "";
			try {
				json = newjson;
				if (convertToMessagePack)
					OnMessagePackChanged (serializer.PackSingleObject (JsonUtility.FromJson (json, targetType)), false);
			} catch (Exception ex) {
				error = ex.Message;
			}
		}

		void OnGUI ()
		{
			EditorGUI.BeginChangeCheck ();

			// Target type to serialize.
			using (new EditorGUILayout.HorizontalScope ()) {
				EditorGUILayout.LabelField ("Target Type", EditorStyles.boldLabel, GUILayout.Width (120));

				// Type popup.
				if (GUILayout.Button (targetType != null ? targetType.Name : "", EditorStyles.popup)) {
					var gm = new GenericMenu ();

					foreach (var type in MsgPackGenerateSerializer.CollectSerializableTypes ()) {
						gm.AddItem (new GUIContent (type.Name), type == targetType, x => OnTypeChanged ((Type)x), type);
					}

					gm.ShowAsContext ();
				}
			}

			// Serialization Method.
			using (new EditorGUILayout.HorizontalScope ()) {
				EditorGUILayout.LabelField ("Serialization Method", EditorStyles.boldLabel, GUILayout.Width (120));
				serializationContext.SerializationMethod = (SerializationMethod)EditorGUILayout.EnumPopup (serializationContext.SerializationMethod);
			}

			scrollPosition = EditorGUILayout.BeginScrollView (scrollPosition, GUILayout.ExpandWidth (false));

			// Json
			using (new EditorGUILayout.VerticalScope (EditorStyles.helpBox)) {
				using (new EditorGUILayout.HorizontalScope ()) {
					EditorGUILayout.LabelField ("Json", EditorStyles.boldLabel, GUILayout.Width (100));
					GUILayout.FlexibleSpace ();

					// Auto-Convert: When json changed, convert it to MsgPack automatically.
					autoConvert = GUILayout.Toggle (autoConvert, "Convert to MsgPack automatically");

					// Reset Object: Reset the object based on [SerializeField]. 
					using (new EditorGUI.DisabledGroupScope (targetType == null)) {
						if (GUILayout.Button ("Reset Object", EditorStyles.miniButton)) {
							OnTypeChanged (targetType);
						}
					}
				}

				// Json text.
				json = GUILayout.TextArea (json);

				// Auto-Convert.
				if (EditorGUI.EndChangeCheck ()) {
					OnJsonChanged (json, autoConvert);
				}
			}

			// Converter.
			using (new EditorGUI.DisabledGroupScope (targetType == null)) {
				using (new EditorGUILayout.HorizontalScope ()) {
					GUILayout.FlexibleSpace ();

					// To MsgPack
					if (GUILayout.Button ("v", EditorStyles.miniButtonLeft, GUILayout.Width (50))) {
						Debug.LogFormat ("Convert to MessagePack");
						OnJsonChanged (json, true);
					}

					// To Json
					if (GUILayout.Button ("^", EditorStyles.miniButtonRight, GUILayout.Width (50))) {
						Debug.LogFormat ("Convert to Json");
						OnMessagePackChanged (bytes, true);
					}
					GUILayout.FlexibleSpace ();
				}
			}

			// MessagePack
			using (new EditorGUILayout.VerticalScope (EditorStyles.helpBox)) {
				using (new EditorGUILayout.HorizontalScope ()) {
					EditorGUILayout.LabelField ("MessagePack", EditorStyles.boldLabel, GUILayout.Width (100));
					GUILayout.FlexibleSpace ();

					// Load File
					if (GUILayout.Button ("Load File", EditorStyles.miniButtonLeft)) {
						var path = PlayerPrefs.GetString (kPrefsKey, "");
						if (!File.Exists (path)) {
							path = "";
						}

						path = EditorUtility.OpenFilePanel ("Load MessagePack binary", path, "");
						if (!string.IsNullOrEmpty (path)) {
							PlayerPrefs.SetString (kPrefsKey, path);
							bytes = File.ReadAllBytes (path);
							Debug.LogFormat ("Load MessagePack binary from {0}. filesize = {1}", path, bytes.Length);
							OnMessagePackChanged (bytes, false);
						}
					}

					// Save As...
					using (new EditorGUI.DisabledGroupScope (targetType == null || bytes.Length == 0)) {
						if (GUILayout.Button ("Save As...", EditorStyles.miniButtonRight)) {
							var path = PlayerPrefs.GetString (kPrefsKey, "");
							path = File.Exists (path) ? Path.GetDirectoryName (path) : "";

							path = EditorUtility.SaveFilePanel ("Save MessagePack binary", path, "MsgPack_" + targetType.Name + ".bytes", "");
							if (!string.IsNullOrEmpty (path)) {
								Debug.LogFormat ("Save MessagePack binary to {0}. filesize = {1}", path, bytes.Length);
								PlayerPrefs.SetString (kPrefsKey, path);
								File.WriteAllBytes (path, bytes);
							}
						}
					}
				}
				GUILayout.TextArea (msgpackBinary, EditorStyles.helpBox);
				GUILayout.TextArea (msgpackJson, EditorStyles.helpBox);
			}

			if (!string.IsNullOrEmpty (error)) {
				EditorGUILayout.HelpBox (error, MessageType.Error);
			}

			EditorGUILayout.EndScrollView ();

		}

	}
}