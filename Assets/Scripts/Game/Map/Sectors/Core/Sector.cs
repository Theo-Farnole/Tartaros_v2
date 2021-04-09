namespace Tartaros.Map
{
    using System.Collections.Generic;
    using Tartaros.Selection;
    using UnityEngine;
    using Tartaros.Economy;
    using Tartaros.ServicesLocator;
    using Tartaros.Map;
    using Tartaros.Math;
    using System.Linq;
    using System;

    public class Sector : MonoBehaviour, ISector
    {
        #region Fields		

        [SerializeField]
        private MeshCollider _collider = null;

        private SectorData _sectorData = null;

        [ShowInRuntime]
        private bool _isCaptured = false;
        private Mesh _sectorMesh = null;
        #endregion Fields

        #region Properties
        public SectorData SectorData { get => _sectorData; set => _sectorData = value; }
        public bool IsCaptured => _isCaptured;
        public ConvexPolygon ConvexPolygon => _sectorData.ConvexPolygon;
        public Mesh SectorMesh => _sectorMesh;

        GameObject[] ISector.ObjectsInSector
        {
            get
            {
                return FindObjectsOfType<GameObject>()
                    .Where(x => IsObjectInSector(x))
                    .ToArray();
            }
        }

        bool ISector.IsCaptured
        {
            get => _isCaptured;

            set
            {
                if (_isCaptured == value) return;

                _isCaptured = value;

                if (_isCaptured == true)
                {
                    OnCaptureSector();
                }
            }
        }

        ISectorResourcesWallet ISector.CapturePrice => SectorData.CapturePrice;
        #endregion Properties

        #region Events
        public class InitializedArgs : EventArgs
        { }

        public event EventHandler<InitializedArgs> Initialized = null;

        public event EventHandler<CapturedArgs> Captured = null;



        event EventHandler<CapturedArgs> ISector.Captured
        {
            add
            {
                Captured += value;
            }

            remove
            {
                Captured -= value;
            }
        }


        #endregion Events

        #region Methods
        public void Initialize(SectorData sectorData)
        {
            _sectorData = sectorData;

            _sectorMesh = SectorMeshGenerator.GenerateMesh(_sectorData);

            _collider.sharedMesh = _sectorMesh;
            Initialized?.Invoke(this, new InitializedArgs());
        }

        public Vector3[] GetPointsWrappedSnappedToGround()
        {
            List<Vector3> sectorPointsSnapToGround = new List<Vector3>();

            foreach (Vector3 sectorPoint in _sectorData.GetWorldPointsWrapped())
            {
                Ray ray = new Ray(sectorPoint + Vector3.up * 5, Vector3.down);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    sectorPointsSnapToGround.Add(hit.point);
                }
                else
                {
                    sectorPointsSnapToGround.Add(sectorPoint);
                }
            }

            return sectorPointsSnapToGround.ToArray();
        }

        public bool IsObjectInSector(GameObject gameObject)
        {
            return _sectorData.ConvexPolygon.ContainsWorldPosition(gameObject.transform.position);
        }

        bool ISector.ContainsPosition(Vector3 point)
        {
            return _sectorData.ConvexPolygon.ContainsPoint2D(new Vector2(point.x, point.z));
        }

        private void OnCaptureSector()
        {
            UpdateSelectableTeam();

            Captured?.Invoke(this, new CapturedArgs());

        }

        private void UpdateSelectableTeam()
        {
            if (TryGetComponent(out ISelectable selectable))
            {
                selectable.Team = Entities.Team.Player;
            }
        }
        #endregion Methods
    }
}
