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
			this.meshPath = PathCorrector.CorrectPath(meshPath);
			this.texturesPath = texturesPath;
		}
		#endregion Ctor

		#region Methods
		public static ModelPath CreateFromFolder(string modelFolder)
		{
			string meshPath = FileHelper.GetFile(modelFolder, ".obj");
			TexturesPath texturesPath = TexturesPath.CreateFromFolder(modelFolder);

			return new ModelPath(meshPath, texturesPath);
		}
		#endregion Methods
	}
}
