using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CTS
{
    /// <summary>
    /// Mesh Blender - handles configuration and setup of mesh blending for terrains with CTS.
    /// Drag and drop this script onto any object that you want to blend with the terrain.
    /// NOTE: This is expensive so use it sparingly.
    /// </summary>
    [ExecuteInEditMode]
    [System.Serializable]
    public class CTSMeshBlender : MonoBehaviour
    {
        [System.Serializable]
        public class TextureData
        {
            public int m_terrainIdx;
            public float m_terrainTextureStrength;
            public Texture2D m_albedo;
            public Texture2D m_normal;
            public Texture2D m_hao_in_GA;
            public float m_tiling;
            public Vector4 m_color;
            public float m_normalPower; //1..5 (1 looks like bug!)
            public float m_aoPower; //0..1
            public float m_geoPower; //0..2
            public float m_heightContrast = 1f;
            public float m_heightDepth = 1f;
            public float m_heightBlendClose = 1f;
        }

        //Blend control
        public float m_textureBlendOffset = -2f;    //This is where the texture blend is offset relative to the terrain at that location
        public float m_textureBlendStart = 2f;      //Where the blend starts relative to the offset
        public float m_textureBlendHeight = 1f;     //Height of the blend
        public float m_normalBlendOffset = -1f;     //This is where the normal blend is offset relative to the terrain at that location
        public float m_normalBlendStart = 0f;       //Where the normal blend starts relative to the offset
        public float m_normalBlendHeight = 2f;      //Height of the normal blend

        //Shader control
        public float m_specular = 1f;
        public float m_smoothness = 1f;
        public bool m_useAO = true;
        public bool m_useAOTexture = false;
        public float m_geoMapClosePower = 0f; //0..2
        public float m_geoTilingClose = 1f; //0..1
        public float m_geoMapOffsetClose = 86f; //0..1000
        public Texture2D m_geoMap;
        public Material m_sharedMaterial;
        public List<TextureData> m_textureList = new List<TextureData>();

        private MaterialPropertyBlock m_materialProperties;

        [SerializeField]
        private MeshRenderer[] m_renderers;
        [SerializeField]
        private MeshFilter[] m_filters;
        [SerializeField]
        private Mesh[] m_originalMeshes;

        //Common ID's across all instances - leverage for faster material updates
        private static bool _ShadersIDsAreInitialized = false;
        private static int _Use_AO;
        private static int _Use_AO_Texture;
        private static int _Terrain_Specular;
        private static int _Terrain_Smoothness;
        private static int _Texture_Geological_Map;
        private static int _Geological_Tiling_Close;
        private static int _Geological_Map_Offset_Close;
        private static int _Geological_Map_Close_Power;
        private static int _Texture_Albedo_Sm_1;
        private static int _Texture_Color_1;
        private static int _Texture_Tiling_1;
        private static int _Texture_Normal_1;
        private static int _Texture_1_Normal_Power;
        private static int _Texture_GHeightAAO_1;
        private static int _Texture_1_AO_Power;
        private static int _Texture_1_Geological_Power;

        //
        private static int _Texture_1_Height_Contrast;
        private static int _Texture_1_Heightmap_Depth;
        private static int _Texture_1_Heightblend_Close;

        private static int _Texture_Albedo_Sm_2;
        private static int _Texture_Color_2;
        private static int _Texture_Tiling_2;
        private static int _Texture_Normal_2;
        private static int _Texture_2_Normal_Power;
        private static int _Texture_GHeightAAO_2;
        private static int _Texture_2_AO_Power;
        private static int _Texture_2_Geological_Power;

        //
        private static int _Texture_2_Height_Contrast;
        private static int _Texture_2_Heightmap_Depth;
        private static int _Texture_2_Heightblend_Close;

        private static int _Texture_Albedo_Sm_3;
        private static int _Texture_Color_3;
        private static int _Texture_Tiling_3;
        private static int _Texture_Normal_3;
        private static int _Texture_3_Normal_Power;
        private static int _Texture_GHeightAAO_3;
        private static int _Texture_3_AO_Power;
        private static int _Texture_3_Geological_Power;

        private static int _Texture_3_Height_Contrast;
        private static int _Texture_3_Heightmap_Depth;
        private static int _Texture_3_Heightblend_Close;


        void Awake()
        {
            //Debug.Log("BLENDER AWAKED!");
            //InitializeShaders();
        }

        /// <summary>
        /// Completely remove the blender material and restore it to its previous stae
        /// </summary>
        public void ClearBlend()
        {
            //Restore meshes to originals
            if (m_filters != null)
            {
                for (int fIdx = 0; fIdx < m_filters.Length; fIdx++)
                {
                    m_filters[fIdx].sharedMesh = m_originalMeshes[fIdx];
                }
            }
//            else
//            {
//                Debug.LogWarning("No filters found!");
//            }

            //Remove any mesh blender materials
            if (m_renderers != null)
            {
                for (int rIdx = 0; rIdx < m_renderers.Length; rIdx++)
                {
                    MeshRenderer renderer = m_renderers[rIdx];
                    List<Material> materials = new List<Material>(renderer.sharedMaterials);
                    for (int mIdx = 0; mIdx < materials.Count;)
                    {
                        Material material = materials[mIdx];
                        if (material == null || material.name == "CTS Model Blend Shader")
                        {
                            materials.RemoveAt(mIdx);
                            m_sharedMaterial = material;
                        }
                        else
                        {
                            mIdx++;
                        }
                    }
                    renderer.sharedMaterials = materials.ToArray();
                }
            }
//            else
//            {
//                Debug.LogWarning("No renderers found!");
//            }

            //Lose all traces
            if (m_sharedMaterial != null)
            {
                DestroyImmediate(m_sharedMaterial);
                m_sharedMaterial = null;
            }
            m_renderers = null;
            m_filters = null;
            m_originalMeshes = null;
            m_textureList.Clear();
        }

        /// <summary>
        /// Remove the blender material, create a new one, calculate the blend, and then update the shader
        /// </summary>
        public void CreateBlend()
        {
            //Remove past
            ClearBlend();

            //Setup our basic stuctures
            m_renderers = gameObject.GetComponentsInChildren<MeshRenderer>();
            m_filters = gameObject.GetComponentsInChildren<MeshFilter>();
            m_originalMeshes = new Mesh[m_filters.Length];

            //Backup meshes, and replace with copies
            for (int fIdx = 0; fIdx < m_filters.Length; fIdx++)
            {
                if (m_filters[fIdx].sharedMesh == null)
                {
                    m_originalMeshes[fIdx] = null;
                }
                else
                {
                    //Grab original mesh for backup purposes
                    m_originalMeshes[fIdx] = m_filters[fIdx].sharedMesh;

                    //Set up the new mesh
                    m_filters[fIdx].sharedMesh = Instantiate<Mesh>(m_originalMeshes[fIdx]);
                }
            }

            //Work out the top most textures and pickup CTS settings at current location
            GetTexturesAndSettingsAtCurrentLocation();

            //Vertex paint our meshes & calculate normals
            Vector3 meshWorldPosition = transform.position;
            Vector3 meshScale = transform.localScale;
            Vector3 meshRotation = transform.eulerAngles;
            for (int fIdx = 0; fIdx < m_filters.Length; fIdx++)
            {
                Mesh mesh = m_filters[fIdx].sharedMesh;
                if (mesh != null)
                {
                    int vertLength = mesh.vertices.Length;
                    Vector3[] vertices = mesh.vertices;
                    Vector3[] normals = mesh.normals;
                    Color[] colors = mesh.colors;

                    //Make sure we have colours
                    if (colors.Length == 0)
                    {
                        colors = new Color[vertLength];
                    }

                    //Process each vertex
                    for (int i = 0; i < vertLength; i++)
                    {
                        Vector3 vertexWorldPosition = meshWorldPosition + (Quaternion.Euler(meshRotation) * Vector3.Scale(vertices[i], meshScale));
                        Terrain terrain = GetTerrain(vertexWorldPosition);
                        if (terrain != null)
                        {
                            Vector3 vertexLocalTerrainPosition = GetLocalPosition(terrain, vertexWorldPosition);
                            float height = terrain.SampleHeight(vertexWorldPosition);
                            float textureBlendMin = height + m_textureBlendOffset;
                            float textureBlendStart = textureBlendMin + m_textureBlendStart;
                            float textureBlendEnd = textureBlendStart + m_textureBlendHeight;
                            float normalBlendMin = height + m_normalBlendOffset;
                            float normalBlendStart = normalBlendMin  + m_normalBlendStart;
                            float normalBlendEnd = normalBlendStart + m_normalBlendHeight;

                            //Calculate colour blend
                            if (vertexWorldPosition.y < textureBlendMin)
                            {
                                colors[i].a = 0f;
                            }
                            else if (vertexWorldPosition.y <= textureBlendEnd)
                            {
                                Color c = new Color();
                                float saturation = 1f;
                                if (vertexWorldPosition.y > textureBlendStart)
                                {
                                    saturation = Mathf.Lerp(1f, 0f, (vertexWorldPosition.y - textureBlendStart) / m_textureBlendHeight);
                                }
                                c.a = saturation;

                                //Process textures at this location
                                float[,,] texturesAtLocation = GetTexturesAtLocation(terrain, vertexLocalTerrainPosition);
                                if (m_textureList.Count >= 1)
                                {
                                    c.r = texturesAtLocation[0, 0, m_textureList[0].m_terrainIdx];
                                }
                                if (m_textureList.Count >= 2)
                                {
                                    c.g = texturesAtLocation[0, 0, m_textureList[1].m_terrainIdx];
                                }
                                if (m_textureList.Count >= 3)
                                {
                                    c.b = texturesAtLocation[0, 0, m_textureList[2].m_terrainIdx];
                                }

                                colors[i] = c;
                            }
                            else
                            {
                                colors[i].a = 0f;
                            }

                            //Calculate normal blend
                            if (vertexWorldPosition.y >= normalBlendMin)
                            {
                                if (vertexWorldPosition.y < normalBlendStart)
                                {
                                    normals[i] = GetNormalsAtLocation(terrain, vertexLocalTerrainPosition);
                                }
                                else if (vertexWorldPosition.y <= normalBlendEnd)
                                {
                                    normals[i] = Vector3.Lerp(GetNormalsAtLocation(terrain, vertexLocalTerrainPosition), normals[i], (normalBlendEnd - vertexWorldPosition.y) / m_normalBlendHeight);
                                }
                            }
                        }
                        else
                        {
                            colors[i].a = 0f;
                        }
                    }

                    //Apply the color
                    mesh.colors = colors;
                    mesh.normals = normals;
                }
            }

            //Setup the materials
            InitializeMaterials();

            //Update the shader
            UpdateShader();
        }


        /// <summary>
        /// Get the nearest vertice of the target object to the source position provided in world units
        /// </summary>
        /// <param name="sourcePosition">Source we are checking from</param>
        /// <param name="targetObject">Target object we are processing</param>
        /// <returns>Closest vertice</returns>
        public Vector3 GetNearestVertice(Vector3 sourcePosition, GameObject targetObject)
        {
            float closestDistance = float.MaxValue;
            Vector3 closestVertice = targetObject.transform.position;
            Vector3 meshWorldPosition = closestVertice;
            Vector3 meshScale = targetObject.transform.localScale;
            Vector3 meshRotation = targetObject.transform.eulerAngles;
            MeshFilter[] filters = targetObject.GetComponentsInChildren<MeshFilter>();
            for (int fIdx = 0; fIdx < filters.Length; fIdx++)
            {
                Mesh mesh = filters[fIdx].sharedMesh;
                if (mesh != null)
                {
                    int vertLength = mesh.vertices.Length;
                    Vector3[] vertices = mesh.vertices;
                    for (int i = 0; i < vertLength; i++)
                    {
                        Vector3 vertexWorldPosition = meshWorldPosition + (Quaternion.Euler(meshRotation) * Vector3.Scale(vertices[i], meshScale));
                        float actualDistance = Vector3.Distance(sourcePosition, vertexWorldPosition);
                        if (actualDistance < closestDistance)
                        {
                            closestDistance = actualDistance;
                            closestVertice = vertexWorldPosition;
                        }
                    }
                }
            }
            return closestVertice;
        }


        #region Private functions

        private void InitializeShaderConstants()
        {
            //Check to see if shader id's are initialized
            if (!_ShadersIDsAreInitialized)
            {
                Debug.Log("Initialising shader IDs");

                _ShadersIDsAreInitialized = true;

                _Use_AO = Shader.PropertyToID("_Use_AO");
                _Use_AO_Texture = Shader.PropertyToID("_Use_AO_Texture");
                _Terrain_Specular = Shader.PropertyToID("_Terrain_Specular");
                _Terrain_Smoothness = Shader.PropertyToID("_Terrain_Smoothness");
                _Texture_Geological_Map = Shader.PropertyToID("_Texture_Geological_Map");
                _Geological_Tiling_Close = Shader.PropertyToID("_Geological_Tiling_Close");
                _Geological_Map_Offset_Close = Shader.PropertyToID("_Geological_Map_Offset_Close");
                _Geological_Map_Close_Power = Shader.PropertyToID("_Geological_Map_Close_Power");

                _Texture_Albedo_Sm_1 = Shader.PropertyToID("_Texture_Albedo_Sm_1");
                _Texture_Color_1 = Shader.PropertyToID("_Texture_Color_1");
                _Texture_Tiling_1 = Shader.PropertyToID("_Texture_Tiling_1");
                _Texture_Normal_1 = Shader.PropertyToID("_Texture_Normal_1");
                _Texture_1_Normal_Power = Shader.PropertyToID("_Texture_1_Normal_Power");
                _Texture_GHeightAAO_1 = Shader.PropertyToID("_Texture_GHeightAAO_1");
                _Texture_1_AO_Power = Shader.PropertyToID("_Texture_1_AO_Power");
                _Texture_1_Geological_Power = Shader.PropertyToID("_Texture_1_Geological_Power");
                _Texture_1_Height_Contrast = Shader.PropertyToID("_Texture_1_Height_Contrast");
                _Texture_1_Heightmap_Depth = Shader.PropertyToID("_Texture_1_Heightmap_Depth");
                _Texture_1_Heightblend_Close = Shader.PropertyToID("_Texture_1_Heightblend_Close");

                _Texture_Albedo_Sm_2 = Shader.PropertyToID("_Texture_Albedo_Sm_2");
                _Texture_Color_2 = Shader.PropertyToID("_Texture_Color_2");
                _Texture_Tiling_2 = Shader.PropertyToID("_Texture_Tiling_2");
                _Texture_Normal_2 = Shader.PropertyToID("_Texture_Normal_2");
                _Texture_2_Normal_Power = Shader.PropertyToID("_Texture_2_Normal_Power");
                _Texture_GHeightAAO_2 = Shader.PropertyToID("_Texture_GHeightAAO_2");
                _Texture_2_AO_Power = Shader.PropertyToID("_Texture_2_AO_Power");
                _Texture_2_Geological_Power = Shader.PropertyToID("_Texture_2_Geological_Power");
                _Texture_2_Height_Contrast = Shader.PropertyToID("_Texture_2_Height_Contrast");
                _Texture_2_Heightmap_Depth = Shader.PropertyToID("_Texture_2_Heightmap_Depth");
                _Texture_2_Heightblend_Close = Shader.PropertyToID("_Texture_2_Heightblend_Close");

                _Texture_Albedo_Sm_3 = Shader.PropertyToID("_Texture_Albedo_Sm_3");
                _Texture_Color_3 = Shader.PropertyToID("_Texture_Color_3");
                _Texture_Tiling_3 = Shader.PropertyToID("_Texture_Tiling_3");
                _Texture_Normal_3 = Shader.PropertyToID("_Texture_Normal_3");
                _Texture_3_Normal_Power = Shader.PropertyToID("_Texture_3_Normal_Power");
                _Texture_GHeightAAO_3 = Shader.PropertyToID("_Texture_GHeightAAO_3");
                _Texture_3_AO_Power = Shader.PropertyToID("_Texture_3_AO_Power");
                _Texture_3_Geological_Power = Shader.PropertyToID("_Texture_3_Geological_Power");
                _Texture_3_Height_Contrast = Shader.PropertyToID("_Texture_3_Height_Contrast");
                _Texture_3_Heightmap_Depth = Shader.PropertyToID("_Texture_3_Heightmap_Depth");
                _Texture_3_Heightblend_Close = Shader.PropertyToID("_Texture_3_Heightblend_Close");
            }
        }

        /// <summary>
        /// Setup the materials for this object
        /// </summary>
        private void InitializeMaterials()
        {
            //Setup the materials 
            for (int rIdx = 0; rIdx < m_renderers.Length; rIdx++)
            {
                MeshRenderer renderer = m_renderers[rIdx];
                if (renderer != null)
                {
                    bool gotMaterial = false;
                    List<Material> materials = new List<Material>(m_renderers[rIdx].sharedMaterials);
                    for (int mIdx = 0; mIdx < materials.Count; mIdx++)
                    {
                        if (materials[mIdx].name == "CTS Model Blend Shader")
                        {
                            gotMaterial = true;
                            m_sharedMaterial = materials[mIdx];
                            break;
                        }
                    }
                    if (!gotMaterial)
                    {
                        if (m_sharedMaterial == null)
                        {
                            m_sharedMaterial = new Material(Shader.Find(CTSConstants.CTSShaderMeshBlenderName))
                            {
                                name = "CTS Model Blend Shader"
                                //hideFlags = HideFlags.HideAndDontSave
                            };
                        }
                        materials.Add(m_sharedMaterial);
                        renderer.sharedMaterials = materials.ToArray();
                    }
                }
                else
                {
                    Debug.LogWarning("Got nulll renderer!");
                }
            }
        }

        /// <summary>
        /// Update the shader
        /// </summary>
        private void UpdateShader()
        {
            //Always check to see if shader constants are initialized
            InitializeShaderConstants();

            if (m_sharedMaterial == null)
            {
                Debug.LogWarning("CTS Blender Missing Material. Exiting without updating.");
                return;
            }

            if (m_renderers == null || m_renderers.Length == 0)
            {
                Debug.LogWarning("CTS Blender Missing Renderer. Exiting without updating.");
                return;
            }

            if (m_textureList.Count == 0)
            {
                Debug.LogWarning("CTS Blender has no textures. Exiting without updating.");
                return;
            }

            if (m_materialProperties == null)
            {
                m_materialProperties = new MaterialPropertyBlock();
            }

            for (int rIdx = 0; rIdx < m_renderers.Length; rIdx++)
            {
                m_sharedMaterial.SetInt(_Use_AO, m_useAO ? 1 : 0);
                m_sharedMaterial.SetInt(_Use_AO_Texture, m_useAOTexture ? 1 : 0);
                m_sharedMaterial.SetFloat(_Terrain_Specular, m_specular);
                m_sharedMaterial.SetFloat(_Terrain_Smoothness, m_smoothness);
                m_sharedMaterial.SetTexture(_Texture_Geological_Map, m_geoMap);
                m_sharedMaterial.SetFloat(_Geological_Tiling_Close, m_geoTilingClose);
                m_sharedMaterial.SetFloat(_Geological_Map_Offset_Close, m_geoMapOffsetClose);
                m_sharedMaterial.SetFloat(_Geological_Map_Close_Power, m_geoMapClosePower);

                if (m_textureList.Count >= 1)
                {
                    TextureData t = m_textureList[0];
                    m_sharedMaterial.SetTexture(_Texture_Albedo_Sm_1, t.m_albedo);
                    m_sharedMaterial.SetTexture(_Texture_Normal_1, t.m_normal);
                    m_sharedMaterial.SetTexture(_Texture_GHeightAAO_1, t.m_hao_in_GA);
                    m_sharedMaterial.SetVector(_Texture_Color_1, t.m_color);
                    m_sharedMaterial.SetFloat(_Texture_Tiling_1, t.m_tiling);
                    m_sharedMaterial.SetFloat(_Texture_1_Normal_Power, t.m_normalPower);
                    m_sharedMaterial.SetFloat(_Texture_1_AO_Power, t.m_aoPower);
                    m_sharedMaterial.SetFloat(_Texture_1_Geological_Power, t.m_geoPower);
                    m_sharedMaterial.SetFloat(_Texture_1_Height_Contrast, t.m_heightContrast);
                    m_sharedMaterial.SetFloat(_Texture_1_Heightmap_Depth, t.m_heightDepth);
                    m_sharedMaterial.SetFloat(_Texture_1_Heightblend_Close, t.m_heightBlendClose);
                }

                if (m_textureList.Count >= 2)
                {
                    TextureData t = m_textureList[1];
                    m_sharedMaterial.SetTexture(_Texture_Albedo_Sm_2, t.m_albedo);
                    m_sharedMaterial.SetTexture(_Texture_Normal_2, t.m_normal);
                    m_sharedMaterial.SetTexture(_Texture_GHeightAAO_2, t.m_hao_in_GA);
                    m_sharedMaterial.SetVector(_Texture_Color_2, t.m_color);
                    m_sharedMaterial.SetFloat(_Texture_Tiling_2, t.m_tiling);
                    m_sharedMaterial.SetFloat(_Texture_2_Normal_Power, t.m_normalPower);
                    m_sharedMaterial.SetFloat(_Texture_2_AO_Power, t.m_aoPower);
                    m_sharedMaterial.SetFloat(_Texture_2_Geological_Power, t.m_geoPower);
                    m_sharedMaterial.SetFloat(_Texture_2_Height_Contrast, t.m_heightContrast);
                    m_sharedMaterial.SetFloat(_Texture_2_Heightmap_Depth, t.m_heightDepth);
                    m_sharedMaterial.SetFloat(_Texture_2_Heightblend_Close, t.m_heightBlendClose);
                }

                if (m_textureList.Count >= 3)
                {
                    TextureData t = m_textureList[2];
                    m_sharedMaterial.SetTexture(_Texture_Albedo_Sm_3, t.m_albedo);
                    m_sharedMaterial.SetTexture(_Texture_Normal_3, t.m_normal);
                    m_sharedMaterial.SetTexture(_Texture_GHeightAAO_3, t.m_hao_in_GA);
                    m_sharedMaterial.SetVector(_Texture_Color_3, t.m_color);
                    m_sharedMaterial.SetFloat(_Texture_Tiling_3, t.m_tiling);
                    m_sharedMaterial.SetFloat(_Texture_3_Normal_Power, t.m_normalPower);
                    m_sharedMaterial.SetFloat(_Texture_3_AO_Power, t.m_aoPower);
                    m_sharedMaterial.SetFloat(_Texture_3_Geological_Power, t.m_geoPower);
                    m_sharedMaterial.SetFloat(_Texture_3_Height_Contrast, t.m_heightContrast);
                    m_sharedMaterial.SetFloat(_Texture_3_Heightmap_Depth, t.m_heightDepth);
                    m_sharedMaterial.SetFloat(_Texture_3_Heightblend_Close, t.m_heightBlendClose);
                }

                //m_renderers[rIdx].SetPropertyBlock(m_materialProperties);


                /*
                                m_renderers[rIdx].GetPropertyBlock(m_materialProperties);

                                m_materialProperties.SetInt(_Use_AO, m_useAO ? 1 : 0);
                                m_materialProperties.SetInt(_Use_AO_Texture, m_useAOTexture ? 1 : 0);
                                m_materialProperties.SetFloat(_Terrain_Specular, m_specular);
                                m_materialProperties.SetFloat(_Terrain_Smoothness, m_smoothness);
                                m_materialProperties.SetTexture(_Texture_Geological_Map, m_geoMap);
                                m_materialProperties.SetFloat(_Geological_Tiling_Close, m_geoTilingClose);
                                m_materialProperties.SetFloat(_Geological_Map_Offset_Close, m_geoMapOffsetClose);
                                m_materialProperties.SetFloat(_Geological_Map_Close_Power, m_geoMapClosePower);

                                if (m_textureList.Count >= 1)
                                {
                                    TextureData t = m_textureList[0];
                                    m_materialProperties.SetTexture(_Texture_Albedo_Sm_1, t.m_albedo);
                                    m_materialProperties.SetTexture(_Texture_Normal_1, t.m_normal);
                                    m_materialProperties.SetTexture(_Texture_GHeightAAO_1, t.m_ao);
                                    m_materialProperties.SetVector(_Texture_Color_1, t.m_color);
                                    m_materialProperties.SetFloat(_Texture_Tiling_1, t.m_tiling);
                                    m_materialProperties.SetFloat(_Texture_1_Normal_Power, t.m_normalPower);
                                    m_materialProperties.SetFloat(_Texture_1_AO_Power, t.m_aoPower);
                                    m_materialProperties.SetFloat(_Texture_1_Geological_Power, t.m_geoPower);
                                }

                                if (m_textureList.Count >= 2)
                                {
                                    TextureData t = m_textureList[1];
                                    m_materialProperties.SetTexture(_Texture_Albedo_Sm_2, t.m_albedo);
                                    m_materialProperties.SetTexture(_Texture_Normal_2, t.m_normal);
                                    m_materialProperties.SetTexture(_Texture_GHeightAAO_2, t.m_ao);
                                    m_materialProperties.SetVector(_Texture_Color_2, t.m_color);
                                    m_materialProperties.SetFloat(_Texture_Tiling_2, t.m_tiling);
                                    m_materialProperties.SetFloat(_Texture_2_Normal_Power, t.m_normalPower);
                                    m_materialProperties.SetFloat(_Texture_2_AO_Power, t.m_aoPower);
                                    m_materialProperties.SetFloat(_Texture_2_Geological_Power, t.m_geoPower);
                                }

                                if (m_textureList.Count >= 3)
                                {
                                    TextureData t = m_textureList[3];
                                    m_materialProperties.SetTexture(_Texture_Albedo_Sm_3, t.m_albedo);
                                    m_materialProperties.SetTexture(_Texture_Normal_3, t.m_normal);
                                    m_materialProperties.SetTexture(_Texture_GHeightAAO_3, t.m_ao);
                                    m_materialProperties.SetVector(_Texture_Color_3, t.m_color);
                                    m_materialProperties.SetFloat(_Texture_Tiling_3, t.m_tiling);
                                    m_materialProperties.SetFloat(_Texture_3_Normal_Power, t.m_normalPower);
                                    m_materialProperties.SetFloat(_Texture_3_AO_Power, t.m_aoPower);
                                    m_materialProperties.SetFloat(_Texture_3_Geological_Power, t.m_geoPower);
                                }

                                m_renderers[rIdx].SetPropertyBlock(m_materialProperties);
                */
            }
        }



        /// <summary>
        /// Pick up the textures from the terrain at this location base on vertext positions
        /// </summary>
        private void GetTexturesAndSettingsAtCurrentLocation()
        {
            //Clear out the old terrain textures and their strengths
            m_textureList.Clear();

            //Iterate through every vertex of every mesh and aggregrate the underlying terrain texture strengths
            CTSProfile ctsProfile = null;
            CTSSplatPrototype[] splatPrototypes = new CTSSplatPrototype[0];
            Vector3 meshWorldPosition = transform.position;
            Vector3 meshWorldScale = transform.localScale;
            Vector3 meshWorldEulerAngles = transform.eulerAngles;
            for (int fIdx = m_filters.Length - 1; fIdx >= 0; fIdx--)
            {
                Mesh mesh = m_filters[fIdx].sharedMesh;
                if (mesh != null)
                {
                    //Now work out strongest textures
                    Vector3[] vertices = mesh.vertices;
                    for (int vIdx = vertices.Length - 1; vIdx >= 0; vIdx--)
                    {
                        //Where is this vertex in world coordinates
                        Vector3 vertexWorldPosition = meshWorldPosition + (Quaternion.Euler(meshWorldEulerAngles) * Vector3.Scale(vertices[vIdx], meshWorldScale));

                        //Get terrain at this location
                        Terrain terrain = GetTerrain(vertexWorldPosition);
                        if (terrain != null)
                        {
                            //Grab the first CTS profile available
                            if (ctsProfile == null)
                            {
                                CompleteTerrainShader cts = terrain.gameObject.GetComponent<CompleteTerrainShader>();
                                if (cts != null)
                                {
                                    ctsProfile = cts.Profile;
                                }
                            }

                            //Grab the first set of splat protos available
                            if (splatPrototypes.Length == 0)
                            {
                                splatPrototypes = CTSSplatPrototype.GetCTSSplatPrototypes(terrain);
                            }

                            //Process textures at this location
                            Vector3 vertexLocalTerrainPosition = GetLocalPosition(terrain, vertexWorldPosition);
                            float[,,] texturesAtLocation = GetTexturesAtLocation(terrain, vertexLocalTerrainPosition);
                            for (int tIdx = 0; tIdx < texturesAtLocation.GetLength(2); tIdx++)
                            {
                                if (tIdx == m_textureList.Count)
                                {
                                    TextureData tData = new TextureData();
                                    tData.m_terrainIdx = tIdx;
                                    tData.m_terrainTextureStrength = texturesAtLocation[0, 0, tIdx];
                                    m_textureList.Add(tData);
                                }
                                else
                                {
                                    m_textureList[tIdx].m_terrainTextureStrength += texturesAtLocation[0, 0, tIdx];
                                }
                            }
                        }
                    }
                }
            }

            //Now sort the list by decending order of maximum detected texture strength
            List<TextureData> textureList = m_textureList.OrderByDescending(x => x.m_terrainTextureStrength).ToList();

            //Then delete all but top 3
            while (textureList.Count > 3)
            {
                textureList.RemoveAt(textureList.Count - 1);
            }

            //Now sort back into same order as CTS and assign back
            m_textureList = textureList.OrderBy(x => x.m_terrainIdx).ToList();

            //Load up the high level settings from CTS profile if present or set some defaults
            if (ctsProfile != null)
            {
                m_geoMap = ctsProfile.GeoAlbedo;
                m_geoMapClosePower = ctsProfile.m_geoMapClosePower;
                m_geoMapOffsetClose = ctsProfile.m_geoMapCloseOffset;
                m_geoTilingClose = ctsProfile.m_geoMapTilingClose;
                m_smoothness = ctsProfile.m_globalTerrainSmoothness;
                m_specular = ctsProfile.m_globalTerrainSpecular;
                switch (ctsProfile.m_globalAOType)
                {
                    case CTSConstants.AOType.None:
                        m_useAO = false;
                        m_useAOTexture = false;
                        break;
                    case CTSConstants.AOType.NormalMapBased:
                        m_useAO = true;
                        m_useAOTexture = false;
                        break;
                    case CTSConstants.AOType.TextureBased:
                        m_useAO = true;
                        m_useAOTexture = true;
                        break;
                }
            }
            else
            {
                m_geoMap = null;
                m_geoMapClosePower = 0f;
                m_geoMapOffsetClose = 0f;
                m_geoTilingClose = 0f;
                m_smoothness = 1f;
                m_specular = 1f;
                m_useAO = true;
                m_useAOTexture = false;
            }

            //The load up the rest of the texture information - either from CTS or the terrain
            byte minHeight = 0;
            byte maxHeight = 0;
            for (int tIdx = 0; tIdx < m_textureList.Count; tIdx++)
            {
                TextureData tData = m_textureList[tIdx];
                if (ctsProfile != null && tData.m_terrainIdx < ctsProfile.TerrainTextures.Count)
                {
                    CTSTerrainTextureDetails ctsTextureDetails = ctsProfile.TerrainTextures[tData.m_terrainIdx];
                    tData.m_albedo = ctsTextureDetails.Albedo;
                    tData.m_normal = ctsTextureDetails.Normal;
                    tData.m_hao_in_GA = ctsProfile.BakeHAOTexture(ctsTextureDetails.Albedo.name, ctsTextureDetails.Height, ctsTextureDetails.AmbientOcclusion, out minHeight, out maxHeight);
                    tData.m_aoPower = ctsTextureDetails.m_aoPower;
                    tData.m_color = new Vector4(ctsTextureDetails.m_tint.r * ctsTextureDetails.m_tintBrightness, ctsTextureDetails.m_tint.g * ctsTextureDetails.m_tintBrightness, ctsTextureDetails.m_tint.b * ctsTextureDetails.m_tintBrightness, ctsTextureDetails.m_smoothness);
                    tData.m_geoPower = ctsTextureDetails.m_geologicalPower;
                    tData.m_normalPower = ctsTextureDetails.m_normalStrength;
                    tData.m_tiling = ctsTextureDetails.m_albedoTilingClose;
                    tData.m_heightContrast = ctsTextureDetails.m_heightContrast;
                    tData.m_heightDepth = ctsTextureDetails.m_heightDepth;
                    tData.m_heightBlendClose = ctsTextureDetails.m_heightBlendClose;
                }
                else
                {
                    if (tData.m_terrainIdx < splatPrototypes.Length)
                    {
                        CTSSplatPrototype splatProto = splatPrototypes[tData.m_terrainIdx];
                        tData.m_albedo = splatProto.texture;
                        tData.m_normal = splatProto.normalMap;
                        tData.m_hao_in_GA = null;
                        tData.m_aoPower = 0f;
                        tData.m_color = Vector4.one;
                        tData.m_geoPower = 0f;
                        tData.m_normalPower = 1f;
                        tData.m_tiling = splatProto.tileSize.x;
                        tData.m_heightContrast = 1f;
                        tData.m_heightDepth = 1f;
                        tData.m_heightBlendClose = 1f;
                    }
                }
            }
        }

        /// <summary>
        /// Get the terrain that matches this location, otherwise return null
        /// </summary>
        /// <param name="locationWU">Location to check in world units</param>
        /// <returns>Terrain at this location or null</returns>
        private Terrain GetTerrain(Vector3 locationWU)
        {
            //First check active terrain - most likely already selected
            Terrain terrain = Terrain.activeTerrain;
            if (terrain != null)
            {
                Vector3 terrainMin = terrain.GetPosition();
                Vector3 terrainMax = terrainMin + terrain.terrainData.size;
                if (locationWU.x >= terrainMin.x && locationWU.x <= terrainMax.x)
                {
                    if (locationWU.z >= terrainMin.z && locationWU.z <= terrainMax.z)
                    {
                        return terrain;
                    }
                }
            }

            //Then check rest of terrains
            for (int idx = 0; idx < Terrain.activeTerrains.Length; idx++)
            {
                terrain = Terrain.activeTerrains[idx];
                Vector3 terrainMin = terrain.GetPosition();
                Vector3 terrainMax = terrainMin + terrain.terrainData.size;
                if (locationWU.x >= terrainMin.x && locationWU.x <= terrainMax.x)
                {
                    if (locationWU.z >= terrainMin.z && locationWU.z <= terrainMax.z)
                    {
                        return terrain;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Convert the world position provided to a local position relative to the terrain supplied
        /// </summary>
        /// <param name="terrain">Terrain to check</param>
        /// <param name="locationWU">World poition</param>
        /// <returns>Local position</returns>
        private Vector3 GetLocalPosition(Terrain terrain, Vector3 locationWU)
        {
            Vector3 terrainLocalPos = terrain.transform.InverseTransformPoint(locationWU);
            return new Vector3(Mathf.InverseLerp(0f, terrain.terrainData.size.x, terrainLocalPos.x),
                    Mathf.InverseLerp(0f, terrain.terrainData.size.y, terrainLocalPos.y),
                    Mathf.InverseLerp(0f, terrain.terrainData.size.z, terrainLocalPos.z));
        }

        /// <summary>
        /// Get the texture strengths at the given local position 
        /// </summary>
        /// <param name="terrain">Terrain to check</param>
        /// <param name="locationTU">Location to check in normalized terrain units</param>
        /// <returns>Textures at this location</returns>
        private float[,,] GetTexturesAtLocation(Terrain terrain, Vector3 locationTU)
        {
            return terrain.terrainData.GetAlphamaps(
                (int)(locationTU.x * (float)(terrain.terrainData.alphamapWidth - 1)),
                (int)(locationTU.z * (float)(terrain.terrainData.alphamapHeight - 1)), 1, 1);
        }

        /// <summary>
        /// Get terrain normal at the local position given
        /// </summary>
        /// <param name="terrain">Terrain to check</param>
        /// <param name="locationTU">Locaton in normalized terrain units</param>
        /// <returns>Normal at this location</returns>
        private Vector3 GetNormalsAtLocation(Terrain terrain, Vector3 locationTU)
        {
            return terrain.terrainData.GetInterpolatedNormal(locationTU.x, locationTU.z);
        }

        #endregion
    }
}
