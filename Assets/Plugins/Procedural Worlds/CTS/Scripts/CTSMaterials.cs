using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace CTS
{
    /// <summary>
    /// Get a CTS material from a cached material store
    /// </summary>
    public static class CTSMaterials
    {
        private static Dictionary<string, Material> m_materialLookup = new Dictionary<string, Material>();

        /// <summary>
        /// Get the designated material - create one if it does not exist.
        /// </summary>
        /// <param name="shaderType">Shader type</param>
        /// <param name="profileName">Profile name </param>
        /// <returns>Material or null if not able to create the shader</returns>
        public static Material GetMaterial(string shaderType, CTSProfile profile)
        {
            Material material;
            if (profile.m_useMaterialControlBlock)
            {
                if (m_materialLookup.TryGetValue(shaderType + ":" + profile.name, out material))
                {
                    return material;
                }
            }

            Shader shader = CTSShaders.GetShader(shaderType);
            if (shader == null)
            {
                Debug.LogErrorFormat("Could not create CTS material for shader : {0}. Make sure you add your CTS shader is pre-loaded!", shaderType);
                return null;
            }

            Stopwatch sw = Stopwatch.StartNew();
            material = new Material(shader);
            material.name = shaderType + ":" + profile.name;
            if (profile.m_useMaterialControlBlock)
            {
                material.hideFlags = HideFlags.DontSave;                // never serialize the material.  We want them to always be shared across objects.
                m_materialLookup.Add(material.name, material);         // this profile has a unique material, but the material is SHARED across all instances of terrain with this profile.
            }
            if (sw.ElapsedMilliseconds > 5)
            {
                //Debug.LogFormat("CTS created material {0} in {1} ms", material.name, sw.ElapsedMilliseconds);
            }
            return material;
        }
    }
}