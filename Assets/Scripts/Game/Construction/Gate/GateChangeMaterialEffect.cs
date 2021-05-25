namespace Tartaros.Construction
{
	using System.Collections;
	using UnityEngine;

	public class GateChangeMaterialEffect : MonoBehaviour, IGateEffect
	{
		[SerializeField] private GameObject _forceField = null;

		void IGateEffect.GateClose()
		{
			Debug.Log("Close");
			_forceField.SetActive(true);
		}

		void IGateEffect.GateOpen()
		{
			Debug.Log("Open");
			_forceField.SetActive(false);
		}
	}
}