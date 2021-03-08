namespace Tartaros.MeshViewer
{
	internal static class PathCorrector
	{
		public static string CorrectPath(string path)
		{
			if (string.IsNullOrEmpty(path) == true) throw new System.ArgumentNullException();

			return path.Replace('\\', '/');
		}
	}
}
