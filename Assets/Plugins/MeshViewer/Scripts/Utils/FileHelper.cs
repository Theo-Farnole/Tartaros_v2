namespace Tartaros.MeshViewer
{
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

		public static bool TryGetFileWithSearchPattern(string directoryPath, string searchPattern, out string filename)
		{
			string[] fbxFiles = System.IO.Directory.GetFiles(directoryPath, searchPattern);

			if (fbxFiles.Length == 1)
			{
				filename = fbxFiles[0];
				return true;
			}
			else if (fbxFiles.Length > 1)
			{
				Debug.LogWarningFormat("Founded more than one file with search pattern {0}. Some problems can happen", searchPattern);
				filename = fbxFiles[0];
				return true;
			}
			else
			{
				filename = null;
				return false;
			}
		}
	}
}
