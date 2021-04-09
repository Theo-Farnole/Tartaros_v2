namespace Tartaros.UI
{
	using Tartaros.Entities;
	using UnityEngine;
	using UnityEngine.UI;

	public class MultiSelectedEntityPortrait : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private Image _portrait = null;

		[SerializeField]
		private UIHealthBar _healthBar = null;

		private Entity _entity = null;
		#endregion Fields

		#region Properties
		public Entity Entity
		{
			get => _entity;

			set
			{
				_entity = value;

				_healthBar.Healthable = _entity.GetComponent<IHealthable>();
				_portrait.sprite = (_entity.EntityData as IPortraiteable).Portrait;
			}
		}
		#endregion Properties
	}
}
