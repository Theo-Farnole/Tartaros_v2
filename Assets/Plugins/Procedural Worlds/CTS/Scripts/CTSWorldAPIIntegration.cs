using UnityEngine;

#if WORLDAPI_PRESENT
using WAPI;
namespace CTS
{
    /// <summary>
    /// Drive CTS from WorldAPI - add a CTS Weather manager in the scene and drop this script onto it
    /// </summary>
    [RequireComponent(typeof(CTSWeatherManager))]
    [ExecuteInEditMode]
    public class CTSWorldAPIIntegration : MonoBehaviour, IWorldApiChangeHandler
    {
        public bool m_updateSnow = true;
        public bool m_updateWetness = true;
        public bool m_updateSeasons = true;
        private CTSWeatherManager m_weatherManager;

        /// <summary>
        /// Set up connection to WAPI to drive CTS
        /// </summary>
        void Start ()
        {
            //CTSTerrainManager.Instance.RegisterAllShaders(true);
            //CTSTerrainManager.Instance.RegisterAllControllers(true);
            m_weatherManager = GetComponent<CTSWeatherManager>();
            ConnectToWorldAPI();
            if (m_updateSnow)
            {
                m_weatherManager.SnowPower = WorldManager.Instance.SnowPowerTerrain;
                m_weatherManager.SnowMinHeight = WorldManager.Instance.SnowMinHeight;
            }
            if (m_updateWetness)
            {
                m_weatherManager.RainPower = WorldManager.Instance.RainPower;
            }
            if (m_updateSeasons)
            {
                m_weatherManager.Season = WorldManager.Instance.Season;
            }
	    }
	
        /// <summary>
        /// Connect to world api and start listening to updates
        /// </summary>
        void ConnectToWorldAPI()
        {
            WorldManager.Instance.AddListener(this);
        }

        /// <summary>
        /// Disconnect from world api
        /// </summary>
        void DisconnectFromWorldAPI()
        {
            WorldManager.Instance.RemoveListener(this);
        }

        /// <summary>
        /// Handle updates from world api
        /// </summary>
        /// <param name="changeArgs">Change arguements</param>
        public void OnWorldChanged(WorldChangeArgs changeArgs)
        {
            if (m_weatherManager == null)
            {
                m_weatherManager = GetComponent<CTSWeatherManager>();
            }
            if (m_updateSnow && changeArgs.HasChanged(WorldConstants.WorldChangeEvents.SnowChanged))
            {
                m_weatherManager.SnowPower = WorldManager.Instance.SnowPowerTerrain;
                m_weatherManager.SnowMinHeight = WorldManager.Instance.SnowMinHeight;
            }
            if (m_updateWetness && changeArgs.HasChanged(WorldConstants.WorldChangeEvents.RainChanged))
            {
                m_weatherManager.RainPower = WorldManager.Instance.RainPowerTerrain;
            }
            if (m_updateSeasons && changeArgs.HasChanged(WorldConstants.WorldChangeEvents.SeasonChanged))
            {
                m_weatherManager.Season = WorldManager.Instance.Season;
            }
        }
    }
}
#endif