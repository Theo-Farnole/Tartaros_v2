namespace Tartaros.Entities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Entities;
    using Tartaros.Entities.Attack;

    public class EntityDetection : MonoBehaviour
    {
        #region Fields
        private EntityDetectionData _entityDetectionData = null;
        private EntityAttackData _entityAttackData = null;
        private List<Transform> _nearEntities = new List<Transform>();

        public EntityDetectionData EntityDetectionData { get => _entityDetectionData; set => _entityDetectionData = value; }
        public EntityAttackData EntityAttackData { get => _entityAttackData; set => _entityAttackData = value; }

        private float _viewRadius;
        private float _attackRange = 1;
        #endregion

        #region Methods


        public Entity GetNearest(SearchQuary searchQuary)
        {
            throw new System.NotImplementedException();
        }

        public bool IsNearestIsInDetectionRange()
        {
            Vector3 nearest = GetNearest(SearchQuary.Enemy | SearchQuary.Unit | SearchQuary.Building).transform.position;
            float distance = Vector3.Distance(this.transform.position, nearest);

            if(distance <= _entityDetectionData.DetectionRange)
            {
                return true;
            }
            else
            {
                return false;
            }


            throw new System.NotImplementedException();
        }



        public bool IsInAttackRange(Entity nearest, float attackRange)
        {
            float distance = Vector3.Distance(this.transform.position, nearest.transform.position);
            if (distance <= attackRange)
            {
                return true;
            }
            else
                return false;
        }
        #endregion
    }
}