namespace Tartaros.Editor
{
	using System.Linq;
	using UnityEditor;
	using UnityEngine;

	public static class SetDirtySelected
	{
		[MenuItem("Tartaros/Dirty/selected objects")]
		public static void SetDirtSelected()
		{
			foreach (UnityEngine.Object obj in Selection.objects)
			{
				EditorUtility.SetDirty(obj);
			}

			AssetDatabase.SaveAssets();
		}

		[MenuItem("Tartaros/Dirty/databases")]
		public static void SetDirtyDatabases()
		{
			var scriptablesObjects = AssetDatabase.FindAssets("t:ScriptableObject", new string[] { "Assets/Databases" })
				.Select(guid => AssetDatabase.GUIDToAssetPath(guid))
				.Select(path => AssetDatabase.LoadAssetAtPath<ScriptableObject>(path))
				.ToArray();

			Debug.LogFormat("Starting set dirty... {0} elements to process", scriptablesObjects.Length);

			foreach (ScriptableObject scriptableObject in scriptablesObjects)
			{
				EditorUtility.SetDirty(scriptableObject);
			}

			AssetDatabase.SaveAssets();

			Debug.LogFormat("Set dirty done. {0} databases processed.", scriptablesObjects.Length);
		}
	}
}