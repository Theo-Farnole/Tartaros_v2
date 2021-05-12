namespace Tartaros.Dialogue
{
	using Sirenix.OdinInspector;
	using System.Collections;
	using UnityEngine;
	using UnityEngine.UI;

	[System.Serializable]
	public class CharacterActorData : SerializedScriptableObject
	{
		[SerializeField, PreviewField] private Sprite _avatar = null;
		[SerializeField] private string _name = null;

		public Sprite Avatar => _avatar;
		public string Name => _name;
	}
}