namespace Tartaros.Dialogue
{
	using Sirenix.OdinInspector;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	[System.Serializable]
	public class Dialogue
	{		
		[SerializeField, AssetSelector, AssetsOnly] CharacterActorData _character = null;
		[SerializeField] private string _speech = null;

		public Sprite SpeakerAvatar => _character.Avatar;
		public string SpeakerName => _character.Name;
		public string Speech => _speech;
	}

}