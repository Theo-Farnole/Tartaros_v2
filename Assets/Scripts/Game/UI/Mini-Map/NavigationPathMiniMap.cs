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
        private Vector3 _targetPosition = new Vector3(6, 0, 8);
        private ISpawnPoint[] _spawnPoints = null;
        [SerializeField]
        private MiniMap _miniMap = null;
        [SerializeField]
        private MiniMapDrawNavigationPath _miniMapDrawNavigationPath = null;
        private RectTransform _rootTransform = null;


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
                var listOfList = new List<List<Vector2>>();

                _miniMapDrawNavigationPath.Setup(
                    Mathf.RoundToInt(_rootTransform.rect.width),
                    Mathf.RoundToInt(_rootTransform.rect.height));

                foreach (NavMeshPath path in GetNavigationsPaths())
                {
                    Vector3[] corners = GetCornersNavigationPath(path);
                    List<Vector2> vertexs = GetVectors2(corners);

                    listOfList.Add(vertexs);
                }

                _miniMapDrawNavigationPath.SetPathNavigationPoints(listOfList.ToArray());
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

        public NavMeshPath[] GetNavigationsPaths()
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
    }
}