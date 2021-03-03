
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
		private string _fileExtensions = "";
		#endregion Fields

		#region Properties
		public string Path => _pathOutput.text;
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
			string[] selectedFile = StandaloneFileBrowser.OpenFilePanel(_filePanelTitle, "", _fileExtensions, false);			

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