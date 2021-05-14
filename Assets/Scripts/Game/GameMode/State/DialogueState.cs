namespace Tartaros.Gamemode.State
{
	using System.Collections;
	using System.Collections.Generic;
	using Tartaros.Dialogue;
	using UnityEngine;

	public class DialogueState : AGameState
	{

		private DialoguesData _data = null;
		private DialogueInputs _inputs = null;

		private int _indexDialogue = 0;
		private int _currentSpeechIndex = 0;

		public DialogueState(GamemodeManager stateOwner, DialoguesData data) : base(stateOwner)
		{
			_data = data;
			_inputs = new DialogueInputs();
		}

		public override void OnStateEnter()
		{
			base.OnStateEnter();

			StopAllInteractionAndGameplay();

			if (_data.Dialogues[_indexDialogue].CameraTarget != null)
			{
				MoveCameraOnTargetPosition();
			}

			EnableDialogueUI();
			NextLines();

			_inputs.ValidatePerformed -= InputPressed;
			_inputs.ValidatePerformed += InputPressed;

		}

		public override void OnStateExit()
		{
			base.OnStateExit();

			EnableAllInteractionAndGameplay();
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

		private void EnableDialogueUI()
		{

		}

		private void StopAllInteractionAndGameplay()
		{

		}

		private void TEST_ShowLinesAndAvatar(string avatar, string dialogue)
		{
			Debug.LogFormat("{0}: {1}", avatar, dialogue);
		}

		private void EnableAllInteractionAndGameplay()
		{

		}

		private void MoveCameraOnTargetPosition()
		{

		}


	}
}