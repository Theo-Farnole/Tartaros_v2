namespace Tartaros.MeshViewer
{
	using Dummiesman;
	using System.IO;
	using UnityEngine;

	internal class ModelLoader
	{
		public GameObject Load(ModelPath modelPath)
		{
			GameObject model = new OBJLoader().Load(modelPath.meshPath);

			MaterialLoader matLoader = new MaterialLoader(modelPath.texturesPath);
			matLoader.ApplyMaterialsToGameObject(model);

			return model;

		}
	}
}
