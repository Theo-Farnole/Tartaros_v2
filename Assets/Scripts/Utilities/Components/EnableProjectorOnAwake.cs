namespace Tartaros
{
	using UnityEngine;

	[RequireComponent(typeof(Projector))]
	public class EnableProjectorOnAwake : MonoBehaviour
	{
		private void Awake()
		{
			GetComponent<Projector>().enabled = true;
		}
	}
}
