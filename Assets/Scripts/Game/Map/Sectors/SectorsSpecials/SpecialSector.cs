namespace Tartaros.Map
{
	using System.Collections;
	using System.Globalization;
	using Tartaros.ServicesLocator;
	using Tartaros.UI.Sectors.Orders;
	using UnityEngine;

	[RequireComponent(typeof(SpecialSectorIncome))]
	public class SpecialSector : MonoBehaviour, ISectorUIStylizer
	{
		public enum God
		{
			Hephaistos,
			Poseidon
		}

		#region Fields
		[SerializeField] private God _godSector = God.Hephaistos;

		private SpecialSectorIncome _specialSectorIncome = null;

		// SERVICES
		private UIStyles _uiStyles = null;
		#endregion Fields

		#region Properties
		public SpecialSectorIncome SpecialSectorIncome => _specialSectorIncome;
		public string SectorGodName => _godSector.ToString();
		SectorStyle ISectorUIStylizer.SectorStyle
		{
			get
			{
				switch (_godSector)
				{
					case God.Hephaistos:
						return _uiStyles.SectorStyles.Hephaistos;

					case God.Poseidon:
						return _uiStyles.SectorStyles.Poseidon;

					default:
						throw new System.NotImplementedException();
				}

			}
		}
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_uiStyles = Services.Instance.Get<UIStyles>();
		}

		private void OnEnable()
		{
			_specialSectorIncome = GetComponent<SpecialSectorIncome>();

			if (_specialSectorIncome == null)
			{
				Debug.LogErrorFormat("there is no SpecialSectorIncome on sector {0}", this.gameObject);
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawIcon(transform.position, GetIconName());
		}

		private string GetIconName()
		{
			switch (_godSector)
			{
				case God.Hephaistos:
					return "anvil-impact";

				case God.Poseidon:
					return "trident";

				default:
					throw new System.NotImplementedException();
			}
		}
		#endregion Methods
	}
}