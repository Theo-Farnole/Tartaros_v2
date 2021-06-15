namespace Tartaros
{
	using DG.Tweening;
	using UnityEngine;

	public static class AudioSourceExtensions
	{
		public static DG.Tweening.Core.TweenerCore<float, float, DG.Tweening.Plugins.Options.FloatOptions> DOVolume(this AudioSource audioSource, float volume, float duration)
		{
			return DOTween.To(() => audioSource.volume, x => audioSource.volume = x, volume, duration);
		}
	}
}
