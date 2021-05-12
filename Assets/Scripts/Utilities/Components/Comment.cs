namespace Tartaros
{
	using Sirenix.OdinInspector;
	using UnityEngine;

	[InfoBox("An editor comment for developers | No impact on gameplay")]
	public class Comment : MonoBehaviour
	{
		#region Fields
		[TextArea(5, 1000)]
		[SerializeField]
#pragma warning disable IDE0051 // Remove unused private members
		private string _comment = null;
#pragma warning restore IDE0051 // Remove unused private members
		#endregion Fields
	}
}