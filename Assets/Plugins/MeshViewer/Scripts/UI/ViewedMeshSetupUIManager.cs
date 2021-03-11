namespace Tartaros.MeshViewer.UI
{
	using Sirenix.OdinInspector;
	using Tartaros.MeshViewer;
	using UnityEngine;

	internal class ViewedMeshSetupUIManager : MeshViewerSingleton<ViewedMeshSetupUIManager>
	{
		#region Fields
		private const string GROUP_SETUP = "Setup";

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

		private ViewModelManager _viewModelManager = null;
		#endregion Fields

		#region Methods
		private void Start()
		{
			_viewModelManager = ViewModelManager.Instance;
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

			_meshPath.SetPathWithoutNotify(modelPath.meshPath);
			_albedoPath.SetPathWithoutNotify(modelPath.texturesPath.AlbedoPath);
			_normalPath.SetPathWithoutNotify(modelPath.texturesPath.NormalPath);
			_aoPath.SetPathWithoutNotify(modelPath.texturesPath.AoPath);

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