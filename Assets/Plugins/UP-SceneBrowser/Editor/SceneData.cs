namespace TF.SceneBrowser.Editor
{
	using System.Collections.Generic;
	using UnityEditor.SceneManagement;
	using UnityEngine;
	using UnityEngine.SceneManagement;

	[System.Serializable]
	public class SceneData
	{
		#region Fields
		[SerializeField]
		private string _name = null;

		[SerializeField]
		private string _path = null;
		#endregion Fields

		public string Name => _name;
		public string Path => _path;
		public bool IsLoaded => Scene.IsValid() && Scene.isLoaded;
		public Scene Scene => SceneManager.GetSceneByPath(_path);

		public SceneData(string sceneAssetPath)
		{
			_name = Utils.GetFileNameWithoutExtension(sceneAssetPath);
			_path = sceneAssetPath;
		}

		public void CloseScene()
		{
			EditorSceneManager.CloseScene(Scene, true);
		}

		public void OpenScene(OpenSceneMode openingMode)
		{
			EditorSceneManager.OpenScene(Path, openingMode);
		}

		public override bool Equals(object obj)
		{
			return obj is SceneData sceneData && sceneData.Path == _path && sceneData.Name == _name;
		}

		public override int GetHashCode()
		{
			int hashCode = -827305254;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_path);
			return hashCode;
		}
	}
}
