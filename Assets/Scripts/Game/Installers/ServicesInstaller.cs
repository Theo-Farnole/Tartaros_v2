namespace Tartaros.ServicesLocator
{
	using Tartaros.Construction;
	using Tartaros.Dialogue;
	using Tartaros.Economy;
	using Tartaros.Entities;
	using Tartaros.Entities.Detection;
	using Tartaros.FogOfWar;
	using Tartaros.Gamemode;
	using Tartaros.Map;
	using Tartaros.OrderGiver;
	using Tartaros.Population;
	using Tartaros.Powers;
	using Tartaros.Selection;
	using Tartaros.SoundsSystem;
	using Tartaros.UI;
	using Tartaros.UI.HoverPopup;
	using Tartaros.UI.MiniMap;
	using Tartaros.UI.Sectors.Orders;
	using Tartaros.Wave;
	using UnityEngine;

	public class ServicesInstaller : MonoBehaviour
	{
		#region Fields
		[SerializeField] private Services _services = null;
		[SerializeField] private bool _silentMissingServiceError = false;
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
			RegisterFromHierarchy<UIManager>();

			RegisterFromHierarchy<MiniMap>();
			RegisterFromHierarchy<NavigationPathMiniMap>();
			RegisterFromHierarchy<UIStyles>();
			RegisterFromHierarchy<HoverPopupManager>();
			RegisterFromHierarchy<GloryGemsManagerUI>();

			RegisterFromChildren<BuildingsDatabase>();
			RegisterFromChildren<MusicManager>();
			RegisterFromChildren<SectorObjectsManager>();
			RegisterFromChildren<PlayerIncomeDisplayAmount>();
			RegisterFromChildren<SoundsHandler>();
			RegisterFromChildren<HoverPopupsDatabase>();
			RegisterFromChildren<ConstructionManager>();
			RegisterFromChildren<IPlayerGloryWallet>();
			RegisterFromChildren<IPlayerIncomeManager>();
			RegisterFromChildren<IPlayerSectorResources>();
			RegisterFromChildren<EntitiesDetectorManager>();
			RegisterFromChildren<FogOfWarManager>();
			RegisterFromChildren<GamemodeManager>();
			RegisterFromChildren<ISectorsCaptureManager>();
			RegisterFromChildren<SelectionOrderGiverInput>(); // TODO: check if I can remove it
			RegisterFromChildren<SelectionOrderGiver>();
			RegisterFromChildren<IPopulationManager>();
			RegisterFromChildren<PowerManager>();
			RegisterFromChildren<CurrentSelection>();
			RegisterFromChildren<IconsDatabase>();
			RegisterFromChildren<UserErrorsLogger>();
			RegisterFromChildren<DialogueManager>();
		}

		private void RegisterFromHierarchy<T>()
		{
			var objectsFound = ObjectsFinder.FindObjectsOfInterface<T>();

			if (objectsFound.Length == 0)
			{
				if (_silentMissingServiceError == false)
				{
					Debug.LogErrorFormat("No object of type {0} found in the scene.", typeof(T));
				}
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
				if (_silentMissingServiceError == false)
				{
					Debug.LogErrorFormat("No object of type {0} found in the children of {1}.", typeof(T), name);
				}
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