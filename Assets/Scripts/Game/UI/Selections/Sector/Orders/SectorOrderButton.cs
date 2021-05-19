namespace Tartaros.UI.Sectors.Orders
{
	using Tartaros.UI;
	using UnityEngine;
	using UnityEngine.UI;

	public class SectorOrderButton : AButtonActionAttacher
	{
		#region Fields
		private SectorOrder _sectorOrder = null;
		#endregion Fields

		#region Properties
		public SectorOrder SectorOrder
		{
			get => _sectorOrder;

			set
			{
				_sectorOrder = value;

				if (Label != null)
				{
					Label.text = _sectorOrder?.ButtonLabel ?? "MISSING ORDER";
				}
				else
				{
					Debug.LogWarning("Missing label on sector order.", this);
				}
			}
		}
		#endregion Properties

		#region Methods
		private void Update()
		{
			// TODO TF: Arf, this is very ugly. Find another way to active or desactive the button.
			gameObject.SetActive(_sectorOrder != null && _sectorOrder.IsAvailable);
		}

		protected override void OnButtonClick()
		{			
			_sectorOrder.Execute();
		}
		#endregion Methods
	}
}
