namespace TF.SceneBrowser.Editor
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using UnityEditor;
	using UnityEngine;

	internal static class Favorites
	{
		private const string PREFS_FAVORITE_SCENE = "SceneBrowser_FavoriteScene";
		private const char SEPARATOR = ';';
		private static List<string> _favoritesScenesPath = null;

		private static List<string> FavoritesScenesPath
		{
			get
			{
				if (_favoritesScenesPath == null)
				{
					InitiliazeFavoriteScenesPath();
				}

				return _favoritesScenesPath;
			}
		}

		private static void SaveFavoritesScenes()
		{
			string joinedFavoritesScenesPaths = string.Join(SEPARATOR.ToString(), _favoritesScenesPath);
			EditorPrefs.SetString(PREFS_FAVORITE_SCENE, joinedFavoritesScenesPaths);
		}

		private static void InitiliazeFavoriteScenesPath()
		{
			if (EditorPrefs.HasKey(PREFS_FAVORITE_SCENE) == false)
			{
				Debug.LogWarning("Cannot retrives favorites preferences. They might been resetted");
			}

			string[] scenesPath = EditorPrefs.GetString(PREFS_FAVORITE_SCENE).Split(SEPARATOR);
			_favoritesScenesPath = new List<string>(scenesPath);
		}

		public static void FavoriteScene(SceneData sceneAsset)
		{
			if (IsSceneFavorite(sceneAsset) == true)
			{
				Debug.LogWarningFormat("Scene {0} is already favorite. Can't favorite it again.", sceneAsset.Name);
				return;
			}

			FavoritesScenesPath.Add(sceneAsset.Path);
			SaveFavoritesScenes();
		}

		public static void UnfavoriteScene(SceneData sceneAsset)
		{
			if (_favoritesScenesPath == null) InitiliazeFavoriteScenesPath();

			FavoritesScenesPath.Remove(sceneAsset.Path);
			SaveFavoritesScenes();
		}

		public static bool IsSceneFavorite(SceneData sceneAsset)
		{
			return FavoritesScenesPath.Contains(sceneAsset.Path);
		}

		public static void ToggleFavorite(SceneData sceneAsset)
		{
			if (IsSceneFavorite(sceneAsset) == true)
			{
				UnfavoriteScene(sceneAsset);
			}
			else
			{
				FavoriteScene(sceneAsset);
			}
		}
	}
}
