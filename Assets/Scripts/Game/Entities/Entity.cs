namespace Tartaros.Entities
{
	using UnityEngine;

	public class Entity : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private EntityData _entityData = null;
		#endregion Fields

		#region Methods
		private void Start()
		{
			GenerateRequiredComponents();
		}

		public void Kill()
		{
			Destroy(gameObject);
		}

		void GenerateRequiredComponents()
		{
			foreach (IEntityBehaviourData behaviour in _entityData.Behaviours)
			{
				behaviour.SpawnRequiredComponents(gameObject);
			}
		}
		#endregion Methods
	}
}