namespace Tartaros.Dialogue
{
	using Sirenix.OdinInspector;
	using System.Collections.Generic;
	using UnityEngine;

	public class DialoguesData : SerializedScriptableObject
	{
		[SerializeField] private Dictionary<string, DialoguesSequence> _idByDialogue = null;
		
		public DialoguesSequence GetDialoguesSequence(string id)
		{
			return _idByDialogue[id];
		}
	}
}