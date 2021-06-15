namespace Tartaros.SoundsSystem
{
	using Tartaros;
	using UnityEngine;

	[RequireComponent(typeof(AudioSource))]
	public class AudioSourceList : MonoBehaviour
	{
		#region Fields
		[SerializeField] private AudioClip[] _audioClips = null;

		private AudioSource _audioSource = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_audioSource = GetComponent<AudioSource>();
		}

		public void Play()
		{
			_audioSource.clip = _audioClips.GetRandom();
			_audioSource.Play();
		}

		public void Stop()
		{
			_audioSource.Stop();
		}

		public void PlayOneShot()
		{
			_audioSource.PlayOneShot(_audioClips.GetRandom());
		}

		public void PlayClipWithoutInstance()
		{
			AudioSource.PlayClipAtPoint(_audioClips.GetRandom(), transform.position);
		}
		#endregion Methods
	}
}
