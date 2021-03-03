using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tartaros.Utilities;
using Tartaros.Entities;

public class StateAttack : AEntityState
{
    Entity target;

	public StateAttack(Entity stateOwner) : base(stateOwner)
	{
	}

	public override void OnUpdate()
	{
		throw new System.NotImplementedException();
	}
}