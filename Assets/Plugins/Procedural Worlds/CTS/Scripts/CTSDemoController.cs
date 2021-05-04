using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
#if UNITY_POST_PROCESSING_STACK_V2
using UnityEngine.Rendering.PostProcessing;
#endif

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Rendering;
#endif

#if HDPipeline
#if UNITY_2019_3_OR_NEWER
        using UnityEngine.Rendering.HighDefinition;
#elif UNITY_2018_3_OR_NEWER
        using UnityEngine.Experimental.Rendering;
        using UnityEngine.Experimental.Rendering.HDPipeline;
#endif
#endif
#if LWPipeline
#if UNITY_2019_1_OR_NEWER
        using UnityEngine.Rendering.LWRP;
#elif UNITY_2018_3_OR_NEWER
        using UnityEngine.Experimental.Rendering.LightweightPipeline;
#endif
#endif


namespace CTS
{
    /// <summary>
    /// Represents the three different CTS demo scenes
    /// </summary>
    public enum DemoSceneType { Landscape, Performance, Swamp }

    /// <summary>
    /// Controller coordinator for demo scenes
    /// </summary>
    public class CTSDemoController : MonoBehaviour
    {
        public DemoSceneType m_demotype;


        [Header("Target")]
        public GameObject m_target;

        [Header("Walk Controller")]
        public CTSWalk m_walkController;
        private CharacterController m_characterController;

        [Header("Fly Controller")]
        public CTSFly m_flyController;

        [Header("Look Controller")]
        public CTSLook m_lookController;

        [Header("Profiles")]
        public CTSProfile m_unityProfile;
        public CTSProfile m_liteProfile;
        public CTSProfile m_basicProfile;
        public CTSProfile m_advancedProfile;
        public CTSProfile m_tesselatedProfile;

        [Header("UX Text")]
        public Text m_pipeline;
        public Text m_mode;
        public Text m_instancing;
        public Text m_readme;
        public Text m_instructions;



        //We need to process those as objects otherwise they can't be serialised properly if the HDRP package is not installed.
        public UnityEngine.Object m_ppProfile;
        [Header("HDRP settings")]
        public UnityEngine.Object m_HDRP_4_8_volume_settings;
        public UnityEngine.Object m_HDRP_5_7_volume_settings;
        public UnityEngine.Object m_HDRP_5_7_pp_settings;
        public UnityEngine.Object m_HDRP_7_1_volume_settings;
        public UnityEngine.Object m_HDRP_7_1_pp_settings;

        [Header("URP settings")]
        public UnityEngine.Object m_URP_7_1_pp_settings;

        public Material m_defaultSkyboxMaterial;
        bool m_tessellationSelected = false;

        private CTSConstants.EnvironmentRenderer m_lastEnvironmentRenderer;
        private bool m_lastPostProcessingState = false;
        [HideInInspector]
        public bool m_initialLightingSetupPerformed = false;

        //old v1 post processing

        //[Header("Post FX")]
        //public ScriptableObject m_postFX;
        //private Component m_postProcessingComponent;





        void Awake()
        {
            CTSSetup.UpdatePipelineDefines();

            #region Display SRP
            switch (CompleteTerrainShader.GetRenderPipeline())
            {
                case CTSConstants.EnvironmentRenderer.BuiltIn:
                    m_pipeline.text = "Built-In Rendering";
                    break;
                case CTSConstants.EnvironmentRenderer.LightWeight:
                    m_pipeline.text = "LWRP Rendering";
                    break;
                case CTSConstants.EnvironmentRenderer.HighDefinition:
                    m_pipeline.text = "HDRP Rendering";
                    break;
                case CTSConstants.EnvironmentRenderer.Universal:
                    m_pipeline.text = "URP Rendering";
                    break;
            }
            #endregion

            //Target
            if (m_target == null)
            {
                m_target = Camera.main.gameObject;
            }

#if LWPipeline
            //setup directional light bias settings, as LWRP tends to mess that one up
            GameObject directionalLight = GameObject.Find("Directional Light");
            if (directionalLight)
            {
                Light light = directionalLight.GetComponent<Light>();
                if (light)
                {
                    LWRPAdditionalLightData data = directionalLight.GetComponent<LWRPAdditionalLightData>();
                    if (data)
                        data.usePipelineSettings = false;
                    light.shadowNormalBias = 3;
                    light.shadowBias = 0.2f;
                }
            }
#endif



            #region PostFX V1
            /*See if we can set up post processing for better lighting
            try
            {
#region PostProcessing V1
                if (m_postFX != null)
                {
                    Camera camera = Camera.main;
                    if (camera == null)
                    {
                        camera = FindObjectOfType<Camera>();
                    }
                    if (camera != null)
                    {
                        Type postProcessingType = GetType("UnityEngine.PostProcessing.PostProcessingBehaviour");
                        if (postProcessingType != null)
                        {
                            GameObject cameraObj = camera.gameObject;

                            m_postProcessingComponent = cameraObj.GetComponent(postProcessingType);
                            if (m_postProcessingComponent == null)
                            {
                                m_postProcessingComponent = cameraObj.AddComponent(postProcessingType);
                            }
                            if (m_postProcessingComponent != null)
                            {
                                FieldInfo fi = postProcessingType.GetField("profile", BindingFlags.Public | BindingFlags.Instance);
                                if (fi != null)
                                {
                                    fi.SetValue(m_postProcessingComponent, m_postFX);
                                }
                                ((MonoBehaviour) m_postProcessingComponent).enabled = false;
                            }
                        }
                    }
                }
#endregion
            }
            catch (Exception)
            {
                Debug.Log("Failed to set up post fx.");
            }*/
            #endregion



            #region Linear Baked Lighting check
#if UNITY_EDITOR
            if (m_readme != null)
            {
                string readme = "";
                bool needLightingUpdate = false;

                if (PlayerSettings.colorSpace != ColorSpace.Linear)
                {
                    needLightingUpdate = true;
                }

                if (!needLightingUpdate)
                {
                    var tier1 = EditorGraphicsSettings.GetTierSettings(EditorUserBuildSettings.selectedBuildTargetGroup, GraphicsTier.Tier1);
                    if (tier1.renderingPath != RenderingPath.DeferredShading)
                    {
                        needLightingUpdate = true;
                    }
                }

                if (!needLightingUpdate)
                {
                    var tier2 = EditorGraphicsSettings.GetTierSettings(EditorUserBuildSettings.selectedBuildTargetGroup, GraphicsTier.Tier2);
                    if (tier2.renderingPath != RenderingPath.DeferredShading)
                    {
                        needLightingUpdate = true;
                    }
                }

                if (!needLightingUpdate)
                {
                    var tier3 = EditorGraphicsSettings.GetTierSettings(EditorUserBuildSettings.selectedBuildTargetGroup, GraphicsTier.Tier3);
                    if (tier3.renderingPath != RenderingPath.DeferredShading)
                    {
                        needLightingUpdate = true;
                    }
                }

                if (needLightingUpdate)
                {
                    readme = "Instructions : Lighting incorrect";
                }

#if !UNITY_POST_PROCESSING_STACK_V2
                if (readme.Length == 0)
                {
                    readme = "Instructions : Post FX missing.";
                }
                else
                {
                    readme += ", Post Processing V2 missing";
                }
#endif

                //#if HDPipeline
                //                if (CompleteTerrainShader.GetRenderPipeline() == CTSConstants.EnvironmentRenderer.HighDefinition2018x && m_HDRP_prefab!=null)
                //                {
                //                    if (GameObject.Find(m_HDRP_prefab.name) == null)
                //                    {
                //                        GameObject newSettingsGO = Instantiate<GameObject>(m_HDRP_prefab);
                //                        newSettingsGO.name = m_HDRP_prefab.name;
                //                        Volume vol = newSettingsGO.GetComponent<Volume>();
                //                        vol.isGlobal = true;
                //                        vol.sharedProfile = m_HDRP_volume_settings; 
                //                    }
                //                }
                //#endif

                UpdateInstancingDisplay();


                if (readme.Length > 0)
                {
                    readme += ". Please read CTS_Demo_ReadMe to fix!";
                }
                m_readme.text = readme;
            }
#endif
            #endregion

            #region Controller setup

            //Fly controller
            if (m_flyController == null)
            {
                m_flyController = m_target.GetComponent<CTSFly>();
            }
            if (m_flyController == null)
            {
                m_flyController = m_target.AddComponent<CTSFly>();
            }
            m_flyController.enabled = false;

            //Character controller
            if (m_characterController == null)
            {
                m_characterController = m_target.GetComponent<CharacterController>();
            }
            if (m_characterController == null)
            {
                m_characterController = m_target.AddComponent<CharacterController>();
                m_characterController.height = 4f;
            }
            m_characterController.enabled = false;

            //Walk controller
            if (m_walkController == null)
            {
                m_walkController = m_target.GetComponent<CTSWalk>();
            }
            if (m_walkController == null)
            {
                m_walkController = m_target.AddComponent<CTSWalk>();
                m_walkController.m_controller = m_characterController;
            }
            m_walkController.enabled = false;

            //Look controller
            if (m_lookController == null)
            {
                m_lookController = m_target.GetComponent<CTSLook>();
            }
            if (m_lookController == null)
            {
                m_lookController = m_target.AddComponent<CTSLook>();
                m_lookController._playerRootT = m_target.transform;
                m_lookController._cameraT = m_target.transform;
            }
            m_lookController.enabled = false;
            #endregion

            #region Instructions
            if (m_instructions != null)
            {
                string commands = "";
                if (m_unityProfile != null)
                {
                    commands += "Controls: 1. Unity";
                }
                if (m_liteProfile != null)
                {
                    if (commands.Length > 0)
                    {
                        commands += ", 2. Lite";
                    }
                    else
                    {
                        commands = "Controls: 2. Lite";
                    }
                }
                if (m_basicProfile != null)
                {
                    if (commands.Length > 0)
                    {
                        commands += ", 3. Basic";
                    }
                    else
                    {
                        commands = "Controls: 3. Basic";
                    }
                }
                if (m_advancedProfile != null)
                {
                    if (commands.Length > 0)
                    {
                        commands += ", 4. Advanced";
                    }
                    else
                    {
                        commands = "Controls: 4. Advanced";
                    }
                }
                if (m_tesselatedProfile != null)
                {
                    if (commands.Length > 0)
                    {
                        commands += ", 5. Tesselated";
                    }
                    else
                    {
                        commands = "Controls: 5. Tesselated";
                    }
                }
                if (m_flyController != null)
                {
                    if (commands.Length > 0)
                    {
                        commands += ", 6. Fly";
                    }
                    else
                    {
                        commands = "Controls: 6. Fly";
                    }
                }
                if (m_walkController != null)
                {
                    if (commands.Length > 0)
                    {
                        commands += ", 7. Walk";
                    }
                    else
                    {
                        commands = "Controls: 7. Walk";
                    }
                }
#if UNITY_POST_PROCESSING_STACK_V2

                if (commands.Length > 0)
                {
                    commands += ", P. Post FX";
                }
                else
                {
                    commands = "Controls: P. Post FX";
                }
#endif
#if UNITY_2018_3_OR_NEWER
                if (commands.Length > 0)
                {
                    commands += ", I. Switch Instancing";
                }
                else
                {
                    commands = "Controls:I. Switch Instancing";
                }
#endif
                if (commands.Length > 0)
                {
                    commands += ", ESC. Exit.";
                }
                else
                {
                    commands = "Controls: ESC. Exit.";
                }
                m_instructions.text = commands;
            }
            #endregion

            //Start in basic mode
            SelectBasic();

            //At home
            if (m_flyController != null)
            {
                m_flyController.enabled = false;
            }
            if (m_walkController != null)
            {
                m_walkController.enabled = false;
            }
            if (m_characterController != null)
            {
                m_characterController.enabled = false;
            }
            if (m_lookController != null)
            {
                m_lookController.enabled = false;
            }
        }


        void OnDrawGizmos()
        {
            SetupLightingAndPipelines();
        }

        public void SetupLightingAndPipelines()
        {
            #region Pipeline Scene & Lighting Setup
            //Set up different lighting settings according to chosen rendering pipeline & SRP version
            var environmentRenderer = CompleteTerrainShader.GetRenderPipeline();

            //check if post processing is active or not
#if UNITY_POST_PROCESSING_STACK_V2
            bool postProcessingEnabled = true;
#else
            bool postProcessingEnabled = false;
#endif


            //Only set up lighting for the first time when scene was loaded or when the renderer / pp state was changed afterwards
            //this allows users to try their own settings for lighting, pp, etc. without the lighting settings being overwritten constantly
            if (!m_initialLightingSetupPerformed || m_lastEnvironmentRenderer != environmentRenderer || m_lastPostProcessingState != postProcessingEnabled)
            {
                Debug.Log("CTS is setting up lighting for demo scene");

                switch (environmentRenderer)
                {
                    case CTSConstants.EnvironmentRenderer.BuiltIn:
                        RemovePPandHDRPSettings();
                        switch (m_demotype)
                        {
                            case DemoSceneType.Landscape:
                                SetupLighting(environmentRenderer, 1.5f, 1.2f, 2600f, 5000f, new Color32(119, 152, 190, 255));
                                break;
                            case DemoSceneType.Performance:
                                SetupLighting(environmentRenderer, 1.2f, 1.2f, 100f, 1000f, new Color32(113, 119, 154, 255));
                                break;
                            case DemoSceneType.Swamp:
                                SetupLighting(environmentRenderer, 1.25f, 3f, 70f, 600f, new Color32(167, 184, 212, 255));
                                break;
                        }
                        break;
                    case CTSConstants.EnvironmentRenderer.LightWeight:
                        RemovePPandHDRPSettings();
                        switch (m_demotype)
                        {
                            case DemoSceneType.Landscape:
                                SetupLighting(environmentRenderer, 1.5f, 1.2f, 2600f, 5000f, new Color32(119, 152, 190, 255));
                                break;
                            case DemoSceneType.Performance:
                                SetupLighting(environmentRenderer, 1.2f, 1.2f, 100f, 1000f, new Color32(113, 119, 154, 255));
                                break;
                            case DemoSceneType.Swamp:
                                SetupLighting(environmentRenderer, 4f, 4f, 70f, 600f, new Color32(167, 184, 212, 255));
                                break;
                        }
                        break;
                    case CTSConstants.EnvironmentRenderer.HighDefinition:
                        RemovePPandHDRPSettings();
                        switch (m_demotype)
                        {
                            case DemoSceneType.Landscape:
#if UNITY_2019_3_OR_NEWER
                                SetupLighting(environmentRenderer, 15f, 1f, 2600f, 5000f, new Color32(119, 152, 190, 255));
#else
                                SetupLighting(environmentRenderer, 5f, 1f, 2600f, 5000f, new Color32(119, 152, 190, 255));
#endif
                                break;
                            case DemoSceneType.Performance:
#if UNITY_2019_3_OR_NEWER
                                SetupLighting(environmentRenderer, 15f, 1.2f, 100f, 1000f, new Color32(113, 119, 154, 255));
#else
                                SetupLighting(environmentRenderer, 5f, 1.2f, 100f, 1000f, new Color32(113, 119, 154, 255));
#endif
                                break;
                            case DemoSceneType.Swamp:
#if UNITY_2019_3_OR_NEWER
                                SetupLighting(environmentRenderer, 20f, 10f, 70f, 600f, new Color32(167, 184, 212, 255));
#else
                                SetupLighting(environmentRenderer, 5f, 10f, 70f, 600f, new Color32(167, 184, 212, 255));
#endif
                                break;
                        }
                        break;
                    case CTSConstants.EnvironmentRenderer.Universal:
                        RemovePPandHDRPSettings();
                        switch (m_demotype)
                        {
                            case DemoSceneType.Landscape:
                                SetupLighting(environmentRenderer, 1.5f, 1.2f, 2600f, 5000f, new Color32(119, 152, 190, 255));
                                break;
                            case DemoSceneType.Performance:
                                SetupLighting(environmentRenderer, 1.2f, 1.2f, 100f, 1000f, new Color32(113, 119, 154, 255));
                                break;
                            case DemoSceneType.Swamp:
                                SetupLighting(environmentRenderer, 4f, 4f, 70f, 600f, new Color32(167, 184, 212, 255));
                                break;
                        }
                        break;
                }

                //Refresh the CTS shader on the terrains in case pipeline has changed
                if (Terrain.activeTerrain && m_lastEnvironmentRenderer != environmentRenderer)
                {
                    var shader = Terrain.activeTerrain.GetComponent<CompleteTerrainShader>();
                    if (shader)
                    {
                        CTSTerrainManager.Instance.BroadcastProfileUpdate(shader.Profile);
                    }

                }

                m_initialLightingSetupPerformed = true;
                m_lastPostProcessingState = postProcessingEnabled;
                m_lastEnvironmentRenderer = environmentRenderer;

            }
#endregion

        }



        private void RemovePPandHDRPSettings()
        {
            GameObject settings = GameObject.Find("HDRP Scene Settings");
            if (settings)
            {
                DestroyImmediate(settings);
            }
            GameObject hdrpPP = GameObject.Find("HDRP Post Processing");
            if (hdrpPP)
            {
                DestroyImmediate(hdrpPP);
            }
            GameObject urpPP = GameObject.Find("URP Post Processing");
            if (urpPP)
            {
                DestroyImmediate(urpPP);
            }
            GameObject pp = GameObject.Find("Post Processing");
            if (pp)
            {
                DestroyImmediate(pp);
            }
        }

        private void SetupLighting(CTSConstants.EnvironmentRenderer renderer, float directionalLightIntensity, float ambientLightIntensity, float fogStart, float fogEnd, Color32 fogColor)
        {


            Camera camera = Camera.main;
            if (camera == null)
            {
                camera = FindObjectOfType<Camera>();
            }
            if (camera != null)
            {
                //Strip off the additional HDRP camera data component as it throws errors if not run in HDRP
#if HDPipeline
                var additionalData = camera.GetComponent<HDAdditionalCameraData>();
                if (additionalData)
                {
                    DestroyImmediate(additionalData);
                }
#endif
                //Same thing with URP
#if UPPipeline
                var additionalData = camera.GetComponent<UnityEngine.Rendering.Universal.UniversalAdditionalCameraData>();
                if (additionalData)
                {
                    DestroyImmediate(additionalData);
                }
#endif


                //Strip off missing components such as the post processing component as it just will throw warnings
#if UNITY_EDITOR && UNITY_2019_1_OR_NEWER
                GameObjectUtility.RemoveMonoBehavioursWithMissingScript(camera.gameObject);
#endif

            }

            //Strip off any additonal components from reflection probe, they might be leftovers from running HDRP before
            GameObject reflectionProbe = GameObject.Find("Reflection Probe");
            if (reflectionProbe != null)
            {
                foreach (Component c in reflectionProbe.GetComponents<Component>())
                {
                    if (c.GetType() == null || (c.GetType() != typeof(Transform) && c.GetType() != typeof(ReflectionProbe)))
                    {
                        DestroyImmediate(c);
                    }
                }
            }

            GameObject directionalLight = GameObject.Find("Directional Light");
            if (directionalLight)
            {
                Light light = directionalLight.GetComponent<Light>();
                if (light)
                {
                    light.intensity = directionalLightIntensity;

                    if (renderer != CTSConstants.EnvironmentRenderer.HighDefinition)
                    {
                        //Strip off all other components from the directional light, they might be leftovers from running HDRP before
                        foreach (Component c in directionalLight.GetComponents<Component>())
                        {
                            if (c.GetType() == null || (c.GetType() != typeof(Transform) && c.GetType() != typeof(Light)))
                            {
                                DestroyImmediate(c);
                            }
                        }




                    }
                    else
                    {
#if HDPipeline
                        //Update the additional light data with intensity
                        HDAdditionalLightData lightData = light.GetComponent<HDAdditionalLightData>();
                        if(!lightData)
                        {
                            lightData = light.gameObject.AddComponent<HDAdditionalLightData>();
                        }

                        if (lightData)
                        {
#if !UNITY_2019_3_OR_NEWER
                            lightData.useVolumetric = true;
#endif
                            lightData.lightUnit = LightUnit.Lux;
                            lightData.intensity = directionalLightIntensity;
                        }
#endif
                        }

                }
            }

            if (renderer == CTSConstants.EnvironmentRenderer.HighDefinition)
            {
#if HDPipeline
                GameObject sceneSettings = new GameObject("HDRP Scene Settings");
                Volume settingsVolume = sceneSettings.AddComponent<Volume>();
                settingsVolume.isGlobal = true;
                settingsVolume.weight = 1;
                settingsVolume.priority = 0;
#if UNITY_2018_3 || UNITY_2018_4
                settingsVolume.sharedProfile = (VolumeProfile)m_HDRP_4_8_volume_settings;

#if UNITY_POST_PROCESSING_STACK_V2
                //we are in SRP 4.8, set up the classic Post Processing
                GameObject pp = new GameObject("Post Processing");
                pp.layer = LayerMask.NameToLayer("TransparentFX");
                PostProcessVolume ppVolume = pp.AddComponent<PostProcessVolume>();
                ppVolume.weight = 0.7f;
                ppVolume.isGlobal = true;
                ppVolume.sharedProfile = (PostProcessProfile)m_ppProfile;
                if (camera != null)
                {
                    PostProcessLayer ppLayer = camera.gameObject.GetComponent<PostProcessLayer>();
                    if (ppLayer == null)
                    {
                        ppLayer = camera.gameObject.AddComponent<PostProcessLayer>();
                    }
                    if (ppLayer != null)
                    {
                        ppLayer.volumeTrigger = camera.transform;
                        ppLayer.volumeLayer = LayerMask.GetMask(new string[] { "TransparentFX" });
                        ppLayer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
                        ppLayer.enabled = false;
                    }
                }
#endif

#elif UNITY_2019_1 || UNITY_2019_2
                settingsVolume.sharedProfile = (VolumeProfile)m_HDRP_5_7_volume_settings;
                //we are in SRP 5.7 or above, set up HDRP post processing
                GameObject hdrpPost = new GameObject("HDRP Post Processing");
                Volume hdrpVolume = hdrpPost.AddComponent<Volume>();
                hdrpVolume.isGlobal = true;
                hdrpVolume.weight = 1;
                hdrpVolume.priority = 0;
                hdrpVolume.sharedProfile = (VolumeProfile)m_HDRP_5_7_pp_settings;
                //switch off pp per default, can be enabled per "P" key later
                hdrpVolume.enabled = false;
#elif UNITY_2019_3_OR_NEWER
                settingsVolume.sharedProfile = (VolumeProfile)m_HDRP_7_1_volume_settings;
                //we are in SRP 5.7 or above, set up HDRP post processing
                GameObject hdrpPost = new GameObject("HDRP Post Processing");
                Volume hdrpVolume = hdrpPost.AddComponent<Volume>();
                hdrpVolume.isGlobal = true;
                hdrpVolume.weight = 1;
                hdrpVolume.priority = 0;
                hdrpVolume.sharedProfile = (VolumeProfile)m_HDRP_7_1_pp_settings;
                //switch off pp per default, can be enabled per "P" key later
                hdrpVolume.enabled = false;
#endif
#if UNITY_2018_3 || UNITY_2018_4
                BakingSky bakingSky = sceneSettings.AddComponent<BakingSky>();
                bakingSky.profile = (VolumeProfile)m_HDRP_4_8_volume_settings;
                bakingSky.bakingSkyUniqueID = 2;
#endif


#endif
            }

            else if (renderer == CTSConstants.EnvironmentRenderer.Universal)
            {
#if UPPipeline
                GameObject urpPost = new GameObject("URP Post Processing");
                Volume urpVolume = urpPost.AddComponent<Volume>();
                urpVolume.isGlobal = true;
                urpVolume.weight = 1;
                urpVolume.priority = 0;
                urpVolume.sharedProfile = (VolumeProfile)m_URP_7_1_pp_settings;
                //switch off pp per default, can be enabled per "P" key later
                urpVolume.enabled = false;
                var additionalData = camera.gameObject.AddComponent<UnityEngine.Rendering.Universal.UniversalAdditionalCameraData>();
                additionalData.renderPostProcessing = true;
#endif
                RenderSettings.skybox = m_defaultSkyboxMaterial;

            }
            else
            {
#if UNITY_POST_PROCESSING_STACK_V2
                GameObject pp = new GameObject("Post Processing");
                pp.layer = LayerMask.NameToLayer("TransparentFX");
                PostProcessVolume ppVolume = pp.AddComponent<PostProcessVolume>();
                ppVolume.weight = 0.7f;
                ppVolume.isGlobal = true;
                ppVolume.sharedProfile = (PostProcessProfile)m_ppProfile;
                if (camera != null)
                {
                    PostProcessLayer ppLayer = camera.gameObject.GetComponent<PostProcessLayer>();
                    if (ppLayer == null)
                    {
                        ppLayer = camera.gameObject.AddComponent<PostProcessLayer>();
                    }
                    if (ppLayer != null)
                    {
                        ppLayer.volumeTrigger = camera.transform;
                        ppLayer.volumeLayer = LayerMask.GetMask(new string[] { "TransparentFX" });
                        ppLayer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
                        ppLayer.enabled = false;
                    }
                }
#endif


                RenderSettings.skybox = m_defaultSkyboxMaterial;
                RenderSettings.ambientMode = AmbientMode.Flat;
                RenderSettings.ambientSkyColor = fogColor;
                RenderSettings.ambientIntensity = ambientLightIntensity;
                RenderSettings.fogMode = FogMode.Linear;
                RenderSettings.fogStartDistance = fogStart;
                RenderSettings.fogEndDistance = fogEnd;
                RenderSettings.fogColor = fogColor;
                RenderSettings.fog = true;
            }

        }


        private void UpdateInstancingDisplay()
        {
#if UNITY_2018_3_OR_NEWER
            if (Terrain.activeTerrains.Length > 0)
            {
                bool firstValue = Terrain.activeTerrains[0].drawInstanced;
                if (m_instancing != null)
                {
                    m_instancing.text = "Instancing: " + firstValue.ToString();
                }
            }
#endif
        }


        public void SelectUnity()
        {
            if (m_unityProfile != null)
            {
                m_tessellationSelected = false;
                CTSTerrainManager.Instance.BroadcastProfileSelect(m_unityProfile);
                if (m_mode != null)
                {
                    m_mode.text = "Unity";
                }
                UpdateInstancingDisplay();
            }
        }

        public void SelectLite()
        {
            if (m_liteProfile != null)
            {
                m_tessellationSelected = false;
                CTSTerrainManager.Instance.BroadcastProfileSelect(m_liteProfile);
                if (m_mode != null)
                {
                    m_mode.text = "Lite";
                }
                UpdateInstancingDisplay();
            }
        }

        public void SelectBasic()
        {
            if (m_basicProfile != null)
            {
                m_tessellationSelected = false;
                CTSTerrainManager.Instance.BroadcastProfileSelect(m_basicProfile);
                if (m_mode != null)
                {
                    m_mode.text = "Basic";
                }
                UpdateInstancingDisplay();
            }
        }

        public void SelectAdvanced()
        {
            if (m_advancedProfile != null)
            {
                m_tessellationSelected = false;
                CTSTerrainManager.Instance.BroadcastProfileSelect(m_advancedProfile);
                if (m_mode != null)
                {
                    m_mode.text = "Advanced";
                }
                UpdateInstancingDisplay();
            }
        }

        public void SelectTesselated()
        {
            if (m_tesselatedProfile != null)
            {
                m_tessellationSelected = true;
                CTSTerrainManager.Instance.BroadcastProfileSelect(m_tesselatedProfile);
                if (m_mode != null)
                {
                    m_mode.text = "Tesselated";
                }
                UpdateInstancingDisplay();
            }
        }

        public void Fly()
        {
            if (m_flyController != null)
            {
                if (!m_flyController.isActiveAndEnabled)
                {
                    if (m_characterController != null)
                    {
                        m_characterController.enabled = false;
                    }
                    if (m_walkController != null)
                    {
                        if (m_walkController.isActiveAndEnabled)
                        {
                            m_walkController.enabled = false;
                        }
                    }
                    if (m_lookController != null)
                    {
                        m_lookController.enabled = true;
                    }
                    m_flyController.enabled = true;
                }
            }
        }

        public void Walk()
        {
            if (m_walkController != null)
            {
                if (!m_walkController.isActiveAndEnabled)
                {
                    if (m_flyController != null)
                    {
                        if (m_flyController.isActiveAndEnabled)
                        {
                            m_flyController.enabled = false;
                        }
                    }
                    if (m_characterController != null)
                    {
                        m_characterController.enabled = true;
                    }
                    if (m_lookController != null)
                    {
                        m_lookController.enabled = true;
                    }
                    m_walkController.enabled = true;
                }
            }
        }

        /// <summary>
        /// Toggle Post FX if they exist
        /// </summary>
        public void PostFX()
        {

            switch (CompleteTerrainShader.GetRenderPipeline())
            {
                case CTSConstants.EnvironmentRenderer.BuiltIn:
                    SwitchRegularPP();
                    break;
                case CTSConstants.EnvironmentRenderer.LightWeight:
                    SwitchRegularPP();
                    break;
                case CTSConstants.EnvironmentRenderer.HighDefinition:
#if UNITY_2019_1_OR_NEWER
                    SwitchHDRPPP();
#elif UNITY_2018_3_OR_NEWER
                SwitchRegularPP();
#endif
                    break;
                case CTSConstants.EnvironmentRenderer.Universal:
                    SwitchURPPP();
                    break;
            
            }
        }

        void SwitchHDRPPP()
        {
#if HDPipeline
            GameObject hdrpPP = GameObject.Find("HDRP Post Processing");
            if (hdrpPP)
            {
                Volume volume = hdrpPP.GetComponent<Volume>();
                if (volume)
                    volume.enabled = !volume.enabled;
            }
#endif
        }

        void SwitchURPPP()
        {
#if UPPipeline
            GameObject urpPP = GameObject.Find("URP Post Processing");
            if (urpPP)
            {
                Volume volume = urpPP.GetComponent<Volume>();
                if (volume)
                    volume.enabled = !volume.enabled;
            }
#endif
        }

        void SwitchRegularPP()
        {
#region PostProcessing V1
            /*
            if (m_postProcessingComponent != null)
            {
                if (((MonoBehaviour) m_postProcessingComponent).isActiveAndEnabled)
                {
                    ((MonoBehaviour)m_postProcessingComponent).enabled = false;
                }
                else
                {
                    ((MonoBehaviour)m_postProcessingComponent).enabled = true;
                }
            }*/
#endregion

#if UNITY_POST_PROCESSING_STACK_V2
            Camera camera = Camera.main;
            if (camera == null)
            {
                camera = FindObjectOfType<Camera>();
            }
            if (camera != null)
            {
                camera.GetComponent<PostProcessLayer>().enabled = !camera.GetComponent<PostProcessLayer>().enabled;
            }
#endif

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectUnity();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectLite();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SelectBasic();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SelectAdvanced();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                SelectTesselated();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                Fly();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                Walk();
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                PostFX();
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                SwitchInstancing();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }

        }

        private void SwitchInstancing()
        {
#if UNITY_2018_3_OR_NEWER
            if (Terrain.activeTerrains.Length > 0)
            {
                bool firstValue = true;

                if (!m_tessellationSelected)
                {
                    firstValue = Terrain.activeTerrains[0].drawInstanced;
                }
                else
                {
                    Debug.LogWarning("Tessellation Profile is active, enabling instancing at the same time is not possible.");
                }

                foreach (var terrain in Terrain.activeTerrains)
                {
                    terrain.drawInstanced = !firstValue;
                }
                if (m_instancing != null)
                {
                    m_instancing.text = "Instancing: " + (!firstValue).ToString();
                }
            }
#endif
        }

        /// <summary>
        /// Get the specified type if it exists
        /// </summary>
        /// <param name="TypeName">Name of the type to load</param>
        /// <returns>Selected type or null</returns>
        public static Type GetType(string TypeName)
        {
            // Try Type.GetType() first. This will work with types defined
            // by the Mono runtime, in the same assembly as the caller, etc.
            var type = Type.GetType(TypeName);

            // If it worked, then we're done here
            if (type != null)
                return type;

            // If the TypeName is a full name, then we can try loading the defining assembly directly
            if (TypeName.Contains("."))
            {
                // Get the name of the assembly (Assumption is that we are using 
                // fully-qualified type names)
                var assemblyName = TypeName.Substring(0, TypeName.IndexOf('.'));

                // Attempt to load the indicated Assembly
                try
                {
                    var assembly = Assembly.Load(assemblyName);
                    if (assembly == null)
                        return null;

                    // Ask that assembly to return the proper Type
                    type = assembly.GetType(TypeName);
                    if (type != null)
                        return type;
                }
                catch (Exception)
                {
                    //Debug.Log("Unable to load assemmbly : " + ex.Message);
                }
            }

            // If we still haven't found the proper type, we can enumerate all of the 
            // loaded assemblies and see if any of them define the type
            var currentAssembly = Assembly.GetCallingAssembly();
            {
                // Load the referenced assembly
                if (currentAssembly != null)
                {
                    // See if that assembly defines the named type
                    type = currentAssembly.GetType(TypeName);
                    if (type != null)
                        return type;
                }

            }

            //All loaded assemblies
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            for (int asyIdx = 0; asyIdx < assemblies.GetLength(0); asyIdx++)
            {
                type = assemblies[asyIdx].GetType(TypeName);
                if (type != null)
                {
                    return type;
                }
            }

            var referencedAssemblies = currentAssembly.GetReferencedAssemblies();
            foreach (var assemblyName in referencedAssemblies)
            {
                // Load the referenced assembly
                var assembly = Assembly.Load(assemblyName);
                if (assembly != null)
                {
                    // See if that assembly defines the named type
                    type = assembly.GetType(TypeName);
                    if (type != null)
                        return type;
                }
            }

            // The type just couldn't be found...
            return null;
        }
    }
}
