namespace Tartaros.Entities.State
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	
	using Tartaros.Entities;
	using Tartaros.Entities.Detection;
	using Tartaros.OrderGiver;
	using Tartaros.Entities.Attack;

	public class StateIdle : AEntityState
	{

		#region Fields
		private readonly EntityMovement _entityMovement = null;
		private readonly EntityDetection _entityDetection = null;
		private readonly EntityAttack _entityAttack = null;
		#endregion Fields

		#region Properties
		private bool ShouldTryAttackNearest => _entityAttack != null;
		#endregion Properties

		#region Ctor
		public StateIdle(Entity stateOwner) : base(stateOwner)
		{
			_entityMovement = stateOwner.GetComponent<EntityMovement>();
			_entityDetection = stateOwner.GetComponent<EntityDetection>();
			_entityAttack = stateOwner.GetComponent<EntityAttack>();
		}
		#endregion Ctor

		#region Methods
		public override void OnStateEnter()
		{
			base.OnStateEnter();

			if (_entityMovement != null)
			{
				_entityMovement.StopMovement();
			}
		}

		public override void OnUpdate()
		{
			if (ShouldTryAttackNearest == true)
			{
				_entityAttack.TryOrderAttackNearestOpponent();
			}
		}
		#endregion Methods
	}

}