namespace Tartaros.Entities
{
	using Sirenix.OdinInspector;
	using System.Collections.Generic;
	using Tartaros.Entities.Movement;
	using Tartaros.Entities.State;
	using UnityEngine;

	[DisallowMultipleComponent]
	public partial class EntityFSM : AEntityBehaviour
	{
		#region Fields
		[OnInspectorGUI("DisplayCurrentState")]
		private GenericFSM<Entity> _finiteStateMachine = new GenericFSM<Entity>();

		private Queue<AEntityState> _statesQueue = new Queue<AEntityState>();
		#endregion Fields

		#region Methods		
		private void Start()
		{
			SetStateToDefaultState();
		}

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
			SetStateToDefaultState();
		}

		public void MarkCurrentStateAsFinish()
		{
			if (_statesQueue.Count > 0)
			{
				SetState(_statesQueue.Dequeue());
			}
			else
			{
				SetStateToDefaultState();
			}

		}

		private void SetState(AEntityState newState)
		{
			if (this.name == "Entity.Archer") Debug.LogFormat("Archer change state from {1} to {0}.", newState.GetType(), _finiteStateMachine.CurrentState);

			_finiteStateMachine.CurrentState = newState;
		}

		private void EnqueueState(AEntityState state)
		{
			_statesQueue.Enqueue(state);
		}

		public void OrderAttack(IAttackable target)
		{
			SetState(InstantiateAttackState(target));
		}

		public void EnqueueOrderAttack(IAttackable target)
		{
			EnqueueState(InstantiateAttackState(target));
		}

		public void OrderMoveAggressively(Vector3 position)
		{
			SetState(new StateAggressiveMove(Entity, position));
		}

		public void EnqueueOrderMoveAggressively(Vector3 position)
		{
			EnqueueState(new StateAggressiveMove(Entity, position));
		}

		public void OrderMove(Vector3 position)
		{
			SetState(new StateMove(Entity, position));
		}

		public void OrderFollow(Transform toFollow)
		{
			SetState(new StateFollow(Entity, toFollow));
		}

		public void EnqueueOrderMove(Vector3 position)
		{
			EnqueueState(new StateMove(Entity, position));
		}

		public void EnqueueOrderFollow(Transform toFollow)
		{
			EnqueueState(new StateFollow(Entity, toFollow));
		}

		public void OrderPatrol(PatrolPoints waypoints)
		{
			SetState(new StatePatrol(Entity, waypoints));
		}

		public void EnqueueOrderPatrol(PatrolPoints waypoints)
		{
			EnqueueState(new StatePatrol(Entity, waypoints));
		}

		public void SetStateToDefaultState()
		{
			SetState(InstantiateDefaultState());
		}

		public void SetStateGoalPattern(Vector3 position, IAttackable target)
		{
			SetState(new StateAttackTemple(Entity, position, target));
		}

		private AEntityState InstantiateDefaultState()
		{
			return new StateIdle(Entity);
		}

		private StateAttack InstantiateAttackState(IAttackable target)
		{
			return new StateAttack(Entity, target);
		}

		#endregion Methods
	}

#if UNITY_EDITOR
	public partial class EntityFSM
	{
#pragma warning disable IDE0051 // Remove unused private members
		void DisplayCurrentState()
#pragma warning restore IDE0051 // Remove unused private members
		{
			if (Application.isPlaying)
			{

				AState<Entity> currentState = _finiteStateMachine.CurrentState;
				string currentStateType = currentState != null ? currentState.GetType().Name : "NO STATE";

				string currentStateMessage = string.Format("Current state: {0}", currentStateType);

				GUILayout.Label(currentStateMessage);
			}
		}
	}
#endif
}