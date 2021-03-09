namespace Tartaros.Selection
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class Selectable : MonoBehaviour, ISelectable
	{
		#region Properties
		bool ISelectable.CanBeSelected { get; }
		#endregion Properties

		#region Events
		public event EventHandler<SelectedArgs> Selected = null;
		public event EventHandler<UnSelectedArgs> UnSelected = null;
		#endregion Events

		#region Methods
		void ISelectable.OnSelected()
		{
			throw new NotImplementedException();
		}

		void ISelectable.OnUnselected()
		{
			throw new NotImplementedException();
		}
		#endregion Methods
	}
}