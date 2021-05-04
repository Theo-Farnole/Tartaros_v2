using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
    /// <summary>
    /// A terrain weather and season controller for CTS. This manager broadcasts weather updates to weather controllers
    /// which then apply them directly to the material, but not the profile. This way you can effect change, without 
    /// wrecking profile settings.
    /// </summary>
    [Serializable]
    public class CTSWeatherManager : MonoBehaviour
    {
        #region External interfaces - Call these to control the weather system from other scripts

        /// <summary>
        /// Snow power - in range 0 .. 1
        /// </summary>
        public float SnowPower
        {
            get { return m_snowPower; }
            set
            {
                if (m_snowPower != value)
                {
                    m_snowPower = Mathf.Clamp01(value);
                    m_somethingChanged = true;
                    if (!Application.isPlaying)
                    {
                        BroadcastUpdates();
                    }
                }
            }
        }

        /// <summary>
        /// Minimum snow height
        /// </summary>
        public float SnowMinHeight
        {
            get { return m_snowMinHeight; }
            set
            {
                if (m_snowMinHeight != value)
                {
                    m_snowMinHeight = value;
                    if (m_snowMinHeight < 0f)
                    {
                        m_snowMinHeight = 0f;
                    }
                    m_somethingChanged = true;
                    if (!Application.isPlaying)
                    {
                        BroadcastUpdates();
                    }
                }
            }
        }

        /// <summary>
        /// Rain power in range 0 No Rain .. 1 - Full Rain
        /// </summary>
        public float RainPower
        {
            get { return m_rainPower; }
            set
            {
                if (m_rainPower != value)
                {
                    m_rainPower = Mathf.Clamp01(value);
                    m_somethingChanged = true;
                    if (!Application.isPlaying)
                    {
                        BroadcastUpdates();
                    }
                }
            }
        }

        /// <summary>
        /// The maximum smoothness value per texture to be set if the rain power changes. Range 0f - 30f.
        /// The actual smoothness is varied between the original texture smoothness and this maximum scaled
        /// by the rain power.
        /// </summary>
        public float MaxRainSmoothness
        {
            get { return m_maxRainSmoothness; }
            set
            {
                if (m_maxRainSmoothness != value)
                {
                    m_maxRainSmoothness = Mathf.Clamp(value, 0f, 30f);
                    m_somethingChanged = true;
                    if (!Application.isPlaying)
                    {
                        BroadcastUpdates();
                    }
                }
            }
        }


        /// <summary>
        /// Just a flag to control if the seasonal tint should be processed & trigger an update
        /// </summary>
        public bool SeasonalTintActive
        {
            get { return m_seasonalTintActive; }
            set
            {
                if (m_seasonalTintActive != value)
                {
                    m_seasonalTintActive = value;
                    m_somethingChanged = true;
                    if (!Application.isPlaying)
                    {
                        BroadcastUpdates();
                    }
                }
            }
        }


        /// <summary>
        /// The season in the range 0 .. 3.9999f 
        /// Controls the way the tints are applied to the landscape
        /// 0 = winter, 1 = spring, 2 = summer, 3 = autumn
        /// </summary>
        public float Season
        {
            get { return m_season; }
            set
            {
                if (m_season != value)
                {
                    m_season = Mathf.Clamp(value, 0f, 3.9999f);
                    if (m_seasonalTintActive)
                    {
                        m_somethingChanged = true;
                        if (!Application.isPlaying)
                        {
                            BroadcastUpdates();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Winter tint
        /// </summary>
        public Color WinterTint
        {
            get { return m_winterTint; }
            set
            {
                if (m_winterTint != value)
                {
                    m_winterTint = value;
                    if (m_seasonalTintActive)
                    {
                        m_somethingChanged = true;
                        if (!Application.isPlaying)
                        {
                            BroadcastUpdates();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Spring tint
        /// </summary>
        public Color SpringTint
        {
            get { return m_springTint; }
            set
            {
                if (m_springTint != value)
                {
                    m_springTint = value;
                    if (m_seasonalTintActive)
                    {
                        m_somethingChanged = true;
                        if (!Application.isPlaying)
                        {
                            BroadcastUpdates();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Summer tint
        /// </summary>
        public Color SummerTint
        {
            get { return m_summerTint; }
            set
            {
                if (m_summerTint != value)
                {
                    m_summerTint = value;
                    if (m_seasonalTintActive)
                    {
                        m_somethingChanged = true;
                        if (!Application.isPlaying)
                        {
                            BroadcastUpdates();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Autumn tint
        /// </summary>
        public Color AutumnTint
        {
            get { return m_autumnTint; }
            set
            {
                if (m_autumnTint != value)
                {
                    m_autumnTint = value;
                    if (m_seasonalTintActive)
                    {
                        m_somethingChanged = true;
                        if (!Application.isPlaying)
                        {
                            BroadcastUpdates();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// List of texture ids to ignore for seasonal tint
        /// </summary>
        [SerializeField]
        public List<int> TextureIDsToIgnore = new List<int>();

        #endregion

        #region Private variables

        //Snow power
        [SerializeField]
        private float m_snowPower = 0f;

        //Snow minimum height
        [SerializeField]
        private float m_snowMinHeight = 0f;

        //Rain power
        [SerializeField]
        private float m_rainPower = 0f;

        //Max rain smoothness
        [SerializeField]
        private float m_maxRainSmoothness = 15f;

        //process seasonal tint changes
        [SerializeField]
        private bool m_seasonalTintActive = true;

        //Season
        [SerializeField]
        private float m_season = 0f;

        /// <summary>
        /// Season tints
        /// </summary>
        [SerializeField]
        private Color m_winterTint = Color.white;
        [SerializeField]
        private Color m_springTint = new Color(188f / 255f, 1f, 150f / 255f);
        [SerializeField]
        private Color m_summerTint = new Color(1f, 185f / 255f, 96f / 255f);
        [SerializeField]
        private Color m_autumnTint = Color.white;

        /// <summary>
        /// Set to true when something changes to signal a material / shader update
        /// </summary>
        private bool m_somethingChanged = true;
        #endregion

        #region Methods

        // Use this for initialization
        void Start()
        {
        }

        /// <summary>
        /// Look for changes at runtime
        /// </summary>
        void LateUpdate()
        {
            BroadcastUpdates();
        }

        /// <summary>
        /// Send updates if something changed
        /// </summary>
        void BroadcastUpdates()
        {
            if (m_somethingChanged)
            {
                //Boadcast an update
                CTSTerrainManager.Instance.BroadcastWeatherUpdate(this);

                //Shut down updates until another change detected
                m_somethingChanged = false;
            }
        }

        #endregion
    }
}
