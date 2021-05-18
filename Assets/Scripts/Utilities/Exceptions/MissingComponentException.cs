namespace Tartaros
{
	using System;
	using UnityEngine;

	public class MissingComponentException : Exception
	{
		public MissingComponentException(Type type, MonoBehaviour monoBehaviour) : this(type, monoBehaviour.gameObject)
		{
		}

		public MissingComponentException(Type type, GameObject gameObject) : base("Missing component of type {0} on GameObject \"{1}\".".Format(type.Name, gameObject))
		{
		}
	}
}
