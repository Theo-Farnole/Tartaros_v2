namespace Tartaros.Construction
{
    using Assets.Scripts.Game.Orders;
    using System.Collections;
    using System.Collections.Generic;
    using Tartaros.Entities;
    using Tartaros.Orders;
    using Tartaros.ServicesLocator;
    using UnityEngine;
    using UnityEngine.AI;

    public class Gate : MonoBehaviour, IOrderable
    {
        private bool _isOpen = false;
        private NavMeshObstacle _navObstacle = null;

        private IGateEffect[] _gateEffects = null;
      
        private void Awake()
        {
            _navObstacle = GetComponent<NavMeshObstacle>();
            _navObstacle.carving = true;
        }

		private void OnEnable()
		{
            _gateEffects = GetComponents<IGateEffect>();
		}

		private void Update()
        {
            NavMeshObstacleUpdate();
        }

        private void NavMeshObstacleUpdate()
        {
            if(_navObstacle == null)
            {
                _navObstacle = GetComponent<NavMeshObstacle>();
                _navObstacle.carving = true;
            }

            if(_isOpen == false)
            {
                _navObstacle.enabled = false;
            }
            else
            {
                _navObstacle.enabled = true;
            }    
        }

        Order[] IOrderable.GenerateOrders()
		{
            List<Order> orders = new List<Order>();

            orders.Add(new OpenDoorsOrder(this));
            orders.Add(new CloseDoorsOrder(this));
            return orders.ToArray();
        }

        public void OpenGate()
        {
			foreach (var gateEffect in _gateEffects)
			{
                gateEffect.GateOpen();
			}
            _isOpen = true;
        }

        public void CloseGate()
        {
            foreach (var gateEffect in _gateEffects)
            {
                gateEffect.GateClose();
            }

            _isOpen = false;
        }
    }
}