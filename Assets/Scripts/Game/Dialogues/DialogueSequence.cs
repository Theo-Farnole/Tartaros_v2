namespace Tartaros.Dialogue
{
	using System.Collections;
	using UnityEngine;

	[System.Serializable]
	public class DialogueSequence
	{
		[SerializeField] private SpeechSequence[] _dialogue = null;
		[SerializeField] private bool _isCameraTarget = false;

		public SpeechSequence[] Dialogue => _dialogue;
		public bool IsCameraTarget => _isCameraTarget;
	}
}