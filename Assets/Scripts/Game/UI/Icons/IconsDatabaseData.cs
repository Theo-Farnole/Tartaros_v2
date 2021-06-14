namespace Tartaros
{
	using Sirenix.OdinInspector;
	using System.Collections.Generic;
	using Tartaros.Economy;
	using UnityEngine;

	public class IconsDatabaseData : SerializedScriptableObject
	{
		#region Fields
		[SerializeField, PreviewField] private Sprite _attackIcon = null;
		[SerializeField, PreviewField] private Sprite _moveIcon = null;
		[SerializeField, PreviewField] private Sprite _moveAgressivelyIcon = null;
		[SerializeField, PreviewField] private Sprite _patrolIcon = null;
		[SerializeField, PreviewField] private Sprite _instanciateGateIcon = null;
		[SerializeField, PreviewField] private Sprite _openDoorIcon = null;
		[SerializeField, PreviewField] private Sprite _closeDoorIcon = null;
		[SerializeField] private Dictionary<SectorRessourceType, Sprite> _icons = new Dictionary<SectorRessourceType, Sprite>();
		[SerializeField, PreviewField] private Sprite _healIcon = null;
		[SerializeField, PreviewField] private Sprite _selfKillIcon = null;
		[SerializeField, PreviewField] private Sprite _populationIcon = null;
		#endregion Fields

		#region Properties
		public Sprite PopulationIcon => _populationIcon;
		public Sprite AttackIcon => _attackIcon;
		public Sprite MoveIcon => _moveIcon;
		public Sprite MoveAgressivelyIcon => _moveAgressivelyIcon;
		public Sprite InstanciateGateIcon => _instanciateGateIcon;
		public Sprite OpenDoorIcon => _openDoorIcon;
		public Sprite CloseDoorIcon => _closeDoorIcon;
		public Sprite PatrolIcon => _patrolIcon;
		public Sprite HealIcon => _healIcon;
		public Sprite SelfKillIcon => _selfKillIcon;
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
