namespace Tartaros.Selection
{
    using System;

    public class SelectedArgs : EventArgs
    {

    }
    public class UnSelectedArgs : EventArgs
    {

    }
    public interface ISelectable
    {
        bool CanBeSelected { get; }
        void OnSelected();
        void OnUnselected();

        event EventHandler<SelectedArgs> Selected;

        event EventHandler<UnSelectedArgs> UnSelected;

    }
}