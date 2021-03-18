﻿namespace Tartaros.Selection
{
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Entities;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class CurrentSelection : MonoBehaviour, ISelection
	{
		#region Fields
		[SerializeField]
		private List<Team> _selectableTeams = new List<Team>();

		List<ISelectable> _selectedObjets = new List<ISelectable>();
		#endregion Fields

		#region Properties
		ISelectable[] ISelection.SelectedSelectables => _selectedObjets.ToArray();
		private ISelection Selection => this as ISelection;
		#endregion Properties

		#region Methods
		void Awake()
		{
			Services.Instance.RegisterService(this);
		}

		void ISelection.AddToSelection(ISelectable selectable)
		{
			if (Selection.IsSelected(selectable) == true)
			{
				Debug.LogErrorFormat("Error while trying to add to selection: selectable \"{0}\" is already in selection.", GetSelectableName(selectable));
				return;
			}

			if (DoSelectableBelongToSelectableTeam(selectable) == false) return;

			if (DoMustClearSelection(selectable))
			{
				Selection.ClearSelection();
			}

			UnselectNoMultiSelectables();

			_selectedObjets.Add(selectable);
			selectable.OnSelected();
		}

		void ISelection.AddToSelection(ISelectable[] selectables)
		{
			if (selectables == null) return;

			foreach (ISelectable selectable in selectables)
			{
				if (selectable.CanBeMultiSelected == true)
				{
					Selection.AddToSelection(selectable);
				}
			}
		}

		void ISelection.RemoveFromSelection(ISelectable selectable)
		{
			if (Selection.IsSelected(selectable) == false)
			{
				Debug.LogErrorFormat("Error while trying to remove from selection: selectable \"{0}\" is not in selection.", GetSelectableName(selectable));
				return;
			}

			if (DoSelectableBelongToSelectableTeam(selectable) == false) return;

			_selectedObjets.Remove(selectable);
			selectable.OnUnselected();
		}

		void ISelection.ClearSelection()
		{
			for (int i = _selectedObjets.Count - 1; i >= 0; i--)
			{
				Selection.RemoveFromSelection(_selectedObjets[i]);
			}
		}

		bool ISelection.IsSelected(ISelectable selectable)
		{
			return _selectedObjets.Contains(selectable);
		}

		void ISelection.AlternateSelection(ISelectable selectable)
		{
			if (Selection.IsSelected(selectable))
			{
				Selection.RemoveFromSelection(selectable);
			}
			else
			{
				Selection.AddToSelection(selectable);
			}
		}

		private void UnselectNoMultiSelectables()
		{
			var elementsToRemove = _selectedObjets
				.Where(x => x.CanBeMultiSelected == false)
				.ToList();

			foreach (var element in elementsToRemove)
			{
				Selection.RemoveFromSelection(element);
			}
		}

		private bool DoMustClearSelection(ISelectable selectable)
		{
			return selectable.CanBeMultiSelected == false;
		}

		private string GetSelectableName(ISelectable selectable)
		{
			return selectable.GameObject.name;
		}

		private bool DoSelectableBelongToSelectableTeam(ISelectable selectable)
		{
			return _selectableTeams.Contains(selectable.Team);
		}
		#endregion Methods
	}
}
