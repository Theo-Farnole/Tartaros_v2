namespace Tartaros.Entities
{
	using Sirenix.OdinInspector;
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Entities.Movement;
	using Unity.Burst;
	using Unity.Collections;
	using Unity.Jobs;
	using Unity.Mathematics;
	using UnityEngine;

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
			Separation = 4,
			Alignment = 8,
			PathFollowing = 16
		}
		#endregion Enums

		#region Fields		
		private const float REACH_PATH_WAYPOINT_THRESHOLD = 0.8f;

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

		[FoldoutGroup("Priorities")]
		[SerializeField]
		private float _alignementWeight = 1;

		[FoldoutGroup("Priorities")]
		[SerializeField]
		private float _pathFollowingWeight = 1;

		private Vector2 _position = Vector2.zero;
		private Vector2 _velocity = Vector2.zero;
		private ISteeringBehaviourAgent _agent = null;
		private IEnumerable<ISteeringBehaviourAgent> _neighbors = null;

		private Path _path = null;
		private float _maxSpeed = -1;
		#endregion Fields

		#region Properties
		public float MaxSpeed { get => _maxSpeed; set => _maxSpeed = value; }
		public Path Path { get => _path; set => _path = value; }
		#endregion Properties

		#region Methods
		public void Construct(ISteeringBehaviourAgent agent, float maxSpeed)
		{
			_maxSpeed = MaxSpeed;
			_agent = agent;
		}

		public Vector2 CalculateVelocity(Vector2 targetPosition, Vector2 agentPosition, Vector2 agentVelocity, IEnumerable<ISteeringBehaviourAgent> neightbors)
		{
			_position = agentPosition;
			_velocity = agentVelocity;
			_neighbors = neightbors;

			Vector2 velocity = Vector2.zero;

			if (IsOn(Behaviours.Separation) == true)
			{
				var force = Separation() * _separationWeight;
				if (AccumulateForce(ref velocity, force) == false) return velocity;
			}

			if (IsOn(Behaviours.Alignment) == true)
			{
				var force = Alignment() * _alignementWeight;

				if (AccumulateForce(ref velocity, force) == false) return velocity;
			}

			if (IsOn(Behaviours.PathFollowing) == true)
			{
				if (_path != null)
				{
					var force = FollowPath() * _pathFollowingWeight;

					if (AccumulateForce(ref velocity, force) == false) return velocity;
				}
				else
				{
					UnityEngine.Debug.LogWarning("Path following behaviour is enabled but no path has been provided. Please set one with the _path field.");
				}
			}

			if (IsOn(Behaviours.Seek) == true)
			{
				UnityEngine.Debug.Log("Seek");
				var force = Seek(targetPosition) * _seekWeight;

				if (AccumulateForce(ref velocity, force) == false) return velocity;
			}

			if (IsOn(Behaviours.Arrive) == true)
			{
				UnityEngine.Debug.Log("Arrive");

				var force = Arrive(targetPosition) * _arriveWeight;
				if (AccumulateForce(ref velocity, force) == false) return velocity;
			}

			return velocity;
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

		public void EnablePathFollowing() => EnableBehaviour(Behaviours.PathFollowing);
		public void DisablePathFollowing() => DisableBehaviour(Behaviours.PathFollowing);

		private void EnableBehaviour(Behaviours behaviour)
		{
			_enabledBehaviours |= behaviour;
		}

		private void DisableBehaviour(Behaviours behaviour)
		{
			_enabledBehaviours &= ~behaviour;
		}

		private Vector2 Seek(Vector2 targetPosition)
		{
			return (GetDesiredVelocity(targetPosition) - _velocity);
		}

		private Vector2 Alignment()
		{
			Vector2 averageHeading = Vector2.zero;

			foreach (var neighbor in _neighbors)
			{
				if (neighbor != _agent)
				{
					averageHeading += neighbor.Heading;
				}
			}

			// neighbors contains the agent
			if (_neighbors.Count() > 1)
			{
				averageHeading /= (float)_neighbors.Count() - 1;
				averageHeading -= _agent.Heading;
			}

			return averageHeading;
		}

		private Vector2 FollowPath()
		{
			bool hasReachedWaypoint = Vector3.Distance(_path.CurrentWaypoint, _position) <= REACH_PATH_WAYPOINT_THRESHOLD;

			if (hasReachedWaypoint == true)
			{
				_path.SetNextWaypoint();
			}

			if (_path.IsLastWaypoint == false)
			{
				return Seek(_path.CurrentWaypoint);
			}
			else
			{
				return Arrive(_path.CurrentWaypoint);
			}
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

		//[BurstCompile(CompileSynchronously = true)]
		//public struct SeparationJob : IJobParallelFor
		//{
		//	[WriteOnly]
		//	public float2 steeringForce;
		//	[Unity.Collections.ReadOnly]
		//	public float2 agentPosition;

		//	[Unity.Collections.ReadOnly]
		//	public NativeArray<float2> neighborsPositions;

		//	public void Execute(int index)
		//	{
		//		float2 directionToAgent = agentPosition - neighborsPositions[index];
		//		steeringForce += math.normalize(directionToAgent) / math.length(directionToAgent);
		//	}
		//}

		private Vector2 Separation()
		{
			Vector2 steeringForce = Vector2.zero;

			foreach (var neighbor in _neighbors)
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