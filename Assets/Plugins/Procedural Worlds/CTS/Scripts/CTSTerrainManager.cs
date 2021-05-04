using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CTS
{
    /// <summary>
    /// Manages communication between weather, terrain profiles and terrain instances. General 
    /// CTS configuration and control should be performed via this class. Local weather control
    /// should be controlled via Weather Manager class.
    /// </summary>
    public class CTSTerrainManager : CTSSingleton<CTSTerrainManager>
    {
        /// <summary>
        /// The shaders in the scene
        /// </summary>
        private HashSet<CompleteTerrainShader> m_shaderSet = new HashSet<CompleteTerrainShader>();

        /// <summary>
        /// The controllers in the scene
        /// </summary>
        private HashSet<CTSWeatherController> m_controllerSet = new HashSet<CTSWeatherController>();

        /// <summary>
        /// Make sure its only ever a singleton by stopping direct instantiation
        /// </summary>
        protected CTSTerrainManager()
        {
        }

        /// <summary>
        /// Register a specific shader
        /// </summary>
        /// <param name="shader">Shader to register</param>
        public void RegisterShader(CompleteTerrainShader shader)
        {
            //Debug.Log("Registering CTS Terrain: " + shader.name);
            m_shaderSet.Add(shader);
        }

		/// <summary>
		/// Remove a specific shader
		/// </summary>
		/// <param name="shader">Shader to unregister</param>
		public void UnregisterShader(CompleteTerrainShader shader)
		{
		    //Debug.Log("UnRegistering CTS Terrain: " + shader.name);
			m_shaderSet.Remove(shader);
		}

		/// <summary>
		/// Register a weather controller
		/// </summary>
		/// <param name="weatherController">Weather controller to register</param>
		public void RegisterWeatherController(CTSWeatherController weatherController)
		{
		    //Debug.Log("Registering WC + " + weatherController.name);
		    m_controllerSet.Add(weatherController);
        }

		/// <summary>
		/// Remove a specific weather controller
		/// </summary>
		/// <param name="weatherController">Weather controller to unregister</param>
		public void UnregisterWeatherController(CTSWeatherController weatherController)
		{
		    //Debug.Log("UnRegistering WC + " + weatherController.name);
			m_controllerSet.Remove(weatherController);
		}

        /// <summary>
        /// Add CTS to all terrains
        /// </summary>
        public void AddCTSToAllTerrains()
        {
            foreach (var terrain in Terrain.activeTerrains)
            {
                CompleteTerrainShader shader = terrain.gameObject.GetComponent<CompleteTerrainShader>();
                if (shader == null)
                {
                    terrain.gameObject.AddComponent<CompleteTerrainShader>();
                    CompleteTerrainShader.SetDirty(terrain, false, false);
                }
            }
            #if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                if (Terrain.activeTerrain != null)
                {
                    EditorGUIUtility.PingObject(Terrain.activeTerrain);
                }
            }
            #endif
        }

        /// <summary>
        /// Add CTS to a specific terrain
        /// </summary>
        /// <param name="terrain">Terrain to be added to</param>
        public void AddCTSToTerrain(Terrain terrain)
        {
            if (terrain == null)
            {
                return;
            }
            CompleteTerrainShader shader = terrain.gameObject.GetComponent<CompleteTerrainShader>();
            if (shader == null)
            {
                terrain.gameObject.AddComponent<CompleteTerrainShader>();
                CompleteTerrainShader.SetDirty(terrain, false, false);
            }
            #if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                if (Terrain.activeTerrain != null)
                {
                    EditorGUIUtility.PingObject(Terrain.activeTerrain);
                }
            }
            #endif
        }

        /// <summary>
        /// Return true if the profile is actively assigned to a terrain
        /// </summary>
        /// <param name="profile">The profile being checked</param>
        /// <returns>True if its been assiged to a terrain</returns>
        public bool ProfileIsActive(CTSProfile profile)
        {
            //Return fail if no profile
            if (profile == null)
            {
                return false;
            }

            //Check for first profile hit
            foreach (CompleteTerrainShader shader in m_shaderSet)
            {
                if (shader.Profile != null && shader.Profile.GetInstanceID() == profile.GetInstanceID())
                {
                    return true;
                }
            }

            //Got nothing
            return false;
        }

        /// <summary>
        /// Broadcast a message to select this profile on all the CTS terrains in the scene
        /// </summary>
        /// <param name="profile">Profile being selected</param>
        public void BroadcastProfileSelect(CTSProfile profile)
        {
            if (profile == null)
            {
                return;
            }
            profile.terrainLayerAssetRebuild = true;

            //Broadcast the select
            foreach (CompleteTerrainShader shader in m_shaderSet)
			{
			    shader.Profile = profile;
            }

            profile.m_currentRenderPipelineType = CompleteTerrainShader.GetRenderPipeline();
        }

        /// <summary>
        /// Broadcast a message to select this profile on the terrain provided - add cts if its not there
        /// </summary>
        /// <param name="profile">Profile being selected</param>
        /// <param name="terrain">Terrain being selected</param>
        public void BroadcastProfileSelect(CTSProfile profile, Terrain terrain)
        {
            if (profile == null || terrain == null)
            {
                return;
            }
            profile.terrainLayerAssetRebuild = true;

            CompleteTerrainShader shader = terrain.gameObject.GetComponent<CompleteTerrainShader>();
            if (shader == null)
            {
                shader = terrain.gameObject.AddComponent<CompleteTerrainShader>();
            }
            shader.IsProfileConnected = true;
            shader.Profile = profile;
        }

        /// <summary>
        /// Broadcast a profile update to all the shaders using it in the scene
        /// </summary>
        /// <param name="profile">Profile being updated</param>
        public void BroadcastProfileUpdate(CTSProfile profile)
        {
            //Can not do this on a null profile
            if (profile == null)
            {
                Debug.LogWarning("Cannot update shader on null profile.");
                return;
            }

            profile.terrainLayerAssetRebuild = true;

            //Broadcast the update
            foreach (CompleteTerrainShader shader in m_shaderSet)
			{
                if (shader.Profile != null)
                {
                    if (shader.Profile.name == profile.name)
                    {
                        shader.UpdateShader();
                    }
                }
            }
            profile.m_currentRenderPipelineType = CompleteTerrainShader.GetRenderPipeline();
        }

        /// <summary>
        /// Broadcast a shader setup on the selected profile in the scene, otherwise all
        /// </summary>
        /// <param name="profile">Profile being updated, otherwise all</param>
        public void BroadcastShaderSetup(CTSProfile profile)
        {
            profile.terrainLayerAssetRebuild = true;

            //First - check to see if we have one on the currently selected terrain - this will usually be where texture changes have been made
            if (Terrain.activeTerrain != null)
            {
				CompleteTerrainShader shader = Terrain.activeTerrain.GetComponent<CompleteTerrainShader>();
                if (shader != null && shader.Profile != null)
                {
                    if (shader.Profile.name == profile.name)
                    {
                        shader.UpdateProfileFromTerrainForced();
                        BroadcastProfileUpdate(profile);
                        return;
                    }
                }
            }

			//Otherwise broadcast the setup
			foreach (CompleteTerrainShader shader in m_shaderSet)
			{
                if (shader.Profile != null)
                {
                    if (profile == null)
                    {
                        shader.UpdateProfileFromTerrainForced();
                    }
                    else
                    {
                        //Find the first match and update it
                        if (shader.Profile.name == profile.name)
                        {
                            shader.UpdateProfileFromTerrainForced();
                            BroadcastProfileUpdate(profile);
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Broadcast bake terrains
        /// </summary>
        public void BroadcastBakeTerrains()
        {
			//Broadcast the setup
			foreach (CompleteTerrainShader shader in m_shaderSet)
            {
                if (shader.AutoBakeNormalMap)
                {
                    shader.BakeTerrainNormals();
                }
                if (shader.AutoBakeColorMap)
                {
                    if (!shader.AutoBakeGrassIntoColorMap)
                    {
                        shader.BakeTerrainBaseMap();
                    }
                    else
                    {
                        shader.BakeTerrainBaseMapWithGrass();
                    }
                }
            }
        }

        /// <summary>
        /// Broadcast an albedo texture switch
        /// </summary>
        /// <param name="profile">Selected profile - null means all CTS terrains</param>
        /// <param name="texture">New texture</param>
        /// <param name="textureIdx">Index</param>
        /// <param name="tiling">Tiling</param>
        /// <returns></returns>
        public void BroadcastAlbedoTextureSwitch(CTSProfile profile, Texture2D texture, int textureIdx, float tiling)
        {
            profile.terrainLayerAssetRebuild = true;

            //Do the texture switch
            foreach (CompleteTerrainShader shader in m_shaderSet)
            {
                if (shader.Profile != null)
                {
                    if (profile == null)
                    {
                        shader.ReplaceAlbedoInTerrain(texture, textureIdx, tiling);
                    }
                    else
                    {
                        if (shader.Profile.name == profile.name)
                        {
                            shader.ReplaceAlbedoInTerrain(texture, textureIdx, tiling);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Broadcast a normal texture switch
        /// </summary>
        /// <param name="profile">Selected profile - null means all CTS terrains</param>
        /// <param name="texture">New texture</param>
        /// <param name="textureIdx">Index</param>
        /// <param name="tiling">Tiling</param>
        public void BroadcastNormalTextureSwitch(CTSProfile profile, Texture2D texture, int textureIdx, float tiling)
        {
            profile.terrainLayerAssetRebuild = true;

            //Do the texture switch
            foreach (CompleteTerrainShader shader in m_shaderSet)
            {
                if (shader.Profile != null)
                {
                    if (profile == null)
                    {
                        shader.ReplaceNormalInTerrain(texture, textureIdx, tiling);
                    }
                    else
                    {
                        if (shader.Profile.name == profile.name)
                        {
                            shader.ReplaceNormalInTerrain(texture, textureIdx, tiling);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Broadcast a weather update
        /// </summary>
        /// <param name="manager">The manager with the update</param>
        public void BroadcastWeatherUpdate(CTSWeatherManager manager)
        {
            //And then broadcast to it
			foreach (CTSWeatherController ctsWeatherController in m_controllerSet)
			{
				ctsWeatherController.ProcessWeatherUpdate(manager);
			}
        }

        /// <summary>
        /// This will remove world seams from loaded terrains - should only be called once for entire terrrain set
        /// </summary>
        public void RemoveWorldSeams()
        {
            //Broadcast the seam
            if (m_shaderSet.Count > 0)
            {
                foreach (var shader in m_shaderSet)
                {
                    shader.RemoveWorldSeams();
                    return;
                }
            }
        }
    }
}