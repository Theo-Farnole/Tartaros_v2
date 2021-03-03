namespace Tartaros.Selection
{
    public interface ISelection
    {
        ISelectable[] SelectedObject { get; }

        void Select();
        void Unselected();
        void AddToSelection();
        void RemoveToSelection();
    }
}