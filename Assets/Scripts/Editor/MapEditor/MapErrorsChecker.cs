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
			Dictionary<SectorData, Line[]> linesBySite = GetLinesBySites(map);

			foreach (SectorData testedSite in map.MapData.Sectors)
			{
				if (IsSiteIntersectWithAnotherSite(map, linesBySite, testedSite) == true)
				{
					return true;
				}
			}

			return false;
		}

		private static bool IsSiteIntersectWithAnotherSite(Map map, Dictionary<SectorData, Line[]> linesBySite, SectorData testedSite)
		{
			foreach (Line testedLines in linesBySite[testedSite])
			{
				if (IsLineIntersectWithAnotherSiteLines(linesBySite, testedSite, testedLines) == true)
				{
					Debug.LogErrorFormat("Error detected on map {0}: site n°{1} is inside other site.", map.name, Array.FindIndex(map.MapData.Sectors, x => x == testedSite));
					return true;
				}
			}

			return false;
		}

		private static bool IsLineIntersectWithAnotherSiteLines(Dictionary<SectorData, Line[]> linesBySite, SectorData site, Line testingLine)
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

		private static Dictionary<SectorData, Line[]> GetLinesBySites(Map map)
		{
			var output = new Dictionary<SectorData, Line[]>();

			foreach (SectorData site in map.MapData.Sectors)
			{
				List<Line> lines = new List<Line>();

				foreach (Vertex2D vertex1 in site.Vertices)
				{
					foreach (Vertex2D vertex2 in site.Vertices)
					{
						if (vertex1 == vertex2) continue;

						var line = new Line(vertex1.WorldPosition, vertex2.WorldPosition);
						lines.Add(line);
					}
				}

				output.Add(site, lines.ToArray());
			}

			return output;
		}
	}
}
