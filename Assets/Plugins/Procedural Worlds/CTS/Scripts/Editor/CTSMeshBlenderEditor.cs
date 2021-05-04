using UnityEditor;
using UnityEngine;

namespace CTS
{
    [CustomEditor(typeof(CTSMeshBlender)), CanEditMultipleObjects]
    public class CTSMeshBlenderEditor : Editor
    {
        void OnEnable()
        {
        }

        public override void OnInspectorGUI()
        {
            CTSMeshBlender ctsBlender = (CTSMeshBlender) target;

            EditorGUILayout.LabelField("Texture Blending");
            EditorGUI.indentLevel++;
            ctsBlender.m_textureBlendOffset = EditorGUILayout.FloatField("Offset", ctsBlender.m_textureBlendOffset);
            ctsBlender.m_textureBlendStart = EditorGUILayout.FloatField("Start", ctsBlender.m_textureBlendStart);
            if (ctsBlender.m_textureBlendStart < 0f)
            {
                ctsBlender.m_textureBlendStart = 0f;
            }
            ctsBlender.m_textureBlendHeight = EditorGUILayout.FloatField("Height", ctsBlender.m_textureBlendHeight);
            if (ctsBlender.m_textureBlendHeight < 0f)
            {
                ctsBlender.m_textureBlendHeight = 0f;
            }
            EditorGUI.indentLevel--;

            EditorGUILayout.LabelField("Normal Blending");
            EditorGUI.indentLevel++;
            ctsBlender.m_normalBlendOffset = EditorGUILayout.FloatField("Offset", ctsBlender.m_normalBlendOffset);
            ctsBlender.m_normalBlendStart = EditorGUILayout.FloatField("Start", ctsBlender.m_normalBlendStart);
            if (ctsBlender.m_normalBlendStart < 0f)
            {
                ctsBlender.m_normalBlendStart = 0f;
            }
            ctsBlender.m_normalBlendHeight= EditorGUILayout.FloatField("Height", ctsBlender.m_normalBlendHeight);
            if (ctsBlender.m_normalBlendHeight < 0f)
            {
                ctsBlender.m_normalBlendHeight = 0f;
            }
            EditorGUI.indentLevel--;

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Blend"))
            {
                ctsBlender.CreateBlend();
            }
            if (GUILayout.Button("Clear Blend"))
            {
                ctsBlender.ClearBlend();
            }
            EditorGUILayout.EndHorizontal();

            GUILayout.Space(20f);
            EditorGUILayout.LabelField("INTERNAL DEBUG - DONT CHANGE");
            DrawDefaultInspector();
        }
    }
}