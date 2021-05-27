
namespace Tartaros.Construction
{
	using System.Collections;
	using UnityEngine;
	using Tartaros.Gamemode;
	using Tartaros.Economy;
	using Tartaros.Gamemode.State;
	using Tartaros.ServicesLocator;
	using Tartaros.Map;

	public class ConstructionState : AGameState
	{
		#region Fields
		private readonly BuildingPreview _buildingPreview = null;
		private readonly IConstructable _constructable = null;

		private readonly ConstructionInputs _constructionInput = null;
		private readonly UserErrorsLogger _errorsLogger = null;
		private readonly IPlayerSectorResources _playerSectorRessources = null;
		private readonly IMap _map = null;
		#endregion Fields

		#region Ctor
		public ConstructionState(GamemodeManager gamemodeManager, IConstructable constructable) : base(gamemodeManager)
		{
			_constructable = constructable;
			_constructionInput = new ConstructionInputs();
			_buildingPreview = new BuildingPreview(_constructable, _constructionInput.GetMousePosition());
			_playerSectorRessources = Services.Instance.Get<IPlayerSectorResources>();
			_errorsLogger = Services.Instance.Get<UserErrorsLogger>();
			_map = Services.Instance.Get<IMap>();
		}
		#endregion Ctor

		#region Methods
		public override void OnStateEnter()
		{
			base.OnStateEnter();

			_stateOwner.InvokeConstructionStateEnable(this, null);

			_constructionInput.ValidatePerformed -= InputValidatePerformed;
			_constructionInput.ValidatePerformed += InputValidatePerformed;

			_constructionInput.LeavePerformed -= InputLeavePerformed;
			_constructionInput.LeavePerformed += InputLeavePerformed;
		}

		private void InputLeavePerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
		{
			LeaveState();
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

			if(CanConstructHere() == true) 
			{
				ChangeColorOfMaterial(Color.green);
			}
			else
			{
				ChangeColorOfMaterial(Color.red);
			}

		}

		private void ChangeColorOfMaterial(Color color)
		{
			if(_buildingPreview != null && _buildingPreview.GetMeshRenderers() != null)
			{

				var buildingMeshsRender = _buildingPreview.GetMeshRenderers();
				var buildingSkinnedMeshRender = _buildingPreview.GetSkinnedMeshRenderers();


				ShaderHelper.ChangeMeshColorMaterials(buildingMeshsRender, color);
				ShaderHelper.ChangeSkinnedMeshColorMaterials(buildingSkinnedMeshRender, color);
			}
		}



		private void InputValidatePerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
		{
			if (CanConstructHere())
			{
				ValidateConstruction();
			}
			else
			{
				Debug.Log("Can't build here");
			}
		}

		public bool CanConstructHere()
		{
			Vector3 buildingPosition = _buildingPreview.GetBuildingPreviewPosition();

			if (_buildingPreview.IsConstructableHere() == false)
			{
				return false;
			}

			return _map.CanBuild(buildingPosition, _constructable.Size) && DoCanConstructRulesAreValid();
		}

		private bool DoCanConstructRulesAreValid()
		{
			bool rulePass = _constructable.DoRulesPassAtPosition(_buildingPreview.GetBuildingPreviewPosition());

			if (rulePass == false)
			{
				LogFailedConstructRules();
			}

			return rulePass;
		}

		private void LogFailedConstructRules()
		{
			var failedRules = _constructable.GetFailedRules(_buildingPreview.GetBuildingPreviewPosition());

			foreach (var failedRule in failedRules)
			{
				_errorsLogger.Log(failedRule.ErrorMessage);
			}
		}

		private void ValidateConstruction()
		{
			InstanciateBuilding();
			PayPriceRessources();
			LeaveState();
		}


		private void InstanciateBuilding()
		{
			_constructable.InstantiateConstructionKit(_buildingPreview.GetBuildingPreviewPosition());
		}

		private void PayPriceRessources()
		{
			_playerSectorRessources.Buy(_constructable.Price);
		}
		#endregion Methods
	}
}