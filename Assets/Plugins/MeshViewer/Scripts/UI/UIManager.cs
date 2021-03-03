namespace Tartaros.MeshViewer.UI
{
	using System;
	using Tartaros.MeshViewer;
	using UnityEngine;
	using UnityEngine.UI;

	internal class UIManager : Singleton<UIManager>
	{
		#region Fields
		[SerializeField]
		private ViewModelManager _viewModelManager = null;

		[SerializeField]
		private FolderInputField _modelFolderInput = null;

		[SerializeField]
		private FileInputField _meshFileInput = null;

		[SerializeField]
		private FileInputField _materialFileInput = null;

		[SerializeField]
		private Button _rotate90Degrees = null;

		[SerializeField]
		private Button _rotateAnti90Degrees = null;
		#endregion Fields

		#region Methods
		private void Start()
		{
			_rotate90Degrees.onClick.RemoveListener(_viewModelManager.Rotate90Degrees);
			_rotate90Degrees.onClick.AddListener(_viewModelManager.Rotate90Degrees);

			_rotateAnti90Degrees.onClick.RemoveListener(_viewModelManager.RotateAnti90Degrees);
			_rotateAnti90Degrees.onClick.AddListener(_viewModelManager.RotateAnti90Degrees);
		}

		private void OnEnable()
		{
			_modelFolderInput.OnPathChanged -= ModelFolderInput_OnPathChanged;
			_modelFolderInput.OnPathChanged += ModelFolderInput_OnPathChanged;

			_meshFileInput.OnPathChanged -= MeshFileInput_PathChanged;
			_meshFileInput.OnPathChanged += MeshFileInput_PathChanged;

			_materialFileInput.OnPathChanged -= ModalFileInput_OnPathChanged;
			_materialFileInput.OnPathChanged += ModalFileInput_OnPathChanged;
		}

		private void OnDisable()
		{
			_modelFolderInput.OnPathChanged -= ModelFolderInput_OnPathChanged;
			_meshFileInput.OnPathChanged -= MeshFileInput_PathChanged;
			_materialFileInput.OnPathChanged -= ModalFileInput_OnPathChanged;
		}

		private void ModalFileInput_OnPathChanged(object sender, FileInputField.PathChangedArgs e)
		{
			UpdateViewModelManagerConfiguration();
		}

		private void MeshFileInput_PathChanged(object sender, FileInputField.PathChangedArgs e)
		{
			UpdateViewModelManagerConfiguration();
		}

		private void ModelFolderInput_OnPathChanged(object sender, FolderInputField.PathChangedArgs e)
		{
			UpdateViewModelManagerConfiguration();
		}

		private MeshPathConfiguration GetMeshPathConfiguration()
		{
			return new MeshPathConfiguration(_modelFolderInput.Path);
		}

		private void UpdateViewModelManagerConfiguration()
		{
			_viewModelManager.SetMeshConfiguration(GetMeshPathConfiguration());
		}
		#endregion Methods
	}
}