namespace Tartaros
{
	using System.Linq;
	using Tartaros.Entities;
	using Tartaros.Map;
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

		public static bool IsSectorNeightborOf(this ISector sector, ISector toTest)
		{
			if (sector is Sector convertSector && toTest is Sector convertToTest)
			{
				foreach (Vertex2D vertex in convertSector.SectorData.Vertices)
				{
					foreach (Vertex2D vertexToTest in convertToTest.SectorData.Vertices)
					{
						if (vertex == vertexToTest)
						{
							return true;
						}
					}
				}

				return false;
			}
			else
			{
				throw new System.NotSupportedException();
			}
		}
	}
}