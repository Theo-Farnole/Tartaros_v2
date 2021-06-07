namespace Tartaros.SoundsSystem
{
	using Sirenix.OdinInspector;
	using Sirenix.Serialization;
	using System.Collections.Generic;
	using Tartaros.Entities;
	using Tartaros.Map;
	using Tartaros.Selection;
	using UnityEngine;

	public class SoundsData : SerializedScriptableObject
	{
		[Title("Selection")]
		[OdinSerialize] private Dictionary<EntityData, AudioClip[]> _selectionClips = new Dictionary<EntityData, AudioClip[]>();
		[SerializeField] private AudioClip[] _sectors = new AudioClip[0];
		[SerializeField] private AudioClip[] _fallbackSelectionClip = new AudioClip[0];

		public AudioClip GetSelectionClip(ISelectable selectable)
		{
			if (selectable.GameObject.TryGetComponent(out Entity entity))
			{
				if (_selectionClips.TryGetValue(entity.EntityData, out AudioClip[] audioClips))
				{
					if (audioClips.Length > 0)
					{
						return audioClips.GetRandom();
					}
					else
					{
						return _fallbackSelectionClip.GetRandom();
					}
				}
				else
				{
					return _fallbackSelectionClip.GetRandom();
				}
			}
			else if (selectable.GameObject.TryGetComponent(out ISector sector))
			{
				return _sectors.GetRandom();
			}
			else
			{
				return _fallbackSelectionClip.GetRandom();
			}
		}
	}
}
