namespace Tartaros.FogOfWar
{
	using System.Collections.Generic;
	using Tartaros.Sectors;
	using Tartaros.ServicesLocator;
	using Tartaros.Utilities;
	using UnityEngine;

	public class FogOfWarManager : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private FogOfWarData _data = null;

		private List<IFogVision> _visions = new List<IFogVision>();
		private List<IFogCoverable> _coverables = new List<IFogCoverable>();

		private bool[,] _visibleCells = null;
		private Bounds2D bounds = null;
		private IMap _map = null;
		#endregion Fields

		#region Properties
		public int CellsWidth => Mathf.RoundToInt(bounds.Width / _data.SizePerCell);
		public int CellsHeight => Mathf.RoundToInt(bounds.Height / _data.SizePerCell);
		#endregion Properties

		#region Methods
		#region MonoBehaviour Callbacks
		private void Awake()
		{
			Services.Instance.RegisterService(this);
		}

		private void Start()
		{
			_map = Services.Instance.Get<IMap>();
			bounds = _map.MapBounds;

			_visibleCells = new bool[CellsWidth, CellsHeight];

			SetAllCellsToFalse();
		}

		private void Update()
		{
			UpdateCellsVisibility();
			UpdateCoverablesVisibility();
		}
		#endregion MonoBehaviour Callbacks

		#region Public Methods
		public void AddVision(IFogVision vision)
		{
			if (_visions.Contains(vision) == true)
			{
				Debug.LogErrorFormat("Cannot add fog vision {0}. It is already in visions list.", vision.ToString());
				return;
			}

			_visions.Add(vision);
		}

		public void RemoveVision(IFogVision vision)
		{
			if (_visions.Contains(vision) == false)
			{
				Debug.LogErrorFormat("Cannot remove fog vision {0}. It is not in visions list.", vision.ToString());
				return;
			}

			_visions.Remove(vision);
		}

		public void AddCoverable(IFogCoverable coverable)
		{
			if (_coverables.Contains(coverable) == true)
			{
				Debug.LogErrorFormat("Cannot add fog coverable {0}. It is already in coverables list.", coverable.ToString());
				return;
			}

			_coverables.Add(coverable);
		}

		public void RemoveCoverable(IFogCoverable coverable)
		{
			if (_coverables.Contains(coverable) == false)
			{
				Debug.LogErrorFormat("Cannot remove fog coverable {0}. It is not in coverables list.", coverable.ToString());
				return;
			}

			_coverables.Remove(coverable);
		}

		public bool IsPositionVisible(Vector3 worldPosition)
		{
			foreach (IFogVision vision in _visions)
			{
				if (vision.IsPointVisible(worldPosition) == true)
				{
					return true;
				}
			}

			return false;
		}
		#endregion Public Methods

		#region Private Methods
		private void UpdateCoverablesVisibility()
		{
			foreach (IFogCoverable coverable in _coverables)
			{
				UpdateCoverableVisibility(coverable);
			}
		}

		private void UpdateCoverableVisibility(IFogCoverable coverable)
		{
			coverable.IsCovered = IsCoverableVisible(coverable);
		}

		private bool IsCoverableVisible(IFogCoverable coverable)
		{
			return IsContainableVisible(coverable);
		}

		private bool IsContainableVisible(IContainable containable)
		{
			for (int i = 0; i < _visibleCells.GetLength(0); i++)
			{
				for (int j = 0; j < _visibleCells.GetLength(1); j++)
				{
					Vector3 worldPosition = CellPositionToWorldPosition(i, j);

					if (containable.ContainsPosition(worldPosition))
					{
						return true;
					}
				}
			}

			return false;
		}

		private void UpdateCellsVisibility()
		{
			SetAllCellsToFalse();

			for (int i = 0; i < _visibleCells.GetLength(0); i++)
			{
				for (int j = 0; j < _visibleCells.GetLength(1); j++)
				{
					Vector3 worldPosition = CellPositionToWorldPosition(i, j);
					_visibleCells[i, j] = IsPositionVisible(worldPosition);
				}
			}
		}

		private void SetAllCellsToFalse()
		{
			for (int i = 0; i < _visibleCells.GetLength(0); i++)
			{
				for (int j = 0; j < _visibleCells.GetLength(1); j++)
				{

					_visibleCells[i, j] = false;
				}
			}
		}

		private Vector3 CellPositionToWorldPosition(int x, int y)
		{
			return new Vector3(x * _data.SizePerCell, y * _data.SizePerCell);
		}
		#endregion Private Methods
		#endregion Methods
	}
}
