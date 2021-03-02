namespace Tartaros.Entities
{
	using Sirenix.OdinInspector;
	using Sirenix.Serialization;

	public class EntityData : SerializedScriptableObject
	{
		#region Fields
		[OdinSerialize]
		private IEntityBehaviourData[] _behaviours = new IEntityBehaviourData[0];
		#endregion Fields

		#region Properties
		public IEntityBehaviourData[] Behaviours => _behaviours;
		#endregion Properties
	}
}