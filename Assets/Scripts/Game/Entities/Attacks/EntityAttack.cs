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
        public EntityAttackData EntityAttackData { get => _entityAttackData; set => _entityAttackData = value; }


        #endregion

        #region Methods
        private void Awake()
        {

        }

        public void DoDamage(IAttackable target)
        {
            target.TakeDamage(_entityAttackData.Damage);
        }

        bool IsInAttackRange()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }

}