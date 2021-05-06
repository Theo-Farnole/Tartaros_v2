namespace TF.SceneBrowser.Editor
{
	using UnityEditor;
	using UnityEngine;

	internal static class SceneBrowserResources
	{
		private const string FILENAME_STAR_EMPTY = "Star_Empty";
		private const string FILENAME_STAR_FULL = "Star_Full";

		public static Texture GetFullStarTexture()
		{
			return Resources.Load<Texture>(FILENAME_STAR_FULL);
		}

		public static Texture GetEmptyStarTexture()
		{
			return Resources.Load<Texture>(FILENAME_STAR_EMPTY);
		}

		public static Texture GetWindowIcon()
		{
			// SOURCE: https://github.com/halak/unity-editor-icons
			return EditorGUIUtility.IconContent("Favorite").image;
		}
	}
}
