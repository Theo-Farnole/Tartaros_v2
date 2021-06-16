namespace Tartaros.Dialogue
{
	using Sirenix.OdinInspector;
	using UnityEngine;

	[System.Serializable]
	public class Dialogue
	{		
		[SerializeField, AssetSelector, AssetsOnly] CharacterActorData _character = null;
		[SerializeField] private string _speech = null;

		[SerializeField] private bool _useCharacterActor = true;
		[SerializeField, AssetSelector, AssetsOnly, HideIf(nameof(_useCharacterActor))] private AudioClip _backgroundAudio = null;

		public Sprite SpeakerAvatar => _character.Avatar;
		public string SpeakerName => _character.Name;
		public string Speech => _speech;
		public AudioClip BackgroundAudio => _useCharacterActor == true ? _character.FallbackBackground : _backgroundAudio;
	}

}