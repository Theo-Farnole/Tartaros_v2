namespace Tartaros.Construction
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class WallBuildingPreview
    {
        private GameObject _buildingPreview = null;
        private List<GameObject> _buildingsPreview = new List<GameObject>();
        private Vector3 _startPosition = Vector3.zero;
        private IConstructable _toBuild = null;

        public float DistanceBetweenInstanciate => _toBuild.Size.y;

        public WallBuildingPreview(IConstructable toBuild, Vector3 startPosition)
        {
            _toBuild = toBuild;
            _buildingPreview = toBuild.PreviewPrefab;
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
        }

        public void GetNumberOfWallSection(Vector3 end, out int numberOfWallSection, out Vector3 direction)
        {
            numberOfWallSection = Mathf.RoundToInt(GetTheDitsanceBetweenTwoPoints(end) / _toBuild.Size.x);
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
            float sectionPercent = _toBuild.Size.x / sectionLength;

            for (int i = 0; i < _buildingsPreview.Count; i++)
            {
                GameObject wallSection = _buildingsPreview[i];
                float interpolation = sectionPercent * i;
                wallSection.transform.position = Vector3.Lerp(_startPosition, end, interpolation);
            }
        }

        public float GetTheDitsanceBetweenTwoPoints(Vector3 end)
        {
            return Vector3.Distance(_startPosition, end);
        }

        public List<GameObject> GetWallBuildingPreview()
        {
            return _buildingsPreview;
        }

        private void AddPreviewWall(GameObject previewToInstanciate)
        {
            _buildingsPreview.Add(previewToInstanciate);
        }

        private void RemovePreviewWall()
        {
            if (_buildingsPreview.Count - 1 > 0)
            {
                GameObject.Destroy(_buildingsPreview[_buildingsPreview.Count - 1]);
                _buildingsPreview.RemoveAt(_buildingsPreview.Count - 1);
            }
        }

        public List<GameObject> GetAllSectionPreview()
        {
            List<GameObject> wallSection = new List<GameObject>(_buildingsPreview);
            int lastIndex = _buildingsPreview.Count - 1;
            wallSection.RemoveAt(lastIndex);
            wallSection.RemoveAt(0);

            return wallSection;
        }



        public List<GameObject> GetAllCornerPreview()
        {
            List<GameObject> wallCorner = new List<GameObject>();
            int lastIndex = _buildingsPreview.Count - 1;

            wallCorner.Add(_buildingsPreview[0]);
            wallCorner.Add(_buildingsPreview[lastIndex]);
            Debug.DrawRay(_buildingsPreview[lastIndex].transform.position, Vector3.up * 5, Color.green, 9999f);

            return wallCorner;
        }
        public void DestroyMehods()
        {
            foreach (GameObject wallSection in _buildingsPreview)
            {
                Debug.Log("delete");
                GameObject.Destroy(wallSection);
            }

			//for (int i = 0; i < _buildingsPreview.Count; i++)
			//{
   //             GameObject.Destroy(_buildingsPreview[_buildingsPreview.Count - 1]);
			//}
        }
    }
}