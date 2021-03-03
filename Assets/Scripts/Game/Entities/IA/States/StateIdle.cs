using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tartaros.Utilities;
using Tartaros.Entities;

public class StateIdle : AEntityState
{
	public StateIdle(Entity stateOwner) : base(stateOwner)
	{
	}

	public override void OnUpdate()
	{
		throw new System.NotImplementedException();
	}
}
