using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tartaros.Utilities;
using Tartaros.Entities;

public class StateAggressiveMove : AEntityState
{
	Vector3 targetPoint = Vector3.zero;

	public StateAggressiveMove(Entity stateOwner) : base(stateOwner)
	{
	}

	public override void OnUpdate()
	{
		throw new System.NotImplementedException();
	}
}