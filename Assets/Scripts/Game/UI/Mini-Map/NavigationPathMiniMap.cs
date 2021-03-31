namespace Tartaros.UI.MiniMap
{
    using System.Collections;
    using UnityEngine;
    using Tartaros.Wave;
    using Tartaros.Utilities;
    using UnityEngine.AI;
    using System.Collections.Generic;
    using Tartaros.ServicesLocator;

    public class NavigationPathMiniMap : MonoBehaviour
    {
        [SerializeField]
        private MiniMap _miniMap = null;
        [SerializeField]
        private GameObject _mapBackground = null;
        [SerializeField]
        private GameObject _navigationLine = null;

        private RectTransform _rootTransform = null;
        private ISpawnPoint[] _spawnPoints = null;
        private Vector3 _targetPosition = new Vector3(6, 0, 8);
        private List<GameObject> _navigationLineInstanciate = new List<GameObject>();
        //TODO DJ: Give the position of the Temple automaticaly 


        private void Awake()
        {
            Services.Instance.RegisterService(this);
            _spawnPoints = ObjectsFinder.FindObjectsOfInterface<ISpawnPoint>();
        }

        private void Start()
        {
            _rootTransform = _miniMap.RootTransform;
        }

        public void DrawPathNavigation()
        {
            if (_spawnPoints.Length > 1)
            {
                foreach (NavMeshPath path in GetNavigationsPaths())
                {
                    Vector3[] corners = GetCornersNavigationPath(path);
                    List<Vector2> vertexs = GetVectors2(corners);

                    GameObject navLine = GameObject.Instantiate(_navigationLine, _mapBackground.transform);
                    MiniMapDrawNavigationPath navPath = navLine.GetComponent<MiniMapDrawNavigationPath>();

                    navPath.Setup(
                    Mathf.RoundToInt(_rootTransform.rect.width),
                    Mathf.RoundToInt(_rootTransform.rect.height));

                    navPath.SetNavigationPoints(vertexs);
                    _navigationLineInstanciate.Add(navLine);
                }
            }
            else
            {
                return;
            }
        }

        private List<Vector2> GetVectors2(Vector3[] corners)
        {
            List<Vector2> list = new List<Vector2>();
            foreach (Vector3 corner in corners)
            {
                list.Add(_miniMap.WordToUiPosition(corner));
            }
            return list;
        }



        private Vector3[] GetCornersNavigationPath(NavMeshPath path)
        {
            List<Vector3> vertex = new List<Vector3>();

            for (int i = 0; i < path.corners.Length; i++)
            {
                vertex.Add(path.corners[i]);
            }

            return vertex.ToArray();
        }

        private NavMeshPath[] GetNavigationsPaths()
        {
            List<NavMeshPath> navPath = new List<NavMeshPath>();

            foreach (ISpawnPoint point in _spawnPoints)
            {
                var path = new NavMeshPath();
                NavMesh.CalculatePath(point.SpawnPoint, _targetPosition, NavMesh.AllAreas, path);
                navPath.Add(path);
            }

            return navPath.ToArray();
        }

        public void DisablePathLine()
        {
            foreach (var line in _navigationLineInstanciate)
            {
                Destroy(line);
            }
            _navigationLineInstanciate.Clear();
        }
    }
}