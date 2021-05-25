using UnityEngine;
#if !UNITY_WEBGL
using System.Threading;
#endif
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.AnimatedValues;
#endif

[ExecuteInEditMode]
public class FogOfWarManager : MonoBehaviour
{
    public FogOfWarBlur fogOfWarBlur;
    public FogOfWar.FogEffect fogEffect;
    public FogOfWar.FogAlignment fogAlignment;

    public FogOfWar.MapSizes LevelW = FogOfWar.MapSizes._128;
    public FogOfWar.MapSizes LevelH = FogOfWar.MapSizes._128;

    public bool AutomaticMode = true;
    public float UpdatesPerSecond = 15f;
    private float NextUpdate = 0f;

    public int LevelWidth = 128;
    public int LevelHeight = 128;
    public bool ScalePatchModifier;
    public float PatchScale = 1f;
    public Vector3 Origin = Vector3.zero;

    private Texture2D FogTexture;
    public Texture2D Resistence;
    public string ResitenceMapPath;
    public string LevelName = "New Level";
    public Vector2 StartEndHeight = new Vector2(0f, 10f);
    public Color RevealOpacities = new Color(1f, 0.5f, 0.1f);                              //R: Revealed; G: Previously revealed; B: Not revealed
    public Color FogColor;
    public float RevealedOpacity = 1f;
    public float CoveredOpacity = 0.5f;
    public float UndiscoveredOpacity = 0.25f;

    public float AnimatedFogSpeed = 1f;
    public float AnimatedFogIntensity = 3f;
    public float AnimatedFogTiling = 2f;

    public FogOfWar.Players RevealFaction = FogOfWar.Players.Player00;
    public List<Faction> Factions = new List<Faction>();

#if UNITY_EDITOR
    public bool DebugMode = true;

    public AnimBool ShowPreview;
    public AnimBool ShowLevelOption;
    public AnimBool ShowFogOptions;
    public AnimBool ShowFactionOptions;
    public AnimBool ShowBlurOptions;
    public AnimBool ShowGrassOptions;
    public AnimBool ShowMixedOptions;
    

    public enum PlaceMode {
        HardBlocker, Height, Modifier, Delete
    };

    public PlaceMode placeMode;
    public int ChangeHeight;
    public bool SaveReminder = false;


    public int MultiPlaceWidth = 3;
    public int MultiPlaceHeight = 3;
    public int MultiPlaceID = 255;
#endif

    public bool ShowBlocker;
    public int FactionCount = 1;
    public bool BlurFactionsInBackground = false;

    public float RevealSpeed = 15f;
    public float CoverSpeed = 5f;

    public RenderTexture BluredRenderTexture;
    public FogOfWar.FogQuality BlurFog = FogOfWar.FogQuality.Off;
    public int UpSample = 1;

    private Texture TextureBuffer;

    public Terrain FogOfWarTerrain;
    public Canvas FogCanvas;

    public FilterMode FogTextureFilterMode = FilterMode.Bilinear;
    public bool UseThreading = true;

    public Texture2D FogNoise;
    public bool ManualMode = true;

#if !UNITY_WEBGL
    private Thread FogThread;
#endif

    public void InitializeMaps()
    {
        FogOfWar.Factions.Clear();

        if (Factions.Count == 0)
            AddFaction();

        //Set up FogOFWar
        //1. FogOfWar Data
        FogOfWar.InitializeFogOfWar(LevelWidth, LevelHeight, Factions, RevealFaction);

        //Pass Reveal opacities
        FogOfWar.RevealOpacities = RevealOpacities;

        //2. ResistenceMap Data
        SetResistenceMap(ResitenceMapPath);

        //Create a new Texture to display the Fog result
        FogTexture = new Texture2D(LevelWidth, LevelHeight, TextureFormat.RGBA32, false);
        FogTexture.filterMode = FogTextureFilterMode;

        //Create a new RenderTexture to Blur the Fog
        BluredRenderTexture = new RenderTexture(LevelWidth * UpSample, LevelHeight * UpSample, 0);
        BluredRenderTexture.filterMode = FogTextureFilterMode;

        if (BlurFog == FogOfWar.FogQuality.Off)
        {
            Shader.SetGlobalTexture("FogOfWar", FogOfWar.Factions[FogOfWar.RevealFactionInt].FogTexture);
        }
        else
        {
            if (fogOfWarBlur == null)
                fogOfWarBlur = gameObject.AddComponent<FogOfWarBlur>();

            Shader.SetGlobalTexture("FogOfWar", FogOfWar.Factions[FogOfWar.RevealFactionInt].BluredRenderTexture);
        }

        //Pass Level width and height to Shaders 
        Shader.SetGlobalFloat("LevelWidth", (float)LevelWidth);
        Shader.SetGlobalFloat("LevelHeight", (float)LevelHeight);
        Shader.SetGlobalFloat("Scale", PatchScale);
        Shader.SetGlobalVector("Origin", new Vector4(Origin.x, Origin.y, Origin.z, 0f));
        Shader.SetGlobalColor("FogColor", FogColor);
        Shader.SetGlobalFloat("FogSpeed", AnimatedFogSpeed);
        Shader.SetGlobalFloat("FogTiling", AnimatedFogTiling);
        Shader.SetGlobalFloat("FogIntensity", AnimatedFogIntensity);
        Shader.SetGlobalTexture("FogNoise", FogNoise);
    }


    public void AddFaction()
    {
        System.Array revealFactions = System.Enum.GetValues(typeof(FogOfWar.Players));

        if (Factions.Count >= revealFactions.Length)
        {
            Debug.LogWarning("[UFoW] Cant add more Factions because the limit of "+ revealFactions.Length+" is reached. Check the Documentation on how to add more Factions. (Default = 8)");
            return;
        }

        int LevelSize = LevelWidth * LevelHeight;
        Faction f = new Faction(LevelSize, Factions.Count);

        for (int i = 0; i < LevelSize; i++)
        {
            f.FogOfWarMapData[i] = new Color(0.0f, RevealOpacities.b, 0.0f, 0.0f);
        }

        f.FogTexture = new Texture2D(LevelWidth, LevelHeight, TextureFormat.RGBA32, false);
        f.FogTexture.filterMode = FogTextureFilterMode;

        //Create a new RenderTexture to Blur the Fog
        f.BluredRenderTexture = new RenderTexture(LevelWidth * UpSample, LevelHeight * UpSample, 0);
        f.BluredRenderTexture.filterMode = FogTextureFilterMode;

        f.ID = Mathf.FloorToInt(Mathf.Pow(2, Factions.Count));
        f.RevealFactions = (FogOfWar.Players)f.ID;
        Factions.Add(f);
        FogOfWar.InitializeFogOfWar(LevelWidth, LevelHeight, Factions, RevealFaction);
    }

    public void RemoveFaction(int i)
    {
        if (Factions.Count - 1 <= 0)
        {
            Debug.LogWarning("[UFoW] Could not remove Faction. Less than 1 Faction is not allowed.");
            return;
        }

        if (i < Factions.Count && Factions.Count > 0)
        {
            Factions.RemoveAt(i);
        }
        FogOfWar.InitializeFogOfWar(LevelWidth, LevelHeight, Factions, RevealFaction);
    }

    public void ShowFaction(int _Faction)
    {
        if (_Faction > Factions.Count)
        {
            Debug.LogWarning("[UFoW] Cant reveal Faction, because it does not exist. Create more Factions.");
        }
        
        RevealFaction = (FogOfWar.Players)Mathf.FloorToInt( Mathf.Pow(2, _Faction));
        

        if (BlurFog == FogOfWar.FogQuality.Off)
        {
            Shader.SetGlobalTexture("FogOfWar", FogOfWar.Factions[_Faction].FogTexture);
        } else {
            if (fogOfWarBlur == null)
            {
                fogOfWarBlur = gameObject.AddComponent<FogOfWarBlur>();
            }

            Shader.SetGlobalTexture("FogOfWar", FogOfWar.Factions[_Faction].BluredRenderTexture);
        }

        FogOfWar.RevealFactionInt = _Faction;
        FogOfWar.RevealFaction = RevealFaction;

#if UNITY_EDITOR
        if (!Application.isPlaying)
            SetWhiteTextureAsFog();
#endif
    }

    public FogOfWar.Players GetFactionViewMask(int _Faction)
    {
        return FogOfWar.Factions[_Faction].RevealFactions;
    }

    public void SetFactionViewMask(int _Faction, FogOfWar.Players _Mask)
    {
        if (_Faction < Factions.Count)
        {
            Factions[_Faction].RevealFactions = _Mask;
            FogOfWar.Factions[_Faction].RevealFactions = _Mask;
        }
    }

    public void CalculateOnce()
    {
        FogOfWar.UpdateFoV = true;
    }

    void Update()
    {
        if (!AutomaticMode)
        {
            if (UpdatesPerSecond > 0)
            {
                if (Time.time >= NextUpdate)
                {
                    FogOfWar.UpdateFoV = true;
                    NextUpdate = Time.time + (1f / UpdatesPerSecond);
                }
            }
        } else {
            FogOfWar.UpdateFoV = true;
        }
        
        FogOfWar.ShowBlocker = ShowBlocker;

#if UNITY_EDITOR
        if(!Application.isPlaying)
            PreparePlacement();

        if (!Application.isPlaying)
            return;
#endif

        FogOfWar.PrepareDynamicBlockers();
        FogOfWar.MainThreadDeltaTime = Time.deltaTime;

        if (UseThreading)
        {
#if !UNITY_WEBGL
            if (FogThread == null || !FogThread.IsAlive)
            {
                FogOfWar.PrepareThread();

                for (int f = 0; f < FogOfWar.Factions.Count; f++)
                {
                    //Array.Copy(FogOfWar.Factions[f].FogOfWarMapData, FogOfWar.Factions[f].FogOfWarMapDataBuffer, FogOfWar.Factions[f].FogOfWarMapDataBuffer.Length);
                    FogOfWar.Factions[f].FogTexture.SetPixels(FogOfWar.Factions[f].FogOfWarMapData);
                    FogOfWar.Factions[f].FogTexture.Apply(false);
                }
#if UNITY_EDITOR
                for (int f = 0; f < FogOfWar.Factions.Count; f++)
                {
                    if (BlurFog == FogOfWar.FogQuality.On)
                    {
                        TextureBuffer = FogOfWar.Factions[f].FogTexture as Texture;
                        Graphics.Blit(TextureBuffer, FogOfWar.Factions[f].BluredRenderTexture);

                        if (fogOfWarBlur != null)
                            fogOfWarBlur.BlurImage(FogOfWar.Factions[f].BluredRenderTexture, FogOfWar.Factions[f].BluredRenderTexture);
                    }
                    else
                    {
                        TextureBuffer = FogOfWar.Factions[f].FogTexture as Texture;
                        Graphics.Blit(TextureBuffer, FogOfWar.Factions[f].BluredRenderTexture);
                    }
                }
#else
                if (BlurFog == FogOfWar.FogQuality.On)
                {
                    TextureBuffer = FogOfWar.Factions[FogOfWar.RevealFactionInt].FogTexture as Texture;
                    Graphics.Blit(TextureBuffer, FogOfWar.Factions[FogOfWar.RevealFactionInt].BluredRenderTexture);

                    if (fogOfWarBlur != null)
                        fogOfWarBlur.BlurImage(FogOfWar.Factions[FogOfWar.RevealFactionInt].BluredRenderTexture, FogOfWar.Factions[FogOfWar.RevealFactionInt].BluredRenderTexture);
                }
                else {
                    TextureBuffer = FogOfWar.Factions[FogOfWar.RevealFactionInt].FogTexture as Texture;
                    Graphics.Blit(TextureBuffer, FogOfWar.Factions[FogOfWar.RevealFactionInt].BluredRenderTexture);
                }
#endif

                FogThread = new Thread(() => FogOfWar.RevealFog(RevealSpeed, CoverSpeed));
                FogThread.Start();
            }
#else
        FogOfWar.PrepareThread();
        FogOfWar.RevealFog(RevealSpeed, CoverSpeed);
            if (BlurFog == FogOfWar.FogQuality.On)
            {
                TextureBuffer = FogOfWar.Factions[FogOfWar.RevealFactionInt].FogTexture as Texture;
                Graphics.Blit(TextureBuffer, FogOfWar.Factions[FogOfWar.RevealFactionInt].BluredRenderTexture);
                if (fogOfWarBlur != null)
                    fogOfWarBlur.BlurImage(FogOfWar.Factions[FogOfWar.RevealFactionInt].BluredRenderTexture, FogOfWar.Factions[FogOfWar.RevealFactionInt].BluredRenderTexture);
            }
            else {
                TextureBuffer = FogOfWar.Factions[FogOfWar.RevealFactionInt].FogTexture as Texture;
                Graphics.Blit(TextureBuffer, FogOfWar.Factions[FogOfWar.RevealFactionInt].BluredRenderTexture);
            }

        FogOfWar.Factions[FogOfWar.RevealFactionInt].FogTexture.SetPixels(FogOfWar.Factions[FogOfWar.RevealFactionInt].FogOfWarMapData);
        FogOfWar.Factions[FogOfWar.RevealFactionInt].FogTexture.Apply(false);
#endif
        }
        else {
            FogOfWar.PrepareThread();
            FogOfWar.RevealFog(RevealSpeed, CoverSpeed);

            if (BlurFog == FogOfWar.FogQuality.On)
            {
                TextureBuffer = FogOfWar.Factions[FogOfWar.RevealFactionInt].FogTexture as Texture;
                Graphics.Blit(TextureBuffer, FogOfWar.Factions[FogOfWar.RevealFactionInt].BluredRenderTexture);
                if (fogOfWarBlur != null)
                    fogOfWarBlur.BlurImage(FogOfWar.Factions[FogOfWar.RevealFactionInt].BluredRenderTexture, FogOfWar.Factions[FogOfWar.RevealFactionInt].BluredRenderTexture);
            }
            else {
                TextureBuffer = FogOfWar.Factions[FogOfWar.RevealFactionInt].FogTexture as Texture;
                Graphics.Blit(TextureBuffer, FogOfWar.Factions[FogOfWar.RevealFactionInt].BluredRenderTexture);
            }

            FogOfWar.Factions[FogOfWar.RevealFactionInt].FogTexture.SetPixels(FogOfWar.Factions[FogOfWar.RevealFactionInt].FogOfWarMapData);
            FogOfWar.Factions[FogOfWar.RevealFactionInt].FogTexture.Apply(false);
        }
    }

    public void SetResistenceMap(string _ResistenceMapPath)
    {
#if UNITY_EDITOR
        if (Resistence == null && _ResistenceMapPath != "")
        {
            Resistence = UnityEditor.AssetDatabase.LoadAssetAtPath<Texture2D>(_ResistenceMapPath);
        }
#endif
        if (Resistence != null)
        {
            FogOfWar.ResistenceMapData = Resistence.GetPixels();
        }
        else
        {
            Debug.LogWarning("Resistence map not assigned! Use Fog manually.");
        }  
    }

    public void SetResistenceMapData(Color[] _ResistenceMapData)
    {
        FogOfWar.ResistenceMapData = _ResistenceMapData;
#if UNITY_EDITOR
        Texture2D tex = new Texture2D(LevelWidth, LevelHeight);
        tex.SetPixels(_ResistenceMapData);
        tex.Apply(false);
        Resistence = tex;
#endif
    }

    public void AnalyzeTerrain()
    {
        if (FogOfWar.ResistenceMapData == null)
        {
            FogOfWar.ResistenceMapData = new Color[LevelWidth * LevelHeight];

            for (int i = 0; i < FogOfWar.ResistenceMapData.Length; i++)
            {
                FogOfWar.ResistenceMapData[i] = new Color(0f, 0f, 0f, 1f);
            }

            Debug.Log("ResistenceMapData was not initialized!");
        }

        if (FogOfWar.ResistenceMapData.Length != 0)
        {
            if (ResitenceMapPath != "")
            {
                SetResistenceMap(ResitenceMapPath);
                InitializeMaps();
            }
        }
        else {
            Debug.Log("[UFoW] No Data!");
        }

        int collums = 0;
        for (float x = Origin.x; x < LevelWidth * PatchScale + Origin.x; x += PatchScale)
        {
            int rows = 0;
            for (float z = Origin.z; z < LevelHeight * PatchScale + Origin.z; z += PatchScale)
            {
                Ray ray = new Ray();
                ray.origin = new Vector3(x + 0.5f, StartEndHeight.y+ 0.1f + Origin.y, z + 0.5f);
                ray.direction = Vector3.down;
                RaycastHit rayHit = new RaycastHit();
                int coordinate = (int)rows * LevelWidth + (int)collums;
                if (Physics.Raycast(ray, out rayHit, Mathf.Infinity))
                {
                    FogOfWar.ResistenceMapData[coordinate].g = FogOfWar.Remap(rayHit.point.y, StartEndHeight.x + Origin.y, StartEndHeight.y + Origin.y, 0f, 1f);
                }
                else{
                    FogOfWar.ResistenceMapData[coordinate].g = 0f;
                }
                rows++;
            }
            collums++;          
        }

#if UNITY_EDITOR
        SetWhiteTextureAsFog();
#endif
    }

    public void SaveFogMaps(string _SaveName)
    {
#if !UNITY_WEBGL
        if (!Directory.Exists(Application.persistentDataPath + "/Saves/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves/");
        }

        int ArraySize = LevelWidth * LevelHeight * FogOfWar.Factions.Count;
        Color[] AllTextures = new Color[ArraySize];

        int index = 0;

        for (int i = 0; i < FogOfWar.Factions.Count; i++)
        {
            for (int j = 0; j < FogOfWar.Factions[i].FogOfWarMapData.Length; j++)
            {
                AllTextures[index] = FogOfWar.Factions[i].FogOfWarMapData[j];
                index++;
            }
        }

        Texture2D temp = new Texture2D(LevelWidth * FogOfWar.Factions.Count, LevelHeight);
        temp.SetPixels(AllTextures);
        byte[] pngData = temp.EncodeToPNG();//temp.GetRawTextureData();                 ->  Replace for Raw data
        File.WriteAllBytes(Application.persistentDataPath + "/Saves/" + _SaveName, pngData);
        Debug.Log("File saved to: " + Application.persistentDataPath + "/Saves/" + _SaveName);
#endif
    }

    public void LoadFogMaps(string _SaveName)
    {
#if !UNITY_WEBGL
        if (!Directory.Exists(Application.persistentDataPath + "/Saves/"))
        {
            Debug.LogWarning("[UFoW] Directory does not exist! Savegame could not be loaded.");
        }

        Texture2D temp = new Texture2D(LevelWidth * FogOfWar.Factions.Count, LevelHeight);
        byte[] pngData = File.ReadAllBytes(Application.persistentDataPath + "/Saves/" + _SaveName);
        temp.LoadImage(pngData, false);
        //temp.LoadRawTextureData(pngData);         ->  Replace for Raw data
        Color[] AllTextures = temp.GetPixels();

        int index = 0;

        for (int i = 0; i < FogOfWar.Factions.Count; i++)
        {
            Color[] FactionTex = new Color[LevelWidth * LevelHeight];

            for (int j = 0; j < LevelWidth * LevelHeight; j++)
            {

                FactionTex[j] = AllTextures[index];
                index++;
            }

            Factions[i].FogOfWarMapData = FactionTex;
            Factions[i].FogOfWarMapDataBuffer = FactionTex;
            FogOfWar.Factions[i].FogOfWarMapData = FactionTex;
            FogOfWar.Factions[i].FogOfWarMapDataBuffer = FactionTex;
        }
        Debug.Log("File loaded from: " + Application.persistentDataPath + "/Saves/" + _SaveName);
#endif
    }

    public Texture2D GetResistenceMap()
    {
        if (FogOfWar.ResistenceMapData == null || Resistence == null)
        {
            return null;
        }
        Resistence.SetPixels(FogOfWar.ResistenceMapData);
        Resistence.Apply(false);
        return Resistence;
    }

    public void OnEnable()
    {
        if (!ManualMode)
        {
            InitializeMaps();
            Shader.SetGlobalTexture("_FogNoise", FogNoise);
        }

        FogOfWar.fogAlignment = fogAlignment;
        FogOfWar.UpdateScaleModifiers(ScalePatchModifier, PatchScale, Origin);

#if UNITY_EDITOR
        SetWhiteTextureAsFog();
#endif
    }

#if UNITY_EDITOR
    public GameObject ModPrefab;
    public GameObject PreviewModPrefab;
    public int[] PlacementID;
    public GameObject[] FogGO;

    public void UpdatePreviewPrefab(Vector3 _Position, Quaternion _Rotation, bool _Snap)
    {
        if (PreviewModPrefab == null && ModPrefab != null)
        {
            PreviewModPrefab = Instantiate(ModPrefab, _Position, _Rotation) as GameObject;
        }

        if (PreviewModPrefab != null && placeMode == PlaceMode.Modifier)
        {
            if (PreviewModPrefab.GetInstanceID() != ModPrefab.GetInstanceID())
            {
                if(PreviewModPrefab != null)
                    DestroyImmediate(PreviewModPrefab);

                if(ModPrefab != null)
                    PreviewModPrefab = Instantiate(ModPrefab, _Position, _Rotation) as GameObject;
            }

            if (_Snap && PreviewModPrefab != null)
            {
                if (fogAlignment == FogOfWar.FogAlignment.Horizontal)
                {
                    PreviewModPrefab.transform.position = new Vector3(Mathf.Floor(_Position.x) + .5f, _Position.y, Mathf.Floor(_Position.z) + .5f);
                }
                else {
                    PreviewModPrefab.transform.position = new Vector3(Mathf.Floor(_Position.x) + .5f, Mathf.Floor(_Position.y) + .5f, _Position.z);
                }
            } else  {
                if(PreviewModPrefab != null)
                    PreviewModPrefab.transform.position = _Position;
            }
        }

        if (placeMode == PlaceMode.Delete)
            DestroyImmediate(PreviewModPrefab);

    }

    public void PreparePlacement()
    {
        if (PlacementID == null || PlacementID.Length != LevelWidth * LevelHeight)
        {
            PlacementID = new int[LevelWidth * LevelHeight];

            for (int i = 0; i < PlacementID.Length; i++)
            {
                PlacementID[i] = Mathf.FloorToInt(FogOfWar.ResistenceMapData[i].a * 255);
            }
        }

        if (FogGO == null || FogGO.Length != LevelWidth * LevelHeight)
        {
            FogGO = new GameObject[LevelWidth * LevelHeight];
        }
    }

    public void FinalizePlacement()
    {
        for (int i = 0; i < PlacementID.Length; i++)
        {
            FogOfWar.ResistenceMapData[i].a = (float)PlacementID[i] / 255f;
        }
    }

    public void PlacePrefab(Vector3 _Position, Quaternion _Rotation, bool _Snap, int _ID)
    {
        if (fogAlignment == FogOfWar.FogAlignment.Horizontal)
        {
            int coord = Mathf.FloorToInt(Mathf.Floor((_Position.z - Origin.z) / PatchScale) * LevelWidth + Mathf.Floor((_Position.x - Origin.x) / PatchScale));

            if (coord > FogOfWar.ResistenceMapData.Length || coord < 0)
                return;

            if (FogGO[coord] != null)
            {
                Debug.LogWarning("[UFoW]Can't place Vision Modifier. Position already contains a Vision Modifier.");
                return;
            }

            FogGO[coord] = PreviewModPrefab;
            PlacementID[coord] = _ID;
            PreviewModPrefab = null;
        }
        else {
            int coord = Mathf.FloorToInt(Mathf.Floor((_Position.y - Origin.y) / PatchScale) * LevelWidth + Mathf.Floor((_Position.x - Origin.x) / PatchScale));

            if (coord > FogOfWar.ResistenceMapData.Length || coord < 0)
                return;

            if (FogGO[coord] != null)
            {
                Debug.LogWarning("[UFoW]Can't place Vision Modifier. Position already contains a Vision Modifier.");
                return;
            }

            FogGO[coord] = PreviewModPrefab;
            PlacementID[coord] = _ID;
            PreviewModPrefab = null;
        }
    }

    public void RemovePreview()
    {
        if (PreviewModPrefab != null)
        {
            DestroyImmediate(PreviewModPrefab);
        }
    }

    public void Revert()
    {
        for (int i = 0; i < FogGO.Length; i++)
        {
            if (FogGO[i] != null)
            {
                DestroyImmediate(FogGO[i]);
            }
        }
        
        for (int i = 0; i < PlacementID.Length; i++)
        {
            PlacementID[i] = 255;
        }
    }

    public void RevertSingle(Vector3 _Position)
    {
        if (fogAlignment == FogOfWar.FogAlignment.Horizontal)
        {
            int coord = Mathf.FloorToInt(Mathf.Floor((_Position.z - Origin.z) / PatchScale) * LevelWidth + Mathf.Floor((_Position.x - Origin.x) / PatchScale));

            if (coord > FogGO.Length || coord < 0)
                return;

            DestroyImmediate(FogGO[coord]);
            PlacementID[coord] = 255;
        } else {
            int coord = Mathf.FloorToInt(Mathf.Floor((_Position.y - Origin.y) / PatchScale) * LevelWidth + Mathf.Floor((_Position.x - Origin.x) / PatchScale));

            if (coord > FogGO.Length || coord < 0)
                return;

            DestroyImmediate(FogGO[coord]);
            PlacementID[coord] = 255;
        }  
    }

    private void SetWhiteTextureAsFog()
    {
        if (!Application.isPlaying)
        {
            Shader.SetGlobalTexture("FogOfWar", Texture2D.whiteTexture);
        }
    }

    public void ChangeHardBlockerTo(Vector3 _Position, int _Width, int _Height, int ID)
    {
        if (fogAlignment == FogOfWar.FogAlignment.Horizontal)
        {
            float StartX = _Position.x + 0.5f - (float)_Width / 2f;
            float EndX = _Position.x + 0.5f + (float)_Width / 2f-1f;
            float StartZ =_Position.z + 0.5f - (float)_Height / 2f;
            float EndZ = _Position.z + 0.5f + (float)_Height / 2f-1f;
            
            for (float x = StartX; x <= EndX; x++)
            {
                for (float z = StartZ; z <= EndZ; z++)
                {
                    int coord = Mathf.FloorToInt(Mathf.Floor((z - Origin.z) / PatchScale) * LevelWidth + Mathf.Floor((x - Origin.x) / PatchScale));

                    if (coord > FogOfWar.ResistenceMapData.Length || coord < 0)
                        return;

                    FogOfWar.ResistenceMapData[coord].r = (float)ID/255f;
                }
            }
        }
        else
        {
            float StartX = _Position.x + 0.5f - (float)_Width / 2f;
            float EndX = _Position.x + 0.5f + (float)_Width / 2f - 1f;
            float StartY = _Position.y + 0.5f - (float)_Height / 2f;
            float EndY = _Position.y + 0.5f + (float)_Height / 2f - 1f;

            for (float x = StartX; x <= EndX; x++)
            {
                for (float y = StartY; y <= EndY; y++)
                {
                    int coord = Mathf.FloorToInt(Mathf.Floor((y - Origin.y) / PatchScale) * LevelWidth + Mathf.Floor((x - Origin.x) / PatchScale));

                    if (coord > FogOfWar.ResistenceMapData.Length || coord < 0)
                        return;

                    FogOfWar.ResistenceMapData[coord].r = (float)ID / 255f;
                }
            }
        }
    }

    public void ChangeHeightTo(Vector3 _Position, float _Height)
    {
        if (fogAlignment == FogOfWar.FogAlignment.Horizontal)
        {
            int coord = Mathf.FloorToInt(Mathf.Floor((_Position.z - Origin.z) / PatchScale) * LevelWidth + Mathf.Floor((_Position.x - Origin.x) / PatchScale));

            if (coord > FogOfWar.ResistenceMapData.Length || coord < 0)
                return;

            FogOfWar.ResistenceMapData[coord].g = (1f / 255f) * _Height;
        }
        else
        {
            int coord = Mathf.FloorToInt(Mathf.Floor((_Position.y - Origin.y) / PatchScale) * LevelWidth + Mathf.Floor((_Position.x - Origin.x) / PatchScale));

            if (coord > FogOfWar.ResistenceMapData.Length || coord < 0)
                return;

            FogOfWar.ResistenceMapData[coord].g = (1f / 255f) * _Height;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position + Vector3.up, "Revealer.png", true);
    }

#endif
}
