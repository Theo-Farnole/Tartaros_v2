namespace Tartaros.Entities.Movement
{
	using Sirenix.OdinInspector;
	using System.Linq;
	using UnityEngine;

	public class SteeringBehaviourAgent : MonoBehaviour, ISteeringBehaviourAgent
	{
		#region Fields
		private static readonly Color ACCELERATION_COLOR = Color.yellow;
		private static readonly Color VELOCITY_COLOR = Color.blue;
		private static readonly Color DESTINATION_COLOR = Color.green;

		[SerializeField]
		private SteeringBehaviour _settings = new SteeringBehaviour();

		[SerializeField]
		private float _maxSpeed = 200;

		[SerializeField]
		private float _decelarationSpeed = 1;

		[SerializeField]
		private float _mass = 1;

		[SerializeField]
		private float _radius = 3;

		[ShowInRuntime]
		private Vector2 _velocity = Vector2.zero;
		private Vector2 _destination = Vector2.zero;
		#endregion Fields

		#region Properties
		public Vector2 Destination { get => _destination; set => _destination = value; }

		Vector2 ISteeringBehaviourAgent.Position => transform.position.GetVector2FromXZ();
		#endregion Properties

		#region Methods
		private void Update()
		{
			UpdatePosition();
		}

		private void OnDrawGizmos()
		{
			if (Application.isPlaying == true)
			{
				Gizmos.color = VELOCITY_COLOR;
				Gizmos.DrawRay(transform.position, _velocity.ToXZ() * 2);

				Gizmos.color = DESTINATION_COLOR;
				Gizmos.DrawLine(transform.position, _destination.ToXZ());

				Gizmos.color = Color.white;
				Gizmos.DrawWireSphere(transform.position, _radius);
			}
		}

		private void UpdatePosition()
		{
			UpdateVelocity();

			transform.position += _velocity.ToXZ() * Time.deltaTime;

			LookAtVelocity();
		}

		private void UpdateVelocity()
		{
			UpdateSteeringBehaviourSettings();
			ISteeringBehaviourAgent[] neightbors = GetNeighbors();

			Vector2 steeringForce = _settings.CalculateVelocity(Destination, transform.position.GetVector2FromXZ(), _velocity, neightbors);

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

		[Button]
		private ISteeringBehaviourAgent[] GetNeighbors()
		{
			return ObjectsFinder
				.FindObjectsOfInterface<ISteeringBehaviourAgent>()
				.Where(agent => agent != (this as ISteeringBehaviourAgent) && Vector3.Distance(transform.position, agent.Position) <= _radius)
				.ToArray();
		}

		private void UpdateSteeringBehaviourSettings()
		{
			_settings.MaxSpeed = _maxSpeed;
		}

		private void LookAtVelocity()
		{
			if (_velocity.sqrMagnitude > 0.00000001f)
			{
				float angle = Mathf.Atan2(_velocity.y, _velocity.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
			}
		}
		#endregion Methods
	}
}
