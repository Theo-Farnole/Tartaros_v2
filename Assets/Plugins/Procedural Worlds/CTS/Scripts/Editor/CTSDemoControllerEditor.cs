using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;

namespace CTS
{
    [CustomEditor(typeof(CTSDemoController))]
    public class CTSDemoControllerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if (GUILayout.Button("Reset Lighting"))
            {
                ((CTSDemoController)target).m_initialLightingSetupPerformed = false;
                ((CTSDemoController)target).SetupLightingAndPipelines();
            }

        }
    }
}
