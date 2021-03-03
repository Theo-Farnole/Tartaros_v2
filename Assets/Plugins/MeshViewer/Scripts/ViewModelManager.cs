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

		public void SetMeshConfiguration(MeshPathConfiguration meshConfiguration)
		{
			if (_currentDisplayMesh != null)
			{
				Destroy(_currentDisplayMesh);
			}

			_currentDisplayMesh = _meshLoader.Load(meshConfiguration);
			_currentDisplayMesh.transform.parent = _viewedMeshParent;
			_currentDisplayMesh.transform.localPosition = Vector3.zero;
		}

		public void Rotate90Degrees() => _currentDisplayMesh.transform.Rotate(0, 90, 0);
		public void RotateAnti90Degrees() => _currentDisplayMesh.transform.Rotate(0, -90, 0);
		#endregion Methods
	}
}
