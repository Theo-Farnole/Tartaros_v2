namespace Tartaros.Entities
{
	using Tartaros.Entities.Detection;
	using Tartaros.ServicesLocator;

	/// <summary>
	/// When 
	/// </summary>
	public class TransitiveStopEmitter
	{
		#region Fields
		private const float TRANSITIVE_STOP_RADIUS_THRESHOLD = 0.05f;

		private readonly EntityMovement _entityMovement;
		private readonly EntitiesDetectorManager _entitiesDetectorManager;
		private readonly float _stopRadius = 0.7f;
		private readonly Entity _entity = null;
		#endregion Fields

		#region Properties
		public Team EntityTeam => _entityMovement.Entity.Team;
		#endregion Properties

		#region Ctor
		public TransitiveStopEmitter(EntityMovement entityMovement)
		{
			_entityMovement = entityMovement;
			_stopRadius = entityMovement.AvoidanceRadius * 2 + TRANSITIVE_STOP_RADIUS_THRESHOLD;
			_entitiesDetectorManager = Services.Instance.Get<EntitiesDetectorManager>();
			_entity = entityMovement.Entity;
		}
		#endregion Ctor

		#region Methods
		// on stop
		public void EmitStop()
		{
			// 1. get nearest entities in radius
			Entity[] entities = _entitiesDetectorManager.GetEntitiesInRadius(EntityTeam, _entityMovement.transform.position, _stopRadius);

			// 2. stop them if they have the same destination
			for (int i = 0, length = entities.Length; i < length; i++)
			{
				Entity entity = entities[i];

				if (entity == _entity) continue;

				if (entity.TryGetComponent(out EntityMovement movement))
				{
					if (IsMovingToMyDestination(movement))
					{
						movement.StopMovementFromTransitiveStop(_entityMovement.gameObject);
					}
				}
			}

		}

		private bool IsMovingToMyDestination(EntityMovement movement)
		{
			return movement.IsMoving == true && movement.Destination == _entityMovement.Destination;
		}
		#endregion Methods
	}
}
