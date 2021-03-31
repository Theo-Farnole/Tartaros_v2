namespace Tartaros.UI.MiniMap
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Tartaros.Map;
    using Tartaros.Sectors;
    using Tartaros.ServicesLocator;
    using UnityEngine;

    public class SectorsMiniMapDisplay : MonoBehaviour
    {
        [SerializeField]
        private GameObject _miniMapBackground = null;
        [SerializeField]
        private GameObject _drawLinePrefab = null;
        [SerializeField]
        private MiniMap _miniMap = null;

        private IMap _map = null;
        private RectTransform _rootTransform = null;

        private void Start()
        {
            _map = Services.Instance.Get<IMap>();
            _rootTransform = _miniMap.RootTransform;
        }

        public void DisplaySectors()
        {
            Sector[] sectors = _map.Sectors.OfType<Sector>().ToArray();

            if (sectors == null)
            {
                Debug.LogError("There is no ref of sectors on the scene");
                return;
            }

            foreach (var sector in sectors)
            {
                GameObject sectorDisplay = GameObject.Instantiate(_drawLinePrefab, _miniMapBackground.transform);
                DrawLineUI drawLineUI = sectorDisplay.GetComponent<DrawLineUI>();

                List<Vector2> listOfVertice = GetVectorOnUI(sector.ConvexPolygon.vertices);
                listOfVertice.Add(listOfVertice.ToArray()[0]);

                drawLineUI.Setup(
                    Mathf.RoundToInt(_rootTransform.rect.width),
                    Mathf.RoundToInt(_rootTransform.rect.height));
                drawLineUI.SetColor(Color.blue);
                drawLineUI.SetNavigationPoints(listOfVertice);
            }
        }

        private List<Vector2> GetVectorOnUI(List<Vector2> vertices)
        {
            List<Vector2> list = new List<Vector2>();
            foreach (Vector2 vertice in vertices)
            {
                list.Add(_miniMap.WordToUiPosition(vertice));
            }
            return list;
        }
    }
}