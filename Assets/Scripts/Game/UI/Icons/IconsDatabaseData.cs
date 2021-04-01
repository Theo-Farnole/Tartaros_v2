namespace Tartaros
{
	using UnityEngine;

	public class IconsDatabaseData : ScriptableObject
	{
		#region Fields
		[SerializeField]
		private Sprite _attackIcon = null;
		#endregion Fields

		#region Properties
		public Sprite AttackIcon => _attackIcon;
		#endregion properties
	}
}
