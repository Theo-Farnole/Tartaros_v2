namespace Tartaros.Selection
{
	using System;
	using UnityEngine;

	public class Selectable : MonoBehaviour, ISelectable
	{
		#region Fields
		private ISelectionEffect _selectionEffect = null;
		#endregion Fields

		#region Properties
		bool ISelectable.CanBeSelected { get; }
		Vector3 ISelectable.Position => transform.position;
		GameObject ISelectable.GameObject => gameObject;
		#endregion Properties

		#region Events
		public event EventHandler<SelectedArgs> Selected = null;
		public event EventHandler<UnSelectedArgs> UnSelected = null;
		#endregion Events

		#region Methods
		void Awake()
		{
			_selectionEffect = GetComponent<ISelectionEffect>();
		}

		void ISelectable.OnSelected()
		{
			_selectionEffect.OnSelected();
		}

		void ISelectable.OnUnselected()
		{
			_selectionEffect.OnUnselected();
		}
		#endregion Methods
	}
}