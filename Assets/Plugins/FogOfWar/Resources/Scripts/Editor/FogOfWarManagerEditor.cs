using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.AnimatedValues;
using UnityEditor.SceneManagement;

[CanEditMultipleObjects]
[CustomEditor(typeof(FogOfWarManager))]
public class FogOfWarManagerEditor : Editor
{
    SerializedProperty StartEndHeight;
    SerializedProperty RevealOpacities;
    SerializedProperty BlurFog;
    SerializedProperty UpSample;
    SerializedProperty ShowBlocker;
    SerializedProperty RevealSpeed;
    SerializedProperty CoverSpeed;
    SerializedProperty ResitenceMapPath;
    SerializedProperty FogFilterMode;
    SerializedProperty ResistenceMapPrefab;
#if !UNITY_WEBGL
    SerializedProperty UseThreading;
#endif
    SerializedProperty FogNoise;
    SerializedProperty RevealedOpacity;
    SerializedProperty CoveredOpacity;
    SerializedProperty UndiscoveredOpacity;
    SerializedProperty DebugMode;
    SerializedProperty ModPrefab;
    SerializedProperty Origin;
    SerializedProperty AutomaticMode;
    SerializedProperty UpdatesPerSecond;
    SerializedProperty FogColor;
    SerializedProperty AnimatedFogSpeed;
    SerializedProperty AnimatedFogIntensity;
    SerializedProperty AnimatedFogTiling;

#pragma warning disable 414
    SerializedProperty PreviewModPrefab;
    SerializedProperty placeMode;
    SerializedProperty FogGO;
    SerializedProperty PlacementID;
    SerializedProperty ChangeHeight;
    SerializedProperty SaveReminder;
    SerializedProperty ScalePatchModifier;
    SerializedProperty PatchScale;
#pragma warning restore 414

    private FogOfWarManager fogOfWarManager;

    private Texture ResistenceMap;
    private Texture FogMap;
    private Material DebugMatR;
    private Material DebugMatG;
    //private Material DebugMatB;
    private Material DebugMatA;
    private bool DisplayTexA = false;
    private bool DisplayTexB = false;
    private bool DisplayTexC = false;
    private bool DisplayTexD = true;
    private float TexSize;
    private int DisplayFactionFog = 0;
    private int GrassID = 0;

    void OnEnable()
    {
        if (fogOfWarManager != null)
        {
            if (fogOfWarManager.ShowPreview == null)
            {
                fogOfWarManager.ShowPreview = new AnimBool(false);
                fogOfWarManager.ShowPreview.valueChanged.AddListener(Repaint);
            }

            if (fogOfWarManager.ShowLevelOption == null)
            {
                fogOfWarManager.ShowLevelOption = new AnimBool(false);
                fogOfWarManager.ShowLevelOption.valueChanged.AddListener(Repaint);
            }

            if (fogOfWarManager.ShowFogOptions == null)
            {
                fogOfWarManager.ShowFogOptions = new AnimBool(false);
                fogOfWarManager.ShowFogOptions.valueChanged.AddListener(Repaint);
            }

            if (fogOfWarManager.ShowFactionOptions == null)
            {
                fogOfWarManager.ShowFactionOptions = new AnimBool(false);
                fogOfWarManager.ShowFactionOptions.valueChanged.AddListener(Repaint);
            }

            if (fogOfWarManager.ShowBlurOptions == null)
            {
                fogOfWarManager.ShowBlurOptions = new AnimBool(false);
                fogOfWarManager.ShowBlurOptions.valueChanged.AddListener(Repaint);
            }

            if (fogOfWarManager.ShowGrassOptions == null)
            {
                fogOfWarManager.ShowGrassOptions = new AnimBool(false);
                fogOfWarManager.ShowGrassOptions.valueChanged.AddListener(Repaint);
            }

            if (fogOfWarManager.ShowMixedOptions == null)
            {
                fogOfWarManager.ShowMixedOptions = new AnimBool(false);
                fogOfWarManager.ShowMixedOptions.valueChanged.AddListener(Repaint);
            }
        }

        StartEndHeight = serializedObject.FindProperty("StartEndHeight");
        RevealOpacities = serializedObject.FindProperty("RevealOpacities");
        UpSample = serializedObject.FindProperty("UpSample");
        ShowBlocker = serializedObject.FindProperty("ShowBlocker");
        RevealSpeed = serializedObject.FindProperty("RevealSpeed");
        CoverSpeed = serializedObject.FindProperty("CoverSpeed");
        ResitenceMapPath = serializedObject.FindProperty("ResitenceMapPath");
        FogFilterMode = serializedObject.FindProperty("FogTextureFilterMode");
        ResistenceMapPrefab = serializedObject.FindProperty("Resistence");
#if !UNITY_WEBGL
        UseThreading = serializedObject.FindProperty("UseThreading");
#endif
        FogNoise = serializedObject.FindProperty("FogNoise");
        RevealedOpacity = serializedObject.FindProperty("RevealedOpacity");
        CoveredOpacity = serializedObject.FindProperty("CoveredOpacity");
        UndiscoveredOpacity = serializedObject.FindProperty("UndiscoveredOpacity");
        DebugMode = serializedObject.FindProperty("DebugMode");
        ModPrefab = serializedObject.FindProperty("ModPrefab");
        PreviewModPrefab = serializedObject.FindProperty("PreviewModPrefab");
        placeMode = serializedObject.FindProperty("placeMode");
        FogGO = serializedObject.FindProperty("FogGO");
        PlacementID = serializedObject.FindProperty("PlacementID");
        ChangeHeight = serializedObject.FindProperty("ChangeHeight");
        SaveReminder = serializedObject.FindProperty("SaveReminder");
        ScalePatchModifier = serializedObject.FindProperty("ScalePatchModifier");
        PatchScale = serializedObject.FindProperty("PatchScale");
        Origin = serializedObject.FindProperty("Origin");
        AutomaticMode = serializedObject.FindProperty("AutomaticMode");
        UpdatesPerSecond = serializedObject.FindProperty("UpdatesPerSecond");
        FogColor = serializedObject.FindProperty("FogColor");
        AnimatedFogSpeed = serializedObject.FindProperty("AnimatedFogSpeed");
        AnimatedFogIntensity = serializedObject.FindProperty("AnimatedFogIntensity");
        AnimatedFogTiling = serializedObject.FindProperty("AnimatedFogTiling");

        EditorApplication.update += Update;
    }

    void OnDisable()
    {
        EditorApplication.update -= Update;
    }

    public override void OnInspectorGUI()
    {
        fogOfWarManager = (FogOfWarManager)target;
        serializedObject.Update();
        EditorGUI.BeginChangeCheck();

        if (DebugMatR == null)
        {
            DebugMatR = new Material(Shader.Find("Hidden/UltimateFogOfWar/Debug/GUIDebug_R"));
        }

        if (DebugMatG == null)
        {
            DebugMatG = new Material(Shader.Find("Hidden/UltimateFogOfWar/Debug/GUIDebug_G"));
        }
        /*
        if (DebugMatB == null)
        {
            DebugMatB = new Material(Shader.Find("Hidden/UltimateFogOfWar/Debug/GUIDebug_B"));
        }
        */
        if (DebugMatA == null)
        {
            DebugMatA = new Material(Shader.Find("Hidden/UltimateFogOfWar/Debug/GUIDebug_A"));
        }

        EditorGUILayout.BeginVertical("Box");
        {
            if (GUILayout.Button("Preview Fog", EditorStyles.toolbarButton))
                fogOfWarManager.ShowPreview.target = !fogOfWarManager.ShowPreview.target;

            if (fogOfWarManager.ShowPreview.target)
            {
                EditorGUILayout.BeginFadeGroup(fogOfWarManager.ShowPreview.faded);
                {
                    //EditorGUILayout.LabelField("Preview Fog", EditorStyles.toolbarButton);
                    GUILayout.Space(5f);

                    EditorGUILayout.BeginHorizontal();
                    {
                        
                        if (GUILayout.Button("<", EditorStyles.miniButtonLeft, GUILayout.MaxWidth(Screen.width / 8f)))
                        {
                            if (DisplayFactionFog > 0)
                                DisplayFactionFog--;
                        }

                        //DisplayFactionFog = Mathf.Clamp(DisplayFactionFog, 0, fogOfWarManager.FactionCount);
                        GUILayout.Button("Displaying Faction: " + DisplayFactionFog.ToString(), EditorStyles.miniButtonMid);
                        //EditorGUILayout.LabelField(DisplayFactionFog.ToString(), EditorStyles.miniButtonMid);

                        if (GUILayout.Button(">", EditorStyles.miniButtonRight, GUILayout.MaxWidth(Screen.width / 8f)))
                        {
                            if (DisplayFactionFog < fogOfWarManager.Factions.Count-1)
                                DisplayFactionFog++;

                        }
                        
                    }
                    EditorGUILayout.EndHorizontal();

                    GUILayout.Space(5f);

                    EditorGUILayout.BeginHorizontal();
                    {
                        if (GUILayout.Button("Static", EditorStyles.toolbarButton, GUILayout.MaxWidth(Screen.width / 4f)))
                        {
                            DisplayTexA = true;
                            DisplayTexB = false;
                            DisplayTexC = false;
                            DisplayTexD = false;
                        }

                        if (GUILayout.Button("Height", EditorStyles.toolbarButton, GUILayout.MaxWidth(Screen.width / 4f)))
                        {
                            DisplayTexA = false;
                            DisplayTexB = true;
                            DisplayTexC = false;
                            DisplayTexD = false;
                        }

                        if (GUILayout.Button("Modifiers", EditorStyles.toolbarButton, GUILayout.MaxWidth(Screen.width / 4f)))
                        {
                            DisplayTexA = false;
                            DisplayTexB = false;
                            DisplayTexC = true;
                            DisplayTexD = false;
                        }
                        if (GUILayout.Button("Fog (Play)", EditorStyles.toolbarButton, GUILayout.MaxWidth(Screen.width / 4f)))
                        {
                            DisplayTexA = false;
                            DisplayTexB = false;
                            DisplayTexC = false;
                            DisplayTexD = true;
                        }
                    }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    {
                        Rect rect = GUILayoutUtility.GetRect(256f, 256f);
                        
                        if (ResistenceMap != null && fogOfWarManager.ShowPreview.faded == 1f)
                        {
                            if (DisplayTexA)
                            {
                                EditorGUI.DrawPreviewTexture(rect, ResistenceMap, DebugMatR, ScaleMode.ScaleToFit);
                            }

                            if (DisplayTexB)
                            {
                                EditorGUI.DrawPreviewTexture(rect, ResistenceMap, DebugMatG, ScaleMode.ScaleToFit);
                            }

                            if (DisplayTexC)
                            {
                                EditorGUI.DrawPreviewTexture(rect, ResistenceMap, DebugMatA, ScaleMode.ScaleToFit);
                            }

                            if (DisplayTexD)
                            {
                                if (FogOfWar.Factions[FogOfWar.RevealFactionInt].BluredRenderTexture != null)
                                {
                                    EditorGUI.DrawPreviewTexture(rect, FogOfWar.Factions[(int)DisplayFactionFog].BluredRenderTexture as Texture, null, ScaleMode.ScaleToFit);
                                }
                            }
                        }
                    }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    {
                        if (!Application.isPlaying)
                        {
                            EditorGUILayout.LabelField("Play the game to start", EditorStyles.toolbarButton);
                        }
                        else
                        {
                            if (!FogOfWar.Factions[DisplayFactionFog].UpdateInBackground && FogOfWar.RevealFactionInt != DisplayFactionFog)
                            {
                                GUI.color = Color.red;
                                EditorGUILayout.LabelField("Faction " + DisplayFactionFog + ": Update in Background disabled", EditorStyles.toolbarButton);
                                GUI.color = Color.white;
                            }
                            else
                            {
                                GUI.color = new Color(0f,.5f+(Mathf.Sin(Time.realtimeSinceStartup*4f)+1f)/4f,0f,1f);
                                EditorGUILayout.LabelField("Revealing", EditorStyles.toolbarButton);
                                GUI.color = Color.white;
                            }

                        }
                    }
                    EditorGUILayout.EndHorizontal();

                    
#if UNITY_WEBGL
                    EditorGUILayout.LabelField("Currently updating only Faction: " + FogOfWar.RevealFaction, EditorStyles.toolbarButton);
#else
                    if (!fogOfWarManager.UseThreading)
                        EditorGUILayout.LabelField("Currently updating only Faction: " + FogOfWar.RevealFaction, EditorStyles.toolbarButton);
#endif
                }
                EditorGUILayout.EndFadeGroup();
            }
            EditorGUILayout.EndVertical();

            if (fogOfWarManager.ShowPreview.target)
                GUILayout.Space(15f);

            EditorGUILayout.BeginVertical("Box");
            {
                if (fogOfWarManager.fogAlignment == FogOfWar.FogAlignment.Horizontal)
                {
                    EditorGUILayout.BeginHorizontal();
                    {
                        if (GUILayout.Button("Level (Terrain Mode)", EditorStyles.toolbarButton))
                            fogOfWarManager.ShowLevelOption.target = !fogOfWarManager.ShowLevelOption.target;

                        //EditorGUILayout.LabelField("Level (Terrain Mode)", EditorStyles.toolbarButton);
                    }
                    EditorGUILayout.EndHorizontal();

                    if (fogOfWarManager.ShowLevelOption.target)
                        fogOfWarManager.FogOfWarTerrain = EditorGUILayout.ObjectField(fogOfWarManager.FogOfWarTerrain, typeof(Terrain), true) as Terrain;
                }
                else {
                    EditorGUILayout.BeginHorizontal();
                    {
                        if (GUILayout.Button("Level (Canvas Mode)", EditorStyles.toolbarButton))
                            fogOfWarManager.ShowLevelOption.target = !fogOfWarManager.ShowLevelOption.target;
                        //EditorGUILayout.LabelField("Level (Canvas Mode)", EditorStyles.toolbarButton);
                    }
                    EditorGUILayout.EndHorizontal();

                    if (fogOfWarManager.ShowLevelOption.target)
                        fogOfWarManager.FogCanvas = EditorGUILayout.ObjectField(fogOfWarManager.FogCanvas, typeof(Canvas), true) as Canvas;
                }

                if (fogOfWarManager.ShowLevelOption.target)
                {
                    EditorGUILayout.BeginFadeGroup(fogOfWarManager.ShowLevelOption.faded);
                    {
                        ResitenceMapPath.stringValue = EditorGUILayout.TextField(ResitenceMapPath.stringValue);
                        ResistenceMapPrefab.objectReferenceValue = EditorGUILayout.ObjectField(ResistenceMapPrefab.objectReferenceValue, typeof(Texture2D), false) as Texture2D;

                        EditorGUILayout.BeginVertical("Box");
                        {
                            EditorGUILayout.BeginVertical("Box");
                            {
                                MakeOnOffButton("Enable Scaling", ScalePatchModifier);

                                if (ScalePatchModifier.boolValue == false)
                                {
                                    PatchScale.floatValue = 1f;
                                    Origin.vector3Value = Vector3.zero;
                                }

                                EditorGUI.BeginDisabledGroup(!ScalePatchModifier.boolValue);
                                {
                                    PatchScale.floatValue = EditorGUILayout.FloatField(new GUIContent("Scale", "Pick a value to scale the Grid, to make it denser or wider"), PatchScale.floatValue);
                                    PatchScale.floatValue = Mathf.Clamp(PatchScale.floatValue, 0.1f, 100f);
                                    Origin.vector3Value = EditorGUILayout.Vector3Field(new GUIContent("Origin", "This represents the Origin of the Fog (Bottom left corner)"), Origin.vector3Value);
                                }
                                EditorGUI.EndDisabledGroup();
                            }
                            EditorGUILayout.EndVertical();

                            EditorGUILayout.BeginHorizontal();
                            {
                                EditorGUI.BeginDisabledGroup(true);
                                {
                                    EditorGUILayout.PrefixLabel("Level Dimensions");
                                    fogOfWarManager.LevelWidth = EditorGUILayout.IntField(fogOfWarManager.LevelWidth);
                                    fogOfWarManager.LevelHeight = EditorGUILayout.IntField(fogOfWarManager.LevelHeight);
                                }
                                EditorGUI.EndDisabledGroup();
                            }
                            EditorGUILayout.EndHorizontal();

                            CoverSpeed.floatValue = EditorGUILayout.FloatField("Cover Speed", CoverSpeed.floatValue);
                            RevealSpeed.floatValue = EditorGUILayout.FloatField("Reveal Speed", RevealSpeed.floatValue);
                            GUILayout.Space(15f);

                            
                            if (fogOfWarManager.fogAlignment == FogOfWar.FogAlignment.Horizontal)
                            {
                                StartEndHeight.vector2Value = EditorGUILayout.Vector2Field("Min Max Level Height", StartEndHeight.vector2Value);

                                if (GUILayout.Button(new GUIContent("Analyze Height","Analyze the height of the Terrain defined in Min Max Level Height. All colliders are included! Make sure that everything that is not part of the Level is deactivated.")))
                                {
                                    fogOfWarManager.AnalyzeTerrain();
                                    SavePNGToDisc();
                                }
                             } else {
                                EditorGUILayout.BeginHorizontal();
                                {
                                    StartEndHeight.vector2Value = EditorGUILayout.Vector2Field("Min Max Level Height", StartEndHeight.vector2Value);
                                }
                                EditorGUILayout.EndHorizontal();
                            }
                            
                            GUILayout.Space(15f);

                            EditorGUILayout.LabelField("Fog Opacities");
                            RevealedOpacity.floatValue = EditorGUILayout.Slider(RevealedOpacity.floatValue, 0f, 1f);
                            CoveredOpacity.floatValue = EditorGUILayout.Slider(CoveredOpacity.floatValue, 0f, 1f);
                            UndiscoveredOpacity.floatValue = EditorGUILayout.Slider(UndiscoveredOpacity.floatValue, 0f, 1f);

                        }
                        EditorGUILayout.EndVertical();
                    }
                    EditorGUILayout.EndFadeGroup();
                }
            }
            EditorGUILayout.EndVertical();

            if (fogOfWarManager.ShowLevelOption.target)
                GUILayout.Space(15f);

            EditorGUILayout.BeginVertical("Box");
            {
                if (GUILayout.Button("Factions", EditorStyles.toolbarButton))
                fogOfWarManager.ShowFactionOptions.target = !fogOfWarManager.ShowFactionOptions.target;

                if (FogOfWar.RevealFaction < 0)
                    FogOfWar.RevealFaction = 0;

                if (fogOfWarManager.ShowFactionOptions.target)
                {
                    EditorGUILayout.BeginFadeGroup(fogOfWarManager.ShowFactionOptions.faded);
                    {
                        EditorGUILayout.BeginVertical("Box");
                        {
                            EditorGUILayout.BeginHorizontal();
                            {
                                //EditorGUILayout.LabelField(FogOfWar.RevealFaction.ToString());
                                EditorGUILayout.LabelField("Number of Factions: " + fogOfWarManager.Factions.Count.ToString());
                            }
                            EditorGUILayout.EndHorizontal();

                            if (Application.isPlaying)
                            {
                                EditorGUILayout.BeginHorizontal();
                                {
                                    //EditorGUILayout.LabelField(FogOfWar.RevealFaction.ToString());
                                    EditorGUILayout.LabelField("Registered Revealers: " + FogOfWar.GetRevealerCount().ToString());
                                }
                                EditorGUILayout.EndHorizontal();
                            }

                            EditorGUILayout.BeginHorizontal();
                            {
                                if (GUILayout.Button("Add Faction", EditorStyles.toolbarButton))
                                {
                                    fogOfWarManager.AddFaction();
                                    fogOfWarManager.ShowFaction(FogOfWar.RevealFactionInt);
                                }

                                if (GUILayout.Button("Remove Faction", EditorStyles.toolbarButton))
                                {
                                    if (DisplayFactionFog > 0 && DisplayFactionFog == fogOfWarManager.Factions.Count - 1)
                                    {
                                        DisplayFactionFog--;
                                    }
                                    fogOfWarManager.RemoveFaction(fogOfWarManager.Factions.Count-1);
                                    fogOfWarManager.ShowFaction(FogOfWar.RevealFactionInt);
                                }
                            }
                            EditorGUILayout.EndHorizontal();

                            EditorGUILayout.BeginHorizontal();
                            {
                                EditorGUILayout.LabelField("Revealing Faction: "+FogOfWar.RevealFactionInt.ToString());
                            }
                            EditorGUILayout.EndHorizontal();

                            for (int i = 0; i < FogOfWar.Factions.Count; i++)
                            {
                                if (FogOfWar.RevealFactionInt == i)
                                {
                                    GUI.color = Color.green;
                                }

                                EditorGUILayout.BeginHorizontal();
                                {
                                    if (GUILayout.Button("Player: " + i.ToString(), EditorStyles.toolbarButton, GUILayout.MaxWidth(65f)))
                                    {
                                        fogOfWarManager.ShowFaction(i);
                                    }
                                    FogOfWar.Factions[i].RevealFactions = (FogOfWar.Players)EditorGUILayout.EnumMaskField(FogOfWar.Factions[i].RevealFactions);

                                    fogOfWarManager.Factions[i].UpdateInBackground = EditorGUILayout.ToggleLeft(new GUIContent("BG Update"," Update this faction when not being shown."), fogOfWarManager.Factions[i].UpdateInBackground, GUILayout.MaxWidth(Screen.width / 5f));
                                }
                                EditorGUILayout.EndHorizontal();

                                if (FogOfWar.RevealFactionInt == i)
                                {
                                    GUI.color = Color.white;
                                }
                            }
                        }
                        EditorGUILayout.EndVertical();
                    }
                }
                EditorGUILayout.EndFadeGroup();
            }
            EditorGUILayout.EndVertical();

            if (fogOfWarManager.ShowFactionOptions.target)
                GUILayout.Space(15f);

            EditorGUILayout.BeginVertical("Box");
            {
                if (GUILayout.Button("Blur Options", EditorStyles.toolbarButton))
                fogOfWarManager.ShowBlurOptions.target = !fogOfWarManager.ShowBlurOptions.target;

                if (fogOfWarManager.ShowBlurOptions.target)
                {
                    EditorGUILayout.BeginFadeGroup(fogOfWarManager.ShowBlurOptions.faded);
                    {
                        EditorGUILayout.BeginVertical("Box");
                        {
                            EditorGUILayout.BeginHorizontal();
                            {
                                EditorGUILayout.PrefixLabel("Fog Upsamle");
                                UpSample.intValue = (int)EditorGUILayout.Slider((float)UpSample.intValue, 1, 4);
                            }
                            EditorGUILayout.EndHorizontal();

                            EditorGUILayout.BeginHorizontal();
                            {
                                EditorGUILayout.PrefixLabel("Blur Fog");
                                fogOfWarManager.BlurFog = (FogOfWar.FogQuality)EditorGUILayout.EnumPopup(fogOfWarManager.BlurFog);
                            }
                            EditorGUILayout.EndHorizontal();

                            EditorGUILayout.PropertyField(FogFilterMode);

                            EditorGUILayout.BeginHorizontal();
                            {
                                EditorGUILayout.PrefixLabel("Fog Effect");
                                fogOfWarManager.fogEffect = (FogOfWar.FogEffect)EditorGUILayout.EnumPopup(fogOfWarManager.fogEffect);
                            }
                            EditorGUILayout.EndHorizontal();

                            if (fogOfWarManager.fogEffect == FogOfWar.FogEffect.Color)
                            {
                                FogColor.colorValue = EditorGUILayout.ColorField("Fog Color", FogColor.colorValue);
                            }

                            if (fogOfWarManager.fogEffect == FogOfWar.FogEffect.AnimatedFog)
                            {

                                EditorGUILayout.PrefixLabel("Fog Noise");
                                FogNoise.objectReferenceValue = EditorGUILayout.ObjectField(FogNoise.objectReferenceValue, typeof(Texture2D), false) as Texture2D;
                                FogColor.colorValue = EditorGUILayout.ColorField("Fog Color", FogColor.colorValue);
                                AnimatedFogSpeed.floatValue = EditorGUILayout.FloatField("Speed", AnimatedFogSpeed.floatValue);
                                AnimatedFogIntensity.floatValue = EditorGUILayout.FloatField("Intensity", AnimatedFogIntensity.floatValue);
                                AnimatedFogTiling.floatValue = EditorGUILayout.FloatField("Tiling", AnimatedFogTiling.floatValue);
                            }
                        }
                        EditorGUILayout.EndVertical();
                    }
                    EditorGUILayout.EndFadeGroup();
                }
            }
        }
        EditorGUILayout.EndVertical();

        if (fogOfWarManager.ShowBlurOptions.target)
            GUILayout.Space(15f);

        EditorGUILayout.BeginVertical("Box");
        {
            if (fogOfWarManager.ShowGrassOptions.target)
            {
                if (GUILayout.Button("Modifier Options (Close to stop editing)", EditorStyles.toolbarButton))
                {
                    if (!fogOfWarManager.ShowGrassOptions.target)
                        fogOfWarManager.PreparePlacement();

                    fogOfWarManager.ShowGrassOptions.target = !fogOfWarManager.ShowGrassOptions.target;
                }
            }
            else {
                if (GUILayout.Button("Modifier Options", EditorStyles.toolbarButton))
                {
                    if (!fogOfWarManager.ShowGrassOptions.target)
                        fogOfWarManager.PreparePlacement();

                    fogOfWarManager.ShowGrassOptions.target = !fogOfWarManager.ShowGrassOptions.target;
                }
            }

            if (fogOfWarManager.ShowGrassOptions.target)
            {
                EditorGUILayout.BeginFadeGroup(fogOfWarManager.ShowGrassOptions.faded);
                {

                    EditorGUILayout.BeginVertical("Box");
                    {
                        EditorGUILayout.BeginHorizontal();
                        {
                            if (placeMode.enumValueIndex == 0)
                                GUI.color = Color.green;

                            if (GUILayout.Button("Hard Blocker", EditorStyles.toolbarButton))
                            {
                                placeMode.enumValueIndex = 0;
                            }
                            GUI.color = Color.white;

                            if (placeMode.enumValueIndex ==1)
                                GUI.color = Color.green;

                            if (GUILayout.Button("Height", EditorStyles.toolbarButton))
                            {
                                placeMode.enumValueIndex = 1;
                            }
                            GUI.color = Color.white;

                            if (placeMode.enumValueIndex == 2)
                                GUI.color = Color.green;

                            if (GUILayout.Button("Modifier", EditorStyles.toolbarButton))
                            {
                                placeMode.enumValueIndex = 2;
                            }
                            GUI.color = Color.white;

                            if (placeMode.enumValueIndex == 3)
                                GUI.color = Color.green;

                            if (GUILayout.Button("Del", EditorStyles.toolbarButton))
                            {
                                placeMode.enumValueIndex = 3;
                            }
                            GUI.color = Color.white;

                        }
                        EditorGUILayout.EndHorizontal();

                        if (placeMode.enumValueIndex == 0)
                        {

                            fogOfWarManager.MultiPlaceID = EditorGUILayout.IntSlider("ID", fogOfWarManager.MultiPlaceID, 0, 255);
                            fogOfWarManager.MultiPlaceWidth = EditorGUILayout.IntSlider("Width", fogOfWarManager.MultiPlaceWidth, 1, 9);
                            fogOfWarManager.MultiPlaceHeight = EditorGUILayout.IntSlider("Height", fogOfWarManager.MultiPlaceHeight, 1, 9);
                        }

                        if (placeMode.enumValueIndex == 1)
                        {
                            ChangeHeight.intValue = EditorGUILayout.IntSlider(new GUIContent("Height:","Change the Height to this value"), ChangeHeight.intValue, 0, 255);
                        }

                        if (placeMode.enumValueIndex == 2)
                        {
                            ModPrefab.objectReferenceValue = EditorGUILayout.ObjectField("Pick Prefab", ModPrefab.objectReferenceValue, typeof(GameObject), true) as GameObject;
                            GrassID = EditorGUILayout.IntField(new GUIContent("Grass ID", "ID 255 is outside of modifers."), GrassID);
                            GrassID = Mathf.Clamp(GrassID, 0, 255);
                        }

                        switch (placeMode.enumValueIndex)
                        {
                            case 0:
                                EditorGUILayout.HelpBox("Left Click: Switch Hard Blocker.", MessageType.Info);
                                break;

                            case 1:
                                EditorGUILayout.HelpBox("Left Click: Save Value from Slider.", MessageType.Info);
                                break;

                            case 2:
                                EditorGUILayout.HelpBox("Left Click: Place, Set Prefab to none to change only the Value.", MessageType.Info);
                                break;

                            case 3:
                                EditorGUILayout.HelpBox("Left Click: Delete Prefab and reset Modifier.", MessageType.Info);
                                break;
                        }

                        EditorGUILayout.BeginHorizontal();
                        {
                            if (GUILayout.Button("Revert All"))
                            {
                                fogOfWarManager.Revert();
                                fogOfWarManager.FinalizePlacement();
                                SavePNGToDisc();
                            }
                            
                            if (SReminder == true)
                                GUI.color = Color.yellow;

                            if (GUILayout.Button("Save"))
                            {
                                fogOfWarManager.FinalizePlacement();
                                SavePNGToDisc();
                                SReminder = false;
                            }

                            GUI.color = Color.white;

                        }
                        EditorGUILayout.EndHorizontal();

                    }
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndFadeGroup();
            }
        }
        EditorGUILayout.EndVertical();
        
        if (fogOfWarManager.ShowGrassOptions.target)
            GUILayout.Space(15f);

        EditorGUILayout.BeginVertical("Box");
        {
            if (GUILayout.Button("Diagnostic & Performance", EditorStyles.toolbarButton))
                fogOfWarManager.ShowMixedOptions.target = !fogOfWarManager.ShowMixedOptions.target;

            if (fogOfWarManager.ShowMixedOptions.target)
            {
                EditorGUILayout.BeginFadeGroup(fogOfWarManager.ShowMixedOptions.faded);
                {
                    EditorGUILayout.BeginVertical("Box");
                    {
#if !UNITY_WEBGL
                        MakeOnOffButton("Use Threads:", UseThreading);
#endif

                        MakeOnOffButton("Automaticly Update:", AutomaticMode);

                        if (!AutomaticMode.boolValue)
                        {
                            UpdatesPerSecond.floatValue = EditorGUILayout.FloatField("Updates per Second", UpdatesPerSecond.floatValue);
                            UpdatesPerSecond.floatValue = Mathf.Round(Mathf.Clamp(UpdatesPerSecond.floatValue, 0f, 60f));
                        }

                        MakeOnOffButton("Reveal Blockers:", ShowBlocker);
                        MakeOnOffButton("Show Guides:", DebugMode);
                        
                    }
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndFadeGroup(); 
            }
        }
        EditorGUILayout.EndVertical();

        if (fogOfWarManager.ShowMixedOptions.target)
            GUILayout.Space(15f);

        if (EditorGUI.EndChangeCheck())
        {
            switch (fogOfWarManager.fogEffect)
            {
                case FogOfWar.FogEffect.None:
                    Shader.DisableKeyword("FoWColor");
                    Shader.DisableKeyword("FoWAnimatedFog");
                    break;

                case FogOfWar.FogEffect.Color:
                    Shader.DisableKeyword("FoWAnimatedFog");
                    Shader.EnableKeyword("FoWColor");
                    Shader.SetGlobalColor("FogColor", FogColor.colorValue);
                    break;

                case FogOfWar.FogEffect.AnimatedFog:
                    Shader.DisableKeyword("FoWColor");
                    Shader.EnableKeyword("FoWAnimatedFog");
                    Shader.SetGlobalTexture("FogNoise", FogNoise.objectReferenceValue as Texture2D);
                    Shader.SetGlobalColor("FogColor", FogColor.colorValue);
                    Shader.SetGlobalFloat("FogSpeed", AnimatedFogSpeed.floatValue);
                    Shader.SetGlobalFloat("FogTiling", AnimatedFogTiling.floatValue);
                    Shader.SetGlobalFloat("FogIntensity", AnimatedFogIntensity.floatValue);
                    break;
            }

            if (fogOfWarManager.BlurFog == FogOfWar.FogQuality.Off)
            {
                FogOfWarBlur blur = fogOfWarManager.GetComponent<FogOfWarBlur>();
                if (blur != null)
                    DestroyImmediate(blur);
            }
            else {
                FogOfWarBlur blur = fogOfWarManager.GetComponent<FogOfWarBlur>();

                if (blur == null)
                    fogOfWarManager.fogOfWarBlur = fogOfWarManager.gameObject.AddComponent<FogOfWarBlur>();
            }

            RevealOpacities.colorValue = new Color(RevealedOpacity.floatValue, CoveredOpacity.floatValue, UndiscoveredOpacity.floatValue, 1f);

            if(!Application.isPlaying)
                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
        
        serializedObject.ApplyModifiedProperties();
    }

    private void MakeOnOffButton(string _Label, SerializedProperty _Bool)
    {
        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.LabelField(_Label);

            if (_Bool.boolValue)
            {
                GUI.color = Color.green;
                if (GUILayout.Button("On", EditorStyles.toolbarButton))
                {
                    _Bool.boolValue = true;
                }
                GUI.color = Color.white;

                GUI.color = Color.grey;
                if (GUILayout.Button("Off", EditorStyles.toolbarButton))
                {
                    _Bool.boolValue = false;
                }
                GUI.color = Color.white;
            }
            else {
                GUI.color = Color.grey;
                if (GUILayout.Button("On", EditorStyles.toolbarButton))
                {
                    _Bool.boolValue = true;
                }
                GUI.color = Color.white;
                GUI.color = Color.green;
                if (GUILayout.Button("Off", EditorStyles.toolbarButton))
                {
                    _Bool.boolValue = false;
                }
                GUI.color = Color.white;
            }
        }
        EditorGUILayout.EndHorizontal();
    }

    void Update()
    {
        if (fogOfWarManager == null)
            return;

        ResistenceMap = fogOfWarManager.GetResistenceMap() as Texture;

        Repaint();
    }

    private Texture LabelTexture;
    private Vector3 Rot;
    private bool SReminder = false;

    void OnSceneGUI()
    {
        fogOfWarManager = (FogOfWarManager)target;

        if (fogOfWarManager != null)
        {
            if (fogOfWarManager.ShowGrassOptions.target)
            {
                Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                RaycastHit rayHit = new RaycastHit();

                if (Physics.Raycast(ray, out rayHit))
                {
                    fogOfWarManager.UpdatePreviewPrefab(rayHit.point, Quaternion.Euler(Rot), !Event.current.shift);
                }

                if (Event.current.type == EventType.ScrollWheel && Event.current.modifiers == EventModifiers.Control)
                {
                    if (fogOfWarManager.fogAlignment == FogOfWar.FogAlignment.Horizontal)
                    {
                        Rot.y += Event.current.delta.y * 2f;
                        Event.current.Use();
                    } else {
                        Rot.z += Event.current.delta.y * 2f;
                        Event.current.Use();
                    } 
                }

                if (Event.current.type == EventType.MouseUp && Event.current.button == 0)
                {
                    switch (placeMode.enumValueIndex)
                    {
                        case 0:
                            fogOfWarManager.ChangeHardBlockerTo(rayHit.point, fogOfWarManager.MultiPlaceWidth, fogOfWarManager.MultiPlaceHeight, fogOfWarManager.MultiPlaceID);
                            fogOfWarManager.FinalizePlacement();
                            SReminder = true;
                            break;

                        case 1:
                            fogOfWarManager.ChangeHeightTo(rayHit.point, (float)ChangeHeight.intValue);
                            fogOfWarManager.FinalizePlacement();
                            SReminder = true;
                            break;

                        case 2:
                            fogOfWarManager.PlacePrefab(rayHit.point, Quaternion.Euler(Rot), Event.current.shift, GrassID);
                            fogOfWarManager.FinalizePlacement();
                            SReminder = true;
                            Rot = Vector3.zero;
                            Event.current.Use();
                            break;

                        case 3:
                            fogOfWarManager.RevertSingle(rayHit.point);
                            fogOfWarManager.FinalizePlacement();
                            SReminder = true;
                            Event.current.Use();
                            break;
                    }
                }

                //Used to override left click
                if (Event.current.type == EventType.Layout)
                {
                    HandleUtility.AddDefaultControl(0);
                }
            }
            else {
                fogOfWarManager.RemovePreview();
            }
        }

        if (LabelTexture == null)
            LabelTexture = Resources.Load("Textures/Editor/PointerBG") as Texture;

        if (fogOfWarManager != null && fogOfWarManager.DebugMode)
        {
            if (fogOfWarManager.fogAlignment == FogOfWar.FogAlignment.Horizontal)
            {
                
                Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                RaycastHit rayHit = new RaycastHit();

                //Big arc
                float Radius = (Mathf.Sqrt(Mathf.Pow(fogOfWarManager.LevelWidth, 2) + Mathf.Pow(fogOfWarManager.LevelHeight, 2)) / 2f);
                Handles.DrawWireArc((new Vector3(fogOfWarManager.LevelWidth / 2f, 0f, fogOfWarManager.LevelHeight / 2f) * PatchScale.floatValue) + Origin.vector3Value, Vector3.up, new Vector3(1f, 0f, 1f), 360f, Radius * PatchScale.floatValue);
                Handles.color = Color.white;
                Handles.DrawWireArc((new Vector3(fogOfWarManager.LevelWidth / 2f, 0f, fogOfWarManager.LevelHeight / 2f) * PatchScale.floatValue) + Origin.vector3Value, Vector3.up, new Vector3(1f, 0f, 1f), 360f, Radius * PatchScale.floatValue + .1f);
                Handles.color = new Color(.953f, .659f, .157f, 1f);
                Handles.DrawWireArc((new Vector3(fogOfWarManager.LevelWidth / 2f, 0f, fogOfWarManager.LevelHeight / 2f) * PatchScale.floatValue) + Origin.vector3Value, Vector3.up, new Vector3(1f, 0f, 1f), 360f, Radius * PatchScale.floatValue + .2f);
                Handles.DrawWireArc((new Vector3(fogOfWarManager.LevelWidth / 2f, 0f, fogOfWarManager.LevelHeight / 2f) * PatchScale.floatValue) + Origin.vector3Value, Vector3.up, new Vector3(1f, 0f, 1f), 360f, Radius * PatchScale.floatValue + 1f);

                Handles.DrawLine((new Vector3(0f, 0f, fogOfWarManager.LevelHeight / 2f) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(-50f, 0f, fogOfWarManager.LevelHeight / 2f) * PatchScale.floatValue) + Origin.vector3Value);
                Handles.DrawLine((new Vector3(fogOfWarManager.LevelWidth, 0f, fogOfWarManager.LevelHeight / 2f) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(fogOfWarManager.LevelWidth + 50f, 0f, fogOfWarManager.LevelHeight / 2f) * PatchScale.floatValue) + Origin.vector3Value);
                Handles.DrawLine((new Vector3(fogOfWarManager.LevelWidth / 2f, 0f, 0f) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(fogOfWarManager.LevelWidth / 2f, 0f, -50f) * PatchScale.floatValue) + Origin.vector3Value);
                Handles.DrawLine((new Vector3(fogOfWarManager.LevelWidth / 2f, 0f, fogOfWarManager.LevelHeight) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(fogOfWarManager.LevelWidth / 2f, 0f, fogOfWarManager.LevelHeight + 50f) * PatchScale.floatValue) + Origin.vector3Value);

                if (Physics.Raycast(ray, out rayHit))
                {
                    if (rayHit.point.x >= Origin.vector3Value.x && rayHit.point.x <= fogOfWarManager.LevelWidth * PatchScale.floatValue + Origin.vector3Value.x && rayHit.point.z >= Origin.vector3Value.z && rayHit.point.z <= fogOfWarManager.LevelHeight * PatchScale.floatValue + Origin.vector3Value.z)
                    {
                        Handles.color = new Color(.953f, .659f, .157f, .4f);
                        Handles.DrawDottedLine(fogOfWarManager.transform.position, rayHit.point, 1f);
                        Handles.color = new Color(.953f, .659f, .157f, 1f);
                        
                        //Rings on pointer
                        Handles.DrawWireArc(rayHit.point, Vector3.up, new Vector3(1f, 0f, 1f), 360f, 1f);
                        Handles.DrawWireArc(rayHit.point, Vector3.up, new Vector3(1f, 0f, 1f), 360f, 1.05f);
                        Handles.color = new Color(.953f, .659f, .157f, 1f);
                        Handles.DrawWireArc(rayHit.point, Vector3.up, new Vector3(1f, 0f, 1f), 360f, 1.1f);
                        Handles.color = Color.white;

                        Handles.color = new Color(.953f, .659f, .157f, 1f);

                        //Pointer position Highlight
                        Vector3[] v = new Vector3[2] { new Vector3(0f + Origin.vector3Value.x, rayHit.point.y, Mathf.Floor(rayHit.point.z / PatchScale.floatValue) * PatchScale.floatValue + PatchScale.floatValue / 2f),
                        new Vector3(Mathf.Floor(fogOfWarManager.LevelWidth) * PatchScale.floatValue + Origin.vector3Value.x, rayHit.point.y, Mathf.Floor(rayHit.point.z / PatchScale.floatValue) * PatchScale.floatValue + PatchScale.floatValue / 2f)};

                        //Handles.DrawAAPolyLine(2f, v);

                        v = new Vector3[2] { new Vector3(Mathf.Floor(rayHit.point.x/PatchScale.floatValue) * PatchScale.floatValue + PatchScale.floatValue/2f, rayHit.point.y, 0f + Origin.vector3Value.z),
                        new Vector3(Mathf.Floor(rayHit.point.x/PatchScale.floatValue) * PatchScale.floatValue + PatchScale.floatValue/2f, rayHit.point.y+.1f, Mathf.Floor(fogOfWarManager.LevelHeight) * PatchScale.floatValue + Origin.vector3Value.z)};

                        Handles.DrawAAPolyLine(2f, v);

                        Handles.color = new Color(.1f, .05f, 0f, .4f);
                        float f1 = Mathf.Floor((rayHit.point.x - Origin.vector3Value.x) / PatchScale.floatValue) * PatchScale.floatValue + (PatchScale.floatValue / 2f + Origin.vector3Value.x);
                        float f2 = Mathf.Floor((rayHit.point.z - Origin.vector3Value.z) / PatchScale.floatValue) * PatchScale.floatValue + (PatchScale.floatValue / 2f + Origin.vector3Value.z);

                        if (placeMode.enumValueIndex == 0 && fogOfWarManager.ShowGrassOptions.target)
                        {
                            float StartX = Mathf.Floor( rayHit.point.x +.5f - (float)fogOfWarManager.MultiPlaceWidth / 2f) * PatchScale.floatValue + PatchScale.floatValue / 2f;
                            float EndX = Mathf.Floor(rayHit.point.x + .5f + (float)fogOfWarManager.MultiPlaceWidth / 2f) * PatchScale.floatValue + PatchScale.floatValue / 2f - 1f;
                            float StartZ = Mathf.Floor(rayHit.point.z + .5f - (float)fogOfWarManager.MultiPlaceHeight / 2f) * PatchScale.floatValue + PatchScale.floatValue / 2f;
                            float EndZ = Mathf.Floor(rayHit.point.z + .5f + (float)fogOfWarManager.MultiPlaceHeight / 2f) * PatchScale.floatValue + PatchScale.floatValue / 2f - 1f;

                            for (float x = StartX; x <= EndX; x++)
                            {
                                for (float z = StartZ; z <= EndZ; z++)
                                {
                                    Handles.RectangleHandleCap(0, new Vector3(x, rayHit.point.y, z), Quaternion.Euler(90f, 0f, 0f), .5f * PatchScale.floatValue, EventType.Repaint);
                                    Handles.RectangleHandleCap(0, new Vector3(x, rayHit.point.y, z), Quaternion.Euler(90f, 0f, 0f), .49f * PatchScale.floatValue, EventType.Repaint);
                                    Handles.RectangleHandleCap(0, new Vector3(x, rayHit.point.y, z), Quaternion.Euler(90f, 0f, 0f), .48f * PatchScale.floatValue, EventType.Repaint);

                                    Handles.color = new Color(.5f, .2f, .0f, 1f);
                                    Handles.RectangleHandleCap(0, new Vector3(x, rayHit.point.y, z), Quaternion.Euler(90f, 0f, 0f), .47f * PatchScale.floatValue, EventType.Repaint);
                                    Handles.RectangleHandleCap(0, new Vector3(x, rayHit.point.y, z), Quaternion.Euler(90f, 0f, 0f), .46f * PatchScale.floatValue, EventType.Repaint);
                                    Handles.RectangleHandleCap(0, new Vector3(x, rayHit.point.y, z), Quaternion.Euler(90f, 0f, 0f), .45f * PatchScale.floatValue, EventType.Repaint);
                                }
                            }
                        }
                        else
                        {
                            Handles.RectangleHandleCap(0, new Vector3(f1, rayHit.point.y, f2), Quaternion.Euler(90f, 0f, 0f), .5f * PatchScale.floatValue, EventType.Repaint);
                            Handles.RectangleHandleCap(0, new Vector3(f1, rayHit.point.y, f2), Quaternion.Euler(90f, 0f, 0f), .49f * PatchScale.floatValue, EventType.Repaint);
                            Handles.RectangleHandleCap(0, new Vector3(f1, rayHit.point.y, f2), Quaternion.Euler(90f, 0f, 0f), .48f * PatchScale.floatValue, EventType.Repaint);

                            Handles.color = new Color(.953f, .659f, .157f, 1f);
                            Handles.RectangleHandleCap(0, new Vector3(f1, rayHit.point.y, f2), Quaternion.Euler(90f, 0f, 0f), .47f * PatchScale.floatValue, EventType.Repaint);
                            Handles.RectangleHandleCap(0, new Vector3(f1, rayHit.point.y, f2), Quaternion.Euler(90f, 0f, 0f), .46f * PatchScale.floatValue, EventType.Repaint);
                            Handles.RectangleHandleCap(0, new Vector3(f1, rayHit.point.y, f2), Quaternion.Euler(90f, 0f, 0f), .45f * PatchScale.floatValue, EventType.Repaint);
                        }
                        
                        DrawPreviewFieldHorizontal(rayHit.point, placeMode.enumValueIndex);
                        
                        //Handles on the side
                        Handles.color = Color.red;
                        Handles.ConeHandleCap(0, new Vector3(-1f + Origin.vector3Value.x, rayHit.point.y, rayHit.point.z), Quaternion.Euler(new Vector3(0f, 90f, 0f)), 1f, EventType.Repaint);
                        Handles.ConeHandleCap(0, new Vector3(fogOfWarManager.LevelWidth * PatchScale.floatValue + Origin.vector3Value.x + 1f, rayHit.point.y, rayHit.point.z), Quaternion.Euler(new Vector3(0f, -90f, 0f)), 1f, EventType.Repaint);

                        Handles.color = Color.blue;

                        Handles.ConeHandleCap(0, new Vector3(rayHit.point.x, rayHit.point.y, -1f + Origin.vector3Value.z), Quaternion.Euler(new Vector3(0f, 0f, 0f)), 1f, EventType.Repaint);
                        Handles.ConeHandleCap(0, new Vector3(rayHit.point.x, rayHit.point.y, fogOfWarManager.LevelWidth * PatchScale.floatValue + Origin.vector3Value.z + 1f), Quaternion.Euler(new Vector3(0f, 180f, 0f)), 1f, EventType.Repaint);
                        Handles.color = Color.white;
                    }
                    

                    //Information Text labels
                    int NewCoordinate = Mathf.FloorToInt(Mathf.Floor((rayHit.point.z - Origin.vector3Value.z) / PatchScale.floatValue) * fogOfWarManager.LevelWidth + Mathf.Floor((rayHit.point.x - Origin.vector3Value.x) / PatchScale.floatValue));
                    float CamDist = Vector3.Distance(Camera.current.transform.position, rayHit.point);

                    if (NewCoordinate < FogOfWar.ResistenceMapData.Length && NewCoordinate >= 0)
                    {
                        Handles.Label(rayHit.point + Camera.current.transform.rotation * new Vector3(0.02f, 0.1f, 0f) * CamDist, LabelTexture);
                        Handles.Label(rayHit.point + Camera.current.transform.rotation * new Vector3(0.025f, 0.095f,0f) * CamDist, "X: " + Mathf.Floor((rayHit.point.x - Origin.vector3Value.x) / PatchScale.floatValue).ToString("f0") + " Y: " + Mathf.Floor(rayHit.point.y).ToString("f0") + " Z: " + Mathf.Floor((rayHit.point.z - Origin.vector3Value.z) / PatchScale.floatValue).ToString("f0"), EditorStyles.whiteMiniLabel);

                        if (FogOfWar.ResistenceMapData[NewCoordinate].r == 0f)
                        {
                            Handles.Label(rayHit.point + Camera.current.transform.rotation * new Vector3(0.025f, 0.078f, 0f) * CamDist, "Hardblock: no", EditorStyles.whiteMiniLabel);
                        }
                        else {
                            int ID = Mathf.RoundToInt(FogOfWar.ResistenceMapData[NewCoordinate].r * 255f);
                            Handles.Label(rayHit.point + Camera.current.transform.rotation * new Vector3(0.025f, 0.078f, 0f) * CamDist, "Hardblock ID: "+ ID.ToString(), EditorStyles.whiteMiniLabel);
                        }

                        Handles.Label(rayHit.point + Camera.current.transform.rotation * new Vector3(0.025f, 0.061f, 0f) * CamDist, "Height: " + Mathf.RoundToInt(FogOfWar.ResistenceMapData[NewCoordinate].g * 255f).ToString(), EditorStyles.whiteMiniLabel);
                        Handles.Label(rayHit.point + Camera.current.transform.rotation * new Vector3(0.025f, 0.044f, 0f) * CamDist, "Vision modifier: " + Mathf.FloorToInt(FogOfWar.ResistenceMapData[NewCoordinate].a * 255), EditorStyles.whiteMiniLabel);
                    }
                }

                //Origin highlight
                Debug.DrawLine((new Vector3(0f, 0f, 0f) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(-2f, 0f, -2f) * PatchScale.floatValue) + Origin.vector3Value, new Color(.953f, .659f, .157f, 1f));

                //Side Dials
                for (float x = 0; x <= fogOfWarManager.LevelWidth; x++)
                {
                    if (x % 5 == 0)
                    {
                        Debug.DrawLine((new Vector3(x, fogOfWarManager.StartEndHeight.x, 0f) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(x, fogOfWarManager.StartEndHeight.x, -2f) * PatchScale.floatValue) + Origin.vector3Value, new Color(.953f, .659f, .157f, 1f));
                    }
                    else {
                        Debug.DrawLine((new Vector3(x, fogOfWarManager.StartEndHeight.x, 0f) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(x, fogOfWarManager.StartEndHeight.x, -.5f) * PatchScale.floatValue) + Origin.vector3Value);
                    }
                }

                for (float x = 0; x <= fogOfWarManager.LevelWidth; x++)
                {
                    if (x % 5 == 0)
                    {
                        Debug.DrawLine((new Vector3(x, fogOfWarManager.StartEndHeight.x, fogOfWarManager.LevelHeight) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(x, fogOfWarManager.StartEndHeight.x, fogOfWarManager.LevelHeight + 2f) * PatchScale.floatValue) + Origin.vector3Value, new Color(.953f, .659f, .157f, 1f));
                    }
                    else {
                        Debug.DrawLine((new Vector3(x, fogOfWarManager.StartEndHeight.x, fogOfWarManager.LevelHeight) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(x, fogOfWarManager.StartEndHeight.x, fogOfWarManager.LevelHeight + .5f) * PatchScale.floatValue) + Origin.vector3Value);
                    }
                }

                for (float y = 0; y <= fogOfWarManager.LevelHeight; y++)
                {
                    if (y % 5 == 0)
                    {
                        Debug.DrawLine((new Vector3(0f, fogOfWarManager.StartEndHeight.x, y) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(-2f, fogOfWarManager.StartEndHeight.x, y) * PatchScale.floatValue) + Origin.vector3Value, new Color(.953f, .659f, .157f, 1f));
                    }
                    else {
                        Debug.DrawLine((new Vector3(0f, fogOfWarManager.StartEndHeight.x, y) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(-0.5f, fogOfWarManager.StartEndHeight.x, y) * PatchScale.floatValue) + Origin.vector3Value);
                    }
                }

                for (float y = 0; y <= fogOfWarManager.LevelHeight; y++)
                {
                    if (y % 5 == 0)
                    {
                        Debug.DrawLine((new Vector3(fogOfWarManager.LevelWidth, fogOfWarManager.StartEndHeight.x, y) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(fogOfWarManager.LevelWidth + 2f, fogOfWarManager.StartEndHeight.x, y) * PatchScale.floatValue) + Origin.vector3Value, new Color(.953f, .659f, .157f, 1f));
                    }
                    else {
                        Debug.DrawLine((new Vector3(fogOfWarManager.LevelWidth, fogOfWarManager.StartEndHeight.x, y) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(fogOfWarManager.LevelWidth + 0.5f, fogOfWarManager.StartEndHeight.x, y) * PatchScale.floatValue) + Origin.vector3Value);
                    }
                }

                Handles.color = new Color(.953f, .659f, .157f, 1f);

                //Height elements
                for (float y = fogOfWarManager.StartEndHeight.x; y < fogOfWarManager.StartEndHeight.y + 1; y++)
                {
                    Color c = new Color(.953f,.659f,.157f,1f);

                    if (ScalePatchModifier.boolValue)
                    {
                        Vector3[] v = new Vector3[5] { (new Vector3(0.0f * PatchScale.floatValue, y, 0.0f * PatchScale.floatValue)) + Origin.vector3Value,
                        (new Vector3(fogOfWarManager.LevelWidth * PatchScale.floatValue, y, 0.0f * PatchScale.floatValue)) + Origin.vector3Value,
                        (new Vector3(fogOfWarManager.LevelWidth * PatchScale.floatValue, y, fogOfWarManager.LevelHeight * PatchScale.floatValue)) + Origin.vector3Value,
                        (new Vector3(0.0f * PatchScale.floatValue, y, fogOfWarManager.LevelHeight * PatchScale.floatValue)) + Origin.vector3Value,
                        (new Vector3(0.0f * PatchScale.floatValue, y, 0.0f * PatchScale.floatValue)) + Origin.vector3Value};

                        Handles.color = c;
                        if (y % 5 == 0)
                        {
                            Handles.DrawAAPolyLine(4f, v);
                        }
                        else {
                            Handles.DrawAAPolyLine(2f, v);
                        }
                    } else {
                        Vector3[] v = new Vector3[5] { new Vector3(0.0f, y, 0.0f),
                        new Vector3(fogOfWarManager.LevelWidth, y, 0.0f),
                        new Vector3(fogOfWarManager.LevelWidth, y, fogOfWarManager.LevelHeight),
                        new Vector3(0.0f, y, fogOfWarManager.LevelHeight),
                        new Vector3(0.0f, y, 0.0f)};

                        Handles.color = c;
                        if (y % 5 == 0)
                        {
                            Handles.DrawAAPolyLine(4f, v);
                        }
                        else {
                            Handles.DrawAAPolyLine(2f, v);
                        }
                    }
                }
            }

            //Vertical
            if (fogOfWarManager.fogAlignment == FogOfWar.FogAlignment.Vertical)
            {
                Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                RaycastHit rayHit = new RaycastHit();

                //Big arc
                float Radius = (Mathf.Sqrt(Mathf.Pow(fogOfWarManager.LevelWidth, 2) + Mathf.Pow(fogOfWarManager.LevelHeight, 2)) / 2f);
                Handles.DrawWireArc((new Vector3(fogOfWarManager.LevelWidth / 2f, fogOfWarManager.LevelHeight / 2f, 0f) * PatchScale.floatValue) + Origin.vector3Value, Vector3.forward, new Vector3(1f, 1f, 0f), 360f, Radius * PatchScale.floatValue);
                Handles.color = Color.white;
                Handles.DrawWireArc((new Vector3(fogOfWarManager.LevelWidth / 2f, fogOfWarManager.LevelHeight / 2f, 0f) * PatchScale.floatValue) + Origin.vector3Value, Vector3.forward, new Vector3(1f, 1f, 0f), 360f, Radius * PatchScale.floatValue + .1f);
                Handles.color = new Color(.953f, .659f, .157f, 1f);
                Handles.DrawWireArc((new Vector3(fogOfWarManager.LevelWidth / 2f, fogOfWarManager.LevelHeight / 2f, 0f) * PatchScale.floatValue) + Origin.vector3Value, Vector3.forward, new Vector3(1f, 1f, 0f), 360f, Radius * PatchScale.floatValue + .2f);
                Handles.DrawWireArc((new Vector3(fogOfWarManager.LevelWidth / 2f, fogOfWarManager.LevelHeight / 2f, 0f) * PatchScale.floatValue) + Origin.vector3Value, Vector3.forward, new Vector3(1f, 1f, 0f), 360f, Radius * PatchScale.floatValue + 1f);

                Handles.DrawLine((new Vector3(0f, fogOfWarManager.LevelHeight / 2f, 0f) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(-50f, fogOfWarManager.LevelHeight / 2f, 0f) * PatchScale.floatValue) + Origin.vector3Value);
                Handles.DrawLine((new Vector3(fogOfWarManager.LevelWidth, fogOfWarManager.LevelHeight / 2f, 0f) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(fogOfWarManager.LevelWidth + 50f, fogOfWarManager.LevelHeight / 2f, 0f) * PatchScale.floatValue) + Origin.vector3Value);
                Handles.DrawLine((new Vector3(fogOfWarManager.LevelWidth / 2f, 0f, 0f) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(fogOfWarManager.LevelWidth / 2f, -50f, 0f) * PatchScale.floatValue) + Origin.vector3Value);
                Handles.DrawLine((new Vector3(fogOfWarManager.LevelWidth / 2f, fogOfWarManager.LevelHeight, 0f) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(fogOfWarManager.LevelWidth / 2f, fogOfWarManager.LevelHeight + 50f, 0f) * PatchScale.floatValue) + Origin.vector3Value);

                if (Physics.Raycast(ray, out rayHit))
                {
                    //Handles on the side
                    if (rayHit.point.x >= Origin.vector3Value.x && rayHit.point.x <= fogOfWarManager.LevelWidth * PatchScale.floatValue + Origin.vector3Value.x && rayHit.point.y >= Origin.vector3Value.y && rayHit.point.y <= fogOfWarManager.LevelHeight * PatchScale.floatValue + Origin.vector3Value.y)
                    {
                        Handles.color = new Color(.953f, .659f, .157f, .4f);
                        Handles.DrawDottedLine(fogOfWarManager.transform.position, rayHit.point, 1f);
                        Handles.color = new Color(.953f, .659f, .157f, 1f);

                        //Rings on pointer
                        Handles.DrawWireArc(rayHit.point, Vector3.forward, new Vector3(1f, 1f, 0f), 360f, 1f);
                        Handles.DrawWireArc(rayHit.point, Vector3.forward, new Vector3(1f, 1f, 0f), 360f, 1.05f);
                        Handles.color = new Color(.953f, .659f, .157f, 1f);
                        Handles.DrawWireArc(rayHit.point, Vector3.forward, new Vector3(1f, 1f, 0f), 360f, 1.1f);
                        Handles.color = Color.white;

                        Handles.color = new Color(.953f, .659f, .157f, 1f);

                        //Pointer position Highlight
                        Vector3[] v = new Vector3[2] { new Vector3(0f + Origin.vector3Value.x, Mathf.Floor(rayHit.point.y / PatchScale.floatValue) * PatchScale.floatValue + PatchScale.floatValue / 2f, rayHit.point.z),
                        new Vector3(Mathf.Floor(fogOfWarManager.LevelWidth) * PatchScale.floatValue + Origin.vector3Value.x, Mathf.Floor(rayHit.point.y / PatchScale.floatValue) * PatchScale.floatValue + PatchScale.floatValue / 2f, rayHit.point.z)};

                        Handles.DrawAAPolyLine(2f, v);

                        v = new Vector3[2] { new Vector3(Mathf.Floor(rayHit.point.x / PatchScale.floatValue) * PatchScale.floatValue + PatchScale.floatValue / 2f, 0f + Origin.vector3Value.y, rayHit.point.z),
                        new Vector3(Mathf.Floor(rayHit.point.x / PatchScale.floatValue) * PatchScale.floatValue + PatchScale.floatValue / 2f, Mathf.Floor(fogOfWarManager.LevelHeight) * PatchScale.floatValue + Origin.vector3Value.y, rayHit.point.z)};

                        Handles.DrawAAPolyLine(2f, v);

                        Handles.color = Color.black;
                        float f1 = Mathf.Floor((rayHit.point.x - Origin.vector3Value.x) / PatchScale.floatValue) * PatchScale.floatValue + (PatchScale.floatValue / 2f + Origin.vector3Value.x);
                        float f2 = Mathf.Floor((rayHit.point.y - Origin.vector3Value.y) / PatchScale.floatValue) * PatchScale.floatValue + (PatchScale.floatValue / 2f + Origin.vector3Value.y);

                        if (placeMode.enumValueIndex == 0 && fogOfWarManager.ShowGrassOptions.target)
                        {
                            float StartX = Mathf.Floor(rayHit.point.x + .5f - (float)fogOfWarManager.MultiPlaceWidth / 2f) * PatchScale.floatValue + PatchScale.floatValue / 2f;
                            float EndX = Mathf.Floor(rayHit.point.x + .5f + (float)fogOfWarManager.MultiPlaceWidth / 2f) * PatchScale.floatValue + PatchScale.floatValue / 2f - 1f;
                            float StartY = Mathf.Floor(rayHit.point.y + .5f - (float)fogOfWarManager.MultiPlaceHeight / 2f) * PatchScale.floatValue + PatchScale.floatValue / 2f;
                            float EndY = Mathf.Floor(rayHit.point.y + .5f + (float)fogOfWarManager.MultiPlaceHeight / 2f) * PatchScale.floatValue + PatchScale.floatValue / 2f - 1f;

                            for (float x = StartX; x <= EndX; x++)
                            {
                                for (float y = StartY; y <= EndY; y++)
                                {
                                    Handles.RectangleHandleCap(0, new Vector3(x, y, rayHit.point.z), Quaternion.identity, .5f * PatchScale.floatValue, EventType.Repaint);
                                    Handles.RectangleHandleCap(0, new Vector3(x, y, rayHit.point.z), Quaternion.identity, .49f * PatchScale.floatValue, EventType.Repaint);
                                    Handles.RectangleHandleCap(0, new Vector3(x, y, rayHit.point.z), Quaternion.identity, .48f * PatchScale.floatValue, EventType.Repaint);

                                    Handles.color = new Color(.5f, .2f, .0f, 1f);
                                    Handles.RectangleHandleCap(0, new Vector3(x, y, rayHit.point.z), Quaternion.identity, .47f * PatchScale.floatValue, EventType.Repaint);
                                    Handles.RectangleHandleCap(0, new Vector3(x, y, rayHit.point.z), Quaternion.identity, .46f * PatchScale.floatValue, EventType.Repaint);
                                    Handles.RectangleHandleCap(0, new Vector3(x, y, rayHit.point.z), Quaternion.identity, .45f * PatchScale.floatValue, EventType.Repaint);
                                }
                            }
                        }
                        else
                        {
                            Handles.RectangleHandleCap(0, new Vector3(f1, f2, rayHit.point.z), Quaternion.identity, .5f * PatchScale.floatValue, EventType.Repaint);
                            Handles.RectangleHandleCap(0, new Vector3(f1, f2, rayHit.point.z), Quaternion.identity, .49f * PatchScale.floatValue, EventType.Repaint);
                            Handles.RectangleHandleCap(0, new Vector3(f1, f2, rayHit.point.z), Quaternion.identity, .48f * PatchScale.floatValue, EventType.Repaint);

                            Handles.color = new Color(.953f, .659f, .157f, 1f);
                            Handles.RectangleHandleCap(0, new Vector3(f1, f2, rayHit.point.z), Quaternion.identity, .47f * PatchScale.floatValue, EventType.Repaint);
                            Handles.RectangleHandleCap(0, new Vector3(f1, f2, rayHit.point.z), Quaternion.identity, .46f * PatchScale.floatValue, EventType.Repaint);
                            Handles.RectangleHandleCap(0, new Vector3(f1, f2, rayHit.point.z), Quaternion.identity, .45f * PatchScale.floatValue, EventType.Repaint);
                        }  
                        
                        DrawPreviewFieldVertical(rayHit.point, placeMode.enumValueIndex);
                        Handles.color = Color.red;
                        Handles.ConeHandleCap(0, new Vector3(-1f + Origin.vector3Value.x, rayHit.point.y, rayHit.point.z), Quaternion.Euler(new Vector3(0f, 90f, 0f)), 1f, EventType.Repaint);
                        Handles.ConeHandleCap(0, new Vector3(fogOfWarManager.LevelWidth * PatchScale.floatValue + Origin.vector3Value.y + 1f, rayHit.point.y, rayHit.point.z), Quaternion.Euler(new Vector3(0f, -90f, 0f)), 1f, EventType.Repaint);

                        Handles.color = Color.green;

                        Handles.ConeHandleCap(0, new Vector3(rayHit.point.x, -1f + Origin.vector3Value.y, rayHit.point.z), Quaternion.Euler(new Vector3(-90f, 0f, 0f)), 1f, EventType.Repaint);
                        Handles.ConeHandleCap(0, new Vector3(rayHit.point.x, fogOfWarManager.LevelHeight * PatchScale.floatValue + Origin.vector3Value.y + 1f, rayHit.point.z), Quaternion.Euler(new Vector3(90f, 0f, 0f)), 1f, EventType.Repaint);
                        Handles.color = Color.white;

                        Handles.color = Color.white;
                    }
                    

                    //Information Text labels
                    int NewCoordinate = Mathf.FloorToInt(Mathf.Floor((rayHit.point.y - Origin.vector3Value.y) / PatchScale.floatValue) * fogOfWarManager.LevelWidth + Mathf.Floor((rayHit.point.x - Origin.vector3Value.x) / PatchScale.floatValue));
                    float CamDist = Vector3.Distance(Camera.current.transform.position, rayHit.point);

                    if (NewCoordinate < FogOfWar.ResistenceMapData.Length && NewCoordinate >= 0)
                    {
                        Handles.Label(rayHit.point + Camera.current.transform.rotation * new Vector3(0.02f, 0.1f, 0f) * CamDist, LabelTexture);
                        Handles.Label(rayHit.point + Camera.current.transform.rotation * new Vector3(0.025f, 0.095f, 0f) * CamDist, "X: " + Mathf.Floor((rayHit.point.x - Origin.vector3Value.x) / PatchScale.floatValue).ToString("f0") + " Y: " + Mathf.Floor((rayHit.point.y - Origin.vector3Value.y) / PatchScale.floatValue).ToString("f0") + " Z: " + Mathf.Floor((rayHit.point.z - Origin.vector3Value.z) / PatchScale.floatValue).ToString("f0"), EditorStyles.whiteMiniLabel);

                        if (FogOfWar.ResistenceMapData[NewCoordinate].r == 0)
                        {
                            Handles.Label(rayHit.point + Camera.current.transform.rotation * new Vector3(0.025f, 0.078f, 0f) * CamDist, "Hardblock: no", EditorStyles.whiteMiniLabel);
                        }
                        else
                        {
                            int ID = Mathf.RoundToInt(FogOfWar.ResistenceMapData[NewCoordinate].r * 255f);
                            Handles.Label(rayHit.point + Camera.current.transform.rotation * new Vector3(0.025f, 0.078f, 0f) * CamDist, "Hardblock ID: " + ID.ToString(), EditorStyles.whiteMiniLabel);
                        }

                        Handles.Label(rayHit.point + Camera.current.transform.rotation * new Vector3(0.025f, 0.061f, 0f) * CamDist, "Height: " + (FogOfWar.ResistenceMapData[NewCoordinate].g * 255).ToString(), EditorStyles.whiteMiniLabel);

                        Handles.Label(rayHit.point + Camera.current.transform.rotation * new Vector3(0.025f, 0.044f, 0f) * CamDist, "Vision modifier: " + Mathf.FloorToInt(FogOfWar.ResistenceMapData[NewCoordinate].a * 255), EditorStyles.whiteMiniLabel);
                    }
                }

                //Origin highlight
                Debug.DrawLine((new Vector3(0f, 0f, 0f) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(-2f, -2f, 0f) * PatchScale.floatValue) + Origin.vector3Value, new Color(.953f, .659f, .157f, 1f));

                //Side Dials
                for (float x = 0; x <= fogOfWarManager.LevelWidth; x++)
                {
                    if (x % 5 == 0)
                    {
                        Debug.DrawLine((new Vector3(x, 0f, fogOfWarManager.StartEndHeight.x) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(x, -2f, fogOfWarManager.StartEndHeight.x) * PatchScale.floatValue) + Origin.vector3Value, new Color(.953f, .659f, .157f, 1f));
                    } else {
                        Debug.DrawLine((new Vector3(x, 0f, fogOfWarManager.StartEndHeight.x) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(x, -.5f, fogOfWarManager.StartEndHeight.x) * PatchScale.floatValue) + Origin.vector3Value);
                    }
                }

                for (float x = 0; x <= fogOfWarManager.LevelWidth; x++)
                {
                    if (x % 5 == 0)
                    {
                        Debug.DrawLine((new Vector3(x, fogOfWarManager.LevelHeight, fogOfWarManager.StartEndHeight.x) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(x, fogOfWarManager.LevelHeight + 2f, fogOfWarManager.StartEndHeight.x) * PatchScale.floatValue) + Origin.vector3Value, new Color(.953f, .659f, .157f, 1f));
                    } else {
                        Debug.DrawLine((new Vector3(x, fogOfWarManager.LevelHeight, fogOfWarManager.StartEndHeight.x) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(x, fogOfWarManager.LevelHeight + .5f, fogOfWarManager.StartEndHeight.x) * PatchScale.floatValue) + Origin.vector3Value);
                    }
                }

                for (float y = 0; y <= fogOfWarManager.LevelHeight; y++)
                {
                    if (y % 5 == 0)
                    {
                        Debug.DrawLine((new Vector3(0f, y, fogOfWarManager.StartEndHeight.x) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(-2f, y, fogOfWarManager.StartEndHeight.x) * PatchScale.floatValue) + Origin.vector3Value, new Color(.953f, .659f, .157f, 1f));
                    } else {
                        Debug.DrawLine((new Vector3(0f, y, fogOfWarManager.StartEndHeight.x) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(-0.5f, y, fogOfWarManager.StartEndHeight.x) * PatchScale.floatValue) + Origin.vector3Value);
                    }
                }

                for (float y = 0; y <= fogOfWarManager.LevelHeight; y++)
                {
                    if (y % 5 == 0)
                    {
                        Debug.DrawLine((new Vector3(fogOfWarManager.LevelWidth, y, fogOfWarManager.StartEndHeight.x) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(fogOfWarManager.LevelWidth + 2f, y, fogOfWarManager.StartEndHeight.x) * PatchScale.floatValue) + Origin.vector3Value, new Color(.953f, .659f, .157f, 1f));
                    } else {
                        Debug.DrawLine((new Vector3(fogOfWarManager.LevelWidth, y, fogOfWarManager.StartEndHeight.x) * PatchScale.floatValue) + Origin.vector3Value, (new Vector3(fogOfWarManager.LevelWidth + 0.5f, y, fogOfWarManager.StartEndHeight.x) * PatchScale.floatValue) + Origin.vector3Value);
                    }
                }

                Handles.color = new Color(.953f, .659f, .157f, 1f);

                //Hight elements
                for (float y = fogOfWarManager.StartEndHeight.x; y < fogOfWarManager.StartEndHeight.y + 1; y++)
                {
                    Color c = new Color(.953f, .659f, .157f, 1f);

                    if (ScalePatchModifier.boolValue)
                    {
                        Vector3[] v = new Vector3[5] { (new Vector3(0.0f * PatchScale.floatValue, 0.0f * PatchScale.floatValue, -y)) +Origin.vector3Value,
                        (new Vector3(fogOfWarManager.LevelWidth * PatchScale.floatValue, 0.0f * PatchScale.floatValue, -y)) +Origin.vector3Value,
                        (new Vector3(fogOfWarManager.LevelWidth * PatchScale.floatValue, fogOfWarManager.LevelHeight * PatchScale.floatValue, -y)) +Origin.vector3Value,
                        (new Vector3(0.0f * PatchScale.floatValue, fogOfWarManager.LevelHeight * PatchScale.floatValue, -y)) +Origin.vector3Value,
                        (new Vector3(0.0f * PatchScale.floatValue, 0.0f * PatchScale.floatValue, -y)) +Origin.vector3Value};

                        Handles.color = c;

                        if (y % 5 == 0)
                        {
                            Handles.DrawAAPolyLine(4f, v);
                        }
                        else {
                            Handles.DrawAAPolyLine(2f, v);
                        }
                    } else {
                        Vector3[] v = new Vector3[5] { new Vector3(0.0f, 0.0f, -y),
                        new Vector3(fogOfWarManager.LevelWidth, 0.0f, -y),
                        new Vector3(fogOfWarManager.LevelWidth, fogOfWarManager.LevelHeight, -y),
                        new Vector3(0.0f, fogOfWarManager.LevelHeight, -y),
                        new Vector3(0.0f, 0.0f, -y)};

                        Handles.color = c;

                        if (y % 5 == 0)
                        {
                            Handles.DrawAAPolyLine(4f, v);
                        }
                        else {
                            Handles.DrawAAPolyLine(2f, v);
                        }
                    }
                    
                }
            }
        }
    }

    private void DrawPreviewFieldVertical(Vector3 _Position, int _PlaceMode)
    {
        float f1 = Mathf.Floor((_Position.x - Origin.vector3Value.x) / PatchScale.floatValue) * PatchScale.floatValue + (PatchScale.floatValue / 2f + Origin.vector3Value.x);
        float f2 = Mathf.Floor((_Position.y - Origin.vector3Value.y) / PatchScale.floatValue) * PatchScale.floatValue + (PatchScale.floatValue / 2f + Origin.vector3Value.y);

        Vector3 InitialPoint = new Vector3(f1, f2, _Position.z);

        for (float x = (InitialPoint.x - 4 * PatchScale.floatValue); x < (InitialPoint.x + 5 * PatchScale.floatValue); x += PatchScale.floatValue)
        {
            if (x < Origin.vector3Value.x || x >= fogOfWarManager.LevelWidth * PatchScale.floatValue + Origin.vector3Value.x)
                continue;


            for (float y = (InitialPoint.y - 4 * PatchScale.floatValue); y < (InitialPoint.y + 5 * PatchScale.floatValue); y += PatchScale.floatValue)
            {
                if (y < Origin.vector3Value.y || y > fogOfWarManager.LevelHeight * PatchScale.floatValue + Origin.vector3Value.y)
                    continue;

                Handles.color = new Color(.4f,.4f,.4f,1f);
                Handles.RectangleHandleCap(0, new Vector3(x, y, _Position.z), Quaternion.identity, .49f * PatchScale.floatValue, EventType.Repaint);

                int coord = Mathf.FloorToInt(Mathf.Floor((y - Origin.vector3Value.y) / PatchScale.floatValue) * fogOfWarManager.LevelWidth + Mathf.Floor((x - Origin.vector3Value.x) / PatchScale.floatValue));

                if (coord >= FogOfWar.ResistenceMapData.Length || coord < 0)
                    return;

                if (_PlaceMode == 0)
                {
                    if (FogOfWar.ResistenceMapData[coord].r != 0f)
                    {
                        Handles.color = new Color(.953f, .659f, .157f, 1f);
                        Handles.RectangleHandleCap(0, new Vector3(x, y, _Position.z), Quaternion.identity, .38f * PatchScale.floatValue, EventType.Repaint);
                        Handles.RectangleHandleCap(0, new Vector3(x, y, _Position.z), Quaternion.identity, .37f * PatchScale.floatValue, EventType.Repaint);
                        Handles.RectangleHandleCap(0, new Vector3(x, y, _Position.z), Quaternion.identity, .36f * PatchScale.floatValue, EventType.Repaint);

                        Handles.color = new Color(.5f, .2f, 0f, 1f);
                        Handles.RectangleHandleCap(0, new Vector3(x, y, _Position.z), Quaternion.identity, .35f * PatchScale.floatValue, EventType.Repaint);
                        Handles.RectangleHandleCap(0, new Vector3(x, y, _Position.z), Quaternion.identity, .34f * PatchScale.floatValue, EventType.Repaint);
                        Handles.RectangleHandleCap(0, new Vector3(x, y, _Position.z), Quaternion.identity, .33f * PatchScale.floatValue, EventType.Repaint);
                    }
                } else if (_PlaceMode == 1)  {
                    Handles.color = new Color(.953f, .659f, .157f, 1f);
                    float height = (fogOfWarManager.StartEndHeight.y - fogOfWarManager.StartEndHeight.x) * FogOfWar.ResistenceMapData[coord].g;
                    Handles.RectangleHandleCap(0, new Vector3(x, y, Origin.vector3Value.z + height), Quaternion.Euler(90f, 0f, 0f), .49f * PatchScale.floatValue, EventType.Repaint);
                } else if (_PlaceMode == 2) {
                    if (FogOfWar.ResistenceMapData[coord].a != 1f)
                    {
                        Handles.color = new Color(.953f, .659f, .157f, 1f);
                        Handles.RectangleHandleCap(0, new Vector3(x, y, _Position.z), Quaternion.identity, .48f * PatchScale.floatValue, EventType.Repaint);
                        Handles.RectangleHandleCap(0, new Vector3(x, y, _Position.z), Quaternion.identity, .47f * PatchScale.floatValue, EventType.Repaint);
                        Handles.RectangleHandleCap(0, new Vector3(x, y, _Position.z), Quaternion.identity, .46f * PatchScale.floatValue, EventType.Repaint);

                        Handles.color = new Color(.5f, 0f, 0f, 1f);
                        Handles.RectangleHandleCap(0, new Vector3(x, y, _Position.z), Quaternion.identity, .45f * PatchScale.floatValue, EventType.Repaint);
                        Handles.RectangleHandleCap(0, new Vector3(x, y, _Position.z), Quaternion.identity, .44f * PatchScale.floatValue, EventType.Repaint);
                        Handles.RectangleHandleCap(0, new Vector3(x, y, _Position.z), Quaternion.identity, .43f * PatchScale.floatValue, EventType.Repaint);
                    }
                } else if (fogOfWarManager.FogGO[coord] != null && _PlaceMode == 3) {

                    Handles.color = new Color(.953f, .659f, .157f, 1f);
                    Handles.RectangleHandleCap(0, new Vector3(x, y, _Position.z), Quaternion.identity, .48f * PatchScale.floatValue, EventType.Repaint);
                    Handles.RectangleHandleCap(0, new Vector3(x, y, _Position.z), Quaternion.identity, .47f * PatchScale.floatValue, EventType.Repaint);
                    Handles.RectangleHandleCap(0, new Vector3(x, y, _Position.z), Quaternion.identity, .46f * PatchScale.floatValue, EventType.Repaint);

                    Handles.color = new Color(.5f, 0f, 0f, 1f);
                    Handles.RectangleHandleCap(0, new Vector3(x, y, _Position.z), Quaternion.identity, .45f * PatchScale.floatValue, EventType.Repaint);
                    Handles.RectangleHandleCap(0, new Vector3(x, y, _Position.z), Quaternion.identity, .44f * PatchScale.floatValue, EventType.Repaint);
                    Handles.RectangleHandleCap(0, new Vector3(x, y, _Position.z), Quaternion.identity, .43f * PatchScale.floatValue, EventType.Repaint);
                }
                Handles.color = new Color(.953f, .659f, .157f, 1f);
            }
        }
    }

    private void DrawPreviewFieldHorizontal(Vector3 _Position, int _PlaceMode)
    {
        float f1 = Mathf.Floor((_Position.x - Origin.vector3Value.x) / PatchScale.floatValue) * PatchScale.floatValue + (PatchScale.floatValue / 2f + Origin.vector3Value.x);
        float f2 = Mathf.Floor((_Position.z - Origin.vector3Value.z) / PatchScale.floatValue) * PatchScale.floatValue + (PatchScale.floatValue / 2f + Origin.vector3Value.z);

        Vector3 InitialPoint = new Vector3(f1, _Position.y, f2);

        for (float x = (InitialPoint.x - 4 * PatchScale.floatValue) ; x < (InitialPoint.x + 5 * PatchScale.floatValue); x += PatchScale.floatValue)
        {
            if (x < Origin.vector3Value.x || x >= fogOfWarManager.LevelWidth * PatchScale.floatValue + Origin.vector3Value.x)
                continue;

            for (float z = (InitialPoint.z - 4 * PatchScale.floatValue) ; z < (InitialPoint.z + 5 * PatchScale.floatValue); z += PatchScale.floatValue)
            {
                if (z < Origin.vector3Value.z || z > fogOfWarManager.LevelHeight * PatchScale.floatValue + Origin.vector3Value.z)
                    continue;
                
                if((_PlaceMode != 1))
                    Handles.RectangleHandleCap(0, new Vector3(x, _Position.y, z), Quaternion.Euler(90f, 0f, 0f), .49f * PatchScale.floatValue, EventType.Repaint);

                int coord = Mathf.FloorToInt(Mathf.Floor((z - Origin.vector3Value.z) / PatchScale.floatValue) * fogOfWarManager.LevelWidth + Mathf.Floor((x - Origin.vector3Value.x) / PatchScale.floatValue));

                if (coord >= FogOfWar.ResistenceMapData.Length || coord < 0)
                    return;

                if (_PlaceMode == 0)
                {
                    if (FogOfWar.ResistenceMapData[coord].r != 0f)
                    {
                        Handles.color = new Color(.953f, .659f, .157f, 1f);
                        Handles.RectangleHandleCap(0, new Vector3(x, _Position.y, z), Quaternion.Euler(90f, 0f, 0f), .38f * PatchScale.floatValue, EventType.Repaint);
                        Handles.RectangleHandleCap(0, new Vector3(x, _Position.y, z), Quaternion.Euler(90f, 0f, 0f), .37f * PatchScale.floatValue, EventType.Repaint);
                        Handles.RectangleHandleCap(0, new Vector3(x, _Position.y, z), Quaternion.Euler(90f, 0f, 0f), .36f * PatchScale.floatValue, EventType.Repaint);

                        Handles.color = new Color(.5f, .2f, 0f, 1f);
                        Handles.RectangleHandleCap(0, new Vector3(x, _Position.y, z), Quaternion.Euler(90f, 0f, 0f), .35f * PatchScale.floatValue, EventType.Repaint);
                        Handles.RectangleHandleCap(0, new Vector3(x, _Position.y, z), Quaternion.Euler(90f, 0f, 0f), .34f * PatchScale.floatValue, EventType.Repaint);
                        Handles.RectangleHandleCap(0, new Vector3(x, _Position.y, z), Quaternion.Euler(90f, 0f, 0f), .33f * PatchScale.floatValue, EventType.Repaint);
                    }
                } else if (_PlaceMode == 1) {
                    Handles.color = new Color(.953f, .659f, .157f, 1f);
                    float height = (fogOfWarManager.StartEndHeight.y - fogOfWarManager.StartEndHeight.x) * FogOfWar.ResistenceMapData[coord].g;
                    Handles.RectangleHandleCap(0, new Vector3(x, Origin.vector3Value.y + height, z), Quaternion.Euler(90f, 0f, 0f), .49f * PatchScale.floatValue, EventType.Repaint);
                } else if (_PlaceMode == 2) {
                    if (FogOfWar.ResistenceMapData[coord].a != 1f)
                    {
                        Handles.color = new Color(.953f, .659f, .157f, 1f);
                        Handles.RectangleHandleCap(0, new Vector3(x, _Position.y, z), Quaternion.Euler(90f, 0f, 0f), .48f * PatchScale.floatValue, EventType.Repaint);
                        Handles.RectangleHandleCap(0, new Vector3(x, _Position.y, z), Quaternion.Euler(90f, 0f, 0f), .47f * PatchScale.floatValue, EventType.Repaint);
                        Handles.RectangleHandleCap(0, new Vector3(x, _Position.y, z), Quaternion.Euler(90f, 0f, 0f), .46f * PatchScale.floatValue, EventType.Repaint);

                        Handles.color = new Color(.5f, 0f, 0f, 1f);
                        Handles.RectangleHandleCap(0, new Vector3(x, _Position.y, z), Quaternion.Euler(90f, 0f, 0f), .45f * PatchScale.floatValue, EventType.Repaint);
                        Handles.RectangleHandleCap(0, new Vector3(x, _Position.y, z), Quaternion.Euler(90f, 0f, 0f), .44f * PatchScale.floatValue, EventType.Repaint);
                        Handles.RectangleHandleCap(0, new Vector3(x, _Position.y, z), Quaternion.Euler(90f, 0f, 0f), .43f * PatchScale.floatValue, EventType.Repaint);
                    }
                } else if (fogOfWarManager.FogGO[coord] != null && _PlaceMode == 3) {
                    Handles.color = new Color(.953f, .659f, .157f, 1f);
                    Handles.RectangleHandleCap(0, new Vector3(x, _Position.y, z), Quaternion.Euler(90f, 0f, 0f), .48f * PatchScale.floatValue, EventType.Repaint);
                    Handles.RectangleHandleCap(0, new Vector3(x, _Position.y, z), Quaternion.Euler(90f, 0f, 0f), .47f * PatchScale.floatValue, EventType.Repaint);
                    Handles.RectangleHandleCap(0, new Vector3(x, _Position.y, z), Quaternion.Euler(90f, 0f, 0f), .46f * PatchScale.floatValue, EventType.Repaint);

                    Handles.color = new Color(.5f, 0f, 0f, 1f);
                    Handles.RectangleHandleCap(0, new Vector3(x, _Position.y, z), Quaternion.Euler(90f, 0f, 0f), .45f * PatchScale.floatValue, EventType.Repaint);
                    Handles.RectangleHandleCap(0, new Vector3(x, _Position.y, z), Quaternion.Euler(90f, 0f, 0f), .44f * PatchScale.floatValue, EventType.Repaint);
                    Handles.RectangleHandleCap(0, new Vector3(x, _Position.y, z), Quaternion.Euler(90f, 0f, 0f), .43f * PatchScale.floatValue, EventType.Repaint);
                }
                Handles.color = new Color(.953f, .659f, .157f, 1f);
            }
        }
    }

    private void SavePNGToDisc()
    {
        if (fogOfWarManager.ResitenceMapPath == null || fogOfWarManager.ResitenceMapPath == "")
            fogOfWarManager.ResitenceMapPath = EditorUtility.SaveFilePanelInProject("Save Level", fogOfWarManager.LevelName, "png", "Please enter a file name to save the texture to");

        if (fogOfWarManager.ResitenceMapPath != null && fogOfWarManager.ResitenceMapPath != "")
        {
            byte[] pngData = fogOfWarManager.GetResistenceMap().EncodeToPNG();

            if (pngData != null)
            {
                File.WriteAllBytes(fogOfWarManager.ResitenceMapPath, pngData);
                Debug.Log("Changes saved to disc: " + fogOfWarManager.ResitenceMapPath);
            }

            fogOfWarManager.SetResistenceMap(fogOfWarManager.ResitenceMapPath);
        }
    }
}
