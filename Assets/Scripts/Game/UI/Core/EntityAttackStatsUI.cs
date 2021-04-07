namespace Tartaros.UI
{
	using Tartaros.Entities;
	using TMPro;
	using UnityEngine;

	public class EntityAttackStatsUI : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private Entity _entity = null;

		[Space]

		[SerializeField]
		private TextMeshProUGUI _damage = null;

		[SerializeField]
		private TextMeshProUGUI _range = null;

		[SerializeField]
		private TextMeshProUGUI _attackSpeed = null;

		[SerializeField]
		private TextMeshProUGUI _type = null;
		#endregion Fields

		#region Properties
		public Entity Entity
		{
			get => _entity;

			set
			{
				_entity = value;
				UpdateInformations();
			}
		}
		#endregion Properties

		#region Methods
		private void Start()
		{
			UpdateInformations();
		}

		void UpdateInformations()
		{
			if (_entity == null) return;

			if (_entity.EntityData.TryGetBehaviour(out EntityAttackData attackData))
			{
				_damage.text = attackData.Damage.ToString();
				_range.text = attackData.AttackRange.ToString();
				_attackSpeed.text = attackData.SecondsBetweenAttacks.ToString();
				_type.text = attackData.AttackMode?.DisplayTypeUI ?? "NONE";
			}
		}
		#endregion Methods
	}
}
