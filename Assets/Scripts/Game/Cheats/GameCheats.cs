namespace Tartaros.Cheats
{
	using Tartaros.CameraSystem;
	using Tartaros.Dialogue;
	using Tartaros.Economy;
	using Tartaros.Entities;
	using Tartaros.Gamemode;
	using Tartaros.Gamemode.State;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using TF.CheatsGUI;
	using UnityEngine;

	public static class GameCheats
	{
		private static bool _isInDebugPause = false;

		public static bool IsInDebugPause => _isInDebugPause;

		[Cheat]
		public static void InflictDamageToSelected(int damage)
		{
			ISelection currentSelection = Services.Instance.Get<CurrentSelection>();

			foreach (var selected in currentSelection.SelectedSelectables)
			{
				if (selected is MonoBehaviour selectedMonoBehaviour && selectedMonoBehaviour.TryGetComponent(out IAttackable attackable) == true)
				{
					attackable.TakeDamage(damage, null);
				}
			}
		}

		[Cheat] public static void GiveStone(int amount = 100) => Services.Instance.Get<IPlayerSectorResources>().AddAmount(SectorRessourceType.Stone, amount);
		[Cheat] public static void GiveIron(int amount = 100) => Services.Instance.Get<IPlayerSectorResources>().AddAmount(SectorRessourceType.Iron, amount);
		[Cheat] public static void GiveFood(int amount = 100) => Services.Instance.Get<IPlayerSectorResources>().AddAmount(SectorRessourceType.Food, amount);


		/// <summary>
		/// The debug pause is a pause where the camera can move.
		/// </summary>
		[Cheat]
		public static void ToggleDebugPause()
		{
			_isInDebugPause = !_isInDebugPause;

			Time.timeScale = _isInDebugPause ? 0 : 1;

			if (Camera.main.TryGetComponent(out CameraController cameraController))
			{
				cameraController.UseUnscaledDeltaTime = _isInDebugPause;
			}
		}

		[Cheat]
		public static void EnterDialogueState()
		{
			var dialogueManager = GameObject.FindObjectOfType<DialogueManager>();

			if(dialogueManager != null)
			{
				dialogueManager.EnterDialogueState();
			}
			else
			{
				Debug.LogWarning("there is no sialogueManager on the scene");
			}
		}
	}
}
