namespace Tartaros.Map
{
	using Sirenix.OdinInspector;
	using System.Collections.Generic;
	using System.Linq;
    using Tartaros.Sectors;
    using Tartaros.Selection;
	using UnityEngine;

	public class SectorOutline : MonoBehaviour, ISelectionEffect
	{
		#region Fields
		private const string EDITOR_GROUP_COLORS = "Colors";

		[SerializeField]
		private float _outlineHeightOffset = 0.1f;

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
		
		private bool _selected = false;
		#endregion Fields

		#region Methods		
		private void Start()
		{
			SetupLinePoints();
			SetUnselectedColor();
		}

		private void OnEnable()
		{
			_sector.Captured -= OnSectorCaptured;
			_sector.Captured += OnSectorCaptured;
		}

		private void OnSectorCaptured(object sender, CapturedArgs e)
		{
			UpdateColor();
		}

		private void UpdateColor()
		{
			if (_selected == true)
			{
				SetSelectedColor();
			}
			else
			{
				SetUnselectedColor();
			}
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
				.Select(x => x + Vector3.up * _outlineHeightOffset)
				.ToArray();

			_lineRenderer.positionCount = positions.Length;
			_lineRenderer.SetPositions(positions);
		}

		void ISelectionEffect.OnSelected()
		{
			SetSelectedColor();

			// TODO TF: (refactor) it's strange to have boolean; we should get the selectable of ISelectionEffect
			_selected = true;
		}

		void ISelectionEffect.OnUnselected()
		{
			SetUnselectedColor();
			_selected = false;
		}
		#endregion Methods
	}
}
