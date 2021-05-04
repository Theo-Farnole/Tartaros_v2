namespace Tartaros
{
	using AnimationInstancing;
	using Sirenix.OdinInspector;
	using UnityEngine;

	public class GPUAnimator : MonoBehaviour
	{
		#region Fields
		[SerializeField] private float _animationInterpolationDuration = 0.1f;

		[Title("References")]
		[SerializeField] private AnimationInstancing _animationInstancing = null;
		[SerializeField] private Animator _animator = null;

		private AnimatorClipInfo _currentClipInfo = default;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			if (_animationInstancing == null)
			{
				_animationInstancing = GetComponent<AnimationInstancing>();
			}

			if (_animationInstancing == null)
			{
				_animator = GetComponent<Animator>();
			}
		}

		private void Update()
		{
			if (_animator != null)
			{
				var clips = _animator.GetCurrentAnimatorClipInfo(0);

				AnimatorClipInfo clip = clips[0];

				if (clip.clip != _currentClipInfo.clip)
				{
					_currentClipInfo = clip;
					_animationInstancing.CrossFade(_currentClipInfo.clip.name, _animationInterpolationDuration);
				}
			}
		}
		#endregion Methods
	}
}