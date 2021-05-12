namespace Tartaros.Dialogue
{
	using System;
	using System.Collections;
	using UnityEngine;
	using UnityEngine.InputSystem;
	using static UnityEngine.InputSystem.InputAction;

	public class DialogueInputs
	{
		private GameInputs _input = null;

		public DialogueInputs()
		{
			_input = new GameInputs();
			_input.Dialogue.Enable();
		}

		public event Action<CallbackContext> ValidatePerformed
		{
			add
			{
				_input.Dialogue.NextSpeech.performed += value;
			}

			remove
			{
				_input.Dialogue.NextSpeech.performed -= value;
			}
		}

		public bool IsValidatePerformed()
		{
			return _input.Dialogue.NextSpeech.phase == InputActionPhase.Performed;
		}
	}
}