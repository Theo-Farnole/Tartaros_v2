namespace Tartaros
{
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Entities;
	using Tartaros.Map;
	using Tartaros.Sectors;

	public static class ISectorExtensions
	{
		public static T[] FindObjectsInSectorOfType<T>(this ISector sector)
		{
			T[] entitiesInSector = sector.ObjectsInSector
				.Select(x => x.GetComponent<T>())
				.Where(x => x != null)
				.ToArray();

			return entitiesInSector;
		}

		public static Entity[] GetEntitiesInSector(this ISector sector)
		{
			Entity[] entitiesInSector = sector.ObjectsInSector
				.Select(x => x.GetComponent<Entity>())
				.Where(x => x != null)
				.ToArray();

			return entitiesInSector;
		}

		public static bool IsThereEnemiesOnSector(this ISector sector)
		{
			return sector.GetEntitiesOfTypeOnSector(Team.Enemy) > 0;
		}

		public static bool IsTherePlayersEntitiesOnSector(this ISector sector)
		{
			return sector.GetEntitiesOfTypeOnSector(Team.Player) > 0;
		}

		private static int GetEntitiesOfTypeOnSector(this ISector sector, Team team)
		{
			return sector.GetEntitiesInSector()
							.Where(x => x.Team == team)
							.Count();
		}

		public static int GetEntityCount(this ISector sector, EntityData correspondingData)
		{
			return sector.GetEntitiesInSector().Count(x => x.EntityData == correspondingData);
		}

		public static bool IsSectorNeightborOf(this ISector sector1, ISector sector2)
		{
			if (sector1 is Sector convertedSector1 && sector2 is Sector convertedSector2)
			{
				Vertex2D[] verticesSector1 = convertedSector1.SectorData.Vertices;
				Vertex2D[] verticesSector2 = convertedSector2.SectorData.Vertices;

				Vertex2D[] mergedVertices = verticesSector1.Concat(verticesSector2).ToArray();

				int sharedVerticesCount = mergedVertices.GroupBy(x => x)
					.Where(g => g.Count() > 1)
					.Select(y => y.Key)
					.Count();

				return sharedVerticesCount >= 2;
			}
			else
			{
				throw new System.NotSupportedException();
			}
		}
	}
}