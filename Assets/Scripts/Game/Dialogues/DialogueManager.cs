namespace Tartaros.Dialogue
{
	using Sirenix.OdinInspector;
	using System;
	using Tartaros.Gamemode;
	using Tartaros.Gamemode.State;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class DialogueManager : MonoBehaviour
	{
		#region Fields
		[SerializeField, Required] private DialoguesData _data = null;
		[SerializeField, Required] private AudioSource _backgroundAudioSource = null;

		private GamemodeManager _gamemodeManager = null;
		#endregion Fields

		#region Events
		public class NextDialogueArgs : EventArgs
		{
			public readonly Dialogue dialogue = null;

			public NextDialogueArgs(Dialogue speech)
			{
				this.dialogue = speech;
			}
		}
		public event EventHandler<NextDialogueArgs> NewDialogue = null;

		public class DialogueOverArgs : EventArgs { }
		public event EventHandler<DialogueOverArgs> DialogueOver = null;

		public class CameraMoveStartArgs : EventArgs { }
		public event EventHandler<CameraMoveStartArgs> CameraMoveStart = null;

		//public class CameraMoveEndArgs : EventArgs { }
		//public event EventHandler<CameraMoveEndArgs> CameraMoveEnd = null;
		#endregion Events

		#region Methods
		private void Awake()
		{
			_gamemodeManager = Services.Instance.Get<GamemodeManager>();
		}

		public void EnterDialogueState(string dialogueID)
		{
			_gamemodeManager.SetState(new DialogueState(_gamemodeManager, _data.GetDialoguesSequence(dialogueID), _backgroundAudioSource));
		}

		public void EnterDialogueState(DialoguesSequence dialoguesSequence)
		{
			_gamemodeManager.SetState(new DialogueState(_gamemodeManager, dialoguesSequence, _backgroundAudioSource));
		}

		public void ShowNextLine()
		{
			if (_gamemodeManager.CurrentState is DialogueState dialogueState)
			{
				dialogueState.ShowNextSpeech();
			}
			else
			{
				throw new NotSupportedException("Cannot show next line, game is not in a dialogue state.");
			}
		}

		public void InvokeNewDialogueEvent(NextDialogueArgs args) => NewDialogue?.Invoke(this, args);
		public void InvokeDialogueOver(DialogueOverArgs args) => DialogueOver?.Invoke(this, args);
		#endregion Methods
	}
}