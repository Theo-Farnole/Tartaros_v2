namespace Tartaros.MeshViewer
{
	using UnityEngine;
	using B83.Win32;
	using Tartaros.MeshViewer.UI;
	using System.Collections.Generic;
	using System.IO;

	public class FolderDragAndDrop : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private FolderInputField _output = null;
		#endregion Fields

		#region Methods
		private void OnEnable()
		{
			UnityDragAndDropHook.InstallHook();
			UnityDragAndDropHook.OnDroppedFiles -= UnityDragAndDropHook_OnDroppedFiles;
			UnityDragAndDropHook.OnDroppedFiles += UnityDragAndDropHook_OnDroppedFiles;
		}

		private void OnDisable()
		{
			UnityDragAndDropHook.OnDroppedFiles -= UnityDragAndDropHook_OnDroppedFiles;
			UnityDragAndDropHook.UninstallHook();
		}

		private void UnityDragAndDropHook_OnDroppedFiles(List<string> aPathNames, POINT aDropPoint)
		{
			_output.Path = Path.GetDirectoryName(aPathNames[0]);
		}
		#endregion Methods
	}
}
