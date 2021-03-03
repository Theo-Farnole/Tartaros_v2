namespace Tartaros.MeshViewer.UI
{
	using System;
	using Tartaros.MeshViewer;
	using UnityEngine;

	public class UIManager : Singleton<UIManager>
	{
		#region Fields
		[SerializeField]
		private FolderInputField _modelFolderInput = null;

		[SerializeField]
		private FileInputField _meshFileInput = null;

		[SerializeField]
		private FileInputField _materialFileInput = null;
		#endregion Fields

		#region Events
		internal class MeshConfigurationChangedArgs : EventArgs
		{
			public readonly MeshPathConfiguration meshPathConfiguration;

			public MeshConfigurationChangedArgs(MeshPathConfiguration meshPathConfiguration)
			{
				this.meshPathConfiguration = meshPathConfiguration;
			}
		}

		internal event EventHandler<MeshConfigurationChangedArgs> MeshConfigurationChanged = null;
		#endregion Events

		#region Methods
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
			InvokeMeshConfigurationChangedEvent();
		}

		private void MeshFileInput_PathChanged(object sender, FileInputField.PathChangedArgs e)
		{
			InvokeMeshConfigurationChangedEvent();
		}

		private void ModelFolderInput_OnPathChanged(object sender, FolderInputField.PathChangedArgs e)
		{
			InvokeMeshConfigurationChangedEvent();
		}

		private MeshPathConfiguration GetMeshPathConfiguration()
		{
			return new MeshPathConfiguration(_modelFolderInput.Path);
		}

		private void InvokeMeshConfigurationChangedEvent()
		{
			MeshConfigurationChanged?.Invoke(this, new MeshConfigurationChangedArgs(GetMeshPathConfiguration()));
		}
		#endregion Methods
	}
}