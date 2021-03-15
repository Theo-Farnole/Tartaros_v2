namespace Tartaros.Map
{
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	public class MapData : ScriptableObject
	{
		#region Fields
		[SerializeField]
		private Vector2 _mapSize = new Vector2(10, 10);

		[SerializeField]
		private List<Site> _sites = new List<Site>(0);
		#endregion Fields

		#region Properties
		public Vector2 MapSize => _mapSize;
		public Site[] Sites => _sites.ToArray();
		public Vertex[] Vertices => _sites.SelectMany(x => x.Vertices).ToArray();
		#endregion Properties

		#region Methods
		public void AddSite(Site site)
		{
			_sites.Add(site);
		}
		#endregion Methods
	}
}