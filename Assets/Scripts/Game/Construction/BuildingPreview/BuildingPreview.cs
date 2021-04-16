namespace Tartaros.Construction
{
	using System.Collections;
	using Tartaros.Entities;
	using Tartaros.UI;
	using UnityEngine;


	public class BuildingPreview
	{
		private GameObject _buildingPreview = null;
		private bool _isWallPreview = false;
		private IConstructable _toBuild = null;
		private bool _isSnaped = false;
		private EntityNeigboorWallManager _neigboorManager = null;
		private CheckObjectUnderCursorManager _objectUnderCursorManager = null;

		public BuildingPreview(IConstructable toBuild, Vector3 positionToInstancate)
		{
			GameObject buildingPreview = GameObject.Instantiate(toBuild.PreviewPrefab, positionToInstancate, Quaternion.identity);
			_toBuild = toBuild;
			_isWallPreview = toBuild.IsWall;
			_buildingPreview = buildingPreview;
			_objectUnderCursorManager = new CheckObjectUnderCursorManager(toBuild);
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


		public void DestroyMethod()
		{
			GameObject.Destroy(_buildingPreview);
		}
	}

}