namespace Tartaros.Entities
{
	using Sirenix.OdinInspector;
	using Sirenix.Serialization;
	using Tartaros.Construction;
	using Tartaros.Economy;
	using Tartaros.UI;
	using UnityEngine;

	public class EntityData : SerializedScriptableObject, ISpawnable
	{
		#region Fields
		[SerializeField]
		private GameObject _prefab = null;

		[SerializeField]
		private Sprite _portrait = null;

		[SerializeField]
		private int _population = 1;

		[OdinSerialize]
		private IEntityBehaviourData[] _behaviours = new IEntityBehaviourData[0];
		#endregion Fields

		#region Properties
		public IEntityBehaviourData[] Behaviours => _behaviours;

		GameObject ISpawnable.Prefab => _prefab;
		Sprite IPortraiteable.Portrait => _portrait;
		int ISpawnable.PopulationAmount => _population;
		#endregion Properties

		#region Methods
		public T GetBehaviour<T>() where T : class
		{
			foreach (IEntityBehaviourData behaviour in _behaviours)
			{
				if (behaviour is T castedBehaviour)
				{
					return castedBehaviour;
				}
			}

			return null;
		}

		public bool HasBehaviour<T>() where T : class
		{
			foreach (IEntityBehaviourData behaviour in _behaviours)
			{
				if (behaviour is T)
				{
					return true;
				}
			}

			return false;
		}

		public bool TryGetBehaviour<T>(out T behaviour) where T : class
		{
			foreach (IEntityBehaviourData bhv in _behaviours)
			{
				if (bhv is T castedBehaviour)
				{
					behaviour = castedBehaviour;
					return true;
				}
			}

			behaviour = null;
			return false;
		}
		#endregion Methods
	}
}