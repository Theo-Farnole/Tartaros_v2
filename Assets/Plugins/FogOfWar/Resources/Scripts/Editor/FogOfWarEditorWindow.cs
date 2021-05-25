using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEditor.AnimatedValues;
using System.IO;

public class FogOfWarEditorWindow : EditorWindow
{
    private int CurrentStage = 0;
    private AnimBool Group0;
    private AnimBool Group1;
    private AnimBool Group2;
    private bool CreateTerrain = true;
    private bool SaveTerrainData = true;
    private bool CreateCanvas = true;

    private FogOfWar.MapSizes MapSizeX = FogOfWar.MapSizes._128;
    private FogOfWar.MapSizes MapSizeZ = FogOfWar.MapSizes._128;
    private int Overshoot = 0;
    private Vector2 MinMaxHeight = new Vector2(0f, 15f);
    private float RevealOpacity = 1f;
    private float CoveredOpacity = 0.5f;
    private float UndiscoveredOpacity = 0.1f;
    private FogOfWar.FogQuality BlurQuality = FogOfWar.FogQuality.On;
    private FogOfWar.TerrainMaterial TerrainMat;
    private FilterMode FogFilterMode = FilterMode.Bilinear;
    private Terrain FOWTerrain;
    private bool BorderResistenceMap = true;
    private bool MakeTerrain = true;

    private string FileLocation = "";

    private Texture2D TerrainTexture;
    private Texture2D CanvasTexture;
    private Material TerrainMatPreview;
    private EditorWindow window;

    [MenuItem("Fog of War/New Fog of War Manager")]
    public static void ShowWindow()
    {
        EditorWindow window = EditorWindow.GetWindow(typeof(FogOfWarEditorWindow), true, "Fog of War Editor");
        //window.position = new Rect(Screen.width/2f,Screen.height/2f,610f,310f);
        window.maxSize = new Vector2(610f, 310f);
        window.minSize = new Vector2(610f, 310f);
    }

    [MenuItem("Fog of War/Add Revealer")]
    public static void AddRevealer()
    {
        if (FogOfWar.fogAlignment == FogOfWar.FogAlignment.Horizontal)
        {
            GameObject g = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            g.name = "Revealer";
            g.AddComponent<ExampleUnit>();
        }

        if (FogOfWar.fogAlignment == FogOfWar.FogAlignment.Vertical)
        {
            GameObject g = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            g.name = "Revealer";
            g.AddComponent<ExampleUnit>();
        }
    }

    [MenuItem("Fog of War/Add Blocker")]
    public static void AddBlocker()
    {
        if (FogOfWar.fogAlignment == FogOfWar.FogAlignment.Horizontal)
        {
            GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
            g.name = "Blocker";
            g.AddComponent<ExampleVisionBlocker>();
        }

        if (FogOfWar.fogAlignment == FogOfWar.FogAlignment.Vertical)
        {
            GameObject g = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            g.name = "Revealer";
            g.AddComponent<ExampleUnit>();
        }
    }

    void OnEnable()
    {
        Group0 = new AnimBool(false);
        Group0.valueChanged.AddListener(Repaint);
        Group1 = new AnimBool(false);
        Group1.valueChanged.AddListener(Repaint);
        Group2 = new AnimBool(false);
        Group2.valueChanged.AddListener(Repaint);

        if (TerrainTexture == null)
            TerrainTexture = Resources.Load("Textures/Editor/Terrain") as Texture2D;

        if (CanvasTexture == null)
            CanvasTexture = Resources.Load("Textures/Editor/Canvas") as Texture2D;

        if (TerrainMatPreview == null)
            TerrainMatPreview = new Material(Shader.Find("Hidden/UltimateFogOfWar/Debug/GUITexture"));
    }

    void OnGUI()
    {
        if (CurrentStage == 0)
        {
            Group0.target = true;
        }
        else {
            Group0.target = false;
        }

        if (Group0.target == true)
        {
            GUILayout.FlexibleSpace();
            EditorGUILayout.BeginFadeGroup(Group0.faded);
            {
                EditorGUILayout.BeginVertical("Button");
                {
                    EditorGUILayout.BeginHorizontal();
                    {
                        GUILayout.FlexibleSpace();
                        EditorGUILayout.LabelField("Choose Fog of War Type", EditorStyles.boldLabel);
                        GUILayout.FlexibleSpace();
                    }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    {
                        EditorGUILayout.BeginVertical("Window");
                        {
                            Rect rect = GUILayoutUtility.GetRect(Screen.width / 2f - 25f, 150f);

                            if (GUILayout.Button("Terrain (Horizontal)", GUILayout.MinWidth(150f), GUILayout.MinHeight(50f)))
                            {
                                MakeTerrain = true;
                                if (CurrentStage == 0)
                                    CurrentStage++;
                            }
                            EditorGUI.DrawPreviewTexture(rect, TerrainTexture, TerrainMatPreview, ScaleMode.ScaleAndCrop);

                            EditorGUILayout.LabelField("In this mode, the Fog of War is simulated on the X & Z axis. Pick this for RTS or Moba games.", EditorStyles.helpBox);
                        }
                        EditorGUILayout.EndVertical();

                        GUILayout.Space(5f);

                        EditorGUILayout.BeginVertical("Window");
                        {
                            Rect rect = GUILayoutUtility.GetRect(Screen.width / 2f - 25f, 150f);
                            if (GUILayout.Button("Canvas (Vertical)", GUILayout.MinWidth(150f), GUILayout.MinHeight(50f)))
                            {
                                MakeTerrain = false;
                                if (CurrentStage == 0)
                                    CurrentStage++;
                            }
                            EditorGUI.DrawPreviewTexture(rect, CanvasTexture, TerrainMatPreview, ScaleMode.ScaleAndCrop);

                            EditorGUILayout.LabelField("In this mode, the Fog of War is simulated on the X & Y axis. Pick this for Platformers or Sprite based games.", EditorStyles.helpBox);
                        }
                        EditorGUILayout.EndVertical();
                    }
                    EditorGUILayout.EndHorizontal();

                    //GUILayout.Space(5f);
                    GUI.color = Color.yellow;
                    EditorGUILayout.BeginHorizontal();
                    {
                        GUILayout.FlexibleSpace();
                        EditorGUILayout.LabelField("This setting cannot be changed later!", EditorStyles.helpBox);
                        GUILayout.FlexibleSpace();
                    }
                    EditorGUILayout.EndHorizontal();
                    //GUILayout.Space(5f);
                }
                EditorGUILayout.EndVertical();
            }
        }
        EditorGUILayout.EndFadeGroup();

        

        if (CurrentStage == 1)
        {
            Group1.target = true;
        }
        else {
            Group1.target = false;
        }

        if (Group1.target == true)
        {
            EditorGUILayout.BeginVertical("Button");
            {
                if (MakeTerrain)
                {
                    EditorGUILayout.BeginHorizontal();
                    {
                        GUILayout.FlexibleSpace();
                        GUILayout.FlexibleSpace();
                        EditorGUILayout.LabelField("New Terrain", EditorStyles.largeLabel);
                        GUILayout.FlexibleSpace();
                    }
                    EditorGUILayout.EndHorizontal();
                } else {
                    EditorGUILayout.BeginHorizontal();
                    {
                        GUILayout.FlexibleSpace();
                        GUILayout.FlexibleSpace();
                        EditorGUILayout.LabelField("New Canvas", EditorStyles.largeLabel);
                        GUILayout.FlexibleSpace();
                    }
                    EditorGUILayout.EndHorizontal();
                }
            
                GUILayout.FlexibleSpace();
                EditorGUILayout.BeginFadeGroup(Group1.faded);
                {
                
                        EditorGUILayout.BeginVertical("Box");
                    {
                        EditorGUILayout.LabelField("Map Size", EditorStyles.boldLabel);

                        EditorGUILayout.BeginHorizontal();
                        {
                            MapSizeX = (FogOfWar.MapSizes)EditorGUILayout.EnumPopup("Width: ", MapSizeX);

                            if (MakeTerrain)
                            {
                                MapSizeZ = (FogOfWar.MapSizes)EditorGUILayout.EnumPopup("Depth: ", MapSizeZ);
                            }
                            else{
                                MapSizeZ = (FogOfWar.MapSizes)EditorGUILayout.EnumPopup("Height: ", MapSizeZ);
                            }
                                
                        }
                        EditorGUILayout.EndHorizontal();

                        EditorGUILayout.BeginHorizontal();
                        {
                            Overshoot = EditorGUILayout.IntSlider("Overshoot:", Overshoot, 0, 100);
                            EditorGUILayout.PrefixLabel("Border Map");
                            BorderResistenceMap = EditorGUILayout.Toggle(BorderResistenceMap);
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                    EditorGUILayout.EndVertical();

                    EditorGUILayout.BeginVertical("Box");
                    {

                        EditorGUILayout.LabelField("Scale and Height", EditorStyles.boldLabel);
                        EditorGUILayout.BeginHorizontal();
                        {
                            EditorGUILayout.PrefixLabel("Height (Min/Max)");
                            MinMaxHeight = EditorGUILayout.Vector2Field("", MinMaxHeight);
                            MinMaxHeight.x = 0f;
                            EditorGUILayout.LabelField(new GUIContent("Precision: "+MinMaxHeight.y/ 255f,"The maximum height precision is limited to 256 steps. (255 / "+ MinMaxHeight.y+")"));
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                    EditorGUILayout.EndVertical();

                    EditorGUILayout.BeginVertical("Box");
                    {
                        EditorGUILayout.LabelField("Fog Opacity", EditorStyles.boldLabel);

                        EditorGUILayout.BeginHorizontal();
                        {
                            EditorGUILayout.PrefixLabel("Revealed");
                            RevealOpacity = EditorGUILayout.Slider(RevealOpacity, 0f, 1f);
                        }
                        EditorGUILayout.EndHorizontal();

                        EditorGUILayout.BeginHorizontal();
                        {
                            EditorGUILayout.PrefixLabel("Covered");
                            CoveredOpacity = EditorGUILayout.Slider(CoveredOpacity, 0f, 1f);
                        }
                        EditorGUILayout.EndHorizontal();

                        EditorGUILayout.BeginHorizontal();
                        {
                            EditorGUILayout.PrefixLabel("Unrevealed");
                            UndiscoveredOpacity = EditorGUILayout.Slider(UndiscoveredOpacity, 0f, 1f);
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                    EditorGUILayout.EndVertical();

                    EditorGUILayout.BeginVertical("Box");
                    {
                        EditorGUILayout.LabelField("Other Options", EditorStyles.boldLabel);

                        if (MakeTerrain)
                        {
                            EditorGUILayout.BeginHorizontal();
                            {
                                TerrainMat = (FogOfWar.TerrainMaterial)EditorGUILayout.EnumPopup("Terrain Material: ", TerrainMat, GUILayout.MaxWidth(Screen.width / 2f));

                            }
                            EditorGUILayout.EndHorizontal();
                        }

                        EditorGUILayout.BeginHorizontal();
                        {
                            BlurQuality = (FogOfWar.FogQuality)EditorGUILayout.EnumPopup("Blur Fog of War: ", BlurQuality, GUILayout.MaxWidth(Screen.width / 2f));
                            FogFilterMode = (FilterMode)EditorGUILayout.EnumPopup("Filter: ", FogFilterMode, GUILayout.MaxWidth(Screen.width / 2f));
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndFadeGroup();
            }
            EditorGUILayout.EndVertical();
            GUILayout.FlexibleSpace();
        }
        if (CurrentStage == 1)
        {
            EditorGUILayout.BeginHorizontal();
            {
                if (GUILayout.Button("<| Back"))
                {
                    CurrentStage--;
                }
                GUILayout.FlexibleSpace();

                if (CurrentStage == 1)
                {
                    GUI.color = Color.green;
                }

                if (GUILayout.Button("Next Step |>"))
                {
                    if (CurrentStage == 1)
                        CurrentStage++;
                }
                GUI.color = Color.white;
            }
            EditorGUILayout.EndHorizontal();
        }

        if (CurrentStage == 2)
        {
            Group2.target = true;
        }
        else {
            Group2.target = false;
        }

        if (Group2.target == true)
        {
            GUILayout.FlexibleSpace();
            EditorGUILayout.BeginFadeGroup(Group2.faded);
            {
                EditorGUILayout.BeginVertical("Button");
                {
                    EditorGUILayout.LabelField("Choose the file location:");

                    EditorGUILayout.BeginHorizontal();
                    {
                        if (GUILayout.Button(">Pick<", EditorStyles.toolbarButton, GUILayout.MaxWidth(Screen.width * 0.3f)))
                        {
                            FileLocation = EditorUtility.SaveFilePanelInProject("Pick file location", "New Level", "png", "Please enter a file name to save the texture to");

                            if (FileLocation != "")
                            {
                                if (!FileLocation.Contains("_ResistenceMap"))
                                    FileLocation = FileLocation.Insert(FileLocation.Length - 4, "_ResistenceMap");
                            }
                        }

                        if (FileLocation == "")
                        {
                            GUI.color = new Color(0.8f,0,0,1f);
                        }

                        GUILayout.Button(FileLocation, EditorStyles.toolbarButton, GUILayout.MaxWidth(Screen.width * 0.7f));
                        GUI.color = Color.white;
                    }
                    EditorGUILayout.EndHorizontal();

                    if (MakeTerrain)
                    {
                        CreateTerrain = EditorGUILayout.Toggle("Create Terrain", CreateTerrain, GUILayout.MaxWidth(Screen.width / 2f));

                        EditorGUI.BeginDisabledGroup(!CreateTerrain);
                        {
                            SaveTerrainData = EditorGUILayout.Toggle("Save Terrain Data", SaveTerrainData, GUILayout.MaxWidth(Screen.width / 2f));
                        }
                        EditorGUI.EndDisabledGroup();
                            
                    }
                    else {
                        CreateCanvas = EditorGUILayout.Toggle("Create Canvas", CreateCanvas, GUILayout.MaxWidth(Screen.width / 2f));
                    }
                        
                }
                EditorGUILayout.EndVertical();

                
                GUILayout.FlexibleSpace();
            }
            EditorGUILayout.EndFadeGroup();

            if (CurrentStage == 2)
            {
                EditorGUILayout.BeginHorizontal();
                {
                    if (GUILayout.Button("<| Back"))
                    {
                        CurrentStage--;
                    }
                    GUILayout.FlexibleSpace();

                    if (CurrentStage == 2)
                    {
                        if (FileLocation != "")
                        {
                            GUI.color = Color.green;
                        }
                        else {
                            GUI.color = new Color(0.8f, 0, 0, 1f);
                        }
                    }

                    if (GUILayout.Button("Create |>"))
                    {
                        if (MakeTerrain)
                        {
                            SaveAndCreateTerrain();
                        }
                        else {
                            SaveAndCreateCanvas();
                        }

                        this.Close();
                    }
                    GUI.color = Color.white;
                }
                EditorGUILayout.EndHorizontal();
            }
        }
    }

    private void SaveAndCreateCanvas()
    {
        int width = int.Parse(MapSizeX.ToString().Remove(0, 1));
        int height = int.Parse(MapSizeZ.ToString().Remove(0, 1));

        Texture2D ResistanceMap = new Texture2D(width, height);
        Color[] c = new Color[width * height];

        for (int i = 0; i < c.Length; i++)
        {
            c[i] = new Color(0f, 0f, 0f, 1f);
        }

        if (BorderResistenceMap)
        {
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    int coord = z * width + x;

                    if (x == 0 || x == width - 1 || z == 0 || z == height - 1)
                    {
                        c[coord].r = 1f;
                    }
                }
            }
        }

        ResistanceMap.SetPixels(c);
        byte[] pngData = ResistanceMap.EncodeToPNG();

        if (pngData != null)
        {
            File.WriteAllBytes(FileLocation, pngData);
        }

        AssetDatabase.Refresh();

        GameObject g = new GameObject("Fog of War Manager");
        FogOfWarManager manager = g.AddComponent<FogOfWarManager>();

        string PathOnly = FileLocation;

        for (int i = PathOnly.Length - 1; i > 0; i--)
        {
            if (PathOnly[i] == '/')
            {
                PathOnly = PathOnly.Remove(i + 1, PathOnly.Length - i - 1);
                break;
            }
        }

        manager.fogAlignment = FogOfWar.FogAlignment.Vertical;

        GameObject FogCanvas = new GameObject("Canvas");
        FogCanvas.AddComponent<Canvas>();
        RectTransform rectT = FogCanvas.GetComponent<RectTransform>();

        Canvas fogCanvas = FogCanvas.GetComponent<Canvas>();
        fogCanvas.renderMode = RenderMode.WorldSpace;

        rectT.position = new Vector3((float)width / 2f, (float)height / 2f, 0f);
        rectT.sizeDelta = new Vector2((float)width, (float)height);

        GameObject camObj = new GameObject("Camera");
        Camera cam = camObj.AddComponent<Camera>();
        cam.orthographic = true;
        cam.orthographicSize = 10f;
        cam.transform.position = new Vector3(width/2f, height/2f, -10f);

        manager.FogCanvas = fogCanvas;
        
        manager.LevelH = MapSizeX;
        manager.LevelW = MapSizeZ;
        manager.LevelWidth = width;
        manager.LevelHeight = height;
        manager.ResitenceMapPath = FileLocation;
        manager.SetResistenceMap(FileLocation);

        manager.RevealOpacities = new Color(RevealOpacity, CoveredOpacity, UndiscoveredOpacity, 1f);
        manager.StartEndHeight = MinMaxHeight;
        manager.FogTextureFilterMode = FogFilterMode;
        manager.ManualMode = false;

        if (BlurQuality != FogOfWar.FogQuality.Off)
        {
            FogOfWarBlur blur = manager.gameObject.AddComponent<FogOfWarBlur>();
            manager.fogOfWarBlur = blur;
            manager.BlurFog = BlurQuality;
        }

        GameObject Quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        Quad.name = "Raycast Catcher";
        Quad.GetComponent<MeshRenderer>().enabled = false;
        Quad.transform.position = new Vector3(width / 2f, height/2f, 0f);
        Quad.transform.localScale = new Vector3(width, height, 1f);
    }

    private void SaveAndCreateTerrain()
    {
        int width = int.Parse(MapSizeX.ToString().Remove(0, 1));
        int height = int.Parse(MapSizeZ.ToString().Remove(0, 1));

        Texture2D ResistanceMap = new Texture2D(width, height);
        Color[] c = new Color[width * height];

        for (int i = 0; i < c.Length; i++)
        {
            c[i] = new Color(0f, 0f, 0f, 1f);
        }

        if (BorderResistenceMap)
        {
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    int coord = z * width + x;

                    if (x == 0 || x == width - 1 || z == 0 || z == height - 1)
                    {
                        c[coord].r = 1f;
                    }
                }
            }
        }

        ResistanceMap.SetPixels(c);
        byte[] pngData = ResistanceMap.EncodeToPNG();

        if (pngData != null)
        {
            File.WriteAllBytes(FileLocation, pngData);
        }

        AssetDatabase.Refresh();

        GameObject g = new GameObject("Fog of War Manager");
        FogOfWarManager manager = g.AddComponent<FogOfWarManager>();

        if (CreateTerrain)
        {
            GameObject t = new GameObject("Terrain");
            Terrain terrain = t.AddComponent<Terrain>();
            TerrainData terrainData = new TerrainData();

            Material TerrainMaterial = new Material(Shader.Find("UltimateFogOfWar/Terrain/Diffuse"));
            TerrainMaterial.name = "TerrainMaterial";

            string PathOnly = FileLocation;

            for (int i = PathOnly.Length - 1; i > 0; i--)
            {
                if (PathOnly[i] == '/')
                {
                    PathOnly = PathOnly.Remove(i + 1, PathOnly.Length - i - 1);
                    break;
                }
            }

            string matString = PathOnly + TerrainMaterial.name + ".mat";
            AssetDatabase.CreateAsset(TerrainMaterial, matString);
            AssetDatabase.SaveAssets();

            switch (TerrainMat)
            {
                case FogOfWar.TerrainMaterial.Legacy_Specular:
                    TerrainMaterial = new Material(Shader.Find("UltimateFogOfWar/Terrain/Specular"));
                    break;
                case FogOfWar.TerrainMaterial.Legacy_Diffuse:
                    TerrainMaterial = new Material(Shader.Find("UltimateFogOfWar/Terrain/Standard"));
                    break;
            }

            terrain.materialType = Terrain.MaterialType.Custom;

            terrainData.heightmapResolution = height + 1;
            terrainData.size = new Vector3(width + (Overshoot * 2), MinMaxHeight.y, height + (Overshoot * 2));
            terrainData.SetDetailResolution(height, 8);

            terrain.terrainData = terrainData;
            terrain.materialTemplate = TerrainMaterial;
            TerrainCollider terrainCollider = t.AddComponent<TerrainCollider>();
            terrainCollider.terrainData = terrainData;

            if (SaveTerrainData)
            {
                string tDString = PathOnly + "TerrainData" + ".asset";
                AssetDatabase.CreateAsset(terrainData, tDString);
                AssetDatabase.SaveAssets();
            }

            t.transform.position -= new Vector3(Overshoot, 0f, Overshoot);
            manager.FogOfWarTerrain = terrain;
        }

        manager.fogAlignment = FogOfWar.FogAlignment.Horizontal;
        manager.LevelH = MapSizeX;
        manager.LevelW = MapSizeZ;
        manager.LevelWidth = width;
        manager.LevelHeight = height;
        manager.ResitenceMapPath = FileLocation;
        manager.SetResistenceMap(FileLocation);
        manager.RevealOpacities = new Color(RevealOpacity, CoveredOpacity, UndiscoveredOpacity, 1f);
        manager.StartEndHeight = MinMaxHeight;
        manager.FogTextureFilterMode = FogFilterMode;
        manager.ManualMode = false;

        if (BlurQuality != FogOfWar.FogQuality.Off)
        {
            FogOfWarBlur blur = manager.gameObject.AddComponent<FogOfWarBlur>();
            manager.fogOfWarBlur = blur;
            manager.BlurFog = BlurQuality;
        }
    }
}
