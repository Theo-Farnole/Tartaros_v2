using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tartaros.Utilities;
using Tartaros.Entities;

public class StatePatrol : AEntityState
{
    readonly Vector3[] targetPoints;

	public StatePatrol(Entity stateOwner) : base(stateOwner)
	{
	}

	public override void OnUpdate()
	{
		throw new System.NotImplementedException();
	}
}