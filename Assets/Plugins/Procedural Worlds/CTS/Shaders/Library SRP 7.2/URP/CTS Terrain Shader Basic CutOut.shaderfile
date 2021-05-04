 Shader "CTS/URP/CTS Terrain Shader Basic CutOut"
{
    Properties
    {
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
		_Texture_14_Perlin_Power("Texture_14_Perlin_Power", Range( 0 , 1)) = 0
		_Texture_15_Perlin_Power("Texture_15_Perlin_Power", Range( 0 , 1)) = 0
		_Texture_16_Perlin_Power("Texture_16_Perlin_Power", Range( 0 , 1)) = 0
		_Texture_1_Geological_Power("Texture_1_Geological_Power", Range( 0 , 5)) = 1
		_Texture_Array_Albedo("Texture_Array_Albedo", 2DArray ) = "" {}
		_Texture_Array_Normal("Texture_Array_Normal", 2DArray ) = "" {}
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
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
    }


    SubShader
    {
		
        Tags { "RenderPipeline"="UniversalPipeline" "RenderType"="Opaque" "Queue"="Geometry-100" }

		Cull Back
		HLSLINCLUDE
		#pragma target 4.0
		ENDHLSL
		
        Pass
        {
			
        	Tags { "LightMode"="UniversalForward" }

        	Name "Base"
			Blend One Zero
			ZWrite On
			ZTest LEqual
			Offset 0 , 0
			ColorMask RGBA
            
        	HLSLPROGRAM
            
            // Required to compile gles 2.0 with standard srp library
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x
            

        	// -------------------------------------
            // Lightweight Pipeline keywords
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE
            #pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
            #pragma multi_compile _ _ADDITIONAL_LIGHT_SHADOWS
            #pragma multi_compile _ _SHADOWS_SOFT
            #pragma multi_compile _ _MIXED_LIGHTING_SUBTRACTIVE
            
        	// -------------------------------------
            // Unity defined keywords
            #pragma multi_compile _ DIRLIGHTMAP_COMBINED
            #pragma multi_compile _ LIGHTMAP_ON
            #pragma multi_compile_fog

            //--------------------------------------
            // GPU Instancing
            #pragma multi_compile_instancing

            #pragma vertex vert
        	#pragma fragment frag

        	#define ASE_SRP_VERSION 60900
        	#define _NORMALMAP 1
        	#define _SPECULAR_SETUP 1
        	#pragma multi_compile __ _USE_AO_ON
        	#include "TerrainVertexCTS.hlsl"
        	#pragma instancing_options assumeuniformscaling nomatrices nolightprobe nolightmap


        	#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        	#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
        	#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
        	#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/UnityInstancing.hlsl"
        	#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"

			half _Global_Color_Map_Close_Power;
			half _Global_Color_Map_Far_Power;
			half _UV_Mix_Start_Distance;
			half _UV_Mix_Power;
			sampler2D _Global_Color_Map;
			float2 _Global_Color_Map_Offset;
			float _Global_Color_Map_Scale;
			half _Global_Color_Opacity_Power;
			sampler2D _Texture_Splat_4;
			sampler2D _Texture_Splat_3;
			sampler2D _Texture_Splat_2;
			sampler2D _Texture_Splat_1;
			half _Texture_1_Albedo_Index;
			half _Texture_1_Triplanar;
			TEXTURE2D_ARRAY( _Texture_Array_Albedo );
			uniform SAMPLER( sampler_Texture_Array_Albedo );
			float _Texture_1_Tiling;
			half _Texture_1_Far_Multiplier;
			half4 _Texture_1_Color;
			float _Texture_2_Albedo_Index;
			float _Texture_2_Triplanar;
			half _Texture_2_Tiling;
			half _Texture_2_Far_Multiplier;
			half4 _Texture_2_Color;
			float _Texture_3_Albedo_Index;
			float _Texture_3_Triplanar;
			half _Texture_3_Tiling;
			half _Texture_3_Far_Multiplier;
			half4 _Texture_3_Color;
			float _Texture_4_Albedo_Index;
			float _Texture_4_Triplanar;
			half _Texture_4_Tiling;
			half _Texture_4_Far_Multiplier;
			half4 _Texture_4_Color;
			float _Texture_5_Albedo_Index;
			float _Texture_5_Triplanar;
			half _Texture_5_Tiling;
			half _Texture_5_Far_Multiplier;
			half4 _Texture_5_Color;
			float _Texture_6_Albedo_Index;
			float _Texture_6_Triplanar;
			half _Texture_6_Tiling;
			half _Texture_6_Far_Multiplier;
			half4 _Texture_6_Color;
			float _Texture_7_Albedo_Index;
			float _Texture_7_Triplanar;
			half _Texture_7_Tiling;
			half _Texture_7_Far_Multiplier;
			half4 _Texture_7_Color;
			float _Texture_8_Albedo_Index;
			float _Texture_8_Triplanar;
			half _Texture_8_Tiling;
			half _Texture_8_Far_Multiplier;
			half4 _Texture_8_Color;
			half _Texture_9_Albedo_Index;
			half _Texture_9_Triplanar;
			half _Texture_9_Tiling;
			half _Texture_9_Far_Multiplier;
			half4 _Texture_9_Color;
			half _Texture_10_Albedo_Index;
			half _Texture_10_Triplanar;
			half _Texture_10_Tiling;
			half _Texture_10_Far_Multiplier;
			half4 _Texture_10_Color;
			half _Texture_11_Albedo_Index;
			half _Texture_11_Triplanar;
			half _Texture_11_Tiling;
			half _Texture_11_Far_Multiplier;
			half4 _Texture_11_Color;
			half _Texture_12_Albedo_Index;
			half _Texture_12_Triplanar;
			half _Texture_12_Tiling;
			half _Texture_12_Far_Multiplier;
			half4 _Texture_12_Color;
			half _Texture_13_Albedo_Index;
			half _Texture_13_Triplanar;
			half _Texture_13_Tiling;
			half _Texture_13_Far_Multiplier;
			half4 _Texture_13_Color;
			half _Texture_14_Albedo_Index;
			half _Texture_14_Triplanar;
			half _Texture_14_Tiling;
			half _Texture_14_Far_Multiplier;
			half4 _Texture_14_Color;
			half _Texture_15_Albedo_Index;
			half _Texture_15_Triplanar;
			half _Texture_15_Tiling;
			half _Texture_15_Far_Multiplier;
			half4 _Texture_15_Color;
			half _Texture_16_Albedo_Index;
			half _Texture_16_Triplanar;
			half _Texture_16_Tiling;
			half _Texture_16_Far_Multiplier;
			half4 _Texture_16_Color;
			half _Geological_Map_Close_Power;
			sampler2D _Texture_Geological_Map;
			half _Geological_Map_Offset_Close;
			half _Geological_Tiling_Close;
			half _Geological_Map_Far_Power;
			half _Geological_Tiling_Far;
			half _Geological_Map_Offset_Far;
			half _Texture_16_Geological_Power;
			half _Texture_15_Geological_Power;
			half _Texture_14_Geological_Power;
			half _Texture_13_Geological_Power;
			half _Texture_12_Geological_Power;
			half _Texture_11_Geological_Power;
			half _Texture_10_Geological_Power;
			half _Texture_9_Geological_Power;
			half _Texture_8_Geological_Power;
			half _Texture_7_Geological_Power;
			half _Texture_6_Geological_Power;
			half _Texture_5_Geological_Power;
			half _Texture_1_Geological_Power;
			half _Texture_2_Geological_Power;
			half _Texture_4_Geological_Power;
			half _Texture_3_Geological_Power;
			half _Texture_Snow_Index;
			half _Snow_Tiling;
			half4 _Texture_Snow_Average;
			half4 _Snow_Color;
			half _Gliter_Color_Power;
			half _Glitter_Refreshing_Speed;
			sampler2D _Texture_Glitter;
			half _Glitter_Tiling;
			half _Glitter_Noise_Threshold;
			half _Texture_1_Normal_Index;
			TEXTURE2D_ARRAY( _Texture_Array_Normal );
			uniform SAMPLER( sampler_Texture_Array_Normal );
			half _Texture_1_Normal_Power;
			float _Texture_2_Normal_Index;
			half _Texture_2_Normal_Power;
			float _Texture_3_Normal_Index;
			half _Texture_3_Normal_Power;
			float _Texture_4_Normal_Index;
			half _Texture_4_Normal_Power;
			float _Texture_5_Normal_Index;
			half _Texture_5_Normal_Power;
			float _Texture_6_Normal_Index;
			half _Texture_6_Normal_Power;
			float _Texture_7_Normal_Index;
			half _Texture_7_Normal_Power;
			float _Texture_8_Normal_Index;
			half _Texture_8_Normal_Power;
			half _Texture_9_Normal_Index;
			half _Texture_9_Normal_Power;
			half _Texture_10_Normal_Index;
			half _Texture_10_Normal_Power;
			half _Texture_11_Normal_Index;
			half _Texture_11_Normal_Power;
			half _Texture_12_Normal_Index;
			half _Texture_12_Normal_Power;
			half _Texture_13_Normal_Index;
			half _Texture_13_Normal_Power;
			half _Texture_14_Normal_Index;
			half _Texture_14_Normal_Power;
			half _Texture_15_Normal_Index;
			half _Texture_15_Normal_Power;
			half _Texture_16_Normal_Index;
			half _Texture_16_Normal_Power;
			float _Texture_Snow_Normal_Index;
			half _Snow_Normal_Scale;
			half _Snow_Blend_Normal;
			half _Snow_Amount;
			half _Snow_Noise_Tiling;
			half _Snow_Noise_Power;
			half _Snow_Maximum_Angle;
			half _Snow_Maximum_Angle_Hardness;
			half _Snow_Min_Height;
			half _Snow_Min_Height_Blending;
			half _Texture_16_Snow_Reduction;
			half _Texture_15_Snow_Reduction;
			half _Texture_13_Snow_Reduction;
			half _Texture_12_Snow_Reduction;
			half _Texture_11_Snow_Reduction;
			half _Texture_9_Snow_Reduction;
			half _Texture_8_Snow_Reduction;
			half _Texture_7_Snow_Reduction;
			half _Texture_5_Snow_Reduction;
			half _Texture_1_Snow_Reduction;
			half _Texture_2_Snow_Reduction;
			half _Texture_3_Snow_Reduction;
			half _Texture_4_Snow_Reduction;
			half _Texture_6_Snow_Reduction;
			half _Texture_10_Snow_Reduction;
			half _Texture_14_Snow_Reduction;
			half _Perlin_Normal_Tiling_Close;
			int _Texture_Perlin_Normal_Index;
			half _Perlin_Normal_Power_Close;
			half _Perlin_Normal_Tiling_Far;
			half _Perlin_Normal_Power;
			float _Texture_16_Perlin_Power;
			float _Texture_15_Perlin_Power;
			float _Texture_14_Perlin_Power;
			float _Texture_13_Perlin_Power;
			float _Texture_12_Perlin_Power;
			float _Texture_11_Perlin_Power;
			float _Texture_10_Perlin_Power;
			float _Texture_9_Perlin_Power;
			float _Texture_8_Perlin_Power;
			float _Texture_7_Perlin_Power;
			float _Texture_6_Perlin_Power;
			float _Texture_5_Perlin_Power;
			float _Texture_1_Perlin_Power;
			float _Texture_2_Perlin_Power;
			float _Texture_4_Perlin_Power;
			float _Texture_3_Perlin_Power;
			half _Snow_Perlin_Power;
			half _Global_Normalmap_Power;
			sampler2D _Global_Normal_Map;
			half _Terrain_Specular;
			half _Snow_Specular;
			half _Glitter_Specular;
			half _Terrain_Smoothness;
			half _Glitter_Smoothness;
			half _Ambient_Occlusion_Power;
			sampler2D _TerrainHolesTexture;
			float4 _TerrainHolesTexture_ST;
			half _Remove_Vert_Height;

            struct GraphVertexInput
            {
                float4 vertex : POSITION;
                float3 ase_normal : NORMAL;
                float4 ase_tangent : TANGENT;
                float4 texcoord1 : TEXCOORD1;
				float4 ase_texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

        	struct GraphVertexOutput
            {
                float4 clipPos                : SV_POSITION;
                float4 lightmapUVOrVertexSH	  : TEXCOORD0;
        		half4 fogFactorAndVertexLight : TEXCOORD1; // x: fogFactor, yzw: vertex light
            	float4 shadowCoord            : TEXCOORD2;
				float4 tSpace0					: TEXCOORD3;
				float4 tSpace1					: TEXCOORD4;
				float4 tSpace2					: TEXCOORD5;
				float4 ase_texcoord7 : TEXCOORD7;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            	UNITY_VERTEX_OUTPUT_STEREO
            };

			inline half MyCustomExpression6279( inout half3 In0 )
			{
				return UNITY_MATRIX_IT_MV[2].xyz;
			}
			
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
			

            GraphVertexOutput vert (GraphVertexInput v  )
        	{
        		GraphVertexOutput o = (GraphVertexOutput)0;
                UNITY_SETUP_INSTANCE_ID(v);
            	UNITY_TRANSFER_INSTANCE_ID(v, o);
        		UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				TerrainInstancing(v.vertex, v.ase_normal, v.ase_texcoord.xy);
				float3 localCalculateTangentsSRP6339 = ( ( v.ase_tangent.xyz * 0.0 ) );
				v.ase_tangent.xyz = cross ( v.ase_normal, float3( 0, 0, 1 ) );
				v.ase_tangent.w = -1;
				
				o.ase_texcoord7.xy = v.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord7.zw = 0;
				float3 vertexValue = localCalculateTangentsSRP6339;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
				v.vertex.xyz = vertexValue;
				#else
				v.vertex.xyz += vertexValue;
				#endif
				v.ase_normal =  v.ase_normal ;

        		// Vertex shader outputs defined by graph
                float3 lwWNormal = TransformObjectToWorldNormal(v.ase_normal);
				float3 lwWorldPos = TransformObjectToWorld(v.vertex.xyz);
				float3 lwWTangent = TransformObjectToWorldDir(v.ase_tangent.xyz);
				float3 lwWBinormal = normalize(cross(lwWNormal, lwWTangent) * v.ase_tangent.w);
				o.tSpace0 = float4(lwWTangent.x, lwWBinormal.x, lwWNormal.x, lwWorldPos.x);
				o.tSpace1 = float4(lwWTangent.y, lwWBinormal.y, lwWNormal.y, lwWorldPos.y);
				o.tSpace2 = float4(lwWTangent.z, lwWBinormal.z, lwWNormal.z, lwWorldPos.z);

                VertexPositionInputs vertexInput = GetVertexPositionInputs(v.vertex.xyz);
                
         		// We either sample GI from lightmap or SH.
        	    // Lightmap UV and vertex SH coefficients use the same interpolator ("float2 lightmapUV" for lightmap or "half3 vertexSH" for SH)
                // see DECLARE_LIGHTMAP_OR_SH macro.
        	    // The following funcions initialize the correct variable with correct data
        	    OUTPUT_LIGHTMAP_UV(v.texcoord1, unity_LightmapST, o.lightmapUVOrVertexSH.xy);
        	    OUTPUT_SH(lwWNormal, o.lightmapUVOrVertexSH.xyz);

        	    half3 vertexLight = VertexLighting(vertexInput.positionWS, lwWNormal);
        	    half fogFactor = ComputeFogFactor(vertexInput.positionCS.z);
        	    o.fogFactorAndVertexLight = half4(fogFactor, vertexLight);
        	    o.clipPos = vertexInput.positionCS;

        	#ifdef _MAIN_LIGHT_SHADOWS
        		o.shadowCoord = GetShadowCoord(vertexInput);
        	#endif
			#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
    o.shadowCoord = GetShadowCoord(vertexInput);
#endif
        		return o;
        	}

        	half4 frag (GraphVertexOutput IN  ) : SV_Target
            {
            	UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(IN);

        		float3 WorldSpaceNormal = normalize(float3(IN.tSpace0.z,IN.tSpace1.z,IN.tSpace2.z));
				float3 WorldSpaceTangent = float3(IN.tSpace0.x,IN.tSpace1.x,IN.tSpace2.x);
				float3 WorldSpaceBiTangent = float3(IN.tSpace0.y,IN.tSpace1.y,IN.tSpace2.y);
				float3 WorldSpacePosition = float3(IN.tSpace0.w,IN.tSpace1.w,IN.tSpace2.w);
				InitializeInputData(IN.ase_texcoord7.xy, WorldSpaceNormal, WorldSpaceTangent, WorldSpaceBiTangent);
				float3 WorldSpaceViewDirection = SafeNormalize( _WorldSpaceCameraPos.xyz  - WorldSpacePosition );
    
				float3 break6201 = abs( ( WorldSpacePosition - _WorldSpaceCameraPos ) );
				float clampResult297 = clamp( pow( ( max( max( break6201.x , break6201.y ) , break6201.z ) / _UV_Mix_Start_Distance ) , _UV_Mix_Power ) , 0.0 , 1.0 );
				half UVmixDistance636 = clampResult297;
				float lerpResult6230 = lerp( _Global_Color_Map_Close_Power , _Global_Color_Map_Far_Power , UVmixDistance636);
				float2 uv02588 = IN.ase_texcoord7.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode6204 = tex2D( _Global_Color_Map, ( _Global_Color_Map_Offset + ( _Global_Color_Map_Scale * uv02588 ) ) );
				float clampResult6326 = clamp( ( tex2DNode6204.a + ( 1.0 - _Global_Color_Opacity_Power ) ) , 0.0 , 1.0 );
				float2 appendResult6241 = (float2(1.0 , ( lerpResult6230 * clampResult6326 )));
				float4 tex2DNode4371 = tex2D( _Texture_Splat_4, uv02588 );
				float4 tex2DNode4370 = tex2D( _Texture_Splat_3, uv02588 );
				float4 tex2DNode4369 = tex2D( _Texture_Splat_2, uv02588 );
				float4 tex2DNode4368 = tex2D( _Texture_Splat_1, uv02588 );
				float3 break6329 = WorldSpacePosition;
				float2 appendResult6267 = (float2(break6329.x , break6329.z));
				half2 Top_Bottom1999 = appendResult6267;
				float temp_output_3830_0 = ( 1.0 / _Texture_1_Tiling );
				float2 appendResult3284 = (float2(temp_output_3830_0 , temp_output_3830_0));
				float2 temp_output_3275_0 = ( Top_Bottom1999 * appendResult3284 );
				float4 texArray3292 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3275_0, _Texture_1_Albedo_Index );
				float4 texArray3293 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3275_0 / _Texture_1_Far_Multiplier ), _Texture_1_Albedo_Index );
				float4 lerpResult5739 = lerp( texArray3292 , texArray3293 , UVmixDistance636);
				float3 clampResult5488 = clamp( pow( ( WorldSpaceNormal * WorldSpaceNormal ) , 25.0 ) , float3( -1,-1,-1 ) , float3( 1,1,1 ) );
				half3 BlendComponents91 = clampResult5488;
				float2 appendResult6265 = (float2(break6329.z , break6329.y));
				half2 Front_Back1991 = appendResult6265;
				float2 temp_output_3279_0 = ( Front_Back1991 * appendResult3284 );
				float4 texArray3287 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3279_0, _Texture_1_Albedo_Index );
				float2 appendResult6266 = (float2(break6329.x , break6329.y));
				half2 Left_Right2003 = appendResult6266;
				float2 temp_output_3277_0 = ( Left_Right2003 * appendResult3284 );
				float4 texArray3294 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3277_0, _Texture_1_Albedo_Index );
				float3 weightedBlendVar5674 = BlendComponents91;
				float4 weightedAvg5674 = ( ( weightedBlendVar5674.x*texArray3287 + weightedBlendVar5674.y*texArray3292 + weightedBlendVar5674.z*texArray3294 )/( weightedBlendVar5674.x + weightedBlendVar5674.y + weightedBlendVar5674.z ) );
				float4 texArray3291 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3279_0 / _Texture_1_Far_Multiplier ), _Texture_1_Albedo_Index );
				float4 texArray3295 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3277_0 / _Texture_1_Far_Multiplier ), _Texture_1_Albedo_Index );
				float3 weightedBlendVar5675 = BlendComponents91;
				float4 weightedAvg5675 = ( ( weightedBlendVar5675.x*texArray3291 + weightedBlendVar5675.y*texArray3293 + weightedBlendVar5675.z*texArray3295 )/( weightedBlendVar5675.x + weightedBlendVar5675.y + weightedBlendVar5675.z ) );
				float4 lerpResult1767 = lerp( weightedAvg5674 , weightedAvg5675 , UVmixDistance636);
				float4 ifLocalVar5782 = 0;
				UNITY_BRANCH 
				if( _Texture_1_Triplanar == 1.0 )
				ifLocalVar5782 = lerpResult1767;
				else
				ifLocalVar5782 = lerpResult5739;
				float4 ifLocalVar6174 = 0;
				UNITY_BRANCH 
				if( _Texture_1_Albedo_Index > -1.0 )
				ifLocalVar6174 = ( ifLocalVar5782 * _Texture_1_Color );
				half4 Texture_1_Final950 = ifLocalVar6174;
				float temp_output_3831_0 = ( 1.0 / _Texture_2_Tiling );
				float2 appendResult3349 = (float2(temp_output_3831_0 , temp_output_3831_0));
				float2 temp_output_3343_0 = ( Top_Bottom1999 * appendResult3349 );
				float4 texArray3338 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3343_0, _Texture_2_Albedo_Index );
				float4 texArray3339 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3343_0 / _Texture_2_Far_Multiplier ), _Texture_2_Albedo_Index );
				float4 lerpResult5749 = lerp( texArray3338 , texArray3339 , UVmixDistance636);
				float2 temp_output_3344_0 = ( Front_Back1991 * appendResult3349 );
				float4 texArray3355 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3344_0, _Texture_2_Albedo_Index );
				float2 temp_output_3379_0 = ( Left_Right2003 * appendResult3349 );
				float4 texArray3341 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3379_0, _Texture_2_Albedo_Index );
				float3 weightedBlendVar5496 = BlendComponents91;
				float4 weightedAvg5496 = ( ( weightedBlendVar5496.x*texArray3355 + weightedBlendVar5496.y*texArray3338 + weightedBlendVar5496.z*texArray3341 )/( weightedBlendVar5496.x + weightedBlendVar5496.y + weightedBlendVar5496.z ) );
				float4 texArray3356 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3344_0 / _Texture_2_Far_Multiplier ), _Texture_2_Albedo_Index );
				float4 texArray3342 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3379_0 / _Texture_2_Far_Multiplier ), _Texture_2_Albedo_Index );
				float3 weightedBlendVar5497 = BlendComponents91;
				float4 weightedAvg5497 = ( ( weightedBlendVar5497.x*texArray3356 + weightedBlendVar5497.y*texArray3339 + weightedBlendVar5497.z*texArray3342 )/( weightedBlendVar5497.x + weightedBlendVar5497.y + weightedBlendVar5497.z ) );
				float4 lerpResult3333 = lerp( weightedAvg5496 , weightedAvg5497 , UVmixDistance636);
				float4 ifLocalVar5771 = 0;
				UNITY_BRANCH 
				if( _Texture_2_Triplanar == 1.0 )
				ifLocalVar5771 = lerpResult3333;
				else
				ifLocalVar5771 = lerpResult5749;
				float4 ifLocalVar6128 = 0;
				UNITY_BRANCH 
				if( _Texture_2_Albedo_Index > -1.0 )
				ifLocalVar6128 = ( ifLocalVar5771 * _Texture_2_Color );
				half4 Texture_2_Final3385 = ifLocalVar6128;
				float temp_output_3832_0 = ( 1.0 / _Texture_3_Tiling );
				float2 appendResult3415 = (float2(temp_output_3832_0 , temp_output_3832_0));
				float2 temp_output_3410_0 = ( Top_Bottom1999 * appendResult3415 );
				float4 texArray3405 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3410_0, _Texture_3_Albedo_Index );
				float4 texArray3406 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3410_0 / _Texture_3_Far_Multiplier ), _Texture_3_Albedo_Index );
				float4 lerpResult5759 = lerp( texArray3405 , texArray3406 , UVmixDistance636);
				float2 temp_output_3411_0 = ( Front_Back1991 * appendResult3415 );
				float4 texArray3419 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3411_0, _Texture_3_Albedo_Index );
				float2 temp_output_3441_0 = ( Left_Right2003 * appendResult3415 );
				float4 texArray3408 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3441_0, _Texture_3_Albedo_Index );
				float3 weightedBlendVar5500 = BlendComponents91;
				float4 weightedAvg5500 = ( ( weightedBlendVar5500.x*texArray3419 + weightedBlendVar5500.y*texArray3405 + weightedBlendVar5500.z*texArray3408 )/( weightedBlendVar5500.x + weightedBlendVar5500.y + weightedBlendVar5500.z ) );
				float2 temp_output_3413_0 = ( temp_output_3411_0 / _Texture_3_Far_Multiplier );
				float4 texArray3420 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3413_0, _Texture_3_Albedo_Index );
				float4 texArray3409 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3441_0 / _Texture_3_Far_Multiplier ), _Texture_3_Albedo_Index );
				float3 weightedBlendVar5501 = BlendComponents91;
				float4 weightedAvg5501 = ( ( weightedBlendVar5501.x*texArray3420 + weightedBlendVar5501.y*texArray3406 + weightedBlendVar5501.z*texArray3409 )/( weightedBlendVar5501.x + weightedBlendVar5501.y + weightedBlendVar5501.z ) );
				float4 lerpResult3400 = lerp( weightedAvg5500 , weightedAvg5501 , UVmixDistance636);
				float4 ifLocalVar5775 = 0;
				UNITY_BRANCH 
				if( _Texture_3_Triplanar == 1.0 )
				ifLocalVar5775 = lerpResult3400;
				else
				ifLocalVar5775 = lerpResult5759;
				float4 ifLocalVar6130 = 0;
				UNITY_BRANCH 
				if( _Texture_3_Albedo_Index > -1.0 )
				ifLocalVar6130 = ( ifLocalVar5775 * _Texture_3_Color );
				half4 Texture_3_Final3451 = ifLocalVar6130;
				float temp_output_3833_0 = ( 1.0 / _Texture_4_Tiling );
				float2 temp_output_3477_0 = ( Top_Bottom1999 * temp_output_3833_0 );
				float4 texArray3472 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3477_0, _Texture_4_Albedo_Index );
				float4 texArray3473 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3477_0 / _Texture_4_Far_Multiplier ), _Texture_4_Albedo_Index );
				float4 lerpResult5761 = lerp( texArray3472 , texArray3473 , UVmixDistance636);
				float2 temp_output_3478_0 = ( Front_Back1991 * temp_output_3833_0 );
				float4 texArray3486 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3478_0, _Texture_4_Albedo_Index );
				float2 temp_output_3508_0 = ( Left_Right2003 * temp_output_3833_0 );
				float4 texArray3475 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3508_0, _Texture_4_Albedo_Index );
				float3 weightedBlendVar5504 = BlendComponents91;
				float4 weightedAvg5504 = ( ( weightedBlendVar5504.x*texArray3486 + weightedBlendVar5504.y*texArray3472 + weightedBlendVar5504.z*texArray3475 )/( weightedBlendVar5504.x + weightedBlendVar5504.y + weightedBlendVar5504.z ) );
				float4 texArray3487 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3478_0 / _Texture_4_Far_Multiplier ), _Texture_4_Albedo_Index );
				float4 texArray3476 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3508_0 / _Texture_4_Far_Multiplier ), _Texture_4_Albedo_Index );
				float3 weightedBlendVar5505 = BlendComponents91;
				float4 weightedAvg5505 = ( ( weightedBlendVar5505.x*texArray3487 + weightedBlendVar5505.y*texArray3473 + weightedBlendVar5505.z*texArray3476 )/( weightedBlendVar5505.x + weightedBlendVar5505.y + weightedBlendVar5505.z ) );
				float4 lerpResult3467 = lerp( weightedAvg5504 , weightedAvg5505 , UVmixDistance636);
				float4 ifLocalVar5777 = 0;
				UNITY_BRANCH 
				if( _Texture_4_Triplanar == 1.0 )
				ifLocalVar5777 = lerpResult3467;
				else
				ifLocalVar5777 = lerpResult5761;
				float4 ifLocalVar6132 = 0;
				UNITY_BRANCH 
				if( _Texture_4_Albedo_Index > -1.0 )
				ifLocalVar6132 = ( ifLocalVar5777 * _Texture_4_Color );
				half4 Texture_4_Final3518 = ifLocalVar6132;
				float4 layeredBlendVar5643 = tex2DNode4368;
				float4 layeredBlend5643 = ( lerp( lerp( lerp( lerp( float4( 0,0,0,0 ) , Texture_1_Final950 , layeredBlendVar5643.x ) , Texture_2_Final3385 , layeredBlendVar5643.y ) , Texture_3_Final3451 , layeredBlendVar5643.z ) , Texture_4_Final3518 , layeredBlendVar5643.w ) );
				float temp_output_4397_0 = ( 1.0 / _Texture_5_Tiling );
				float2 appendResult4399 = (float2(temp_output_4397_0 , temp_output_4397_0));
				float2 temp_output_4416_0 = ( Top_Bottom1999 * appendResult4399 );
				float4 texArray4450 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4416_0, _Texture_5_Albedo_Index );
				float4 texArray4445 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4416_0 / _Texture_5_Far_Multiplier ), _Texture_5_Albedo_Index );
				float4 lerpResult5789 = lerp( texArray4450 , texArray4445 , UVmixDistance636);
				float2 temp_output_4400_0 = ( Front_Back1991 * appendResult4399 );
				float4 texArray4442 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4400_0, _Texture_5_Albedo_Index );
				float2 temp_output_4413_0 = ( Left_Right2003 * appendResult4399 );
				float4 texArray4443 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4413_0, _Texture_5_Albedo_Index );
				float3 weightedBlendVar5512 = BlendComponents91;
				float4 weightedAvg5512 = ( ( weightedBlendVar5512.x*texArray4442 + weightedBlendVar5512.y*texArray4450 + weightedBlendVar5512.z*texArray4443 )/( weightedBlendVar5512.x + weightedBlendVar5512.y + weightedBlendVar5512.z ) );
				float4 texArray4444 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4400_0 / _Texture_5_Far_Multiplier ), _Texture_5_Albedo_Index );
				float4 texArray4439 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4413_0 / _Texture_5_Far_Multiplier ), _Texture_5_Albedo_Index );
				float3 weightedBlendVar5514 = BlendComponents91;
				float4 weightedAvg5514 = ( ( weightedBlendVar5514.x*texArray4444 + weightedBlendVar5514.y*texArray4445 + weightedBlendVar5514.z*texArray4439 )/( weightedBlendVar5514.x + weightedBlendVar5514.y + weightedBlendVar5514.z ) );
				float4 lerpResult4466 = lerp( weightedAvg5512 , weightedAvg5514 , UVmixDistance636);
				float4 ifLocalVar5804 = 0;
				UNITY_BRANCH 
				if( _Texture_5_Triplanar == 1.0 )
				ifLocalVar5804 = lerpResult4466;
				else
				ifLocalVar5804 = lerpResult5789;
				float4 ifLocalVar6134 = 0;
				UNITY_BRANCH 
				if( _Texture_5_Albedo_Index > -1.0 )
				ifLocalVar6134 = ( ifLocalVar5804 * _Texture_5_Color );
				half4 Texture_5_Final4396 = ifLocalVar6134;
				float temp_output_4469_0 = ( 1.0 / _Texture_6_Tiling );
				float2 appendResult4471 = (float2(temp_output_4469_0 , temp_output_4469_0));
				float2 temp_output_4485_0 = ( Top_Bottom1999 * appendResult4471 );
				float4 texArray4517 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4485_0, _Texture_6_Albedo_Index );
				float4 texArray4512 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4485_0 / _Texture_6_Far_Multiplier ), _Texture_6_Albedo_Index );
				float4 lerpResult5794 = lerp( texArray4517 , texArray4512 , UVmixDistance636);
				float2 temp_output_4472_0 = ( Front_Back1991 * appendResult4471 );
				float4 texArray4509 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4472_0, _Texture_6_Albedo_Index );
				float2 temp_output_4483_0 = ( Left_Right2003 * appendResult4471 );
				float4 texArray4510 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4483_0, _Texture_6_Albedo_Index );
				float3 weightedBlendVar5520 = BlendComponents91;
				float4 weightedAvg5520 = ( ( weightedBlendVar5520.x*texArray4509 + weightedBlendVar5520.y*texArray4517 + weightedBlendVar5520.z*texArray4510 )/( weightedBlendVar5520.x + weightedBlendVar5520.y + weightedBlendVar5520.z ) );
				float4 texArray4511 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4472_0 / _Texture_6_Far_Multiplier ), _Texture_6_Albedo_Index );
				float4 texArray4506 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4483_0 / _Texture_6_Far_Multiplier ), _Texture_6_Albedo_Index );
				float3 weightedBlendVar5522 = BlendComponents91;
				float4 weightedAvg5522 = ( ( weightedBlendVar5522.x*texArray4511 + weightedBlendVar5522.y*texArray4512 + weightedBlendVar5522.z*texArray4506 )/( weightedBlendVar5522.x + weightedBlendVar5522.y + weightedBlendVar5522.z ) );
				float4 lerpResult4532 = lerp( weightedAvg5520 , weightedAvg5522 , UVmixDistance636);
				float4 ifLocalVar5809 = 0;
				UNITY_BRANCH 
				if( _Texture_6_Triplanar == 1.0 )
				ifLocalVar5809 = lerpResult4532;
				else
				ifLocalVar5809 = lerpResult5794;
				float4 ifLocalVar6136 = 0;
				UNITY_BRANCH 
				if( _Texture_6_Albedo_Index > -1.0 )
				ifLocalVar6136 = ( ifLocalVar5809 * _Texture_6_Color );
				half4 Texture_6_Final4536 = ifLocalVar6136;
				float temp_output_4543_0 = ( 1.0 / _Texture_7_Tiling );
				float2 appendResult4545 = (float2(temp_output_4543_0 , temp_output_4543_0));
				float2 temp_output_4559_0 = ( Top_Bottom1999 * appendResult4545 );
				float4 texArray4591 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4559_0, _Texture_7_Albedo_Index );
				float4 texArray4586 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4559_0 / _Texture_7_Far_Multiplier ), _Texture_7_Albedo_Index );
				float4 lerpResult5798 = lerp( texArray4591 , texArray4586 , UVmixDistance636);
				float2 temp_output_4546_0 = ( Front_Back1991 * appendResult4545 );
				float4 texArray4583 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4546_0, _Texture_7_Albedo_Index );
				float2 temp_output_4557_0 = ( Left_Right2003 * appendResult4545 );
				float4 texArray4584 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4557_0, _Texture_7_Albedo_Index );
				float3 weightedBlendVar5524 = BlendComponents91;
				float4 weightedAvg5524 = ( ( weightedBlendVar5524.x*texArray4583 + weightedBlendVar5524.y*texArray4591 + weightedBlendVar5524.z*texArray4584 )/( weightedBlendVar5524.x + weightedBlendVar5524.y + weightedBlendVar5524.z ) );
				float4 texArray4585 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4546_0 / _Texture_7_Far_Multiplier ), _Texture_7_Albedo_Index );
				float4 texArray4580 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4557_0 / _Texture_7_Far_Multiplier ), _Texture_7_Albedo_Index );
				float3 weightedBlendVar5526 = BlendComponents91;
				float4 weightedAvg5526 = ( ( weightedBlendVar5526.x*texArray4585 + weightedBlendVar5526.y*texArray4586 + weightedBlendVar5526.z*texArray4580 )/( weightedBlendVar5526.x + weightedBlendVar5526.y + weightedBlendVar5526.z ) );
				float4 lerpResult4606 = lerp( weightedAvg5524 , weightedAvg5526 , UVmixDistance636);
				float4 ifLocalVar5812 = 0;
				UNITY_BRANCH 
				if( _Texture_7_Triplanar == 1.0 )
				ifLocalVar5812 = lerpResult4606;
				else
				ifLocalVar5812 = lerpResult5798;
				float4 ifLocalVar6139 = 0;
				UNITY_BRANCH 
				if( _Texture_7_Albedo_Index > -1.0 )
				ifLocalVar6139 = ( ifLocalVar5812 * _Texture_7_Color );
				half4 Texture_7_Final4614 = ifLocalVar6139;
				float temp_output_4617_0 = ( 1.0 / _Texture_8_Tiling );
				float2 appendResult4619 = (float2(temp_output_4617_0 , temp_output_4617_0));
				float2 temp_output_4633_0 = ( Top_Bottom1999 * appendResult4619 );
				float4 texArray4665 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4633_0, _Texture_8_Albedo_Index );
				float4 texArray4660 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4633_0 / _Texture_8_Far_Multiplier ), _Texture_8_Albedo_Index );
				float4 lerpResult5802 = lerp( texArray4665 , texArray4660 , UVmixDistance636);
				float2 temp_output_4620_0 = ( Front_Back1991 * appendResult4619 );
				float4 texArray4657 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4620_0, _Texture_8_Albedo_Index );
				float2 temp_output_4631_0 = ( Left_Right2003 * appendResult4619 );
				float4 texArray4658 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4631_0, _Texture_8_Albedo_Index );
				float3 weightedBlendVar5528 = BlendComponents91;
				float4 weightedAvg5528 = ( ( weightedBlendVar5528.x*texArray4657 + weightedBlendVar5528.y*texArray4665 + weightedBlendVar5528.z*texArray4658 )/( weightedBlendVar5528.x + weightedBlendVar5528.y + weightedBlendVar5528.z ) );
				float4 texArray4659 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4620_0 / _Texture_8_Far_Multiplier ), _Texture_8_Albedo_Index );
				float4 texArray4654 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4631_0 / _Texture_8_Far_Multiplier ), _Texture_8_Albedo_Index );
				float3 weightedBlendVar5530 = BlendComponents91;
				float4 weightedAvg5530 = ( ( weightedBlendVar5530.x*texArray4659 + weightedBlendVar5530.y*texArray4660 + weightedBlendVar5530.z*texArray4654 )/( weightedBlendVar5530.x + weightedBlendVar5530.y + weightedBlendVar5530.z ) );
				float4 lerpResult4680 = lerp( weightedAvg5528 , weightedAvg5530 , UVmixDistance636);
				float4 ifLocalVar5815 = 0;
				UNITY_BRANCH 
				if( _Texture_8_Triplanar == 1.0 )
				ifLocalVar5815 = lerpResult4680;
				else
				ifLocalVar5815 = lerpResult5802;
				float4 ifLocalVar6141 = 0;
				UNITY_BRANCH 
				if( _Texture_8_Albedo_Index > -1.0 )
				ifLocalVar6141 = ( ifLocalVar5815 * _Texture_8_Color );
				half4 Texture_8_Final4689 = ifLocalVar6141;
				float4 layeredBlendVar5644 = tex2DNode4369;
				float4 layeredBlend5644 = ( lerp( lerp( lerp( lerp( layeredBlend5643 , Texture_5_Final4396 , layeredBlendVar5644.x ) , Texture_6_Final4536 , layeredBlendVar5644.y ) , Texture_7_Final4614 , layeredBlendVar5644.z ) , Texture_8_Final4689 , layeredBlendVar5644.w ) );
				float temp_output_4703_0 = ( 1.0 / _Texture_9_Tiling );
				float2 appendResult4736 = (float2(temp_output_4703_0 , temp_output_4703_0));
				float2 temp_output_4712_0 = ( Top_Bottom1999 * appendResult4736 );
				float4 texArray4723 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4712_0, _Texture_9_Albedo_Index );
				float4 texArray4889 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4712_0 / _Texture_9_Far_Multiplier ), _Texture_9_Albedo_Index );
				float4 lerpResult5845 = lerp( texArray4723 , texArray4889 , UVmixDistance636);
				float2 temp_output_4706_0 = ( Front_Back1991 * appendResult4736 );
				float4 texArray5286 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4706_0, _Texture_9_Albedo_Index );
				float2 temp_output_4761_0 = ( Left_Right2003 * appendResult4736 );
				float4 texArray4858 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4761_0, _Texture_9_Albedo_Index );
				float3 weightedBlendVar5489 = BlendComponents91;
				float4 weightedAvg5489 = ( ( weightedBlendVar5489.x*texArray5286 + weightedBlendVar5489.y*texArray4723 + weightedBlendVar5489.z*texArray4858 )/( weightedBlendVar5489.x + weightedBlendVar5489.y + weightedBlendVar5489.z ) );
				float4 texArray4719 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4706_0 / _Texture_9_Far_Multiplier ), _Texture_9_Albedo_Index );
				float4 texArray4865 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4761_0 / _Texture_9_Far_Multiplier ), _Texture_9_Albedo_Index );
				float3 weightedBlendVar5490 = BlendComponents91;
				float4 weightedAvg5490 = ( ( weightedBlendVar5490.x*texArray4719 + weightedBlendVar5490.y*texArray4889 + weightedBlendVar5490.z*texArray4865 )/( weightedBlendVar5490.x + weightedBlendVar5490.y + weightedBlendVar5490.z ) );
				float4 lerpResult4976 = lerp( weightedAvg5489 , weightedAvg5490 , UVmixDistance636);
				float4 ifLocalVar5844 = 0;
				UNITY_BRANCH 
				if( _Texture_9_Triplanar == 1.0 )
				ifLocalVar5844 = lerpResult4976;
				else
				ifLocalVar5844 = lerpResult5845;
				float4 ifLocalVar6143 = 0;
				UNITY_BRANCH 
				if( _Texture_9_Albedo_Index > -1.0 )
				ifLocalVar6143 = ( ifLocalVar5844 * _Texture_9_Color );
				half4 Texture_9_Final4987 = ifLocalVar6143;
				float temp_output_4734_0 = ( 1.0 / _Texture_10_Tiling );
				float2 appendResult4738 = (float2(temp_output_4734_0 , temp_output_4734_0));
				float2 temp_output_4793_0 = ( Top_Bottom1999 * appendResult4738 );
				float4 texArray4899 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4793_0, _Texture_10_Albedo_Index );
				float4 texArray4913 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4793_0 / _Texture_10_Far_Multiplier ), _Texture_10_Albedo_Index );
				float4 lerpResult5841 = lerp( texArray4899 , texArray4913 , UVmixDistance636);
				float2 temp_output_4742_0 = ( Front_Back1991 * appendResult4738 );
				float4 texArray4886 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4742_0, _Texture_10_Albedo_Index );
				float2 temp_output_4785_0 = ( Left_Right2003 * appendResult4738 );
				float4 texArray4877 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4785_0, _Texture_10_Albedo_Index );
				float3 weightedBlendVar5532 = BlendComponents91;
				float4 weightedAvg5532 = ( ( weightedBlendVar5532.x*texArray4886 + weightedBlendVar5532.y*texArray4899 + weightedBlendVar5532.z*texArray4877 )/( weightedBlendVar5532.x + weightedBlendVar5532.y + weightedBlendVar5532.z ) );
				float4 texArray4894 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4742_0 / _Texture_10_Far_Multiplier ), _Texture_10_Albedo_Index );
				float4 texArray4878 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4785_0 / _Texture_10_Far_Multiplier ), _Texture_10_Albedo_Index );
				float3 weightedBlendVar5534 = BlendComponents91;
				float4 weightedAvg5534 = ( ( weightedBlendVar5534.x*texArray4894 + weightedBlendVar5534.y*texArray4913 + weightedBlendVar5534.z*texArray4878 )/( weightedBlendVar5534.x + weightedBlendVar5534.y + weightedBlendVar5534.z ) );
				float4 lerpResult4983 = lerp( weightedAvg5532 , weightedAvg5534 , UVmixDistance636);
				float4 ifLocalVar5840 = 0;
				UNITY_BRANCH 
				if( _Texture_10_Triplanar == 1.0 )
				ifLocalVar5840 = lerpResult4983;
				else
				ifLocalVar5840 = lerpResult5841;
				float4 ifLocalVar6145 = 0;
				UNITY_BRANCH 
				if( _Texture_10_Albedo_Index > -1.0 )
				ifLocalVar6145 = ( ifLocalVar5840 * _Texture_10_Color );
				half4 Texture_10_Final4994 = ifLocalVar6145;
				float temp_output_4739_0 = ( 1.0 / _Texture_11_Tiling );
				float2 appendResult4741 = (float2(temp_output_4739_0 , temp_output_4739_0));
				float2 temp_output_4817_0 = ( Top_Bottom1999 * appendResult4741 );
				float4 texArray4928 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4817_0, _Texture_11_Albedo_Index );
				float4 texArray4923 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4817_0 / _Texture_11_Far_Multiplier ), _Texture_11_Albedo_Index );
				float4 lerpResult5837 = lerp( texArray4928 , texArray4923 , UVmixDistance636);
				float2 temp_output_4748_0 = ( Front_Back1991 * appendResult4741 );
				float4 texArray4917 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4748_0, _Texture_11_Albedo_Index );
				float2 temp_output_4795_0 = ( Left_Right2003 * appendResult4741 );
				float4 texArray4911 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4795_0, _Texture_11_Albedo_Index );
				float3 weightedBlendVar5536 = BlendComponents91;
				float4 weightedAvg5536 = ( ( weightedBlendVar5536.x*texArray4917 + weightedBlendVar5536.y*texArray4928 + weightedBlendVar5536.z*texArray4911 )/( weightedBlendVar5536.x + weightedBlendVar5536.y + weightedBlendVar5536.z ) );
				float4 texArray4898 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4748_0 / _Texture_11_Far_Multiplier ), _Texture_11_Albedo_Index );
				float4 texArray4914 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4795_0 / _Texture_11_Far_Multiplier ), _Texture_11_Albedo_Index );
				float3 weightedBlendVar5538 = BlendComponents91;
				float4 weightedAvg5538 = ( ( weightedBlendVar5538.x*texArray4898 + weightedBlendVar5538.y*texArray4923 + weightedBlendVar5538.z*texArray4914 )/( weightedBlendVar5538.x + weightedBlendVar5538.y + weightedBlendVar5538.z ) );
				float4 lerpResult4988 = lerp( weightedAvg5536 , weightedAvg5538 , UVmixDistance636);
				float4 ifLocalVar5836 = 0;
				UNITY_BRANCH 
				if( _Texture_11_Triplanar == 1.0 )
				ifLocalVar5836 = lerpResult4988;
				else
				ifLocalVar5836 = lerpResult5837;
				float4 ifLocalVar6147 = 0;
				UNITY_BRANCH 
				if( _Texture_11_Albedo_Index > -1.0 )
				ifLocalVar6147 = ( ifLocalVar5836 * _Texture_11_Color );
				half4 Texture_11_Final4996 = ifLocalVar6147;
				float temp_output_4745_0 = ( 1.0 / _Texture_12_Tiling );
				float2 appendResult4751 = (float2(temp_output_4745_0 , temp_output_4745_0));
				float2 temp_output_4849_0 = ( Top_Bottom1999 * appendResult4751 );
				float4 texArray4954 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4849_0, _Texture_12_Albedo_Index );
				float4 texArray4952 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4849_0 / _Texture_12_Far_Multiplier ), _Texture_12_Albedo_Index );
				float4 lerpResult5833 = lerp( texArray4954 , texArray4952 , UVmixDistance636);
				float2 temp_output_4758_0 = ( Front_Back1991 * appendResult4751 );
				float4 texArray4926 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4758_0, _Texture_12_Albedo_Index );
				float2 temp_output_4830_0 = ( Left_Right2003 * appendResult4751 );
				float4 texArray4927 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4830_0, _Texture_12_Albedo_Index );
				float3 weightedBlendVar5540 = BlendComponents91;
				float4 weightedAvg5540 = ( ( weightedBlendVar5540.x*texArray4926 + weightedBlendVar5540.y*texArray4954 + weightedBlendVar5540.z*texArray4927 )/( weightedBlendVar5540.x + weightedBlendVar5540.y + weightedBlendVar5540.z ) );
				float4 texArray4919 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4758_0 / _Texture_12_Far_Multiplier ), _Texture_12_Albedo_Index );
				float4 texArray4931 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4830_0 / _Texture_12_Far_Multiplier ), _Texture_12_Albedo_Index );
				float3 weightedBlendVar5542 = BlendComponents91;
				float4 weightedAvg5542 = ( ( weightedBlendVar5542.x*texArray4919 + weightedBlendVar5542.y*texArray4952 + weightedBlendVar5542.z*texArray4931 )/( weightedBlendVar5542.x + weightedBlendVar5542.y + weightedBlendVar5542.z ) );
				float4 lerpResult4993 = lerp( weightedAvg5540 , weightedAvg5542 , UVmixDistance636);
				float4 ifLocalVar5832 = 0;
				UNITY_BRANCH 
				if( _Texture_12_Triplanar == 1.0 )
				ifLocalVar5832 = lerpResult4993;
				else
				ifLocalVar5832 = lerpResult5833;
				float4 ifLocalVar6169 = 0;
				UNITY_BRANCH 
				if( _Texture_12_Albedo_Index > -1.0 )
				ifLocalVar6169 = ( ifLocalVar5832 * _Texture_12_Color );
				half4 Texture_12_Final4997 = ifLocalVar6169;
				float4 layeredBlendVar5645 = tex2DNode4370;
				float4 layeredBlend5645 = ( lerp( lerp( lerp( lerp( layeredBlend5644 , Texture_9_Final4987 , layeredBlendVar5645.x ) , Texture_10_Final4994 , layeredBlendVar5645.y ) , Texture_11_Final4996 , layeredBlendVar5645.z ) , Texture_12_Final4997 , layeredBlendVar5645.w ) );
				float temp_output_5125_0 = ( 1.0 / _Texture_13_Tiling );
				float2 appendResult5027 = (float2(temp_output_5125_0 , temp_output_5125_0));
				float2 temp_output_5037_0 = ( Top_Bottom1999 * appendResult5027 );
				float4 texArray5043 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5037_0, _Texture_13_Albedo_Index );
				float4 texArray5034 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5037_0 / _Texture_13_Far_Multiplier ), _Texture_13_Albedo_Index );
				float4 lerpResult5829 = lerp( texArray5043 , texArray5034 , UVmixDistance636);
				float2 temp_output_5025_0 = ( Front_Back1991 * appendResult5027 );
				float4 texArray5128 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5025_0, _Texture_13_Albedo_Index );
				float2 temp_output_5035_0 = ( Left_Right2003 * appendResult5027 );
				float4 texArray5129 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5035_0, _Texture_13_Albedo_Index );
				float3 weightedBlendVar5544 = BlendComponents91;
				float4 weightedAvg5544 = ( ( weightedBlendVar5544.x*texArray5128 + weightedBlendVar5544.y*texArray5043 + weightedBlendVar5544.z*texArray5129 )/( weightedBlendVar5544.x + weightedBlendVar5544.y + weightedBlendVar5544.z ) );
				float4 texArray5130 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5025_0 / _Texture_13_Far_Multiplier ), _Texture_13_Albedo_Index );
				float4 texArray5121 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5035_0 / _Texture_13_Far_Multiplier ), _Texture_13_Albedo_Index );
				float3 weightedBlendVar5546 = BlendComponents91;
				float4 weightedAvg5546 = ( ( weightedBlendVar5546.x*texArray5130 + weightedBlendVar5546.y*texArray5034 + weightedBlendVar5546.z*texArray5121 )/( weightedBlendVar5546.x + weightedBlendVar5546.y + weightedBlendVar5546.z ) );
				float4 lerpResult5054 = lerp( weightedAvg5544 , weightedAvg5546 , UVmixDistance636);
				float4 ifLocalVar5828 = 0;
				UNITY_BRANCH 
				if( _Texture_13_Triplanar == 1.0 )
				ifLocalVar5828 = lerpResult5054;
				else
				ifLocalVar5828 = lerpResult5829;
				float4 ifLocalVar6151 = 0;
				UNITY_BRANCH 
				if( _Texture_13_Albedo_Index > -1.0 )
				ifLocalVar6151 = ( ifLocalVar5828 * _Texture_13_Color );
				half4 Texture_13_Final5058 = ifLocalVar6151;
				float temp_output_5006_0 = ( 1.0 / _Texture_14_Tiling );
				float2 appendResult5033 = (float2(temp_output_5006_0 , temp_output_5006_0));
				float2 temp_output_5022_0 = ( Top_Bottom1999 * appendResult5033 );
				float4 texArray5202 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5022_0, _Texture_14_Albedo_Index );
				float4 texArray5171 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5022_0 / _Texture_14_Far_Multiplier ), _Texture_14_Albedo_Index );
				float4 lerpResult5825 = lerp( texArray5202 , texArray5171 , UVmixDistance636);
				float2 temp_output_5009_0 = ( Front_Back1991 * appendResult5033 );
				float4 texArray5168 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5009_0, _Texture_14_Albedo_Index );
				float2 temp_output_5010_0 = ( Left_Right2003 * appendResult5033 );
				float4 texArray5239 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5010_0, _Texture_14_Albedo_Index );
				float3 weightedBlendVar5548 = BlendComponents91;
				float4 weightedAvg5548 = ( ( weightedBlendVar5548.x*texArray5168 + weightedBlendVar5548.y*texArray5202 + weightedBlendVar5548.z*texArray5239 )/( weightedBlendVar5548.x + weightedBlendVar5548.y + weightedBlendVar5548.z ) );
				float4 texArray5205 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5009_0 / _Texture_14_Far_Multiplier ), _Texture_14_Albedo_Index );
				float4 texArray5241 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5010_0 / _Texture_14_Far_Multiplier ), _Texture_14_Albedo_Index );
				float3 weightedBlendVar5550 = BlendComponents91;
				float4 weightedAvg5550 = ( ( weightedBlendVar5550.x*texArray5205 + weightedBlendVar5550.y*texArray5171 + weightedBlendVar5550.z*texArray5241 )/( weightedBlendVar5550.x + weightedBlendVar5550.y + weightedBlendVar5550.z ) );
				float4 lerpResult5197 = lerp( weightedAvg5548 , weightedAvg5550 , UVmixDistance636);
				float4 ifLocalVar5824 = 0;
				UNITY_BRANCH 
				if( _Texture_14_Triplanar == 1.0 )
				ifLocalVar5824 = lerpResult5197;
				else
				ifLocalVar5824 = lerpResult5825;
				float4 ifLocalVar6153 = 0;
				UNITY_BRANCH 
				if( _Texture_14_Albedo_Index > -1.0 )
				ifLocalVar6153 = ( ifLocalVar5824 * _Texture_14_Color );
				half4 Texture_14_Final5163 = ifLocalVar6153;
				float temp_output_5210_0 = ( 1.0 / _Texture_15_Tiling );
				float2 appendResult5212 = (float2(temp_output_5210_0 , temp_output_5210_0));
				float2 temp_output_5226_0 = ( Top_Bottom1999 * appendResult5212 );
				float4 texArray5259 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5226_0, _Texture_15_Albedo_Index );
				float4 texArray5272 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5226_0 / _Texture_15_Far_Multiplier ), _Texture_15_Albedo_Index );
				float4 lerpResult5821 = lerp( texArray5259 , texArray5272 , UVmixDistance636);
				float2 temp_output_5213_0 = ( Front_Back1991 * appendResult5212 );
				float4 texArray5182 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5213_0, _Texture_15_Albedo_Index );
				float2 temp_output_5224_0 = ( Left_Right2003 * appendResult5212 );
				float4 texArray5189 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5224_0, _Texture_15_Albedo_Index );
				float3 weightedBlendVar5552 = BlendComponents91;
				float4 weightedAvg5552 = ( ( weightedBlendVar5552.x*texArray5182 + weightedBlendVar5552.y*texArray5259 + weightedBlendVar5552.z*texArray5189 )/( weightedBlendVar5552.x + weightedBlendVar5552.y + weightedBlendVar5552.z ) );
				float4 texArray5188 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5213_0 / _Texture_15_Far_Multiplier ), _Texture_15_Albedo_Index );
				float4 texArray5247 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5224_0 / _Texture_15_Far_Multiplier ), _Texture_15_Albedo_Index );
				float3 weightedBlendVar5554 = BlendComponents91;
				float4 weightedAvg5554 = ( ( weightedBlendVar5554.x*texArray5188 + weightedBlendVar5554.y*texArray5272 + weightedBlendVar5554.z*texArray5247 )/( weightedBlendVar5554.x + weightedBlendVar5554.y + weightedBlendVar5554.z ) );
				float4 lerpResult5279 = lerp( weightedAvg5552 , weightedAvg5554 , UVmixDistance636);
				float4 ifLocalVar5820 = 0;
				UNITY_BRANCH 
				if( _Texture_15_Triplanar == 1.0 )
				ifLocalVar5820 = lerpResult5279;
				else
				ifLocalVar5820 = lerpResult5821;
				float4 ifLocalVar6155 = 0;
				UNITY_BRANCH 
				if( _Texture_15_Albedo_Index > -1.0 )
				ifLocalVar6155 = ( ifLocalVar5820 * _Texture_15_Color );
				half4 Texture_15_Final5270 = ifLocalVar6155;
				float temp_output_5075_0 = ( 1.0 / _Texture_16_Tiling );
				float2 appendResult5078 = (float2(temp_output_5075_0 , temp_output_5075_0));
				float2 temp_output_5083_0 = ( Top_Bottom1999 * appendResult5078 );
				float4 texArray5139 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5083_0, _Texture_16_Albedo_Index );
				float4 texArray5143 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5083_0 / _Texture_16_Far_Multiplier ), _Texture_16_Albedo_Index );
				float4 lerpResult5817 = lerp( texArray5139 , texArray5143 , UVmixDistance636);
				float2 temp_output_5079_0 = ( Front_Back1991 * appendResult5078 );
				float4 texArray5150 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5079_0, _Texture_16_Albedo_Index );
				float2 temp_output_5085_0 = ( Left_Right2003 * appendResult5078 );
				float4 texArray5145 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5085_0, _Texture_16_Albedo_Index );
				float3 weightedBlendVar5556 = BlendComponents91;
				float4 weightedAvg5556 = ( ( weightedBlendVar5556.x*texArray5150 + weightedBlendVar5556.y*texArray5139 + weightedBlendVar5556.z*texArray5145 )/( weightedBlendVar5556.x + weightedBlendVar5556.y + weightedBlendVar5556.z ) );
				float4 texArray5144 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5079_0 / _Texture_16_Far_Multiplier ), _Texture_16_Albedo_Index );
				float4 texArray5154 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5085_0 / _Texture_16_Far_Multiplier ), _Texture_16_Albedo_Index );
				float3 weightedBlendVar5558 = BlendComponents91;
				float4 weightedAvg5558 = ( ( weightedBlendVar5558.x*texArray5144 + weightedBlendVar5558.y*texArray5143 + weightedBlendVar5558.z*texArray5154 )/( weightedBlendVar5558.x + weightedBlendVar5558.y + weightedBlendVar5558.z ) );
				float4 lerpResult5104 = lerp( weightedAvg5556 , weightedAvg5558 , UVmixDistance636);
				float4 ifLocalVar5816 = 0;
				UNITY_BRANCH 
				if( _Texture_16_Triplanar == 1.0 )
				ifLocalVar5816 = lerpResult5104;
				else
				ifLocalVar5816 = lerpResult5817;
				float4 ifLocalVar6183 = 0;
				UNITY_BRANCH 
				if( _Texture_16_Albedo_Index > -1.0 )
				ifLocalVar6183 = ( ifLocalVar5816 * _Texture_16_Color );
				half4 Texture_16_Final5094 = ifLocalVar6183;
				float4 layeredBlendVar5646 = tex2DNode4371;
				float4 layeredBlend5646 = ( lerp( lerp( lerp( lerp( layeredBlend5645 , Texture_13_Final5058 , layeredBlendVar5646.x ) , Texture_14_Final5163 , layeredBlendVar5646.y ) , Texture_15_Final5270 , layeredBlendVar5646.z ) , Texture_16_Final5094 , layeredBlendVar5646.w ) );
				float4 break3856 = layeredBlend5646;
				float3 appendResult3857 = (float3(break3856.x , break3856.y , break3856.z));
				float3 appendResult6206 = (float3(tex2DNode6204.r , tex2DNode6204.g , tex2DNode6204.b));
				float2 weightedBlendVar6240 = appendResult6241;
				float3 weightedAvg6240 = ( ( weightedBlendVar6240.x*appendResult3857 + weightedBlendVar6240.y*appendResult6206 )/( weightedBlendVar6240.x + weightedBlendVar6240.y ) );
				float2 temp_cast_0 = (( _Geological_Map_Offset_Close + ( WorldSpacePosition.y / _Geological_Tiling_Close ) )).xx;
				float4 tex2DNode5984 = tex2D( _Texture_Geological_Map, temp_cast_0 );
				float3 appendResult5986 = (float3(tex2DNode5984.r , tex2DNode5984.g , tex2DNode5984.b));
				float2 temp_cast_1 = (( ( WorldSpacePosition.y / _Geological_Tiling_Far ) + _Geological_Map_Offset_Far )).xx;
				float4 tex2DNode5983 = tex2D( _Texture_Geological_Map, temp_cast_1 );
				float3 appendResult5985 = (float3(tex2DNode5983.r , tex2DNode5983.g , tex2DNode5983.b));
				float3 lerpResult1315 = lerp( ( _Geological_Map_Close_Power * ( appendResult5986 + float3( -0.3,-0.3,-0.3 ) ) ) , ( _Geological_Map_Far_Power * ( appendResult5985 + float3( -0.3,-0.3,-0.3 ) ) ) , UVmixDistance636);
				half Splat4_A2546 = tex2DNode4371.a;
				half Splat4_B2545 = tex2DNode4371.b;
				half Splat4_G2544 = tex2DNode4371.g;
				half Splat4_R2543 = tex2DNode4371.r;
				half Splat3_A2540 = tex2DNode4370.a;
				half Splat3_B2539 = tex2DNode4370.b;
				half Splat3_G2538 = tex2DNode4370.g;
				half Splat3_R2537 = tex2DNode4370.r;
				half Splat2_A2109 = tex2DNode4369.a;
				half Splat2_B2108 = tex2DNode4369.b;
				half Splat2_G2107 = tex2DNode4369.g;
				half Splat2_R2106 = tex2DNode4369.r;
				half Splat1_R1438 = tex2DNode4368.r;
				half Splat1_G1441 = tex2DNode4368.g;
				half Splat1_A1491 = tex2DNode4368.a;
				half Splat1_B1442 = tex2DNode4368.b;
				float3 blendOpSrc4362 = weightedAvg6240;
				float3 blendOpDest4362 = ( lerpResult1315 * ( ( _Texture_16_Geological_Power * Splat4_A2546 ) + ( ( _Texture_15_Geological_Power * Splat4_B2545 ) + ( ( _Texture_14_Geological_Power * Splat4_G2544 ) + ( ( _Texture_13_Geological_Power * Splat4_R2543 ) + ( ( _Texture_12_Geological_Power * Splat3_A2540 ) + ( ( _Texture_11_Geological_Power * Splat3_B2539 ) + ( ( _Texture_10_Geological_Power * Splat3_G2538 ) + ( ( _Texture_9_Geological_Power * Splat3_R2537 ) + ( ( _Texture_8_Geological_Power * Splat2_A2109 ) + ( ( _Texture_7_Geological_Power * Splat2_B2108 ) + ( ( _Texture_6_Geological_Power * Splat2_G2107 ) + ( ( _Texture_5_Geological_Power * Splat2_R2106 ) + ( ( _Texture_1_Geological_Power * Splat1_R1438 ) + ( ( _Texture_2_Geological_Power * Splat1_G1441 ) + ( ( _Texture_4_Geological_Power * Splat1_A1491 ) + ( _Texture_3_Geological_Power * Splat1_B1442 ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) );
				float3 clampResult5715 = clamp( ( saturate( ( blendOpSrc4362 + blendOpDest4362 ) )) , float3( 0,0,0 ) , float3( 1,1,1 ) );
				float2 temp_output_3893_0 = ( Top_Bottom1999 / _Snow_Tiling );
				float4 texArray4378 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3893_0, _Texture_Snow_Index );
				float4 lerpResult1416 = lerp( texArray4378 , _Texture_Snow_Average , UVmixDistance636);
				float4 ifLocalVar6165 = 0;
				UNITY_BRANCH 
				if( _Texture_Snow_Index > -1.0 )
				ifLocalVar6165 = ( lerpResult1416 * _Snow_Color );
				float4 break1409 = ifLocalVar6165;
				float3 appendResult1410 = (float3(break1409.x , break1409.y , break1409.z));
				half3 In06279 = float3( 0,0,0 );
				half localMyCustomExpression6279 = MyCustomExpression6279( In06279 );
				float3 break6278 = _WorldSpaceCameraPos;
				float temp_output_6283_0 = ( _Glitter_Refreshing_Speed * ( ( localMyCustomExpression6279 * 10.0 ) + ( break6278.x + break6278.y + break6278.z ) ) );
				float temp_output_6286_0 = ( 0.0 + temp_output_6283_0 );
				float clampResult6298 = clamp( sin( ( temp_output_6286_0 * 0.1 ) ) , 0.0 , 1.0 );
				float2 temp_output_6289_0 = ( Top_Bottom1999 * ( 1.0 / _Glitter_Tiling ) );
				float2 break6322 = temp_output_6289_0;
				float2 appendResult6321 = (float2(break6322.y , break6322.x));
				float4 tex2DNode6300 = tex2D( _Texture_Glitter, ( appendResult6321 + float2( 0.37,0.67 ) ) );
				float2 panner6290 = ( ( temp_output_6283_0 * 0.01 ) * float2( 1,1 ) + temp_output_6289_0);
				float cos6292 = cos( sin( ( temp_output_6286_0 * 0.0001 ) ) );
				float sin6292 = sin( sin( ( temp_output_6286_0 * 0.0001 ) ) );
				float2 rotator6292 = mul( panner6290 - float2( 0.5,0.5 ) , float2x2( cos6292 , -sin6292 , sin6292 , cos6292 )) + float2( 0.5,0.5 );
				float clampResult6302 = clamp( pow( tex2D( _Texture_Glitter, ( ( rotator6292 + temp_output_6289_0 ) * float2( 0.2,0.2 ) ) ).r , ( 1.0 - _Glitter_Noise_Threshold ) ) , 0.0 , 1.0 );
				float lerpResult6303 = lerp(  ( clampResult6298 - 0.2 > 0.0 ? tex2D( _Texture_Glitter, temp_output_6289_0 ).r : clampResult6298 - 0.2 <= 0.0 && clampResult6298 + 0.2 >= 0.0 ? tex2DNode6300.r : tex2DNode6300.r )  , 0.6 , clampResult6302);
				float clampResult6305 = clamp( pow( lerpResult6303 , 100.0 ) , 0.0 , 1.0 );
				float temp_output_6306_0 = ( _Gliter_Color_Power * clampResult6305 );
				float4 texArray3300 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3275_0, _Texture_1_Normal_Index );
				float2 appendResult11_g1028 = (float2(texArray3300.w , texArray3300.y));
				float2 temp_output_4_0_g1028 = ( ( ( appendResult11_g1028 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_1_Normal_Power );
				float2 break8_g1028 = temp_output_4_0_g1028;
				float dotResult5_g1028 = dot( temp_output_4_0_g1028 , temp_output_4_0_g1028 );
				float temp_output_9_0_g1028 = sqrt( ( 1.0 - saturate( dotResult5_g1028 ) ) );
				float3 appendResult20_g1028 = (float3(break8_g1028.x , break8_g1028.y , temp_output_9_0_g1028));
				float3 temp_output_6001_0 = appendResult20_g1028;
				float4 texArray3299 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3279_0, _Texture_1_Normal_Index );
				float2 appendResult11_g837 = (float2(texArray3299.w , texArray3299.y));
				float2 temp_output_4_0_g837 = ( ( ( appendResult11_g837 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_1_Normal_Power * -1.0 ) );
				float2 break8_g837 = temp_output_4_0_g837;
				float dotResult5_g837 = dot( temp_output_4_0_g837 , temp_output_4_0_g837 );
				float temp_output_9_0_g837 = sqrt( ( 1.0 - saturate( dotResult5_g837 ) ) );
				float3 appendResult21_g837 = (float3(break8_g837.y , break8_g837.x , temp_output_9_0_g837));
				float3 appendResult5874 = (float3(WorldSpaceNormal.x , -1.0 , 1.0));
				float4 texArray3301 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3277_0, _Texture_1_Normal_Index );
				float2 appendResult11_g838 = (float2(texArray3301.w , texArray3301.y));
				float2 temp_output_4_0_g838 = ( ( ( appendResult11_g838 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_1_Normal_Power );
				float2 break8_g838 = temp_output_4_0_g838;
				float dotResult5_g838 = dot( temp_output_4_0_g838 , temp_output_4_0_g838 );
				float temp_output_9_0_g838 = sqrt( ( 1.0 - saturate( dotResult5_g838 ) ) );
				float3 appendResult20_g838 = (float3(break8_g838.x , break8_g838.y , temp_output_9_0_g838));
				float3 appendResult5876 = (float3(1.0 , ( WorldSpaceNormal.z * -1.0 ) , 1.0));
				float3 weightedBlendVar5676 = BlendComponents91;
				float3 weightedAvg5676 = ( ( weightedBlendVar5676.x*( appendResult21_g837 * appendResult5874 ) + weightedBlendVar5676.y*temp_output_6001_0 + weightedBlendVar5676.z*( appendResult20_g838 * appendResult5876 ) )/( weightedBlendVar5676.x + weightedBlendVar5676.y + weightedBlendVar5676.z ) );
				float3 ifLocalVar5783 = 0;
				UNITY_BRANCH 
				if( _Texture_1_Triplanar == 1.0 )
				ifLocalVar5783 = weightedAvg5676;
				else
				ifLocalVar5783 = temp_output_6001_0;
				half3 EmptyNRM6172 = half3(0,0,1);
				float3 ifLocalVar6127 = 0;
				UNITY_BRANCH 
				if( _Texture_1_Normal_Index <= -1.0 )
				ifLocalVar6127 = EmptyNRM6172;
				else
				ifLocalVar6127 = ifLocalVar5783;
				half3 Normal_1569 = ifLocalVar6127;
				float4 texArray3350 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3343_0, _Texture_2_Normal_Index );
				float2 appendResult11_g1024 = (float2(texArray3350.w , texArray3350.y));
				float2 temp_output_4_0_g1024 = ( ( ( appendResult11_g1024 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_2_Normal_Power );
				float2 break8_g1024 = temp_output_4_0_g1024;
				float dotResult5_g1024 = dot( temp_output_4_0_g1024 , temp_output_4_0_g1024 );
				float temp_output_9_0_g1024 = sqrt( ( 1.0 - saturate( dotResult5_g1024 ) ) );
				float3 appendResult20_g1024 = (float3(break8_g1024.x , break8_g1024.y , temp_output_9_0_g1024));
				float3 temp_output_6005_0 = appendResult20_g1024;
				float4 texArray3384 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3344_0, _Texture_2_Normal_Index );
				float2 appendResult11_g832 = (float2(texArray3384.w , texArray3384.y));
				float2 temp_output_4_0_g832 = ( ( ( appendResult11_g832 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_2_Normal_Power * -1.0 ) );
				float2 break8_g832 = temp_output_4_0_g832;
				float dotResult5_g832 = dot( temp_output_4_0_g832 , temp_output_4_0_g832 );
				float temp_output_9_0_g832 = sqrt( ( 1.0 - saturate( dotResult5_g832 ) ) );
				float3 appendResult21_g832 = (float3(break8_g832.y , break8_g832.x , temp_output_9_0_g832));
				float3 appendResult5879 = (float3(WorldSpaceNormal.x , -1.0 , 1.0));
				float4 texArray3351 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3379_0, _Texture_2_Normal_Index );
				float2 appendResult11_g836 = (float2(texArray3351.w , texArray3351.y));
				float2 temp_output_4_0_g836 = ( ( ( appendResult11_g836 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_2_Normal_Power );
				float2 break8_g836 = temp_output_4_0_g836;
				float dotResult5_g836 = dot( temp_output_4_0_g836 , temp_output_4_0_g836 );
				float temp_output_9_0_g836 = sqrt( ( 1.0 - saturate( dotResult5_g836 ) ) );
				float3 appendResult20_g836 = (float3(break8_g836.x , break8_g836.y , temp_output_9_0_g836));
				float3 appendResult5882 = (float3(1.0 , ( WorldSpaceNormal.z * -1.0 ) , 1.0));
				float3 weightedBlendVar5499 = BlendComponents91;
				float3 weightedAvg5499 = ( ( weightedBlendVar5499.x*( appendResult21_g832 * appendResult5879 ) + weightedBlendVar5499.y*temp_output_6005_0 + weightedBlendVar5499.z*( appendResult20_g836 * appendResult5882 ) )/( weightedBlendVar5499.x + weightedBlendVar5499.y + weightedBlendVar5499.z ) );
				float3 ifLocalVar5774 = 0;
				UNITY_BRANCH 
				if( _Texture_2_Triplanar == 1.0 )
				ifLocalVar5774 = weightedAvg5499;
				else
				ifLocalVar5774 = temp_output_6005_0;
				float3 ifLocalVar6129 = 0;
				UNITY_BRANCH 
				if( _Texture_2_Normal_Index <= -1.0 )
				ifLocalVar6129 = EmptyNRM6172;
				else
				ifLocalVar6129 = ifLocalVar5774;
				half3 Normal_23361 = ifLocalVar6129;
				float4 texArray3416 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3410_0, _Texture_3_Normal_Index );
				float2 appendResult11_g1029 = (float2(texArray3416.w , texArray3416.y));
				float2 temp_output_4_0_g1029 = ( ( ( appendResult11_g1029 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_3_Normal_Power );
				float2 break8_g1029 = temp_output_4_0_g1029;
				float dotResult5_g1029 = dot( temp_output_4_0_g1029 , temp_output_4_0_g1029 );
				float temp_output_9_0_g1029 = sqrt( ( 1.0 - saturate( dotResult5_g1029 ) ) );
				float3 appendResult20_g1029 = (float3(break8_g1029.x , break8_g1029.y , temp_output_9_0_g1029));
				float3 temp_output_6008_0 = appendResult20_g1029;
				float4 texArray3445 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3413_0, _Texture_3_Normal_Index );
				float2 appendResult11_g833 = (float2(texArray3445.w , texArray3445.y));
				float2 temp_output_4_0_g833 = ( ( ( appendResult11_g833 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_3_Normal_Power * -1.0 ) );
				float2 break8_g833 = temp_output_4_0_g833;
				float dotResult5_g833 = dot( temp_output_4_0_g833 , temp_output_4_0_g833 );
				float temp_output_9_0_g833 = sqrt( ( 1.0 - saturate( dotResult5_g833 ) ) );
				float3 appendResult21_g833 = (float3(break8_g833.y , break8_g833.x , temp_output_9_0_g833));
				float3 appendResult5886 = (float3(WorldSpaceNormal.x , -1.0 , 1.0));
				float4 texArray3417 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3441_0, _Texture_3_Normal_Index );
				float2 appendResult11_g835 = (float2(texArray3417.w , texArray3417.y));
				float2 temp_output_4_0_g835 = ( ( ( appendResult11_g835 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_3_Normal_Power );
				float2 break8_g835 = temp_output_4_0_g835;
				float dotResult5_g835 = dot( temp_output_4_0_g835 , temp_output_4_0_g835 );
				float temp_output_9_0_g835 = sqrt( ( 1.0 - saturate( dotResult5_g835 ) ) );
				float3 appendResult20_g835 = (float3(break8_g835.x , break8_g835.y , temp_output_9_0_g835));
				float3 appendResult5889 = (float3(1.0 , ( WorldSpaceNormal.z * -1.0 ) , 1.0));
				float3 weightedBlendVar5503 = BlendComponents91;
				float3 weightedAvg5503 = ( ( weightedBlendVar5503.x*( appendResult21_g833 * appendResult5886 ) + weightedBlendVar5503.y*temp_output_6008_0 + weightedBlendVar5503.z*( appendResult20_g835 * appendResult5889 ) )/( weightedBlendVar5503.x + weightedBlendVar5503.y + weightedBlendVar5503.z ) );
				float3 ifLocalVar5776 = 0;
				UNITY_BRANCH 
				if( _Texture_3_Triplanar == 1.0 )
				ifLocalVar5776 = weightedAvg5503;
				else
				ifLocalVar5776 = temp_output_6008_0;
				float3 ifLocalVar6131 = 0;
				UNITY_BRANCH 
				if( _Texture_3_Normal_Index > -1.0 )
				ifLocalVar6131 = ifLocalVar5776;
				half3 Normal_33452 = ifLocalVar6131;
				float4 texArray3483 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3477_0, _Texture_4_Normal_Index );
				float2 appendResult11_g1022 = (float2(texArray3483.w , texArray3483.y));
				float2 temp_output_4_0_g1022 = ( ( ( appendResult11_g1022 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_4_Normal_Power );
				float2 break8_g1022 = temp_output_4_0_g1022;
				float dotResult5_g1022 = dot( temp_output_4_0_g1022 , temp_output_4_0_g1022 );
				float temp_output_9_0_g1022 = sqrt( ( 1.0 - saturate( dotResult5_g1022 ) ) );
				float3 appendResult20_g1022 = (float3(break8_g1022.x , break8_g1022.y , temp_output_9_0_g1022));
				float3 temp_output_6011_0 = appendResult20_g1022;
				float4 texArray3512 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3478_0, _Texture_4_Normal_Index );
				float2 appendResult11_g831 = (float2(texArray3512.w , texArray3512.y));
				float2 temp_output_4_0_g831 = ( ( ( appendResult11_g831 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_4_Normal_Power * -1.0 ) );
				float2 break8_g831 = temp_output_4_0_g831;
				float dotResult5_g831 = dot( temp_output_4_0_g831 , temp_output_4_0_g831 );
				float temp_output_9_0_g831 = sqrt( ( 1.0 - saturate( dotResult5_g831 ) ) );
				float3 appendResult21_g831 = (float3(break8_g831.y , break8_g831.x , temp_output_9_0_g831));
				float3 appendResult5893 = (float3(WorldSpaceNormal.x , -1.0 , 1.0));
				float4 texArray3484 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3508_0, _Texture_4_Normal_Index );
				float2 appendResult11_g834 = (float2(texArray3484.w , texArray3484.y));
				float2 temp_output_4_0_g834 = ( ( ( appendResult11_g834 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_4_Normal_Power );
				float2 break8_g834 = temp_output_4_0_g834;
				float dotResult5_g834 = dot( temp_output_4_0_g834 , temp_output_4_0_g834 );
				float temp_output_9_0_g834 = sqrt( ( 1.0 - saturate( dotResult5_g834 ) ) );
				float3 appendResult20_g834 = (float3(break8_g834.x , break8_g834.y , temp_output_9_0_g834));
				float3 appendResult5896 = (float3(1.0 , ( WorldSpaceNormal.z * -1.0 ) , 1.0));
				float3 weightedBlendVar5507 = BlendComponents91;
				float3 weightedAvg5507 = ( ( weightedBlendVar5507.x*( appendResult21_g831 * appendResult5893 ) + weightedBlendVar5507.y*temp_output_6011_0 + weightedBlendVar5507.z*( appendResult20_g834 * appendResult5896 ) )/( weightedBlendVar5507.x + weightedBlendVar5507.y + weightedBlendVar5507.z ) );
				float3 ifLocalVar5999 = 0;
				UNITY_BRANCH 
				if( _Texture_4_Triplanar == 1.0 )
				ifLocalVar5999 = weightedAvg5507;
				else
				ifLocalVar5999 = temp_output_6011_0;
				float3 ifLocalVar6133 = 0;
				UNITY_BRANCH 
				if( _Texture_4_Normal_Index <= -1.0 )
				ifLocalVar6133 = EmptyNRM6172;
				else
				ifLocalVar6133 = ifLocalVar5999;
				half3 Normal_43519 = ifLocalVar6133;
				float4 layeredBlendVar5639 = tex2DNode4368;
				float3 layeredBlend5639 = ( lerp( lerp( lerp( lerp( float3( 0,0,0 ) , Normal_1569 , layeredBlendVar5639.x ) , Normal_23361 , layeredBlendVar5639.y ) , Normal_33452 , layeredBlendVar5639.z ) , Normal_43519 , layeredBlendVar5639.w ) );
				float4 texArray4424 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4416_0, _Texture_5_Normal_Index );
				float2 appendResult11_g1054 = (float2(texArray4424.w , texArray4424.y));
				float2 temp_output_4_0_g1054 = ( ( ( appendResult11_g1054 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_5_Normal_Power );
				float2 break8_g1054 = temp_output_4_0_g1054;
				float dotResult5_g1054 = dot( temp_output_4_0_g1054 , temp_output_4_0_g1054 );
				float temp_output_9_0_g1054 = sqrt( ( 1.0 - saturate( dotResult5_g1054 ) ) );
				float3 appendResult20_g1054 = (float3(break8_g1054.x , break8_g1054.y , temp_output_9_0_g1054));
				float3 temp_output_6014_0 = appendResult20_g1054;
				float4 texArray4417 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4400_0, _Texture_5_Normal_Index );
				float2 appendResult11_g1027 = (float2(texArray4417.w , texArray4417.y));
				float2 temp_output_4_0_g1027 = ( ( ( appendResult11_g1027 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_5_Normal_Power * -1.0 ) );
				float2 break8_g1027 = temp_output_4_0_g1027;
				float dotResult5_g1027 = dot( temp_output_4_0_g1027 , temp_output_4_0_g1027 );
				float temp_output_9_0_g1027 = sqrt( ( 1.0 - saturate( dotResult5_g1027 ) ) );
				float3 appendResult21_g1027 = (float3(break8_g1027.y , break8_g1027.x , temp_output_9_0_g1027));
				float3 appendResult5900 = (float3(WorldSpaceNormal.x , -1.0 , 1.0));
				float4 texArray4422 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4413_0, _Texture_5_Normal_Index );
				float2 appendResult11_g1025 = (float2(texArray4422.w , texArray4422.y));
				float2 temp_output_4_0_g1025 = ( ( ( appendResult11_g1025 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_5_Normal_Power );
				float2 break8_g1025 = temp_output_4_0_g1025;
				float dotResult5_g1025 = dot( temp_output_4_0_g1025 , temp_output_4_0_g1025 );
				float temp_output_9_0_g1025 = sqrt( ( 1.0 - saturate( dotResult5_g1025 ) ) );
				float3 appendResult20_g1025 = (float3(break8_g1025.x , break8_g1025.y , temp_output_9_0_g1025));
				float3 appendResult5903 = (float3(1.0 , ( WorldSpaceNormal.z * -1.0 ) , 1.0));
				float3 weightedBlendVar5511 = BlendComponents91;
				float3 weightedAvg5511 = ( ( weightedBlendVar5511.x*( appendResult21_g1027 * appendResult5900 ) + weightedBlendVar5511.y*temp_output_6014_0 + weightedBlendVar5511.z*( appendResult20_g1025 * appendResult5903 ) )/( weightedBlendVar5511.x + weightedBlendVar5511.y + weightedBlendVar5511.z ) );
				float3 ifLocalVar5806 = 0;
				UNITY_BRANCH 
				if( _Texture_5_Triplanar == 1.0 )
				ifLocalVar5806 = weightedAvg5511;
				else
				ifLocalVar5806 = temp_output_6014_0;
				float3 ifLocalVar6135 = 0;
				UNITY_BRANCH 
				if( _Texture_5_Normal_Index <= -1.0 )
				ifLocalVar6135 = EmptyNRM6172;
				else
				ifLocalVar6135 = ifLocalVar5806;
				half3 Normal_54456 = ifLocalVar6135;
				float4 texArray4493 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4485_0, _Texture_6_Normal_Index );
				float2 appendResult11_g1058 = (float2(texArray4493.w , texArray4493.y));
				float2 temp_output_4_0_g1058 = ( ( ( appendResult11_g1058 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_6_Normal_Power );
				float2 break8_g1058 = temp_output_4_0_g1058;
				float dotResult5_g1058 = dot( temp_output_4_0_g1058 , temp_output_4_0_g1058 );
				float temp_output_9_0_g1058 = sqrt( ( 1.0 - saturate( dotResult5_g1058 ) ) );
				float3 appendResult20_g1058 = (float3(break8_g1058.x , break8_g1058.y , temp_output_9_0_g1058));
				float3 temp_output_6017_0 = appendResult20_g1058;
				float4 texArray4486 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4472_0, _Texture_6_Normal_Index );
				float2 appendResult11_g1021 = (float2(texArray4486.w , texArray4486.y));
				float2 temp_output_4_0_g1021 = ( ( ( appendResult11_g1021 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_6_Normal_Power * -1.0 ) );
				float2 break8_g1021 = temp_output_4_0_g1021;
				float dotResult5_g1021 = dot( temp_output_4_0_g1021 , temp_output_4_0_g1021 );
				float temp_output_9_0_g1021 = sqrt( ( 1.0 - saturate( dotResult5_g1021 ) ) );
				float3 appendResult21_g1021 = (float3(break8_g1021.y , break8_g1021.x , temp_output_9_0_g1021));
				float3 appendResult5907 = (float3(WorldSpaceNormal.x , -1.0 , 1.0));
				float4 texArray4491 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4483_0, _Texture_6_Normal_Index );
				float2 appendResult11_g1023 = (float2(texArray4491.w , texArray4491.y));
				float2 temp_output_4_0_g1023 = ( ( ( appendResult11_g1023 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_6_Normal_Power );
				float2 break8_g1023 = temp_output_4_0_g1023;
				float dotResult5_g1023 = dot( temp_output_4_0_g1023 , temp_output_4_0_g1023 );
				float temp_output_9_0_g1023 = sqrt( ( 1.0 - saturate( dotResult5_g1023 ) ) );
				float3 appendResult20_g1023 = (float3(break8_g1023.x , break8_g1023.y , temp_output_9_0_g1023));
				float3 appendResult5910 = (float3(1.0 , ( WorldSpaceNormal.z * -1.0 ) , 1.0));
				float3 weightedBlendVar5519 = BlendComponents91;
				float3 weightedAvg5519 = ( ( weightedBlendVar5519.x*( appendResult21_g1021 * appendResult5907 ) + weightedBlendVar5519.y*temp_output_6017_0 + weightedBlendVar5519.z*( appendResult20_g1023 * appendResult5910 ) )/( weightedBlendVar5519.x + weightedBlendVar5519.y + weightedBlendVar5519.z ) );
				float3 ifLocalVar5807 = 0;
				UNITY_BRANCH 
				if( _Texture_6_Triplanar == 1.0 )
				ifLocalVar5807 = weightedAvg5519;
				else
				ifLocalVar5807 = temp_output_6017_0;
				float3 ifLocalVar6138 = 0;
				UNITY_BRANCH 
				if( _Texture_6_Normal_Index <= -1.0 )
				ifLocalVar6138 = EmptyNRM6172;
				else
				ifLocalVar6138 = ifLocalVar5807;
				half3 Normal_64537 = ifLocalVar6138;
				float4 texArray4567 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4559_0, _Texture_7_Normal_Index );
				float2 appendResult11_g1056 = (float2(texArray4567.w , texArray4567.y));
				float2 temp_output_4_0_g1056 = ( ( ( appendResult11_g1056 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_7_Normal_Power );
				float2 break8_g1056 = temp_output_4_0_g1056;
				float dotResult5_g1056 = dot( temp_output_4_0_g1056 , temp_output_4_0_g1056 );
				float temp_output_9_0_g1056 = sqrt( ( 1.0 - saturate( dotResult5_g1056 ) ) );
				float3 appendResult20_g1056 = (float3(break8_g1056.x , break8_g1056.y , temp_output_9_0_g1056));
				float3 temp_output_6020_0 = appendResult20_g1056;
				float4 texArray4560 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4546_0, _Texture_7_Normal_Index );
				float2 appendResult11_g1031 = (float2(texArray4560.w , texArray4560.y));
				float2 temp_output_4_0_g1031 = ( ( ( appendResult11_g1031 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_7_Normal_Power * -1.0 ) );
				float2 break8_g1031 = temp_output_4_0_g1031;
				float dotResult5_g1031 = dot( temp_output_4_0_g1031 , temp_output_4_0_g1031 );
				float temp_output_9_0_g1031 = sqrt( ( 1.0 - saturate( dotResult5_g1031 ) ) );
				float3 appendResult21_g1031 = (float3(break8_g1031.y , break8_g1031.x , temp_output_9_0_g1031));
				float3 appendResult5914 = (float3(WorldSpaceNormal.x , -1.0 , 1.0));
				float4 texArray4565 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4557_0, _Texture_7_Normal_Index );
				float2 appendResult11_g1032 = (float2(texArray4565.w , texArray4565.y));
				float2 temp_output_4_0_g1032 = ( ( ( appendResult11_g1032 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_7_Normal_Power );
				float2 break8_g1032 = temp_output_4_0_g1032;
				float dotResult5_g1032 = dot( temp_output_4_0_g1032 , temp_output_4_0_g1032 );
				float temp_output_9_0_g1032 = sqrt( ( 1.0 - saturate( dotResult5_g1032 ) ) );
				float3 appendResult20_g1032 = (float3(break8_g1032.x , break8_g1032.y , temp_output_9_0_g1032));
				float3 appendResult5917 = (float3(1.0 , ( WorldSpaceNormal.z * -1.0 ) , 1.0));
				float3 weightedBlendVar5523 = BlendComponents91;
				float3 weightedAvg5523 = ( ( weightedBlendVar5523.x*( appendResult21_g1031 * appendResult5914 ) + weightedBlendVar5523.y*temp_output_6020_0 + weightedBlendVar5523.z*( appendResult20_g1032 * appendResult5917 ) )/( weightedBlendVar5523.x + weightedBlendVar5523.y + weightedBlendVar5523.z ) );
				float3 ifLocalVar5853 = 0;
				UNITY_BRANCH 
				if( _Texture_7_Triplanar == 1.0 )
				ifLocalVar5853 = weightedAvg5523;
				else
				ifLocalVar5853 = temp_output_6020_0;
				float3 ifLocalVar6140 = 0;
				UNITY_BRANCH 
				if( _Texture_7_Normal_Index <= -1.0 )
				ifLocalVar6140 = EmptyNRM6172;
				else
				ifLocalVar6140 = ifLocalVar5853;
				half3 Normal_74615 = ifLocalVar6140;
				float4 texArray4641 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4633_0, _Texture_8_Normal_Index );
				float2 appendResult11_g1050 = (float2(texArray4641.w , texArray4641.y));
				float2 temp_output_4_0_g1050 = ( ( ( appendResult11_g1050 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_8_Normal_Power );
				float2 break8_g1050 = temp_output_4_0_g1050;
				float dotResult5_g1050 = dot( temp_output_4_0_g1050 , temp_output_4_0_g1050 );
				float temp_output_9_0_g1050 = sqrt( ( 1.0 - saturate( dotResult5_g1050 ) ) );
				float3 appendResult20_g1050 = (float3(break8_g1050.x , break8_g1050.y , temp_output_9_0_g1050));
				float3 temp_output_6023_0 = appendResult20_g1050;
				float4 texArray4634 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4620_0, _Texture_8_Normal_Index );
				float2 appendResult11_g1030 = (float2(texArray4634.w , texArray4634.y));
				float2 temp_output_4_0_g1030 = ( ( ( appendResult11_g1030 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_8_Normal_Power * -1.0 ) );
				float2 break8_g1030 = temp_output_4_0_g1030;
				float dotResult5_g1030 = dot( temp_output_4_0_g1030 , temp_output_4_0_g1030 );
				float temp_output_9_0_g1030 = sqrt( ( 1.0 - saturate( dotResult5_g1030 ) ) );
				float3 appendResult21_g1030 = (float3(break8_g1030.y , break8_g1030.x , temp_output_9_0_g1030));
				float3 appendResult5921 = (float3(WorldSpaceNormal.x , -1.0 , 1.0));
				float4 texArray4639 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4631_0, _Texture_8_Normal_Index );
				float2 appendResult11_g1026 = (float2(texArray4639.w , texArray4639.y));
				float2 temp_output_4_0_g1026 = ( ( ( appendResult11_g1026 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_8_Normal_Power );
				float2 break8_g1026 = temp_output_4_0_g1026;
				float dotResult5_g1026 = dot( temp_output_4_0_g1026 , temp_output_4_0_g1026 );
				float temp_output_9_0_g1026 = sqrt( ( 1.0 - saturate( dotResult5_g1026 ) ) );
				float3 appendResult20_g1026 = (float3(break8_g1026.x , break8_g1026.y , temp_output_9_0_g1026));
				float3 appendResult5924 = (float3(1.0 , ( WorldSpaceNormal.z * -1.0 ) , 1.0));
				float3 weightedBlendVar5527 = BlendComponents91;
				float3 weightedAvg5527 = ( ( weightedBlendVar5527.x*( appendResult21_g1030 * appendResult5921 ) + weightedBlendVar5527.y*temp_output_6023_0 + weightedBlendVar5527.z*( appendResult20_g1026 * appendResult5924 ) )/( weightedBlendVar5527.x + weightedBlendVar5527.y + weightedBlendVar5527.z ) );
				float3 ifLocalVar5813 = 0;
				UNITY_BRANCH 
				if( _Texture_8_Triplanar == 1.0 )
				ifLocalVar5813 = weightedAvg5527;
				else
				ifLocalVar5813 = temp_output_6023_0;
				float3 ifLocalVar6142 = 0;
				UNITY_BRANCH 
				if( _Texture_8_Normal_Index <= -1.0 )
				ifLocalVar6142 = EmptyNRM6172;
				else
				ifLocalVar6142 = ifLocalVar5813;
				half3 Normal_84690 = ifLocalVar6142;
				float4 layeredBlendVar5640 = tex2DNode4369;
				float3 layeredBlend5640 = ( lerp( lerp( lerp( lerp( layeredBlend5639 , Normal_54456 , layeredBlendVar5640.x ) , Normal_64537 , layeredBlendVar5640.y ) , Normal_74615 , layeredBlendVar5640.z ) , Normal_84690 , layeredBlendVar5640.w ) );
				float4 texArray4788 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4712_0, _Texture_9_Normal_Index );
				float2 appendResult11_g1062 = (float2(texArray4788.w , texArray4788.y));
				float2 temp_output_4_0_g1062 = ( ( ( appendResult11_g1062 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_9_Normal_Power );
				float2 break8_g1062 = temp_output_4_0_g1062;
				float dotResult5_g1062 = dot( temp_output_4_0_g1062 , temp_output_4_0_g1062 );
				float temp_output_9_0_g1062 = sqrt( ( 1.0 - saturate( dotResult5_g1062 ) ) );
				float3 appendResult20_g1062 = (float3(break8_g1062.x , break8_g1062.y , temp_output_9_0_g1062));
				float3 temp_output_6047_0 = appendResult20_g1062;
				float4 texArray5285 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4706_0, _Texture_9_Normal_Index );
				float2 appendResult11_g1053 = (float2(texArray5285.w , texArray5285.y));
				float2 temp_output_4_0_g1053 = ( ( ( appendResult11_g1053 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_9_Normal_Power * -1.0 ) );
				float2 break8_g1053 = temp_output_4_0_g1053;
				float dotResult5_g1053 = dot( temp_output_4_0_g1053 , temp_output_4_0_g1053 );
				float temp_output_9_0_g1053 = sqrt( ( 1.0 - saturate( dotResult5_g1053 ) ) );
				float3 appendResult21_g1053 = (float3(break8_g1053.y , break8_g1053.x , temp_output_9_0_g1053));
				float3 appendResult5977 = (float3(WorldSpaceNormal.x , -1.0 , 1.0));
				float4 texArray4783 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4761_0, _Texture_9_Normal_Index );
				float2 appendResult11_g1055 = (float2(texArray4783.w , texArray4783.y));
				float2 temp_output_4_0_g1055 = ( ( ( appendResult11_g1055 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_9_Normal_Power );
				float2 break8_g1055 = temp_output_4_0_g1055;
				float dotResult5_g1055 = dot( temp_output_4_0_g1055 , temp_output_4_0_g1055 );
				float temp_output_9_0_g1055 = sqrt( ( 1.0 - saturate( dotResult5_g1055 ) ) );
				float3 appendResult20_g1055 = (float3(break8_g1055.x , break8_g1055.y , temp_output_9_0_g1055));
				float3 appendResult5980 = (float3(1.0 , ( WorldSpaceNormal.z * -1.0 ) , 1.0));
				float3 weightedBlendVar5491 = BlendComponents91;
				float3 weightedAvg5491 = ( ( weightedBlendVar5491.x*( appendResult21_g1053 * appendResult5977 ) + weightedBlendVar5491.y*temp_output_6047_0 + weightedBlendVar5491.z*( appendResult20_g1055 * appendResult5980 ) )/( weightedBlendVar5491.x + weightedBlendVar5491.y + weightedBlendVar5491.z ) );
				float3 ifLocalVar5846 = 0;
				UNITY_BRANCH 
				if( _Texture_9_Triplanar == 1.0 )
				ifLocalVar5846 = weightedAvg5491;
				else
				ifLocalVar5846 = temp_output_6047_0;
				float3 ifLocalVar6144 = 0;
				UNITY_BRANCH 
				if( _Texture_9_Normal_Index <= -1.0 )
				ifLocalVar6144 = EmptyNRM6172;
				else
				ifLocalVar6144 = ifLocalVar5846;
				half3 Normal_94897 = ifLocalVar6144;
				float4 texArray4822 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4793_0, _Texture_10_Normal_Index );
				float2 appendResult11_g1066 = (float2(texArray4822.w , texArray4822.y));
				float2 temp_output_4_0_g1066 = ( ( ( appendResult11_g1066 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_10_Normal_Power );
				float2 break8_g1066 = temp_output_4_0_g1066;
				float dotResult5_g1066 = dot( temp_output_4_0_g1066 , temp_output_4_0_g1066 );
				float temp_output_9_0_g1066 = sqrt( ( 1.0 - saturate( dotResult5_g1066 ) ) );
				float3 appendResult20_g1066 = (float3(break8_g1066.x , break8_g1066.y , temp_output_9_0_g1066));
				float3 temp_output_6044_0 = appendResult20_g1066;
				float4 texArray4798 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4742_0, _Texture_10_Normal_Index );
				float2 appendResult11_g1052 = (float2(texArray4798.w , texArray4798.y));
				float2 temp_output_4_0_g1052 = ( ( ( appendResult11_g1052 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_10_Normal_Power * -1.0 ) );
				float2 break8_g1052 = temp_output_4_0_g1052;
				float dotResult5_g1052 = dot( temp_output_4_0_g1052 , temp_output_4_0_g1052 );
				float temp_output_9_0_g1052 = sqrt( ( 1.0 - saturate( dotResult5_g1052 ) ) );
				float3 appendResult21_g1052 = (float3(break8_g1052.y , break8_g1052.x , temp_output_9_0_g1052));
				float3 appendResult5970 = (float3(WorldSpaceNormal.x , -1.0 , 1.0));
				float4 texArray4791 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4785_0, _Texture_10_Normal_Index );
				float2 appendResult11_g1060 = (float2(texArray4791.w , texArray4791.y));
				float2 temp_output_4_0_g1060 = ( ( ( appendResult11_g1060 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_10_Normal_Power );
				float2 break8_g1060 = temp_output_4_0_g1060;
				float dotResult5_g1060 = dot( temp_output_4_0_g1060 , temp_output_4_0_g1060 );
				float temp_output_9_0_g1060 = sqrt( ( 1.0 - saturate( dotResult5_g1060 ) ) );
				float3 appendResult20_g1060 = (float3(break8_g1060.x , break8_g1060.y , temp_output_9_0_g1060));
				float3 appendResult5973 = (float3(1.0 , ( WorldSpaceNormal.z * -1.0 ) , 1.0));
				float3 weightedBlendVar5531 = BlendComponents91;
				float3 weightedAvg5531 = ( ( weightedBlendVar5531.x*( appendResult21_g1052 * appendResult5970 ) + weightedBlendVar5531.y*temp_output_6044_0 + weightedBlendVar5531.z*( appendResult20_g1060 * appendResult5973 ) )/( weightedBlendVar5531.x + weightedBlendVar5531.y + weightedBlendVar5531.z ) );
				float3 ifLocalVar5842 = 0;
				UNITY_BRANCH 
				if( _Texture_10_Triplanar == 1.0 )
				ifLocalVar5842 = weightedAvg5531;
				else
				ifLocalVar5842 = temp_output_6044_0;
				float3 ifLocalVar6146 = 0;
				UNITY_BRANCH 
				if( _Texture_10_Normal_Index <= -1.0 )
				ifLocalVar6146 = EmptyNRM6172;
				else
				ifLocalVar6146 = ifLocalVar5842;
				half3 Normal_104918 = ifLocalVar6146;
				float4 texArray4856 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4817_0, _Texture_11_Normal_Index );
				float2 appendResult11_g1065 = (float2(texArray4856.w , texArray4856.y));
				float2 temp_output_4_0_g1065 = ( ( ( appendResult11_g1065 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_11_Normal_Power );
				float2 break8_g1065 = temp_output_4_0_g1065;
				float dotResult5_g1065 = dot( temp_output_4_0_g1065 , temp_output_4_0_g1065 );
				float temp_output_9_0_g1065 = sqrt( ( 1.0 - saturate( dotResult5_g1065 ) ) );
				float3 appendResult20_g1065 = (float3(break8_g1065.x , break8_g1065.y , temp_output_9_0_g1065));
				float3 temp_output_6041_0 = appendResult20_g1065;
				float4 texArray4828 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4748_0, _Texture_11_Normal_Index );
				float2 appendResult11_g1051 = (float2(texArray4828.w , texArray4828.y));
				float2 temp_output_4_0_g1051 = ( ( ( appendResult11_g1051 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_11_Normal_Power * -1.0 ) );
				float2 break8_g1051 = temp_output_4_0_g1051;
				float dotResult5_g1051 = dot( temp_output_4_0_g1051 , temp_output_4_0_g1051 );
				float temp_output_9_0_g1051 = sqrt( ( 1.0 - saturate( dotResult5_g1051 ) ) );
				float3 appendResult21_g1051 = (float3(break8_g1051.y , break8_g1051.x , temp_output_9_0_g1051));
				float3 appendResult5963 = (float3(WorldSpaceNormal.x , -1.0 , 1.0));
				float4 texArray4811 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4795_0, _Texture_11_Normal_Index );
				float2 appendResult11_g1059 = (float2(texArray4811.w , texArray4811.y));
				float2 temp_output_4_0_g1059 = ( ( ( appendResult11_g1059 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_11_Normal_Power );
				float2 break8_g1059 = temp_output_4_0_g1059;
				float dotResult5_g1059 = dot( temp_output_4_0_g1059 , temp_output_4_0_g1059 );
				float temp_output_9_0_g1059 = sqrt( ( 1.0 - saturate( dotResult5_g1059 ) ) );
				float3 appendResult20_g1059 = (float3(break8_g1059.x , break8_g1059.y , temp_output_9_0_g1059));
				float3 appendResult5966 = (float3(1.0 , ( WorldSpaceNormal.z * -1.0 ) , 1.0));
				float3 weightedBlendVar5535 = BlendComponents91;
				float3 weightedAvg5535 = ( ( weightedBlendVar5535.x*( appendResult21_g1051 * appendResult5963 ) + weightedBlendVar5535.y*temp_output_6041_0 + weightedBlendVar5535.z*( appendResult20_g1059 * appendResult5966 ) )/( weightedBlendVar5535.x + weightedBlendVar5535.y + weightedBlendVar5535.z ) );
				float3 ifLocalVar5838 = 0;
				UNITY_BRANCH 
				if( _Texture_11_Triplanar == 1.0 )
				ifLocalVar5838 = weightedAvg5535;
				else
				ifLocalVar5838 = temp_output_6041_0;
				float3 ifLocalVar6148 = 0;
				UNITY_BRANCH 
				if( _Texture_11_Normal_Index <= -1.0 )
				ifLocalVar6148 = EmptyNRM6172;
				else
				ifLocalVar6148 = ifLocalVar5838;
				half3 Normal_114948 = ifLocalVar6148;
				float4 texArray4870 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4849_0, _Texture_12_Normal_Index );
				float2 appendResult11_g1068 = (float2(texArray4870.w , texArray4870.y));
				float2 temp_output_4_0_g1068 = ( ( ( appendResult11_g1068 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_12_Normal_Power );
				float2 break8_g1068 = temp_output_4_0_g1068;
				float dotResult5_g1068 = dot( temp_output_4_0_g1068 , temp_output_4_0_g1068 );
				float temp_output_9_0_g1068 = sqrt( ( 1.0 - saturate( dotResult5_g1068 ) ) );
				float3 appendResult20_g1068 = (float3(break8_g1068.x , break8_g1068.y , temp_output_9_0_g1068));
				float3 temp_output_6038_0 = appendResult20_g1068;
				float4 texArray4850 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4758_0, _Texture_12_Normal_Index );
				float2 appendResult11_g1049 = (float2(texArray4850.w , texArray4850.y));
				float2 temp_output_4_0_g1049 = ( ( ( appendResult11_g1049 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_12_Normal_Power * -1.0 ) );
				float2 break8_g1049 = temp_output_4_0_g1049;
				float dotResult5_g1049 = dot( temp_output_4_0_g1049 , temp_output_4_0_g1049 );
				float temp_output_9_0_g1049 = sqrt( ( 1.0 - saturate( dotResult5_g1049 ) ) );
				float3 appendResult21_g1049 = (float3(break8_g1049.y , break8_g1049.x , temp_output_9_0_g1049));
				float3 appendResult5956 = (float3(WorldSpaceNormal.x , -1.0 , 1.0));
				float4 texArray4852 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4830_0, _Texture_12_Normal_Index );
				float2 appendResult11_g1057 = (float2(texArray4852.w , texArray4852.y));
				float2 temp_output_4_0_g1057 = ( ( ( appendResult11_g1057 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_12_Normal_Power );
				float2 break8_g1057 = temp_output_4_0_g1057;
				float dotResult5_g1057 = dot( temp_output_4_0_g1057 , temp_output_4_0_g1057 );
				float temp_output_9_0_g1057 = sqrt( ( 1.0 - saturate( dotResult5_g1057 ) ) );
				float3 appendResult20_g1057 = (float3(break8_g1057.x , break8_g1057.y , temp_output_9_0_g1057));
				float3 appendResult5959 = (float3(1.0 , ( WorldSpaceNormal.z * -1.0 ) , 1.0));
				float3 weightedBlendVar5539 = BlendComponents91;
				float3 weightedAvg5539 = ( ( weightedBlendVar5539.x*( appendResult21_g1049 * appendResult5956 ) + weightedBlendVar5539.y*temp_output_6038_0 + weightedBlendVar5539.z*( appendResult20_g1057 * appendResult5959 ) )/( weightedBlendVar5539.x + weightedBlendVar5539.y + weightedBlendVar5539.z ) );
				float3 ifLocalVar5834 = 0;
				UNITY_BRANCH 
				if( _Texture_12_Triplanar == 1.0 )
				ifLocalVar5834 = weightedAvg5539;
				else
				ifLocalVar5834 = temp_output_6038_0;
				float3 ifLocalVar6150 = 0;
				UNITY_BRANCH 
				if( _Texture_12_Normal_Index <= -1.0 )
				ifLocalVar6150 = EmptyNRM6172;
				else
				ifLocalVar6150 = ifLocalVar5834;
				half3 Normal_124962 = ifLocalVar6150;
				float4 layeredBlendVar5641 = tex2DNode4370;
				float3 layeredBlend5641 = ( lerp( lerp( lerp( lerp( layeredBlend5640 , Normal_94897 , layeredBlendVar5641.x ) , Normal_104918 , layeredBlendVar5641.y ) , Normal_114948 , layeredBlendVar5641.z ) , Normal_124962 , layeredBlendVar5641.w ) );
				float4 texArray5120 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5037_0, _Texture_13_Normal_Index );
				float2 appendResult11_g1076 = (float2(texArray5120.w , texArray5120.y));
				float2 temp_output_4_0_g1076 = ( ( ( appendResult11_g1076 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_13_Normal_Power );
				float2 break8_g1076 = temp_output_4_0_g1076;
				float dotResult5_g1076 = dot( temp_output_4_0_g1076 , temp_output_4_0_g1076 );
				float temp_output_9_0_g1076 = sqrt( ( 1.0 - saturate( dotResult5_g1076 ) ) );
				float3 appendResult20_g1076 = (float3(break8_g1076.x , break8_g1076.y , temp_output_9_0_g1076));
				float3 temp_output_6035_0 = appendResult20_g1076;
				float4 texArray5127 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5025_0, _Texture_13_Normal_Index );
				float2 appendResult11_g1067 = (float2(texArray5127.w , texArray5127.y));
				float2 temp_output_4_0_g1067 = ( ( ( appendResult11_g1067 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_13_Normal_Power * -1.0 ) );
				float2 break8_g1067 = temp_output_4_0_g1067;
				float dotResult5_g1067 = dot( temp_output_4_0_g1067 , temp_output_4_0_g1067 );
				float temp_output_9_0_g1067 = sqrt( ( 1.0 - saturate( dotResult5_g1067 ) ) );
				float3 appendResult21_g1067 = (float3(break8_g1067.y , break8_g1067.x , temp_output_9_0_g1067));
				float3 appendResult5949 = (float3(WorldSpaceNormal.x , -1.0 , 1.0));
				float4 texArray5109 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5035_0, _Texture_13_Normal_Index );
				float2 appendResult11_g1069 = (float2(texArray5109.w , texArray5109.y));
				float2 temp_output_4_0_g1069 = ( ( ( appendResult11_g1069 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_13_Normal_Power );
				float2 break8_g1069 = temp_output_4_0_g1069;
				float dotResult5_g1069 = dot( temp_output_4_0_g1069 , temp_output_4_0_g1069 );
				float temp_output_9_0_g1069 = sqrt( ( 1.0 - saturate( dotResult5_g1069 ) ) );
				float3 appendResult20_g1069 = (float3(break8_g1069.x , break8_g1069.y , temp_output_9_0_g1069));
				float3 appendResult5952 = (float3(1.0 , ( WorldSpaceNormal.z * -1.0 ) , 1.0));
				float3 weightedBlendVar5543 = BlendComponents91;
				float3 weightedAvg5543 = ( ( weightedBlendVar5543.x*( appendResult21_g1067 * appendResult5949 ) + weightedBlendVar5543.y*temp_output_6035_0 + weightedBlendVar5543.z*( appendResult20_g1069 * appendResult5952 ) )/( weightedBlendVar5543.x + weightedBlendVar5543.y + weightedBlendVar5543.z ) );
				float3 ifLocalVar5830 = 0;
				UNITY_BRANCH 
				if( _Texture_13_Triplanar == 1.0 )
				ifLocalVar5830 = weightedAvg5543;
				else
				ifLocalVar5830 = temp_output_6035_0;
				float3 ifLocalVar6152 = 0;
				UNITY_BRANCH 
				if( _Texture_13_Normal_Index <= -1.0 )
				ifLocalVar6152 = EmptyNRM6172;
				else
				ifLocalVar6152 = ifLocalVar5830;
				half3 Normal_135059 = ifLocalVar6152;
				float4 texArray5178 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5022_0, _Texture_14_Normal_Index );
				float2 appendResult11_g1074 = (float2(texArray5178.w , texArray5178.y));
				float2 temp_output_4_0_g1074 = ( ( ( appendResult11_g1074 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_14_Normal_Power );
				float2 break8_g1074 = temp_output_4_0_g1074;
				float dotResult5_g1074 = dot( temp_output_4_0_g1074 , temp_output_4_0_g1074 );
				float temp_output_9_0_g1074 = sqrt( ( 1.0 - saturate( dotResult5_g1074 ) ) );
				float3 appendResult20_g1074 = (float3(break8_g1074.x , break8_g1074.y , temp_output_9_0_g1074));
				float3 temp_output_6032_0 = appendResult20_g1074;
				float4 texArray5017 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5009_0, _Texture_14_Normal_Index );
				float2 appendResult11_g1064 = (float2(texArray5017.w , texArray5017.y));
				float2 temp_output_4_0_g1064 = ( ( ( appendResult11_g1064 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_14_Normal_Power * -1.0 ) );
				float2 break8_g1064 = temp_output_4_0_g1064;
				float dotResult5_g1064 = dot( temp_output_4_0_g1064 , temp_output_4_0_g1064 );
				float temp_output_9_0_g1064 = sqrt( ( 1.0 - saturate( dotResult5_g1064 ) ) );
				float3 appendResult21_g1064 = (float3(break8_g1064.y , break8_g1064.x , temp_output_9_0_g1064));
				float3 appendResult5942 = (float3(WorldSpaceNormal.x , -1.0 , 1.0));
				float4 texArray5170 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5010_0, _Texture_14_Normal_Index );
				float2 appendResult11_g1063 = (float2(texArray5170.w , texArray5170.y));
				float2 temp_output_4_0_g1063 = ( ( ( appendResult11_g1063 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_14_Normal_Power );
				float2 break8_g1063 = temp_output_4_0_g1063;
				float dotResult5_g1063 = dot( temp_output_4_0_g1063 , temp_output_4_0_g1063 );
				float temp_output_9_0_g1063 = sqrt( ( 1.0 - saturate( dotResult5_g1063 ) ) );
				float3 appendResult20_g1063 = (float3(break8_g1063.x , break8_g1063.y , temp_output_9_0_g1063));
				float3 appendResult5945 = (float3(1.0 , ( WorldSpaceNormal.z * -1.0 ) , 1.0));
				float3 weightedBlendVar5547 = BlendComponents91;
				float3 weightedAvg5547 = ( ( weightedBlendVar5547.x*( appendResult21_g1064 * appendResult5942 ) + weightedBlendVar5547.y*temp_output_6032_0 + weightedBlendVar5547.z*( appendResult20_g1063 * appendResult5945 ) )/( weightedBlendVar5547.x + weightedBlendVar5547.y + weightedBlendVar5547.z ) );
				float3 ifLocalVar5826 = 0;
				UNITY_BRANCH 
				if( _Texture_14_Triplanar == 1.0 )
				ifLocalVar5826 = weightedAvg5547;
				else
				ifLocalVar5826 = temp_output_6032_0;
				float3 ifLocalVar6154 = 0;
				UNITY_BRANCH 
				if( _Texture_14_Normal_Index <= -1.0 )
				ifLocalVar6154 = EmptyNRM6172;
				else
				ifLocalVar6154 = ifLocalVar5826;
				half3 Normal_145196 = ifLocalVar6154;
				float4 texArray5246 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5226_0, _Texture_15_Normal_Index );
				float2 appendResult11_g1073 = (float2(texArray5246.w , texArray5246.y));
				float2 temp_output_4_0_g1073 = ( ( ( appendResult11_g1073 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_15_Normal_Power );
				float2 break8_g1073 = temp_output_4_0_g1073;
				float dotResult5_g1073 = dot( temp_output_4_0_g1073 , temp_output_4_0_g1073 );
				float temp_output_9_0_g1073 = sqrt( ( 1.0 - saturate( dotResult5_g1073 ) ) );
				float3 appendResult20_g1073 = (float3(break8_g1073.x , break8_g1073.y , temp_output_9_0_g1073));
				float3 temp_output_6029_0 = appendResult20_g1073;
				float4 texArray5227 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5213_0, _Texture_15_Normal_Index );
				float2 appendResult11_g1071 = (float2(texArray5227.w , texArray5227.y));
				float2 temp_output_4_0_g1071 = ( ( ( appendResult11_g1071 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_15_Normal_Power * -1.0 ) );
				float2 break8_g1071 = temp_output_4_0_g1071;
				float dotResult5_g1071 = dot( temp_output_4_0_g1071 , temp_output_4_0_g1071 );
				float temp_output_9_0_g1071 = sqrt( ( 1.0 - saturate( dotResult5_g1071 ) ) );
				float3 appendResult21_g1071 = (float3(break8_g1071.y , break8_g1071.x , temp_output_9_0_g1071));
				float3 appendResult5935 = (float3(WorldSpaceNormal.x , -1.0 , 1.0));
				float4 texArray5250 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5224_0, _Texture_15_Normal_Index );
				float2 appendResult11_g1072 = (float2(texArray5250.w , texArray5250.y));
				float2 temp_output_4_0_g1072 = ( ( ( appendResult11_g1072 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_15_Normal_Power );
				float2 break8_g1072 = temp_output_4_0_g1072;
				float dotResult5_g1072 = dot( temp_output_4_0_g1072 , temp_output_4_0_g1072 );
				float temp_output_9_0_g1072 = sqrt( ( 1.0 - saturate( dotResult5_g1072 ) ) );
				float3 appendResult20_g1072 = (float3(break8_g1072.x , break8_g1072.y , temp_output_9_0_g1072));
				float3 appendResult5938 = (float3(1.0 , ( WorldSpaceNormal.z * -1.0 ) , 1.0));
				float3 weightedBlendVar5551 = BlendComponents91;
				float3 weightedAvg5551 = ( ( weightedBlendVar5551.x*( appendResult21_g1071 * appendResult5935 ) + weightedBlendVar5551.y*temp_output_6029_0 + weightedBlendVar5551.z*( appendResult20_g1072 * appendResult5938 ) )/( weightedBlendVar5551.x + weightedBlendVar5551.y + weightedBlendVar5551.z ) );
				float3 ifLocalVar5822 = 0;
				UNITY_BRANCH 
				if( _Texture_15_Triplanar == 1.0 )
				ifLocalVar5822 = weightedAvg5551;
				else
				ifLocalVar5822 = temp_output_6029_0;
				float3 ifLocalVar6156 = 0;
				UNITY_BRANCH 
				if( _Texture_15_Normal_Index <= -1.0 )
				ifLocalVar6156 = EmptyNRM6172;
				else
				ifLocalVar6156 = ifLocalVar5822;
				half3 Normal_155280 = ifLocalVar6156;
				float4 texArray5099 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5083_0, _Texture_16_Normal_Index );
				float2 appendResult11_g1075 = (float2(texArray5099.w , texArray5099.y));
				float2 temp_output_4_0_g1075 = ( ( ( appendResult11_g1075 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_16_Normal_Power );
				float2 break8_g1075 = temp_output_4_0_g1075;
				float dotResult5_g1075 = dot( temp_output_4_0_g1075 , temp_output_4_0_g1075 );
				float temp_output_9_0_g1075 = sqrt( ( 1.0 - saturate( dotResult5_g1075 ) ) );
				float3 appendResult20_g1075 = (float3(break8_g1075.x , break8_g1075.y , temp_output_9_0_g1075));
				float3 temp_output_6026_0 = appendResult20_g1075;
				float4 texArray5082 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5079_0, _Texture_16_Normal_Index );
				float2 appendResult11_g1070 = (float2(texArray5082.w , texArray5082.y));
				float2 temp_output_4_0_g1070 = ( ( ( appendResult11_g1070 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_16_Normal_Power * -1.0 ) );
				float2 break8_g1070 = temp_output_4_0_g1070;
				float dotResult5_g1070 = dot( temp_output_4_0_g1070 , temp_output_4_0_g1070 );
				float temp_output_9_0_g1070 = sqrt( ( 1.0 - saturate( dotResult5_g1070 ) ) );
				float3 appendResult21_g1070 = (float3(break8_g1070.y , break8_g1070.x , temp_output_9_0_g1070));
				float3 appendResult5928 = (float3(WorldSpaceNormal.x , -1.0 , 1.0));
				float4 texArray4731 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5085_0, _Texture_16_Normal_Index );
				float2 appendResult11_g1061 = (float2(texArray4731.w , texArray4731.y));
				float2 temp_output_4_0_g1061 = ( ( ( appendResult11_g1061 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_16_Normal_Power );
				float2 break8_g1061 = temp_output_4_0_g1061;
				float dotResult5_g1061 = dot( temp_output_4_0_g1061 , temp_output_4_0_g1061 );
				float temp_output_9_0_g1061 = sqrt( ( 1.0 - saturate( dotResult5_g1061 ) ) );
				float3 appendResult20_g1061 = (float3(break8_g1061.x , break8_g1061.y , temp_output_9_0_g1061));
				float3 appendResult5931 = (float3(1.0 , ( WorldSpaceNormal.z * -1.0 ) , 1.0));
				float3 weightedBlendVar5555 = BlendComponents91;
				float3 weightedAvg5555 = ( ( weightedBlendVar5555.x*( appendResult21_g1070 * appendResult5928 ) + weightedBlendVar5555.y*temp_output_6026_0 + weightedBlendVar5555.z*( appendResult20_g1061 * appendResult5931 ) )/( weightedBlendVar5555.x + weightedBlendVar5555.y + weightedBlendVar5555.z ) );
				float3 ifLocalVar5818 = 0;
				UNITY_BRANCH 
				if( _Texture_16_Triplanar == 1.0 )
				ifLocalVar5818 = weightedAvg5555;
				else
				ifLocalVar5818 = temp_output_6026_0;
				float3 ifLocalVar6158 = 0;
				UNITY_BRANCH 
				if( _Texture_16_Normal_Index <= -1.0 )
				ifLocalVar6158 = EmptyNRM6172;
				else
				ifLocalVar6158 = ifLocalVar5818;
				half3 Normal_164696 = ifLocalVar6158;
				float4 layeredBlendVar5642 = tex2DNode4371;
				float3 layeredBlend5642 = ( lerp( lerp( lerp( lerp( layeredBlend5641 , Normal_135059 , layeredBlendVar5642.x ) , Normal_145196 , layeredBlendVar5642.y ) , Normal_155280 , layeredBlendVar5642.z ) , Normal_164696 , layeredBlendVar5642.w ) );
				float3 normalizeResult3900 = normalize( layeredBlend5642 );
				float4 texArray4382 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3893_0, _Texture_Snow_Normal_Index );
				float2 appendResult11_g1077 = (float2(texArray4382.w , texArray4382.y));
				float2 temp_output_4_0_g1077 = ( ( ( appendResult11_g1077 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Snow_Normal_Scale );
				float2 break8_g1077 = temp_output_4_0_g1077;
				float dotResult5_g1077 = dot( temp_output_4_0_g1077 , temp_output_4_0_g1077 );
				float temp_output_9_0_g1077 = sqrt( ( 1.0 - saturate( dotResult5_g1077 ) ) );
				float3 appendResult20_g1077 = (float3(break8_g1077.x , break8_g1077.y , temp_output_9_0_g1077));
				float3 ifLocalVar6166 = 0;
				UNITY_BRANCH 
				if( _Texture_Snow_Normal_Index <= -1.0 )
				ifLocalVar6166 = EmptyNRM6172;
				else
				ifLocalVar6166 = appendResult20_g1077;
				float simplePerlin2D6331 = snoise( ( Top_Bottom1999 * _Snow_Noise_Tiling ) );
				float clampResult6340 = clamp( simplePerlin2D6331 , 0.0 , 1.0 );
				float lerpResult4310 = lerp( 1.0 , clampResult6340 , _Snow_Noise_Power);
				float clampResult4302 = clamp( ( lerpResult4310 * _Snow_Amount ) , 0.4 , 1.0 );
				float clampResult1354 = clamp( WorldSpaceNormal.y , 0.0 , 0.9999 );
				float temp_output_1349_0 = ( _Snow_Maximum_Angle / 90.0 );
				float clampResult1347 = clamp( ( clampResult1354 - ( 1.0 - temp_output_1349_0 ) ) , 0.0 , 2.0 );
				half SnowSlope1352 = pow( ( 1.0 - ( clampResult1347 * ( 1.0 / temp_output_1349_0 ) ) ) , _Snow_Maximum_Angle_Hardness );
				float clampResult4146 = clamp( SnowSlope1352 , 0.0 , 1.0 );
				float lerpResult4293 = lerp( ( _Snow_Amount * clampResult4302 ) , 0.0 , clampResult4146);
				float temp_output_3751_0 = ( ( 1.0 - _Snow_Min_Height ) + WorldSpacePosition.y );
				float clampResult4220 = clamp( ( temp_output_3751_0 + 1.0 ) , 0.0 , 1.0 );
				float clampResult4260 = clamp( ( ( 1.0 - ( ( temp_output_3751_0 + _Snow_Min_Height_Blending ) / temp_output_3751_0 ) ) + -0.5 ) , 0.0 , 1.0 );
				float clampResult4263 = clamp( ( clampResult4220 + clampResult4260 ) , 0.0 , 1.0 );
				float lerpResult3759 = lerp( 0.0 , lerpResult4293 , clampResult4263);
				float clampResult4298 = clamp( lerpResult3759 , 0.0 , 1.0 );
				float temp_output_3708_0 = saturate( ( ( clampResult4298 / 1.5 ) * _Snow_Amount ) );
				float3 lerpResult5703 = lerp( normalizeResult3900 , ifLocalVar6166 , ( _Snow_Blend_Normal * temp_output_3708_0 ));
				float HeightMask5474 = saturate(pow(((( ( normalizeResult3900.y + 1.0 ) * 0.5 )*temp_output_3708_0)*4)+(temp_output_3708_0*2),5.0));
				float3 lerpResult3902 = lerp( normalizeResult3900 , lerpResult5703 , HeightMask5474);
				float3 tanToWorld0 = float3( WorldSpaceTangent.x, WorldSpaceBiTangent.x, WorldSpaceNormal.x );
				float3 tanToWorld1 = float3( WorldSpaceTangent.y, WorldSpaceBiTangent.y, WorldSpaceNormal.y );
				float3 tanToWorld2 = float3( WorldSpaceTangent.z, WorldSpaceBiTangent.z, WorldSpaceNormal.z );
				float3 tanNormal3706 = lerpResult3902;
				float3 worldNormal3706 = float3(dot(tanToWorld0,tanNormal3706), dot(tanToWorld1,tanNormal3706), dot(tanToWorld2,tanNormal3706));
				float lerpResult4350 = lerp( normalizeResult3900.y , worldNormal3706.y , pow( clampResult4298 , 2.0 ));
				float clampResult4299 = clamp( ( lerpResult4350 * clampResult4298 ) , 0.0 , 1.0 );
				float clampResult3702 = clamp( pow( ( ( ( _Texture_16_Snow_Reduction * Splat4_A2546 ) + ( ( _Texture_15_Snow_Reduction * Splat4_B2545 ) + ( ( ( _Texture_13_Snow_Reduction * Splat4_R2543 ) + ( ( _Texture_12_Snow_Reduction * Splat3_A2540 ) + ( ( _Texture_11_Snow_Reduction * Splat3_B2539 ) + ( ( ( _Texture_9_Snow_Reduction * Splat3_R2537 ) + ( ( _Texture_8_Snow_Reduction * Splat2_A2109 ) + ( ( _Texture_7_Snow_Reduction * Splat2_B2108 ) + ( ( ( _Texture_5_Snow_Reduction * Splat2_R2106 ) + ( ( _Texture_1_Snow_Reduction * Splat1_R1438 ) + ( ( _Texture_2_Snow_Reduction * Splat1_G1441 ) + ( ( _Texture_3_Snow_Reduction * Splat1_B1442 ) + ( _Texture_4_Snow_Reduction * Splat1_A1491 ) ) ) ) ) + ( _Texture_6_Snow_Reduction * Splat2_G2107 ) ) ) ) ) + ( _Texture_10_Snow_Reduction * Splat3_G2538 ) ) ) ) ) + ( _Texture_14_Snow_Reduction * Splat4_G2544 ) ) ) ) * ( lerpResult4310 * 5.0 ) ) , 3.0 ) , 0.0 , 1.0 );
				float lerpResult3742 = lerp( saturate( clampResult4299 ) , 0.0 , clampResult3702);
				float3 lerpResult1356 = lerp( clampResult5715 , ( appendResult1410 + temp_output_6306_0 ) , lerpResult3742);
				
				float4 texArray5480 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, ( Top_Bottom1999 / _Perlin_Normal_Tiling_Close ), (float)_Texture_Perlin_Normal_Index );
				float2 appendResult11_g1078 = (float2(texArray5480.w , texArray5480.y));
				float2 temp_output_4_0_g1078 = ( ( ( appendResult11_g1078 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Perlin_Normal_Power_Close );
				float2 break8_g1078 = temp_output_4_0_g1078;
				float dotResult5_g1078 = dot( temp_output_4_0_g1078 , temp_output_4_0_g1078 );
				float temp_output_9_0_g1078 = sqrt( ( 1.0 - saturate( dotResult5_g1078 ) ) );
				float3 appendResult20_g1078 = (float3(break8_g1078.x , break8_g1078.y , temp_output_9_0_g1078));
				float4 texArray4374 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, ( Top_Bottom1999 / _Perlin_Normal_Tiling_Far ), (float)_Texture_Perlin_Normal_Index );
				float2 appendResult11_g1079 = (float2(texArray4374.w , texArray4374.y));
				float2 temp_output_4_0_g1079 = ( ( ( appendResult11_g1079 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Perlin_Normal_Power );
				float2 break8_g1079 = temp_output_4_0_g1079;
				float dotResult5_g1079 = dot( temp_output_4_0_g1079 , temp_output_4_0_g1079 );
				float temp_output_9_0_g1079 = sqrt( ( 1.0 - saturate( dotResult5_g1079 ) ) );
				float3 appendResult20_g1079 = (float3(break8_g1079.x , break8_g1079.y , temp_output_9_0_g1079));
				float3 lerpResult5460 = lerp( appendResult20_g1078 , appendResult20_g1079 , UVmixDistance636);
				float clampResult3775 = clamp( ( ( _Texture_16_Perlin_Power * Splat4_A2546 ) + ( ( _Texture_15_Perlin_Power * Splat4_B2545 ) + ( ( _Texture_14_Perlin_Power * Splat4_G2544 ) + ( ( _Texture_13_Perlin_Power * Splat4_R2543 ) + ( ( _Texture_12_Perlin_Power * Splat3_A2540 ) + ( ( _Texture_11_Perlin_Power * Splat3_B2539 ) + ( ( _Texture_10_Perlin_Power * Splat3_G2538 ) + ( ( _Texture_9_Perlin_Power * Splat3_R2537 ) + ( ( _Texture_8_Perlin_Power * Splat2_A2109 ) + ( ( _Texture_7_Perlin_Power * Splat2_B2108 ) + ( ( _Texture_6_Perlin_Power * Splat2_G2107 ) + ( ( _Texture_5_Perlin_Power * Splat2_R2106 ) + ( ( _Texture_1_Perlin_Power * Splat1_R1438 ) + ( ( _Texture_2_Perlin_Power * Splat1_G1441 ) + ( ( _Texture_4_Perlin_Power * Splat1_A1491 ) + ( _Texture_3_Perlin_Power * Splat1_B1442 ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) , 0.0 , 1.0 );
				float3 lerpResult3776 = lerp( float3( 0,0,1 ) , lerpResult5460 , clampResult3775);
				float3 lerpResult3906 = lerp( float3( 0,0,1 ) , lerpResult5460 , ( _Snow_Perlin_Power * 0.5 ));
				float3 lerpResult5722 = lerp( lerpResult3776 , lerpResult3906 , lerpResult3742);
				float3 lerpResult3741 = lerp( lerpResult3902 , normalizeResult3900 , clampResult3702);
				float3 lerpResult939 = lerp( lerpResult3741 , UnpackNormalScale( tex2D( _Global_Normal_Map, uv02588 ), _Global_Normalmap_Power ) , UVmixDistance636);
				float3 normalizeResult3901 = normalize( lerpResult939 );
				float3 temp_output_4100_0 = BlendNormal( lerpResult5722 , normalizeResult3901 );
				
				float3 clampResult5471 = clamp( appendResult1410 , float3( 0,0,0 ) , float3( 0.5,0.5,0.5 ) );
				float3 temp_cast_4 = (_Glitter_Specular).xxx;
				float clampResult6307 = clamp( temp_output_6306_0 , 0.0 , 1.0 );
				float3 lerpResult6309 = lerp( ( clampResult5471 * _Snow_Specular ) , temp_cast_4 , clampResult6307);
				float3 lerpResult4040 = lerp( ( ( appendResult3857 * float3( 0.3,0.3,0.3 ) ) * _Terrain_Specular ) , lerpResult6309 , lerpResult3742);
				
				float lerpResult6308 = lerp( break1409.w , _Glitter_Smoothness , clampResult6307);
				float lerpResult3951 = lerp( ( break3856.w * _Terrain_Smoothness ) , lerpResult6308 , lerpResult3742);
				
				float clampResult5699 = clamp( ( ( 1.0 + temp_output_4100_0.y ) * 0.5 ) , ( 1.0 - _Ambient_Occlusion_Power ) , 1.0 );
				#ifdef _USE_AO_ON
				float staticSwitch6192 = clampResult5699;
				#else
				float staticSwitch6192 = 1.0;
				#endif
				
				float2 uv_TerrainHolesTexture = IN.ase_texcoord7.xy * _TerrainHolesTexture_ST.xy + _TerrainHolesTexture_ST.zw;
				float clampResult6254 = clamp( ( WorldSpacePosition.y + ( 0.0 - _Remove_Vert_Height ) ) , 0.0 , 1.0 );
				
				
		        float3 Albedo = lerpResult1356;
				float3 Normal = temp_output_4100_0;
				float3 Emission = 0;
				float3 Specular = lerpResult4040;
				float Metallic = 0;
				float Smoothness = lerpResult3951;
				float Occlusion = staticSwitch6192;
				float Alpha = ( tex2D( _TerrainHolesTexture, uv_TerrainHolesTexture ).r * clampResult6254 );
				

				float AlphaClipThreshold = 0.5;
				clip(Alpha-AlphaClipThreshold);

        		InputData inputData;
        		inputData.positionWS = WorldSpacePosition;

        #ifdef _NORMALMAP
        	    inputData.normalWS = normalize(TransformTangentToWorld(Normal, half3x3(WorldSpaceTangent, WorldSpaceBiTangent, WorldSpaceNormal)));
        #else
            #if !SHADER_HINT_NICE_QUALITY
                inputData.normalWS = WorldSpaceNormal;
            #else
        	    inputData.normalWS = normalize(WorldSpaceNormal);
            #endif
        #endif

        #if !SHADER_HINT_NICE_QUALITY
        	    // viewDirection should be normalized here, but we avoid doing it as it's close enough and we save some ALU.
        	    inputData.viewDirectionWS = WorldSpaceViewDirection;
        #else
        	    inputData.viewDirectionWS = normalize(WorldSpaceViewDirection);
        #endif

        	    inputData.shadowCoord = IN.shadowCoord;
				#if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
				inputData.shadowCoord = IN.shadowCoord;
#elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
				inputData.shadowCoord = TransformWorldToShadowCoord(WorldSpacePosition);
#else
				inputData.shadowCoord = float4(0, 0, 0, 0);
#endif
        	    inputData.fogCoord = IN.fogFactorAndVertexLight.x;
        	    inputData.vertexLighting = IN.fogFactorAndVertexLight.yzw;
        	    inputData.bakedGI = SAMPLE_GI(IN.lightmapUVOrVertexSH.xy, IN.lightmapUVOrVertexSH.xyz, inputData.normalWS);

        		half4 color = UniversalFragmentPBR(
        			inputData, 
        			Albedo, 
        			Metallic, 
        			Specular, 
        			Smoothness, 
        			Occlusion, 
        			Emission, 
        			Alpha);

			#ifdef TERRAIN_SPLAT_ADDPASS
				color.rgb = MixFogColor(color.rgb, half3( 0, 0, 0 ), IN.fogFactorAndVertexLight.x );
			#else
				color.rgb = MixFog(color.rgb, IN.fogFactorAndVertexLight.x);
			#endif



		#if ASE_LW_FINAL_COLOR_ALPHA_MULTIPLY
				color.rgb *= color.a;
		#endif
        		return color;
            }

        	ENDHLSL
        }

		
        Pass
        {
			
        	Name "ShadowCaster"
            Tags { "LightMode"="ShadowCaster" }

			ZWrite On
			ZTest LEqual

            HLSLPROGRAM
            
            // Required to compile gles 2.0 with standard srp library
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x
            

            //--------------------------------------
            // GPU Instancing
            #pragma multi_compile_instancing

            #pragma vertex ShadowPassVertex
            #pragma fragment ShadowPassFragment

            #define ASE_SRP_VERSION 60900
            #include "TerrainVertexCTS.hlsl"
            #pragma instancing_options assumeuniformscaling nomatrices nolightprobe nolightmap


            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"

            struct GraphVertexInput
            {
                float4 vertex : POSITION;
                float3 ase_normal : NORMAL;
				float4 ase_tangent : TANGENT;
				float4 ase_texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

			sampler2D _TerrainHolesTexture;
			float4 _TerrainHolesTexture_ST;
			half _Remove_Vert_Height;

        	struct VertexOutput
        	{
        	    float4 clipPos      : SV_POSITION;
                float4 ase_texcoord7 : TEXCOORD7;
                float4 ase_texcoord8 : TEXCOORD8;
                UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
        	};

			
            // x: global clip space bias, y: normal world space bias
            float3 _LightDirection;

            VertexOutput ShadowPassVertex(GraphVertexInput v )
        	{
        	    VertexOutput o;
        	    UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);
				TerrainInstancing(v.vertex, v.ase_normal);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO (o);

				float3 localCalculateTangentsSRP6339 = ( ( v.ase_tangent.xyz * 0.0 ) );
				v.ase_tangent.xyz = cross ( v.ase_normal, float3( 0, 0, 1 ) );
				v.ase_tangent.w = -1;
				
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				o.ase_texcoord8.xyz = ase_worldPos;
				
				o.ase_texcoord7.xy = v.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord7.zw = 0;
				o.ase_texcoord8.w = 0;
				float3 vertexValue = localCalculateTangentsSRP6339;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
				v.vertex.xyz = vertexValue;
				#else
				v.vertex.xyz += vertexValue;
				#endif

				v.ase_normal =  v.ase_normal ;

        	    float3 positionWS = TransformObjectToWorld(v.vertex.xyz);
                float3 normalWS = TransformObjectToWorldDir(v.ase_normal);

                float invNdotL = 1.0 - saturate(dot(_LightDirection, normalWS));
                float scale = invNdotL * _ShadowBias.y;

                // normal bias is negative since we want to apply an inset normal offset
                positionWS = _LightDirection * _ShadowBias.xxx + positionWS;
				positionWS = normalWS * scale.xxx + positionWS;
                float4 clipPos = TransformWorldToHClip(positionWS);

                // _ShadowBias.x sign depens on if platform has reversed z buffer
                //clipPos.z += _ShadowBias.x;

        	#if UNITY_REVERSED_Z
        	    clipPos.z = min(clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE);
        	#else
        	    clipPos.z = max(clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE);
        	#endif
                o.clipPos = clipPos;

        	    return o;
        	}

            half4 ShadowPassFragment(VertexOutput IN  ) : SV_TARGET
            {
                UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(IN);

               float2 uv_TerrainHolesTexture = IN.ase_texcoord7.xy * _TerrainHolesTexture_ST.xy + _TerrainHolesTexture_ST.zw;
               float3 ase_worldPos = IN.ase_texcoord8.xyz;
               float clampResult6254 = clamp( ( ase_worldPos.y + ( 0.0 - _Remove_Vert_Height ) ) , 0.0 , 1.0 );
               

				float Alpha = ( tex2D( _TerrainHolesTexture, uv_TerrainHolesTexture ).r * clampResult6254 );
				float AlphaClipThreshold = 0.5;
				clip(Alpha-AlphaClipThreshold);


                return 0;
            }

            ENDHLSL
        }

		
        Pass
        {
			
        	Name "DepthOnly"
            Tags { "LightMode"="DepthOnly" }

            ZWrite On
			ColorMask 0

            HLSLPROGRAM
            
            // Required to compile gles 2.0 with standard srp library
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x

            //--------------------------------------
            // GPU Instancing
            #pragma multi_compile_instancing

            #pragma vertex vert
            #pragma fragment frag

            #define ASE_SRP_VERSION 60900
            #include "TerrainVertexCTS.hlsl"
            #pragma instancing_options assumeuniformscaling nomatrices nolightprobe nolightmap


            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"

			sampler2D _TerrainHolesTexture;
			float4 _TerrainHolesTexture_ST;
			half _Remove_Vert_Height;

            struct GraphVertexInput
            {
                float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 ase_tangent : TANGENT;
				float4 ase_texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

        	struct VertexOutput
        	{
        	    float4 clipPos      : SV_POSITION;
                float4 ase_texcoord : TEXCOORD0;
                float4 ase_texcoord1 : TEXCOORD1;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                UNITY_VERTEX_OUTPUT_STEREO
        	};

			           

            VertexOutput vert(GraphVertexInput v  )
            {
                VertexOutput o = (VertexOutput)0;
        	    UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				TerrainInstancing(v.vertex, v.ase_normal);
				float3 localCalculateTangentsSRP6339 = ( ( v.ase_tangent.xyz * 0.0 ) );
				v.ase_tangent.xyz = cross ( v.ase_normal, float3( 0, 0, 1 ) );
				v.ase_tangent.w = -1;
				
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				o.ase_texcoord1.xyz = ase_worldPos;
				
				o.ase_texcoord.xy = v.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord.zw = 0;
				o.ase_texcoord1.w = 0;
				float3 vertexValue = localCalculateTangentsSRP6339;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
				v.vertex.xyz = vertexValue;
				#else
				v.vertex.xyz += vertexValue;
				#endif

				v.ase_normal =  v.ase_normal ;

        	    o.clipPos = TransformObjectToHClip(v.vertex.xyz);
        	    return o;
            }

            half4 frag(VertexOutput IN  ) : SV_TARGET
            {
                UNITY_SETUP_INSTANCE_ID(IN);

				float2 uv_TerrainHolesTexture = IN.ase_texcoord.xy * _TerrainHolesTexture_ST.xy + _TerrainHolesTexture_ST.zw;
				float3 ase_worldPos = IN.ase_texcoord1.xyz;
				float clampResult6254 = clamp( ( ase_worldPos.y + ( 0.0 - _Remove_Vert_Height ) ) , 0.0 , 1.0 );
				

				float Alpha = ( tex2D( _TerrainHolesTexture, uv_TerrainHolesTexture ).r * clampResult6254 );
	
				float AlphaClipThreshold = 0.5;
				clip(Alpha-AlphaClipThreshold);


                return 0;
            }
            ENDHLSL
        }

        // This pass it not used during regular rendering, only for lightmap baking.
		
        Pass
        {
			
        	Name "Meta"
            Tags { "LightMode"="Meta" }

            Cull Off

            HLSLPROGRAM
            
            // Required to compile gles 2.0 with standard srp library
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x

            #pragma vertex vert
            #pragma fragment frag

            #define ASE_SRP_VERSION 60900
            #include "TerrainVertexCTS.hlsl"
            #pragma instancing_options assumeuniformscaling nomatrices nolightprobe nolightmap


			uniform float4 _MainTex_ST;
			
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/MetaInput.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"

			half _Global_Color_Map_Close_Power;
			half _Global_Color_Map_Far_Power;
			half _UV_Mix_Start_Distance;
			half _UV_Mix_Power;
			sampler2D _Global_Color_Map;
			float2 _Global_Color_Map_Offset;
			float _Global_Color_Map_Scale;
			half _Global_Color_Opacity_Power;
			sampler2D _Texture_Splat_4;
			sampler2D _Texture_Splat_3;
			sampler2D _Texture_Splat_2;
			sampler2D _Texture_Splat_1;
			half _Texture_1_Albedo_Index;
			half _Texture_1_Triplanar;
			TEXTURE2D_ARRAY( _Texture_Array_Albedo );
			uniform SAMPLER( sampler_Texture_Array_Albedo );
			float _Texture_1_Tiling;
			half _Texture_1_Far_Multiplier;
			half4 _Texture_1_Color;
			float _Texture_2_Albedo_Index;
			float _Texture_2_Triplanar;
			half _Texture_2_Tiling;
			half _Texture_2_Far_Multiplier;
			half4 _Texture_2_Color;
			float _Texture_3_Albedo_Index;
			float _Texture_3_Triplanar;
			half _Texture_3_Tiling;
			half _Texture_3_Far_Multiplier;
			half4 _Texture_3_Color;
			float _Texture_4_Albedo_Index;
			float _Texture_4_Triplanar;
			half _Texture_4_Tiling;
			half _Texture_4_Far_Multiplier;
			half4 _Texture_4_Color;
			float _Texture_5_Albedo_Index;
			float _Texture_5_Triplanar;
			half _Texture_5_Tiling;
			half _Texture_5_Far_Multiplier;
			half4 _Texture_5_Color;
			float _Texture_6_Albedo_Index;
			float _Texture_6_Triplanar;
			half _Texture_6_Tiling;
			half _Texture_6_Far_Multiplier;
			half4 _Texture_6_Color;
			float _Texture_7_Albedo_Index;
			float _Texture_7_Triplanar;
			half _Texture_7_Tiling;
			half _Texture_7_Far_Multiplier;
			half4 _Texture_7_Color;
			float _Texture_8_Albedo_Index;
			float _Texture_8_Triplanar;
			half _Texture_8_Tiling;
			half _Texture_8_Far_Multiplier;
			half4 _Texture_8_Color;
			half _Texture_9_Albedo_Index;
			half _Texture_9_Triplanar;
			half _Texture_9_Tiling;
			half _Texture_9_Far_Multiplier;
			half4 _Texture_9_Color;
			half _Texture_10_Albedo_Index;
			half _Texture_10_Triplanar;
			half _Texture_10_Tiling;
			half _Texture_10_Far_Multiplier;
			half4 _Texture_10_Color;
			half _Texture_11_Albedo_Index;
			half _Texture_11_Triplanar;
			half _Texture_11_Tiling;
			half _Texture_11_Far_Multiplier;
			half4 _Texture_11_Color;
			half _Texture_12_Albedo_Index;
			half _Texture_12_Triplanar;
			half _Texture_12_Tiling;
			half _Texture_12_Far_Multiplier;
			half4 _Texture_12_Color;
			half _Texture_13_Albedo_Index;
			half _Texture_13_Triplanar;
			half _Texture_13_Tiling;
			half _Texture_13_Far_Multiplier;
			half4 _Texture_13_Color;
			half _Texture_14_Albedo_Index;
			half _Texture_14_Triplanar;
			half _Texture_14_Tiling;
			half _Texture_14_Far_Multiplier;
			half4 _Texture_14_Color;
			half _Texture_15_Albedo_Index;
			half _Texture_15_Triplanar;
			half _Texture_15_Tiling;
			half _Texture_15_Far_Multiplier;
			half4 _Texture_15_Color;
			half _Texture_16_Albedo_Index;
			half _Texture_16_Triplanar;
			half _Texture_16_Tiling;
			half _Texture_16_Far_Multiplier;
			half4 _Texture_16_Color;
			half _Geological_Map_Close_Power;
			sampler2D _Texture_Geological_Map;
			half _Geological_Map_Offset_Close;
			half _Geological_Tiling_Close;
			half _Geological_Map_Far_Power;
			half _Geological_Tiling_Far;
			half _Geological_Map_Offset_Far;
			half _Texture_16_Geological_Power;
			half _Texture_15_Geological_Power;
			half _Texture_14_Geological_Power;
			half _Texture_13_Geological_Power;
			half _Texture_12_Geological_Power;
			half _Texture_11_Geological_Power;
			half _Texture_10_Geological_Power;
			half _Texture_9_Geological_Power;
			half _Texture_8_Geological_Power;
			half _Texture_7_Geological_Power;
			half _Texture_6_Geological_Power;
			half _Texture_5_Geological_Power;
			half _Texture_1_Geological_Power;
			half _Texture_2_Geological_Power;
			half _Texture_4_Geological_Power;
			half _Texture_3_Geological_Power;
			half _Texture_Snow_Index;
			half _Snow_Tiling;
			half4 _Texture_Snow_Average;
			half4 _Snow_Color;
			half _Gliter_Color_Power;
			half _Glitter_Refreshing_Speed;
			sampler2D _Texture_Glitter;
			half _Glitter_Tiling;
			half _Glitter_Noise_Threshold;
			half _Texture_1_Normal_Index;
			TEXTURE2D_ARRAY( _Texture_Array_Normal );
			uniform SAMPLER( sampler_Texture_Array_Normal );
			half _Texture_1_Normal_Power;
			float _Texture_2_Normal_Index;
			half _Texture_2_Normal_Power;
			float _Texture_3_Normal_Index;
			half _Texture_3_Normal_Power;
			float _Texture_4_Normal_Index;
			half _Texture_4_Normal_Power;
			float _Texture_5_Normal_Index;
			half _Texture_5_Normal_Power;
			float _Texture_6_Normal_Index;
			half _Texture_6_Normal_Power;
			float _Texture_7_Normal_Index;
			half _Texture_7_Normal_Power;
			float _Texture_8_Normal_Index;
			half _Texture_8_Normal_Power;
			half _Texture_9_Normal_Index;
			half _Texture_9_Normal_Power;
			half _Texture_10_Normal_Index;
			half _Texture_10_Normal_Power;
			half _Texture_11_Normal_Index;
			half _Texture_11_Normal_Power;
			half _Texture_12_Normal_Index;
			half _Texture_12_Normal_Power;
			half _Texture_13_Normal_Index;
			half _Texture_13_Normal_Power;
			half _Texture_14_Normal_Index;
			half _Texture_14_Normal_Power;
			half _Texture_15_Normal_Index;
			half _Texture_15_Normal_Power;
			half _Texture_16_Normal_Index;
			half _Texture_16_Normal_Power;
			float _Texture_Snow_Normal_Index;
			half _Snow_Normal_Scale;
			half _Snow_Blend_Normal;
			half _Snow_Amount;
			half _Snow_Noise_Tiling;
			half _Snow_Noise_Power;
			half _Snow_Maximum_Angle;
			half _Snow_Maximum_Angle_Hardness;
			half _Snow_Min_Height;
			half _Snow_Min_Height_Blending;
			half _Texture_16_Snow_Reduction;
			half _Texture_15_Snow_Reduction;
			half _Texture_13_Snow_Reduction;
			half _Texture_12_Snow_Reduction;
			half _Texture_11_Snow_Reduction;
			half _Texture_9_Snow_Reduction;
			half _Texture_8_Snow_Reduction;
			half _Texture_7_Snow_Reduction;
			half _Texture_5_Snow_Reduction;
			half _Texture_1_Snow_Reduction;
			half _Texture_2_Snow_Reduction;
			half _Texture_3_Snow_Reduction;
			half _Texture_4_Snow_Reduction;
			half _Texture_6_Snow_Reduction;
			half _Texture_10_Snow_Reduction;
			half _Texture_14_Snow_Reduction;
			sampler2D _TerrainHolesTexture;
			float4 _TerrainHolesTexture_ST;
			half _Remove_Vert_Height;

            #pragma shader_feature _ _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A
            #pragma shader_feature EDITOR_VISUALIZATION


            struct GraphVertexInput
            {
                float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 texcoord1 : TEXCOORD1;
				float4 texcoord2 : TEXCOORD2;
				float4 ase_tangent : TANGENT;
				float4 ase_texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

        	struct VertexOutput
        	{
        	    float4 clipPos      : SV_POSITION;
                float4 ase_texcoord : TEXCOORD0;
                float4 ase_texcoord1 : TEXCOORD1;
                float4 ase_texcoord2 : TEXCOORD2;
                float4 ase_texcoord3 : TEXCOORD3;
                float4 ase_texcoord4 : TEXCOORD4;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                UNITY_VERTEX_OUTPUT_STEREO
        	};

			inline half MyCustomExpression6279( inout half3 In0 )
			{
				return UNITY_MATRIX_IT_MV[2].xyz;
			}
			
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
			

            VertexOutput vert(GraphVertexInput v  )
            {
                VertexOutput o = (VertexOutput)0;
        	    UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				TerrainInstancing(v.vertex, v.ase_normal, v.ase_texcoord.xy);
				float3 localCalculateTangentsSRP6339 = ( ( v.ase_tangent.xyz * 0.0 ) );
				v.ase_tangent.xyz = cross ( v.ase_normal, float3( 0, 0, 1 ) );
				v.ase_tangent.w = -1;
				
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				o.ase_texcoord.xyz = ase_worldPos;
				float3 ase_worldNormal = TransformObjectToWorldNormal(v.ase_normal);
				o.ase_texcoord2.xyz = ase_worldNormal;
				float3 ase_worldTangent = TransformObjectToWorldDir(v.ase_tangent.xyz);
				o.ase_texcoord3.xyz = ase_worldTangent;
				float ase_vertexTangentSign = v.ase_tangent.w * unity_WorldTransformParams.w;
				float3 ase_worldBitangent = cross( ase_worldNormal, ase_worldTangent ) * ase_vertexTangentSign;
				o.ase_texcoord4.xyz = ase_worldBitangent;
				
				o.ase_texcoord1.xy = v.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord.w = 0;
				o.ase_texcoord1.zw = 0;
				o.ase_texcoord2.w = 0;
				o.ase_texcoord3.w = 0;
				o.ase_texcoord4.w = 0;

				float3 vertexValue = localCalculateTangentsSRP6339;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
				v.vertex.xyz = vertexValue;
				#else
				v.vertex.xyz += vertexValue;
				#endif

				v.ase_normal =  v.ase_normal ;
#if !defined( ASE_SRP_VERSION ) || ASE_SRP_VERSION  > 51300				
                o.clipPos = MetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord1.xy, unity_LightmapST, unity_DynamicLightmapST);
#else
				o.clipPos = MetaVertexPosition (v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST);
#endif
        	    return o;
            }

            half4 frag(VertexOutput IN  ) : SV_TARGET
            {
                UNITY_SETUP_INSTANCE_ID(IN);

           		float3 ase_worldPos = IN.ase_texcoord.xyz;
           		float3 break6201 = abs( ( ase_worldPos - _WorldSpaceCameraPos ) );
           		float clampResult297 = clamp( pow( ( max( max( break6201.x , break6201.y ) , break6201.z ) / _UV_Mix_Start_Distance ) , _UV_Mix_Power ) , 0.0 , 1.0 );
           		half UVmixDistance636 = clampResult297;
           		float lerpResult6230 = lerp( _Global_Color_Map_Close_Power , _Global_Color_Map_Far_Power , UVmixDistance636);
           		float2 uv02588 = IN.ase_texcoord1.xy * float2( 1,1 ) + float2( 0,0 );
           		float4 tex2DNode6204 = tex2D( _Global_Color_Map, ( _Global_Color_Map_Offset + ( _Global_Color_Map_Scale * uv02588 ) ) );
           		float clampResult6326 = clamp( ( tex2DNode6204.a + ( 1.0 - _Global_Color_Opacity_Power ) ) , 0.0 , 1.0 );
           		float2 appendResult6241 = (float2(1.0 , ( lerpResult6230 * clampResult6326 )));
           		float4 tex2DNode4371 = tex2D( _Texture_Splat_4, uv02588 );
           		float4 tex2DNode4370 = tex2D( _Texture_Splat_3, uv02588 );
           		float4 tex2DNode4369 = tex2D( _Texture_Splat_2, uv02588 );
           		float4 tex2DNode4368 = tex2D( _Texture_Splat_1, uv02588 );
           		float3 break6329 = ase_worldPos;
           		float2 appendResult6267 = (float2(break6329.x , break6329.z));
           		half2 Top_Bottom1999 = appendResult6267;
           		float temp_output_3830_0 = ( 1.0 / _Texture_1_Tiling );
           		float2 appendResult3284 = (float2(temp_output_3830_0 , temp_output_3830_0));
           		float2 temp_output_3275_0 = ( Top_Bottom1999 * appendResult3284 );
           		float4 texArray3292 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3275_0, _Texture_1_Albedo_Index );
           		float4 texArray3293 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3275_0 / _Texture_1_Far_Multiplier ), _Texture_1_Albedo_Index );
           		float4 lerpResult5739 = lerp( texArray3292 , texArray3293 , UVmixDistance636);
           		float3 ase_worldNormal = IN.ase_texcoord2.xyz;
           		float3 clampResult5488 = clamp( pow( ( ase_worldNormal * ase_worldNormal ) , 25.0 ) , float3( -1,-1,-1 ) , float3( 1,1,1 ) );
           		half3 BlendComponents91 = clampResult5488;
           		float2 appendResult6265 = (float2(break6329.z , break6329.y));
           		half2 Front_Back1991 = appendResult6265;
           		float2 temp_output_3279_0 = ( Front_Back1991 * appendResult3284 );
           		float4 texArray3287 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3279_0, _Texture_1_Albedo_Index );
           		float2 appendResult6266 = (float2(break6329.x , break6329.y));
           		half2 Left_Right2003 = appendResult6266;
           		float2 temp_output_3277_0 = ( Left_Right2003 * appendResult3284 );
           		float4 texArray3294 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3277_0, _Texture_1_Albedo_Index );
           		float3 weightedBlendVar5674 = BlendComponents91;
           		float4 weightedAvg5674 = ( ( weightedBlendVar5674.x*texArray3287 + weightedBlendVar5674.y*texArray3292 + weightedBlendVar5674.z*texArray3294 )/( weightedBlendVar5674.x + weightedBlendVar5674.y + weightedBlendVar5674.z ) );
           		float4 texArray3291 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3279_0 / _Texture_1_Far_Multiplier ), _Texture_1_Albedo_Index );
           		float4 texArray3295 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3277_0 / _Texture_1_Far_Multiplier ), _Texture_1_Albedo_Index );
           		float3 weightedBlendVar5675 = BlendComponents91;
           		float4 weightedAvg5675 = ( ( weightedBlendVar5675.x*texArray3291 + weightedBlendVar5675.y*texArray3293 + weightedBlendVar5675.z*texArray3295 )/( weightedBlendVar5675.x + weightedBlendVar5675.y + weightedBlendVar5675.z ) );
           		float4 lerpResult1767 = lerp( weightedAvg5674 , weightedAvg5675 , UVmixDistance636);
           		float4 ifLocalVar5782 = 0;
           		UNITY_BRANCH 
           		if( _Texture_1_Triplanar == 1.0 )
           		ifLocalVar5782 = lerpResult1767;
           		else
           		ifLocalVar5782 = lerpResult5739;
           		float4 ifLocalVar6174 = 0;
           		UNITY_BRANCH 
           		if( _Texture_1_Albedo_Index > -1.0 )
           		ifLocalVar6174 = ( ifLocalVar5782 * _Texture_1_Color );
           		half4 Texture_1_Final950 = ifLocalVar6174;
           		float temp_output_3831_0 = ( 1.0 / _Texture_2_Tiling );
           		float2 appendResult3349 = (float2(temp_output_3831_0 , temp_output_3831_0));
           		float2 temp_output_3343_0 = ( Top_Bottom1999 * appendResult3349 );
           		float4 texArray3338 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3343_0, _Texture_2_Albedo_Index );
           		float4 texArray3339 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3343_0 / _Texture_2_Far_Multiplier ), _Texture_2_Albedo_Index );
           		float4 lerpResult5749 = lerp( texArray3338 , texArray3339 , UVmixDistance636);
           		float2 temp_output_3344_0 = ( Front_Back1991 * appendResult3349 );
           		float4 texArray3355 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3344_0, _Texture_2_Albedo_Index );
           		float2 temp_output_3379_0 = ( Left_Right2003 * appendResult3349 );
           		float4 texArray3341 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3379_0, _Texture_2_Albedo_Index );
           		float3 weightedBlendVar5496 = BlendComponents91;
           		float4 weightedAvg5496 = ( ( weightedBlendVar5496.x*texArray3355 + weightedBlendVar5496.y*texArray3338 + weightedBlendVar5496.z*texArray3341 )/( weightedBlendVar5496.x + weightedBlendVar5496.y + weightedBlendVar5496.z ) );
           		float4 texArray3356 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3344_0 / _Texture_2_Far_Multiplier ), _Texture_2_Albedo_Index );
           		float4 texArray3342 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3379_0 / _Texture_2_Far_Multiplier ), _Texture_2_Albedo_Index );
           		float3 weightedBlendVar5497 = BlendComponents91;
           		float4 weightedAvg5497 = ( ( weightedBlendVar5497.x*texArray3356 + weightedBlendVar5497.y*texArray3339 + weightedBlendVar5497.z*texArray3342 )/( weightedBlendVar5497.x + weightedBlendVar5497.y + weightedBlendVar5497.z ) );
           		float4 lerpResult3333 = lerp( weightedAvg5496 , weightedAvg5497 , UVmixDistance636);
           		float4 ifLocalVar5771 = 0;
           		UNITY_BRANCH 
           		if( _Texture_2_Triplanar == 1.0 )
           		ifLocalVar5771 = lerpResult3333;
           		else
           		ifLocalVar5771 = lerpResult5749;
           		float4 ifLocalVar6128 = 0;
           		UNITY_BRANCH 
           		if( _Texture_2_Albedo_Index > -1.0 )
           		ifLocalVar6128 = ( ifLocalVar5771 * _Texture_2_Color );
           		half4 Texture_2_Final3385 = ifLocalVar6128;
           		float temp_output_3832_0 = ( 1.0 / _Texture_3_Tiling );
           		float2 appendResult3415 = (float2(temp_output_3832_0 , temp_output_3832_0));
           		float2 temp_output_3410_0 = ( Top_Bottom1999 * appendResult3415 );
           		float4 texArray3405 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3410_0, _Texture_3_Albedo_Index );
           		float4 texArray3406 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3410_0 / _Texture_3_Far_Multiplier ), _Texture_3_Albedo_Index );
           		float4 lerpResult5759 = lerp( texArray3405 , texArray3406 , UVmixDistance636);
           		float2 temp_output_3411_0 = ( Front_Back1991 * appendResult3415 );
           		float4 texArray3419 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3411_0, _Texture_3_Albedo_Index );
           		float2 temp_output_3441_0 = ( Left_Right2003 * appendResult3415 );
           		float4 texArray3408 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3441_0, _Texture_3_Albedo_Index );
           		float3 weightedBlendVar5500 = BlendComponents91;
           		float4 weightedAvg5500 = ( ( weightedBlendVar5500.x*texArray3419 + weightedBlendVar5500.y*texArray3405 + weightedBlendVar5500.z*texArray3408 )/( weightedBlendVar5500.x + weightedBlendVar5500.y + weightedBlendVar5500.z ) );
           		float2 temp_output_3413_0 = ( temp_output_3411_0 / _Texture_3_Far_Multiplier );
           		float4 texArray3420 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3413_0, _Texture_3_Albedo_Index );
           		float4 texArray3409 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3441_0 / _Texture_3_Far_Multiplier ), _Texture_3_Albedo_Index );
           		float3 weightedBlendVar5501 = BlendComponents91;
           		float4 weightedAvg5501 = ( ( weightedBlendVar5501.x*texArray3420 + weightedBlendVar5501.y*texArray3406 + weightedBlendVar5501.z*texArray3409 )/( weightedBlendVar5501.x + weightedBlendVar5501.y + weightedBlendVar5501.z ) );
           		float4 lerpResult3400 = lerp( weightedAvg5500 , weightedAvg5501 , UVmixDistance636);
           		float4 ifLocalVar5775 = 0;
           		UNITY_BRANCH 
           		if( _Texture_3_Triplanar == 1.0 )
           		ifLocalVar5775 = lerpResult3400;
           		else
           		ifLocalVar5775 = lerpResult5759;
           		float4 ifLocalVar6130 = 0;
           		UNITY_BRANCH 
           		if( _Texture_3_Albedo_Index > -1.0 )
           		ifLocalVar6130 = ( ifLocalVar5775 * _Texture_3_Color );
           		half4 Texture_3_Final3451 = ifLocalVar6130;
           		float temp_output_3833_0 = ( 1.0 / _Texture_4_Tiling );
           		float2 temp_output_3477_0 = ( Top_Bottom1999 * temp_output_3833_0 );
           		float4 texArray3472 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3477_0, _Texture_4_Albedo_Index );
           		float4 texArray3473 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3477_0 / _Texture_4_Far_Multiplier ), _Texture_4_Albedo_Index );
           		float4 lerpResult5761 = lerp( texArray3472 , texArray3473 , UVmixDistance636);
           		float2 temp_output_3478_0 = ( Front_Back1991 * temp_output_3833_0 );
           		float4 texArray3486 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3478_0, _Texture_4_Albedo_Index );
           		float2 temp_output_3508_0 = ( Left_Right2003 * temp_output_3833_0 );
           		float4 texArray3475 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3508_0, _Texture_4_Albedo_Index );
           		float3 weightedBlendVar5504 = BlendComponents91;
           		float4 weightedAvg5504 = ( ( weightedBlendVar5504.x*texArray3486 + weightedBlendVar5504.y*texArray3472 + weightedBlendVar5504.z*texArray3475 )/( weightedBlendVar5504.x + weightedBlendVar5504.y + weightedBlendVar5504.z ) );
           		float4 texArray3487 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3478_0 / _Texture_4_Far_Multiplier ), _Texture_4_Albedo_Index );
           		float4 texArray3476 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_3508_0 / _Texture_4_Far_Multiplier ), _Texture_4_Albedo_Index );
           		float3 weightedBlendVar5505 = BlendComponents91;
           		float4 weightedAvg5505 = ( ( weightedBlendVar5505.x*texArray3487 + weightedBlendVar5505.y*texArray3473 + weightedBlendVar5505.z*texArray3476 )/( weightedBlendVar5505.x + weightedBlendVar5505.y + weightedBlendVar5505.z ) );
           		float4 lerpResult3467 = lerp( weightedAvg5504 , weightedAvg5505 , UVmixDistance636);
           		float4 ifLocalVar5777 = 0;
           		UNITY_BRANCH 
           		if( _Texture_4_Triplanar == 1.0 )
           		ifLocalVar5777 = lerpResult3467;
           		else
           		ifLocalVar5777 = lerpResult5761;
           		float4 ifLocalVar6132 = 0;
           		UNITY_BRANCH 
           		if( _Texture_4_Albedo_Index > -1.0 )
           		ifLocalVar6132 = ( ifLocalVar5777 * _Texture_4_Color );
           		half4 Texture_4_Final3518 = ifLocalVar6132;
           		float4 layeredBlendVar5643 = tex2DNode4368;
           		float4 layeredBlend5643 = ( lerp( lerp( lerp( lerp( float4( 0,0,0,0 ) , Texture_1_Final950 , layeredBlendVar5643.x ) , Texture_2_Final3385 , layeredBlendVar5643.y ) , Texture_3_Final3451 , layeredBlendVar5643.z ) , Texture_4_Final3518 , layeredBlendVar5643.w ) );
           		float temp_output_4397_0 = ( 1.0 / _Texture_5_Tiling );
           		float2 appendResult4399 = (float2(temp_output_4397_0 , temp_output_4397_0));
           		float2 temp_output_4416_0 = ( Top_Bottom1999 * appendResult4399 );
           		float4 texArray4450 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4416_0, _Texture_5_Albedo_Index );
           		float4 texArray4445 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4416_0 / _Texture_5_Far_Multiplier ), _Texture_5_Albedo_Index );
           		float4 lerpResult5789 = lerp( texArray4450 , texArray4445 , UVmixDistance636);
           		float2 temp_output_4400_0 = ( Front_Back1991 * appendResult4399 );
           		float4 texArray4442 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4400_0, _Texture_5_Albedo_Index );
           		float2 temp_output_4413_0 = ( Left_Right2003 * appendResult4399 );
           		float4 texArray4443 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4413_0, _Texture_5_Albedo_Index );
           		float3 weightedBlendVar5512 = BlendComponents91;
           		float4 weightedAvg5512 = ( ( weightedBlendVar5512.x*texArray4442 + weightedBlendVar5512.y*texArray4450 + weightedBlendVar5512.z*texArray4443 )/( weightedBlendVar5512.x + weightedBlendVar5512.y + weightedBlendVar5512.z ) );
           		float4 texArray4444 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4400_0 / _Texture_5_Far_Multiplier ), _Texture_5_Albedo_Index );
           		float4 texArray4439 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4413_0 / _Texture_5_Far_Multiplier ), _Texture_5_Albedo_Index );
           		float3 weightedBlendVar5514 = BlendComponents91;
           		float4 weightedAvg5514 = ( ( weightedBlendVar5514.x*texArray4444 + weightedBlendVar5514.y*texArray4445 + weightedBlendVar5514.z*texArray4439 )/( weightedBlendVar5514.x + weightedBlendVar5514.y + weightedBlendVar5514.z ) );
           		float4 lerpResult4466 = lerp( weightedAvg5512 , weightedAvg5514 , UVmixDistance636);
           		float4 ifLocalVar5804 = 0;
           		UNITY_BRANCH 
           		if( _Texture_5_Triplanar == 1.0 )
           		ifLocalVar5804 = lerpResult4466;
           		else
           		ifLocalVar5804 = lerpResult5789;
           		float4 ifLocalVar6134 = 0;
           		UNITY_BRANCH 
           		if( _Texture_5_Albedo_Index > -1.0 )
           		ifLocalVar6134 = ( ifLocalVar5804 * _Texture_5_Color );
           		half4 Texture_5_Final4396 = ifLocalVar6134;
           		float temp_output_4469_0 = ( 1.0 / _Texture_6_Tiling );
           		float2 appendResult4471 = (float2(temp_output_4469_0 , temp_output_4469_0));
           		float2 temp_output_4485_0 = ( Top_Bottom1999 * appendResult4471 );
           		float4 texArray4517 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4485_0, _Texture_6_Albedo_Index );
           		float4 texArray4512 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4485_0 / _Texture_6_Far_Multiplier ), _Texture_6_Albedo_Index );
           		float4 lerpResult5794 = lerp( texArray4517 , texArray4512 , UVmixDistance636);
           		float2 temp_output_4472_0 = ( Front_Back1991 * appendResult4471 );
           		float4 texArray4509 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4472_0, _Texture_6_Albedo_Index );
           		float2 temp_output_4483_0 = ( Left_Right2003 * appendResult4471 );
           		float4 texArray4510 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4483_0, _Texture_6_Albedo_Index );
           		float3 weightedBlendVar5520 = BlendComponents91;
           		float4 weightedAvg5520 = ( ( weightedBlendVar5520.x*texArray4509 + weightedBlendVar5520.y*texArray4517 + weightedBlendVar5520.z*texArray4510 )/( weightedBlendVar5520.x + weightedBlendVar5520.y + weightedBlendVar5520.z ) );
           		float4 texArray4511 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4472_0 / _Texture_6_Far_Multiplier ), _Texture_6_Albedo_Index );
           		float4 texArray4506 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4483_0 / _Texture_6_Far_Multiplier ), _Texture_6_Albedo_Index );
           		float3 weightedBlendVar5522 = BlendComponents91;
           		float4 weightedAvg5522 = ( ( weightedBlendVar5522.x*texArray4511 + weightedBlendVar5522.y*texArray4512 + weightedBlendVar5522.z*texArray4506 )/( weightedBlendVar5522.x + weightedBlendVar5522.y + weightedBlendVar5522.z ) );
           		float4 lerpResult4532 = lerp( weightedAvg5520 , weightedAvg5522 , UVmixDistance636);
           		float4 ifLocalVar5809 = 0;
           		UNITY_BRANCH 
           		if( _Texture_6_Triplanar == 1.0 )
           		ifLocalVar5809 = lerpResult4532;
           		else
           		ifLocalVar5809 = lerpResult5794;
           		float4 ifLocalVar6136 = 0;
           		UNITY_BRANCH 
           		if( _Texture_6_Albedo_Index > -1.0 )
           		ifLocalVar6136 = ( ifLocalVar5809 * _Texture_6_Color );
           		half4 Texture_6_Final4536 = ifLocalVar6136;
           		float temp_output_4543_0 = ( 1.0 / _Texture_7_Tiling );
           		float2 appendResult4545 = (float2(temp_output_4543_0 , temp_output_4543_0));
           		float2 temp_output_4559_0 = ( Top_Bottom1999 * appendResult4545 );
           		float4 texArray4591 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4559_0, _Texture_7_Albedo_Index );
           		float4 texArray4586 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4559_0 / _Texture_7_Far_Multiplier ), _Texture_7_Albedo_Index );
           		float4 lerpResult5798 = lerp( texArray4591 , texArray4586 , UVmixDistance636);
           		float2 temp_output_4546_0 = ( Front_Back1991 * appendResult4545 );
           		float4 texArray4583 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4546_0, _Texture_7_Albedo_Index );
           		float2 temp_output_4557_0 = ( Left_Right2003 * appendResult4545 );
           		float4 texArray4584 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4557_0, _Texture_7_Albedo_Index );
           		float3 weightedBlendVar5524 = BlendComponents91;
           		float4 weightedAvg5524 = ( ( weightedBlendVar5524.x*texArray4583 + weightedBlendVar5524.y*texArray4591 + weightedBlendVar5524.z*texArray4584 )/( weightedBlendVar5524.x + weightedBlendVar5524.y + weightedBlendVar5524.z ) );
           		float4 texArray4585 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4546_0 / _Texture_7_Far_Multiplier ), _Texture_7_Albedo_Index );
           		float4 texArray4580 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4557_0 / _Texture_7_Far_Multiplier ), _Texture_7_Albedo_Index );
           		float3 weightedBlendVar5526 = BlendComponents91;
           		float4 weightedAvg5526 = ( ( weightedBlendVar5526.x*texArray4585 + weightedBlendVar5526.y*texArray4586 + weightedBlendVar5526.z*texArray4580 )/( weightedBlendVar5526.x + weightedBlendVar5526.y + weightedBlendVar5526.z ) );
           		float4 lerpResult4606 = lerp( weightedAvg5524 , weightedAvg5526 , UVmixDistance636);
           		float4 ifLocalVar5812 = 0;
           		UNITY_BRANCH 
           		if( _Texture_7_Triplanar == 1.0 )
           		ifLocalVar5812 = lerpResult4606;
           		else
           		ifLocalVar5812 = lerpResult5798;
           		float4 ifLocalVar6139 = 0;
           		UNITY_BRANCH 
           		if( _Texture_7_Albedo_Index > -1.0 )
           		ifLocalVar6139 = ( ifLocalVar5812 * _Texture_7_Color );
           		half4 Texture_7_Final4614 = ifLocalVar6139;
           		float temp_output_4617_0 = ( 1.0 / _Texture_8_Tiling );
           		float2 appendResult4619 = (float2(temp_output_4617_0 , temp_output_4617_0));
           		float2 temp_output_4633_0 = ( Top_Bottom1999 * appendResult4619 );
           		float4 texArray4665 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4633_0, _Texture_8_Albedo_Index );
           		float4 texArray4660 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4633_0 / _Texture_8_Far_Multiplier ), _Texture_8_Albedo_Index );
           		float4 lerpResult5802 = lerp( texArray4665 , texArray4660 , UVmixDistance636);
           		float2 temp_output_4620_0 = ( Front_Back1991 * appendResult4619 );
           		float4 texArray4657 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4620_0, _Texture_8_Albedo_Index );
           		float2 temp_output_4631_0 = ( Left_Right2003 * appendResult4619 );
           		float4 texArray4658 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4631_0, _Texture_8_Albedo_Index );
           		float3 weightedBlendVar5528 = BlendComponents91;
           		float4 weightedAvg5528 = ( ( weightedBlendVar5528.x*texArray4657 + weightedBlendVar5528.y*texArray4665 + weightedBlendVar5528.z*texArray4658 )/( weightedBlendVar5528.x + weightedBlendVar5528.y + weightedBlendVar5528.z ) );
           		float4 texArray4659 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4620_0 / _Texture_8_Far_Multiplier ), _Texture_8_Albedo_Index );
           		float4 texArray4654 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4631_0 / _Texture_8_Far_Multiplier ), _Texture_8_Albedo_Index );
           		float3 weightedBlendVar5530 = BlendComponents91;
           		float4 weightedAvg5530 = ( ( weightedBlendVar5530.x*texArray4659 + weightedBlendVar5530.y*texArray4660 + weightedBlendVar5530.z*texArray4654 )/( weightedBlendVar5530.x + weightedBlendVar5530.y + weightedBlendVar5530.z ) );
           		float4 lerpResult4680 = lerp( weightedAvg5528 , weightedAvg5530 , UVmixDistance636);
           		float4 ifLocalVar5815 = 0;
           		UNITY_BRANCH 
           		if( _Texture_8_Triplanar == 1.0 )
           		ifLocalVar5815 = lerpResult4680;
           		else
           		ifLocalVar5815 = lerpResult5802;
           		float4 ifLocalVar6141 = 0;
           		UNITY_BRANCH 
           		if( _Texture_8_Albedo_Index > -1.0 )
           		ifLocalVar6141 = ( ifLocalVar5815 * _Texture_8_Color );
           		half4 Texture_8_Final4689 = ifLocalVar6141;
           		float4 layeredBlendVar5644 = tex2DNode4369;
           		float4 layeredBlend5644 = ( lerp( lerp( lerp( lerp( layeredBlend5643 , Texture_5_Final4396 , layeredBlendVar5644.x ) , Texture_6_Final4536 , layeredBlendVar5644.y ) , Texture_7_Final4614 , layeredBlendVar5644.z ) , Texture_8_Final4689 , layeredBlendVar5644.w ) );
           		float temp_output_4703_0 = ( 1.0 / _Texture_9_Tiling );
           		float2 appendResult4736 = (float2(temp_output_4703_0 , temp_output_4703_0));
           		float2 temp_output_4712_0 = ( Top_Bottom1999 * appendResult4736 );
           		float4 texArray4723 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4712_0, _Texture_9_Albedo_Index );
           		float4 texArray4889 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4712_0 / _Texture_9_Far_Multiplier ), _Texture_9_Albedo_Index );
           		float4 lerpResult5845 = lerp( texArray4723 , texArray4889 , UVmixDistance636);
           		float2 temp_output_4706_0 = ( Front_Back1991 * appendResult4736 );
           		float4 texArray5286 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4706_0, _Texture_9_Albedo_Index );
           		float2 temp_output_4761_0 = ( Left_Right2003 * appendResult4736 );
           		float4 texArray4858 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4761_0, _Texture_9_Albedo_Index );
           		float3 weightedBlendVar5489 = BlendComponents91;
           		float4 weightedAvg5489 = ( ( weightedBlendVar5489.x*texArray5286 + weightedBlendVar5489.y*texArray4723 + weightedBlendVar5489.z*texArray4858 )/( weightedBlendVar5489.x + weightedBlendVar5489.y + weightedBlendVar5489.z ) );
           		float4 texArray4719 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4706_0 / _Texture_9_Far_Multiplier ), _Texture_9_Albedo_Index );
           		float4 texArray4865 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4761_0 / _Texture_9_Far_Multiplier ), _Texture_9_Albedo_Index );
           		float3 weightedBlendVar5490 = BlendComponents91;
           		float4 weightedAvg5490 = ( ( weightedBlendVar5490.x*texArray4719 + weightedBlendVar5490.y*texArray4889 + weightedBlendVar5490.z*texArray4865 )/( weightedBlendVar5490.x + weightedBlendVar5490.y + weightedBlendVar5490.z ) );
           		float4 lerpResult4976 = lerp( weightedAvg5489 , weightedAvg5490 , UVmixDistance636);
           		float4 ifLocalVar5844 = 0;
           		UNITY_BRANCH 
           		if( _Texture_9_Triplanar == 1.0 )
           		ifLocalVar5844 = lerpResult4976;
           		else
           		ifLocalVar5844 = lerpResult5845;
           		float4 ifLocalVar6143 = 0;
           		UNITY_BRANCH 
           		if( _Texture_9_Albedo_Index > -1.0 )
           		ifLocalVar6143 = ( ifLocalVar5844 * _Texture_9_Color );
           		half4 Texture_9_Final4987 = ifLocalVar6143;
           		float temp_output_4734_0 = ( 1.0 / _Texture_10_Tiling );
           		float2 appendResult4738 = (float2(temp_output_4734_0 , temp_output_4734_0));
           		float2 temp_output_4793_0 = ( Top_Bottom1999 * appendResult4738 );
           		float4 texArray4899 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4793_0, _Texture_10_Albedo_Index );
           		float4 texArray4913 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4793_0 / _Texture_10_Far_Multiplier ), _Texture_10_Albedo_Index );
           		float4 lerpResult5841 = lerp( texArray4899 , texArray4913 , UVmixDistance636);
           		float2 temp_output_4742_0 = ( Front_Back1991 * appendResult4738 );
           		float4 texArray4886 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4742_0, _Texture_10_Albedo_Index );
           		float2 temp_output_4785_0 = ( Left_Right2003 * appendResult4738 );
           		float4 texArray4877 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4785_0, _Texture_10_Albedo_Index );
           		float3 weightedBlendVar5532 = BlendComponents91;
           		float4 weightedAvg5532 = ( ( weightedBlendVar5532.x*texArray4886 + weightedBlendVar5532.y*texArray4899 + weightedBlendVar5532.z*texArray4877 )/( weightedBlendVar5532.x + weightedBlendVar5532.y + weightedBlendVar5532.z ) );
           		float4 texArray4894 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4742_0 / _Texture_10_Far_Multiplier ), _Texture_10_Albedo_Index );
           		float4 texArray4878 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4785_0 / _Texture_10_Far_Multiplier ), _Texture_10_Albedo_Index );
           		float3 weightedBlendVar5534 = BlendComponents91;
           		float4 weightedAvg5534 = ( ( weightedBlendVar5534.x*texArray4894 + weightedBlendVar5534.y*texArray4913 + weightedBlendVar5534.z*texArray4878 )/( weightedBlendVar5534.x + weightedBlendVar5534.y + weightedBlendVar5534.z ) );
           		float4 lerpResult4983 = lerp( weightedAvg5532 , weightedAvg5534 , UVmixDistance636);
           		float4 ifLocalVar5840 = 0;
           		UNITY_BRANCH 
           		if( _Texture_10_Triplanar == 1.0 )
           		ifLocalVar5840 = lerpResult4983;
           		else
           		ifLocalVar5840 = lerpResult5841;
           		float4 ifLocalVar6145 = 0;
           		UNITY_BRANCH 
           		if( _Texture_10_Albedo_Index > -1.0 )
           		ifLocalVar6145 = ( ifLocalVar5840 * _Texture_10_Color );
           		half4 Texture_10_Final4994 = ifLocalVar6145;
           		float temp_output_4739_0 = ( 1.0 / _Texture_11_Tiling );
           		float2 appendResult4741 = (float2(temp_output_4739_0 , temp_output_4739_0));
           		float2 temp_output_4817_0 = ( Top_Bottom1999 * appendResult4741 );
           		float4 texArray4928 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4817_0, _Texture_11_Albedo_Index );
           		float4 texArray4923 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4817_0 / _Texture_11_Far_Multiplier ), _Texture_11_Albedo_Index );
           		float4 lerpResult5837 = lerp( texArray4928 , texArray4923 , UVmixDistance636);
           		float2 temp_output_4748_0 = ( Front_Back1991 * appendResult4741 );
           		float4 texArray4917 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4748_0, _Texture_11_Albedo_Index );
           		float2 temp_output_4795_0 = ( Left_Right2003 * appendResult4741 );
           		float4 texArray4911 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4795_0, _Texture_11_Albedo_Index );
           		float3 weightedBlendVar5536 = BlendComponents91;
           		float4 weightedAvg5536 = ( ( weightedBlendVar5536.x*texArray4917 + weightedBlendVar5536.y*texArray4928 + weightedBlendVar5536.z*texArray4911 )/( weightedBlendVar5536.x + weightedBlendVar5536.y + weightedBlendVar5536.z ) );
           		float4 texArray4898 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4748_0 / _Texture_11_Far_Multiplier ), _Texture_11_Albedo_Index );
           		float4 texArray4914 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4795_0 / _Texture_11_Far_Multiplier ), _Texture_11_Albedo_Index );
           		float3 weightedBlendVar5538 = BlendComponents91;
           		float4 weightedAvg5538 = ( ( weightedBlendVar5538.x*texArray4898 + weightedBlendVar5538.y*texArray4923 + weightedBlendVar5538.z*texArray4914 )/( weightedBlendVar5538.x + weightedBlendVar5538.y + weightedBlendVar5538.z ) );
           		float4 lerpResult4988 = lerp( weightedAvg5536 , weightedAvg5538 , UVmixDistance636);
           		float4 ifLocalVar5836 = 0;
           		UNITY_BRANCH 
           		if( _Texture_11_Triplanar == 1.0 )
           		ifLocalVar5836 = lerpResult4988;
           		else
           		ifLocalVar5836 = lerpResult5837;
           		float4 ifLocalVar6147 = 0;
           		UNITY_BRANCH 
           		if( _Texture_11_Albedo_Index > -1.0 )
           		ifLocalVar6147 = ( ifLocalVar5836 * _Texture_11_Color );
           		half4 Texture_11_Final4996 = ifLocalVar6147;
           		float temp_output_4745_0 = ( 1.0 / _Texture_12_Tiling );
           		float2 appendResult4751 = (float2(temp_output_4745_0 , temp_output_4745_0));
           		float2 temp_output_4849_0 = ( Top_Bottom1999 * appendResult4751 );
           		float4 texArray4954 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4849_0, _Texture_12_Albedo_Index );
           		float4 texArray4952 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4849_0 / _Texture_12_Far_Multiplier ), _Texture_12_Albedo_Index );
           		float4 lerpResult5833 = lerp( texArray4954 , texArray4952 , UVmixDistance636);
           		float2 temp_output_4758_0 = ( Front_Back1991 * appendResult4751 );
           		float4 texArray4926 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4758_0, _Texture_12_Albedo_Index );
           		float2 temp_output_4830_0 = ( Left_Right2003 * appendResult4751 );
           		float4 texArray4927 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_4830_0, _Texture_12_Albedo_Index );
           		float3 weightedBlendVar5540 = BlendComponents91;
           		float4 weightedAvg5540 = ( ( weightedBlendVar5540.x*texArray4926 + weightedBlendVar5540.y*texArray4954 + weightedBlendVar5540.z*texArray4927 )/( weightedBlendVar5540.x + weightedBlendVar5540.y + weightedBlendVar5540.z ) );
           		float4 texArray4919 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4758_0 / _Texture_12_Far_Multiplier ), _Texture_12_Albedo_Index );
           		float4 texArray4931 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_4830_0 / _Texture_12_Far_Multiplier ), _Texture_12_Albedo_Index );
           		float3 weightedBlendVar5542 = BlendComponents91;
           		float4 weightedAvg5542 = ( ( weightedBlendVar5542.x*texArray4919 + weightedBlendVar5542.y*texArray4952 + weightedBlendVar5542.z*texArray4931 )/( weightedBlendVar5542.x + weightedBlendVar5542.y + weightedBlendVar5542.z ) );
           		float4 lerpResult4993 = lerp( weightedAvg5540 , weightedAvg5542 , UVmixDistance636);
           		float4 ifLocalVar5832 = 0;
           		UNITY_BRANCH 
           		if( _Texture_12_Triplanar == 1.0 )
           		ifLocalVar5832 = lerpResult4993;
           		else
           		ifLocalVar5832 = lerpResult5833;
           		float4 ifLocalVar6169 = 0;
           		UNITY_BRANCH 
           		if( _Texture_12_Albedo_Index > -1.0 )
           		ifLocalVar6169 = ( ifLocalVar5832 * _Texture_12_Color );
           		half4 Texture_12_Final4997 = ifLocalVar6169;
           		float4 layeredBlendVar5645 = tex2DNode4370;
           		float4 layeredBlend5645 = ( lerp( lerp( lerp( lerp( layeredBlend5644 , Texture_9_Final4987 , layeredBlendVar5645.x ) , Texture_10_Final4994 , layeredBlendVar5645.y ) , Texture_11_Final4996 , layeredBlendVar5645.z ) , Texture_12_Final4997 , layeredBlendVar5645.w ) );
           		float temp_output_5125_0 = ( 1.0 / _Texture_13_Tiling );
           		float2 appendResult5027 = (float2(temp_output_5125_0 , temp_output_5125_0));
           		float2 temp_output_5037_0 = ( Top_Bottom1999 * appendResult5027 );
           		float4 texArray5043 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5037_0, _Texture_13_Albedo_Index );
           		float4 texArray5034 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5037_0 / _Texture_13_Far_Multiplier ), _Texture_13_Albedo_Index );
           		float4 lerpResult5829 = lerp( texArray5043 , texArray5034 , UVmixDistance636);
           		float2 temp_output_5025_0 = ( Front_Back1991 * appendResult5027 );
           		float4 texArray5128 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5025_0, _Texture_13_Albedo_Index );
           		float2 temp_output_5035_0 = ( Left_Right2003 * appendResult5027 );
           		float4 texArray5129 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5035_0, _Texture_13_Albedo_Index );
           		float3 weightedBlendVar5544 = BlendComponents91;
           		float4 weightedAvg5544 = ( ( weightedBlendVar5544.x*texArray5128 + weightedBlendVar5544.y*texArray5043 + weightedBlendVar5544.z*texArray5129 )/( weightedBlendVar5544.x + weightedBlendVar5544.y + weightedBlendVar5544.z ) );
           		float4 texArray5130 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5025_0 / _Texture_13_Far_Multiplier ), _Texture_13_Albedo_Index );
           		float4 texArray5121 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5035_0 / _Texture_13_Far_Multiplier ), _Texture_13_Albedo_Index );
           		float3 weightedBlendVar5546 = BlendComponents91;
           		float4 weightedAvg5546 = ( ( weightedBlendVar5546.x*texArray5130 + weightedBlendVar5546.y*texArray5034 + weightedBlendVar5546.z*texArray5121 )/( weightedBlendVar5546.x + weightedBlendVar5546.y + weightedBlendVar5546.z ) );
           		float4 lerpResult5054 = lerp( weightedAvg5544 , weightedAvg5546 , UVmixDistance636);
           		float4 ifLocalVar5828 = 0;
           		UNITY_BRANCH 
           		if( _Texture_13_Triplanar == 1.0 )
           		ifLocalVar5828 = lerpResult5054;
           		else
           		ifLocalVar5828 = lerpResult5829;
           		float4 ifLocalVar6151 = 0;
           		UNITY_BRANCH 
           		if( _Texture_13_Albedo_Index > -1.0 )
           		ifLocalVar6151 = ( ifLocalVar5828 * _Texture_13_Color );
           		half4 Texture_13_Final5058 = ifLocalVar6151;
           		float temp_output_5006_0 = ( 1.0 / _Texture_14_Tiling );
           		float2 appendResult5033 = (float2(temp_output_5006_0 , temp_output_5006_0));
           		float2 temp_output_5022_0 = ( Top_Bottom1999 * appendResult5033 );
           		float4 texArray5202 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5022_0, _Texture_14_Albedo_Index );
           		float4 texArray5171 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5022_0 / _Texture_14_Far_Multiplier ), _Texture_14_Albedo_Index );
           		float4 lerpResult5825 = lerp( texArray5202 , texArray5171 , UVmixDistance636);
           		float2 temp_output_5009_0 = ( Front_Back1991 * appendResult5033 );
           		float4 texArray5168 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5009_0, _Texture_14_Albedo_Index );
           		float2 temp_output_5010_0 = ( Left_Right2003 * appendResult5033 );
           		float4 texArray5239 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5010_0, _Texture_14_Albedo_Index );
           		float3 weightedBlendVar5548 = BlendComponents91;
           		float4 weightedAvg5548 = ( ( weightedBlendVar5548.x*texArray5168 + weightedBlendVar5548.y*texArray5202 + weightedBlendVar5548.z*texArray5239 )/( weightedBlendVar5548.x + weightedBlendVar5548.y + weightedBlendVar5548.z ) );
           		float4 texArray5205 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5009_0 / _Texture_14_Far_Multiplier ), _Texture_14_Albedo_Index );
           		float4 texArray5241 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5010_0 / _Texture_14_Far_Multiplier ), _Texture_14_Albedo_Index );
           		float3 weightedBlendVar5550 = BlendComponents91;
           		float4 weightedAvg5550 = ( ( weightedBlendVar5550.x*texArray5205 + weightedBlendVar5550.y*texArray5171 + weightedBlendVar5550.z*texArray5241 )/( weightedBlendVar5550.x + weightedBlendVar5550.y + weightedBlendVar5550.z ) );
           		float4 lerpResult5197 = lerp( weightedAvg5548 , weightedAvg5550 , UVmixDistance636);
           		float4 ifLocalVar5824 = 0;
           		UNITY_BRANCH 
           		if( _Texture_14_Triplanar == 1.0 )
           		ifLocalVar5824 = lerpResult5197;
           		else
           		ifLocalVar5824 = lerpResult5825;
           		float4 ifLocalVar6153 = 0;
           		UNITY_BRANCH 
           		if( _Texture_14_Albedo_Index > -1.0 )
           		ifLocalVar6153 = ( ifLocalVar5824 * _Texture_14_Color );
           		half4 Texture_14_Final5163 = ifLocalVar6153;
           		float temp_output_5210_0 = ( 1.0 / _Texture_15_Tiling );
           		float2 appendResult5212 = (float2(temp_output_5210_0 , temp_output_5210_0));
           		float2 temp_output_5226_0 = ( Top_Bottom1999 * appendResult5212 );
           		float4 texArray5259 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5226_0, _Texture_15_Albedo_Index );
           		float4 texArray5272 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5226_0 / _Texture_15_Far_Multiplier ), _Texture_15_Albedo_Index );
           		float4 lerpResult5821 = lerp( texArray5259 , texArray5272 , UVmixDistance636);
           		float2 temp_output_5213_0 = ( Front_Back1991 * appendResult5212 );
           		float4 texArray5182 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5213_0, _Texture_15_Albedo_Index );
           		float2 temp_output_5224_0 = ( Left_Right2003 * appendResult5212 );
           		float4 texArray5189 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5224_0, _Texture_15_Albedo_Index );
           		float3 weightedBlendVar5552 = BlendComponents91;
           		float4 weightedAvg5552 = ( ( weightedBlendVar5552.x*texArray5182 + weightedBlendVar5552.y*texArray5259 + weightedBlendVar5552.z*texArray5189 )/( weightedBlendVar5552.x + weightedBlendVar5552.y + weightedBlendVar5552.z ) );
           		float4 texArray5188 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5213_0 / _Texture_15_Far_Multiplier ), _Texture_15_Albedo_Index );
           		float4 texArray5247 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5224_0 / _Texture_15_Far_Multiplier ), _Texture_15_Albedo_Index );
           		float3 weightedBlendVar5554 = BlendComponents91;
           		float4 weightedAvg5554 = ( ( weightedBlendVar5554.x*texArray5188 + weightedBlendVar5554.y*texArray5272 + weightedBlendVar5554.z*texArray5247 )/( weightedBlendVar5554.x + weightedBlendVar5554.y + weightedBlendVar5554.z ) );
           		float4 lerpResult5279 = lerp( weightedAvg5552 , weightedAvg5554 , UVmixDistance636);
           		float4 ifLocalVar5820 = 0;
           		UNITY_BRANCH 
           		if( _Texture_15_Triplanar == 1.0 )
           		ifLocalVar5820 = lerpResult5279;
           		else
           		ifLocalVar5820 = lerpResult5821;
           		float4 ifLocalVar6155 = 0;
           		UNITY_BRANCH 
           		if( _Texture_15_Albedo_Index > -1.0 )
           		ifLocalVar6155 = ( ifLocalVar5820 * _Texture_15_Color );
           		half4 Texture_15_Final5270 = ifLocalVar6155;
           		float temp_output_5075_0 = ( 1.0 / _Texture_16_Tiling );
           		float2 appendResult5078 = (float2(temp_output_5075_0 , temp_output_5075_0));
           		float2 temp_output_5083_0 = ( Top_Bottom1999 * appendResult5078 );
           		float4 texArray5139 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5083_0, _Texture_16_Albedo_Index );
           		float4 texArray5143 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5083_0 / _Texture_16_Far_Multiplier ), _Texture_16_Albedo_Index );
           		float4 lerpResult5817 = lerp( texArray5139 , texArray5143 , UVmixDistance636);
           		float2 temp_output_5079_0 = ( Front_Back1991 * appendResult5078 );
           		float4 texArray5150 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5079_0, _Texture_16_Albedo_Index );
           		float2 temp_output_5085_0 = ( Left_Right2003 * appendResult5078 );
           		float4 texArray5145 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_5085_0, _Texture_16_Albedo_Index );
           		float3 weightedBlendVar5556 = BlendComponents91;
           		float4 weightedAvg5556 = ( ( weightedBlendVar5556.x*texArray5150 + weightedBlendVar5556.y*texArray5139 + weightedBlendVar5556.z*texArray5145 )/( weightedBlendVar5556.x + weightedBlendVar5556.y + weightedBlendVar5556.z ) );
           		float4 texArray5144 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5079_0 / _Texture_16_Far_Multiplier ), _Texture_16_Albedo_Index );
           		float4 texArray5154 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( temp_output_5085_0 / _Texture_16_Far_Multiplier ), _Texture_16_Albedo_Index );
           		float3 weightedBlendVar5558 = BlendComponents91;
           		float4 weightedAvg5558 = ( ( weightedBlendVar5558.x*texArray5144 + weightedBlendVar5558.y*texArray5143 + weightedBlendVar5558.z*texArray5154 )/( weightedBlendVar5558.x + weightedBlendVar5558.y + weightedBlendVar5558.z ) );
           		float4 lerpResult5104 = lerp( weightedAvg5556 , weightedAvg5558 , UVmixDistance636);
           		float4 ifLocalVar5816 = 0;
           		UNITY_BRANCH 
           		if( _Texture_16_Triplanar == 1.0 )
           		ifLocalVar5816 = lerpResult5104;
           		else
           		ifLocalVar5816 = lerpResult5817;
           		float4 ifLocalVar6183 = 0;
           		UNITY_BRANCH 
           		if( _Texture_16_Albedo_Index > -1.0 )
           		ifLocalVar6183 = ( ifLocalVar5816 * _Texture_16_Color );
           		half4 Texture_16_Final5094 = ifLocalVar6183;
           		float4 layeredBlendVar5646 = tex2DNode4371;
           		float4 layeredBlend5646 = ( lerp( lerp( lerp( lerp( layeredBlend5645 , Texture_13_Final5058 , layeredBlendVar5646.x ) , Texture_14_Final5163 , layeredBlendVar5646.y ) , Texture_15_Final5270 , layeredBlendVar5646.z ) , Texture_16_Final5094 , layeredBlendVar5646.w ) );
           		float4 break3856 = layeredBlend5646;
           		float3 appendResult3857 = (float3(break3856.x , break3856.y , break3856.z));
           		float3 appendResult6206 = (float3(tex2DNode6204.r , tex2DNode6204.g , tex2DNode6204.b));
           		float2 weightedBlendVar6240 = appendResult6241;
           		float3 weightedAvg6240 = ( ( weightedBlendVar6240.x*appendResult3857 + weightedBlendVar6240.y*appendResult6206 )/( weightedBlendVar6240.x + weightedBlendVar6240.y ) );
           		float2 temp_cast_0 = (( _Geological_Map_Offset_Close + ( ase_worldPos.y / _Geological_Tiling_Close ) )).xx;
           		float4 tex2DNode5984 = tex2D( _Texture_Geological_Map, temp_cast_0 );
           		float3 appendResult5986 = (float3(tex2DNode5984.r , tex2DNode5984.g , tex2DNode5984.b));
           		float2 temp_cast_1 = (( ( ase_worldPos.y / _Geological_Tiling_Far ) + _Geological_Map_Offset_Far )).xx;
           		float4 tex2DNode5983 = tex2D( _Texture_Geological_Map, temp_cast_1 );
           		float3 appendResult5985 = (float3(tex2DNode5983.r , tex2DNode5983.g , tex2DNode5983.b));
           		float3 lerpResult1315 = lerp( ( _Geological_Map_Close_Power * ( appendResult5986 + float3( -0.3,-0.3,-0.3 ) ) ) , ( _Geological_Map_Far_Power * ( appendResult5985 + float3( -0.3,-0.3,-0.3 ) ) ) , UVmixDistance636);
           		half Splat4_A2546 = tex2DNode4371.a;
           		half Splat4_B2545 = tex2DNode4371.b;
           		half Splat4_G2544 = tex2DNode4371.g;
           		half Splat4_R2543 = tex2DNode4371.r;
           		half Splat3_A2540 = tex2DNode4370.a;
           		half Splat3_B2539 = tex2DNode4370.b;
           		half Splat3_G2538 = tex2DNode4370.g;
           		half Splat3_R2537 = tex2DNode4370.r;
           		half Splat2_A2109 = tex2DNode4369.a;
           		half Splat2_B2108 = tex2DNode4369.b;
           		half Splat2_G2107 = tex2DNode4369.g;
           		half Splat2_R2106 = tex2DNode4369.r;
           		half Splat1_R1438 = tex2DNode4368.r;
           		half Splat1_G1441 = tex2DNode4368.g;
           		half Splat1_A1491 = tex2DNode4368.a;
           		half Splat1_B1442 = tex2DNode4368.b;
           		float3 blendOpSrc4362 = weightedAvg6240;
           		float3 blendOpDest4362 = ( lerpResult1315 * ( ( _Texture_16_Geological_Power * Splat4_A2546 ) + ( ( _Texture_15_Geological_Power * Splat4_B2545 ) + ( ( _Texture_14_Geological_Power * Splat4_G2544 ) + ( ( _Texture_13_Geological_Power * Splat4_R2543 ) + ( ( _Texture_12_Geological_Power * Splat3_A2540 ) + ( ( _Texture_11_Geological_Power * Splat3_B2539 ) + ( ( _Texture_10_Geological_Power * Splat3_G2538 ) + ( ( _Texture_9_Geological_Power * Splat3_R2537 ) + ( ( _Texture_8_Geological_Power * Splat2_A2109 ) + ( ( _Texture_7_Geological_Power * Splat2_B2108 ) + ( ( _Texture_6_Geological_Power * Splat2_G2107 ) + ( ( _Texture_5_Geological_Power * Splat2_R2106 ) + ( ( _Texture_1_Geological_Power * Splat1_R1438 ) + ( ( _Texture_2_Geological_Power * Splat1_G1441 ) + ( ( _Texture_4_Geological_Power * Splat1_A1491 ) + ( _Texture_3_Geological_Power * Splat1_B1442 ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) );
           		float3 clampResult5715 = clamp( ( saturate( ( blendOpSrc4362 + blendOpDest4362 ) )) , float3( 0,0,0 ) , float3( 1,1,1 ) );
           		float2 temp_output_3893_0 = ( Top_Bottom1999 / _Snow_Tiling );
           		float4 texArray4378 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, temp_output_3893_0, _Texture_Snow_Index );
           		float4 lerpResult1416 = lerp( texArray4378 , _Texture_Snow_Average , UVmixDistance636);
           		float4 ifLocalVar6165 = 0;
           		UNITY_BRANCH 
           		if( _Texture_Snow_Index > -1.0 )
           		ifLocalVar6165 = ( lerpResult1416 * _Snow_Color );
           		float4 break1409 = ifLocalVar6165;
           		float3 appendResult1410 = (float3(break1409.x , break1409.y , break1409.z));
           		half3 In06279 = float3( 0,0,0 );
           		half localMyCustomExpression6279 = MyCustomExpression6279( In06279 );
           		float3 break6278 = _WorldSpaceCameraPos;
           		float temp_output_6283_0 = ( _Glitter_Refreshing_Speed * ( ( localMyCustomExpression6279 * 10.0 ) + ( break6278.x + break6278.y + break6278.z ) ) );
           		float temp_output_6286_0 = ( 0.0 + temp_output_6283_0 );
           		float clampResult6298 = clamp( sin( ( temp_output_6286_0 * 0.1 ) ) , 0.0 , 1.0 );
           		float2 temp_output_6289_0 = ( Top_Bottom1999 * ( 1.0 / _Glitter_Tiling ) );
           		float2 break6322 = temp_output_6289_0;
           		float2 appendResult6321 = (float2(break6322.y , break6322.x));
           		float4 tex2DNode6300 = tex2D( _Texture_Glitter, ( appendResult6321 + float2( 0.37,0.67 ) ) );
           		float2 panner6290 = ( ( temp_output_6283_0 * 0.01 ) * float2( 1,1 ) + temp_output_6289_0);
           		float cos6292 = cos( sin( ( temp_output_6286_0 * 0.0001 ) ) );
           		float sin6292 = sin( sin( ( temp_output_6286_0 * 0.0001 ) ) );
           		float2 rotator6292 = mul( panner6290 - float2( 0.5,0.5 ) , float2x2( cos6292 , -sin6292 , sin6292 , cos6292 )) + float2( 0.5,0.5 );
           		float clampResult6302 = clamp( pow( tex2D( _Texture_Glitter, ( ( rotator6292 + temp_output_6289_0 ) * float2( 0.2,0.2 ) ) ).r , ( 1.0 - _Glitter_Noise_Threshold ) ) , 0.0 , 1.0 );
           		float lerpResult6303 = lerp(  ( clampResult6298 - 0.2 > 0.0 ? tex2D( _Texture_Glitter, temp_output_6289_0 ).r : clampResult6298 - 0.2 <= 0.0 && clampResult6298 + 0.2 >= 0.0 ? tex2DNode6300.r : tex2DNode6300.r )  , 0.6 , clampResult6302);
           		float clampResult6305 = clamp( pow( lerpResult6303 , 100.0 ) , 0.0 , 1.0 );
           		float temp_output_6306_0 = ( _Gliter_Color_Power * clampResult6305 );
           		float4 texArray3300 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3275_0, _Texture_1_Normal_Index );
           		float2 appendResult11_g1028 = (float2(texArray3300.w , texArray3300.y));
           		float2 temp_output_4_0_g1028 = ( ( ( appendResult11_g1028 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_1_Normal_Power );
           		float2 break8_g1028 = temp_output_4_0_g1028;
           		float dotResult5_g1028 = dot( temp_output_4_0_g1028 , temp_output_4_0_g1028 );
           		float temp_output_9_0_g1028 = sqrt( ( 1.0 - saturate( dotResult5_g1028 ) ) );
           		float3 appendResult20_g1028 = (float3(break8_g1028.x , break8_g1028.y , temp_output_9_0_g1028));
           		float3 temp_output_6001_0 = appendResult20_g1028;
           		float4 texArray3299 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3279_0, _Texture_1_Normal_Index );
           		float2 appendResult11_g837 = (float2(texArray3299.w , texArray3299.y));
           		float2 temp_output_4_0_g837 = ( ( ( appendResult11_g837 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_1_Normal_Power * -1.0 ) );
           		float2 break8_g837 = temp_output_4_0_g837;
           		float dotResult5_g837 = dot( temp_output_4_0_g837 , temp_output_4_0_g837 );
           		float temp_output_9_0_g837 = sqrt( ( 1.0 - saturate( dotResult5_g837 ) ) );
           		float3 appendResult21_g837 = (float3(break8_g837.y , break8_g837.x , temp_output_9_0_g837));
           		float3 appendResult5874 = (float3(ase_worldNormal.x , -1.0 , 1.0));
           		float4 texArray3301 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3277_0, _Texture_1_Normal_Index );
           		float2 appendResult11_g838 = (float2(texArray3301.w , texArray3301.y));
           		float2 temp_output_4_0_g838 = ( ( ( appendResult11_g838 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_1_Normal_Power );
           		float2 break8_g838 = temp_output_4_0_g838;
           		float dotResult5_g838 = dot( temp_output_4_0_g838 , temp_output_4_0_g838 );
           		float temp_output_9_0_g838 = sqrt( ( 1.0 - saturate( dotResult5_g838 ) ) );
           		float3 appendResult20_g838 = (float3(break8_g838.x , break8_g838.y , temp_output_9_0_g838));
           		float3 appendResult5876 = (float3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
           		float3 weightedBlendVar5676 = BlendComponents91;
           		float3 weightedAvg5676 = ( ( weightedBlendVar5676.x*( appendResult21_g837 * appendResult5874 ) + weightedBlendVar5676.y*temp_output_6001_0 + weightedBlendVar5676.z*( appendResult20_g838 * appendResult5876 ) )/( weightedBlendVar5676.x + weightedBlendVar5676.y + weightedBlendVar5676.z ) );
           		float3 ifLocalVar5783 = 0;
           		UNITY_BRANCH 
           		if( _Texture_1_Triplanar == 1.0 )
           		ifLocalVar5783 = weightedAvg5676;
           		else
           		ifLocalVar5783 = temp_output_6001_0;
           		half3 EmptyNRM6172 = half3(0,0,1);
           		float3 ifLocalVar6127 = 0;
           		UNITY_BRANCH 
           		if( _Texture_1_Normal_Index <= -1.0 )
           		ifLocalVar6127 = EmptyNRM6172;
           		else
           		ifLocalVar6127 = ifLocalVar5783;
           		half3 Normal_1569 = ifLocalVar6127;
           		float4 texArray3350 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3343_0, _Texture_2_Normal_Index );
           		float2 appendResult11_g1024 = (float2(texArray3350.w , texArray3350.y));
           		float2 temp_output_4_0_g1024 = ( ( ( appendResult11_g1024 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_2_Normal_Power );
           		float2 break8_g1024 = temp_output_4_0_g1024;
           		float dotResult5_g1024 = dot( temp_output_4_0_g1024 , temp_output_4_0_g1024 );
           		float temp_output_9_0_g1024 = sqrt( ( 1.0 - saturate( dotResult5_g1024 ) ) );
           		float3 appendResult20_g1024 = (float3(break8_g1024.x , break8_g1024.y , temp_output_9_0_g1024));
           		float3 temp_output_6005_0 = appendResult20_g1024;
           		float4 texArray3384 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3344_0, _Texture_2_Normal_Index );
           		float2 appendResult11_g832 = (float2(texArray3384.w , texArray3384.y));
           		float2 temp_output_4_0_g832 = ( ( ( appendResult11_g832 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_2_Normal_Power * -1.0 ) );
           		float2 break8_g832 = temp_output_4_0_g832;
           		float dotResult5_g832 = dot( temp_output_4_0_g832 , temp_output_4_0_g832 );
           		float temp_output_9_0_g832 = sqrt( ( 1.0 - saturate( dotResult5_g832 ) ) );
           		float3 appendResult21_g832 = (float3(break8_g832.y , break8_g832.x , temp_output_9_0_g832));
           		float3 appendResult5879 = (float3(ase_worldNormal.x , -1.0 , 1.0));
           		float4 texArray3351 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3379_0, _Texture_2_Normal_Index );
           		float2 appendResult11_g836 = (float2(texArray3351.w , texArray3351.y));
           		float2 temp_output_4_0_g836 = ( ( ( appendResult11_g836 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_2_Normal_Power );
           		float2 break8_g836 = temp_output_4_0_g836;
           		float dotResult5_g836 = dot( temp_output_4_0_g836 , temp_output_4_0_g836 );
           		float temp_output_9_0_g836 = sqrt( ( 1.0 - saturate( dotResult5_g836 ) ) );
           		float3 appendResult20_g836 = (float3(break8_g836.x , break8_g836.y , temp_output_9_0_g836));
           		float3 appendResult5882 = (float3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
           		float3 weightedBlendVar5499 = BlendComponents91;
           		float3 weightedAvg5499 = ( ( weightedBlendVar5499.x*( appendResult21_g832 * appendResult5879 ) + weightedBlendVar5499.y*temp_output_6005_0 + weightedBlendVar5499.z*( appendResult20_g836 * appendResult5882 ) )/( weightedBlendVar5499.x + weightedBlendVar5499.y + weightedBlendVar5499.z ) );
           		float3 ifLocalVar5774 = 0;
           		UNITY_BRANCH 
           		if( _Texture_2_Triplanar == 1.0 )
           		ifLocalVar5774 = weightedAvg5499;
           		else
           		ifLocalVar5774 = temp_output_6005_0;
           		float3 ifLocalVar6129 = 0;
           		UNITY_BRANCH 
           		if( _Texture_2_Normal_Index <= -1.0 )
           		ifLocalVar6129 = EmptyNRM6172;
           		else
           		ifLocalVar6129 = ifLocalVar5774;
           		half3 Normal_23361 = ifLocalVar6129;
           		float4 texArray3416 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3410_0, _Texture_3_Normal_Index );
           		float2 appendResult11_g1029 = (float2(texArray3416.w , texArray3416.y));
           		float2 temp_output_4_0_g1029 = ( ( ( appendResult11_g1029 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_3_Normal_Power );
           		float2 break8_g1029 = temp_output_4_0_g1029;
           		float dotResult5_g1029 = dot( temp_output_4_0_g1029 , temp_output_4_0_g1029 );
           		float temp_output_9_0_g1029 = sqrt( ( 1.0 - saturate( dotResult5_g1029 ) ) );
           		float3 appendResult20_g1029 = (float3(break8_g1029.x , break8_g1029.y , temp_output_9_0_g1029));
           		float3 temp_output_6008_0 = appendResult20_g1029;
           		float4 texArray3445 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3413_0, _Texture_3_Normal_Index );
           		float2 appendResult11_g833 = (float2(texArray3445.w , texArray3445.y));
           		float2 temp_output_4_0_g833 = ( ( ( appendResult11_g833 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_3_Normal_Power * -1.0 ) );
           		float2 break8_g833 = temp_output_4_0_g833;
           		float dotResult5_g833 = dot( temp_output_4_0_g833 , temp_output_4_0_g833 );
           		float temp_output_9_0_g833 = sqrt( ( 1.0 - saturate( dotResult5_g833 ) ) );
           		float3 appendResult21_g833 = (float3(break8_g833.y , break8_g833.x , temp_output_9_0_g833));
           		float3 appendResult5886 = (float3(ase_worldNormal.x , -1.0 , 1.0));
           		float4 texArray3417 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3441_0, _Texture_3_Normal_Index );
           		float2 appendResult11_g835 = (float2(texArray3417.w , texArray3417.y));
           		float2 temp_output_4_0_g835 = ( ( ( appendResult11_g835 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_3_Normal_Power );
           		float2 break8_g835 = temp_output_4_0_g835;
           		float dotResult5_g835 = dot( temp_output_4_0_g835 , temp_output_4_0_g835 );
           		float temp_output_9_0_g835 = sqrt( ( 1.0 - saturate( dotResult5_g835 ) ) );
           		float3 appendResult20_g835 = (float3(break8_g835.x , break8_g835.y , temp_output_9_0_g835));
           		float3 appendResult5889 = (float3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
           		float3 weightedBlendVar5503 = BlendComponents91;
           		float3 weightedAvg5503 = ( ( weightedBlendVar5503.x*( appendResult21_g833 * appendResult5886 ) + weightedBlendVar5503.y*temp_output_6008_0 + weightedBlendVar5503.z*( appendResult20_g835 * appendResult5889 ) )/( weightedBlendVar5503.x + weightedBlendVar5503.y + weightedBlendVar5503.z ) );
           		float3 ifLocalVar5776 = 0;
           		UNITY_BRANCH 
           		if( _Texture_3_Triplanar == 1.0 )
           		ifLocalVar5776 = weightedAvg5503;
           		else
           		ifLocalVar5776 = temp_output_6008_0;
           		float3 ifLocalVar6131 = 0;
           		UNITY_BRANCH 
           		if( _Texture_3_Normal_Index > -1.0 )
           		ifLocalVar6131 = ifLocalVar5776;
           		half3 Normal_33452 = ifLocalVar6131;
           		float4 texArray3483 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3477_0, _Texture_4_Normal_Index );
           		float2 appendResult11_g1022 = (float2(texArray3483.w , texArray3483.y));
           		float2 temp_output_4_0_g1022 = ( ( ( appendResult11_g1022 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_4_Normal_Power );
           		float2 break8_g1022 = temp_output_4_0_g1022;
           		float dotResult5_g1022 = dot( temp_output_4_0_g1022 , temp_output_4_0_g1022 );
           		float temp_output_9_0_g1022 = sqrt( ( 1.0 - saturate( dotResult5_g1022 ) ) );
           		float3 appendResult20_g1022 = (float3(break8_g1022.x , break8_g1022.y , temp_output_9_0_g1022));
           		float3 temp_output_6011_0 = appendResult20_g1022;
           		float4 texArray3512 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3478_0, _Texture_4_Normal_Index );
           		float2 appendResult11_g831 = (float2(texArray3512.w , texArray3512.y));
           		float2 temp_output_4_0_g831 = ( ( ( appendResult11_g831 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_4_Normal_Power * -1.0 ) );
           		float2 break8_g831 = temp_output_4_0_g831;
           		float dotResult5_g831 = dot( temp_output_4_0_g831 , temp_output_4_0_g831 );
           		float temp_output_9_0_g831 = sqrt( ( 1.0 - saturate( dotResult5_g831 ) ) );
           		float3 appendResult21_g831 = (float3(break8_g831.y , break8_g831.x , temp_output_9_0_g831));
           		float3 appendResult5893 = (float3(ase_worldNormal.x , -1.0 , 1.0));
           		float4 texArray3484 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3508_0, _Texture_4_Normal_Index );
           		float2 appendResult11_g834 = (float2(texArray3484.w , texArray3484.y));
           		float2 temp_output_4_0_g834 = ( ( ( appendResult11_g834 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_4_Normal_Power );
           		float2 break8_g834 = temp_output_4_0_g834;
           		float dotResult5_g834 = dot( temp_output_4_0_g834 , temp_output_4_0_g834 );
           		float temp_output_9_0_g834 = sqrt( ( 1.0 - saturate( dotResult5_g834 ) ) );
           		float3 appendResult20_g834 = (float3(break8_g834.x , break8_g834.y , temp_output_9_0_g834));
           		float3 appendResult5896 = (float3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
           		float3 weightedBlendVar5507 = BlendComponents91;
           		float3 weightedAvg5507 = ( ( weightedBlendVar5507.x*( appendResult21_g831 * appendResult5893 ) + weightedBlendVar5507.y*temp_output_6011_0 + weightedBlendVar5507.z*( appendResult20_g834 * appendResult5896 ) )/( weightedBlendVar5507.x + weightedBlendVar5507.y + weightedBlendVar5507.z ) );
           		float3 ifLocalVar5999 = 0;
           		UNITY_BRANCH 
           		if( _Texture_4_Triplanar == 1.0 )
           		ifLocalVar5999 = weightedAvg5507;
           		else
           		ifLocalVar5999 = temp_output_6011_0;
           		float3 ifLocalVar6133 = 0;
           		UNITY_BRANCH 
           		if( _Texture_4_Normal_Index <= -1.0 )
           		ifLocalVar6133 = EmptyNRM6172;
           		else
           		ifLocalVar6133 = ifLocalVar5999;
           		half3 Normal_43519 = ifLocalVar6133;
           		float4 layeredBlendVar5639 = tex2DNode4368;
           		float3 layeredBlend5639 = ( lerp( lerp( lerp( lerp( float3( 0,0,0 ) , Normal_1569 , layeredBlendVar5639.x ) , Normal_23361 , layeredBlendVar5639.y ) , Normal_33452 , layeredBlendVar5639.z ) , Normal_43519 , layeredBlendVar5639.w ) );
           		float4 texArray4424 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4416_0, _Texture_5_Normal_Index );
           		float2 appendResult11_g1054 = (float2(texArray4424.w , texArray4424.y));
           		float2 temp_output_4_0_g1054 = ( ( ( appendResult11_g1054 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_5_Normal_Power );
           		float2 break8_g1054 = temp_output_4_0_g1054;
           		float dotResult5_g1054 = dot( temp_output_4_0_g1054 , temp_output_4_0_g1054 );
           		float temp_output_9_0_g1054 = sqrt( ( 1.0 - saturate( dotResult5_g1054 ) ) );
           		float3 appendResult20_g1054 = (float3(break8_g1054.x , break8_g1054.y , temp_output_9_0_g1054));
           		float3 temp_output_6014_0 = appendResult20_g1054;
           		float4 texArray4417 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4400_0, _Texture_5_Normal_Index );
           		float2 appendResult11_g1027 = (float2(texArray4417.w , texArray4417.y));
           		float2 temp_output_4_0_g1027 = ( ( ( appendResult11_g1027 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_5_Normal_Power * -1.0 ) );
           		float2 break8_g1027 = temp_output_4_0_g1027;
           		float dotResult5_g1027 = dot( temp_output_4_0_g1027 , temp_output_4_0_g1027 );
           		float temp_output_9_0_g1027 = sqrt( ( 1.0 - saturate( dotResult5_g1027 ) ) );
           		float3 appendResult21_g1027 = (float3(break8_g1027.y , break8_g1027.x , temp_output_9_0_g1027));
           		float3 appendResult5900 = (float3(ase_worldNormal.x , -1.0 , 1.0));
           		float4 texArray4422 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4413_0, _Texture_5_Normal_Index );
           		float2 appendResult11_g1025 = (float2(texArray4422.w , texArray4422.y));
           		float2 temp_output_4_0_g1025 = ( ( ( appendResult11_g1025 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_5_Normal_Power );
           		float2 break8_g1025 = temp_output_4_0_g1025;
           		float dotResult5_g1025 = dot( temp_output_4_0_g1025 , temp_output_4_0_g1025 );
           		float temp_output_9_0_g1025 = sqrt( ( 1.0 - saturate( dotResult5_g1025 ) ) );
           		float3 appendResult20_g1025 = (float3(break8_g1025.x , break8_g1025.y , temp_output_9_0_g1025));
           		float3 appendResult5903 = (float3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
           		float3 weightedBlendVar5511 = BlendComponents91;
           		float3 weightedAvg5511 = ( ( weightedBlendVar5511.x*( appendResult21_g1027 * appendResult5900 ) + weightedBlendVar5511.y*temp_output_6014_0 + weightedBlendVar5511.z*( appendResult20_g1025 * appendResult5903 ) )/( weightedBlendVar5511.x + weightedBlendVar5511.y + weightedBlendVar5511.z ) );
           		float3 ifLocalVar5806 = 0;
           		UNITY_BRANCH 
           		if( _Texture_5_Triplanar == 1.0 )
           		ifLocalVar5806 = weightedAvg5511;
           		else
           		ifLocalVar5806 = temp_output_6014_0;
           		float3 ifLocalVar6135 = 0;
           		UNITY_BRANCH 
           		if( _Texture_5_Normal_Index <= -1.0 )
           		ifLocalVar6135 = EmptyNRM6172;
           		else
           		ifLocalVar6135 = ifLocalVar5806;
           		half3 Normal_54456 = ifLocalVar6135;
           		float4 texArray4493 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4485_0, _Texture_6_Normal_Index );
           		float2 appendResult11_g1058 = (float2(texArray4493.w , texArray4493.y));
           		float2 temp_output_4_0_g1058 = ( ( ( appendResult11_g1058 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_6_Normal_Power );
           		float2 break8_g1058 = temp_output_4_0_g1058;
           		float dotResult5_g1058 = dot( temp_output_4_0_g1058 , temp_output_4_0_g1058 );
           		float temp_output_9_0_g1058 = sqrt( ( 1.0 - saturate( dotResult5_g1058 ) ) );
           		float3 appendResult20_g1058 = (float3(break8_g1058.x , break8_g1058.y , temp_output_9_0_g1058));
           		float3 temp_output_6017_0 = appendResult20_g1058;
           		float4 texArray4486 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4472_0, _Texture_6_Normal_Index );
           		float2 appendResult11_g1021 = (float2(texArray4486.w , texArray4486.y));
           		float2 temp_output_4_0_g1021 = ( ( ( appendResult11_g1021 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_6_Normal_Power * -1.0 ) );
           		float2 break8_g1021 = temp_output_4_0_g1021;
           		float dotResult5_g1021 = dot( temp_output_4_0_g1021 , temp_output_4_0_g1021 );
           		float temp_output_9_0_g1021 = sqrt( ( 1.0 - saturate( dotResult5_g1021 ) ) );
           		float3 appendResult21_g1021 = (float3(break8_g1021.y , break8_g1021.x , temp_output_9_0_g1021));
           		float3 appendResult5907 = (float3(ase_worldNormal.x , -1.0 , 1.0));
           		float4 texArray4491 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4483_0, _Texture_6_Normal_Index );
           		float2 appendResult11_g1023 = (float2(texArray4491.w , texArray4491.y));
           		float2 temp_output_4_0_g1023 = ( ( ( appendResult11_g1023 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_6_Normal_Power );
           		float2 break8_g1023 = temp_output_4_0_g1023;
           		float dotResult5_g1023 = dot( temp_output_4_0_g1023 , temp_output_4_0_g1023 );
           		float temp_output_9_0_g1023 = sqrt( ( 1.0 - saturate( dotResult5_g1023 ) ) );
           		float3 appendResult20_g1023 = (float3(break8_g1023.x , break8_g1023.y , temp_output_9_0_g1023));
           		float3 appendResult5910 = (float3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
           		float3 weightedBlendVar5519 = BlendComponents91;
           		float3 weightedAvg5519 = ( ( weightedBlendVar5519.x*( appendResult21_g1021 * appendResult5907 ) + weightedBlendVar5519.y*temp_output_6017_0 + weightedBlendVar5519.z*( appendResult20_g1023 * appendResult5910 ) )/( weightedBlendVar5519.x + weightedBlendVar5519.y + weightedBlendVar5519.z ) );
           		float3 ifLocalVar5807 = 0;
           		UNITY_BRANCH 
           		if( _Texture_6_Triplanar == 1.0 )
           		ifLocalVar5807 = weightedAvg5519;
           		else
           		ifLocalVar5807 = temp_output_6017_0;
           		float3 ifLocalVar6138 = 0;
           		UNITY_BRANCH 
           		if( _Texture_6_Normal_Index <= -1.0 )
           		ifLocalVar6138 = EmptyNRM6172;
           		else
           		ifLocalVar6138 = ifLocalVar5807;
           		half3 Normal_64537 = ifLocalVar6138;
           		float4 texArray4567 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4559_0, _Texture_7_Normal_Index );
           		float2 appendResult11_g1056 = (float2(texArray4567.w , texArray4567.y));
           		float2 temp_output_4_0_g1056 = ( ( ( appendResult11_g1056 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_7_Normal_Power );
           		float2 break8_g1056 = temp_output_4_0_g1056;
           		float dotResult5_g1056 = dot( temp_output_4_0_g1056 , temp_output_4_0_g1056 );
           		float temp_output_9_0_g1056 = sqrt( ( 1.0 - saturate( dotResult5_g1056 ) ) );
           		float3 appendResult20_g1056 = (float3(break8_g1056.x , break8_g1056.y , temp_output_9_0_g1056));
           		float3 temp_output_6020_0 = appendResult20_g1056;
           		float4 texArray4560 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4546_0, _Texture_7_Normal_Index );
           		float2 appendResult11_g1031 = (float2(texArray4560.w , texArray4560.y));
           		float2 temp_output_4_0_g1031 = ( ( ( appendResult11_g1031 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_7_Normal_Power * -1.0 ) );
           		float2 break8_g1031 = temp_output_4_0_g1031;
           		float dotResult5_g1031 = dot( temp_output_4_0_g1031 , temp_output_4_0_g1031 );
           		float temp_output_9_0_g1031 = sqrt( ( 1.0 - saturate( dotResult5_g1031 ) ) );
           		float3 appendResult21_g1031 = (float3(break8_g1031.y , break8_g1031.x , temp_output_9_0_g1031));
           		float3 appendResult5914 = (float3(ase_worldNormal.x , -1.0 , 1.0));
           		float4 texArray4565 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4557_0, _Texture_7_Normal_Index );
           		float2 appendResult11_g1032 = (float2(texArray4565.w , texArray4565.y));
           		float2 temp_output_4_0_g1032 = ( ( ( appendResult11_g1032 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_7_Normal_Power );
           		float2 break8_g1032 = temp_output_4_0_g1032;
           		float dotResult5_g1032 = dot( temp_output_4_0_g1032 , temp_output_4_0_g1032 );
           		float temp_output_9_0_g1032 = sqrt( ( 1.0 - saturate( dotResult5_g1032 ) ) );
           		float3 appendResult20_g1032 = (float3(break8_g1032.x , break8_g1032.y , temp_output_9_0_g1032));
           		float3 appendResult5917 = (float3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
           		float3 weightedBlendVar5523 = BlendComponents91;
           		float3 weightedAvg5523 = ( ( weightedBlendVar5523.x*( appendResult21_g1031 * appendResult5914 ) + weightedBlendVar5523.y*temp_output_6020_0 + weightedBlendVar5523.z*( appendResult20_g1032 * appendResult5917 ) )/( weightedBlendVar5523.x + weightedBlendVar5523.y + weightedBlendVar5523.z ) );
           		float3 ifLocalVar5853 = 0;
           		UNITY_BRANCH 
           		if( _Texture_7_Triplanar == 1.0 )
           		ifLocalVar5853 = weightedAvg5523;
           		else
           		ifLocalVar5853 = temp_output_6020_0;
           		float3 ifLocalVar6140 = 0;
           		UNITY_BRANCH 
           		if( _Texture_7_Normal_Index <= -1.0 )
           		ifLocalVar6140 = EmptyNRM6172;
           		else
           		ifLocalVar6140 = ifLocalVar5853;
           		half3 Normal_74615 = ifLocalVar6140;
           		float4 texArray4641 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4633_0, _Texture_8_Normal_Index );
           		float2 appendResult11_g1050 = (float2(texArray4641.w , texArray4641.y));
           		float2 temp_output_4_0_g1050 = ( ( ( appendResult11_g1050 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_8_Normal_Power );
           		float2 break8_g1050 = temp_output_4_0_g1050;
           		float dotResult5_g1050 = dot( temp_output_4_0_g1050 , temp_output_4_0_g1050 );
           		float temp_output_9_0_g1050 = sqrt( ( 1.0 - saturate( dotResult5_g1050 ) ) );
           		float3 appendResult20_g1050 = (float3(break8_g1050.x , break8_g1050.y , temp_output_9_0_g1050));
           		float3 temp_output_6023_0 = appendResult20_g1050;
           		float4 texArray4634 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4620_0, _Texture_8_Normal_Index );
           		float2 appendResult11_g1030 = (float2(texArray4634.w , texArray4634.y));
           		float2 temp_output_4_0_g1030 = ( ( ( appendResult11_g1030 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_8_Normal_Power * -1.0 ) );
           		float2 break8_g1030 = temp_output_4_0_g1030;
           		float dotResult5_g1030 = dot( temp_output_4_0_g1030 , temp_output_4_0_g1030 );
           		float temp_output_9_0_g1030 = sqrt( ( 1.0 - saturate( dotResult5_g1030 ) ) );
           		float3 appendResult21_g1030 = (float3(break8_g1030.y , break8_g1030.x , temp_output_9_0_g1030));
           		float3 appendResult5921 = (float3(ase_worldNormal.x , -1.0 , 1.0));
           		float4 texArray4639 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4631_0, _Texture_8_Normal_Index );
           		float2 appendResult11_g1026 = (float2(texArray4639.w , texArray4639.y));
           		float2 temp_output_4_0_g1026 = ( ( ( appendResult11_g1026 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_8_Normal_Power );
           		float2 break8_g1026 = temp_output_4_0_g1026;
           		float dotResult5_g1026 = dot( temp_output_4_0_g1026 , temp_output_4_0_g1026 );
           		float temp_output_9_0_g1026 = sqrt( ( 1.0 - saturate( dotResult5_g1026 ) ) );
           		float3 appendResult20_g1026 = (float3(break8_g1026.x , break8_g1026.y , temp_output_9_0_g1026));
           		float3 appendResult5924 = (float3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
           		float3 weightedBlendVar5527 = BlendComponents91;
           		float3 weightedAvg5527 = ( ( weightedBlendVar5527.x*( appendResult21_g1030 * appendResult5921 ) + weightedBlendVar5527.y*temp_output_6023_0 + weightedBlendVar5527.z*( appendResult20_g1026 * appendResult5924 ) )/( weightedBlendVar5527.x + weightedBlendVar5527.y + weightedBlendVar5527.z ) );
           		float3 ifLocalVar5813 = 0;
           		UNITY_BRANCH 
           		if( _Texture_8_Triplanar == 1.0 )
           		ifLocalVar5813 = weightedAvg5527;
           		else
           		ifLocalVar5813 = temp_output_6023_0;
           		float3 ifLocalVar6142 = 0;
           		UNITY_BRANCH 
           		if( _Texture_8_Normal_Index <= -1.0 )
           		ifLocalVar6142 = EmptyNRM6172;
           		else
           		ifLocalVar6142 = ifLocalVar5813;
           		half3 Normal_84690 = ifLocalVar6142;
           		float4 layeredBlendVar5640 = tex2DNode4369;
           		float3 layeredBlend5640 = ( lerp( lerp( lerp( lerp( layeredBlend5639 , Normal_54456 , layeredBlendVar5640.x ) , Normal_64537 , layeredBlendVar5640.y ) , Normal_74615 , layeredBlendVar5640.z ) , Normal_84690 , layeredBlendVar5640.w ) );
           		float4 texArray4788 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4712_0, _Texture_9_Normal_Index );
           		float2 appendResult11_g1062 = (float2(texArray4788.w , texArray4788.y));
           		float2 temp_output_4_0_g1062 = ( ( ( appendResult11_g1062 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_9_Normal_Power );
           		float2 break8_g1062 = temp_output_4_0_g1062;
           		float dotResult5_g1062 = dot( temp_output_4_0_g1062 , temp_output_4_0_g1062 );
           		float temp_output_9_0_g1062 = sqrt( ( 1.0 - saturate( dotResult5_g1062 ) ) );
           		float3 appendResult20_g1062 = (float3(break8_g1062.x , break8_g1062.y , temp_output_9_0_g1062));
           		float3 temp_output_6047_0 = appendResult20_g1062;
           		float4 texArray5285 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4706_0, _Texture_9_Normal_Index );
           		float2 appendResult11_g1053 = (float2(texArray5285.w , texArray5285.y));
           		float2 temp_output_4_0_g1053 = ( ( ( appendResult11_g1053 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_9_Normal_Power * -1.0 ) );
           		float2 break8_g1053 = temp_output_4_0_g1053;
           		float dotResult5_g1053 = dot( temp_output_4_0_g1053 , temp_output_4_0_g1053 );
           		float temp_output_9_0_g1053 = sqrt( ( 1.0 - saturate( dotResult5_g1053 ) ) );
           		float3 appendResult21_g1053 = (float3(break8_g1053.y , break8_g1053.x , temp_output_9_0_g1053));
           		float3 appendResult5977 = (float3(ase_worldNormal.x , -1.0 , 1.0));
           		float4 texArray4783 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4761_0, _Texture_9_Normal_Index );
           		float2 appendResult11_g1055 = (float2(texArray4783.w , texArray4783.y));
           		float2 temp_output_4_0_g1055 = ( ( ( appendResult11_g1055 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_9_Normal_Power );
           		float2 break8_g1055 = temp_output_4_0_g1055;
           		float dotResult5_g1055 = dot( temp_output_4_0_g1055 , temp_output_4_0_g1055 );
           		float temp_output_9_0_g1055 = sqrt( ( 1.0 - saturate( dotResult5_g1055 ) ) );
           		float3 appendResult20_g1055 = (float3(break8_g1055.x , break8_g1055.y , temp_output_9_0_g1055));
           		float3 appendResult5980 = (float3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
           		float3 weightedBlendVar5491 = BlendComponents91;
           		float3 weightedAvg5491 = ( ( weightedBlendVar5491.x*( appendResult21_g1053 * appendResult5977 ) + weightedBlendVar5491.y*temp_output_6047_0 + weightedBlendVar5491.z*( appendResult20_g1055 * appendResult5980 ) )/( weightedBlendVar5491.x + weightedBlendVar5491.y + weightedBlendVar5491.z ) );
           		float3 ifLocalVar5846 = 0;
           		UNITY_BRANCH 
           		if( _Texture_9_Triplanar == 1.0 )
           		ifLocalVar5846 = weightedAvg5491;
           		else
           		ifLocalVar5846 = temp_output_6047_0;
           		float3 ifLocalVar6144 = 0;
           		UNITY_BRANCH 
           		if( _Texture_9_Normal_Index <= -1.0 )
           		ifLocalVar6144 = EmptyNRM6172;
           		else
           		ifLocalVar6144 = ifLocalVar5846;
           		half3 Normal_94897 = ifLocalVar6144;
           		float4 texArray4822 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4793_0, _Texture_10_Normal_Index );
           		float2 appendResult11_g1066 = (float2(texArray4822.w , texArray4822.y));
           		float2 temp_output_4_0_g1066 = ( ( ( appendResult11_g1066 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_10_Normal_Power );
           		float2 break8_g1066 = temp_output_4_0_g1066;
           		float dotResult5_g1066 = dot( temp_output_4_0_g1066 , temp_output_4_0_g1066 );
           		float temp_output_9_0_g1066 = sqrt( ( 1.0 - saturate( dotResult5_g1066 ) ) );
           		float3 appendResult20_g1066 = (float3(break8_g1066.x , break8_g1066.y , temp_output_9_0_g1066));
           		float3 temp_output_6044_0 = appendResult20_g1066;
           		float4 texArray4798 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4742_0, _Texture_10_Normal_Index );
           		float2 appendResult11_g1052 = (float2(texArray4798.w , texArray4798.y));
           		float2 temp_output_4_0_g1052 = ( ( ( appendResult11_g1052 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_10_Normal_Power * -1.0 ) );
           		float2 break8_g1052 = temp_output_4_0_g1052;
           		float dotResult5_g1052 = dot( temp_output_4_0_g1052 , temp_output_4_0_g1052 );
           		float temp_output_9_0_g1052 = sqrt( ( 1.0 - saturate( dotResult5_g1052 ) ) );
           		float3 appendResult21_g1052 = (float3(break8_g1052.y , break8_g1052.x , temp_output_9_0_g1052));
           		float3 appendResult5970 = (float3(ase_worldNormal.x , -1.0 , 1.0));
           		float4 texArray4791 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4785_0, _Texture_10_Normal_Index );
           		float2 appendResult11_g1060 = (float2(texArray4791.w , texArray4791.y));
           		float2 temp_output_4_0_g1060 = ( ( ( appendResult11_g1060 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_10_Normal_Power );
           		float2 break8_g1060 = temp_output_4_0_g1060;
           		float dotResult5_g1060 = dot( temp_output_4_0_g1060 , temp_output_4_0_g1060 );
           		float temp_output_9_0_g1060 = sqrt( ( 1.0 - saturate( dotResult5_g1060 ) ) );
           		float3 appendResult20_g1060 = (float3(break8_g1060.x , break8_g1060.y , temp_output_9_0_g1060));
           		float3 appendResult5973 = (float3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
           		float3 weightedBlendVar5531 = BlendComponents91;
           		float3 weightedAvg5531 = ( ( weightedBlendVar5531.x*( appendResult21_g1052 * appendResult5970 ) + weightedBlendVar5531.y*temp_output_6044_0 + weightedBlendVar5531.z*( appendResult20_g1060 * appendResult5973 ) )/( weightedBlendVar5531.x + weightedBlendVar5531.y + weightedBlendVar5531.z ) );
           		float3 ifLocalVar5842 = 0;
           		UNITY_BRANCH 
           		if( _Texture_10_Triplanar == 1.0 )
           		ifLocalVar5842 = weightedAvg5531;
           		else
           		ifLocalVar5842 = temp_output_6044_0;
           		float3 ifLocalVar6146 = 0;
           		UNITY_BRANCH 
           		if( _Texture_10_Normal_Index <= -1.0 )
           		ifLocalVar6146 = EmptyNRM6172;
           		else
           		ifLocalVar6146 = ifLocalVar5842;
           		half3 Normal_104918 = ifLocalVar6146;
           		float4 texArray4856 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4817_0, _Texture_11_Normal_Index );
           		float2 appendResult11_g1065 = (float2(texArray4856.w , texArray4856.y));
           		float2 temp_output_4_0_g1065 = ( ( ( appendResult11_g1065 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_11_Normal_Power );
           		float2 break8_g1065 = temp_output_4_0_g1065;
           		float dotResult5_g1065 = dot( temp_output_4_0_g1065 , temp_output_4_0_g1065 );
           		float temp_output_9_0_g1065 = sqrt( ( 1.0 - saturate( dotResult5_g1065 ) ) );
           		float3 appendResult20_g1065 = (float3(break8_g1065.x , break8_g1065.y , temp_output_9_0_g1065));
           		float3 temp_output_6041_0 = appendResult20_g1065;
           		float4 texArray4828 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4748_0, _Texture_11_Normal_Index );
           		float2 appendResult11_g1051 = (float2(texArray4828.w , texArray4828.y));
           		float2 temp_output_4_0_g1051 = ( ( ( appendResult11_g1051 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_11_Normal_Power * -1.0 ) );
           		float2 break8_g1051 = temp_output_4_0_g1051;
           		float dotResult5_g1051 = dot( temp_output_4_0_g1051 , temp_output_4_0_g1051 );
           		float temp_output_9_0_g1051 = sqrt( ( 1.0 - saturate( dotResult5_g1051 ) ) );
           		float3 appendResult21_g1051 = (float3(break8_g1051.y , break8_g1051.x , temp_output_9_0_g1051));
           		float3 appendResult5963 = (float3(ase_worldNormal.x , -1.0 , 1.0));
           		float4 texArray4811 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4795_0, _Texture_11_Normal_Index );
           		float2 appendResult11_g1059 = (float2(texArray4811.w , texArray4811.y));
           		float2 temp_output_4_0_g1059 = ( ( ( appendResult11_g1059 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_11_Normal_Power );
           		float2 break8_g1059 = temp_output_4_0_g1059;
           		float dotResult5_g1059 = dot( temp_output_4_0_g1059 , temp_output_4_0_g1059 );
           		float temp_output_9_0_g1059 = sqrt( ( 1.0 - saturate( dotResult5_g1059 ) ) );
           		float3 appendResult20_g1059 = (float3(break8_g1059.x , break8_g1059.y , temp_output_9_0_g1059));
           		float3 appendResult5966 = (float3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
           		float3 weightedBlendVar5535 = BlendComponents91;
           		float3 weightedAvg5535 = ( ( weightedBlendVar5535.x*( appendResult21_g1051 * appendResult5963 ) + weightedBlendVar5535.y*temp_output_6041_0 + weightedBlendVar5535.z*( appendResult20_g1059 * appendResult5966 ) )/( weightedBlendVar5535.x + weightedBlendVar5535.y + weightedBlendVar5535.z ) );
           		float3 ifLocalVar5838 = 0;
           		UNITY_BRANCH 
           		if( _Texture_11_Triplanar == 1.0 )
           		ifLocalVar5838 = weightedAvg5535;
           		else
           		ifLocalVar5838 = temp_output_6041_0;
           		float3 ifLocalVar6148 = 0;
           		UNITY_BRANCH 
           		if( _Texture_11_Normal_Index <= -1.0 )
           		ifLocalVar6148 = EmptyNRM6172;
           		else
           		ifLocalVar6148 = ifLocalVar5838;
           		half3 Normal_114948 = ifLocalVar6148;
           		float4 texArray4870 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4849_0, _Texture_12_Normal_Index );
           		float2 appendResult11_g1068 = (float2(texArray4870.w , texArray4870.y));
           		float2 temp_output_4_0_g1068 = ( ( ( appendResult11_g1068 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_12_Normal_Power );
           		float2 break8_g1068 = temp_output_4_0_g1068;
           		float dotResult5_g1068 = dot( temp_output_4_0_g1068 , temp_output_4_0_g1068 );
           		float temp_output_9_0_g1068 = sqrt( ( 1.0 - saturate( dotResult5_g1068 ) ) );
           		float3 appendResult20_g1068 = (float3(break8_g1068.x , break8_g1068.y , temp_output_9_0_g1068));
           		float3 temp_output_6038_0 = appendResult20_g1068;
           		float4 texArray4850 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4758_0, _Texture_12_Normal_Index );
           		float2 appendResult11_g1049 = (float2(texArray4850.w , texArray4850.y));
           		float2 temp_output_4_0_g1049 = ( ( ( appendResult11_g1049 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_12_Normal_Power * -1.0 ) );
           		float2 break8_g1049 = temp_output_4_0_g1049;
           		float dotResult5_g1049 = dot( temp_output_4_0_g1049 , temp_output_4_0_g1049 );
           		float temp_output_9_0_g1049 = sqrt( ( 1.0 - saturate( dotResult5_g1049 ) ) );
           		float3 appendResult21_g1049 = (float3(break8_g1049.y , break8_g1049.x , temp_output_9_0_g1049));
           		float3 appendResult5956 = (float3(ase_worldNormal.x , -1.0 , 1.0));
           		float4 texArray4852 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_4830_0, _Texture_12_Normal_Index );
           		float2 appendResult11_g1057 = (float2(texArray4852.w , texArray4852.y));
           		float2 temp_output_4_0_g1057 = ( ( ( appendResult11_g1057 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_12_Normal_Power );
           		float2 break8_g1057 = temp_output_4_0_g1057;
           		float dotResult5_g1057 = dot( temp_output_4_0_g1057 , temp_output_4_0_g1057 );
           		float temp_output_9_0_g1057 = sqrt( ( 1.0 - saturate( dotResult5_g1057 ) ) );
           		float3 appendResult20_g1057 = (float3(break8_g1057.x , break8_g1057.y , temp_output_9_0_g1057));
           		float3 appendResult5959 = (float3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
           		float3 weightedBlendVar5539 = BlendComponents91;
           		float3 weightedAvg5539 = ( ( weightedBlendVar5539.x*( appendResult21_g1049 * appendResult5956 ) + weightedBlendVar5539.y*temp_output_6038_0 + weightedBlendVar5539.z*( appendResult20_g1057 * appendResult5959 ) )/( weightedBlendVar5539.x + weightedBlendVar5539.y + weightedBlendVar5539.z ) );
           		float3 ifLocalVar5834 = 0;
           		UNITY_BRANCH 
           		if( _Texture_12_Triplanar == 1.0 )
           		ifLocalVar5834 = weightedAvg5539;
           		else
           		ifLocalVar5834 = temp_output_6038_0;
           		float3 ifLocalVar6150 = 0;
           		UNITY_BRANCH 
           		if( _Texture_12_Normal_Index <= -1.0 )
           		ifLocalVar6150 = EmptyNRM6172;
           		else
           		ifLocalVar6150 = ifLocalVar5834;
           		half3 Normal_124962 = ifLocalVar6150;
           		float4 layeredBlendVar5641 = tex2DNode4370;
           		float3 layeredBlend5641 = ( lerp( lerp( lerp( lerp( layeredBlend5640 , Normal_94897 , layeredBlendVar5641.x ) , Normal_104918 , layeredBlendVar5641.y ) , Normal_114948 , layeredBlendVar5641.z ) , Normal_124962 , layeredBlendVar5641.w ) );
           		float4 texArray5120 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5037_0, _Texture_13_Normal_Index );
           		float2 appendResult11_g1076 = (float2(texArray5120.w , texArray5120.y));
           		float2 temp_output_4_0_g1076 = ( ( ( appendResult11_g1076 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_13_Normal_Power );
           		float2 break8_g1076 = temp_output_4_0_g1076;
           		float dotResult5_g1076 = dot( temp_output_4_0_g1076 , temp_output_4_0_g1076 );
           		float temp_output_9_0_g1076 = sqrt( ( 1.0 - saturate( dotResult5_g1076 ) ) );
           		float3 appendResult20_g1076 = (float3(break8_g1076.x , break8_g1076.y , temp_output_9_0_g1076));
           		float3 temp_output_6035_0 = appendResult20_g1076;
           		float4 texArray5127 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5025_0, _Texture_13_Normal_Index );
           		float2 appendResult11_g1067 = (float2(texArray5127.w , texArray5127.y));
           		float2 temp_output_4_0_g1067 = ( ( ( appendResult11_g1067 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_13_Normal_Power * -1.0 ) );
           		float2 break8_g1067 = temp_output_4_0_g1067;
           		float dotResult5_g1067 = dot( temp_output_4_0_g1067 , temp_output_4_0_g1067 );
           		float temp_output_9_0_g1067 = sqrt( ( 1.0 - saturate( dotResult5_g1067 ) ) );
           		float3 appendResult21_g1067 = (float3(break8_g1067.y , break8_g1067.x , temp_output_9_0_g1067));
           		float3 appendResult5949 = (float3(ase_worldNormal.x , -1.0 , 1.0));
           		float4 texArray5109 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5035_0, _Texture_13_Normal_Index );
           		float2 appendResult11_g1069 = (float2(texArray5109.w , texArray5109.y));
           		float2 temp_output_4_0_g1069 = ( ( ( appendResult11_g1069 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_13_Normal_Power );
           		float2 break8_g1069 = temp_output_4_0_g1069;
           		float dotResult5_g1069 = dot( temp_output_4_0_g1069 , temp_output_4_0_g1069 );
           		float temp_output_9_0_g1069 = sqrt( ( 1.0 - saturate( dotResult5_g1069 ) ) );
           		float3 appendResult20_g1069 = (float3(break8_g1069.x , break8_g1069.y , temp_output_9_0_g1069));
           		float3 appendResult5952 = (float3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
           		float3 weightedBlendVar5543 = BlendComponents91;
           		float3 weightedAvg5543 = ( ( weightedBlendVar5543.x*( appendResult21_g1067 * appendResult5949 ) + weightedBlendVar5543.y*temp_output_6035_0 + weightedBlendVar5543.z*( appendResult20_g1069 * appendResult5952 ) )/( weightedBlendVar5543.x + weightedBlendVar5543.y + weightedBlendVar5543.z ) );
           		float3 ifLocalVar5830 = 0;
           		UNITY_BRANCH 
           		if( _Texture_13_Triplanar == 1.0 )
           		ifLocalVar5830 = weightedAvg5543;
           		else
           		ifLocalVar5830 = temp_output_6035_0;
           		float3 ifLocalVar6152 = 0;
           		UNITY_BRANCH 
           		if( _Texture_13_Normal_Index <= -1.0 )
           		ifLocalVar6152 = EmptyNRM6172;
           		else
           		ifLocalVar6152 = ifLocalVar5830;
           		half3 Normal_135059 = ifLocalVar6152;
           		float4 texArray5178 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5022_0, _Texture_14_Normal_Index );
           		float2 appendResult11_g1074 = (float2(texArray5178.w , texArray5178.y));
           		float2 temp_output_4_0_g1074 = ( ( ( appendResult11_g1074 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_14_Normal_Power );
           		float2 break8_g1074 = temp_output_4_0_g1074;
           		float dotResult5_g1074 = dot( temp_output_4_0_g1074 , temp_output_4_0_g1074 );
           		float temp_output_9_0_g1074 = sqrt( ( 1.0 - saturate( dotResult5_g1074 ) ) );
           		float3 appendResult20_g1074 = (float3(break8_g1074.x , break8_g1074.y , temp_output_9_0_g1074));
           		float3 temp_output_6032_0 = appendResult20_g1074;
           		float4 texArray5017 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5009_0, _Texture_14_Normal_Index );
           		float2 appendResult11_g1064 = (float2(texArray5017.w , texArray5017.y));
           		float2 temp_output_4_0_g1064 = ( ( ( appendResult11_g1064 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_14_Normal_Power * -1.0 ) );
           		float2 break8_g1064 = temp_output_4_0_g1064;
           		float dotResult5_g1064 = dot( temp_output_4_0_g1064 , temp_output_4_0_g1064 );
           		float temp_output_9_0_g1064 = sqrt( ( 1.0 - saturate( dotResult5_g1064 ) ) );
           		float3 appendResult21_g1064 = (float3(break8_g1064.y , break8_g1064.x , temp_output_9_0_g1064));
           		float3 appendResult5942 = (float3(ase_worldNormal.x , -1.0 , 1.0));
           		float4 texArray5170 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5010_0, _Texture_14_Normal_Index );
           		float2 appendResult11_g1063 = (float2(texArray5170.w , texArray5170.y));
           		float2 temp_output_4_0_g1063 = ( ( ( appendResult11_g1063 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_14_Normal_Power );
           		float2 break8_g1063 = temp_output_4_0_g1063;
           		float dotResult5_g1063 = dot( temp_output_4_0_g1063 , temp_output_4_0_g1063 );
           		float temp_output_9_0_g1063 = sqrt( ( 1.0 - saturate( dotResult5_g1063 ) ) );
           		float3 appendResult20_g1063 = (float3(break8_g1063.x , break8_g1063.y , temp_output_9_0_g1063));
           		float3 appendResult5945 = (float3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
           		float3 weightedBlendVar5547 = BlendComponents91;
           		float3 weightedAvg5547 = ( ( weightedBlendVar5547.x*( appendResult21_g1064 * appendResult5942 ) + weightedBlendVar5547.y*temp_output_6032_0 + weightedBlendVar5547.z*( appendResult20_g1063 * appendResult5945 ) )/( weightedBlendVar5547.x + weightedBlendVar5547.y + weightedBlendVar5547.z ) );
           		float3 ifLocalVar5826 = 0;
           		UNITY_BRANCH 
           		if( _Texture_14_Triplanar == 1.0 )
           		ifLocalVar5826 = weightedAvg5547;
           		else
           		ifLocalVar5826 = temp_output_6032_0;
           		float3 ifLocalVar6154 = 0;
           		UNITY_BRANCH 
           		if( _Texture_14_Normal_Index <= -1.0 )
           		ifLocalVar6154 = EmptyNRM6172;
           		else
           		ifLocalVar6154 = ifLocalVar5826;
           		half3 Normal_145196 = ifLocalVar6154;
           		float4 texArray5246 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5226_0, _Texture_15_Normal_Index );
           		float2 appendResult11_g1073 = (float2(texArray5246.w , texArray5246.y));
           		float2 temp_output_4_0_g1073 = ( ( ( appendResult11_g1073 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_15_Normal_Power );
           		float2 break8_g1073 = temp_output_4_0_g1073;
           		float dotResult5_g1073 = dot( temp_output_4_0_g1073 , temp_output_4_0_g1073 );
           		float temp_output_9_0_g1073 = sqrt( ( 1.0 - saturate( dotResult5_g1073 ) ) );
           		float3 appendResult20_g1073 = (float3(break8_g1073.x , break8_g1073.y , temp_output_9_0_g1073));
           		float3 temp_output_6029_0 = appendResult20_g1073;
           		float4 texArray5227 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5213_0, _Texture_15_Normal_Index );
           		float2 appendResult11_g1071 = (float2(texArray5227.w , texArray5227.y));
           		float2 temp_output_4_0_g1071 = ( ( ( appendResult11_g1071 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_15_Normal_Power * -1.0 ) );
           		float2 break8_g1071 = temp_output_4_0_g1071;
           		float dotResult5_g1071 = dot( temp_output_4_0_g1071 , temp_output_4_0_g1071 );
           		float temp_output_9_0_g1071 = sqrt( ( 1.0 - saturate( dotResult5_g1071 ) ) );
           		float3 appendResult21_g1071 = (float3(break8_g1071.y , break8_g1071.x , temp_output_9_0_g1071));
           		float3 appendResult5935 = (float3(ase_worldNormal.x , -1.0 , 1.0));
           		float4 texArray5250 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5224_0, _Texture_15_Normal_Index );
           		float2 appendResult11_g1072 = (float2(texArray5250.w , texArray5250.y));
           		float2 temp_output_4_0_g1072 = ( ( ( appendResult11_g1072 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_15_Normal_Power );
           		float2 break8_g1072 = temp_output_4_0_g1072;
           		float dotResult5_g1072 = dot( temp_output_4_0_g1072 , temp_output_4_0_g1072 );
           		float temp_output_9_0_g1072 = sqrt( ( 1.0 - saturate( dotResult5_g1072 ) ) );
           		float3 appendResult20_g1072 = (float3(break8_g1072.x , break8_g1072.y , temp_output_9_0_g1072));
           		float3 appendResult5938 = (float3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
           		float3 weightedBlendVar5551 = BlendComponents91;
           		float3 weightedAvg5551 = ( ( weightedBlendVar5551.x*( appendResult21_g1071 * appendResult5935 ) + weightedBlendVar5551.y*temp_output_6029_0 + weightedBlendVar5551.z*( appendResult20_g1072 * appendResult5938 ) )/( weightedBlendVar5551.x + weightedBlendVar5551.y + weightedBlendVar5551.z ) );
           		float3 ifLocalVar5822 = 0;
           		UNITY_BRANCH 
           		if( _Texture_15_Triplanar == 1.0 )
           		ifLocalVar5822 = weightedAvg5551;
           		else
           		ifLocalVar5822 = temp_output_6029_0;
           		float3 ifLocalVar6156 = 0;
           		UNITY_BRANCH 
           		if( _Texture_15_Normal_Index <= -1.0 )
           		ifLocalVar6156 = EmptyNRM6172;
           		else
           		ifLocalVar6156 = ifLocalVar5822;
           		half3 Normal_155280 = ifLocalVar6156;
           		float4 texArray5099 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5083_0, _Texture_16_Normal_Index );
           		float2 appendResult11_g1075 = (float2(texArray5099.w , texArray5099.y));
           		float2 temp_output_4_0_g1075 = ( ( ( appendResult11_g1075 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_16_Normal_Power );
           		float2 break8_g1075 = temp_output_4_0_g1075;
           		float dotResult5_g1075 = dot( temp_output_4_0_g1075 , temp_output_4_0_g1075 );
           		float temp_output_9_0_g1075 = sqrt( ( 1.0 - saturate( dotResult5_g1075 ) ) );
           		float3 appendResult20_g1075 = (float3(break8_g1075.x , break8_g1075.y , temp_output_9_0_g1075));
           		float3 temp_output_6026_0 = appendResult20_g1075;
           		float4 texArray5082 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5079_0, _Texture_16_Normal_Index );
           		float2 appendResult11_g1070 = (float2(texArray5082.w , texArray5082.y));
           		float2 temp_output_4_0_g1070 = ( ( ( appendResult11_g1070 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_16_Normal_Power * -1.0 ) );
           		float2 break8_g1070 = temp_output_4_0_g1070;
           		float dotResult5_g1070 = dot( temp_output_4_0_g1070 , temp_output_4_0_g1070 );
           		float temp_output_9_0_g1070 = sqrt( ( 1.0 - saturate( dotResult5_g1070 ) ) );
           		float3 appendResult21_g1070 = (float3(break8_g1070.y , break8_g1070.x , temp_output_9_0_g1070));
           		float3 appendResult5928 = (float3(ase_worldNormal.x , -1.0 , 1.0));
           		float4 texArray4731 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_5085_0, _Texture_16_Normal_Index );
           		float2 appendResult11_g1061 = (float2(texArray4731.w , texArray4731.y));
           		float2 temp_output_4_0_g1061 = ( ( ( appendResult11_g1061 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_16_Normal_Power );
           		float2 break8_g1061 = temp_output_4_0_g1061;
           		float dotResult5_g1061 = dot( temp_output_4_0_g1061 , temp_output_4_0_g1061 );
           		float temp_output_9_0_g1061 = sqrt( ( 1.0 - saturate( dotResult5_g1061 ) ) );
           		float3 appendResult20_g1061 = (float3(break8_g1061.x , break8_g1061.y , temp_output_9_0_g1061));
           		float3 appendResult5931 = (float3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
           		float3 weightedBlendVar5555 = BlendComponents91;
           		float3 weightedAvg5555 = ( ( weightedBlendVar5555.x*( appendResult21_g1070 * appendResult5928 ) + weightedBlendVar5555.y*temp_output_6026_0 + weightedBlendVar5555.z*( appendResult20_g1061 * appendResult5931 ) )/( weightedBlendVar5555.x + weightedBlendVar5555.y + weightedBlendVar5555.z ) );
           		float3 ifLocalVar5818 = 0;
           		UNITY_BRANCH 
           		if( _Texture_16_Triplanar == 1.0 )
           		ifLocalVar5818 = weightedAvg5555;
           		else
           		ifLocalVar5818 = temp_output_6026_0;
           		float3 ifLocalVar6158 = 0;
           		UNITY_BRANCH 
           		if( _Texture_16_Normal_Index <= -1.0 )
           		ifLocalVar6158 = EmptyNRM6172;
           		else
           		ifLocalVar6158 = ifLocalVar5818;
           		half3 Normal_164696 = ifLocalVar6158;
           		float4 layeredBlendVar5642 = tex2DNode4371;
           		float3 layeredBlend5642 = ( lerp( lerp( lerp( lerp( layeredBlend5641 , Normal_135059 , layeredBlendVar5642.x ) , Normal_145196 , layeredBlendVar5642.y ) , Normal_155280 , layeredBlendVar5642.z ) , Normal_164696 , layeredBlendVar5642.w ) );
           		float3 normalizeResult3900 = normalize( layeredBlend5642 );
           		float4 texArray4382 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, temp_output_3893_0, _Texture_Snow_Normal_Index );
           		float2 appendResult11_g1077 = (float2(texArray4382.w , texArray4382.y));
           		float2 temp_output_4_0_g1077 = ( ( ( appendResult11_g1077 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Snow_Normal_Scale );
           		float2 break8_g1077 = temp_output_4_0_g1077;
           		float dotResult5_g1077 = dot( temp_output_4_0_g1077 , temp_output_4_0_g1077 );
           		float temp_output_9_0_g1077 = sqrt( ( 1.0 - saturate( dotResult5_g1077 ) ) );
           		float3 appendResult20_g1077 = (float3(break8_g1077.x , break8_g1077.y , temp_output_9_0_g1077));
           		float3 ifLocalVar6166 = 0;
           		UNITY_BRANCH 
           		if( _Texture_Snow_Normal_Index <= -1.0 )
           		ifLocalVar6166 = EmptyNRM6172;
           		else
           		ifLocalVar6166 = appendResult20_g1077;
           		float simplePerlin2D6331 = snoise( ( Top_Bottom1999 * _Snow_Noise_Tiling ) );
           		float clampResult6340 = clamp( simplePerlin2D6331 , 0.0 , 1.0 );
           		float lerpResult4310 = lerp( 1.0 , clampResult6340 , _Snow_Noise_Power);
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
           		float3 ase_worldTangent = IN.ase_texcoord3.xyz;
           		float3 ase_worldBitangent = IN.ase_texcoord4.xyz;
           		float3 tanToWorld0 = float3( ase_worldTangent.x, ase_worldBitangent.x, ase_worldNormal.x );
           		float3 tanToWorld1 = float3( ase_worldTangent.y, ase_worldBitangent.y, ase_worldNormal.y );
           		float3 tanToWorld2 = float3( ase_worldTangent.z, ase_worldBitangent.z, ase_worldNormal.z );
           		float3 tanNormal3706 = lerpResult3902;
           		float3 worldNormal3706 = float3(dot(tanToWorld0,tanNormal3706), dot(tanToWorld1,tanNormal3706), dot(tanToWorld2,tanNormal3706));
           		float lerpResult4350 = lerp( normalizeResult3900.y , worldNormal3706.y , pow( clampResult4298 , 2.0 ));
           		float clampResult4299 = clamp( ( lerpResult4350 * clampResult4298 ) , 0.0 , 1.0 );
           		float clampResult3702 = clamp( pow( ( ( ( _Texture_16_Snow_Reduction * Splat4_A2546 ) + ( ( _Texture_15_Snow_Reduction * Splat4_B2545 ) + ( ( ( _Texture_13_Snow_Reduction * Splat4_R2543 ) + ( ( _Texture_12_Snow_Reduction * Splat3_A2540 ) + ( ( _Texture_11_Snow_Reduction * Splat3_B2539 ) + ( ( ( _Texture_9_Snow_Reduction * Splat3_R2537 ) + ( ( _Texture_8_Snow_Reduction * Splat2_A2109 ) + ( ( _Texture_7_Snow_Reduction * Splat2_B2108 ) + ( ( ( _Texture_5_Snow_Reduction * Splat2_R2106 ) + ( ( _Texture_1_Snow_Reduction * Splat1_R1438 ) + ( ( _Texture_2_Snow_Reduction * Splat1_G1441 ) + ( ( _Texture_3_Snow_Reduction * Splat1_B1442 ) + ( _Texture_4_Snow_Reduction * Splat1_A1491 ) ) ) ) ) + ( _Texture_6_Snow_Reduction * Splat2_G2107 ) ) ) ) ) + ( _Texture_10_Snow_Reduction * Splat3_G2538 ) ) ) ) ) + ( _Texture_14_Snow_Reduction * Splat4_G2544 ) ) ) ) * ( lerpResult4310 * 5.0 ) ) , 3.0 ) , 0.0 , 1.0 );
           		float lerpResult3742 = lerp( saturate( clampResult4299 ) , 0.0 , clampResult3702);
           		float3 lerpResult1356 = lerp( clampResult5715 , ( appendResult1410 + temp_output_6306_0 ) , lerpResult3742);
           		
           		float2 uv_TerrainHolesTexture = IN.ase_texcoord1.xy * _TerrainHolesTexture_ST.xy + _TerrainHolesTexture_ST.zw;
           		float clampResult6254 = clamp( ( ase_worldPos.y + ( 0.0 - _Remove_Vert_Height ) ) , 0.0 , 1.0 );
           		
				
		        float3 Albedo = lerpResult1356;
				float3 Emission = 0;
				float Alpha = ( tex2D( _TerrainHolesTexture, uv_TerrainHolesTexture ).r * clampResult6254 );

				float AlphaClipThreshold = 0.5;
				clip(Alpha-AlphaClipThreshold);



                MetaInput metaInput = (MetaInput)0;
                metaInput.Albedo = Albedo;
                metaInput.Emission = Emission;
                
                return MetaFragment(metaInput);
            }
            ENDHLSL
        }
 		UsePass "Hidden/Nature/Terrain/Utilities/PICKING"
        UsePass "Hidden/Nature/Terrain/Utilities/SELECTION"
		
    }
    
	
	Dependency "BaseMapShader"="CTS/URP/CTS Terrain Shader Basic LOD CutOut"

}