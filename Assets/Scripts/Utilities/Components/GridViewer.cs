namespace Tartaros
{
	using UnityEngine;

	public class GridViewer : MonoBehaviour
	{
		[SerializeField] private float _cellSize = 3;
		[SerializeField] private float _gridLenght = 250;
		[SerializeField] private Color _gridColor = Color.yellow;

		private void OnDrawGizmos()
		{
			Gizmos.color = _gridColor;

			int cellsCountOnEdge = Mathf.RoundToInt(_gridLenght / _cellSize);

			for (int i = 0; i < cellsCountOnEdge + 1; i++)
			{
				// horizontal line
				Vector3 p1 = transform.position + new Vector3(_cellSize * i, 0, 0);
				Vector3 p2 = transform.position + new Vector3(_cellSize * i, 0, _cellSize * cellsCountOnEdge);

				Gizmos.DrawLine(p1, p2);

				// vertical line
				p1 = transform.position + new Vector3(0, 0, _cellSize * i);
				p2 = transform.position + new Vector3(_cellSize * cellsCountOnEdge, 0, _cellSize * i);

				Gizmos.DrawLine(p1, p2);
			}
		}
	}
}