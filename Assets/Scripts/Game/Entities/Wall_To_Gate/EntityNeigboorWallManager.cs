namespace Tartaros.Entities
{
	using Boo.Lang;
	using System.Collections;
	using System.Linq;
	using Tartaros.Construction;
	using Tartaros.UI;
	using UnityEngine;

	public class EntityNeigboorWallManager : MonoBehaviour
	{
		private bool _security = false;
		private IConstructable _constructable = null;


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
			_constructable = GetComponent<Entity>().EntityData.GetBehaviour<EntityConstructableData>() as IConstructable;
			CheckIsNeigboorhood();

			_security = true;
		}

		private void GetNeighbourWallBack()
		{
			var entity = RayHitEntity(Vector3.back);

			if (entity != null)
			{
				_backAdjacentWall = entity;

				if (_security == false)
				{
					entity.gameObject.GetComponent<EntityNeigboorWallManager>().CheckIsNeigboorhoodSecurity();
				}
			}
			else
			{
				return;
			}
		}
		private void GetNeighbourWallBackSecurity()
		{
			var entity = RayHitEntity(Vector3.back);

			if (entity != null)
			{
				_backAdjacentWall = entity;
			}
			else
			{
				return;
			}
		}
		private void GetNeigboorWallFront()
		{
			var entity = RayHitEntity(Vector3.forward);

			if (entity != null)
			{
				if (entity.gameObject.name.All(char.IsDigit) == true)
				{
					Debug.Break();
				}

				_frontAdjacentWall = entity;
				if (_security == false)
				{
					entity.gameObject.GetComponent<EntityNeigboorWallManager>().CheckIsNeigboorhoodSecurity();
				}
			}
			else
			{
				return;
			}
		}
		private void GetNeigboorWallFrontSecurity()
		{
			var entity = RayHitEntity(Vector3.forward);

			if (entity != null)
			{
				if (entity.gameObject.name.All(char.IsDigit) == true)
				{
					Debug.Break();
				}

				_frontAdjacentWall = entity;
			}
			else
			{
				return;
			}
		}
		private void GetNeighbourWallRight()
		{
			var entity = RayHitEntity(Vector3.right);

			if (entity != null)
			{
				_rightAdjacecntWall = entity;
				if (_security == false)
				{
					entity.gameObject.GetComponent<EntityNeigboorWallManager>().CheckIsNeigboorhoodSecurity();
				}
			}
			else
			{
				return;
			}
		}
		private void GetNeighbourWallRightSecurity()
		{
			var entity = RayHitEntity(Vector3.right);

			if (entity != null)
			{
				_rightAdjacecntWall = entity;
			}
			else
			{
				return;
			}
		}
		private void GetNeighbourWallLeft()
		{
			var entity = RayHitEntity(Vector3.left);
			if (entity != null)
			{
				_leftAdjacentWall = entity;

				if (_security == false)
				{
					entity.gameObject.GetComponent<EntityNeigboorWallManager>().CheckIsNeigboorhoodSecurity();
				}
			}
			else
			{
				return;
			}
		}
		private void GetNeighbourWallLeftSecurity()
		{
			var entity = RayHitEntity(Vector3.left);
			if (entity != null)
			{
				_leftAdjacentWall = entity;
			}
			else
			{
				return;
			}
		}

		private Entity RayHitEntity(Vector3 direction)
		{
			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, 2.6f)
				&& hit.transform.gameObject.GetComponentInParent<Entity>().EntityData.TryGetBehaviour<EntityConstructableData>(out EntityConstructableData data))
			{
				IConstructable constructable = hit.transform.gameObject.GetComponentInParent<Entity>().EntityData.GetBehaviour<EntityConstructableData>() as IConstructable;
				var wallNeighbour = hit.transform.gameObject.GetComponentInParent<EntityNeigboorWallManager>();

				if (wallNeighbour != null && _constructable == constructable)
				{
					return hit.transform.gameObject.GetComponentInParent<Entity>();
				}
			}
			return null;
		}

		public void CheckIsNeigboorhoodSecurity()
		{
			GetNeighbourWallLeftSecurity();
			GetNeighbourWallRightSecurity();
			GetNeigboorWallFrontSecurity();
			GetNeighbourWallBackSecurity();
		}

		public void CheckIsNeigboorhood()
		{
			GetNeighbourWallBack();
			GetNeigboorWallFront();
			GetNeighbourWallLeft();
			GetNeighbourWallRight();
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
				if (entity != null)
				{
					number++;
				}
			}

			return number;
		}
	}
}