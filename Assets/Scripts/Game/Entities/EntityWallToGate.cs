namespace Tartaros.Entities
{
    using System.Collections;
    using System.Collections.Generic;
    using Tartaros.Economy;
    using Tartaros.Orders;
    using Tartaros.Selection;
    using Tartaros.ServicesLocator;
    using UnityEngine;

    public class EntityWallToGate : MonoBehaviour, IEntityOrderable
    {
        private EntityWallToGateData _data = null;
        private IconsDatabase _iconsDataBase = null;
        private IPlayerSectorResources _playerResources = null;

        [SerializeField]
        private Entity _previousAdjacentWall = null;
        [SerializeField]
        private Entity _nextAdjacentWall = null;

        public Entity PreviousAdjacentWall => _previousAdjacentWall;
        public Entity NextAdjacentWall { get => _nextAdjacentWall; set => _nextAdjacentWall = value; }

        public IconsDatabase IconData => _iconsDataBase;

        public EntityWallToGateData EntityWallToGateData { get => _data; set => _data = value; }


        private void Start()
        {
            _iconsDataBase = Services.Instance.Get<IconsDatabase>();
            _playerResources = Services.Instance.Get<IPlayerSectorResources>();

            GetNeighbourWall();
        }


        Order[] IEntityOrderable.GenerateOrders(Entity entity)
        {
            List<Order> orders = new List<Order>();

            orders.Add(new InstanciateGateOrder(this));
            return orders.ToArray();
        }

        public void InstanciateGate()
        {
            if (CanSpawn())
            {
                Vector3 position = (transform.position + _previousAdjacentWall.gameObject.transform.position) / 2;

                GameObject gate = GameObject.Instantiate(_data.GatePrefab, position, transform.rotation);
                Destroy(_previousAdjacentWall.gameObject);
                Destroy(this.gameObject);

                ISelection selction = Services.Instance.Get<CurrentSelection>();
                selction.ClearSelection();
                selction.AddToSelection(gate.GetComponent<ISelectable>());
            }
        }

        public bool HaveEnoughSpace()
        {
            return _nextAdjacentWall != null && _previousAdjacentWall != null;
        }

        private void GetNeighbourWall()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 2))
            {
                var entity = hit.transform.gameObject.GetComponent<Entity>();

                if (entity != null)
                {
                    _previousAdjacentWall = entity;

                    entity.gameObject.GetComponent<EntityWallToGate>().NextAdjacentWall = gameObject.GetComponent<Entity>();
                }
                else
                {
                    Debug.LogError("there is no adjacentWall detected");
                    return;
                }
            }
        }

        public bool CanSpawn()
        {
            return _playerResources.CanBuyWallet(_data.GatePrice);
        }
    }
}