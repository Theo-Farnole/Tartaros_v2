namespace Tartaros.MeshViewer
{
	using System.Collections.Generic;
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

		/// <summary>
		/// Ignore .metafile
		/// </summary>
		public static string GetFile(string directoryPath, string filename)
		{
			string[] files = Directory.GetFiles(directoryPath)
				.Where(name => !name.EndsWith(".meta") && name.Contains(filename))
				.ToArray();

			if (files.Length == 0)
			{
				Debug.LogWarningFormat("No found file containing {0} in directory {1}.", filename, directoryPath);
				return null;
			}
			else if (files.Length > 1)
			{
				Debug.LogWarningFormat("Founded more than one file with search pattern {0}. Some problems can happen", filename);
			}

			return files[0];
		}

		public static string GetFile(string directoryPath, string[] extensions)
		{
			string[] files = GetFilesWithExtension(directoryPath, extensions);			

			if (files.Length == 0)
			{
				string extensionsAsString = string.Join(",", extensions);
				Debug.LogWarningFormat("No found file of extensions {0} in directory {1}.", extensionsAsString, directoryPath);
				return null;
			}
			else if (files.Length > 1)
			{
				Debug.LogWarningFormat("Founded more than one file with the extensions {0}. Some problems can happen", extensions);
			}

			return files[0];
		}

		private static string[] GetFilesWithExtension(string directoryPath, string[] extensions)
		{
			IEnumerable<string> filesEnumeration = Directory.GetFiles(directoryPath);
			List<string> files = new List<string>();

			foreach (var extension in extensions)
			{
				string extWithDot = string.Format(".{0}", extension);

				IEnumerable<string> filesOfExtensions = filesEnumeration
					.Where(filename => filename.EndsWith(extWithDot));

				files.AddRange(filesOfExtensions);
			}

			return files.ToArray();
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
			if (string.IsNullOrEmpty(textureFilePath) == true)
			{
				Debug.LogError("Path is null or empty.");
				return null;
			}

			byte[] bytes = File.ReadAllBytes(textureFilePath);
			Texture2D texture = new Texture2D(2, 2);
			texture.LoadImage(bytes);
			return texture;
		}
	}
}
