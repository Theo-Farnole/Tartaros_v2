namespace Tartaros
{
	using UnityEngine;

	public class CameraBillboard : MonoBehaviour
	{
		private void LateUpdate()
		{
			Camera main = Camera.main;
			transform.forward = new Vector3(main.transform.forward.x, transform.forward.y, main.transform.forward.z);
		}
	}
}