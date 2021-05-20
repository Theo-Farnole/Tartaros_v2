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
		[SerializeField] private Color _buttonTextColor = Color.white;
		#endregion Fields

		#region Properties
		public Sprite Icon { get => _icon; set => _icon = value; }
		public Sprite Background { get => _background; set => _background = value; }
		public Sprite ButtonDefault { get => _buttonDefault; set => _buttonDefault = value; }
		public SpriteState ButtonTransition { get => _buttonTransition; set => _buttonTransition = value; }
		public Color ButtonTextColor { get => _buttonTextColor; set => _buttonTextColor = value; }
		#endregion Properties

		#region Ctor
		public SectorStyle(SectorStyle toCopy) : this(toCopy._icon, toCopy._background, toCopy._buttonDefault, toCopy._buttonTransition, toCopy._buttonTextColor)
		{ }

		public SectorStyle(Sprite icon, Sprite background, Sprite buttonDefault, SpriteState buttonTransition, Color buttonTextColor)
		{
			_icon = icon;
			_background = background;
			_buttonDefault = buttonDefault;
			_buttonTransition = buttonTransition;
			_buttonTextColor = buttonTextColor;
		}
		#endregion Ctor
	}
}
