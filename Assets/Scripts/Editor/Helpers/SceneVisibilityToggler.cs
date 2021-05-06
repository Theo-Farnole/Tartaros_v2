namespace Tartaros.Editor
{
	using UnityEditor;
	using UnityEngine;

	public static class SceneVisibilityToggler
	{
		[MenuItem("Tartaros/Hide useless layer")]
		public static void ToggleUselessLayers()
		{
			int usefullLayers = ~LayerMask.GetMask("FogOfWar", "UI", "MiniMap");

			Tools.visibleLayers = usefullLayers;
		}
	}
}