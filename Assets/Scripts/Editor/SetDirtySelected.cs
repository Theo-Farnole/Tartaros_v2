namespace Tartaros.Editor
{
	using UnityEditor;

	public static class SetDirtySelected
	{
		[MenuItem("Tartaros/Set dirty selected objects than save.")]
		public static void SetDirtSelected()
		{
			foreach (UnityEngine.Object obj in Selection.objects)
			{
				EditorUtility.SetDirty(obj);
			}

			AssetDatabase.SaveAssets();
		}
	}
}