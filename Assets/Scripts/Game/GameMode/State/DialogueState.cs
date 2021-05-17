namespace Tartaros.Gamemode.State
{
	using System.Collections;
	using System.Collections.Generic;
	using Tartaros.CameraSystem;
	using Tartaros.Dialogue;
	using UnityEngine;

	public class DialogueState : AGameState
	{

		#region Fields
		private DialoguesData _data = null;
		private DialogueInputs _inputs = null;
		private Transform _cameraTarget = null;
		private int _indexDialogue = 0;


		private int _currentSpeechIndex = 0;
		private bool _isInDebugPause = false; 
		#endregion

		#region Ctor
		public DialogueState(GamemodeManager stateOwner, DialoguesData data, int indexDialogue, Transform cameraTarget) : base(stateOwner)
		{
			_data = data;
			_inputs = new DialogueInputs();
			_indexDialogue = indexDialogue;
			_cameraTarget = cameraTarget;
		} 
		#endregion

		#region Methods
		public override void OnStateEnter()
		{
			base.OnStateEnter();

			SetTimeFreeze();

			if (_data.Dialogues[_indexDialogue].IsCameraTarget == true)
			{
				SetCameraFollowTargetMode(true);
			}

			if (_data.Dialogues.Length - 1 <= _indexDialogue)
			{
				NextLines();
			}
			else
			{
				Debug.LogWarning("there is no more Dialogues to instancaite");
				LeaveState();
			}

			_inputs.ValidatePerformed -= InputPressed;
			_inputs.ValidatePerformed += InputPressed;

		}

		public override void OnStateExit()
		{
			base.OnStateExit();

			SetTimeFreeze();
			if (_data.Dialogues[_indexDialogue].IsCameraTarget == true)
			{
				SetCameraFollowTargetMode(false);
			}
			Debug.Log("dialogueStateFinish");
		}

		private void InputPressed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
		{
			if (IsDialogueFinish() != true)
			{
				NextLines();
			}
			else
			{
				LeaveState();
			}
		}

		private void NextLines()
		{
			var currentDialogue = _data.Dialogues[_indexDialogue];
			var characterName = currentDialogue.Dialogue[_currentSpeechIndex].Character.name;
			var speech = currentDialogue.Dialogue[_currentSpeechIndex].Speech;

			TEST_ShowLinesAndAvatar(characterName, speech);

			_currentSpeechIndex += 1;
		}

		private bool IsDialogueFinish()
		{
			var currentDialogue = _data.Dialogues[_indexDialogue];

			return _currentSpeechIndex > currentDialogue.Dialogue.Length - 1;
		}

		private void SetTimeFreeze()
		{
			_isInDebugPause = !_isInDebugPause;

			Time.timeScale = _isInDebugPause ? 0 : 1;

			if (Camera.main.TryGetComponent(out CameraController cameraController))
			{
				cameraController.UseUnscaledDeltaTime = _isInDebugPause;
			}
		}

		private void TEST_ShowLinesAndAvatar(string name, string dialogue)
		{
			Debug.LogFormat("{0}: {1}", name, dialogue);
		}

		private void SetCameraFollowTargetMode(bool mode)
		{
			if (Camera.main.TryGetComponent<CameraController>(out CameraController cameraController))
			{
				if(_cameraTarget != null)
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