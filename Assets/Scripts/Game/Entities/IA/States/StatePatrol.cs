namespace Tartaros.Entities.State
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Tartaros.Utilities;
	using Tartaros.Entities;

	public class StatePatrol : AEntityState
	{
		private readonly Vector3[] _targetPoints;

		public StatePatrol(Entity stateOwner, Vector3[] targetPoints) : base(stateOwner)
		{
			_targetPoints = targetPoints;
		}

		public override void OnUpdate()
		{
			throw new System.NotImplementedException();
		}
	}
}