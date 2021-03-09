namespace Tartaros.Entities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Entities;
    using System;

    public class EntityHealth : MonoBehaviour, IAttackable
    {

        #region Fields
        private float _currentHealth = 0;
        private Coroutine _timeWithouTakingDamage = null;

        Transform IAttackable.TransformAttackble => transform;


        private EntityHealthData _entityHealthData = null;
        public EntityHealthData EntityHealthData { get => _entityHealthData; set => _entityHealthData = value; }


        #endregion


        #region Events
        public class DamageTakenArgs : EventArgs
        {

        }

        public event EventHandler<DamageTakenArgs> DamageTaken = null;
        #endregion

        #region Methods

        private void Awake()
        {
            _currentHealth = EntityHealthData.Health;
        }

        void RegenerateHealth()
        {
            _currentHealth += _entityHealthData.HealthPointsRegenerationPerSeconds;
        }


        void IAttackable.TakeDamage(int damage)
        {
            _currentHealth -= damage;
            DamageTaken?.Invoke(this, new DamageTakenArgs());
            StopCoroutine(_timeWithouTakingDamage);
            _timeWithouTakingDamage = StartCoroutine(TimeWithoutTakingDamage());
        }
        #endregion

        IEnumerator TimeWithoutTakingDamage()
        {
            yield return new WaitForSeconds(_entityHealthData.RegenerationDelayWithoutTakingDamage);

            while (true)
            {
                RegenerateHealth();
                yield return new WaitForEndOfFrame();
            }
        }
    }

}