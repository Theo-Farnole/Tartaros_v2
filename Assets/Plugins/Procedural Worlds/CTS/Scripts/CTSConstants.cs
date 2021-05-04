using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CTS
{
    /// <summary>
    /// CTS Constants
    /// </summary>
    public static class CTSConstants
    {
        /// <summary>
        /// Version information
        /// </summary>
        public static readonly int MajorVersion = 2019;
        public static readonly int MinorVersion = 1;
        public static readonly int PatchVersion = 6;

        /// <summary>
        /// CTS Present define
        /// </summary>
        public static readonly string CTSPresentSymbol = "CTS_PRESENT";

        /// <summary>
        /// The shader being used
        /// </summary>
        public enum ShaderType { Unity, Basic, Advanced, Tesselation, Lite }

        /// <summary>
        /// Special Feature variants of a shader        
        /// /// </summary>
        public enum ShaderFeatureSet { None, Cutout }


        /// <summary>
        /// The render pipeline we are targeting
        /// </summary>
        public enum EnvironmentRenderer { BuiltIn, LightWeight, HighDefinition, Universal }

        /// <summary>
        /// Dictionary for all possible shader name strings, accessible by their criteria
        /// </summary>
        public static readonly Dictionary<CTSShaderCriteria, string> shaderNames = new Dictionary<CTSShaderCriteria, string>()
        {
            { new CTSShaderCriteria(EnvironmentRenderer.BuiltIn, ShaderType.Basic, ShaderFeatureSet.None), "CTS/CTS Terrain Shader Basic" },
            { new CTSShaderCriteria(EnvironmentRenderer.BuiltIn, ShaderType.Basic, ShaderFeatureSet.Cutout),"CTS/CTS Terrain Shader Basic CutOut" },
            { new CTSShaderCriteria(EnvironmentRenderer.BuiltIn, ShaderType.Advanced, ShaderFeatureSet.None), "CTS/CTS Terrain Shader Advanced" },
            { new CTSShaderCriteria(EnvironmentRenderer.BuiltIn, ShaderType.Advanced, ShaderFeatureSet.Cutout), "CTS/CTS Terrain Shader Advanced CutOut" },
            { new CTSShaderCriteria(EnvironmentRenderer.BuiltIn, ShaderType.Tesselation, ShaderFeatureSet.None), "CTS/CTS Terrain Shader Advanced Tess" },
            { new CTSShaderCriteria(EnvironmentRenderer.BuiltIn, ShaderType.Tesselation, ShaderFeatureSet.Cutout), "CTS/CTS Terrain Shader Advanced Tess CutOut" },
            { new CTSShaderCriteria(EnvironmentRenderer.BuiltIn, ShaderType.Lite, ShaderFeatureSet.None), "CTS/CTS Terrain Shader Lite" },
            { new CTSShaderCriteria(EnvironmentRenderer.LightWeight, ShaderType.Basic, ShaderFeatureSet.None), "CTS/LWRP/CTS Terrain Shader Basic" },
            { new CTSShaderCriteria(EnvironmentRenderer.LightWeight, ShaderType.Basic, ShaderFeatureSet.Cutout),"CTS/LWRP/CTS Terrain Shader Basic CutOut" },
            { new CTSShaderCriteria(EnvironmentRenderer.LightWeight, ShaderType.Advanced, ShaderFeatureSet.None), "CTS/LWRP/CTS Terrain Shader Advanced" },
            { new CTSShaderCriteria(EnvironmentRenderer.LightWeight, ShaderType.Advanced, ShaderFeatureSet.Cutout), "CTS/LWRP/CTS Terrain Shader Advanced CutOut" },
            { new CTSShaderCriteria(EnvironmentRenderer.LightWeight, ShaderType.Lite, ShaderFeatureSet.None), "CTS/LWRP/CTS Terrain Shader Lite" },
            { new CTSShaderCriteria(EnvironmentRenderer.HighDefinition, ShaderType.Basic, ShaderFeatureSet.None), "CTS/HDRP/CTS Terrain Shader Basic" },
            { new CTSShaderCriteria(EnvironmentRenderer.HighDefinition, ShaderType.Basic, ShaderFeatureSet.Cutout),"CTS/HDRP/CTS Terrain Shader Basic CutOut" },
            { new CTSShaderCriteria(EnvironmentRenderer.HighDefinition, ShaderType.Advanced, ShaderFeatureSet.None), "CTS/HDRP/CTS Terrain Shader Advanced" },
            { new CTSShaderCriteria(EnvironmentRenderer.HighDefinition, ShaderType.Advanced, ShaderFeatureSet.Cutout), "CTS/HDRP/CTS Terrain Shader Advanced CutOut" },
            { new CTSShaderCriteria(EnvironmentRenderer.HighDefinition, ShaderType.Lite, ShaderFeatureSet.None), "CTS/HDRP/CTS Terrain Shader Lite" },
            { new CTSShaderCriteria(EnvironmentRenderer.Universal, ShaderType.Basic, ShaderFeatureSet.None), "CTS/URP/CTS Terrain Shader Basic" },
            { new CTSShaderCriteria(EnvironmentRenderer.Universal, ShaderType.Basic, ShaderFeatureSet.Cutout),"CTS/URP/CTS Terrain Shader Basic CutOut" },
            { new CTSShaderCriteria(EnvironmentRenderer.Universal, ShaderType.Advanced, ShaderFeatureSet.None), "CTS/URP/CTS Terrain Shader Advanced" },
            { new CTSShaderCriteria(EnvironmentRenderer.Universal, ShaderType.Advanced, ShaderFeatureSet.Cutout), "CTS/URP/CTS Terrain Shader Advanced CutOut" },
            { new CTSShaderCriteria(EnvironmentRenderer.Universal, ShaderType.Lite, ShaderFeatureSet.None), "CTS/URP/CTS Terrain Shader Lite" }
        };

        


        /// <summary>
        /// Names of the various shaders
        /// </summary>
        public const string CTSShaderName = "CTS/CTS Terrain";
        public const string CTSShaderMeshBlenderName = "CTS/CTS_Model_Blend";
        public const string CTSShaderMeshBlenderAdvancedName = "CTS/CTS_Model_Blend_Advanced";
        //public const string CTSShaderLiteName = "CTS/CTS Terrain Shader Lite";
        //public const string CTSShaderBasicName = "CTS/CTS Terrain Shader Basic";
        //public const string CTSShaderBasicCutoutName = "CTS/CTS Terrain Shader Basic CutOut";
        //public const string CTSShaderAdvancedName = "CTS/CTS Terrain Shader Advanced";
        //public const string CTSShaderAdvancedCutoutName = "CTS/CTS Terrain Shader Advanced CutOut";
        //public const string CTSShaderTesselatedName = "CTS/CTS Terrain Shader Advanced Tess";
        //public const string CTSShaderTesselatedCutoutName = "CTS/CTS Terrain Shader Advanced Tess CutOut";

        /// <summary>
        /// The shader mode being used
        /// </summary>
        public enum ShaderMode { DesignTime, RunTime }

        /// <summary>
        /// Occlusion Type being used
        /// </summary>
        public enum AOType { None, NormalMapBased, TextureBased}

        /// <summary>
        /// The size of the textures that will be used to generate atlases
        /// </summary>
        public enum TextureSize { Texture_64, Texture_128, Texture_256, Texture_512, Texture_1024, Texture_2048, Texture_4096, Texture_8192 }

        /// <summary>
        /// Get the size of the texture
        /// </summary>
        /// <param name="size">Texture size</param>
        /// <returns>Texture size or zero if invalid</returns>
        public static int GetTextureSize(TextureSize size)
        {
            switch (size)
            {
                case CTSConstants.TextureSize.Texture_64:
                    return 64;
                case CTSConstants.TextureSize.Texture_128:
                    return 128;
                case CTSConstants.TextureSize.Texture_256:
                    return 256;
                case CTSConstants.TextureSize.Texture_512:
                    return 512;
                case CTSConstants.TextureSize.Texture_1024:
                    return 1024;
                case CTSConstants.TextureSize.Texture_2048:
                    return 2048;
                case CTSConstants.TextureSize.Texture_4096:
                    return 4096;
                case CTSConstants.TextureSize.Texture_8192:
                    return 8192;
            }
            //Invalid setting passed in
            return 0;
        }

        /// <summary>
        /// Texture types
        /// </summary>
        public enum TextureType { Albedo, Normal, AmbientOcclusion, Height, Splat, Emission }

        /// <summary>
        /// Texture channels
        /// </summary>
        public enum TextureChannel { R, G, B, A }

        /// <summary>
        /// Flags used to decipher terrain changes
        /// </summary>
        [Flags]
        public enum TerrainChangedFlags
        {
            NoChange = 0,
            Heightmap = 1 << 0,
            TreeInstances = 1 << 1,
            DelayedHeightmapUpdate = 1 << 2,
            FlushEverythingImmediately = 1 << 3,
            RemoveDirtyDetailsImmediately = 1 << 4,
            WillBeDestroyed = 1 << 8,
        }


        /// <summary>
        /// List for common compression formats for Windows, Linux, macOs, PS4, XBoxOne.
        /// Used in the recommendedTextureFormats dictionary.
        /// </summary>
        public static readonly List<TextureFormat> desktopAndConsoleFormats = new List<TextureFormat>()
        {
            TextureFormat.RGB24,
            TextureFormat.RGBA32,
            TextureFormat.RGBAHalf,
            TextureFormat.DXT1,
            TextureFormat.DXT5,
            TextureFormat.BC6H,
            TextureFormat.BC7,
        };


#if UNITY_EDITOR

        /// <summary>
        /// Dictionary for all recommended texture compression formats for a certain build target.
        /// Source: https://docs.unity3d.com/Manual/class-TextureImporterOverride.html
        /// </summary>
        public static readonly Dictionary<BuildTarget, List<TextureFormat>> recommendedTextureFormats = new Dictionary<BuildTarget, List<TextureFormat>>()
        {
            {BuildTarget.Android, new List<TextureFormat>{TextureFormat.RGB24,
                                                          TextureFormat.RGBA32,
                                                          TextureFormat.ETC2_RGB,
                                                          TextureFormat.ETC2_RGBA1,
                                                          TextureFormat.ETC2_RGBA8,
                                                          TextureFormat.ETC_RGB4
                                                          } },

            {BuildTarget.iOS, new List<TextureFormat>{  TextureFormat.RGB24,
                                                        TextureFormat.RGBA32,
                                                        TextureFormat.PVRTC_RGB2,
                                                        TextureFormat.PVRTC_RGB4,
                                                        TextureFormat.PVRTC_RGBA2,
                                                        TextureFormat.PVRTC_RGBA4
                                                          } },
#if UNITY_2017_3_OR_NEWER
            {BuildTarget.StandaloneOSX, desktopAndConsoleFormats },
#endif
            {BuildTarget.PS4, desktopAndConsoleFormats },
#if !UNITY_2019_2_OR_NEWER
            {BuildTarget.StandaloneLinux, desktopAndConsoleFormats },
#endif
            {BuildTarget.StandaloneLinux64, desktopAndConsoleFormats },
#if !UNITY_2019_2_OR_NEWER
            {BuildTarget.StandaloneLinuxUniversal, desktopAndConsoleFormats },
#endif
            {BuildTarget.StandaloneWindows, desktopAndConsoleFormats },
            {BuildTarget.StandaloneWindows64, desktopAndConsoleFormats },

            {BuildTarget.tvOS, new List<TextureFormat>{   TextureFormat.RGB24,
                                                          TextureFormat.RGBA32,
                                                          //RGBAHalf = RGBA 16 bit
                                                          TextureFormat.RGBAHalf,
                                                          TextureFormat.ASTC_RGB_4x4,
                                                          TextureFormat.ASTC_RGB_6x6,
                                                          TextureFormat.ASTC_RGB_8x8,
                                                          TextureFormat.ASTC_RGBA_4x4,
                                                          TextureFormat.ASTC_RGBA_6x6,
                                                          TextureFormat.ASTC_RGBA_8x8,
                                                          } },

            {BuildTarget.WebGL, new List<TextureFormat>{  TextureFormat.RGB24,
                                                          TextureFormat.RGBA32,
                                                          //RGBAHalf = RGBA 16 bit
                                                          TextureFormat.DXT1,
                                                          TextureFormat.DXT5
                                                          } },

        };
#endif


        }
}

