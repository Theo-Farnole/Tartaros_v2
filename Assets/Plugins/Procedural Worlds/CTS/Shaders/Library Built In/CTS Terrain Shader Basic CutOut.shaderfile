Shader "CTS/CTS Terrain Shader Basic CutOut"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_Geological_Tiling_Far("Geological_Tiling_Far", Range( 0 , 1000)) = 87
		_Geological_Tiling_Close("Geological_Tiling_Close", Range( 0 , 1000)) = 87
		_Geological_Map_Offset_Far("Geological_Map_Offset _Far", Range( 0 , 1)) = 1
		_Texture_Glitter("Texture_Glitter", 2D) = "black" {}
		_Global_Color_Map_Far_Power("Global_Color_Map_Far_Power", Range( 0 , 10)) = 5
		_Global_Color_Map_Close_Power("Global_Color_Map_Close_Power", Range( 0 , 10)) = 0.1
		_Geological_Map_Offset_Close("Geological_Map_Offset _Close", Range( 0 , 1)) = 1
		_Gliter_Color_Power("Gliter_Color_Power", Range( 0 , 2)) = 0.8
		_Geological_Map_Close_Power("Geological_Map_Close_Power", Range( 0 , 1)) = 0
		_Global_Color_Opacity_Power("Global_Color_Opacity_Power", Range( 0 , 1)) = 0
		_Geological_Map_Far_Power("Geological_Map_Far_Power", Range( 0 , 1)) = 1
		_Glitter_Noise_Threshold("Glitter_Noise_Threshold", Range( 0 , 1)) = 0.991
		_UV_Mix_Power("UV_Mix_Power", Range( 0.01 , 10)) = 4
		_Glitter_Specular("Glitter_Specular", Range( 0 , 3)) = 0.2
		_UV_Mix_Start_Distance("UV_Mix_Start_Distance", Range( 0 , 100000)) = 400
		_Perlin_Normal_Tiling_Close("Perlin_Normal_Tiling_Close", Range( 0.01 , 1000)) = 40
		_Glitter_Smoothness("Glitter_Smoothness", Range( 0 , 1)) = 0.9
		_Perlin_Normal_Tiling_Far("Perlin_Normal_Tiling_Far", Range( 0.01 , 1000)) = 40
		_Perlin_Normal_Power("Perlin_Normal_Power", Range( 0 , 10)) = 1
		_Perlin_Normal_Power_Close("Perlin_Normal_Power_Close", Range( 0 , 10)) = 0.5
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
		_Texture_1_Perlin_Power("Texture_1_Perlin_Power", Range( 0 , 1)) = 0
		_Texture_2_Perlin_Power("Texture_2_Perlin_Power", Range( 0 , 1)) = 0
		_Texture_3_Perlin_Power("Texture_3_Perlin_Power", Range( 0 , 1)) = 0
		_Texture_4_Perlin_Power("Texture_4_Perlin_Power", Range( 0 , 1)) = 0
		_Texture_5_Perlin_Power("Texture_5_Perlin_Power", Range( 0 , 1)) = 0
		_Texture_6_Perlin_Power("Texture_6_Perlin_Power", Range( 0 , 1)) = 0
		_Texture_7_Perlin_Power("Texture_7_Perlin_Power", Range( 0 , 1)) = 0
		_Texture_8_Perlin_Power("Texture_8_Perlin_Power", Range( 0 , 1)) = 0
		_Texture_9_Perlin_Power("Texture_9_Perlin_Power", Range( 0 , 1)) = 0
		_Texture_10_Perlin_Power("Texture_10_Perlin_Power", Range( 0 , 1)) = 0
		_Texture_11_Perlin_Power("Texture_11_Perlin_Power", Range( 0 , 1)) = 0
		_Texture_12_Perlin_Power("Texture_12_Perlin_Power", Range( 0 , 1)) = 0
		_Texture_13_Perlin_Power("Texture_13_Perlin_Power", Range( 0 , 1)) = 0
		_Texture_Array_Normal("Texture_Array_Normal", 2DArray ) = "" {}
		_Texture_14_Perlin_Power("Texture_14_Perlin_Power", Range( 0 , 1)) = 0
		_Texture_15_Perlin_Power("Texture_15_Perlin_Power", Range( 0 , 1)) = 0
		_Texture_16_Perlin_Power("Texture_16_Perlin_Power", Range( 0 , 1)) = 0
		_Texture_Array_Albedo("Texture_Array_Albedo", 2DArray ) = "" {}
		_Texture_1_Geological_Power("Texture_1_Geological_Power", Range( 0 , 5)) = 1
		_Texture_2_Geological_Power("Texture_2_Geological_Power", Range( 0 , 5)) = 1
		_Texture_3_Geological_Power("Texture_3_Geological_Power", Range( 0 , 5)) = 1
		_Texture_4_Geological_Power("Texture_4_Geological_Power", Range( 0 , 5)) = 1
		_Texture_5_Geological_Power("Texture_5_Geological_Power", Range( 0 , 5)) = 1
		_Texture_6_Geological_Power("Texture_6_Geological_Power", Range( 0 , 5)) = 1
		_Texture_7_Geological_Power("Texture_7_Geological_Power", Range( 0 , 5)) = 1
		_Texture_8_Geological_Power("Texture_8_Geological_Power", Range( 0 , 5)) = 1
		_Texture_9_Geological_Power("Texture_9_Geological_Power", Range( 0 , 5)) = 1
		_Texture_10_Geological_Power("Texture_10_Geological_Power", Range( 0 , 5)) = 1
		_Texture_11_Geological_Power("Texture_11_Geological_Power", Range( 0 , 5)) = 1
		_Texture_12_Geological_Power("Texture_12_Geological_Power", Range( 0 , 5)) = 1
		_Texture_13_Geological_Power("Texture_13_Geological_Power", Range( 0 , 5)) = 1
		_Texture_14_Geological_Power("Texture_14_Geological_Power", Range( 0 , 5)) = 1
		_Texture_15_Geological_Power("Texture_15_Geological_Power", Range( 0 , 5)) = 1
		_Texture_16_Geological_Power("Texture_16_Geological_Power", Range( 0 , 5)) = 1
		_Snow_Specular("Snow_Specular", Range( 0 , 3)) = 1
		_Snow_Normal_Scale("Snow_Normal_Scale", Range( 0 , 5)) = 1
		_Snow_Blend_Normal("Snow_Blend_Normal", Range( 0 , 1)) = 0.8
		_Snow_Amount("Snow_Amount", Range( 0 , 2)) = 0
		_Snow_Tiling("Snow_Tiling", Range( 0.001 , 20)) = 15
		_Snow_Perlin_Power("Snow_Perlin_Power", Range( 0 , 1)) = 0
		_Snow_Noise_Power("Snow_Noise_Power", Range( 0 , 1)) = 1
		_Snow_Noise_Tiling("Snow_Noise_Tiling", Range( 0.001 , 1)) = 0.02
		_Snow_Min_Height("Snow_Min_Height", Range( -1000 , 10000)) = -1000
		_Snow_Min_Height_Blending("Snow_Min_Height_Blending", Range( 0 , 500)) = 1
		_Snow_Maximum_Angle("Snow_Maximum_Angle", Range( 0.001 , 180)) = 30
		_Snow_Maximum_Angle_Hardness("Snow_Maximum_Angle_Hardness", Range( 0.01 , 3)) = 1
		_Texture_1_Snow_Reduction("Texture_1_Snow_Reduction", Range( 0 , 1)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		_Texture_2_Snow_Reduction("Texture_2_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_3_Snow_Reduction("Texture_3_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_4_Snow_Reduction("Texture_4_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_5_Snow_Reduction("Texture_5_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_6_Snow_Reduction("Texture_6_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_7_Snow_Reduction("Texture_7_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_8_Snow_Reduction("Texture_8_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_9_Snow_Reduction("Texture_9_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_10_Snow_Reduction("Texture_10_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_11_Snow_Reduction("Texture_11_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_12_Snow_Reduction("Texture_12_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_13_Snow_Reduction("Texture_13_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_14_Snow_Reduction("Texture_14_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_15_Snow_Reduction("Texture_15_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_16_Snow_Reduction("Texture_16_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_Perlin_Normal_Index("Texture_Perlin_Normal_Index", Int) = -1
		_Texture_1_Normal_Power("Texture_1_Normal_Power", Range( 0 , 5)) = 1
		_Texture_2_Normal_Power("Texture_2_Normal_Power", Range( 0 , 5)) = 1
		_Texture_3_Normal_Power("Texture_3_Normal_Power", Range( 0 , 5)) = 1
		_Texture_4_Normal_Power("Texture_4_Normal_Power", Range( 0 , 5)) = 1
		_Texture_5_Normal_Power("Texture_5_Normal_Power", Range( 0 , 5)) = 1
		_Texture_6_Normal_Power("Texture_6_Normal_Power", Range( 0 , 5)) = 1
		_Texture_7_Normal_Power("Texture_7_Normal_Power", Range( 0 , 5)) = 1
		_Texture_8_Normal_Power("Texture_8_Normal_Power", Range( 0 , 5)) = 1
		_Texture_9_Normal_Power("Texture_9_Normal_Power", Range( 0 , 5)) = 1
		_Texture_10_Normal_Power("Texture_10_Normal_Power", Range( 0 , 5)) = 1
		_Texture_11_Normal_Power("Texture_11_Normal_Power", Range( 0 , 5)) = 1
		_Texture_12_Normal_Power("Texture_12_Normal_Power", Range( 0 , 5)) = 1
		_Texture_13_Normal_Power("Texture_13_Normal_Power", Range( 0 , 5)) = 1
		_Texture_14_Normal_Power("Texture_14_Normal_Power", Range( 0 , 5)) = 1
		_Texture_15_Normal_Power("Texture_15_Normal_Power", Range( 0 , 5)) = 1
		_Texture_16_Normal_Power("Texture_16_Normal_Power", Range( 0 , 5)) = 1
		_Texture_Splat_1("Texture_Splat_1", 2D) = "black" {}
		_Texture_Splat_2("Texture_Splat_2", 2D) = "black" {}
		_Texture_Splat_3("Texture_Splat_3", 2D) = "black" {}
		_Texture_Splat_4("Texture_Splat_4", 2D) = "black" {}
		_Global_Normal_Map("Global_Normal_Map", 2D) = "bump" {}
		_Ambient_Occlusion_Power("Ambient_Occlusion_Power", Range( 0 , 1)) = 1
		_Texture_3_Triplanar("Texture_3_Triplanar", Range( 0 , 1)) = 0
		_Texture_Snow_Index("Texture_Snow_Index", Range( -1 , 100)) = -1
		_Texture_Snow_Normal_Index("Texture_Snow_Normal_Index", Range( -1 , 100)) = -1
		_Texture_4_Triplanar("Texture_4_Triplanar", Range( 0 , 1)) = 0
		_Texture_2_Triplanar("Texture_2_Triplanar", Range( 0 , 1)) = 0
		_Texture_6_Triplanar("Texture_6_Triplanar", Range( 0 , 1)) = 0
		_Texture_Snow_Average("Texture_Snow_Average", Vector) = (0,0,0,0)
		_Texture_8_Triplanar("Texture_8_Triplanar", Range( 0 , 1)) = 0
		_Remove_Vert_Height("Remove_Vert_Height", Range( -10000 , 10000)) = -1000
		_Texture_9_Triplanar("Texture_9_Triplanar", Range( 0 , 1)) = 0
		_Texture_10_Triplanar("Texture_10_Triplanar", Range( 0 , 1)) = 0
		_Texture_11_Triplanar("Texture_11_Triplanar", Range( 0 , 1)) = 0
		_Texture_12_Triplanar("Texture_12_Triplanar", Range( 0 , 1)) = 0
		_Texture_13_Triplanar("Texture_13_Triplanar", Range( 0 , 1)) = 0
		_Texture_14_Triplanar("Texture_14_Triplanar", Range( 0 , 1)) = 0
		_Texture_15_Triplanar("Texture_15_Triplanar", Range( 0 , 1)) = 0
		_Texture_16_Triplanar("Texture_16_Triplanar", Range( 0 , 1)) = 0
		_Texture_7_Triplanar("Texture_7_Triplanar", Range( 0 , 1)) = 0
		_Texture_5_Triplanar("Texture_5_Triplanar", Range( 0 , 1)) = 0
		_Texture_1_Triplanar("Texture_1_Triplanar", Range( 0 , 1)) = 0
		_Texture_Geological_Map("Texture_Geological_Map", 2D) = "white" {}
		_Texture_4_Color("Texture_4_Color", Vector) = (1,1,1,1)
		_Snow_Color("Snow_Color", Vector) = (1,1,1,1)
		_Texture_16_Color("Texture_16_Color", Vector) = (1,1,1,1)
		_Texture_8_Color("Texture_8_Color", Vector) = (1,1,1,1)
		_Texture_7_Color("Texture_7_Color", Vector) = (1,1,1,1)
		_Texture_6_Color("Texture_6_Color", Vector) = (1,1,1,1)
		_Texture_5_Color("Texture_5_Color", Vector) = (1,1,1,1)
		_Texture_2_Color("Texture_2_Color", Vector) = (1,1,1,1)
		_Texture_3_Color("Texture_3_Color", Vector) = (1,1,1,1)
		_Texture_13_Color("Texture_13_Color", Vector) = (1,1,1,1)
		_Texture_15_Color("Texture_15_Color", Vector) = (1,1,1,1)
		_Texture_14_Color("Texture_14_Color", Vector) = (1,1,1,1)
		_Texture_9_Color("Texture_9_Color", Vector) = (1,1,1,1)
		_Texture_12_Color("Texture_12_Color", Vector) = (1,1,1,1)
		_Texture_11_Color("Texture_11_Color", Vector) = (1,1,1,1)
		_Texture_10_Color("Texture_10_Color", Vector) = (1,1,1,1)
		_Texture_1_Color("Texture_1_Color", Vector) = (1,1,1,1)
		_Texture_1_Albedo_Index("Texture_1_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_1_Normal_Index("Texture_1_Normal_Index", Range( -1 , 100)) = -1
		_Texture_2_Albedo_Index("Texture_2_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_3_Albedo_Index("Texture_3_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_3_Normal_Index("Texture_3_Normal_Index", Range( -1 , 100)) = -1
		_Texture_4_Albedo_Index("Texture_4_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_4_Normal_Index("Texture_4_Normal_Index", Range( -1 , 100)) = -1
		_Texture_5_Albedo_Index("Texture_5_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_5_Normal_Index("Texture_5_Normal_Index", Range( -1 , 100)) = -1
		_Texture_6_Normal_Index("Texture_6_Normal_Index", Range( -1 , 100)) = -1
		_Texture_6_Albedo_Index("Texture_6_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_7_Normal_Index("Texture_7_Normal_Index", Range( -1 , 100)) = -1
		_Texture_8_Albedo_Index("Texture_8_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_2_Normal_Index("Texture_2_Normal_Index", Range( -1 , 100)) = -1
		_Texture_8_Normal_Index("Texture_8_Normal_Index", Range( -1 , 100)) = -1
		_Texture_16_Normal_Index("Texture_16_Normal_Index", Range( -1 , 100)) = -1
		_Texture_15_Normal_Index("Texture_15_Normal_Index", Range( -1 , 100)) = -1
		_Texture_15_Albedo_Index("Texture_15_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_7_Albedo_Index("Texture_7_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_14_Normal_Index("Texture_14_Normal_Index", Range( -1 , 100)) = -1
		_Texture_13_Normal_Index("Texture_13_Normal_Index", Range( -1 , 100)) = -1
		_Texture_14_Albedo_Index("Texture_14_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_13_Albedo_Index("Texture_13_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_12_Normal_Index("Texture_12_Normal_Index", Range( -1 , 100)) = -1
		_Texture_12_Albedo_Index("Texture_12_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_11_Normal_Index("Texture_11_Normal_Index", Range( -1 , 100)) = -1
		_Texture_11_Albedo_Index("Texture_11_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_10_Normal_Index("Texture_10_Normal_Index", Range( -1 , 100)) = -1
		_Texture_10_Albedo_Index("Texture_10_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_9_Normal_Index("Texture_9_Normal_Index", Range( -1 , 100)) = -1
		[Toggle(_USE_AO_ON)] _Use_AO("Use_AO", Float) = 0
		_Texture_9_Albedo_Index("Texture_9_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_16_Albedo_Index("Texture_16_Albedo_Index", Range( -1 , 100)) = -1
		_Global_Color_Map("Global_Color_Map", 2D) = "white" {}
		_Global_Color_Map_Scale("Global_Color_Map_Scale", Float) = 1
		_Global_Color_Map_Offset("Global_Color_Map_Offset", Vector) = (0,0,0,0)
		_TerrainHolesTexture("Holes Map (RGB)", 2D) = "white" {}
		_Glitter_Refreshing_Speed("Glitter_Refreshing_Speed", Range( 0 , 7)) = 4
		_Glitter_Tiling("Glitter_Tiling", Range( 0 , 100)) = 3
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "Geometry-100" }
		Cull Back
		ZTest LEqual
		CGINCLUDE
		#include "UnityStandardUtils.cginc"
		#include "UnityShaderVariables.cginc"
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 3.5
		#pragma multi_compile __ _USE_AO_ON
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
		uniform half _Perlin_Normal_Tiling_Close;
		uniform int _Texture_Perlin_Normal_Index;
		uniform half _Perlin_Normal_Power_Close;
		uniform half _Perlin_Normal_Tiling_Far;
		uniform half _Perlin_Normal_Power;
		uniform half _UV_Mix_Start_Distance;
		uniform half _UV_Mix_Power;
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
		uniform half _Texture_1_Normal_Index;
		uniform half _Texture_1_Triplanar;
		uniform half _Texture_1_Tiling;
		uniform half _Texture_1_Normal_Power;
		uniform half _Texture_2_Normal_Index;
		uniform half _Texture_2_Triplanar;
		uniform half _Texture_2_Tiling;
		uniform half _Texture_2_Normal_Power;
		uniform half _Texture_3_Normal_Index;
		uniform half _Texture_3_Triplanar;
		uniform half _Texture_3_Tiling;
		uniform half _Texture_3_Normal_Power;
		uniform half _Texture_3_Far_Multiplier;
		uniform half _Texture_4_Normal_Index;
		uniform half _Texture_4_Triplanar;
		uniform half _Texture_4_Tiling;
		uniform half _Texture_4_Normal_Power;
		uniform half _Texture_5_Normal_Index;
		uniform half _Texture_5_Triplanar;
		uniform half _Texture_5_Tiling;
		uniform half _Texture_5_Normal_Power;
		uniform half _Texture_6_Normal_Index;
		uniform half _Texture_6_Triplanar;
		uniform half _Texture_6_Tiling;
		uniform half _Texture_6_Normal_Power;
		uniform half _Texture_7_Normal_Index;
		uniform half _Texture_7_Triplanar;
		uniform half _Texture_7_Tiling;
		uniform half _Texture_7_Normal_Power;
		uniform half _Texture_8_Normal_Index;
		uniform half _Texture_8_Triplanar;
		uniform half _Texture_8_Tiling;
		uniform half _Texture_8_Normal_Power;
		uniform half _Texture_9_Normal_Index;
		uniform half _Texture_9_Triplanar;
		uniform half _Texture_9_Tiling;
		uniform half _Texture_9_Normal_Power;
		uniform half _Texture_10_Normal_Index;
		uniform half _Texture_10_Triplanar;
		uniform half _Texture_10_Tiling;
		uniform half _Texture_10_Normal_Power;
		uniform half _Texture_11_Normal_Index;
		uniform half _Texture_11_Triplanar;
		uniform half _Texture_11_Tiling;
		uniform half _Texture_11_Normal_Power;
		uniform half _Texture_12_Normal_Index;
		uniform half _Texture_12_Triplanar;
		uniform half _Texture_12_Tiling;
		uniform half _Texture_12_Normal_Power;
		uniform half _Texture_13_Normal_Index;
		uniform half _Texture_13_Triplanar;
		uniform half _Texture_13_Tiling;
		uniform half _Texture_13_Normal_Power;
		uniform half _Texture_14_Normal_Index;
		uniform half _Texture_14_Triplanar;
		uniform half _Texture_14_Tiling;
		uniform half _Texture_14_Normal_Power;
		uniform half _Texture_15_Normal_Index;
		uniform half _Texture_15_Triplanar;
		uniform half _Texture_15_Tiling;
		uniform half _Texture_15_Normal_Power;
		uniform half _Texture_16_Normal_Index;
		uniform half _Texture_16_Triplanar;
		uniform half _Texture_16_Tiling;
		uniform half _Texture_16_Normal_Power;
		uniform half _Texture_Snow_Normal_Index;
		uniform half _Snow_Tiling;
		uniform half _Snow_Normal_Scale;
		uniform half _Snow_Blend_Normal;
		uniform half _Snow_Amount;
		uniform half _Snow_Noise_Tiling;
		uniform half _Snow_Noise_Power;
		uniform half _Snow_Maximum_Angle;
		uniform half _Snow_Maximum_Angle_Hardness;
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
		uniform half _Global_Normalmap_Power;
		uniform sampler2D _Global_Normal_Map;
		uniform half _Global_Color_Map_Close_Power;
		uniform half _Global_Color_Map_Far_Power;
		uniform sampler2D _Global_Color_Map;
		uniform half2 _Global_Color_Map_Offset;
		uniform half _Global_Color_Map_Scale;
		uniform half _Global_Color_Opacity_Power;
		uniform half _Texture_1_Albedo_Index;
		uniform UNITY_DECLARE_TEX2DARRAY( _Texture_Array_Albedo );
		uniform half _Texture_1_Far_Multiplier;
		uniform half4 _Texture_1_Color;
		uniform half _Texture_2_Albedo_Index;
		uniform half _Texture_2_Far_Multiplier;
		uniform half4 _Texture_2_Color;
		uniform half _Texture_3_Albedo_Index;
		uniform half4 _Texture_3_Color;
		uniform half _Texture_4_Albedo_Index;
		uniform half _Texture_4_Far_Multiplier;
		uniform half4 _Texture_4_Color;
		uniform half _Texture_5_Albedo_Index;
		uniform half _Texture_5_Far_Multiplier;
		uniform half4 _Texture_5_Color;
		uniform half _Texture_6_Albedo_Index;
		uniform half _Texture_6_Far_Multiplier;
		uniform half4 _Texture_6_Color;
		uniform half _Texture_7_Albedo_Index;
		uniform half _Texture_7_Far_Multiplier;
		uniform half4 _Texture_7_Color;
		uniform half _Texture_8_Albedo_Index;
		uniform half _Texture_8_Far_Multiplier;
		uniform half4 _Texture_8_Color;
		uniform half _Texture_9_Albedo_Index;
		uniform half _Texture_9_Far_Multiplier;
		uniform half4 _Texture_9_Color;
		uniform half _Texture_10_Albedo_Index;
		uniform half _Texture_10_Far_Multiplier;
		uniform half4 _Texture_10_Color;
		uniform half _Texture_11_Albedo_Index;
		uniform half _Texture_11_Far_Multiplier;
		uniform half4 _Texture_11_Color;
		uniform half _Texture_12_Albedo_Index;
		uniform half _Texture_12_Far_Multiplier;
		uniform half4 _Texture_12_Color;
		uniform half _Texture_13_Albedo_Index;
		uniform half _Texture_13_Far_Multiplier;
		uniform half4 _Texture_13_Color;
		uniform half _Texture_14_Albedo_Index;
		uniform half _Texture_14_Far_Multiplier;
		uniform half4 _Texture_14_Color;
		uniform half _Texture_15_Albedo_Index;
		uniform half _Texture_15_Far_Multiplier;
		uniform half4 _Texture_15_Color;
		uniform half _Texture_16_Albedo_Index;
		uniform half _Texture_16_Far_Multiplier;
		uniform half4 _Texture_16_Color;
		uniform half _Geological_Map_Close_Power;
		uniform sampler2D _Texture_Geological_Map;
		uniform half _Geological_Map_Offset_Close;
		uniform half _Geological_Tiling_Close;
		uniform half _Geological_Map_Far_Power;
		uniform half _Geological_Tiling_Far;
		uniform half _Geological_Map_Offset_Far;
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
		uniform half _Texture_Snow_Index;
		uniform half4 _Texture_Snow_Average;
		uniform half4 _Snow_Color;
		uniform half _Gliter_Color_Power;
		uniform half _Glitter_Refreshing_Speed;
		uniform sampler2D _Texture_Glitter;
		uniform half _Glitter_Tiling;
		uniform half _Glitter_Noise_Threshold;
		uniform half _Terrain_Specular;
		uniform half _Snow_Specular;
		uniform half _Glitter_Specular;
		uniform half _Terrain_Smoothness;
		uniform half _Glitter_Smoothness;
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


		inline half MyCustomExpression6279( inout half3 In0 )
		{
			return UNITY_MATRIX_IT_MV[2].xyz;
		}


		void surf( Input i , inout SurfaceOutputStandardSpecular o )
		{
			float3 ase_worldPos = i.worldPos;
			float3 break6329 = ase_worldPos;
			float2 appendResult6267 = (half2(break6329.x , break6329.z));
			half2 Top_Bottom1999 = appendResult6267;
			float4 texArray5480 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(( Top_Bottom1999 / _Perlin_Normal_Tiling_Close ), (float)_Texture_Perlin_Normal_Index)  );
			float2 appendResult11_g1034 = (half2(texArray5480.w , texArray5480.y));
			float2 temp_output_4_0_g1034 = ( ( ( appendResult11_g1034 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Perlin_Normal_Power_Close );
			float2 break8_g1034 = temp_output_4_0_g1034;
			float dotResult5_g1034 = dot( temp_output_4_0_g1034 , temp_output_4_0_g1034 );
			float temp_output_9_0_g1034 = sqrt( ( 1.0 - saturate( dotResult5_g1034 ) ) );
			float3 appendResult20_g1034 = (half3(break8_g1034.x , break8_g1034.y , temp_output_9_0_g1034));
			float4 texArray4374 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(( Top_Bottom1999 / _Perlin_Normal_Tiling_Far ), (float)_Texture_Perlin_Normal_Index)  );
			float2 appendResult11_g1033 = (half2(texArray4374.w , texArray4374.y));
			float2 temp_output_4_0_g1033 = ( ( ( appendResult11_g1033 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Perlin_Normal_Power );
			float2 break8_g1033 = temp_output_4_0_g1033;
			float dotResult5_g1033 = dot( temp_output_4_0_g1033 , temp_output_4_0_g1033 );
			float temp_output_9_0_g1033 = sqrt( ( 1.0 - saturate( dotResult5_g1033 ) ) );
			float3 appendResult20_g1033 = (half3(break8_g1033.x , break8_g1033.y , temp_output_9_0_g1033));
			float3 break6201 = abs( ( ase_worldPos - _WorldSpaceCameraPos ) );
			float clampResult297 = clamp( pow( ( max( max( break6201.x , break6201.y ) , break6201.z ) / _UV_Mix_Start_Distance ) , _UV_Mix_Power ) , 0.0 , 1.0 );
			half UVmixDistance636 = clampResult297;
			float3 lerpResult5460 = lerp( appendResult20_g1034 , appendResult20_g1033 , UVmixDistance636);
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
			float3 lerpResult3776 = lerp( float3( 0,0,1 ) , lerpResult5460 , clampResult3775);
			float3 lerpResult3906 = lerp( float3( 0,0,1 ) , lerpResult5460 , ( _Snow_Perlin_Power * 0.5 ));
			float temp_output_3830_0 = ( 1.0 / _Texture_1_Tiling );
			float2 appendResult3284 = (half2(temp_output_3830_0 , temp_output_3830_0));
			float2 temp_output_3275_0 = ( Top_Bottom1999 * appendResult3284 );
			float4 texArray3300 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3275_0, _Texture_1_Normal_Index)  );
			float2 appendResult11_g992 = (half2(texArray3300.w , texArray3300.y));
			float2 temp_output_4_0_g992 = ( ( ( appendResult11_g992 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_1_Normal_Power );
			float2 break8_g992 = temp_output_4_0_g992;
			float dotResult5_g992 = dot( temp_output_4_0_g992 , temp_output_4_0_g992 );
			float temp_output_9_0_g992 = sqrt( ( 1.0 - saturate( dotResult5_g992 ) ) );
			float3 appendResult20_g992 = (half3(break8_g992.x , break8_g992.y , temp_output_9_0_g992));
			float3 temp_output_6001_0 = appendResult20_g992;
			half3 ase_worldNormal = WorldNormalVector( i, half3( 0, 0, 1 ) );
			NormalForWorld(ase_worldNormal, i.tc.zw);
			float3 clampResult5488 = clamp( pow( ( ase_worldNormal * ase_worldNormal ) , 25.0 ) , float3( -1,-1,-1 ) , float3( 1,1,1 ) );
			half3 BlendComponents91 = clampResult5488;
			float2 appendResult6265 = (half2(break6329.z , break6329.y));
			half2 Front_Back1991 = appendResult6265;
			float2 temp_output_3279_0 = ( Front_Back1991 * appendResult3284 );
			float4 texArray3299 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3279_0, _Texture_1_Normal_Index)  );
			float2 appendResult11_g805 = (half2(texArray3299.w , texArray3299.y));
			float2 temp_output_4_0_g805 = ( ( ( appendResult11_g805 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_1_Normal_Power * -1.0 ) );
			float2 break8_g805 = temp_output_4_0_g805;
			float dotResult5_g805 = dot( temp_output_4_0_g805 , temp_output_4_0_g805 );
			float temp_output_9_0_g805 = sqrt( ( 1.0 - saturate( dotResult5_g805 ) ) );
			float3 appendResult21_g805 = (half3(break8_g805.y , break8_g805.x , temp_output_9_0_g805));
			float3 appendResult5874 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float2 appendResult6266 = (half2(break6329.x , break6329.y));
			half2 Left_Right2003 = appendResult6266;
			float2 temp_output_3277_0 = ( Left_Right2003 * appendResult3284 );
			float4 texArray3301 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3277_0, _Texture_1_Normal_Index)  );
			float2 appendResult11_g804 = (half2(texArray3301.w , texArray3301.y));
			float2 temp_output_4_0_g804 = ( ( ( appendResult11_g804 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_1_Normal_Power );
			float2 break8_g804 = temp_output_4_0_g804;
			float dotResult5_g804 = dot( temp_output_4_0_g804 , temp_output_4_0_g804 );
			float temp_output_9_0_g804 = sqrt( ( 1.0 - saturate( dotResult5_g804 ) ) );
			float3 appendResult20_g804 = (half3(break8_g804.x , break8_g804.y , temp_output_9_0_g804));
			float3 appendResult5876 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar5676 = BlendComponents91;
			float3 weightedAvg5676 = ( ( weightedBlendVar5676.x*( appendResult21_g805 * appendResult5874 ) + weightedBlendVar5676.y*temp_output_6001_0 + weightedBlendVar5676.z*( appendResult20_g804 * appendResult5876 ) )/( weightedBlendVar5676.x + weightedBlendVar5676.y + weightedBlendVar5676.z ) );
			half3 ifLocalVar5783 = 0;
			UNITY_BRANCH 
			if( _Texture_1_Triplanar == 1.0 )
				ifLocalVar5783 = weightedAvg5676;
			else
				ifLocalVar5783 = temp_output_6001_0;
			half3 EmptyNRM6172 = half3(0,0,1);
			half3 ifLocalVar6127 = 0;
			UNITY_BRANCH 
			if( _Texture_1_Normal_Index <= -1.0 )
				ifLocalVar6127 = EmptyNRM6172;
			else
				ifLocalVar6127 = ifLocalVar5783;
			half3 Normal_1569 = ifLocalVar6127;
			float temp_output_3831_0 = ( 1.0 / _Texture_2_Tiling );
			float2 appendResult3349 = (half2(temp_output_3831_0 , temp_output_3831_0));
			float2 temp_output_3343_0 = ( Top_Bottom1999 * appendResult3349 );
			float4 texArray3350 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3343_0, _Texture_2_Normal_Index)  );
			float2 appendResult11_g988 = (half2(texArray3350.w , texArray3350.y));
			float2 temp_output_4_0_g988 = ( ( ( appendResult11_g988 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_2_Normal_Power );
			float2 break8_g988 = temp_output_4_0_g988;
			float dotResult5_g988 = dot( temp_output_4_0_g988 , temp_output_4_0_g988 );
			float temp_output_9_0_g988 = sqrt( ( 1.0 - saturate( dotResult5_g988 ) ) );
			float3 appendResult20_g988 = (half3(break8_g988.x , break8_g988.y , temp_output_9_0_g988));
			float3 temp_output_6005_0 = appendResult20_g988;
			float2 temp_output_3344_0 = ( Front_Back1991 * appendResult3349 );
			float4 texArray3384 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3344_0, _Texture_2_Normal_Index)  );
			float2 appendResult11_g807 = (half2(texArray3384.w , texArray3384.y));
			float2 temp_output_4_0_g807 = ( ( ( appendResult11_g807 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_2_Normal_Power * -1.0 ) );
			float2 break8_g807 = temp_output_4_0_g807;
			float dotResult5_g807 = dot( temp_output_4_0_g807 , temp_output_4_0_g807 );
			float temp_output_9_0_g807 = sqrt( ( 1.0 - saturate( dotResult5_g807 ) ) );
			float3 appendResult21_g807 = (half3(break8_g807.y , break8_g807.x , temp_output_9_0_g807));
			float3 appendResult5879 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float2 temp_output_3379_0 = ( Left_Right2003 * appendResult3349 );
			float4 texArray3351 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3379_0, _Texture_2_Normal_Index)  );
			float2 appendResult11_g801 = (half2(texArray3351.w , texArray3351.y));
			float2 temp_output_4_0_g801 = ( ( ( appendResult11_g801 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_2_Normal_Power );
			float2 break8_g801 = temp_output_4_0_g801;
			float dotResult5_g801 = dot( temp_output_4_0_g801 , temp_output_4_0_g801 );
			float temp_output_9_0_g801 = sqrt( ( 1.0 - saturate( dotResult5_g801 ) ) );
			float3 appendResult20_g801 = (half3(break8_g801.x , break8_g801.y , temp_output_9_0_g801));
			float3 appendResult5882 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar5499 = BlendComponents91;
			float3 weightedAvg5499 = ( ( weightedBlendVar5499.x*( appendResult21_g807 * appendResult5879 ) + weightedBlendVar5499.y*temp_output_6005_0 + weightedBlendVar5499.z*( appendResult20_g801 * appendResult5882 ) )/( weightedBlendVar5499.x + weightedBlendVar5499.y + weightedBlendVar5499.z ) );
			half3 ifLocalVar5774 = 0;
			UNITY_BRANCH 
			if( _Texture_2_Triplanar == 1.0 )
				ifLocalVar5774 = weightedAvg5499;
			else
				ifLocalVar5774 = temp_output_6005_0;
			half3 ifLocalVar6129 = 0;
			UNITY_BRANCH 
			if( _Texture_2_Normal_Index <= -1.0 )
				ifLocalVar6129 = EmptyNRM6172;
			else
				ifLocalVar6129 = ifLocalVar5774;
			half3 Normal_23361 = ifLocalVar6129;
			float temp_output_3832_0 = ( 1.0 / _Texture_3_Tiling );
			float2 appendResult3415 = (half2(temp_output_3832_0 , temp_output_3832_0));
			float2 temp_output_3410_0 = ( Top_Bottom1999 * appendResult3415 );
			float4 texArray3416 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3410_0, _Texture_3_Normal_Index)  );
			float2 appendResult11_g983 = (half2(texArray3416.w , texArray3416.y));
			float2 temp_output_4_0_g983 = ( ( ( appendResult11_g983 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_3_Normal_Power );
			float2 break8_g983 = temp_output_4_0_g983;
			float dotResult5_g983 = dot( temp_output_4_0_g983 , temp_output_4_0_g983 );
			float temp_output_9_0_g983 = sqrt( ( 1.0 - saturate( dotResult5_g983 ) ) );
			float3 appendResult20_g983 = (half3(break8_g983.x , break8_g983.y , temp_output_9_0_g983));
			float3 temp_output_6008_0 = appendResult20_g983;
			float2 temp_output_3411_0 = ( Front_Back1991 * appendResult3415 );
			float2 temp_output_3413_0 = ( temp_output_3411_0 / _Texture_3_Far_Multiplier );
			float4 texArray3445 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3413_0, _Texture_3_Normal_Index)  );
			float2 appendResult11_g806 = (half2(texArray3445.w , texArray3445.y));
			float2 temp_output_4_0_g806 = ( ( ( appendResult11_g806 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_3_Normal_Power * -1.0 ) );
			float2 break8_g806 = temp_output_4_0_g806;
			float dotResult5_g806 = dot( temp_output_4_0_g806 , temp_output_4_0_g806 );
			float temp_output_9_0_g806 = sqrt( ( 1.0 - saturate( dotResult5_g806 ) ) );
			float3 appendResult21_g806 = (half3(break8_g806.y , break8_g806.x , temp_output_9_0_g806));
			float3 appendResult5886 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float2 temp_output_3441_0 = ( Left_Right2003 * appendResult3415 );
			float4 texArray3417 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3441_0, _Texture_3_Normal_Index)  );
			float2 appendResult11_g802 = (half2(texArray3417.w , texArray3417.y));
			float2 temp_output_4_0_g802 = ( ( ( appendResult11_g802 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_3_Normal_Power );
			float2 break8_g802 = temp_output_4_0_g802;
			float dotResult5_g802 = dot( temp_output_4_0_g802 , temp_output_4_0_g802 );
			float temp_output_9_0_g802 = sqrt( ( 1.0 - saturate( dotResult5_g802 ) ) );
			float3 appendResult20_g802 = (half3(break8_g802.x , break8_g802.y , temp_output_9_0_g802));
			float3 appendResult5889 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar5503 = BlendComponents91;
			float3 weightedAvg5503 = ( ( weightedBlendVar5503.x*( appendResult21_g806 * appendResult5886 ) + weightedBlendVar5503.y*temp_output_6008_0 + weightedBlendVar5503.z*( appendResult20_g802 * appendResult5889 ) )/( weightedBlendVar5503.x + weightedBlendVar5503.y + weightedBlendVar5503.z ) );
			half3 ifLocalVar5776 = 0;
			UNITY_BRANCH 
			if( _Texture_3_Triplanar == 1.0 )
				ifLocalVar5776 = weightedAvg5503;
			else
				ifLocalVar5776 = temp_output_6008_0;
			half3 ifLocalVar6131 = 0;
			UNITY_BRANCH 
			if( _Texture_3_Normal_Index > -1.0 )
				ifLocalVar6131 = ifLocalVar5776;
			half3 Normal_33452 = ifLocalVar6131;
			float temp_output_3833_0 = ( 1.0 / _Texture_4_Tiling );
			float2 temp_output_3477_0 = ( Top_Bottom1999 * temp_output_3833_0 );
			float4 texArray3483 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3477_0, _Texture_4_Normal_Index)  );
			float2 appendResult11_g986 = (half2(texArray3483.w , texArray3483.y));
			float2 temp_output_4_0_g986 = ( ( ( appendResult11_g986 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_4_Normal_Power );
			float2 break8_g986 = temp_output_4_0_g986;
			float dotResult5_g986 = dot( temp_output_4_0_g986 , temp_output_4_0_g986 );
			float temp_output_9_0_g986 = sqrt( ( 1.0 - saturate( dotResult5_g986 ) ) );
			float3 appendResult20_g986 = (half3(break8_g986.x , break8_g986.y , temp_output_9_0_g986));
			float3 temp_output_6011_0 = appendResult20_g986;
			float2 temp_output_3478_0 = ( Front_Back1991 * temp_output_3833_0 );
			float4 texArray3512 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3478_0, _Texture_4_Normal_Index)  );
			float2 appendResult11_g808 = (half2(texArray3512.w , texArray3512.y));
			float2 temp_output_4_0_g808 = ( ( ( appendResult11_g808 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_4_Normal_Power * -1.0 ) );
			float2 break8_g808 = temp_output_4_0_g808;
			float dotResult5_g808 = dot( temp_output_4_0_g808 , temp_output_4_0_g808 );
			float temp_output_9_0_g808 = sqrt( ( 1.0 - saturate( dotResult5_g808 ) ) );
			float3 appendResult21_g808 = (half3(break8_g808.y , break8_g808.x , temp_output_9_0_g808));
			float3 appendResult5893 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float2 temp_output_3508_0 = ( Left_Right2003 * temp_output_3833_0 );
			float4 texArray3484 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3508_0, _Texture_4_Normal_Index)  );
			float2 appendResult11_g809 = (half2(texArray3484.w , texArray3484.y));
			float2 temp_output_4_0_g809 = ( ( ( appendResult11_g809 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_4_Normal_Power );
			float2 break8_g809 = temp_output_4_0_g809;
			float dotResult5_g809 = dot( temp_output_4_0_g809 , temp_output_4_0_g809 );
			float temp_output_9_0_g809 = sqrt( ( 1.0 - saturate( dotResult5_g809 ) ) );
			float3 appendResult20_g809 = (half3(break8_g809.x , break8_g809.y , temp_output_9_0_g809));
			float3 appendResult5896 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar5507 = BlendComponents91;
			float3 weightedAvg5507 = ( ( weightedBlendVar5507.x*( appendResult21_g808 * appendResult5893 ) + weightedBlendVar5507.y*temp_output_6011_0 + weightedBlendVar5507.z*( appendResult20_g809 * appendResult5896 ) )/( weightedBlendVar5507.x + weightedBlendVar5507.y + weightedBlendVar5507.z ) );
			half3 ifLocalVar5999 = 0;
			UNITY_BRANCH 
			if( _Texture_4_Triplanar == 1.0 )
				ifLocalVar5999 = weightedAvg5507;
			else
				ifLocalVar5999 = temp_output_6011_0;
			half3 ifLocalVar6133 = 0;
			UNITY_BRANCH 
			if( _Texture_4_Normal_Index <= -1.0 )
				ifLocalVar6133 = EmptyNRM6172;
			else
				ifLocalVar6133 = ifLocalVar5999;
			half3 Normal_43519 = ifLocalVar6133;
			float4 layeredBlendVar5639 = tex2DNode4368;
			float3 layeredBlend5639 = ( lerp( lerp( lerp( lerp( float3( 0,0,0 ) , Normal_1569 , layeredBlendVar5639.x ) , Normal_23361 , layeredBlendVar5639.y ) , Normal_33452 , layeredBlendVar5639.z ) , Normal_43519 , layeredBlendVar5639.w ) );
			float temp_output_4397_0 = ( 1.0 / _Texture_5_Tiling );
			float2 appendResult4399 = (half2(temp_output_4397_0 , temp_output_4397_0));
			float2 temp_output_4416_0 = ( Top_Bottom1999 * appendResult4399 );
			float4 texArray4424 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4416_0, _Texture_5_Normal_Index)  );
			float2 appendResult11_g1004 = (half2(texArray4424.w , texArray4424.y));
			float2 temp_output_4_0_g1004 = ( ( ( appendResult11_g1004 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_5_Normal_Power );
			float2 break8_g1004 = temp_output_4_0_g1004;
			float dotResult5_g1004 = dot( temp_output_4_0_g1004 , temp_output_4_0_g1004 );
			float temp_output_9_0_g1004 = sqrt( ( 1.0 - saturate( dotResult5_g1004 ) ) );
			float3 appendResult20_g1004 = (half3(break8_g1004.x , break8_g1004.y , temp_output_9_0_g1004));
			float3 temp_output_6014_0 = appendResult20_g1004;
			float2 temp_output_4400_0 = ( Front_Back1991 * appendResult4399 );
			float4 texArray4417 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4400_0, _Texture_5_Normal_Index)  );
			float2 appendResult11_g991 = (half2(texArray4417.w , texArray4417.y));
			float2 temp_output_4_0_g991 = ( ( ( appendResult11_g991 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_5_Normal_Power * -1.0 ) );
			float2 break8_g991 = temp_output_4_0_g991;
			float dotResult5_g991 = dot( temp_output_4_0_g991 , temp_output_4_0_g991 );
			float temp_output_9_0_g991 = sqrt( ( 1.0 - saturate( dotResult5_g991 ) ) );
			float3 appendResult21_g991 = (half3(break8_g991.y , break8_g991.x , temp_output_9_0_g991));
			float3 appendResult5900 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float2 temp_output_4413_0 = ( Left_Right2003 * appendResult4399 );
			float4 texArray4422 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4413_0, _Texture_5_Normal_Index)  );
			float2 appendResult11_g989 = (half2(texArray4422.w , texArray4422.y));
			float2 temp_output_4_0_g989 = ( ( ( appendResult11_g989 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_5_Normal_Power );
			float2 break8_g989 = temp_output_4_0_g989;
			float dotResult5_g989 = dot( temp_output_4_0_g989 , temp_output_4_0_g989 );
			float temp_output_9_0_g989 = sqrt( ( 1.0 - saturate( dotResult5_g989 ) ) );
			float3 appendResult20_g989 = (half3(break8_g989.x , break8_g989.y , temp_output_9_0_g989));
			float3 appendResult5903 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar5511 = BlendComponents91;
			float3 weightedAvg5511 = ( ( weightedBlendVar5511.x*( appendResult21_g991 * appendResult5900 ) + weightedBlendVar5511.y*temp_output_6014_0 + weightedBlendVar5511.z*( appendResult20_g989 * appendResult5903 ) )/( weightedBlendVar5511.x + weightedBlendVar5511.y + weightedBlendVar5511.z ) );
			half3 ifLocalVar5806 = 0;
			UNITY_BRANCH 
			if( _Texture_5_Triplanar == 1.0 )
				ifLocalVar5806 = weightedAvg5511;
			else
				ifLocalVar5806 = temp_output_6014_0;
			half3 ifLocalVar6135 = 0;
			UNITY_BRANCH 
			if( _Texture_5_Normal_Index <= -1.0 )
				ifLocalVar6135 = EmptyNRM6172;
			else
				ifLocalVar6135 = ifLocalVar5806;
			half3 Normal_54456 = ifLocalVar6135;
			float temp_output_4469_0 = ( 1.0 / _Texture_6_Tiling );
			float2 appendResult4471 = (half2(temp_output_4469_0 , temp_output_4469_0));
			float2 temp_output_4485_0 = ( Top_Bottom1999 * appendResult4471 );
			float4 texArray4493 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4485_0, _Texture_6_Normal_Index)  );
			float2 appendResult11_g1009 = (half2(texArray4493.w , texArray4493.y));
			float2 temp_output_4_0_g1009 = ( ( ( appendResult11_g1009 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_6_Normal_Power );
			float2 break8_g1009 = temp_output_4_0_g1009;
			float dotResult5_g1009 = dot( temp_output_4_0_g1009 , temp_output_4_0_g1009 );
			float temp_output_9_0_g1009 = sqrt( ( 1.0 - saturate( dotResult5_g1009 ) ) );
			float3 appendResult20_g1009 = (half3(break8_g1009.x , break8_g1009.y , temp_output_9_0_g1009));
			float3 temp_output_6017_0 = appendResult20_g1009;
			float2 temp_output_4472_0 = ( Front_Back1991 * appendResult4471 );
			float4 texArray4486 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4472_0, _Texture_6_Normal_Index)  );
			float2 appendResult11_g984 = (half2(texArray4486.w , texArray4486.y));
			float2 temp_output_4_0_g984 = ( ( ( appendResult11_g984 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_6_Normal_Power * -1.0 ) );
			float2 break8_g984 = temp_output_4_0_g984;
			float dotResult5_g984 = dot( temp_output_4_0_g984 , temp_output_4_0_g984 );
			float temp_output_9_0_g984 = sqrt( ( 1.0 - saturate( dotResult5_g984 ) ) );
			float3 appendResult21_g984 = (half3(break8_g984.y , break8_g984.x , temp_output_9_0_g984));
			float3 appendResult5907 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float2 temp_output_4483_0 = ( Left_Right2003 * appendResult4471 );
			float4 texArray4491 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4483_0, _Texture_6_Normal_Index)  );
			float2 appendResult11_g987 = (half2(texArray4491.w , texArray4491.y));
			float2 temp_output_4_0_g987 = ( ( ( appendResult11_g987 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_6_Normal_Power );
			float2 break8_g987 = temp_output_4_0_g987;
			float dotResult5_g987 = dot( temp_output_4_0_g987 , temp_output_4_0_g987 );
			float temp_output_9_0_g987 = sqrt( ( 1.0 - saturate( dotResult5_g987 ) ) );
			float3 appendResult20_g987 = (half3(break8_g987.x , break8_g987.y , temp_output_9_0_g987));
			float3 appendResult5910 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar5519 = BlendComponents91;
			float3 weightedAvg5519 = ( ( weightedBlendVar5519.x*( appendResult21_g984 * appendResult5907 ) + weightedBlendVar5519.y*temp_output_6017_0 + weightedBlendVar5519.z*( appendResult20_g987 * appendResult5910 ) )/( weightedBlendVar5519.x + weightedBlendVar5519.y + weightedBlendVar5519.z ) );
			half3 ifLocalVar5807 = 0;
			UNITY_BRANCH 
			if( _Texture_6_Triplanar == 1.0 )
				ifLocalVar5807 = weightedAvg5519;
			else
				ifLocalVar5807 = temp_output_6017_0;
			half3 ifLocalVar6138 = 0;
			UNITY_BRANCH 
			if( _Texture_6_Normal_Index <= -1.0 )
				ifLocalVar6138 = EmptyNRM6172;
			else
				ifLocalVar6138 = ifLocalVar5807;
			half3 Normal_64537 = ifLocalVar6138;
			float temp_output_4543_0 = ( 1.0 / _Texture_7_Tiling );
			float2 appendResult4545 = (half2(temp_output_4543_0 , temp_output_4543_0));
			float2 temp_output_4559_0 = ( Top_Bottom1999 * appendResult4545 );
			float4 texArray4567 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4559_0, _Texture_7_Normal_Index)  );
			float2 appendResult11_g1006 = (half2(texArray4567.w , texArray4567.y));
			float2 temp_output_4_0_g1006 = ( ( ( appendResult11_g1006 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_7_Normal_Power );
			float2 break8_g1006 = temp_output_4_0_g1006;
			float dotResult5_g1006 = dot( temp_output_4_0_g1006 , temp_output_4_0_g1006 );
			float temp_output_9_0_g1006 = sqrt( ( 1.0 - saturate( dotResult5_g1006 ) ) );
			float3 appendResult20_g1006 = (half3(break8_g1006.x , break8_g1006.y , temp_output_9_0_g1006));
			float3 temp_output_6020_0 = appendResult20_g1006;
			float2 temp_output_4546_0 = ( Front_Back1991 * appendResult4545 );
			float4 texArray4560 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4546_0, _Texture_7_Normal_Index)  );
			float2 appendResult11_g982 = (half2(texArray4560.w , texArray4560.y));
			float2 temp_output_4_0_g982 = ( ( ( appendResult11_g982 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_7_Normal_Power * -1.0 ) );
			float2 break8_g982 = temp_output_4_0_g982;
			float dotResult5_g982 = dot( temp_output_4_0_g982 , temp_output_4_0_g982 );
			float temp_output_9_0_g982 = sqrt( ( 1.0 - saturate( dotResult5_g982 ) ) );
			float3 appendResult21_g982 = (half3(break8_g982.y , break8_g982.x , temp_output_9_0_g982));
			float3 appendResult5914 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float2 temp_output_4557_0 = ( Left_Right2003 * appendResult4545 );
			float4 texArray4565 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4557_0, _Texture_7_Normal_Index)  );
			float2 appendResult11_g985 = (half2(texArray4565.w , texArray4565.y));
			float2 temp_output_4_0_g985 = ( ( ( appendResult11_g985 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_7_Normal_Power );
			float2 break8_g985 = temp_output_4_0_g985;
			float dotResult5_g985 = dot( temp_output_4_0_g985 , temp_output_4_0_g985 );
			float temp_output_9_0_g985 = sqrt( ( 1.0 - saturate( dotResult5_g985 ) ) );
			float3 appendResult20_g985 = (half3(break8_g985.x , break8_g985.y , temp_output_9_0_g985));
			float3 appendResult5917 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar5523 = BlendComponents91;
			float3 weightedAvg5523 = ( ( weightedBlendVar5523.x*( appendResult21_g982 * appendResult5914 ) + weightedBlendVar5523.y*temp_output_6020_0 + weightedBlendVar5523.z*( appendResult20_g985 * appendResult5917 ) )/( weightedBlendVar5523.x + weightedBlendVar5523.y + weightedBlendVar5523.z ) );
			half3 ifLocalVar5853 = 0;
			UNITY_BRANCH 
			if( _Texture_7_Triplanar == 1.0 )
				ifLocalVar5853 = weightedAvg5523;
			else
				ifLocalVar5853 = temp_output_6020_0;
			half3 ifLocalVar6140 = 0;
			UNITY_BRANCH 
			if( _Texture_7_Normal_Index <= -1.0 )
				ifLocalVar6140 = EmptyNRM6172;
			else
				ifLocalVar6140 = ifLocalVar5853;
			half3 Normal_74615 = ifLocalVar6140;
			float temp_output_4617_0 = ( 1.0 / _Texture_8_Tiling );
			float2 appendResult4619 = (half2(temp_output_4617_0 , temp_output_4617_0));
			float2 temp_output_4633_0 = ( Top_Bottom1999 * appendResult4619 );
			float4 texArray4641 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4633_0, _Texture_8_Normal_Index)  );
			float2 appendResult11_g1011 = (half2(texArray4641.w , texArray4641.y));
			float2 temp_output_4_0_g1011 = ( ( ( appendResult11_g1011 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_8_Normal_Power );
			float2 break8_g1011 = temp_output_4_0_g1011;
			float dotResult5_g1011 = dot( temp_output_4_0_g1011 , temp_output_4_0_g1011 );
			float temp_output_9_0_g1011 = sqrt( ( 1.0 - saturate( dotResult5_g1011 ) ) );
			float3 appendResult20_g1011 = (half3(break8_g1011.x , break8_g1011.y , temp_output_9_0_g1011));
			float3 temp_output_6023_0 = appendResult20_g1011;
			float2 temp_output_4620_0 = ( Front_Back1991 * appendResult4619 );
			float4 texArray4634 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4620_0, _Texture_8_Normal_Index)  );
			float2 appendResult11_g981 = (half2(texArray4634.w , texArray4634.y));
			float2 temp_output_4_0_g981 = ( ( ( appendResult11_g981 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_8_Normal_Power * -1.0 ) );
			float2 break8_g981 = temp_output_4_0_g981;
			float dotResult5_g981 = dot( temp_output_4_0_g981 , temp_output_4_0_g981 );
			float temp_output_9_0_g981 = sqrt( ( 1.0 - saturate( dotResult5_g981 ) ) );
			float3 appendResult21_g981 = (half3(break8_g981.y , break8_g981.x , temp_output_9_0_g981));
			float3 appendResult5921 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float2 temp_output_4631_0 = ( Left_Right2003 * appendResult4619 );
			float4 texArray4639 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4631_0, _Texture_8_Normal_Index)  );
			float2 appendResult11_g990 = (half2(texArray4639.w , texArray4639.y));
			float2 temp_output_4_0_g990 = ( ( ( appendResult11_g990 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_8_Normal_Power );
			float2 break8_g990 = temp_output_4_0_g990;
			float dotResult5_g990 = dot( temp_output_4_0_g990 , temp_output_4_0_g990 );
			float temp_output_9_0_g990 = sqrt( ( 1.0 - saturate( dotResult5_g990 ) ) );
			float3 appendResult20_g990 = (half3(break8_g990.x , break8_g990.y , temp_output_9_0_g990));
			float3 appendResult5924 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar5527 = BlendComponents91;
			float3 weightedAvg5527 = ( ( weightedBlendVar5527.x*( appendResult21_g981 * appendResult5921 ) + weightedBlendVar5527.y*temp_output_6023_0 + weightedBlendVar5527.z*( appendResult20_g990 * appendResult5924 ) )/( weightedBlendVar5527.x + weightedBlendVar5527.y + weightedBlendVar5527.z ) );
			half3 ifLocalVar5813 = 0;
			UNITY_BRANCH 
			if( _Texture_8_Triplanar == 1.0 )
				ifLocalVar5813 = weightedAvg5527;
			else
				ifLocalVar5813 = temp_output_6023_0;
			half3 ifLocalVar6142 = 0;
			UNITY_BRANCH 
			if( _Texture_8_Normal_Index <= -1.0 )
				ifLocalVar6142 = EmptyNRM6172;
			else
				ifLocalVar6142 = ifLocalVar5813;
			half3 Normal_84690 = ifLocalVar6142;
			float4 layeredBlendVar5640 = tex2DNode4369;
			float3 layeredBlend5640 = ( lerp( lerp( lerp( lerp( layeredBlend5639 , Normal_54456 , layeredBlendVar5640.x ) , Normal_64537 , layeredBlendVar5640.y ) , Normal_74615 , layeredBlendVar5640.z ) , Normal_84690 , layeredBlendVar5640.w ) );
			float temp_output_4703_0 = ( 1.0 / _Texture_9_Tiling );
			float2 appendResult4736 = (half2(temp_output_4703_0 , temp_output_4703_0));
			float2 temp_output_4712_0 = ( Top_Bottom1999 * appendResult4736 );
			float4 texArray4788 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4712_0, _Texture_9_Normal_Index)  );
			float2 appendResult11_g1022 = (half2(texArray4788.w , texArray4788.y));
			float2 temp_output_4_0_g1022 = ( ( ( appendResult11_g1022 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_9_Normal_Power );
			float2 break8_g1022 = temp_output_4_0_g1022;
			float dotResult5_g1022 = dot( temp_output_4_0_g1022 , temp_output_4_0_g1022 );
			float temp_output_9_0_g1022 = sqrt( ( 1.0 - saturate( dotResult5_g1022 ) ) );
			float3 appendResult20_g1022 = (half3(break8_g1022.x , break8_g1022.y , temp_output_9_0_g1022));
			float3 temp_output_6047_0 = appendResult20_g1022;
			float2 temp_output_4706_0 = ( Front_Back1991 * appendResult4736 );
			float4 texArray5285 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4706_0, _Texture_9_Normal_Index)  );
			float2 appendResult11_g1014 = (half2(texArray5285.w , texArray5285.y));
			float2 temp_output_4_0_g1014 = ( ( ( appendResult11_g1014 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_9_Normal_Power * -1.0 ) );
			float2 break8_g1014 = temp_output_4_0_g1014;
			float dotResult5_g1014 = dot( temp_output_4_0_g1014 , temp_output_4_0_g1014 );
			float temp_output_9_0_g1014 = sqrt( ( 1.0 - saturate( dotResult5_g1014 ) ) );
			float3 appendResult21_g1014 = (half3(break8_g1014.y , break8_g1014.x , temp_output_9_0_g1014));
			float3 appendResult5977 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float2 temp_output_4761_0 = ( Left_Right2003 * appendResult4736 );
			float4 texArray4783 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4761_0, _Texture_9_Normal_Index)  );
			float2 appendResult11_g1000 = (half2(texArray4783.w , texArray4783.y));
			float2 temp_output_4_0_g1000 = ( ( ( appendResult11_g1000 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_9_Normal_Power );
			float2 break8_g1000 = temp_output_4_0_g1000;
			float dotResult5_g1000 = dot( temp_output_4_0_g1000 , temp_output_4_0_g1000 );
			float temp_output_9_0_g1000 = sqrt( ( 1.0 - saturate( dotResult5_g1000 ) ) );
			float3 appendResult20_g1000 = (half3(break8_g1000.x , break8_g1000.y , temp_output_9_0_g1000));
			float3 appendResult5980 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar5491 = BlendComponents91;
			float3 weightedAvg5491 = ( ( weightedBlendVar5491.x*( appendResult21_g1014 * appendResult5977 ) + weightedBlendVar5491.y*temp_output_6047_0 + weightedBlendVar5491.z*( appendResult20_g1000 * appendResult5980 ) )/( weightedBlendVar5491.x + weightedBlendVar5491.y + weightedBlendVar5491.z ) );
			half3 ifLocalVar5846 = 0;
			UNITY_BRANCH 
			if( _Texture_9_Triplanar == 1.0 )
				ifLocalVar5846 = weightedAvg5491;
			else
				ifLocalVar5846 = temp_output_6047_0;
			half3 ifLocalVar6144 = 0;
			UNITY_BRANCH 
			if( _Texture_9_Normal_Index <= -1.0 )
				ifLocalVar6144 = EmptyNRM6172;
			else
				ifLocalVar6144 = ifLocalVar5846;
			half3 Normal_94897 = ifLocalVar6144;
			float temp_output_4734_0 = ( 1.0 / _Texture_10_Tiling );
			float2 appendResult4738 = (half2(temp_output_4734_0 , temp_output_4734_0));
			float2 temp_output_4793_0 = ( Top_Bottom1999 * appendResult4738 );
			float4 texArray4822 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4793_0, _Texture_10_Normal_Index)  );
			float2 appendResult11_g1023 = (half2(texArray4822.w , texArray4822.y));
			float2 temp_output_4_0_g1023 = ( ( ( appendResult11_g1023 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_10_Normal_Power );
			float2 break8_g1023 = temp_output_4_0_g1023;
			float dotResult5_g1023 = dot( temp_output_4_0_g1023 , temp_output_4_0_g1023 );
			float temp_output_9_0_g1023 = sqrt( ( 1.0 - saturate( dotResult5_g1023 ) ) );
			float3 appendResult20_g1023 = (half3(break8_g1023.x , break8_g1023.y , temp_output_9_0_g1023));
			float3 temp_output_6044_0 = appendResult20_g1023;
			float2 temp_output_4742_0 = ( Front_Back1991 * appendResult4738 );
			float4 texArray4798 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4742_0, _Texture_10_Normal_Index)  );
			float2 appendResult11_g1012 = (half2(texArray4798.w , texArray4798.y));
			float2 temp_output_4_0_g1012 = ( ( ( appendResult11_g1012 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_10_Normal_Power * -1.0 ) );
			float2 break8_g1012 = temp_output_4_0_g1012;
			float dotResult5_g1012 = dot( temp_output_4_0_g1012 , temp_output_4_0_g1012 );
			float temp_output_9_0_g1012 = sqrt( ( 1.0 - saturate( dotResult5_g1012 ) ) );
			float3 appendResult21_g1012 = (half3(break8_g1012.y , break8_g1012.x , temp_output_9_0_g1012));
			float3 appendResult5970 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float2 temp_output_4785_0 = ( Left_Right2003 * appendResult4738 );
			float4 texArray4791 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4785_0, _Texture_10_Normal_Index)  );
			float2 appendResult11_g1005 = (half2(texArray4791.w , texArray4791.y));
			float2 temp_output_4_0_g1005 = ( ( ( appendResult11_g1005 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_10_Normal_Power );
			float2 break8_g1005 = temp_output_4_0_g1005;
			float dotResult5_g1005 = dot( temp_output_4_0_g1005 , temp_output_4_0_g1005 );
			float temp_output_9_0_g1005 = sqrt( ( 1.0 - saturate( dotResult5_g1005 ) ) );
			float3 appendResult20_g1005 = (half3(break8_g1005.x , break8_g1005.y , temp_output_9_0_g1005));
			float3 appendResult5973 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar5531 = BlendComponents91;
			float3 weightedAvg5531 = ( ( weightedBlendVar5531.x*( appendResult21_g1012 * appendResult5970 ) + weightedBlendVar5531.y*temp_output_6044_0 + weightedBlendVar5531.z*( appendResult20_g1005 * appendResult5973 ) )/( weightedBlendVar5531.x + weightedBlendVar5531.y + weightedBlendVar5531.z ) );
			half3 ifLocalVar5842 = 0;
			UNITY_BRANCH 
			if( _Texture_10_Triplanar == 1.0 )
				ifLocalVar5842 = weightedAvg5531;
			else
				ifLocalVar5842 = temp_output_6044_0;
			half3 ifLocalVar6146 = 0;
			UNITY_BRANCH 
			if( _Texture_10_Normal_Index <= -1.0 )
				ifLocalVar6146 = EmptyNRM6172;
			else
				ifLocalVar6146 = ifLocalVar5842;
			half3 Normal_104918 = ifLocalVar6146;
			float temp_output_4739_0 = ( 1.0 / _Texture_11_Tiling );
			float2 appendResult4741 = (half2(temp_output_4739_0 , temp_output_4739_0));
			float2 temp_output_4817_0 = ( Top_Bottom1999 * appendResult4741 );
			float4 texArray4856 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4817_0, _Texture_11_Normal_Index)  );
			float2 appendResult11_g1026 = (half2(texArray4856.w , texArray4856.y));
			float2 temp_output_4_0_g1026 = ( ( ( appendResult11_g1026 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_11_Normal_Power );
			float2 break8_g1026 = temp_output_4_0_g1026;
			float dotResult5_g1026 = dot( temp_output_4_0_g1026 , temp_output_4_0_g1026 );
			float temp_output_9_0_g1026 = sqrt( ( 1.0 - saturate( dotResult5_g1026 ) ) );
			float3 appendResult20_g1026 = (half3(break8_g1026.x , break8_g1026.y , temp_output_9_0_g1026));
			float3 temp_output_6041_0 = appendResult20_g1026;
			float2 temp_output_4748_0 = ( Front_Back1991 * appendResult4741 );
			float4 texArray4828 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4748_0, _Texture_11_Normal_Index)  );
			float2 appendResult11_g1013 = (half2(texArray4828.w , texArray4828.y));
			float2 temp_output_4_0_g1013 = ( ( ( appendResult11_g1013 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_11_Normal_Power * -1.0 ) );
			float2 break8_g1013 = temp_output_4_0_g1013;
			float dotResult5_g1013 = dot( temp_output_4_0_g1013 , temp_output_4_0_g1013 );
			float temp_output_9_0_g1013 = sqrt( ( 1.0 - saturate( dotResult5_g1013 ) ) );
			float3 appendResult21_g1013 = (half3(break8_g1013.y , break8_g1013.x , temp_output_9_0_g1013));
			float3 appendResult5963 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float2 temp_output_4795_0 = ( Left_Right2003 * appendResult4741 );
			float4 texArray4811 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4795_0, _Texture_11_Normal_Index)  );
			float2 appendResult11_g1008 = (half2(texArray4811.w , texArray4811.y));
			float2 temp_output_4_0_g1008 = ( ( ( appendResult11_g1008 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_11_Normal_Power );
			float2 break8_g1008 = temp_output_4_0_g1008;
			float dotResult5_g1008 = dot( temp_output_4_0_g1008 , temp_output_4_0_g1008 );
			float temp_output_9_0_g1008 = sqrt( ( 1.0 - saturate( dotResult5_g1008 ) ) );
			float3 appendResult20_g1008 = (half3(break8_g1008.x , break8_g1008.y , temp_output_9_0_g1008));
			float3 appendResult5966 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar5535 = BlendComponents91;
			float3 weightedAvg5535 = ( ( weightedBlendVar5535.x*( appendResult21_g1013 * appendResult5963 ) + weightedBlendVar5535.y*temp_output_6041_0 + weightedBlendVar5535.z*( appendResult20_g1008 * appendResult5966 ) )/( weightedBlendVar5535.x + weightedBlendVar5535.y + weightedBlendVar5535.z ) );
			half3 ifLocalVar5838 = 0;
			UNITY_BRANCH 
			if( _Texture_11_Triplanar == 1.0 )
				ifLocalVar5838 = weightedAvg5535;
			else
				ifLocalVar5838 = temp_output_6041_0;
			half3 ifLocalVar6148 = 0;
			UNITY_BRANCH 
			if( _Texture_11_Normal_Index <= -1.0 )
				ifLocalVar6148 = EmptyNRM6172;
			else
				ifLocalVar6148 = ifLocalVar5838;
			half3 Normal_114948 = ifLocalVar6148;
			float temp_output_4745_0 = ( 1.0 / _Texture_12_Tiling );
			float2 appendResult4751 = (half2(temp_output_4745_0 , temp_output_4745_0));
			float2 temp_output_4849_0 = ( Top_Bottom1999 * appendResult4751 );
			float4 texArray4870 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4849_0, _Texture_12_Normal_Index)  );
			float2 appendResult11_g1017 = (half2(texArray4870.w , texArray4870.y));
			float2 temp_output_4_0_g1017 = ( ( ( appendResult11_g1017 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_12_Normal_Power );
			float2 break8_g1017 = temp_output_4_0_g1017;
			float dotResult5_g1017 = dot( temp_output_4_0_g1017 , temp_output_4_0_g1017 );
			float temp_output_9_0_g1017 = sqrt( ( 1.0 - saturate( dotResult5_g1017 ) ) );
			float3 appendResult20_g1017 = (half3(break8_g1017.x , break8_g1017.y , temp_output_9_0_g1017));
			float3 temp_output_6038_0 = appendResult20_g1017;
			float2 temp_output_4758_0 = ( Front_Back1991 * appendResult4751 );
			float4 texArray4850 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4758_0, _Texture_12_Normal_Index)  );
			float2 appendResult11_g1010 = (half2(texArray4850.w , texArray4850.y));
			float2 temp_output_4_0_g1010 = ( ( ( appendResult11_g1010 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_12_Normal_Power * -1.0 ) );
			float2 break8_g1010 = temp_output_4_0_g1010;
			float dotResult5_g1010 = dot( temp_output_4_0_g1010 , temp_output_4_0_g1010 );
			float temp_output_9_0_g1010 = sqrt( ( 1.0 - saturate( dotResult5_g1010 ) ) );
			float3 appendResult21_g1010 = (half3(break8_g1010.y , break8_g1010.x , temp_output_9_0_g1010));
			float3 appendResult5956 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float2 temp_output_4830_0 = ( Left_Right2003 * appendResult4751 );
			float4 texArray4852 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4830_0, _Texture_12_Normal_Index)  );
			float2 appendResult11_g1007 = (half2(texArray4852.w , texArray4852.y));
			float2 temp_output_4_0_g1007 = ( ( ( appendResult11_g1007 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_12_Normal_Power );
			float2 break8_g1007 = temp_output_4_0_g1007;
			float dotResult5_g1007 = dot( temp_output_4_0_g1007 , temp_output_4_0_g1007 );
			float temp_output_9_0_g1007 = sqrt( ( 1.0 - saturate( dotResult5_g1007 ) ) );
			float3 appendResult20_g1007 = (half3(break8_g1007.x , break8_g1007.y , temp_output_9_0_g1007));
			float3 appendResult5959 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar5539 = BlendComponents91;
			float3 weightedAvg5539 = ( ( weightedBlendVar5539.x*( appendResult21_g1010 * appendResult5956 ) + weightedBlendVar5539.y*temp_output_6038_0 + weightedBlendVar5539.z*( appendResult20_g1007 * appendResult5959 ) )/( weightedBlendVar5539.x + weightedBlendVar5539.y + weightedBlendVar5539.z ) );
			half3 ifLocalVar5834 = 0;
			UNITY_BRANCH 
			if( _Texture_12_Triplanar == 1.0 )
				ifLocalVar5834 = weightedAvg5539;
			else
				ifLocalVar5834 = temp_output_6038_0;
			half3 ifLocalVar6150 = 0;
			UNITY_BRANCH 
			if( _Texture_12_Normal_Index <= -1.0 )
				ifLocalVar6150 = EmptyNRM6172;
			else
				ifLocalVar6150 = ifLocalVar5834;
			half3 Normal_124962 = ifLocalVar6150;
			float4 layeredBlendVar5641 = tex2DNode4370;
			float3 layeredBlend5641 = ( lerp( lerp( lerp( lerp( layeredBlend5640 , Normal_94897 , layeredBlendVar5641.x ) , Normal_104918 , layeredBlendVar5641.y ) , Normal_114948 , layeredBlendVar5641.z ) , Normal_124962 , layeredBlendVar5641.w ) );
			float temp_output_5125_0 = ( 1.0 / _Texture_13_Tiling );
			float2 appendResult5027 = (half2(temp_output_5125_0 , temp_output_5125_0));
			float2 temp_output_5037_0 = ( Top_Bottom1999 * appendResult5027 );
			float4 texArray5120 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5037_0, _Texture_13_Normal_Index)  );
			float2 appendResult11_g1030 = (half2(texArray5120.w , texArray5120.y));
			float2 temp_output_4_0_g1030 = ( ( ( appendResult11_g1030 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_13_Normal_Power );
			float2 break8_g1030 = temp_output_4_0_g1030;
			float dotResult5_g1030 = dot( temp_output_4_0_g1030 , temp_output_4_0_g1030 );
			float temp_output_9_0_g1030 = sqrt( ( 1.0 - saturate( dotResult5_g1030 ) ) );
			float3 appendResult20_g1030 = (half3(break8_g1030.x , break8_g1030.y , temp_output_9_0_g1030));
			float3 temp_output_6035_0 = appendResult20_g1030;
			float2 temp_output_5025_0 = ( Front_Back1991 * appendResult5027 );
			float4 texArray5127 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5025_0, _Texture_13_Normal_Index)  );
			float2 appendResult11_g1024 = (half2(texArray5127.w , texArray5127.y));
			float2 temp_output_4_0_g1024 = ( ( ( appendResult11_g1024 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_13_Normal_Power * -1.0 ) );
			float2 break8_g1024 = temp_output_4_0_g1024;
			float dotResult5_g1024 = dot( temp_output_4_0_g1024 , temp_output_4_0_g1024 );
			float temp_output_9_0_g1024 = sqrt( ( 1.0 - saturate( dotResult5_g1024 ) ) );
			float3 appendResult21_g1024 = (half3(break8_g1024.y , break8_g1024.x , temp_output_9_0_g1024));
			float3 appendResult5949 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float2 temp_output_5035_0 = ( Left_Right2003 * appendResult5027 );
			float4 texArray5109 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5035_0, _Texture_13_Normal_Index)  );
			float2 appendResult11_g1016 = (half2(texArray5109.w , texArray5109.y));
			float2 temp_output_4_0_g1016 = ( ( ( appendResult11_g1016 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_13_Normal_Power );
			float2 break8_g1016 = temp_output_4_0_g1016;
			float dotResult5_g1016 = dot( temp_output_4_0_g1016 , temp_output_4_0_g1016 );
			float temp_output_9_0_g1016 = sqrt( ( 1.0 - saturate( dotResult5_g1016 ) ) );
			float3 appendResult20_g1016 = (half3(break8_g1016.x , break8_g1016.y , temp_output_9_0_g1016));
			float3 appendResult5952 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar5543 = BlendComponents91;
			float3 weightedAvg5543 = ( ( weightedBlendVar5543.x*( appendResult21_g1024 * appendResult5949 ) + weightedBlendVar5543.y*temp_output_6035_0 + weightedBlendVar5543.z*( appendResult20_g1016 * appendResult5952 ) )/( weightedBlendVar5543.x + weightedBlendVar5543.y + weightedBlendVar5543.z ) );
			half3 ifLocalVar5830 = 0;
			UNITY_BRANCH 
			if( _Texture_13_Triplanar == 1.0 )
				ifLocalVar5830 = weightedAvg5543;
			else
				ifLocalVar5830 = temp_output_6035_0;
			half3 ifLocalVar6152 = 0;
			UNITY_BRANCH 
			if( _Texture_13_Normal_Index <= -1.0 )
				ifLocalVar6152 = EmptyNRM6172;
			else
				ifLocalVar6152 = ifLocalVar5830;
			half3 Normal_135059 = ifLocalVar6152;
			float temp_output_5006_0 = ( 1.0 / _Texture_14_Tiling );
			float2 appendResult5033 = (half2(temp_output_5006_0 , temp_output_5006_0));
			float2 temp_output_5022_0 = ( Top_Bottom1999 * appendResult5033 );
			float4 texArray5178 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5022_0, _Texture_14_Normal_Index)  );
			float2 appendResult11_g1031 = (half2(texArray5178.w , texArray5178.y));
			float2 temp_output_4_0_g1031 = ( ( ( appendResult11_g1031 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_14_Normal_Power );
			float2 break8_g1031 = temp_output_4_0_g1031;
			float dotResult5_g1031 = dot( temp_output_4_0_g1031 , temp_output_4_0_g1031 );
			float temp_output_9_0_g1031 = sqrt( ( 1.0 - saturate( dotResult5_g1031 ) ) );
			float3 appendResult20_g1031 = (half3(break8_g1031.x , break8_g1031.y , temp_output_9_0_g1031));
			float3 temp_output_6032_0 = appendResult20_g1031;
			float2 temp_output_5009_0 = ( Front_Back1991 * appendResult5033 );
			float4 texArray5017 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5009_0, _Texture_14_Normal_Index)  );
			float2 appendResult11_g1020 = (half2(texArray5017.w , texArray5017.y));
			float2 temp_output_4_0_g1020 = ( ( ( appendResult11_g1020 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_14_Normal_Power * -1.0 ) );
			float2 break8_g1020 = temp_output_4_0_g1020;
			float dotResult5_g1020 = dot( temp_output_4_0_g1020 , temp_output_4_0_g1020 );
			float temp_output_9_0_g1020 = sqrt( ( 1.0 - saturate( dotResult5_g1020 ) ) );
			float3 appendResult21_g1020 = (half3(break8_g1020.y , break8_g1020.x , temp_output_9_0_g1020));
			float3 appendResult5942 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float2 temp_output_5010_0 = ( Left_Right2003 * appendResult5033 );
			float4 texArray5170 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5010_0, _Texture_14_Normal_Index)  );
			float2 appendResult11_g1027 = (half2(texArray5170.w , texArray5170.y));
			float2 temp_output_4_0_g1027 = ( ( ( appendResult11_g1027 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_14_Normal_Power );
			float2 break8_g1027 = temp_output_4_0_g1027;
			float dotResult5_g1027 = dot( temp_output_4_0_g1027 , temp_output_4_0_g1027 );
			float temp_output_9_0_g1027 = sqrt( ( 1.0 - saturate( dotResult5_g1027 ) ) );
			float3 appendResult20_g1027 = (half3(break8_g1027.x , break8_g1027.y , temp_output_9_0_g1027));
			float3 appendResult5945 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar5547 = BlendComponents91;
			float3 weightedAvg5547 = ( ( weightedBlendVar5547.x*( appendResult21_g1020 * appendResult5942 ) + weightedBlendVar5547.y*temp_output_6032_0 + weightedBlendVar5547.z*( appendResult20_g1027 * appendResult5945 ) )/( weightedBlendVar5547.x + weightedBlendVar5547.y + weightedBlendVar5547.z ) );
			half3 ifLocalVar5826 = 0;
			UNITY_BRANCH 
			if( _Texture_14_Triplanar == 1.0 )
				ifLocalVar5826 = weightedAvg5547;
			else
				ifLocalVar5826 = temp_output_6032_0;
			half3 ifLocalVar6154 = 0;
			UNITY_BRANCH 
			if( _Texture_14_Normal_Index <= -1.0 )
				ifLocalVar6154 = EmptyNRM6172;
			else
				ifLocalVar6154 = ifLocalVar5826;
			half3 Normal_145196 = ifLocalVar6154;
			float temp_output_5210_0 = ( 1.0 / _Texture_15_Tiling );
			float2 appendResult5212 = (half2(temp_output_5210_0 , temp_output_5210_0));
			float2 temp_output_5226_0 = ( Top_Bottom1999 * appendResult5212 );
			float4 texArray5246 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5226_0, _Texture_15_Normal_Index)  );
			float2 appendResult11_g1028 = (half2(texArray5246.w , texArray5246.y));
			float2 temp_output_4_0_g1028 = ( ( ( appendResult11_g1028 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_15_Normal_Power );
			float2 break8_g1028 = temp_output_4_0_g1028;
			float dotResult5_g1028 = dot( temp_output_4_0_g1028 , temp_output_4_0_g1028 );
			float temp_output_9_0_g1028 = sqrt( ( 1.0 - saturate( dotResult5_g1028 ) ) );
			float3 appendResult20_g1028 = (half3(break8_g1028.x , break8_g1028.y , temp_output_9_0_g1028));
			float3 temp_output_6029_0 = appendResult20_g1028;
			float2 temp_output_5213_0 = ( Front_Back1991 * appendResult5212 );
			float4 texArray5227 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5213_0, _Texture_15_Normal_Index)  );
			float2 appendResult11_g1018 = (half2(texArray5227.w , texArray5227.y));
			float2 temp_output_4_0_g1018 = ( ( ( appendResult11_g1018 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_15_Normal_Power * -1.0 ) );
			float2 break8_g1018 = temp_output_4_0_g1018;
			float dotResult5_g1018 = dot( temp_output_4_0_g1018 , temp_output_4_0_g1018 );
			float temp_output_9_0_g1018 = sqrt( ( 1.0 - saturate( dotResult5_g1018 ) ) );
			float3 appendResult21_g1018 = (half3(break8_g1018.y , break8_g1018.x , temp_output_9_0_g1018));
			float3 appendResult5935 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float2 temp_output_5224_0 = ( Left_Right2003 * appendResult5212 );
			float4 texArray5250 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5224_0, _Texture_15_Normal_Index)  );
			float2 appendResult11_g1019 = (half2(texArray5250.w , texArray5250.y));
			float2 temp_output_4_0_g1019 = ( ( ( appendResult11_g1019 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_15_Normal_Power );
			float2 break8_g1019 = temp_output_4_0_g1019;
			float dotResult5_g1019 = dot( temp_output_4_0_g1019 , temp_output_4_0_g1019 );
			float temp_output_9_0_g1019 = sqrt( ( 1.0 - saturate( dotResult5_g1019 ) ) );
			float3 appendResult20_g1019 = (half3(break8_g1019.x , break8_g1019.y , temp_output_9_0_g1019));
			float3 appendResult5938 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar5551 = BlendComponents91;
			float3 weightedAvg5551 = ( ( weightedBlendVar5551.x*( appendResult21_g1018 * appendResult5935 ) + weightedBlendVar5551.y*temp_output_6029_0 + weightedBlendVar5551.z*( appendResult20_g1019 * appendResult5938 ) )/( weightedBlendVar5551.x + weightedBlendVar5551.y + weightedBlendVar5551.z ) );
			half3 ifLocalVar5822 = 0;
			UNITY_BRANCH 
			if( _Texture_15_Triplanar == 1.0 )
				ifLocalVar5822 = weightedAvg5551;
			else
				ifLocalVar5822 = temp_output_6029_0;
			half3 ifLocalVar6156 = 0;
			UNITY_BRANCH 
			if( _Texture_15_Normal_Index <= -1.0 )
				ifLocalVar6156 = EmptyNRM6172;
			else
				ifLocalVar6156 = ifLocalVar5822;
			half3 Normal_155280 = ifLocalVar6156;
			float temp_output_5075_0 = ( 1.0 / _Texture_16_Tiling );
			float2 appendResult5078 = (half2(temp_output_5075_0 , temp_output_5075_0));
			float2 temp_output_5083_0 = ( Top_Bottom1999 * appendResult5078 );
			float4 texArray5099 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5083_0, _Texture_16_Normal_Index)  );
			float2 appendResult11_g1029 = (half2(texArray5099.w , texArray5099.y));
			float2 temp_output_4_0_g1029 = ( ( ( appendResult11_g1029 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_16_Normal_Power );
			float2 break8_g1029 = temp_output_4_0_g1029;
			float dotResult5_g1029 = dot( temp_output_4_0_g1029 , temp_output_4_0_g1029 );
			float temp_output_9_0_g1029 = sqrt( ( 1.0 - saturate( dotResult5_g1029 ) ) );
			float3 appendResult20_g1029 = (half3(break8_g1029.x , break8_g1029.y , temp_output_9_0_g1029));
			float3 temp_output_6026_0 = appendResult20_g1029;
			float2 temp_output_5079_0 = ( Front_Back1991 * appendResult5078 );
			float4 texArray5082 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5079_0, _Texture_16_Normal_Index)  );
			float2 appendResult11_g1025 = (half2(texArray5082.w , texArray5082.y));
			float2 temp_output_4_0_g1025 = ( ( ( appendResult11_g1025 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_16_Normal_Power * -1.0 ) );
			float2 break8_g1025 = temp_output_4_0_g1025;
			float dotResult5_g1025 = dot( temp_output_4_0_g1025 , temp_output_4_0_g1025 );
			float temp_output_9_0_g1025 = sqrt( ( 1.0 - saturate( dotResult5_g1025 ) ) );
			float3 appendResult21_g1025 = (half3(break8_g1025.y , break8_g1025.x , temp_output_9_0_g1025));
			float3 appendResult5928 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float2 temp_output_5085_0 = ( Left_Right2003 * appendResult5078 );
			float4 texArray4731 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5085_0, _Texture_16_Normal_Index)  );
			float2 appendResult11_g1021 = (half2(texArray4731.w , texArray4731.y));
			float2 temp_output_4_0_g1021 = ( ( ( appendResult11_g1021 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_16_Normal_Power );
			float2 break8_g1021 = temp_output_4_0_g1021;
			float dotResult5_g1021 = dot( temp_output_4_0_g1021 , temp_output_4_0_g1021 );
			float temp_output_9_0_g1021 = sqrt( ( 1.0 - saturate( dotResult5_g1021 ) ) );
			float3 appendResult20_g1021 = (half3(break8_g1021.x , break8_g1021.y , temp_output_9_0_g1021));
			float3 appendResult5931 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar5555 = BlendComponents91;
			float3 weightedAvg5555 = ( ( weightedBlendVar5555.x*( appendResult21_g1025 * appendResult5928 ) + weightedBlendVar5555.y*temp_output_6026_0 + weightedBlendVar5555.z*( appendResult20_g1021 * appendResult5931 ) )/( weightedBlendVar5555.x + weightedBlendVar5555.y + weightedBlendVar5555.z ) );
			half3 ifLocalVar5818 = 0;
			UNITY_BRANCH 
			if( _Texture_16_Triplanar == 1.0 )
				ifLocalVar5818 = weightedAvg5555;
			else
				ifLocalVar5818 = temp_output_6026_0;
			half3 ifLocalVar6158 = 0;
			UNITY_BRANCH 
			if( _Texture_16_Normal_Index <= -1.0 )
				ifLocalVar6158 = EmptyNRM6172;
			else
				ifLocalVar6158 = ifLocalVar5818;
			half3 Normal_164696 = ifLocalVar6158;
			float4 layeredBlendVar5642 = tex2DNode4371;
			float3 layeredBlend5642 = ( lerp( lerp( lerp( lerp( layeredBlend5641 , Normal_135059 , layeredBlendVar5642.x ) , Normal_145196 , layeredBlendVar5642.y ) , Normal_155280 , layeredBlendVar5642.z ) , Normal_164696 , layeredBlendVar5642.w ) );
			float3 normalizeResult3900 = normalize( layeredBlend5642 );
			float2 temp_output_3893_0 = ( Top_Bottom1999 / _Snow_Tiling );
			float4 texArray4382 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3893_0, _Texture_Snow_Normal_Index)  );
			float2 appendResult11_g1032 = (half2(texArray4382.w , texArray4382.y));
			float2 temp_output_4_0_g1032 = ( ( ( appendResult11_g1032 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Snow_Normal_Scale );
			float2 break8_g1032 = temp_output_4_0_g1032;
			float dotResult5_g1032 = dot( temp_output_4_0_g1032 , temp_output_4_0_g1032 );
			float temp_output_9_0_g1032 = sqrt( ( 1.0 - saturate( dotResult5_g1032 ) ) );
			float3 appendResult20_g1032 = (half3(break8_g1032.x , break8_g1032.y , temp_output_9_0_g1032));
			half3 ifLocalVar6166 = 0;
			UNITY_BRANCH 
			if( _Texture_Snow_Normal_Index <= -1.0 )
				ifLocalVar6166 = EmptyNRM6172;
			else
				ifLocalVar6166 = appendResult20_g1032;
			float simplePerlin2D6331 = snoise( ( Top_Bottom1999 * _Snow_Noise_Tiling ) );
			float clampResult6332 = clamp( simplePerlin2D6331 , 0.0 , 1.0 );
			float lerpResult4310 = lerp( 1.0 , clampResult6332 , _Snow_Noise_Power);
			float clampResult4302 = clamp( ( lerpResult4310 * _Snow_Amount ) , 0.4 , 1.0 );
			float clampResult1354 = clamp( ase_worldNormal.y , 0.0 , 0.9999 );
			float temp_output_1349_0 = ( _Snow_Maximum_Angle / 90.0 );
			float clampResult1347 = clamp( ( clampResult1354 - ( 1.0 - temp_output_1349_0 ) ) , 0.0 , 2.0 );
			half SnowSlope1352 = pow( ( 1.0 - ( clampResult1347 * ( 1.0 / temp_output_1349_0 ) ) ) , _Snow_Maximum_Angle_Hardness );
			float clampResult4146 = clamp( SnowSlope1352 , 0.0 , 1.0 );
			float lerpResult4293 = lerp( ( _Snow_Amount * clampResult4302 ) , 0.0 , clampResult4146);
			float temp_output_3751_0 = ( ( 1.0 - _Snow_Min_Height ) + ase_worldPos.y );
			float clampResult4220 = clamp( ( temp_output_3751_0 + 1.0 ) , 0.0 , 1.0 );
			float clampResult4260 = clamp( ( ( 1.0 - ( ( temp_output_3751_0 + _Snow_Min_Height_Blending ) / temp_output_3751_0 ) ) + -0.5 ) , 0.0 , 1.0 );
			float clampResult4263 = clamp( ( clampResult4220 + clampResult4260 ) , 0.0 , 1.0 );
			float lerpResult3759 = lerp( 0.0 , lerpResult4293 , clampResult4263);
			float clampResult4298 = clamp( lerpResult3759 , 0.0 , 1.0 );
			float temp_output_3708_0 = saturate( ( ( clampResult4298 / 1.5 ) * _Snow_Amount ) );
			float3 lerpResult5703 = lerp( normalizeResult3900 , ifLocalVar6166 , ( _Snow_Blend_Normal * temp_output_3708_0 ));
			float HeightMask5474 = saturate(pow(((( ( normalizeResult3900.y + 1.0 ) * 0.5 )*temp_output_3708_0)*4)+(temp_output_3708_0*2),5.0));
			float3 lerpResult3902 = lerp( normalizeResult3900 , lerpResult5703 , HeightMask5474);
			float lerpResult4350 = lerp( normalizeResult3900.y , (WorldNormalVector( i , lerpResult3902 )).y , pow( clampResult4298 , 2.0 ));
			float clampResult4299 = clamp( ( lerpResult4350 * clampResult4298 ) , 0.0 , 1.0 );
			float clampResult3702 = clamp( pow( ( ( ( _Texture_16_Snow_Reduction * Splat4_A2546 ) + ( ( _Texture_15_Snow_Reduction * Splat4_B2545 ) + ( ( ( _Texture_13_Snow_Reduction * Splat4_R2543 ) + ( ( _Texture_12_Snow_Reduction * Splat3_A2540 ) + ( ( _Texture_11_Snow_Reduction * Splat3_B2539 ) + ( ( ( _Texture_9_Snow_Reduction * Splat3_R2537 ) + ( ( _Texture_8_Snow_Reduction * Splat2_A2109 ) + ( ( _Texture_7_Snow_Reduction * Splat2_B2108 ) + ( ( ( _Texture_5_Snow_Reduction * Splat2_R2106 ) + ( ( _Texture_1_Snow_Reduction * Splat1_R1438 ) + ( ( _Texture_2_Snow_Reduction * Splat1_G1441 ) + ( ( _Texture_3_Snow_Reduction * Splat1_B1442 ) + ( _Texture_4_Snow_Reduction * Splat1_A1491 ) ) ) ) ) + ( _Texture_6_Snow_Reduction * Splat2_G2107 ) ) ) ) ) + ( _Texture_10_Snow_Reduction * Splat3_G2538 ) ) ) ) ) + ( _Texture_14_Snow_Reduction * Splat4_G2544 ) ) ) ) * ( lerpResult4310 * 5.0 ) ) , 3.0 ) , 0.0 , 1.0 );
			float lerpResult3742 = lerp( saturate( clampResult4299 ) , 0.0 , clampResult3702);
			float3 lerpResult5722 = lerp( lerpResult3776 , lerpResult3906 , lerpResult3742);
			float3 lerpResult3741 = lerp( lerpResult3902 , normalizeResult3900 , clampResult3702);
			float3 lerpResult939 = lerp( lerpResult3741 , UnpackScaleNormal( tex2D( _Global_Normal_Map, i.uv_texcoord ), _Global_Normalmap_Power ) , UVmixDistance636);
			float3 normalizeResult3901 = normalize( lerpResult939 );
			float3 temp_output_4100_0 = BlendNormals( lerpResult5722 , normalizeResult3901 );
			o.Normal = temp_output_4100_0;
			float lerpResult6230 = lerp( _Global_Color_Map_Close_Power , _Global_Color_Map_Far_Power , UVmixDistance636);
			half4 tex2DNode6204 = tex2D( _Global_Color_Map, ( _Global_Color_Map_Offset + ( _Global_Color_Map_Scale * i.uv_texcoord ) ) );
			float clampResult6326 = clamp( ( tex2DNode6204.a + ( 1.0 - _Global_Color_Opacity_Power ) ) , 0.0 , 1.0 );
			float2 appendResult6241 = (half2(1.0 , ( lerpResult6230 * clampResult6326 )));
			float4 texArray3292 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3275_0, _Texture_1_Albedo_Index)  );
			float4 texArray3293 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_3275_0 / _Texture_1_Far_Multiplier ), _Texture_1_Albedo_Index)  );
			float4 lerpResult5739 = lerp( texArray3292 , texArray3293 , UVmixDistance636);
			float4 texArray3287 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3279_0, _Texture_1_Albedo_Index)  );
			float4 texArray3294 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3277_0, _Texture_1_Albedo_Index)  );
			float3 weightedBlendVar5674 = BlendComponents91;
			float4 weightedAvg5674 = ( ( weightedBlendVar5674.x*texArray3287 + weightedBlendVar5674.y*texArray3292 + weightedBlendVar5674.z*texArray3294 )/( weightedBlendVar5674.x + weightedBlendVar5674.y + weightedBlendVar5674.z ) );
			float4 texArray3291 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_3279_0 / _Texture_1_Far_Multiplier ), _Texture_1_Albedo_Index)  );
			float4 texArray3295 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_3277_0 / _Texture_1_Far_Multiplier ), _Texture_1_Albedo_Index)  );
			float3 weightedBlendVar5675 = BlendComponents91;
			float4 weightedAvg5675 = ( ( weightedBlendVar5675.x*texArray3291 + weightedBlendVar5675.y*texArray3293 + weightedBlendVar5675.z*texArray3295 )/( weightedBlendVar5675.x + weightedBlendVar5675.y + weightedBlendVar5675.z ) );
			float4 lerpResult1767 = lerp( weightedAvg5674 , weightedAvg5675 , UVmixDistance636);
			half4 ifLocalVar5782 = 0;
			UNITY_BRANCH 
			if( _Texture_1_Triplanar == 1.0 )
				ifLocalVar5782 = lerpResult1767;
			else
				ifLocalVar5782 = lerpResult5739;
			half4 ifLocalVar6174 = 0;
			UNITY_BRANCH 
			if( _Texture_1_Albedo_Index > -1.0 )
				ifLocalVar6174 = ( ifLocalVar5782 * _Texture_1_Color );
			half4 Texture_1_Final950 = ifLocalVar6174;
			float4 texArray3338 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3343_0, _Texture_2_Albedo_Index)  );
			float4 texArray3339 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_3343_0 / _Texture_2_Far_Multiplier ), _Texture_2_Albedo_Index)  );
			float4 lerpResult5749 = lerp( texArray3338 , texArray3339 , UVmixDistance636);
			float4 texArray3355 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3344_0, _Texture_2_Albedo_Index)  );
			float4 texArray3341 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3379_0, _Texture_2_Albedo_Index)  );
			float3 weightedBlendVar5496 = BlendComponents91;
			float4 weightedAvg5496 = ( ( weightedBlendVar5496.x*texArray3355 + weightedBlendVar5496.y*texArray3338 + weightedBlendVar5496.z*texArray3341 )/( weightedBlendVar5496.x + weightedBlendVar5496.y + weightedBlendVar5496.z ) );
			float4 texArray3356 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_3344_0 / _Texture_2_Far_Multiplier ), _Texture_2_Albedo_Index)  );
			float4 texArray3342 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_3379_0 / _Texture_2_Far_Multiplier ), _Texture_2_Albedo_Index)  );
			float3 weightedBlendVar5497 = BlendComponents91;
			float4 weightedAvg5497 = ( ( weightedBlendVar5497.x*texArray3356 + weightedBlendVar5497.y*texArray3339 + weightedBlendVar5497.z*texArray3342 )/( weightedBlendVar5497.x + weightedBlendVar5497.y + weightedBlendVar5497.z ) );
			float4 lerpResult3333 = lerp( weightedAvg5496 , weightedAvg5497 , UVmixDistance636);
			half4 ifLocalVar5771 = 0;
			UNITY_BRANCH 
			if( _Texture_2_Triplanar == 1.0 )
				ifLocalVar5771 = lerpResult3333;
			else
				ifLocalVar5771 = lerpResult5749;
			half4 ifLocalVar6128 = 0;
			UNITY_BRANCH 
			if( _Texture_2_Albedo_Index > -1.0 )
				ifLocalVar6128 = ( ifLocalVar5771 * _Texture_2_Color );
			half4 Texture_2_Final3385 = ifLocalVar6128;
			float4 texArray3405 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3410_0, _Texture_3_Albedo_Index)  );
			float4 texArray3406 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_3410_0 / _Texture_3_Far_Multiplier ), _Texture_3_Albedo_Index)  );
			float4 lerpResult5759 = lerp( texArray3405 , texArray3406 , UVmixDistance636);
			float4 texArray3419 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3411_0, _Texture_3_Albedo_Index)  );
			float4 texArray3408 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3441_0, _Texture_3_Albedo_Index)  );
			float3 weightedBlendVar5500 = BlendComponents91;
			float4 weightedAvg5500 = ( ( weightedBlendVar5500.x*texArray3419 + weightedBlendVar5500.y*texArray3405 + weightedBlendVar5500.z*texArray3408 )/( weightedBlendVar5500.x + weightedBlendVar5500.y + weightedBlendVar5500.z ) );
			float4 texArray3420 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3413_0, _Texture_3_Albedo_Index)  );
			float4 texArray3409 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_3441_0 / _Texture_3_Far_Multiplier ), _Texture_3_Albedo_Index)  );
			float3 weightedBlendVar5501 = BlendComponents91;
			float4 weightedAvg5501 = ( ( weightedBlendVar5501.x*texArray3420 + weightedBlendVar5501.y*texArray3406 + weightedBlendVar5501.z*texArray3409 )/( weightedBlendVar5501.x + weightedBlendVar5501.y + weightedBlendVar5501.z ) );
			float4 lerpResult3400 = lerp( weightedAvg5500 , weightedAvg5501 , UVmixDistance636);
			half4 ifLocalVar5775 = 0;
			UNITY_BRANCH 
			if( _Texture_3_Triplanar == 1.0 )
				ifLocalVar5775 = lerpResult3400;
			else
				ifLocalVar5775 = lerpResult5759;
			half4 ifLocalVar6130 = 0;
			UNITY_BRANCH 
			if( _Texture_3_Albedo_Index > -1.0 )
				ifLocalVar6130 = ( ifLocalVar5775 * _Texture_3_Color );
			half4 Texture_3_Final3451 = ifLocalVar6130;
			float4 texArray3472 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3477_0, _Texture_4_Albedo_Index)  );
			float4 texArray3473 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_3477_0 / _Texture_4_Far_Multiplier ), _Texture_4_Albedo_Index)  );
			float4 lerpResult5761 = lerp( texArray3472 , texArray3473 , UVmixDistance636);
			float4 texArray3486 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3478_0, _Texture_4_Albedo_Index)  );
			float4 texArray3475 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3508_0, _Texture_4_Albedo_Index)  );
			float3 weightedBlendVar5504 = BlendComponents91;
			float4 weightedAvg5504 = ( ( weightedBlendVar5504.x*texArray3486 + weightedBlendVar5504.y*texArray3472 + weightedBlendVar5504.z*texArray3475 )/( weightedBlendVar5504.x + weightedBlendVar5504.y + weightedBlendVar5504.z ) );
			float4 texArray3487 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_3478_0 / _Texture_4_Far_Multiplier ), _Texture_4_Albedo_Index)  );
			float4 texArray3476 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_3508_0 / _Texture_4_Far_Multiplier ), _Texture_4_Albedo_Index)  );
			float3 weightedBlendVar5505 = BlendComponents91;
			float4 weightedAvg5505 = ( ( weightedBlendVar5505.x*texArray3487 + weightedBlendVar5505.y*texArray3473 + weightedBlendVar5505.z*texArray3476 )/( weightedBlendVar5505.x + weightedBlendVar5505.y + weightedBlendVar5505.z ) );
			float4 lerpResult3467 = lerp( weightedAvg5504 , weightedAvg5505 , UVmixDistance636);
			half4 ifLocalVar5777 = 0;
			UNITY_BRANCH 
			if( _Texture_4_Triplanar == 1.0 )
				ifLocalVar5777 = lerpResult3467;
			else
				ifLocalVar5777 = lerpResult5761;
			half4 ifLocalVar6132 = 0;
			UNITY_BRANCH 
			if( _Texture_4_Albedo_Index > -1.0 )
				ifLocalVar6132 = ( ifLocalVar5777 * _Texture_4_Color );
			half4 Texture_4_Final3518 = ifLocalVar6132;
			float4 layeredBlendVar5643 = tex2DNode4368;
			float4 layeredBlend5643 = ( lerp( lerp( lerp( lerp( float4( 0,0,0,0 ) , Texture_1_Final950 , layeredBlendVar5643.x ) , Texture_2_Final3385 , layeredBlendVar5643.y ) , Texture_3_Final3451 , layeredBlendVar5643.z ) , Texture_4_Final3518 , layeredBlendVar5643.w ) );
			float4 texArray4450 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4416_0, _Texture_5_Albedo_Index)  );
			float4 texArray4445 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4416_0 / _Texture_5_Far_Multiplier ), _Texture_5_Albedo_Index)  );
			float4 lerpResult5789 = lerp( texArray4450 , texArray4445 , UVmixDistance636);
			float4 texArray4442 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4400_0, _Texture_5_Albedo_Index)  );
			float4 texArray4443 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4413_0, _Texture_5_Albedo_Index)  );
			float3 weightedBlendVar5512 = BlendComponents91;
			float4 weightedAvg5512 = ( ( weightedBlendVar5512.x*texArray4442 + weightedBlendVar5512.y*texArray4450 + weightedBlendVar5512.z*texArray4443 )/( weightedBlendVar5512.x + weightedBlendVar5512.y + weightedBlendVar5512.z ) );
			float4 texArray4444 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4400_0 / _Texture_5_Far_Multiplier ), _Texture_5_Albedo_Index)  );
			float4 texArray4439 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4413_0 / _Texture_5_Far_Multiplier ), _Texture_5_Albedo_Index)  );
			float3 weightedBlendVar5514 = BlendComponents91;
			float4 weightedAvg5514 = ( ( weightedBlendVar5514.x*texArray4444 + weightedBlendVar5514.y*texArray4445 + weightedBlendVar5514.z*texArray4439 )/( weightedBlendVar5514.x + weightedBlendVar5514.y + weightedBlendVar5514.z ) );
			float4 lerpResult4466 = lerp( weightedAvg5512 , weightedAvg5514 , UVmixDistance636);
			half4 ifLocalVar5804 = 0;
			UNITY_BRANCH 
			if( _Texture_5_Triplanar == 1.0 )
				ifLocalVar5804 = lerpResult4466;
			else
				ifLocalVar5804 = lerpResult5789;
			half4 ifLocalVar6134 = 0;
			UNITY_BRANCH 
			if( _Texture_5_Albedo_Index > -1.0 )
				ifLocalVar6134 = ( ifLocalVar5804 * _Texture_5_Color );
			half4 Texture_5_Final4396 = ifLocalVar6134;
			float4 texArray4517 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4485_0, _Texture_6_Albedo_Index)  );
			float4 texArray4512 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4485_0 / _Texture_6_Far_Multiplier ), _Texture_6_Albedo_Index)  );
			float4 lerpResult5794 = lerp( texArray4517 , texArray4512 , UVmixDistance636);
			float4 texArray4509 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4472_0, _Texture_6_Albedo_Index)  );
			float4 texArray4510 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4483_0, _Texture_6_Albedo_Index)  );
			float3 weightedBlendVar5520 = BlendComponents91;
			float4 weightedAvg5520 = ( ( weightedBlendVar5520.x*texArray4509 + weightedBlendVar5520.y*texArray4517 + weightedBlendVar5520.z*texArray4510 )/( weightedBlendVar5520.x + weightedBlendVar5520.y + weightedBlendVar5520.z ) );
			float4 texArray4511 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4472_0 / _Texture_6_Far_Multiplier ), _Texture_6_Albedo_Index)  );
			float4 texArray4506 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4483_0 / _Texture_6_Far_Multiplier ), _Texture_6_Albedo_Index)  );
			float3 weightedBlendVar5522 = BlendComponents91;
			float4 weightedAvg5522 = ( ( weightedBlendVar5522.x*texArray4511 + weightedBlendVar5522.y*texArray4512 + weightedBlendVar5522.z*texArray4506 )/( weightedBlendVar5522.x + weightedBlendVar5522.y + weightedBlendVar5522.z ) );
			float4 lerpResult4532 = lerp( weightedAvg5520 , weightedAvg5522 , UVmixDistance636);
			half4 ifLocalVar5809 = 0;
			UNITY_BRANCH 
			if( _Texture_6_Triplanar == 1.0 )
				ifLocalVar5809 = lerpResult4532;
			else
				ifLocalVar5809 = lerpResult5794;
			half4 ifLocalVar6136 = 0;
			UNITY_BRANCH 
			if( _Texture_6_Albedo_Index > -1.0 )
				ifLocalVar6136 = ( ifLocalVar5809 * _Texture_6_Color );
			half4 Texture_6_Final4536 = ifLocalVar6136;
			float4 texArray4591 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4559_0, _Texture_7_Albedo_Index)  );
			float4 texArray4586 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4559_0 / _Texture_7_Far_Multiplier ), _Texture_7_Albedo_Index)  );
			float4 lerpResult5798 = lerp( texArray4591 , texArray4586 , UVmixDistance636);
			float4 texArray4583 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4546_0, _Texture_7_Albedo_Index)  );
			float4 texArray4584 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4557_0, _Texture_7_Albedo_Index)  );
			float3 weightedBlendVar5524 = BlendComponents91;
			float4 weightedAvg5524 = ( ( weightedBlendVar5524.x*texArray4583 + weightedBlendVar5524.y*texArray4591 + weightedBlendVar5524.z*texArray4584 )/( weightedBlendVar5524.x + weightedBlendVar5524.y + weightedBlendVar5524.z ) );
			float4 texArray4585 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4546_0 / _Texture_7_Far_Multiplier ), _Texture_7_Albedo_Index)  );
			float4 texArray4580 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4557_0 / _Texture_7_Far_Multiplier ), _Texture_7_Albedo_Index)  );
			float3 weightedBlendVar5526 = BlendComponents91;
			float4 weightedAvg5526 = ( ( weightedBlendVar5526.x*texArray4585 + weightedBlendVar5526.y*texArray4586 + weightedBlendVar5526.z*texArray4580 )/( weightedBlendVar5526.x + weightedBlendVar5526.y + weightedBlendVar5526.z ) );
			float4 lerpResult4606 = lerp( weightedAvg5524 , weightedAvg5526 , UVmixDistance636);
			half4 ifLocalVar5812 = 0;
			UNITY_BRANCH 
			if( _Texture_7_Triplanar == 1.0 )
				ifLocalVar5812 = lerpResult4606;
			else
				ifLocalVar5812 = lerpResult5798;
			half4 ifLocalVar6139 = 0;
			UNITY_BRANCH 
			if( _Texture_7_Albedo_Index > -1.0 )
				ifLocalVar6139 = ( ifLocalVar5812 * _Texture_7_Color );
			half4 Texture_7_Final4614 = ifLocalVar6139;
			float4 texArray4665 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4633_0, _Texture_8_Albedo_Index)  );
			float4 texArray4660 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4633_0 / _Texture_8_Far_Multiplier ), _Texture_8_Albedo_Index)  );
			float4 lerpResult5802 = lerp( texArray4665 , texArray4660 , UVmixDistance636);
			float4 texArray4657 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4620_0, _Texture_8_Albedo_Index)  );
			float4 texArray4658 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4631_0, _Texture_8_Albedo_Index)  );
			float3 weightedBlendVar5528 = BlendComponents91;
			float4 weightedAvg5528 = ( ( weightedBlendVar5528.x*texArray4657 + weightedBlendVar5528.y*texArray4665 + weightedBlendVar5528.z*texArray4658 )/( weightedBlendVar5528.x + weightedBlendVar5528.y + weightedBlendVar5528.z ) );
			float4 texArray4659 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4620_0 / _Texture_8_Far_Multiplier ), _Texture_8_Albedo_Index)  );
			float4 texArray4654 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4631_0 / _Texture_8_Far_Multiplier ), _Texture_8_Albedo_Index)  );
			float3 weightedBlendVar5530 = BlendComponents91;
			float4 weightedAvg5530 = ( ( weightedBlendVar5530.x*texArray4659 + weightedBlendVar5530.y*texArray4660 + weightedBlendVar5530.z*texArray4654 )/( weightedBlendVar5530.x + weightedBlendVar5530.y + weightedBlendVar5530.z ) );
			float4 lerpResult4680 = lerp( weightedAvg5528 , weightedAvg5530 , UVmixDistance636);
			half4 ifLocalVar5815 = 0;
			UNITY_BRANCH 
			if( _Texture_8_Triplanar == 1.0 )
				ifLocalVar5815 = lerpResult4680;
			else
				ifLocalVar5815 = lerpResult5802;
			half4 ifLocalVar6141 = 0;
			UNITY_BRANCH 
			if( _Texture_8_Albedo_Index > -1.0 )
				ifLocalVar6141 = ( ifLocalVar5815 * _Texture_8_Color );
			half4 Texture_8_Final4689 = ifLocalVar6141;
			float4 layeredBlendVar5644 = tex2DNode4369;
			float4 layeredBlend5644 = ( lerp( lerp( lerp( lerp( layeredBlend5643 , Texture_5_Final4396 , layeredBlendVar5644.x ) , Texture_6_Final4536 , layeredBlendVar5644.y ) , Texture_7_Final4614 , layeredBlendVar5644.z ) , Texture_8_Final4689 , layeredBlendVar5644.w ) );
			float4 texArray4723 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4712_0, _Texture_9_Albedo_Index)  );
			float4 texArray4889 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4712_0 / _Texture_9_Far_Multiplier ), _Texture_9_Albedo_Index)  );
			float4 lerpResult5845 = lerp( texArray4723 , texArray4889 , UVmixDistance636);
			float4 texArray5286 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4706_0, _Texture_9_Albedo_Index)  );
			float4 texArray4858 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4761_0, _Texture_9_Albedo_Index)  );
			float3 weightedBlendVar5489 = BlendComponents91;
			float4 weightedAvg5489 = ( ( weightedBlendVar5489.x*texArray5286 + weightedBlendVar5489.y*texArray4723 + weightedBlendVar5489.z*texArray4858 )/( weightedBlendVar5489.x + weightedBlendVar5489.y + weightedBlendVar5489.z ) );
			float4 texArray4719 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4706_0 / _Texture_9_Far_Multiplier ), _Texture_9_Albedo_Index)  );
			float4 texArray4865 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4761_0 / _Texture_9_Far_Multiplier ), _Texture_9_Albedo_Index)  );
			float3 weightedBlendVar5490 = BlendComponents91;
			float4 weightedAvg5490 = ( ( weightedBlendVar5490.x*texArray4719 + weightedBlendVar5490.y*texArray4889 + weightedBlendVar5490.z*texArray4865 )/( weightedBlendVar5490.x + weightedBlendVar5490.y + weightedBlendVar5490.z ) );
			float4 lerpResult4976 = lerp( weightedAvg5489 , weightedAvg5490 , UVmixDistance636);
			half4 ifLocalVar5844 = 0;
			UNITY_BRANCH 
			if( _Texture_9_Triplanar == 1.0 )
				ifLocalVar5844 = lerpResult4976;
			else
				ifLocalVar5844 = lerpResult5845;
			half4 ifLocalVar6143 = 0;
			UNITY_BRANCH 
			if( _Texture_9_Albedo_Index > -1.0 )
				ifLocalVar6143 = ( ifLocalVar5844 * _Texture_9_Color );
			half4 Texture_9_Final4987 = ifLocalVar6143;
			float4 texArray4899 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4793_0, _Texture_10_Albedo_Index)  );
			float4 texArray4913 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4793_0 / _Texture_10_Far_Multiplier ), _Texture_10_Albedo_Index)  );
			float4 lerpResult5841 = lerp( texArray4899 , texArray4913 , UVmixDistance636);
			float4 texArray4886 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4742_0, _Texture_10_Albedo_Index)  );
			float4 texArray4877 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4785_0, _Texture_10_Albedo_Index)  );
			float3 weightedBlendVar5532 = BlendComponents91;
			float4 weightedAvg5532 = ( ( weightedBlendVar5532.x*texArray4886 + weightedBlendVar5532.y*texArray4899 + weightedBlendVar5532.z*texArray4877 )/( weightedBlendVar5532.x + weightedBlendVar5532.y + weightedBlendVar5532.z ) );
			float4 texArray4894 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4742_0 / _Texture_10_Far_Multiplier ), _Texture_10_Albedo_Index)  );
			float4 texArray4878 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4785_0 / _Texture_10_Far_Multiplier ), _Texture_10_Albedo_Index)  );
			float3 weightedBlendVar5534 = BlendComponents91;
			float4 weightedAvg5534 = ( ( weightedBlendVar5534.x*texArray4894 + weightedBlendVar5534.y*texArray4913 + weightedBlendVar5534.z*texArray4878 )/( weightedBlendVar5534.x + weightedBlendVar5534.y + weightedBlendVar5534.z ) );
			float4 lerpResult4983 = lerp( weightedAvg5532 , weightedAvg5534 , UVmixDistance636);
			half4 ifLocalVar5840 = 0;
			UNITY_BRANCH 
			if( _Texture_10_Triplanar == 1.0 )
				ifLocalVar5840 = lerpResult4983;
			else
				ifLocalVar5840 = lerpResult5841;
			half4 ifLocalVar6145 = 0;
			UNITY_BRANCH 
			if( _Texture_10_Albedo_Index > -1.0 )
				ifLocalVar6145 = ( ifLocalVar5840 * _Texture_10_Color );
			half4 Texture_10_Final4994 = ifLocalVar6145;
			float4 texArray4928 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4817_0, _Texture_11_Albedo_Index)  );
			float4 texArray4923 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4817_0 / _Texture_11_Far_Multiplier ), _Texture_11_Albedo_Index)  );
			float4 lerpResult5837 = lerp( texArray4928 , texArray4923 , UVmixDistance636);
			float4 texArray4917 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4748_0, _Texture_11_Albedo_Index)  );
			float4 texArray4911 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4795_0, _Texture_11_Albedo_Index)  );
			float3 weightedBlendVar5536 = BlendComponents91;
			float4 weightedAvg5536 = ( ( weightedBlendVar5536.x*texArray4917 + weightedBlendVar5536.y*texArray4928 + weightedBlendVar5536.z*texArray4911 )/( weightedBlendVar5536.x + weightedBlendVar5536.y + weightedBlendVar5536.z ) );
			float4 texArray4898 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4748_0 / _Texture_11_Far_Multiplier ), _Texture_11_Albedo_Index)  );
			float4 texArray4914 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4795_0 / _Texture_11_Far_Multiplier ), _Texture_11_Albedo_Index)  );
			float3 weightedBlendVar5538 = BlendComponents91;
			float4 weightedAvg5538 = ( ( weightedBlendVar5538.x*texArray4898 + weightedBlendVar5538.y*texArray4923 + weightedBlendVar5538.z*texArray4914 )/( weightedBlendVar5538.x + weightedBlendVar5538.y + weightedBlendVar5538.z ) );
			float4 lerpResult4988 = lerp( weightedAvg5536 , weightedAvg5538 , UVmixDistance636);
			half4 ifLocalVar5836 = 0;
			UNITY_BRANCH 
			if( _Texture_11_Triplanar == 1.0 )
				ifLocalVar5836 = lerpResult4988;
			else
				ifLocalVar5836 = lerpResult5837;
			half4 ifLocalVar6147 = 0;
			UNITY_BRANCH 
			if( _Texture_11_Albedo_Index > -1.0 )
				ifLocalVar6147 = ( ifLocalVar5836 * _Texture_11_Color );
			half4 Texture_11_Final4996 = ifLocalVar6147;
			float4 texArray4954 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4849_0, _Texture_12_Albedo_Index)  );
			float4 texArray4952 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4849_0 / _Texture_12_Far_Multiplier ), _Texture_12_Albedo_Index)  );
			float4 lerpResult5833 = lerp( texArray4954 , texArray4952 , UVmixDistance636);
			float4 texArray4926 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4758_0, _Texture_12_Albedo_Index)  );
			float4 texArray4927 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4830_0, _Texture_12_Albedo_Index)  );
			float3 weightedBlendVar5540 = BlendComponents91;
			float4 weightedAvg5540 = ( ( weightedBlendVar5540.x*texArray4926 + weightedBlendVar5540.y*texArray4954 + weightedBlendVar5540.z*texArray4927 )/( weightedBlendVar5540.x + weightedBlendVar5540.y + weightedBlendVar5540.z ) );
			float4 texArray4919 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4758_0 / _Texture_12_Far_Multiplier ), _Texture_12_Albedo_Index)  );
			float4 texArray4931 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_4830_0 / _Texture_12_Far_Multiplier ), _Texture_12_Albedo_Index)  );
			float3 weightedBlendVar5542 = BlendComponents91;
			float4 weightedAvg5542 = ( ( weightedBlendVar5542.x*texArray4919 + weightedBlendVar5542.y*texArray4952 + weightedBlendVar5542.z*texArray4931 )/( weightedBlendVar5542.x + weightedBlendVar5542.y + weightedBlendVar5542.z ) );
			float4 lerpResult4993 = lerp( weightedAvg5540 , weightedAvg5542 , UVmixDistance636);
			half4 ifLocalVar5832 = 0;
			UNITY_BRANCH 
			if( _Texture_12_Triplanar == 1.0 )
				ifLocalVar5832 = lerpResult4993;
			else
				ifLocalVar5832 = lerpResult5833;
			half4 ifLocalVar6169 = 0;
			UNITY_BRANCH 
			if( _Texture_12_Albedo_Index > -1.0 )
				ifLocalVar6169 = ( ifLocalVar5832 * _Texture_12_Color );
			half4 Texture_12_Final4997 = ifLocalVar6169;
			float4 layeredBlendVar5645 = tex2DNode4370;
			float4 layeredBlend5645 = ( lerp( lerp( lerp( lerp( layeredBlend5644 , Texture_9_Final4987 , layeredBlendVar5645.x ) , Texture_10_Final4994 , layeredBlendVar5645.y ) , Texture_11_Final4996 , layeredBlendVar5645.z ) , Texture_12_Final4997 , layeredBlendVar5645.w ) );
			float4 texArray5043 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5037_0, _Texture_13_Albedo_Index)  );
			float4 texArray5034 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_5037_0 / _Texture_13_Far_Multiplier ), _Texture_13_Albedo_Index)  );
			float4 lerpResult5829 = lerp( texArray5043 , texArray5034 , UVmixDistance636);
			float4 texArray5128 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5025_0, _Texture_13_Albedo_Index)  );
			float4 texArray5129 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5035_0, _Texture_13_Albedo_Index)  );
			float3 weightedBlendVar5544 = BlendComponents91;
			float4 weightedAvg5544 = ( ( weightedBlendVar5544.x*texArray5128 + weightedBlendVar5544.y*texArray5043 + weightedBlendVar5544.z*texArray5129 )/( weightedBlendVar5544.x + weightedBlendVar5544.y + weightedBlendVar5544.z ) );
			float4 texArray5130 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_5025_0 / _Texture_13_Far_Multiplier ), _Texture_13_Albedo_Index)  );
			float4 texArray5121 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_5035_0 / _Texture_13_Far_Multiplier ), _Texture_13_Albedo_Index)  );
			float3 weightedBlendVar5546 = BlendComponents91;
			float4 weightedAvg5546 = ( ( weightedBlendVar5546.x*texArray5130 + weightedBlendVar5546.y*texArray5034 + weightedBlendVar5546.z*texArray5121 )/( weightedBlendVar5546.x + weightedBlendVar5546.y + weightedBlendVar5546.z ) );
			float4 lerpResult5054 = lerp( weightedAvg5544 , weightedAvg5546 , UVmixDistance636);
			half4 ifLocalVar5828 = 0;
			UNITY_BRANCH 
			if( _Texture_13_Triplanar == 1.0 )
				ifLocalVar5828 = lerpResult5054;
			else
				ifLocalVar5828 = lerpResult5829;
			half4 ifLocalVar6151 = 0;
			UNITY_BRANCH 
			if( _Texture_13_Albedo_Index > -1.0 )
				ifLocalVar6151 = ( ifLocalVar5828 * _Texture_13_Color );
			half4 Texture_13_Final5058 = ifLocalVar6151;
			float4 texArray5202 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5022_0, _Texture_14_Albedo_Index)  );
			float4 texArray5171 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_5022_0 / _Texture_14_Far_Multiplier ), _Texture_14_Albedo_Index)  );
			float4 lerpResult5825 = lerp( texArray5202 , texArray5171 , UVmixDistance636);
			float4 texArray5168 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5009_0, _Texture_14_Albedo_Index)  );
			float4 texArray5239 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5010_0, _Texture_14_Albedo_Index)  );
			float3 weightedBlendVar5548 = BlendComponents91;
			float4 weightedAvg5548 = ( ( weightedBlendVar5548.x*texArray5168 + weightedBlendVar5548.y*texArray5202 + weightedBlendVar5548.z*texArray5239 )/( weightedBlendVar5548.x + weightedBlendVar5548.y + weightedBlendVar5548.z ) );
			float4 texArray5205 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_5009_0 / _Texture_14_Far_Multiplier ), _Texture_14_Albedo_Index)  );
			float4 texArray5241 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_5010_0 / _Texture_14_Far_Multiplier ), _Texture_14_Albedo_Index)  );
			float3 weightedBlendVar5550 = BlendComponents91;
			float4 weightedAvg5550 = ( ( weightedBlendVar5550.x*texArray5205 + weightedBlendVar5550.y*texArray5171 + weightedBlendVar5550.z*texArray5241 )/( weightedBlendVar5550.x + weightedBlendVar5550.y + weightedBlendVar5550.z ) );
			float4 lerpResult5197 = lerp( weightedAvg5548 , weightedAvg5550 , UVmixDistance636);
			half4 ifLocalVar5824 = 0;
			UNITY_BRANCH 
			if( _Texture_14_Triplanar == 1.0 )
				ifLocalVar5824 = lerpResult5197;
			else
				ifLocalVar5824 = lerpResult5825;
			half4 ifLocalVar6153 = 0;
			UNITY_BRANCH 
			if( _Texture_14_Albedo_Index > -1.0 )
				ifLocalVar6153 = ( ifLocalVar5824 * _Texture_14_Color );
			half4 Texture_14_Final5163 = ifLocalVar6153;
			float4 texArray5259 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5226_0, _Texture_15_Albedo_Index)  );
			float4 texArray5272 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_5226_0 / _Texture_15_Far_Multiplier ), _Texture_15_Albedo_Index)  );
			float4 lerpResult5821 = lerp( texArray5259 , texArray5272 , UVmixDistance636);
			float4 texArray5182 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5213_0, _Texture_15_Albedo_Index)  );
			float4 texArray5189 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5224_0, _Texture_15_Albedo_Index)  );
			float3 weightedBlendVar5552 = BlendComponents91;
			float4 weightedAvg5552 = ( ( weightedBlendVar5552.x*texArray5182 + weightedBlendVar5552.y*texArray5259 + weightedBlendVar5552.z*texArray5189 )/( weightedBlendVar5552.x + weightedBlendVar5552.y + weightedBlendVar5552.z ) );
			float4 texArray5188 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_5213_0 / _Texture_15_Far_Multiplier ), _Texture_15_Albedo_Index)  );
			float4 texArray5247 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_5224_0 / _Texture_15_Far_Multiplier ), _Texture_15_Albedo_Index)  );
			float3 weightedBlendVar5554 = BlendComponents91;
			float4 weightedAvg5554 = ( ( weightedBlendVar5554.x*texArray5188 + weightedBlendVar5554.y*texArray5272 + weightedBlendVar5554.z*texArray5247 )/( weightedBlendVar5554.x + weightedBlendVar5554.y + weightedBlendVar5554.z ) );
			float4 lerpResult5279 = lerp( weightedAvg5552 , weightedAvg5554 , UVmixDistance636);
			half4 ifLocalVar5820 = 0;
			UNITY_BRANCH 
			if( _Texture_15_Triplanar == 1.0 )
				ifLocalVar5820 = lerpResult5279;
			else
				ifLocalVar5820 = lerpResult5821;
			half4 ifLocalVar6155 = 0;
			UNITY_BRANCH 
			if( _Texture_15_Albedo_Index > -1.0 )
				ifLocalVar6155 = ( ifLocalVar5820 * _Texture_15_Color );
			half4 Texture_15_Final5270 = ifLocalVar6155;
			float4 texArray5139 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5083_0, _Texture_16_Albedo_Index)  );
			float4 texArray5143 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_5083_0 / _Texture_16_Far_Multiplier ), _Texture_16_Albedo_Index)  );
			float4 lerpResult5817 = lerp( texArray5139 , texArray5143 , UVmixDistance636);
			float4 texArray5150 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5079_0, _Texture_16_Albedo_Index)  );
			float4 texArray5145 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5085_0, _Texture_16_Albedo_Index)  );
			float3 weightedBlendVar5556 = BlendComponents91;
			float4 weightedAvg5556 = ( ( weightedBlendVar5556.x*texArray5150 + weightedBlendVar5556.y*texArray5139 + weightedBlendVar5556.z*texArray5145 )/( weightedBlendVar5556.x + weightedBlendVar5556.y + weightedBlendVar5556.z ) );
			float4 texArray5144 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_5079_0 / _Texture_16_Far_Multiplier ), _Texture_16_Albedo_Index)  );
			float4 texArray5154 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_5085_0 / _Texture_16_Far_Multiplier ), _Texture_16_Albedo_Index)  );
			float3 weightedBlendVar5558 = BlendComponents91;
			float4 weightedAvg5558 = ( ( weightedBlendVar5558.x*texArray5144 + weightedBlendVar5558.y*texArray5143 + weightedBlendVar5558.z*texArray5154 )/( weightedBlendVar5558.x + weightedBlendVar5558.y + weightedBlendVar5558.z ) );
			float4 lerpResult5104 = lerp( weightedAvg5556 , weightedAvg5558 , UVmixDistance636);
			half4 ifLocalVar5816 = 0;
			UNITY_BRANCH 
			if( _Texture_16_Triplanar == 1.0 )
				ifLocalVar5816 = lerpResult5104;
			else
				ifLocalVar5816 = lerpResult5817;
			half4 ifLocalVar6183 = 0;
			UNITY_BRANCH 
			if( _Texture_16_Albedo_Index > -1.0 )
				ifLocalVar6183 = ( ifLocalVar5816 * _Texture_16_Color );
			half4 Texture_16_Final5094 = ifLocalVar6183;
			float4 layeredBlendVar5646 = tex2DNode4371;
			float4 layeredBlend5646 = ( lerp( lerp( lerp( lerp( layeredBlend5645 , Texture_13_Final5058 , layeredBlendVar5646.x ) , Texture_14_Final5163 , layeredBlendVar5646.y ) , Texture_15_Final5270 , layeredBlendVar5646.z ) , Texture_16_Final5094 , layeredBlendVar5646.w ) );
			float4 break3856 = layeredBlend5646;
			float3 appendResult3857 = (half3(break3856.x , break3856.y , break3856.z));
			float3 appendResult6206 = (half3(tex2DNode6204.r , tex2DNode6204.g , tex2DNode6204.b));
			float2 weightedBlendVar6240 = appendResult6241;
			float3 weightedAvg6240 = ( ( weightedBlendVar6240.x*appendResult3857 + weightedBlendVar6240.y*appendResult6206 )/( weightedBlendVar6240.x + weightedBlendVar6240.y ) );
			half2 temp_cast_2 = (( _Geological_Map_Offset_Close + ( ase_worldPos.y / _Geological_Tiling_Close ) )).xx;
			half4 tex2DNode5984 = tex2D( _Texture_Geological_Map, temp_cast_2 );
			float3 appendResult5986 = (half3(tex2DNode5984.r , tex2DNode5984.g , tex2DNode5984.b));
			half2 temp_cast_3 = (( ( ase_worldPos.y / _Geological_Tiling_Far ) + _Geological_Map_Offset_Far )).xx;
			half4 tex2DNode5983 = tex2D( _Texture_Geological_Map, temp_cast_3 );
			float3 appendResult5985 = (half3(tex2DNode5983.r , tex2DNode5983.g , tex2DNode5983.b));
			float3 lerpResult1315 = lerp( ( _Geological_Map_Close_Power * ( appendResult5986 + float3( -0.3,-0.3,-0.3 ) ) ) , ( _Geological_Map_Far_Power * ( appendResult5985 + float3( -0.3,-0.3,-0.3 ) ) ) , UVmixDistance636);
			half3 blendOpSrc4362 = weightedAvg6240;
			half3 blendOpDest4362 = ( lerpResult1315 * ( ( _Texture_16_Geological_Power * Splat4_A2546 ) + ( ( _Texture_15_Geological_Power * Splat4_B2545 ) + ( ( _Texture_14_Geological_Power * Splat4_G2544 ) + ( ( _Texture_13_Geological_Power * Splat4_R2543 ) + ( ( _Texture_12_Geological_Power * Splat3_A2540 ) + ( ( _Texture_11_Geological_Power * Splat3_B2539 ) + ( ( _Texture_10_Geological_Power * Splat3_G2538 ) + ( ( _Texture_9_Geological_Power * Splat3_R2537 ) + ( ( _Texture_8_Geological_Power * Splat2_A2109 ) + ( ( _Texture_7_Geological_Power * Splat2_B2108 ) + ( ( _Texture_6_Geological_Power * Splat2_G2107 ) + ( ( _Texture_5_Geological_Power * Splat2_R2106 ) + ( ( _Texture_1_Geological_Power * Splat1_R1438 ) + ( ( _Texture_2_Geological_Power * Splat1_G1441 ) + ( ( _Texture_4_Geological_Power * Splat1_A1491 ) + ( _Texture_3_Geological_Power * Splat1_B1442 ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) );
			float3 clampResult5715 = clamp( ( saturate( ( blendOpSrc4362 + blendOpDest4362 ) )) , float3( 0,0,0 ) , float3( 1,1,1 ) );
			float4 texArray4378 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3893_0, _Texture_Snow_Index)  );
			float4 lerpResult1416 = lerp( texArray4378 , _Texture_Snow_Average , UVmixDistance636);
			half4 ifLocalVar6165 = 0;
			UNITY_BRANCH 
			if( _Texture_Snow_Index > -1.0 )
				ifLocalVar6165 = ( lerpResult1416 * _Snow_Color );
			float4 break1409 = ifLocalVar6165;
			float3 appendResult1410 = (half3(break1409.x , break1409.y , break1409.z));
			half3 In06279 = float3( 0,0,0 );
			half localMyCustomExpression6279 = MyCustomExpression6279( In06279 );
			float3 break6278 = _WorldSpaceCameraPos;
			float temp_output_6283_0 = ( _Glitter_Refreshing_Speed * ( ( localMyCustomExpression6279 * 10.0 ) + ( break6278.x + break6278.y + break6278.z ) ) );
			float temp_output_6286_0 = ( 0.0 + temp_output_6283_0 );
			float clampResult6298 = clamp( sin( ( temp_output_6286_0 * 0.1 ) ) , 0.0 , 1.0 );
			float2 temp_output_6289_0 = ( Top_Bottom1999 * ( 1.0 / _Glitter_Tiling ) );
			float2 break6322 = temp_output_6289_0;
			float2 appendResult6321 = (half2(break6322.y , break6322.x));
			half4 tex2DNode6300 = tex2D( _Texture_Glitter, ( appendResult6321 + float2( 0.37,0.67 ) ) );
			float2 panner6290 = ( ( temp_output_6283_0 * 0.01 ) * float2( 1,1 ) + temp_output_6289_0);
			float cos6292 = cos( sin( ( temp_output_6286_0 * 0.0001 ) ) );
			float sin6292 = sin( sin( ( temp_output_6286_0 * 0.0001 ) ) );
			float2 rotator6292 = mul( panner6290 - float2( 0.5,0.5 ) , float2x2( cos6292 , -sin6292 , sin6292 , cos6292 )) + float2( 0.5,0.5 );
			float clampResult6302 = clamp( pow( tex2D( _Texture_Glitter, ( ( rotator6292 + temp_output_6289_0 ) * float2( 0.2,0.2 ) ) ).r , ( 1.0 - _Glitter_Noise_Threshold ) ) , 0.0 , 1.0 );
			float lerpResult6303 = lerp(  ( clampResult6298 - 0.2 > 0.0 ? tex2D( _Texture_Glitter, temp_output_6289_0 ).r : clampResult6298 - 0.2 <= 0.0 && clampResult6298 + 0.2 >= 0.0 ? tex2DNode6300.r : tex2DNode6300.r )  , 0.6 , clampResult6302);
			float clampResult6305 = clamp( pow( lerpResult6303 , 100.0 ) , 0.0 , 1.0 );
			float temp_output_6306_0 = ( _Gliter_Color_Power * clampResult6305 );
			float3 lerpResult1356 = lerp( clampResult5715 , ( appendResult1410 + temp_output_6306_0 ) , lerpResult3742);
			o.Albedo = lerpResult1356;
			float3 clampResult5471 = clamp( appendResult1410 , float3( 0,0,0 ) , float3( 0.5,0.5,0.5 ) );
			half3 temp_cast_4 = (_Glitter_Specular).xxx;
			float clampResult6307 = clamp( temp_output_6306_0 , 0.0 , 1.0 );
			float3 lerpResult6309 = lerp( ( clampResult5471 * _Snow_Specular ) , temp_cast_4 , clampResult6307);
			float3 lerpResult4040 = lerp( ( ( appendResult3857 * float3( 0.3,0.3,0.3 ) ) * _Terrain_Specular ) , lerpResult6309 , lerpResult3742);
			o.Specular = lerpResult4040;
			float lerpResult6308 = lerp( break1409.w , _Glitter_Smoothness , clampResult6307);
			float lerpResult3951 = lerp( ( break3856.w * _Terrain_Smoothness ) , lerpResult6308 , lerpResult3742);
			o.Smoothness = lerpResult3951;
			float clampResult5699 = clamp( ( ( 1.0 + temp_output_4100_0.y ) * 0.5 ) , ( 1.0 - _Ambient_Occlusion_Power ) , 1.0 );
			#ifdef _USE_AO_ON
				float staticSwitch6192 = clampResult5699;
			#else
				float staticSwitch6192 = 1.0;
			#endif
			o.Occlusion = staticSwitch6192;
			o.Alpha = 1;
			float2 uv_TerrainHolesTexture = i.uv_texcoord * _TerrainHolesTexture_ST.xy + _TerrainHolesTexture_ST.zw;
			float clampResult6254 = clamp( ( ase_worldPos.y + ( 0.0 - _Remove_Vert_Height ) ) , 0.0 , 1.0 );
			clip( ( tex2D( _TerrainHolesTexture, uv_TerrainHolesTexture ).r * clampResult6254 ) - _Cutoff );
			//float hole = (tex2D(_TerrainHolesTexture, uv_TerrainHolesTexture).r * clampResult6254 ) - _Cutoff ;
           // clip(hole <= 0.0f ? -1 : 1);
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

	Dependency "BaseMapShader"="CTS/CTS Terrain Shader Basic LOD CutOut"
	Fallback "Diffuse"
}