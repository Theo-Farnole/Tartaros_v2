namespace Tartaros.Dialogue
{
	using System;
	using Tartaros.Gamemode;
	using Tartaros.Gamemode.State;
	using Tartaros.ServicesLocator;
	using Tartaros.Wave;
	using UnityEngine;

	public class DialogueManager : MonoBehaviour
	{
		#region Fields
		[SerializeField] private DialoguesData _data = null;
		[SerializeField] private Transform _cameraTarget = null;

		private int _indexDialogue = 0;

		private GamemodeManager _gamemodeManager = null;
		#endregion Fields

		#region Events
		public class NewSpeechArgs : EventArgs
		{
			public readonly SpeechSequence speech = null;

			public NewSpeechArgs(SpeechSequence speech)
			{
				this.speech = speech;
			}
		}
		public event EventHandler<NewSpeechArgs> NewSpeech = null;

		public class DialogueOverArgs : EventArgs { }
		public event EventHandler<DialogueOverArgs> DialogueOver = null;

		public class CameraMoveStartArgs : EventArgs { }
		public event EventHandler<CameraMoveStartArgs> CameraMoveStart = null;

		public class CameraMoveEndArgs : EventArgs { }
		public event EventHandler<CameraMoveEndArgs> CameraMoveEnd = null;
		#endregion Events

		#region Methods
		private void Awake()
		{
			_gamemodeManager = Services.Instance.Get<GamemodeManager>();
		}

		public void EnterDialogueState()
		{
			_gamemodeManager.SetState(new DialogueState(_gamemodeManager, _data, _indexDialogue, _cameraTarget));
			_indexDialogue++;
		}

		public void ShowNextLine()
		{
			if (_gamemodeManager.CurrentState is DialogueState dialogueState)
			{
				dialogueState.ShowNextLine();
			}
			else
			{
				throw new NotSupportedException("Cannot show next line, game is not in a dialogue state.");
			}
		}

		public void InvokeNewSpeech(NewSpeechArgs args) => NewSpeech.Invoke(this, args);
		public void InvokeDialogueOver(DialogueOverArgs args) => DialogueOver?.Invoke(this, args);
		#endregion Methods
	}
}