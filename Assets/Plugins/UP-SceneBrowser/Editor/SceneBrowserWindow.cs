namespace TF.SceneBrowser.Editor
{
	using System.Collections.Generic;
	using System.Linq;
	using UnityEditor;
	using UnityEditor.SceneManagement;
	using UnityEngine;

	internal class SceneBrowserWindow : EditorWindow
	{
		private const int MEDIUM_BUTTON_WIDTH = 100;
		private const int SMALL_BUTTON_WIDTH = 80;
		private const int SPACING_PX_BUTTONS = 3;

		[SerializeField]
		private SceneData[] _projectScenes = null;

		[SerializeField]
		private Vector2 _scrollPosition = Vector2.zero;

		[MenuItem("Tools/Open SceneBrowser &b")]
		public static void OpenWindow()
		{
			var window = GetWindow<SceneBrowserWindow>();
			window.Show();
		}

		private void OnEnable()
		{
			this.titleContent = new GUIContent("Tartaros Scene Browser");

			if (_projectScenes == null || _projectScenes.Length == 0)
			{
				SetScenesAssets();
			}
		}

		protected void OnGUI()
		{
			GUILayout.Label("Scenes Browser", EditorStyles.boldLabel);

			GUIHelper.DrawSeparator();

			if (GUILayout.Button("Refresh"))
			{
				SetScenesAssets();
			}

			GUIHelper.DrawSeparator();

			_scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
			{
				DrawFavoritesScenes();

				DrawNotFavoritesScenes();
			}
			GUILayout.EndScrollView();
		}

		private void DrawNotFavoritesScenes()
		{
			DrawScenesContent(GetNotFavoritesScenes());
		}

		private void DrawFavoritesScenes()
		{
			SceneData[] favoritesScenes = GetOnlyFavoritesScenes();

			if (favoritesScenes.Length != 0)
			{
				DrawScenesContent(favoritesScenes);

				GUIHelper.DrawSeparator();
			}
		}

		private SceneData[] GetNotFavoritesScenes()
		{
			return _projectScenes.Where(x => Favorites.IsSceneFavorite(x) == false).ToArray();
		}

		private SceneData[] GetOnlyFavoritesScenes()
		{
			return _projectScenes.Where(x => Favorites.IsSceneFavorite(x) == true).ToArray();
		}

		private void DrawScenesContent(SceneData[] scenesToDraw)
		{
			foreach (SceneData scene in scenesToDraw)
			{
				DrawScene(scene);
			}
		}

		private void DrawScene(SceneData sceneAsset)
		{
			GUILayout.BeginHorizontal();
			{
				DrawFavoriteButton(sceneAsset);
				GUILayout.Label(sceneAsset.Name);
				DrawSelectButton(sceneAsset);
				DrawOpenButtons(sceneAsset);
			}
			GUILayout.EndHorizontal();
		}

		private static void DrawSelectButton(SceneData sceneAsset)
		{
			if (GUIHelper.DrawColoredButton("Select", Color.grey, GUILayout.Width(SMALL_BUTTON_WIDTH), GUILayout.ExpandWidth(false)))
			{
				Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(sceneAsset.Path);
			}
		}

		private void DrawFavoriteButton(SceneData sceneAsset)
		{
			Texture buttonTexture = Favorites.IsSceneFavorite(sceneAsset) ? SceneBrowserResources.GetFullStarTexture() : SceneBrowserResources.GetEmptyStarTexture();


			bool clickOnFavoriteButton = GUILayout.Button(new GUIContent(buttonTexture), GUILayout.Height(EditorGUIUtility.singleLineHeight), GUILayout.Width(EditorGUIUtility.singleLineHeight + 15));

			if (clickOnFavoriteButton == true)
			{
				Favorites.ToggleFavorite(sceneAsset);
			}
		}

		private void DrawOpenButtons(SceneData sceneAsset)
		{
			if (sceneAsset.IsLoaded == true)
			{
				bool shouldClose = GUIHelper.DrawColoredButton("Close", Color.red, GUILayout.Width(MEDIUM_BUTTON_WIDTH * 2 + SPACING_PX_BUTTONS), GUILayout.ExpandWidth(false));

				if (shouldClose)
				{
					sceneAsset.CloseScene();
				}
			}
			else
			{
				bool shouldOpenScene = GUILayout.Button("Open", GUILayout.Width(MEDIUM_BUTTON_WIDTH), GUILayout.ExpandWidth(false));

				if (shouldOpenScene)
				{
					sceneAsset.OpenScene(OpenSceneMode.Single);
				}
				else
				{


					bool additiveOpen = GUILayout.Button("Additive Open", GUILayout.Width(MEDIUM_BUTTON_WIDTH), GUILayout.ExpandWidth(false));

					if (additiveOpen)
					{
						sceneAsset.OpenScene(OpenSceneMode.Additive);
					}
				}
			}
		}

		private void SetScenesAssets()
		{
			_projectScenes = Utils.GetAllSceneDatas();
		}
	}
}