
using System;
using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CTS
{
    /// <summary>
    /// Wrapper to allow unified access to splat prototype data across different unity terrain APIs (pre and post 2018.3)
    /// </summary>
    public struct CTSSplatPrototype
    {
        public float metallic;
        public Texture2D normalMap;
        public float smoothness;
        public Texture2D texture;
        public Vector2 tileOffset;
        public Vector2 tileSize;

#if UNITY_2018_3_OR_NEWER

        public CTSSplatPrototype(TerrainLayer terrainLayer)
        {
            //Initialize empty
            metallic = 0f;
            normalMap = null;
            smoothness = 0f;
            texture = null;
            tileOffset = Vector2.zero;
            tileSize = Vector2.zero;

            if (terrainLayer != null)
            {
                metallic = terrainLayer.metallic;
                normalMap = terrainLayer.normalMapTexture;
                smoothness = terrainLayer.smoothness;
                texture = terrainLayer.diffuseTexture;
                tileOffset = terrainLayer.tileOffset;
                tileSize = terrainLayer.tileSize;
            }
        }

        /// <summary>
        /// Returns the contained data as a TerrainLayer object.
        /// </summary>
        /// <returns>A TerrainLayer object.</returns>
        public TerrainLayer Convert()
        {
            return new TerrainLayer {
                                        metallic = metallic,
                                        normalMapTexture = normalMap,
                                        smoothness = smoothness,
                                        diffuseTexture = texture,
                                        tileOffset = tileOffset,
                                        tileSize = tileSize
                                    };
        }

#else

        public CTSSplatPrototype(SplatPrototype splatPrototype)
        {
            //Initialize empty
            metallic = 0f;
            normalMap = null;
            smoothness = 0f;
            texture = null;
            tileOffset = Vector2.zero;
            tileSize = Vector2.zero;

            if (splatPrototype != null)
            {
                metallic = splatPrototype.metallic;
                normalMap = splatPrototype.normalMap;
                smoothness = splatPrototype.smoothness;
                texture = splatPrototype.texture;
                tileOffset = splatPrototype.tileOffset;
                tileSize = splatPrototype.tileSize;
            }
        }

        /// <summary>
        /// Returns the contained data as a SplatPrototype object.
        /// </summary>
        /// <returns>A SplatPrototype object.</returns>
        public SplatPrototype Convert()
        {
            return new SplatPrototype {
                                        metallic = metallic,
                                        normalMap = normalMap,
                                        smoothness = smoothness,
                                        texture = texture,
                                        tileOffset = tileOffset,
                                        tileSize = tileSize
                                    };
        }

#endif

        /// <summary>
        /// Gets all splat prototypes from a terrain. Uses the correct terrain API for pre and post Unity 2018.3.
        /// </summary>
        /// <param name="terrain">The terrain containing the splat prototype data.</param>
        /// <returns>Null if invalid terrain data. An empty CTSSplatPrototype array if no splat prototypes in terrain data. A filled CTSSplatPrototype array if splat prototypes present.</returns>
        public static CTSSplatPrototype[] GetCTSSplatPrototypes(Terrain terrain)
        {
            if (terrain == null || terrain.terrainData == null)
            {
                return null;
            }
            TerrainData terrainData = terrain.terrainData;

#if UNITY_2018_3_OR_NEWER

            if (terrainData.terrainLayers == null || terrainData.terrainLayers.Length == 0)
            {
                return new CTSSplatPrototype[0];
            }

            CTSSplatPrototype[] splatPrototypes = new CTSSplatPrototype[terrainData.terrainLayers.Length];

            for (int i = 0; i < terrainData.terrainLayers.Length; i++)
            {
                splatPrototypes[i] = new CTSSplatPrototype(terrainData.terrainLayers[i]);
            }
            return splatPrototypes;
#else
            if (terrainData.splatPrototypes == null ||terrainData.splatPrototypes.Length == 0)
            {
                return new CTSSplatPrototype[0];
            }

            CTSSplatPrototype[] splatPrototypes = new CTSSplatPrototype[terrainData.splatPrototypes.Length];

            for (int i = 0; i < terrainData.splatPrototypes.Length; i++)
            {
                splatPrototypes[i] = new CTSSplatPrototype(terrainData.splatPrototypes[i]);
            }
            return splatPrototypes;
#endif

        }

        /// <summary>
        /// Returns the number of texture prototypes contained in the terrain data. Uses the correct terrain API for pre and post Unity 2018.3. 
        /// </summary>
        /// <param name="data">The terrain data object to count the textures in.</param>
        /// <returns></returns>
        public static int GetNumberOfTerrainTextures(TerrainData data)
        {
#if UNITY_2018_3_OR_NEWER
            return data.terrainLayers.Length;
#else
            return data.splatPrototypes.Length;
#endif
        }

        /// <summary>
        /// Applies an array of CTS Splat prototypes to a terrain. Uses the correct terrain API for pre and post Unity 2018.3.
        /// </summary>
        /// <param name="terrain">The terrain to assign the splat prototypes to.</param>
        /// <param name="splats">Array of CTSSplatPrototypes to assign to the terrain.</param>
        /// <param name="profileName">The current CTS profile. Used for terrain layer asset filenames.</param>
        public static void SetCTSSplatPrototypes(Terrain terrain, CTSSplatPrototype[] splats, ref CTSProfile profile)
        {
            if (terrain != null && splats != null)
            {
#if UNITY_2018_3_OR_NEWER

                TerrainLayer[] updatedTerrainLayers = new TerrainLayer[splats.Length];

                if (profile.terrainLayerAssetRebuild)
                {
                    bool fileCreationRequired = false;

                    



                    //check if it is actually required to re-write the .asset files for the layers
                    //this is only necessary if there is currently more or less cached layer files for this terrain
                    //or if one of the cached Layers is null for some reason (e.g. user deleted the file)
                    //if we got the same amount of layer files we can simply re-use them with the appropiate textures
                    if (profile.cachedTerrainLayers != null)
                    {
#if UNITY_EDITOR
                        //check if the target directory has been moved, if yes we want to rebuild the files there
                        //This is only done in Editor mode since it is not relevant during runtime & we can't access AssetDatabase in a build
                        if (profile.cachedTerrainLayers.Length > 0 && profile.m_terrainLayerPath!=null && profile.m_terrainLayerPath != "")
                        {
                            if (profile.m_terrainLayerPath.StartsWith("Assets/"))
                            {

                                if (!profile.m_terrainLayerPath.EndsWith("/"))
                                {
                                    profile.m_terrainLayerPath += "/";
                                }

                                //The path we get from the asset database contains the file name, 
                                //so we remove the file name to compare against the path entered in the profile.
                                string currentFullPath = AssetDatabase.GetAssetPath(profile.cachedTerrainLayers[0]);
                                if (currentFullPath != null && currentFullPath != "")
                                {
                                    string currentFileName = Path.GetFileName(currentFullPath);
                                    string currentPath = currentFullPath.Replace(currentFileName, "");

                                    if (currentPath != profile.m_terrainLayerPath)
                                    {
                                        fileCreationRequired = true;
                                    }
                                }
                                else
                                {
                                    //no path to the current asset files? looks like we need to create them anyways
                                    fileCreationRequired = true;
                                }
                            }
                        }
#endif

                        for (int i = 0; i < profile.cachedTerrainLayers.Length; i++)
                        {
                            if (profile.cachedTerrainLayers[i] == null)
                            {
                                fileCreationRequired = true;
                            }
                        }

                        if (splats.Length != profile.cachedTerrainLayers.Length)
                        {
                            fileCreationRequired = true;
                        }
                    }
                    else
                    {
                        fileCreationRequired = true;
                    }

                    if (fileCreationRequired)
                    {
                        for (int i = 0; i < splats.Length; i++)
                        {
                            updatedTerrainLayers[i] = splats[i].Convert();
                        }

                        //completely remove all old splat prototypes first to prevent build-up of abandoned files
                        RemoveTerrainLayerAssetFiles(profile);

                        //Permanently save the new layers as asset files & get a reference, else they will not work properly in the terrain
                        for (int i = 0; i < updatedTerrainLayers.Length; i++)
                        {
                            updatedTerrainLayers[i] = SaveTerrainLayerAsAsset(profile, i.ToString(), updatedTerrainLayers[i]);
                        }
                    }
                    else
                    {
                        // no need to re-write the .asset files, just update the info in the cached files and assign those to the terrain 
                        for (int i = 0; i < splats.Length; i++)
                        {
                            profile.cachedTerrainLayers[i].metallic = splats[i].metallic;
                            profile.cachedTerrainLayers[i].normalMapTexture = splats[i].normalMap;
                            profile.cachedTerrainLayers[i].smoothness = splats[i].smoothness;
                            profile.cachedTerrainLayers[i].diffuseTexture = splats[i].texture;
                            profile.cachedTerrainLayers[i].tileOffset = splats[i].tileOffset;
                            profile.cachedTerrainLayers[i].tileSize = splats[i].tileSize;

                            updatedTerrainLayers[i] = profile.cachedTerrainLayers[i];
                        }

                    }

                    profile.cachedTerrainLayers = updatedTerrainLayers;
                    CompleteTerrainShader.SetDirty(profile, false, true);

                    //Only perform the rebuild once per update. If an update is called for multiple shader instances,
                    //the lookup in the else branch below will be used instead to just assign the cached layers.
                    profile.terrainLayerAssetRebuild = false;
                }
                else
                {
                    updatedTerrainLayers = profile.cachedTerrainLayers;
                }

                terrain.terrainData.terrainLayers = updatedTerrainLayers;
                
#else

                SplatPrototype[] splatPrototypes = new SplatPrototype[splats.Length];

                for (int i = 0; i < splats.Length; i++)
                {
                    splatPrototypes[i] = splats[i].Convert();
                }
                terrain.terrainData.splatPrototypes = splatPrototypes;

#endif
            }
        }
#if UNITY_2018_3_OR_NEWER
        /// <summary>
        /// Looks up terrain layer asset files matching a CTS profile name, and returns them as an array.
        /// </summary>
        /// <param name="profileName">The CTS profile name to look up terrain layer asset files for.</param>
        /// <returns></returns>
        private static TerrainLayer[] LookupTerrainLayerAssetFiles(string profileName)
        {
#if UNITY_EDITOR

            string ctsDirectory = CompleteTerrainShader.GetCTSDirectory();
            string terrainLayerDirectory = ctsDirectory + "Profiles/TerrainLayers";
            DirectoryInfo info = new DirectoryInfo(terrainLayerDirectory);
            FileInfo[] fileInfo = info.GetFiles(profileName + "*.asset");

            TerrainLayer[] returnArray = new TerrainLayer[fileInfo.Length];

            for (int i = 0; i < fileInfo.Length; i++)
            {
                returnArray[i] = (TerrainLayer)AssetDatabase.LoadAssetAtPath("Assets" + fileInfo[i].FullName.Substring(Application.dataPath.Length), typeof(TerrainLayer));
            }
            return returnArray;
#else
            Debug.LogError("Runtime CTS profile generation is not supported");
            return new TerrainLayer[0];
#endif
        }

        /// <summary>
        /// Compares two textures by looking at the Color values pixel by pixel.
        /// </summary>
        /// <param name="first">First texture to compare</param>
        /// <param name="second">Second texture to compare</param>
        /// <returns>True if the both textures contain the same pixels.</returns>
        private static bool CompareTexture(Texture2D first, Texture2D second)
        {
            Color[] firstPix = first.GetPixels();
            Color[] secondPix = second.GetPixels();
            if (firstPix.Length != secondPix.Length)
            {
                return false;
            }
            for (int i = 0; i < firstPix.Length; i++)
            {
                if (firstPix[i] != secondPix[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Saves a unity terrain layer as asset file and returns a reference to the newly created Terrain Layerfile.
        /// </summary>
        /// <param name="profileName">The name of the current profile (for the filename).</param>
        /// <param name="layerId">The layer ID of the layer that is to be saved (for the filename).</param>
        /// <param name="terrainLayer">The terrain layer object to save.</param>
        /// <returns>Reference to the created TerrainLayer</returns>
        private static TerrainLayer SaveTerrainLayerAsAsset(CTSProfile profile, string layerId, TerrainLayer terrainLayer)
        {
#if UNITY_EDITOR
            string ctsDirectory = CompleteTerrainShader.GetCTSDirectory();
            

            //The combination of profile name and layer id should be unique enough so that users don't overwrite layers between profiles.
            

            //Default path
            string terrainLayerDirectory = ctsDirectory + "Profiles/TerrainLayers";
            if (profile.m_terrainLayerPath != null && profile.m_terrainLayerPath != "")
            {
                if (profile.m_terrainLayerPath.StartsWith("Assets/"))
                {
                    terrainLayerDirectory = profile.m_terrainLayerPath;
                }
            }

            if (!terrainLayerDirectory.EndsWith("/"))
            {
                terrainLayerDirectory += "/";
            }

            Directory.CreateDirectory(terrainLayerDirectory);

            string terrainLayerName = profile.name + "_" + layerId + ".asset";

            string path = terrainLayerDirectory + terrainLayerName;

            AssetDatabase.CreateAsset(terrainLayer, path);
            AssetDatabase.SaveAssets();

            return AssetDatabase.LoadAssetAtPath<TerrainLayer>(path);

#else
            Debug.LogError("Runtime CTS profile generation is not supported");
            return new TerrainLayer();
#endif
        }

        /// <summary>
        /// Removes all Terrain Layer Asset Files for a given profile
        /// </summary>
        /// <param name="profileName"></param>
        private static void RemoveTerrainLayerAssetFiles(CTSProfile profile)
        {

#if UNITY_EDITOR
            string ctsDirectory = CompleteTerrainShader.GetCTSDirectory();

            //Default directory
            string terrainLayerDirectory = ctsDirectory + "Profiles/TerrainLayers";

            if (profile.m_terrainLayerPath != null && profile.m_terrainLayerPath != "")
            {
                if (profile.m_terrainLayerPath.StartsWith("Assets/"))
                {
                    terrainLayerDirectory = profile.m_terrainLayerPath;
                }
            }

            if (!terrainLayerDirectory.EndsWith("/"))
            {
                terrainLayerDirectory += "/";
            }


            DirectoryInfo info = new DirectoryInfo(terrainLayerDirectory);
            //only read in files if the directory exists.
            //The save function will create the directory in case it is missing.
            if (info.Exists)
            {
                FileInfo[] fileInfo = info.GetFiles(profile.name + "*.asset");

                for (int i = 0; i < fileInfo.Length; i++)
                {
                    File.Delete(fileInfo[i].FullName);
                }
            }
#else
            Debug.LogError("Runtime CTS profile generation is not supported");
#endif

        }
#endif

    }

}
