 Shader "CTS/CTS Terrain Shader Advanced LOD CutOut"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_Geological_Tiling_Far("Geological_Tiling_Far", Range( 0 , 1000)) = 87
		_Geological_Map_Offset_Far("Geological_Map_Offset _Far", Range( 0 , 1)) = 1
		_Geological_Map_Far_Power("Geological_Map_Far_Power", Range( 0 , 2)) = 1
		_Global_Color_Map_Far_Power("Global_Color_Map_Far_Power", Range( 0 , 10)) = 5
		_Perlin_Normal_Tiling_Far("Perlin_Normal_Tiling_Far", Range( 0.01 , 1000)) = 40
		_Perlin_Normal_Power("Perlin_Normal_Power", Range( 0 , 2)) = 1
		_Global_Color_Opacity_Power("Global_Color_Opacity_Power", Range( 0 , 1)) = 0
		_Terrain_Smoothness("Terrain_Smoothness", Range( 0 , 2)) = 1
		_Terrain_Specular("Terrain_Specular", Range( 0 , 3)) = 1
		_Global_Normalmap_Power("Global_Normalmap_Power", Range( 0 , 10)) = 0
		_Texture_1_Tiling("Texture_1_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_2_Tiling("Texture_2_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_3_Tiling("Texture_3_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_4_Tiling("Texture_4_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_5_Tiling("Texture_5_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_6_Tiling("Texture_6_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_7_Tiling("Texture_7_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_8_Tiling("Texture_8_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_9_Tiling("Texture_9_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_10_Tiling("Texture_10_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_11_Tiling("Texture_11_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_12_Tiling("Texture_12_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_13_Tiling("Texture_13_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_14_Tiling("Texture_14_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_15_Tiling("Texture_15_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_16_Tiling("Texture_16_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_1_Far_Multiplier("Texture_1_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_2_Far_Multiplier("Texture_2_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_3_Far_Multiplier("Texture_3_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_4_Far_Multiplier("Texture_4_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_5_Far_Multiplier("Texture_5_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_6_Far_Multiplier("Texture_6_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_7_Far_Multiplier("Texture_7_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_8_Far_Multiplier("Texture_8_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_9_Far_Multiplier("Texture_9_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_10_Far_Multiplier("Texture_10_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_11_Far_Multiplier("Texture_11_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_12_Far_Multiplier("Texture_12_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_13_Far_Multiplier("Texture_13_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_14_Far_Multiplier("Texture_14_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_15_Far_Multiplier("Texture_15_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_16_Far_Multiplier("Texture_16_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_1_Perlin_Power("Texture_1_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_2_Perlin_Power("Texture_2_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_3_Perlin_Power("Texture_3_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_4_Perlin_Power("Texture_4_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_5_Perlin_Power("Texture_5_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_6_Perlin_Power("Texture_6_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_7_Perlin_Power("Texture_7_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_8_Perlin_Power("Texture_8_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_9_Perlin_Power("Texture_9_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_10_Perlin_Power("Texture_10_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_11_Perlin_Power("Texture_11_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_12_Perlin_Power("Texture_12_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_13_Perlin_Power("Texture_13_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_14_Perlin_Power("Texture_14_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_15_Perlin_Power("Texture_15_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_16_Perlin_Power("Texture_16_Perlin_Power", Range( 0 , 2)) = 0
		_Snow_Heightmap_Depth("Snow_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_14_Heightmap_Depth("Texture_14_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_13_Heightmap_Depth("Texture_13_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_11_Heightmap_Depth("Texture_11_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_15_Heightmap_Depth("Texture_15_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_16_Heightmap_Depth("Texture_16_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_12_Heightmap_Depth("Texture_12_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_6_Heightmap_Depth("Texture_6_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_10_Heightmap_Depth("Texture_10_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_9_Heightmap_Depth("Texture_9_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_5_Heightmap_Depth("Texture_5_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_7_Heightmap_Depth("Texture_7_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_Array_Normal("Texture_Array_Normal", 2DArray ) = "" {}
		_Texture_3_Heightmap_Depth("Texture_3_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_8_Heightmap_Depth("Texture_8_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_4_Heightmap_Depth("Texture_4_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_2_Heightmap_Depth("Texture_2_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_1_Heightmap_Depth("Texture_1_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_1_Height_Contrast("Texture_1_Height_Contrast", Range( 0 , 10)) = 1
		_Snow_Height_Contrast("Snow_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_14_Height_Contrast("Texture_14_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_16_Height_Contrast("Texture_16_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_15_Height_Contrast("Texture_15_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_9_Height_Contrast("Texture_9_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_13_Height_Contrast("Texture_13_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_10_Height_Contrast("Texture_10_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_11_Height_Contrast("Texture_11_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_12_Height_Contrast("Texture_12_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_6_Height_Contrast("Texture_6_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_8_Height_Contrast("Texture_8_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_7_Height_Contrast("Texture_7_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_3_Height_Contrast("Texture_3_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_5_Height_Contrast("Texture_5_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_4_Height_Contrast("Texture_4_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_2_Height_Contrast("Texture_2_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_16_Heightblend_Far("Texture_16_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_15_Heightblend_Far("Texture_15_Heightblend_Far", Range( 1 , 10)) = 5
		_Snow_Heightblend_Far("Snow_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_14_Heightblend_Far("Texture_14_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_12_Heightblend_Far("Texture_12_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_13_Heightblend_Far("Texture_13_Heightblend_Far", Range( 1 , 10)) = 5
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		_Texture_7_Heightblend_Far("Texture_7_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_11_Heightblend_Far("Texture_11_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_10_Heightblend_Far("Texture_10_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_9_Heightblend_Far("Texture_9_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_8_Heightblend_Far("Texture_8_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_6_Heightblend_Far("Texture_6_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_5_Heightblend_Far("Texture_5_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_3_Heightblend_Far("Texture_3_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_4_Heightblend_Far("Texture_4_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_2_Heightblend_Far("Texture_2_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_1_Heightblend_Far("Texture_1_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_1_Geological_Power("Texture_1_Geological_Power", Range( 0 , 2)) = 1
		_Texture_2_Geological_Power("Texture_2_Geological_Power", Range( 0 , 2)) = 1
		_Texture_3_Geological_Power("Texture_3_Geological_Power", Range( 0 , 2)) = 1
		_Texture_4_Geological_Power("Texture_4_Geological_Power", Range( 0 , 2)) = 1
		_Texture_5_Geological_Power("Texture_5_Geological_Power", Range( 0 , 2)) = 1
		_Texture_6_Geological_Power("Texture_6_Geological_Power", Range( 0 , 2)) = 1
		_Texture_7_Geological_Power("Texture_7_Geological_Power", Range( 0 , 2)) = 1
		_Texture_8_Geological_Power("Texture_8_Geological_Power", Range( 0 , 2)) = 1
		_Texture_9_Geological_Power("Texture_9_Geological_Power", Range( 0 , 2)) = 1
		_Texture_10_Geological_Power("Texture_10_Geological_Power", Range( 0 , 2)) = 1
		_Texture_11_Geological_Power("Texture_11_Geological_Power", Range( 0 , 2)) = 1
		_Texture_12_Geological_Power("Texture_12_Geological_Power", Range( 0 , 2)) = 1
		_Texture_13_Geological_Power("Texture_13_Geological_Power", Range( 0 , 2)) = 1
		_Texture_14_Geological_Power("Texture_14_Geological_Power", Range( 0 , 2)) = 1
		_Texture_15_Geological_Power("Texture_15_Geological_Power", Range( 0 , 2)) = 1
		_Texture_16_Geological_Power("Texture_16_Geological_Power", Range( 0 , 2)) = 1
		_Snow_Specular("Snow_Specular", Range( 0 , 3)) = 1
		_Snow_Color("Snow_Color", Vector) = (1,1,1,1)
		_Snow_Amount("Snow_Amount", Range( 0 , 2)) = 0
		_Snow_Perlin_Power("Snow_Perlin_Power", Range( 0 , 2)) = 0
		_Snow_Min_Height("Snow_Min_Height", Range( -1000 , 10000)) = -1000
		_Snow_Min_Height_Blending("Snow_Min_Height_Blending", Range( 0 , 500)) = 1
		_Snow_Maximum_Angle("Snow_Maximum_Angle", Range( 0.001 , 180)) = 30
		_Snow_Maximum_Angle_Hardness("Snow_Maximum_Angle_Hardness", Range( 0.001 , 10)) = 1
		_Texture_1_Snow_Reduction("Texture_1_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_2_Snow_Reduction("Texture_2_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_3_Snow_Reduction("Texture_3_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_4_Snow_Reduction("Texture_4_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_5_Snow_Reduction("Texture_5_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_Snow_Average("Texture_Snow_Average", Vector) = (0,0,0,0)
		_Texture_6_Snow_Reduction("Texture_6_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_7_Snow_Reduction("Texture_7_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_8_Snow_Reduction("Texture_8_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_9_Snow_Reduction("Texture_9_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_10_Snow_Reduction("Texture_10_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_11_Snow_Reduction("Texture_11_Snow_Reduction", Range( 0 , 1)) = 0
		_Remove_Vert_Height("Remove_Vert_Height", Range( -10000 , 10000)) = -1000
		_Texture_12_Snow_Reduction("Texture_12_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_13_Snow_Reduction("Texture_13_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_14_Snow_Reduction("Texture_14_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_15_Snow_Reduction("Texture_15_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_16_Snow_Reduction("Texture_16_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_Perlin_Normal_Index("Texture_Perlin_Normal_Index", Int) = -1
		_Texture_Snow_H_AO_Index("Texture_Snow_H_AO_Index", Int) = -1
		_Texture_9_Color("Texture_9_Color", Vector) = (1,1,1,1)
		_Texture_10_Color("Texture_10_Color", Vector) = (1,1,1,1)
		_Texture_13_Color("Texture_13_Color", Vector) = (1,1,1,1)
		_Texture_11_Color("Texture_11_Color", Vector) = (1,1,1,1)
		_Texture_12_Color("Texture_12_Color", Vector) = (1,1,1,1)
		_Texture_15_Color("Texture_15_Color", Vector) = (1,1,1,1)
		_Texture_14_Color("Texture_14_Color", Vector) = (1,1,1,1)
		_Texture_8_Color("Texture_8_Color", Vector) = (1,1,1,1)
		_Texture_16_Color("Texture_16_Color", Vector) = (1,1,1,1)
		_Texture_7_Color("Texture_7_Color", Vector) = (1,1,1,1)
		_Texture_5_Color("Texture_5_Color", Vector) = (1,1,1,1)
		_Texture_6_Color("Texture_6_Color", Vector) = (1,1,1,1)
		_Texture_4_Color("Texture_4_Color", Vector) = (1,1,1,1)
		_Texture_1_Color("Texture_1_Color", Vector) = (1,1,1,1)
		_Texture_3_Color("Texture_3_Color", Vector) = (1,1,1,1)
		_Texture_2_Color("Texture_2_Color", Vector) = (1,1,1,1)
		_Texture_Geological_Map("Texture_Geological_Map", 2D) = "white" {}
		_Snow_Noise_Power("Snow_Noise_Power", Range( 0 , 1)) = 1
		_Snow_Noise_Tiling("Snow_Noise_Tiling", Range( 0.001 , 1)) = 0.02
		_Texture_Splat_1("Texture_Splat_1", 2D) = "black" {}
		_Texture_Splat_2("Texture_Splat_2", 2D) = "black" {}
		_Texture_Splat_3("Texture_Splat_3", 2D) = "black" {}
		_Texture_Splat_4("Texture_Splat_4", 2D) = "black" {}
		_Global_Normal_Map("Global_Normal_Map", 2D) = "bump" {}
		_Texture_1_Albedo_Index("Texture_1_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_1_H_AO_Index("Texture_1_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_2_Albedo_Index("Texture_2_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_2_H_AO_Index("Texture_2_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_3_H_AO_Index("Texture_3_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_3_Albedo_Index("Texture_3_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_4_H_AO_Index("Texture_4_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_4_Albedo_Index("Texture_4_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_5_Albedo_Index("Texture_5_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_5_H_AO_Index("Texture_5_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_6_H_AO_Index("Texture_6_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_6_Albedo_Index("Texture_6_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_7_Albedo_Index("Texture_7_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_7_H_AO_Index("Texture_7_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_8_Albedo_Index("Texture_8_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_8_H_AO_Index("Texture_8_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_16_H_AO_Index("Texture_16_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_15_H_AO_Index("Texture_15_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_16_Albedo_Index("Texture_16_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_15_Albedo_Index("Texture_15_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_14_H_AO_Index("Texture_14_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_14_Albedo_Index("Texture_14_Albedo_Index", Range( -1 , 100)) = -1
		_Ambient_Occlusion_Power("Ambient_Occlusion_Power", Range( 0 , 1)) = 1
		_Texture_13_H_AO_Index("Texture_13_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_13_Albedo_Index("Texture_13_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_12_H_AO_Index("Texture_12_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_12_Albedo_Index("Texture_12_Albedo_Index", Range( -1 , 100)) = -1
		_Global_Color_Map("Global_Color_Map", 2D) = "white" {}
		_Texture_11_H_AO_Index("Texture_11_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_11_Albedo_Index("Texture_11_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_10_Albedo_Index("Texture_10_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_10_H_AO_Index("Texture_10_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_9_H_AO_Index_AO_H_Index("Texture_9_H_AO_Index_AO_H_Index", Range( -1 , 100)) = -1
		_Texture_9_Albedo_Index("Texture_9_Albedo_Index", Range( -1 , 100)) = -1
		[Toggle(_USE_AO_TEXTURE_ON)] _Use_AO_Texture("Use_AO_Texture", Float) = 0
		_TerrainHolesTexture("Holes Map (RGB)", 2D) = "white" {}
		_Global_Color_Map_Scale("Global_Color_Map_Scale", Float) = 1
		_Global_Color_Map_Offset("Global_Color_Map_Offset", Vector) = (0,0,0,0)
		_Texture_Array_Albedo("Texture_Array_Albedo", 2DArray ) = "" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "Geometry-100" }
		Cull Back
		ZTest LEqual
		CGINCLUDE
		#include "UnityStandardUtils.cginc"
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 3.5
		#pragma multi_compile __ _USE_AO_TEXTURE_ON
		#pragma instancing_options assumeuniformscaling nomatrices nolightprobe nolightmap forwardadd  
		#include "TerrainSplatmapCommonCTS.cginc"
		#pragma multi_compile_instancing
		#ifdef UNITY_PASS_SHADOWCASTER
			#undef INTERNAL_DATA
			#undef WorldReflectionVector
			#undef WorldNormalVector
			#define INTERNAL_DATA half3 internalSurfaceTtoW0; half3 internalSurfaceTtoW1; half3 internalSurfaceTtoW2;
			#define WorldReflectionVector(data,normal) reflect (data.worldRefl, half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal)))
			#define WorldNormalVector(data,normal) half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal))
		#endif

		uniform UNITY_DECLARE_TEX2DARRAY( _Texture_Array_Normal );
		uniform half _Perlin_Normal_Tiling_Far;
		uniform int _Texture_Perlin_Normal_Index;
		uniform half _Perlin_Normal_Power;
		uniform half _Texture_16_Perlin_Power;
		uniform sampler2D _Texture_Splat_4;
		uniform half _Texture_15_Perlin_Power;
		uniform half _Texture_14_Perlin_Power;
		uniform half _Texture_13_Perlin_Power;
		uniform half _Texture_12_Perlin_Power;
		uniform sampler2D _Texture_Splat_3;
		uniform half _Texture_11_Perlin_Power;
		uniform half _Texture_10_Perlin_Power;
		uniform half _Texture_9_Perlin_Power;
		uniform half _Texture_8_Perlin_Power;
		uniform sampler2D _Texture_Splat_2;
		uniform half _Texture_7_Perlin_Power;
		uniform half _Texture_6_Perlin_Power;
		uniform half _Texture_5_Perlin_Power;
		uniform half _Texture_1_Perlin_Power;
		uniform sampler2D _Texture_Splat_1;
		uniform half _Texture_2_Perlin_Power;
		uniform half _Texture_4_Perlin_Power;
		uniform half _Texture_3_Perlin_Power;
		uniform half _Snow_Perlin_Power;
		uniform half _Texture_1_H_AO_Index;
		uniform UNITY_DECLARE_TEX2DARRAY( _Texture_Array_Albedo );
		uniform half _Texture_1_Tiling;
		uniform half _Texture_1_Far_Multiplier;
		uniform half _Texture_1_Height_Contrast;
		uniform half _Texture_1_Heightmap_Depth;
		uniform half _Texture_2_Heightmap_Depth;
		uniform half _Texture_2_H_AO_Index;
		uniform half _Texture_2_Tiling;
		uniform half _Texture_2_Far_Multiplier;
		uniform half _Texture_2_Height_Contrast;
		uniform half _Texture_3_Heightmap_Depth;
		uniform half _Texture_3_H_AO_Index;
		uniform half _Texture_3_Tiling;
		uniform half _Texture_3_Far_Multiplier;
		uniform half _Texture_3_Height_Contrast;
		uniform half _Texture_4_Heightmap_Depth;
		uniform half _Texture_4_H_AO_Index;
		uniform half _Texture_4_Tiling;
		uniform half _Texture_4_Far_Multiplier;
		uniform half _Texture_4_Height_Contrast;
		uniform half _Texture_5_Heightmap_Depth;
		uniform half _Texture_5_H_AO_Index;
		uniform half _Texture_5_Tiling;
		uniform half _Texture_5_Far_Multiplier;
		uniform half _Texture_5_Height_Contrast;
		uniform half _Texture_6_Heightmap_Depth;
		uniform half _Texture_6_H_AO_Index;
		uniform half _Texture_6_Tiling;
		uniform half _Texture_6_Far_Multiplier;
		uniform half _Texture_6_Height_Contrast;
		uniform half _Texture_7_Heightmap_Depth;
		uniform half _Texture_7_H_AO_Index;
		uniform half _Texture_7_Tiling;
		uniform half _Texture_7_Far_Multiplier;
		uniform half _Texture_7_Height_Contrast;
		uniform half _Texture_8_Heightmap_Depth;
		uniform half _Texture_8_H_AO_Index;
		uniform half _Texture_8_Tiling;
		uniform half _Texture_8_Far_Multiplier;
		uniform half _Texture_8_Height_Contrast;
		uniform half _Texture_9_Heightmap_Depth;
		uniform half _Texture_9_H_AO_Index_AO_H_Index;
		uniform half _Texture_9_Tiling;
		uniform half _Texture_9_Far_Multiplier;
		uniform half _Texture_9_Height_Contrast;
		uniform half _Texture_10_Heightmap_Depth;
		uniform half _Texture_10_H_AO_Index;
		uniform half _Texture_10_Tiling;
		uniform half _Texture_10_Far_Multiplier;
		uniform half _Texture_10_Height_Contrast;
		uniform half _Texture_11_Heightmap_Depth;
		uniform half _Texture_11_H_AO_Index;
		uniform half _Texture_11_Tiling;
		uniform half _Texture_11_Far_Multiplier;
		uniform half _Texture_11_Height_Contrast;
		uniform half _Texture_12_Heightmap_Depth;
		uniform half _Texture_12_H_AO_Index;
		uniform half _Texture_12_Tiling;
		uniform half _Texture_12_Far_Multiplier;
		uniform half _Texture_12_Height_Contrast;
		uniform half _Texture_13_Heightmap_Depth;
		uniform half _Texture_13_H_AO_Index;
		uniform half _Texture_13_Tiling;
		uniform half _Texture_13_Far_Multiplier;
		uniform half _Texture_13_Height_Contrast;
		uniform half _Texture_14_Heightmap_Depth;
		uniform half _Texture_14_H_AO_Index;
		uniform half _Texture_14_Tiling;
		uniform half _Texture_14_Far_Multiplier;
		uniform half _Texture_14_Height_Contrast;
		uniform half _Texture_15_Heightmap_Depth;
		uniform half _Texture_15_H_AO_Index;
		uniform half _Texture_15_Tiling;
		uniform half _Texture_15_Far_Multiplier;
		uniform half _Texture_15_Height_Contrast;
		uniform half _Texture_16_Heightmap_Depth;
		uniform half _Texture_16_H_AO_Index;
		uniform half _Texture_16_Tiling;
		uniform half _Texture_16_Far_Multiplier;
		uniform half _Texture_16_Height_Contrast;
		uniform int _Texture_Snow_H_AO_Index;
		uniform half _Snow_Height_Contrast;
		uniform half _Snow_Heightmap_Depth;
		uniform half _Snow_Amount;
		uniform half _Snow_Noise_Tiling;
		uniform half _Snow_Noise_Power;
		uniform half _Snow_Maximum_Angle_Hardness;
		uniform half _Snow_Maximum_Angle;
		uniform half _Snow_Min_Height;
		uniform half _Snow_Min_Height_Blending;
		uniform half _Texture_16_Snow_Reduction;
		uniform half _Texture_15_Snow_Reduction;
		uniform half _Texture_13_Snow_Reduction;
		uniform half _Texture_12_Snow_Reduction;
		uniform half _Texture_11_Snow_Reduction;
		uniform half _Texture_9_Snow_Reduction;
		uniform half _Texture_8_Snow_Reduction;
		uniform half _Texture_7_Snow_Reduction;
		uniform half _Texture_5_Snow_Reduction;
		uniform half _Texture_1_Snow_Reduction;
		uniform half _Texture_2_Snow_Reduction;
		uniform half _Texture_3_Snow_Reduction;
		uniform half _Texture_4_Snow_Reduction;
		uniform half _Texture_6_Snow_Reduction;
		uniform half _Texture_10_Snow_Reduction;
		uniform half _Texture_14_Snow_Reduction;
		uniform half _Snow_Heightblend_Far;
		uniform half _Global_Normalmap_Power;
		uniform sampler2D _Global_Normal_Map;
		uniform half _Global_Color_Map_Far_Power;
		uniform sampler2D _Global_Color_Map;
		uniform half2 _Global_Color_Map_Offset;
		uniform half _Global_Color_Map_Scale;
		uniform half _Global_Color_Opacity_Power;
		uniform half _Texture_13_Heightblend_Far;
		uniform half _Texture_14_Heightblend_Far;
		uniform half _Texture_15_Heightblend_Far;
		uniform half _Texture_16_Heightblend_Far;
		uniform half _Texture_9_Heightblend_Far;
		uniform half _Texture_10_Heightblend_Far;
		uniform half _Texture_11_Heightblend_Far;
		uniform half _Texture_12_Heightblend_Far;
		uniform half _Texture_5_Heightblend_Far;
		uniform half _Texture_6_Heightblend_Far;
		uniform half _Texture_7_Heightblend_Far;
		uniform half _Texture_8_Heightblend_Far;
		uniform half _Texture_1_Heightblend_Far;
		uniform half _Texture_2_Heightblend_Far;
		uniform half _Texture_3_Heightblend_Far;
		uniform half _Texture_4_Heightblend_Far;
		uniform half _Texture_1_Albedo_Index;
		uniform half4 _Texture_1_Color;
		uniform half _Texture_2_Albedo_Index;
		uniform half4 _Texture_2_Color;
		uniform half _Texture_3_Albedo_Index;
		uniform half4 _Texture_3_Color;
		uniform half _Texture_4_Albedo_Index;
		uniform half4 _Texture_4_Color;
		uniform half _Texture_5_Albedo_Index;
		uniform half4 _Texture_5_Color;
		uniform half _Texture_6_Albedo_Index;
		uniform half4 _Texture_6_Color;
		uniform half _Texture_7_Albedo_Index;
		uniform half4 _Texture_7_Color;
		uniform half _Texture_8_Albedo_Index;
		uniform half4 _Texture_8_Color;
		uniform half _Texture_9_Albedo_Index;
		uniform half4 _Texture_9_Color;
		uniform half _Texture_10_Albedo_Index;
		uniform half4 _Texture_10_Color;
		uniform half _Texture_11_Albedo_Index;
		uniform half4 _Texture_11_Color;
		uniform half _Texture_12_Albedo_Index;
		uniform half4 _Texture_12_Color;
		uniform half _Texture_13_Albedo_Index;
		uniform half4 _Texture_13_Color;
		uniform half _Texture_14_Albedo_Index;
		uniform half4 _Texture_14_Color;
		uniform half _Texture_15_Albedo_Index;
		uniform half4 _Texture_15_Color;
		uniform half _Texture_16_Albedo_Index;
		uniform half4 _Texture_16_Color;
		uniform sampler2D _Texture_Geological_Map;
		uniform half _Geological_Tiling_Far;
		uniform half _Geological_Map_Offset_Far;
		uniform half _Geological_Map_Far_Power;
		uniform half _Texture_16_Geological_Power;
		uniform half _Texture_15_Geological_Power;
		uniform half _Texture_14_Geological_Power;
		uniform half _Texture_13_Geological_Power;
		uniform half _Texture_12_Geological_Power;
		uniform half _Texture_11_Geological_Power;
		uniform half _Texture_10_Geological_Power;
		uniform half _Texture_9_Geological_Power;
		uniform half _Texture_8_Geological_Power;
		uniform half _Texture_7_Geological_Power;
		uniform half _Texture_6_Geological_Power;
		uniform half _Texture_5_Geological_Power;
		uniform half _Texture_1_Geological_Power;
		uniform half _Texture_2_Geological_Power;
		uniform half _Texture_4_Geological_Power;
		uniform half _Texture_3_Geological_Power;
		uniform half4 _Texture_Snow_Average;
		uniform half4 _Snow_Color;
		uniform half _Terrain_Specular;
		uniform half _Snow_Specular;
		uniform half _Terrain_Smoothness;
		uniform half _Ambient_Occlusion_Power;
		uniform sampler2D _TerrainHolesTexture;
		uniform float4 _TerrainHolesTexture_ST;
		uniform half _Remove_Vert_Height;
		uniform float _Cutoff = 0.5;


		float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }

		float snoise( float2 v )
		{
			const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
			float2 i = floor( v + dot( v, C.yy ) );
			float2 x0 = v - i + dot( i, C.xx );
			float2 i1;
			i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
			float4 x12 = x0.xyxy + C.xxzz;
			x12.xy -= i1;
			i = mod2D289( i );
			float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
			float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
			m = m * m;
			m = m * m;
			float3 x = 2.0 * frac( p * C.www ) - 1.0;
			float3 h = abs( x ) - 0.5;
			float3 ox = floor( x + 0.5 );
			float3 a0 = x - ox;
			m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
			float3 g;
			g.x = a0.x * x0.x + h.x * x0.y;
			g.yz = a0.yz * x12.xz + h.yz * x12.yw;
			return 130.0 * dot( m, g );
		}


		void surf( Input i , inout SurfaceOutputStandardSpecular o )
		{
			float3 ase_worldPos = i.worldPos;
			float3 break7756 = ase_worldPos;
			float2 appendResult7743 = (half2(break7756.x , break7756.z));
			half2 Top_Bottom1999 = appendResult7743;
			float4 texArray4374 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(( Top_Bottom1999 / _Perlin_Normal_Tiling_Far ), (float)_Texture_Perlin_Normal_Index)  );
			float2 appendResult11_g668 = (half2(texArray4374.w , texArray4374.y));
			float2 temp_output_4_0_g668 = ( ( ( appendResult11_g668 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Perlin_Normal_Power );
			float2 break8_g668 = temp_output_4_0_g668;
			float dotResult5_g668 = dot( temp_output_4_0_g668 , temp_output_4_0_g668 );
			float temp_output_9_0_g668 = sqrt( ( 1.0 - saturate( dotResult5_g668 ) ) );
			float3 appendResult20_g668 = (half3(break8_g668.x , break8_g668.y , temp_output_9_0_g668));
			float3 temp_output_7038_0 = appendResult20_g668;
			half4 tex2DNode4371 = tex2D( _Texture_Splat_4, i.uv_texcoord );
			half Splat4_A2546 = tex2DNode4371.a;
			half Splat4_B2545 = tex2DNode4371.b;
			half Splat4_G2544 = tex2DNode4371.g;
			half Splat4_R2543 = tex2DNode4371.r;
			half4 tex2DNode4370 = tex2D( _Texture_Splat_3, i.uv_texcoord );
			half Splat3_A2540 = tex2DNode4370.a;
			half Splat3_B2539 = tex2DNode4370.b;
			half Splat3_G2538 = tex2DNode4370.g;
			half Splat3_R2537 = tex2DNode4370.r;
			half4 tex2DNode4369 = tex2D( _Texture_Splat_2, i.uv_texcoord );
			half Splat2_A2109 = tex2DNode4369.a;
			half Splat2_B2108 = tex2DNode4369.b;
			half Splat2_G2107 = tex2DNode4369.g;
			half Splat2_R2106 = tex2DNode4369.r;
			half4 tex2DNode4368 = tex2D( _Texture_Splat_1, i.uv_texcoord );
			half Splat1_R1438 = tex2DNode4368.r;
			half Splat1_G1441 = tex2DNode4368.g;
			half Splat1_A1491 = tex2DNode4368.a;
			half Splat1_B1442 = tex2DNode4368.b;
			float clampResult3775 = clamp( ( ( _Texture_16_Perlin_Power * Splat4_A2546 ) + ( ( _Texture_15_Perlin_Power * Splat4_B2545 ) + ( ( _Texture_14_Perlin_Power * Splat4_G2544 ) + ( ( _Texture_13_Perlin_Power * Splat4_R2543 ) + ( ( _Texture_12_Perlin_Power * Splat3_A2540 ) + ( ( _Texture_11_Perlin_Power * Splat3_B2539 ) + ( ( _Texture_10_Perlin_Power * Splat3_G2538 ) + ( ( _Texture_9_Perlin_Power * Splat3_R2537 ) + ( ( _Texture_8_Perlin_Power * Splat2_A2109 ) + ( ( _Texture_7_Perlin_Power * Splat2_B2108 ) + ( ( _Texture_6_Perlin_Power * Splat2_G2107 ) + ( ( _Texture_5_Perlin_Power * Splat2_R2106 ) + ( ( _Texture_1_Perlin_Power * Splat1_R1438 ) + ( ( _Texture_2_Perlin_Power * Splat1_G1441 ) + ( ( _Texture_4_Perlin_Power * Splat1_A1491 ) + ( _Texture_3_Perlin_Power * Splat1_B1442 ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) , 0.0 , 1.0 );
			float3 lerpResult3776 = lerp( float3( 0,0,1 ) , temp_output_7038_0 , clampResult3775);
			float3 lerpResult3906 = lerp( float3( 0,0,1 ) , temp_output_7038_0 , ( _Snow_Perlin_Power * 0.5 ));
			float temp_output_3830_0 = ( 1.0 / _Texture_1_Tiling );
			float2 appendResult3284 = (half2(temp_output_3830_0 , temp_output_3830_0));
			float2 temp_output_3298_0 = ( ( Top_Bottom1999 * appendResult3284 ) / _Texture_1_Far_Multiplier );
			float4 texArray7704 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3298_0, _Texture_1_H_AO_Index)  );
			half ifLocalVar7658 = 0;
			UNITY_BRANCH 
			if( _Texture_1_H_AO_Index > -1.0 )
				ifLocalVar7658 = texArray7704.g;
			half Texture_1_H5480 = ifLocalVar7658;
			float temp_output_5544_0 = ( pow( Texture_1_H5480 , _Texture_1_Height_Contrast ) * _Texture_1_Heightmap_Depth );
			float temp_output_3831_0 = ( 1.0 / _Texture_2_Tiling );
			float2 appendResult3349 = (half2(temp_output_3831_0 , temp_output_3831_0));
			float2 temp_output_3345_0 = ( ( Top_Bottom1999 * appendResult3349 ) / _Texture_2_Far_Multiplier );
			float4 texArray5533 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3345_0, _Texture_2_H_AO_Index)  );
			half ifLocalVar7662 = 0;
			UNITY_BRANCH 
			if( _Texture_2_H_AO_Index > -1.0 )
				ifLocalVar7662 = texArray5533.y;
			half Texture_2_H5497 = ifLocalVar7662;
			float temp_output_5545_0 = ( _Texture_2_Heightmap_Depth * pow( Texture_2_H5497 , _Texture_2_Height_Contrast ) );
			float temp_output_3832_0 = ( 1.0 / _Texture_3_Tiling );
			float2 appendResult3415 = (half2(temp_output_3832_0 , temp_output_3832_0));
			float2 temp_output_3412_0 = ( ( Top_Bottom1999 * appendResult3415 ) / _Texture_3_Far_Multiplier );
			float4 texArray5586 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3412_0, _Texture_3_H_AO_Index)  );
			half ifLocalVar7664 = 0;
			UNITY_BRANCH 
			if( _Texture_3_H_AO_Index > -1.0 )
				ifLocalVar7664 = texArray5586.y;
			half Texture_3_H5581 = ifLocalVar7664;
			float temp_output_5590_0 = ( _Texture_3_Heightmap_Depth * pow( Texture_3_H5581 , _Texture_3_Height_Contrast ) );
			float temp_output_3833_0 = ( 1.0 / _Texture_4_Tiling );
			float2 appendResult3482 = (half2(temp_output_3833_0 , temp_output_3833_0));
			float2 temp_output_3479_0 = ( ( Top_Bottom1999 * appendResult3482 ) / _Texture_4_Far_Multiplier );
			float4 texArray5615 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3479_0, _Texture_4_H_AO_Index)  );
			half ifLocalVar7666 = 0;
			UNITY_BRANCH 
			if( _Texture_4_H_AO_Index > -1.0 )
				ifLocalVar7666 = texArray5615.y;
			half Texture_4_H5631 = ifLocalVar7666;
			float temp_output_6118_0 = ( _Texture_4_Heightmap_Depth * pow( Texture_4_H5631 , _Texture_4_Height_Contrast ) );
			float4 layeredBlendVar6518 = tex2DNode4368;
			float layeredBlend6518 = ( lerp( lerp( lerp( lerp( 0.0 , temp_output_5544_0 , layeredBlendVar6518.x ) , temp_output_5545_0 , layeredBlendVar6518.y ) , temp_output_5590_0 , layeredBlendVar6518.z ) , temp_output_6118_0 , layeredBlendVar6518.w ) );
			float temp_output_4397_0 = ( 1.0 / _Texture_5_Tiling );
			float2 appendResult4399 = (half2(temp_output_4397_0 , temp_output_4397_0));
			float2 temp_output_4440_0 = ( ( Top_Bottom1999 * appendResult4399 ) / _Texture_5_Far_Multiplier );
			float4 texArray5655 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4440_0, _Texture_5_H_AO_Index)  );
			half ifLocalVar7668 = 0;
			UNITY_BRANCH 
			if( _Texture_5_H_AO_Index > -1.0 )
				ifLocalVar7668 = texArray5655.y;
			half Texture_5_H5671 = ifLocalVar7668;
			float temp_output_6120_0 = ( _Texture_5_Heightmap_Depth * pow( Texture_5_H5671 , _Texture_5_Height_Contrast ) );
			float temp_output_4469_0 = ( 1.0 / _Texture_6_Tiling );
			float2 appendResult4471 = (half2(temp_output_4469_0 , temp_output_4469_0));
			float2 temp_output_4507_0 = ( ( Top_Bottom1999 * appendResult4471 ) / _Texture_6_Far_Multiplier );
			float4 texArray5695 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4507_0, _Texture_6_H_AO_Index)  );
			half ifLocalVar7670 = 0;
			UNITY_BRANCH 
			if( _Texture_6_H_AO_Index > -1.0 )
				ifLocalVar7670 = texArray5695.y;
			half Texture_6_H5711 = ifLocalVar7670;
			float temp_output_6126_0 = ( _Texture_6_Heightmap_Depth * pow( Texture_6_H5711 , _Texture_6_Height_Contrast ) );
			float temp_output_4543_0 = ( 1.0 / _Texture_7_Tiling );
			float2 appendResult4545 = (half2(temp_output_4543_0 , temp_output_4543_0));
			float2 temp_output_4581_0 = ( ( Top_Bottom1999 * appendResult4545 ) / _Texture_7_Far_Multiplier );
			float4 texArray5735 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4581_0, _Texture_7_H_AO_Index)  );
			half ifLocalVar7672 = 0;
			UNITY_BRANCH 
			if( _Texture_7_H_AO_Index > -1.0 )
				ifLocalVar7672 = texArray5735.y;
			half Texture_7_H5751 = ifLocalVar7672;
			float temp_output_6132_0 = ( _Texture_7_Heightmap_Depth * pow( Texture_7_H5751 , _Texture_7_Height_Contrast ) );
			float temp_output_4617_0 = ( 1.0 / _Texture_8_Tiling );
			float2 appendResult4619 = (half2(temp_output_4617_0 , temp_output_4617_0));
			float2 temp_output_4655_0 = ( ( Top_Bottom1999 * appendResult4619 ) / _Texture_8_Far_Multiplier );
			float4 texArray5775 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4655_0, _Texture_8_H_AO_Index)  );
			half ifLocalVar7674 = 0;
			UNITY_BRANCH 
			if( _Texture_8_H_AO_Index > -1.0 )
				ifLocalVar7674 = texArray5775.y;
			half Texture_8_H5791 = ifLocalVar7674;
			float temp_output_6138_0 = ( _Texture_8_Heightmap_Depth * pow( Texture_8_H5791 , _Texture_8_Height_Contrast ) );
			float4 layeredBlendVar6525 = tex2DNode4369;
			float layeredBlend6525 = ( lerp( lerp( lerp( lerp( layeredBlend6518 , temp_output_6120_0 , layeredBlendVar6525.x ) , temp_output_6126_0 , layeredBlendVar6525.y ) , temp_output_6132_0 , layeredBlendVar6525.z ) , temp_output_6138_0 , layeredBlendVar6525.w ) );
			float temp_output_4703_0 = ( 1.0 / _Texture_9_Tiling );
			float2 appendResult4736 = (half2(temp_output_4703_0 , temp_output_4703_0));
			float2 temp_output_4721_0 = ( ( Top_Bottom1999 * appendResult4736 ) / _Texture_9_Far_Multiplier );
			float4 texArray5811 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4721_0, _Texture_9_H_AO_Index_AO_H_Index)  );
			half ifLocalVar7689 = 0;
			UNITY_BRANCH 
			if( _Texture_9_H_AO_Index_AO_H_Index > -1.0 )
				ifLocalVar7689 = texArray5811.y;
			half Texture_9_H5832 = ifLocalVar7689;
			float temp_output_6144_0 = ( _Texture_9_Heightmap_Depth * pow( Texture_9_H5832 , _Texture_9_Height_Contrast ) );
			float temp_output_4734_0 = ( 1.0 / _Texture_10_Tiling );
			float2 appendResult4738 = (half2(temp_output_4734_0 , temp_output_4734_0));
			float2 temp_output_4879_0 = ( ( Top_Bottom1999 * appendResult4738 ) / _Texture_10_Far_Multiplier );
			float4 texArray5851 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4879_0, _Texture_10_H_AO_Index)  );
			half ifLocalVar7687 = 0;
			UNITY_BRANCH 
			if( _Texture_10_H_AO_Index > -1.0 )
				ifLocalVar7687 = texArray5851.y;
			half Texture_10_H5872 = ifLocalVar7687;
			float temp_output_6150_0 = ( _Texture_10_Heightmap_Depth * pow( Texture_10_H5872 , _Texture_10_Height_Contrast ) );
			float temp_output_4739_0 = ( 1.0 / _Texture_11_Tiling );
			float2 appendResult4741 = (half2(temp_output_4739_0 , temp_output_4739_0));
			float2 temp_output_4904_0 = ( ( Top_Bottom1999 * appendResult4741 ) / _Texture_11_Far_Multiplier );
			float4 texArray5891 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4904_0, _Texture_11_H_AO_Index)  );
			half ifLocalVar7685 = 0;
			UNITY_BRANCH 
			if( _Texture_11_H_AO_Index > -1.0 )
				ifLocalVar7685 = texArray5891.y;
			half Texture_11_H5912 = ifLocalVar7685;
			float temp_output_6156_0 = ( _Texture_11_Heightmap_Depth * pow( Texture_11_H5912 , _Texture_11_Height_Contrast ) );
			float temp_output_4745_0 = ( 1.0 / _Texture_12_Tiling );
			float2 appendResult4751 = (half2(temp_output_4745_0 , temp_output_4745_0));
			float2 temp_output_4932_0 = ( ( Top_Bottom1999 * appendResult4751 ) / _Texture_12_Far_Multiplier );
			float4 texArray5931 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4932_0, _Texture_12_H_AO_Index)  );
			half ifLocalVar7683 = 0;
			UNITY_BRANCH 
			if( _Texture_12_H_AO_Index > -1.0 )
				ifLocalVar7683 = texArray5931.y;
			half Texture_12_H5952 = ifLocalVar7683;
			float temp_output_6162_0 = ( _Texture_12_Heightmap_Depth * pow( Texture_12_H5952 , _Texture_12_Height_Contrast ) );
			float4 layeredBlendVar6527 = tex2DNode4370;
			float layeredBlend6527 = ( lerp( lerp( lerp( lerp( layeredBlend6525 , temp_output_6144_0 , layeredBlendVar6527.x ) , temp_output_6150_0 , layeredBlendVar6527.y ) , temp_output_6156_0 , layeredBlendVar6527.z ) , temp_output_6162_0 , layeredBlendVar6527.w ) );
			float temp_output_5125_0 = ( 1.0 / _Texture_13_Tiling );
			float2 appendResult5027 = (half2(temp_output_5125_0 , temp_output_5125_0));
			float2 temp_output_5112_0 = ( ( Top_Bottom1999 * appendResult5027 ) / _Texture_13_Far_Multiplier );
			float4 texArray5971 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5112_0, _Texture_13_H_AO_Index)  );
			half ifLocalVar7681 = 0;
			UNITY_BRANCH 
			if( _Texture_13_H_AO_Index > -1.0 )
				ifLocalVar7681 = texArray5971.y;
			half Texture_13_H5992 = ifLocalVar7681;
			float temp_output_6168_0 = ( _Texture_13_Heightmap_Depth * pow( Texture_13_H5992 , _Texture_13_Height_Contrast ) );
			float temp_output_5006_0 = ( 1.0 / _Texture_14_Tiling );
			float2 appendResult5033 = (half2(temp_output_5006_0 , temp_output_5006_0));
			float2 temp_output_5172_0 = ( ( Top_Bottom1999 * appendResult5033 ) / _Texture_14_Far_Multiplier );
			float4 texArray6011 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5172_0, _Texture_14_H_AO_Index)  );
			half ifLocalVar7679 = 0;
			UNITY_BRANCH 
			if( _Texture_14_H_AO_Index > -1.0 )
				ifLocalVar7679 = texArray6011.y;
			half Texture_14_H6032 = ifLocalVar7679;
			float temp_output_6174_0 = ( _Texture_14_Heightmap_Depth * pow( Texture_14_H6032 , _Texture_14_Height_Contrast ) );
			float temp_output_5210_0 = ( 1.0 / _Texture_15_Tiling );
			float2 appendResult5212 = (half2(temp_output_5210_0 , temp_output_5210_0));
			float2 temp_output_5190_0 = ( ( Top_Bottom1999 * appendResult5212 ) / _Texture_15_Far_Multiplier );
			float4 texArray6051 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5190_0, _Texture_15_H_AO_Index)  );
			half ifLocalVar7677 = 0;
			UNITY_BRANCH 
			if( _Texture_15_H_AO_Index > -1.0 )
				ifLocalVar7677 = texArray6051.y;
			half Texture_15_H6072 = ifLocalVar7677;
			float temp_output_6180_0 = ( _Texture_15_Heightmap_Depth * pow( Texture_15_H6072 , _Texture_15_Height_Contrast ) );
			float temp_output_5075_0 = ( 1.0 / _Texture_16_Tiling );
			float2 appendResult5078 = (half2(temp_output_5075_0 , temp_output_5075_0));
			float2 temp_output_5153_0 = ( ( Top_Bottom1999 * appendResult5078 ) / _Texture_16_Far_Multiplier );
			float4 texArray6091 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5153_0, _Texture_16_H_AO_Index)  );
			half ifLocalVar7675 = 0;
			UNITY_BRANCH 
			if( _Texture_16_H_AO_Index > -1.0 )
				ifLocalVar7675 = texArray6091.y;
			half Texture_16_H6112 = ifLocalVar7675;
			float temp_output_6186_0 = ( _Texture_16_Heightmap_Depth * pow( Texture_16_H6112 , _Texture_16_Height_Contrast ) );
			float4 layeredBlendVar6530 = tex2DNode4371;
			float layeredBlend6530 = ( lerp( lerp( lerp( lerp( layeredBlend6527 , temp_output_6168_0 , layeredBlendVar6530.x ) , temp_output_6174_0 , layeredBlendVar6530.y ) , temp_output_6180_0 , layeredBlendVar6530.z ) , temp_output_6186_0 , layeredBlendVar6530.w ) );
			float4 texArray6270 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(Top_Bottom1999, (float)_Texture_Snow_H_AO_Index)  );
			float temp_output_6545_0 = ( layeredBlend6530 + ( pow( texArray6270.y , _Snow_Height_Contrast ) * _Snow_Heightmap_Depth ) );
			float clampResult6546 = clamp( temp_output_6545_0 , 0.0 , temp_output_6545_0 );
			float clampResult7176 = clamp( clampResult6546 , 0.0 , 1.0 );
			float simplePerlin2D7758 = snoise( ( Top_Bottom1999 * _Snow_Noise_Tiling ) );
			float lerpResult7728 = lerp( 1.0 , simplePerlin2D7758 , ( _Snow_Noise_Power * 0.1 ));
			float temp_output_7621_0 = ( _Snow_Maximum_Angle_Hardness * 0.5 );
			half3 ase_worldNormal = WorldNormalVector( i, half3( 0, 0, 1 ) );
			NormalForWorld(ase_worldNormal, i.tc.zw);
			float clampResult1354 = clamp( ase_worldNormal.y , 0.0 , 0.9999 );
			float temp_output_1349_0 = ( _Snow_Maximum_Angle / 90.0 );
			float clampResult1347 = clamp( ( clampResult1354 - ( 1.0 - temp_output_1349_0 ) ) , 0.0 , 2.0 );
			half SnowSlope1352 = ( clampResult1347 * ( 1.0 / temp_output_1349_0 ) );
			float clampResult6569 = clamp( ( 1.0 - ( temp_output_7621_0 * 0.1 ) ) , 0.01 , 1.0 );
			float clampResult4146 = clamp( pow( ( ( _Snow_Amount * ( 0.1 - ( temp_output_7621_0 * 0.01 ) ) ) * SnowSlope1352 ) , clampResult6569 ) , 0.0 , 1.0 );
			float temp_output_3751_0 = ( ( 1.0 - _Snow_Min_Height ) + ase_worldPos.y );
			float clampResult4220 = clamp( ( temp_output_3751_0 + 1.0 ) , 0.0 , 1.0 );
			float clampResult4260 = clamp( ( ( 1.0 - ( ( temp_output_3751_0 + _Snow_Min_Height_Blending ) / temp_output_3751_0 ) ) + -0.5 ) , 0.0 , 1.0 );
			float clampResult4263 = clamp( ( clampResult4220 + clampResult4260 ) , 0.0 , 1.0 );
			float lerpResult3759 = lerp( 0.0 , ( ( _Snow_Amount * lerpResult7728 ) * clampResult4146 ) , clampResult4263);
			float clampResult4298 = clamp( lerpResult3759 , 0.0 , 2.0 );
			float HeightMask6539 = saturate(pow(((( 1.0 - clampResult7176 )*( clampResult4298 * ( 1.0 - ( ( _Texture_16_Snow_Reduction * Splat4_A2546 ) + ( ( _Texture_15_Snow_Reduction * Splat4_B2545 ) + ( ( ( _Texture_13_Snow_Reduction * Splat4_R2543 ) + ( ( _Texture_12_Snow_Reduction * Splat3_A2540 ) + ( ( _Texture_11_Snow_Reduction * Splat3_B2539 ) + ( ( ( _Texture_9_Snow_Reduction * Splat3_R2537 ) + ( ( _Texture_8_Snow_Reduction * Splat2_A2109 ) + ( ( _Texture_7_Snow_Reduction * Splat2_B2108 ) + ( ( ( _Texture_5_Snow_Reduction * Splat2_R2106 ) + ( ( _Texture_1_Snow_Reduction * Splat1_R1438 ) + ( ( _Texture_2_Snow_Reduction * Splat1_G1441 ) + ( ( _Texture_3_Snow_Reduction * Splat1_B1442 ) + ( _Texture_4_Snow_Reduction * Splat1_A1491 ) ) ) ) ) + ( _Texture_6_Snow_Reduction * Splat2_G2107 ) ) ) ) ) + ( _Texture_10_Snow_Reduction * Splat3_G2538 ) ) ) ) ) + ( _Texture_14_Snow_Reduction * Splat4_G2544 ) ) ) ) ) ))*4)+(( clampResult4298 * ( 1.0 - ( ( _Texture_16_Snow_Reduction * Splat4_A2546 ) + ( ( _Texture_15_Snow_Reduction * Splat4_B2545 ) + ( ( ( _Texture_13_Snow_Reduction * Splat4_R2543 ) + ( ( _Texture_12_Snow_Reduction * Splat3_A2540 ) + ( ( _Texture_11_Snow_Reduction * Splat3_B2539 ) + ( ( ( _Texture_9_Snow_Reduction * Splat3_R2537 ) + ( ( _Texture_8_Snow_Reduction * Splat2_A2109 ) + ( ( _Texture_7_Snow_Reduction * Splat2_B2108 ) + ( ( ( _Texture_5_Snow_Reduction * Splat2_R2106 ) + ( ( _Texture_1_Snow_Reduction * Splat1_R1438 ) + ( ( _Texture_2_Snow_Reduction * Splat1_G1441 ) + ( ( _Texture_3_Snow_Reduction * Splat1_B1442 ) + ( _Texture_4_Snow_Reduction * Splat1_A1491 ) ) ) ) ) + ( _Texture_6_Snow_Reduction * Splat2_G2107 ) ) ) ) ) + ( _Texture_10_Snow_Reduction * Splat3_G2538 ) ) ) ) ) + ( _Texture_14_Snow_Reduction * Splat4_G2544 ) ) ) ) ) )*2),_Snow_Heightblend_Far));
			float3 lerpResult6503 = lerp( lerpResult3776 , lerpResult3906 , HeightMask6539);
			float3 normalizeResult3901 = normalize( UnpackScaleNormal( tex2D( _Global_Normal_Map, i.uv_texcoord ), _Global_Normalmap_Power ) );
			float3 temp_output_4100_0 = BlendNormals( lerpResult6503 , normalizeResult3901 );
			o.Normal = temp_output_4100_0;
			half4 tex2DNode7708 = tex2D( _Global_Color_Map, ( _Global_Color_Map_Offset + ( _Global_Color_Map_Scale * i.uv_texcoord ) ) );
			float clampResult7751 = clamp( ( tex2DNode7708.a + ( 1.0 - _Global_Color_Opacity_Power ) ) , 0.0 , 1.0 );
			float2 appendResult7710 = (half2(1.0 , ( _Global_Color_Map_Far_Power * clampResult7751 )));
			float HeightMask6231 = saturate(pow(((temp_output_6168_0*Splat4_R2543)*4)+(Splat4_R2543*2),_Texture_13_Heightblend_Far));
			float HeightMask6234 = saturate(pow(((temp_output_6174_0*Splat4_G2544)*4)+(Splat4_G2544*2),_Texture_14_Heightblend_Far));
			float HeightMask6237 = saturate(pow(((temp_output_6180_0*Splat4_B2545)*4)+(Splat4_B2545*2),_Texture_15_Heightblend_Far));
			float HeightMask6240 = saturate(pow(((temp_output_6186_0*Splat4_A2546)*4)+(Splat4_A2546*2),_Texture_16_Heightblend_Far));
			float4 appendResult6533 = (half4(HeightMask6231 , HeightMask6234 , HeightMask6237 , HeightMask6240));
			float HeightMask6219 = saturate(pow(((temp_output_6144_0*Splat3_R2537)*4)+(Splat3_R2537*2),_Texture_9_Heightblend_Far));
			float HeightMask6222 = saturate(pow(((temp_output_6150_0*Splat3_G2538)*4)+(Splat3_G2538*2),_Texture_10_Heightblend_Far));
			float HeightMask6225 = saturate(pow(((temp_output_6156_0*Splat3_B2539)*4)+(Splat3_B2539*2),_Texture_11_Heightblend_Far));
			float HeightMask6228 = saturate(pow(((temp_output_6162_0*Splat3_A2540)*4)+(Splat3_A2540*2),_Texture_12_Heightblend_Far));
			float4 appendResult6529 = (half4(HeightMask6219 , HeightMask6222 , HeightMask6225 , HeightMask6228));
			float HeightMask6205 = saturate(pow(((temp_output_6120_0*Splat2_R2106)*4)+(Splat2_R2106*2),_Texture_5_Heightblend_Far));
			float HeightMask6208 = saturate(pow(((temp_output_6126_0*Splat2_G2107)*4)+(Splat2_G2107*2),_Texture_6_Heightblend_Far));
			float HeightMask6211 = saturate(pow(((temp_output_6132_0*Splat2_B2108)*4)+(Splat2_B2108*2),_Texture_7_Heightblend_Far));
			float HeightMask6214 = saturate(pow(((temp_output_6138_0*Splat2_A2109)*4)+(Splat2_A2109*2),_Texture_8_Heightblend_Far));
			float4 appendResult6524 = (half4(HeightMask6205 , HeightMask6208 , HeightMask6211 , HeightMask6214));
			float HeightMask6196 = saturate(pow(((temp_output_5544_0*Splat1_R1438)*4)+(Splat1_R1438*2),_Texture_1_Heightblend_Far));
			float HeightMask6515 = saturate(pow(((temp_output_5545_0*Splat1_G1441)*4)+(Splat1_G1441*2),_Texture_2_Heightblend_Far));
			float HeightMask6516 = saturate(pow(((temp_output_5590_0*Splat1_B1442)*4)+(Splat1_B1442*2),_Texture_3_Heightblend_Far));
			float HeightMask6203 = saturate(pow(((temp_output_6118_0*Splat1_A1491)*4)+(Splat1_A1491*2),_Texture_4_Heightblend_Far));
			float4 appendResult6517 = (half4(HeightMask6196 , HeightMask6515 , HeightMask6516 , HeightMask6203));
			float4 texArray3292 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3298_0, _Texture_1_Albedo_Index)  );
			half4 ifLocalVar7657 = 0;
			UNITY_BRANCH 
			if( _Texture_1_Albedo_Index > -1.0 )
				ifLocalVar7657 = ( texArray3292 * _Texture_1_Color );
			half4 Texture_1_Final950 = ifLocalVar7657;
			float4 texArray3339 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3345_0, _Texture_2_Albedo_Index)  );
			half4 ifLocalVar7661 = 0;
			UNITY_BRANCH 
			if( _Texture_2_Albedo_Index > -1.0 )
				ifLocalVar7661 = ( texArray3339 * _Texture_2_Color );
			half4 Texture_2_Final3385 = ifLocalVar7661;
			float4 texArray3406 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3412_0, _Texture_3_Albedo_Index)  );
			half4 ifLocalVar7663 = 0;
			UNITY_BRANCH 
			if( _Texture_3_Albedo_Index > -1.0 )
				ifLocalVar7663 = ( texArray3406 * _Texture_3_Color );
			half4 Texture_3_Final3451 = ifLocalVar7663;
			float4 texArray3473 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3479_0, _Texture_4_Albedo_Index)  );
			half4 ifLocalVar7665 = 0;
			UNITY_BRANCH 
			if( _Texture_4_Albedo_Index > -1.0 )
				ifLocalVar7665 = ( texArray3473 * _Texture_4_Color );
			half4 Texture_4_Final3518 = ifLocalVar7665;
			float4 layeredBlendVar6512 = appendResult6517;
			float4 layeredBlend6512 = ( lerp( lerp( lerp( lerp( float4( 0,0,0,0 ) , Texture_1_Final950 , layeredBlendVar6512.x ) , Texture_2_Final3385 , layeredBlendVar6512.y ) , Texture_3_Final3451 , layeredBlendVar6512.z ) , Texture_4_Final3518 , layeredBlendVar6512.w ) );
			float4 texArray4445 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4440_0, _Texture_5_Albedo_Index)  );
			half4 ifLocalVar7667 = 0;
			UNITY_BRANCH 
			if( _Texture_5_Albedo_Index > -1.0 )
				ifLocalVar7667 = ( texArray4445 * _Texture_5_Color );
			half4 Texture_5_Final4396 = ifLocalVar7667;
			float4 texArray4512 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4507_0, _Texture_6_Albedo_Index)  );
			half4 ifLocalVar7669 = 0;
			UNITY_BRANCH 
			if( _Texture_6_Albedo_Index > -1.0 )
				ifLocalVar7669 = ( texArray4512 * _Texture_6_Color );
			half4 Texture_6_Final4536 = ifLocalVar7669;
			float4 texArray4586 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4581_0, _Texture_7_Albedo_Index)  );
			half4 ifLocalVar7671 = 0;
			UNITY_BRANCH 
			if( _Texture_7_Albedo_Index > -1.0 )
				ifLocalVar7671 = ( texArray4586 * _Texture_7_Color );
			half4 Texture_7_Final4614 = ifLocalVar7671;
			float4 texArray4660 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4655_0, _Texture_8_Albedo_Index)  );
			half4 ifLocalVar7673 = 0;
			UNITY_BRANCH 
			if( _Texture_8_Albedo_Index > -1.0 )
				ifLocalVar7673 = ( texArray4660 * _Texture_8_Color );
			half4 Texture_8_Final4689 = ifLocalVar7673;
			float4 layeredBlendVar6520 = appendResult6524;
			float4 layeredBlend6520 = ( lerp( lerp( lerp( lerp( layeredBlend6512 , Texture_5_Final4396 , layeredBlendVar6520.x ) , Texture_6_Final4536 , layeredBlendVar6520.y ) , Texture_7_Final4614 , layeredBlendVar6520.z ) , Texture_8_Final4689 , layeredBlendVar6520.w ) );
			float4 texArray4889 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4721_0, _Texture_9_Albedo_Index)  );
			half4 ifLocalVar7690 = 0;
			UNITY_BRANCH 
			if( _Texture_9_Albedo_Index > -1.0 )
				ifLocalVar7690 = ( texArray4889 * _Texture_9_Color );
			half4 Texture_9_Final4987 = ifLocalVar7690;
			float4 texArray4913 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4879_0, _Texture_10_Albedo_Index)  );
			half4 ifLocalVar7688 = 0;
			UNITY_BRANCH 
			if( _Texture_10_Albedo_Index > -1.0 )
				ifLocalVar7688 = ( texArray4913 * _Texture_10_Color );
			half4 Texture_10_Final4994 = ifLocalVar7688;
			float4 texArray4923 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4904_0, _Texture_11_Albedo_Index)  );
			half4 ifLocalVar7686 = 0;
			UNITY_BRANCH 
			if( _Texture_11_Albedo_Index > -1.0 )
				ifLocalVar7686 = ( texArray4923 * _Texture_11_Color );
			half4 Texture_11_Final4996 = ifLocalVar7686;
			float4 texArray4952 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4932_0, _Texture_12_Albedo_Index)  );
			half4 ifLocalVar7684 = 0;
			UNITY_BRANCH 
			if( _Texture_12_Albedo_Index > -1.0 )
				ifLocalVar7684 = ( texArray4952 * _Texture_12_Color );
			half4 Texture_12_Final4997 = ifLocalVar7684;
			float4 layeredBlendVar6528 = appendResult6529;
			float4 layeredBlend6528 = ( lerp( lerp( lerp( lerp( layeredBlend6520 , Texture_9_Final4987 , layeredBlendVar6528.x ) , Texture_10_Final4994 , layeredBlendVar6528.y ) , Texture_11_Final4996 , layeredBlendVar6528.z ) , Texture_12_Final4997 , layeredBlendVar6528.w ) );
			float4 texArray5034 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5112_0, _Texture_13_Albedo_Index)  );
			half4 ifLocalVar7682 = 0;
			UNITY_BRANCH 
			if( _Texture_13_Albedo_Index > -1.0 )
				ifLocalVar7682 = ( texArray5034 * _Texture_13_Color );
			half4 Texture_13_Final5058 = ifLocalVar7682;
			float4 texArray5171 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5172_0, _Texture_14_Albedo_Index)  );
			half4 ifLocalVar7680 = 0;
			UNITY_BRANCH 
			if( _Texture_14_Albedo_Index > -1.0 )
				ifLocalVar7680 = ( texArray5171 * _Texture_14_Color );
			half4 Texture_14_Final5163 = ifLocalVar7680;
			float4 texArray5272 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5190_0, _Texture_15_Albedo_Index)  );
			half4 ifLocalVar7678 = 0;
			UNITY_BRANCH 
			if( _Texture_15_Albedo_Index > -1.0 )
				ifLocalVar7678 = ( texArray5272 * _Texture_15_Color );
			half4 Texture_15_Final5270 = ifLocalVar7678;
			float4 texArray5143 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5153_0, _Texture_16_Albedo_Index)  );
			half4 ifLocalVar7676 = 0;
			UNITY_BRANCH 
			if( _Texture_16_Albedo_Index > -1.0 )
				ifLocalVar7676 = ( texArray5143 * _Texture_16_Color );
			half4 Texture_16_Final5094 = ifLocalVar7676;
			float4 layeredBlendVar6532 = appendResult6533;
			float4 layeredBlend6532 = ( lerp( lerp( lerp( lerp( layeredBlend6528 , Texture_13_Final5058 , layeredBlendVar6532.x ) , Texture_14_Final5163 , layeredBlendVar6532.y ) , Texture_15_Final5270 , layeredBlendVar6532.z ) , Texture_16_Final5094 , layeredBlendVar6532.w ) );
			float4 break3856 = layeredBlend6532;
			float3 appendResult3857 = (half3(break3856.x , break3856.y , break3856.z));
			float3 appendResult7709 = (half3(tex2DNode7708.r , tex2DNode7708.g , tex2DNode7708.b));
			float2 weightedBlendVar7711 = appendResult7710;
			float3 weightedAvg7711 = ( ( weightedBlendVar7711.x*appendResult3857 + weightedBlendVar7711.y*appendResult7709 )/( weightedBlendVar7711.x + weightedBlendVar7711.y ) );
			half2 temp_cast_2 = (( ( ase_worldPos.y / _Geological_Tiling_Far ) + _Geological_Map_Offset_Far )).xx;
			half4 tex2DNode6969 = tex2D( _Texture_Geological_Map, temp_cast_2 );
			float3 appendResult6971 = (half3(tex2DNode6969.r , tex2DNode6969.g , tex2DNode6969.b));
			half3 blendOpSrc4362 = weightedAvg7711;
			half3 blendOpDest4362 = ( ( ( appendResult6971 + float3( -0.3,-0.3,-0.3 ) ) * _Geological_Map_Far_Power ) * ( ( _Texture_16_Geological_Power * Splat4_A2546 ) + ( ( _Texture_15_Geological_Power * Splat4_B2545 ) + ( ( _Texture_14_Geological_Power * Splat4_G2544 ) + ( ( _Texture_13_Geological_Power * Splat4_R2543 ) + ( ( _Texture_12_Geological_Power * Splat3_A2540 ) + ( ( _Texture_11_Geological_Power * Splat3_B2539 ) + ( ( _Texture_10_Geological_Power * Splat3_G2538 ) + ( ( _Texture_9_Geological_Power * Splat3_R2537 ) + ( ( _Texture_8_Geological_Power * Splat2_A2109 ) + ( ( _Texture_7_Geological_Power * Splat2_B2108 ) + ( ( _Texture_6_Geological_Power * Splat2_G2107 ) + ( ( _Texture_5_Geological_Power * Splat2_R2106 ) + ( ( _Texture_1_Geological_Power * Splat1_R1438 ) + ( ( _Texture_2_Geological_Power * Splat1_G1441 ) + ( ( _Texture_4_Geological_Power * Splat1_A1491 ) + ( _Texture_3_Geological_Power * Splat1_B1442 ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) );
			float4 break1409 = ( _Texture_Snow_Average * _Snow_Color );
			float3 appendResult1410 = (half3(break1409.x , break1409.y , break1409.z));
			float3 lerpResult1356 = lerp( ( saturate( ( blendOpSrc4362 + blendOpDest4362 ) )) , appendResult1410 , HeightMask6539);
			o.Albedo = lerpResult1356;
			float3 clampResult6245 = clamp( appendResult1410 , float3( 0,0,0 ) , float3( 0.5,0.5,0.5 ) );
			float3 lerpResult4040 = lerp( ( ( appendResult3857 * float3( 0.3,0.3,0.3 ) ) * _Terrain_Specular ) , ( clampResult6245 * _Snow_Specular ) , HeightMask6539);
			o.Specular = lerpResult4040;
			float lerpResult3951 = lerp( ( break3856.w * _Terrain_Smoothness ) , break1409.w , HeightMask6539);
			o.Smoothness = lerpResult3951;
			float clampResult7695 = clamp( ( ( 1.0 + temp_output_4100_0.y ) * 0.5 ) , ( 1.0 - _Ambient_Occlusion_Power ) , 1.0 );
			#ifdef _USE_AO_TEXTURE_ON
				float staticSwitch7703 = 1.0;
			#else
				float staticSwitch7703 = clampResult7695;
			#endif
			o.Occlusion = staticSwitch7703;
			o.Alpha = 1;
			float2 uv_TerrainHolesTexture = i.uv_texcoord * _TerrainHolesTexture_ST.xy + _TerrainHolesTexture_ST.zw;
			float clampResult7733 = clamp( ( ase_worldPos.y + ( 0.0 - _Remove_Vert_Height ) ) , 0.0 , 1.0 );
			clip( ( tex2D( _TerrainHolesTexture, uv_TerrainHolesTexture ).r * clampResult7733 ) - _Cutoff );
			MixedNormal(o.Normal, i.tc.zw);
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf StandardSpecular keepalpha fullforwardshadows vertex:SplatmapVert 

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.5
			#pragma multi_compile_shadowcaster
			#pragma multi_compile UNITY_PASS_SHADOWCASTER
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			#include "HLSLSupport.cginc"
			#if ( SHADER_API_D3D11 || SHADER_API_GLCORE || SHADER_API_GLES || SHADER_API_GLES3 || SHADER_API_METAL || SHADER_API_VULKAN )
				#define CAN_SKIP_VPOS
			#endif
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityPBSLighting.cginc"
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float2 customPack1 : TEXCOORD1;
				float4 tSpace0 : TEXCOORD2;
				float4 tSpace1 : TEXCOORD3;
				float4 tSpace2 : TEXCOORD4;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			v2f vert( appdata_full v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_INITIALIZE_OUTPUT( v2f, o );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				Input customInputData;
				SplatmapVert(v, customInputData);
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				half3 worldTangent = UnityObjectToWorldDir( v.tangent.xyz );
				half tangentSign = v.tangent.w * unity_WorldTransformParams.w;
				half3 worldBinormal = cross( worldNormal, worldTangent ) * tangentSign;
				o.tSpace0 = float4( worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x );
				o.tSpace1 = float4( worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y );
				o.tSpace2 = float4( worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z );
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				return o;
			}
			half4 frag( v2f IN
			#if !defined( CAN_SKIP_VPOS )
			, UNITY_VPOS_TYPE vpos : VPOS
			#endif
			) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				Input surfIN;
				UNITY_INITIALIZE_OUTPUT( Input, surfIN );
				surfIN.uv_texcoord = IN.customPack1.xy;
				float3 worldPos = float3( IN.tSpace0.w, IN.tSpace1.w, IN.tSpace2.w );
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				surfIN.worldPos = worldPos;
				surfIN.worldNormal = float3( IN.tSpace0.z, IN.tSpace1.z, IN.tSpace2.z );
				surfIN.internalSurfaceTtoW0 = IN.tSpace0.xyz;
				surfIN.internalSurfaceTtoW1 = IN.tSpace1.xyz;
				surfIN.internalSurfaceTtoW2 = IN.tSpace2.xyz;
				SurfaceOutputStandardSpecular o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputStandardSpecular, o )
				surf( surfIN, o );
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
		  UsePass "Hidden/Nature/Terrain/Utilities/PICKING"
		  UsePass "Hidden/Nature/Terrain/Utilities/SELECTION"

	}
	Fallback "Diffuse"
}