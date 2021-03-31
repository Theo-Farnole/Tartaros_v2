namespace Tartaros.Map.Editor
{
	using UnityEditor;
	using UnityEngine;

	public class MapSitesDrawer
	{
		#region Fields
		public const float HANDLE_SIZE = 0.5f;
		public static readonly Color HANDLE_COLOR = Color.red;
		public static readonly Quaternion HANDLE_ROTATION = Quaternion.Euler(90, 0, 0);

		private Map _map = null;

		private SiteDrawer _siteDrawer = null;
		#endregion Fields

		#region Properties
		public bool CanEdit { get; set; }
		#endregion Properties

		#region Ctor
		public MapSitesDrawer(Map map)
		{
			_map = map;
			_siteDrawer = new SiteDrawer();

		}
		#endregion Ctor

		#region Methods
		public void Draw()
		{
			if (_map.MapData == null) return;

			DrawSites(Color.white);
		}

		private void DrawSites(Color color)
		{
			for (int i = 0; i < _map.MapData.Sectors.Length; i++)
			{
				SectorData site = _map.MapData.Sectors[i];
				_siteDrawer.lineColor = color;

				_siteDrawer.DrawBorders(site);
				_siteDrawer.DrawSiteLabel(site, i.ToString());

				if (EditorPrefs.GetBool(Map.FILL_SITE_ID))
				{
					_siteDrawer.DrawColorInsideBorders(site);
				}
			}
		}
		#endregion Methods
	}
}
