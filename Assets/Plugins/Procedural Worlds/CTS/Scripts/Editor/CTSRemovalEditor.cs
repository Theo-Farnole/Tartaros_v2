using UnityEditor;

namespace CTS
{
    /// <summary>
    /// This will remove CTS define in project when CTS is deleted
    /// </summary>
    public class CTSRemovalEditor : UnityEditor.AssetModificationProcessor
    {
        public static AssetDeleteResult OnWillDeleteAsset(string AssetPath, RemoveAssetOptions rao)
        {
            if (AssetPath.Contains("CTS"))
            {
                string symbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
                if (symbols.Contains(CTSConstants.CTSPresentSymbol))
                {
                    symbols = symbols.Replace(CTSConstants.CTSPresentSymbol + ";", "");
                    symbols = symbols.Replace(CTSConstants.CTSPresentSymbol, "");
                    PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, symbols);
                }
            }
            return AssetDeleteResult.DidNotDelete;
        }
    }
}