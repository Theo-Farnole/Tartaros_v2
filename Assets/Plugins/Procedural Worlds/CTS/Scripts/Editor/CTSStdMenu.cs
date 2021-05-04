// Copyright © 2018 Procedural Worlds Pty Limited.  All Rights Reserved.
using UnityEngine;
using UnityEditor;
using PWCommon2;

namespace CTS.Internal
{
    public class CTSStdMenu : Editor
    {
        /// <summary>
        /// Show tutorials
        /// </summary>
        [MenuItem("Window/" + PWConst.COMMON_MENU + "/CTS/Show CTS Tutorials...", false, 100)]
        public static void ShowTutorial()
        {
            Application.OpenURL(PWApp.CONF.TutorialsLink);
        }

        /// <summary>
        /// Show support page
        /// </summary>
        [MenuItem("Window/" + PWConst.COMMON_MENU + "/CTS/Show CTS Support, Lodge a Ticket...", false, 101)]
        public static void ShowSupport()
        {
            Application.OpenURL(PWApp.CONF.SupportLink);
        }

        /// <summary>
        /// Show review option
        /// </summary>
        [MenuItem("Window/" + PWConst.COMMON_MENU + "/CTS/Please Review CTS...", false, 102)]
        public static void ShowProductAssetStore()
        {
            Application.OpenURL(PWApp.CONF.ASLink);
        }

        /// <summary>
        /// Show the welcome screen for this app
        /// </summary>
        [MenuItem("Window/" + PWConst.COMMON_MENU + "/CTS/Show CTS Welcome...", false, 103)]
        public static void ShowProductWelcome()
        {
            PWWelcome.ShowWelcome(PWApp.CONF);
        }
    }
}
