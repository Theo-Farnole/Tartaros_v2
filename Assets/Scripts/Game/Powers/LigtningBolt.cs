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

        private GameObject _preCastVFX = null;
        private GameObject _castVFX = null;

        void IPower.Cast()
        {
            StartCoroutine(CastSpellMethods());
        }

        private void OnEnable()
        {
            StartCoroutine(CastSpellMethods());
        }

        //TODO DJ: move GetEvryEntityInRadius in KdTree
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

        private void Finish()
        {
            InstanciateCastVFX();
            AppliedDamage();
            StartCoroutine(FinishVFX());
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

        IEnumerator CastSpellMethods()
        {
            InstanciatePrecastVFX();
            yield return new WaitForSeconds(1);
            Finish();
        }

        IEnumerator FinishVFX()
        {
            yield return new WaitForSeconds(1);
            DestoryMehods();
        }
    }
}