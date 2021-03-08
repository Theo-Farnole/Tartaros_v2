namespace Tartaros.MeshViewer
{
	using UnityEngine;

	internal class ModelPath
	{
		#region Fields
		public readonly string meshPath = null;
		public readonly TexturesPath texturesPath = null;
		#endregion Fields

		#region Ctor
		public ModelPath(string meshPath, TexturesPath texturesPath)
		{
			if (string.IsNullOrEmpty(meshPath))
			{
				Debug.LogWarning("Mesh path is empty.");
			}
			else
			{
				meshPath = PathCorrector.CorrectPath(meshPath);
			}

			this.meshPath = meshPath;
			this.texturesPath = texturesPath;
		}
		#endregion Ctor

		#region Methods
		public static ModelPath CreateFromFolder(string modelFolder)
		{
			string[] supportedExtensions = new string[] { "obj", "fbx" };

			string meshPath = FileHelper.GetFile(modelFolder, supportedExtensions);
			TexturesPath texturesPath = TexturesPath.CreateFromFolder(modelFolder);

			return new ModelPath(meshPath, texturesPath);
		}
		#endregion Methods
	}
}
