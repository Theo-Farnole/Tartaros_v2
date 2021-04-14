namespace Tartaros
{
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	public partial class PoolsManager
	{
		private class Pool
		{
			#region Fields
			private readonly GameObject _prefab = null;
			private Queue<GameObject> _disabledObjects = new Queue<GameObject>();
			#endregion Fields

			#region Ctor
			public Pool(GameObject prefab)
			{
				_prefab = prefab;
			}
			#endregion Ctor

			#region Methods
			public GameObject GetObject()
			{
				if (IsThereNoAvailableObjectToGet())
				{
					PopulatePool(1);
				}

				CheckForErrors();

				GameObject getObject = _disabledObjects.Dequeue();
				getObject.SetActive(true);

				if (getObject.TryGetComponent(out IObjectPooleable objectPooleable))
				{
					objectPooleable.OnObjectReused();
				}

				return getObject;
			}

			public void ReleaseObject(GameObject objectToRelease)
			{
				if (objectToRelease == null)
				{
					Debug.LogErrorFormat("The released object in prefab pooler {0} is null. Object releasing is aborted.s");
					return;
				}

				if (objectToRelease.TryGetComponent(out IObjectPooleable objectPooleable))
				{
					objectPooleable.OnObjectRelease();
				}

				objectToRelease.SetActive(false);

				_disabledObjects.Enqueue(objectToRelease);
			}

			public void PopulatePool(int amount)
			{
				for (int i = 0; i < amount; i++)
				{
					InstantiateOneObject();
				}

				void InstantiateOneObject()
				{
					GameObject newObject = Instantiate(_prefab);
					newObject.SetActive(false);

					_disabledObjects.Enqueue(newObject);
				}
			}

			private bool IsThereNoAvailableObjectToGet()
			{
				return _disabledObjects.Count == 0 || _disabledObjects.Where(x => x != null).Count() == 0;
			}

			private void CheckForErrors()
			{
				if (_disabledObjects.Peek() == null)
				{
					Debug.LogWarningFormat("An element in the prefab pool {0} is null. It might has been destroyed. The error is handled.", _prefab.name);
					RemoveNullElements();
				}
			}

			private void RemoveNullElements()
			{
				while (_disabledObjects.ContainsElement() && _disabledObjects.Peek() == null)
				{
					_disabledObjects.Dequeue();
				}
			} 
			#endregion Methods
		}
	}
}
