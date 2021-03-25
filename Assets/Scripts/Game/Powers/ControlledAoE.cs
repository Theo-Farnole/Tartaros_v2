namespace Tartaros.Power
{
    using System.Collections;
    using System.Collections.Generic;
    using Tartaros.Entities;
    using UnityEngine;

    public class ControlledAoE : MonoBehaviour, IPower
    {
        private ControlledAoEData _data = null;

        float IPower.range => _data.SpellRadius;

        GameObject IPower.prefabPower => gameObject;

        void IPower.Cast()
        {
            throw new System.NotImplementedException();
        }

        private List<Entity> GetEveryEntityInRadius()
        {
            throw new System.NotImplementedException();
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