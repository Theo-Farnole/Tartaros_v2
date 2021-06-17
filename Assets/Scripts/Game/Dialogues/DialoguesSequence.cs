namespace Tartaros.Dialogue
{
	using Sirenix.OdinInspector;
	using UnityEngine;

	public class DialoguesSequence : ScriptableObject
	{

		[SerializeField, SuffixLabel("play next dialogue when this is over")] private DialoguesSequence _nextDialogue = null;
		[SerializeField] private CameraFocus _beforeDialogueFocus = CameraFocus.None;
		[SerializeField] private Dialogue[] _dialogues = null;

		public bool IsNextDialogue => _nextDialogue != null;
		public DialoguesSequence NextDialogue => _nextDialogue;
		public int DialoguesCount => _dialogues.Length;

		public Vector3? BeforeDialogueCameraDestination => _beforeDialogueFocus.GetDestination();

		public Dialogue GetDialogue(int dialogueIndex)
		{
			if (dialogueIndex < 0 || dialogueIndex + 1 > _dialogues.Length) throw new System.IndexOutOfRangeException("Dialogue at index {0} doesn't exists".Format(dialogueIndex));

			return _dialogues[dialogueIndex];
		}
	}
}