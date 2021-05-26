namespace Tartaros.Gamemode.State
{
	using System.Collections;
	using System.Collections.Generic;
	using Tartaros.CameraSystem;
	using Tartaros.Dialogue;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class DialogueState : AGameState
	{

		#region Fields
		private int _currentSpeechIndex = 0;
		private bool _isInDebugPause = false;

		private readonly DialoguesData _data = null;
		private readonly Transform _cameraTarget = null;
		private readonly int _indexDialogue = 0;

		// SERVICES
		private readonly DialogueManager _dialogueManager = null;
		#endregion

		#region Ctor
		public DialogueState(GamemodeManager stateOwner, DialoguesData data, int indexDialogue, Transform cameraTarget) : base(stateOwner)
		{
			_data = data;
			_indexDialogue = indexDialogue;
			_cameraTarget = cameraTarget;
			_dialogueManager = Services.Instance.Get<DialogueManager>();
		}
		#endregion

		#region Methods
		public override void OnStateEnter()
		{
			base.OnStateEnter();

			ToggleTimeFreeze();

			if (_indexDialogue < _data.Dialogues.Length)
			{
				ShowNextLine();

				if (_data.Dialogues[_indexDialogue].IsCameraTarget == true)
				{
					SetCameraFollowTargetMode(true);
				}
			}
			else
			{
				throw new System.NotSupportedException("There is no dialogue to display.");
			}

		}

		public override void OnStateExit()
		{
			base.OnStateExit();

			ToggleTimeFreeze();
			if (_data.Dialogues[_indexDialogue].IsCameraTarget == true)
			{
				SetCameraFollowTargetMode(false);
			}
			Debug.Log("dialogueStateFinish");
		}

		public void ShowNextLine()
		{
			if (IsDialogueFinish() == true)
			{
				_dialogueManager.InvokeDialogueOver(new DialogueManager.DialogueOverArgs());
				LeaveState();
			}
			else
			{
				_currentSpeechIndex += 1;

				SpeechSequence speech = _data.Dialogues[_indexDialogue].Dialogue[_currentSpeechIndex];
				_dialogueManager.InvokeNewSpeech(new DialogueManager.NewSpeechArgs(speech));
			}
		}

		private bool IsDialogueFinish()
		{
			var currentDialogue = _data.Dialogues[_indexDialogue];

			return _currentSpeechIndex + 1 < currentDialogue.Dialogue.Length;
		}

		private void ToggleTimeFreeze()
		{
			_isInDebugPause = !_isInDebugPause;

			Time.timeScale = _isInDebugPause ? 0 : 1;

			if (Camera.main.TryGetComponent(out CameraController cameraController))
			{
				cameraController.UseUnscaledDeltaTime = _isInDebugPause;
			}
		}

		private void SetCameraFollowTargetMode(bool mode)
		{
			if (Camera.main.TryGetComponent<CameraController>(out CameraController cameraController))
			{
				if (_cameraTarget != null)
				{
					cameraController.SetCameraTarget(_cameraTarget);
					cameraController.SetCameraFollowTargetMode(mode);
				}
				else
				{
					Debug.LogWarning("there is no cameraTarget in DialogueManager");
				}
			}
			else
			{
				Debug.LogError("Dialogue State don't find cameraController");
			}
		}
	}
	#endregion
}