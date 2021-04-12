namespace Tartaros.Entities
{
	using Sirenix.OdinInspector;
	using System.Collections.Generic;
	using Tartaros.Entities.State;
	using Tartaros.Utilities;
	using UnityEngine;

	public partial class EntityFSM : MonoBehaviour
	{
		#region Fields
		[OnInspectorGUI("DisplayCurrentState")]
		private GenericFSM<Entity> _finiteStateMachine = new GenericFSM<Entity>();

		private Queue<AEntityState> _statesQueue = new Queue<AEntityState>();

		private Entity _entity = null;
		#endregion Fields

		#region Methods		
		private void Awake()
		{
			_entity = GetComponent<Entity>();
		}

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

		public void SetState(AEntityState newState)
		{
			_finiteStateMachine.CurrentState = newState;
		}

		public void EnqueueState(AEntityState state)
		{
			_statesQueue.Enqueue(state);
		}

		public void SetStateToDefaultState()
		{
			SetState(GenerateDefaultState());
		}

		private AEntityState GenerateDefaultState()
		{
			return new StateIdle(_entity);
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