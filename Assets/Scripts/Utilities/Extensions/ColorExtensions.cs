namespace Tartaros
{
	using UnityEngine;

	public static class ColorExtensions
	{
		/// <returns># + the color to hex</returns>
		public static string ToHex(this Color c)
		{
			return "#{0}".Format(ColorUtility.ToHtmlStringRGB(c));
		}
	}
}
