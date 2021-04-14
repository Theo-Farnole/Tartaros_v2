namespace Tartaros.ServicesLocator
{
	using Tartaros.Construction;
	using Tartaros.Economy;
	using Tartaros.Entities.Detection;
	using Tartaros.FogOfWar;
	using Tartaros.Gamemode;
	using Tartaros.Map;
	using Tartaros.OrderGiver;
	using Tartaros.Population;
	using Tartaros.Power;
	using Tartaros.Selection;
	using Tartaros.UI.MiniMap;
	using Tartaros.Utilities;
	using Tartaros.Wave;
	using UnityEngine;

	public class ServicesInstaller : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private Services _services = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			InstallBindings();
		}

		void InstallBindings()
		{
			RegisterFromHierarchy<IMap>();
			RegisterFromHierarchy<EnemiesWavesManager>();

			RegisterFromHierarchy<MiniMap>();
			RegisterFromHierarchy<NavigationPathMiniMap>();

			RegisterFromChildren<ConstructionManager>();
			RegisterFromChildren<IPlayerGloryWallet>();
			RegisterFromChildren<IPlayerIncomeManager>();
			RegisterFromChildren<IPlayerSectorResources>();
			RegisterFromChildren<EntitiesKDTrees>();
			RegisterFromChildren<FogOfWarManager>();
			RegisterFromChildren<GamemodeManager>();
			RegisterFromChildren<ICheckCanConstruct>();
			RegisterFromChildren<ISectorsCaptureManager>();
			RegisterFromChildren<SelectionOrderGiverInput>(); // TODO: check if I can remove it
			RegisterFromChildren<SelectionOrderGiver>();
			RegisterFromChildren<IPopulationManager>();
			RegisterFromChildren<PowerManager>();
			RegisterFromChildren<CurrentSelection>();
			RegisterFromChildren<IconsDatabase>();
			RegisterFromChildren<UserErrorsLogger>();

		}

		private void RegisterFromHierarchy<T>()
		{
			var objectsFound = ObjectsFinder.FindObjectsOfInterface<T>();

			if (objectsFound.Length == 0)
			{
				Debug.LogErrorFormat("No object of type {0} found in the scene.", typeof(T));
			}
			else
			{
				if (objectsFound.Length > 1)
				{
					Debug.LogErrorFormat("More than one object of type {0} found in the scene. We register the first element of the array.", typeof(T));
				}

				T objectToRegister = objectsFound[0];
				_services.RegisterService(objectToRegister);
			}
		}

		private void RegisterFromChildren<T>()
		{
			var objectsFound = GetComponentsInChildren<T>();

			if (objectsFound.Length == 0)
			{
				Debug.LogErrorFormat("No object of type {0} found in the children of {1}.", typeof(T), name);
			}
			else
			{
				if (objectsFound.Length > 1)
				{
					Debug.LogErrorFormat("More than one object of type {0} found in the chidren of {1}. We register the first element of the array.", typeof(T), name);
				}

				T objectToRegister = objectsFound[0];
				_services.RegisterService(objectToRegister);
			}
		}
		#endregion Methods
	}
}