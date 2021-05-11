namespace Tartaros
{
	using UnityEngine;
	using UnityEngine.UI;

	[RequireComponent(typeof(Image))]
	public class DisableImageIfSpriteIsNull : MonoBehaviour
	{
		private Image _image = null;

		private void Awake()
		{
			_image = GetComponent<Image>();
		}

		private void Update()
		{
			_image.color = _image.overrideSprite != null ? Color.white : Color.clear;
		}
	}
}