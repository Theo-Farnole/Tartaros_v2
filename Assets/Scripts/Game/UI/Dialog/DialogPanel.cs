namespace Tartaros.UI.Dialog
{
	using DG.Tweening;
	using DG.Tweening.Core;
	using DG.Tweening.Plugins.Options;
	using Sirenix.OdinInspector;
	using System.Collections.Generic;
	using Tartaros.Dialogue;
	using Tartaros.ServicesLocator;
	using Tartaros.UI;
	using TMPro;
	using UnityEngine;
	using UnityEngine.UI;

	public class DialogPanel : APanel
	{
		#region Fields

		[Title("Animation Settings")]
		[SerializeField] private float _textAnimationDurationPerCharacter = 0.01f;
		[SerializeField] private float _backgroundFadeInDuration = 0.3f;
		[SerializeField] private Ease _backgroundEase = Ease.InSine;

		[Title("UI References")]
		[SerializeField, SceneObjectsOnly] private TextMeshProUGUI _speakerName = null;
		[SerializeField, SceneObjectsOnly] private Image _background = null;
		[SerializeField, SceneObjectsOnly] private Image _speakerAvatar = null;
		[SerializeField, SceneObjectsOnly] private TextMeshProUGUI _content = null;
		[SerializeField, SceneObjectsOnly] private Button _nextButton = null;

		[SerializeField, SceneObjectsOnly] private Canvas[] _canvasesToHide = null;

		private Coroutine _textAnimationCoroutine = null;
		private Dialogue _dialogue = null;
		private float _backgroundAlpha = 0.8f;

		private List<Canvas> _disabledCanvases = new List<Canvas>(10);

		// SERVICES
		private DialogueManager _dialogueManager = null;
		private UIManager _uiManager = null;
		#endregion Fields

		#region Methods
		#region Mono Callbacks
		protected override void Awake()
		{
			base.Awake();
			_dialogueManager = Services.Instance.Get<DialogueManager>();
			_uiManager = Services.Instance.Get<UIManager>();
			_backgroundAlpha = _background.color.a;

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
		#endregion

		#region Events
		private void OnNextButtonClicked()
		{
			if (_content.text == _dialogue.Speech)
			{
				_dialogueManager.ShowNextLine();
			}
			else
			{
				StopCoroutine(_textAnimationCoroutine);
				_content.text = _dialogue.Speech;
			}
		}


		private void OnDialogueOver(object sender, DialogueManager.DialogueOverArgs e)
		{
			Hide();
		}


		private void NewSpeech(object sender, DialogueManager.NextDialogueArgs e)
		{
			Show();

			SetSpeech(e.dialogue);
		}
		#endregion

		private void SetSpeech(Dialogue dialogue)
		{
			_dialogue = dialogue;

			if (_textAnimationCoroutine != null)
			{
				StopCoroutine(_textAnimationCoroutine);
			}

			_speakerName.text = dialogue.SpeakerName;
			_speakerAvatar.sprite = dialogue.SpeakerAvatar;

			if (_textAnimationDurationPerCharacter <= 0)
			{
				_content.text = dialogue.Speech;
			}
			else
			{
				_textAnimationCoroutine = _content.SetTextAnimated(dialogue.Speech, _textAnimationDurationPerCharacter, true);
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			HideOthersPanels();

			_uiManager.ShowBlackBorders();

			_background.SetAlpha(0);
			_background.DOFade(_backgroundAlpha, _backgroundFadeInDuration)
				.SetUpdate(true)
				.SetEase(_backgroundEase);
		}

		protected override void OnHide()
		{
			base.OnHide();
			ShowDisabledPanels();

			if (_uiManager == null)
			{
				_uiManager = Services.Instance.Get<UIManager>();
			}

			_uiManager.HideBlackBorders();
		}

		private void HideOthersPanels()
		{
			foreach (Canvas canvas in _canvasesToHide)
			{
				if (canvas.TryGetComponent(out APanel panel))
				{
					panel.Hide();
				}
				else
				{
					canvas.enabled = false;
				}

				_disabledCanvases.Add(canvas);
			}
		}

		private void ShowDisabledPanels()
		{
			foreach (var canvas in _disabledCanvases)
			{
				if (canvas.TryGetComponent(out APanel panel))
				{
					panel.Hide();				
				}
				else
				{
					canvas.enabled = true;
				}
			}

			_disabledCanvases.Clear();
		}
		#endregion Methods
	}
}
