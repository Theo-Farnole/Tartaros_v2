namespace Tartaros.Map
{
	using Sirenix.OdinInspector;
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Selection;
	using UnityEngine;

	public class SectorOutline : MonoBehaviour, ISelectionEffect
	{
		#region Fields
		private const string EDITOR_GROUP_COLORS = "Colors";

		[SerializeField]
		private LineRenderer _lineRenderer = null;

		[SerializeField]
		private Sector _sector = null;

		[FoldoutGroup(EDITOR_GROUP_COLORS)]
		[SerializeField]
		private Color _selectedOutlineColor = Color.magenta;

		[FoldoutGroup(EDITOR_GROUP_COLORS)]
		[SerializeField]
		private Color _capturedOutlineColor = Color.red;

		[FoldoutGroup(EDITOR_GROUP_COLORS)]
		[SerializeField]
		private Color _uncapturedOutlineColor = Color.grey;
		#endregion Fields

		#region Methods		
		private void Start()
		{
			SetupLinePoints();
			SetUnselectedColor();
		}

		void ISelectionEffect.OnSelected()
		{
			SetSelectedColor();
		}

		void ISelectionEffect.OnUnselected()
		{
			SetUnselectedColor();
		}

		private void SetSelectedColor()
		{
			_lineRenderer.SetColor(_selectedOutlineColor);
		}

		private void SetUnselectedColor()
		{
			if (_sector.IsCaptured == true)
			{
				_lineRenderer.SetColor(_capturedOutlineColor);
			}
			else
			{
				_lineRenderer.SetColor(_uncapturedOutlineColor);
			}
		}

		private void SetupLinePoints()
		{
			Vector3[] positions = _sector.GetPointsWrappedSnappedToGround()
				.Select(x => x + Vector3.up * 0.1f)
				.ToArray();

			_lineRenderer.positionCount = positions.Length;
			_lineRenderer.SetPositions(positions);
		}
		#endregion Methods
	}
}
