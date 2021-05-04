using UnityEngine;

namespace CTS
{
    /// <summary>
    /// Runtime terrain helper
    /// ----------------------
    /// 
    /// This helper has a number of methods for applying CTS to your runtime terrain. You will 
    /// need to generate and texture your terrain before applying CTS to it, as CTS will modify the terrain
    /// textures and the terrain material when the profile is applied.
    /// 
    /// For instructions on use with Map Magic please read down a little further.
    /// 
    /// NOTE: For the correct result you will need to make sure that the number of textures in 
    /// your profile matches the number in the generated terrain.
    /// 
    /// GENERIC RUNTIME TERRAIN:
    /// ========================
    /// 
    /// Instantiate this component in your scene after your terrain has been generated and supply a profile
    /// and optionally a terrain. 
    /// 
    /// Make a choice about whether to auto apply the profile in the Awake and Start events, or optionally, 
    /// manually via one of the Apply methods. If applying manually, do this after the terrain has been
    /// created and textured.
    /// 
    /// If a terrain has been supplied then the component will apply to that terrain, otherwise
    /// if the component has been attached to a game object that has a terrain then it will apply on 
    /// the terrain it is attached to, otherwise it will apply to all active terrains in the scene.
    /// 
    /// Additionally, you can manually supply a terrain to one of the apply methods and update any terrain.
    /// 
    /// MAP MAGIC RUNTIME TERRAIN:
    /// ==========================
    /// 
    /// Create an empty game object, add this script and supply a profile. It will intercept Map Magic terrain
    /// generated events and auto apply the profile to all new terrains created in your scene.
    /// 
    /// </summary>
    public class CTSRuntimeTerrainHelper : MonoBehaviour
    {
        /// <summary>
        /// The profile that will be assigned
        /// </summary>
        public CTSProfile m_CTSProfile;

        /// <summary>
        /// If true, will try and auto apply the profile in Awake and on Start, otherwise 
        /// you will need to make the appropriate apply call.
        /// </summary>
        public bool m_autoApplyProfile = true;

        /// <summary>
        /// The terrain we are managing - optional - will pick up from current terrain if possible
        /// </summary>
        public Terrain m_terrain;

        /// <summary>
        /// Assign map magic event
        /// </summary>
        void Awake()
        {
            #if MAPMAGIC
            MapMagic.MapMagic.OnGenerateCompleted += OnGenerateCompleted;
            #endif

            if (m_terrain == null)
            {
                m_terrain = GetComponent<Terrain>();
            }

            if (m_autoApplyProfile)
            {
                if (m_terrain == null)
                {
                    ApplyProfileToActiveTerrains();
                }
                else
                {
                    ApplyProfileToTerrain();
                }
            }
        }

        /// <summary>
        /// Handle start event
        /// </summary>
        void Start()
        {
            if (m_terrain == null)
            {
                m_terrain = GetComponent<Terrain>();
            }

            if (m_autoApplyProfile)
            {
                if (m_terrain == null)
                {
                    ApplyProfileToActiveTerrains();
                }
                else
                {
                    ApplyProfileToTerrain();
                }
            }
        }

        /// <summary>
        /// Handle mapmagic terrain update event
        /// </summary>
        /// <param name="terrain"></param>
        void OnGenerateCompleted(Terrain terrain)
        {
            if (terrain != null)
            {
                m_terrain = terrain;
                ApplyProfileToTerrain();
            }
        }

        /// <summary>
        /// Apply profile to selected terrain
        /// </summary>
        public void ApplyProfileToTerrain()
        {
            if (m_terrain != null)
            {
                CTSTerrainManager.Instance.AddCTSToTerrain(m_terrain);
                CTSTerrainManager.Instance.BroadcastProfileSelect(m_CTSProfile, m_terrain);
            }
        }

        /// <summary>
        /// Apply profile to a specific terrain
        /// </summary>
        public void ApplyProfileToTerrain(Terrain terrain)
        {
            CTSTerrainManager.Instance.AddCTSToTerrain(terrain);
            CTSTerrainManager.Instance.BroadcastProfileSelect(m_CTSProfile, terrain);
        }

        /// <summary>
        /// Apply profile to all active terrains
        /// </summary>
        public void ApplyProfileToActiveTerrains()
        {
            CTSTerrainManager.Instance.AddCTSToAllTerrains();
            CTSTerrainManager.Instance.BroadcastProfileSelect(m_CTSProfile);
        }
    }
}