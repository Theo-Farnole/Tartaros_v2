namespace Tartaros.Dialogue
{
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class LaunchDialogAtStart : MonoBehaviour
	{
		[SerializeField] private string _dialogueID = "";

		private DialogueManager _dialogueManager = null;

		private void Awake()
		{
			_dialogueManager = Services.Instance.Get<DialogueManager>();
		}

		private void Start()
		{
			_dialogueManager.EnterDialogueState(_dialogueID);
		}
	}
}
