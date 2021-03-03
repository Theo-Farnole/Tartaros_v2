namespace Tartaros.Utilities
{
	using UnityEngine;

	public class GizmosWireSphere : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private Color _sphereColor = Color.red;

		[SerializeField]
		private float _sphereRadius = 1f;

		[SerializeField]
		private bool _drawOnSelectedOnly = false;
		#endregion Fields

		#region Methods
		private void OnDrawGizmos()
		{
			DrawSphere();
		}

		private void OnDrawGizmosSelected()
		{
			if (_drawOnSelectedOnly == true)
			{
				DrawSphere();
			}
		}

		void DrawSphere()
		{
			Gizmos.color = _sphereColor;
			Gizmos.DrawWireSphere(transform.position, _sphereRadius);
		}
		#endregion Methods
	}
}