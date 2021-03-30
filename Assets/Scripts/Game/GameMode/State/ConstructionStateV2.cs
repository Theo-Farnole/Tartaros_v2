
namespace Tartaros.Construction
{
	using System.Collections;
	using UnityEngine;
	using Tartaros.Gamemode;
	using Tartaros.Economy;
	using Tartaros.Gamemode.State;
	using Tartaros.ServicesLocator;
	using Tartaros.Sectors;

	public class ConstructionStateV2 : AGameState
	{
		#region Fields
		private BuildingPreview _buildingPreview = null;
		private ConstructionInputs _constructionInput = null;
		private IConstructable _constructable = null;
		private IPlayerSectorResources _playerSectorRessources = null;
		private IMap _map = null;
		#endregion Fields

		#region Ctor
		public ConstructionStateV2(GamemodeManager gamemodeManager, IConstructable constructable) : base(gamemodeManager)
		{
			_constructable = constructable;
			_constructionInput = new ConstructionInputs();
			_buildingPreview = new BuildingPreview(_constructable, _constructionInput.GetMousePosition());
			_playerSectorRessources = Services.Instance.Get<IPlayerSectorResources>();
			_map = Services.Instance.Get<IMap>();
		}
		#endregion Ctor

		#region Methods
		public override void OnStateEnter()
		{
			base.OnStateEnter();

			_constructionInput.ValidatePerformed -= InputValidatePerformed;
			_constructionInput.ValidatePerformed += InputValidatePerformed;
		}

		public override void OnStateExit()
		{
			base.OnStateExit();

			_buildingPreview.DestroyMethod();
			_constructionInput.ValidatePerformed -= InputValidatePerformed;
		}

		public override void OnUpdate()
		{
			base.OnUpdate();

			_buildingPreview.SetBuildingPreviewPosition(_constructionInput.GetMousePosition());
		}

		private void InputValidatePerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
		{
			if (CanConstructHere())
			{
				Validate();
			}
		}

		bool CanConstructHere()
		{
			Vector3 buildingPosition = _buildingPreview.GetBuildingPreviewPosition();

			Debug.Log("buildingPosition = " + buildingPosition);


			if (_map.CanBuild(buildingPosition, _constructable.Size) == false)
			{
				Debug.LogFormat("Cannot build: map prevents build on {0}.", buildingPosition);
				return false;
			}
			else if (DoCanConstructRulesAreValid() == false)
			{
				Debug.LogFormat("Cannot build: construction rules prevent build on {0}.", buildingPosition);
				return false;
			}

			return true;
		}

		private bool DoCanConstructRulesAreValid()
		{
			return _constructable.DoRulesPassAtPosition(_buildingPreview.GetBuildingPreviewPosition());
		}

		private void Validate()
		{
			InstanciateBuilding();
			PayPriceRessources();
			LeaveState();
		}


		private void InstanciateBuilding()
		{
			GameObject.Instantiate(_constructable.GameplayPrefab, _buildingPreview.GetBuildingPreviewPosition(), Quaternion.identity);
		}

		private void PayPriceRessources()
		{
			_playerSectorRessources.Buy(_constructable.Price);
		}

		void LeaveState()
		{
			_stateOwner.SetState(new PlayState(_stateOwner));
		}
		#endregion Methods
	}
}