#if GAIA_PRESENT && UNITY_EDITOR

using System;
using UnityEngine;
using UnityEditor;
using CTS;
using Object = UnityEngine.Object;

namespace Gaia.GX.ProceduralWorlds
{
    /// <summary>
    /// Simple camera and light FX for Gaia.
    /// </summary>
    public class CTSGaiaIntegratiion : MonoBehaviour
    {
        #region Generic informational methods

        /// <summary>
        /// Returns the publisher name if provided. 
        /// This will override the publisher name in the namespace ie Gaia.GX.PublisherName
        /// </summary>
        /// <returns>Publisher name</returns>
        public static string GetPublisherName()
        {
            return "Procedural Worlds";
        }

        /// <summary>
        /// Returns the package name if provided
        /// This will override the package name in the class name ie public class PackageName.
        /// </summary>
        /// <returns>Package name</returns>
        public static string GetPackageName()
        {
            return "CTS - Complete Terrain Shader";
        }

        #endregion

        #region Methods exposed by Gaia as buttons must be prefixed with GX_

        public static void GX_About()
        {
            EditorUtility.DisplayDialog("About CTS - Complete Terrain Shader", "Welcome to the CTS Gaia Integration. Select the profiles below to set them up in your scene.", "OK");
        }

        /// <summary>
        /// Add profile to terrain
        /// </summary>
        public static void GX_Profiles_AddG1Basic()
        {
            ApplyProfile("CTS_Profile_G1_Basic");
        }

        /// <summary>
        /// Add profile to terrain
        /// </summary>
        public static void GX_Profiles_AddG2Basic()
        {
            ApplyProfile("CTS_Profile_G2_Basic");
        }

        public static void GX_Profiles_AddG3Basic()
        {
            ApplyProfile("CTS_Profile_G3_Basic");
        }

        public static void GX_Profiles_AddG4Basic()
        {
            ApplyProfile("CTS_Profile_G4_Basic");
        }

        public static void GX_Profiles_AddG5Basic()
        {
            ApplyProfile("CTS_Profile_G5_Basic");
        }

        public static void GX_Profiles_AddG6Basic()
        {
            ApplyProfile("CTS_Profile_G6_Basic");
        }

        public static void GX_Profiles_AddG6BasicWarm()
        {
            ApplyProfile("CTS_Profile_G6_Basic Warm");
        }

        public static void GX_Profiles_AddG7BasicGeo()
        {
            ApplyProfile("CTS_Profile_G7_Basic_Geo");
        }

        public static void GX_Profiles_AddG7AdvancedGeo()
        {
            ApplyProfile("CTS_Profile_G7_Adv_Geo");
        }

        public static void GX_Profiles_AddG7TesselationGeo()
        {
            ApplyProfile("CTS_Profile_G7_Tess_Geo");
        }

        #endregion

        #region Helper methods

        /// <summary>
        /// Get the asset if we can find it in the project
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static CTSProfile GetProfileAtPath(string name)
        {
            #if UNITY_EDITOR
            string[] assets = AssetDatabase.FindAssets(name, null);
            for (int idx = 0; idx < assets.Length; idx++)
            {
                string path = AssetDatabase.GUIDToAssetPath(assets[idx]);
                if (path.Contains(name + ".asset"))
                {
                    return AssetDatabase.LoadAssetAtPath<CTSProfile>(path);
                }
            }
            #endif
            return null;
        }

        public static void ApplyProfile(string profileName)
        {
            CTSTerrainManager.Instance.AddCTSToAllTerrains();
            var profile = GetProfileAtPath(profileName);
            if (profile == null)
            {
                EditorUtility.DisplayDialog("CTS", "Unable to load " + profileName + " to assign it.", "OK");
            }
            else
            {
                CTSTerrainManager.Instance.BroadcastProfileSelect(profile);
            }
        }

        #endregion
    }
}

#endif