namespace Tartaros.Entities.Movement
{
	using Sirenix.OdinInspector;
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Utilities.SpatialPartioning;
	using TMPro;
	using UnityEngine;
	using UnityEngine.AI;

	[SelectionBase]
	public partial class SteeringBehaviourAgent : MonoBehaviour, ISteeringBehaviourAgent
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
		#endregion Fields

		#region Properties
		public Vector2 Destination
		{
			get => _destination;

			set
			{
				_destination = value;
				SetPathToDestination();
			}
		}

		Vector2 ISteeringBehaviourAgent.Position { get => transform.position.GetVector2FromXZ(); set => transform.position = value.ToXZ(); }
		float ISteeringBehaviourAgent.Radius => _radius;

		Vector2 ISteeringBehaviourAgent.Heading => transform.forward.GetVector2FromXZ();

		Vector3 ISpatialPartioningObject.WorldPosition { get => _cachedTransform.position; set => transform.position = value; }
		#endregion Properties

		#region Methods
		void Awake()
		{
			_cachedTransform = transform;
		}

		private void Update()
		{
			UpdatePosition();
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

		private void UpdateVelocity()
		{
			UpdateSteeringBehaviourSettings();

			Vector2 steeringForce = _settings.CalculateVelocity(Destination, transform.position.GetVector2FromXZ(), _velocity, GetNeighbors());

			if (steeringForce != Vector2.zero)
			{
				Vector2 acceleration = steeringForce / _mass;
				Debug.DrawRay(transform.position, acceleration.ToXZ() * 2, ACCELERATION_COLOR);

				_velocity += acceleration * Time.deltaTime;
				_velocity = _velocity.Min(_maxSpeed);
			}
			else
			{
				_velocity = Vector3.MoveTowards(_velocity, Vector2.zero, _decelarationSpeed * Time.deltaTime);
			}
		}

		private void SetPosition(Vector3 position)
		{
			SteeringBehaviourAgentsDetector.MoveAgent(this, position);
		}

		[Button]
		[ShowInRuntime]
		private ISteeringBehaviourAgent[] GetNeighbors()
		{
			return SteeringBehaviourAgentsDetector.GetAgentsInRadius(transform.position, _radius);
			//return SteeringBehaviourAgentsDetector.GetAgentsInRadius(transform.position, _radius).Where(x => x != this as ISteeringBehaviourAgent).ToArray();
		}

		private void EnforceNonPenetrationConstraint()
		{
			ISteeringBehaviourAgent self = (this as ISteeringBehaviourAgent);

			foreach (var neighbor in GetNeighbors())
			{
				var directionToNeighbor = self.Position - neighbor.Position;
				float distanceToNeighbor = directionToNeighbor.magnitude;

				float amountOfOverlap = self.Radius + neighbor.Radius - distanceToNeighbor;

				if (amountOfOverlap >= 0)
				{
					self.Position = self.Position + directionToNeighbor / distanceToNeighbor * amountOfOverlap;
				}
			}
		}

		private void SetPathToDestination()
		{
			if (NavMeshHelper.IsThereANavMeshInScene())
			{
				_settings.EnablePathFollowing();
				_settings.Path = CalculatePathTo(_destination);

			}
			else
			{
				_settings.DisablePathFollowing();
			}
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
				Debug.LogError("The entity \"{0}\" cannot get path to {1}. The path has been draw in the inspector in red for 30 seconds");
				Debug.DrawLine(transform.position, target.ToXZ(), Color.red, 30);

				// TODO: better handle this case
				throw new System.NotSupportedException();
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
