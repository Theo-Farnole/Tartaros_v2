using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;

namespace CTS
{
    /// <summary>
    /// Injects CTS_PRESENT define into project
    /// </summary>
    [InitializeOnLoad]
    public class CTSDefinesEditor : Editor
    {
        static CTSDefinesEditor()
        {
            //Make sure we inject CTS_PRESENT
            var symbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            if (!symbols.Contains(CTSConstants.CTSPresentSymbol))
            {
                symbols += ";" + CTSConstants.CTSPresentSymbol;
                PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, symbols);
            }

            //Make sure build settings correct - warn the user about DX9 settings
            #if !UNITY_2018_1_OR_NEWER
            GraphicsDeviceType[] apis = PlayerSettings.GetGraphicsAPIs(EditorUserBuildSettings.selectedStandaloneTarget);
            foreach (var v in apis)
            {
                if (v == GraphicsDeviceType.Direct3D9)
                {
                    Debug.LogError("DirectX9 is not supported by CTS. Please go to Build Settings -> Player Settings -> Other Settings. Then UnCheck Auto Graphics API for Windows and remove Direct3D9 from the Grapics APIs list.");
                }
            }
            #endif
        }
    }
}