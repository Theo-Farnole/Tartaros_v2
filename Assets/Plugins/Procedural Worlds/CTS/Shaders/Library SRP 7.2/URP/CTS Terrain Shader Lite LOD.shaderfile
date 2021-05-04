Shader "CTS/URP/CTS Terrain Shader Lite LOD"
{
    Properties
    {
		_Geological_Tiling_Far("Geological_Tiling_Far", Range( 0 , 1000)) = 87
		_Geological_Map_Offset_Far("Geological_Map_Offset _Far", Range( 0 , 1)) = 1
		_Geological_Map_Far_Power("Geological_Map_Far_Power", Range( 0 , 1)) = 1
		_Perlin_Normal_Tiling_Far("Perlin_Normal_Tiling_Far", Range( 0.01 , 1000)) = 40
		_Perlin_Normal_Power("Perlin_Normal_Power", Range( 0 , 10)) = 1
		_Terrain_Smoothness("Terrain_Smoothness", Range( 0 , 2)) = 1
		_Terrain_Specular("Terrain_Specular", Range( 0 , 3)) = 1
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
		_Texture_2_Geological_Power("Texture_2_Geological_Power", Range( 0 , 5)) = 1
		_Texture_3_Geological_Power("Texture_3_Geological_Power", Range( 0 , 5)) = 1
		_Texture_4_Geological_Power("Texture_4_Geological_Power", Range( 0 , 5)) = 1
		_Texture_5_Geological_Power("Texture_5_Geological_Power", Range( 0 , 5)) = 1
		_Texture_6_Geological_Power("Texture_6_Geological_Power", Range( 0 , 5)) = 1
		_Texture_Array_Normal("Texture_Array_Normal", 2DArray ) = "" {}
		_Texture_7_Geological_Power("Texture_7_Geological_Power", Range( 0 , 5)) = 1
		_Texture_8_Geological_Power("Texture_8_Geological_Power", Range( 0 , 5)) = 1
		_Texture_Array_Albedo("Texture_Array_Albedo", 2DArray ) = "" {}
		_Texture_9_Geological_Power("Texture_9_Geological_Power", Range( 0 , 5)) = 1
		_Texture_10_Geological_Power("Texture_10_Geological_Power", Range( 0 , 5)) = 1
		_Texture_11_Geological_Power("Texture_11_Geological_Power", Range( 0 , 5)) = 1
		_Texture_12_Geological_Power("Texture_12_Geological_Power", Range( 0 , 5)) = 1
		_Texture_13_Geological_Power("Texture_13_Geological_Power", Range( 0 , 5)) = 1
		_Texture_14_Geological_Power("Texture_14_Geological_Power", Range( 0 , 5)) = 1
		_Texture_15_Geological_Power("Texture_15_Geological_Power", Range( 0 , 5)) = 1
		_Texture_16_Geological_Power("Texture_16_Geological_Power", Range( 0 , 5)) = 1
		_Texture_Perlin_Normal_Index("Texture_Perlin_Normal_Index", Int) = -1
		_Texture_Splat_1("Texture_Splat_1", 2D) = "black" {}
		_Texture_Splat_2("Texture_Splat_2", 2D) = "black" {}
		_Texture_Splat_3("Texture_Splat_3", 2D) = "black" {}
		_Texture_Splat_4("Texture_Splat_4", 2D) = "black" {}
		_Texture_Geological_Map("Texture_Geological_Map", 2D) = "white" {}
		_Texture_4_Color("Texture_4_Color", Vector) = (1,1,1,1)
		_Texture_16_Color("Texture_16_Color", Vector) = (1,1,1,1)
		_Texture_8_Color("Texture_8_Color", Vector) = (1,1,1,1)
		_Texture_7_Color("Texture_7_Color", Vector) = (1,1,1,1)
		_Texture_6_Color("Texture_6_Color", Vector) = (1,1,1,1)
		_Texture_5_Color("Texture_5_Color", Vector) = (1,1,1,1)
		_Texture_3_Color("Texture_3_Color", Vector) = (1,1,1,1)
		_Texture_13_Color("Texture_13_Color", Vector) = (1,1,1,1)
		_Texture_15_Color("Texture_15_Color", Vector) = (1,1,1,1)
		_Texture_14_Color("Texture_14_Color", Vector) = (1,1,1,1)
		_Texture_9_Color("Texture_9_Color", Vector) = (1,1,1,1)
		_Texture_12_Color("Texture_12_Color", Vector) = (1,1,1,1)
		_Texture_11_Color("Texture_11_Color", Vector) = (1,1,1,1)
		_Texture_10_Color("Texture_10_Color", Vector) = (1,1,1,1)
		_Texture_1_Color("Texture_1_Color", Vector) = (1,1,1,1)
		_Texture_2_Color("Texture_2_Color", Vector) = (1,1,1,1)
		_Ambient_Occlusion_Power("Ambient_Occlusion_Power", Range( 0 , 1)) = 1
		_Texture_10_Albedo_Index("Texture_10_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_9_Albedo_Index("Texture_9_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_11_Albedo_Index("Texture_11_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_12_Albedo_Index("Texture_12_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_13_Albedo_Index("Texture_13_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_14_Albedo_Index("Texture_14_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_8_Albedo_Index("Texture_8_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_7_Albedo_Index("Texture_7_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_15_Albedo_Index("Texture_15_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_16_Albedo_Index("Texture_16_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_6_Albedo_Index("Texture_6_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_3_Albedo_Index("Texture_3_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_2_Albedo_Index("Texture_2_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_5_Albedo_Index("Texture_5_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_4_Albedo_Index("Texture_4_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_1_Albedo_Index("Texture_1_Albedo_Index", Range( -1 , 100)) = -1
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
        	#include "TerrainVertexCTS.hlsl"
        	#pragma instancing_options assumeuniformscaling nomatrices nolightprobe nolightmap


        	#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        	#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
        	#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
        	#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/UnityInstancing.hlsl"
        	#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"

			sampler2D _Texture_Splat_4;
			sampler2D _Texture_Splat_3;
			sampler2D _Texture_Splat_2;
			sampler2D _Texture_Splat_1;
			half _Texture_1_Albedo_Index;
			TEXTURE2D_ARRAY( _Texture_Array_Albedo );
			uniform SAMPLER( sampler_Texture_Array_Albedo );
			half _Texture_1_Tiling;
			half _Texture_1_Far_Multiplier;
			half4 _Texture_1_Color;
			half _Texture_2_Albedo_Index;
			half _Texture_2_Tiling;
			half _Texture_2_Far_Multiplier;
			half4 _Texture_2_Color;
			half _Texture_3_Albedo_Index;
			half _Texture_3_Tiling;
			half _Texture_3_Far_Multiplier;
			half4 _Texture_3_Color;
			half _Texture_4_Albedo_Index;
			half _Texture_4_Tiling;
			half _Texture_4_Far_Multiplier;
			half4 _Texture_4_Color;
			half _Texture_5_Albedo_Index;
			half _Texture_5_Tiling;
			half _Texture_5_Far_Multiplier;
			half4 _Texture_5_Color;
			half _Texture_6_Albedo_Index;
			half _Texture_6_Tiling;
			half _Texture_6_Far_Multiplier;
			half4 _Texture_6_Color;
			half _Texture_7_Albedo_Index;
			half _Texture_7_Tiling;
			half _Texture_7_Far_Multiplier;
			half4 _Texture_7_Color;
			half _Texture_8_Albedo_Index;
			half _Texture_8_Tiling;
			half _Texture_8_Far_Multiplier;
			half4 _Texture_8_Color;
			half _Texture_9_Albedo_Index;
			half _Texture_9_Tiling;
			half _Texture_9_Far_Multiplier;
			half4 _Texture_9_Color;
			half _Texture_10_Albedo_Index;
			half _Texture_10_Tiling;
			half _Texture_10_Far_Multiplier;
			half4 _Texture_10_Color;
			half _Texture_11_Albedo_Index;
			half _Texture_11_Tiling;
			half _Texture_11_Far_Multiplier;
			half4 _Texture_11_Color;
			half _Texture_12_Albedo_Index;
			half _Texture_12_Tiling;
			half _Texture_12_Far_Multiplier;
			half4 _Texture_12_Color;
			half _Texture_13_Albedo_Index;
			half _Texture_13_Tiling;
			half _Texture_13_Far_Multiplier;
			half4 _Texture_13_Color;
			half _Texture_14_Albedo_Index;
			half _Texture_14_Tiling;
			half _Texture_14_Far_Multiplier;
			half4 _Texture_14_Color;
			half _Texture_15_Albedo_Index;
			half _Texture_15_Tiling;
			half _Texture_15_Far_Multiplier;
			half4 _Texture_15_Color;
			half _Texture_16_Albedo_Index;
			half _Texture_16_Tiling;
			half _Texture_16_Far_Multiplier;
			half4 _Texture_16_Color;
			half _Geological_Map_Far_Power;
			sampler2D _Texture_Geological_Map;
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
			TEXTURE2D_ARRAY( _Texture_Array_Normal );
			uniform SAMPLER( sampler_Texture_Array_Normal );
			half _Perlin_Normal_Tiling_Far;
			int _Texture_Perlin_Normal_Index;
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
			half _Terrain_Specular;
			half _Terrain_Smoothness;
			half _Ambient_Occlusion_Power;

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

			
            GraphVertexOutput vert (GraphVertexInput v  )
        	{
        		GraphVertexOutput o = (GraphVertexOutput)0;
                UNITY_SETUP_INSTANCE_ID(v);
            	UNITY_TRANSFER_INSTANCE_ID(v, o);
        		UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				TerrainInstancing(v.vertex, v.ase_normal, v.ase_texcoord.xy);
				float3 localCalculateTangentsSRP6187 = ( ( v.ase_tangent.xyz * 0.0 ) );
				v.ase_tangent.xyz = cross ( v.ase_normal, float3( 0, 0, 1 ) );
				v.ase_tangent.w = -1;
				
				o.ase_texcoord7.xy = v.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord7.zw = 0;
				float3 vertexValue = localCalculateTangentsSRP6187;
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
    
				float2 uv02588 = IN.ase_texcoord7.xy * float2( 1,1 ) + float2( 0,0 );
				float4 tex2DNode4371 = tex2D( _Texture_Splat_4, uv02588 );
				float4 tex2DNode4370 = tex2D( _Texture_Splat_3, uv02588 );
				float4 tex2DNode4369 = tex2D( _Texture_Splat_2, uv02588 );
				float4 tex2DNode4368 = tex2D( _Texture_Splat_1, uv02588 );
				float3 break6175 = WorldSpacePosition;
				float2 appendResult6171 = (float2(break6175.x , break6175.z));
				half2 Top_Bottom1999 = appendResult6171;
				float temp_output_3830_0 = ( 1.0 / _Texture_1_Tiling );
				float2 appendResult3284 = (float2(temp_output_3830_0 , temp_output_3830_0));
				float4 texArray3292 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult3284 ) / _Texture_1_Far_Multiplier ), _Texture_1_Albedo_Index );
				float4 ifLocalVar6119 = 0;
				UNITY_BRANCH 
				if( _Texture_1_Albedo_Index > -1.0 )
				ifLocalVar6119 = ( texArray3292 * _Texture_1_Color );
				half4 Texture_1_Final950 = ifLocalVar6119;
				float temp_output_3831_0 = ( 1.0 / _Texture_2_Tiling );
				float2 appendResult3349 = (float2(temp_output_3831_0 , temp_output_3831_0));
				float4 texArray3339 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult3349 ) / _Texture_2_Far_Multiplier ), _Texture_2_Albedo_Index );
				float4 ifLocalVar6120 = 0;
				UNITY_BRANCH 
				if( _Texture_2_Albedo_Index > -1.0 )
				ifLocalVar6120 = ( texArray3339 * _Texture_2_Color );
				half4 Texture_2_Final3385 = ifLocalVar6120;
				float temp_output_3832_0 = ( 1.0 / _Texture_3_Tiling );
				float2 appendResult3415 = (float2(temp_output_3832_0 , temp_output_3832_0));
				float4 texArray3406 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult3415 ) / _Texture_3_Far_Multiplier ), _Texture_3_Albedo_Index );
				float4 ifLocalVar6121 = 0;
				UNITY_BRANCH 
				if( _Texture_3_Albedo_Index > -1.0 )
				ifLocalVar6121 = ( texArray3406 * _Texture_3_Color );
				half4 Texture_3_Final3451 = ifLocalVar6121;
				float4 texArray3473 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * ( 1.0 / _Texture_4_Tiling ) ) / _Texture_4_Far_Multiplier ), _Texture_4_Albedo_Index );
				float4 ifLocalVar6122 = 0;
				UNITY_BRANCH 
				if( _Texture_4_Albedo_Index > -1.0 )
				ifLocalVar6122 = ( texArray3473 * _Texture_4_Color );
				half4 Texture_4_Final3518 = ifLocalVar6122;
				float4 layeredBlendVar5643 = tex2DNode4368;
				float4 layeredBlend5643 = ( lerp( lerp( lerp( lerp( float4( 0,0,0,0 ) , Texture_1_Final950 , layeredBlendVar5643.x ) , Texture_2_Final3385 , layeredBlendVar5643.y ) , Texture_3_Final3451 , layeredBlendVar5643.z ) , Texture_4_Final3518 , layeredBlendVar5643.w ) );
				float temp_output_4397_0 = ( 1.0 / _Texture_5_Tiling );
				float2 appendResult4399 = (float2(temp_output_4397_0 , temp_output_4397_0));
				float4 texArray4445 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult4399 ) / _Texture_5_Far_Multiplier ), _Texture_5_Albedo_Index );
				float4 ifLocalVar6123 = 0;
				UNITY_BRANCH 
				if( _Texture_5_Albedo_Index > -1.0 )
				ifLocalVar6123 = ( texArray4445 * _Texture_5_Color );
				half4 Texture_5_Final4396 = ifLocalVar6123;
				float temp_output_4469_0 = ( 1.0 / _Texture_6_Tiling );
				float2 appendResult4471 = (float2(temp_output_4469_0 , temp_output_4469_0));
				float4 texArray4512 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult4471 ) / _Texture_6_Far_Multiplier ), _Texture_6_Albedo_Index );
				float4 ifLocalVar6124 = 0;
				UNITY_BRANCH 
				if( _Texture_6_Albedo_Index > -1.0 )
				ifLocalVar6124 = ( texArray4512 * _Texture_6_Color );
				half4 Texture_6_Final4536 = ifLocalVar6124;
				float temp_output_4543_0 = ( 1.0 / _Texture_7_Tiling );
				float2 appendResult4545 = (float2(temp_output_4543_0 , temp_output_4543_0));
				float4 texArray4586 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult4545 ) / _Texture_7_Far_Multiplier ), _Texture_7_Albedo_Index );
				float4 ifLocalVar6125 = 0;
				UNITY_BRANCH 
				if( _Texture_7_Albedo_Index > -1.0 )
				ifLocalVar6125 = ( texArray4586 * _Texture_7_Color );
				half4 Texture_7_Final4614 = ifLocalVar6125;
				float temp_output_4617_0 = ( 1.0 / _Texture_8_Tiling );
				float2 appendResult4619 = (float2(temp_output_4617_0 , temp_output_4617_0));
				float4 texArray4660 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult4619 ) / _Texture_8_Far_Multiplier ), _Texture_8_Albedo_Index );
				float4 ifLocalVar6126 = 0;
				UNITY_BRANCH 
				if( _Texture_8_Albedo_Index > -1.0 )
				ifLocalVar6126 = ( texArray4660 * _Texture_8_Color );
				half4 Texture_8_Final4689 = ifLocalVar6126;
				float4 layeredBlendVar5644 = tex2DNode4369;
				float4 layeredBlend5644 = ( lerp( lerp( lerp( lerp( layeredBlend5643 , Texture_5_Final4396 , layeredBlendVar5644.x ) , Texture_6_Final4536 , layeredBlendVar5644.y ) , Texture_7_Final4614 , layeredBlendVar5644.z ) , Texture_8_Final4689 , layeredBlendVar5644.w ) );
				float temp_output_4703_0 = ( 1.0 / _Texture_9_Tiling );
				float2 appendResult4736 = (float2(temp_output_4703_0 , temp_output_4703_0));
				float4 texArray4889 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult4736 ) / _Texture_9_Far_Multiplier ), _Texture_9_Albedo_Index );
				float4 ifLocalVar6134 = 0;
				UNITY_BRANCH 
				if( _Texture_9_Albedo_Index > -1.0 )
				ifLocalVar6134 = ( texArray4889 * _Texture_9_Color );
				half4 Texture_9_Final4987 = ifLocalVar6134;
				float temp_output_4734_0 = ( 1.0 / _Texture_10_Tiling );
				float2 appendResult4738 = (float2(temp_output_4734_0 , temp_output_4734_0));
				float4 texArray4913 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult4738 ) / _Texture_10_Far_Multiplier ), _Texture_10_Albedo_Index );
				float4 ifLocalVar6133 = 0;
				UNITY_BRANCH 
				if( _Texture_10_Albedo_Index > -1.0 )
				ifLocalVar6133 = ( texArray4913 * _Texture_10_Color );
				half4 Texture_10_Final4994 = ifLocalVar6133;
				float temp_output_4739_0 = ( 1.0 / _Texture_11_Tiling );
				float2 appendResult4741 = (float2(temp_output_4739_0 , temp_output_4739_0));
				float4 texArray4923 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult4741 ) / _Texture_11_Far_Multiplier ), _Texture_11_Albedo_Index );
				float4 ifLocalVar6132 = 0;
				UNITY_BRANCH 
				if( _Texture_11_Albedo_Index > -1.0 )
				ifLocalVar6132 = ( texArray4923 * _Texture_11_Color );
				half4 Texture_11_Final4996 = ifLocalVar6132;
				float temp_output_4745_0 = ( 1.0 / _Texture_12_Tiling );
				float2 appendResult4751 = (float2(temp_output_4745_0 , temp_output_4745_0));
				float4 texArray4952 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult4751 ) / _Texture_12_Far_Multiplier ), _Texture_12_Albedo_Index );
				float4 ifLocalVar6131 = 0;
				UNITY_BRANCH 
				if( _Texture_12_Albedo_Index > -1.0 )
				ifLocalVar6131 = ( texArray4952 * _Texture_12_Color );
				half4 Texture_12_Final4997 = ifLocalVar6131;
				float4 layeredBlendVar5645 = tex2DNode4370;
				float4 layeredBlend5645 = ( lerp( lerp( lerp( lerp( layeredBlend5644 , Texture_9_Final4987 , layeredBlendVar5645.x ) , Texture_10_Final4994 , layeredBlendVar5645.y ) , Texture_11_Final4996 , layeredBlendVar5645.z ) , Texture_12_Final4997 , layeredBlendVar5645.w ) );
				float temp_output_5125_0 = ( 1.0 / _Texture_13_Tiling );
				float2 appendResult5027 = (float2(temp_output_5125_0 , temp_output_5125_0));
				float4 texArray5034 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult5027 ) / _Texture_13_Far_Multiplier ), _Texture_13_Albedo_Index );
				float4 ifLocalVar6130 = 0;
				UNITY_BRANCH 
				if( _Texture_13_Albedo_Index > -1.0 )
				ifLocalVar6130 = ( texArray5034 * _Texture_13_Color );
				half4 Texture_13_Final5058 = ifLocalVar6130;
				float temp_output_5006_0 = ( 1.0 / _Texture_14_Tiling );
				float2 appendResult5033 = (float2(temp_output_5006_0 , temp_output_5006_0));
				float4 texArray5171 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult5033 ) / _Texture_14_Far_Multiplier ), _Texture_14_Albedo_Index );
				float4 ifLocalVar6129 = 0;
				UNITY_BRANCH 
				if( _Texture_14_Albedo_Index > -1.0 )
				ifLocalVar6129 = ( texArray5171 * _Texture_14_Color );
				half4 Texture_14_Final5163 = ifLocalVar6129;
				float temp_output_5210_0 = ( 1.0 / _Texture_15_Tiling );
				float2 appendResult5212 = (float2(temp_output_5210_0 , temp_output_5210_0));
				float4 texArray5272 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult5212 ) / _Texture_15_Far_Multiplier ), _Texture_15_Albedo_Index );
				float4 ifLocalVar6128 = 0;
				UNITY_BRANCH 
				if( _Texture_15_Albedo_Index > -1.0 )
				ifLocalVar6128 = ( texArray5272 * _Texture_15_Color );
				half4 Texture_15_Final5270 = ifLocalVar6128;
				float temp_output_5075_0 = ( 1.0 / _Texture_16_Tiling );
				float2 appendResult5078 = (float2(temp_output_5075_0 , temp_output_5075_0));
				float4 texArray5145 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult5078 ) / _Texture_16_Far_Multiplier ), _Texture_16_Albedo_Index );
				float4 ifLocalVar6127 = 0;
				UNITY_BRANCH 
				if( _Texture_16_Albedo_Index > -1.0 )
				ifLocalVar6127 = ( texArray5145 * _Texture_16_Color );
				half4 Texture_16_Final5094 = ifLocalVar6127;
				float4 layeredBlendVar5646 = tex2DNode4371;
				float4 layeredBlend5646 = ( lerp( lerp( lerp( lerp( layeredBlend5645 , Texture_13_Final5058 , layeredBlendVar5646.x ) , Texture_14_Final5163 , layeredBlendVar5646.y ) , Texture_15_Final5270 , layeredBlendVar5646.z ) , Texture_16_Final5094 , layeredBlendVar5646.w ) );
				float4 break3856 = layeredBlend5646;
				float3 appendResult3857 = (float3(break3856.x , break3856.y , break3856.z));
				float2 temp_cast_0 = (( ( WorldSpacePosition.y / _Geological_Tiling_Far ) + _Geological_Map_Offset_Far )).xx;
				float4 tex2DNode5983 = tex2D( _Texture_Geological_Map, temp_cast_0 );
				float3 appendResult5985 = (float3(tex2DNode5983.r , tex2DNode5983.g , tex2DNode5983.b));
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
				float3 blendOpSrc4362 = appendResult3857;
				float3 blendOpDest4362 = ( ( _Geological_Map_Far_Power * ( appendResult5985 + float3( -0.3,-0.3,-0.3 ) ) ) * ( ( _Texture_16_Geological_Power * Splat4_A2546 ) + ( ( _Texture_15_Geological_Power * Splat4_B2545 ) + ( ( _Texture_14_Geological_Power * Splat4_G2544 ) + ( ( _Texture_13_Geological_Power * Splat4_R2543 ) + ( ( _Texture_12_Geological_Power * Splat3_A2540 ) + ( ( _Texture_11_Geological_Power * Splat3_B2539 ) + ( ( _Texture_10_Geological_Power * Splat3_G2538 ) + ( ( _Texture_9_Geological_Power * Splat3_R2537 ) + ( ( _Texture_8_Geological_Power * Splat2_A2109 ) + ( ( _Texture_7_Geological_Power * Splat2_B2108 ) + ( ( _Texture_6_Geological_Power * Splat2_G2107 ) + ( ( _Texture_5_Geological_Power * Splat2_R2106 ) + ( ( _Texture_1_Geological_Power * Splat1_R1438 ) + ( ( _Texture_2_Geological_Power * Splat1_G1441 ) + ( ( _Texture_4_Geological_Power * Splat1_A1491 ) + ( _Texture_3_Geological_Power * Splat1_B1442 ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) );
				float3 clampResult5715 = clamp( ( saturate( ( blendOpSrc4362 + blendOpDest4362 ) )) , float3( 0,0,0 ) , float3( 1,1,1 ) );
				
				float4 texArray4374 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Normal, sampler_Texture_Array_Normal, ( Top_Bottom1999 / _Perlin_Normal_Tiling_Far ), (float)_Texture_Perlin_Normal_Index );
				float2 appendResult11_g223 = (float2(texArray4374.w , texArray4374.y));
				float2 temp_output_4_0_g223 = ( ( ( appendResult11_g223 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Perlin_Normal_Power );
				float2 break8_g223 = temp_output_4_0_g223;
				float dotResult5_g223 = dot( temp_output_4_0_g223 , temp_output_4_0_g223 );
				float temp_output_9_0_g223 = sqrt( ( 1.0 - saturate( dotResult5_g223 ) ) );
				float3 appendResult20_g223 = (float3(break8_g223.x , break8_g223.y , temp_output_9_0_g223));
				float clampResult3775 = clamp( ( ( _Texture_16_Perlin_Power * Splat4_A2546 ) + ( ( _Texture_15_Perlin_Power * Splat4_B2545 ) + ( ( _Texture_14_Perlin_Power * Splat4_G2544 ) + ( ( _Texture_13_Perlin_Power * Splat4_R2543 ) + ( ( _Texture_12_Perlin_Power * Splat3_A2540 ) + ( ( _Texture_11_Perlin_Power * Splat3_B2539 ) + ( ( _Texture_10_Perlin_Power * Splat3_G2538 ) + ( ( _Texture_9_Perlin_Power * Splat3_R2537 ) + ( ( _Texture_8_Perlin_Power * Splat2_A2109 ) + ( ( _Texture_7_Perlin_Power * Splat2_B2108 ) + ( ( _Texture_6_Perlin_Power * Splat2_G2107 ) + ( ( _Texture_5_Perlin_Power * Splat2_R2106 ) + ( ( _Texture_1_Perlin_Power * Splat1_R1438 ) + ( ( _Texture_2_Perlin_Power * Splat1_G1441 ) + ( ( _Texture_4_Perlin_Power * Splat1_A1491 ) + ( _Texture_3_Perlin_Power * Splat1_B1442 ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) , 0.0 , 1.0 );
				float3 lerpResult3776 = lerp( float3( 0,0,1 ) , appendResult20_g223 , clampResult3775);
				
				
		        float3 Albedo = clampResult5715;
				float3 Normal = lerpResult3776;
				float3 Emission = 0;
				float3 Specular = ( ( appendResult3857 * float3( 0.3,0.3,0.3 ) ) * _Terrain_Specular );
				float Metallic = 0;
				float Smoothness = ( break3856.w * _Terrain_Smoothness );
				float Occlusion = _Ambient_Occlusion_Power;
				float Alpha = 1;
				float AlphaClipThreshold = 0;

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

        #if _AlphaClip
        		clip(Alpha - AlphaClipThreshold);
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
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

			
        	struct VertexOutput
        	{
        	    float4 clipPos      : SV_POSITION;
                
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

				float3 localCalculateTangentsSRP6187 = ( ( v.ase_tangent.xyz * 0.0 ) );
				v.ase_tangent.xyz = cross ( v.ase_normal, float3( 0, 0, 1 ) );
				v.ase_tangent.w = -1;
				
				float3 vertexValue = localCalculateTangentsSRP6187;
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

               

				float Alpha = 1;
				float AlphaClipThreshold = AlphaClipThreshold;

         #if _AlphaClip
        		clip(Alpha - AlphaClipThreshold);
        #endif
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

			
            struct GraphVertexInput
            {
                float4 vertex : POSITION;
				float3 ase_normal : NORMAL;
				float4 ase_tangent : TANGENT;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

        	struct VertexOutput
        	{
        	    float4 clipPos      : SV_POSITION;
                
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

				float3 localCalculateTangentsSRP6187 = ( ( v.ase_tangent.xyz * 0.0 ) );
				v.ase_tangent.xyz = cross ( v.ase_normal, float3( 0, 0, 1 ) );
				v.ase_tangent.w = -1;
				
				float3 vertexValue = localCalculateTangentsSRP6187;
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

				

				float Alpha = 1;
				float AlphaClipThreshold = AlphaClipThreshold;

         #if _AlphaClip
        		clip(Alpha - AlphaClipThreshold);
        #endif
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

			sampler2D _Texture_Splat_4;
			sampler2D _Texture_Splat_3;
			sampler2D _Texture_Splat_2;
			sampler2D _Texture_Splat_1;
			half _Texture_1_Albedo_Index;
			TEXTURE2D_ARRAY( _Texture_Array_Albedo );
			uniform SAMPLER( sampler_Texture_Array_Albedo );
			half _Texture_1_Tiling;
			half _Texture_1_Far_Multiplier;
			half4 _Texture_1_Color;
			half _Texture_2_Albedo_Index;
			half _Texture_2_Tiling;
			half _Texture_2_Far_Multiplier;
			half4 _Texture_2_Color;
			half _Texture_3_Albedo_Index;
			half _Texture_3_Tiling;
			half _Texture_3_Far_Multiplier;
			half4 _Texture_3_Color;
			half _Texture_4_Albedo_Index;
			half _Texture_4_Tiling;
			half _Texture_4_Far_Multiplier;
			half4 _Texture_4_Color;
			half _Texture_5_Albedo_Index;
			half _Texture_5_Tiling;
			half _Texture_5_Far_Multiplier;
			half4 _Texture_5_Color;
			half _Texture_6_Albedo_Index;
			half _Texture_6_Tiling;
			half _Texture_6_Far_Multiplier;
			half4 _Texture_6_Color;
			half _Texture_7_Albedo_Index;
			half _Texture_7_Tiling;
			half _Texture_7_Far_Multiplier;
			half4 _Texture_7_Color;
			half _Texture_8_Albedo_Index;
			half _Texture_8_Tiling;
			half _Texture_8_Far_Multiplier;
			half4 _Texture_8_Color;
			half _Texture_9_Albedo_Index;
			half _Texture_9_Tiling;
			half _Texture_9_Far_Multiplier;
			half4 _Texture_9_Color;
			half _Texture_10_Albedo_Index;
			half _Texture_10_Tiling;
			half _Texture_10_Far_Multiplier;
			half4 _Texture_10_Color;
			half _Texture_11_Albedo_Index;
			half _Texture_11_Tiling;
			half _Texture_11_Far_Multiplier;
			half4 _Texture_11_Color;
			half _Texture_12_Albedo_Index;
			half _Texture_12_Tiling;
			half _Texture_12_Far_Multiplier;
			half4 _Texture_12_Color;
			half _Texture_13_Albedo_Index;
			half _Texture_13_Tiling;
			half _Texture_13_Far_Multiplier;
			half4 _Texture_13_Color;
			half _Texture_14_Albedo_Index;
			half _Texture_14_Tiling;
			half _Texture_14_Far_Multiplier;
			half4 _Texture_14_Color;
			half _Texture_15_Albedo_Index;
			half _Texture_15_Tiling;
			half _Texture_15_Far_Multiplier;
			half4 _Texture_15_Color;
			half _Texture_16_Albedo_Index;
			half _Texture_16_Tiling;
			half _Texture_16_Far_Multiplier;
			half4 _Texture_16_Color;
			half _Geological_Map_Far_Power;
			sampler2D _Texture_Geological_Map;
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
                UNITY_VERTEX_INPUT_INSTANCE_ID
                UNITY_VERTEX_OUTPUT_STEREO
        	};

			
            VertexOutput vert(GraphVertexInput v  )
            {
                VertexOutput o = (VertexOutput)0;
        	    UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				TerrainInstancing(v.vertex, v.ase_normal, v.ase_texcoord.xy);
				float3 localCalculateTangentsSRP6187 = ( ( v.ase_tangent.xyz * 0.0 ) );
				v.ase_tangent.xyz = cross ( v.ase_normal, float3( 0, 0, 1 ) );
				v.ase_tangent.w = -1;
				
				float3 ase_worldPos = mul(GetObjectToWorldMatrix(), v.vertex).xyz;
				o.ase_texcoord1.xyz = ase_worldPos;
				
				o.ase_texcoord.xy = v.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord.zw = 0;
				o.ase_texcoord1.w = 0;

				float3 vertexValue = localCalculateTangentsSRP6187;
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

           		float2 uv02588 = IN.ase_texcoord.xy * float2( 1,1 ) + float2( 0,0 );
           		float4 tex2DNode4371 = tex2D( _Texture_Splat_4, uv02588 );
           		float4 tex2DNode4370 = tex2D( _Texture_Splat_3, uv02588 );
           		float4 tex2DNode4369 = tex2D( _Texture_Splat_2, uv02588 );
           		float4 tex2DNode4368 = tex2D( _Texture_Splat_1, uv02588 );
           		float3 ase_worldPos = IN.ase_texcoord1.xyz;
           		float3 break6175 = ase_worldPos;
           		float2 appendResult6171 = (float2(break6175.x , break6175.z));
           		half2 Top_Bottom1999 = appendResult6171;
           		float temp_output_3830_0 = ( 1.0 / _Texture_1_Tiling );
           		float2 appendResult3284 = (float2(temp_output_3830_0 , temp_output_3830_0));
           		float4 texArray3292 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult3284 ) / _Texture_1_Far_Multiplier ), _Texture_1_Albedo_Index );
           		float4 ifLocalVar6119 = 0;
           		UNITY_BRANCH 
           		if( _Texture_1_Albedo_Index > -1.0 )
           		ifLocalVar6119 = ( texArray3292 * _Texture_1_Color );
           		half4 Texture_1_Final950 = ifLocalVar6119;
           		float temp_output_3831_0 = ( 1.0 / _Texture_2_Tiling );
           		float2 appendResult3349 = (float2(temp_output_3831_0 , temp_output_3831_0));
           		float4 texArray3339 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult3349 ) / _Texture_2_Far_Multiplier ), _Texture_2_Albedo_Index );
           		float4 ifLocalVar6120 = 0;
           		UNITY_BRANCH 
           		if( _Texture_2_Albedo_Index > -1.0 )
           		ifLocalVar6120 = ( texArray3339 * _Texture_2_Color );
           		half4 Texture_2_Final3385 = ifLocalVar6120;
           		float temp_output_3832_0 = ( 1.0 / _Texture_3_Tiling );
           		float2 appendResult3415 = (float2(temp_output_3832_0 , temp_output_3832_0));
           		float4 texArray3406 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult3415 ) / _Texture_3_Far_Multiplier ), _Texture_3_Albedo_Index );
           		float4 ifLocalVar6121 = 0;
           		UNITY_BRANCH 
           		if( _Texture_3_Albedo_Index > -1.0 )
           		ifLocalVar6121 = ( texArray3406 * _Texture_3_Color );
           		half4 Texture_3_Final3451 = ifLocalVar6121;
           		float4 texArray3473 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * ( 1.0 / _Texture_4_Tiling ) ) / _Texture_4_Far_Multiplier ), _Texture_4_Albedo_Index );
           		float4 ifLocalVar6122 = 0;
           		UNITY_BRANCH 
           		if( _Texture_4_Albedo_Index > -1.0 )
           		ifLocalVar6122 = ( texArray3473 * _Texture_4_Color );
           		half4 Texture_4_Final3518 = ifLocalVar6122;
           		float4 layeredBlendVar5643 = tex2DNode4368;
           		float4 layeredBlend5643 = ( lerp( lerp( lerp( lerp( float4( 0,0,0,0 ) , Texture_1_Final950 , layeredBlendVar5643.x ) , Texture_2_Final3385 , layeredBlendVar5643.y ) , Texture_3_Final3451 , layeredBlendVar5643.z ) , Texture_4_Final3518 , layeredBlendVar5643.w ) );
           		float temp_output_4397_0 = ( 1.0 / _Texture_5_Tiling );
           		float2 appendResult4399 = (float2(temp_output_4397_0 , temp_output_4397_0));
           		float4 texArray4445 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult4399 ) / _Texture_5_Far_Multiplier ), _Texture_5_Albedo_Index );
           		float4 ifLocalVar6123 = 0;
           		UNITY_BRANCH 
           		if( _Texture_5_Albedo_Index > -1.0 )
           		ifLocalVar6123 = ( texArray4445 * _Texture_5_Color );
           		half4 Texture_5_Final4396 = ifLocalVar6123;
           		float temp_output_4469_0 = ( 1.0 / _Texture_6_Tiling );
           		float2 appendResult4471 = (float2(temp_output_4469_0 , temp_output_4469_0));
           		float4 texArray4512 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult4471 ) / _Texture_6_Far_Multiplier ), _Texture_6_Albedo_Index );
           		float4 ifLocalVar6124 = 0;
           		UNITY_BRANCH 
           		if( _Texture_6_Albedo_Index > -1.0 )
           		ifLocalVar6124 = ( texArray4512 * _Texture_6_Color );
           		half4 Texture_6_Final4536 = ifLocalVar6124;
           		float temp_output_4543_0 = ( 1.0 / _Texture_7_Tiling );
           		float2 appendResult4545 = (float2(temp_output_4543_0 , temp_output_4543_0));
           		float4 texArray4586 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult4545 ) / _Texture_7_Far_Multiplier ), _Texture_7_Albedo_Index );
           		float4 ifLocalVar6125 = 0;
           		UNITY_BRANCH 
           		if( _Texture_7_Albedo_Index > -1.0 )
           		ifLocalVar6125 = ( texArray4586 * _Texture_7_Color );
           		half4 Texture_7_Final4614 = ifLocalVar6125;
           		float temp_output_4617_0 = ( 1.0 / _Texture_8_Tiling );
           		float2 appendResult4619 = (float2(temp_output_4617_0 , temp_output_4617_0));
           		float4 texArray4660 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult4619 ) / _Texture_8_Far_Multiplier ), _Texture_8_Albedo_Index );
           		float4 ifLocalVar6126 = 0;
           		UNITY_BRANCH 
           		if( _Texture_8_Albedo_Index > -1.0 )
           		ifLocalVar6126 = ( texArray4660 * _Texture_8_Color );
           		half4 Texture_8_Final4689 = ifLocalVar6126;
           		float4 layeredBlendVar5644 = tex2DNode4369;
           		float4 layeredBlend5644 = ( lerp( lerp( lerp( lerp( layeredBlend5643 , Texture_5_Final4396 , layeredBlendVar5644.x ) , Texture_6_Final4536 , layeredBlendVar5644.y ) , Texture_7_Final4614 , layeredBlendVar5644.z ) , Texture_8_Final4689 , layeredBlendVar5644.w ) );
           		float temp_output_4703_0 = ( 1.0 / _Texture_9_Tiling );
           		float2 appendResult4736 = (float2(temp_output_4703_0 , temp_output_4703_0));
           		float4 texArray4889 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult4736 ) / _Texture_9_Far_Multiplier ), _Texture_9_Albedo_Index );
           		float4 ifLocalVar6134 = 0;
           		UNITY_BRANCH 
           		if( _Texture_9_Albedo_Index > -1.0 )
           		ifLocalVar6134 = ( texArray4889 * _Texture_9_Color );
           		half4 Texture_9_Final4987 = ifLocalVar6134;
           		float temp_output_4734_0 = ( 1.0 / _Texture_10_Tiling );
           		float2 appendResult4738 = (float2(temp_output_4734_0 , temp_output_4734_0));
           		float4 texArray4913 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult4738 ) / _Texture_10_Far_Multiplier ), _Texture_10_Albedo_Index );
           		float4 ifLocalVar6133 = 0;
           		UNITY_BRANCH 
           		if( _Texture_10_Albedo_Index > -1.0 )
           		ifLocalVar6133 = ( texArray4913 * _Texture_10_Color );
           		half4 Texture_10_Final4994 = ifLocalVar6133;
           		float temp_output_4739_0 = ( 1.0 / _Texture_11_Tiling );
           		float2 appendResult4741 = (float2(temp_output_4739_0 , temp_output_4739_0));
           		float4 texArray4923 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult4741 ) / _Texture_11_Far_Multiplier ), _Texture_11_Albedo_Index );
           		float4 ifLocalVar6132 = 0;
           		UNITY_BRANCH 
           		if( _Texture_11_Albedo_Index > -1.0 )
           		ifLocalVar6132 = ( texArray4923 * _Texture_11_Color );
           		half4 Texture_11_Final4996 = ifLocalVar6132;
           		float temp_output_4745_0 = ( 1.0 / _Texture_12_Tiling );
           		float2 appendResult4751 = (float2(temp_output_4745_0 , temp_output_4745_0));
           		float4 texArray4952 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult4751 ) / _Texture_12_Far_Multiplier ), _Texture_12_Albedo_Index );
           		float4 ifLocalVar6131 = 0;
           		UNITY_BRANCH 
           		if( _Texture_12_Albedo_Index > -1.0 )
           		ifLocalVar6131 = ( texArray4952 * _Texture_12_Color );
           		half4 Texture_12_Final4997 = ifLocalVar6131;
           		float4 layeredBlendVar5645 = tex2DNode4370;
           		float4 layeredBlend5645 = ( lerp( lerp( lerp( lerp( layeredBlend5644 , Texture_9_Final4987 , layeredBlendVar5645.x ) , Texture_10_Final4994 , layeredBlendVar5645.y ) , Texture_11_Final4996 , layeredBlendVar5645.z ) , Texture_12_Final4997 , layeredBlendVar5645.w ) );
           		float temp_output_5125_0 = ( 1.0 / _Texture_13_Tiling );
           		float2 appendResult5027 = (float2(temp_output_5125_0 , temp_output_5125_0));
           		float4 texArray5034 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult5027 ) / _Texture_13_Far_Multiplier ), _Texture_13_Albedo_Index );
           		float4 ifLocalVar6130 = 0;
           		UNITY_BRANCH 
           		if( _Texture_13_Albedo_Index > -1.0 )
           		ifLocalVar6130 = ( texArray5034 * _Texture_13_Color );
           		half4 Texture_13_Final5058 = ifLocalVar6130;
           		float temp_output_5006_0 = ( 1.0 / _Texture_14_Tiling );
           		float2 appendResult5033 = (float2(temp_output_5006_0 , temp_output_5006_0));
           		float4 texArray5171 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult5033 ) / _Texture_14_Far_Multiplier ), _Texture_14_Albedo_Index );
           		float4 ifLocalVar6129 = 0;
           		UNITY_BRANCH 
           		if( _Texture_14_Albedo_Index > -1.0 )
           		ifLocalVar6129 = ( texArray5171 * _Texture_14_Color );
           		half4 Texture_14_Final5163 = ifLocalVar6129;
           		float temp_output_5210_0 = ( 1.0 / _Texture_15_Tiling );
           		float2 appendResult5212 = (float2(temp_output_5210_0 , temp_output_5210_0));
           		float4 texArray5272 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult5212 ) / _Texture_15_Far_Multiplier ), _Texture_15_Albedo_Index );
           		float4 ifLocalVar6128 = 0;
           		UNITY_BRANCH 
           		if( _Texture_15_Albedo_Index > -1.0 )
           		ifLocalVar6128 = ( texArray5272 * _Texture_15_Color );
           		half4 Texture_15_Final5270 = ifLocalVar6128;
           		float temp_output_5075_0 = ( 1.0 / _Texture_16_Tiling );
           		float2 appendResult5078 = (float2(temp_output_5075_0 , temp_output_5075_0));
           		float4 texArray5145 = SAMPLE_TEXTURE2D_ARRAY(_Texture_Array_Albedo, sampler_Texture_Array_Albedo, ( ( Top_Bottom1999 * appendResult5078 ) / _Texture_16_Far_Multiplier ), _Texture_16_Albedo_Index );
           		float4 ifLocalVar6127 = 0;
           		UNITY_BRANCH 
           		if( _Texture_16_Albedo_Index > -1.0 )
           		ifLocalVar6127 = ( texArray5145 * _Texture_16_Color );
           		half4 Texture_16_Final5094 = ifLocalVar6127;
           		float4 layeredBlendVar5646 = tex2DNode4371;
           		float4 layeredBlend5646 = ( lerp( lerp( lerp( lerp( layeredBlend5645 , Texture_13_Final5058 , layeredBlendVar5646.x ) , Texture_14_Final5163 , layeredBlendVar5646.y ) , Texture_15_Final5270 , layeredBlendVar5646.z ) , Texture_16_Final5094 , layeredBlendVar5646.w ) );
           		float4 break3856 = layeredBlend5646;
           		float3 appendResult3857 = (float3(break3856.x , break3856.y , break3856.z));
           		float2 temp_cast_0 = (( ( ase_worldPos.y / _Geological_Tiling_Far ) + _Geological_Map_Offset_Far )).xx;
           		float4 tex2DNode5983 = tex2D( _Texture_Geological_Map, temp_cast_0 );
           		float3 appendResult5985 = (float3(tex2DNode5983.r , tex2DNode5983.g , tex2DNode5983.b));
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
           		float3 blendOpSrc4362 = appendResult3857;
           		float3 blendOpDest4362 = ( ( _Geological_Map_Far_Power * ( appendResult5985 + float3( -0.3,-0.3,-0.3 ) ) ) * ( ( _Texture_16_Geological_Power * Splat4_A2546 ) + ( ( _Texture_15_Geological_Power * Splat4_B2545 ) + ( ( _Texture_14_Geological_Power * Splat4_G2544 ) + ( ( _Texture_13_Geological_Power * Splat4_R2543 ) + ( ( _Texture_12_Geological_Power * Splat3_A2540 ) + ( ( _Texture_11_Geological_Power * Splat3_B2539 ) + ( ( _Texture_10_Geological_Power * Splat3_G2538 ) + ( ( _Texture_9_Geological_Power * Splat3_R2537 ) + ( ( _Texture_8_Geological_Power * Splat2_A2109 ) + ( ( _Texture_7_Geological_Power * Splat2_B2108 ) + ( ( _Texture_6_Geological_Power * Splat2_G2107 ) + ( ( _Texture_5_Geological_Power * Splat2_R2106 ) + ( ( _Texture_1_Geological_Power * Splat1_R1438 ) + ( ( _Texture_2_Geological_Power * Splat1_G1441 ) + ( ( _Texture_4_Geological_Power * Splat1_A1491 ) + ( _Texture_3_Geological_Power * Splat1_B1442 ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) );
           		float3 clampResult5715 = clamp( ( saturate( ( blendOpSrc4362 + blendOpDest4362 ) )) , float3( 0,0,0 ) , float3( 1,1,1 ) );
           		
				
		        float3 Albedo = clampResult5715;
				float3 Emission = 0;
				float Alpha = 1;
				float AlphaClipThreshold = 0;

         #if _AlphaClip
        		clip(Alpha - AlphaClipThreshold);
        #endif

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
    
	
}