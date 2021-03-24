﻿namespace Tartaros.Construction
{
    using System.Collections;
    using UnityEngine;


    public class BuildingPreview
    {
        private GameObject _buildingPreview = null;

        public BuildingPreview(IConstructable toBuild, Vector3 positionToInstancate)
        {
            GameObject buildingPreview = GameObject.Instantiate(toBuild.PreviewPrefab, positionToInstancate, Quaternion.identity);

            _buildingPreview = buildingPreview;
        }

        public void SetBuildingPreviewPosition(Vector3 position)
        {
            _buildingPreview.transform.position = position;

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