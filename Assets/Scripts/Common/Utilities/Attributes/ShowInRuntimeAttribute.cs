namespace Tartaros
{
	using Sirenix.OdinInspector;

	[IncludeMyAttributes, System.Diagnostics.Conditional("UNITY_EDITOR")]
	[HideInEditorMode]
	[ShowInInspector]
	[ReadOnly]
	public class ShowInRuntimeAttribute : System.Attribute
	{
	}

}