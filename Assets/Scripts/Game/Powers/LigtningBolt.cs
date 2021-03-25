namespace Tartaros.Power
{
    using Sirenix.OdinInspector;
    using System.Collections;
    using System.Collections.Generic;
    using Tartaros.Entities;
    using Tartaros.Entities.Detection;
    using Tartaros.ServicesLocator;
    using UnityEngine;

    public class LigtningBolt : SerializedMonoBehaviour, IPower
    {
        [SerializeField]
        private LightningBoltData _data = null;

        float IPower.range => _data.SpellRadius;

        GameObject IPower.prefabPower => gameObject;

        void IPower.Cast()
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
            throw new System.NotImplementedException();
        }

        private void InstanciateCastVFX()
        {
            throw new System.NotImplementedException();
        }

        private void AppliedDamage()
        {
            throw new System.NotImplementedException();
        }

        private void DestoryMehods()
        {
            throw new System.NotImplementedException();
        }
    }
}