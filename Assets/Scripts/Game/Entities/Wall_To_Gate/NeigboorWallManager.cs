namespace Tartaros.Entities
{
	using Boo.Lang;
	using System.Collections;
	using UnityEngine;

	public class NeigboorWallManager : MonoBehaviour
	{
		[SerializeField]
		private Entity _backAdjacentWall = null;
		[SerializeField]
		private Entity _frontAdjacentWall = null;
		[SerializeField]
		private Entity _rightAdjacecntWall = null;
		[SerializeField]
		private Entity _leftAdjacentWall = null;

		public Entity BackAdjacentWall => _backAdjacentWall;
		public Entity FrontAdjacentWall { get => _frontAdjacentWall; set => _frontAdjacentWall = value; }
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
				_backAdjacentWall = entity;

				entity.gameObject.GetComponent<NeigboorWallManager>().FrontAdjacentWall = gameObject.GetComponent<Entity>();
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


		public int GetNumberOfNeigboor()
		{
			int number = 0;

			List<Entity> list = new List<Entity>();

			list.Add(FrontAdjacentWall);
			list.Add(BackAdjacentWall);
			list.Add(RightAdjacentWall);
			list.Add(LeftAdjacentWall);

			foreach (var entity in list)
			{
				if(entity != null)
				{
					number++;
				}
			}

			return number;
		}
	}
}