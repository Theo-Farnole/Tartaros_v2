namespace Tartaros.MeshViewer
{
	using Dummiesman;
	using Plugins.FBXImporter;
	using System.IO;
	using UnityEngine;
	using UnityMeshImporter;

	internal class ModelLoader
	{
		public GameObject Load(ModelPath modelPath)
		{
			GameObject mesh = CreateMesh(modelPath);

			ApplyMaterial(modelPath, mesh);

			return mesh;
		}

		private GameObject CreateMesh(ModelPath modelPath)
		{
			string extension = Path.GetExtension(modelPath.meshPath);

			if (extension == ".obj" || extension == ".fbx")
			{
				return MeshImporter.Load(modelPath.meshPath);
			}
			else
			{
				throw new System.NotSupportedException(string.Format("The mesh file is not a supported extensions \"{0}\".", extension));
			}
		}

		private void ApplyMaterial(ModelPath modelPath, GameObject model)
		{
			MaterialLoader matLoader = new MaterialLoader(modelPath.texturesPath);
			matLoader.ApplyMaterialsToGameObject(model);
		}
	}
}
