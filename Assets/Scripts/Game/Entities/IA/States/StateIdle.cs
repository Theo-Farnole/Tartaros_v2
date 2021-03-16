namespace Tartaros.Entities.State
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Tartaros.Utilities;
	using Tartaros.Entities;

	public class StateIdle : AEntityState
	{

		private readonly EntityMovement _entityMovement = null;
		public StateIdle(Entity stateOwner) : base(stateOwner)
		{
			_entityMovement = stateOwner.GetComponent<EntityMovement>();
		}

		public override void OnStateEnter()
		{
			base.OnStateEnter();

			_entityMovement.StopMovement();
		}

		public override void OnUpdate()
		{
		}
	}

}