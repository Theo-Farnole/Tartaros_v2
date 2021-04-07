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
		private string _comment = null; 
		#endregion Fields
	}
}