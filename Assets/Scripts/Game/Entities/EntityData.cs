﻿namespace Tartaros.Entities
{
	using Sirenix.OdinInspector;
	using Sirenix.Serialization;
	using System.Linq;

	public class EntityData : SerializedScriptableObject
	{
		#region Fields
		[OdinSerialize]
		private IEntityBehaviourData[] _behaviours = new IEntityBehaviourData[0];
		#endregion Fields

		#region Properties
		public IEntityBehaviourData[] Behaviours => _behaviours;
		#endregion Properties

		#region Methods
		public T GetBehaviour<T>() where T : class, IEntityBehaviourData
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

		public bool HasBehaviour<T>() where T : class, IEntityBehaviourData
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

		public bool TryGetBehaviour<T>(out T behaviour) where T : class, IEntityBehaviourData
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