namespace Tartaros.Editor
{
	using System;
	using System.Linq;
	using UnityEditor;

	public static class AssetsDatabaseHelper
	{
		public static T[] FindAssets<T>() where T : UnityEngine.Object
		{
			string filter = string.Format("t:{0}", typeof(T).Name);

			return AssetDatabase.FindAssets(filter)
				.Select(guid => AssetDatabase.GUIDToAssetPath(guid))
				.Select(path => AssetDatabase.LoadAssetAtPath<T>(path))
				.ToArray();
		}

		public static T FindAsset<T>(string assetName) where T : UnityEngine.Object
		{
			// TODO TF: log warning if there is asset with the same name
			return FindAssets<T>()
				.Where(asset => asset.name == assetName)
				.FirstOrDefault();
		}
	}
}
