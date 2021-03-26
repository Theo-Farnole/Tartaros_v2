namespace Tartaros.Power
{
    using System.Collections;
    using System.Collections.Generic;
    using Tartaros.Entities;
    using Tartaros.Entities.Detection;
    using Tartaros.OrderGiver;
    using Tartaros.ServicesLocator;
    using UnityEngine;

    public class ControlledAoE : MonoBehaviour, IPower, IOrderMoveReceiver
    {
        private ControlledAoEData _data = null;
        private GameObject _preCastVFX = null;
        private GameObject _castVFX = null;

        float IPower.range => _data.SpellRadius;

        GameObject IPower.prefabPower => gameObject;


        void IPower.Cast()
        {
            throw new System.NotImplementedException();
        }

        void IOrderMoveReceiver.Move(Vector3 position)
        {
            throw new System.NotImplementedException();
        }

        void IOrderMoveReceiver.Move(Transform toFollow)
        {
            throw new System.NotImplementedException();
        }

        void IOrderMoveReceiver.MoveAdditive(Vector3 position)
        {
            throw new System.NotImplementedException();
        }

        void IOrderMoveReceiver.MoveAdditive(Transform toFollow)
        {
            throw new System.NotImplementedException();
        }

        private Entity[] GetEveryEntityInRadius()
        {
            var kdTree = Services.Instance.Get<EntitiesKDTrees>();
            var output = new List<Entity>();

            IEnumerable<Entity> enemiesSortByDistance = kdTree.FindClose(Team.Enemy, transform.position);

            foreach (Entity entity in enemiesSortByDistance)
            {
                if (IsEntityInRadius(entity))
                {
                    output.Add(entity);
                }
                else
                {
                    return output.ToArray();
                }
            }

            return output.ToArray();
        }

        private bool IsEntityInRadius(Entity entity)
        {
            return Vector3.Distance(entity.transform.position, transform.position) <= _data.SpellRadius;
        }

        private void InstanciatePrecastVFX()
        {

            _preCastVFX = GameObject.Instantiate(_data.PreCastVFXPrefab, transform.position, Quaternion.identity);
        }

        private void InstanciateCastVFX()
        {
            Debug.Log(_data.CastVFXPrefab);
            _castVFX = GameObject.Instantiate(_data.CastVFXPrefab, transform.position, Quaternion.identity);
        }

        private void AppliedDamage()
        {
            Entity[] entity = GetEveryEntityInRadius();

            for (int i = 0; i < entity.Length; i++)
            {
                //IAttackable attackable = entity[i].GetComponent<IAttackable>();
                entity[i].Kill();
            }
        }

        private void DestoryMehods()
        {
            Destroy(_preCastVFX);
            Destroy(_castVFX);
            Destroy(gameObject);
        }

        
    }
}