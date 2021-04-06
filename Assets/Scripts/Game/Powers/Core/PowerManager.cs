namespace Tartaros.Power
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Tartaros.Gamemode;
	using Tartaros.ServicesLocator;
	using Tartaros.Gamemode.State;
	using Sirenix.OdinInspector;

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
		#endregion Fields


		#region Methods
		private void Awake()
		{
			Services.Instance.RegisterService(this);
		}

		private void Start()
		{
			_gameModeManager = Services.Instance.Get<GamemodeManager>();
			_userErrorsLogger = Services.Instance.Get<UserErrorsLogger>();
		}

		public bool CanCastSpell(IPower power)
		{
			return true;
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
				_userErrorsLogger.Log("Cannot cast spell {0}.", power.ToString());
			}
		}
		#endregion Methods
	}
}