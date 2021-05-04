using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CTS
{
    public class CTSSetup : MonoBehaviour
    {
#if UNITY_EDITOR
        [MenuItem("Window/Procedural Worlds/CTS/Shader Installation", false, 100)]
        public static void InstallShaders(MenuCommand menuCommand)
        {
            string SRPVersion = GetSRPVersion();
            var environmentRenderer = CompleteTerrainShader.GetRenderPipeline();
            string requiredDirectoryName = GetRequiredDirectoryName(environmentRenderer, SRPVersion);

            bool installRequested = false;

            if (CheckIfShaderInstallRequired(requiredDirectoryName))
            {
                if (EditorUtility.DisplayDialog("CTS Shader Installation", "CTS found that the correct shaders for the current rendering pipeline are not installed and needs to install new shaders to properly function. \n\nDo you want to install the new shaders now? \n\nThe installation takes 5-10 minutes. It is recommended to perform the installation in an empty scene without any CTS terrain active, otherwise you might see error messages during the installation in the console.", "Install Now", "Cancel"))
                {
                    installRequested = true;
                }
            }
            else
            {
                if (EditorUtility.DisplayDialog("CTS Shader Installation", "CTS found that the correct CTS shaders should already be installed for this project.\n\n You can force a reinstallation of the shaders if you suspect something is out of the order, but it should normally not be required.", "Force Re-Install", "Cancel"))
                {
                    installRequested = true;
                }
            }

            if (installRequested)
            {
                //Install was requested, set the bools accordingly
                EditorPrefs.SetBool("CTS_ShadersInstallRequested", true);
                EditorPrefs.SetBool("CTS_AutoUpdateShaders", true);
                InstallShaders(environmentRenderer, SRPVersion, requiredDirectoryName);
            }
        }
#endif
        public static void UpdatePipelineDefines()
        {
#if UNITY_EDITOR
            if (EditorPrefs.GetBool("CTS_AutoUpdateShaders", true))
            {
                if (Application.isPlaying)
                {
                    //not during runtime
                    return;
                }
                bool changesMade = false;

                string SRPVersion = GetSRPVersion();
                var environmentRenderer = CompleteTerrainShader.GetRenderPipeline();

                string requiredDirectoryName = GetRequiredDirectoryName(environmentRenderer, SRPVersion);

                //Continue with install if requested by the user 
                if (EditorPrefs.GetBool("CTS_ShadersInstallRequested", false))
                {
                    //Make sure we re-enter the installation until it is finished
                    EditorPrefs.SetBool("CTS_ShadersInstallRequested", true);
                    changesMade = InstallShaders(environmentRenderer, SRPVersion, requiredDirectoryName);
                }
                else
                {
                    //no install running? check if we need to display the notification dialog
                    if (CheckIfShaderInstallRequired(requiredDirectoryName))
                    {
                        if (EditorUtility.DisplayDialog("CTS Shader Info", "CTS noticed that the current rendering pipeline does not match the currently installed CTS shaders, and other shaders need to be installed for CTS to function properly. This is perfectly normal if you just installed this version of CTS, or if you just switched rendering pipelines.  Please run the command \n\n Window > Procedural Worlds > CTS > Shader Installation \n\n to start the shader installation when it is convenient for you. It is recommended to start the installation from an empty scene without any CTS terrains being active.", "Ok, got it!"))
                        {
                            EditorPrefs.SetBool("CTS_AutoUpdateShaders", false);
                        }
                    }
                }
                

                //Check build settings

                string originalBuildSettings = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
                string currBuildSettings = originalBuildSettings;

                if (environmentRenderer == CTSConstants.EnvironmentRenderer.HighDefinition)
                {
                    if (!currBuildSettings.Contains("HDPipeline"))
                    {
                        if (string.IsNullOrEmpty(currBuildSettings))
                        {
                            currBuildSettings = "HDPipeline";
                        }
                        else
                        {
                            currBuildSettings += ";HDPipeline";
                        }
                    }
                }
                else
                {
                    currBuildSettings = currBuildSettings.Replace("HDPipeline;", "");
                    currBuildSettings = currBuildSettings.Replace("HDPipeline", "");
                }

                if (environmentRenderer == CTSConstants.EnvironmentRenderer.LightWeight)
                {
                    if (!currBuildSettings.Contains("LWPipeline"))
                    {
                        if (string.IsNullOrEmpty(currBuildSettings))
                        {
                            currBuildSettings = "LWPipeline";
                        }
                        else
                        {
                            currBuildSettings += ";LWPipeline";
                        }
                    }
                }
                else
                {
                    currBuildSettings = currBuildSettings.Replace("LWPipeline;", "");
                    currBuildSettings = currBuildSettings.Replace("LWPipeline", "");
                }

                if (environmentRenderer == CTSConstants.EnvironmentRenderer.Universal)
                {
                    if (!currBuildSettings.Contains("UPPipeline"))
                    {
                        if (string.IsNullOrEmpty(currBuildSettings))
                        {
                            currBuildSettings = "UPPipeline";
                        }
                        else
                        {
                            currBuildSettings += ";UPPipeline";
                        }
                    }
                }
                else
                {
                    currBuildSettings = currBuildSettings.Replace("UPPipeline;", "");
                    currBuildSettings = currBuildSettings.Replace("UPPipeline", "");
                }


                if (originalBuildSettings != currBuildSettings)
                {
                    PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, currBuildSettings);
                }

                //Things were changed? We need to refresh.
                if (changesMade)
                {
                    AssetDatabase.Refresh();
                }
            }
#endif
        }
#if UNITY_EDITOR
        private static bool InstallShaders(CTSConstants.EnvironmentRenderer environmentRenderer, string SRPVersion, string requiredDirectoryName)
        {
            bool changesMade = false;

            //Determine if the correct Shaders are installed in the Shaders directory.

            string ctsDirectory = CompleteTerrainShader.GetCTSDirectory();

            //No CTS directory? Abort then, this installation / check attempt will do no good.
            if (ctsDirectory == null || ctsDirectory == "")
            {
                EditorPrefs.SetBool("CTS_AutoUpdateShaders", false);
                EditorPrefs.SetBool("CTS_ShadersInstallRequested", false);
                return false;
            }

            string shaderDirectory = ctsDirectory + "Shaders";
            DirectoryInfo shaderDirectoryInfo = new DirectoryInfo(shaderDirectory);
            var directories = shaderDirectoryInfo.GetDirectories();
            foreach (DirectoryInfo dir in directories)
            {
                //Get rid off any directory that does not start with "Library"
                if (!dir.Name.StartsWith("Library"))
                {
                    FileUtil.DeleteFileOrDirectory(dir.FullName);
                    //Remove the .meta file, if any
                    FileUtil.DeleteFileOrDirectory(dir.FullName + ".meta");
                    changesMade = true;
                }
            }


            var files = shaderDirectoryInfo.GetFiles();

            foreach (FileInfo file in files)
            {
                //Delete all files other than the readme txt file, and meta files, this will clean up any unwanted files & leftover shaders
                if (!file.Extension.EndsWith("txt") && !file.Extension.EndsWith("meta"))
                {
                    FileUtil.DeleteFileOrDirectory(file.FullName);
                    changesMade = true;
                }
            }

            //Determine correct library folder for installation
            string librarySourceFolder = shaderDirectory + "/Library Built In";
            switch (environmentRenderer)
            {
                case CTSConstants.EnvironmentRenderer.LightWeight:
                    librarySourceFolder = shaderDirectory + "/Library SRP " + SRPVersion + "/LWRP";
                    break;
                case CTSConstants.EnvironmentRenderer.HighDefinition:
                    librarySourceFolder = shaderDirectory + "/Library SRP " + SRPVersion + "/HDRP";
                    break;
                case CTSConstants.EnvironmentRenderer.Universal:
                    librarySourceFolder = shaderDirectory + "/Library SRP " + SRPVersion + "/URP";
                    break;
            }

            //Check if the source directory exists
            DirectoryInfo sourceDirectoryInfo = new DirectoryInfo(librarySourceFolder);
            if (!sourceDirectoryInfo.Exists)
            {
                Debug.LogError("CTS could not install shaders for " + requiredDirectoryName + " rendering, the required shaders were not found in the shader library!");
                EditorPrefs.SetBool("CTS_AutoUpdateShaders", false);
                return false;
            }

            //We only have copied the "raw" .shaderfiles at this point, we still need to remove the "file" suffix. However this must take place on the next run of this function,
            //otherwise unity will crash when the file endings are altered before the deleted file changes from above have been processed!
            if (!changesMade)
            {
                //Set target directory
                string targetDirectory = shaderDirectory + "/" + requiredDirectoryName;

                FileUtil.CopyFileOrDirectory(librarySourceFolder, targetDirectory);
                RemoveFileSuffix(targetDirectory);
                //All done, remove permission
                EditorPrefs.SetBool("CTS_ShadersInstallRequested", false);
            }

            AssetDatabase.Refresh();

            //Rebuild the shader dictionary, otherwise the new shaders cannot be found!
            CTSShaders.RebuildShaderDictionary();

            return changesMade;
        }
#endif
        private static string GetSRPVersion()
        {
#if UNITY_2019_3_OR_NEWER
            return "7.2";
#elif UNITY_2019_2_OR_NEWER
            return "6.9";
#elif UNITY_2019_1_OR_NEWER
            return "5.7";
#elif UNITY_2018_3_OR_NEWER
            return "4.8";
#else
                return "";
#endif
        }

        private static string GetRequiredDirectoryName(CTSConstants.EnvironmentRenderer environmentRenderer, string SRPVersion)
        {
            string requiredDirectoryName = "Built In";

            switch (environmentRenderer)
            {
                case CTSConstants.EnvironmentRenderer.LightWeight:
                    requiredDirectoryName = "LWRP " + SRPVersion;
                    break;
                case CTSConstants.EnvironmentRenderer.HighDefinition:
                    requiredDirectoryName = "HDRP " + SRPVersion;
                    break;
                case CTSConstants.EnvironmentRenderer.Universal:
                    requiredDirectoryName = "URP " + SRPVersion;
                    break;
            }

            return requiredDirectoryName;
        }


        /// <summary>
        /// Checks if the correct shader directory is present for this pipeline in the "Shaders" directory - if not, it is likely that the correct shaders need to be installed
        /// </summary>
        /// <returns></returns>
        public static bool CheckIfShaderInstallRequired()
        {
            string SRPVersion = GetSRPVersion();
            var environmentRenderer = CompleteTerrainShader.GetRenderPipeline();
            string requiredDirectoryName = GetRequiredDirectoryName(environmentRenderer, SRPVersion);
            return CheckIfShaderInstallRequired(requiredDirectoryName);
        }


        private static bool CheckIfShaderInstallRequired(string requiredDirectoryName)
        {

            //Determine if the correct Shaders are installed in the Shaders directory.
            string ctsDirectory = CompleteTerrainShader.GetCTSDirectory();

            //No CTS directory? Abort then, this installation / check attempt will do no good.
            if (ctsDirectory == null || ctsDirectory == "")
            {
                return false;
            }

            string shaderDirectory = ctsDirectory + "Shaders";
            DirectoryInfo shaderDirectoryInfo = new DirectoryInfo(shaderDirectory);
            var directories = shaderDirectoryInfo.GetDirectories();

            //Iterate through the directories and check if the correct shader version has been installed


            bool shaderInstallRequired = true;
            foreach (DirectoryInfo dir in directories)
            {
                if (requiredDirectoryName == dir.Name)
                {
                    shaderInstallRequired = false;
                    break;
                }
            }
            return shaderInstallRequired;

        }
#if UNITY_EDITOR
        static void RemoveFileSuffix(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            var files = dirInfo.GetFiles();
            bool changes = false;
            foreach (FileInfo file in files)
            {
                if (file.Extension.EndsWith("file"))
                {
                    string fileName = file.FullName;
                    File.Move(fileName, fileName.Remove(fileName.Length - 4, 4));
                    changes = true;
                }
                //Delete all meta files and let unity make new ones, we don't want any conflicts when importing a new package
                if (file.Extension.EndsWith("meta"))
                {
                    FileUtil.DeleteFileOrDirectory(file.FullName);
                    changes = true;
                }
            }

            if (changes)
            {
                AssetDatabase.Refresh();
            }
        }
#endif
    }
}