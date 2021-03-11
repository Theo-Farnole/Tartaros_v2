namespace Tartaros.MeshViewer
{
	using Tartaros.MeshViewer.UI;
	using UnityEngine;

	internal class ViewModelManager : MeshViewerSingleton<ViewModelManager>
	{
		#region Fields		
		private const float DEFAULT_SCALE = 0.01f;

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

		public void SetMeshConfiguration(ModelPath meshConfiguration)
		{
			if (_currentDisplayMesh != null)
			{
				Destroy(_currentDisplayMesh);
			}

			_currentDisplayMesh = _meshLoader.Load(meshConfiguration);
			_currentDisplayMesh.transform.parent = _viewedMeshParent;
			_currentDisplayMesh.transform.localPosition = Vector3.zero;
		}

		public void Rotate90Degrees()
		{
			_currentDisplayMesh.transform.Rotate(0, 90, 0);
		}

		public void RotateAnti90Degrees()
		{
			_currentDisplayMesh.transform.Rotate(0, -90, 0);
		}

		public void SetScale(float scale)
		{
			if (_currentDisplayMesh == null) return;

			_currentDisplayMesh.transform.localScale = Vector3.one * scale * DEFAULT_SCALE;
		}
		#endregion Methods
	}
}
