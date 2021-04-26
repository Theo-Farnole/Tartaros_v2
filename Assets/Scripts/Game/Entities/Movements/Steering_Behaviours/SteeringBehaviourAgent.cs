﻿namespace Tartaros.Entities.Movement
{
	using Sirenix.OdinInspector;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Utilities.SpatialPartioning;
	using TMPro;
	using UnityEngine;
	using UnityEngine.AI;

	[SelectionBase]
	public partial class SteeringBehaviourAgent : MonoBehaviour, ISpatialPartioningObject
	{
		#region Fields
		private const string EDITOR_GROUP_SECURITY = "SECURITIES";
		private const string EDITOR_GROUP_MAIN = "MAIN";

		private static readonly Color ACCELERATION_COLOR = Color.yellow;
		private static readonly Color VELOCITY_COLOR = Color.blue;
		private static readonly Color DESTINATION_COLOR = Color.green;

		[FoldoutGroup(EDITOR_GROUP_MAIN)]
		[SerializeField]
		private float _maxSpeed = 200;

		[FoldoutGroup(EDITOR_GROUP_MAIN)]
		[SerializeField]
		private float _decelarationSpeed = 1;

		[FoldoutGroup(EDITOR_GROUP_MAIN)]
		[SerializeField]
		private float _stoppingDistance = 0.3f;

		[FoldoutGroup(EDITOR_GROUP_MAIN)]
		[SerializeField]
		private float _mass = 1;

		[FoldoutGroup(EDITOR_GROUP_MAIN)]
		[SerializeField]
		private float _radius = 3;

		[FoldoutGroup(EDITOR_GROUP_MAIN)]
		[SerializeField]
		private SteeringBehaviour _settings = new SteeringBehaviour();

		[FoldoutGroup(EDITOR_GROUP_SECURITY)]
		[SerializeField]
		private bool _enforceNonPenetrationConstraint = false;

		[FoldoutGroup(EDITOR_GROUP_SECURITY)]
		[SerializeField]
		private bool _forceToBeOnNavMesh = true;

		[FoldoutGroup(EDITOR_GROUP_SECURITY)]
		[SerializeField]
		private bool _recalculatePathIfStuck = true;

		[ShowInRuntime]
		private Vector2 _velocity = Vector2.zero;
		private Vector2 _destination = Vector2.zero;

		private Transform _cachedTransform = null;
		private Vector2 _coords = Vector2.zero;
		private bool _isStopped = true;
		#endregion Fields

		#region Properties
		public Vector2 Destination
		{
			get => _destination;

			set
			{
				_isStopped = false;
				_destination = value;
				_settings.EnableMoveTo();
				SetPathToDestination();
			}
		}

		public Vector2 CoordsPosition { get => _coords; /*set => _cachedTransform.position = value.ToXZ();*/ }
		public float Radius => _radius;
		public bool IsStopped => _isStopped;

		public Vector2 Heading => _cachedTransform.forward.GetVector2FromXZ();

		Vector3 ISpatialPartioningObject.WorldPosition
		{
			get => _cachedTransform.position;

			set
			{
				_cachedTransform.position = value;
				SetCoordsFromWorldPosition();
			}
		}

		public float MaxSpeed { get => _maxSpeed; set => _maxSpeed = value; }
		#endregion Properties

		#region Methods
		void Awake()
		{
			_cachedTransform = transform;
			SetCoordsFromWorldPosition();
		}

		private void Update()
		{
			UpdatePosition();

			if (_isStopped == false && DestinationReached() == true)
			{
				Stop();
			}
		}

		private void OnEnable()
		{
			SteeringBehaviourAgentsDetector.AddAgent(this);
		}

		private void OnDisable()
		{
			SteeringBehaviourAgentsDetector.RemoveAgent(this);
		}

		public bool DestinationReached()
		{
			return Vector3.Distance(transform.position, Destination.ToXZ()) <= _stoppingDistance;
		}

		public void Stop()
		{
			_isStopped = true;
			_settings.DisableMoveTo();
		}

		public NavMeshPath CalculatePath(Vector3 target)
		{
			var navMeshPath = new NavMeshPath();
			NavMesh.CalculatePath(transform.position, target, NavMesh.AllAreas, navMeshPath);

			return navMeshPath;
		}

		private void UpdatePosition()
		{
			UpdateVelocity();

			SetPosition(transform.position + _velocity.ToXZ() * Time.deltaTime);

			LookAtVelocity();

			if (_enforceNonPenetrationConstraint == true)
			{
				EnforceNonPenetrationConstraint();
			}

			if (_forceToBeOnNavMesh == true)
			{
				if (NavMesh.SamplePosition(transform.position, out NavMeshHit hit, 10, NavMesh.AllAreas))
				{
					SetPosition(hit.position);
				}
			}

			if (_recalculatePathIfStuck == true)
			{
				bool stuck = DestinationReached() == false && Time.frameCount % 30 == 0;

				if (stuck == true)
				{
					SetPathToDestination();
				}
			}
		}

		private void SetCoordsFromWorldPosition()
		{
			_coords = _cachedTransform.position.GetVector2FromXZ();
		}

		private void UpdateVelocity()
		{
			UpdateSteeringBehaviourSettings();

			Vector2 steeringForce = _settings.CalculateVelocity(Destination, transform.position.GetVector2FromXZ(), _velocity, GetNeighbors());

			Debug.LogFormat("SteeringBehaviourAgent {0} has {1} neighbors.", name, GetNeighbors().Count());

			if (steeringForce != Vector2.zero)
			{
				Vector2 acceleration = steeringForce / _mass;
				Debug.DrawRay(transform.position, acceleration.ToXZ() * 2, ACCELERATION_COLOR);

				_velocity += acceleration * Time.deltaTime;
				_velocity = _velocity.Min(_maxSpeed);
			}
			else
			{
				DecelerateVelocity();
			}
		}

		private void DecelerateVelocity()
		{
			_velocity = Vector3.MoveTowards(_velocity, Vector2.zero, _decelarationSpeed * Time.deltaTime);
		}

		private void SetPosition(Vector3 position)
		{
			SteeringBehaviourAgentsDetector.MoveAgent(this, position);
		}

		[Button]
		[ShowInRuntime]
		private IEnumerable<SteeringBehaviourAgent> GetNeighbors()
		{
			return SteeringBehaviourAgentsDetector.GetNeighbors(transform.position, _radius);
		}

		private void EnforceNonPenetrationConstraint()
		{
			throw new System.NotImplementedException();
		}

		private void SetPathToDestination()
		{
			_settings.EnablePathFollowing();
			_settings.Path = CalculatePathTo(_destination);
		}

		private void UpdateSteeringBehaviourSettings()
		{
			_settings.MaxSpeed = _maxSpeed;
			_settings.Construct(this, _maxSpeed);
		}

		private void LookAtVelocity()
		{
			if (_velocity.sqrMagnitude > 0.00000001f)
			{
				float angle = Mathf.Atan2(_velocity.y, _velocity.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
			}
		}

		private Path CalculatePathTo(Vector2 target)
		{
			NavMeshPath path = new NavMeshPath();
			bool succesful = NavMesh.CalculatePath(transform.position, target.ToXZ(), NavMesh.AllAreas, path);

			if (succesful == false)
			{
				string message = string.Format("The entity \"{0}\" cannot get path to {1}. The path has been draw in the inspector in red for 30 seconds", name, target);

				Debug.LogError(message);
				Debug.DrawLine(transform.position, target.ToXZ(), Color.red, 30);
			}

			List<Vector2> waypoints = new List<Vector2>();

			foreach (var waypoint in path.corners)
			{
				waypoints.Add(waypoint.GetVector2FromXZ());
			}

			return new Path(waypoints.ToArray());
		}
		#endregion Methods
	}

#if UNITY_EDITOR
	public partial class SteeringBehaviourAgent
	{
		private void OnDrawGizmos()
		{
			if (Application.isPlaying == true)
			{
				Gizmos.color = VELOCITY_COLOR;
				Gizmos.DrawRay(transform.position, _velocity.ToXZ() * 2);

				Gizmos.color = DESTINATION_COLOR;
				Gizmos.DrawLine(transform.position, _destination.ToXZ());
			}

			Editor.HandlesHelper.DrawWireCircle(transform.position, Vector3.up, _radius, Color.white);
		}
	}
#endif
}
