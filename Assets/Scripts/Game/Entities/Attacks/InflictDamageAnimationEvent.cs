namespace Tartaros.Entities
{
	using System;
	using UnityEngine;

	public class InflictDamageAnimationEvent : MonoBehaviour
	{
		public class InflictDamageAnimationPlayedArgs : EventArgs { }
		public event EventHandler<InflictDamageAnimationPlayedArgs> InflictDamageAnimationPlayed = null;

		public void InvokeInflictDamageAnimationPlayed()
		{
			InflictDamageAnimationPlayed?.Invoke(this, new InflictDamageAnimationPlayedArgs());
		}
	}
}
