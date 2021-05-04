using UnityEngine;
using UnityEditor;
using PWCommon2;
using CTS.Internal;

namespace CTS
{
    public class DirStructChecker
    {
        private const string PW_FOLDER_NAME = "/Procedural Worlds";
        static string incorrectPath = "";

        [InitializeOnLoadMethod]
        static void Onload()
        {
            AppConfig conf = AssetUtils.GetConfig(PWApp.CONF_NAME, true);
            if (conf != null)
            {
                if (conf.Folder != null)
                {
                    Check(conf);
                }
            }
            else
            {
                // Need to wait for things to import before creating the common menu - Using delegates and only check menu when something gets imported
                AssetDatabase.importPackageCompleted -= OnImportPackageCompleted;
                AssetDatabase.importPackageCompleted += OnImportPackageCompleted;

                AssetDatabase.importPackageCancelled -= OnImportPackageCancelled;
                AssetDatabase.importPackageCancelled += OnImportPackageCancelled;

                AssetDatabase.importPackageFailed -= OnImportPackageFailed;
                AssetDatabase.importPackageFailed += OnImportPackageFailed;
            }
        }

        /// <summary>
        /// Called when a package import is Completed.
        /// </summary>
        private static void OnImportPackageCompleted(string packageName)
        {
            OnPackageImport();
        }

        /// <summary>
        /// Called when a package import is Cancelled.
        /// </summary>
        private static void OnImportPackageCancelled(string packageName)
        {
            OnPackageImport();
        }

        /// <summary>
        /// Called when a package import fails.
        /// </summary>
        private static void OnImportPackageFailed(string packageName, string error)
        {
            OnPackageImport();
        }

        /// <summary>
        /// Used to run things after a package was imported.
        /// </summary>
        private static void OnPackageImport()
        {
            Check(PWApp.CONF);

            // No need for these anymore
            AssetDatabase.importPackageCompleted -= OnImportPackageCompleted;
            AssetDatabase.importPackageCancelled -= OnImportPackageCancelled;
            AssetDatabase.importPackageFailed -= OnImportPackageFailed;
        }

        /// <summary>
        /// Checks the folder structure
        /// </summary>
        /// <param name="conf"></param>
        private static void Check(AppConfig conf)
        {
            string procWorldsPath;
            string path = GetFolderPath(conf.Folder, out procWorldsPath);

            if (string.IsNullOrEmpty(path) == false)
            {
                if (string.IsNullOrEmpty(procWorldsPath) == false)
                {
                    string dialogText = string.Format("{0} {1} is now using Procedural Worlds' improved folder structure.\n\n" +
                        "Remnants of an older version of this product were found in this project. A clean update is recommended.\n\n" +
                        "The path that triggered this check is: " + incorrectPath +
                        "\n\n" +
                        "To do a clean update, please follow these steps:\n" +
                        " 1. Save/back up any of your data that may be contained inside the {0} folder ({2}).\n" +
                        " 2. Completely remove {0} (from where it was originally installed and also from the Procedural Worlds folder).\n" +
                        " 3. Reimport the new version of {0}.\n\n",
                        conf.Name, conf.Version, conf.Folder);
                    if (EditorUtility.DisplayDialog(conf.Name + " " + conf.Version, dialogText, "Ok", "Don't show this again") == false)
                    {
                        SelfDestruct();
                    }
                    //AssetDatabase.MoveAsset(path, procWorldsPath + "/" + conf.Folder);
                }
                else
                {
                    Debug.LogWarningFormat("[{0}]: Could not find the '{1}' folder.", conf.Name, PW_FOLDER_NAME);
                }
            }
        }

        /// <summary>
        /// Get the path of the product folder.
        /// </summary>
        /// <param name="appConfig">Appconfig of the product.</param>
        /// <returns></returns>
        private static string GetFolderPath(string folderName, out string procWorldsPath)
        {
            procWorldsPath = null;
            bool prodFolderFound = false;


            foreach (var path in AssetDatabase.GetAllAssetPaths())
            {
                if (path.EndsWith(PW_FOLDER_NAME))
                {
                    procWorldsPath = path;
                }

                if (path.EndsWith("/" + folderName))
                {
                    prodFolderFound = true;

                    // Product not in the new folder structure and needs to be moved.
                    if (path.Contains(PW_FOLDER_NAME) == false)
                    {
                        incorrectPath = path;
                    }
                }
            }

            if (!prodFolderFound)
            {
                Debug.LogWarningFormat("[{0}]: Could not find the '{1}' folder.", PWApp.CONF.Name, folderName);
            }
            return incorrectPath;
        }

        /// <summary>
        /// Removes this script
        /// </summary>
        private static void SelfDestruct()
        {
            foreach (var path in AssetDatabase.GetAllAssetPaths())
            {
                // If found this script under this products folder
                if (path.EndsWith("DirStructChecker.cs") && path.Contains(PWApp.CONF.Folder))
                {
                    //Debug.LogFormat("This'd have removed '{0}'", path);
                    AssetDatabase.DeleteAsset(path);
                }
            }
        }
    }
}