namespace Tartaros.MeshViewer
{
	using Dummiesman;
	using System.IO;
	using UnityEngine;

	internal class ModelLoader
	{
		public GameObject Load(ModelPath modelPath)
		{
			GameObject model = CreateMesh(modelPath);

			ApplyMaterial(modelPath, model);

			return model;
		}

		private static GameObject CreateMesh(ModelPath modelPath)
		{
			string extension = Path.GetExtension(modelPath.meshPath);

			if (extension == ".obj")
			{
				return new OBJLoader().Load(modelPath.meshPath);
			}
			else if (extension == ".fbx")
			{
				throw new System.NotImplementedException();
			}
			else
			{
				throw new System.NotSupportedException(string.Format("The mesh file is not a supported extensions \"{0}\".", extension));
			}

		}

		private static void ApplyMaterial(ModelPath modelPath, GameObject model)
		{
			MaterialLoader matLoader = new MaterialLoader(modelPath.texturesPath);
			matLoader.ApplyMaterialsToGameObject(model);
		}
	}
}
