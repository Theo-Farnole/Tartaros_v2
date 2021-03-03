namespace Tartaros.MeshViewer
{
	using System.IO;
	using UnityEngine;

	internal class MaterialLoader
	{
		public void ApplyMaterialsToGameObject(GameObject model, string modelPath)
		{
			string modelFolder = Path.GetDirectoryName(modelPath);

			Material mat = CreateMaterial(modelFolder);

			model.GetComponentInChildren<Renderer>().material = mat;
		}

		private Material CreateMaterial(string modelFolder)
		{
			Material mat = new Material(Shader.Find("Standard"));
			mat.SetTexture("_MainTex", LoadImage(modelFolder, "Albedo"));

			// TODO TF: ao
			// TODO TF: normal

			return mat;
		}

		private Texture LoadImage(string modelFolder, string imageType)
		{
			if (FileHelper.TryGetFileWithSearchPattern(modelFolder, string.Format("*{0}*", imageType), out string filename))
			{
				byte[] bytes = File.ReadAllBytes(filename);
				Texture2D texture = new Texture2D(2, 2);
				texture.LoadImage(bytes);
				return texture;
			}
			else
			{
				Debug.LogWarningFormat("Cannot load texture of type {0}.", imageType);
				return null;
			}
		}
	}
}
