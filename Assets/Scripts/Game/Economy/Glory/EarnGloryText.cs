namespace Tartaros.UI
{
	using DG.Tweening;
	using Sirenix.OdinInspector;
	using TMPro;
	using UnityEngine;

	public class EarnGloryText : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private TextMeshPro _gloryLabel = null;

		[SerializeField]
		private float _lifetime = 2;

		[FoldoutGroup("Animation")]
		[SerializeField]
		private float _delayBeforeFade = 1f;

		[FoldoutGroup("Animation")]
		[SerializeField]
		private float _localMoveY = 2;

		private int _earnedGloryAmount = 0;
		#endregion Fields

		#region Properties
		public int EarnedGloryAmount
		{
			get => _earnedGloryAmount;

			set
			{
				_earnedGloryAmount = value;
				UpdateGloryLabel();
			}
		}
		#endregion Properties

		#region Methods
		private void Start()
		{
			var m_Camera = Camera.main;
			transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
			m_Camera.transform.rotation * Vector3.up);

			Destroy(gameObject, _lifetime);

			transform.DOLocalMoveY(_localMoveY, _lifetime - _delayBeforeFade).SetDelay(_delayBeforeFade).SetEase(Ease.OutCubic);
			_gloryLabel.DOFade(0, _lifetime);
		}

		private void Update()
		{
			
		}

		private void UpdateGloryLabel()
		{
			_gloryLabel.text = "{0}{1}".Format(GetPrefix(), _earnedGloryAmount.ToString());
		}

		private string GetPrefix()
		{
			if (_earnedGloryAmount > 0)
			{
				return "+";
			}
			else if (_earnedGloryAmount < 0)
			{
				return "-";
			}
			else
			{
				return string.Empty;
			}
		}
		#endregion Methods
	}
}
