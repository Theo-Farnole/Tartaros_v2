namespace Tartaros.Selection
{
	using System;
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
		ISelectable[] ISelection.Objects
		{
			get
			{
				_selectedObjets.RemoveAll(x => x.IsInterfaceDestroyed());
				return _selectedObjets.Where(x => x.IsInterfaceDestroyed() == false).ToArray();
			}
		}

		int ISelection.ObjectsCount
		{
			get
			{
				_selectedObjets.RemoveAll(x => x.IsInterfaceDestroyed());
				return _selectedObjets.Where(x => x.IsInterfaceDestroyed() == false).Count();
			}
		}

		private ISelection Selection => this as ISelection;

		private event EventHandler<SelectionChangedArgs> SelectionChanged = null;
		event EventHandler<SelectionChangedArgs> ISelection.SelectionChanged { add => SelectionChanged += value; remove => SelectionChanged -= value; }
		#endregion Properties

		#region Methods
		void ISelection.Add(ISelectable selectable)
		{
			_Add(selectable, true);
		}

		void ISelection.Add(ISelectable[] selectables)
		{
			if (selectables is null) throw new ArgumentNullException(nameof(selectables));

			foreach (ISelectable selectable in selectables)
			{
				if (selectable.CanBeMultiSelected == true)
				{
					_Add(selectable, false);
				}
			}

			SelectionChanged?.Invoke(this, new SelectionChangedArgs());
		}

		void ISelection.Remove(ISelectable selectable)
		{
			_Remove(selectable, true);
		}

		private void _Add(ISelectable selectable, bool invokeEvent)
		{
			if (selectable is null) throw new ArgumentNullException(nameof(selectable));

			if (Selection.IsSelected(selectable) == true)
			{
				Debug.LogErrorFormat("Error while trying to add to selection: selectable \"{0}\" is already in selection.", GetSelectableName(selectable));
				return;
			}

			if (DoSelectableBelongToSelectableTeam(selectable) == false) return;

			if (DoMustClearSelection(selectable))
			{
				Selection.Clear();
			}

			UnselectNoMultiSelectables();

			_selectedObjets.Add(selectable);
			selectable.OnSelected();

			if (invokeEvent == true)
			{
				SelectionChanged?.Invoke(this, new SelectionChangedArgs());
			}
		}

		private void _Remove(ISelectable selectable, bool invokeEvent)
		{
			if (selectable is null) throw new ArgumentNullException(nameof(selectable));


			if (Selection.IsSelected(selectable) == false)
			{
				Debug.LogErrorFormat("Error while trying to remove from selection: selectable \"{0}\" is not in selection.", GetSelectableName(selectable));
				return;
			}

			if (DoSelectableBelongToSelectableTeam(selectable) == false) return;

			_selectedObjets.Remove(selectable);
			selectable.OnUnselected();

			if (invokeEvent == true)
			{
				SelectionChanged?.Invoke(this, new SelectionChangedArgs());
			}
		}

		void ISelection.Clear()
		{
			for (int i = _selectedObjets.Count - 1; i >= 0; i--)
			{
				_Remove(_selectedObjets[i], false);
			}

			SelectionChanged?.Invoke(this, new SelectionChangedArgs());
		}

		bool ISelection.IsSelected(ISelectable selectable)
		{
			if (selectable is null) throw new ArgumentNullException(nameof(selectable));

			return _selectedObjets.Contains(selectable);
		}

		void ISelection.Toggle(ISelectable selectable)
		{
			if (selectable is null) throw new ArgumentNullException(nameof(selectable));

			if (Selection.IsSelected(selectable))
			{
				Selection.Remove(selectable);
			}
			else
			{
				Selection.Add(selectable);
			}
		}

		private void UnselectNoMultiSelectables()
		{
			var elementsToRemove = _selectedObjets
				.Where(x => x.CanBeMultiSelected == false)
				.ToList();

			foreach (var element in elementsToRemove)
			{
				Selection.Remove(element);
			}
		}

		private bool DoMustClearSelection(ISelectable selectable)
		{
			if (selectable is null) throw new ArgumentNullException(nameof(selectable));

			return selectable.CanBeMultiSelected == false;
		}

		private string GetSelectableName(ISelectable selectable)
		{
			if (selectable is null) throw new ArgumentNullException(nameof(selectable));

			return selectable.GameObject.name;
		}

		private bool DoSelectableBelongToSelectableTeam(ISelectable selectable)
		{
			if (selectable is null) throw new ArgumentNullException(nameof(selectable));

			return _selectableTeams.Contains(selectable.Team);
		}
		#endregion Methods
	}
}
