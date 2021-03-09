namespace Tartaros.Entities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Entities;
    using Tartaros.Entities.Attack;


    public class EntityAttack : MonoBehaviour
    {
        #region Fields
        private EntityAttackData _entityAttackData = null;
        private EntityDetection _entityDetection = null;
        private EntityMovement _entityMovement = null;
        public EntityAttackData EntityAttackData { get => _entityAttackData; set => _entityAttackData = value; }


        #endregion

        #region Methods
        private void Awake()
        {
            _entityDetection = GetComponent<EntityDetection>();
            _entityMovement = GetComponent<EntityMovement>();
        }

        public void DoDamage(IAttackable target)
        {
            var nearestEnemie = _entityDetection.GetNearest(SearchQuary.Enemy | SearchQuary.Unit);

            if (_entityDetection.IsInAttackRange(nearestEnemie, _entityAttackData.AttackRange))
            {
                target.TakeDamage(_entityAttackData.Damage);
            }
            else
            {
                _entityMovement.MoveToPoint(target.TransformAttackble.position);
            }
        }
        #endregion
    }

}