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
		private NeigboorWallManager _neigboorManager = null;

		public BuildingPreview(IConstructable toBuild, Vector3 positionToInstancate)
		{
			GameObject buildingPreview = GameObject.Instantiate(toBuild.PreviewPrefab, positionToInstancate, Quaternion.identity);
			_toBuild = toBuild;
			_isWallPreview = toBuild.IsWall;
			_buildingPreview = buildingPreview;
		}

		public void SetBuildingPreviewPosition(Vector3 position)
		{
			if (_isWallPreview)
			{
				GameObject objectUnderCursor = MouseHelper.GetGameObjectUnderCursor();

				if (objectUnderCursor != null
					&& objectUnderCursor.TryGetComponentInParent(out Entity entity)
					&& entity.EntityData.TryGetBehaviour<EntityConstructableData>(out EntityConstructableData data))
				{
					IConstructable constructable = entity.EntityData.GetBehaviour<EntityConstructableData>() as IConstructable;

					if (constructable == _toBuild)
					{
						_buildingPreview.transform.position = MouseHelper.GetGameObjectUnderCursor().transform.position;
						_neigboorManager = entity.gameObject.GetComponentInParent<NeigboorWallManager>();
						return;
					}
				}
			}
			_neigboorManager = null;
			_buildingPreview.transform.position = position;

		}

		public Vector3 GetBuildingPreviewPosition()
		{
			return _buildingPreview.transform.position;
		}

		public NeigboorWallManager GetNeigboorManager()
		{
			return _neigboorManager;
		}

		public GameObject GetObjectUnderCursor()
		{
			GameObject objectUnderCursor = MouseHelper.GetGameObjectUnderCursor();
			if (objectUnderCursor != null && objectUnderCursor.TryGetComponentInParent(out Entity entity))
			{
				return entity.gameObject;
			}
			Debug.LogError("There is no entity to return");
			return null;
		}


		public void DestroyMethod()
		{
			GameObject.Destroy(_buildingPreview);
		}
	}

}