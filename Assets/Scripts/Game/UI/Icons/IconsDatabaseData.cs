namespace Tartaros
{
	using Sirenix.OdinInspector;
	using System.Collections.Generic;
	using Tartaros.Economy;
	using UnityEngine;

	public class IconsDatabaseData : SerializedScriptableObject
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
		[SerializeField]
		private Dictionary<SectorRessourceType, Sprite> _icons = new Dictionary<SectorRessourceType, Sprite>();
		[SerializeField]
		private Sprite _healIcon = null;
		#endregion Fields

		#region Properties
		public Sprite AttackIcon => _attackIcon;
		public Sprite MoveIcon => _moveIcon;
		public Sprite MoveAgressivelyIcon => _moveAgressivelyIcon;
		public Sprite InstanciateGateIcon => _instanciateGateIcon;
		public Sprite OpenDoorIcon => _openDoorIcon;
		public Sprite CloseDoorIcon => _closeDoorIcon;
		public Sprite PatrolIcon => _patrolIcon;
		public Sprite HealIcon => _healIcon;
		#endregion properties

		#region Methods
		public Sprite GetResourceIcon(SectorRessourceType type)
		{
			if (_icons.TryGetValue(type, out Sprite icon))
			{
				return icon;
			}
			else
			{
				Debug.LogErrorFormat("Missing resource icon {0} in IconsDatabase.", type);
				return null;
			}
		}
		#endregion Methods
	}
}
