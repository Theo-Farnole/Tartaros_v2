namespace Tartaros.Utilities.SpatialPartioning
{
	using System;

	public class SameTransformInMultipleCellsException : Exception
	{
		public SameTransformInMultipleCellsException() : base("A transform is present in multiple cells. Call Move method when moving a transform.")
		{ }
	}
}
