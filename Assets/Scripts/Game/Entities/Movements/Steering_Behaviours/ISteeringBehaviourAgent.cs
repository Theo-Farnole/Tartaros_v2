namespace Tartaros.Entities.Movement
{
	using UnityEngine;

	public interface ISteeringBehaviourAgent
	{
		Vector2 Position { get; set; }
		float Radius { get; }
		Vector2 Heading { get; }
	}
}
