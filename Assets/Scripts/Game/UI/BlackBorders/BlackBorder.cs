namespace Tartaros.UI.Dialog
{
	using DG.Tweening;
	using DG.Tweening.Core;
	using DG.Tweening.Plugins.Options;
	using UnityEngine;

	[RequireComponent(typeof(RectTransform))]
	public class BlackBorder : MonoBehaviour
	{
		#region Fields
		[SerializeField] private Ease _ease = Ease.OutCirc;
		[SerializeField] private float _easeDurationInSeconds = 1f;

		private float _height = -1;
		private TweenerCore<Vector2, Vector2, VectorOptions> _tweener = null;

		private RectTransform _rectTransform = null;
		#endregion Fields

		#region Properties
		public Vector2 HideSize => new Vector2(RectTransform.sizeDelta.x, 0);
		public Vector2 ShowSize => new Vector2(RectTransform.sizeDelta.x, _height);

		public RectTransform RectTransform
		{
			get
			{
				if (_rectTransform == null)
				{
					_rectTransform = GetComponent<RectTransform>();
				}

				return _rectTransform;
			}
		}
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_height = _rectTransform.sizeDelta.y;
		}

		public void Show(bool show)
		{
			//return;
			if (_tweener != null)
			{
				_tweener.Kill(true);
			}

			// set default size
			_rectTransform.sizeDelta = show == true ? HideSize : ShowSize;


			Vector2 targetSize = show == true ? ShowSize : HideSize;

			_tweener = _rectTransform
				.DOSizeDelta(targetSize, _easeDurationInSeconds)
				.SetEase(_ease)
				.SetUpdate(true);
		}
		#endregion Methods
	}
}
