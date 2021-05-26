namespace Tartaros.UI.Dialog
{
	using DG.Tweening;
	using DG.Tweening.Core;
	using DG.Tweening.Plugins.Options;
	using Tartaros.Dialogue;
	using Tartaros.ServicesLocator;
	using Tartaros.UI;
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

		[SerializeField] private BlackBorder[] _blackBorders = new BlackBorder[0];

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
			_dialogueManager.NewDialogue -= NewSpeech;
			_dialogueManager.NewDialogue += NewSpeech;

			_dialogueManager.DialogueOver -= OnDialogueOver;
			_dialogueManager.DialogueOver += OnDialogueOver;

			_nextButton.onClick.RemoveListener(OnNextButtonClicked);
			_nextButton.onClick.AddListener(OnNextButtonClicked);
		}

		private void OnDisable()
		{
			_dialogueManager.NewDialogue -= NewSpeech;
			_dialogueManager.DialogueOver -= OnDialogueOver;

			_nextButton.onClick.RemoveListener(OnNextButtonClicked);
		}

		private void OnNextButtonClicked()
		{
			_dialogueManager.ShowNextLine();
		}


		private void OnDialogueOver(object sender, DialogueManager.DialogueOverArgs e)
		{
			Hide();
		}


		private void NewSpeech(object sender, DialogueManager.NextDialogueArgs e)
		{
			Show();

			SetSpeech(e.speech);
		}

		private void SetSpeech(Dialogue speechSequence)
		{
			_speakerName.text = speechSequence.SpeakerName;
			_speakerAvatar.sprite = speechSequence.SpeakerAvatar;
			_content.text = speechSequence.Speech;
		}

		protected override void OnShow()
		{
			base.OnShow();

			CanvasHelper.SetActiveAllCanvasInScene(false, Canvas);
			ShowBlackBorder(true);
		}

		protected override void OnHide()
		{
			base.OnHide();

			CanvasHelper.SetActiveAllCanvasInScene(true, Canvas);
			ShowBlackBorder(false);
		}

		private void ShowBlackBorder(bool show)
		{
			foreach (var blackBorder in _blackBorders)
			{
				blackBorder.Show(show);
			}
		}
		#endregion Methods
	}
}
