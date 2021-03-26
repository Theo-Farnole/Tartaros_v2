namespace Tartaros.Power
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.AI;
    using Tartaros.OrderGiver;

    public class ControlledAoEMovement 
    {
        private NavMeshAgent _navAgent = null;
    

        public ControlledAoEMovement(NavMeshAgent navAgent)
        {
            _navAgent = navAgent;
        }

        public void Move(Vector3 position)
        {
            _navAgent.SetDestination(position);
        }

        public void Move(Transform position)
        {
            _navAgent.SetDestination(position.position);
        }

        public void AdditiveMove(Vector3 position)
        {
            _navAgent.SetDestination(position);
        }

        public void AdditiveMove(Transform position)
        {
            _navAgent.SetDestination(position.position);
        }
    }

}