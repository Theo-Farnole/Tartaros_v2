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

    public class Gate : MonoBehaviour, IEntityOrderable
    {
        [SerializeField]
        private bool _useAnimatorONEDITOR = false;

        private Animator _animator = null;
        private IconsDatabase _iconsDataBase = null;
        private bool _isOpen = false;
        private NavMeshObstacle _navObstacle = null;

        public IconsDatabase IconData => _iconsDataBase;
        public Animator Animator => _animator;

        private void Awake()
        {
            _navObstacle = GetComponent<NavMeshObstacle>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            NavMeshObstacleUpdate();
        }

        private void Start()
        {
            _iconsDataBase = Services.Instance.Get<IconsDatabase>();
        }

        private void NavMeshObstacleUpdate()
        {
            if(_navObstacle == null)
            {
                _navObstacle = GetComponent<NavMeshObstacle>();
            }

            if(_isOpen == false)
            {
                _navObstacle.carving = false;
            }
            else
            {
                _navObstacle.carving = true;
            }    
        }

        Order[] IEntityOrderable.GenerateOrders(Entity entity)
        {
            List<Order> orders = new List<Order>();

            orders.Add(new OpenDoorsOrder(this));
            orders.Add(new CloseDoorsOrder(this));
            return orders.ToArray();
        }

        public void OpenGate()
        {
            if (_useAnimatorONEDITOR)
            {
                _animator.SetBool("isOpen", true);
            }
            _isOpen = true;
        }

        public void CloseGate()
        {
            if (_useAnimatorONEDITOR)
            {
                _animator.SetBool("isOpen", false);
            }
            _isOpen = false;
        }
    }
}