// Copyright © 2018 Procedural Worlds Pty Limited.  All Rights Reserved.
using UnityEditor;
using UnityEngine;
using PWCommon2;

namespace CTS.Internal
{
    [InitializeOnLoad]
    public static class PWApp
    {
        public const string CONF_NAME = "CTS";

        private static AppConfig m_conf;
        public static AppConfig CONF
        {
            get
            {
                if (m_conf != null)
                {
                    return m_conf;
                }

                m_conf = AssetUtils.GetConfig(CONF_NAME);
                if (m_conf != null)
                {
                    Prod.Checkin(m_conf);
                }

                return m_conf;
            }
        }

        static PWApp()
        {
            // Need to wait for things to import before creating the common menu - Using delegates and only check menu when something gets imported
            AssetDatabase.importPackageCompleted -= OnImportPackageCompleted;
            AssetDatabase.importPackageCompleted += OnImportPackageCompleted;

            AssetDatabase.importPackageCancelled -= OnImportPackageCancelled;
            AssetDatabase.importPackageCancelled += OnImportPackageCancelled;

            AssetDatabase.importPackageFailed -= OnImportPackageFailed;
            AssetDatabase.importPackageFailed += OnImportPackageFailed;

            m_conf = AssetUtils.GetConfig(CONF_NAME, true);
        }

        /// <summary>
        /// Called when a package import is Completed.
        /// </summary>
        private static void OnImportPackageCompleted(string packageName)
        {
#if PW_DEBUG
            Debug.LogFormat("[C.Prod]: '{0}' Import Completed", packageName);
#endif
            OnPackageImport();
        }

        /// <summary>
        /// Called when a package import is Cancelled.
        /// </summary>
        private static void OnImportPackageCancelled(string packageName)
        {
            //Debug.LogWarningFormat("'{0}' Import was Cancelled.", packageName);
            OnPackageImport();
        }

        /// <summary>
        /// Called when a package import fails.
        /// </summary>
        private static void OnImportPackageFailed(string packageName, string error)
        {
            //Debug.LogErrorFormat("'{0}' Import Failed with error message: '{1}'.", packageName, error);
            OnPackageImport();
        }

        /// <summary>
        /// Used to run things after a package was imported.
        /// </summary>
        private static void OnPackageImport()
        {
            if (m_conf == null)
            {
                m_conf = AssetUtils.GetConfig(CONF_NAME);
            }
            Prod.Checkin(m_conf);

            // No need for these anymore
            AssetDatabase.importPackageCompleted -= OnImportPackageCompleted;
            AssetDatabase.importPackageCancelled -= OnImportPackageCancelled;
            AssetDatabase.importPackageFailed -= OnImportPackageFailed;
        }

        /// <summary>
        /// Get an editor utils object that can be used for common Editor stuff - DO make sure to Dispose() the instance.
        /// </summary>
        /// <param name="editorObj">The class that uses the utils. Just pass in "this".</param>
        /// <param name="customUpdateMethod">(Optional) The method to be called when the GUI needs to be updated. (Repaint will always be called.)</param>
        /// <returns>Editor Utils</returns>
        public static EditorUtils GetEditorUtils(IPWEditor editorObj, System.Action customUpdateMethod = null)
        {
            return new EditorUtils(CONF, editorObj, customUpdateMethod);
        }
    }
}
