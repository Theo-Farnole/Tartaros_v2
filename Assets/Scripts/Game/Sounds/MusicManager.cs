namespace Tartaros.SoundsSystem
{
	using System.Collections.Generic;
	using UnityEngine;

	public class MusicManager : MonoBehaviour
	{
		#region Enums
		public enum MusicPhase
		{
			None = 0,
			Construction,
			Defend
		}
		#endregion Enums

		#region Fields
		[SerializeField] private AudioSourceList _constructionMusics = null;
		[SerializeField] private AudioSourceList _defendMusics = null;
		[Space]
		[SerializeField] private float _volumeFadeDuration = 1f;
		[SerializeField] private MusicPhase _defaultPhase = MusicPhase.Construction;

		private Dictionary<MusicPhase, AudioSourceList> _musicsByPhase = null;

		private MusicPhase _currentMusic = MusicPhase.None;
		#endregion Fields

		#region Properties
		public MusicPhase CurrentMusic
		{
			get => _currentMusic;

			set
			{
				Debug.LogFormat("Set phase from {0} to {1}.", _currentMusic, value);
				_currentMusic = value;

				PlayPhaseMusic(_currentMusic);
			}
		}
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_musicsByPhase = new Dictionary<MusicPhase, AudioSourceList>()
			{
				{ MusicPhase.Construction, _constructionMusics },
				{ MusicPhase.Defend, _defendMusics },
			};

			_currentMusic = _defaultPhase;
		}

		private void Start()
		{
			PlayPhaseMusic(_currentMusic);
		}

		private void PlayPhaseMusic(MusicPhase music)
		{
			foreach (KeyValuePair<MusicPhase, AudioSourceList> kvp in _musicsByPhase)
			{
				AudioSourceList audioList = kvp.Value;

				if (kvp.Key == music)
				{
					audioList.Play();
				}
				else
				{
					audioList.Stop();
				}
			}
		}
		#endregion Methods
	}
}
