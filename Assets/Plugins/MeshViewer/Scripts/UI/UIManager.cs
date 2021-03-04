namespace Tartaros.MeshViewer.UI
{
	using Sirenix.OdinInspector;
	using System;
	using Tartaros.MeshViewer;
	using UnityEngine;
	using UnityEngine.UI;

	internal class UIManager : Singleton<UIManager>
	{
		#region Fields
		private const string GROUP_SETUP = "Setup";

		[SerializeField]
		private ViewModelManager _viewModelManager = null;

		[SerializeField]
		private FolderInputField _modelFolder = null;

		[FoldoutGroup(GROUP_SETUP)]
		[SerializeField]
		private FileInputField _meshPath = null;

		[FoldoutGroup(GROUP_SETUP)]
		[SerializeField]
		private FileInputField _albedoPath = null;

		[FoldoutGroup(GROUP_SETUP)]
		[SerializeField]
		private FileInputField _normalPath = null;

		[FoldoutGroup(GROUP_SETUP)]
		[SerializeField]
		private FileInputField _aoPath = null;

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
			_modelFolder.OnPathChanged -= ModelPathChanged;
			_modelFolder.OnPathChanged += ModelPathChanged;

			_meshPath.OnPathChanged -= MeshPathChanged;
			_meshPath.OnPathChanged += MeshPathChanged;

			_albedoPath.OnPathChanged -= TexturePathChanged;
			_albedoPath.OnPathChanged += TexturePathChanged;

			_normalPath.OnPathChanged -= TexturePathChanged;
			_normalPath.OnPathChanged += TexturePathChanged;

			_aoPath.OnPathChanged -= TexturePathChanged;
			_aoPath.OnPathChanged += TexturePathChanged;
		}

		private void OnDisable()
		{
			_modelFolder.OnPathChanged -= ModelPathChanged;
			_meshPath.OnPathChanged -= MeshPathChanged;
			_albedoPath.OnPathChanged -= TexturePathChanged;
			_normalPath.OnPathChanged -= TexturePathChanged;
			_aoPath.OnPathChanged -= TexturePathChanged;
		}

		private void ModelPathChanged(object sender, FolderInputField.PathChangedArgs e)
		{
			UpdatePathInputs();
		}

		private void TexturePathChanged(object sender, FileInputField.PathChangedArgs e)
		{
			UpdateViewedModel();
		}

		private void MeshPathChanged(object sender, FileInputField.PathChangedArgs e)
		{
			UpdateViewedModel();
		}

		private void UpdatePathInputs()
		{
			ModelPath modelPath = ModelPath.CreateFromFolder(_modelFolder.Path);

			_meshPath.Path = modelPath.meshPath;
			_albedoPath.Path = modelPath.texturesPath.AlbedoPath;
			_normalPath.Path = modelPath.texturesPath.NormalPath;
			_aoPath.Path = modelPath.texturesPath.AoPath;

			UpdateViewedModel();
		}		

		private void UpdateViewedModel()
		{
			ModelPath modelPath = GetCurrentModelPath();

			_viewModelManager.SetMeshConfiguration(modelPath);
		}

		private ModelPath GetCurrentModelPath()
		{
			return new ModelPath(_meshPath.Path, new TexturesPath(_albedoPath.Path, _normalPath.Path, _aoPath.Path));
		}
		#endregion Methods
	}
}