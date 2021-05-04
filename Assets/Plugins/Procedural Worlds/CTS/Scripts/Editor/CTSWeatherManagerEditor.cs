﻿using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CTS
{
    /// <summary>
    /// Editor script weather manager
    /// </summary>
    [CustomEditor(typeof(CTSWeatherManager))]
    public class CTSWeatherManagerEditor : Editor
    {
        //private GUIStyle m_boxStyleNormal;
        private GUIStyle m_boxStyle;
        private GUIStyle m_wrapStyle;
        private GUIStyle m_wrapHelpStyle;
        //private GUIStyle m_descWrapStyle;
        private bool m_showTooltips = true;
        private bool m_globalHelp = false;
        private CTSWeatherManager m_manager;
        private bool m_seasonalTintActive = true;

        private List<int> m_textureIDsToIgnore = new List<int>();

        /// <summary>
        /// Called when we select this object
        /// </summary>
        void OnEnable()
        {
            //Check for target
            if (target == null)
            {
                return;
            }

            //Setup target
            m_manager = (CTSWeatherManager)target;
        }

        /// <summary>
        /// Editor UX
        /// </summary>
        public override void OnInspectorGUI()
        {
            #region Setup and introduction

            //Get the target
            m_manager = (CTSWeatherManager) target;

            //Set up the styles
            if (m_boxStyle == null)
            {
                m_boxStyle = new GUIStyle(GUI.skin.box);
                m_boxStyle.normal.textColor = GUI.skin.label.normal.textColor;
                m_boxStyle.fontStyle = FontStyle.Bold;
                m_boxStyle.alignment = TextAnchor.UpperLeft;
            }

            if (m_wrapStyle == null)
            {
                m_wrapStyle = new GUIStyle(GUI.skin.label);
                m_wrapStyle.fontStyle = FontStyle.Normal;
                m_wrapStyle.wordWrap = true;
            }

            if (m_wrapHelpStyle == null)
            {
                m_wrapHelpStyle = new GUIStyle(GUI.skin.label);
                m_wrapHelpStyle.richText = true;
                m_wrapHelpStyle.wordWrap = true;
            }

            //Text intro


            int majorVersion, minorVersion, patchVersion = 0;

            if (CTS.Internal.PWApp.CONF != null)
            {
                if (!Int32.TryParse(CTS.Internal.PWApp.CONF.MajorVersion, out majorVersion))
                {
                    Debug.LogWarning("Error when reading the CTS major version number!");
                }
                if (!Int32.TryParse(CTS.Internal.PWApp.CONF.MinorVersion, out minorVersion))
                {
                    Debug.LogWarning("Error when reading the CTS minor version number!");
                }
                if (!Int32.TryParse(CTS.Internal.PWApp.CONF.PatchVersion, out patchVersion))
                {
                    Debug.LogWarning("Error when reading the CTS patch version number!");
                }
            }
            else
            {
                majorVersion = CTSConstants.MajorVersion;
                minorVersion = CTSConstants.MinorVersion;
                patchVersion = CTSConstants.PatchVersion;
            }

            GUILayout.BeginVertical(string.Format("CTS ({0}.{1}.{2})", majorVersion, minorVersion, patchVersion), m_boxStyle);
            if (m_globalHelp)
            {
                Rect rect = EditorGUILayout.BeginVertical();
                //rect.y -= 10f;
                rect.x = rect.width - 10;
                rect.width = 25;
                rect.height = 20;
                if (GUI.Button(rect, "?-"))
                {
                    m_globalHelp = !m_globalHelp;
                }
                EditorGUILayout.EndVertical();
            }
            else
            {
                Rect rect = EditorGUILayout.BeginVertical();
                //rect.y -= 10f;
                rect.x = rect.width - 10;
                rect.width = 25;
                rect.height = 20;
                if (GUI.Button(rect, "?+"))
                {
                    m_globalHelp = !m_globalHelp;
                }
                EditorGUILayout.EndVertical();
            }

            GUILayout.Space(20);

            EditorGUILayout.LabelField("Welcome to CTS Weather Manager. Click ? for help.", m_wrapStyle);
            DrawHelpSectionLabel("Overview");

            if (m_globalHelp)
            {
                if (GUILayout.Button(GetLabel("View Online Tutorials & Docs")))
                {
                    Application.OpenURL("http://www.procedural-worlds.com/cts/");
                }
            }

            GUILayout.EndVertical();

            #endregion

            //Monitor for changes
            EditorGUI.BeginChangeCheck();

            GUILayout.BeginVertical("Control", m_boxStyle);
            GUILayout.Space(20f);
            DrawHelpSectionLabel("Control");


            GUILayout.BeginVertical(m_boxStyle);
            float rainPower = EditorGUILayout.Slider(GetLabel("Rain Power"), m_manager.RainPower, 0f, 1f);
            DrawHelpLabel("Rain Power");

            float snowPower = EditorGUILayout.Slider(GetLabel("Snow Power"), m_manager.SnowPower, 0f, 1f);
            DrawHelpLabel("Snow Power");

            float season = 0f;

            if (m_seasonalTintActive)
            {
                season = EditorGUILayout.Slider(GetLabel("Season"), m_manager.Season, 0f, 3.9999f);
                DrawHelpLabel("Season");

                EditorGUI.indentLevel++;
                if (season < 1f)
                {
                    EditorGUILayout.LabelField(string.Format("{0:0}% Winter {1:0}% Spring", (1f - season) * 100f, season * 100f));
                }
                else if (season < 2f)
                {
                    EditorGUILayout.LabelField(string.Format("{0:0}% Spring {1:0}% Summer", (2f - season) * 100f, (season - 1f) * 100f));
                }
                else if (season < 3f)
                {
                    EditorGUILayout.LabelField(string.Format("{0:0}% Summer {1:0}% Autumn", (3f - season) * 100f, (season - 2f) * 100f));
                }
                else
                {
                    EditorGUILayout.LabelField(string.Format("{0:0}% Autumn {1:0}% Winter", (4f - season) * 100f, (season - 3f) * 100f));
                }

                EditorGUI.indentLevel--;
            }
            GUILayout.EndVertical();
            GUILayout.EndVertical();

            GUILayout.BeginVertical("Settings", m_boxStyle);
            GUILayout.Space(20f);
            DrawHelpSectionLabel("Settings");

            GUILayout.BeginVertical(m_boxStyle);
            float minSnowHeight = EditorGUILayout.FloatField(GetLabel("Min Snow Height"), m_manager.SnowMinHeight);
            DrawHelpLabel("Min Snow Height");

            float maxSmoothness = EditorGUILayout.Slider(GetLabel("Max Smoothness"), m_manager.MaxRainSmoothness, 0f, 30f);
            DrawHelpLabel("Max Smoothness");

            m_seasonalTintActive = EditorGUILayout.Toggle(GetLabel("Seasonal Tint"), m_manager.SeasonalTintActive);
            DrawHelpLabel("Seasonal Tint");

            Color winterTint = m_manager.WinterTint;
            Color springTint = m_manager.SpringTint;
            Color summerTint = m_manager.SummerTint;
            Color autumnTint = m_manager.AutumnTint;

            if (m_seasonalTintActive)
            {

                winterTint = EditorGUILayout.ColorField(GetLabel("Winter Tint"), m_manager.WinterTint);
                DrawHelpLabel("Winter Tint");

                springTint = EditorGUILayout.ColorField(GetLabel("Spring Tint"), m_manager.SpringTint);
                DrawHelpLabel("Spring Tint");

                summerTint = EditorGUILayout.ColorField(GetLabel("Summer Tint"), m_manager.SummerTint);
                DrawHelpLabel("Summer Tint");

                autumnTint = EditorGUILayout.ColorField(GetLabel("Autumn Tint"), m_manager.AutumnTint);
                DrawHelpLabel("Autumn Tint");
            }
            EditorGUI.indentLevel++;
            var list = serializedObject.FindProperty("TextureIDsToIgnore");
            EditorGUILayout.PropertyField(list,GetLabel("Ignored Texture IDs"),true);
            EditorGUI.indentLevel--;
            GUILayout.EndVertical();
            

            GUILayout.EndVertical();

            //Handle changes
            if (EditorGUI.EndChangeCheck())
            {
                CompleteTerrainShader.SetDirty(m_manager, false, false);

                //UX Settings
                m_manager.SnowPower = snowPower;
                m_manager.SnowMinHeight = minSnowHeight;
                m_manager.RainPower = rainPower;
                m_manager.SeasonalTintActive = m_seasonalTintActive;
                m_manager.Season = season;
                m_manager.MaxRainSmoothness = maxSmoothness;
                m_manager.WinterTint = winterTint;
                m_manager.SpringTint = springTint;
                m_manager.SummerTint = summerTint;
                m_manager.AutumnTint = autumnTint;
                serializedObject.ApplyModifiedProperties();
            }
        }

        /// <summary>
        /// Draw some help
        /// </summary>
        /// <param name="title"></param>
        private void DrawHelpSectionLabel(string title)
        {
            if (m_globalHelp)
            {
                string description;
                if (m_tooltips.TryGetValue(title, out description))
                {
                    GUILayout.BeginVertical(m_boxStyle);
                    if (EditorGUIUtility.isProSkin)
                    {
                        EditorGUILayout.LabelField(string.Format("<color=#CBC5C1><b>{0}</b>\n\n{1}\n</color>", title, description), m_wrapHelpStyle);
                    }
                    else
                    {
                        EditorGUILayout.LabelField(string.Format("<color=#3F3D40><b>{0}</b>\n\n{1}\n</color>", title, description), m_wrapHelpStyle);
                    }
                    GUILayout.EndVertical();
                }
            }
        }

        /// <summary>
        /// Draw some help
        /// </summary>
        /// <param name="title"></param>
        private void DrawHelpLabel(string title)
        {
            if (m_globalHelp)
            {
                string description;
                if (m_tooltips.TryGetValue(title, out description))
                {
                    //EditorGUILayout.LabelField(string.Format("<color=lightblue><b>{0}</b>\n{1}</color>", title, description), m_wrapHelpStyle);
                    EditorGUI.indentLevel++;
                    if (EditorGUIUtility.isProSkin)
                    {
                        EditorGUILayout.LabelField(string.Format("<color=#98918F>{0}</color>", description), m_wrapHelpStyle);
                    }
                    else
                    {
                        EditorGUILayout.LabelField(string.Format("<color=#6F6C6F>{0}</color>", description), m_wrapHelpStyle);
                    }
                    EditorGUI.indentLevel--;
                }
            }
        }

        /// <summary>
        /// Get a content label - look the tooltip up if possible
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        GUIContent GetLabel(string name)
        {
            string tooltip = "";
            if (m_showTooltips)
            {
                if (m_tooltips.TryGetValue(name, out tooltip))
                {
                    return new GUIContent(name, tooltip);
                }
                else
                {
                    return new GUIContent(name);
                }
            }
            else
            {
                return new GUIContent(name);
            }
        }

        /// <summary>
        /// The tooltips
        /// </summary>
        static Dictionary<string, string> m_tooltips = new Dictionary<string, string>
        {
            { "Overview", "    The CTS Weather Manager provides a simple interface to allow you to control the way the currently selected terrain material responds to weather changes.\n\nUse the control panel below to change the settings, or alternatively use the properties on the weather manager object in your scripts to change it.\n\nNOTE: These settings will not change your profile, and when you update your profile it will overwrite the terrain material with its own settings until the weather manager is updated again."},
            { "Control", "    This section allows you to control the way the weather and seasons are applied to the terrain."},
            { "Settings", "    This section allows you to update the settings used to apply the weather and seasons to the terrain."},
            { "Rain Power", "The power of the rain. This modifies texture smoothness to simulate the effect of rain."},
            { "Snow Power", "The power of the snow. This controls the strength of the snow setting applied."},
            { "Season", "The season controls the tint applied to the terrain textures to simulate seasonal shifts. Note: This tint will overwrite the any tint that may have been configured in the profile."},
            { "Min Snow Height", "The minimum height from which snow will be applied."},
            { "Seasonal Tint", "Enables / disables Seasonal color tinting on the terrain. When switched off during runtime, the seasonal tint will stay as it is in that moment."},
            { "Winter Tint", "The tint that will be applied in winter."},
            { "Sprint Tint", "The tint that will be applied in spring."},
            { "Summer Tint", "The tint that will be applied in summer."},
            { "Autumn Tint", "The tint that will be applied in autumn."},
            { "Ignored IDs for Seasonal Tint", "You can enter multiple texture IDs here that will be ignored when applying the seasonal tint. 1st texture in the profile = 0, 2nd = 1, etc." },

        };

    }
}

