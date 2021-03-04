
namespace Tartaros.MeshViewer.UI
{
	using UnityEngine;
	using UnityEngine.UI;
	using TMPro;
	using SFB;
	using System;

	internal class FileInputField : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private Button _openExplorerButton = null;

		[SerializeField]
		private TMP_InputField _pathOutput = null;

		[SerializeField]
		private string _filePanelTitle = "Open File";

		[SerializeField]
		private string[] _fileExtensions = new string[0];
		#endregion Fields

		#region Properties
		public string Path { get => _pathOutput.text; set => _pathOutput.text = value; }
		#endregion Properties

		#region Events
		public class PathChangedArgs : EventArgs
		{
			public readonly string path;

			public PathChangedArgs(string path)
			{
				this.path = path;
			}
		}

		public event EventHandler<PathChangedArgs> OnPathChanged = null;
		#endregion Events

		#region Methods
		private void OnEnable()
		{
			_openExplorerButton.onClick.RemoveListener(OnExplorerButtonClicked);
			_openExplorerButton.onClick.AddListener(OnExplorerButtonClicked);

			_pathOutput.onValueChanged.RemoveListener(OnPathOutputValueChanged);
			_pathOutput.onValueChanged.AddListener(OnPathOutputValueChanged);
		}

		private void OnDisable()
		{
			_pathOutput.onValueChanged.RemoveListener(OnPathOutputValueChanged);
			_openExplorerButton.onClick.RemoveListener(OnExplorerButtonClicked);
		}

		private void OnExplorerButtonClicked()
		{
			ExtensionFilter[] extensionFilters = new ExtensionFilter[]
			{
				new ExtensionFilter("", _fileExtensions)
			};

			string[] selectedFile = StandaloneFileBrowser.OpenFilePanel(_filePanelTitle, "", extensionFilters, false);

			if (selectedFile.Length == 0)
			{
				Debug.Log("File selection cancelled.");
				return;
			}

			_pathOutput.text = selectedFile[0];
		}

		private void OnPathOutputValueChanged(string path)
		{
			OnPathChanged?.Invoke(this, new PathChangedArgs(_pathOutput.text));
		}
		#endregion Methods
	}
}