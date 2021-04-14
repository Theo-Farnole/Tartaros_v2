namespace Tartaros.Power
{
	using Sirenix.OdinInspector;
	using Tartaros.Economy;
	using Tartaros.Gamemode;
	using Tartaros.Gamemode.State;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class PowerManager : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		[AssetsOnly]
		private GameObject _lightningBoltPrefab = null;

		[SerializeField]
		[AssetsOnly]
		private GameObject _controlledAoEPrefab = null;

		private GamemodeManager _gameModeManager = null;
		private UserErrorsLogger _userErrorsLogger = null;
		private IPlayerGloryWallet _gloryWallet = null;
		#endregion Fields

		#region Methods
		private void Start()
		{
			_gameModeManager = Services.Instance.Get<GamemodeManager>();
			_userErrorsLogger = Services.Instance.Get<UserErrorsLogger>();
			_gloryWallet = Services.Instance.Get<IPlayerGloryWallet>();
		}

		public bool CanCastSpell(IPower power)
		{
			return _gloryWallet.CanSpend(power.Price);
		}

		public void CastLightningBolt()
		{
			Cast(_lightningBoltPrefab);
		}

		public void CastControlledAoE()
		{
			Cast(_controlledAoEPrefab);
		}

		private void Cast(GameObject prefab)
		{
			if (prefab.TryGetComponent(out IPower power))
			{
				Cast(power);
			}
			else
			{
				Debug.LogFormat("Missing power component on prefab {0} of power manager.", prefab.name);
			}
		}

		public void Cast(IPower power)
		{
			if (CanCastSpell(power) == true)
			{
				_gameModeManager.SetState(new PowerState(_gameModeManager, power));
			}
			else
			{
				_userErrorsLogger.Log("Not enought glory to cast spell {0}.", power.ToString());
			}
		}
		#endregion Methods
	}
}