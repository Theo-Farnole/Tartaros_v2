namespace Tartaros.Selection
{
    public interface ISelection
    {
        ISelectable[] SelectedSelectables { get; }

        void ClearSelection();
        void AddToSelection(ISelectable selectable);
        void AddToSelection(ISelectable[] selectables);
        void RemoveFromSelection(ISelectable selectable);
        bool IsSelected(ISelectable selectable);

        // TODO: find a better name
        /// <summary>
        /// If selectable is selected, unselect it. Else, select it.
        /// </summary>
        void AlternateSelection(ISelectable selectable);
    }
}