namespace Tartaros.Selection
{
	using System.Collections.Generic;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class CurrentSelection : MonoBehaviour, ISelection
	{
		#region Fields
		List<ISelectable> _selectedObjets = new List<ISelectable>();
		#endregion Fields

		#region Methods
		void Awake()
		{
			Services.Instance.RegisterService(this);
		}

		void ISelection.AddToSelection(ISelectable selectable)
		{
			if (_selectedObjets.Contains(selectable) == true)
			{
				Debug.LogErrorFormat("Error while trying to add to selection: selectable \"{0}\" is already in selection.", GetSelectableName(selectable));
				return;
			}

			_selectedObjets.Add(selectable);
		}

		void ISelection.RemoveFromSelection(ISelectable selectable)
		{
			if (_selectedObjets.Contains(selectable) == false)
			{
				Debug.LogErrorFormat("Error while trying to remove from selection: selectable \"{0}\" is not in selection.", GetSelectableName(selectable));
				return;
			}

			_selectedObjets.Remove(selectable);
		}

		void ISelection.ClearSelection()
		{
			_selectedObjets.Clear();
		}

		private static string GetSelectableName(ISelectable selectable)
		{
			return selectable is MonoBehaviour obj ? obj.name : selectable.ToString();
		}
		#endregion Methods
	}
}
