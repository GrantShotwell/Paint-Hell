using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Text.RegularExpressions;

#if UNITY_EDITOR
using UnityEditor;

namespace SaveManager.Editors {

	[CustomEditor(typeof(SaveLocation))]
	public class SaveLocationEditor : Editor {

		private static Regex fileRegex = new Regex(@"^[^.?%*:|""<>]+$");
		private static Regex extensionRegex = new Regex(@"^[^.?%*:|""<>]*$");

		SerializedProperty folder;
		SerializedProperty extension;

		void OnEnable() {
			folder = serializedObject.FindProperty("folder");
			extension = serializedObject.FindProperty("extension");
		}

		public override void OnInspectorGUI() {

			serializedObject.Update();

			EditorGUILayout.PropertyField(folder);
			EditorGUILayout.PropertyField(extension);

			serializedObject.ApplyModifiedProperties();

			string _folder = folder.stringValue;
			if(_folder.Length >= 2 && _folder[1] == ':') {
				EditorGUILayout.HelpBox("This should be the name of a folder within the user's AppData, so it cannot start with a drive specifier.", MessageType.Error);
			} else if(_folder.Length == 0 || !fileRegex.IsMatch(_folder)) {
				EditorGUILayout.HelpBox("This directory name is invalid.", MessageType.Error);
			}

			string _extension = extension.stringValue;
			if(_extension.Length == 0 || !extensionRegex.IsMatch(_extension)) {
				EditorGUILayout.HelpBox("This is not a valid extension name.", MessageType.Error);
			}

		}
	}

}

#endif

namespace SaveManager {

	/// <summary>
	/// Represents a location, by name, for objects to be saved and loaded to disk, by name.
	/// </summary>
	[CreateAssetMenu(fileName = "MyUnityGame Save Location", menuName = "Save Manager/Save Location")]
	public class SaveLocation : ScriptableObject {

		/// <summary>
		/// The folder inside of <see cref="Application.persistentDataPath"/> that all object files are saved to.
		/// </summary>
		[Tooltip("The directory name inside of the persistent data path that all object files are saved to.")]
		public string folder = "MyUnityGame";

		/// <summary>
		/// The file extension to use when saving objects at this location.
		/// </summary>
		[Tooltip("The file entension to use when saving objects at this location.")]
		public string extension = "data";

		/// <summary>
		/// The <see cref="BinaryFormatter"/> used to serialize and deserialize <see cref="object"/>s.
		/// </summary>
		private readonly BinaryFormatter formatter = new BinaryFormatter();

		/// <summary>
		/// Saves the given <see cref="object"/> in a file called <paramref name="id"/> located in this <see cref="SaveLocation"/>.
		/// </summary>
		/// <param name="id">What this object is called.</param>
		/// <param name="obj">The <see cref="object"/> to serialize.</param>
		/// <seealso cref="LoadObject(string, out object)"/>
		public void SaveObject(string id, object obj) {

			string path = $"{Application.persistentDataPath}\\{folder}";
			if(!Directory.Exists(path)) Directory.CreateDirectory(path);
			path += $"\\{id}.{extension}";
			using FileStream stream = File.Exists(path) ? File.OpenWrite(path) : File.Create(path);
			formatter.Serialize(stream, obj);

		}

		/// <summary>
		/// Loads an <see cref="object"/> found by its <paramref name="id"/>.
		/// </summary>
		/// <param name="id">What the object is called.</param>
		/// <param name="obj">The <see cref="object"/> that has been deserialized.</param>
		/// <returns>Returns <see langword="true"/> if the file on this object exists.</returns>
		/// <seealso cref="SaveObject(string, object)"/>
		public bool LoadObject(string id, out object obj) {

			string path = $"{Application.persistentDataPath}\\{folder}\\{id}.{extension}";
			if(File.Exists(path)) {
				using FileStream stream = File.OpenRead(path);
				obj = formatter.Deserialize(stream);
				return true;
			} else {
				obj = null;
				return false;
			}

		}

		/// <summary>
		/// Loads an <see cref="object"/> found by its <paramref name="id"/> and casts the result as <typeparamref name="T"/>.
		/// If unsuccessful, does not change <paramref name="obj"/>.
		/// </summary>
		/// <param name="id">What the object is called.</param>
		/// <param name="obj">The <see cref="object"/> that has been deserialized.</param>
		/// <returns>Returns <see langword="true"/> if the file on this object exists.</returns>
		/// <seealso cref="SaveObject(string, object)"/>
		public bool LoadObject<T>(string id, ref T obj) {

			bool success = LoadObject(id, out object _obj);
			if(success) {
				obj = (T)_obj;
				return true;
			} else {
				return false;
			}

		}

	}

}
