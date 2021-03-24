namespace Tartaros.Entities
{
	using Tartaros.Selection;
	using UnityEngine;

	public class EntitySelectable : IEntityBehaviourData
	{
		#region Fields
		[SerializeField]
		private bool _canBeMultiSelected = false;
		#endregion Fields

		#region Methods
		void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
		{
			Selectable selectable = entityRoot.AddComponent<Selectable>();

			selectable.CanBeMultiSelected = _canBeMultiSelected;
			selectable.Team = entityRoot.GetComponent<Entity>().Team;
		}
		#endregion Methods
	}
}
