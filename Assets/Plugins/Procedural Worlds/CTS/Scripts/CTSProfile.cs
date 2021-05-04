using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

#if SUBSTANCE_PLUGIN_ENABLED
using Substance.Game;
#endif

namespace CTS
{
    /// <summary>
    /// This class stores a terrain profile. One profile can be shared by many terrains.
    /// </summary>
    [System.Serializable]
    public class CTSProfile : ScriptableObject
    {
        #region General settings

        /// <summary>
        /// CTS Major version used to generate this profile - used to force rebakes
        /// </summary>
        public int MajorVersion
        {
            get { return m_ctsMajorVersion; }
            set
            {
                if (!m_ctsMajorVersion.Equals(value))
                {
                    m_ctsMajorVersion = value;
                    m_needsAlbedosArrayUpdate = true;
                    m_needsNormalsArrayUpdate = true;
                }
            }
        }
        [SerializeField]
        private int m_ctsMajorVersion = CTSConstants.MajorVersion;

        /// <summary>
        /// CTS Minor version used to generate this profile - used to force rebakes
        /// </summary>
        public int MinorVersion
        {
            get { return m_ctsMinorVersion; }
            set
            {
                if (!m_ctsMinorVersion.Equals(value))
                {
                    m_ctsMinorVersion = value;
                    m_needsAlbedosArrayUpdate = true;
                    m_needsNormalsArrayUpdate = true;
                }
            }
        }
        [SerializeField]
        private int m_ctsMinorVersion = CTSConstants.MinorVersion;

        /// <summary>
        /// CTS Patch version used to generate this profile - used to force rebakes
        /// </summary>
        public int PatchVersion
        {
            get { return m_ctsPatchVersion; }
            set
            {
                if (!m_ctsPatchVersion.Equals(value))
                {
                    m_ctsPatchVersion = value;
                    m_needsAlbedosArrayUpdate = true;
                    m_needsNormalsArrayUpdate = true;
                }
            }
        }
        [SerializeField]
        private int m_ctsPatchVersion = CTSConstants.PatchVersion;

        //Material retated settings
        //public bool m_persistMaterials = false;
        public bool m_useMaterialControlBlock = false;

        //Control settings
        public bool m_showGlobalSettings = true;
        public bool m_showSnowSettings = false;
        public bool m_showTextureSettings = false;
        public bool m_showGeoSettings = true;
        public bool m_showDetailSettings = true;
        public bool m_showColorMapSettings = false;
        public bool m_showOptimisationSettings = false;
        public string m_ctsDirectory = "Assets/CTS/";

        //Shader to use
        public CTSConstants.ShaderType ShaderType
        {
            get { return m_shaderType; }
            set
            {
                if (m_shaderType != value)
                {
                    m_shaderType = value;
                }
            }
        }
        [SerializeField]
        private CTSConstants.ShaderType m_shaderType = CTSConstants.ShaderType.Basic;

        [HideInInspector]
        [SerializeField]
        public CTSConstants.EnvironmentRenderer m_currentRenderPipelineType = CTSConstants.EnvironmentRenderer.BuiltIn;

        //Global settings
        public float m_globalUvMixPower = 3f;
        public float m_globalUvMixStartDistance = 400f;
        public float m_globalNormalPower = 0.1f;
        public float m_globalDetailNormalClosePower = 1f;
        public float m_globalDetailNormalCloseTiling = 60f;
        public float m_globalDetailNormalFarPower = 1f;
        public float m_globalDetailNormalFarTiling = 300f;
        public float m_globalTerrainSmoothness = 1f;
        public float m_globalTerrainSpecular = 1f;
        public float m_globalTesselationPower = 7f;
        public float m_globalTesselationMinDistance = 0f;
        public float m_globalTesselationMaxDistance = 50f;
        public float m_globalTesselationPhongStrength = 1f;
        public CTSConstants.AOType m_globalAOType = CTSConstants.AOType.NormalMapBased;
        public float m_globalAOPower = 1f;
        public float m_globalBasemapDistance = 1000f;

//This setting creates issues with terrain details in builds in 2019.1+
#if UNITY_2019_1_OR_NEWER
        public bool m_globalStripTexturesAtRuntime = false;
#else
        public bool m_globalStripTexturesAtRuntime = true;
#endif

#if UNITY_2018_3_OR_NEWER
        public bool m_drawInstanced = true;
#else
        public int m_targetDetailResolutionPerPatch = 64;
#endif
        public int m_renderQueue = -1;

        public bool ignoreInstancedWarningPopUp = false;

        public string m_terrainLayerPath = "";


        //public bool m_globalDisconnectProfileAtRuntime = true;

        //Colormap settings
        public float m_colorMapClosePower = 0f;
        public float m_colorMapFarPower = 0f;
        public float m_colorMapOpacity = 1f;

        //Geological settings
        public float m_geoMapCloseOffset = 0.028f;
        public float m_geoMapClosePower = 0.05f;
        public float m_geoMapTilingClose = 142f;
        public float m_geoMapFarOffset = 0f;
        public float m_geoMapFarPower = 0.05f;
        public float m_geoMapTilingFar = 100f;

        //Snow settings
        public float m_snowAmount = 0f;
        public float m_snowMaxAngle = 22.9f;
        public float m_snowMaxAngleHardness = 1f;
        public float m_snowMinHeight = 145f;
        public float m_snowMinHeightBlending = 27f;
        public float m_snowNoisePower = 0.8f;
        public float m_snowNoiseTiling = 0.02f;
        public float m_snowNormalScale = 1f;
        public float m_snowDetailPower = 1f;
        public float m_snowTilingClose = 6.9f;
        public float m_snowTilingFar = 3;
        public float m_snowBrightness = 1f;
        public float m_snowBlendNormal = 0.9f;
        public float m_snowSmoothness = 1f;
        public Color m_snowTint = new Color(1f, 1f, 1f);
        public float m_snowSpecular = 1f;
        public float m_snowHeightmapBlendClose = 1f;
        public float m_snowHeightmapBlendFar = 1f;
        public float m_snowHeightmapDepth = 8f;
        public float m_snowHeightmapContrast = 1f;
        public float m_snowHeightmapMinValue = 0f;
        public float m_snowHeightmapMaxValue = 1f;
        public float m_snowTesselationDepth = 0f;
        public float m_snowAOStrength = 1f;
        public Vector4 m_snowAverage;

        //Global format all temporary textures will be created in before the final compression format will be applied
        private static TextureFormat m_workTextureFormat = TextureFormat.RGBA32;

        //flag to determine whether the terrain layer assets have already been built in an update process across multiple shaders or not
        public bool terrainLayerAssetRebuild = false;

        //Albedo defaults
        public TextureFormat m_albedoFormat = TextureFormat.DXT5;
        public int m_albedoAniso = 8;
        public FilterMode m_albedoFilterMode = FilterMode.Bilinear;
        public CTSConstants.TextureSize AlbedoTextureSize
        {
            get { return m_albedoTextureSize; }
            set
            {
                if (m_albedoTextureSize != value)
                {
                    CompleteTerrainShader.SetDirty(this, false, true);
                    m_albedoTextureSize = value;
                    m_albedoTextureSizePx = CTSConstants.GetTextureSize(m_albedoTextureSize);
                    m_needsAlbedosArrayUpdate = true;
                }
            }
        }
        [SerializeField]
        private CTSConstants.TextureSize m_albedoTextureSize = CTSConstants.TextureSize.Texture_1024;
        public int m_albedoTextureSizePx = 1024;
        public bool AlbedoCompressionEnabled
        {
            get { return m_albedoCompress; }
            set
            {
                if (m_albedoCompress != value)
                {
                    CompleteTerrainShader.SetDirty(this, false, true);
                    m_albedoCompress = value;
                    m_needsAlbedosArrayUpdate = true;
                }
            }
        }
        [SerializeField]
        private bool m_albedoCompress = true;

        //Normal defaults
        public TextureFormat m_normalFormat = TextureFormat.DXT5;
        public int m_normalAniso = 8;
        public FilterMode m_normalFilterMode = FilterMode.Bilinear;
        public CTSConstants.TextureSize NormalTextureSize
        {
            get
            {
                return m_normalTextureSize;
            }
            set
            {
                if (m_normalTextureSize != value)
                {
                    CompleteTerrainShader.SetDirty(this, false, true);
                    m_normalTextureSize = value;
                    m_normalTextureSizePx = CTSConstants.GetTextureSize(m_normalTextureSize);
                    m_needsNormalsArrayUpdate = true;
                }
            }
        }
        [SerializeField]
        private CTSConstants.TextureSize m_normalTextureSize = CTSConstants.TextureSize.Texture_1024;
        public int m_normalTextureSizePx = 1024;
        public bool NormalCompressionEnabled
        {
            get { return m_normalCompress; }
            set
            {
                if (m_normalCompress != value)
                {
                    CompleteTerrainShader.SetDirty(this, false, true);
                    m_normalCompress = value;
                    m_needsNormalsArrayUpdate = true;
                }
            }
        }
        [SerializeField]
        private bool m_normalCompress = true;

#endregion

#region Detail Normal Map Texture

        /// <summary>
        /// Index of global detail normal map in normal map array
        /// </summary>
        public int m_globalDetailNormalMapIdx = -1;

        /// <summary>
        /// Global detail normal map
        /// </summary>
        public Texture2D GlobalDetailNormalMap
        {
            get { return m_globalDetailNormalMap; }
            set
            {
                if (IsDifferentTexture(m_globalDetailNormalMap, value))
                {
                    CompleteTerrainShader.SetDirty(this, false, true);
                    m_globalDetailNormalMap = value;
                    m_needsNormalsArrayUpdate = true;
                }
            }
        }
        [SerializeField]
        private Texture2D m_globalDetailNormalMap;

#endregion

#region Snow Textures

        /// <summary>
        /// The index of the snow albedo texture in the abledos texture array
        /// </summary>
        public int m_snowAlbedoTextureIdx = -1;

        /// <summary>
        /// Snow albedo texture
        /// </summary>
        public Texture2D SnowAlbedo
        {
            get { return m_snowAlbedoTexture; }
            set
            {
                if (IsDifferentTexture(m_snowAlbedoTexture, value))
                {
                    CompleteTerrainShader.SetDirty(this, false, true);
                    m_snowAlbedoTexture = value;
                    m_needsAlbedosArrayUpdate = true;
                }
            }
        }
        [SerializeField]
        private Texture2D m_snowAlbedoTexture;

        /// <summary>
        /// The index of the snow normal texture in the normals texture array
        /// </summary>
        public int m_snowNormalTextureIdx = -1;

        /// <summary>
        /// Snow normal texture
        /// </summary>
        public Texture2D SnowNormal
        {
            get { return m_snowNormalTexture; }
            set
            {
                if (IsDifferentTexture(m_snowNormalTexture, value))
                {
                    CompleteTerrainShader.SetDirty(this, false, true);
                    m_snowNormalTexture = value;
                    m_needsNormalsArrayUpdate = true;
                }
            }
        }
        [SerializeField]
        private Texture2D m_snowNormalTexture;

        /// <summary>
        /// Snow height texture index in albedo array
        /// </summary>
        public int m_snowHeightTextureIdx = -1;

        /// <summary>
        /// Snow height texture
        /// </summary>
        public Texture2D SnowHeight
        {
            get { return m_snowHeightTexture; }
            set
            {
                if (IsDifferentTexture(m_snowHeightTexture, value))
                {
                    CompleteTerrainShader.SetDirty(this, false, true);
                    m_snowHeightTexture = value;
                    m_needsAlbedosArrayUpdate = true;
                }
            }
        }
        [SerializeField]
        private Texture2D m_snowHeightTexture;

        /// <summary>
        /// Snow noise texture index in albedo array
        /// </summary>
        public int m_snowAOTextureIdx = -1;

        /// <summary>
        /// Snow AO texture
        /// </summary>
        public Texture2D SnowAmbientOcclusion
        {
            get { return m_snowAOTexture; }
            set
            {
                if (IsDifferentTexture(m_snowAOTexture, value))
                {
                    CompleteTerrainShader.SetDirty(this, false, true);
                    m_snowAOTexture = value;
                    m_needsAlbedosArrayUpdate = true;
                }
            }
        }
        [SerializeField]
        private Texture2D m_snowAOTexture;

        /// <summary>
        /// Snow emission texture index in albedo array
        /// </summary>
        public int m_snowEmissionTextureIdx = -1;

        /// <summary>
        /// Snow emission texture
        /// </summary>
        public Texture2D SnowEmission
        {
            get { return m_snowEmissionTexture; }
            set
            {
                if (IsDifferentTexture(m_snowEmissionTexture, value))
                {
                    CompleteTerrainShader.SetDirty(this, false, true);
                    m_snowEmissionTexture = value;
                    m_needsAlbedosArrayUpdate = true;
                }
            }
        }
        [SerializeField]
        private Texture2D m_snowEmissionTexture;

        /// <summary>
        /// Snow glitter texture
        /// </summary>
        public Texture2D SnowGlitter
        {
            get { return m_snowGlitterTexture; }
            set
            {
                if (IsDifferentTexture(m_snowGlitterTexture, value))
                {
                    CompleteTerrainShader.SetDirty(this, false, true);
                    m_snowGlitterTexture = value;
                }
            }
        }
        [SerializeField]
        private Texture2D m_snowGlitterTexture;

        public float m_snowGlitterColorPower = 0.2f;
        public float m_snowGlitterNoiseThreshold = 0.991f;
        public float m_snowGlitterSpecularPower = 0.2f;
        public float m_snowGlitterSmoothness = 0.9f;
        public float m_snowGlitterRefreshSpeed = 4f;
        public float m_snowGlitterTiling = 2.5f;

#endregion

#region Geo Texture

        /// <summary>
        /// The Geo albedo texture used for geo banding
        /// </summary>
        public Texture2D GeoAlbedo
        {
            get { return m_geoAlbedoTexture; }
            set
            {
                if (IsDifferentTexture(m_geoAlbedoTexture, value))
                {
                    CompleteTerrainShader.SetDirty(this, false, true);
                    m_geoAlbedoTexture = value;
                }
            }
        }
        [SerializeField]
        private Texture2D m_geoAlbedoTexture;

#endregion

#region Terrain Textures

        /// <summary>
        /// Terrain Textures - there will be one of these for every splat prototype in the terrain
        /// </summary>
        public List<CTSTerrainTextureDetails> TerrainTextures
        {
            get { return m_terrainTextures; }
            set { m_terrainTextures = value; }
        }
        [SerializeField]
        private List<CTSTerrainTextureDetails> m_terrainTextures = new List<CTSTerrainTextureDetails>();

        /// <summary>
        /// Replacement terrain albedos
        /// </summary>
        public List<Texture2D> ReplacementTerrainAlbedos
        {
            get { return m_replacementTerrainAlbedos; }
        }

        /// <summary>
        /// Replacement terrain normals
        /// </summary>
        public List<Texture2D> ReplacementTerrainNormals
        {
            get { return m_replacementTerrainNormals; }
        }
        [SerializeField]
        private List<Texture2D> m_replacementTerrainAlbedos = new List<Texture2D>();
        [SerializeField]
        private List<Texture2D> m_replacementTerrainNormals = new List<Texture2D>();

#endregion

#region Texture Arrays

        /// <summary>
        /// Albedo texture array
        /// </summary>
        public Texture2DArray AlbedosTextureArray
        {
            get { return m_albedosTextureArray; }
            set
            {
                CompleteTerrainShader.SetDirty(this, false, false);
                m_albedosTextureArray = value;
                m_needsAlbedosArrayUpdate = false;
            }
        }
        [SerializeField]
        private Texture2DArray m_albedosTextureArray;
        public bool m_needsAlbedosArrayUpdate = false;

        /// <summary>
        /// Normals texture array
        /// </summary>
        public Texture2DArray NormalsTextureArray
        {
            get { return m_normalsTextureArray; }
            set
            {
                CompleteTerrainShader.SetDirty(this, false, false);
                m_normalsTextureArray = value;
                m_needsNormalsArrayUpdate = false;
            }
        }
        [SerializeField]
        private Texture2DArray m_normalsTextureArray;
        public bool m_needsNormalsArrayUpdate = false;

#if UNITY_2018_3_OR_NEWER
        [SerializeField]
        public TerrainLayer[] cachedTerrainLayers;
#endif

        /// <summary>
        /// Used to signal that we need an array update
        /// </summary>
        /// <returns>True if we need an array update</returns>
        public bool NeedsArrayUpdate()
        {
            //Albedos
            if (m_needsAlbedosArrayUpdate)
            {
                return true;
            }

            //Normals
            if (m_needsNormalsArrayUpdate)
            {
                return true;
            }

            //Substance or texture changed
            for (int idx = 0; idx < m_terrainTextures.Count; idx++)
            {
#if !UNITY_WEBGL && !UNITY_WII && (!UNITY_2018_1_OR_NEWER || SUBSTANCE_PLUGIN_ENABLED)
                if (m_terrainTextures[idx].m_substanceRegenOnBake || m_terrainTextures[idx].TextureHasChanged())
                {
                    return true;
                }
#else
                if (m_terrainTextures[idx].TextureHasChanged())
                {
                    return true;
                }
#endif
            }

            //NADA
            return false;
        }

        /// <summary>
        /// Will regenerate the texture arrays if necessary
        /// </summary>
        public void RegenerateArraysIfNecessary()
        {
#if UNITY_EDITOR
            EditorUtility.DisplayProgressBar("Baking Textures", "Starting", 0f);
#endif

            //If we have asked for substance regen - then we always have to re-export textures and redo the arrays
#if UNITY_EDITOR
            EditorUtility.DisplayProgressBar("Baking Textures", "Unpacking Substances", 0f);
#endif
            for (int idx = 0; idx < m_terrainTextures.Count; idx++)
            {
#if UNITY_EDITOR
                EditorUtility.DisplayProgressBar("Baking Textures", "Unpacking Substances..", (float)idx / (float)m_terrainTextures.Count);
#endif
#if !UNITY_WEBGL && !UNITY_WII && (!UNITY_2018_1_OR_NEWER || SUBSTANCE_PLUGIN_ENABLED)
                if (m_terrainTextures[idx].m_substanceRegenOnBake)
                {
                    m_needsAlbedosArrayUpdate = true;
                    m_needsNormalsArrayUpdate = true;
#if SUBSTANCE_PLUGIN_ENABLED
                    UnpackSubstance(m_terrainTextures[idx].Substance);
#else
                    UnpackSubstanceEditorMode(m_terrainTextures[idx].Substance);
#endif
                }
#endif
                }

            bool madeChanges = false;

            //Albedos
            if (m_needsAlbedosArrayUpdate)
            {
                madeChanges = true;
                ConstructAlbedosTextureArray();
            }

            //Normals
            if (m_needsNormalsArrayUpdate)
            {
                madeChanges = true;
                ConstructNormalsTextureArray();
            }

#if UNITY_EDITOR
            //any changes made? save asset database
            if (madeChanges)
            {
                //AssetDatabase.Refresh();
                //AssetDatabase.SaveAssets();
            }
#endif


            //Reset any changed flags
            for (int idx = 0; idx < m_terrainTextures.Count; idx++)
            {
                m_terrainTextures[idx].ResetChangedFlags();
            }

#if UNITY_EDITOR
            EditorUtility.ClearProgressBar();
#endif
        }

        /// <summary>
        /// Construct and optionally save the albedos texture array
        /// </summary>
        private void ConstructAlbedosTextureArray()
        {
            //No longer needs an update
            m_needsAlbedosArrayUpdate = false;

            //Contruct new one
            List<Texture2D> textures = new List<Texture2D>();

            int albedoIdx = 0;
            CTSTerrainTextureDetails td = null;
            byte minHeight;
            byte maxHeight;
            for (int idx = 0; idx < m_terrainTextures.Count; idx++)
            {
#if UNITY_EDITOR
                EditorUtility.DisplayProgressBar("Baking Textures", "Ingesting albedos..", (float)idx / (float)(m_terrainTextures.Count + 3));
#endif

                td = m_terrainTextures[idx];

                //And go the rest
                if (td.Albedo != null)
                {
                    //Albedo
                    Texture2D albedoTex;
                    if (td.Smoothness == null && td.Roughness == null)
                    {
                        if (m_albedoCompress)
                        {
                            albedoTex = ResizeTexture(td.Albedo, m_albedoFormat, m_albedoAniso, m_albedoTextureSizePx, m_albedoTextureSizePx, true, false, true);
                        }
                        else
                        {
                            albedoTex = ResizeTexture(td.Albedo, m_albedoFormat, m_albedoAniso, m_albedoTextureSizePx, m_albedoTextureSizePx, true, false, false);
                        }
                    }
                    else
                    {
                        albedoTex = BakeAlbedo(td.Albedo, td.Smoothness, td.Roughness);
                    }
                    textures.Add(albedoTex);
                    Color[] maxMipColors = albedoTex.GetPixels(albedoTex.mipmapCount - 1);
                    Color mmColor = maxMipColors[0].linear;
                    td.m_albedoAverage = new Vector4(mmColor.r, mmColor.g, mmColor.b, mmColor.a);
                    td.m_albedoIdx = albedoIdx++;

                    //Height / AO - only used in advanced or tess shaders
                    if ((m_shaderType == CTSConstants.ShaderType.Advanced || m_shaderType == CTSConstants.ShaderType.Tesselation)
                        && (td.Height != null || td.AmbientOcclusion != null))
                    {
                        textures.Add(BakeHAOTexture(td.m_name, td.Height, td.AmbientOcclusion, out minHeight, out maxHeight));
                        if (td.Height != null)
                        {
                            td.m_heightIdx = albedoIdx;
                            td.m_heightMin = (float)minHeight / 255f;
                            td.m_heightMax = (float)maxHeight / 255f;
                        }
                        else
                        {
                            td.m_heightIdx = -1;
                        }
                        if (td.AmbientOcclusion != null)
                        {
                            td.m_aoIdx = albedoIdx;
                        }
                        else
                        {
                            td.m_aoIdx = -1;
                        }
                        albedoIdx++;
                    }
                    else
                    {
                        td.m_aoIdx = -1;
                        td.m_heightIdx = -1;
                    }
                }
                else
                {
                    td.m_albedoIdx = -1;
                }
                td.m_albedoWasChanged = false;
            }

            //Snow albedo
#if UNITY_EDITOR
            EditorUtility.DisplayProgressBar("Baking Textures", "Ingesting albedos..", (float)(m_terrainTextures.Count) / (float)(m_terrainTextures.Count + 3));
#endif
            //Only add snow if texture is set and actually used
            if (m_snowAlbedoTexture != null && m_snowAmount>0)
            {
                Texture2D snowTex;
                if (m_albedoCompress)
                {
                    snowTex = ResizeTexture(m_snowAlbedoTexture, m_albedoFormat, m_normalAniso, m_albedoTextureSizePx, m_albedoTextureSizePx, true, false, true);
                }
                else
                {
                    snowTex = ResizeTexture(m_snowAlbedoTexture, m_albedoFormat, m_normalAniso, m_albedoTextureSizePx, m_albedoTextureSizePx, true, false, false);
                }
                Color[] maxMipColors = snowTex.GetPixels(snowTex.mipmapCount - 1);
                Color mmColor = maxMipColors[0].linear;
                m_snowAverage = new Vector4(mmColor.r, mmColor.g, mmColor.b, mmColor.a);
                textures.Add(snowTex);
                m_snowAlbedoTextureIdx = albedoIdx++;
            }
            else
            {
                m_snowAlbedoTextureIdx = -1;
            }

            //Snow Height & AO
#if UNITY_EDITOR
            EditorUtility.DisplayProgressBar("Baking Textures", "Ingesting albedos..", (float)(m_terrainTextures.Count) / (float)(m_terrainTextures.Count + 3));
#endif
            if ((m_snowHeightTexture != null || m_snowAOTexture != null) && m_snowAmount>0)
            {
                textures.Add(BakeHAOTexture("CTS_SnowHAO", m_snowHeightTexture, m_snowAOTexture, out minHeight, out maxHeight));
                if (m_snowHeightTexture != null)
                {
                    m_snowHeightTextureIdx = albedoIdx;
                    m_snowHeightmapMinValue = (float)minHeight / 255f;
                    m_snowHeightmapMaxValue = (float)maxHeight / 255f;
                }
                else
                {
                    m_snowHeightTextureIdx = -1;
                    m_snowHeightmapMinValue = 0f;
                    m_snowHeightmapMaxValue = 1f;
                }
                if (m_snowAOTexture != null)
                {
                    m_snowAOTextureIdx = albedoIdx;
                }
                else
                {
                    m_snowAOTextureIdx = -1;
                }
                albedoIdx++;
            }
            else
            {
                m_snowAOTextureIdx = -1;
                m_snowHeightTextureIdx = -1;
            }

            //Snow Noise
#if UNITY_EDITOR
            EditorUtility.DisplayProgressBar("Baking Textures", "Ingesting albedos..", (float)(m_terrainTextures.Count + 1) / (float)(m_terrainTextures.Count + 3));
#endif

            //Construct texture array, resizing / reimporting if necessary
#if UNITY_EDITOR
            EditorUtility.DisplayProgressBar("Baking Textures", "Ingesting albedos..", (float)(m_terrainTextures.Count + 1) / (float)(m_terrainTextures.Count + 3));
#endif

            Texture2DArray texArray = GetTextureArray(textures, CTSConstants.TextureType.Albedo, m_albedoAniso);
            //Set default aniso level to 4 for better performance
            texArray.anisoLevel = 4;

            //Save if not playing and in editor
#if UNITY_EDITOR
            if (texArray != null && !Application.isPlaying)
            {
                Directory.CreateDirectory(m_ctsDirectory + "Profiles/");
                Directory.CreateDirectory(m_ctsDirectory + "Profiles/Arrays/");

                string arrayPath = AssetDatabase.GetAssetPath(this);
                if (string.IsNullOrEmpty(arrayPath))
                {
                    arrayPath = string.Format("{0}Profiles/Arrays/{1}_Albedos.asset", m_ctsDirectory, this.name);
                }
                else
                {
                    string filePath = Path.GetDirectoryName(arrayPath) + "/Arrays/";
                    Directory.CreateDirectory(filePath);
                    arrayPath = filePath + Path.GetFileName(arrayPath);
                    arrayPath = arrayPath.Replace(".asset", "_Albedos.asset");
                }

                EditorUtility.DisplayProgressBar("Baking Textures", "Ingesting albedos..", (float)(m_terrainTextures.Count + 2) / (float)(m_terrainTextures.Count + 3));
                AssetDatabase.CreateAsset(texArray, arrayPath);
                //Setting default Aniso level
                var importer = AssetImporter.GetAtPath(arrayPath) as TextureImporter;
                if (importer != null)
                {
                    importer.anisoLevel = 4;
                    AssetDatabase.ImportAsset(arrayPath, ImportAssetOptions.ForceUpdate);
                }
                    //AssetDatabase.Refresh();
                }
#endif

            AlbedosTextureArray = texArray;

            //Construct albedo terrain replacements
            //ConstructTerrainReplacementAlbedos();

            //Force save 
//#if UNITY_EDITOR
//            AssetDatabase.SaveAssets();
//#endif
        }

        /// <summary>
        /// Construct and optionally save the normals texture array
        /// </summary>
        private void ConstructNormalsTextureArray()
        {
            //No longer need one
            m_needsNormalsArrayUpdate = false;

            //Contruct new one
            List<Texture2D> textures = new List<Texture2D>();

            //Per texture normals
            int normalIdx = 0;
            CTSTerrainTextureDetails td = null;
            for (int idx = 0; idx < m_terrainTextures.Count; idx++)
            {
#if UNITY_EDITOR
                EditorUtility.DisplayProgressBar("Baking Textures", "Ingesting normals..", (float)idx / (float)(m_terrainTextures.Count + 4));
#endif

                td = m_terrainTextures[idx];
                if (td.Normal != null)
                {
                    textures.Add(BakeNormal(td.Normal));
                    td.m_normalIdx = normalIdx++;
                }
                else
                {
                    td.m_normalIdx = -1;
                }

                td.m_normalWasChanged = false;
            }

            //Snow normal
#if UNITY_EDITOR
            EditorUtility.DisplayProgressBar("Baking Textures", "Ingesting normals..", (float)(m_terrainTextures.Count) / (float)(m_terrainTextures.Count + 4));
#endif
            //Only add snow normals if snow is actually used
            if (m_snowNormalTexture != null && m_snowAmount>0)
            {
                textures.Add(BakeNormal(m_snowNormalTexture));
                m_snowNormalTextureIdx = normalIdx++;
            }
            else
            {
                m_snowNormalTextureIdx = -1;
            }

            //Global detail normal
#if UNITY_EDITOR
            EditorUtility.DisplayProgressBar("Baking Textures", "Ingesting normals..", (float)(m_terrainTextures.Count + 1) / (float)(m_terrainTextures.Count + 4));
#endif
            //Only add detail normals if detail normals are actually used
            if (m_globalDetailNormalMap && (m_globalDetailNormalClosePower > 0 || m_globalDetailNormalClosePower > 0))
            {
                textures.Add(BakeNormal(m_globalDetailNormalMap));
                m_globalDetailNormalMapIdx = normalIdx++;
            }
            else
            {
                m_globalDetailNormalMapIdx = -1;
            }

            //Construct texture array, resizing / reimporting if necessary
#if UNITY_EDITOR
            EditorUtility.DisplayProgressBar("Baking Textures", "Ingesting normals..", (float)(m_terrainTextures.Count + 2) / (float)(m_terrainTextures.Count + 4));
#endif

            Texture2DArray texArray = GetTextureArray(textures, CTSConstants.TextureType.Normal, m_normalAniso);

            //Save if not running and in the the editor
#if UNITY_EDITOR
            if (texArray != null && !Application.isPlaying)
            {
                //Set default aniso level to 4 for better performance
                texArray.anisoLevel = 4;

                Directory.CreateDirectory(m_ctsDirectory + "Profiles/");
                Directory.CreateDirectory(m_ctsDirectory + "Profiles/Arrays/");

                string arrayPath = AssetDatabase.GetAssetPath(this);
                if (string.IsNullOrEmpty(arrayPath))
                {
                    arrayPath = string.Format("{0}Profiles/Arrays/{1}_Normals.asset", m_ctsDirectory, this.name);
                }
                else
                {
                    string filePath = Path.GetDirectoryName(arrayPath) + "/Arrays/";
                    Directory.CreateDirectory(filePath);
                    arrayPath = filePath + Path.GetFileName(arrayPath);
                    arrayPath = arrayPath.Replace(".asset", "_Normals.asset");
                }

                EditorUtility.DisplayProgressBar("Baking Textures", "Ingesting normals..", (float)(m_terrainTextures.Count + 3) / (float)(m_terrainTextures.Count + 4));
                AssetDatabase.CreateAsset(texArray, arrayPath);
                var importer = AssetImporter.GetAtPath(arrayPath) as TextureImporter;
                if (importer != null)
                {
                    importer.anisoLevel = 4;
                    AssetDatabase.ImportAsset(arrayPath, ImportAssetOptions.ForceUpdate);
                }
                //                AssetDatabase.Refresh();
            }
#endif

            NormalsTextureArray = texArray;

            //Construct normal terrain replacements
            //ConstructTerrainReplacementNormals();

            //Force save 
//#if UNITY_EDITOR
//            AssetDatabase.SaveAssets();
//#endif
        }

        /// <summary>
        /// Update texture settings from terrain
        /// </summary>
        /// <param name="terrain">Terrain to get settings from</param>
        public void UpdateSettingsFromTerrain(Terrain terrain, bool forceUpdate)
        {
            //Drop out if no valid terrain
            if (terrain == null || terrain.terrainData == null)
            {
                return;
            }

            //If we are forcing then do a regen regardless
            if (forceUpdate)
            {
                m_needsAlbedosArrayUpdate = true;
                m_needsNormalsArrayUpdate = true;
            }

            CTSSplatPrototype[] splats = CTSSplatPrototype.GetCTSSplatPrototypes(terrain);

            //Kill excess textures if the terrain now has less and force and update
            while (m_terrainTextures.Count > splats.Length)
            {
                m_terrainTextures.RemoveAt(m_terrainTextures.Count - 1);
                m_needsAlbedosArrayUpdate = true;
                m_needsNormalsArrayUpdate = true;
            }

            //Now work our way through each texture and update / add new settings
            CTSTerrainTextureDetails ts = null;
            CTSSplatPrototype proto;
            for (int splatIdx = 0; splatIdx < splats.Length; splatIdx++)
            {
                proto = splats[splatIdx];
                if (splatIdx < m_terrainTextures.Count)
                {
                    ts = m_terrainTextures[splatIdx];
                    ts.Albedo = proto.texture;
                    ts.m_albedoTilingClose = splats[splatIdx].tileSize.x;
                    ts.Normal = proto.normalMap;
                }
                else
                {
                    //Creating new texture details
                    ts = new CTSTerrainTextureDetails();
                    ts.m_textureIdx = splatIdx;
                    ts.Albedo = splats[splatIdx].texture;
                    ts.m_albedoTilingClose = splats[splatIdx].tileSize.x;
                    ts.Normal = splats[splatIdx].normalMap;
                    m_terrainTextures.Add(ts);
                }
            }

            RegenerateArraysIfNecessary();
        }

#endregion

#region Utilities

#if !UNITY_WEBGL && !UNITY_WII && (!UNITY_2018_1_OR_NEWER || SUBSTANCE_PLUGIN_ENABLED)

#if SUBSTANCE_PLUGIN_ENABLED //Plugin Substance support
        /// <summary>
        /// Unpack the substance for this profile. This version is used for the asset store plugin provided by allegorithmic 
        /// </summary>
        public static void UnpackSubstance(SubstanceGraph sg)
        {
            if (sg == null)
            {
                Debug.LogWarning("No substance supplied");
                return;
            }

            //Make sure we have a directory for it
            string path = string.Format("{0}/Substances/{1}/", CompleteTerrainShader.GetCTSDirectory(), sg.name);
            Directory.CreateDirectory(path);
            
            Texture2D[] generatedTextures = sg.GetGeneratedTextures().ToArray();

            for (int tIdx = 0; tIdx < generatedTextures.Length; tIdx++)
            {
                if (generatedTextures[tIdx] == null)
                {
                    Debug.LogWarning("CTS found empty texture maps in the substance '" + sg.name + "'. Please re-import / regenerate the substance in the asset hierarchy.");
                    continue;
                }
                //Debug.Log(generatedTextures[tIdx].name);
                if (
                    generatedTextures[tIdx].name.EndsWith("baseColor") ||
                    generatedTextures[tIdx].name.EndsWith("height") ||
                    generatedTextures[tIdx].name.EndsWith("ambientOcclusion") ||
                    generatedTextures[tIdx].name.EndsWith("normal") ||
                    generatedTextures[tIdx].name.EndsWith("metallic")
                    )
                {

                    if (generatedTextures[tIdx].name.EndsWith("metallic"))
                    {
                        //a metallic texture was supplied, we need to copy the metallic alpha channel over into a new smoothness mask image
                        Texture2D smoothnessMask = new Texture2D(generatedTextures[tIdx].width, generatedTextures[tIdx].height);
                        Color32[] originalColors = generatedTextures[tIdx].GetPixels32();
                        Color32[] targetColors = new Color32[originalColors.Length];
                        for (int i = 0; i < originalColors.Length; i++)
                        {
                            //create a new Color for the target image by copying the alpha value over in the rgb-channels.
                            //This results in a grayscale mask of the original alpha channel
                            targetColors[i] = new Color32(originalColors[i].a, originalColors[i].a, originalColors[i].a, byte.MaxValue);
                        }
                        smoothnessMask.name = generatedTextures[tIdx].name;
                        smoothnessMask.SetPixels32(targetColors);
                        smoothnessMask.Apply();
                        SaveProceduralTexture(smoothnessMask, path, m_workTextureFormat);
                    }
                    else
                    {
                        SaveProceduralTexture(generatedTextures[tIdx], path, m_workTextureFormat);
                    }
                }
              
            }
            
#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif
        }
        /// <summary>
        /// Saves a procedural substance texture in a path.
        /// </summary>
        /// <param name="texture">The texture that is to be saved.</param>
        /// <param name="path">The path where the texture will be saved in.</param>
        public static void SaveProceduralTexture(Texture2D texture, string path, TextureFormat textureFormat)
        {
            //Create a new, uncompressed texture for saving
            Color32[] colors = texture.GetPixels32();
            Texture2D newTexture = new Texture2D(texture.width, texture.height, textureFormat, false);
            newTexture.name = texture.name;
            newTexture.SetPixels32(colors);
            newTexture.Apply();

            SaveTexture(path + newTexture.name, newTexture);
            if (!Application.isPlaying)
            {
                DestroyImmediate(newTexture, true);
            }
            else
            {
                Destroy(newTexture);
            }
        }


#else //Native Substance Support

            /// <summary>
            /// Unpack the substance for this profile. This version is used for the native unity substance support before 2018.1 
            /// </summary>
            public void UnpackSubstance(ProceduralMaterial pm)
            {
                if (pm == null)
                {
                    Debug.LogWarning("No substance supplied");
                    return;
                }

                //Make it readable
                pm.isReadable = true;

                //Make sure its got generated textures
                if (!pm.isCachedDataAvailable)
                {
                    pm.RebuildTexturesImmediately();
                }

                //Make sure we have a directory for it
                string path = string.Format("{0}/Substances/{1}/",CompleteTerrainShader.GetCTSDirectory(), pm.name);
                Directory.CreateDirectory(path);

                Texture[] generatedTextures = pm.GetGeneratedTextures();
                for (int tIdx = 0; tIdx < generatedTextures.Length; tIdx++)
                {
                    Debug.Log(generatedTextures[tIdx].name);
                    ProceduralTexture proceduralTexture = pm.GetGeneratedTexture(generatedTextures[tIdx].name);
                    if (proceduralTexture.GetProceduralOutputType() == ProceduralOutputType.Diffuse)
                    {
                        Color32[] colors = proceduralTexture.GetPixels32(0, 0, proceduralTexture.width, proceduralTexture.height);
                        Texture2D newTexture = new Texture2D(proceduralTexture.width, proceduralTexture.height, m_albedoFormat, false);
                        newTexture.name = proceduralTexture.name;
                        newTexture.SetPixels32(colors);
                        newTexture.Apply();
                        SaveTexture(path + proceduralTexture.name, newTexture);
                        newTexture.Compress(true);
                        newTexture.Apply(true);
                        if (!Application.isPlaying)
                        {
                            DestroyImmediate(newTexture);
                        }
                        else
                        {
                            Destroy(newTexture);
                        }
                    }
                    else if (proceduralTexture.GetProceduralOutputType() == ProceduralOutputType.Height)
                    {
                        Color32[] colors = proceduralTexture.GetPixels32(0, 0, proceduralTexture.width, proceduralTexture.height);
                        Texture2D newTexture = new Texture2D(proceduralTexture.width, proceduralTexture.height, m_albedoFormat, false);
                        newTexture.name = proceduralTexture.name;
                        newTexture.SetPixels32(colors);
                        newTexture.Apply();
                        SaveTexture(path + proceduralTexture.name, newTexture);
                        newTexture.Compress(true);
                        newTexture.Apply(true);
                        if (!Application.isPlaying)
                        {
                            DestroyImmediate(newTexture);
                        }
                        else
                        {
                            Destroy(newTexture);
                        }
                    }
                    else if (proceduralTexture.GetProceduralOutputType() == ProceduralOutputType.AmbientOcclusion)
                    {
                        Color32[] colors = proceduralTexture.GetPixels32(0, 0, proceduralTexture.width, proceduralTexture.height);
                        Texture2D newTexture = new Texture2D(proceduralTexture.width, proceduralTexture.height, m_albedoFormat, false);
                        newTexture.name = proceduralTexture.name;
                        newTexture.SetPixels32(colors);
                        newTexture.Apply();
                        SaveTexture(path + proceduralTexture.name, newTexture);
                        newTexture.Compress(true);
                        newTexture.Apply(true);
                        if (!Application.isPlaying)
                        {
                            DestroyImmediate(newTexture);
                        }
                        else
                        {
                            Destroy(newTexture);
                        }
                    }
                    else if (proceduralTexture.GetProceduralOutputType() == ProceduralOutputType.Normal)
                    {
                        Color32[] colors = proceduralTexture.GetPixels32(0, 0, proceduralTexture.width, proceduralTexture.height);
                        Texture2D newTexture = new Texture2D(proceduralTexture.width, proceduralTexture.height, m_normalFormat, false);
                        newTexture.name = proceduralTexture.name;
                        newTexture.SetPixels32(colors);
                        newTexture.Apply();
                        SaveTexture(path + proceduralTexture.name, newTexture);
                        newTexture.Compress(true);
                        newTexture.Apply(true);
                        if (!Application.isPlaying)
                        {
                            DestroyImmediate(newTexture);
                        }
                        else
                        {
                            Destroy(newTexture);
                        }
                    }
                }
#if UNITY_EDITOR
                AssetDatabase.Refresh();
#endif
            }

            /// <summary>
            /// Unpack the substance for this material - can only be done in the unity editor
            /// </summary>
            /// <param name="pm">Substance material to unpack</param>
            public static void UnpackSubstanceEditorMode(ProceduralMaterial pm)
            {
                if (pm == null)
                {
                    Debug.LogWarning("No substance supplied");
                    return;
                }

#if UNITY_EDITOR
                //Get its full path
                string srcPath = AssetDatabase.GetAssetPath(pm);

                //Make sure we have an output directory for it
                string exportPath = string.Format("{0}Substances/{1}/", CompleteTerrainShader.GetCTSDirectory(), pm.name);
                Directory.CreateDirectory(exportPath);

                pm.SetProceduralVector("$outputsize", new Vector4(11, 11, 0, 0)); //11 = 2048, 10 - 1024
                SubstanceImporter si = AssetImporter.GetAtPath(srcPath) as SubstanceImporter;
                if (si != null)
                {
                    //si.SetGenerateAllOutputs(pm, true);
                    si.SetMaterialScale(pm, new Vector2(2048f, 2048f));
                    si.ExportBitmaps(pm, exportPath, true);
                    AssetDatabase.Refresh();
                }
#endif
            }
#endif //Native Substance support
#endif

        /// <summary>
        /// Make sure the texture is imported in the right format for the shader - only works in editor - is compiled out during build
        /// </summary>
        /// <param name="texture">Texture to process</param>
        private void ImportTexture(Texture2D texture, int textureSize, bool asNormal = false)
        {
            if (texture == null)
            {
                return;
            }

            Debug.Log("Importing " + texture.name + " " + textureSize);

#if UNITY_EDITOR
            string assetPath = AssetDatabase.GetAssetPath(texture);
            var importer = AssetImporter.GetAtPath(assetPath) as TextureImporter;
            if (importer != null)
            {
                bool reimport = false;
                if (importer.isReadable == false)
                {
                    reimport = true;
                }
                else if (importer.textureCompression != TextureImporterCompression.Compressed)
                {
                    reimport = true;
                }
                else if (texture.width != textureSize || texture.height != textureSize)
                {
                    reimport = true;
                }
                if (reimport)
                {
                    importer.isReadable = true;
                    importer.maxTextureSize = textureSize;
                    importer.textureCompression = TextureImporterCompression.Compressed;
                    importer.anisoLevel = 8;
                    importer.filterMode = FilterMode.Bilinear;
                    importer.mipmapEnabled = true;
                    if (asNormal)
                    {
                        if (importer.textureType != TextureImporterType.NormalMap)
                        {
                            importer.textureType = TextureImporterType.NormalMap;
                            importer.convertToNormalmap = true;
                            importer.normalmapFilter = TextureImporterNormalFilter.Standard;
                            importer.heightmapScale = 0.1f;
                        }
                    }
                    AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);
                }
            }
#endif
        }

        /// <summary>
        /// Get the content of the texture, resized, and converted to the correct format, as a color 32 array
        /// </summary>
        /// <param name="source">Source texture</param>
        /// <param name="format">New format</param>
        /// <param name="dimensions">Texture dimensions (width == height)</param>
        /// <returns></returns>
        Color32[] GetTextureColors(Texture2D source, TextureFormat format, int dimensions)
        {
            Texture2D tex = ResizeTexture(source, format, m_albedoAniso, dimensions, dimensions, false, false, false);
            Color32[] colors = tex.GetPixels32();
            if (!Application.isPlaying)
            {
                DestroyImmediate(tex);
            }
            else
            {
                Destroy(tex);
            }
            return colors;
        }

        /// <summary>
        /// Bake height into rgb, ao into a.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="hTexture">Height texture</param>
        /// <param name="aoTexture">AO texture</param>
        /// <param name="minHeight">Minimum height</param>
        /// <param name="maxHeight">Maximum height</param>
        /// <returns></returns>
        public Texture2D BakeHAOTexture(string name, Texture2D hTexture, Texture2D aoTexture, out byte minHeight, out byte maxHeight)
        {
            //Set return heights
            minHeight = 0x00;
            maxHeight = 0xFF;

            //Check dimensions
            int dimensions = m_albedoTextureSizePx * m_albedoTextureSizePx;
            if (dimensions == 0)
            {
                return null;
            }
            Texture2D newTexture = new Texture2D(m_albedoTextureSizePx, m_albedoTextureSizePx, m_workTextureFormat, true, false);
            newTexture.name = "CTS_" + name + "_HAO";
            newTexture.anisoLevel = m_albedoAniso;
            newTexture.filterMode = m_albedoFilterMode;
            Color32[] target = newTexture.GetPixels32();

            //Process heights
            if (hTexture != null)
            {
                byte height;
                minHeight = 0xFF;
                maxHeight = 0x00;
                Texture2D tmpHTexture = ResizeTexture(hTexture, m_workTextureFormat, m_albedoAniso, m_albedoTextureSizePx, m_albedoTextureSizePx, false, false, false);
                Color32[] heights = tmpHTexture.GetPixels32();
                for (int idx = 0; idx < dimensions; idx++)
                {
                    height = heights[idx].g;
                    if (height < minHeight)
                    {
                        minHeight = height;
                    }
                    if (height > maxHeight)
                    {
                        maxHeight = height;
                    }
                    target[idx].r = target[idx].g = target[idx].b = height;
                }
                if (Application.isPlaying)
                {
                    Destroy(tmpHTexture);
                }
                else
                {
                    DestroyImmediate(tmpHTexture);
                }
            }

            //Process AO
            if (aoTexture != null)
            {
                Texture2D tmpAOTexture = ResizeTexture(aoTexture, m_workTextureFormat, m_albedoAniso, m_albedoTextureSizePx, m_albedoTextureSizePx, false, false, false);
                Color32[] aos = tmpAOTexture.GetPixels32();
                for (int idx = 0; idx < dimensions; idx++)
                {
                    target[idx].a = aos[idx].g;
                }
                if (Application.isPlaying)
                {
                    Destroy(tmpAOTexture);
                }
                else
                {
                    DestroyImmediate(tmpAOTexture);
                }
            }
            else
            {
                for (int idx = 0; idx < dimensions; idx++)
                {
                    target[idx].a = 0xFF;
                }
            }

            //Now update the texture
            newTexture.SetPixels32(target);
            newTexture.Apply(true);

            //DEBUG
            //SaveTexture(m_ctsDirectory + "CTS_" + name + "_NormalAOHeight.png", newTexture);

            //Compress and return
            if (m_albedoCompress)
            {
                newTexture = CompressTexture(newTexture, m_albedoFormat);
            }
            return newTexture;
        }

        /// <summary>
        /// This will bake normalTexture
        /// </summary>
        /// <param name="normalTexture">Normal texture - if not supplied then RG defaults to 0</param>
        /// <returns>Newly baked and compressed normal texture.</returns>
        private Texture2D BakeNormal(Texture2D normalTexture)
        {
            //Check dimensions
            int dimensions = m_normalTextureSizePx * m_normalTextureSizePx;
            if (dimensions == 0 || normalTexture == null)
            {
                return null;
            }
            Texture2D newTexture = new Texture2D(m_normalTextureSizePx, m_normalTextureSizePx, m_workTextureFormat, true, true);
            newTexture.name = "CTS_" + name + "_Normal";
            newTexture.anisoLevel = m_normalAniso;
            newTexture.filterMode = m_normalFilterMode;

            Color32[] target = newTexture.GetPixels32();
            Texture2D tmpNormalTexture = ResizeTexture(normalTexture, m_workTextureFormat, m_normalAniso, m_normalTextureSizePx, m_normalTextureSizePx, false, true, false);
            Color32[] normals = tmpNormalTexture.GetPixels32();

            for (int idx = 0; idx < dimensions; idx++)
            {
                target[idx].r = 0x80;
                target[idx].g = normals[idx].g;
                target[idx].b = 0x80;
                target[idx].a = normals[idx].a;
            }

            if (Application.isPlaying)
            {
                Destroy(tmpNormalTexture);
            }
            else
            {
                DestroyImmediate(tmpNormalTexture);
            }

            //Now update the texture
            newTexture.SetPixels32(target);
            newTexture.Apply(true);

            //DEBUG
            //SaveTexture(m_ctsDirectory + "CTS_" + name + "_Normal.png", newTexture);

            //Compress and return
            if (m_normalCompress)
            {
                newTexture = CompressTexture(newTexture, m_normalFormat);
            }
            return newTexture;
        }

        /// <summary>
        /// This will bake the albedo into RGB and smoothness or roughness into A channel, and will return the compressed result. 
        /// </summary>
        /// <param name="albedoTexture">Albedo</param>
        /// <param name="smoothnessTexture">Source smoothness - takes precedence if present</param>
        /// <param name="roughnessTexture">Source roughness</param>
        /// <returns>Compressed and baked textures</returns>
        private Texture2D BakeAlbedo(Texture2D albedoTexture, Texture2D smoothnessTexture, Texture2D roughnessTexture)
        {
            //Check dimensions
            int dimensions = m_albedoTextureSizePx * m_albedoTextureSizePx;
            if (dimensions == 0)
            {
                return null;
            }

            Texture2D newTexture = new Texture2D(m_albedoTextureSizePx, m_albedoTextureSizePx, m_workTextureFormat, true, false);
            newTexture.name = "CTS_" + name + "_ASm";
            newTexture.anisoLevel = m_albedoAniso;
            newTexture.filterMode = m_albedoFilterMode;
            Color32[] target = newTexture.GetPixels32();

            //Process albedo
            if (albedoTexture != null)
            {
                Texture2D tmpAlbedoTexture = ResizeTexture(albedoTexture, m_workTextureFormat, m_albedoAniso, m_albedoTextureSizePx, m_albedoTextureSizePx, false, false, false);
                Color32[] rgb = tmpAlbedoTexture.GetPixels32();
                for (int idx = 0; idx < dimensions; idx++)
                {
                    target[idx].r = rgb[idx].r;
                    target[idx].g = rgb[idx].g;
                    target[idx].b = rgb[idx].b;
                }
                if (Application.isPlaying)
                {
                    Destroy(tmpAlbedoTexture);
                }
                else
                {
                    DestroyImmediate(tmpAlbedoTexture);
                }
            }

            //Process roughness - smoothness = 1 - roughness
            if (roughnessTexture != null && smoothnessTexture == null)
            {
                Texture2D tmpRTexture = ResizeTexture(roughnessTexture, m_workTextureFormat, m_albedoAniso, m_albedoTextureSizePx, m_albedoTextureSizePx, false, false, false);
                Color32[] r = tmpRTexture.GetPixels32();
                for (int idx = 0; idx < dimensions; idx++)
                {
                    target[idx].a = (byte)(0xFF - r[idx].g);
                }
                if (Application.isPlaying)
                {
                    Destroy(tmpRTexture);
                }
                else
                {
                    DestroyImmediate(tmpRTexture);
                }
            }

            //Process smoothness
            if (smoothnessTexture != null)
            {
                Texture2D tmpSTexture = ResizeTexture(smoothnessTexture, m_workTextureFormat, m_albedoAniso, m_albedoTextureSizePx, m_albedoTextureSizePx, false, false, false);
                Color32[] s = tmpSTexture.GetPixels32();
                for (int idx = 0; idx < dimensions; idx++)
                {
                    target[idx].a = s[idx].g;
                }
                if (Application.isPlaying)
                {
                    Destroy(tmpSTexture);
                }
                else
                {
                    DestroyImmediate(tmpSTexture);
                }
            }

            //Now update the texture
            newTexture.SetPixels32(target);
            newTexture.Apply(true);

            //DEBUG
            //SaveTexture(m_ctsDirectory + "CTS_" + name + "_NormalAOHeight.png", newTexture);

            //Compress and return
            if (m_albedoCompress)
            {
                newTexture = CompressTexture(newTexture, m_albedoFormat);
            }
            return newTexture;
        }



        /// <summary>
        /// Returns a compressed Texture2D in the desired output format.
        /// </summary>
        /// <param name="texture">The input texture.</param>
        /// <param name="textureFormat">The compression format to apply.</param>
        /// <returns>Texture2D in the desired format.</returns>
        private static Texture2D CompressTexture(Texture2D texture, TextureFormat textureFormat)
        {

#if UNITY_EDITOR
            //Anything other than TextureCompressionQuality.Fast resulted in extreme (>2 hours!) 
            //texture baking times for certain compression formats. Change only if truly needed.
#if UNITY_2018_3_OR_NEWER
            EditorUtility.CompressTexture(texture, textureFormat, UnityEditor.TextureCompressionQuality.Fast);
#else
            EditorUtility.CompressTexture(texture, textureFormat, TextureCompressionQuality.Fast);
#endif
#else
            //fallback in case someone creates profiles during runtime
            texture.Compress(true);
#endif
            texture.Apply(true);
            return texture;
        }




        /// <summary>
        /// Handy dump util
        /// </summary>
        /// <param name="name">Name of texture</param>
        /// <param name="color">Color being dumped</param>
        private void DebugTextureColorData(string name, Color32 color)
        {
            Debug.Log(string.Format("{0} - r{1} g{2} b{3} a{4}", name, color.r, color.g, color.b, color.a));
        }

        /// <summary>
        /// Utility to save textures for debugging
        /// </summary>
        /// <param name="path">The path and file name, but not file type of the texture</param>
        /// <param name="texture">Texture to save</param>
        private static void SaveTexture(string path, Texture2D texture)
        {
            byte[] content = texture.EncodeToPNG();
            File.WriteAllBytes(path + ".png", content);
        }

        /// <summary>
        /// Resize the supplied texture, also handles non rw textures and makes them rm
        /// </summary>
        /// <param name="texture">Source texture</param>
        /// <param name="width">Width of new texture</param>
        /// <param name="height">Height of new texture</param>
        /// <param name="mipmap">Generate mipmaps</param>
        /// <param name="linear">Use linear colour conversion</param>
        /// <returns>New texture</returns>
        public static Texture2D ResizeTexture(Texture2D texture, TextureFormat format, int aniso, int width, int height, bool mipmap, bool linear, bool compress)
        {
            RenderTexture rt;
            if (linear)
            {
                rt = RenderTexture.GetTemporary(width, height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
            }
            else
            {
                rt = RenderTexture.GetTemporary(width, height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.sRGB);
            }
            bool prevRgbConversionState = GL.sRGBWrite;
            if (linear)
            {
                GL.sRGBWrite = false;
            }
            else
            {
                GL.sRGBWrite = true;
            }
            Graphics.Blit(texture, rt);
            RenderTexture previous = RenderTexture.active;
            RenderTexture.active = rt;
            Texture2D newTexture = new Texture2D(width, height, m_workTextureFormat, mipmap, linear);
            newTexture.name = texture.name + " X";
            newTexture.anisoLevel = aniso;
            newTexture.filterMode = texture.filterMode;
            newTexture.wrapMode = texture.wrapMode;
            newTexture.mipMapBias = texture.mipMapBias;
            newTexture.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
            newTexture.Apply(true);

            //DEBUG
            //SaveTexture("Assets/" + newTexture.name, newTexture);

            newTexture =  CompressTexture(newTexture, format);

            RenderTexture.active = previous;
            RenderTexture.ReleaseTemporary(rt);
            GL.sRGBWrite = prevRgbConversionState;
            return newTexture;
        }

        /// <summary>
        /// Turn source textures into a 2D texture array
        /// </summary>
        /// <param name="sourceTextures">Textures to place into array</param>
        /// <returns>TextureArray if successful, null otherwise</returns>
        private Texture2DArray GetTextureArray(List<Texture2D> sourceTextures, CTSConstants.TextureType textureType, int aniso)
        {
            //Do some validation
            if (sourceTextures == null)
            {
                return null;
            }
            if (sourceTextures.Count == 0)
            {
                return null;
            }

            //Check they are all the same size
            Texture2D sourceTexture = sourceTextures[0];
            TextureFormat format = sourceTexture.format;
            int width = sourceTexture.width;
            int height = sourceTexture.height;
            for (int idx = 1; idx < sourceTextures.Count; idx++)
            {
                if (sourceTextures[idx].width != width || sourceTextures[idx].height != height)
                {
                    Debug.Log(string.Format("GetTextureArray : {0} width {1} <> {2}, height {3} <> {4}", sourceTextures[idx].name, sourceTextures[idx].width, width, sourceTextures[idx].height, height));
                    return null;
                }
            }

            Texture2DArray textureArray;
            switch (textureType)
            {
                case CTSConstants.TextureType.Albedo:
                case CTSConstants.TextureType.AmbientOcclusion:
                case CTSConstants.TextureType.Height:
                    textureArray = new Texture2DArray(width, height, sourceTextures.Count, format, true, false);
                    break;
                case CTSConstants.TextureType.Normal:
                    textureArray = new Texture2DArray(width, height, sourceTextures.Count, format, true, true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("textureType", textureType, null);
            }
            textureArray.filterMode = sourceTexture.filterMode;
            textureArray.wrapMode = sourceTexture.wrapMode;
            textureArray.anisoLevel = aniso;
            textureArray.mipMapBias = sourceTexture.mipMapBias;

            for (int idx = 0; idx < sourceTextures.Count; idx++)
            {
                if (sourceTextures[idx] != null)
                {
                    sourceTexture = sourceTextures[idx];
                    //Debug.Log(sourceTexture.name);
                    for (int mip = 0; mip < sourceTexture.mipmapCount; mip++)
                    {
                        Graphics.CopyTexture(sourceTexture, 0, mip, textureArray, idx, mip);
                    }
                }
            }
            textureArray.Apply(false);
            return textureArray;
        }

        /// <summary>
        /// Test to check whether two textures are different - does not check texture content
        /// </summary>
        /// <param name="src">Source texture</param>
        /// <param name="target">Target texture</param>
        /// <returns>True if different, false if not</returns>
        public static bool IsDifferentTexture(Texture2D src, Texture2D target)
        {
            if (src == null)
            {
                if (target != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (target == null)
                {
                    return true;
                }
                else
                {
                    if (src.GetInstanceID() != target.GetInstanceID())
                    {
                        return true;
                    }
                    else if (src.width != target.width)
                    {
                        return true;
                    }
                    else if (src.height != target.height)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Generate terrain replacement albedo textures
        /// </summary>
        public void ConstructTerrainReplacementAlbedos()
        {
            //Only do this when the application is not playing
            if (Application.isPlaying)
            {
                return;
            }

            //Match lengths up
            while (m_replacementTerrainAlbedos.Count > m_terrainTextures.Count)
            {
                m_replacementTerrainAlbedos.RemoveAt(m_replacementTerrainAlbedos.Count - 1);
            }
            while (m_replacementTerrainAlbedos.Count < m_terrainTextures.Count)
            {
                m_replacementTerrainAlbedos.Add(null);
            }

            //Create the directory if necessary
            string path = m_ctsDirectory + "Terrains/ReplacementTextures/";
            Directory.CreateDirectory(path);

            //Now generate the new replacement textures
            CTSTerrainTextureDetails td = null;
            for (int idx = 0; idx < m_terrainTextures.Count; idx++)
            {
                td = m_terrainTextures[idx];
                if (td.Albedo != null)
                {
                    string fullPath = path + td.Albedo.name + "_cts.png";
                    if (!File.Exists(fullPath))
                    {
                        Texture2D newAlbedo = ResizeTexture(td.Albedo, m_albedoFormat, m_albedoAniso, 64, 64, false, true, false);
                        newAlbedo.name = td.Albedo.name + "_cts";
                        m_replacementTerrainAlbedos[idx] = newAlbedo;
                        byte[] content = m_replacementTerrainAlbedos[idx].EncodeToPNG();
                        File.WriteAllBytes(fullPath, content);
#if UNITY_EDITOR
                        m_replacementTerrainAlbedos[idx] = AssetDatabase.LoadAssetAtPath<Texture2D>(fullPath);
#endif
                    }
                    else
                    {
#if UNITY_EDITOR
                        m_replacementTerrainAlbedos[idx] = AssetDatabase.LoadAssetAtPath<Texture2D>(fullPath);
#endif
                    }
                }
                else
                {
                    m_replacementTerrainAlbedos[idx] = null;
                }
            }
            CompleteTerrainShader.SetDirty(this, false, true);
        }

        /// <summary>
        /// Generate terrain replacement normal textures
        /// </summary>
        public void ConstructTerrainReplacementNormals()
        {
            //Forget about this if we are playing
            if (Application.isPlaying)
            {
                return;
            }


            //Match lengths up
            while (m_replacementTerrainNormals.Count > m_terrainTextures.Count)
            {
                m_replacementTerrainNormals.RemoveAt(m_replacementTerrainNormals.Count - 1);
            }
            while (m_replacementTerrainNormals.Count < m_terrainTextures.Count)
            {
                m_replacementTerrainNormals.Add(null);
            }

            //Create the directory if necessary
            string path = m_ctsDirectory + "Terrains/ReplacementTextures/";
            Directory.CreateDirectory(path);

            //Now generate the new replacement textures
            CTSTerrainTextureDetails td = null;
            for (int idx = 0; idx < m_terrainTextures.Count; idx++)
            {
                td = m_terrainTextures[idx];
                if (td.Normal != null)
                {
                    string fullPath = path + td.Normal.name + "_nrm_cts.png";
                    if (!File.Exists(fullPath))
                    {
                        Texture2D newNormal = ResizeTexture(td.Normal, m_normalFormat, m_normalAniso, 64, 64, false, true, false);
                        newNormal.name = td.Normal.name + "_nrm_cts";
                        m_replacementTerrainNormals[idx] = newNormal;
                        byte[] content = m_replacementTerrainNormals[idx].EncodeToPNG();
                        File.WriteAllBytes(fullPath, content);
#if UNITY_EDITOR
                        m_replacementTerrainNormals[idx] = AssetDatabase.LoadAssetAtPath<Texture2D>(fullPath);
#endif
                    }
                    else
                    {
#if UNITY_EDITOR
                        m_replacementTerrainNormals[idx] = AssetDatabase.LoadAssetAtPath<Texture2D>(fullPath);
#endif
                    }
                }
                else
                {
                    m_replacementTerrainNormals[idx] = null;
                }
            }
            CompleteTerrainShader.SetDirty(this, false, true);
        }
#endregion
    }
}

