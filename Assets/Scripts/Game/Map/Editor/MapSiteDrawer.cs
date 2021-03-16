namespace Tartaros.Map.Editor
{
	using UnityEditor;
	using UnityEngine;

	public class MapSiteDrawer
	{
		#region Fields
		public float polygonOpacity = 0.5f;
		public Color lineColor = Color.white;
		#endregion Fields

		#region Methods
		public void DrawSite(Site site)
		{
			if (site == null) throw new System.ArgumentNullException();

			DrawLine(site);
			DrawPolygon(site);
		}

		private void DrawLine(Site site)
		{
			Vector3[] sitePoints = site.GetWorldPointsWrapped();

			Handles.color = lineColor;
			Handles.DrawPolyLine(sitePoints);
		}

		private void DrawPolygon(Site site)
		{
			Vector3[] sitePoints = site.GetWorldPointsWrapped();

			SetHandleColorFromSite(site);
			Handles.DrawAAConvexPolygon(sitePoints);
		}

		private void SetHandleColorFromSite(Site site)
		{
			Random.InitState(site.GetHashCode());

			Color handlesColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
			handlesColor.a = polygonOpacity;
			Handles.color = handlesColor;
		}
		#endregion Methods
	}
}
