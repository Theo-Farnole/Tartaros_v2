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
		private readonly EntityAttack _entityAttack = null;
		#endregion Fields

		#region Properties
		private bool CanTryAttackNearest => _entityAttack != null;
		#endregion Properties

		#region Ctor
		public StateIdle(Entity stateOwner) : base(stateOwner)
		{
			_entityMovement = stateOwner.GetComponent<EntityMovement>();
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
			if (CanTryAttackNearest == true)
			{
				_entityAttack.TryOrderAttackNearestOpponent();
			}
		}
		#endregion Methods
	}

}