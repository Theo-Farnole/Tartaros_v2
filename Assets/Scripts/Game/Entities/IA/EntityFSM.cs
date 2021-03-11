namespace Tartaros.Entities
{
	using System.Collections.Generic;
	using Tartaros.Utilities;
	using UnityEngine;

	public class EntityFSM : MonoBehaviour
	{
		#region Fields
		private GenericFSM<Entity> _finiteStateMachine = new GenericFSM<Entity>();

		private Queue<AEntityState> _statesQueue = new Queue<AEntityState>();
		#endregion Fields

		#region Methods		
		private void Update()
		{
			if (_finiteStateMachine != null)
			{
				_finiteStateMachine.OnUpdate();
			}
		}

		public void Stop()
		{
			_statesQueue.Clear();
			SetState(null);
		}

		public void MarkCurrentStateAsFinish()
		{
			if (_statesQueue.Count != 0) return;

			SetState(_statesQueue.Dequeue());
		}

		public void SetState(AEntityState newState)
		{
			_finiteStateMachine.CurrentState = newState;
		}

		public void EnqueueState(AEntityState state)
		{
			_statesQueue.Enqueue(state);
		}
		#endregion Methods
	}
}