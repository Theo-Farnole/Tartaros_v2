namespace Tartaros.Selection
{
	using System;
	using UnityEngine;

	public class SelectedArgs : EventArgs
	{

	}
	public class UnSelectedArgs : EventArgs
	{

	}
	public interface ISelectable
	{
		bool CanBeSelected { get; }
		Vector3 Position { get; }
		GameObject GameObject { get; }

		void OnSelected();
		void OnUnselected();

		event EventHandler<SelectedArgs> Selected;

		event EventHandler<UnSelectedArgs> UnSelected;

	}
}