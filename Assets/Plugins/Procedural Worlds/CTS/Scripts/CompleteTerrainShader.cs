using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using UnityEngine.Rendering;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace CTS
{
    /// <summary>
    /// The complete terrain shader editor manager - installed per terrain object - does shader control on a terrain.
    /// </summary>
    [RequireComponent(typeof(Terrain))]
    [AddComponentMenu("CTS/Add CTS To Terrain")]
    [ExecuteInEditMode]
    [System.Serializable]
    public class CompleteTerrainShader : MonoBehaviour
    {
        /// <summary>
        /// The terrain profile
        /// </summary>
        public CTSProfile Profile
        {
            get { return m_profile; }
            set
            {
                //only allow to set a profile when it is connected
                if (m_isProfileConnected)
                {

                    //Make sure we have terrain
                    if (m_terrain == null)
                    {
                        m_terrain = transform.GetComponent<Terrain>();
                    }

                    if (m_profile == null)
                    {
                        m_profile = value;
                        if (m_profile != null)
                        {
                            if (m_profile.TerrainTextures.Count == 0)
                            {
                                UpdateProfileFromTerrainForced();
                            }
                            else if (TerrainNeedsTextureUpdate())
                            {
                                ReplaceTerrainTexturesFromProfile(false);
                            }
                        }
                    }
                    else
                    {
                        if (value == null)
                        {
                            m_profile = value;
                        }
                        else
                        {
                            if (m_profile.name != value.name)
                            {
                                m_profile = value;
                            }
                            if (m_profile.TerrainTextures.Count == 0)
                            {
                                UpdateProfileFromTerrainForced();
                            }
                            else if (TerrainNeedsTextureUpdate())
                            {
                                ReplaceTerrainTexturesFromProfile(false);
                            }
                        }
                    }
                    if (m_profile != null)
                    {
                        ApplyMaterialAndUpdateShader();
                    }
                }
            }
        }
        [SerializeField]
        private CTSProfile m_profile;

        /// <summary>
        /// Terrain normal map
        /// </summary>
        public Texture2D NormalMap
        {
            get { return m_normalMap; }
            set
            {
                if (value == null)
                {
                    if (m_normalMap != null)
                    {
                        m_normalMap = value;
                        SetDirty(this, false, false);
                    }
                }
                else
                {
                    if (m_normalMap == null || m_normalMap.GetInstanceID() != value.GetInstanceID())
                    {
                        m_normalMap = value;
                        SetDirty(this, false, false);
                    }
                }
            }
        }
        [SerializeField]
        private Texture2D m_normalMap;


        /// <summary>
        /// A flag that indicates if the profile is currently connected for this shader.
        /// </summary>
        public bool IsProfileConnected
        {
            get { return m_isProfileConnected; }
            set { m_isProfileConnected = value; }
        }
        [SerializeField]
        private bool m_isProfileConnected = true;

        /// <summary>
        /// A flag that indicates if the material needs to be reapplied.
        /// </summary>
        public bool MaterialNeedsReapply
        {
            get { return m_materialNeedsReapply; }
            set { m_materialNeedsReapply = value; }
        }
        [SerializeField]
        private bool m_materialNeedsReapply = false;



        /// <summary>
        ///The asset GUID for the last CTS profile that was in use on this terrain before disconnecting the CTS profile.
        /// </summary>
        public string LastUsedCTSProfileID
        {
            get { return m_lastUsedCTSProfileID; }
            set { m_lastUsedCTSProfileID = value; }
        }
        [SerializeField]
        private string m_lastUsedCTSProfileID = "";

        /// <summary>
        /// GUID for the first persistent splatmap file that was created when disconnecting the profile.
        /// </summary>
        public string PersistentSplatGUID1
        {
            get { return m_persistentSplatGUID1; }
            set { m_persistentSplatGUID1 = value; }
        }
        [SerializeField]
        private string m_persistentSplatGUID1 = "";

        /// <summary>
        /// GUID for the second persistent splatmap file that was created when disconnecting the profile.
        /// </summary>
        public string PersistentSplatGUID2
        {
            get { return m_persistentSplatGUID2; }
            set { m_persistentSplatGUID2 = value; }
        }
        [SerializeField]
        private string m_persistentSplatGUID2 = "";

        /// <summary>
        /// GUID for the third persistent splatmap file that was created when disconnecting the profile.
        /// </summary>
        public string PersistentSplatGUID3
        {
            get { return m_persistentSplatGUID3; }
            set { m_persistentSplatGUID3 = value; }
        }
        [SerializeField]
        private string m_persistentSplatGUID3 = "";

        /// <summary>
        /// GUID for the fourth persistent splatmap file that was created when disconnecting the profile.
        /// </summary>
        public string PersistentSplatGUID4
        {
            get { return m_persistentSplatGUID4; }
            set { m_persistentSplatGUID4 = value; }
        }
        [SerializeField]
        private string m_persistentSplatGUID4 = "";

        /// <summary>
        /// GUID to the normal map file that was last used when disconnecting the profile.
        /// </summary>
        public string PersistentNormalMapGUID
        {
            get { return m_persistentNormalMapGUID; }
            set { m_persistentNormalMapGUID = value; }
        }
        [SerializeField]
        private string m_persistentNormalMapGUID = "";

        /// <summary>
        /// GUID to the color map file that was last used when disconnecting the profile.
        /// </summary>
        public string PersistentColorMapGUID
        {
            get { return m_persistentColorMapGUID; }
            set { m_persistentColorMapGUID = value; }
        }
        [SerializeField]
        private string m_persistentColorMapGUID = "";

        /// <summary>
        /// GUID to the cutout mask file that was last used when disconnecting the profile.
        /// </summary>
        public string PersistentCutoutMaskGUID
        {
            get { return m_persistentCutoutMaskGUID; }
            set { m_persistentCutoutMaskGUID = value; }
        }
        [SerializeField]
        private string m_persistentCutoutMaskGUID = "";

        /// <summary>
        /// Auto bake the normal map when baking terrain
        /// </summary>
        public bool AutoBakeNormalMap
        {
            get { return m_bakeNormalMap; }
            set { m_bakeNormalMap = value; }
        }
        [SerializeField]
        private bool m_bakeNormalMap = true;

        /// <summary>
        /// Terrain colormap
        /// </summary>
        public Texture2D ColorMap
        {
            get { return m_colorMap; }
            set
            {
                if (value == null)
                {
                    if (m_colorMap != null)
                    {
                        m_colorMap = value;
                        SetDirty(this, false, false);
                    }
                }
                else
                {
                    if (m_colorMap == null || m_colorMap.GetInstanceID() != value.GetInstanceID())
                    {
                        m_colorMap = value;
                        SetDirty(this, false, false);
                    }
                }
            }
        }
        [SerializeField]
        private Texture2D m_colorMap;

        /// <summary>
        /// Auto bake the colour map when baking terrain
        /// </summary>
        public bool AutoBakeColorMap
        {
            get { return m_bakeColorMap; }
            set { m_bakeColorMap = value; }
        }
        [SerializeField]
        private bool m_bakeColorMap = false;

        /// <summary>
        /// Autobake grass into color map when baking terrain
        /// </summary>
        public bool AutoBakeGrassIntoColorMap
        {
            get { return m_bakeGrassTextures; }
            set { m_bakeGrassTextures = value; }
        }
        [SerializeField]
        private bool m_bakeGrassTextures = false;

        /// <summary>
        /// Grass mix strength when baking
        /// </summary>
        public float AutoBakeGrassMixStrength
        {
            get { return m_bakeGrassMixStrength; }
            set { m_bakeGrassMixStrength = value; }
        }
        [SerializeField]
        private float m_bakeGrassMixStrength = 0.2f;

        /// <summary>
        /// Grass darken amount when baking
        /// </summary>
        public float AutoBakeGrassDarkenAmount
        {
            get { return m_bakeGrassDarkenAmount; }
            set { m_bakeGrassDarkenAmount = value; }
        }
        [SerializeField]
        private float m_bakeGrassDarkenAmount = 0.2f;

        /// <summary>
        /// Flag to signal usage of a cutout shader
        /// </summary>
        public bool UseCutout
        {
            get { return m_useCutout; }
            set
            {
                if (m_useCutout != value)
                {
                    m_useCutout = value;
                    SetDirty(this, false, false);
                }
            }
        }
        [SerializeField]
        private bool m_useCutout = false;

        /// <summary>
        /// Cutout mask - used with cutout shader - cutout mask is in the (A) channel
        /// </summary>
        public Texture2D CutoutMask
        {
            get { return m_cutoutMask; }
            set
            {
                if (value == null)
                {
                    if (m_cutoutMask != null)
                    {
                        m_cutoutMask = value;
                        SetDirty(this, false, false);
                    }
                }
                else
                {
                    if (m_cutoutMask == null || m_cutoutMask.GetInstanceID() != value.GetInstanceID())
                    {
                        m_cutoutMask = value;
                        SetDirty(this, false, false);
                    }
                }
            }
        }
        [SerializeField]
        private Texture2D m_cutoutMask;

        /// <summary>
        /// Height below which the terrain cutout will be applied
        /// </summary>
        public float CutoutHeight
        {
            get { return m_cutoutHeight; }
            set
            {
                if (m_cutoutHeight != value)
                {
                    m_cutoutHeight = value;
                    SetDirty(this, false, false);
                }
            }
        }
        [SerializeField]
        private float m_cutoutHeight = 50f;

        /// <summary>
        /// Splat texture 1 - controls textures 0..3
        /// </summary>
        public Texture2D Splat1
        {
            get { return m_splat1; }
            set
            {
                if (value == null)
                {
                    if (m_splat1 != null)
                    {
                        m_splat1 = value;
                        SetDirty(this, false, false);
                    }
                }
                else
                {
                    if (m_splat1 == null || m_splat1.GetInstanceID() != value.GetInstanceID())
                    {
                        m_splat1 = value;
                        SetDirty(this, false, false);
                    }
                }
            }
        }
        [SerializeField]
        private Texture2D m_splat1;

        /// <summary>
        /// Splat texture 2 - controls textures 4..7
        /// </summary>
        public Texture2D Splat2
        {
            get { return m_splat2; }
            set
            {
                if (value == null)
                {
                    if (m_splat2 != null)
                    {
                        m_splat2 = value;
                        SetDirty(this, false, false);
                    }
                }
                else
                {
                    if (m_splat2 == null || m_splat2.GetInstanceID() != value.GetInstanceID())
                    {
                        m_splat2 = value;
                        SetDirty(this, false, false);
                    }
                }
            }
        }
        [SerializeField]
        private Texture2D m_splat2;

        /// <summary>
        /// Splat texture 3 - controls textures 8..11
        /// </summary>
        public Texture2D Splat3
        {
            get { return m_splat3; }
            set
            {
                if (value == null)
                {
                    if (m_splat3 != null)
                    {
                        m_splat3 = value;
                        SetDirty(this, false, false);
                    }
                }
                else
                {
                    if (m_splat3 == null || m_splat3.GetInstanceID() != value.GetInstanceID())
                    {
                        m_splat3 = value;
                        SetDirty(this, false, false);
                    }
                }
            }
        }
        [SerializeField]
        private Texture2D m_splat3;

        /// <summary>
        /// Splat texture 4 - controls textures 12..15
        /// </summary>
        public Texture2D Splat4
        {
            get { return m_splat4; }
            set
            {
                if (value == null)
                {
                    if (m_splat4 != null)
                    {
                        m_splat4 = value;
                        SetDirty(this, false, false);
                    }
                }
                else
                {
                    if (m_splat4 == null || m_splat4.GetInstanceID() != value.GetInstanceID())
                    {
                        m_splat4 = value;
                        SetDirty(this, false, false);
                    }
                }
            }
        }
        [SerializeField]
        private Texture2D m_splat4;

        /// <summary>
        /// Whether we should strip textures at runtime
        /// </summary>
        [SerializeField]
        public bool m_stripTexturesAtRuntime = true;

        /// <summary>
        /// Store a backup of the splats here if there is chance we will use unity shader
        /// </summary>
        [NonSerialized]
        private float [,,] m_splatBackupArray;

        /// <summary>
        /// Shader type
        /// </summary>
        [SerializeField]
        private CTSConstants.ShaderType m_activeShaderType = CTSConstants.ShaderType.Unity;

        /// <summary>
        /// Current terrain
        /// </summary>
        [NonSerialized]
        private Terrain m_terrain;

        /// <summary>
        /// Current material
        /// </summary>
        [NonSerialized]
        private Material m_material;

        /// <summary>
        /// Current material property block
        /// </summary>
        [NonSerialized]
        private MaterialPropertyBlock m_materialPropertyBlock;

        /// <summary>
        /// Flags used to decipher terrain changes
        /// </summary>
        [Flags]
        internal enum TerrainChangedFlags
        {
            NoChange = 0,
            Heightmap = 1 << 0,
            TreeInstances = 1 << 1,
            DelayedHeightmapUpdate = 1 << 2,
            FlushEverythingImmediately = 1 << 3,
            RemoveDirtyDetailsImmediately = 1 << 4,
            WillBeDestroyed = 1 << 8,
        }

		/// <summary>
		/// Called when scene loads
		/// </summary>
		void Awake()
        {
            if (m_terrain == null)
            {
                m_terrain = transform.GetComponent<Terrain>();
                if (m_terrain == null)
                {
                    Debug.LogWarning("CTS needs a terrain to work!");
                }
            }
        }

        /// <summary>
        /// Called when scene starts
        /// </summary>
        void Start()
        {
            
        }

		/// <summary>
		/// Automatically register this script when it's active
		/// </summary>
		void OnEnable()
		{
            //Setup the materials on the terrain
            ApplyMaterialAndUpdateShader();

            //Add shader tp management so that it responds to events
            CTSTerrainManager.Instance.RegisterShader(this);
		}

		/// <summary>
		/// Automatically unregister when it stops being active
		/// </summary>
		void OnDisable()
		{
			//Remove shader from management so that it can go out of scope nicely
			CTSTerrainManager.Instance.UnregisterShader(this);
		}

		/// <summary>
		/// Returns the first asset that matches the file path and name passed. Will try
		/// full path first, then will try just the file name.
		/// </summary>
		/// <param name="fileNameOrPath">File name as standalone or fully pathed</param>
		/// <returns>Object or null if it was not found</returns>
		public static UnityEngine.Object GetAsset(string fileNameOrPath, Type assetType)
        {
#if UNITY_EDITOR
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
#endif
            return null;
        }

        /// <summary>
        /// Get the asset path of the first thing that matches the name
        /// </summary>
        /// <param name="fileName">File name to search for</param>
        /// <returns></returns>
        public static string GetAssetPath(string fileName)
        {
#if UNITY_EDITOR
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
#endif
            return "";
        }

        /// <summary>
        /// Get the specified type if it exists
        /// </summary>
        /// <param name="TypeName">Name of the type to load</param>
        /// <returns>Selected type or null</returns>
        public static Type GetType(string TypeName)
        {
            // Try Type.GetType() first. This will work with types defined
            // by the Mono runtime, in the same assembly as the caller, etc.
            var type = Type.GetType(TypeName);

            // If it worked, then we're done here
            if (type != null)
                return type;

            // If the TypeName is a full name, then we can try loading the defining assembly directly
            if (TypeName.Contains("."))
            {
                // Get the name of the assembly (Assumption is that we are using 
                // fully-qualified type names)
                var assemblyName = TypeName.Substring(0, TypeName.IndexOf('.'));

                // Attempt to load the indicated Assembly
                try
                {
                    var assembly = Assembly.Load(assemblyName);
                    if (assembly == null)
                        return null;

                    // Ask that assembly to return the proper Type
                    type = assembly.GetType(TypeName);
                    if (type != null)
                        return type;
                }
                catch (Exception)
                {
                    //Debug.Log("Unable to load assemmbly : " + ex.Message);
                }
            }

            // If we still haven't found the proper type, we can enumerate all of the 
            // loaded assemblies and see if any of them define the type
            var currentAssembly = Assembly.GetCallingAssembly();
            {
                // Load the referenced assembly
                if (currentAssembly != null)
                {
                    // See if that assembly defines the named type
                    type = currentAssembly.GetType(TypeName);
                    if (type != null)
                        return type;
                }

            }

            //All loaded assemblies
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            for (int asyIdx = 0; asyIdx < assemblies.GetLength(0); asyIdx++)
            {
                type = assemblies[asyIdx].GetType(TypeName);
                if (type != null)
                {
                    return type;
                }
            }

            var referencedAssemblies = currentAssembly.GetReferencedAssemblies();
            foreach (var assemblyName in referencedAssemblies)
            {
                // Load the referenced assembly
                var assembly = Assembly.Load(assemblyName);
                if (assembly != null)
                {
                    // See if that assembly defines the named type
                    type = assembly.GetType(TypeName);
                    if (type != null)
                        return type;
                }
            }

            // The type just couldn't be found...
            return null;
        }

        /// <summary>
        /// Apply the unity shader
        /// </summary>
        private void ApplyUnityShader()
        {
            //Make sure we have terrain
            if (m_terrain == null)
            {
                m_terrain = transform.GetComponent<Terrain>();
                if (m_terrain == null)
                {
                    Debug.LogError("Unable to locate Terrain, apply unity shader cancelled.");
                    return;
                }
            }

            //Restore splats and textures if possible
            if (Application.isPlaying && m_profile != null)
            {
                if (m_splatBackupArray != null && m_splatBackupArray.GetLength(0) > 0)
                {
                    //Debug.Log("Restoring terrain textures and splatmaps");

                    //First restore textures from profile
                    ReplaceTerrainTexturesFromProfile(true);

                    //Then restore the splats
                    m_terrain.terrainData.SetAlphamaps(0, 0, m_splatBackupArray);

                    //And signal it
                    m_terrain.Flush();
                }
            }

            //Apply it
            m_terrain.basemapDistance = 2000f;
            m_activeShaderType = CTSConstants.ShaderType.Unity;

#if UNITY_2018_1_OR_NEWER
            if (GraphicsSettings.renderPipelineAsset == null)
            {
                SetBuiltInStandardMaterial(m_terrain);
            }
            else
            {
#if UNITY_2019_1_OR_NEWER
                Material defaultTerrainMaterial = GraphicsSettings.renderPipelineAsset.defaultTerrainMaterial; 
#else
                Material defaultTerrainMaterial = GraphicsSettings.renderPipelineAsset.GetDefaultTerrainMaterial();
#endif
                if (defaultTerrainMaterial != null)
                {
#if !UNITY_2019_2_OR_NEWER
                    m_terrain.materialType = Terrain.MaterialType.Custom;
#endif
                    m_terrain.materialTemplate = defaultTerrainMaterial;
                }
                else
                {
                    Debug.LogWarning("CTS could not find a default terrain material in your current rendering pipeline configuration. Reverting to built-in rendering terrain material.");
                    SetBuiltInStandardMaterial(m_terrain);
                }
            }
#else
                    m_terrain.materialType = Terrain.MaterialType.BuiltInStandard;
            m_terrain.materialTemplate = null;
#endif
            m_material = null;
            m_materialPropertyBlock = null;
        }

        private void SetBuiltInStandardMaterial(Terrain terrain)
        {
#if UNITY_2019_2_OR_NEWER
                //In 2019.2 & above the template type does not exist anymore, the default material cannot be accessed anymore by "switching back to built-in"
                 Material defaultMat = null;
#if UNITY_EDITOR
            //In editor scope we can fetch the "official" material from the hidden bulitin-unity-extras package
            UnityEngine.Object[] objs = UnityEditor.AssetDatabase.LoadAllAssetsAtPath("Resources/unity_builtin_extra");
                foreach (UnityEngine.Object o in objs)
                {
                    if (o.name == "Default-Terrain-Standard")
                    {
                        defaultMat = (Material)o;
                    }
                }
#else
            //outside of the editor we will just make up a material on the fly with the standard terrain shader
            defaultMat = new Material(Shader.Find("Nature/Terrain/Standard"));

#endif
            terrain.materialTemplate = defaultMat;
#else
            terrain.materialType = Terrain.MaterialType.BuiltInStandard;
            terrain.materialTemplate = null;
#endif
        }



        /// <summary>
        /// Set up correct material for use with the shader
        /// </summary>
        private void ApplyMaterial()
        {
            //Debug.Log("Apply Shader Material");

            //Make sure we have a terrain
            if (m_terrain == null)
            {
                m_terrain = transform.GetComponent<Terrain>();
                if (m_terrain == null)
                {
                    Debug.LogWarning("CTS needs terrain to function - exiting!");
                    return;
                }
            }

            //Make sure we have a profile
            if (m_profile == null)
            {
                Debug.Log("This CTS component has no profile - it will use Unity shading until a CTS profile is assigned.");
                ApplyUnityShader();
                return;
            }

            //Make sure the profile has texture arrays
            if (m_profile.AlbedosTextureArray == null)
            {
                Debug.LogWarning("CTS profile needs albedos texture array to function - applying unity shader and exiting!");
                m_profile.m_needsAlbedosArrayUpdate = true;
                ApplyUnityShader();
                return;
            }

            //if (m_profile.NormalsTextureArray == null)
            //{
            //    Debug.LogWarning("CTS profile needs normals texture array to function - applying unity shader and exiting!");
            //    m_profile.m_needsNormalsArrayUpdate = true;
            //    ApplyUnityShader();
            //    return;
            //}

            //Grab terrain splats if missing
            if (m_splat1 == null && m_terrain.terrainData.alphamapTextures.Length > 0)
            {
                m_splat1 = m_terrain.terrainData.alphamapTextures[0];
            }
            if (m_splat2 == null && m_terrain.terrainData.alphamapTextures.Length > 1)
            {
                m_splat2 = m_terrain.terrainData.alphamapTextures[1];
            }
            if (m_splat3 == null && m_terrain.terrainData.alphamapTextures.Length > 2)
            {
                m_splat3 = m_terrain.terrainData.alphamapTextures[2];
            }
            if (m_splat4 == null && m_terrain.terrainData.alphamapTextures.Length > 3)
            {
                m_splat4 = m_terrain.terrainData.alphamapTextures[3];
            }

            m_materialPropertyBlock = null;
            m_activeShaderType = m_profile.ShaderType;

#region old string based lookup


            /*
            switch (m_activeShaderType)
            {
                case CTSConstants.ShaderType.Unity:
                    ApplyUnityShader();
                    return;
                case CTSConstants.ShaderType.Lite:
                    m_material = CTSMaterials.GetMaterial(CTSConstants.CTSShaderLiteName, m_profile);
                    break;
                case CTSConstants.ShaderType.Basic:
                    if (!m_useCutout)
                    {
						m_material = CTSMaterials.GetMaterial(CTSConstants.CTSShaderBasicName, m_profile);
                    }
                    else
                    {
						m_material = CTSMaterials.GetMaterial(CTSConstants.CTSShaderBasicCutoutName, m_profile);
                    }
                    break;
                case CTSConstants.ShaderType.Advanced:
                    if (!m_useCutout)
                    {
						m_material = CTSMaterials.GetMaterial(CTSConstants.CTSShaderAdvancedName, m_profile);
                    }
                    else
                    {
						m_material = CTSMaterials.GetMaterial(CTSConstants.CTSShaderAdvancedCutoutName, m_profile);
                    }
                    break;
                case CTSConstants.ShaderType.Tesselation:
                    if (!m_useCutout)
                    {
						m_material = CTSMaterials.GetMaterial(CTSConstants.CTSShaderTesselatedName, m_profile);
                    }
                    else
                    {
						m_material = CTSMaterials.GetMaterial(CTSConstants.CTSShaderTesselatedCutoutName, m_profile);
                    }
                    break;
            }*/

#endregion

            if (m_activeShaderType == CTSConstants.ShaderType.Unity)
            {
                ApplyUnityShader();
                return;
            }
            else
            {
                CTSConstants.EnvironmentRenderer renderPipelineType = GetRenderPipeline();

                CTSConstants.ShaderFeatureSet shaderFeatureSet = GetShaderFeatureSet();

                CTSShaderCriteria criteria = new CTSShaderCriteria(renderPipelineType,m_profile.ShaderType,shaderFeatureSet);
                string shaderName;

                if (CTSConstants.shaderNames.TryGetValue(criteria, out shaderName))
                {
                    m_material = CTSMaterials.GetMaterial(shaderName, m_profile);
                }
                else
                {
                    Debug.LogErrorFormat("CTS could not find a valid shader for this configuration: -- Render Pipeline: {0} - Shader Type: {1} - Shader Feature Set: {2}", renderPipelineType, m_profile.ShaderType, shaderFeatureSet);
                    return;
                }
            }

            //Exit if necessary
            if (m_material == null)
            {
                Debug.LogErrorFormat("CTS could not locate shader {0} - exiting!", m_activeShaderType);
                return;
            }

            //Apply it to terrain
#if !UNITY_2019_2_OR_NEWER
            m_terrain.materialType = Terrain.MaterialType.Custom;
#endif
            m_terrain.materialTemplate = m_material;
            
			//Replace with optimal textures
			UpdateTerrainSplatsAtRuntime();
        }

        /// <summary>
        /// UpdateShader always grabs the appropriate material and sets the material properties on it, since we aren't creating a material
        /// except when a new profile is used.
        /// </summary>
        public void ApplyMaterialAndUpdateShader()
        {
            //Make sure profile is not disconnected
            if (!IsProfileConnected)
            {
                //profile disconnected, no updates possible
                return;
            }


            //Make sure we have profile - if not then set to unity as the shader
            if (m_profile == null)
            {
                ApplyMaterial();
            }
            else
            {
                if (m_activeShaderType != m_profile.ShaderType || m_profile.m_currentRenderPipelineType != GetRenderPipeline() || m_materialNeedsReapply)
                {
                    ApplyMaterial();
                    m_materialNeedsReapply = false;
                }
            }
            if (m_activeShaderType != CTSConstants.ShaderType.Unity)
            {
                UpdateShader();
            }
        }

        /// <summary>
        /// Update the shader settings into the terrain's MaterialPropertyBlock
        /// </summary>
        public void UpdateShader()
        {
            //Debug.LogFormat("UpdateShader({0})", m_activeShaderType);

            //Make sure we have terrain
            if (m_terrain == null)
            {
                m_terrain = transform.GetComponent<Terrain>();
                if (m_terrain == null)
                {
                    Debug.LogWarning("CTS missing terrain, cannot operate without terrain!");
                    return;
                }
            }

            //Make sure we have profile
            if (m_profile == null)
            {
                Debug.LogWarning("Missing CTS profile!");
                return;
            }

            //And albedo tex
            if (m_profile.AlbedosTextureArray == null)
            {
                Debug.LogError("Missing CTS texture array - rebake textures");
                return;
            }

            ////And normal tex
            //if (m_profile.NormalsTextureArray == null)
            //{
            //    Debug.LogError("Missing CTS texture array - rebake textures");
            //    return;
            //}

            //Check if number of terrain textures does not exceed 16 (16 are supported max)
            if (CTSSplatPrototype.GetNumberOfTerrainTextures(m_terrain.terrainData) > 16)
            {
                Debug.LogError("Found more than 16 textures on the terrain. CTS supports up to 16 textures, please reduce the texture count on the terrain.");
                return;
            }

          
            //Grab terrain splats if missing
            if (m_splat1 == null && m_terrain.terrainData.alphamapTextures.Length > 0)
            {
                m_splat1 = m_terrain.terrainData.alphamapTextures[0];
            }
            if (m_splat2 == null && m_terrain.terrainData.alphamapTextures.Length > 1)
            {
                m_splat2 = m_terrain.terrainData.alphamapTextures[1];
            }
            if (m_splat3 == null && m_terrain.terrainData.alphamapTextures.Length > 2)
            {
                m_splat3 = m_terrain.terrainData.alphamapTextures[2];
            }
            if (m_splat4 == null && m_terrain.terrainData.alphamapTextures.Length > 3)
            {
                m_splat4 = m_terrain.terrainData.alphamapTextures[3];
            }
            if (m_splat1 == null)
            {
                Debug.LogError("Missing splat textures - add some textures to your terrain");
                return;
            }
          
            //Measure this
            Stopwatch sw = Stopwatch.StartNew();

            //Make sure we have a material & it has the correct shader on it
            if (m_activeShaderType != m_profile.ShaderType || m_profile.m_currentRenderPipelineType != GetRenderPipeline() || m_material == null)
            {
                ApplyMaterial();
            }

            //Exit if unity shader
            if (m_activeShaderType == CTSConstants.ShaderType.Unity)
            {
                return;
            }

            //Still no material with a CTS shader? Exit with error message
            if (m_activeShaderType != CTSConstants.ShaderType.Unity && m_material == null)
            {
                Debug.LogError("Could not create a valid material for the CTS shader, shader properties can not be updated.");
                return;
            }


            //Set global profile settings - same across all terrains - on the material that is shared between terrains

            //Do we want to strip textures at runtime - will persist even when profile disconnected
            if (m_stripTexturesAtRuntime != m_profile.m_globalStripTexturesAtRuntime)
            {
                m_stripTexturesAtRuntime = m_profile.m_globalStripTexturesAtRuntime;
                SetDirty(this, false, false);
            }

#if UNITY_2018_3_OR_NEWER
            //DrawInstanced
            if (m_terrain.drawInstanced != m_profile.m_drawInstanced)
            {
                m_terrain.drawInstanced = m_profile.m_drawInstanced;
            }
#endif
            //Basemap distance
            if (m_terrain.basemapDistance != m_profile.m_globalBasemapDistance)
            {
                m_terrain.basemapDistance = m_profile.m_globalBasemapDistance;
            }

            //Albedo's
            m_material.SetTexture(CTSShaderID.Texture_Array_Albedo, m_profile.AlbedosTextureArray);

            //Normals
            m_material.SetTexture(CTSShaderID.Texture_Array_Normal, m_profile.NormalsTextureArray);

            //Global settings
            m_material.SetFloat(CTSShaderID.UV_Mix_Power, m_profile.m_globalUvMixPower);
            m_material.SetFloat(CTSShaderID.UV_Mix_Start_Distance, m_profile.m_globalUvMixStartDistance + UnityEngine.Random.Range(0.001f, 0.003f));
            m_material.SetFloat(CTSShaderID.Perlin_Normal_Tiling_Close, m_profile.m_globalDetailNormalCloseTiling);
            m_material.SetFloat(CTSShaderID.Perlin_Normal_Tiling_Far, m_profile.m_globalDetailNormalFarTiling);
            m_material.SetFloat(CTSShaderID.Perlin_Normal_Power, m_profile.m_globalDetailNormalFarPower);
            m_material.SetFloat(CTSShaderID.Perlin_Normal_Power_Close, m_profile.m_globalDetailNormalClosePower);
            m_material.SetFloat(CTSShaderID.Terrain_Smoothness, m_profile.m_globalTerrainSmoothness);
            m_material.SetFloat(CTSShaderID.Terrain_Specular, m_profile.m_globalTerrainSpecular);
            m_material.SetFloat(CTSShaderID.TessValue, m_profile.m_globalTesselationPower);
            m_material.SetFloat(CTSShaderID.TessMin, m_profile.m_globalTesselationMinDistance);
            m_material.SetFloat(CTSShaderID.TessMax, m_profile.m_globalTesselationMaxDistance);
            m_material.SetFloat(CTSShaderID.TessPhongStrength, m_profile.m_globalTesselationPhongStrength);
            m_material.SetFloat(CTSShaderID.TessDistance, m_profile.m_globalTesselationMaxDistance);
            m_material.SetInt(CTSShaderID.Ambient_Occlusion_Type, (int)m_profile.m_globalAOType);

            //AO
            if (m_profile.m_globalAOType == CTSConstants.AOType.None)
            {
                m_material.DisableKeyword("_Use_AO_ON");
                m_material.DisableKeyword("_USE_AO_TEXTURE_ON");
                m_material.SetInt(CTSShaderID.Use_AO, 0);
                m_material.SetInt(CTSShaderID.Use_AO_Texture, 0);
                m_material.SetFloat(CTSShaderID.Ambient_Occlusion_Power, 0f);
            }
            else if (m_profile.m_globalAOType == CTSConstants.AOType.NormalMapBased)
            {
                m_material.DisableKeyword("_USE_AO_TEXTURE_ON");
                m_material.SetInt(CTSShaderID.Use_AO_Texture, 0);
                if (m_profile.m_globalAOPower > 0)
                {
                    m_material.EnableKeyword("_USE_AO_ON");
                    m_material.SetInt(CTSShaderID.Use_AO, 1);
                    m_material.SetFloat(CTSShaderID.Ambient_Occlusion_Power, m_profile.m_globalAOPower);
                }
                else
                {
                    m_material.DisableKeyword("_USE_AO_ON");
                    m_material.SetInt(CTSShaderID.Use_AO, 0);
                    m_material.SetFloat(CTSShaderID.Ambient_Occlusion_Power, 0f);
                }
            }
            else
            {
                if (m_profile.m_globalAOPower > 0)
                {
                    m_material.EnableKeyword("_USE_AO_ON");
                    m_material.EnableKeyword("_USE_AO_TEXTURE_ON");
                    m_material.SetInt(CTSShaderID.Use_AO, 1);
                    m_material.SetInt(CTSShaderID.Use_AO_Texture, 1);
                    m_material.SetFloat(CTSShaderID.Ambient_Occlusion_Power, m_profile.m_globalAOPower);
                }
                else
                {
                    m_material.DisableKeyword("_USE_AO_ON");
                    m_material.DisableKeyword("_USE_AO_TEXTURE_ON");
                    m_material.SetInt(CTSShaderID.Use_AO, 0);
                    m_material.SetInt(CTSShaderID.Use_AO_Texture, 0);
                    m_material.SetFloat(CTSShaderID.Ambient_Occlusion_Power, 0f);
                }
            }

            //Global Detail
            if (m_profile.m_globalDetailNormalClosePower > 0f || m_profile.m_globalDetailNormalFarPower > 0f)
            {
                m_material.SetInt(CTSShaderID.Texture_Perlin_Normal_Index, m_profile.m_globalDetailNormalMapIdx);
            }
            else
            {
                m_material.SetInt(CTSShaderID.Texture_Perlin_Normal_Index, -1);
            }

            //Geological settings
            if (m_profile.GeoAlbedo != null)
            {
                if (m_profile.m_geoMapClosePower > 0f || m_profile.m_geoMapFarPower > 0f)
                {
                    m_material.SetFloat(CTSShaderID.Geological_Map_Offset_Close, m_profile.m_geoMapCloseOffset);
                    m_material.SetFloat(CTSShaderID.Geological_Map_Close_Power, m_profile.m_geoMapClosePower);
                    m_material.SetFloat(CTSShaderID.Geological_Tiling_Close, m_profile.m_geoMapTilingClose);
                    m_material.SetFloat(CTSShaderID.Geological_Map_Offset_Far, m_profile.m_geoMapFarOffset);
                    m_material.SetFloat(CTSShaderID.Geological_Map_Far_Power, m_profile.m_geoMapFarPower);
                    m_material.SetFloat(CTSShaderID.Geological_Tiling_Far, m_profile.m_geoMapTilingFar);
                    m_material.SetTexture(CTSShaderID.Texture_Geological_Map, m_profile.GeoAlbedo);
                }
                else
                {
                    m_material.SetFloat(CTSShaderID.Geological_Map_Close_Power, 0f);
                    m_material.SetFloat(CTSShaderID.Geological_Map_Far_Power, 0f);
                    m_material.SetTexture(CTSShaderID.Texture_Geological_Map, null);
                }
            }
            else
            {
                m_material.SetFloat(CTSShaderID.Geological_Map_Close_Power, 0f);
                m_material.SetFloat(CTSShaderID.Geological_Map_Far_Power, 0f);
                m_material.SetTexture(CTSShaderID.Texture_Geological_Map, null);
            }

            //Snow settings
            m_material.SetFloat(CTSShaderID.Snow_Amount, m_profile.m_snowAmount);
            m_material.SetInt(CTSShaderID.Texture_Snow_Index, m_profile.m_snowAlbedoTextureIdx);
            m_material.SetInt(CTSShaderID.Texture_Snow_Normal_Index, m_profile.m_snowNormalTextureIdx);
            m_material.SetInt(CTSShaderID.Texture_Snow_H_AO_Index, m_profile.m_snowHeightTextureIdx != -1 ? m_profile.m_snowHeightTextureIdx : m_profile.m_snowAOTextureIdx);
            m_material.SetTexture(CTSShaderID.Texture_Glitter, m_profile.SnowGlitter);
            m_material.SetFloat(CTSShaderID.Snow_Maximum_Angle, m_profile.m_snowMaxAngle);
            m_material.SetFloat(CTSShaderID.Snow_Maximum_Angle_Hardness, m_profile.m_snowMaxAngleHardness);
            m_material.SetFloat(CTSShaderID.Snow_Min_Height, m_profile.m_snowMinHeight);
            m_material.SetFloat(CTSShaderID.Snow_Min_Height_Blending, m_profile.m_snowMinHeightBlending);
            m_material.SetFloat(CTSShaderID.Snow_Noise_Power, m_profile.m_snowNoisePower);
            m_material.SetFloat(CTSShaderID.Snow_Noise_Tiling, m_profile.m_snowNoiseTiling);
            m_material.SetFloat(CTSShaderID.Snow_Normal_Scale, m_profile.m_snowNormalScale);
            m_material.SetFloat(CTSShaderID.Snow_Perlin_Power, m_profile.m_snowDetailPower);
            m_material.SetFloat(CTSShaderID.Snow_Tiling, m_profile.m_snowTilingClose);
            m_material.SetFloat(CTSShaderID.Snow_Tiling_Far_Multiplier, m_profile.m_snowTilingFar);
            m_material.SetFloat(CTSShaderID.Snow_Brightness, m_profile.m_snowBrightness);
            m_material.SetFloat(CTSShaderID.Snow_Blend_Normal, m_profile.m_snowBlendNormal);
            m_material.SetFloat(CTSShaderID.Snow_Smoothness, m_profile.m_snowSmoothness);
            m_material.SetFloat(CTSShaderID.Snow_Specular, m_profile.m_snowSpecular);
            m_material.SetFloat(CTSShaderID.Snow_Heightblend_Close, m_profile.m_snowHeightmapBlendClose);
            m_material.SetFloat(CTSShaderID.Snow_Heightblend_Far, m_profile.m_snowHeightmapBlendFar);
            m_material.SetFloat(CTSShaderID.Snow_Height_Contrast, m_profile.m_snowHeightmapContrast);
            m_material.SetFloat(CTSShaderID.Snow_Heightmap_Depth, m_profile.m_snowHeightmapDepth);
            m_material.SetFloat(CTSShaderID.Snow_Heightmap_MinHeight, m_profile.m_snowHeightmapMinValue);
            m_material.SetFloat(CTSShaderID.Snow_Heightmap_MaxHeight, m_profile.m_snowHeightmapMaxValue);
            m_material.SetFloat(CTSShaderID.Snow_Ambient_Occlusion_Power, m_profile.m_snowAOStrength);
            m_material.SetFloat(CTSShaderID.Snow_Tesselation_Depth, m_profile.m_snowTesselationDepth);
            m_material.SetVector(CTSShaderID.Snow_Color, new Vector4(m_profile.m_snowTint.r * m_profile.m_snowBrightness, m_profile.m_snowTint.g * m_profile.m_snowBrightness, m_profile.m_snowTint.b * m_profile.m_snowBrightness, m_profile.m_snowSmoothness));
            m_material.SetVector(CTSShaderID.Texture_Snow_Average, m_profile.m_snowAverage);

            m_material.SetFloat(CTSShaderID.Glitter_Color_Power, m_profile.m_snowGlitterColorPower);
            m_material.SetFloat(CTSShaderID.Glitter_Noise_Threshold, m_profile.m_snowGlitterNoiseThreshold);
            m_material.SetFloat(CTSShaderID.Glitter_Specular, m_profile.m_snowGlitterSpecularPower);
            m_material.SetFloat(CTSShaderID.Glitter_Smoothness, m_profile.m_snowGlitterSmoothness);
            m_material.SetFloat(CTSShaderID.Glitter_Refreshing_Speed, m_profile.m_snowGlitterRefreshSpeed);
            m_material.SetFloat(CTSShaderID.Glitter_Tiling, m_profile.m_snowGlitterTiling);

            //Push per texture based settings
            CTSTerrainTextureDetails td;
            for (int i = 0; i < m_profile.TerrainTextures.Count; i++)
            {
                td = m_profile.TerrainTextures[i];

                m_material.SetInt(CTSShaderID.Texture_X_Albedo_Index[i], td.m_albedoIdx);
                m_material.SetInt(CTSShaderID.Texture_X_Normal_Index[i], td.m_normalIdx);
                m_material.SetInt(CTSShaderID.Texture_X_H_AO_Index[i], td.m_heightIdx != -1 ? td.m_heightIdx : td.m_aoIdx);

                m_material.SetFloat(CTSShaderID.Texture_X_Tiling[i], td.m_albedoTilingClose);
                m_material.SetFloat(CTSShaderID.Texture_X_Far_Multiplier[i], td.m_albedoTilingFar);
                m_material.SetFloat(CTSShaderID.Texture_X_Perlin_Power[i], td.m_detailPower);
                m_material.SetFloat(CTSShaderID.Texture_X_Snow_Reduction[i], td.m_snowReductionPower);
                m_material.SetFloat(CTSShaderID.Texture_X_Geological_Power[i], td.m_geologicalPower);
                m_material.SetFloat(CTSShaderID.Texture_X_Heightmap_Depth[i], td.m_heightDepth);
                m_material.SetFloat(CTSShaderID.Texture_X_Height_Contrast[i], td.m_heightContrast);
                m_material.SetFloat(CTSShaderID.Texture_X_Heightblend_Close[i], td.m_heightBlendClose);
                m_material.SetFloat(CTSShaderID.Texture_X_Heightblend_Far[i], td.m_heightBlendFar);
                m_material.SetFloat(CTSShaderID.Texture_X_Tesselation_Depth[i], td.m_heightTesselationDepth);
                m_material.SetFloat(CTSShaderID.Texture_X_Heightmap_MinHeight[i], td.m_heightMin);
                m_material.SetFloat(CTSShaderID.Texture_X_Heightmap_MaxHeight[i], td.m_heightMax);
                m_material.SetFloat(CTSShaderID.Texture_X_AO_Power[i], td.m_aoPower);
                m_material.SetFloat(CTSShaderID.Texture_X_Normal_Power[i], td.m_normalStrength);
                m_material.SetFloat(CTSShaderID.Texture_X_Triplanar[i], td.m_triplanar ? 1f : 0f);
                m_material.SetVector(CTSShaderID.Texture_X_Average[i], td.m_albedoAverage);
                m_material.SetVector(CTSShaderID.Texture_X_Color[i], new Vector4(td.m_tint.r * td.m_tintBrightness, td.m_tint.g * td.m_tintBrightness, td.m_tint.b * td.m_tintBrightness, td.m_smoothness));
            }

            //And fill out rest as well
            for (int i = m_profile.TerrainTextures.Count; i < 16; i++)
            {
                m_material.SetInt(CTSShaderID.Texture_X_Albedo_Index[i], -1);
                m_material.SetInt(CTSShaderID.Texture_X_Normal_Index[i], -1);
                m_material.SetInt(CTSShaderID.Texture_X_H_AO_Index[i], -1);
            }

            // Handle MCB based updates
            if (m_profile.m_useMaterialControlBlock)
            {
                // Create the MPB if we don't already have one
                if (m_materialPropertyBlock == null)
                {
                    m_materialPropertyBlock = new MaterialPropertyBlock();
                }

                //Now use this to apply terrain specific overrides
                m_terrain.GetSplatMaterialPropertyBlock(m_materialPropertyBlock);

                //Splats
                m_materialPropertyBlock.SetTexture(CTSShaderID.Texture_Splat_1, m_splat1);
                if (m_splat2 != null)
                {
                    m_materialPropertyBlock.SetTexture(CTSShaderID.Texture_Splat_2, m_splat2);
                }

                if (m_splat3 != null)
                {
                    m_materialPropertyBlock.SetTexture(CTSShaderID.Texture_Splat_3, m_splat3);
                }

                if (m_splat4 != null)
                {
                    m_materialPropertyBlock.SetTexture(CTSShaderID.Texture_Splat_4, m_splat4);
                }

                //Cutout
                m_materialPropertyBlock.SetFloat(CTSShaderID.Remove_Vert_Height, m_cutoutHeight);
                if (m_cutoutMask != null)
                {
                    m_materialPropertyBlock.SetTexture(CTSShaderID.Terrain_Holes_Texture, m_cutoutMask);
                }

                //Global Normal Map
                if (NormalMap != null)
                {
                    m_materialPropertyBlock.SetFloat(CTSShaderID.Global_Normalmap_Power, m_profile.m_globalNormalPower);
                    if (m_profile.m_globalNormalPower > 0f && NormalMap != null)
                    {
                        m_materialPropertyBlock.SetTexture(CTSShaderID.Global_Normal_Map, NormalMap);
                    }
                }
                else
                {
                    m_materialPropertyBlock.SetFloat(CTSShaderID.Global_Normalmap_Power, 0f);
                }

                //Colormap settings
                if (ColorMap != null)
                {
                    m_materialPropertyBlock.SetFloat(CTSShaderID.Global_Color_Map_Far_Power, m_profile.m_colorMapFarPower);
                    m_materialPropertyBlock.SetFloat(CTSShaderID.Global_Color_Map_Close_Power, m_profile.m_colorMapClosePower);
                    m_materialPropertyBlock.SetFloat(CTSShaderID.Global_Color_Opacity_Power, m_profile.m_colorMapOpacity);
                    if (m_profile.m_colorMapFarPower > 0f || m_profile.m_colorMapClosePower > 0f)
                    {
                        m_materialPropertyBlock.SetTexture(CTSShaderID.Global_Color_Map, ColorMap);
                    }
                }
                else
                {
                    m_materialPropertyBlock.SetFloat(CTSShaderID.Global_Color_Map_Far_Power, 0f);
                    m_materialPropertyBlock.SetFloat(CTSShaderID.Global_Color_Map_Close_Power, 0f);
                    m_materialPropertyBlock.SetFloat(CTSShaderID.Global_Color_Opacity_Power, 0f);
                }

                m_terrain.SetSplatMaterialPropertyBlock(m_materialPropertyBlock);  // set all the values we can
            }
            else
            {
                //Splats
                m_material.SetTexture(CTSShaderID.Texture_Splat_1, m_splat1);
                if (m_splat2 != null)
                {
                    m_material.SetTexture(CTSShaderID.Texture_Splat_2, m_splat2);
                }

                if (m_splat3 != null)
                {
                    m_material.SetTexture(CTSShaderID.Texture_Splat_3, m_splat3);
                }

                if (m_splat4 != null)
                {
                    m_material.SetTexture(CTSShaderID.Texture_Splat_4, m_splat4);
                }

                //Cutout
                m_material.SetFloat(CTSShaderID.Remove_Vert_Height, m_cutoutHeight);
                if (m_cutoutMask != null)
                {
                    m_material.SetTexture(CTSShaderID.Terrain_Holes_Texture, m_cutoutMask);
                }

                //Global Normal Map
                if (NormalMap != null)
                {
                    m_material.SetFloat(CTSShaderID.Global_Normalmap_Power, m_profile.m_globalNormalPower);
                    if (m_profile.m_globalNormalPower > 0f && NormalMap != null)
                    {
                        m_material.SetTexture(CTSShaderID.Global_Normal_Map, NormalMap);
                    }
                }
                else
                {
                    m_material.SetFloat(CTSShaderID.Global_Normalmap_Power, 0f);
                }

                //Colormap settings
                if (ColorMap != null)
                {
                    m_material.SetFloat(CTSShaderID.Global_Color_Map_Far_Power, m_profile.m_colorMapFarPower);
                    m_material.SetFloat(CTSShaderID.Global_Color_Map_Close_Power, m_profile.m_colorMapClosePower);
                    m_material.SetFloat(CTSShaderID.Global_Color_Opacity_Power, m_profile.m_colorMapOpacity);
                    if (m_profile.m_colorMapFarPower > 0f || m_profile.m_colorMapClosePower > 0f)
                    {
                        m_material.SetTexture(CTSShaderID.Global_Color_Map, ColorMap);
                    }
                }
                else
                {
                    m_material.SetFloat(CTSShaderID.Global_Color_Map_Far_Power, 0f);
                    m_material.SetFloat(CTSShaderID.Global_Color_Map_Close_Power, 0f);
                    m_material.SetFloat(CTSShaderID.Global_Color_Opacity_Power, 0f);
                }
            }

            
            m_material.renderQueue = m_profile.m_renderQueue;
            

            if (sw.ElapsedMilliseconds > 5)
            {
                //Debug.LogFormat("CTS updated {0} in {1} ms", this.name, sw.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Update profile settings from terrain and refresh shader
        /// </summary>
        public void UpdateProfileFromTerrainForced()
        {
            //Make sure we have terrain
            if (m_terrain == null)
            {
                m_terrain = transform.GetComponent<Terrain>();
                if (m_terrain == null)
                {
                    Debug.LogError("CTS is missing terrain, cannot update.");
                    return;
                }
            }

            //Make sure we have 16 textures max
            if (CTSSplatPrototype.GetNumberOfTerrainTextures(m_terrain.terrainData) > 16)
            {
                Debug.LogError("Found more than 16 textures on the terrain. CTS supports up to 16 textures, please reduce the texture count on the terrain.");
                return;
            }

            m_profile.UpdateSettingsFromTerrain(m_terrain, true);
            ApplyMaterialAndUpdateShader();
        }

        /// <summary>
        /// Check to see if the profile needs a texture update
        /// </summary>
        /// <returns>True if it does, false otherwise</returns>
        private bool ProfileNeedsTextureUpdate()
        {
            //Make sure we have terrain
            if (m_terrain == null)
            {
                m_terrain = transform.GetComponent<Terrain>();
            }
            if (m_terrain == null)
            {
                Debug.LogWarning("No terrain , unable to check if needs texture update");
                return false;
            }

            if (m_profile == null)
            {
                Debug.LogWarning("No profile, unable to check if needs texture update");
                return false;
            }

            if (m_profile.TerrainTextures.Count == 0)
            {
                return false;
            }

            //Now check the terrain splats against the profile splats
            CTSSplatPrototype[] splats = CTSSplatPrototype.GetCTSSplatPrototypes(m_terrain);
            if (m_profile.TerrainTextures.Count != splats.Length)
            {
                return true;
            }

            //Check each individual texture
            CTSSplatPrototype splatProto;
            CTSTerrainTextureDetails terrainDetail;
            for (int idx = 0; idx < splats.Length; idx++)
            {
                terrainDetail = m_profile.TerrainTextures[idx];
                splatProto = splats[idx];
                if (terrainDetail.Albedo == null)
                {
                    if (splatProto.texture != null)
                    {
                        return true;
                    }
                }
                else
                {
                    if (splatProto.texture == null)
                    {
                        return true;
                    }
                    else
                    {
                        if (terrainDetail.Albedo.name != splatProto.texture.name)
                        {
                            return true;
                        }
                    }
                }

                if (terrainDetail.Normal == null)
                {
                    if (splatProto.normalMap != null)
                    {
                        return true;
                    }
                }
                else
                {
                    if (splatProto.normalMap == null)
                    {
                        return true;
                    }
                    else
                    {
                        if (terrainDetail.Normal.name != splatProto.normalMap.name)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check to see if the terrain needs a texture update
        /// </summary>
        /// <returns></returns>
        private bool TerrainNeedsTextureUpdate()
        {
            //Make sure we have terrain
            if (m_terrain == null)
            {
                m_terrain = transform.GetComponent<Terrain>();
            }
            if (m_terrain == null)
            {
                Debug.LogWarning("No terrain , unable to check if needs texture update");
                return false;
            }

            if (m_profile == null)
            {
                Debug.LogWarning("No profile, unable to check if needs texture update");
                return false;
            }

            if (m_profile.TerrainTextures.Count == 0)
            {
                return false;
            }

            //Now check the terrain splats against the profile splats
            CTSSplatPrototype[] splats = CTSSplatPrototype.GetCTSSplatPrototypes(m_terrain);
            if (m_profile.TerrainTextures.Count != splats.Length)
            {
                return true;
            }

            //Check each individual texture
            CTSSplatPrototype splatProto;
            CTSTerrainTextureDetails terrainDetail;
            for (int idx = 0; idx < splats.Length; idx++)
            {
                terrainDetail = m_profile.TerrainTextures[idx];
                splatProto = splats[idx];
                if (terrainDetail.Albedo == null)
                {
                    if (splatProto.texture != null)
                    {
                        return true;
                    }
                }
                else
                {
                    if (splatProto.texture == null)
                    {
                        return true;
                    }
                    if (terrainDetail.Albedo.name != splatProto.texture.name)
                    {
                        return true;
                    }
                    if (terrainDetail.m_albedoTilingClose != splatProto.tileSize.x)
                    {
                        return true;
                    }
                }

                if (terrainDetail.Normal == null)
                {
                    if (splatProto.normalMap != null)
                    {
                        return true;
                    }
                }
                else
                {
                    if (splatProto.normalMap == null)
                    {
                        return true;
                    }
                    if (terrainDetail.Normal.name != splatProto.normalMap.name)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Replace the existing texture in the terrain with a new one
        /// </summary>
        /// <param name="texture">New texture</param>
        /// <param name="textureIdx">Index of texture</param>
        /// <param name="tiling">Tiling</param>
        public void ReplaceAlbedoInTerrain(Texture2D texture, int textureIdx, float tiling)
        {
            //Make sure we have terrain
            if (m_terrain == null)
            {
                m_terrain = transform.GetComponent<Terrain>();
            }

            if (m_terrain != null)
            {
                CTSSplatPrototype[] splats = CTSSplatPrototype.GetCTSSplatPrototypes(m_terrain);
                if (textureIdx >= 0 && textureIdx < splats.Length)
                {
                    splats[textureIdx].texture = texture;
                    splats[textureIdx].tileSize = new Vector2(tiling, tiling);
                    CTSSplatPrototype.SetCTSSplatPrototypes(m_terrain, splats, ref m_profile);
                    m_terrain.Flush();
                    SetDirty(m_terrain, false, false);
                }
                else
                {
                    Debug.LogWarning("Invalid texture index in replace albedo");
                }
            }
        }

        /// <summary>
        /// Replace the existing normal texture in the terrain with a new one
        /// </summary>
        /// <param name="texture">New texture</param>
        /// <param name="textureIdx">Index of texture</param>
        /// <param name="tiling">Tiling</param>
        public void ReplaceNormalInTerrain(Texture2D texture, int textureIdx, float tiling)
        {
            //Make sure we have terrain
            if (m_terrain == null)
            {
                m_terrain = transform.GetComponent<Terrain>();
            }

            if (m_terrain != null)
            {
                CTSSplatPrototype[] splats = CTSSplatPrototype.GetCTSSplatPrototypes(m_terrain);
                if (textureIdx >= 0 && textureIdx < splats.Length)
                {
                    splats[textureIdx].normalMap = texture;
                    splats[textureIdx].tileSize = new Vector2(tiling, tiling);
                    CTSSplatPrototype.SetCTSSplatPrototypes(m_terrain,splats, ref m_profile);
                    m_terrain.Flush();
                    SetDirty(m_terrain, false, false);
                }
                else
                {
                    Debug.LogWarning("Invalid texture index in replace normal!");
                }
            }
        }

        /// <summary>
        /// Construct normal from terrain
        /// </summary>
        public void BakeTerrainNormals()
        {
            //Make sure we have terrain
            if (m_terrain == null)
            {
                m_terrain = transform.GetComponent<Terrain>();
            }
            if (m_terrain == null)
            {
                Debug.LogWarning("Could not make terrain normal, as terrain object not set.");
                return;
            }

#if UNITY_EDITOR
            EditorUtility.DisplayProgressBar("Baking Textures", "Generating terrain normals : " + m_terrain.name, 0f);
#endif

            Texture2D nrmTex = CalculateNormals(m_terrain);
            nrmTex.name = m_terrain.name + " Nrm";
//            nrmTex.wrapMode = TextureWrapMode.Clamp;
//            nrmTex.filterMode = FilterMode.Bilinear;
//            nrmTex.anisoLevel = 8;

#if UNITY_EDITOR
            EditorUtility.DisplayProgressBar("Baking Textures", "Encoding terrain normals : " + m_terrain.name + "..", 0f);
            string normalsPath = GetCTSDirectory() + "Terrains/";
            if (!Directory.Exists(normalsPath))
            {
                Directory.CreateDirectory(normalsPath);
            }
            normalsPath += nrmTex.name + ".png";   
            byte[] content = nrmTex.EncodeToPNG();
            File.WriteAllBytes(normalsPath, content);
            AssetDatabase.Refresh();

            //Import it back in as a normal map
            var importer = AssetImporter.GetAtPath(normalsPath) as TextureImporter;
            if (importer != null)
            {
                importer.isReadable = true;
                importer.textureType = TextureImporterType.NormalMap;
//                importer.textureCompression = TextureImporterCompression.Compressed;
//                importer.convertToNormalmap = true;
//                importer.heightmapScale = 0.1f;
//                importer.anisoLevel = 8;
//                importer.filterMode = FilterMode.Bilinear;
//                importer.mipmapEnabled = true;
//                importer.mipmapFilter = TextureImporterMipFilter.BoxFilter;
//                importer.normalmapFilter = TextureImporterNormalFilter.Standard;
//                importer.wrapMode = TextureWrapMode.Clamp;
                AssetDatabase.ImportAsset(normalsPath, ImportAssetOptions.ForceUpdate);
                AssetDatabase.Refresh();
            }

            //Load & assign it
            nrmTex = AssetDatabase.LoadAssetAtPath<Texture2D>(normalsPath);
            EditorUtility.ClearProgressBar();
#endif

            NormalMap = nrmTex;
        }


        /// <summary>
        /// Calculate the normals for the terrain
        /// </summary>
        /// <returns>Normals for the terrain</returns>
        public Texture2D CalculateNormals(Terrain terrain)
        {
            int width = terrain.terrainData.heightmapResolution;
            int height = terrain.terrainData.heightmapResolution;
            float ux = 1.0f / (width - 1.0f);
            float uy = 1.0f / (height - 1.0f);
            float terrainHeight = width / 2f;
            float scaleX = terrainHeight / (float)width;
            float scaleY = terrainHeight / (float)height;
            float[] heights = new float[width * height];
            Buffer.BlockCopy(terrain.terrainData.GetHeights(0,0,width,height), 0, heights, 0, heights.Length * sizeof(float));
            Texture2D normalMap = new Texture2D(width, height, TextureFormat.RGBAFloat, false, true);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int xp1 = (x == width - 1) ? x : x + 1;
                    int xn1 = (x == 0) ? x : x - 1;

                    int yp1 = (y == height - 1) ? y : y + 1;
                    int yn1 = (y == 0) ? y : y - 1;

                    float l = heights[xn1 + y * width] * scaleX;
                    float r = heights[xp1 + y * width] * scaleX;

                    float b = heights[x + yn1 * width] * scaleY;
                    float t = heights[x + yp1 * width] * scaleY;

                    float dx = (r - l) / (2.0f * ux);
                    float dy = (t - b) / (2.0f * uy);

                    Vector3 normal;
                    normal.x = -dx;
                    normal.y = -dy;
                    normal.z = 1;
                    normal.Normalize();

                    Color pixel;
                    pixel.r = normal.x * 0.5f + 0.5f;
                    pixel.g = normal.y * 0.5f + 0.5f;
                    pixel.b = normal.z;
                    pixel.a = 1.0f;

                    normalMap.SetPixel(x, y, pixel);
                }
            }
            normalMap.Apply();
            return normalMap;
        }






        /// <summary>
        /// Construct base map from terrain
        /// </summary>
        public void BakeTerrainBaseMap()
        {
            //Make sure we have terrain
            if (m_terrain == null)
            {
                m_terrain = transform.GetComponent<Terrain>();
            }
            if (m_terrain == null)
            {
                Debug.LogWarning("Could not make terrain base map, as terrain object not set.");
                return;
            }

#if UNITY_EDITOR
            EditorUtility.DisplayProgressBar("Baking Textures", "Generating terrain basemap : " + m_terrain.name, 0f);
#endif

            int width = 2048;
            int height = 2048;
            Texture2D terrainSplat;
            Texture2D[] terrainSplats = m_terrain.terrainData.alphamapTextures;
            CTSSplatPrototype[] terrainSplatPrototypes = CTSSplatPrototype.GetCTSSplatPrototypes(m_terrain);
            if (terrainSplats.Length > 0)
            {
                width = terrainSplats[0].width;
                height = terrainSplats[0].height;
            }
            float dimensions = width * height;

            //Get the average colours of the terrain textures by using the highest mip
            Color splatColor;
            Color[] averageSplatColors = new Color[terrainSplatPrototypes.Length];
            CTSSplatPrototype proto;
            for (int protoIdx = 0; protoIdx < terrainSplatPrototypes.Length; protoIdx++)
            {
                proto = terrainSplatPrototypes[protoIdx];
                Texture2D tmpTerrainTex = CTSProfile.ResizeTexture(proto.texture, TextureFormat.ARGB32, 8, width, height, true, false, false);
                Color[] maxMipColors = tmpTerrainTex.GetPixels(tmpTerrainTex.mipmapCount - 1);
                averageSplatColors[protoIdx] = new Color(maxMipColors[0].r, maxMipColors[0].g, maxMipColors[0].b, maxMipColors[0].a);
            }

//            //Resize / get the alpha map
//            Texture2D alphamap = null;
//            if (m_cutoutMask != null)
//            {
//                alphamap = CTSProfile.ResizeTexture(m_cutoutMask, TextureFormat.ARGB32, 8, width, height, true, false, false);
//            }

            //Create the new texture
            Texture2D colorTex = new Texture2D(width, height, TextureFormat.RGBA32, false);
            colorTex.name = m_terrain.name + "_BaseMap";
            colorTex.wrapMode = TextureWrapMode.Repeat;
            colorTex.filterMode = FilterMode.Bilinear;
            colorTex.anisoLevel = 8;

            for (int x = 0; x < width; x++)
            {
#if UNITY_EDITOR
                if (x % 250 == 0)
                {
                    EditorUtility.DisplayProgressBar("Baking Textures", "Ingesting terrain basemap : " + m_terrain.name + "..", (float)(x * width) / dimensions);
                }
#endif

                for (int z = 0; z < height; z++)
                {
                    int splatColorIdx = 0;
                    Color mapColor = Color.black;
                    for (int splatIdx = 0; splatIdx < terrainSplats.Length; splatIdx++)
                    {
                        terrainSplat = terrainSplats[splatIdx];
                        splatColor = terrainSplat.GetPixel(x, z);
                        if (splatColorIdx < averageSplatColors.Length)
                        {
                            mapColor = Color.Lerp(mapColor, averageSplatColors[splatColorIdx++], splatColor.r);
                        }
                        if (splatColorIdx < averageSplatColors.Length)
                        {
                            mapColor = Color.Lerp(mapColor, averageSplatColors[splatColorIdx++], splatColor.g);
                        }
                        if (splatColorIdx < averageSplatColors.Length)
                        {
                            mapColor = Color.Lerp(mapColor, averageSplatColors[splatColorIdx++], splatColor.b);
                        }
                        if (splatColorIdx < averageSplatColors.Length)
                        {
                            mapColor = Color.Lerp(mapColor, averageSplatColors[splatColorIdx++], splatColor.a);
                        }
                        mapColor.a = 1f;
                    }
//                    if (alphamap != null)
//                    {
//                        mapColor.a = alphamap.GetPixel(x, z).grayscale;
//                    }
                    colorTex.SetPixel(x, z, mapColor);
                }
            }
            colorTex.Apply();

#if UNITY_EDITOR
            EditorUtility.DisplayProgressBar("Baking Textures", "Encoding terrain basemap : " + m_terrain.name + "..", 0f);

            //Save it
//            string cmapPath = AssetDatabase.GetAssetPath(m_material);
//            if (string.IsNullOrEmpty(cmapPath))
//            {
//                cmapPath = string.Format("{0}Terrains/{1}_BaseMap.png", GetCTSDirectory(), m_material.name);
//                cmapPath = cmapPath.Replace(".mat", "");
//            }
//            else
//            {
//                cmapPath = cmapPath.Replace(".mat", "_BaseMap.png");
//            }

			// save the basemap in the CTS/Terrains folder based off the object name it's assigned to, since we don't save materials anymore
			string cmapPath = GetCTSDirectory() + "Terrains/" + colorTex.name + ".png";   

            Directory.CreateDirectory(GetCTSDirectory() + "Terrains/");
            byte[] content = colorTex.EncodeToPNG();
            File.WriteAllBytes(cmapPath, content);
            AssetDatabase.Refresh();

            //Load & assign it
            colorTex = AssetDatabase.LoadAssetAtPath<Texture2D>(cmapPath);
            EditorUtility.ClearProgressBar();
#endif

            ColorMap = colorTex;
        }

        /// <summary>
        /// Construct base map from terrain and grass
        /// </summary>
        public void BakeTerrainBaseMapWithGrass()
        {
            //Make sure we have terrain
            if (m_terrain == null)
            {
                m_terrain = transform.GetComponent<Terrain>();
            }
            if (m_terrain == null)
            {
                Debug.LogWarning("Could not make terrain base map, as terrain object not set.");
                return;
            }

#if UNITY_EDITOR
            EditorUtility.DisplayProgressBar("Baking Textures", "Generating terrain basemap : " + m_terrain.name, 0f);
#endif

            int width = 2048;
            int height = 2048;
            Texture2D terrainSplat;
            Texture2D[] terrainSplats = m_terrain.terrainData.alphamapTextures;
            CTSSplatPrototype[] terrainSplatPrototypes = CTSSplatPrototype.GetCTSSplatPrototypes(m_terrain);
            if (terrainSplats.Length > 0)
            {
                width = terrainSplats[0].width;
                height = terrainSplats[0].height;
            }
            float dimensions = width * height;

            //Get the average colours of the terrain textures by using the highest mip
            Color splatColor;
            Color[] averageSplatColors = new Color[terrainSplatPrototypes.Length];
            CTSSplatPrototype proto;
            for (int protoIdx = 0; protoIdx < terrainSplatPrototypes.Length; protoIdx++)
            {
                proto = terrainSplatPrototypes[protoIdx];
                Texture2D tmpTerrainTex = CTSProfile.ResizeTexture(proto.texture, TextureFormat.ARGB32, 8, width, height, true, false, false);
                Color[] maxMipColors = tmpTerrainTex.GetPixels(tmpTerrainTex.mipmapCount - 1);
                averageSplatColors[protoIdx] = new Color(maxMipColors[0].r, maxMipColors[0].g, maxMipColors[0].b, maxMipColors[0].a);
            }

            //Get the average colours of the terrain grasses by using the highest mip
            List<Color> averageGrassColors = new List<Color>();
            DetailPrototype grassProto;
            DetailPrototype[] grassPrototypes = m_terrain.terrainData.detailPrototypes;
            List<CTSHeightMap> grassArrays = new List<CTSHeightMap>();
            int grassArrayWidth = m_terrain.terrainData.detailWidth;
            int grassArrayHeight = m_terrain.terrainData.detailHeight;

            for (int protoIdx = 0; protoIdx < grassPrototypes.Length; protoIdx++)
            {
                grassProto = grassPrototypes[protoIdx];
                if (grassProto.usePrototypeMesh == false && grassProto.prototypeTexture != null)
                {
                    //Get the detail array
                    grassArrays.Add(new CTSHeightMap(m_terrain.terrainData.GetDetailLayer(0, 0, grassArrayWidth, grassArrayHeight, protoIdx)));

                    //Resize it to get around read restrictions
                    Texture2D tmpGrassTex = CTSProfile.ResizeTexture(grassProto.prototypeTexture, TextureFormat.ARGB32, 8, grassArrayWidth, grassArrayHeight, true, false, false);

                    //Get the mip colour
                    Color[] maxMipColors = tmpGrassTex.GetPixels(tmpGrassTex.mipmapCount - 1);
                    Color grassColor = new Color(maxMipColors[0].r, maxMipColors[0].g, maxMipColors[0].b, 1f);

                    //Need to consider the detail colour as well - make an average based on noise spread
                    Color grassTint = Color.Lerp(grassProto.healthyColor, grassProto.dryColor, 0.2f);

                    //And now apply it to grass color
                    grassColor = Color.Lerp(grassColor, grassTint, 0.3f);

                    //And store
                    averageGrassColors.Add(grassColor);
                }
            }

            //Resize / get the alpha map
//            Texture2D alphamap = null;
//            if (m_cutoutMask != null)
//            {
//                alphamap = CTSProfile.ResizeTexture(m_cutoutMask, TextureFormat.ARGB32, 8, width, height, true, false, false);
//            }

            //Create the new texture
            Texture2D colorTex = new Texture2D(width, height, TextureFormat.RGBA32, false);
            colorTex.name = m_terrain.name + "_BaseMap";
            colorTex.wrapMode = TextureWrapMode.Repeat;
            colorTex.filterMode = FilterMode.Bilinear;
            colorTex.anisoLevel = 8;

            for (int x = 0; x < width; x++)
            {
#if UNITY_EDITOR
                if (x % 250 == 0)
                {
                    EditorUtility.DisplayProgressBar("Baking Textures", "Ingesting terrain basemap : " + m_terrain.name + "..", (float)(x * width) / dimensions);
                }
#endif

                for (int z = 0; z < height; z++)
                {
                    int splatColorIdx = 0;
                    Color mapColor = Color.black;

                    //Make basemap
                    for (int splatIdx = 0; splatIdx < terrainSplats.Length; splatIdx++)
                    {
                        terrainSplat = terrainSplats[splatIdx];
                        splatColor = terrainSplat.GetPixel(x, z);
                        if (splatColorIdx < averageSplatColors.Length)
                        {
                            mapColor = Color.Lerp(mapColor, averageSplatColors[splatColorIdx++], splatColor.r);
                        }
                        if (splatColorIdx < averageSplatColors.Length)
                        {
                            mapColor = Color.Lerp(mapColor, averageSplatColors[splatColorIdx++], splatColor.g);
                        }
                        if (splatColorIdx < averageSplatColors.Length)
                        {
                            mapColor = Color.Lerp(mapColor, averageSplatColors[splatColorIdx++], splatColor.b);
                        }
                        if (splatColorIdx < averageSplatColors.Length)
                        {
                            mapColor = Color.Lerp(mapColor, averageSplatColors[splatColorIdx++], splatColor.a);
                        }
                    }

                    //Now add in the grass
                    for (int grassIdx = 0; grassIdx < averageGrassColors.Count; grassIdx++)
                    {
                        CTSHeightMap grassHm = grassArrays[grassIdx];
                        float grassStrength = grassHm[(float) z/(float) height, (float) x/(float) width] * m_bakeGrassMixStrength;
                        mapColor = Color.Lerp(mapColor, Color.Lerp(averageGrassColors[grassIdx], Color.black, m_bakeGrassDarkenAmount), grassStrength);
                    }

                    //Set alpha
                    mapColor.a = 1f;
//                    if (alphamap != null)
//                    {
//                        mapColor.a = alphamap.GetPixel(x, z).grayscale;
//                    }

                    //And keep it
                    colorTex.SetPixel(x, z, mapColor);
                }
            }

            colorTex.Apply();

#if UNITY_EDITOR
            EditorUtility.DisplayProgressBar("Baking Textures", "Encoding terrain basemap : " + m_terrain.name + "..", 0f);

            //Save it
//            string cmapPath = AssetDatabase.GetAssetPath(m_material);
//            if (string.IsNullOrEmpty(cmapPath))
//            {
//                cmapPath = string.Format("{0}Terrains/{1}_BaseMap.png", GetCTSDirectory(), m_material.name);
//                cmapPath = cmapPath.Replace(".mat", "");
//            }
//            else
//            {
//                cmapPath = cmapPath.Replace(".mat", "_BaseMap.png");
//            }

			// save the basemap in the CTS/Terrains folder based off the object name it's assigned to, since we don't save materials anymore
			string cmapPath = GetCTSDirectory() + "Terrains/" + colorTex.name + ".png";   

            Directory.CreateDirectory(GetCTSDirectory() + "Terrains/");
            byte[] content = colorTex.EncodeToPNG();
            File.WriteAllBytes(cmapPath, content);
            AssetDatabase.Refresh();

            //Load & assign it
            colorTex = AssetDatabase.LoadAssetAtPath<Texture2D>(cmapPath);
            EditorUtility.ClearProgressBar();
#endif

            ColorMap = colorTex;
        }

        /// <summary>
        /// We are going to replace the terrain with a new in memory one, and rip out all the splats in the new one
        /// </summary>
        private void UpdateTerrainSplatsAtRuntime()
        {
            //Make sure we only do this when application is playing
            if (!Application.isPlaying)
            {
                return;
            }

            //Make sure we have terrain
            if (m_terrain == null)
            {
                return;
            }

#if UNITY_2018_3_OR_NEWER
            //Make sure draw instanced is set as in the profile
            m_terrain.drawInstanced = m_profile.m_drawInstanced;
#endif
            //Make sure we have strip textures enabled
            if (m_profile != null)
            {
                m_stripTexturesAtRuntime = m_profile.m_globalStripTexturesAtRuntime;
            }
            if (!m_stripTexturesAtRuntime)
            {
                return;
            }

            //Make back up the splat maps - but only if we have none already - this should always be true first time thru
            if (m_splatBackupArray == null || m_splatBackupArray.GetLength(0) == 0)
            {
                m_splatBackupArray = m_terrain.terrainData.GetAlphamaps(0, 0, m_terrain.terrainData.alphamapWidth, m_terrain.terrainData.alphamapHeight);
            }

            //Only do rest if we are not unity shader
#if UNITY_2019_2_OR_NEWER
            if (m_terrain.materialTemplate.shader.name.Contains("CTS"))
            {
                return;
            }
#else
            if (m_terrain.materialType != Terrain.MaterialType.Custom)
            {
                return;
            }
#endif

            //Strip textures by making a replica of the terrain data - but only for first time thru
            if (!m_terrain.terrainData.name.EndsWith("_copy"))
            {
                //Then replicate the terrain data minus the splats
                TerrainData terrainData = new TerrainData();
                terrainData.name = m_terrain.terrainData.name + "_copy";
#if !UNITY_2019_3_OR_NEWER
                terrainData.thickness = m_terrain.terrainData.thickness;
#endif
                terrainData.alphamapResolution = m_terrain.terrainData.alphamapResolution;
                terrainData.baseMapResolution = m_terrain.terrainData.baseMapResolution;

                //Detail related
                //Reading detail resolution from the terrain data object was only added in 2018.3
                //adding a text field in the profile for the previous unity versions
#if UNITY_2018_3_OR_NEWER
                terrainData.SetDetailResolution(m_terrain.terrainData.detailResolution, m_terrain.terrainData.detailResolutionPerPatch);
#else
                terrainData.SetDetailResolution(m_terrain.terrainData.detailResolution, m_profile.m_targetDetailResolutionPerPatch);
#endif
                terrainData.detailPrototypes = m_terrain.terrainData.detailPrototypes;
                for (int dtlIdx = 0; dtlIdx < terrainData.detailPrototypes.Length; dtlIdx++)
                {
                    terrainData.SetDetailLayer(0, 0, dtlIdx, m_terrain.terrainData.GetDetailLayer(0, 0, terrainData.detailResolution, terrainData.detailResolution, dtlIdx));
                }
                terrainData.wavingGrassAmount = m_terrain.terrainData.wavingGrassAmount;
                terrainData.wavingGrassSpeed = m_terrain.terrainData.wavingGrassSpeed;
                terrainData.wavingGrassStrength = m_terrain.terrainData.wavingGrassStrength;
                terrainData.wavingGrassTint = m_terrain.terrainData.wavingGrassTint;

                //Tree related
                terrainData.treePrototypes = m_terrain.terrainData.treePrototypes;
                terrainData.treeInstances = m_terrain.terrainData.treeInstances;

                //Height related
                terrainData.heightmapResolution = m_terrain.terrainData.heightmapResolution;
                terrainData.SetHeights(0, 0, m_terrain.terrainData.GetHeights(0, 0, terrainData.heightmapResolution, terrainData.heightmapResolution));

                //Size
                terrainData.size = m_terrain.terrainData.size;

                //Assign to terrain
                m_terrain.terrainData = terrainData;
                m_terrain.Flush();

                //Update the collider
                TerrainCollider collider = m_terrain.gameObject.GetComponent<TerrainCollider>();
                if (collider != null)
                {
                    collider.terrainData = terrainData;
                }
            }

            //Remove old stuff from memory
            //            System.GC.Collect();  // this can be VERY expensive to run.
        }

        /// <summary>
        /// Replace the terrain textures dependent on the thing being done
        /// </summary>
        private void ReplaceTerrainTexturesFromProfile(bool ignoreStripTextures)
        {
            //Exit if no terrain
            if (m_terrain == null)
            {
                m_terrain = transform.GetComponent<Terrain>();
                if (m_terrain == null)
                {
                    return;
                }
            }

            //Exit if no profile
            if (m_profile == null)
            {
                Debug.LogWarning("No profile, unable to replace terrain textures");
                return;
            }

            //Exit if no textures
            if (m_profile.TerrainTextures.Count == 0)
            {
                Debug.LogWarning("No profile textures, unable to replace terrain textures");
                return;
            }

            //Exit if remove textures selected
            m_stripTexturesAtRuntime = m_profile.m_globalStripTexturesAtRuntime;
            if (Application.isPlaying && !ignoreStripTextures)
            {
                if (m_stripTexturesAtRuntime )
                {
                    return;
                }
            }

            //Create new splats
            CTSSplatPrototype[] splats = new CTSSplatPrototype[m_profile.TerrainTextures.Count];
            for (int idx = 0; idx < splats.Length; idx++)
            {
                splats[idx] = new CTSSplatPrototype();
                splats[idx].texture = m_profile.TerrainTextures[idx].Albedo;
                splats[idx].normalMap = m_profile.TerrainTextures[idx].Normal;
                splats[idx].tileSize = new Vector2(m_profile.TerrainTextures[idx].m_albedoTilingClose, m_profile.TerrainTextures[idx].m_albedoTilingClose);
            }

            //Push splats back to the terrain
            CTSSplatPrototype.SetCTSSplatPrototypes(m_terrain, splats, ref m_profile);
            m_terrain.Flush();

            //Mark terrain as dirty
            SetDirty(m_terrain, false, false);
        }

		/// <summary>Only GetCTSDirectory() should access this.  To get the directory, call the function.</summary>
		static private string s_ctsDirectory = null;

		/// <summary>
		/// Return the CTS directory in the project
		/// </summary>
		/// <returns>If in editor it returns the full cts directory, if in build, returns assets directory.</returns>
		public static string GetCTSDirectory()
        {
			if (string.IsNullOrEmpty(s_ctsDirectory))
			{
#if UNITY_EDITOR
				string[] assets = AssetDatabase.FindAssets("CTS_ReadMe", null);
				for (int idx = 0; idx < assets.Length; idx++)
				{
					string path = AssetDatabase.GUIDToAssetPath(assets[idx]);
					if (Path.GetFileName(path) == "CTS_ReadMe.txt")
					{
						s_ctsDirectory = Path.GetDirectoryName(path) + "/";
					}
				}
#else
				s_ctsDirectory = "Assets/Procedural Worlds/CTS/";
#endif
			}
			return s_ctsDirectory;
        }

        /// <summary>
        /// Marks the object and its scene if possible as dirty. NOTE: This will only work
        /// in the editor. It compiles out of builds.
        /// </summary>
        /// <param name="obj">Object to mark</param>
        /// <param name="recordUndo">Tell Unity we also want and undo option</param>
        /// <param name="isPlayingAllowed">Allow dirty when application is playing as well</param>
        public static void SetDirty(UnityEngine.Object obj, bool recordUndo, bool isPlayingAllowed)
        {
#if UNITY_EDITOR

            //Check to see if we are playing 
            if (!isPlayingAllowed && Application.isPlaying)
            {
                return;
            }

            //Check to see if we are really an object
            if (obj == null)
            {
                Debug.LogWarning("Attempting to set null object dirty");
                return;
            }

            //Undo
            if (recordUndo)
            {
                Undo.RecordObject(obj, "Made changes");
            }

            //Calling this everywhere - because unity doco so obscure
            EditorUtility.SetDirty(obj);

            //Mark the scene as dirty as well for non persisted objects
#if !(UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
            if (!Application.isPlaying && !EditorUtility.IsPersistent(obj))
                {
                    MonoBehaviour mb = obj as MonoBehaviour;
                    if (mb != null)
                    {
                        EditorSceneManager.MarkSceneDirty(mb.gameObject.scene);
                        return;
                    }
                    GameObject go = obj as GameObject;
                    if (go != null)
                    {
                        EditorSceneManager.MarkSceneDirty(go.scene);
                        return;
                    }
                    EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
                }
#endif
#endif
        }

        /// <summary>
        /// Remove the seams from active terrain tiles
        /// </summary>
        public void RemoveWorldSeams()
        {
            Terrain[] terrains = Terrain.activeTerrains;

            //Check to see if we have terrains
            if (terrains.Length == 0)
            {
                return;
            }

            //Get the terrain bounds
            int terrainX;
            int terrainZ;
            float terrainWidth = terrains[0].terrainData.size.x;
            float terrainHeight = terrains[0].terrainData.size.z;
            float minBoundsX = float.MaxValue;
            float maxBoundsX = float.MinValue;
            float minBoundsZ = float.MaxValue;
            float maxBoundsZ = int.MinValue;
            foreach (var terrain in terrains)
            {
                Vector3 position = terrain.GetPosition();

                if (position.x < minBoundsX)
                {
                    minBoundsX = position.x;
                }
                if (position.z < minBoundsZ)
                {
                    minBoundsZ = position.z;
                }
                if (position.x > maxBoundsX)
                {
                    maxBoundsX = position.x;
                }
                if (position.z > maxBoundsZ)
                {
                    maxBoundsZ = position.z;
                }
            }

            //Put the terrains in right places
            int tilesX = (int)((maxBoundsX - minBoundsX) / terrainWidth) + 1;
            int tilesZ = (int)((maxBoundsZ - minBoundsZ) / terrainHeight) + 1;
            Terrain[,] terrainTiles = new Terrain[tilesX, tilesZ];
            foreach (var terrain in terrains)
            {
                Vector3 position = terrain.GetPosition();
                terrainX = tilesX - (int)((maxBoundsX - position.x) / terrainWidth) - 1;
                terrainZ = tilesZ - (int)((maxBoundsZ - position.z) / terrainHeight) - 1;
                //Debug.Log(string.Format("{0},{1} - {2},{3}", position.x, position.z, terrainX, terrainZ));
                terrainTiles[terrainX, terrainZ] = terrain;
            }

            //Now assign neightbors
            for (int tx = 0; tx < tilesX; tx++)
            {
                for (int tz = 0; tz < tilesZ; tz++)
                {
                    Terrain right = null;
                    Terrain left = null;
                    Terrain bottom = null;
                    Terrain top = null;

                    if (tx > 0) left = terrainTiles[(tx - 1), tz];
                    if (tx < tilesX - 1) right = terrainTiles[(tx + 1), tz];
                    if (tz > 0) bottom = terrainTiles[tx, (tz - 1)];
                    if (tz < tilesZ - 1) top = terrainTiles[tx, (tz + 1)];
#if UNITY_2018_3_OR_NEWER
                    terrainTiles[tx, tz].allowAutoConnect = true;
#endif
                    terrainTiles[tx, tz].SetNeighbors(left, top, right, bottom);
                    
                }
            }
        }

        /// <summary>
        /// Gets the required additonal features for the current CTS shader
        /// </summary>
        /// <returns>The current ShaderFeatureSet.</returns>
        public CTSConstants.ShaderFeatureSet GetShaderFeatureSet()
        {
            if (m_useCutout)
            {
                return CTSConstants.ShaderFeatureSet.Cutout;
            }
            else
            {
                return CTSConstants.ShaderFeatureSet.None;
            }
        }



        /// <summary>
        /// Gets the current render pipeline used in this project. Determined by the type name of the render pipeline asset.
        /// </summary>
        /// <returns>The current render pipeline.</returns>
        public static CTSConstants.EnvironmentRenderer GetRenderPipeline()
        {
#if UNITY_2018_1_OR_NEWER
            if (GraphicsSettings.renderPipelineAsset == null)
            {
                return CTSConstants.EnvironmentRenderer.BuiltIn;
            }

            switch (GraphicsSettings.renderPipelineAsset.GetType().Name)
            {
                case "LightweightRenderPipelineAsset":
                    return CTSConstants.EnvironmentRenderer.LightWeight;
                case "HDRenderPipelineAsset":
                    return CTSConstants.EnvironmentRenderer.HighDefinition;
                case "UniversalRenderPipelineAsset":
                    return CTSConstants.EnvironmentRenderer.Universal;
                default:
                    return CTSConstants.EnvironmentRenderer.BuiltIn;

            }


#region Lookup by default terrain material

            /*Material defaultTerrainMaterial = GraphicsSettings.renderPipelineAsset.GetDefaultTerrainMaterial();

            if (defaultTerrainMaterial.shader.name == null)
            {
                return CTSConstants.EnvironmentRenderer.BuiltIn;
            }

            switch (defaultTerrainMaterial.shader.name)
            {
                case "Lightweight Render Pipeline/Terrain/Lit":
                    return CTSConstants.EnvironmentRenderer.LightWeight2018x;
                case "HD Render Pipeline/TerrainLit":
                    return CTSConstants.EnvironmentRenderer.HighDefinition2018x;
                default:
                    return CTSConstants.EnvironmentRenderer.BuiltIn;

            };*/
#endregion
#else
            return CTSConstants.EnvironmentRenderer.BuiltIn;
#endif
        }



    }
}