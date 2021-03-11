namespace Tartaros.Entities.State
{
	using UnityEngine;

	public class StateFollow : AEntityState
	{
		#region Fields
		private readonly Transform _toFollow = null;
		private readonly EntityMovement _entityMovement = null;
		#endregion Fields

		#region Ctor
		public StateFollow(Entity stateOwner, Transform toFollow) : base(stateOwner)
		{
			_toFollow = toFollow;

			_entityMovement = stateOwner.GetComponent<EntityMovement>();
		}
		#endregion Ctor

		#region Methods
		public override void OnStateEnter()
		{
			base.OnStateEnter();

			_entityMovement.MoveToPoint(_toFollow.position);
		}

		public override void OnStateExit()
		{
			base.OnStateExit();

			_entityMovement.StopMovement();
		}

		public override void OnUpdate()
		{
			_entityMovement.MoveToPoint(_toFollow.position);
		}
		#endregion Methods
	}
}
