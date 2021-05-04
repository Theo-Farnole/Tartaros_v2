using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using System;

namespace CTS
{
    /// <summary>
    /// Handy editor utils
    /// </summary>
    public class CTSEditorUtils
    {
        private bool m_initialized = false;
        private GUIStyle m_boxStyle;
        private GUIStyle m_wrapStyle;
        private GUIStyle m_editWrapStyle;
        private GUIStyle m_titleStyle;
        private GUIStyle m_headingStyle;
        private GUIStyle m_bodyStyle;
        private GUIStyle m_linkStyle;
        private bool m_positionChecked = false;


        #region Data

        /// <summary>
        /// Access to position checked method
        /// </summary>
        public bool PositionChecked
        {
            get { return m_positionChecked; }
        }

        /// <summary>
        /// Box style
        /// </summary>
        public GUIStyle BoxStyle
        {
            get { return m_boxStyle; }
        }

        /// <summary>
        /// Wrap style
        /// </summary>
        public GUIStyle WrapStyle
        {
            get { return m_wrapStyle; }
        }

        public GUIStyle EditWrapStyle
        {
            get { return m_editWrapStyle; }
        }

        /// <summary>
        /// Body style
        /// </summary>
        public GUIStyle BodyStyle
        {
            get { return m_bodyStyle; }
        }

        /// <summary>
        /// Heading style
        /// </summary>
        public GUIStyle HeadingStyle
        {
            get { return m_headingStyle; }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Initialize editor styles
        /// </summary>
        public void Initialize()
        {
            //Set up the box style
            if (m_boxStyle == null)
            {
                m_boxStyle = new GUIStyle(GUI.skin.box);
                m_boxStyle.normal.textColor = GUI.skin.label.normal.textColor;
                m_boxStyle.fontStyle = FontStyle.Bold;
                m_boxStyle.alignment = TextAnchor.UpperLeft;
            }

            //Setup the wrap style
            if (m_wrapStyle == null)
            {
                m_wrapStyle = new GUIStyle(GUI.skin.label);
                m_wrapStyle.fontStyle = FontStyle.Normal;
                m_wrapStyle.wordWrap = true;
            }

            if (m_bodyStyle == null)
            {
                m_bodyStyle = new GUIStyle(GUI.skin.label);
                m_bodyStyle.fontStyle = FontStyle.Normal;
                m_bodyStyle.wordWrap = true;
            }

            if (m_editWrapStyle == null)
            {
                m_editWrapStyle = new GUIStyle(GUI.skin.textArea);
                m_editWrapStyle.wordWrap = true;
            }

            if (m_titleStyle == null)
            {
                m_titleStyle = new GUIStyle(m_bodyStyle);
                m_titleStyle.fontStyle = FontStyle.Bold;
                m_titleStyle.fontSize = 20;
            }

            if (m_headingStyle == null)
            {
                m_headingStyle = new GUIStyle(m_bodyStyle);
                m_headingStyle.fontStyle = FontStyle.Bold;
            }

            if (m_linkStyle == null)
            {
                m_linkStyle = new GUIStyle(m_bodyStyle);
                m_linkStyle.wordWrap = false;
                m_linkStyle.normal.textColor = new Color(0x00 / 255f, 0x78 / 255f, 0xDA / 255f, 1f);
                m_linkStyle.stretchWidth = false;
            }

            m_initialized = true;
        }

        /// <summary>
        /// Check and caclulate window adjustment for editor windows relative to scene & game view
        /// </summary>
        /// <param name="position"></param>
        /// <param name="maximized"></param>
        /// <returns></returns>
        public Rect CheckPosition(Rect position, bool maximized)
        {
            if (!m_positionChecked)
            {
                m_positionChecked = true;
                if (!maximized)
                {
                    //Get scene position
                    Rect scenePosition = new Rect(0f, 0f, 800f, 600f);
                    if (SceneView.lastActiveSceneView != null)
                    {
                        scenePosition = SceneView.lastActiveSceneView.position;
                    }
                    //Check our position
                    if (position.x < scenePosition.xMin || position.x > scenePosition.xMax)
                    {
                        position.x = scenePosition.xMin + (((scenePosition.xMax - scenePosition.xMin) / 2f) - (position.width / 2f));
                    }
                    if (position.y < scenePosition.yMin || position.y > scenePosition.yMax)
                    {
                        position.y = scenePosition.yMin + 100f;
                    }
                }
            }
            return position;
        }

        /// <summary>
        /// Draw the intro
        /// </summary>
        /// <param name="name">Name of the intro</param>
        /// <param name="description">Description</param>
        /// <param name="url">Make description clickable if supplied</param>
        public void DrawIntro(string name, string description = "", string url = "")
        {
            if (!m_initialized)
            {
                Initialize();
            }

            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            int majorVersion, minorVersion, patchVersion = 0;

            if (CTS.Internal.PWApp.CONF != null)
            {
                if (!Int32.TryParse(CTS.Internal.PWApp.CONF.MajorVersion, out majorVersion))
                {
                    Debug.LogWarning("Error when reading the CTS major version number!");
                }
                if (!Int32.TryParse(CTS.Internal.PWApp.CONF.MinorVersion, out minorVersion))
                {
                    Debug.LogWarning("Error when reading the CTS minor version number!");
                }
                if (!Int32.TryParse(CTS.Internal.PWApp.CONF.PatchVersion, out patchVersion))
                {
                    Debug.LogWarning("Error when reading the CTS patch version number!");
                }
            }
            else
            {
                majorVersion = CTSConstants.MajorVersion;
                minorVersion = CTSConstants.MinorVersion;
                patchVersion = CTSConstants.PatchVersion;
            }

            GUILayout.BeginVertical(string.Format("CTS ({0}.{1}.{2})", majorVersion, minorVersion, patchVersion), m_boxStyle);
            GUILayout.Label("");
            if (!string.IsNullOrEmpty(description))
            {
                if (string.IsNullOrEmpty(url))
                {
                    DrawBody(description);
                }
                else
                {
                    if (DrawClickableBody(description))
                    {
                        Application.OpenURL(url);
                    }
                }
            }
            GUILayout.EndVertical();
        }

        /// <summary>
        /// Display an image - the image must be of type editor & legacy gui to display
        /// </summary>
        /// <param name="image">The image</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public void DrawImage(Texture2D image, float width, float height)
        {
            GUILayout.Label(image, GUILayout.Width(width), GUILayout.Height(height));
        }

        /// <summary>
        /// Display text in title style
        /// </summary>
        /// <param name="text">Text to display</param>
        public void DrawTitle(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            if (!m_initialized)
            {
                Initialize();
            }
            GUILayout.Label(text, m_titleStyle);
        }

        /// <summary>
        /// Display text in header style
        /// </summary>
        /// <param name="text">Text to display</param>
        public void DrawHeader(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            if (!m_initialized)
            {
                Initialize();
            }
            GUILayout.Label(text, m_headingStyle);
        }

        /// <summary>
        /// Draw header text as clickable object
        /// </summary>
        /// <param name="text">Text to display</param>
        /// <param name="options">Display options</param>
        /// <returns>True if it was clicked</returns>
        public bool DrawClickableHeader(string text, params GUILayoutOption[] options)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            return DrawClickableHeader(GetLabel(text), options);
        }

        /// <summary>
        /// Draw header text as clickable object
        /// </summary>
        /// <param name="text">Text to display</param>
        /// <param name="options">Display options</param>
        /// <returns>True if it was clicked</returns>
        public bool DrawClickableHeader(GUIContent text, params GUILayoutOption[] options)
        {
            if (text == null)
            {
                return false;
            }
            if (!m_initialized)
            {
                Initialize();
            }
            var position = GUILayoutUtility.GetRect(text, m_headingStyle, options);
            Handles.BeginGUI();
            Color oldColor = Handles.color;
            Handles.color = m_headingStyle.normal.textColor;
            Handles.DrawLine(new Vector3(position.xMin, position.yMax), new Vector3(position.xMax, position.yMax));
            Handles.color = oldColor;
            Handles.EndGUI();
            EditorGUIUtility.AddCursorRect(position, MouseCursor.Link);
            return GUI.Button(position, text, m_headingStyle);
        }

        /// <summary>
        /// Display text in body style
        /// </summary>
        /// <param name="text"></param>
        public void DrawBody(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            GUILayout.Label(text, m_bodyStyle);
        }

        /// <summary>
        /// Draw clickable body text
        /// </summary>
        /// <param name="text">Text to display</param>
        /// <returns>True if it was clicked</returns>
        public bool DrawClickableBody(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            return DrawLinkBody(GetLabel(text));
        }

        /// <summary>
        /// Draw clickable link body
        /// </summary>
        /// <param name="text">Text to display</param>
        /// <param name="options">Options</param>
        /// <returns></returns>
        public bool DrawLinkBody(GUIContent text, params GUILayoutOption[] options)
        {
            if (text == null)
            {
                return false;
            }
            if (!m_initialized)
            {
                Initialize();
            }
            var position = GUILayoutUtility.GetRect(text, m_bodyStyle, options);
            EditorGUIUtility.AddCursorRect(position, MouseCursor.Link);
            return GUI.Button(position, text, m_bodyStyle);
        }

        /// <summary>
        /// Handy wrapper
        /// </summary>
        /// <param name="label"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public bool DrawLink(string label, params GUILayoutOption[] options)
        {
            if (string.IsNullOrEmpty(label))
            {
                return false;
            }
            return DrawLinkLabel(GetLabel(label), options);
        }

        /// <summary>
        /// Draw link label
        /// </summary>
        /// <param name="label">Label</param>
        /// <param name="options">Options</param>
        /// <returns></returns>
        public bool DrawLinkLabel(GUIContent label, params GUILayoutOption[] options)
        {
            if (label == null)
            {
                return false;
            }
            if (!m_initialized)
            {
                Initialize();
            }
            var position = GUILayoutUtility.GetRect(label, m_linkStyle, options);
            Handles.BeginGUI();
            Color oldColor = Handles.color;
            Handles.color = m_linkStyle.normal.textColor;
            Handles.DrawLine(new Vector3(position.xMin, position.yMax), new Vector3(position.xMax, position.yMax));
            Handles.color = oldColor;
            Handles.EndGUI();
            EditorGUIUtility.AddCursorRect(position, MouseCursor.Link);
            return GUI.Button(position, label, m_linkStyle);
        }

        /// <summary>
        /// Draw a body styled line at top of the rect provided
        /// </summary>
        /// <param name="rect"></param>
        public void DrawBodyLineTop(Rect rect)
        {
            Handles.BeginGUI();
            Color oldColor = Handles.color;
            Handles.color = m_bodyStyle.normal.textColor;
            Handles.DrawLine(new Vector3(rect.xMin, rect.y), new Vector3(rect.xMax, rect.y));
            Handles.color = oldColor;
            Handles.EndGUI();
        }

        /// <summary>
        /// Draw a body styled line at bottom of the rect provided
        /// </summary>
        /// <param name="rect"></param>
        public void DrawBodyLineBottom(Rect rect)
        {
            Handles.BeginGUI();
            Color oldColor = Handles.color;
            Handles.color = m_bodyStyle.normal.textColor;
            Handles.DrawLine(new Vector3(rect.xMin, rect.yMax), new Vector3(rect.xMax, rect.yMax));
            Handles.color = oldColor;
            Handles.EndGUI();
        }

        /// <summary>
        /// Draw a line in the space provided by the label
        /// </summary>
        /// <param name="label">Label - used for spacing / volume</param>
        /// <param name="options">Parameters - eg height / width</param>
        public void DrawBodyLine(GUIContent label, params GUILayoutOption[] options)
        {
            if (label == null)
            {
                return;
            }
            if (!m_initialized)
            {
                Initialize();
            }
            var position = GUILayoutUtility.GetRect(label, m_bodyStyle, options);
            Handles.BeginGUI();
            Color oldColor = Handles.color;
            Handles.color = m_bodyStyle.normal.textColor;
            Handles.DrawLine(new Vector3(position.xMin, position.y), new Vector3(position.xMax, position.y));
            Handles.color = oldColor;
            Handles.EndGUI();
        }

        /// <summary>
        /// Draw a button that takes editor indentation into account
        /// </summary>
        /// <param name="text">Text to display</param>
        /// <returns>True if clicked</returns>
        public bool DrawButton(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            return DrawButton(GetLabel(text));
        }

        /// <summary>
        /// Display a button that takes editor indentation into account
        /// </summary>
        /// <param name="content">Content to display</param>
        /// <returns>True is clicked</returns>
        public bool DrawButton(GUIContent content)
        {
            TextAnchor oldalignment = GUI.skin.button.alignment;
            GUI.skin.button.alignment = TextAnchor.MiddleLeft;
            Rect btnR = EditorGUILayout.BeginHorizontal();
            btnR.xMin += (EditorGUI.indentLevel * 18f);
            btnR.height += 20f;
            btnR.width -= 4f;
            bool result = GUI.Button(btnR, content);
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(22);
            GUI.skin.button.alignment = oldalignment;
            return result;
        }

        /// <summary>
        /// Get a content label
        /// </summary>
        /// <param name="name">Name of the label</param>
        /// <returns>Label</returns>
        public GUIContent GetLabel(string name)
        {
            return new GUIContent(name);
        }

        /// <summary>
        /// Get a content label - look the tooltip up if possible
        /// </summary>
        /// <param name="name">Name of thing</param>
        /// <param name="tooltips">Tooltips of things</param>
        /// <returns>Content plus tool tip if it exists</returns>
        public GUIContent GetLabel(string name, Dictionary<string, string> tooltips)
        {
            string tooltip = "";
            if (tooltips.TryGetValue(name, out tooltip))
            {
                return new GUIContent(name, tooltip);
            }
            else
            {
                return new GUIContent(name);
            }
        }

        /// <summary>
        /// Compress / encode a multi layer map file to an image
        /// </summary>
        /// <param name="input">Multi layer map in format x,y,layer</param>
        /// <param name="imageName">Output image name - image image index and extension will be added</param>
        /// <param name="exportPNG">True if a png is wanted</param>
        /// <param name="exportJPG">True if a jpg is wanted</param>
        public static void CompressToMultiChannelFileImage(float[,,] input, string imageName, TextureFormat imageStorageFormat = TextureFormat.RGBA32, bool exportPNG = true, bool exportJPG = true)
        {
            int width = input.GetLength(0);
            int height = input.GetLength(1);
            int layers = input.GetLength(2);
            int images = (layers + 3) / 4;

            for (int image = 0; image < images; image++)
            {
                Texture2D exportTexture = new Texture2D(width, width, imageStorageFormat, false);
                Color pixelColor = new Color();
                int layer = image * 4;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        pixelColor.r = layer < layers ? input[x, y, layer] : 0f;
                        pixelColor.g = (layer + 1) < layers ? input[x, y, (layer + 1)] : 0f;
                        pixelColor.b = (layer + 2) < layers ? input[x, y, (layer + 2)] : 0f;
                        pixelColor.a = (layer + 3) < layers ? input[x, y, (layer + 3)] : 0f;

                        //The x and y switch here is itentional - not sure why but else the result will be flipped on export
                        exportTexture.SetPixel(y, x, pixelColor);
                    }
                }
                exportTexture.Apply();

                // Write JPG
                if (exportJPG)
                {
                    byte[] jpgBytes = exportTexture.EncodeToJPG();
                    WriteAllBytes(imageName + image + ".jpg", jpgBytes);
                }

                // Write PNG
                if (exportPNG)
                {
                    byte[] pngBytes = exportTexture.EncodeToPNG();
                    WriteAllBytes(imageName + image + ".png", pngBytes);
                }

                //Lose the texture
                exportTexture = null;
                //DestroyImmediate(exportTexture);
            }
        }

        /// <summary>
        /// Write the byte array to the supplied file
        /// </summary>
        /// <param name="path">File to write</param>
        /// <param name="bytes">Byte array to write</param>
        public static void WriteAllBytes(string path, byte[] bytes)
        {
            using (Stream stream = File.Create(path))
            {
                stream.Write(bytes, 0, bytes.Length);
            }
        }

        public static Texture2D GetColorChannelTexture(Texture2D inputTexture, CTSConstants.TextureChannel channel)
        {
            Texture2D outputTexture = new Texture2D(inputTexture.width, inputTexture.height);
            Color32[] originalColors = inputTexture.GetPixels32();
            Color32[] targetColors = new Color32[originalColors.Length];
            for (int i = 0; i < originalColors.Length; i++)
            {
                //create a new Color for the target image by copying only the desired value over in the rgb-channels.
                switch(channel)
                {
                    case CTSConstants.TextureChannel.R:
                        targetColors[i] = new Color32(originalColors[i].r, 0, 0, 0);
                    break;
                    case CTSConstants.TextureChannel.G:
                        targetColors[i] = new Color32(0, originalColors[i].g, 0, 0);
                    break;
                    case CTSConstants.TextureChannel.B:
                        targetColors[i] = new Color32(0, 0, originalColors[i].b, 0);
                    break;
                    case CTSConstants.TextureChannel.A:
                        targetColors[i] = new Color32(0, 0, 0, originalColors[i].a);
                    break;
                }

               
            }
            outputTexture.name = inputTexture.name + "_" + channel.ToString();
            outputTexture.SetPixels32(targetColors);
            outputTexture.Apply();
            return outputTexture;
        }


        /// <summary>
        /// Get the text of the content indexed by name, or the name if not found
        /// </summary>
        /// <param name="name">Name to search for</param>
        /// <param name="tooltips">Toolips dictionary</param>
        /// <returns></returns>
        public string GetLabelText(string name, Dictionary<string, string> tooltips)
        {
            string tooltip = "";
            if (tooltips.TryGetValue(name, out tooltip))
            {
                return tooltip;
            }
            else
            {
                return name;
            }
        }
        #endregion
    }
}
