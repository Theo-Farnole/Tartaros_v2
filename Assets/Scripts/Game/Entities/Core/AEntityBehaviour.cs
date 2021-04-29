namespace Tartaros.Entities
{
	using UnityEngine;

	[RequireComponent(typeof(Entity))]	
	public abstract class AEntityBehaviour : MonoBehaviour
	{
		private Entity _entity = null;

		protected Entity Entity
		{
			get
			{
				if (_entity == null)
				{
					_entity = GetComponent<Entity>();
				}

				return _entity;
			}
		}
	}
}
