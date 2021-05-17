namespace Tartaros.Construction
{
	using System.Collections;
	using UnityEngine;

	public class GateChangeMaterialEffect : MonoBehaviour, IGateEffect
	{
		[SerializeField] private GameObject _forceField = null;

		void IGateEffect.GateClose()
		{
			_forceField.SetActive(true);
		}

		void IGateEffect.GateOpen()
		{
			_forceField.SetActive(false);
		}
	}
}