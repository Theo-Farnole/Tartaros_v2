using System;
using UnityEngine;
#if SUBSTANCE_PLUGIN_ENABLED
using Substance.Game;
#endif


namespace CTS
{
    /// <summary>
    /// CTS terrain texture settings. Stores all the detail required to configure a CTS texture.
    /// </summary>
    [System.Serializable]
    public class CTSTerrainTextureDetails
    {
        #region General

        /// <summary>
        /// Whether this texture is currently open in the editor
        /// </summary>
        public bool m_isOpenInEditor = false;

        /// <summary>
        /// The index of this texture set in the terrain splat prototypes
        /// </summary>
        public int m_textureIdx = 0;

        /// <summary>
        /// The name of this texture set - derived from the albedo name
        /// </summary>
        public string m_name = "Texture";

        /// <summary>
        /// Detail power
        /// </summary>
        public float m_detailPower = 1f;

        /// <summary>
        /// Snow reduction power
        /// </summary>
        public float m_snowReductionPower = 0f;

        /// <summary>
        /// Geological power
        /// </summary>
        public float m_geologicalPower = 1f;

        /// <summary>
        /// Triplanar enabled or not
        /// </summary>
        public bool m_triplanar = false;

        /// <summary>
        /// Colour tint
        /// </summary>
        public Color m_tint = new Color(1f, 1f, 1f);

        /// <summary>
        /// Colour brightness
        /// </summary>
        public float m_tintBrightness = 1f;

        /// <summary>
        /// Smoothness
        /// </summary>
        public float m_smoothness = 1f;

        #endregion

        #region Substance related
#if !UNITY_WEBGL && !UNITY_WII && (!UNITY_2018_1_OR_NEWER || SUBSTANCE_PLUGIN_ENABLED)

        /// <summary>
        /// Regenerate substance texture on a bake
        /// </summary>
        public bool m_substanceRegenOnBake = false;

        /// <summary>
        /// Did we change a substance
        /// </summary>
        [NonSerialized]
        public bool m_substanceWasChanged = false;

        /// <summary>
        /// A substance texture - will support all the necessary texure types
        /// </summary>
#if SUBSTANCE_PLUGIN_ENABLED
        public SubstanceGraph Substance
#else
        public ProceduralMaterial Substance
#endif
        {
            get { return m_substance; }
            set
            {
                if (value == null)
                {
                    m_substance = value;
                }
                else
                {
                    if (m_substance == null || m_substance.GetInstanceID() != value.GetInstanceID())
                    {
                        m_substance = value;
                        m_substanceWasChanged = true;
                        #if SUBSTANCE_PLUGIN_ENABLED
                            CTSProfile.UnpackSubstance(m_substance);
                        #else
                            CTSProfile.UnpackSubstanceEditorMode(m_substance);
                        #endif
                    }
                }
            }
        }
        [SerializeField]
        #if SUBSTANCE_PLUGIN_ENABLED
            private SubstanceGraph m_substance;
        #else
            private ProceduralMaterial m_substance;
        #endif
#endif
#endregion

                        #region Albedo related

                        /// <summary>
                        /// Index of this texture in the albedo array
                        /// </summary>
        public int m_albedoIdx = -1;

        /// <summary>
        /// Albedo tiling
        /// </summary>
        public float m_albedoTilingClose = 15f;

        /// <summary>
        /// Far tiling factor for this albedo
        /// </summary>
        public float m_albedoTilingFar = 3f;

        /// <summary>
        /// Did we change the albedo
        /// </summary>
        [NonSerialized]
        public bool m_albedoWasChanged = false;

        /// <summary>
        /// The average colour and smoothness of this albedo
        /// </summary>
        public Vector4 m_albedoAverage;

        /// <summary>
        /// The albedo texture
        /// </summary>
        public Texture2D Albedo
        {
            get { return m_albedoTexture; }
            set
            {
                if (CTSProfile.IsDifferentTexture(m_albedoTexture, value))
                {
                    m_albedoTexture = value;
                    m_albedoWasChanged = true;
                    if (m_albedoTexture != null)
                    {
                        m_name = m_albedoTexture.name;
                    }
                    else
                    {
                        m_name = "Missing Albedo";
                    }
                }
            }
        }
        [SerializeField]
        private Texture2D m_albedoTexture;

        #endregion

        #region Smoothness related - baked into alpha channel on albedo if supplied

        /// <summary>
        /// Did we change the smoothness
        /// </summary>
        [NonSerialized]
        public bool m_smoothnessWasChanged = false;

        /// <summary>
        /// The smoothness texture
        /// </summary>
        public Texture2D Smoothness
        {
            get { return m_smoothnessTexture; }
            set
            {
                if (CTSProfile.IsDifferentTexture(m_smoothnessTexture, value))
                {
                    m_smoothnessTexture = value;
                    m_smoothnessWasChanged = true;
                }
            }
        }
        [SerializeField]
        private Texture2D m_smoothnessTexture;

#endregion

        #region Roughness related - converted to smoothness and baked into alpha channel on albedo if supplied

        /// <summary>
        /// Did we change the roughness
        /// </summary>
        [NonSerialized]
        public bool m_roughnessWasChanged = false;

        /// <summary>
        /// The roughness texture
        /// </summary>
        public Texture2D Roughness
        {
            get { return m_roughnessTexture; }
            set
            {
                if (CTSProfile.IsDifferentTexture(m_roughnessTexture, value))
                {
                    m_roughnessTexture = value;
                    m_roughnessWasChanged = true;
                }
            }
        }
        [SerializeField]
        private Texture2D m_roughnessTexture;

        #endregion

        #region Normal related

        /// <summary>
        /// The index of this normal texture in the normal array
        /// </summary>
        public int m_normalIdx = -1;

        /// <summary>
        /// The expressed power of this normal texture
        /// </summary>
        public float m_normalStrength = 1f;

        /// <summary>
        /// Did we change the normal
        /// </summary>
        [NonSerialized]
        public bool m_normalWasChanged = false;

        /// <summary>
        /// The normal texture
        /// </summary>
        public Texture2D Normal
        {
            get { return m_normalTexture; }
            set
            {
                if (CTSProfile.IsDifferentTexture(m_normalTexture, value))
                {
                    m_normalTexture = value;
                    m_normalWasChanged = true;
                }
            }
        }
        [SerializeField]
        private Texture2D m_normalTexture;

        #endregion

        #region Height related

        /// <summary>
        /// The albedo array index of this height texture
        /// </summary>
        public int m_heightIdx = -1;

        /// <summary>
        /// Height strength
        /// </summary>
        public float m_heightDepth = 8f;

        /// <summary>
        /// Height contrast
        /// </summary>
        public float m_heightContrast = 1f;

        /// <summary>
        /// Height blend sharpness close
        /// </summary>
        public float m_heightBlendClose = 1f;

        /// <summary>
        /// Height blend sharpness far
        /// </summary>
        public float m_heightBlendFar = 1f;

        /// <summary>
        /// Tesselation depth
        /// </summary>
        public float m_heightTesselationDepth = 0f;

        /// <summary>
        /// Minimim height in the texture
        /// </summary>
        public float m_heightMin = 0f;

        /// <summary>
        /// Maximum height in the texture
        /// </summary>
        public float m_heightMax = 1f;

        /// <summary>
        /// Was the height texture changed
        /// </summary>
        [NonSerialized]
        public bool m_heightWasChanged = false;

        /// <summary>
        /// The height texture
        /// </summary>
        public Texture2D Height
        {
            get { return m_heightTexture; }
            set
            {
                if (CTSProfile.IsDifferentTexture(m_heightTexture, value))
                {
                    m_heightTexture = value;
                    m_heightWasChanged = true;
                }
            }
        }
        [SerializeField]
        private Texture2D m_heightTexture;

        #endregion

        #region AO related

        /// <summary>
        /// The index of this ao texture in the albedo array
        /// </summary>
        public int m_aoIdx = -1;

        /// <summary>
        /// AO strength
        /// </summary>
        public float m_aoPower = 1f;

        /// <summary>
        /// Was the AO changed
        /// </summary>
        [NonSerialized]
        public bool m_aoWasChanged = false;

        /// <summary>
        /// AO texture
        /// </summary>
        public Texture2D AmbientOcclusion
        {
            get { return m_aoTexture; }
            set
            {
                if (CTSProfile.IsDifferentTexture(m_aoTexture, value))
                {
                    m_aoTexture = value;
                    m_aoWasChanged = true;
                }
            }
        }
        [SerializeField]
        private Texture2D m_aoTexture;
   
        #endregion

        #region Emission related

        /// <summary>
        /// The index of this emission texture in the albedo array
        /// </summary>
        public int m_emissionIdx = -1;

        /// <summary>
        /// Emission strength
        /// </summary>
        public float m_emissionStrength = 1f;

        /// <summary>
        /// Was the emission changed
        /// </summary>
        [NonSerialized]
        public bool m_emissionWasChanged = false;

        /// <summary>
        /// Emission texture
        /// </summary>
        public Texture2D Emission
        {
            get { return m_emissionTexture; }
            set
            {
                if (CTSProfile.IsDifferentTexture(m_emissionTexture, value))
                {
                    m_emissionTexture = value;
                    m_emissionWasChanged = true;
                }
            }
        }
        [SerializeField]
        private Texture2D m_emissionTexture;

        #endregion

        //Default constructor
        public CTSTerrainTextureDetails() {}

        /// <summary>
        /// Copy constructor - wont duplicate textures tho - just settings and references
        /// </summary>
        /// <param name="src">Source object</param>
        public CTSTerrainTextureDetails(CTSTerrainTextureDetails src)
        {
            m_isOpenInEditor = src.m_isOpenInEditor;
            m_textureIdx = src.m_textureIdx;
            m_name = src.m_name;
            m_detailPower = src.m_detailPower;
            m_snowReductionPower = src.m_snowReductionPower;
            m_geologicalPower = src.m_geologicalPower;
            m_triplanar = src.m_triplanar;
            m_tint = src.m_tint;
            m_tintBrightness = src.m_tintBrightness;
            m_smoothness = src.m_smoothness;

            #if !UNITY_WEBGL && !UNITY_WII && (!UNITY_2018_1_OR_NEWER || SUBSTANCE_PLUGIN_ENABLED)
            m_substanceRegenOnBake = src.m_substanceRegenOnBake;
            m_substanceWasChanged = src.m_substanceWasChanged;
            m_substance = src.m_substance;
            #endif

            m_albedoIdx = src.m_albedoIdx;
            m_albedoTilingClose = src.m_albedoTilingClose;
            m_albedoTilingFar = src.m_albedoTilingFar;
            m_albedoWasChanged = src.m_albedoWasChanged;
            m_albedoTexture = src.m_albedoTexture;

            m_normalIdx = src.m_normalIdx;
            m_normalStrength = src.m_normalStrength;
            m_normalWasChanged = src.m_normalWasChanged;
            m_normalTexture = src.m_normalTexture;

            m_heightIdx = src.m_heightIdx;
            m_heightDepth = src.m_heightDepth;
            m_heightTesselationDepth = src.m_heightTesselationDepth;
            m_heightContrast = src.m_heightContrast;
            m_heightBlendClose = src.m_heightBlendClose;
            m_heightBlendFar = src.m_heightBlendFar;
            m_heightWasChanged = src.m_heightWasChanged;
            m_heightTexture = src.m_heightTexture;

            m_aoIdx = src.m_aoIdx;
            m_aoPower = src.m_aoPower;
            m_aoWasChanged = src.m_aoWasChanged;
            m_aoTexture = src.m_aoTexture;

            m_emissionIdx = src.m_emissionIdx;
            m_emissionStrength = src.m_emissionStrength;
            m_emissionWasChanged = src.m_emissionWasChanged;
            m_emissionTexture = src.m_emissionTexture;

            m_smoothness = src.m_smoothness;
            m_roughnessTexture = src.m_roughnessTexture;
        }

        /// <summary>
        /// Reset all the changed flags
        /// </summary>
        public void ResetChangedFlags()
        {
            #if !UNITY_WEBGL && !UNITY_WII && (!UNITY_2018_1_OR_NEWER || SUBSTANCE_PLUGIN_ENABLED)
            m_substanceWasChanged = false;
            #endif
            m_albedoWasChanged = false;
            m_normalWasChanged = false;
            m_heightWasChanged = false;
            m_aoWasChanged = false;
            m_emissionWasChanged = false;
        }

        /// <summary>
        /// Return true if any texture has changed
        /// </summary>
        /// <returns>True if a texture has been changed</returns>
        public bool TextureHasChanged()
        {
            #if !UNITY_WEBGL && !UNITY_WII && (!UNITY_2018_1_OR_NEWER || SUBSTANCE_PLUGIN_ENABLED)
            if (m_substanceWasChanged)
                return true;
            #endif
            if (m_albedoWasChanged)
                return true;
            if (m_normalWasChanged)
                return true;
            if (m_heightWasChanged)
                return true;
            if (m_aoWasChanged)
                return true;
            if (m_emissionWasChanged)
                return true;

            return false;
        }
    }
}

