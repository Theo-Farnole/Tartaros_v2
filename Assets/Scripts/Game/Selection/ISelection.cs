namespace Tartaros.Selection
{
	using System;
	public class SelectionChangedArgs : EventArgs
	{
		public readonly ISelectable[] added = null;
		public readonly ISelectable[] removed = null;

		public SelectionChangedArgs(ISelectable[] added, ISelectable[] removed)
		{
			this.added = added ?? new ISelectable[0];
			this.removed = removed ?? new ISelectable[0];
		}
	}

	public interface ISelection
	{
		ISelectable[] Objects { get; }
		int ObjectsCount { get; }

		event EventHandler<SelectionChangedArgs> SelectionChanged;

		void Clear();
		void Add(ISelectable selectable);
		void Add(ISelectable[] selectables);
		void Remove(ISelectable selectable);
		bool IsSelected(ISelectable selectable);

		// TODO: find a better name
		/// <summary>
		/// If selectable is selected, unselect it. Else, select it.
		/// </summary>
		void Toggle(ISelectable selectable);
	}
}