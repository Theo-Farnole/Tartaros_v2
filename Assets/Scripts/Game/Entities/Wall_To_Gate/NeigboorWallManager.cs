namespace Tartaros.Entities
{
	using System.Collections;
	using UnityEngine;

	public class NeigboorWallManager : MonoBehaviour
	{
		[SerializeField]
		private Entity _previousAdjacentWall = null;
		[SerializeField]
		private Entity _nextAdjacentWall = null;
		[SerializeField]
		private Entity _rightAdjacecntWall = null;
		[SerializeField]
		private Entity _leftAdjacentWall = null;

		public Entity PreviousAdjacentWall => _previousAdjacentWall;
		public Entity NextAdjacentWall { get => _nextAdjacentWall; set => _nextAdjacentWall = value; }
		public Entity RightAdjacentWall => _rightAdjacecntWall;
		public Entity LeftAdjacentWall => _leftAdjacentWall;

		private void Start()
		{
			GetNeighbourWallFrontAndBack();
			GetNeighbourWallLeft();
			GetNeighbourWallRight();
		}


		private void GetNeighbourWallFrontAndBack()
		{

			var entity = RayHitEntity(Vector3.back);

			if (entity != null)
			{
				_previousAdjacentWall = entity;

				entity.gameObject.GetComponent<NeigboorWallManager>().NextAdjacentWall = gameObject.GetComponent<Entity>();
			}
			else
			{
				//Debug.LogError("there is no adjacentWall detected");
				return;
			}
		}

		private void GetNeighbourWallRight()
		{
			var entity = RayHitEntity(Vector3.right);

			if (entity != null)
			{
				_rightAdjacecntWall = entity;
			}
			else
			{
				//Debug.LogError("there is no adjacentWall detected");
				return;
			}
		}

		private void GetNeighbourWallLeft()
		{
			var entity = RayHitEntity(Vector3.left);

			if (entity != null)
			{
				_leftAdjacentWall = entity;
			}
			else
			{
				//Debug.LogError("there is no adjacentWall detected");
				return;
			}
		}

		private Entity RayHitEntity(Vector3 direction)
		{
			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, 5))
			{
				return hit.transform.gameObject.GetComponentInParent<Entity>();
			}
			return null;
		}
	}
}