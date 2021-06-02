namespace Tartaros.Powers
{
	using Sirenix.OdinInspector;
	using System.Collections.Generic;
	using Tartaros.Economy;
	using Tartaros.Gamemode;
	using Tartaros.Gamemode.State;
	using Tartaros.Map.Village;
	using Tartaros.ServicesLocator;
	using UnityEngine;
	using UnityEngine.Rendering;

	public partial class PowerManager : MonoBehaviour
	{
		#region Fields
		// TODO TF: extract settings fields into a ScriptableObject
		[Title("Settings")]
		[SerializeField] private List<Power> _unlockedPowers = new List<Power>() { Power.LightningBolt };

		[Title("Prefabs References")]
		[SerializeField, AssetsOnly] private GameObject _previewPrefab = null;
		[Space]
		[SerializeField, AssetsOnly] private GameObject _lightningBoltPrefab = null;
		[SerializeField, AssetsOnly] private GameObject _controlledAoEPrefab = null;

		private Dictionary<Power, GameObject> _powersPrefab = null;

		// SERVICES
		private GamemodeManager _gameModeManager = null;
		private UserErrorsLogger _userErrorsLogger = null;
		private IPlayerGloryWallet _gloryWallet = null;
		#endregion Fields

		#region Properties
		public GameObject PreviewPrefab => _previewPrefab;
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_gameModeManager = Services.Instance.Get<GamemodeManager>();
			_userErrorsLogger = Services.Instance.Get<UserErrorsLogger>();
			_gloryWallet = Services.Instance.Get<IPlayerGloryWallet>();

			_powersPrefab = new Dictionary<Power, GameObject>()
			{
				{ Power.LightningBolt, _lightningBoltPrefab },
				{ Power.ControlledAoE, _controlledAoEPrefab }
			};
		}

		public int GetGloryPrice(Power power)
		{
			return _powersPrefab[power].GetComponent<IPower>().Price;
		}

		public void UnlockAllPowers()
		{
			foreach (Power power in EnumHelper.GetValues<Power>())
			{
				if (IsPowerUnlock(power))
				{
					UnlockPower(power);
				}
			}
		}

		public bool IsPowerUnlock(Power power)
		{
			return _unlockedPowers.Contains(power);
		}

		public void UnlockPower(Power power)
		{
			if (power == Power.None) return;

			bool addSuccesful = _unlockedPowers.TryAddWithoutDuplicate(power);

			if (addSuccesful == true)
			{
				Debug.LogFormat("Power {0} unlocked.", power.ToString());
			}
			else
			{
				Debug.LogError("Cannot unlock power {0}.".Format(power.ToString()));
			}
		}

		public void CastLightningBolt() => Cast(Power.LightningBolt);
		public void CastControlledAoE() => Cast(Power.ControlledAoE);

		public void Cast(Power power)
		{
			if (CanCastSpell(power) == true)
			{
				IPower powerPrefab = _powersPrefab[power].GetComponent<IPower>();
				_gameModeManager.SetState(new PowerState(_gameModeManager, powerPrefab));
			}
		}

		private bool CanCastSpell(Power power, bool verbose = true)
		{
			if (_unlockedPowers.Contains(power) == false)
			{
				if (verbose == true)
				{
					_userErrorsLogger.Log("Power {0} is not locked. Capture a village first!", power.ToString());
				}

				return false;
			}

			if (_gloryWallet.CanSpend(GetGloryPrice(power)) == false)
			{
				if (verbose == true)
				{
					_userErrorsLogger.Log("Missing glory to cast power.");
				}

				return false;
			}

			return true;
		}

		#endregion Methods
	}
}