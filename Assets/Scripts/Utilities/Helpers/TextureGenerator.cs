namespace Tartaros
{
	using UnityEngine;

	public static class TextureGenerator
	{
		public static Texture2D GenerateTexture2D(Color color)
		{
			Texture2D texture = new Texture2D(1, 1);
			texture.SetPixel(0, 0, color);
			texture.Apply();

			return texture;
		}
	}
}
