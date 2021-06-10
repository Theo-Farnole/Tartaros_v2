namespace Tartaros.Entities
{
	using UnityEngine;

	[System.Serializable]
	public class DeadbodyData
	{
		[SerializeField] private float _lifetime = 3;

		public float Lifetime => _lifetime;
	}
}
