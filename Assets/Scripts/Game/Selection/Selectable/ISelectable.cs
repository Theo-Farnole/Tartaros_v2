namespace Tartaros.Selection
{
	using System;
	using Tartaros.Entities;
	using UnityEngine;

	public class SelectedArgs : EventArgs
	{

	}
	public class UnSelectedArgs : EventArgs
	{

	}
	public interface ISelectable
	{
		bool CanBeMultiSelected { get; }
		bool CanBeSelected { get; }
		Vector3 Position { get; }
		GameObject GameObject { get; }
		Team Team { get; set; }

		void OnSelected();
		void OnUnselected();
	}
}