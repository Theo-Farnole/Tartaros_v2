﻿namespace Tartaros.MeshViewer
{
	using System.IO;
	using UnityEngine;

	internal class MaterialLoader
	{
		#region Fields
		public readonly TexturesPath texturesPath = null;
		#endregion Fields

		#region Ctor
		public MaterialLoader(TexturesPath texturesPath)
		{
			this.texturesPath = texturesPath;
		}
		#endregion Ctor

		#region Methods
		public void ApplyMaterialsToGameObject(GameObject model)
		{
			Material mat = CreateMaterial();

			model.GetComponentInChildren<Renderer>().material = mat;
		}

		private Material CreateMaterial()
		{
			Material mat = new Material(Shader.Find("Standard"));

			mat.SetTexture("_MainTex", texturesPath.AlbedoTexture);
			mat.SetTexture("_Occlusion", texturesPath.AOTexture);
			mat.SetTexture("_BumpMap", texturesPath.NormalTexture);

			return mat;
		}
		#endregion Methods
	}
}
