namespace Tartaros
{
	using UnityEngine;

	public class IconsDatabaseData : ScriptableObject
	{
		#region Fields
		[SerializeField]
		private Sprite _attackIcon = null;
		[SerializeField]
		private Sprite _moveIcon = null;
		[SerializeField]
		private Sprite _moveAgressivelyIcon = null;
		[SerializeField]
		private Sprite _patrolIcon = null;
		[SerializeField]
		private Sprite _instanciateGateIcon = null;
		[SerializeField]
		private Sprite _openDoorIcon = null;
		[SerializeField]
		private Sprite _closeDoorIcon = null;
		#endregion Fields

		#region Properties
		public Sprite AttackIcon => _attackIcon;
		public Sprite MoveIcon => _moveIcon;
		public Sprite MoveAgressivelyIcon => _moveAgressivelyIcon;
		public Sprite InstanciateGateIcon => _instanciateGateIcon;
		public Sprite OpenDoorIcon => _openDoorIcon;
		public Sprite CloseDoorIcon => _closeDoorIcon;
		public Sprite PatrolIcon => _patrolIcon;
		#endregion properties
	}
}
