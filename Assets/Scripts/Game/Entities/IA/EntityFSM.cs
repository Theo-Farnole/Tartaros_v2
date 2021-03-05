namespace Tartaros.Entities
{
	using Tartaros.Utilities;
	using UnityEngine;

	public class EntityFSM : MonoBehaviour
	{
		#region Fields
		private GenericFSM<Entity> _finiteStateMachine = new GenericFSM<Entity>();

		private AEntityState _currentState;
		#endregion Fields

		#region Methods		

		private void Update()
		{
			if (_finiteStateMachine != null)
			{
				_finiteStateMachine.OnUpdate();
			}
		}

		void SetState(AEntityState newState)
        {

        }

		void AddFuturState(AEntityState futurState)
        {

        }
		#endregion Methods
	}
}