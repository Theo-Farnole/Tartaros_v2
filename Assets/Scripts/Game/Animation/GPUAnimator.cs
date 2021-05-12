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

		[ShowInRuntime]
		private AnimationClip CurrentClip => _currentClipInfo.clip;

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

		private void Start()
		{
			CrossToWantedClip();
		}

		private void Update()
		{
			if (_animator != null)
			{
				AnimatorClipInfo wantedClip = _animator.GetCurrentAnimatorClipInfo(0)[0];

				if (wantedClip.clip.name != _animationInstancing.GetCurrentAnimationName())
				{
					CrossToWantedClip();
				}
			}
		}

		private void CrossToWantedClip()
		{
			AnimatorClipInfo wantedClip = _animator.GetCurrentAnimatorClipInfo(0)[0];
			_currentClipInfo = wantedClip;
			_animationInstancing.CrossFade(_currentClipInfo.clip.name, _animationInterpolationDuration);
		}
		#endregion Methods
	}
}