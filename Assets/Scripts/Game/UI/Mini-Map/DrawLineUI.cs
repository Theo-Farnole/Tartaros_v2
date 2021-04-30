namespace Tartaros.UI.MiniMap
{
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class DrawLineUI : MaskableGraphic
    {
        private Vector2Int _gridSize;
        [SerializeField]
        private List<Vector2> _points = null;

        float _width;
        float _height;
        float _unitWidth;
        float _unitHeight;

        public float _thickness = 10f;

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();

            _width = rectTransform.rect.width;
            _height = rectTransform.rect.height;

            _unitWidth = _width / (float)_gridSize.x;
            _unitHeight = _height / (float)_gridSize.y;

            //Debug.Log(_points.Count);
            if (_points.Count < 2)
            {
                return;
            }

            for (int i = 0; i < _points.Count - 1; i++)
            {
                Vector2 point = _points[i];
                float angle = 0f;

                angle = GetAngle(_points[i], _points[i + 1]) + 90f;
                DrawVerticesForPoint(point, vh, angle);

                Vector2 nextPoint = _points[i + 1];
                DrawVerticesForPoint(nextPoint, vh, angle);
            }

            for (int i = 0; i < _points.Count * 2 - 3; i++)
            {
                int index = i * 2;

                vh.AddTriangle(index + 0, index + 1, index + 3);
                vh.AddTriangle(index + 3, index + 2, index + 0);
            }

        }

        public float GetAngle(Vector2 from, Vector2 to)
        {
            return (float)(Mathf.Atan2(_unitHeight * (to.y - from.y), _unitWidth * (to.x - from.x)) * Mathf.Rad2Deg);
        }

        void DrawVerticesForPoint(Vector2 point, VertexHelper vh, float angle)
        {
            UIVertex vertex = UIVertex.simpleVert;
            vertex.color = color;

            vertex.position = Quaternion.Euler(0, 0, angle) * new Vector3(-_thickness / 2, 0);
            vertex.position += new Vector3(_unitWidth * point.x, _unitHeight * point.y);
            vh.AddVert(vertex);


            vertex.position = Quaternion.Euler(0, 0, angle) * new Vector3(_thickness / 2, 0);
            vertex.position += new Vector3(_unitWidth * point.x, _unitHeight * point.y);
            vh.AddVert(vertex);
        }

        public void SetColor(Color newColor)
        {
            color = newColor;
        }

        public void SetMaterial(Material mat)
        {
            material = mat;
        }

        public void SetNavigationPoints(List<Vector2> pointsToSet)
        {
            _points = pointsToSet;
            SetVerticesDirty();
        }

        public void Setup(int width, int height)
        {
            _gridSize.x = width;
            _gridSize.y = height;
        }
        public void ClearPoints()
        {
            _points.Clear();
        }
    }
}