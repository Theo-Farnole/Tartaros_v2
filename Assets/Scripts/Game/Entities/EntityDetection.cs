namespace Tartaros.Entities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Entities;

    public class EntityDetection : MonoBehaviour
    {
        #region Fields
        private EntityDetectionData _data = null;
        private List<Transform> _nearEntities = new List<Transform>();
        private float _viewRadius; 
        #endregion

        #region Methods
        Entity GetNearest(SearchQuary searchQuary)
        {
            _nearEntities.Clear();
            Transform entity = transform;

            Collider[] targetsInViewRadius = Physics.OverlapSphere(entity.position, _viewRadius);
            for (int i = 0; i < targetsInViewRadius.Length; i++)
            {
                Transform target = targetsInViewRadius[i].transform;
                if(target != entity)
                {

                }
            }

            throw new System.NotImplementedException();
        } 
        #endregion
    }
}