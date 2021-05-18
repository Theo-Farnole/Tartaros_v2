namespace Tartaros.Map
{
	using System.Collections;
	using System.Globalization;
	using UnityEngine;

	[RequireComponent(typeof(SpecialSectorIncome))]
	public class SpecialSector : MonoBehaviour
	{
		private enum God
		{
			Hephaistos,
			Poseïdon
		}

		[SerializeField] private God _godSector = God.Hephaistos;

		private SpecialSectorIncome _specialSectorIncome = null;

		public SpecialSectorIncome SpecialSectorIncome => _specialSectorIncome;
		public string SectorGodName => _godSector.ToString();

		private void OnEnable()
		{
			_specialSectorIncome = GetComponent<SpecialSectorIncome>();

			if(_specialSectorIncome == null)
			{
				Debug.LogErrorFormat("there is no SpecialSectorIncome on sector {0}", this.gameObject);
			}
		}
	}
}