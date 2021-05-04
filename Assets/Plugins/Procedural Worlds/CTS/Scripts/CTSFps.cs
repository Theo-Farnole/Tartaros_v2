using System;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
    /// <summary>
    /// Handy FPS and device capabilities class.
    /// </summary>
    public class CTSFps : MonoBehaviour
    {
        /// <summary>
        /// External access to fps
        /// </summary>
        public int FPS
        {
            get { return (int)m_currentFps; }
        }

        //FPS Related settings
        #region FPS Variables
        const string cFormat = "FPS {0}, MS {1:0.00}";
        const float cMeasurePeriod = 1f;
        private float m_currentFps;
        private float m_currentMs;
        private float m_fpsAccumulator = 0;
        private float m_fpsNextPeriod = 0;
        #endregion

        //Some useful system metrics
        #region System Metrics Variables
        public string m_CTSVersion;
        public string m_OS;
        public string m_deviceName;
        public string m_deviceType;
        public string m_deviceModel;
        public string m_platform;
        public string m_processor;
        public string m_ram;
        public string m_gpu;
        public string m_gpuDevice;
        public string m_gpuVendor;
        public string m_gpuSpec;
        public string m_gpuRam;
        public string m_gpuCapabilities;
        public string m_screenInfo;
        public string m_quality;
        #endregion

        #region System Metrics UX
        public Text m_fpsText;
        public Text m_CTSVersionText;
        public Text m_OSText;
        public Text m_deviceText;
        public Text m_systemText;
        public Text m_gpuText;
        public Text m_gpuCapabilitiesText;
        public Text m_screenInfoText;
        #endregion

        private void Start()
        {
            m_fpsNextPeriod = Time.realtimeSinceStartup + cMeasurePeriod;

            //Grab information about the system
            try
            {
                m_CTSVersion = "CTS v" + CTSConstants.MajorVersion + "." + CTSConstants.MinorVersion + "." + CTSConstants.PatchVersion + ", Unity v" + Application.unityVersion;
                m_deviceName = SystemInfo.deviceName;
                m_deviceType = SystemInfo.deviceType.ToString();
                m_OS = SystemInfo.operatingSystem;
                m_platform = Application.platform.ToString();
                m_processor = SystemInfo.processorType + " - " + SystemInfo.processorCount + " cores";
                m_gpu = SystemInfo.graphicsDeviceName;
                m_gpuDevice = SystemInfo.graphicsDeviceType + " - " + SystemInfo.graphicsDeviceVersion;
                m_gpuVendor = SystemInfo.graphicsDeviceVendor;
                m_gpuRam = SystemInfo.graphicsMemorySize.ToString();
                m_gpuCapabilities += "TA: " + SystemInfo.supports2DArrayTextures.ToString();
                m_gpuCapabilities += ", MT: " + SystemInfo.maxTextureSize.ToString();
                m_gpuCapabilities += ", NPOT: " + SystemInfo.npotSupport.ToString();
                m_gpuCapabilities += ", RTC: " + SystemInfo.supportedRenderTargetCount.ToString();
                m_gpuCapabilities += ", CT: " + SystemInfo.copyTextureSupport.ToString();

                int sm = SystemInfo.graphicsShaderLevel;
                if (sm >= 10 && sm <= 99)
                {
                    // getting first and second digits from sm
                    m_gpuSpec = "SM: " + (sm /= 10) + '.' + (sm/10);
                }
                else
                {
                    m_gpuSpec = "SM: N/A";
                }

                int vram = SystemInfo.graphicsMemorySize;
                if (vram > 0)
                {
                    m_gpuSpec += ", VRAM: " + vram + " MB";
                }
                else
                {
                    m_gpuSpec += ", VRAM: " + vram + " N/A";
                }

                int ram = SystemInfo.systemMemorySize;
                if (ram > 0)
                {
                    m_ram = ram.ToString();
                }
                else
                {
                    m_ram = "N/A";
                }

                Resolution res = Screen.currentResolution;
                m_screenInfo = res.width + "x" + res.height + " @" + res.refreshRate + " Hz [window size: " +
                               Screen.width + "x" + Screen.height;
                float dpi = Screen.dpi;
                if (dpi > 0)
                {
                    m_screenInfo += ", DPI: " + dpi + "]";
                }
                else
                {
                    m_screenInfo += "]";
                }

                m_deviceModel = SystemInfo.deviceModel;
                m_quality = QualitySettings.GetQualityLevel().ToString();
            }
            catch (Exception ex)
            {
                Debug.Log("Problem getting system metrics : " + ex.Message);
            }

            //Update UX if it is there
            if (m_CTSVersionText != null)
            {
                m_CTSVersionText.text = m_CTSVersion;
            }

            if (m_OSText != null)
            {
                m_OSText.text = m_OS;
            }

            if (m_deviceText != null)
            {
                m_deviceText.text = m_deviceName + ", " + m_platform + ", " + m_deviceType;
            }

            if (m_systemText != null)
            {
                m_systemText.text = m_deviceModel + ", " + m_processor + ", " + m_ram + " GB";
            }

            if (m_gpuText != null)
            {
                m_gpuText.text = m_gpu + ", " + m_gpuSpec + ", QUAL: " + m_quality;
            }

            if (m_gpuCapabilitiesText != null)
            {
                m_gpuCapabilitiesText.text = m_gpuDevice + ", " + m_gpuCapabilities;
            }

            if (m_screenInfoText != null)
            {
                m_screenInfoText.text = m_screenInfo;
            }
        }

        private void Update()
        {
            // measure average frames per second
            m_fpsAccumulator++;
            if (Time.realtimeSinceStartup > m_fpsNextPeriod)
            {
                m_currentFps = m_fpsAccumulator / cMeasurePeriod;
                m_currentMs = 1000f / m_currentFps;
                m_fpsAccumulator = 0f;
                m_fpsNextPeriod = Time.realtimeSinceStartup + cMeasurePeriod;
                if (m_fpsText != null)
                {
                    m_fpsText.text = string.Format(cFormat, m_currentFps, m_currentMs);
                }
            }
        }
    }
}
