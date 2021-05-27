namespace Tartaros.Gamemode.State
{
	using Tartaros.CameraSystem;
	using Tartaros.Dialogue;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class DialogueState : AGameState
	{
		#region Fields
		private int _currentSpeechIndex = -1;

		private readonly DialoguesSequence _dialogueSequence = null;
		private readonly CameraController _cameraController = null;
		private readonly CinematicCameraController _cinematicCameraController = null;

		// SERVICES
		private readonly DialogueManager _dialogueManager = null;
		private readonly ISelection _currentSelection = null;
		private readonly RectangleSelectionInput _rectangleSelectionInput = null;
		private readonly ClickSelectionInput _clickSelectionInput = null;
		#endregion

		#region Ctor
		public DialogueState(GamemodeManager stateOwner, DialoguesSequence sequence) : base(stateOwner)
		{
			if (stateOwner is null) throw new System.ArgumentNullException(nameof(stateOwner));

			_dialogueSequence = sequence ?? throw new System.ArgumentNullException(nameof(sequence));

			_dialogueManager = Services.Instance.Get<DialogueManager>();
			_currentSelection = Services.Instance.Get<CurrentSelection>();
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

			PauseGame(false);

			_dialogueManager.InvokeDialogueOver(new DialogueManager.DialogueOverArgs());
		}

		public void ShowNextSpeech()
		{
			if (IsThereSpeechToShow() == true)
			{
				_currentSpeechIndex++;

				Dialogue speech = _dialogueSequence.GetDialogue(_currentSpeechIndex);
				_dialogueManager.InvokeNewDialogueEvent(new DialogueManager.NextDialogueArgs(speech));
			}
			else
			{
				LeaveState();
			}
		}
		private void DestinationReached(object sender, CinematicCameraController.DestinationReachedArgs e)
		{
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