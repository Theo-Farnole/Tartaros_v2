namespace Tartaros.UI.Sectors.Orders
{
	using System;
	using UnityEngine;
	using UnityEngine.UI;

	[Serializable]
	public class SectorStyle
	{
		#region Fields
		[SerializeField] private Sprite _icon = null;
		[SerializeField] private Sprite _background = null;
		[SerializeField] private Sprite _buttonDefault = null;
		[SerializeField] private SpriteState _buttonTransition = new SpriteState(); 
		#endregion Fields

		#region Properties
		public Sprite Icon { get => _icon; set => _icon = value; }
		public Sprite Background { get => _background; set => _background = value; }
		public Sprite ButtonDefault { get => _buttonDefault; set => _buttonDefault = value; }
		public SpriteState ButtonTransition { get => _buttonTransition; set => _buttonTransition = value; }
		#endregion Properties

		#region Ctor
		public SectorStyle(SectorStyle toCopy) : this(toCopy._icon, toCopy._background, toCopy._buttonDefault, toCopy._buttonTransition)
		{ }

		public SectorStyle(Sprite icon, Sprite background, Sprite buttonDefault, SpriteState buttonTransition)
		{
			_icon = icon;
			_background = background;
			_buttonDefault = buttonDefault;
			_buttonTransition = buttonTransition;
		}
		#endregion Ctor
	}
}
