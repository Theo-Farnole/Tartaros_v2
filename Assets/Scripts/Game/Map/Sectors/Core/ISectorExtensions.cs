namespace Tartaros
{
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Construction;
	using Tartaros.Economy;
	using Tartaros.Entities;
	using Tartaros.Map;
	using Tartaros.UI.Sectors.Orders;
	using UnityEngine;

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

		public static IEnumerable<T> EnumerateObjectsOfType<T>(this ISector sector)
		{
			return sector.ObjectsInSector
				.Select(x => x.GetComponent<T>())
				.Where(x => x != null);
		}

		public static IEnumerable<BuildingSlot> GetBuildingSlots(this ISector sector)
		{
			return sector.EnumerateObjectsOfType<BuildingSlot>();
		}

		/// <summary>
		/// Returns null if no slot is available
		/// </summary>
		public static BuildingSlot GetBuildingSlotAvailable(this ISector sector)
		{
			IEnumerable<BuildingSlot> slots = sector.EnumerateObjectsOfType<BuildingSlot>();

			foreach (BuildingSlot slot in slots)
			{
				if (slot.IsAvailable == true)
				{
					return slot;
				}
			}

			throw new System.NotSupportedException("No available building slot found on sector {0}.".Format(sector));
		}

		public static bool ContainsAvailablCaptureBuilding(this ISector sector)
		{
			IEnumerable<CaptureBuilding> captureBuildings = sector.EnumerateObjectsOfType<CaptureBuilding>();

			foreach (CaptureBuilding capture in captureBuildings)
			{
				Debug.Log("here");
				if (capture.IsAvailable == true)
				{
					return true;
				}
			}

			return false;
		}

		public static bool ContainsAvailableBuildingSlot(this ISector sector)
		{
			IEnumerable<BuildingSlot> slots = sector.EnumerateObjectsOfType<BuildingSlot>();

			foreach (BuildingSlot slot in slots)
			{
				if (slot.IsAvailable == true)
				{
					return true;
				}
			}

			return false;
		}

		public static Entity GetConstructableInSector(this ISector sector, IConstructable constructable)
		{
			Entity[] entities = GetEntitiesInSector(sector);


			foreach (var entity in entities)
			{
				
				if(entity.EntityType == EntityType.Building)
				{
					Debug.Log(entity.GetBehaviourData<IConstructable>());
				}

				if (entity.EntityType == EntityType.Building && entity.GetBehaviourData<IConstructable>() == constructable)
				{
					return entity;
				}
			}

			return null;
		}

		public static Entity[] GetEntitiesInSector(this ISector sector)
		{
			Entity[] entitiesInSector = sector.ObjectsInSector
				.Select(x => x.GetComponent<Entity>())
				.Where(x => x != null)
				.ToArray();

			return entitiesInSector;
		}

		public static bool ContainsResourceFlag(this ISector sector, SectorRessourceType type)
		{
			return GetResourceFlagCount(sector, type) > 0;
		}

		public static int GetResourceFlagCount(this ISector sector, SectorRessourceType type)
		{
			return sector.ObjectsInSector.Count(objectInSector => IsResourceFlag(objectInSector, type));
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

		public static int GetEntitiesCountInSector(this ISector sector, EntityData correspondingData)
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

		public static bool ContainsResource(this ISector sector)
		{
			return sector.FindObjectsInSectorOfType<FlagResourceToSector>().Length > 0;
		}

		public static SectorRessourceType GetResourceType(this ISector sector)
		{
			FlagResourceToSector[] flags = sector.FindObjectsInSectorOfType<FlagResourceToSector>();

			if (flags.Length == 1)
			{
				return flags[0].Type;
			}
			else
			{
				throw new System.NotSupportedException(string.Format("There is {0} resources flags on sector {1}. This is not supported.", flags.Length, sector.ToString()));
			}
		}

		public static ISectorUIStylizer GetUIStylizer(this ISector sector)
		{
			ISectorUIStylizer[] stylizers = sector.FindObjectsInSectorOfType<ISectorUIStylizer>();

			if (stylizers.Length > 1) throw new System.NotSupportedException("A sector cannot contains more than one UI stylizer. Please remove one.");

			if (stylizers.Length > 0)
			{
				return stylizers[0];
			}
			else
			{
				return null;
			}
		}

		public static SectorUIContent GetUIContent(this ISector sector)
		{
			ISectorUIContentProvider[] content = sector.FindObjectsInSectorOfType<ISectorUIContentProvider>();

			if (content.Length > 1) throw new System.NotSupportedException("A sector cannot contains more than one UI content. Please remove one.");

			if (content.Length > 0)
			{
				return content[0].GetSectorContent();
			}
			else
			{
				return null;
			}
		}

		public static bool TryGetResourceType(this ISector sector, out SectorRessourceType type)
		{
			FlagResourceToSector[] flags = sector.FindObjectsInSectorOfType<FlagResourceToSector>();

			if (flags.Length > 1)
			{
				throw new System.NotSupportedException(string.Format("There is {0} resources flags on sector {1}. This is not supported.", flags.Length, sector.ToString()));
			}
			else if (flags.Length == 1)
			{
				type = flags[0].Type;
				return true;
			}
			else
			{
				type = SectorRessourceType.Food;
				return false;
			}
		}

		private static bool IsResourceFlag(GameObject gameObject, SectorRessourceType type)
		{
			if (gameObject.TryGetComponent(out FlagResourceToSector resourceFlag))
			{
				return resourceFlag.Type == type;
			}
			else
			{
				return false;
			}
		}
	}
}