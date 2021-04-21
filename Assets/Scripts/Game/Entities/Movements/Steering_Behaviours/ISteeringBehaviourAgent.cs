namespace Tartaros.Entities.Movement
{
	using Tartaros.Utilities.SpatialPartioning;
	using UnityEngine;

	public interface ISteeringBehaviourAgent : ISpatialPartioningObject
	{
		Vector2 Position { get; set; }
		float Radius { get; }
		Vector2 Heading { get; }
	}
}
