namespace Tartaros
{
	using UnityEngine;

	public class CameraBillboard : MonoBehaviour
	{
		private void LateUpdate()
		{
			transform.forward = -Camera.main.transform.forward;
		}
	}
}