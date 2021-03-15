namespace Tartaros.Selection
{
	using System;
	using Tartaros.Entities;
	using UnityEngine;

	public class Selectable : MonoBehaviour, ISelectable
	{
		#region Fields
		[SerializeField]
		private Team _team = Team.Player;

		private ISelectionEffect _selectionEffect = null;
		#endregion Fields

		#region Properties
		bool ISelectable.CanBeSelected { get; }
		Vector3 ISelectable.Position => transform.position;
		GameObject ISelectable.GameObject => gameObject;
		Team ISelectable.Team => _team;
		#endregion Properties

		#region Events
		public event EventHandler<SelectedArgs> Selected = null;
		public event EventHandler<UnSelectedArgs> Unselected = null;

		event EventHandler<SelectedArgs> ISelectable.Selected
		{
			add => Selected += value;
			remove => Selected -= value;
		}

		event EventHandler<UnSelectedArgs> ISelectable.UnSelected
		{
			add => Unselected += value;
			remove => Unselected -= value;
		}
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