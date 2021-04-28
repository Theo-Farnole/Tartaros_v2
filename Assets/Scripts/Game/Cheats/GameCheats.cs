namespace Tartaros.Cheats
{
	using Tartaros.CameraSystem;
	using Tartaros.Entities;
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
					attackable.TakeDamage(damage);
				}
			}
		}


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
	}
}
