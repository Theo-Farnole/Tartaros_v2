namespace Tartaros.Entities.State
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Tartaros.Utilities;
	using Tartaros.Entities;

	public class StateMove : AEntityState
	{
		private readonly Vector3 _targetPoint = Vector3.zero;

		public StateMove(Entity stateOwner, Vector3 targetPoint) : base(stateOwner)
		{
			_targetPoint = targetPoint;
		}

		public override void OnUpdate()
		{
			throw new System.NotImplementedException();
		}
	}
}