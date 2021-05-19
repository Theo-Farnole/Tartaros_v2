namespace Tartaros.UI.HoverPopup
{
	using Sirenix.OdinInspector;
	using Sirenix.Serialization;
	using Tartaros.Economy;
	using UnityEngine;

	[System.Serializable]
	public class HoverPopupData
	{
		#region Fields
		private const string COOLDOWN_FORMAT = "{0}s";

		[SerializeField] private string _name = "Lorem ipsum";
		[SerializeField] private string _description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
		[SerializeField] private string _loreDescription = "";

		[OdinSerialize] private ISectorResourcesWallet _sectorResourcesCost = null;

		[SerializeField] private int _favorCost = 0;
		[SerializeField] private float _cooldown = 0;
		[SerializeField] private bool _hasHotkey = false;

		[ShowIf(nameof(_hasHotkey))] [SerializeField] private KeyCode _hotkey = KeyCode.A;
		#endregion Fields

		#region Properties
		[ShowInInspector] public bool HasName => !string.IsNullOrEmpty(_name);
		public string Name => _name;
		[ShowInInspector] public bool HasDescription => !string.IsNullOrEmpty(_description);
		public string Description => _description;
		[ShowInInspector] public bool HasCooldown => _cooldown != 0;
		public string CooldownFormated => string.Format(COOLDOWN_FORMAT, _cooldown);
		public float CooldownInSeconds { set => _cooldown = value; }
		[ShowInInspector] public bool HasCost => HasFavorCost || HasSectorResourcesCost;
		public ISectorResourcesWallet SectorResourcesCost
		{
			set
			{
				if (HasFavorCost) throw new System.NotSupportedException("Cannot set a sector resources cost while there is already a glory cost.");

				_sectorResourcesCost = value;
			}
		}
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

		public bool HasHotkey => _hasHotkey;
		public string Hotkey => _hotkey.ToString();

		public bool HasLoreDescription => !string.IsNullOrEmpty(_loreDescription);
		public string LoreDescription => _loreDescription;

		private bool HasFavorCost => _favorCost != 0;
		private bool HasSectorResourcesCost => _sectorResourcesCost != null;
		#endregion Properties

		#region Ctor
		public HoverPopupData(HoverPopupData hoverPopupData)
		{
			_name = hoverPopupData._name;
			_description = hoverPopupData._description;
			_loreDescription = hoverPopupData._loreDescription;
			_sectorResourcesCost = hoverPopupData._sectorResourcesCost;
			_favorCost = hoverPopupData._favorCost;
			_cooldown = hoverPopupData._cooldown;
			_hasHotkey = hoverPopupData._hasHotkey;
			_hotkey = hoverPopupData._hotkey;
		}
		#endregion Ctor
	}
}
