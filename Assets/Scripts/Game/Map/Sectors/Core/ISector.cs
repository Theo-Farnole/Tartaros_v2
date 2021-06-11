namespace Tartaros.Map
{
	using System;
	using Tartaros.Economy;
	using Tartaros.Math;
	using UnityEngine;

	public class CapturedArgs : EventArgs { }
	public class ObjectAddedArgs : EventArgs
	{
		public readonly GameObject addedObject = null;

		public ObjectAddedArgs(GameObject addedObject)
		{
			this.addedObject = addedObject;
		}
	}
	public class ObjectRemovedArgs : EventArgs
	{
		public readonly GameObject removedObject = null;

		public ObjectRemovedArgs(GameObject removedObject)
		{
			this.removedObject = removedObject;
		}
	}

	public interface ISector
	{
		event EventHandler<CapturedArgs> Captured;
		event EventHandler<ObjectAddedArgs> ObjectAdded;
		event EventHandler<ObjectRemovedArgs> ObjectRemoved;

		bool IsCaptured { get; set; }
		GameObject[] ObjectsInSector { get; }
		ISectorResourcesWallet CapturePrice { get; }
		bool ContainsPosition(Vector3 worldPosition);

		void AddObjectInSector(GameObject gameObject);
		void RemoveObjectInSector(GameObject gameObject);
	}
}
