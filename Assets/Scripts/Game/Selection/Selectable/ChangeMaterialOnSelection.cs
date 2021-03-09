namespace Tartaros.Selection
{
	using System;
	using UnityEngine;

	[RequireComponent(typeof(Renderer))]
	class ChangeMaterialOnSelection : MonoBehaviour, ISelectionEffect
	{
		#region Fields
		[SerializeField]
		private Material _selectedMaterial = null;

		private Material _unselectedMaterial = null;
		private Renderer _renderer = null; 
		#endregion Fields

		#region Methods
		void Start()
		{
			_renderer = GetComponent<Renderer>();
			_unselectedMaterial = _renderer.material;
		}

		void ISelectionEffect.OnSelected()
		{
			_renderer.material = _selectedMaterial;
		}

		void ISelectionEffect.OnUnselected()
		{
			_renderer.material = _unselectedMaterial;
		} 
		#endregion Methods
	}
}
