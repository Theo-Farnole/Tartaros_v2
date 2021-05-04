using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace CTS
{
    /// <summary>
    /// Get a CTS shader from a cached shader store
    /// </summary>
    public static class CTSShaders
    {
        private static Dictionary<string, Shader> m_shaderLookup = new Dictionary<string, Shader>();

        static CTSShaders()
        {
            Stopwatch sw = Stopwatch.StartNew();
            #region old string based lookup
            /*
            Shader shader = Shader.Find(CTSConstants.CTSShaderLiteName);
            if (shader != null)
            {
                m_shaderLookup.Add(CTSConstants.CTSShaderLiteName, shader);
            }

            shader = Shader.Find(CTSConstants.CTSShaderBasicName);
            if (shader != null)
            {
                m_shaderLookup.Add(CTSConstants.CTSShaderBasicName, shader);
            }

            shader = Shader.Find(CTSConstants.CTSShaderBasicCutoutName);
            if (shader != null)
            {
                m_shaderLookup.Add(CTSConstants.CTSShaderBasicCutoutName, shader);
            }

            shader = Shader.Find(CTSConstants.CTSShaderAdvancedName);
            if (shader != null)
            {
                m_shaderLookup.Add(CTSConstants.CTSShaderAdvancedName, shader);
            }

            shader = Shader.Find(CTSConstants.CTSShaderAdvancedCutoutName);
            if (shader != null)
            {
                m_shaderLookup.Add(CTSConstants.CTSShaderAdvancedCutoutName, shader);
            }

            shader = Shader.Find(CTSConstants.CTSShaderTesselatedName);
            if (shader != null)
            {
                m_shaderLookup.Add(CTSConstants.CTSShaderTesselatedName, shader);
            }

            shader = Shader.Find(CTSConstants.CTSShaderTesselatedCutoutName);
            if (shader != null)
            {
                m_shaderLookup.Add(CTSConstants.CTSShaderTesselatedCutoutName, shader);
            }
            */
            #endregion

            RebuildShaderDictionary();


            if (sw.ElapsedMilliseconds > 0)
            {
                //Debug.LogFormat("CTS located {0} CTS shaders in {1} ms.", m_shaderLookup.Count, sw.ElapsedMilliseconds);
            }
        }

        public static void RebuildShaderDictionary()
        {
            m_shaderLookup = new Dictionary<string, Shader>();

            foreach (KeyValuePair<CTSShaderCriteria, string> kvp in CTSConstants.shaderNames)
            {
                Shader shader = Shader.Find(kvp.Value);
                if (shader != null)
                {
                    m_shaderLookup.Add(kvp.Value, shader);
                }
            }
        }



        /// <summary>
        /// Get the designated shader.
        /// </summary>
        /// <param name="shaderType">Shader type</param>
        /// <returns>Shader or null if not found</returns>
        public static Shader GetShader(string shaderType)
        {
            Shader shader;
            if (m_shaderLookup.TryGetValue(shaderType, out shader))
            {
                return shader;
            }
            else
            {
                //If we are not finding this shader in the editor, check if a shader installation is required
#if UNITY_EDITOR
                if (CTSSetup.CheckIfShaderInstallRequired())
                {
                    Debug.LogError("CTS could not find a required shader, and it looks like the correct shaders are not installed for this project. Please run 'Windows > Procedural Worlds > CTS > Shader Installation' to install the missing shaders.");
                }
                else
                {
#endif
                    Debug.LogErrorFormat(
                        "Could not load CTS shader : {0}. Make sure you add your CTS shader to pre-loaded assets!",
                        shaderType);
#if UNITY_EDITOR
                }
#endif
                return null;
            }
        }
    }
}