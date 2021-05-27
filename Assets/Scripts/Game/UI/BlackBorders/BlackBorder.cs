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
		private RectTransform _rectTransform = null;

		private TweenerCore<Vector2, Vector2, VectorOptions> _tweener = null;
		#endregion Fields

		#region Properties
		public Vector2 HideSize => new Vector2(_rectTransform.sizeDelta.x, 0);
		public Vector2 ShowSize => new Vector2(_rectTransform.sizeDelta.x, _height);
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();

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
