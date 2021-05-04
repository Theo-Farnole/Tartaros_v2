using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace CTS
{
    /// <summary>
    /// Shader ID's. Shader ID's are an efficient way to locate and change CTS shader values.
    /// </summary>
    public static class CTSShaderID
    {
        public static readonly int Texture_Array_Albedo;
        public static readonly int Texture_Array_Normal;
        public static readonly int Texture_Splat_1;
        public static readonly int Texture_Splat_2;
        public static readonly int Texture_Splat_3;
        public static readonly int Texture_Splat_4;
        public static readonly int UV_Mix_Power;
        public static readonly int UV_Mix_Start_Distance;
        public static readonly int Perlin_Normal_Tiling_Close;
        public static readonly int Perlin_Normal_Tiling_Far;
        public static readonly int Perlin_Normal_Power;
        public static readonly int Perlin_Normal_Power_Close;
        public static readonly int Terrain_Smoothness;
        public static readonly int Terrain_Specular;
        public static readonly int TessValue;
        public static readonly int TessMin;
        public static readonly int TessMax;
        public static readonly int TessPhongStrength;
        public static readonly int TessDistance;
        public static readonly int Ambient_Occlusion_Type;
        public static readonly int Remove_Vert_Height;
        public static readonly int Terrain_Holes_Texture;
        public static readonly int Use_AO;
        public static readonly int Use_AO_Texture;
        public static readonly int Ambient_Occlusion_Power;
        public static readonly int Texture_Perlin_Normal_Index;
        public static readonly int Global_Normalmap_Power;
        public static readonly int Global_Normal_Map;
        public static readonly int Global_Color_Map_Far_Power;
        public static readonly int Global_Color_Map_Close_Power;
        public static readonly int Global_Color_Opacity_Power;
        public static readonly int Global_Color_Map;
        public static readonly int Geological_Map_Offset_Close;
        public static readonly int Geological_Map_Close_Power;
        public static readonly int Geological_Tiling_Close;
        public static readonly int Geological_Map_Offset_Far;
        public static readonly int Geological_Map_Far_Power;
        public static readonly int Geological_Tiling_Far;
        public static readonly int Texture_Geological_Map;
        public static readonly int Texture_Snow_Index;
        public static readonly int Texture_Snow_Normal_Index;
        public static readonly int Texture_Snow_H_AO_Index;
        public static readonly int Snow_Amount;
        public static readonly int Snow_Maximum_Angle;
        public static readonly int Snow_Maximum_Angle_Hardness;
        public static readonly int Snow_Min_Height;
        public static readonly int Snow_Min_Height_Blending;
        public static readonly int Snow_Noise_Power;
        public static readonly int Snow_Noise_Tiling;
        public static readonly int Snow_Normal_Scale;
        public static readonly int Snow_Perlin_Power;
        public static readonly int Snow_Tiling;
        public static readonly int Snow_Tiling_Far_Multiplier;
        public static readonly int Snow_Brightness;
        public static readonly int Snow_Blend_Normal;
        public static readonly int Snow_Smoothness;
        public static readonly int Snow_Specular;
        public static readonly int Snow_Heightblend_Close;
        public static readonly int Snow_Heightblend_Far;
        public static readonly int Snow_Height_Contrast;
        public static readonly int Snow_Heightmap_Depth;
        public static readonly int Snow_Heightmap_MinHeight;
        public static readonly int Snow_Heightmap_MaxHeight;
        public static readonly int Snow_Ambient_Occlusion_Power;
        public static readonly int Snow_Tesselation_Depth;
        public static readonly int Snow_Color;
        public static readonly int Texture_Snow_Average;
        public static readonly int Texture_Glitter;
        public static readonly int Glitter_Color_Power;
        public static readonly int Glitter_Noise_Threshold;
        public static readonly int Glitter_Specular;
        public static readonly int Glitter_Smoothness;
        public static readonly int Glitter_Refreshing_Speed;
        public static readonly int Glitter_Tiling;
        public static readonly int[] Texture_X_Albedo_Index;
        public static readonly int[] Texture_X_Normal_Index;
        public static readonly int[] Texture_X_H_AO_Index;
        public static readonly int[] Texture_X_Tiling;
        public static readonly int[] Texture_X_Far_Multiplier;
        public static readonly int[] Texture_X_Perlin_Power;
        public static readonly int[] Texture_X_Snow_Reduction;
        public static readonly int[] Texture_X_Geological_Power;
        public static readonly int[] Texture_X_Heightmap_Depth;
        public static readonly int[] Texture_X_Height_Contrast;
        public static readonly int[] Texture_X_Heightblend_Close;
        public static readonly int[] Texture_X_Heightblend_Far;
        public static readonly int[] Texture_X_Tesselation_Depth;
        public static readonly int[] Texture_X_Heightmap_MinHeight;
        public static readonly int[] Texture_X_Heightmap_MaxHeight;
        public static readonly int[] Texture_X_AO_Power;
        public static readonly int[] Texture_X_Normal_Power;
        public static readonly int[] Texture_X_Triplanar;
        public static readonly int[] Texture_X_Average;
        public static readonly int[] Texture_X_Color;

        static CTSShaderID()
        {
            Texture_Array_Albedo = Shader.PropertyToID("_Texture_Array_Albedo");
            Texture_Array_Normal = Shader.PropertyToID("_Texture_Array_Normal");
            Texture_Splat_1 = Shader.PropertyToID("_Texture_Splat_1");
            Texture_Splat_2 = Shader.PropertyToID("_Texture_Splat_2");
            Texture_Splat_3 = Shader.PropertyToID("_Texture_Splat_3");
            Texture_Splat_4 = Shader.PropertyToID("_Texture_Splat_4");
            UV_Mix_Power = Shader.PropertyToID("_UV_Mix_Power");
            UV_Mix_Start_Distance = Shader.PropertyToID("_UV_Mix_Start_Distance");
            Perlin_Normal_Tiling_Close = Shader.PropertyToID("_Perlin_Normal_Tiling_Close");
            Perlin_Normal_Tiling_Far = Shader.PropertyToID("_Perlin_Normal_Tiling_Far");
            Perlin_Normal_Power = Shader.PropertyToID("_Perlin_Normal_Power");
            Perlin_Normal_Power_Close = Shader.PropertyToID("_Perlin_Normal_Power_Close");
            Terrain_Smoothness = Shader.PropertyToID("_Terrain_Smoothness");
            Terrain_Specular = Shader.PropertyToID("_Terrain_Specular");
            TessValue = Shader.PropertyToID("_TessValue");
            TessMin = Shader.PropertyToID("_TessMin");
            TessMax = Shader.PropertyToID("_TessMax");
            TessPhongStrength = Shader.PropertyToID("_TessPhongStrength");
            TessDistance = Shader.PropertyToID("_TessDistance");
            Ambient_Occlusion_Type = Shader.PropertyToID("_Ambient_Occlusion_Type");
            Remove_Vert_Height = Shader.PropertyToID("_Remove_Vert_Height");
            Terrain_Holes_Texture = Shader.PropertyToID("_TerrainHolesTexture");
            Use_AO = Shader.PropertyToID("_Use_AO");
            Use_AO_Texture = Shader.PropertyToID("_Use_AO_Texture");
            Ambient_Occlusion_Power = Shader.PropertyToID("_Ambient_Occlusion_Power");
            Texture_Perlin_Normal_Index = Shader.PropertyToID("_Texture_Perlin_Normal_Index");
            Global_Normalmap_Power = Shader.PropertyToID("_Global_Normalmap_Power");
            Global_Normal_Map = Shader.PropertyToID("_Global_Normal_Map");
            Global_Color_Map_Far_Power = Shader.PropertyToID("_Global_Color_Map_Far_Power");
            Global_Color_Map_Close_Power = Shader.PropertyToID("_Global_Color_Map_Close_Power");
            Global_Color_Opacity_Power = Shader.PropertyToID("_Global_Color_Opacity_Power");
            Global_Color_Map = Shader.PropertyToID("_Global_Color_Map");
            Geological_Map_Offset_Close = Shader.PropertyToID("_Geological_Map_Offset_Close");
            Geological_Map_Close_Power = Shader.PropertyToID("_Geological_Map_Close_Power");
            Geological_Tiling_Close = Shader.PropertyToID("_Geological_Tiling_Close");
            Geological_Map_Offset_Far = Shader.PropertyToID("_Geological_Map_Offset_Far");
            Geological_Map_Far_Power = Shader.PropertyToID("_Geological_Map_Far_Power");
            Geological_Tiling_Far = Shader.PropertyToID("_Geological_Tiling_Far");
            Texture_Geological_Map = Shader.PropertyToID("_Texture_Geological_Map");
            Texture_Snow_Index = Shader.PropertyToID("_Texture_Snow_Index");
            Texture_Snow_Normal_Index = Shader.PropertyToID("_Texture_Snow_Normal_Index");
            Texture_Snow_H_AO_Index = Shader.PropertyToID("_Texture_Snow_H_AO_Index");
            Snow_Amount = Shader.PropertyToID("_Snow_Amount");
            Snow_Maximum_Angle = Shader.PropertyToID("_Snow_Maximum_Angle");
            Snow_Maximum_Angle_Hardness = Shader.PropertyToID("_Snow_Maximum_Angle_Hardness");
            Snow_Min_Height = Shader.PropertyToID("_Snow_Min_Height");
            Snow_Min_Height_Blending = Shader.PropertyToID("_Snow_Min_Height_Blending");
            Snow_Noise_Power = Shader.PropertyToID("_Snow_Noise_Power");
            Snow_Noise_Tiling = Shader.PropertyToID("_Snow_Noise_Tiling");
            Snow_Normal_Scale = Shader.PropertyToID("_Snow_Normal_Scale");
            Snow_Perlin_Power = Shader.PropertyToID("_Snow_Perlin_Power");
            Snow_Tiling = Shader.PropertyToID("_Snow_Tiling");
            Snow_Tiling_Far_Multiplier = Shader.PropertyToID("_Snow_Tiling_Far_Multiplier");
            Snow_Brightness = Shader.PropertyToID("_Snow_Brightness");
            Snow_Blend_Normal = Shader.PropertyToID("_Snow_Blend_Normal");
            Snow_Smoothness = Shader.PropertyToID("_Snow_Smoothness");
            Snow_Specular = Shader.PropertyToID("_Snow_Specular");
            Snow_Heightblend_Close = Shader.PropertyToID("_Snow_Heightblend_Close");
            Snow_Heightblend_Far = Shader.PropertyToID("_Snow_Heightblend_Far");
            Snow_Height_Contrast = Shader.PropertyToID("_Snow_Height_Contrast");
            Snow_Heightmap_Depth = Shader.PropertyToID("_Snow_Heightmap_Depth");
            Snow_Heightmap_MinHeight = Shader.PropertyToID("_Snow_Heightmap_MinHeight");
            Snow_Heightmap_MaxHeight = Shader.PropertyToID("_Snow_Heightmap_MaxHeight");
            Snow_Ambient_Occlusion_Power = Shader.PropertyToID("_Snow_Ambient_Occlusion_Power");
            Snow_Tesselation_Depth = Shader.PropertyToID("_Snow_Tesselation_Depth");
            Snow_Color = Shader.PropertyToID("_Snow_Color");
            Texture_Snow_Average = Shader.PropertyToID("_Texture_Snow_Average");
            Texture_Glitter = Shader.PropertyToID("_Texture_Glitter");
            Glitter_Color_Power = Shader.PropertyToID("_Gliter_Color_Power");
            Glitter_Noise_Threshold = Shader.PropertyToID("_Glitter_Noise_Treshold");
            Glitter_Specular = Shader.PropertyToID("_Glitter_Specular");
            Glitter_Smoothness = Shader.PropertyToID("_Glitter_Smoothness");
            Glitter_Refreshing_Speed = Shader.PropertyToID("_Glitter_Refreshing_Speed");
            Glitter_Tiling = Shader.PropertyToID("_Glitter_Tiling");
            Texture_X_Albedo_Index = new int[16];
            Texture_X_Normal_Index = new int[16];
            Texture_X_H_AO_Index = new int[16];
            Texture_X_Tiling = new int[16];
            Texture_X_Far_Multiplier = new int[16];
            Texture_X_Perlin_Power = new int[16];
            Texture_X_Snow_Reduction = new int[16];
            Texture_X_Geological_Power = new int[16];
            Texture_X_Heightmap_Depth = new int[16];
            Texture_X_Height_Contrast = new int[16];
            Texture_X_Heightblend_Close = new int[16];
            Texture_X_Heightblend_Far = new int[16];
            Texture_X_Tesselation_Depth = new int[16];
            Texture_X_Heightmap_MinHeight = new int[16];
            Texture_X_Heightmap_MaxHeight = new int[16];
            Texture_X_AO_Power = new int[16];
            Texture_X_Normal_Power = new int[16];
            Texture_X_Triplanar = new int[16];
            Texture_X_Average = new int[16];
            Texture_X_Color = new int[16];

            for (int i = 1; i <= 16; i++)
            {
                Texture_X_Albedo_Index[i - 1] = Shader.PropertyToID(string.Format("_Texture_{0}_Albedo_Index", i));
                Texture_X_Normal_Index[i - 1] = Shader.PropertyToID(string.Format("_Texture_{0}_Normal_Index", i));
                Texture_X_H_AO_Index[i - 1] = Shader.PropertyToID(string.Format("_Texture_{0}_H_AO_Index", i));
                Texture_X_Tiling[i - 1] = Shader.PropertyToID(string.Format("_Texture_{0}_Tiling", i));
                Texture_X_Far_Multiplier[i - 1] = Shader.PropertyToID(string.Format("_Texture_{0}_Far_Multiplier", i));
                Texture_X_Perlin_Power[i - 1] = Shader.PropertyToID(string.Format("_Texture_{0}_Perlin_Power", i));
                Texture_X_Snow_Reduction[i - 1] = Shader.PropertyToID(string.Format("_Texture_{0}_Snow_Reduction", i));
                Texture_X_Geological_Power[i - 1] =
                    Shader.PropertyToID(string.Format("_Texture_{0}_Geological_Power", i));
                Texture_X_Heightmap_Depth[i - 1] =
                    Shader.PropertyToID(string.Format("_Texture_{0}_Heightmap_Depth", i));
                Texture_X_Height_Contrast[i - 1] =
                    Shader.PropertyToID(string.Format("_Texture_{0}_Height_Contrast", i));
                Texture_X_Heightblend_Close[i - 1] =
                    Shader.PropertyToID(string.Format("_Texture_{0}_Heightblend_Close", i));
                Texture_X_Heightblend_Far[i - 1] =
                    Shader.PropertyToID(string.Format("_Texture_{0}_Heightblend_Far", i));
                Texture_X_Tesselation_Depth[i - 1] =
                    Shader.PropertyToID(string.Format("_Texture_{0}_Tesselation_Depth", i));
                Texture_X_Heightmap_MinHeight[i - 1] =
                    Shader.PropertyToID(string.Format("_Texture_{0}_Heightmap_MinHeight", i));
                Texture_X_Heightmap_MaxHeight[i - 1] =
                    Shader.PropertyToID(string.Format("_Texture_{0}_Heightmap_MaxHeight", i));
                Texture_X_AO_Power[i - 1] = Shader.PropertyToID(string.Format("_Texture_{0}_AO_Power", i));
                Texture_X_Normal_Power[i - 1] = Shader.PropertyToID(string.Format("_Texture_{0}_Normal_Power", i));
                Texture_X_Triplanar[i - 1] = Shader.PropertyToID(string.Format("_Texture_{0}_Triplanar", i));
                Texture_X_Average[i - 1] = Shader.PropertyToID(string.Format("_Texture_{0}_Average", i));
                Texture_X_Color[i - 1] = Shader.PropertyToID(string.Format("_Texture_{0}_Color", i));
            }
        }
    }
}