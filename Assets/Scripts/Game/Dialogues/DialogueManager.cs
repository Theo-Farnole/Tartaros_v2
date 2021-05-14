namespace Tartaros.Dialogue
{
	using System.Collections;
	using Tartaros.Gamemode;
	using Tartaros.Gamemode.State;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class DialogueManager : MonoBehaviour
	{
		[SerializeField] private DialoguesData _data = null;
		[SerializeField] private Transform _cameraTarget = null;

		private int _indexDialogue = 0;

		private GamemodeManager _gamemodeManager = null;

		private void Awake()
		{
			_gamemodeManager = Services.Instance.Get<GamemodeManager>();
		}

		public void EnterDialogueState()
		{
			_gamemodeManager.SetState(new DialogueState(_gamemodeManager, _data, _indexDialogue, _cameraTarget));
			_indexDialogue += 1;
		}
	}
}