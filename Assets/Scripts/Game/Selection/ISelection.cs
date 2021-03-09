namespace Tartaros.Selection
{
    public interface ISelection
    {
        void ClearSelection();
        void AddToSelection(ISelectable selectable);
        void RemoveFromSelection(ISelectable selectable);
    }
}