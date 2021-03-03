namespace Tartaros.MeshViewer
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using UnityEngine;

	internal class MeshPathConfiguration
	{
		public readonly string modelPath = null;
		public readonly string meshPath = null;

		public MeshPathConfiguration(string modelPath)
		{
			if (string.IsNullOrEmpty(modelPath)) Debug.LogWarning("Model path is null or empty.");

			this.modelPath = PathCorrector.CorrectPath(modelPath);

			meshPath = PathCorrector.CorrectPath(FindMeshPath(this.modelPath));
		}

		private static string FindMeshPath(string modelPath)
		{
			if (FileHelper.TryGetFileWithExtension(modelPath, "obj", out string meshFile))
			{
				return meshFile;
			}
			else
			{
				Debug.LogWarning("Not mesh file found.");
				return null;
			}
		}

		private static string FindMaterialPath(string modelPath)
		{
			if (FileHelper.TryGetFileWithExtension(modelPath, "mtl", out string matFile))
			{
				return matFile;
			}
			else
			{
				Debug.LogWarning("Not material file found.");
				return null;
			}
		}
	}
}
