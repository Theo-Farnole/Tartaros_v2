namespace Tartaros.Entities
{
	using Tartaros.Utilities;
	using UnityEngine;

	public class EntityFSM : MonoBehaviour
	{
		#region Fields
		private GenericFSM<Entity> _finiteStateMachine = new GenericFSM<Entity>();
		#endregion Fields

		#region Methods		

		private void Update()
		{
			if (_finiteStateMachine != null)
			{
				_finiteStateMachine.OnUpdate();
			}
		}
		#endregion Methods
	}
}