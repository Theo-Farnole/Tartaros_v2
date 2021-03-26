namespace Tartaros.Selection
{
	using Sirenix.OdinInspector;
	using System;
	using UnityEngine;

	class ChangeMaterialOnSelection : MonoBehaviour, ISelectionEffect
	{
		#region Fields
		[SerializeField]
		[SuffixLabel("self if null")]
		private Renderer _renderer = null;

		[SerializeField]
		private Material _selectedMaterial = null;

		private Material _unselectedMaterial = null;
		#endregion Fields

		#region Methods
		void Start()
		{
			if (_renderer == null)
			{
				_renderer = GetComponent<Renderer>();
			}

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
