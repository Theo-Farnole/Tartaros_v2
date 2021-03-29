namespace TF.SceneBrowser.Editor
{
	using System.IO;
	using System.Linq;
	using UnityEditor;

	internal static class Utils
	{
		public static SceneData[] GetAllSceneDatas()
		{
			return GetPathOfScenesAssets()
				.Select(path => new SceneData(path))
				.ToArray();
		}

		private static string[] GetPathOfScenesAssets()
		{
			return AssetDatabase.FindAssets(string.Format("t:Scene"))
				.Select(guid => AssetDatabase.GUIDToAssetPath(guid))
				.ToArray();
		}

		public static string GetFileNameWithoutExtension(string path) => Path.GetFileNameWithoutExtension(path);
	}
}
