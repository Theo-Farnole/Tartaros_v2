namespace Tartaros.Construction
{
	using System.Collections;
	using System.Collections.Generic;
	using Tartaros.Entities;
	using Tartaros.UI;
	using UnityEngine;
	using UnityEngine.AI;

	public class BuildingPreview
	{
		private GameObject _buildingPreview = null;
		private bool _isWallPreview = false;
		private EntityNeigboorWallManager _neigboorManager = null;
		private CheckObjectUnderCursorManager _objectUnderCursorManager = null;
		private IConstructable _toBuild = null;
		private Vector2[] _pointsToCheck = null;

		public BuildingPreview(IConstructable toBuild, Vector3 positionToInstancate)
		{
			GameObject buildingPreview = GameObject.Instantiate(toBuild.PreviewPrefab, positionToInstancate, Quaternion.identity);

			_toBuild = toBuild;
			_isWallPreview = toBuild.IsWall;
			_buildingPreview = buildingPreview;
			_objectUnderCursorManager = new CheckObjectUnderCursorManager(toBuild);
			_pointsToCheck = GetPointToCheckTheConstructionViability();
		}

		public void SetBuildingPreviewPosition(Vector3 position)
		{
			if (_isWallPreview)
			{
				if (_objectUnderCursorManager.IsTheSameConstructable())
				{
					_buildingPreview.transform.position = MouseHelper.GetGameObjectUnderCursor().transform.position;
					_neigboorManager = _objectUnderCursorManager.GetEntityUnderCursor().gameObject.GetComponentInParent<EntityNeigboorWallManager>();
					return;
				}
			}
			_neigboorManager = null;
			_buildingPreview.transform.position = position;
		}



		public Vector3 GetBuildingPreviewPosition()
		{
			return _buildingPreview.transform.position;
		}

		public EntityNeigboorWallManager GetNeigboorManager()
		{
			return _neigboorManager;
		}

		public GameObject GetObjectUnderCursor()
		{
			return _objectUnderCursorManager.GetObjectUnderCursor();
		}

		public bool IsConstructableHere()
		{
			RaycastHit mousePosition;
			MouseHelper.GetHitUnderCursor(out mousePosition);

			foreach (Vector2 position in _pointsToCheck)
			{
				float buildingPosX = _buildingPreview.transform.position.x - _toBuild.Size.x / 2;
				float buildingPosZ = _buildingPreview.transform.position.z - _toBuild.Size.y / 2;
				Vector3 positionV3 = new Vector3(position.x + buildingPosX, 1, position.y + buildingPosZ);


				RaycastHit hit;

				if (Physics.Raycast(positionV3, Vector3.down, out hit, Mathf.Infinity, NavMesh.AllAreas))
				{
					Debug.DrawRay(positionV3, Vector3.down * 10, Color.yellow);
					if (NavMeshHelper.IsPositionOnNavMesh(hit.point) == false)
					{

						if (_isWallPreview == true)
						{
							if (_objectUnderCursorManager.IsTheSameConstructable() == false)
							{
								return false;
							}
						}
						else
						{
							return false;
						}
					}
				}
				else
				{
					return false;
				}
			}
			return true;
		}

		private Vector2[] GetPointToCheckTheConstructionViability()
		{
			float previewWidght = _toBuild.Size.y - 1f;
			float previewLenght = _toBuild.Size.x - 1f;
			List<Vector2> output = new List<Vector2>();

			//center
			output.Add(new Vector2(previewWidght / 2, previewLenght / 2));
			//bottomLeft
			output.Add(Vector2.zero);
			//topRight
			output.Add(new Vector2(previewWidght, previewLenght));
			//bottomRight
			output.Add(new Vector2(previewWidght, 0));
			//topLeft
			output.Add(new Vector2(0, previewLenght));
			//centerLeft
			output.Add(new Vector2(0, previewLenght / 2));
			//centerUp
			output.Add(new Vector2(previewWidght / 2, previewLenght));
			//centerRight
			output.Add(new Vector2(previewWidght, previewLenght / 2));
			//centerBottom
			output.Add(new Vector2(previewWidght / 2, 0));

			return output.ToArray();
		}
		public void DestroyMethod()
		{
			GameObject.Destroy(_buildingPreview);
		}
	}

}