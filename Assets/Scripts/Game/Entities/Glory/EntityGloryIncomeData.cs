namespace Tartaros.Entities
{
    using System.Collections;
    using UnityEngine;

    public class EntityGloryIncomeData : IEntityBehaviourData
    {
        [SerializeField]
        private int _gloryIncome = 0;

        public EntityGloryIncomeData(int gloryIncome)
        {
            _gloryIncome = gloryIncome;
        }

        public int GloryIncome => _gloryIncome;

#if UNITY_EDITOR
		void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
		{

		} 
#endif
	}
}