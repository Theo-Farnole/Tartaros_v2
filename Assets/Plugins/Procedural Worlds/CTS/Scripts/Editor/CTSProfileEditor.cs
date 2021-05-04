using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

#if SUBSTANCE_PLUGIN_ENABLED
using Substance.Game;
#endif

namespace CTS
{
    /// <summary>
    /// Editor script for a complete terrain shader profile
    /// </summary>
    [CustomEditor(typeof(CTSProfile))]
    public class CTSProfileEditor : Editor
    {
        private GUIStyle m_boxStyleNormal;
        private GUIStyle m_boxStyleNeedsUpdate;
        private GUIStyle m_boxStyle;
        private GUIStyle m_wrapStyle;
        private GUIStyle m_wrapHelpStyle;
        private GUIStyle m_imageLabelStyle;
        private CTSProfile m_profile;
        private bool m_showTooltips = true;
        private float m_minTerrainHeight = 0f;
        private float m_maxTerrainHeight = 1000f;
        private bool m_globalHelp = false;
        private bool m_profileIsActive = false;
        private Texture2D m_alertBG;

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
            m_profile = (CTSProfile)target;

            //Set the CTS dir in the profile, and work out if we are active
            if (m_profile != null)
            {
                m_profile.m_ctsDirectory = CompleteTerrainShader.GetCTSDirectory();
            }
            else
            {
                m_profileIsActive = false;
            }

            //Get some height defaults
            Terrain terrain = Terrain.activeTerrain;
            if (terrain != null)
            {
                m_minTerrainHeight = terrain.transform.position.y;
                m_maxTerrainHeight = m_minTerrainHeight + terrain.terrainData.size.y;
            }

            if (m_alertBG == null)
            {
                Texture2D bgTex = new Texture2D(5, 5);
                Color[] colors = new Color[25];
                for (int i = 0; i < 25; i++)
                {
                    colors[i] = new Color(255f / 255f, 152f / 255f, 152f / 255f, 0.1f);
                }
                bgTex.SetPixels(colors);
                bgTex.Apply(true);
                m_alertBG = bgTex;
            }
        }

        /// <summary>
        /// Editor UX
        /// </summary>
        public override void OnInspectorGUI()
        {
            #region Setup and introduction

            //Get the target
            m_profile = (CTSProfile)target;

            //Are we active on a terrain somewhere
            m_profileIsActive = CTSTerrainManager.Instance.ProfileIsActive(m_profile);

            //Set up the styles
            if (m_boxStyleNormal == null)
            {
                m_boxStyleNormal = new GUIStyle(GUI.skin.box);
                m_boxStyleNormal.normal.textColor = GUI.skin.label.normal.textColor;
                m_boxStyleNormal.fontStyle = FontStyle.Bold;
                m_boxStyleNormal.alignment = TextAnchor.UpperLeft;
            }

            if (m_boxStyleNeedsUpdate == null)
            {
                m_boxStyleNeedsUpdate = new GUIStyle(GUI.skin.box);
                m_boxStyleNeedsUpdate.normal.background = m_alertBG;
                m_boxStyleNeedsUpdate.normal.textColor = GUI.skin.label.normal.textColor;
                m_boxStyleNeedsUpdate.fontStyle = FontStyle.Bold;
                m_boxStyleNeedsUpdate.alignment = TextAnchor.UpperLeft;
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

            if (m_imageLabelStyle == null)
            {
                m_imageLabelStyle = new GUIStyle(GUI.skin.label);
                m_imageLabelStyle.fontStyle = FontStyle.Bold;
            }

            //Signal that we need to be baked
            if (m_profileIsActive && m_profile.NeedsArrayUpdate())
            {
                m_boxStyle = m_boxStyleNeedsUpdate;
            }
            else
            {
                m_boxStyle = m_boxStyleNormal;
            }


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


            //Text intro
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
            EditorGUILayout.LabelField("Welcome to CTS. Click ? for help.", m_wrapStyle);
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

            //Disable the profile until it is active
            if (!m_profileIsActive)
            {
                GUI.enabled = false;
            }

            if (m_profileIsActive && m_profile.m_currentRenderPipelineType != CompleteTerrainShader.GetRenderPipeline())
            {
                Debug.Log("CTS detected a rendering pipeline change, updating shader.");
                CTSTerrainManager.Instance.BroadcastProfileUpdate(m_profile);
            }

            #region Global settings

            GUILayout.BeginVertical(m_boxStyle);

            bool showGlobalSettings = EditorGUILayout.BeginToggleGroup(GetLabel(" Global Settings"), m_profile.m_showGlobalSettings);

            float globalUvMixPower = m_profile.m_globalUvMixPower;
            float globalUvMixStartDistance = m_profile.m_globalUvMixStartDistance;
            float globalNormalPower = m_profile.m_globalNormalPower;
            float globalTerrainSmoothness = m_profile.m_globalTerrainSmoothness;
            float globalTerrainSpecular = m_profile.m_globalTerrainSpecular;
            float globalTesselationPower = m_profile.m_globalTesselationPower;
            float globalTesselationMinDistance = m_profile.m_globalTesselationMinDistance;
            float globalTesselationMaxDistance = m_profile.m_globalTesselationMaxDistance;
            float globalTesselationPhongStrength = m_profile.m_globalTesselationPhongStrength;
            CTSConstants.AOType globalAOType = m_profile.m_globalAOType;
            float globalAoPower = m_profile.m_globalAOPower;
            CTSConstants.ShaderType shaderType = m_profile.ShaderType;

            if (showGlobalSettings == true)
            {
                GUILayout.BeginVertical(m_boxStyle);

                DrawHelpSectionLabel("Global Settings");

                shaderType = (CTSConstants.ShaderType)EditorGUILayout.EnumPopup(GetLabel("Shader Type"), shaderType);
                DrawHelpLabel("Shader Type");

                if (shaderType != CTSConstants.ShaderType.Unity)
                {
                    CTSShaderCriteria criteria = new CTSShaderCriteria(CompleteTerrainShader.GetRenderPipeline(), shaderType, CTSConstants.ShaderFeatureSet.None);
                    string shaderName;
                    if (!CTSConstants.shaderNames.TryGetValue(criteria, out shaderName))
                    {
                        string message;
                        m_tooltips.TryGetValue("Invalid RP Shadertype", out message);
                        EditorGUILayout.HelpBox(message, MessageType.Error, true);
                    }

#if UNITY_2018_3_OR_NEWER
                    if (shaderType == CTSConstants.ShaderType.Tesselation && m_profile.m_drawInstanced)
                    {
                        string message;
                        m_tooltips.TryGetValue("Tesselation Draw Instanced", out message);
                        EditorGUILayout.HelpBox(message, MessageType.Error, true);
                    }
#endif
                }

                CheckIfGUIEnabled(shaderType);

               

                globalTerrainSmoothness = EditorGUILayout.Slider(GetLabel("Smoothness"), globalTerrainSmoothness, 0f, 2f); //0.3
                DrawHelpLabel("Smoothness");
                globalTerrainSpecular = EditorGUILayout.Slider(GetLabel("Specular Power"), globalTerrainSpecular, 0f, 1f); //1
                DrawHelpLabel("Specular Power");
                if (shaderType != CTSConstants.ShaderType.Lite)
                {
                    globalNormalPower =
                        EditorGUILayout.Slider(GetLabel("Global Normal Power"), globalNormalPower, 0f, 1f); //0.5
                    DrawHelpLabel("Global Normal Power");

                    EditorGUILayout.LabelField(GetLabel("Ambient Occlusion"));
                    DrawHelpLabel("Ambient Occlusion");
                    EditorGUI.indentLevel++;
                    globalAOType =
                        (CTSConstants.AOType)EditorGUILayout.EnumPopup(GetLabel("Occlusion Type"), globalAOType);
                    DrawHelpLabel("Occlusion Type");
                    if (globalAOType != CTSConstants.AOType.None)
                    {
                        globalAoPower = EditorGUILayout.Slider(GetLabel("Occlusion Power"), globalAoPower, 0f, 1f); //1
                        DrawHelpLabel("Occlusion Power");

                        //Only allow advanced selection in advanced and tesselation shaders
                        if (shaderType == CTSConstants.ShaderType.Basic &&
                            globalAOType == CTSConstants.AOType.TextureBased)
                        {
                            globalAOType = CTSConstants.AOType.NormalMapBased;
                        }
                    }

                    EditorGUI.indentLevel--;
                }

                EditorGUILayout.LabelField(GetLabel("Global Mixing"));
                DrawHelpLabel("Global Mixing");
                EditorGUI.indentLevel++;
                globalUvMixStartDistance = EditorGUILayout.FloatField(GetLabel("Mix Distance"), globalUvMixStartDistance); //300
                DrawHelpLabel("Mix Distance");
                globalUvMixPower = EditorGUILayout.Slider(GetLabel("Mix Sharpness"), globalUvMixPower, 0.5f, 10f); //4
                DrawHelpLabel("Mix Sharpness");
                EditorGUI.indentLevel--;

                if (shaderType == CTSConstants.ShaderType.Tesselation)
                {
                    EditorGUILayout.LabelField("Tesselation");
                    DrawHelpLabel("Tesselation");
                    EditorGUI.indentLevel++;
                    globalTesselationPower = EditorGUILayout.Slider(GetLabel("Density"), globalTesselationPower, 1f, 20f); //5
                    DrawHelpLabel("Density");
                    globalTesselationMinDistance = EditorGUILayout.Slider(GetLabel("Min Distance"), globalTesselationMinDistance, 0f, 30f); //0
                    DrawHelpLabel("Min Distance");
                    globalTesselationMaxDistance = EditorGUILayout.Slider(GetLabel("Max Distance"), globalTesselationMaxDistance, 1f, 100f); //40
                    DrawHelpLabel("Max Distance");
                    //globalTesselationPhongStrength = EditorGUILayout.Slider(GetLabel("Phong Strength"), globalTesselationPhongStrength, 0f, 1f);
                    //DrawHelpLabel("Phong Strength");
                    EditorGUI.indentLevel--;
                }


                GUILayout.EndVertical();
            }

            EditorGUILayout.EndToggleGroup();
            GUILayout.Space(1);
            GUILayout.EndVertical();

            CheckIfGUIEnabled(shaderType);

            #endregion

            #region Texture settings

            GUILayout.BeginVertical(m_boxStyle);
            bool showTextureSettings = EditorGUILayout.BeginToggleGroup(GetLabel(" Texture Settings"), m_profile.m_showTextureSettings);
            CTSTerrainTextureDetails td;
            List<CTSTerrainTextureDetails> textureSettings = m_profile.TerrainTextures;
            if (showTextureSettings == true)
            {
                GUILayout.BeginVertical(m_boxStyle);

                DrawHelpSectionLabel("Texture Settings");

                EditorGUI.indentLevel++;
                for (int idx = 0; idx < textureSettings.Count; idx++)
                {
                    td = textureSettings[idx];
                    td.m_isOpenInEditor = EditorGUILayout.Foldout(td.m_isOpenInEditor, td.m_name);
                    if (td.m_isOpenInEditor)
                    {
                        #if !UNITY_WEBGL && !UNITY_WII && (!UNITY_2018_1_OR_NEWER || SUBSTANCE_PLUGIN_ENABLED)
                            HandleSubstanceTextureDetails(td);
                        #endif

                        td.Albedo = (Texture2D)EditorGUILayout.ObjectField(GetLabel("Albedo"), td.Albedo, typeof(Texture2D), false, GUILayout.Height(16f));
                        DrawHelpLabel("Albedo");
                        if (td.m_albedoWasChanged)
                        {
                            td.m_albedoWasChanged = false;
                            m_profile.m_needsAlbedosArrayUpdate = true;
                            CTSTerrainManager.Instance.BroadcastAlbedoTextureSwitch(m_profile, td.Albedo, td.m_textureIdx, td.m_albedoTilingClose);
                        }
                        if (td.Albedo != null)
                        {
                            td.Normal = (Texture2D)EditorGUILayout.ObjectField(GetLabel("Normal"), td.Normal, typeof(Texture2D), false, GUILayout.Height(16f));
                            DrawHelpLabel("Normal");
                            if (td.m_normalWasChanged)
                            {
                                td.m_normalWasChanged = false;
                                m_profile.m_needsNormalsArrayUpdate = true;
                                CTSTerrainManager.Instance.BroadcastNormalTextureSwitch(m_profile, td.Normal, td.m_textureIdx, td.m_albedoTilingClose);
                            }

                            td.Smoothness = (Texture2D)EditorGUILayout.ObjectField(GetLabel("Smoothness"), td.Smoothness, typeof(Texture2D), false, GUILayout.Height(16f));
                            DrawHelpLabel("Smoothness Tx");
                            if (td.m_smoothnessWasChanged)
                            {
                                td.m_smoothnessWasChanged = false;
                                m_profile.m_needsAlbedosArrayUpdate = true;
                            }

                            td.Roughness = (Texture2D)EditorGUILayout.ObjectField(GetLabel("Roughness"), td.Roughness, typeof(Texture2D), false, GUILayout.Height(16f));
                            DrawHelpLabel("Roughness");
                            if (td.m_roughnessWasChanged)
                            {
                                td.m_roughnessWasChanged = false;
                                m_profile.m_needsAlbedosArrayUpdate = true;
                            }

                            if (shaderType == CTSConstants.ShaderType.Advanced || shaderType == CTSConstants.ShaderType.Tesselation)
                            {
                                td.Height = (Texture2D)EditorGUILayout.ObjectField(GetLabel("Height"), td.Height, typeof(Texture2D), false, GUILayout.Height(16f));
                                DrawHelpLabel("Height");
                                if (td.m_heightWasChanged)
                                {
                                    td.m_heightWasChanged = false;
                                    m_profile.m_needsNormalsArrayUpdate = true;
                                }
                                if (globalAOType == CTSConstants.AOType.TextureBased)
                                {
                                    td.AmbientOcclusion = (Texture2D)EditorGUILayout.ObjectField(GetLabel("Occlusion"), td.AmbientOcclusion, typeof(Texture2D), false, GUILayout.Height(16f));
                                    DrawHelpLabel("Occlusion");
                                    if (td.m_aoWasChanged)
                                    {
                                        td.m_aoWasChanged = false;
                                        //m_profile.m_needsAOArrayUpdate = true;
                                    }
                                }
                            }

                            EditorGUI.indentLevel--;
                            Rect rect = EditorGUILayout.BeginHorizontal();
                            GUILayout.Label("", GUILayout.Height(50));
                            GUILayout.EndHorizontal();
                            rect.xMin += 17f;
                            rect.width = 50f;
                            EditorGUI.DrawPreviewTexture(rect, td.Albedo);
                            DrawImageLabel(rect, "A");

                            if (td.Normal != null)
                            {
                                rect.position = new Vector2(rect.position.x + 57f, rect.position.y);
                                EditorGUI.DrawPreviewTexture(rect, td.Normal);
                                DrawImageLabel(rect, "N");
                            }

                            if (td.Smoothness != null)
                            {
                                rect.position = new Vector2(rect.position.x + 57f, rect.position.y);
                                EditorGUI.DrawPreviewTexture(rect, td.Smoothness);
                                DrawImageLabel(rect, "S");
                            }

                            if (td.Roughness != null)
                            {
                                rect.position = new Vector2(rect.position.x + 57f, rect.position.y);
                                EditorGUI.DrawPreviewTexture(rect, td.Roughness);
                                DrawImageLabel(rect, "R");
                            }

                            if (shaderType == CTSConstants.ShaderType.Advanced || shaderType == CTSConstants.ShaderType.Tesselation)
                            {
                                if (td.Height != null)
                                {
                                    rect.position = new Vector2(rect.position.x + 57f, rect.position.y);
                                    EditorGUI.DrawPreviewTexture(rect, td.Height);
                                    DrawImageLabel(rect, "H");
                                }

                                if (globalAOType == CTSConstants.AOType.TextureBased && td.AmbientOcclusion != null)
                                {
                                    rect.position = new Vector2(rect.position.x + 57f, rect.position.y);
                                    EditorGUI.DrawPreviewTexture(rect, td.AmbientOcclusion);
                                    DrawImageLabel(rect, "AO");
                                }

                                if (td.Emission != null)
                                {
                                    rect.position = new Vector2(rect.position.x + 57f, rect.position.y);
                                    EditorGUI.DrawPreviewTexture(rect, td.Emission);
                                    DrawImageLabel(rect, "E");
                                }
                            }
                            EditorGUI.indentLevel++;
                        }

                        td.m_albedoTilingClose = EditorGUILayout.FloatField(GetLabel(string.Format("Tile Size", idx)), td.m_albedoTilingClose);
                        DrawHelpLabel("Tile Size");
                        td.m_albedoTilingFar = EditorGUILayout.Slider(GetLabel("Far Multiplier"), td.m_albedoTilingFar, 0f, 20f); //3
                        DrawHelpLabel("Far Multiplier");
                        td.m_normalStrength = EditorGUILayout.Slider(GetLabel("Normal Power"), td.m_normalStrength, 0f, 10f); //1
                        DrawHelpLabel("Normal Power");
                        td.m_detailPower = EditorGUILayout.Slider(GetLabel("Detail Power"), td.m_detailPower, 0f, 1f); //1
                        DrawHelpLabel("Detail Power");
                        td.m_geologicalPower = EditorGUILayout.Slider(GetLabel("Geological Power"), td.m_geologicalPower, 0f, 1f); //1
                        DrawHelpLabel("Geological Power");
                        if (shaderType != CTSConstants.ShaderType.Lite)
                        {
                            td.m_snowReductionPower = 1f - EditorGUILayout.Slider(GetLabel("Snow Power"), 1f - td.m_snowReductionPower, 0f, 1f); //0
                            DrawHelpLabel("Snow Power");
                        }
                        if (globalAOType == CTSConstants.AOType.TextureBased)
                        {
                            td.m_aoPower = EditorGUILayout.Slider(GetLabel("Occlusion Power"), td.m_aoPower, 0f, 1f); // 1
                            DrawHelpLabel("Occlusion Power");
                        }
                        td.m_tint = EditorGUILayout.ColorField(GetLabel("Tint"), td.m_tint);
                        DrawHelpLabel("Tint");
                        td.m_tintBrightness = EditorGUILayout.Slider(GetLabel("Brightness"), td.m_tintBrightness, 0f, 2f);
                        DrawHelpLabel("Brightness");
                        td.m_smoothness = EditorGUILayout.Slider(GetLabel("Smoothness"), td.m_smoothness, 0f, 30f);
                        DrawHelpLabel("Smoothness");
                        if (shaderType == CTSConstants.ShaderType.Advanced || shaderType == CTSConstants.ShaderType.Tesselation)
                        {
                            if (idx != 0)
                            {
                                td.m_heightBlendClose = EditorGUILayout.Slider(GetLabel("Splat Sharp Close"), td.m_heightBlendClose, 1f, 10f); //5
                                DrawHelpLabel("Splat Sharp Close");
                                td.m_heightBlendFar = EditorGUILayout.Slider(GetLabel("Splat Sharp Far"), td.m_heightBlendFar, 1f, 10f); //5
                                DrawHelpLabel("Splat Sharp Far");
                            }
                            td.m_heightContrast = EditorGUILayout.Slider(GetLabel("Heightmap Contrast"), td.m_heightContrast, 0.3f, 10f); //5
                            DrawHelpLabel("Heightmap Contrast");
                            td.m_heightDepth = EditorGUILayout.Slider(GetLabel("Heightmap Depth"), td.m_heightDepth, 0f, 10f); //2
                            DrawHelpLabel("Heightmap Depth");
                            //td.m_emissionStrength = EditorGUILayout.Slider(GetLabel("Emission"), td.m_emissionStrength, 0f, 10f); // 1
                            if (shaderType == CTSConstants.ShaderType.Tesselation)
                            {
                                td.m_heightTesselationDepth = EditorGUILayout.Slider(GetLabel("Heightmap Tess Depth"), td.m_heightTesselationDepth, 0f, 10f); //2
                                DrawHelpLabel("Heightmap Tess Depth");
                            }
                        }
                        if (shaderType != CTSConstants.ShaderType.Lite)
                        {
                            td.m_triplanar = EditorGUILayout.Toggle(GetLabel("Triplanar"), td.m_triplanar);
                            DrawHelpLabel("Triplanar");
                        }
                    }
                }
                EditorGUI.indentLevel--;
                GUILayout.EndVertical();
            }
            EditorGUILayout.EndToggleGroup();
            GUILayout.Space(1);
            GUILayout.EndVertical();

            #endregion

            #region ColorMap Settings

            GUILayout.BeginVertical(m_boxStyle);
            bool showColorMapSettings = m_profile.m_showColorMapSettings;
            float colorMapClosePower = m_profile.m_colorMapClosePower / 10f;
            float colorMapFarPower = m_profile.m_colorMapFarPower / 10f;
            float colorMapOpacity = m_profile.m_colorMapOpacity;
            if (shaderType == CTSConstants.ShaderType.Lite)
            {
                showColorMapSettings = EditorGUILayout.BeginToggleGroup(GetLabel(" ColorMap Settings [disabled]"), showColorMapSettings);
            }
            else if (colorMapClosePower == 0f && colorMapFarPower == 0f)
            {
                showColorMapSettings = EditorGUILayout.BeginToggleGroup(GetLabel(" ColorMap Settings [inactive]"), showColorMapSettings);
            }
            else
            {
                showColorMapSettings = EditorGUILayout.BeginToggleGroup(GetLabel(" ColorMap Settings"), showColorMapSettings);
            }
            if (showColorMapSettings == true)
            {
                GUILayout.BeginVertical(m_boxStyle);

                if (shaderType == CTSConstants.ShaderType.Lite)
                {
                    EditorGUILayout.LabelField(GetLabel("ColorMap disabled in Lite shader"));
                }
                else
                {
                    DrawHelpSectionLabel("ColorMap Settings");
                    colorMapClosePower = EditorGUILayout.Slider(GetLabel("Close Power"), colorMapClosePower, 0f, 1f);
                    DrawHelpLabel("Close Power");
                    colorMapFarPower = EditorGUILayout.Slider(GetLabel("Far Power"), colorMapFarPower, 0f, 1f);
                    DrawHelpLabel("Far Power");
                    colorMapOpacity = EditorGUILayout.Slider(GetLabel("Transparency"), colorMapOpacity, 0f, 1f);
                    DrawHelpLabel("Transparency");
                }

                GUILayout.EndVertical();
            }
            EditorGUILayout.EndToggleGroup();
            GUILayout.Space(1);
            GUILayout.EndVertical();

            #endregion

            #region Detail Settings

            GUILayout.BeginVertical(m_boxStyle);
            Texture2D globalDetailNormalMap = m_profile.GlobalDetailNormalMap;
            float globalDetailNormalFarPower = m_profile.m_globalDetailNormalFarPower;
            float globalDetailNormalClosePower = m_profile.m_globalDetailNormalClosePower;
            float globalDetailNormalCloseTiling = m_profile.m_globalDetailNormalCloseTiling;
            float globalDetailNormalFarTiling = m_profile.m_globalDetailNormalFarTiling;
            bool showDetailSettings = m_profile.m_showDetailSettings;
            if (globalDetailNormalFarPower == 0f && globalDetailNormalClosePower == 0f)
            {
                showDetailSettings = EditorGUILayout.BeginToggleGroup(GetLabel(" Detail Settings [inactive]"), showDetailSettings);
            }
            else
            {
                showDetailSettings = EditorGUILayout.BeginToggleGroup(GetLabel(" Detail Settings"), showDetailSettings);
            }
            if (showDetailSettings == true)
            {
                GUILayout.BeginVertical(m_boxStyle);

                DrawHelpSectionLabel("Detail Settings");

                if (m_profile.m_globalDetailNormalMapIdx == -1 && (m_profile.m_globalDetailNormalClosePower > 0 ||  m_profile.m_globalDetailNormalFarPower > 0))
                {
                    EditorGUILayout.HelpBox("The detail normal map was inactive in this profile before. Please bake your textures to make sure the detail normal map will be included in the CTS Texture Arrays. The detail normal map feature will not work properly until the textures have been rebaked!", MessageType.Error);
                    m_profile.m_needsNormalsArrayUpdate = true;
                }

                if (m_profile.m_globalDetailNormalMapIdx != -1 && m_profile.m_globalDetailNormalClosePower <= 0 && m_profile.m_globalDetailNormalFarPower <= 0)
                {
                    EditorGUILayout.HelpBox("The close and far power is set to 0, but the CTS texture arrays still contain the detail normal map texture at the moment. Consider baking textures again to save memory.", MessageType.Info);
                }

                globalDetailNormalMap = (Texture2D)EditorGUILayout.ObjectField("Detail Normal", globalDetailNormalMap, typeof(Texture2D), false, GUILayout.Height(16f));
                DrawHelpLabel("Detail Normal");
                if (globalDetailNormalMap != null)
                {
                    globalDetailNormalClosePower = EditorGUILayout.Slider(GetLabel("Close Power"), globalDetailNormalClosePower, 0f, 10f); //0.3
                    DrawHelpLabel("Close Power");
                    if (globalDetailNormalClosePower > 0.0f)
                    {
                        EditorGUI.indentLevel++;
                        globalDetailNormalCloseTiling = EditorGUILayout.Slider(GetLabel("Close Tiling"), globalDetailNormalCloseTiling, 0f, 1000f); //300
                        DrawHelpLabel("Close Tiling");
                        EditorGUI.indentLevel--;
                    }
                    globalDetailNormalFarPower = EditorGUILayout.Slider(GetLabel("Far Power"), globalDetailNormalFarPower, 0f, 10f); //1
                    DrawHelpLabel("Far Power");
                    if (globalDetailNormalFarPower > 0.0f)
                    {
                        EditorGUI.indentLevel++;
                        globalDetailNormalFarTiling = EditorGUILayout.Slider(GetLabel("Far Tiling"), globalDetailNormalFarTiling, 0f, 1000f); //300
                        DrawHelpLabel("Far Tiling");
                        EditorGUI.indentLevel--;
                    }
                }
                else
                {
                    globalDetailNormalClosePower = 0f;
                    globalDetailNormalFarPower = 0f;
                }

                GUILayout.EndVertical();
            }
            EditorGUILayout.EndToggleGroup();
            GUILayout.Space(1);
            GUILayout.EndVertical();

            #endregion

            #region Geo Settings

            GUILayout.BeginVertical(m_boxStyle);
            float geoMapCloseOffset = m_profile.m_geoMapCloseOffset;
            float geoMapClosePower = m_profile.m_geoMapClosePower;
            float geoMapFarOffset = m_profile.m_geoMapFarOffset;
            float geoMapFarPower = m_profile.m_geoMapFarPower;
            float geoMapTilingClose = m_profile.m_geoMapTilingClose;
            float geoMapTilingFar = m_profile.m_geoMapTilingFar;
            Texture2D geoAlbedo = m_profile.GeoAlbedo;
            bool showGeoSettings = m_profile.m_showGeoSettings;
            if (geoMapClosePower == 0f && geoMapFarPower == 0f)
            {
                showGeoSettings = EditorGUILayout.BeginToggleGroup(GetLabel(" Geological Settings [inactive]"), showGeoSettings);
            }
            else
            {
                showGeoSettings = EditorGUILayout.BeginToggleGroup(GetLabel(" Geological Settings"), showGeoSettings);
            }
            if (showGeoSettings == true)
            {
                GUILayout.BeginVertical(m_boxStyle);

                DrawHelpSectionLabel("Geological Settings");

                geoAlbedo = (Texture2D)EditorGUILayout.ObjectField("Albedo", geoAlbedo, typeof(Texture2D), false, GUILayout.Height(16f));
                DrawHelpLabel("Albedo");
                if (geoAlbedo != null)
                {
                    geoMapClosePower = EditorGUILayout.Slider(GetLabel("Close Power"), geoMapClosePower, 0f, 10f); //1.1
                    DrawHelpLabel("Close Power");
                    if (geoMapClosePower > 0.0f)
                    {
                        EditorGUI.indentLevel++;
                        geoMapCloseOffset = EditorGUILayout.Slider(GetLabel("Close Offset"), geoMapCloseOffset, 0f, 1f); //0
                        DrawHelpLabel("Close Offset");
                        geoMapTilingClose = EditorGUILayout.Slider(GetLabel("Close Tiling"), geoMapTilingClose, 0f, 1000f); //20
                        DrawHelpLabel("Close Tiling");
                        EditorGUI.indentLevel--;
                    }
                    geoMapFarPower = EditorGUILayout.Slider(GetLabel("Far Power"), geoMapFarPower, 0f, 10f); //1.1
                    DrawHelpLabel("Far Power");
                    if (geoMapFarPower > 0.0f)
                    {
                        EditorGUI.indentLevel++;
                        geoMapFarOffset = EditorGUILayout.Slider(GetLabel("Far Offset"), geoMapFarOffset, 0f, 1f); //0
                        DrawHelpLabel("Far Offset");
                        geoMapTilingFar = EditorGUILayout.Slider(GetLabel("Far Tiling"), geoMapTilingFar, 0f, 1000f); //20
                        DrawHelpLabel("Far Tiling");
                        EditorGUI.indentLevel--;
                    }
                }
                GUILayout.EndVertical();
            }
            EditorGUILayout.EndToggleGroup();
            GUILayout.Space(1);
            GUILayout.EndVertical();

            #endregion

            #region Snow settings

            float snowAmount = m_profile.m_snowAmount;
            float snowMaxAngle = m_profile.m_snowMaxAngle;
            float snowMaxAngleHardness = m_profile.m_snowMaxAngleHardness;
            float snowMinHeight = m_profile.m_snowMinHeight;
            float snowMinHeightBlending = m_profile.m_snowMinHeightBlending;
            float snowNoisePower = m_profile.m_snowNoisePower;
            float snowNoiseTiling = m_profile.m_snowNoiseTiling;
            float snowNormalScale = m_profile.m_snowNormalScale;
            float snowDetailPower = m_profile.m_snowDetailPower;
            float snowTiling = m_profile.m_snowTilingClose;
            float snowTilingFarMultiplier = m_profile.m_snowTilingFar;
            float snowBlendNormal = m_profile.m_snowBlendNormal;
            float snowBrightness = m_profile.m_snowBrightness;
            float snowSmoothness = m_profile.m_snowSmoothness;
            Color snowTint = m_profile.m_snowTint;
            float snowSpecular = m_profile.m_snowSpecular;
            float snowHeightmapBlendClose = m_profile.m_snowHeightmapBlendClose;
            float snowHeightmapBlendFar = m_profile.m_snowHeightmapBlendFar;
            float snowHeightmapDepth = m_profile.m_snowHeightmapDepth;
            float snowHeightmapContrast = m_profile.m_snowHeightmapContrast;
            float snowAOStrength = m_profile.m_snowAOStrength;
            float snowTesselationDepth = m_profile.m_snowTesselationDepth;
            float snowGlitterColorPower = m_profile.m_snowGlitterColorPower;
            float snowGlitterNoiseThreshold = m_profile.m_snowGlitterNoiseThreshold;
            float snowGlitterSpecularPower = m_profile.m_snowGlitterSpecularPower;
            float snowGlitterSmoothness = m_profile.m_snowGlitterSmoothness;
            float snowGlitterRefreshSpeed = m_profile.m_snowGlitterRefreshSpeed;
            float snowGlitterTiling = m_profile.m_snowGlitterTiling;

            Texture2D snowAlbedo = m_profile.SnowAlbedo;
            Texture2D snowNormal = m_profile.SnowNormal;
            Texture2D snowHeight = m_profile.SnowHeight;
            Texture2D snowEmission = m_profile.SnowEmission;
            Texture2D snowOcclusion = m_profile.SnowAmbientOcclusion;
            Texture2D snowGlitter = m_profile.SnowGlitter;

            bool showSnowSettings = m_profile.m_showSnowSettings;

            GUILayout.BeginVertical(m_boxStyle);

            if (shaderType == CTSConstants.ShaderType.Lite)
            {
                showSnowSettings = EditorGUILayout.BeginToggleGroup(GetLabel(" Snow Settings [disabled]"), showSnowSettings);
                snowAmount = 0;
            }
            else
            {
                if (m_profile.m_snowAmount > 0)
                {
                    showSnowSettings = EditorGUILayout.BeginToggleGroup(GetLabel(" Snow Settings"), showSnowSettings);
                }
                else
                {
                    showSnowSettings = EditorGUILayout.BeginToggleGroup(GetLabel(" Snow Settings [inactive]"), showSnowSettings);
                }
            }

            if (showSnowSettings == true)
            {
                GUILayout.BeginVertical(m_boxStyle);

                DrawHelpSectionLabel("Snow Settings");

                if (m_profile.m_snowAlbedoTextureIdx == -1 && m_profile.m_snowNormalTextureIdx == -1 && m_profile.m_snowHeightTextureIdx == -1 && m_profile.m_snowAOTextureIdx == -1 && m_profile.m_snowAmount > 0)
                {
                    EditorGUILayout.HelpBox("Snow was inactive in this profile before. Please bake your textures to make sure the snow textures below are included in the CTS Texture Arrays. The snow feature will not work properly until the textures have been rebaked!", MessageType.Error);
                    m_profile.m_needsNormalsArrayUpdate = true;
                    m_profile.m_needsAlbedosArrayUpdate = true;
                }

                if (m_profile.m_snowAlbedoTextureIdx != -1 && m_profile.m_snowNormalTextureIdx != -1 && m_profile.m_snowHeightTextureIdx != -1 && m_profile.m_snowAOTextureIdx != -1 && m_profile.m_snowAmount <= 0)
                {
                    EditorGUILayout.HelpBox("The snow amount is set to 0, but the CTS texture arrays still contain snow textures at the moment. Consider baking textures again to save memory.", MessageType.Info);
                }

                if (shaderType == CTSConstants.ShaderType.Lite)
                {
                    EditorGUILayout.LabelField(GetLabel("Snow disabled in Lite shader"));
                }
                else
                {
                    snowAlbedo = (Texture2D)EditorGUILayout.ObjectField("Albedo", snowAlbedo, typeof(Texture2D), false, GUILayout.Height(16f));
                    DrawHelpLabel("Albedo");
                    snowNormal = (Texture2D)EditorGUILayout.ObjectField("Normal", snowNormal, typeof(Texture2D), false, GUILayout.Height(16f));
                    DrawHelpLabel("Normal");
                    snowHeight = (Texture2D)EditorGUILayout.ObjectField("Height", snowHeight, typeof(Texture2D), false, GUILayout.Height(16f));
                    DrawHelpLabel("Height");
                    if (globalAOType == CTSConstants.AOType.TextureBased)
                    {
                        snowOcclusion = (Texture2D)EditorGUILayout.ObjectField("Occlusion", snowOcclusion, typeof(Texture2D), false, GUILayout.Height(16f));
                        DrawHelpLabel("Occlusion");
                    }
                    //DrawHelpLabel("Emission");
                    //snowEmission = (Texture2D)EditorGUILayout.ObjectField("Emission", snowEmission, typeof(Texture2D), false, GUILayout.Height(16f));
                    snowGlitter = (Texture2D)EditorGUILayout.ObjectField("Glitter", snowGlitter, typeof(Texture2D), false, GUILayout.Height(16f));
                    DrawHelpLabel("Glitter");

                    if (snowAlbedo != null)
                    {
                        Rect rect = EditorGUILayout.BeginHorizontal();
                        GUILayout.Label("", GUILayout.Height(50));
                        GUILayout.EndHorizontal();
                        rect.xMin += 2f;
                        rect.width = 50f;
                        EditorGUI.DrawPreviewTexture(rect, snowAlbedo);
                        DrawImageLabel(rect, "A");

                        if (snowNormal != null)
                        {
                            rect.position = new Vector2(rect.position.x + 57f, rect.position.y);
                            EditorGUI.DrawPreviewTexture(rect, snowNormal);
                            DrawImageLabel(rect, "N");
                        }

                        if (snowHeight != null)
                        {
                            rect.position = new Vector2(rect.position.x + 57f, rect.position.y);
                            EditorGUI.DrawPreviewTexture(rect, snowHeight);
                            DrawImageLabel(rect, "H");
                        }

                        if (snowOcclusion != null)
                        {
                            rect.position = new Vector2(rect.position.x + 57f, rect.position.y);
                            EditorGUI.DrawPreviewTexture(rect, snowOcclusion);
                            DrawImageLabel(rect, "AO");
                        }

                        if (snowEmission != null)
                        {
                            rect.position = new Vector2(rect.position.x + 57f, rect.position.y);
                            EditorGUI.DrawPreviewTexture(rect, snowEmission);
                            DrawImageLabel(rect, "E");
                        }

                        if (snowGlitter != null)
                        {
                            rect.position = new Vector2(rect.position.x + 57f, rect.position.y);
                            EditorGUI.DrawPreviewTexture(rect, snowGlitter);
                            DrawImageLabel(rect, "G");
                        }

                        snowAmount = EditorGUILayout.Slider(GetLabel("Snow Amount"), snowAmount, 0f, 2f); //0
                        DrawHelpLabel("Snow Amount");
                        snowMaxAngle = EditorGUILayout.Slider(GetLabel("Max Angle"), snowMaxAngle, 0.001f, 180f); //40
                        DrawHelpLabel("Max Angle");
                        snowMaxAngleHardness = EditorGUILayout.Slider(GetLabel("Angle Hardness"), snowMaxAngleHardness, 0.01f, 10f); //1
                        DrawHelpLabel("Angle Hardness");
                        snowTiling = EditorGUILayout.Slider(GetLabel("Tile Size"), snowTiling, 0.1f, 300f); //15
                        DrawHelpLabel("Tile Size");
                        snowTilingFarMultiplier = EditorGUILayout.Slider(GetLabel("Far Multiplier"), snowTilingFarMultiplier, 1f, 20f); //5
                        DrawHelpLabel("Far Multiplier");
                        snowMinHeight = EditorGUILayout.Slider(GetLabel("Minimum Height"), snowMinHeight, m_minTerrainHeight, m_maxTerrainHeight); //100 --- make as 
                        DrawHelpLabel("Minimum Height");
                        snowMinHeightBlending = EditorGUILayout.Slider(GetLabel("Height Blend Range"), snowMinHeightBlending, 0f, (m_maxTerrainHeight - m_minTerrainHeight) / 2f);
                        DrawHelpLabel("Height Blend Range");
                        snowTint = EditorGUILayout.ColorField(GetLabel("Tint"), snowTint);
                        DrawHelpLabel("Tint");
                        snowBrightness = EditorGUILayout.Slider(GetLabel("Brightness"), snowBrightness, 0f, 2f); //0.8
                        DrawHelpLabel("Brightness");
                        snowSmoothness = EditorGUILayout.Slider(GetLabel("Smoothness"), snowSmoothness, 0f, 3f); //1
                        DrawHelpLabel("Smoothness");
                        snowSpecular = EditorGUILayout.Slider(GetLabel("Specular"), snowSpecular, 0f, 3f); //1
                        DrawHelpLabel("Specular");
                        snowAOStrength = EditorGUILayout.Slider(GetLabel("Occlusion"), snowAOStrength, 0f, 1f); //1
                        DrawHelpLabel("Occlusion");
                        snowNoisePower = EditorGUILayout.Slider(GetLabel("Noise Power"), snowNoisePower, 0f, 1f); //0.8
                        DrawHelpLabel("Noise Power");
                        snowNoiseTiling = EditorGUILayout.Slider(GetLabel("Noise Tiling"), snowNoiseTiling, 0f, 0.4f); //0.01
                        DrawHelpLabel("Noise Tiling");
                        snowNormalScale = EditorGUILayout.Slider(GetLabel("Normal Power"), snowNormalScale, 0f, 5f); // 1
                        DrawHelpLabel("Normal Power");
                        snowBlendNormal = 1f - EditorGUILayout.Slider(GetLabel("Normal Blend"), 1f - snowBlendNormal, 0f, 1f); //0.6
                        DrawHelpLabel("Normal Blend");
                        snowDetailPower = EditorGUILayout.Slider(GetLabel("Detail Power"), snowDetailPower, 0f, 1f); //0.5
                        DrawHelpLabel("Detail Power");

                        snowGlitterColorPower = EditorGUILayout.Slider(GetLabel("Glitter Color Power"), snowGlitterColorPower, 0f, 1f);
                        snowGlitterNoiseThreshold = EditorGUILayout.Slider(GetLabel("Glitter Noise Threshhold"), snowGlitterNoiseThreshold, 0f, 1f);
                        snowGlitterSpecularPower = EditorGUILayout.Slider(GetLabel("Glitter Specular Power"), snowGlitterSpecularPower, 0f, 1f); ;
                        snowGlitterSmoothness = EditorGUILayout.Slider(GetLabel("Glitter Smoothness"), snowGlitterSmoothness, 0f, 1f); ;
                        snowGlitterRefreshSpeed = EditorGUILayout.Slider(GetLabel("Glitter Refresh Speed"), snowGlitterRefreshSpeed, 0f, 6f); ;
                        snowGlitterTiling = EditorGUILayout.Slider(GetLabel("Glitter Tiling"), snowGlitterTiling, 0.1f, 4f); ;

                        if (shaderType != CTSConstants.ShaderType.Basic)
                        {
                            snowHeightmapBlendClose = EditorGUILayout.Slider(GetLabel("Splat Sharp Close"), snowHeightmapBlendClose, 0.003f, 10f); //1
                            DrawHelpLabel("Splat Sharp Close");
                            snowHeightmapBlendFar = EditorGUILayout.Slider(GetLabel("Splat Sharp Far"), snowHeightmapBlendFar, 0.003f, 10f); //1
                            DrawHelpLabel("Splat Sharp Far");
                            snowHeightmapContrast = EditorGUILayout.Slider(GetLabel("Heightmap Contrast"), snowHeightmapContrast, 0.3f, 10f); //1
                            DrawHelpLabel("Heightmap Contrast");
                            snowHeightmapDepth = EditorGUILayout.Slider(GetLabel("Heightmap Depth"), snowHeightmapDepth, 0f, 10f); //1
                            DrawHelpLabel("Heightmap Depth");
                            if (shaderType == CTSConstants.ShaderType.Tesselation)
                            {
                                snowTesselationDepth = EditorGUILayout.Slider(GetLabel("Heightmap Tess Depth"), snowTesselationDepth, 0f, 10f); //1
                                DrawHelpLabel("Heightmap Tess Depth");
                            }
                        }
                    }
                }
                GUILayout.EndVertical();
            }
            EditorGUILayout.EndToggleGroup();
            GUILayout.Space(1);
            GUILayout.EndVertical();

            #endregion

            #region Optimization settings

            GUILayout.BeginVertical(m_boxStyle);

            bool showOptimisationSettings = EditorGUILayout.BeginToggleGroup(GetLabel(" Optimization Settings"), m_profile.m_showOptimisationSettings);
            CTSConstants.TextureSize albedoTextureSize = m_profile.AlbedoTextureSize;
            int albedoAniso = m_profile.m_albedoAniso;
            CTSConstants.TextureSize normalTextureSize = m_profile.NormalTextureSize;
            int normalAniso = m_profile.m_normalAniso;
            bool compressNormals = m_profile.NormalCompressionEnabled;
            TextureFormat normalFormat = m_profile.m_normalFormat;
            bool compressAlbedos = m_profile.AlbedoCompressionEnabled;
            TextureFormat albedoFormat = m_profile.m_albedoFormat;
            bool globalStripTexturesAtRuntime = m_profile.m_globalStripTexturesAtRuntime;
            string terrainLayerPath = m_profile.m_terrainLayerPath;
#if UNITY_2018_3_OR_NEWER
            bool drawInstanced = m_profile.m_drawInstanced;
#else
            int targetDetailResolutionPerPatch = m_profile.m_targetDetailResolutionPerPatch;
#endif
            int renderQueue = m_profile.m_renderQueue;

            //bool globalDisconnectProfileAtRuntime = m_profile.m_globalDisconnectProfileAtRuntime;
            float globalBasemapDistance = m_profile.m_globalBasemapDistance;
            //bool persistMaterials = m_profile.m_persistMaterials;


#if UNITY_2018_3_OR_NEWER
            // override to always show the optimization settings to the user
            // in case they were checking the "Draw Instanced" box with shader type = tesselated
            // this is to prevent that the user "lock themselves out" from the profile
            if (shaderType == CTSConstants.ShaderType.Tesselation && m_profile.m_drawInstanced)
            {
                showOptimisationSettings = true;
            }
#endif

            if (showOptimisationSettings)
            {
                GUILayout.BeginVertical(m_boxStyle);

                DrawHelpSectionLabel("Optimization Settings");

                EditorGUILayout.LabelField(GetLabel("Compression Settings"));
                DrawHelpLabel("Compression Settings");
                EditorGUI.indentLevel++;

                albedoTextureSize = (CTSConstants.TextureSize)EditorGUILayout.EnumPopup(GetLabel("Albedo Size"), albedoTextureSize);
                DrawHelpLabel("Albedo Size");

                albedoAniso = EditorGUILayout.IntSlider(GetLabel("Albedo Aniso"), albedoAniso, 0, 16);
                DrawHelpLabel("Albedo Aniso");

                compressAlbedos = EditorGUILayout.Toggle(GetLabel("Compress Albedos"), compressAlbedos);
                DrawHelpLabel("Compress Albedos");

                if (compressAlbedos)
                {
                    albedoFormat = (TextureFormat)EditorGUILayout.EnumPopup(GetLabel("Albedo Compression Format"), albedoFormat);
                    DrawHelpLabel("Albedo Compression Format");
                    string message;
                    MessageType messageType;
                    if (!CheckForBuildCompressionSettings(albedoFormat, out message, out messageType))
                    {
                        EditorGUILayout.HelpBox(message, messageType, true);
                    }
                }

                normalTextureSize = (CTSConstants.TextureSize)EditorGUILayout.EnumPopup(GetLabel("Normal Size"), normalTextureSize);
                DrawHelpLabel("Normal Size");

                normalAniso = EditorGUILayout.IntSlider(GetLabel("Normal Aniso"), normalAniso, 0, 16);
                DrawHelpLabel("Normal Aniso");

                compressNormals = EditorGUILayout.Toggle(GetLabel("Compress Normals"), compressNormals);
                DrawHelpLabel("Compress Normals");

                if (compressNormals)
                {
                    normalFormat = (TextureFormat)EditorGUILayout.EnumPopup(GetLabel("Normal Compression Format"), normalFormat);
                    DrawHelpLabel("Normal Compression Format");
                    string message;
                    MessageType messageType;
                    if (!CheckForBuildCompressionSettings(normalFormat, out message, out messageType))
                    {
                        EditorGUILayout.HelpBox(message, messageType, true);
                    }
                }

                EditorGUI.indentLevel--;

                EditorGUILayout.LabelField(GetLabel("Runtime Optimization"));
                DrawHelpLabel("Runtime Optimization");
                EditorGUI.indentLevel++;

                globalBasemapDistance = EditorGUILayout.FloatField(GetLabel("LOD Distance"), globalBasemapDistance);
                DrawHelpLabel("LOD Distance");

#if UNITY_2018_3_OR_NEWER

                //override GUI.enabled for this field so the user can remove the profile lock that they just created
                // in case they were checking the "Draw Instanced" box with shader type = tesselated
                if (shaderType == CTSConstants.ShaderType.Tesselation && m_profile.m_drawInstanced)
                {
                    GUI.enabled = true;
                }
                //strip textures removed  here since not required with the new terrain system anymore.
                drawInstanced = EditorGUILayout.Toggle(GetLabel("Draw Instanced"), drawInstanced);
                DrawHelpLabel("Draw Instanced");

                if (shaderType == CTSConstants.ShaderType.Tesselation && m_profile.m_drawInstanced)
                {
                    string message;
                    m_tooltips.TryGetValue("Tesselation Draw Instanced", out message);
                    EditorGUILayout.HelpBox(message, MessageType.Error, true);
                }

                CheckIfGUIEnabled(shaderType);

#endif
                globalStripTexturesAtRuntime = EditorGUILayout.Toggle(GetLabel("Strip Textures"), globalStripTexturesAtRuntime);
                DrawHelpLabel("Strip Textures");

#if !UNITY_2018_3_OR_NEWER
                if(globalStripTexturesAtRuntime)
                {   
                    targetDetailResolutionPerPatch = EditorGUILayout.IntField(GetLabel("Detail Resolution Per Patch"), targetDetailResolutionPerPatch);
                    DrawHelpLabel("Detail Resolution Per Patch");
                }
#endif


                //globalDisconnectProfileAtRuntime = EditorGUILayout.Toggle(GetLabel("Disconnect Profile"), globalDisconnectProfileAtRuntime);
                //DrawHelpLabel("Disconnect Profile");

                EditorGUI.indentLevel--;

                renderQueue = EditorGUILayout.IntField(GetLabel("Render Queue"), renderQueue);

                terrainLayerPath = EditorGUILayout.TextField(GetLabel("Terrain Layer Path"), terrainLayerPath);

                if (terrainLayerPath == "")
                {
                    string message;
                    m_tooltips.TryGetValue("Terrain Layer Path Default", out message);
                    EditorGUILayout.HelpBox(message, MessageType.Info, true);
                }
                else
                {
                    if (!terrainLayerPath.EndsWith("/"))
                    {
                        terrainLayerPath += "/";
                    }

                    if (!terrainLayerPath.StartsWith("Assets/"))
                    {
                        string message;
                        m_tooltips.TryGetValue("Terrain Layer Path MustStartWithAsset", out message);
                        EditorGUILayout.HelpBox(message, MessageType.Error, true);
                    }
                    else
                    {
                        //Check if path exists
                        if(!Directory.Exists(terrainLayerPath))
                        {
                            string message;
                            m_tooltips.TryGetValue("Terrain Layer Path WillBeCreated", out message);
                            EditorGUILayout.HelpBox(message, MessageType.Warning, true);
                        }

                    }
                }


                //persistMaterials = EditorGUILayout.Toggle(GetLabel("Persist Materials"), persistMaterials);
                //DrawHelpLabel("Persist Materials");

                GUILayout.EndVertical();
            }
            EditorGUILayout.EndToggleGroup();
            GUILayout.Space(1);
            GUILayout.EndVertical();

#endregion

#region Controls

            DrawHelpSectionLabel("Controls");

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button(GetLabel("Bake Textures")))
            {
                EditorUtility.SetDirty(m_profile);
                CTSTerrainManager.Instance.BroadcastShaderSetup(m_profile);
                return;
            }
            if (GUILayout.Button(GetLabel("Bake Terrains")))
            {
                CTSTerrainManager.Instance.BroadcastBakeTerrains();
                return;
            }
            EditorGUILayout.EndHorizontal();
            GUI.enabled = true;

            if (shaderType == CTSConstants.ShaderType.Tesselation && (m_profile.m_currentRenderPipelineType == CTSConstants.EnvironmentRenderer.LightWeight || m_profile.m_currentRenderPipelineType == CTSConstants.EnvironmentRenderer.Universal))
            {
                GUI.enabled = false;
            }

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button(GetLabel("Apply Profile")))
            {
                if (EditorUtility.DisplayDialog("Apply CTS Profile", "You are about to apply this CTS Profile to all active terrains with an attached CTS component. This will exchange the textures on your terrains with the ones contained in the profile. Since your original terrain data will be modified during this operation, it is recommended to back up your project before. Continue?", "Yes", "Cancel"))
                {
                    CTSTerrainManager.Instance.BroadcastProfileSelect(m_profile);
                    return;
                }
            }
            EditorGUILayout.EndHorizontal();

#endregion

#region Handle changes

            //Check for changes, make undo record, make changes and let editor know we are dirty
            if (EditorGUI.EndChangeCheck())
            {
                CompleteTerrainShader.SetDirty(m_profile, false, true);

                //Profile version - will force signal of rebake if missing


                bool parseFailed = false;

                if (CTS.Internal.PWApp.CONF != null)
                {
                    if (!Int32.TryParse(CTS.Internal.PWApp.CONF.MajorVersion, out majorVersion))
                    {
                        parseFailed = true;
                        Debug.LogWarning("Error when reading the CTS major version number!");
                    }
                    if (!Int32.TryParse(CTS.Internal.PWApp.CONF.MinorVersion, out minorVersion))
                    {
                        parseFailed = true;
                        Debug.LogWarning("Error when reading the CTS minor version number!");
                    }
                    if (!Int32.TryParse(CTS.Internal.PWApp.CONF.PatchVersion, out patchVersion))
                    {
                        parseFailed = true;
                        Debug.LogWarning("Error when reading the CTS patch version number!");
                    }

                    if (!parseFailed)
                    {
                        m_profile.MajorVersion = majorVersion;
                        m_profile.MinorVersion = minorVersion;
                        m_profile.PatchVersion = patchVersion;

                        if (majorVersion != CTSConstants.MajorVersion ||
                           minorVersion != CTSConstants.MinorVersion ||
                           patchVersion != CTSConstants.PatchVersion)
                        {
                            Debug.LogError("Version Mismatch between app config and CTS constants!");

                        }

                    }
                }
                else
                {
                    m_profile.MajorVersion = CTSConstants.MajorVersion;
                    m_profile.MinorVersion = CTSConstants.MinorVersion;
                    m_profile.PatchVersion = CTSConstants.PatchVersion;
                }

                //UX Settings
                m_profile.m_showGlobalSettings = showGlobalSettings;
                m_profile.m_showSnowSettings = showSnowSettings;
                m_profile.m_showTextureSettings = showTextureSettings;
                m_profile.m_showGeoSettings = showGeoSettings;
                m_profile.m_showDetailSettings = showDetailSettings;
                m_profile.m_showColorMapSettings = showColorMapSettings;
                m_profile.m_showOptimisationSettings = showOptimisationSettings;

                //Global settings
                m_profile.m_globalUvMixStartDistance = globalUvMixStartDistance;
                m_profile.m_globalUvMixPower = globalUvMixPower;
                m_profile.m_globalNormalPower = globalNormalPower;
                m_profile.GlobalDetailNormalMap = globalDetailNormalMap;
                m_profile.m_globalDetailNormalCloseTiling = globalDetailNormalCloseTiling;
                m_profile.m_globalDetailNormalFarTiling = globalDetailNormalFarTiling;
                m_profile.m_globalDetailNormalClosePower = globalDetailNormalClosePower;
                m_profile.m_globalDetailNormalFarPower = globalDetailNormalFarPower;
                m_profile.m_globalTerrainSmoothness = globalTerrainSmoothness;
                m_profile.m_globalTerrainSpecular = globalTerrainSpecular;
                m_profile.m_globalTesselationPower = globalTesselationPower;
                m_profile.m_globalAOType = globalAOType;
                m_profile.m_globalAOPower = globalAoPower;
                m_profile.m_globalTesselationMinDistance = globalTesselationMinDistance;
                m_profile.m_globalTesselationMaxDistance = globalTesselationMaxDistance;
                m_profile.m_globalTesselationPhongStrength = globalTesselationPhongStrength;
                m_profile.m_globalBasemapDistance = globalBasemapDistance;
                m_profile.AlbedoTextureSize = albedoTextureSize;
                m_profile.m_albedoAniso = albedoAniso;
                m_profile.AlbedoCompressionEnabled = compressAlbedos;
                m_profile.m_albedoFormat = albedoFormat;
                m_profile.NormalTextureSize = normalTextureSize;
                m_profile.m_normalAniso = normalAniso;
                m_profile.NormalCompressionEnabled = compressNormals;
                m_profile.m_normalFormat = normalFormat;
                m_profile.m_globalStripTexturesAtRuntime = globalStripTexturesAtRuntime;
#if UNITY_2018_3_OR_NEWER
                m_profile.m_drawInstanced = drawInstanced;
#else
                //target detail resolution per patch only required for 2018.2 below
                m_profile.m_targetDetailResolutionPerPatch = targetDetailResolutionPerPatch;
#endif
                m_profile.m_renderQueue = renderQueue;
                m_profile.m_terrainLayerPath = terrainLayerPath;
                //m_profile.m_globalDisconnectProfileAtRuntime = globalDisconnectProfileAtRuntime;
                //m_profile.m_persistMaterials = persistMaterials;

                //Geological settings
                m_profile.m_geoMapCloseOffset = geoMapCloseOffset;
                m_profile.m_geoMapClosePower = geoMapClosePower;
                m_profile.m_geoMapFarOffset = geoMapFarOffset;
                m_profile.m_geoMapFarPower = geoMapFarPower;
                m_profile.m_geoMapTilingClose = geoMapTilingClose;
                m_profile.m_geoMapTilingFar = geoMapTilingFar;
                m_profile.GeoAlbedo = geoAlbedo;

                //Snow settings
                m_profile.SnowAlbedo = snowAlbedo;
                m_profile.SnowNormal = snowNormal;
                m_profile.SnowHeight = snowHeight;
                m_profile.SnowAmbientOcclusion = snowOcclusion;
                m_profile.SnowEmission = snowEmission;
                m_profile.SnowGlitter = snowGlitter;
                m_profile.m_snowAmount = snowAmount;
                m_profile.m_snowMaxAngle = snowMaxAngle;
                m_profile.m_snowMaxAngleHardness = snowMaxAngleHardness;
                m_profile.m_snowMinHeight = snowMinHeight;
                m_profile.m_snowMinHeightBlending = snowMinHeightBlending;
                m_profile.m_snowNoisePower = snowNoisePower;
                m_profile.m_snowNoiseTiling = snowNoiseTiling;
                m_profile.m_snowNormalScale = snowNormalScale;
                m_profile.m_snowDetailPower = snowDetailPower;
                m_profile.m_snowTilingClose = snowTiling;
                m_profile.m_snowTilingFar = snowTilingFarMultiplier;
                m_profile.m_snowBlendNormal = snowBlendNormal;
                m_profile.m_snowBrightness = snowBrightness;
                m_profile.m_snowSmoothness = snowSmoothness;
                m_profile.m_snowTint = snowTint;
                m_profile.m_snowSpecular = snowSpecular;
                m_profile.m_snowAOStrength = snowAOStrength;
                m_profile.m_snowHeightmapBlendClose = snowHeightmapBlendClose;
                m_profile.m_snowHeightmapBlendFar = snowHeightmapBlendFar;
                m_profile.m_snowHeightmapContrast = snowHeightmapContrast;
                m_profile.m_snowHeightmapDepth = snowHeightmapDepth;
                m_profile.m_snowTesselationDepth = snowTesselationDepth;
                m_profile.m_snowGlitterColorPower = snowGlitterColorPower;
                m_profile.m_snowGlitterNoiseThreshold = snowGlitterNoiseThreshold;
                m_profile.m_snowGlitterSpecularPower = snowGlitterSpecularPower;
                m_profile.m_snowGlitterSmoothness = snowGlitterSmoothness;
                m_profile.m_snowGlitterRefreshSpeed = snowGlitterRefreshSpeed;
                m_profile.m_snowGlitterTiling = snowGlitterTiling;

                //Colomap settings
                m_profile.m_colorMapClosePower = colorMapClosePower * 10f;
                m_profile.m_colorMapFarPower = colorMapFarPower * 10f;
                m_profile.m_colorMapOpacity = colorMapOpacity;

                //Shader type
                m_profile.ShaderType = shaderType;

#if UNITY_2018_3_OR_NEWER
                if (m_profile.ShaderType == CTSConstants.ShaderType.Tesselation && m_profile.m_drawInstanced)
                {
                    if (EditorUtility.DisplayDialog("Draw Instanced and Tessellation Warning", "You selected the Tessellation shader type together with the Draw Instanced optimization feature. Tessellation does not work in combination with Draw Instanced due to technical limitations of instanced terrain rendering. Do you want to switch off Draw Instanced for this profile?", "Yes", "Ignore for now"))
                    {
                        m_profile.m_drawInstanced = false;
                        drawInstanced = false;
                        m_profile.ignoreInstancedWarningPopUp = false;
                    }
                    else
                    {
                        m_profile.ignoreInstancedWarningPopUp = true;
                    }
                }
                else
                {
                    //Reset warning flag
                    m_profile.ignoreInstancedWarningPopUp = false;
                }
#endif

                //Check for presence of albedos and normals arrays - if missing then we need a rebake as CTS wont work
                if (m_profile.AlbedosTextureArray == null)
                {
                    m_profile.m_needsAlbedosArrayUpdate = true;
                }
                if (m_profile.NormalsTextureArray == null)
                {
                    m_profile.m_needsNormalsArrayUpdate = true;
                }

                //Let all shaders dependent on this do an update
                CTSTerrainManager.Instance.BroadcastProfileUpdate(m_profile);
            }

#endregion
        }
#if !UNITY_WEBGL && !UNITY_WII && (!UNITY_2018_1_OR_NEWER || SUBSTANCE_PLUGIN_ENABLED)
#if SUBSTANCE_PLUGIN_ENABLED
        private void HandleSubstanceTextureDetails(CTSTerrainTextureDetails td)
        {
            td.Substance = (SubstanceGraph)EditorGUILayout.ObjectField("Substance", td.Substance, typeof(SubstanceGraph), false, GUILayout.Height(16f));
            DrawHelpLabel("Substance");

            if (td.Substance != null)
            {
                td.m_substanceRegenOnBake = EditorGUILayout.Toggle(GetLabel("ReGen On Bake"), td.m_substanceRegenOnBake);
            }

            //Test to see if it changed - if so then auto assign as many textures as we can for it
            if (td.m_substanceWasChanged)
            {
                //Reset it
                td.m_substanceWasChanged = false;

                //Get busy autoassigning textures if we can
                string substancePath = m_profile.m_ctsDirectory + "Substances/" + td.Substance.name + "/";

                Texture2D[] generatedTextures = td.Substance.GetGeneratedTextures().ToArray();
                for (int sIdx = 0; sIdx < generatedTextures.Length; sIdx++)
                {

                    if (generatedTextures[sIdx] == null)
                    {
                        Debug.LogWarning("CTS found empty texture maps in the substance '" + td.Substance.name + "'. Please re-import / regenerate the substance in the asset hierarchy.");
                        continue;
                    }

                    if (generatedTextures[sIdx].name.EndsWith("baseColor"))
                    {
                        td.Albedo = AssetDatabase.LoadAssetAtPath(substancePath + generatedTextures[sIdx].name + ".png", typeof(Texture2D)) as Texture2D;
                    }
                    if (generatedTextures[sIdx].name.EndsWith("height"))
                    {
                        td.Height = AssetDatabase.LoadAssetAtPath(substancePath + generatedTextures[sIdx].name + ".png", typeof(Texture2D)) as Texture2D;
                    }
                    if (generatedTextures[sIdx].name.EndsWith("ambientOcclusion"))
                    {
                        td.AmbientOcclusion = AssetDatabase.LoadAssetAtPath(substancePath + generatedTextures[sIdx].name + ".png", typeof(Texture2D)) as Texture2D;
                    }
                    if (generatedTextures[sIdx].name.EndsWith("normal"))
                    {
                        var importer = AssetImporter.GetAtPath(substancePath + generatedTextures[sIdx].name + ".png") as TextureImporter;
                        if (importer != null && importer.textureType != TextureImporterType.NormalMap)
                        {
                            importer.textureType = TextureImporterType.NormalMap;
                            importer.SaveAndReimport();
                            AssetDatabase.Refresh();
                        }
                        td.Normal = AssetDatabase.LoadAssetAtPath(substancePath + generatedTextures[sIdx].name + ".png", typeof(Texture2D)) as Texture2D;
                    }
                    if (generatedTextures[sIdx].name.EndsWith("metallic"))
                    {
                        td.Smoothness = AssetDatabase.LoadAssetAtPath(substancePath + generatedTextures[sIdx].name + ".png", typeof(Texture2D)) as Texture2D;
                    }
                }
                if (td.Smoothness != null)
                {
                    td.Roughness = null;
                }
            }
        }
#else
        private void HandleSubstanceTextureDetails(CTSTerrainTextureDetails td)
        {
            td.Substance = (ProceduralMaterial)EditorGUILayout.ObjectField("Substance", td.Substance, typeof(ProceduralMaterial), false, GUILayout.Height(16f));
            DrawHelpLabel("Substance");

            if (td.Substance != null)
            {
                td.m_substanceRegenOnBake = EditorGUILayout.Toggle(GetLabel("ReGen On Bake"), td.m_substanceRegenOnBake);
            }

            //Test to see if it changed - if so then auto assign as many textures as we can for it
            if (td.m_substanceWasChanged)
            {
                //Reset it
                td.m_substanceWasChanged = false;

                //Get busy autoassigning textures if we can
                string substancePath = m_profile.m_ctsDirectory + "Substances/" + td.Substance.name + "/";

                Texture[] generatedTextures = td.Substance.GetGeneratedTextures();
                for (int sIdx = 0; sIdx < generatedTextures.Length; sIdx++)
                {
                    ProceduralTexture proceduralTexture = td.Substance.GetGeneratedTexture(generatedTextures[sIdx].name);
                    if (proceduralTexture.GetProceduralOutputType() == ProceduralOutputType.Diffuse)
                    {
                        td.Albedo = AssetDatabase.LoadAssetAtPath(substancePath + generatedTextures[sIdx].name + ".tga", typeof(Texture2D)) as Texture2D;
                    }
                    else if (proceduralTexture.GetProceduralOutputType() == ProceduralOutputType.Height)
                    {
                        td.Height = AssetDatabase.LoadAssetAtPath(substancePath + generatedTextures[sIdx].name + ".tga", typeof(Texture2D)) as Texture2D;
                    }
                    else if (proceduralTexture.GetProceduralOutputType() == ProceduralOutputType.AmbientOcclusion)
                    {
                        td.AmbientOcclusion = AssetDatabase.LoadAssetAtPath(substancePath + generatedTextures[sIdx].name + ".tga", typeof(Texture2D)) as Texture2D;
                    }
                    else if (proceduralTexture.GetProceduralOutputType() == ProceduralOutputType.Normal)
                    {
                        var importer = AssetImporter.GetAtPath(substancePath + generatedTextures[sIdx].name + ".tga") as TextureImporter;
                        if (importer != null && importer.textureType != TextureImporterType.NormalMap)
                        {
                            importer.textureType = TextureImporterType.NormalMap;
                            importer.SaveAndReimport();
                            AssetDatabase.Refresh();
                        }
                        td.Normal = AssetDatabase.LoadAssetAtPath(substancePath + generatedTextures[sIdx].name + ".tga", typeof(Texture2D)) as Texture2D;
                    }
                    else if (proceduralTexture.GetProceduralOutputType() == ProceduralOutputType.Smoothness)
                    {
                        td.Smoothness = AssetDatabase.LoadAssetAtPath(substancePath + generatedTextures[sIdx].name + ".tga", typeof(Texture2D)) as Texture2D;
                    }
                    else if (proceduralTexture.GetProceduralOutputType() == ProceduralOutputType.Roughness)
                    {
                        td.Roughness = AssetDatabase.LoadAssetAtPath(substancePath + generatedTextures[sIdx].name + ".tga", typeof(Texture2D)) as Texture2D;
                    }
                    //else if (proceduralTexture.GetProceduralOutputType() == ProceduralOutputType.Emissive)
                    //{
                    //    td.Emission = AssetDatabase.LoadAssetAtPath(substancePath + generatedTextures[sIdx].name + ".tga", typeof(Texture2D)) as Texture2D;
                    //}
                    if (td.Smoothness != null)
                    {
                        td.Roughness = null;
                    }
                }
            }
        }
#endif
#endif


        /// <summary>
        /// Disable the GUI for input for various shader types / settings
        /// </summary>
        private void CheckIfGUIEnabled(CTSConstants.ShaderType shaderType)
        {
            if (shaderType == CTSConstants.ShaderType.Unity)
            {
                GUI.enabled = false;
            }
#if UNITY_2018_3_OR_NEWER
            if (shaderType == CTSConstants.ShaderType.Tesselation && m_profile.m_drawInstanced)
            {
                GUI.enabled = false;
            }
#endif
            if (shaderType != CTSConstants.ShaderType.Unity)
            {
                CTSShaderCriteria criteria = new CTSShaderCriteria(CompleteTerrainShader.GetRenderPipeline(), shaderType, CTSConstants.ShaderFeatureSet.None);
                string shaderName;
                if (!CTSConstants.shaderNames.TryGetValue(criteria, out shaderName))
                {
                    GUI.enabled = false;
                }
            }

        }

        /// <summary>
        /// Checks if the supplied texture format is a recommended texture compression format for the current build target. 
        /// </summary>
        /// <param name="textureFormat">The texture format to check against.</param>
        /// <returns>True if there is a mismatch between build target and texture compression format.</returns>
        public bool CheckForBuildCompressionSettings(TextureFormat textureFormat, out string message, out MessageType messageType)
        {

            //Check for crunched textures first and abort early if found
            if (textureFormat.ToString().EndsWith("Crunched"))
            {
                message = "You selected crunch type compression. This might lead to processing errors in CTS and is usually not recommended for most platforms.";
                messageType = MessageType.Error;
                return false;
            }

            //Check if textures are recommended defaults for this build target.
            List<TextureFormat> recommendedFormats;
            if (CTSConstants.recommendedTextureFormats.TryGetValue(EditorUserBuildSettings.activeBuildTarget, out recommendedFormats))
            {
                if (!recommendedFormats.Contains(textureFormat))
                {
                    message = "The selection is not listed as default compression format for this platform. This might lead to texture rendering issues in a build.";
                    messageType = MessageType.Warning;
                    return false;
                }
                else
                {
                    message = "The selection is listed as default compression format by Unity.";
                    messageType = MessageType.Info;
                    return true;
                }
            }
            //Could not find the current build target in the dictionary, so we have no info about recommended formats.
            message = "The active build target had no default compression formats defined.";
            messageType = MessageType.Info;
            return true;
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
        /// Draw a label on an image
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="label"></param>
        private void DrawImageLabel(Rect rect, string label)
        {
            Color c = GUI.contentColor;
            GUI.contentColor = Color.black;
            rect.x += 1;
            EditorGUI.LabelField(rect, label, m_imageLabelStyle);
            GUI.contentColor = Color.white;
            rect.x -= 1;
            EditorGUI.LabelField(rect, label, m_imageLabelStyle);
            GUI.contentColor = c;
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
            { "Overview", "    CTS is a profile driven terrain shading system. To use CTS, first apply CTS to the terrain by selecting Component-> CTS-> Add CTS to terrain. Then create and apply a new profile by selecting Component-> CTS-> Create And Apply Profile, or by dragging an existing profile into the profile slot on the terrain, or by hitting Apply Profile on an existing profile.\n\n    Profiles are the textures and settings that drive CTS to render your terrain. Before a profile can be used, the profile needs to convert these textures into a more efficient format for the shader and this process is called baking. To add a new texture to the profile, first add it to the terrain in the usual way, and then re-bake the profile.\n\n    When CTS detects that it needs to bake its textures it will go RED. Click the Bake Textures button to re-bake the textures and see them applied to the terrain. Hit the Bake Terrains button to generate terrain normals and optionally terrain colour maps. These are used to add more interest to your terrain. Finally, when you click Apply to Terrain, CTS will find all CTS terrains and apply this profile and textures. A word of WARNING - this will overwrite any textures that were previously there!\n\n    To see the latest documentation and video tutorials please click on the button below."},
            { "Global Settings", "    This sections controls high level settings that apply to the entire terrain. You would typically set these first."},
            { "ColorMap Settings", "    This sections controls how the color map is applied to the terrain. A color map is a texture that is blended with the terrain to add more visual interest to it. While they are controlled from here, you need to add your colour maps to each individual terrain."},
            { "Controls", "    This sections controls baking and profile application.\n\n<b>Bake Textures</b> : When you change the textures in your environment you will need to bake it. This is only required when the inspector turns red.\n\n<b>Bake Terrains</b> : When your terrain heights are modified you will need to re-bake your terrain normals and color maps so that the shader can use them.\n\n<b>Apply Profile</b> : This will apply this profile and make it active on your terrain. Be careful with this as it will also overwrite any textures that were previously in your terrain. You will only be able to bake textures and normals when the profile is active on a terrain."},
            { "Shader Type", "The type of shader used to render your terrain. Each shader adds more features but these also take more time to render, so choose your shader according to the capability of your target audiences hardware.\n<b>Unity</b> - The Unity terrain shader.\n<b>Lite</b> - Fastest CTS terrain shader - no snow, no triplanar, no cutouts.\n<b>Basic</b> - The CTS basic terrain shader. Adds snow and triplanar. Good and fast in most scenarios. Triplanar is expensive, and should only be used on steeply angled textures such as cliffs.\n<b>Advanced</b> - The CTS Advanced terrain shader. Adds height blending.\n<b>Tesselation</b> - The CTS Advanced Tesselation terrain shader adds tesselation. Note: Tesselation is not actual terrain, it is a visual effect and should be used sparingly. You may also need to adjust your lights shadow bias if you get unusual shadows."},
            { "Invalid RP Shadertype", "CTS could not find a suitable shader for this shader type in this rendering pipeline configuration. Please change your shader type or your rendering pipeline configuration and re-apply the profile." },
            { "Tesselation Draw Instanced", "The tesselation shader type is not comptatible with the 'Draw Instanced' setting. This is a limitation of the instanced rendering. Please disable 'Draw Instanced' in the optimization settings or select a different shader type." },
            { "Roughness", "Optional texture that defines roughness. Infuences reflections - smooth surfaces reflect light back like a mirror and rough surfaces scatter light at many angles. Roughness is the inverse of smoothness. Will be baked into Alpha channel of Albedo."},
            { "Smoothness Tx", "Optional texture that defines smoothness (also known as Glossiness). Infuences reflections - smooth surfaces reflect light back like a mirror and rough surfaces scatter light at many angles. Smoothness is the inverse of roughness. Will be baked into Alpha channel of Albedo."},
            { "Smoothness", "The global terrain or per texture smoothness (also known as Glossiness). Infuences reflections - smooth surfaces reflect light back like a mirror and matte surfaces scatter light at many angles. Smoothness is the inverse of roughness."},
            { "Specular Power", "The terrain or snow specular power. Influences reflections - typically shows as brighter highlights, and is also affected by smoothness."},
            { "Ambient Occlusion", "The depth or darkeness of shadows. This effect will only be visible on areas of your terrain that are shadowed."},
            { "Occlusion Type", "The type of occlusion to apply. \n<b>None</b> - No occlusion.\n<b>Normal Map Based</b> - Approximated from normals.\n<b>Texture Based</b> - Based off the occlusion textures supplied. If no texture supplied then no occlusion is calculated."},
            { "Occlusion Power", "The maximum amount of occlusion applied. Can be overridden locally per texture when texture based occlusion is chosen."},
            { "Global Normal Power", "Uses the global normal map to add interesting highlights to distant terrain. This adds visual detail that would otherwise be lost back into the far distance."},
            { "LOD Distance", "The distance beyond which cheaper terrain will be drawn. Distant terrain will not look quite as good, but will also render a lot faster. CTS removes triplanar, ambient occlusion and other effects to speed up distant rendering. You would typically mask this with fog and atmospheric scattering."},
            { "Global Mixing", "The distance and sharpness of all mixing. This is used to drive the separation between CLOSE and FAR values. This is primarily used to break up tiling."},
            { "Mix Sharpness", "The sharpness of the mix. A higher value will result in a sharper mix."},
            { "Mix Distance", "The distance at which the mix is complete - from this distance onwards all mixing will be FAR mixing."},
            { "Detail Settings", "    This section controls the addition of detail from a normal map into your terrain to create a more interesting visual look and help break up tiling."},
            { "Detail Normal", "The normal map used as the source of the detail being mixed into the terrain."},
            { "Close Power", "The power of the effect at close range - based on Mix Distance."},
            { "Close Tiling", "The tiling of the effect at close range."},
            { "Close Offset", "Close effect offset."},
            { "Far Power", "The power of the effect at far range - based on Mix Distance."},
            { "Far Tiling", "The tiling of the effect at far range."},
            { "Far Offset", "Far effect offset."},
            { "Transparency", "If a color map has been supplied on the terrain, and it contains a transparency mask in the alpha (A) channel, then this will control its strength."},
            { "Albedo Size", "The size that albedo (diffuse) textures will be compressed to. Smaller sizes will reduce the visual clarity of the textures but also speed up terrain rendering."},
            { "Normal Size", "The size that normal textures will be compressed to. Smaller sizes will reduce the visual clarity of the textures but also speed up terrain rendering."},
            { "Tesselation", "Controls the amount of tesselation detail applied to the terrain. The quality of your tesselation is influenced by your height maps, so good quality heightmaps will yield better results. Tesselation should be treated like normals i.e. as a decorative thing only, as the underlying terrain collider will not also be modified."},
            { "Density", "The maximum density of the tesselation that will be applied. Big values are more expensive to render and yield minimal extra results so this is kept at around 7 or 8."},
            { "Min Distance", "The minimum distance from the camera that tesselation will be applied."},
            { "Max Distance", "The maximum distance from the camera that tesselation will be applied."},
            { "Phong Strength", "Influences tesselation artifacts. Modify to taste."},
            { "Geological Settings", "    This section controls the application of banding to simulate sedimentation in your terrain. It is lovely way to add interesting visual highlights to your environment. It's strength can be further refined for each texture."},
            { "Substance", "Procedural Substance - The contents will be extracted into the CTS Substance directory."},
            { "Albedo", "Albedo or diffuse texture. Provides the base colours of the texture."},
            { "Normal", "Normal texture. Provides additional detail that can be rendered on a texture. Must be marked as a normal on your import settings."},
            { "Height", "Height texture. Provides the height or protusion information used to drive the height blending and tesselation process."},
            { "Occlusion", "Ambient Occlusion texture. Provides information about which parts of the texture should receive indirect lighting. Used to control which areas of a texture to be darkened when in shaded environments."},
            { "Emission", "Emission texture. Projects light from the texture."},
            { "Noise", "Noise mask."},
            { "Texture Settings", "    This section allows you to control the settings of every texture in your terrain. If you want to add or remove textures, then add or remove them from your terrain first and then hit Bake Textures to see them here."},
            { "Tile Size", "The tile size of the texture up close."},
            { "Far Multiplier", "The multiplier factor applied to this texture in the distance. Use this to break up distant tiling."},
            { "Normal Power", "The power of this textures normals. Use this to make close up detail pop."},
            { "Detail Power", "The power of the global detail effect applied to this texture."},
            { "Geological Power", "The power of the geological effect applied to this texture."},
            { "Snow Power", "The power of the snow effect applied to this texture."},
            { "Tint", "The tint that will be applied to this texture."},
            { "Brightness", "The brightness that will be applied to this texture."},
            { "Splat Sharp Close", "Use this to blend or soften close heightmap textures."},
            { "Splat Sharp Far", "Use this to blend between far heightmap textures. This would typically be used to soften texture borders in the distance."},
            { "Heightmap Contrast", "Use this to increase the contrast of the supplied height map. Can be useful to help pick detail out of the heightmap."},
            { "Heightmap Depth", "Use this to increase the depth of the supplied height map. Useful when comparing two heightmaps."},
            { "Heightmap Tess Depth", "Use this to increase the height of the tesselated offset. This value should be kept fairly small and used for visual effect only in same way you use normals. It will not effect the underlying terrain collider."},
            { "Triplanar", "Apply triplanar to this texture. This is an expensive effect, and should only be applied textures that will be painted onto steep surfaces such as cliffs."},
            { "Bake Textures", "Gets all the latest textures from the terrain and the profile, bakes them up into a texture array, and applies this to the terrain. Also bakes global normals and applies them as well."},
            { "Apply Profile", "Applies this profile to all terrains that have the CTS script attached to them. Will also update the terrains textures so that they match the textures in the profile."},
            { "Snow Settings", "    This section controls the application of snow to your terrain. You can also use it to create puddles by swapping the snow texture with a water texture, and setting the Max Angle to 1."},
            { "Snow Amount", "The amount of the snow to apply."},
            { "Max Angle", "The maximum angle to apply snow to."},
            { "Angle Hardness", "The hardness of the angle to apply the snow. You can use this to soften or harden snow edges."},
            { "Minimum Height", "The minimum height in your terrain at which to apply snow."},
            { "Height Blend Range", "The height range used to blend from no snow to full snow."},
            { "Noise Power", "The strength of the snow noise mask."},
            { "Noise Tiling", "The tiling to be used for snow noise masking."},
            { "Specular", "Controls the strength of specular reflections."},
            { "Normal Blend", "The is the blend between snow normal and the background normal."},
            { "Compression Format Warning", "Note that this texture compression format is not recommended for the current target platform. This might lead to textures not rendering properly in a build. "},
            { "Compress Albedos", "Compress the albedos array. If Uncompressed this will result in large textures being sent to GPU and this may impact performance on older cards. Set to uncompressed for WebGL 2.0."},
            { "Albedo Compression Format", "Texture format for albedo compression. Please change only if required and select according to your target device. This setting can result in longer texture bake times. Default setting for Desktop is DXT5."},
            { "Compress Normals", "Compress the normals array. If Uncompressed this will result in large textures being sent to GPU and this may impact performance on older cards. Set to uncompressed for WebGL 2.0."},
            { "Normal Compression Format", "Texture format for normal compression. Please change only if required and select according to your target device. This setting can result in longer texture bake times. Default setting for Desktop is DXT5."},
            { "Strip Textures", "This option will remove all textures from the terrain at runtime, and run the terrain directly from CTS as a first pass shader. It will reduce gpu memory usage on all terrains, and drawcalls on terrains with more than 4 textures."},
            { "Draw Instanced", "This option will enable instanced rendering on the terrain this profile is applied to."},
            { "Render Queue", "Sets the render queue for the CTS shader on the terrain. Please use this only if required for your own shader development, leave the value at '-1' otherwise."},
            { "Terrain Layer Path", "Enter a custom storage path for terrain layer files created by this profile. Must start with 'Assets/'"},
            { "Terrain Layer Path Default", "Default terrain layer storage path will be used."},
            { "Terrain Layer Path MustStartWithAsset", "The terrain layer storage path must start with 'Assets/'! Default storage path will be used."},
            { "Terrain Layer Path WillBeCreated", "The terrain layer path does currently not exist, but will be created when required."},
            { "Detail Resolution Per Patch", "If you choose to Strip Textures, CTS will create a texture-less copy of the terrain data to run from. Please enter the desired 'Detail Resolution Per Patch' setting for the copy here. Normally this would be the same value you are using for your original terrain itself." },
            { "Disconnect Profile", "This will disconnect the profile from the terrain at runtime, and this will reduce memory usage, however it will also stop changes to the profile at runtime from being reflected into the terrain in real time."},
            { "Persist Materials", "This option will write a copy of the terrain material to disk for debugging. It is RECOMMENDED to leave this setting OFF."},
            { "Albedo Aniso", "Anisotropic filtering level of the albedo texture array. Anisotropic filtering makes textures look better when viewed at a shallow angle, but comes at a performance cost in the graphics hardware. Usually you use it on floor, ground or road textures to make them look better. The value range of this variable goes from 1 to 9, where 1 equals no filtering applied and 9 equals full filtering applied. As the value gets bigger, the texture is clearer at shallow angles. Lower values mean the texture will be more blurry at shallow angles."},
            { "Normal Aniso", "Anisotropic filtering level of the normals texture array. Anisotropic filtering makes textures look better when viewed at a shallow angle, but comes at a performance cost in the graphics hardware. Usually you use it on floor, ground or road textures to make them look better. The value range of this variable goes from 1 to 9, where 1 equals no filtering applied and 9 equals full filtering applied. As the value gets bigger, the texture is clearer at shallow angles. Lower values mean the texture will be more blurry at shallow angles."},
            { "Glitter", "This is the glitter texture - it controls the sparkles."},
            { "Glitter Color Power", "This is the intensity of the emmission from the snow. Bloom will be exagerated if the settings are too high."},
            { "Glitter Noise Threshhold", "This is the threshold of the glitter points. It will generate different values for alpha power of your glitter texture."},
            { "Glitter Specular Power", "The specularity of the glitter influences the glitter reflection."},
            { "Glitter Smoothness", "The smoothness of the glitter influences the glitter reflection."},
            { "Glitter Refresh Speed", "The refresh speed of the glitter as the camera moves."},
            { "Glitter Tiling", "The tiling of the glitter."},
        };
    }
}