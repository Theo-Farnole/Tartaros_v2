namespace Tartaros.Construction
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Tartaros.Construction;
	using Tartaros.Economy;
	using Tartaros.Gamemode;
	using Tartaros.ServicesLocator;
    using Tartaros.Gamemode.State;

    public class ConstructionManager : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private ConstructionManagerData _constructionManagerData = null;
		private GamemodeManager _gamemodeManager = null;
		private IPlayerSectorResources _playerSectorRessources = null;
		#endregion

		#region Properties
		public ConstructionManagerData ConstructionManagerData => _constructionManagerData;
		#endregion Properties

		#region Methods
		private void Awake()
		{
			Services.Instance.RegisterService(this);
		}

		private void Start()
		{
			_gamemodeManager = Services.Instance.Get<GamemodeManager>();
			_playerSectorRessources = Services.Instance.Get<IPlayerSectorResources>();
		}

		public bool CanEnterConstruction(IConstructable constructable)
		{
			return _playerSectorRessources.CanBuy(constructable.Price);
		}

		public void EnterConstructionMode(IConstructable toBuild)
		{
            if (toBuild.IsWall)
            {
				_gamemodeManager.SetState(new WallConstructionState(_gamemodeManager, toBuild));
            }
            else
            {
				_gamemodeManager.SetState(new ConstructionStateV2(_gamemodeManager, toBuild));
            }
		}
		#endregion
	}

}