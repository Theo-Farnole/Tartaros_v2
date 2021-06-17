namespace Tartaros.Gamemode.State
{
	using DG.Tweening;
	using Tartaros.CameraSystem;
	using Tartaros.Dialogue;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using Tartaros.SoundsSystem;
	using Tartaros.UI;
	using UnityEngine;

	public class DialogueState : AGameState
	{
		#region Fields
		private int _currentSpeechIndex = -1;

		private readonly DialoguesSequence _dialogueSequence = null;
		private readonly CameraController _cameraController = null;
		private readonly CinematicCameraController _cinematicCameraController = null;
		private readonly AudioSource _backgroundAudioSource = null;

		// SERVICES
		private readonly DialogueManager _dialogueManager = null;
		private readonly ISelection _currentSelection = null;
		private readonly RectangleSelectionInput _rectangleSelectionInput = null;
		private readonly ClickSelectionInput _clickSelectionInput = null;
		private readonly UIManager _uiManager = null;
		private readonly MusicManager _musicManager = null;
		private readonly float _startingVolume = -1;
		#endregion

		#region Ctor
		public DialogueState(GamemodeManager stateOwner, DialoguesSequence sequence, AudioSource backgroundAudioSource) : base(stateOwner)
		{
			if (stateOwner is null) throw new System.ArgumentNullException(nameof(stateOwner));

			_dialogueSequence = sequence ?? throw new System.ArgumentNullException(nameof(sequence));

			_backgroundAudioSource = backgroundAudioSource;
			_startingVolume = _backgroundAudioSource.volume;

			_dialogueManager = Services.Instance.Get<DialogueManager>();
			_currentSelection = Services.Instance.Get<CurrentSelection>();
			_uiManager = Services.Instance.Get<UIManager>();
			_musicManager = Services.Instance.Get<MusicManager>();

			_rectangleSelectionInput = GameObject.FindObjectOfType<RectangleSelectionInput>();
			_clickSelectionInput = GameObject.FindObjectOfType<ClickSelectionInput>();
			_cameraController = Camera.main.GetComponent<CameraController>();
			_cinematicCameraController = Camera.main.GetComponent<CinematicCameraController>();

			if (_cameraController == null)
			{
				Debug.LogError("Dialogue state don't find camera controller.");
			}
		}
		#endregion

		#region Methods
		public override void OnStateEnter()
		{
			base.OnStateEnter();

			_cinematicCameraController.DestinationReached -= DestinationReached;
			_cinematicCameraController.DestinationReached += DestinationReached;

			_currentSelection.Clear();
			_rectangleSelectionInput.enabled = false;
			_clickSelectionInput.enabled = false;
			_cameraController.EnableInputs = false;

			_uiManager.ShowBlackBorders();

			PauseGame(true);

			Vector3? destination = _dialogueSequence.BeforeDialogueCameraDestination;
			if (destination is Vector3 valueOfDestination)
			{
				_cinematicCameraController.MoveTo(valueOfDestination);
			}
			else
			{
				ShowNextSpeech();
			}
		}

		public override void OnStateExit()
		{
			base.OnStateExit();

			_cinematicCameraController.DestinationReached -= DestinationReached;

			_rectangleSelectionInput.enabled = true;
			_clickSelectionInput.enabled = true;
			_cameraController.EnableInputs = true;

			_backgroundAudioSource.Stop();

			_uiManager.HideBlackBorders();

			PauseGame(false);

			_dialogueManager.InvokeDialogueOver(new DialogueManager.DialogueOverArgs());

			if (_dialogueSequence.IsNextDialogue == true)
			{
				_dialogueManager.ExecuteAfterFrame(() => _dialogueManager.EnterDialogueState(_dialogueSequence.NextDialogue));
			}
		}

		public void ShowNextSpeech()
		{
			if (IsThereSpeechToShow() == true)
			{
				_currentSpeechIndex++;

				Dialogue speech = _dialogueSequence.GetDialogue(_currentSpeechIndex);
				_dialogueManager.InvokeNewDialogueEvent(new DialogueManager.NextDialogueArgs(speech));
				PlaySpeechMusic(speech);
			}
			else
			{
				LeaveState();
			}
		}

		private void PlaySpeechMusic(Dialogue speech)
		{
			

			_backgroundAudioSource.DOVolume(0, 0.1f)
				.SetUpdate(true)
				.OnComplete(() =>
			{
				_backgroundAudioSource.clip = speech.BackgroundAudio;
				_backgroundAudioSource.DOVolume(_startingVolume, 0.1f)
					.SetUpdate(true); ;

				if (_backgroundAudioSource.isPlaying == false)
				{
					_backgroundAudioSource.Play();
				}
			});


		}

		private void DestinationReached(object sender, CinematicCameraController.DestinationReachedArgs e)
		{
			Debug.Log(nameof(DestinationReached));

			ShowNextSpeech();
		}

		private bool IsThereSpeechToShow()
		{
			return _currentSpeechIndex + 1 < _dialogueSequence.DialoguesCount;
		}

		private void PauseGame(bool enablePause)
		{
			Time.timeScale = enablePause ? 0 : 1;

			if (Camera.main.TryGetComponent(out CameraController cameraController))
			{
				cameraController.UseUnscaledDeltaTime = enablePause;
			}
		}
	}
	#endregion
}