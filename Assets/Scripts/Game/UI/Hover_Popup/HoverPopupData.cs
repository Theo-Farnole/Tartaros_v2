namespace Tartaros.UI.HoverPopup
{
	using Tartaros.Economy;
	using UnityEngine;

	public class HoverPopupData
	{
		#region Fields
		private const string COOLDOWN_FORMAT = "{0}s";

		[SerializeField]
		private string _name = "Lorem ipsum";

		[SerializeField]
		private string _description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";

		[SerializeField]
		private ISectorResourcesWallet _sectorResourcesCost = null;

		[SerializeField]
		private int _favorCost = 0;

		[SerializeField]
		private float _cooldown = 0;

		[SerializeField]
		private KeyCode _hotkey = KeyCode.A;
		#endregion Fields

		#region Properties
		public string Name => _name;
		public string Description => _description;
		public string Cooldown => string.Format(COOLDOWN_FORMAT, _cooldown);
		public bool HasCost => HasFavorCost || HasSectorResourcesCost;
		public string Cost
		{
			get
			{
				if (HasFavorCost)
				{
					return string.Format("{0} {1}", _favorCost, TartarosTexts.FAVOR);
				}
				else if (HasSectorResourcesCost)
				{
					return _sectorResourcesCost.ToRichTextString();
				}
				else
				{
					throw new System.NotSupportedException("Cannot get the cost. No favor or sector resources cost set.");
				}
			}
		}
		public string Hotkey => _hotkey.ToString();

		private bool HasFavorCost => _favorCost != 0;
		private bool HasSectorResourcesCost => _sectorResourcesCost != null;
		#endregion Properties
	}
}
