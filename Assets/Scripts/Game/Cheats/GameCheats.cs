namespace Tartaros.Cheats
{
	using Tartaros.Entities;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using TF.CheatsGUI;
	using UnityEngine;

	public static class GTameCheats
	{
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
	}
}
