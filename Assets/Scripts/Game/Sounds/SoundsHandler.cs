namespace Tartaros.SoundsSystem
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
		[SerializeField] private AudioSource[] _ordersPatrols = new AudioSource[0];
		[SerializeField] private AudioSource[] _ordersStop = new AudioSource[0];
		[SerializeField] private AudioSource[] _ordersMove = new AudioSource[0];
		[SerializeField] private AudioSource[] _ordersMoveAttack = new AudioSource[0];
		[SerializeField] private AudioSource[] _ordersAttack = new AudioSource[0];
		[SerializeField] private AudioSource[] _buttonClicked = new AudioSource[0];

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
				{ Sound.OrderPatrol, _ordersPatrols },
				{ Sound.OrderStop, _ordersStop },
				{ Sound.OrderMove, _ordersMove },
				{ Sound.OrderMoveAttack, _ordersMoveAttack },
				{ Sound.OrderAttack, _ordersAttack },
				{ Sound.ButtonClick, _buttonClicked },
			};

			CheckAudioSourcesErrors();
		}

		public void PlayOneShot(Sound sound)
		{
			if (_audioSources.IsEmpty() == false)
			{
				AudioSource audioSource = _audioSources[sound].GetRandom();
				audioSource.PlayOneShot(audioSource.clip);

				Debug.Assert(audioSource.clip != null, "Audio source {0} to play is unset.".Format(audioSource.clip));
				Debug.LogFormat("Audio {0} played.", audioSource.name);
			}
		}

		public void Play(Sound sound)
		{
			if (_audioSources.IsEmpty() == false)
			{
				AudioSource audioSource = _audioSources[sound].GetRandom();
				audioSource.Play();
			}
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
