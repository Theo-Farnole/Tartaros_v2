// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_WaterReflective"
{
	Properties
	{
		_Distance("Distance", Float) = 0
		_WaterDepth("WaterDepth", Float) = 0
		[HDR]_Depths("Depths", Color) = (0,0,0,0)
		[HDR]_Surface("Surface", Color) = (0,0,0,0)
		_MovementSpeed("MovementSpeed", Float) = 0
		_Scale("Scale", Float) = 1
		_RefractionStrength("RefractionStrength", Float) = 0
		_FoamCutoff("FoamCutoff", Float) = 0
		[HDR]_FoamColor("FoamColor", Color) = (0,0,0,0.3882353)
		_ScaleFoam("ScaleFoam", Float) = 0
		_WaveSpeed("WaveSpeed", Float) = 0
		_WaveScale("WaveScale", Float) = 0
		_SmoothStepWaves("SmoothStepWaves", Vector) = (0,1,0,0)
		[HDR]_CausticsColor("CausticsColor", Color) = (1,1,1,1)
		_WavesScale("WavesScale", Vector) = (0,0,0,0)
		_WavesSpeed("WavesSpeed", Vector) = (0,0,0,0)
		_FresnelPower("FresnelPower", Range( 0 , 5)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		GrabPass{ }
		CGINCLUDE
		#include "UnityPBSLighting.cginc"
		#include "UnityShaderVariables.cginc"
		#include "UnityCG.cginc"
		#include "Lighting.cginc"
		#pragma target 3.0
		#if defined(UNITY_STEREO_INSTANCING_ENABLED) || defined(UNITY_STEREO_MULTIVIEW_ENABLED)
		#define ASE_DECLARE_SCREENSPACE_TEXTURE(tex) UNITY_DECLARE_SCREENSPACE_TEXTURE(tex);
		#else
		#define ASE_DECLARE_SCREENSPACE_TEXTURE(tex) UNITY_DECLARE_SCREENSPACE_TEXTURE(tex)
		#endif
		#ifdef UNITY_PASS_SHADOWCASTER
			#undef INTERNAL_DATA
			#undef WorldReflectionVector
			#undef WorldNormalVector
			#define INTERNAL_DATA half3 internalSurfaceTtoW0; half3 internalSurfaceTtoW1; half3 internalSurfaceTtoW2;
			#define WorldReflectionVector(data,normal) reflect (data.worldRefl, half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal)))
			#define WorldNormalVector(data,normal) half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal))
		#endif
		struct Input
		{
			float4 screenPos;
			float3 worldNormal;
			INTERNAL_DATA
			float3 worldPos;
			float2 uv_texcoord;
		};

		struct SurfaceOutputCustomLightingCustom
		{
			half3 Albedo;
			half3 Normal;
			half3 Emission;
			half Metallic;
			half Smoothness;
			half Occlusion;
			half Alpha;
			Input SurfInput;
			UnityGIInput GIData;
		};

		ASE_DECLARE_SCREENSPACE_TEXTURE( _GrabTexture )
		uniform float2 _SmoothStepWaves;
		uniform float _WaveScale;
		uniform float _WaveSpeed;
		uniform float2 _WavesScale;
		uniform float2 _WavesSpeed;
		uniform float _Scale;
		uniform float _MovementSpeed;
		uniform float _ScaleFoam;
		uniform float _RefractionStrength;
		uniform float4 _CausticsColor;
		uniform float4 _Surface;
		uniform float4 _Depths;
		UNITY_DECLARE_DEPTH_TEXTURE( _CameraDepthTexture );
		uniform float4 _CameraDepthTexture_TexelSize;
		uniform float _WaterDepth;
		uniform float4 _FoamColor;
		uniform float _Distance;
		uniform float _FoamCutoff;
		uniform float _FresnelPower;


		inline float4 ASE_ComputeGrabScreenPos( float4 pos )
		{
			#if UNITY_UV_STARTS_AT_TOP
			float scale = -1.0;
			#else
			float scale = 1.0;
			#endif
			float4 o = pos;
			o.y = pos.w * 0.5f;
			o.y = ( pos.y - o.y ) * _ProjectionParams.x * scale + o.y;
			return o;
		}


		float2 voronoihash152( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi152( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
		{
			float2 n = floor( v );
			float2 f = frac( v );
			float F1 = 8.0;
			float F2 = 8.0; float2 mg = 0;
			for ( int j = -3; j <= 3; j++ )
			{
				for ( int i = -3; i <= 3; i++ )
			 	{
			 		float2 g = float2( i, j );
			 		float2 o = voronoihash152( n + g );
					o = ( sin( time + o * 6.2831 ) * 0.5 + 0.5 ); float2 r = f - g - o;
					float d = 0.5 * dot( r, r );
			 		if( d<F1 ) {
			 			F2 = F1;
			 			F1 = d; mg = g; mr = r; id = o;
			 		} else if( d<F2 ) {
			 			F2 = d;
			 		}
			 	}
			}
			return F1;
		}


		float2 voronoihash143( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi143( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
		{
			float2 n = floor( v );
			float2 f = frac( v );
			float F1 = 8.0;
			float F2 = 8.0; float2 mg = 0;
			for ( int j = -3; j <= 3; j++ )
			{
				for ( int i = -3; i <= 3; i++ )
			 	{
			 		float2 g = float2( i, j );
			 		float2 o = voronoihash143( n + g );
					o = ( sin( time + o * 6.2831 ) * 0.5 + 0.5 ); float2 r = f - g - o;
					float d = 0.5 * dot( r, r );
			 		if( d<F1 ) {
			 			F2 = F1;
			 			F1 = d; mg = g; mr = r; id = o;
			 		} else if( d<F2 ) {
			 			F2 = d;
			 		}
			 	}
			}
			return (F2 + F1) * 0.5;
		}


		//https://www.shadertoy.com/view/XdXGW8
		float2 GradientNoiseDir( float2 x )
		{
			const float2 k = float2( 0.3183099, 0.3678794 );
			x = x * k + k.yx;
			return -1.0 + 2.0 * frac( 16.0 * k * frac( x.x * x.y * ( x.x + x.y ) ) );
		}
		
		float GradientNoise( float2 UV, float Scale )
		{
			float2 p = UV * Scale;
			float2 i = floor( p );
			float2 f = frac( p );
			float2 u = f * f * ( 3.0 - 2.0 * f );
			return lerp( lerp( dot( GradientNoiseDir( i + float2( 0.0, 0.0 ) ), f - float2( 0.0, 0.0 ) ),
					dot( GradientNoiseDir( i + float2( 1.0, 0.0 ) ), f - float2( 1.0, 0.0 ) ), u.x ),
					lerp( dot( GradientNoiseDir( i + float2( 0.0, 1.0 ) ), f - float2( 0.0, 1.0 ) ),
					dot( GradientNoiseDir( i + float2( 1.0, 1.0 ) ), f - float2( 1.0, 1.0 ) ), u.x ), u.y );
		}


		inline half4 LightingStandardCustomLighting( inout SurfaceOutputCustomLightingCustom s, half3 viewDir, UnityGI gi )
		{
			UnityGIInput data = s.GIData;
			Input i = s.SurfInput;
			half4 c = 0;
			float temp_output_137_0 = ( _Time.y * _WaveSpeed );
			float time152 = temp_output_137_0;
			float2 uv_TexCoord127 = i.uv_texcoord * _WavesScale + ( _Time.x * _WavesSpeed );
			float2 MovementWaves134 = uv_TexCoord127;
			float2 coords152 = MovementWaves134 * _WaveScale;
			float2 id152 = 0;
			float2 uv152 = 0;
			float fade152 = 0.5;
			float voroi152 = 0;
			float rest152 = 0;
			for( int it152 = 0; it152 <8; it152++ ){
			voroi152 += fade152 * voronoi152( coords152, time152, id152, uv152, 0 );
			rest152 += fade152;
			coords152 *= 2;
			fade152 *= 0.5;
			}//Voronoi152
			voroi152 /= rest152;
			float time143 = temp_output_137_0;
			float2 coords143 = MovementWaves134 * _WaveScale;
			float2 id143 = 0;
			float2 uv143 = 0;
			float voroi143 = voronoi143( coords143, time143, id143, uv143, 0 );
			float smoothstepResult175 = smoothstep( _SmoothStepWaves.x , _SmoothStepWaves.y , ( saturate( voroi152 ) * saturate( voroi143 ) ));
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float4 ase_screenPosNorm = ase_screenPos / ase_screenPos.w;
			ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
			float WaterDepth154 = _WaterDepth;
			float screenDepth167 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_screenPosNorm.xy ));
			float distanceDepth167 = abs( ( screenDepth167 - LinearEyeDepth( ase_screenPosNorm.z ) ) / ( WaterDepth154 ) );
			float4 lerpResult171 = lerp( _Surface , _Depths , distanceDepth167);
			float4 clampResult182 = clamp( lerpResult171 , float4( 0,0,0,0 ) , float4( 1,1,1,1 ) );
			float4 FoamColor178 = _FoamColor;
			float screenDepth147 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_screenPosNorm.xy ));
			float distanceDepth147 = abs( ( screenDepth147 - LinearEyeDepth( ase_screenPosNorm.z ) ) / ( _Distance ) );
			float eyeDepth117 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_screenPosNorm.xy ));
			float DepthFade139 = saturate( ( ( eyeDepth117 - ase_screenPosNorm.w ) / 0.0 ) );
			float2 temp_cast_5 = (_Scale).xx;
			float2 temp_cast_6 = (( _Time.x * _MovementSpeed )).xx;
			float2 uv_TexCoord133 = i.uv_texcoord * temp_cast_5 + temp_cast_6;
			float2 MovementNormal136 = uv_TexCoord133;
			float gradientNoise153 = GradientNoise(MovementNormal136,_ScaleFoam);
			gradientNoise153 = gradientNoise153*0.5 + 0.5;
			float FoamAlpha180 = ( _FoamColor.a * step( ( distanceDepth147 * _FoamCutoff * DepthFade139 ) , gradientNoise153 ) );
			float4 lerpResult188 = lerp( ( ( smoothstepResult175 * _CausticsColor ) + clampResult182 ) , FoamColor178 , FoamAlpha180);
			float temp_output_194_3 = lerpResult188.a;
			float3 ase_worldNormal = WorldNormalVector( i, float3( 0, 0, 1 ) );
			Unity_GlossyEnvironmentData g212 = UnityGlossyEnvironmentSetup( 1.0, data.worldViewDir, ase_worldNormal, float3(0,0,0));
			float3 indirectSpecular212 = UnityGI_IndirectSpecular( data, 1.0, ase_worldNormal, g212 );
			float4 ase_grabScreenPos = ASE_ComputeGrabScreenPos( ase_screenPos );
			float4 ase_grabScreenPosNorm = ase_grabScreenPos / ase_grabScreenPos.w;
			float2 appendResult220 = (float2(ase_grabScreenPosNorm.r , ase_grabScreenPosNorm.g));
			float3 ase_worldPos = i.worldPos;
			float3 temp_output_16_0_g5 = ( ase_worldPos * 100.0 );
			float3 crossY18_g5 = cross( ase_worldNormal , ddy( temp_output_16_0_g5 ) );
			float3 worldDerivativeX2_g5 = ddx( temp_output_16_0_g5 );
			float dotResult6_g5 = dot( crossY18_g5 , worldDerivativeX2_g5 );
			float crossYDotWorldDerivX34_g5 = abs( dotResult6_g5 );
			float HeightCustom213 = smoothstepResult175;
			float temp_output_20_0_g5 = HeightCustom213;
			float3 crossX19_g5 = cross( ase_worldNormal , worldDerivativeX2_g5 );
			float3 break29_g5 = ( sign( crossYDotWorldDerivX34_g5 ) * ( ( ddx( temp_output_20_0_g5 ) * crossY18_g5 ) + ( ddy( temp_output_20_0_g5 ) * crossX19_g5 ) ) );
			float3 appendResult30_g5 = (float3(break29_g5.x , -break29_g5.y , break29_g5.z));
			float3 normalizeResult39_g5 = normalize( ( ( crossYDotWorldDerivX34_g5 * ase_worldNormal ) - appendResult30_g5 ) );
			float3 ase_worldTangent = WorldNormalVector( i, float3( 1, 0, 0 ) );
			float3 ase_worldBitangent = WorldNormalVector( i, float3( 0, 1, 0 ) );
			float3x3 ase_worldToTangent = float3x3( ase_worldTangent, ase_worldBitangent, ase_worldNormal );
			float3 worldToTangentDir42_g5 = mul( ase_worldToTangent, normalizeResult39_g5);
			float2 temp_output_145_0 = (worldToTangentDir42_g5).xy;
			float2 ScreenUV222 = ( appendResult220 - ( temp_output_145_0 * float2( 0.1,0.1 ) ) );
			float4 screenColor195 = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_GrabTexture,ScreenUV222);
			float3 temp_output_16_0_g4 = ( ase_worldPos * 100.0 );
			float3 crossY18_g4 = cross( ase_worldNormal , ddy( temp_output_16_0_g4 ) );
			float3 worldDerivativeX2_g4 = ddx( temp_output_16_0_g4 );
			float dotResult6_g4 = dot( crossY18_g4 , worldDerivativeX2_g4 );
			float crossYDotWorldDerivX34_g4 = abs( dotResult6_g4 );
			float temp_output_20_0_g4 = gradientNoise153;
			float3 crossX19_g4 = cross( ase_worldNormal , worldDerivativeX2_g4 );
			float3 break29_g4 = ( sign( crossYDotWorldDerivX34_g4 ) * ( ( ddx( temp_output_20_0_g4 ) * crossY18_g4 ) + ( ddy( temp_output_20_0_g4 ) * crossX19_g4 ) ) );
			float3 appendResult30_g4 = (float3(break29_g4.x , -break29_g4.y , break29_g4.z));
			float3 normalizeResult39_g4 = normalize( ( ( crossYDotWorldDerivX34_g4 * ase_worldNormal ) - appendResult30_g4 ) );
			float3 worldToTangentDir42_g4 = mul( ase_worldToTangent, normalizeResult39_g4);
			float4 screenColor186 = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_GrabTexture,( ase_screenPosNorm + float4( ( worldToTangentDir42_g4 * _RefractionStrength ) , 0.0 ) ).xy);
			float4 NormalToSceneColor189 = screenColor186;
			float4 lerpResult196 = lerp( NormalToSceneColor189 , lerpResult188 , lerpResult188.a);
			float4 lerpResult199 = lerp( screenColor195 , lerpResult196 , lerpResult188.a);
			float3 ase_worldViewDir = normalize( UnityWorldSpaceViewDir( ase_worldPos ) );
			float3 ase_vertexNormal = mul( unity_WorldToObject, float4( ase_worldNormal, 0 ) );
			float2 appendResult144 = (float2(ase_vertexNormal.x , ase_vertexNormal.y));
			float3 appendResult169 = (float3(( appendResult144 - temp_output_145_0 ) , ase_vertexNormal.z));
			float dotResult170 = dot( ase_worldViewDir , appendResult169 );
			float CustomFresnel197 = pow( ( 1.0 - saturate( abs( dotResult170 ) ) ) , _FresnelPower );
			float4 lerpResult206 = lerp( float4( indirectSpecular212 , 0.0 ) , lerpResult199 , CustomFresnel197);
			c.rgb = lerpResult206.rgb;
			c.a = temp_output_194_3;
			return c;
		}

		inline void LightingStandardCustomLighting_GI( inout SurfaceOutputCustomLightingCustom s, UnityGIInput data, inout UnityGI gi )
		{
			s.GIData = data;
		}

		void surf( Input i , inout SurfaceOutputCustomLightingCustom o )
		{
			o.SurfInput = i;
			o.Normal = float3(0,0,1);
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float4 ase_grabScreenPos = ASE_ComputeGrabScreenPos( ase_screenPos );
			float4 ase_grabScreenPosNorm = ase_grabScreenPos / ase_grabScreenPos.w;
			float2 appendResult220 = (float2(ase_grabScreenPosNorm.r , ase_grabScreenPosNorm.g));
			float3 ase_worldNormal = WorldNormalVector( i, float3( 0, 0, 1 ) );
			float3 ase_worldPos = i.worldPos;
			float3 temp_output_16_0_g5 = ( ase_worldPos * 100.0 );
			float3 crossY18_g5 = cross( ase_worldNormal , ddy( temp_output_16_0_g5 ) );
			float3 worldDerivativeX2_g5 = ddx( temp_output_16_0_g5 );
			float dotResult6_g5 = dot( crossY18_g5 , worldDerivativeX2_g5 );
			float crossYDotWorldDerivX34_g5 = abs( dotResult6_g5 );
			float temp_output_137_0 = ( _Time.y * _WaveSpeed );
			float time152 = temp_output_137_0;
			float2 uv_TexCoord127 = i.uv_texcoord * _WavesScale + ( _Time.x * _WavesSpeed );
			float2 MovementWaves134 = uv_TexCoord127;
			float2 coords152 = MovementWaves134 * _WaveScale;
			float2 id152 = 0;
			float2 uv152 = 0;
			float fade152 = 0.5;
			float voroi152 = 0;
			float rest152 = 0;
			for( int it152 = 0; it152 <8; it152++ ){
			voroi152 += fade152 * voronoi152( coords152, time152, id152, uv152, 0 );
			rest152 += fade152;
			coords152 *= 2;
			fade152 *= 0.5;
			}//Voronoi152
			voroi152 /= rest152;
			float time143 = temp_output_137_0;
			float2 coords143 = MovementWaves134 * _WaveScale;
			float2 id143 = 0;
			float2 uv143 = 0;
			float voroi143 = voronoi143( coords143, time143, id143, uv143, 0 );
			float smoothstepResult175 = smoothstep( _SmoothStepWaves.x , _SmoothStepWaves.y , ( saturate( voroi152 ) * saturate( voroi143 ) ));
			float HeightCustom213 = smoothstepResult175;
			float temp_output_20_0_g5 = HeightCustom213;
			float3 crossX19_g5 = cross( ase_worldNormal , worldDerivativeX2_g5 );
			float3 break29_g5 = ( sign( crossYDotWorldDerivX34_g5 ) * ( ( ddx( temp_output_20_0_g5 ) * crossY18_g5 ) + ( ddy( temp_output_20_0_g5 ) * crossX19_g5 ) ) );
			float3 appendResult30_g5 = (float3(break29_g5.x , -break29_g5.y , break29_g5.z));
			float3 normalizeResult39_g5 = normalize( ( ( crossYDotWorldDerivX34_g5 * ase_worldNormal ) - appendResult30_g5 ) );
			float3 ase_worldTangent = WorldNormalVector( i, float3( 1, 0, 0 ) );
			float3 ase_worldBitangent = WorldNormalVector( i, float3( 0, 1, 0 ) );
			float3x3 ase_worldToTangent = float3x3( ase_worldTangent, ase_worldBitangent, ase_worldNormal );
			float3 worldToTangentDir42_g5 = mul( ase_worldToTangent, normalizeResult39_g5);
			float2 temp_output_145_0 = (worldToTangentDir42_g5).xy;
			float2 ScreenUV222 = ( appendResult220 - ( temp_output_145_0 * float2( 0.1,0.1 ) ) );
			float4 screenColor195 = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_GrabTexture,ScreenUV222);
			float4 ase_screenPosNorm = ase_screenPos / ase_screenPos.w;
			ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
			float3 temp_output_16_0_g4 = ( ase_worldPos * 100.0 );
			float3 crossY18_g4 = cross( ase_worldNormal , ddy( temp_output_16_0_g4 ) );
			float3 worldDerivativeX2_g4 = ddx( temp_output_16_0_g4 );
			float dotResult6_g4 = dot( crossY18_g4 , worldDerivativeX2_g4 );
			float crossYDotWorldDerivX34_g4 = abs( dotResult6_g4 );
			float2 temp_cast_0 = (_Scale).xx;
			float2 temp_cast_1 = (( _Time.x * _MovementSpeed )).xx;
			float2 uv_TexCoord133 = i.uv_texcoord * temp_cast_0 + temp_cast_1;
			float2 MovementNormal136 = uv_TexCoord133;
			float gradientNoise153 = GradientNoise(MovementNormal136,_ScaleFoam);
			gradientNoise153 = gradientNoise153*0.5 + 0.5;
			float temp_output_20_0_g4 = gradientNoise153;
			float3 crossX19_g4 = cross( ase_worldNormal , worldDerivativeX2_g4 );
			float3 break29_g4 = ( sign( crossYDotWorldDerivX34_g4 ) * ( ( ddx( temp_output_20_0_g4 ) * crossY18_g4 ) + ( ddy( temp_output_20_0_g4 ) * crossX19_g4 ) ) );
			float3 appendResult30_g4 = (float3(break29_g4.x , -break29_g4.y , break29_g4.z));
			float3 normalizeResult39_g4 = normalize( ( ( crossYDotWorldDerivX34_g4 * ase_worldNormal ) - appendResult30_g4 ) );
			float3 worldToTangentDir42_g4 = mul( ase_worldToTangent, normalizeResult39_g4);
			float4 screenColor186 = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_GrabTexture,( ase_screenPosNorm + float4( ( worldToTangentDir42_g4 * _RefractionStrength ) , 0.0 ) ).xy);
			float4 NormalToSceneColor189 = screenColor186;
			float WaterDepth154 = _WaterDepth;
			float screenDepth167 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_screenPosNorm.xy ));
			float distanceDepth167 = abs( ( screenDepth167 - LinearEyeDepth( ase_screenPosNorm.z ) ) / ( WaterDepth154 ) );
			float4 lerpResult171 = lerp( _Surface , _Depths , distanceDepth167);
			float4 clampResult182 = clamp( lerpResult171 , float4( 0,0,0,0 ) , float4( 1,1,1,1 ) );
			float4 FoamColor178 = _FoamColor;
			float screenDepth147 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_screenPosNorm.xy ));
			float distanceDepth147 = abs( ( screenDepth147 - LinearEyeDepth( ase_screenPosNorm.z ) ) / ( _Distance ) );
			float eyeDepth117 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_screenPosNorm.xy ));
			float DepthFade139 = saturate( ( ( eyeDepth117 - ase_screenPosNorm.w ) / 0.0 ) );
			float FoamAlpha180 = ( _FoamColor.a * step( ( distanceDepth147 * _FoamCutoff * DepthFade139 ) , gradientNoise153 ) );
			float4 lerpResult188 = lerp( ( ( smoothstepResult175 * _CausticsColor ) + clampResult182 ) , FoamColor178 , FoamAlpha180);
			float4 lerpResult196 = lerp( NormalToSceneColor189 , lerpResult188 , lerpResult188.a);
			float4 lerpResult199 = lerp( screenColor195 , lerpResult196 , lerpResult188.a);
			o.Emission = lerpResult199.rgb;
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf StandardCustomLighting alpha:fade keepalpha fullforwardshadows exclude_path:deferred 

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
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
			sampler3D _DitherMaskLOD;
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float2 customPack1 : TEXCOORD1;
				float4 screenPos : TEXCOORD2;
				float4 tSpace0 : TEXCOORD3;
				float4 tSpace1 : TEXCOORD4;
				float4 tSpace2 : TEXCOORD5;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};
			v2f vert( appdata_full v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_INITIALIZE_OUTPUT( v2f, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				Input customInputData;
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
				o.screenPos = ComputeScreenPos( o.pos );
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
				surfIN.screenPos = IN.screenPos;
				SurfaceOutputCustomLightingCustom o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputCustomLightingCustom, o )
				surf( surfIN, o );
				UnityGI gi;
				UNITY_INITIALIZE_OUTPUT( UnityGI, gi );
				o.Alpha = LightingStandardCustomLighting( o, worldViewDir, gi ).a;
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				half alphaRef = tex3D( _DitherMaskLOD, float3( vpos.xy * 0.25, o.Alpha * 0.9375 ) ).a;
				clip( alphaRef - 0.01 );
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
361;73;1175;655;1856.41;827.7914;1.3;True;False
Node;AmplifyShaderEditor.TimeNode;119;-4850.003,-1065.734;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;120;-4824.186,-907.3875;Inherit;False;Property;_WavesSpeed;WavesSpeed;15;0;Create;True;0;0;False;0;False;0,0;0,-0.3;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;122;-4535.926,-1167.338;Inherit;False;Property;_WavesScale;WavesScale;14;0;Create;True;0;0;False;0;False;0,0;0.5,1.5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;124;-4529.9,-1036.471;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;127;-4166.782,-1086.601;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;130;-2853.768,-925.7535;Inherit;False;Property;_WaveSpeed;WaveSpeed;10;0;Create;True;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;134;-3845.74,-1090.537;Inherit;True;MovementWaves;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TimeNode;132;-2889.569,-1069.553;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;137;-2571.868,-1012.854;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;138;-2614.705,-863.732;Inherit;False;Property;_WaveScale;WaveScale;11;0;Create;True;0;0;False;0;False;0;40;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;140;-2599.708,-1146.462;Inherit;False;134;MovementWaves;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.VoronoiNode;152;-2333.972,-1359.25;Inherit;True;2;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;10;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.VoronoiNode;143;-2328.022,-1125.663;Inherit;False;2;0;1;3;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;10;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.ScreenPosInputsNode;116;-4957.558,-2113.816;Float;False;0;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;157;-2091.236,-1306.124;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;155;-2105.286,-1184.623;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;168;-1560.402,-1077.04;Inherit;False;Property;_SmoothStepWaves;SmoothStepWaves;12;0;Create;True;0;0;False;0;False;0,1;-0.5,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;166;-1880.958,-1373.311;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenDepthNode;117;-4720.346,-2116.642;Inherit;False;0;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenPosInputsNode;118;-4792.047,-1891.176;Float;True;0;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;175;-1544.44,-1208.262;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0.5;False;2;FLOAT;0.6;False;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;123;-4870.926,-1376.46;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;121;-4866.201,-1220.001;Inherit;False;Property;_MovementSpeed;MovementSpeed;4;0;Create;True;0;0;False;0;False;0;-0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;125;-4388.524,-1888.318;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;129;-4021.326,-1866.286;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;126;-4555.255,-1396.145;Inherit;False;Property;_Scale;Scale;5;0;Create;True;0;0;False;0;False;1;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;128;-4550.823,-1311.197;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;213;-1294.713,-1203.443;Inherit;False;HeightCustom;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;133;-4187.705,-1361.327;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;131;-3780.809,-1866.286;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;215;-5617.543,1477.849;Inherit;False;213;HeightCustom;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;214;-5309.395,1484.979;Inherit;True;Normal From Height;-1;;5;1942fe2c5f1a1f94881a33d532e4afeb;0;1;20;FLOAT;0;False;2;FLOAT3;40;FLOAT3;0
Node;AmplifyShaderEditor.NormalVertexDataNode;141;-5158.71,1285.433;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;135;-5621.98,-293.9164;Inherit;False;Property;_Distance;Distance;0;0;Create;True;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;136;-3866.663,-1365.263;Inherit;True;MovementNormal;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;139;-3564.091,-1845.133;Inherit;True;DepthFade;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;145;-4884.995,1477.258;Inherit;False;True;True;False;True;1;0;FLOAT3;0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DepthFade;147;-5373.548,-404.7435;Inherit;False;True;False;True;2;1;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;148;-5355.871,-268.2896;Inherit;False;139;DepthFade;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;151;-5335.622,-172.5822;Inherit;False;Property;_FoamCutoff;FoamCutoff;7;0;Create;True;0;0;False;0;False;0;4.09;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;150;-3071.459,102.0368;Inherit;False;Property;_WaterDepth;WaterDepth;1;0;Create;True;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;149;-5337.192,264.7672;Inherit;False;136;MovementNormal;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;144;-4834.589,1311.891;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;146;-5262.804,357.1635;Inherit;False;Property;_ScaleFoam;ScaleFoam;9;0;Create;True;0;0;False;0;False;0;100;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;158;-4611.883,1380.382;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;156;-4984.571,-228.8107;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;153;-5047.151,266.8238;Inherit;True;Gradient;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;20;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;154;-2873.927,90.04769;Inherit;False;WaterDepth;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;160;-2574.965,-446.4584;Inherit;False;Property;_Surface;Surface;3;1;[HDR];Create;True;0;0;False;0;False;0,0,0,0;0,0.2802697,0.509434,0.8078431;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;161;-4770.622,-401.1258;Inherit;False;Property;_FoamColor;FoamColor;8;1;[HDR];Create;True;0;0;False;0;False;0,0,0,0.3882353;0.2082592,0.4867719,0.6792453,0.8666667;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ViewDirInputsCoordNode;159;-4355.012,1209.657;Inherit;False;World;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.DepthFade;167;-2609.126,-36.24015;Inherit;False;True;False;True;2;1;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;162;-4753.285,274.8724;Inherit;True;Normal From Height;-1;;4;1942fe2c5f1a1f94881a33d532e4afeb;0;1;20;FLOAT;0;False;2;FLOAT3;40;FLOAT3;0
Node;AmplifyShaderEditor.StepOpNode;163;-4705.866,-82.41422;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;164;-2578.352,-261.8848;Inherit;False;Property;_Depths;Depths;2;1;[HDR];Create;True;0;0;False;0;False;0,0,0,0;0.133633,0.4706989,0.7264151,0.6470588;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;169;-4293.927,1385.081;Inherit;False;FLOAT3;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;165;-4557.412,511.7813;Inherit;False;Property;_RefractionStrength;RefractionStrength;6;0;Create;True;0;0;False;0;False;0;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DotProductOpNode;170;-4076.215,1289.538;Inherit;True;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;174;-4357.294,-87.23698;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;172;-4227.438,381.3538;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ScreenPosInputsNode;176;-4248.249,169.6473;Float;False;0;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;171;-2245.771,-258.8034;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;173;-1853.511,-1087.957;Inherit;False;Property;_CausticsColor;CausticsColor;13;1;[HDR];Create;True;0;0;False;0;False;1,1,1,1;0.2830189,0.2830189,0.2830189,0.1490196;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GrabScreenPosition;219;-4730.197,1850.832;Inherit;False;0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;218;-4620.694,1698.639;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0.1,0.1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;178;-4478.756,-396.8967;Inherit;False;FoamColor;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;177;-3939.492,363.3947;Inherit;True;2;2;0;FLOAT4;0,0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;179;-1513.303,-910.3448;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.AbsOpNode;181;-3845.971,1292.671;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;220;-4431.378,1882.384;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ClampOpNode;182;-2078.213,-213.3357;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,1,1,1;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;180;-4133.938,-97.39335;Inherit;False;FoamAlpha;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;221;-4249.491,1752.464;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;184;-2195.53,47.40133;Inherit;False;178;FoamColor;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;183;-1924.391,-207.4237;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ScreenColorNode;186;-3668.513,356.1685;Inherit;False;Global;_GrabScreen0;Grab Screen 0;7;0;Create;True;0;0;False;0;False;Object;-1;False;False;1;0;FLOAT2;0,0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;187;-2196.325,137.608;Inherit;False;180;FoamAlpha;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;185;-3698.739,1291.104;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;189;-3412.438,360.1665;Inherit;True;NormalToSceneColor;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;188;-1859.894,-21.19498;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;191;-3531.142,1292.671;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;190;-3672.11,1400.742;Inherit;False;Property;_FresnelPower;FresnelPower;18;0;Create;True;0;0;False;0;False;0;1;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;222;-4047.188,1750.608;Inherit;False;ScreenUV;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.BreakToComponentsNode;194;-1545.744,15.57075;Inherit;True;COLOR;1;0;COLOR;0,0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.GetLocalVarNode;223;-1311.709,-480.6914;Inherit;False;222;ScreenUV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PowerNode;193;-3336.924,1291.104;Inherit;False;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;192;-1527.194,-299.1786;Inherit;False;189;NormalToSceneColor;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.ScreenColorNode;195;-1102.314,-384.6234;Inherit;False;Global;_GrabScreen2;Grab Screen 2;16;0;Create;True;0;0;False;0;False;Object;-1;False;False;1;0;FLOAT2;0,0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;196;-1167.148,-141.0215;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;197;-3112.94,1287.972;Inherit;False;CustomFresnel;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;198;-319.47,436.1608;Inherit;False;197;CustomFresnel;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;199;-739.9208,-106.527;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.IndirectSpecularLight;212;-414.6814,591.6007;Inherit;False;Tangent;3;0;FLOAT3;0,0,1;False;1;FLOAT;1;False;2;FLOAT;1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ViewDirInputsCoordNode;203;-2094.392,453.7454;Inherit;False;Tangent;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.ScreenColorNode;208;-720.4009,333.6156;Inherit;False;Global;_GrabScreen1;Grab Screen 1;17;0;Create;True;0;0;False;0;False;Object;-1;False;True;1;0;FLOAT4;0,0,0,0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;209;-2083.903,778.7154;Inherit;False;Property;_Reflection;Reflection;16;0;Create;True;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.CustomExpressionNode;205;-1702.039,540.7764;Inherit;False;return refract(View, Normal, IOR)@;3;False;3;False;View;FLOAT3;0,0,0;In;;Inherit;False;False;Normal;FLOAT3;0,0,0;In;;Inherit;False;False;IOR;FLOAT;0;In;;Inherit;False;Custom Refract;True;False;0;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ScreenPosInputsNode;207;-1448.16,354.0116;Float;False;0;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TransformDirectionNode;201;-1454.968,536.2896;Inherit;False;World;Tangent;False;Fast;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.Vector3Node;211;-853.2057,1117.507;Inherit;False;Property;_BSP;BSP;17;0;Create;True;0;0;False;0;False;0,0,0;0,1,5;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.FresnelNode;210;-604.0848,1081.191;Inherit;False;Standard;WorldNormal;ViewDir;False;False;5;0;FLOAT3;0,0,1;False;4;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;202;-141.7572,95.28281;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.WorldSpaceLightDirHlpNode;200;-192.4501,876.8044;Inherit;False;False;1;0;FLOAT;0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.LerpOp;206;30.45795,245.4063;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.WorldNormalVector;204;-2106.717,618.8365;Inherit;False;False;1;0;FLOAT3;0,0,1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;1670.955,131.4602;Float;False;True;-1;2;ASEMaterialInspector;0;0;CustomLighting;Tartaros/SH_WaterReflective;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;5;True;True;0;False;Transparent;;Transparent;ForwardOnly;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;5;True;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.3;False;-1;0;False;-1;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;124;0;119;1
WireConnection;124;1;120;0
WireConnection;127;0;122;0
WireConnection;127;1;124;0
WireConnection;134;0;127;0
WireConnection;137;0;132;2
WireConnection;137;1;130;0
WireConnection;152;0;140;0
WireConnection;152;1;137;0
WireConnection;152;2;138;0
WireConnection;143;0;140;0
WireConnection;143;1;137;0
WireConnection;143;2;138;0
WireConnection;157;0;152;0
WireConnection;155;0;143;0
WireConnection;166;0;157;0
WireConnection;166;1;155;0
WireConnection;117;0;116;0
WireConnection;175;0;166;0
WireConnection;175;1;168;1
WireConnection;175;2;168;2
WireConnection;125;0;117;0
WireConnection;125;1;118;4
WireConnection;129;0;125;0
WireConnection;128;0;123;1
WireConnection;128;1;121;0
WireConnection;213;0;175;0
WireConnection;133;0;126;0
WireConnection;133;1;128;0
WireConnection;131;0;129;0
WireConnection;214;20;215;0
WireConnection;136;0;133;0
WireConnection;139;0;131;0
WireConnection;145;0;214;40
WireConnection;147;0;135;0
WireConnection;144;0;141;1
WireConnection;144;1;141;2
WireConnection;158;0;144;0
WireConnection;158;1;145;0
WireConnection;156;0;147;0
WireConnection;156;1;151;0
WireConnection;156;2;148;0
WireConnection;153;0;149;0
WireConnection;153;1;146;0
WireConnection;154;0;150;0
WireConnection;167;0;154;0
WireConnection;162;20;153;0
WireConnection;163;0;156;0
WireConnection;163;1;153;0
WireConnection;169;0;158;0
WireConnection;169;2;141;3
WireConnection;170;0;159;0
WireConnection;170;1;169;0
WireConnection;174;0;161;4
WireConnection;174;1;163;0
WireConnection;172;0;162;40
WireConnection;172;1;165;0
WireConnection;171;0;160;0
WireConnection;171;1;164;0
WireConnection;171;2;167;0
WireConnection;218;0;145;0
WireConnection;178;0;161;0
WireConnection;177;0;176;0
WireConnection;177;1;172;0
WireConnection;179;0;175;0
WireConnection;179;1;173;0
WireConnection;181;0;170;0
WireConnection;220;0;219;1
WireConnection;220;1;219;2
WireConnection;182;0;171;0
WireConnection;180;0;174;0
WireConnection;221;0;220;0
WireConnection;221;1;218;0
WireConnection;183;0;179;0
WireConnection;183;1;182;0
WireConnection;186;0;177;0
WireConnection;185;0;181;0
WireConnection;189;0;186;0
WireConnection;188;0;183;0
WireConnection;188;1;184;0
WireConnection;188;2;187;0
WireConnection;191;0;185;0
WireConnection;222;0;221;0
WireConnection;194;0;188;0
WireConnection;193;0;191;0
WireConnection;193;1;190;0
WireConnection;195;0;223;0
WireConnection;196;0;192;0
WireConnection;196;1;188;0
WireConnection;196;2;194;3
WireConnection;197;0;193;0
WireConnection;199;0;195;0
WireConnection;199;1;196;0
WireConnection;199;2;194;3
WireConnection;205;0;203;0
WireConnection;205;1;204;0
WireConnection;205;2;209;0
WireConnection;201;0;205;0
WireConnection;210;1;211;1
WireConnection;210;2;211;2
WireConnection;210;3;211;3
WireConnection;202;0;199;0
WireConnection;206;0;212;0
WireConnection;206;1;199;0
WireConnection;206;2;198;0
WireConnection;0;2;199;0
WireConnection;0;9;194;3
WireConnection;0;13;206;0
ASEEND*/
//CHKSM=5AC6781051BFD8EC80755CF1D6F0E6078D023540