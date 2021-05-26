﻿namespace Tartaros.Dialogue
{
	using UnityEngine;

	public class DialoguesSequence : ScriptableObject
	{

		[SerializeField] private CameraFocus _beforeDialogueFocus = CameraFocus.None;
		[SerializeField] private CameraFocus _afterDialogueFocus = CameraFocus.None;
		[SerializeField] private Dialogue[] _dialogues = null;

		public int DialoguesCount => _dialogues.Length;

		public CameraFocus BeforeDialogueFocus => _beforeDialogueFocus;
		public CameraFocus AfterDialogueFocus => _afterDialogueFocus;

		public Dialogue GetDialogue(int dialogueIndex)
		{
			if (dialogueIndex < 0 || dialogueIndex + 1 > _dialogues.Length) throw new System.IndexOutOfRangeException("Dialogue at index {0} doesn't exists".Format(dialogueIndex));

			return _dialogues[dialogueIndex];
		}
	}
}