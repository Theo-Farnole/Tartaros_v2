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
			if (dialogueIndex < 0) throw new System.NotSupportedException("The provided speech index is negative. There is no negative speeches. Specify a positive index please");
			if (dialogueIndex > _dialogues.Length) throw new System.NotSupportedException("The provided speech index is greater than the speeches counts. Specify a index lesser than speeches count.");

			return _dialogues[dialogueIndex];
		}
	}
}