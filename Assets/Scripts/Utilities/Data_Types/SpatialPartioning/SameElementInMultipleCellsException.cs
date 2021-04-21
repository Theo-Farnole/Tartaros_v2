namespace Tartaros.Utilities.SpatialPartioning
{
	using System;
	using UnityEngine;

	public class SameElementInMultipleCellsException : Exception
	{
		public SameElementInMultipleCellsException() : base("An element is present in multiple cells. Call Move method when moving a transform.")
		{ }

		public SameElementInMultipleCellsException(object obj) : base("The element \"{0}\" is present in multiple cells. Call Move method when moving a transform.".Format(obj.ToString()))
		{ }
	}
}
