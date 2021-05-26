namespace Tartaros.Dialogue
{
	using UnityEngine;

	public class DialoguesSequence : ScriptableObject
	{
		[SerializeField] private Dialogue[] _dialogues = null;
		[SerializeField] private bool _isCameraTarget = false;

		public bool IsCameraTarget => _isCameraTarget;
		public int DialoguesCount => _dialogues.Length;


		public Dialogue GetDialogue(int dialogueIndex)
		{
			if (dialogueIndex < 0 || dialogueIndex + 1 > _dialogues.Length) throw new System.IndexOutOfRangeException("Dialogue at index {0} doesn't exists".Format(dialogueIndex));

			return _dialogues[dialogueIndex];
		}
	}
}