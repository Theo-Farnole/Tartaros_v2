using System;
using System.IO;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

namespace CTS
{
    /// <summary>
    /// Editor script for Complete Terrain Shader (CTS)
    /// </summary>
    [CustomEditor(typeof(CompleteTerrainShader))]
    public class CompleteTerrainShaderEditor : Editor
    {
        private GUIStyle m_boxStyle;
        private GUIStyle m_wrapStyle;
        private GUIStyle m_wrapHelpStyle;
        //private GUIStyle m_descWrapStyle;
        private CompleteTerrainShader m_shader;
        private bool m_globalHelp = false;

        #region Menu Commands

        /// <summary>
        /// Set linear deferred lighting
        /// </summary>
        [MenuItem("Window/Procedural Worlds/CTS/Set Linear Deferred", false, 40)]
        public static void SetLinearDeferredLighting()
        {
            PlayerSettings.colorSpace = ColorSpace.Linear;

            var tier1 = EditorGraphicsSettings.GetTierSettings(EditorUserBuildSettings.selectedBuildTargetGroup, GraphicsTier.Tier1);
            tier1.renderingPath = RenderingPath.DeferredShading;
            EditorGraphicsSettings.SetTierSettings(EditorUserBuildSettings.selectedBuildTargetGroup, GraphicsTier.Tier1, tier1);

            var tier2 = EditorGraphicsSettings.GetTierSettings(EditorUserBuildSettings.selectedBuildTargetGroup, GraphicsTier.Tier2);
            tier2.renderingPath = RenderingPath.DeferredShading;
            EditorGraphicsSettings.SetTierSettings(EditorUserBuildSettings.selectedBuildTargetGroup, GraphicsTier.Tier2, tier2);

            var tier3 = EditorGraphicsSettings.GetTierSettings(EditorUserBuildSettings.selectedBuildTargetGroup, GraphicsTier.Tier3);
            tier3.renderingPath = RenderingPath.DeferredShading;
            EditorGraphicsSettings.SetTierSettings(EditorUserBuildSettings.selectedBuildTargetGroup, GraphicsTier.Tier3, tier3);
        }

        /// <summary>
        /// Add terrain shader and create materials
        /// </summary>
        [MenuItem("Window/Procedural Worlds/CTS/Add CTS To All Terrains", false, 41)]
        public static void AddCTSToTerrain(MenuCommand menuCommand)
        {
            CTSTerrainManager.Instance.AddCTSToAllTerrains();
        }

        /// <summary>
        /// Add terrain shader and create materials
        /// </summary>
        [MenuItem("Window/Procedural Worlds/CTS/Create And Apply Profile", false, 42)]
        public static void CreateCTSProfile1(MenuCommand menuCommand)
        {
            CTSProfile profile = ScriptableObject.CreateInstance<CTS.CTSProfile>();
            profile.GlobalDetailNormalMap = GetAsset("T_Detail_Normal_3.png", typeof(Texture2D)) as Texture2D;
            profile.GeoAlbedo = GetAsset("T_Geo_00.png", typeof(Texture2D)) as Texture2D;
            profile.SnowAlbedo = GetAsset("T_Ground_Snow_1_A_Sm.tga", typeof(Texture2D)) as Texture2D;
            profile.SnowNormal = GetAsset("T_Ground_Snow_1_N.tga", typeof(Texture2D)) as Texture2D;
            profile.SnowHeight = GetAsset("T_Ground_Snow_1_H.png", typeof(Texture2D)) as Texture2D;
            profile.SnowAmbientOcclusion = GetAsset("T_Ground_Snow_1_AO.tga", typeof(Texture2D)) as Texture2D;
            profile.SnowGlitter = GetAsset("T_Glitter_SM.tga", typeof(Texture2D)) as Texture2D;
            profile.m_ctsDirectory = CompleteTerrainShader.GetCTSDirectory();
            Directory.CreateDirectory(profile.m_ctsDirectory + "Profiles/");
            AssetDatabase.CreateAsset(profile, string.Format("{0}Profiles/CTS_Profile_{1:yyMMdd-HHmm}.asset", profile.m_ctsDirectory, DateTime.Now));
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            CTSTerrainManager.Instance.BroadcastProfileSelect(profile);
            EditorGUIUtility.PingObject(profile);
        }


         /// <summary>
        /// Triggers the color map baking process for all terrains
        /// </summary>
        [MenuItem("Window/Procedural Worlds/CTS/Bake Color Map on all Terrains", false, 43)]
        public static void BakeAllColorMaps(MenuCommand menuCommand)
        {
            if(EditorUtility.DisplayDialog("Bake Color Map for ALL terrains in the scene", "You are about to bake the color maps on ALL ACTIVE TERRAINS in your scene. Continue?", "Yes", "Cancel"))
            {
                EditorUtility.DisplayProgressBar("Baking Color Maps", "Preparing...", 0);
                int terrainCount = 0;
                //Check if a shader is on each terrain in the scene, if yes disconnect it if required
                foreach (var terrain in Terrain.activeTerrains)
                {
                    terrainCount++;
                    EditorUtility.DisplayProgressBar("Baking Color Maps", "Processing terrain " + terrainCount.ToString() + " of " + Terrain.activeTerrains.Length.ToString(), (float)terrainCount / (float)Terrain.activeTerrains.Length);
                    CompleteTerrainShader shader = terrain.GetComponent<CompleteTerrainShader>();
                    if (shader!=null && shader.IsProfileConnected)
                    {
                        shader.BakeTerrainBaseMap();
                    }
                }
                EditorUtility.ClearProgressBar();
            }
        }

        /// <summary>
        /// Triggers the normal map baking process for all terrains
        /// </summary>
        [MenuItem("Window/Procedural Worlds/CTS/Bake Normal Map on all Terrains", false, 43)]
        public static void BakeAllNormalMaps(MenuCommand menuCommand)
        {
            if (EditorUtility.DisplayDialog("Bake Normal Map for ALL terrains in the scene", "You are about to bake the normal maps on ALL ACTIVE TERRAINS in your scene. Continue?", "Yes", "Cancel"))
            {
                EditorUtility.DisplayProgressBar("Baking Normal Maps", "Preparing...", 0);
                int terrainCount = 0;
                //Check if a shader is on each terrain in the scene, if yes disconnect it if required
                foreach (var terrain in Terrain.activeTerrains)
                {
                    terrainCount++;
                    EditorUtility.DisplayProgressBar("Baking Normal Maps", "Processing terrain " + terrainCount.ToString() + " of " + Terrain.activeTerrains.Length.ToString(), (float)terrainCount / (float)Terrain.activeTerrains.Length);
                    CompleteTerrainShader shader = terrain.GetComponent<CompleteTerrainShader>();
                    if (shader != null && shader.IsProfileConnected)
                    {
                        shader.BakeTerrainNormals();
                    }
                }
                EditorUtility.ClearProgressBar();
            }
        }


        /// <summary>
        /// Strip textures and CTS profile from the terrain. Only the current CTS Material will remain on the terrain for optimal build size / performance
        /// </summary>
        [MenuItem("Window/Procedural Worlds/CTS/Disconnect ALL terrains", false, 60)]
        public static void DisconnectProfilesForBuild(MenuCommand menuCommand)
        {
            if(EditorUtility.DisplayDialog("Disconnect ALL terrains in the scene", "You are about to remove all texture prototypes and CTS profiles from ALL ACTIVE TERRAINS in your scene. The terrains will still be rendered by CTS, but it won't be possible to change the CTS profile during runtime anymore. This puts CTS in a 'minimal state' for a build where it uses as little resources as possible. You can later revert this process again, but since your original terrain data will be modified during this operation, it is recommended to back up your project before.Continue?", "Yes", "Cancel"))
            {
                EditorUtility.DisplayProgressBar("Disconnecting profiles", "Preparing...", 0);
                int terrainCount = 0;
                //Check if a shader is on each terrain in the scene, if yes disconnect it if required
                foreach (var terrain in Terrain.activeTerrains)
                {
                    terrainCount++;
                    EditorUtility.DisplayProgressBar("Disconnecting profiles", "Processing terrain " + terrainCount.ToString() + " of " + Terrain.activeTerrains.Length.ToString(), (float)terrainCount / (float)Terrain.activeTerrains.Length);
                    CompleteTerrainShader shader = terrain.GetComponent<CompleteTerrainShader>();
                    if (shader!=null && shader.IsProfileConnected)
                    {
                        DisconnectProfile(shader);
                    }
                }
                EditorUtility.ClearProgressBar();
            }
        }
        
        /// <summary>
        /// Undos the build optimizations and reattaches the CTS red profile to the terrain
        /// </summary>
        [MenuItem("Window/Procedural Worlds/CTS/Reconnect ALL terrains", false, 61)]
        public static void ReconnectProfilesAfterBuild(MenuCommand menuCommand)
        {
            //Ask the user for permission
            if (EditorUtility.DisplayDialog("Reconnect ALL terrains in the scene", "You are about to restore texture prototypes and CTS profiles for ALL ACTIVE TERRAINS in your scene. The terrains will get the last used CTS profile re-applied. Since your original terrain data will be modified during this operation, it is recommended to back up your project before. Continue?", "Yes", "Cancel"))
            {
                EditorUtility.DisplayProgressBar("Connecting profiles", "Preparing...", 0);
                int terrainCount = 0;
                //Check if a shader is on each terrain in the scene, if yes reconnect it if required
                foreach (var terrain in Terrain.activeTerrains)
                {
                    terrainCount++;
                    EditorUtility.DisplayProgressBar("Connecting profiles", "Processing terrain " + terrainCount.ToString() + " of " + Terrain.activeTerrains.Length.ToString(), (float)terrainCount / (float)Terrain.activeTerrains.Length);
                    CompleteTerrainShader shader = terrain.GetComponent<CompleteTerrainShader>();
                    if (shader == null)
                    {
                        //No CTS on this terrain > skip
                        continue;
                    }

                    //all good, let's reconnect the profile if required
                    if (!shader.IsProfileConnected)
                    {
                        ReconnectProfile(shader);
                    }
                }
                EditorUtility.ClearProgressBar();
            }
        }

        /// <summary>
        /// Add CTS runtime controller to the scene
        /// </summary>
        [MenuItem("Window/Procedural Worlds/CTS/Add Weather Manager", false, 80)]
        public static void AddCTSRuntimeWeatherToScene(MenuCommand menuCommand)
        {
            //Add a weather manager
            GameObject ctsWeatherManager = GameObject.Find("CTS Weather Manager");
            if (ctsWeatherManager == null)
            {
                ctsWeatherManager = new GameObject();
                ctsWeatherManager.name = "CTS Weather Manager";
                ctsWeatherManager.AddComponent<CTSWeatherManager>();
                CompleteTerrainShader.SetDirty(ctsWeatherManager, false, false);
            }
            EditorGUIUtility.PingObject(ctsWeatherManager);

            //And now add weather controllers
            foreach (var terrain in Terrain.activeTerrains)
            {
                CompleteTerrainShader shader = terrain.gameObject.GetComponent<CompleteTerrainShader>();
                if (shader != null)
                {
                    CTSWeatherController controller = terrain.gameObject.GetComponent<CTSWeatherController>();
                    if (controller == null)
                    {
                        controller = terrain.gameObject.AddComponent<CTSWeatherController>();
                        CompleteTerrainShader.SetDirty(terrain, false, false);
                        CompleteTerrainShader.SetDirty(controller, false, false);
                    }
                }
            }
        }

        /// <summary>
        /// Add world API to scene
        /// </summary>
        [MenuItem("Window/Procedural Worlds/CTS/Add World API Integration", false, 81)]
        public static void AddWorldAPIToScene(MenuCommand menuCommand)
        {
            //First - are we even here present
            Type worldAPIType = CompleteTerrainShader.GetType("WAPI.WorldManager");
            if (worldAPIType == null)
            {
                EditorUtility.DisplayDialog("World Manager API", "World Manager is not present in your project. Please go to http://www.procedural-worlds.com/blog/wapi/ to learn about it.", "OK");
                Application.OpenURL("http://www.procedural-worlds.com/blog/wapi/");
                Application.OpenURL("https://github.com/adamgoodrich/WorldManager");
                return;
            }

            //First add a weather manager
            GameObject ctsWeatherManager = GameObject.Find("CTS Weather Manager");
            if (ctsWeatherManager == null)
            {
                ctsWeatherManager = new GameObject();
                ctsWeatherManager.name = "CTS Weather Manager";
                ctsWeatherManager.AddComponent<CTSWeatherManager>();
                CompleteTerrainShader.SetDirty(ctsWeatherManager, false, false);
            }
            EditorGUIUtility.PingObject(ctsWeatherManager);

            //And now add weather controllers
            foreach (var terrain in Terrain.activeTerrains)
            {
                CompleteTerrainShader shader = terrain.gameObject.GetComponent<CompleteTerrainShader>();
                if (shader != null)
                {
                    CTSWeatherController controller = terrain.gameObject.GetComponent<CTSWeatherController>();
                    if (controller == null)
                    {
                        controller = terrain.gameObject.AddComponent<CTSWeatherController>();
                        CompleteTerrainShader.SetDirty(terrain, false, false);
                        CompleteTerrainShader.SetDirty(controller, false, false);
                    }
                }
            }

            //And now add world API integration component to weather manager
#if WORLDAPI_PRESENT
            var worldAPIIntegration = ctsWeatherManager.GetComponent<CTSWorldAPIIntegration>();
            if (worldAPIIntegration == null)
            {
                worldAPIIntegration = ctsWeatherManager.AddComponent<CTSWorldAPIIntegration>();
            }
#endif
        }

#region Replaced by commons

        /*/// <summary>
        /// Show documentation
        /// </summary>
        [MenuItem("Window/CTS/Show Documentation...", false, 60)]
        public static void ShowDocumentation()
        {
            Application.OpenURL("http://www.procedural-worlds.com/cts/?section=documentation");
        }

        /// <summary>
        /// Show the forum
        /// </summary>
        [MenuItem("Window/CTS/Show Forum...", false, 61)]
        public static void ShowForum()
        {
            Application.OpenURL(
                "https://forum.unity3d.com/threads/cts-complete-terrain-shader.477615/");
        }

        /// <summary>
        /// Show tutorial
        /// </summary>
        [MenuItem("Window/CTS/Show Tutorials...", false, 62)]
        public static void ShowTutorial()
        {
            Application.OpenURL("http://www.procedural-worlds.com/cts/?section=tutorials");
        }

        /// <summary>
        /// Show review option
        /// </summary>
        [MenuItem("Window/CTS/Please Review CTS...", false, 63)]
        public static void ShowAssetStore()
        {
            if (UnityEngine.Random.Range(0,2) == 0)
            {
                Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/91938?aid=1011lGkb");
            }
            else
            {
                Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/91938?aid=1101lSqC");
            }
        }*/

#endregion

        /// <summary>
        /// Show review option
        /// </summary>
        [MenuItem("Window/Procedural Worlds/CTS/About/Nature Manufacture...", false, 120)]
        public static void ShowNatureManufacture()
        {
            Application.OpenURL("https://www.assetstore.unity3d.com/en/#!/search/page=1/sortby=popularity/query=publisher:6887?aid=1011lGkb");
        }

        /// <summary>
        /// Show review option
        /// </summary>
        [MenuItem("Window/Procedural Worlds/CTS/About/Procedural Worlds...", false, 121)]
        public static void ShowProcWorlds()
        {
            Application.OpenURL("https://www.assetstore.unity3d.com/en/#!/search/page=1/sortby=popularity/query=publisher:15277?aid=1101lSqC");
        }

#endregion

        /// <summary>
        /// Called when we select this in the scene
        /// </summary>
        void OnEnable()
        {
            //Check for target
            if (target == null)
            {
                return;
            }

            //Setup target
            m_shader = (CompleteTerrainShader) target;
        }

        /// <summary>
        /// Editor UX
        /// </summary>
        public override void OnInspectorGUI()
        {
            //Set the target
            m_shader = (CompleteTerrainShader) target;

            if (m_shader == null)
            {
                return;
            }

            if (m_shader.Profile!=null && m_shader.Profile.m_currentRenderPipelineType != CompleteTerrainShader.GetRenderPipeline())
            {
                Debug.Log("CTS detected a rendering pipeline change, updating shader.");
                CTSTerrainManager.Instance.BroadcastProfileUpdate(m_shader.Profile);
            }


#region Setup and introduction

            //Set up the box style
            if (m_boxStyle == null)
            {
                m_boxStyle = new GUIStyle(GUI.skin.box);
                m_boxStyle.normal.textColor = GUI.skin.label.normal.textColor;
                m_boxStyle.fontStyle = FontStyle.Bold;
                m_boxStyle.alignment = TextAnchor.UpperLeft;
            }

            //Setup the wrap style
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

            //Monitor for changes - but only if profile is connected
            if (m_shader.IsProfileConnected)
            {
                EditorGUI.BeginChangeCheck();
            }
            

            GUILayout.Space(5);

            GUILayout.BeginVertical(m_boxStyle);

            CTSProfile profile = m_shader.Profile;
            Texture2D globalNormal = m_shader.NormalMap;
            bool autobakeNormalMap = m_shader.AutoBakeNormalMap;
            Texture2D globalColorMap = m_shader.ColorMap;
            bool autobakeColorMap = m_shader.AutoBakeColorMap;
            bool autoBakeGrassIntoColorMap = m_shader.AutoBakeGrassIntoColorMap;
            float autoBakeGrassMixStrength = m_shader.AutoBakeGrassMixStrength;
            float autoBakeGrassDarkenAmount = m_shader.AutoBakeGrassDarkenAmount;
            bool useCutout = m_shader.UseCutout;
            Texture2D globalCutoutMask = m_shader.CutoutMask;
            float heightCutout = m_shader.CutoutHeight;

            if (m_shader.IsProfileConnected)
            {

                profile = (CTSProfile)EditorGUILayout.ObjectField(GetLabel("Profile"), m_shader.Profile, typeof(CTSProfile), false);
                DrawHelpLabel("Profile");


                if (GUILayout.Button(GetLabel("Disconnect Profile")))
                {
                    if (EditorUtility.DisplayDialog("Disconnect for Build", "You are about to remove all texture prototypes and the CTS profile from this terrain. The terrain will still be rendered by CTS, but it won't be possible to change the CTS profile during runtime anymore. You can later revert this process again, but since your original terrain data will be modified during this operation, it is recommended to back up your project before. Continue?", "Yes", "Cancel"))
                    {
                        //early end of the change check - required to prevent errors from unity
                        EditorGUI.EndChangeCheck();
                        DisconnectProfile(m_shader);
                    }
                }
            }
            else
            {
                //Try to load last used profile to display the name

                var lastProfile = AssetDatabase.LoadAssetAtPath<CTSProfile>(AssetDatabase.GUIDToAssetPath(m_shader.LastUsedCTSProfileID));

                if (lastProfile != null)
                {
                    EditorGUILayout.LabelField(string.Format("Last used CTS Profile: {0}", lastProfile.name));
                    if (GUILayout.Button(GetLabel("Connect Profile")))
                    {
                        if (EditorUtility.DisplayDialog("Reconnect profile", "You are about to connect the last attached profile to this terrain. This will add back all texture prototypes and the CTS profile as well as restore the splatmaps in the terrain data. Since your original terrain data will be modified during this operation, it is recommended to back up your project before. Continue?", "Yes", "Cancel"))
                        {
                            ReconnectProfile(m_shader);
                            //early start of the change check - required to prevent errors from unity
                            EditorGUI.BeginChangeCheck();
                        }
                    }
                }
                else
                {
                    EditorGUILayout.HelpBox("Could not load last used Profile! The profile cannot be reconnected automatically for this terrain anymore!", MessageType.Error, true);
                }
            }       


               

            DrawHelpLabel("DisconnectProfile");


            


            if (m_shader.IsProfileConnected)
            {
                EditorGUILayout.LabelField(GetLabel("Terrain NormalMap"));
                DrawHelpLabel("Terrain NormalMap");
                EditorGUI.indentLevel++;

                autobakeNormalMap = EditorGUILayout.Toggle(GetLabel("Auto Bake"), m_shader.AutoBakeNormalMap);
                DrawHelpLabel("Auto Bake");

                globalNormal = (Texture2D)EditorGUILayout.ObjectField(GetLabel("Normal Map"), m_shader.NormalMap, typeof(Texture2D), false, GUILayout.Height(16f));
                DrawHelpLabel("Normal Map");

                EditorGUI.indentLevel--;

                EditorGUILayout.LabelField(GetLabel("Terrain ColorMap"));
                DrawHelpLabel("Terrain ColorMap");
                EditorGUI.indentLevel++;

                autobakeColorMap = EditorGUILayout.Toggle(GetLabel("Auto Bake"), m_shader.AutoBakeColorMap);
                DrawHelpLabel("Auto Bake");
                autoBakeGrassIntoColorMap = m_shader.AutoBakeGrassIntoColorMap;
                autoBakeGrassMixStrength = m_shader.AutoBakeGrassMixStrength;
                autoBakeGrassDarkenAmount = m_shader.AutoBakeGrassDarkenAmount;
                autoBakeGrassIntoColorMap = EditorGUILayout.Toggle(GetLabel("Bake Grass"), autoBakeGrassIntoColorMap);
                DrawHelpLabel("Bake Grass");
                if (autoBakeGrassIntoColorMap)
                {
                    EditorGUI.indentLevel++;
                    autoBakeGrassMixStrength = EditorGUILayout.Slider(GetLabel("Grass Strength"), autoBakeGrassMixStrength, 0f, 1f);
                    DrawHelpLabel("Grass Strength");
                    autoBakeGrassDarkenAmount = EditorGUILayout.Slider(GetLabel("Darken Strength"), autoBakeGrassDarkenAmount, 0f, 1f);
                    DrawHelpLabel("Darken Strength");
                    EditorGUI.indentLevel--;
                }
                //float globalColorMapOpacity = EditorGUILayout.Slider(GetLabel("Strength"), m_shader.m_)
                globalColorMap = (Texture2D)EditorGUILayout.ObjectField(GetLabel("Color Map"), m_shader.ColorMap, typeof(Texture2D), false, GUILayout.Height(16f));
                DrawHelpLabel("Color Map");

                EditorGUI.indentLevel--;

                useCutout = EditorGUILayout.Toggle(GetLabel("Use Cutout"), m_shader.UseCutout);
                DrawHelpLabel("Use Cutout");
                heightCutout = m_shader.CutoutHeight;
                globalCutoutMask = m_shader.CutoutMask;
                if (useCutout)
                {
                    EditorGUI.indentLevel++;
                    heightCutout = EditorGUILayout.FloatField(GetLabel("Cutout Below"), heightCutout);
                    DrawHelpLabel("Cutout Below");
                    globalCutoutMask = (Texture2D)EditorGUILayout.ObjectField(GetLabel("Cutout Mask"), globalCutoutMask, typeof(Texture2D), false, GUILayout.Height(16f));
                    DrawHelpLabel("Cutout Mask");
                    EditorGUI.indentLevel--;
                }

                GUILayout.BeginHorizontal();
                if (GUILayout.Button(GetLabel("Bake NormalMap")))
                {
                    m_shader.BakeTerrainNormals();
                    globalNormal = m_shader.NormalMap;
                }
                if (GUILayout.Button(GetLabel("Bake ColorMap")))
                {
                    if (!autoBakeGrassIntoColorMap)
                    {
                        m_shader.BakeTerrainBaseMap();
                    }
                    else
                    {
                        m_shader.BakeTerrainBaseMapWithGrass();
                    }
                    globalColorMap = m_shader.ColorMap;
                }
                GUILayout.EndHorizontal();

            } //is Profile Connected

            GUILayout.EndVertical();

            GUILayout.Space(5);

#region Handle changes

            //Only check for changes while profile is connected
            if (m_shader.IsProfileConnected)
            {
                //Check for changes, make undo record, make changes and let editor know we are dirty
                if (EditorGUI.EndChangeCheck())
                {
                    CompleteTerrainShader.SetDirty(m_shader, false, false);
                    if (profile != null)
                    {
                        profile.terrainLayerAssetRebuild = true;
                    }
                    m_shader.Profile = profile;
                    m_shader.NormalMap = globalNormal;
                    m_shader.AutoBakeNormalMap = autobakeNormalMap;
                    m_shader.ColorMap = globalColorMap;
                    m_shader.AutoBakeColorMap = autobakeColorMap;
                    m_shader.AutoBakeGrassIntoColorMap = autoBakeGrassIntoColorMap;
                    m_shader.AutoBakeGrassMixStrength = autoBakeGrassMixStrength;
                    m_shader.AutoBakeGrassDarkenAmount = autoBakeGrassDarkenAmount;
                    //If the cutout mode changed, mark the material for reapply
                    if (m_shader.UseCutout != useCutout || m_shader.CutoutMask != globalCutoutMask)
                    {
                        m_shader.MaterialNeedsReapply = true;
                    }
                    m_shader.UseCutout = useCutout;
                    m_shader.CutoutMask = globalCutoutMask;
                    m_shader.CutoutHeight = heightCutout;
                    m_shader.ApplyMaterialAndUpdateShader();
                }
            }
#endregion
        }


        /// <summary>
        /// Disconnects the CTS profile from this terrain for build optimization.
        /// Removes the original terrain splatmap prototypes / layers from the terrain. Creates a persistent material with exported splatmaps so CTS can be run with minimal memory / performance impact.
        /// </summary>
        /// <param name="shader">The shader object to perform the disconnect for. Needs to be on a terrain as a component and must have a profile connected.</param>
        private static void DisconnectProfile(CompleteTerrainShader shader)
        {
            //Early tests and exits
            Terrain terrain = shader.GetComponent<Terrain>();
            if (terrain == null)
            {
                Debug.LogError("Trying to disconnect a CTS profile from a shader instance that is not attached to a terrain.");
                return;
            }

            if (terrain.terrainData == null)
            {
                Debug.LogError("Trying to disconnect a CTS profile from a shader instance without a valid terrain data object.");
                return;
            }

            if (!shader.IsProfileConnected)
            {
                Debug.LogWarning(String.Format("Trying to disconnect a CTS profile from a shader instance that is already disconnected. Please check the state of the CTS component on terrain '{0}'", terrain.name));
                return;
            }

            if (shader.Profile == null)
            {
                Debug.LogError("Trying to disconnect a CTS profile from a shader instance, but the profile is null.");
                return;
            }

            string CTSProfileGUID = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(shader.Profile));

            if (CTSProfileGUID == null || CTSProfileGUID == "")
            {
                Debug.LogError(String.Format("Could not Disconnect Profile: Not able to determine Asset GUID for CTS Profile: {0}", shader.Profile.name));
                return;
            }

            string terrainDataGUID = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(terrain.terrainData));

            if (terrainDataGUID == null || terrainDataGUID == "")
            {
                Debug.LogError(String.Format("Could not Disconnect Profile: Not able to determine Asset GUID for Terrain Data object: {0}" , terrain.terrainData.name));
                return;
            }


            //make a persistent material
            Material persistentMat = new Material(terrain.materialTemplate.shader);

            //Create a material directory if it does not exist.
            string ctsDirectory = CompleteTerrainShader.GetCTSDirectory();
            string materialDirectory = ctsDirectory + "Profiles/Materials";
            Directory.CreateDirectory(materialDirectory);

            //Save the material as permanent asset
            AssetDatabase.CreateAsset(persistentMat, materialDirectory + String.Format("/Material_{0}_{1}.mat", CTSProfileGUID, terrainDataGUID));

            //Copy all properties from the existing CTS material
            persistentMat.CopyPropertiesFromMaterial(terrain.materialTemplate);

            //Create a directory to store the splatmaps if it does not exist
            string splatmapDirectory = ctsDirectory + "Profiles/Splatmaps";
            Directory.CreateDirectory(splatmapDirectory);

            //The CompressToMultiChannelFileImage function below takes care of creating the full filename
            //including an incrementing number from 0 to 4 for multiple splatmaps.
            string splatFileNameTemplate = splatmapDirectory + String.Format("/Splat_{0}_{1}_", CTSProfileGUID, terrainDataGUID);

            //Save away the splatmaps, those will be gone later due to removal of the splat prototypes
            float[,,] splatMaps = terrain.terrainData.GetAlphamaps(0, 0, terrain.terrainData.alphamapResolution, terrain.terrainData.alphamapResolution);
            CTSEditorUtils.CompressToMultiChannelFileImage(splatMaps, splatFileNameTemplate, TextureFormat.RGBA32, true, false);
            AssetDatabase.Refresh();
            //Now look up all written splatmaps (up to 4 for 16 textures) and assign those to the material

            for (int i = 0; i < 4; i++)
            {
                string fullSplatFilename = splatFileNameTemplate + i.ToString() + ".png";
                
                if (File.Exists(fullSplatFilename))
                {
                    //Reimport as non-color texture, else the splatmap files will display slightly different on the terrain than the splatmaps stored in terrain data
                    var importer = AssetImporter.GetAtPath(fullSplatFilename) as TextureImporter;
                    if (importer != null)
                    {
                        importer.sRGBTexture = false;
                        importer.wrapMode = TextureWrapMode.Clamp;
                        importer.textureCompression = TextureImporterCompression.Uncompressed;
                        AssetDatabase.ImportAsset(fullSplatFilename, ImportAssetOptions.ForceUpdate);
                        AssetDatabase.Refresh();
                    }

                    Texture tex = AssetDatabase.LoadAssetAtPath<Texture>(fullSplatFilename);
                    switch (i)
                    {
                        case 0:
                            persistentMat.SetTexture(CTSShaderID.Texture_Splat_1, tex);
                            shader.PersistentSplatGUID1 = fullSplatFilename;
                            break;
                        case 1:
                            persistentMat.SetTexture(CTSShaderID.Texture_Splat_2, tex);
                            shader.PersistentSplatGUID2 = fullSplatFilename;
                            break;
                        case 2:
                            persistentMat.SetTexture(CTSShaderID.Texture_Splat_3, tex);
                            shader.PersistentSplatGUID3 = fullSplatFilename;
                            break;
                        case 3:
                            persistentMat.SetTexture(CTSShaderID.Texture_Splat_4, tex);
                            shader.PersistentSplatGUID4 = fullSplatFilename;
                            break;
                        default:
                            //should never happen - do nothing
                            break;
                    }

                }

            }

            //Material is done, assign it
            terrain.materialTemplate = persistentMat;

            //Remove all terrain layers / splat prototypes
#if UNITY_2018_3_OR_NEWER
            terrain.terrainData.terrainLayers = new TerrainLayer[0];
#else
            terrain.terrainData.splatPrototypes = new SplatPrototype[0];
#endif
            //remove profile reference and texture map / mask references in shader
            //store asset guids for these files instead so we can restore those if required
            if (shader.NormalMap != null)
            {
                shader.PersistentNormalMapGUID = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(shader.NormalMap));
                shader.NormalMap = null;
            }
            if (shader.ColorMap != null)
            {
                shader.PersistentColorMapGUID = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(shader.ColorMap));
                shader.ColorMap = null;
            }
            if (shader.CutoutMask != null)
            {
                shader.PersistentCutoutMaskGUID = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(shader.CutoutMask));
                shader.CutoutMask = null;
            }
          
            shader.Profile = null;

            //all done, mark profile removal in shader
            shader.LastUsedCTSProfileID = CTSProfileGUID;
            shader.IsProfileConnected = false;
            EditorUtility.SetDirty(shader);

        }


        /// <summary>
        /// Connects the CTS profile from this terrain again after it has been removed by DisconnectProfile before.
        /// Applies the last used profile and in turn restores the original terrain splatmap prototypes / layers on the terrain. 
        /// </summary>
        /// <param name="shader">The shader object to perform the reconnect for. Needs to be on a terrain as a component and must have a profile ID stored.</param>
        private static void ReconnectProfile(CompleteTerrainShader shader)
        {
            //Early checks and returns
            if (shader == null)
            {
                Debug.LogError("Trying to reconnect CTS profile for a shader object that is NULL.");
                return;
            }

            if (shader.LastUsedCTSProfileID == null || shader.LastUsedCTSProfileID == "")
            {
                Debug.LogError("Trying to reconnect a CTS Profile on a shader, but there is no Profile ID stored.");
                return;
            }

            Terrain terrain = shader.GetComponent<Terrain>();

            if (terrain == null)
            {
                Debug.LogError("Trying to reconnect CTS profile for a shader that is not attached to a terrain as a component.");
                return;
            }

            if (terrain.terrainData == null)
            {
                Debug.LogError("Trying to reconnect a CTS profile for a shader instance without a valid terrain data object.");
                return;
            }

            //try to load the profile
            var profile = AssetDatabase.LoadAssetAtPath<CTSProfile>(AssetDatabase.GUIDToAssetPath(shader.LastUsedCTSProfileID));

            if (profile == null)
            {
                Debug.LogError("Trying to reconnect a CTS Profile on a shader, could not load CTS profile by asset GUID.");
                return;
            }

            string terrainDataGUID = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(terrain.terrainData));

            if (terrainDataGUID == null || terrainDataGUID == "")
            {
                Debug.LogError(String.Format("Could not Reconnect Profile: Not able to determine Asset GUID for Terrain Data object: {0}", terrain.terrainData.name));
                return;
            }


            //all good, restore some shader settings from the current terrain material before reapplying the CTS profile

            Material currentTerrainMat = terrain.materialTemplate;

            if(shader.PersistentNormalMapGUID!=null && shader.PersistentNormalMapGUID != "")
                shader.NormalMap = AssetDatabase.LoadAssetAtPath<Texture2D>(AssetDatabase.GUIDToAssetPath(shader.PersistentNormalMapGUID));
            if (shader.PersistentColorMapGUID != null && shader.PersistentColorMapGUID != "")
                shader.ColorMap = AssetDatabase.LoadAssetAtPath<Texture2D>(AssetDatabase.GUIDToAssetPath(shader.PersistentColorMapGUID));
            if (shader.PersistentCutoutMaskGUID != null && shader.PersistentCutoutMaskGUID != "")
                shader.CutoutMask = AssetDatabase.LoadAssetAtPath<Texture2D>(AssetDatabase.GUIDToAssetPath(shader.PersistentCutoutMaskGUID));

            //Make sure the material is changed back to the CTS on-the-fly material
            shader.MaterialNeedsReapply = true;

            CTSTerrainManager.Instance.BroadcastProfileSelect(profile, terrain);
            //final step: restore the splatmaps in the terrain data object

            string ctsDirectory = CompleteTerrainShader.GetCTSDirectory();
            string splatmapDirectory = ctsDirectory + "Profiles/Splatmaps";
            string splatFileNameTemplate = splatmapDirectory + String.Format("/Splat_{0}_{1}_", shader.LastUsedCTSProfileID, terrainDataGUID);

            float[,,] map = new float[terrain.terrainData.alphamapWidth, terrain.terrainData.alphamapHeight, terrain.terrainData.alphamapLayers];
            int mapIndex=0;

            for (int i = 0; i < 4; i++)
            {
                //Continue reading in textures as long as we have not processed all layers yet
                if (mapIndex < terrain.terrainData.alphamapLayers)
                {
                    string fullSplatFilename = splatFileNameTemplate + i.ToString() + ".png";
                    var tex = new Texture2D(2, 2);
                    if (File.Exists(fullSplatFilename))
                    {
                        var fileData = File.ReadAllBytes(fullSplatFilename);
                        tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.

                        //Start reading the individual channels of the file and put them into the map at the right index
                        for (int j = 0; j < 4; j++)
                        {
                            //Continue reading in color channels from that texture as long as we have not processed all layers yet
                            if (mapIndex < terrain.terrainData.alphamapLayers)
                            {
                                switch (j)
                                {
                                    case 0:
                                        AddTexture2DChanneltoMapData(mapIndex, map, tex, CTSConstants.TextureChannel.R);
                                        mapIndex++;
                                        break;
                                    case 1:
                                        AddTexture2DChanneltoMapData(mapIndex, map, tex, CTSConstants.TextureChannel.G);
                                        mapIndex++;
                                        break;
                                    case 2:
                                        AddTexture2DChanneltoMapData(mapIndex, map, tex, CTSConstants.TextureChannel.B);
                                        mapIndex++;
                                        break;
                                    case 3:
                                        AddTexture2DChanneltoMapData(mapIndex, map, tex, CTSConstants.TextureChannel.A);
                                        mapIndex++;
                                        break;

                                }
                            }
                            else break;
                        }
                    }
                }
                else break;
            }

            terrain.terrainData.SetAlphamaps(0, 0, map);

        }

        /// <summary>
        /// adds a texture 2D to 
        /// </summary>
        /// <param name="mapIndex"></param>
        /// <param name="map"></param>
        /// <param name="inputTexture"></param>
        private static void AddTexture2DChanneltoMapData(int mapIndex, float[,,] map, Texture2D inputTexture, CTSConstants.TextureChannel channel)
        {
            for (int y = 0; y <map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    //create a new Color for the target image by copying only the desired value over in the rgb-channels.

                    //!!! Note !!! the y-x switch below is intentional, GetPixel(x,y) will result in a flipped result
                    switch (channel)
                    {
                        case CTSConstants.TextureChannel.R:
                            map[x,y,mapIndex] = inputTexture.GetPixel(y, x).r;
                            break;
                        case CTSConstants.TextureChannel.G:
                            map[x, y, mapIndex] = inputTexture.GetPixel(y, x).g;
                            break;
                        case CTSConstants.TextureChannel.B:
                            map[x, y, mapIndex] = inputTexture.GetPixel(y, x).b;
                            break;
                        case CTSConstants.TextureChannel.A:
                            map[x, y, mapIndex] = inputTexture.GetPixel(y, x).a;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Returns the first asset that matches the file path and name passed. Will try
        /// full path first, then will try just the file name.
        /// </summary>
        /// <param name="fileNameOrPath">File name as standalone or fully pathed</param>
        /// <returns>Object or null if it was not found</returns>
        public static UnityEngine.Object GetAsset(string fileNameOrPath, Type assetType)
        {
            if (!string.IsNullOrEmpty(fileNameOrPath))
            {
                UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath(fileNameOrPath, assetType);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    string path = GetAssetPath(Path.GetFileName(fileNameOrPath));
                    if (!string.IsNullOrEmpty(path))
                    {
                        return AssetDatabase.LoadAssetAtPath(path, assetType);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Get the asset path of the first thing that matches the name
        /// </summary>
        /// <param name="fileName">File name to search for</param>
        /// <returns></returns>
        public static string GetAssetPath(string fileName)
        {
            string fName = Path.GetFileNameWithoutExtension(fileName);
            string[] assets = AssetDatabase.FindAssets(fName, null);
            for (int idx = 0; idx < assets.Length; idx++)
            {
                string path = AssetDatabase.GUIDToAssetPath(assets[idx]);
                if (Path.GetFileName(path) == fileName)
                {
                    return path;
                }
            }
            return "";
        }

        /// <summary>
        /// Get a content label - look the tooltip up if possible
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        GUIContent GetLabel(string name)
        {
            string tooltip = "";
            if (m_tooltips.TryGetValue(name, out tooltip))
            {
                return new GUIContent(name, tooltip);
            }
            else
            {
                return new GUIContent(name);
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
        /// The tooltips
        /// </summary>
        static Dictionary<string, string> m_tooltips = new Dictionary<string, string>
        {
            { "Overview", "    CTS is a terrain shading system driven by profiles. To use CTS, first add CTS to the terrain by selecting Component-> CTS-> Add CTS To Terrain. Then create and apply a new profile by selecting Window -> Procedural Worlds -> CTS-> Create And Apply Profile, or by dragging an existing profile into the profile slot, or by hitting Apply Profile on an existing profile.\n\n    To see the latest documentation and video tutorials please click on the button below."},
            { "Mode", "The mode this terrain is in.\n<b>Design Mode</b> - Changes are made via the currently selected profile.\n<b>Runtime Mode</b> - The profile is disconnected from the terrain to reduce runtime memory overhead."},
            { "Profile", "Drop your CTS profile here. Alternatively select a profile and then click Apply Profile. Or to create and apply a new apply a new profile select Window -> Procedural Worlds -> CTS-> Create And Apply Profile."},
            { "DisconnectProfile", "Disconnecting your profile will create a persistent material and removes all unneccesary references to textures and splatmaps from the terrain. This can be done to create an optimized version of the terrain for a build. Please see the readme file for more information." },
            { "Auto Bake", "Automatically create this map when the Bake Terrains button is clicked on the profile."},
            { "Terrain NormalMap", "Normal Map for this terrain tile. It is used to highlight distant terrain features. Strength of application is controlled via Global Normal Power setting in the profile."},
            { "Normal Map", "Normal Map for this terrain tile."},
            { "Terrain ColorMap", "Color Map for this terrain tile. Use this to blend additional color detail into the terrain to add interest. Strength of application is controlled via ColorMap Settings in the profile. NOTE: The alpha channel of your color map can be used to store a mask to control where the color map will be drawn."},
            { "Color Map", "Color Map for this terrain tile. The alpha (A) channel of this texture can optionally store a transparency mask so that you can mask out areas in which you do not want to draw your color map. The transarency strength is controlled via your profile settings."},
            { "Bake Grass", "Bake the dominant grass color into the color map that is generated to add additional interest to the color maps."},
            { "Grass Strength", "How strongly the grass should be baked into the underlying color map."},
            { "Darken Strength", "How strongly the baked grass should darkened when baked into the underlying color map."},
            { "Use Cutout", "Enable or disable the use of cutouts. NOTE: Cutouts are more expensive to render, so use only when needed."},
            { "Cutout Below", "Cut out the drawing of all terrain below this height."},
            { "Cutout Mask", "Mask where the terrain cutout will be drawn. The cutout mask is taken from the alpha (A) channel of this texture."},
        };
    }
}