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

        public IconsDatabase IconData => _iconsDataBase;

        public EntityWallToGateData EntityWallToGateData { get => _data; set => _data = value; }


        private void Start()
        {
            _iconsDataBase = Services.Instance.Get<IconsDatabase>();
            _playerResources = Services.Instance.Get<IPlayerSectorResources>();
        }


        Order[] IEntityOrderable.GenerateOrders(Entity entity)
        {
            List<Order> orders = new List<Order>();

            orders.Add(new InstanciateGateOrder(this, _iconsDataBase.Data.AttackIcon));
            return orders.ToArray();
        }

        public void InstanciateGate()
        {
            if (CanSpawn())
            {
                GameObject gate = GameObject.Instantiate(_data.GatePrefab, transform.position, transform.rotation);
                Destroy(this.gameObject);

                ISelection selction = Services.Instance.Get<CurrentSelection>();
                selction.ClearSelection();
                selction.AddToSelection(gate.GetComponent<ISelectable>());
            }
        }

        public bool CanSpawn()
        {
            return _playerResources.CanBuyWallet(_data.GatePrice);
        }
    }
}