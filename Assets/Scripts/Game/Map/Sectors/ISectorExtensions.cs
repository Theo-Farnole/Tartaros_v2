namespace Tartaros
{
	using System.Linq;
	using Tartaros.Entities;
	using Tartaros.Sectors;

	public static class ISectorExtensions
	{
		public static Entity[] GetEntitiesInSector(this ISector sector)
		{
			Entity[] entitiesInSector = sector.ObjectsInSector
				.Select(x => x.GetComponent<Entity>())
				.Where(x => x != null)
				.ToArray();

			return entitiesInSector;
		}

		public static int GetEntityCount(this ISector sector, EntityData correspondingData)
		{
			return sector.GetEntitiesInSector().Count(x => x.EntityData == correspondingData);
		}
	}
}