namespace Tartaros.Power
{
    using Sirenix.OdinInspector;
    using System.Collections;
    using System.Collections.Generic;
    using Tartaros.Entities;
    using Tartaros.Entities.Detection;
    using Tartaros.OrderGiver;
    using Tartaros.ServicesLocator;
    using UnityEngine;
    using UnityEngine.AI;

    public class ControlledAoE : SerializedMonoBehaviour, IPower, IOrderMoveReceiver
    {
        #region Fields
        [SerializeField]
        private ControlledAoEData _data = null;
        private GameObject _preCastVFX = null;
        private GameObject _castVFX = null;
        private ControlledAoEMovement _movement = null; 
        #endregion

        #region Properties
        float IPower.range => _data.SpellRadius;

        GameObject IPower.prefabPower => gameObject;

        int IPower.price => _data.GloryPrice;
        #endregion

        private void OnEnable()
        {
            _movement = new ControlledAoEMovement(GetComponent<NavMeshAgent>());
            StartCoroutine(OnInstanciate());
        }

        void IPower.Cast()
        {
            throw new System.NotImplementedException();
        }


        void IOrderMoveReceiver.Move(Vector3 position)
        {
            _movement.Move(position);
        }

        void IOrderMoveReceiver.Move(Transform toFollow)
        {
            _movement.Move(toFollow);
        }

        void IOrderMoveReceiver.MoveAdditive(Vector3 position)
        {
            _movement.Move(position);
        }

        void IOrderMoveReceiver.MoveAdditive(Transform toFollow)
        {
            _movement.Move(toFollow);
        }

        #region Methods
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

        void OnDrawGizmos()
        {
#if UNITY_EDITOR
            Editor.HandlesHelper.DrawSolidCircle(transform.position, Vector3.up, _data.SpellRadius, Color.red);
#endif
        }

        private bool IsEntityInRadius(Entity entity)
        {
            return Vector3.Distance(entity.transform.position, transform.position) <= _data.SpellRadius;
        }

        private void InstanciatePrecastVFX()
        {

            _preCastVFX = GameObject.Instantiate(_data.PreCastVFXPrefab, transform.position, Quaternion.identity, gameObject.transform);
        }

        private void InstanciateCastVFX()
        {
            _castVFX = GameObject.Instantiate(_data.CastVFXPrefab, transform.position, Quaternion.identity, gameObject.transform);
        }

        private void AppliedDamage()
        {
            Entity[] entity = GetEveryEntityInRadius();
            Debug.Log(GetEveryEntityInRadius().Length);

            for (int i = 0; i < entity.Length; i++)
            {
                //IAttackable attackable = entity[i].GetComponent<IAttackable>();
                entity[i].Kill();
            }
        }

        private void DestroyMethods()
        {
            Destroy(_preCastVFX);
            Destroy(_castVFX);
            Destroy(gameObject);
        }
        #endregion

        #region Enumerator
        IEnumerator OnInstanciate()
        {
            InstanciateCastVFX();
            yield return new WaitForSeconds(_data.TimeBeforeAppliedDamage);
            StartCoroutine(AppliedDamageEverySeconds());
        }

        IEnumerator AppliedDamageEverySeconds()
        {
            for (int i = 0; i < _data.LifeTime; i++)
            {
                AppliedDamage();
                yield return new WaitForSeconds(_data.AttackFrequency);
            }

            DestroyMethods();
        } 
        #endregion

    }
}