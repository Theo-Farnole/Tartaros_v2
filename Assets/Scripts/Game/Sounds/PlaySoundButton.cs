namespace Tartaros.SoundsSystem
{
	using Tartaros.ServicesLocator;
	using Tartaros.UI;
	using UnityEngine;

	public class PlaySoundButton : AButtonActionAttacher
	{
		#region Fields
		[SerializeField] private Sound _sound = Sound.ButtonClick;

		private SoundsHandler _soundsHandler = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_soundsHandler = Services.Instance.Get<SoundsHandler>();
		}

		protected override void OnButtonClick()
		{
			_soundsHandler.PlayOneShot(_sound);
		}
		#endregion Methods
	}
}