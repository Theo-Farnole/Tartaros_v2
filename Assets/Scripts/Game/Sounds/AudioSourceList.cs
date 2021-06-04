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
		private void Start()
		{
			_audioSource = GetComponent<AudioSource>();
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
