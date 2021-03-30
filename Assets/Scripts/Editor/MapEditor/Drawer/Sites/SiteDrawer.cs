namespace Tartaros.Map.Editor
{
	using UnityEditor;
	using UnityEngine;

	public class SiteDrawer
	{
		#region Fields
		public float polygonOpacity = 0.5f;
		public Color lineColor = Color.white;
		#endregion Fields

		#region Methods
		/// <summary>
		/// Draw site with borders, label and color inside borders.
		/// </summary>
		/// <param name="site"></param>
		/// <param name="label"></param>
		public void DrawCompleteSite(SectorData site, string label)
		{
			if (site == null) throw new System.ArgumentNullException();

			DrawBorders(site);
			DrawSiteLabel(site, label);
			DrawColorInsideBorders(site);
		}

		public void DrawSiteLabel(SectorData site, string label)
		{
			if (site == null) throw new System.ArgumentNullException();
			Handles.Label(site.Centroid, label);
		}

		public void DrawBorders(SectorData site)
		{
			if (site == null) throw new System.ArgumentNullException();

			Vector3[] sitePoints = site.GetWorldPointsWrapped();

			Handles.color = lineColor;
			Handles.DrawPolyLine(sitePoints);
		}

		public void DrawColorInsideBorders(SectorData site)
		{
			Vector3[] sitePoints = site.GetWorldPointsWrapped();

			SetHandleColorFromSite(site);
			Handles.DrawAAConvexPolygon(sitePoints);
		}

		private void SetHandleColorFromSite(SectorData site)
		{
			Random.InitState(site.GetHashCode());

			Color handlesColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
			handlesColor.a = polygonOpacity;
			Handles.color = handlesColor;
		}
		#endregion Methods
	}
}
