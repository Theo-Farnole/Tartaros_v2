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
		[SerializeField] private AudioClip[] _fallbackBackground = new AudioClip[0];

		public Sprite Avatar => _avatar;
		public string Name => _name;
		public AudioClip FallbackBackground => _fallbackBackground.Length == 0 ? null : _fallbackBackground.GetRandom();
	}
}