namespace Tartaros.Dialogue
{
	using Sirenix.OdinInspector;
	using System.Collections;
	using UnityEngine;

	public class DialoguesData : SerializedScriptableObject
	{
		[SerializeField] private DialogueSequence[] _dialogues = null;

		public DialogueSequence[] Dialogues => _dialogues;
	}
}