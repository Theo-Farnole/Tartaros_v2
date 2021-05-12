namespace Tartaros.Dialogue
{
	using System.Collections;
	using UnityEngine;

	[System.Serializable]
	public class DialogueSequence
	{
		[SerializeField] private SpeechSequence[] _dialogue = null;
		[SerializeField] private Transform _cameraTarget = null;

		public SpeechSequence[] Dialogue => _dialogue;
		public Transform CameraTarget => _cameraTarget;
	}
}