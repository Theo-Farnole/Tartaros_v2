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

		[SerializeField]
		private bool _canBeMultiSelected = true;

		private ISelectionEffect _selectionEffect = null;
		#endregion Fields

		#region Properties
		public bool CanBeMultiSelected { get => _canBeMultiSelected; set => _canBeMultiSelected = value; }
		public Team Team { get => _team; set => _team = value; }
		bool ISelectable.CanBeSelected { get; }
		Vector3 ISelectable.Position => transform.position;
		GameObject ISelectable.GameObject => gameObject;
		Team ISelectable.Team { get => _team; set => _team = value; }
		bool ISelectable.CanBeMultiSelected { get => _canBeMultiSelected; }
		#endregion Properties

		#region Methods
		void Awake()
		{
			_selectionEffect = GetComponent<ISelectionEffect>();
		}

		void ISelectable.OnSelected()
		{
			if (_selectionEffect != null)
			{
				_selectionEffect.OnSelected();
			}
		}

		void ISelectable.OnUnselected()
		{
			if (_selectionEffect != null)
			{
				_selectionEffect.OnUnselected();
			}
		}
		#endregion Methods
	}
}