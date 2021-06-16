namespace Tartaros.Dialogue
{
	using Sirenix.OdinInspector;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	public class DialoguesData : SerializedScriptableObject
	{
		[SerializeField] private Dictionary<string, DialoguesSequence> _idByDialogue = null;
		
		public DialoguesSequence GetDialoguesSequence(string id)
		{
			if (_idByDialogue.ContainsKey(id) == false) throw new System.Exception("No dialogue corresponding to id \"{0}\".".Format(id));

			return _idByDialogue[id];
		}

		private void OnValidate()
		{
			_idByDialogue = _idByDialogue.ToDictionary(x => x.Key.Trim(), x => x.Value);
		}
	}
}