using UnityEngine;

namespace CTS
{
    /// <summary>
    /// Per terrain weather controller for CTS. This applies weather updates into the terrain. To control weather 
    /// globally use the Weather Manager class instead.
    /// </summary>
    public class CTSWeatherController : MonoBehaviour
    {
        /// <summary>
        /// The terrain we are managing
        /// </summary>
        private Terrain m_terrain;

		/// <summary>
		/// Automatically register this script when it's active
		/// </summary>
		void OnEnable()
		{
			CTSTerrainManager.Instance.RegisterWeatherController(this);  // it should always be ok for a component coming online to have an instance of CTSTerrainManager around
		}

		/// <summary>
		/// Automatically unregister when it stops being active
		/// </summary>
		void OnDisable()
		{
			CTSTerrainManager.Instance.UnregisterWeatherController(this);
		}

        /// <summary>
        /// Process a weather update
        /// </summary>
        /// <param name="manager">The manager providing the update</param>
        public void ProcessWeatherUpdate(CTSWeatherManager manager)
        {
            //Make sure we have a terrain
            if (m_terrain == null)
            {
                m_terrain = GetComponent<Terrain>();
                if (m_terrain == null)
                {
                    Debug.Log("CTS Weather Controller must be connected to a terrain to work.");
                    return;
                }
            }

            //Make sure we have a custom controller
            //Material type is not available in 2019.2 or newer anymore
#if !UNITY_2019_2_OR_NEWER
            if (m_terrain.materialType != Terrain.MaterialType.Custom)
            {
                Debug.Log("CTS Weather Controller needs a CTS Material to work with.");
                return;
            }
#endif

            //Do the update
            Material material = m_terrain.materialTemplate;
            if (material == null)
            {
                Debug.Log("CTS Weather Controller needs a Custom Material to work with.");
                return;
            }

            material.SetFloat(CTSShaderID.Snow_Amount, manager.SnowPower*2f);
            material.SetFloat(CTSShaderID.Snow_Min_Height, manager.SnowMinHeight);

            float shinyness = manager.RainPower*manager.MaxRainSmoothness;
            material.SetFloat(CTSShaderID.Terrain_Smoothness, shinyness);
            //material.SetFloat(CTSShaderID.Snow_Smoothness, shinyness);

            if (manager.SeasonalTintActive)
            {
                Color tint = Color.white;
                if (manager.Season < 1f)
                {
                    tint = Color.Lerp(manager.WinterTint, manager.SpringTint, manager.Season);
                }
                else if (manager.Season < 2f)
                {
                    tint = Color.Lerp(manager.SpringTint, manager.SummerTint, manager.Season - 1f);
                }
                else if (manager.Season < 3f)
                {
                    tint = Color.Lerp(manager.SummerTint, manager.AutumnTint, manager.Season - 2f);
                }
                else
                {
                    tint = Color.Lerp(manager.AutumnTint, manager.WinterTint, manager.Season - 3f);
                }
                for (int idx = 0; idx < 16; idx++)
                {
                    if (!manager.TextureIDsToIgnore.Contains(idx))
                    {
                        float textureShinyness = material.GetVector(CTSShaderID.Texture_X_Color[idx]).w;
                        material.SetVector(CTSShaderID.Texture_X_Color[idx], new Vector4(tint.r, tint.g, tint.b, textureShinyness));
                    }
                }
            }
        }
    }
}