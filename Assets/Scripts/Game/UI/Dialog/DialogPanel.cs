namespace Tartaros.UI.Dialog
{
	using Tartaros.Dialogue;
	using Tartaros.ServicesLocator;
	using Tartaros.UI;
	using Tartaros.Wave;
	using TMPro;
	using UnityEngine;
	using UnityEngine.UI;

	public class DialogPanel : APanel
	{
		#region Fields
		[SerializeField] private TextMeshProUGUI _speakerName = null;
		[SerializeField] private Image _speakerAvatar = null;
		[SerializeField] private TextMeshProUGUI _content = null;
		[SerializeField] private Button _nextButton = null;

		// SERVICES
		private DialogueManager _dialogueManager = null;
		#endregion Fields

		#region Methods
		protected override void Awake()
		{
			base.Awake();
			_dialogueManager = Services.Instance.Get<DialogueManager>();

			if (_speakerAvatar is null) throw new MissingReferenceException(nameof(_speakerAvatar));
			if (_speakerName is null) throw new MissingReferenceException(nameof(_speakerName));
			if (_content is null) throw new MissingReferenceException(nameof(_content));
		}

		private void OnEnable()
		{
			_dialogueManager.NewSpeech -= NewSpeech;
			_dialogueManager.NewSpeech += NewSpeech;

			_nextButton.onClick.RemoveListener(OnNextButtonClicked);
			_nextButton.onClick.AddListener(OnNextButtonClicked);
		}

		private void OnDisable()
		{
			_dialogueManager.NewSpeech -= NewSpeech;

			_nextButton.onClick.RemoveListener(OnNextButtonClicked);
		}

		private void OnNextButtonClicked()
		{
			_dialogueManager.ShowNextLine();
		}

		private void NewSpeech(object sender, DialogueManager.NewSpeechArgs e)
		{
			Show();

			SetSpeech(e.speech);
		}

		private void SetSpeech(SpeechSequence speechSequence)
		{
			_speakerName.text = speechSequence.SpeakerName;
			_speakerAvatar.sprite = speechSequence.SpeakerAvatar;
			_content.text = speechSequence.Speech;
		}
		#endregion Methods
	}
}
