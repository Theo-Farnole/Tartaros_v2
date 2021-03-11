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

		#region Properties
		ISelectable[] ISelection.SelectedSelectables => _selectedObjets.ToArray();
		#endregion Properties

		#region Methods
		void Awake()
		{
			Services.Instance.RegisterService(this);
		}

		void ISelection.AddToSelection(ISelectable selectable)
		{
			if ((this as ISelection).IsSelected(selectable) == true)
			{
				Debug.LogErrorFormat("Error while trying to add to selection: selectable \"{0}\" is already in selection.", GetSelectableName(selectable));
				return;
			}

			_selectedObjets.Add(selectable);
			selectable.OnSelected();
		}

		void ISelection.AddToSelection(ISelectable[] selectables)
		{
			if (selectables == null) return;

			foreach (ISelectable selectable in selectables)
			{
				(this as ISelection).AddToSelection(selectable);
			}
		}

		void ISelection.RemoveFromSelection(ISelectable selectable)
		{
			if ((this as ISelection).IsSelected(selectable) == false)
			{
				Debug.LogErrorFormat("Error while trying to remove from selection: selectable \"{0}\" is not in selection.", GetSelectableName(selectable));
				return;
			}

			_selectedObjets.Remove(selectable);
			selectable.OnUnselected();
		}

		void ISelection.ClearSelection()
		{
			_selectedObjets.Clear();
		}

		bool ISelection.IsSelected(ISelectable selectable)
		{
			return _selectedObjets.Contains(selectable);
		}

		void ISelection.AlternateSelection(ISelectable selectable)
		{
			var selfSelection = this as ISelection;

			if (selfSelection.IsSelected(selectable))
			{
				selfSelection.RemoveFromSelection(selectable);
			}
			else
			{
				selfSelection.AddToSelection(selectable);
			}
		}

		private string GetSelectableName(ISelectable selectable)
		{
			return selectable is MonoBehaviour obj ? obj.name : selectable.ToString();
		}
		#endregion Methods
	}
}
