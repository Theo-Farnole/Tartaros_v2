namespace Tartaros.Math
{
	using UnityEngine;

	public class Line
	{
		public Vector3 p1;
		public Vector3 p2;

		public Line(Vector3 p1, Vector3 p2)
		{
			this.p1 = p1;
			this.p2 = p2;
		}

		public Vector3 GetPositionFromPercent(float percent)
		{
			return Vector3.Lerp(p1, p2, percent);
		}
	}
}