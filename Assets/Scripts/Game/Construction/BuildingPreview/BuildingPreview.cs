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

        public BuildingPreview(IConstructable toBuild, Vector3 positionToInstancate)
        {
            GameObject buildingPreview = GameObject.Instantiate(toBuild.PreviewPrefab, positionToInstancate, Quaternion.identity);
            _toBuild = toBuild;
            _isWallPreview = toBuild.IsWall;
            _buildingPreview = buildingPreview;
        }

        public void SetBuildingPreviewPosition(Vector3 position)
        {
			//if (_isWallPreview)
			//{
			//	GameObject objectUnderCursor = MouseHelper.GetGameObjectUnderCursor();

   //             if(objectUnderCursor != null)
			//	{
			//	    IConstructable constructable = objectUnderCursor.GetComponent<Entity>().EntityData.GetBehaviour<EntityConstructableData>() as IConstructable;

   //                 Debug.Log(_isWallPreview);

   //                 if (constructable == _toBuild)
   //                 {
   //                     _buildingPreview.transform.position = MouseHelper.GetGameObjectUnderCursor().transform.position;

   //                 }
   //                 else
   //                 {
   //                     _buildingPreview.transform.position = position;
   //                 }
   //             }
			//	else
			//	{
   //                 _buildingPreview.transform.position = position;
   //             }
			//}
			//else
			//{
                _buildingPreview.transform.position = position;
           // }
        }

        public Vector3 GetBuildingPreviewPosition()
        {
            return _buildingPreview.transform.position;
        }


        public void DestroyMethod()
        {
            GameObject.Destroy(_buildingPreview);
        }
    }

}