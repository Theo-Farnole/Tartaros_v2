namespace Tartaros.Map.Editor
{
	using System;
	using System.Collections.Generic;
	using UnityEngine;

	public static class MapErrorsChecker
	{
		private class Line
		{
			public Vector2 p1;
			public Vector2 p2;

			public Line(Vector2 p1, Vector2 p2)
			{
				this.p1 = p1;
				this.p2 = p2;
			}
		}

		public static bool HasErrors(Map map)
		{
			Dictionary<Site, Line[]> linesBySite = GetLinesBySites(map);

			foreach (Site testedSite in map.MapData.Sites)
			{
				if (IsSiteIntersectWithAnotherSite(map, linesBySite, testedSite) == true)
				{
					return true;
				}
			}

			return false;
		}

		private static bool IsSiteIntersectWithAnotherSite(Map map, Dictionary<Site, Line[]> linesBySite, Site testedSite)
		{
			foreach (Line testedLines in linesBySite[testedSite])
			{
				if (IsLineIntersectWithAnotherSiteLines(linesBySite, testedSite, testedLines) == true)
				{
					Debug.LogErrorFormat("Error detected on map {0}: site n°{1} is inside other site.", map.name, Array.FindIndex(map.MapData.Sites, x => x == testedSite));
					return true;
				}
			}

			return false;
		}

		private static bool IsLineIntersectWithAnotherSiteLines(Dictionary<Site, Line[]> linesBySite, Site site, Line testingLine)
		{
			foreach (var kvp in linesBySite)
			{
				if (kvp.Key == site) continue;

				foreach (Line line in kvp.Value)
				{
					bool areLinesIntesrsecting = MathHelper.AreLinesIntersecting(testingLine.p1, testingLine.p2, line.p1, line.p2, false);

					if (areLinesIntesrsecting == true)
					{
						return true;
					}
				}
			}

			return false;
		}

		private static Dictionary<Site, Line[]> GetLinesBySites(Map map)
		{
			var output = new Dictionary<Site, Line[]>();

			foreach (Site site in map.MapData.Sites)
			{
				List<Line> lines = new List<Line>();

				foreach (Vertex vertex1 in site.Vertices)
				{
					foreach (Vertex vertex2 in site.Vertices)
					{
						if (vertex1 == vertex2) continue;

						var line = new Line(vertex1.Position, vertex2.Position);
						lines.Add(line);
					}
				}

				output.Add(site, lines.ToArray());
			}

			return output;
		}
	}
}
