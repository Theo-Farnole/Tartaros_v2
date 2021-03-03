namespace Tartaros.MeshViewer
{
	using Tartaros.MeshViewer.UI;
	using UnityEngine;

	internal class ViewModelManager : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private Transform _viewedMeshParent = null;

		private GameObject _currentDisplayMesh = null;
		private ModelLoader _meshLoader = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_meshLoader = new ModelLoader();
		}

		private void OnEnable()
		{
			UIManager.Instance.MeshConfigurationChanged -= Instance_MeshConfigurationChanged;
			UIManager.Instance.MeshConfigurationChanged += Instance_MeshConfigurationChanged;
		}

		private void OnDisable()
		{
			UIManager.Instance.MeshConfigurationChanged -= Instance_MeshConfigurationChanged;
		}

		private void Instance_MeshConfigurationChanged(object sender, UIManager.MeshConfigurationChangedArgs e)
		{
			RefreshMesh(e.meshPathConfiguration);
		}

		void RefreshMesh(MeshPathConfiguration meshConfiguration)
		{
			if (_currentDisplayMesh != null)
			{
				Destroy(_currentDisplayMesh);
			}

			_currentDisplayMesh = _meshLoader.Load(meshConfiguration);
			_currentDisplayMesh.transform.parent = _viewedMeshParent;
			_currentDisplayMesh.transform.localPosition = Vector3.zero;
		}
		#endregion Methods
	}
}
