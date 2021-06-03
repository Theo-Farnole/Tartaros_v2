namespace Tartaros.SoundSystem
{
	using Sirenix.OdinInspector;
	using Sirenix.Utilities;
	using System.Collections.Generic;
	using Tartaros.SoundsSystem;
	using UnityEngine;

	public class SoundsHandler : MonoBehaviour
	{
		#region Fields
		[SerializeField] private AudioSource[] _waveStart = new AudioSource[0];
		[SerializeField] private AudioSource[] _waveEnd = new AudioSource[0];
		[SerializeField] private AudioSource[] _unitSpawn = new AudioSource[0];

		private Dictionary<Sound, AudioSource[]> _audioSources = null;
		#endregion Fields

		#region Methods
		private void Start()
		{
			_audioSources = new Dictionary<Sound, AudioSource[]>()
			{
				{ Sound.WaveStart, _waveStart },
				{ Sound.WaveEnd, _waveEnd },
				{ Sound.UnitSpawn, _unitSpawn },
			};

			CheckAudioSourcesErrors();
		}

		public void PlayOneShot(Sound sound)
		{
			AudioSource audioSource = _audioSources[sound].GetRandom();
			audioSource.PlayOneShot(audioSource.clip);

			Debug.Assert(audioSource.clip != null, "Audio source {0} to play is unset.".Format(audioSource.clip));
			Debug.LogFormat("Audio {0} played.", audioSource.name);
		}

		private void CheckAudioSourcesErrors()
		{
			IsAudioSourcesMissings();

			void IsAudioSourcesMissings()
			{
				foreach (var soundEnum in EnumHelper.GetValues<Sound>())
				{
					if (_audioSources.ContainsKey(soundEnum) == false)
					{
						Debug.LogErrorFormat("Missing audio sources for sound {0}.", soundEnum);
					}
				}
			}
		}
		#endregion Methods
	}
}
