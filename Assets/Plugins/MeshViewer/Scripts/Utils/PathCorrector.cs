namespace Tartaros.MeshViewer
{
	internal static class PathCorrector
	{
		public static string CorrectPath(string path)
		{
			return path.Replace('\\', '/');
		}
	}
}
