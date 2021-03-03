using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tartaros.Utilities;
using Tartaros.Entities;

public class StateMove : AEntityState
{
    Vector3 targetPoint;

	public StateMove(Entity stateOwner) : base(stateOwner)
	{
	}

	public override void OnUpdate()
	{
		throw new System.NotImplementedException();
	}
}