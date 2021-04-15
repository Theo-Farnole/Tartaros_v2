namespace Tartaros.Selection
{
	using Sirenix.OdinInspector;
	using UnityEngine;

	public class InstantiateGameObjectOnSelection : MonoBehaviour, ISelectionEffect
	{
		#region Fields
		[SerializeField]
		[AssetsOnly]
		[Required]
		private GameObject _prefabToInstantiateOnSelection = null;

		[ShowInRuntime]
		private GameObject _currentPrefab = null;

		[SerializeField]
		private float _prefabScale = 1;
		#endregion Fields

		#region Properties
		public GameObject PrefabToInstantiateOnSelection { get => _prefabToInstantiateOnSelection; set => _prefabToInstantiateOnSelection = value; }
		#endregion Properties

		#region Methods
		void Start()
		{
			if (PrefabToInstantiateOnSelection == null)
			{
				Debug.LogWarningFormat("Missing projector prefab on {0}.", name);
			}
		}

		void ISelectionEffect.OnSelected()
		{
			InstantiatePrefab();
		}

		void ISelectionEffect.OnUnselected()
		{
			DestroyCurrentPrefab();
		}

		private void InstantiatePrefab()
		{
			if (_currentPrefab != null)
			{
				Debug.LogErrorFormat("Trying to instanciate the prefab while it is already instanciated. We destroy the current prefab and instantiate a new one to avoid error.");
				DestroyCurrentPrefab();
			}

			_currentPrefab = Instantiate(PrefabToInstantiateOnSelection, transform);
			_currentPrefab.transform.localScale = Vector3.one * _prefabScale;
		}

		private void DestroyCurrentPrefab()
		{
			if (_currentPrefab != null)
			{
				GameObject.Destroy(_currentPrefab);
			}
		}
		#endregion Methods
	}
}
