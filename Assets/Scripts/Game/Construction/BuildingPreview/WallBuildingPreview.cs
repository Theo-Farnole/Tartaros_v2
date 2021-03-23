namespace Tartaros.Construction
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class WallBuildingPreview
    {
        private GameObject _buildingPreview = null;
        private List<GameObject> _buildingsPreview = new List<GameObject>();
        private float _distanceBetweenInstanciate = 10f;
        private Vector3 _startPosition = Vector3.zero;
        private IConstructable _toBuild = null;

        public float DistanceBetweenInstanciate  => _toBuild.Size.y; 

        public WallBuildingPreview(IConstructable toBuild, Vector3 startPosition)
        {
            _toBuild = toBuild;
            _buildingPreview = toBuild.ModelPrefab;
            _startPosition = startPosition;
            InstanciatePreview(_startPosition);
        }

        public void CheckLine(Vector3 end)
        {
            int numberOfWallSection;
            Vector3 direction;
            GetNumberOfWallSection(end, out numberOfWallSection, out direction);

            if (numberOfWallSection > _buildingsPreview.Count)
            {
                Vector3 position = _startPosition + (-direction * ((DistanceBetweenInstanciate) * _buildingsPreview.Count));
                InstanciatePreview(position);
            }
            else if (numberOfWallSection < _buildingsPreview.Count)
            {
                RemovePreviewWall();
            }

            SetPositionRotationOfPreviews(end);
            //throw new System.NotImplementedException();
        }

        public void GetNumberOfWallSection(Vector3 end, out int numberOfWallSection, out Vector3 direction)
        {
            numberOfWallSection = Mathf.RoundToInt(GetTheDitsanceBetweenTwoPoints(end) / DistanceBetweenInstanciate);
            Debug.Log(GetTheDitsanceBetweenTwoPoints(end));
            direction = (_startPosition - end).normalized;
        }

        private void InstanciatePreview(Vector3 position)
        {
            GameObject wallInstance = GameObject.Instantiate(_buildingPreview, position, Quaternion.identity);
            AddPreviewWall(wallInstance);
        }

        private void SetPositionRotationOfPreviews(Vector3 end)
        {
            SetPositionOfPreview(end);

            foreach (GameObject wallSection in _buildingsPreview)
            {




                wallSection.transform.LookAt(end);
            }
        }

        private void SetPositionOfPreview(Vector3 end)
        {
            float sectionLength = Vector3.Distance(_startPosition, end);
            float sectionPercent = _buildingsPreview.Count / sectionLength;

            for (int i = 0; i < _buildingsPreview.Count; i++)
            {
                GameObject wallSection = _buildingsPreview[i];
                float interpolation = sectionPercent * i;
                wallSection.transform.position = Vector3.Lerp(_startPosition, end, interpolation);

                Debug.LogFormat("{0} {1}", i, interpolation);
            }
        }

        public float GetTheDitsanceBetweenTwoPoints(Vector3 end)
        {
            return Vector3.Distance(_startPosition, end);
        }

        private void AddPreviewWall(GameObject previewToInstanciate)
        {
            _buildingsPreview.Add(previewToInstanciate);


            //throw new System.NotImplementedException();
        }

        private void RemovePreviewWall()
        {
            if (_buildingsPreview.Count - 1 > 0)
            {
                Debug.Log(_buildingsPreview[_buildingsPreview.Count - 1]);
                GameObject.Destroy(_buildingsPreview[_buildingsPreview.Count - 1]);
                _buildingsPreview.RemoveAt(_buildingsPreview.Count - 1);
            }
            //throw new System.NotImplementedException();
        }

    }
}