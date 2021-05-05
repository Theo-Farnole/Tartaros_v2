namespace Tartaros.Power
{
	using Sirenix.OdinInspector;
	using Tartaros.Economy;
	using Tartaros.Gamemode;
	using Tartaros.Gamemode.State;
	using Tartaros.Map.Village;
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

		private Village _OnCaptureVillageUnlockPower = null;
		private GamemodeManager _gameModeManager = null;
		private UserErrorsLogger _userErrorsLogger = null;
		private IPlayerGloryWallet _gloryWallet = null;
		private bool _villageIsCaptured = false;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_gameModeManager = Services.Instance.Get<GamemodeManager>();
			_userErrorsLogger = Services.Instance.Get<UserErrorsLogger>();
			_gloryWallet = Services.Instance.Get<IPlayerGloryWallet>();
			_OnCaptureVillageUnlockPower = FindObjectOfType<Village>();
		}

		private void OnEnable()
		{
			if(_OnCaptureVillageUnlockPower != null)
			{
				_OnCaptureVillageUnlockPower.VillageCaptured -= VillageCaptured;
				_OnCaptureVillageUnlockPower.VillageCaptured += VillageCaptured;
			}
			else
			{
				Debug.LogWarning("there is no Village to unlock on the map");
			}
		}

		private void VillageCaptured(object sender, Village.VillageCapturedArgs e)
		{
			_villageIsCaptured = true;
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

		public bool IsAVillageToCaptureOnTheScene()
		{
			return _OnCaptureVillageUnlockPower != null;
		}

		public bool IsVillageCaptured()
		{
			return _villageIsCaptured;
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