namespace Tartaros.MeshViewer
{
	using Dummiesman;
	using System.IO;
	using UnityEngine;

	internal class ModelLoader
	{
		public GameObject Load(string meshPath)
		{
			GameObject model = new OBJLoader().Load(meshPath);

			new MaterialLoader().ApplyMaterialsToGameObject(model, meshPath);

			return model;
		}

		public GameObject Load(MeshPathConfiguration meshPathConfiguration)
		{
			return Load(meshPathConfiguration.meshPath);
		}
	}
}
