namespace Tartaros.Entities
{
	using Sirenix.OdinInspector;
	using Tartaros.Entities.Movement;
	using UnityEngine;
	using UnityEngine.Rendering;

	[System.Serializable]
	public class SteeringBehaviour
	{
		#region Enums
		[System.Flags]
		private enum Behaviours
		{
			None = 0,
			Seek = 1,
			Arrive = 2,
			Separation = 4
		}
		#endregion Enums

		#region Fields		
		[SerializeField]
		private Behaviours _enabledBehaviours = Behaviours.Seek;

		[SerializeField]
		private float _arrivalDeceleration = 0.3f;

		[SerializeField]
		private float _arrivalDistance = 1;

		[SerializeField]
		private float _maxForce = 200;

		[FoldoutGroup("Priorities")]
		[SerializeField]
		private float _separationWeight = 1;

		[FoldoutGroup("Priorities")]
		[SerializeField]
		private float _seekWeight = 1;

		[FoldoutGroup("Priorities")]
		[SerializeField]
		private float _arriveWeight = 1;

		private Vector2 _position = Vector2.zero;
		private Vector2 _velocity = Vector2.zero;
		private ISteeringBehaviourAgent _agent = null;

		private float _maxSpeed = -1;
		#endregion Fields

		#region Properties
		public float MaxSpeed { get => _maxSpeed; set => _maxSpeed = value; }
		#endregion Properties

		#region Methods
		public void Construct(ISteeringBehaviourAgent agent, float maxSpeed)
		{
			_maxSpeed = MaxSpeed;
			_agent = agent;
		}

		public Vector2 CalculateVelocity(Vector2 targetPosition, Vector2 agentPosition, Vector2 agentVelocity, ISteeringBehaviourAgent[] neightbors)
		{
			_position = agentPosition;
			_velocity = agentVelocity;

			Vector2 output = Vector2.zero;

			if (IsOn(Behaviours.Separation) == true)
			{
				var force = Separation(neightbors) * _separationWeight;
				if (AccumulateForce(ref output, force) == false) return output;
			}

			if (IsOn(Behaviours.Seek) == true)
			{
				Debug.Log("Seek");
				var force = Seek(targetPosition) * _seekWeight;

				if (AccumulateForce(ref output, force) == false) return output;
			}

			if (IsOn(Behaviours.Arrive) == true)
			{
				Debug.Log("Arrive");

				var force = Arrive(targetPosition) * _arriveWeight;
				if (AccumulateForce(ref output, force) == false) return output;
			}

			return output;
		}

		private bool AccumulateForce(ref Vector2 currentSteeringBehaviour, Vector2 forceToAdd)
		{
			float currentMagnitude = currentSteeringBehaviour.magnitude;
			float remainingMagnitude = _maxForce - currentMagnitude;

			if (remainingMagnitude <= 0) return false;

			float magnitudeToAdd = forceToAdd.magnitude;

			if (magnitudeToAdd < remainingMagnitude)
			{
				currentSteeringBehaviour += forceToAdd;
			}
			else
			{
				currentSteeringBehaviour += forceToAdd.normalized * remainingMagnitude;
			}

			return true;

		}

		private bool IsOn(Behaviours behaviour)
		{
			return _enabledBehaviours.HasFlag(behaviour);
		}

		private Vector2 Seek(Vector2 targetPosition)
		{
			return (GetDesiredVelocity(targetPosition) - _velocity);
		}

		private Vector2 Arrive(Vector2 targetPosition)
		{
			Vector2 ToTarget = targetPosition - _position;
			float dist = ToTarget.magnitude;

			if (dist > 0.1f)
			{
				float speed = dist / _arrivalDeceleration;
				speed = Mathf.Min(speed, _maxSpeed); // clamp speed

				Vector2 desiredVelocity = ToTarget * speed / dist;
				return desiredVelocity - _velocity;
			}

			return Vector2.zero;
		}

		private Vector2 Separation(ISteeringBehaviourAgent[] neighbors)
		{
			Vector2 steeringForce = Vector2.zero;

			foreach (ISteeringBehaviourAgent neighbor in neighbors)
			{
				if (neighbor != _agent)
				{
					Vector2 directionToAgent = _position - neighbor.Position;

					steeringForce += directionToAgent.normalized / directionToAgent.magnitude;
				}
			}

			return steeringForce;
		}

		private Vector2 GetDesiredVelocity(Vector2 targetPosition)
		{
			Vector2 directionToTarget = _position.GetDirectionTo(targetPosition);
			Vector2 desiredVelocity = directionToTarget * _maxSpeed;
			return desiredVelocity;
		}
		#endregion Methods
	}
}