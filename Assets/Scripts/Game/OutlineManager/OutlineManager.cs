namespace Tartaros
{
	using System.Collections;
	using System.Collections.Generic;
	using Tartaros.Entities;
	using UnityEngine;

	public class OutlineManager : MonoBehaviour
	{

		private Outline _outline = null;

		private void Update()
		{
			if(IsUnderOutline(out Outline outline) == true)
			{
				if (_outline != outline)
				{
					if (_outline != null)
					{
						_outline.enabled = false;
					}
					_outline = outline;
					_outline.enabled = true;
				}
				else if (outline == null)
				{
					if (_outline != null)
					{
						_outline.enabled = false;
						_outline = null;
					}
				}
			}
			else
			{
				if (_outline != null)
				{
					_outline.enabled = false;
					_outline = null;
				}
			}
		}


		private bool IsUnderOutline(out Outline outline)
		{
			if (MouseHelper.IsCursorOverWindow() == true && MouseHelper.GetGameObjectUnderCursor() != null)
			{
				var entity = MouseHelper.GetGameObjectUnderCursor().GetComponentInParent<Entity>();

				if (entity != null)
				{
					outline = entity.GetComponent<Outline>();

					if (outline != null)
					{
						return true;
					}
				}
			}
			outline = null;
			return false;
		}
	}
}