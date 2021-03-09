namespace Tartaros.Selection
{
	using UnityEngine;
	using UnityEngine.EventSystems;

	public class ClickSelectionInput : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private ISelection _selection = null;
		#endregion Fields

		#region Methods
		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (CanSelect() && TryGetISelectableUnderCursor(out ISelectable selectableUnderCursor) == true)
				{
					_selection.AlternateSelection(selectableUnderCursor);
				}
			}
		}

		private bool TryGetISelectableUnderCursor(out ISelectable selectableUnderCursor)
		{
			if (RaycastUnderCursor(out RaycastHit hit))
			{
				if (hit.transform.TryGetComponent(out selectableUnderCursor))
				{
					return true;
				}
			}

			selectableUnderCursor = null;
			return false;
		}

		private bool RaycastUnderCursor(out RaycastHit hit)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			return Physics.Raycast(ray, out hit, Mathf.Infinity);
		}

		private bool CanSelect()
		{
			return IsPointerOverUI() == false;
		}

		private bool IsPointerOverUI()
		{
			return EventSystem.current.IsPointerOverGameObject(-1);
		}
		#endregion Methods
	}
}
