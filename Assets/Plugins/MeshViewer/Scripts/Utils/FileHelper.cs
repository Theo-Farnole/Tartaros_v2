namespace Tartaros.MeshViewer
{
	using System.IO;
	using System.Linq;
	using UnityEngine;

	internal static class FileHelper
	{
		public static bool TryGetFileWithExtension(string directoryPath, string extension, out string filename)
		{
			string[] fbxFiles = System.IO.Directory.GetFiles(directoryPath, string.Format("*.{0}", extension));

			if (fbxFiles.Length == 1)
			{
				filename = fbxFiles[0];
				return true;
			}
			else if (fbxFiles.Length > 1)
			{
				Debug.LogWarningFormat("Founded more than one {0} file in model. Some problems can happen", extension);
				filename = fbxFiles[0];
				return true;
			}
			else
			{
				filename = null;
				return false;
			}
		}

		public static string GetFile(string directoryPath, string searchPattern)
		{
			string[] files = Directory.GetFiles(directoryPath)
				.Where(name => !name.EndsWith(".meta") && name.Contains(searchPattern))
				.ToArray();

			if (files.Length == 0)
			{
				Debug.LogWarningFormat("No found file containing {0} in directory {1}.", searchPattern, directoryPath);
				return null;
			}
			else if (files.Length > 1)
			{
				Debug.LogWarningFormat("Founded more than one file with search pattern {0}. Some problems can happen", searchPattern);
			}

			return files[0];
		}

		public static bool TryGetFile(string directoryPath, string searchPattern, out string filename)
		{
			string[] files = Directory.GetFiles(directoryPath)
				.Where(name => !name.EndsWith(".meta") && name.Contains(searchPattern))
				.ToArray();

			if (files.Length == 0)
			{
				filename = null;
				return false;
			}
			else
			{
				if (files.Length > 1)
				{
					Debug.LogWarningFormat("Founded more than one file with search pattern {0}. Some problems can happen", searchPattern);
				}

				filename = files[0];
				return true;
			}
		}

		public static Texture2D LoadTexture(string textureFilePath)
		{
			if (string.IsNullOrEmpty(textureFilePath) == true) throw new System.ArgumentException("Path is null or empty.");

			byte[] bytes = File.ReadAllBytes(textureFilePath);
			Texture2D texture = new Texture2D(2, 2);
			texture.LoadImage(bytes);
			return texture;
		}
	}
}
