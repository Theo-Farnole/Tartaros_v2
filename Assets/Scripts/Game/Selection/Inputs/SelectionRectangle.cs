namespace Tartaros.Selection
{
	using System.Linq;
	
	using UnityEngine;
	using UnityEngine.InputSystem;

	public class SelectionRectangle : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private Color _backgroundColor = new Color(0.8f, 0.8f, 0.95f, 0.25f);

		[SerializeField]
		private Color _borderColor = new Color(0.8f, 0.8f, 0.95f);

		[SerializeField]
		private float _borderThickness = 2;

		private Vector2 _positionOne = Vector2.zero;
		private Vector2 _positionTwo = Vector2.zero;
		#endregion Fields

		#region Properties
		public Vector2 PositionOne { get => _positionOne; set => _positionOne = value; }
		public Vector2 PositionTwo { get => _positionTwo; set => _positionTwo = value; }
		public Bounds SelectionRect => GUIRectDrawer.GetViewportBounds(Camera.main, _positionOne, _positionTwo);
		#endregion Properties

		#region Methods
		public void OnGUI()
		{
			Rect rect = GUIRectDrawer.GetScreenRect(_positionOne, _positionTwo);

			GUIRectDrawer.DrawScreenRect(rect, _backgroundColor);
			GUIRectDrawer.DrawScreenRectBorder(rect, _borderThickness, _borderColor);
		}

		public ISelectable[] GetSelectablesInRectangle()
		{
			ISelectable[] selectablesInGame = GetAllSelectablesInWorld();
			ISelectable[] selectablesInViewport = SelectionHelper.KeepSelectablesInRectangle(selectablesInGame, SelectionRect);

			return selectablesInViewport;
		}

		private ISelectable[] GetAllSelectablesInWorld()
		{
			return ObjectsFinder.FindObjectsOfInterface<ISelectable>();
		}

				
		#endregion Methods
	}
}
