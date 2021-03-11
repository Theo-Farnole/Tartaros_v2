// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "SH_Water"
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
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" }
		Cull Back
		GrabPass{ }
		CGINCLUDE
		#include "UnityShaderVariables.cginc"
		#include "UnityCG.cginc"
		#include "UnityPBSLighting.cginc"
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

		ASE_DECLARE_SCREENSPACE_TEXTURE( _GrabTexture )
		uniform float _Scale;
		uniform float _MovementSpeed;
		uniform float _ScaleFoam;
		uniform float _RefractionStrength;
		uniform float2 _SmoothStepWaves;
		uniform float _WaveScale;
		uniform float _WaveSpeed;
		uniform float2 _WavesScale;
		uniform float2 _WavesSpeed;
		uniform float4 _CausticsColor;
		uniform float4 _Surface;
		uniform float4 _Depths;
		UNITY_DECLARE_DEPTH_TEXTURE( _CameraDepthTexture );
		uniform float4 _CameraDepthTexture_TexelSize;
		uniform float _WaterDepth;
		uniform float4 _FoamColor;
		uniform float _Distance;
		uniform float _FoamCutoff;


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


		float2 voronoihash90( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi90( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash90( n + g );
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


		float2 voronoihash75( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi75( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash75( n + g );
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


		void surf( Input i , inout SurfaceOutputStandard o )
		{
			o.Normal = float3(0,0,1);
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float4 ase_screenPosNorm = ase_screenPos / ase_screenPos.w;
			ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
			float3 ase_worldNormal = WorldNormalVector( i, float3( 0, 0, 1 ) );
			float3 ase_worldPos = i.worldPos;
			float3 temp_output_16_0_g1 = ( ase_worldPos * 100.0 );
			float3 crossY18_g1 = cross( ase_worldNormal , ddy( temp_output_16_0_g1 ) );
			float3 worldDerivativeX2_g1 = ddx( temp_output_16_0_g1 );
			float dotResult6_g1 = dot( crossY18_g1 , worldDerivativeX2_g1 );
			float crossYDotWorldDerivX34_g1 = abs( dotResult6_g1 );
			float2 temp_cast_0 = (_Scale).xx;
			float2 temp_cast_1 = (( _Time.x * _MovementSpeed )).xx;
			float2 uv_TexCoord30 = i.uv_texcoord * temp_cast_0 + temp_cast_1;
			float2 MovementNormal33 = uv_TexCoord30;
			float gradientNoise37 = GradientNoise(MovementNormal33,_ScaleFoam);
			gradientNoise37 = gradientNoise37*0.5 + 0.5;
			float temp_output_20_0_g1 = gradientNoise37;
			float3 crossX19_g1 = cross( ase_worldNormal , worldDerivativeX2_g1 );
			float3 break29_g1 = ( sign( crossYDotWorldDerivX34_g1 ) * ( ( ddx( temp_output_20_0_g1 ) * crossY18_g1 ) + ( ddy( temp_output_20_0_g1 ) * crossX19_g1 ) ) );
			float3 appendResult30_g1 = (float3(break29_g1.x , -break29_g1.y , break29_g1.z));
			float3 normalizeResult39_g1 = normalize( ( ( crossYDotWorldDerivX34_g1 * ase_worldNormal ) - appendResult30_g1 ) );
			float3 ase_worldTangent = WorldNormalVector( i, float3( 1, 0, 0 ) );
			float3 ase_worldBitangent = WorldNormalVector( i, float3( 0, 1, 0 ) );
			float3x3 ase_worldToTangent = float3x3( ase_worldTangent, ase_worldBitangent, ase_worldNormal );
			float3 worldToTangentDir42_g1 = mul( ase_worldToTangent, normalizeResult39_g1);
			float4 screenColor43 = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_GrabTexture,( ase_screenPosNorm + float4( ( worldToTangentDir42_g1 * _RefractionStrength ) , 0.0 ) ).xy);
			float4 NormalToSceneColor45 = screenColor43;
			float temp_output_85_0 = ( _Time.y * _WaveSpeed );
			float time90 = temp_output_85_0;
			float2 uv_TexCoord98 = i.uv_texcoord * _WavesScale + ( _Time.x * _WavesSpeed );
			float2 MovementWaves99 = uv_TexCoord98;
			float2 coords90 = MovementWaves99 * _WaveScale;
			float2 id90 = 0;
			float2 uv90 = 0;
			float fade90 = 0.5;
			float voroi90 = 0;
			float rest90 = 0;
			for( int it90 = 0; it90 <8; it90++ ){
			voroi90 += fade90 * voronoi90( coords90, time90, id90, uv90, 0 );
			rest90 += fade90;
			coords90 *= 2;
			fade90 *= 0.5;
			}//Voronoi90
			voroi90 /= rest90;
			float time75 = temp_output_85_0;
			float2 coords75 = MovementWaves99 * _WaveScale;
			float2 id75 = 0;
			float2 uv75 = 0;
			float voroi75 = voronoi75( coords75, time75, id75, uv75, 0 );
			float smoothstepResult80 = smoothstep( _SmoothStepWaves.x , _SmoothStepWaves.y , ( saturate( voroi90 ) * saturate( voroi75 ) ));
			float WaterDepth71 = _WaterDepth;
			float screenDepth24 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_screenPosNorm.xy ));
			float distanceDepth24 = abs( ( screenDepth24 - LinearEyeDepth( ase_screenPosNorm.z ) ) / ( WaterDepth71 ) );
			float4 lerpResult25 = lerp( _Surface , _Depths , distanceDepth24);
			float4 clampResult115 = clamp( lerpResult25 , float4( 0,0,0,0 ) , float4( 1,1,1,1 ) );
			float4 FoamColor62 = _FoamColor;
			float screenDepth67 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_screenPosNorm.xy ));
			float distanceDepth67 = abs( ( screenDepth67 - LinearEyeDepth( ase_screenPosNorm.z ) ) / ( _Distance ) );
			float eyeDepth2 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_screenPosNorm.xy ));
			float DepthFade34 = saturate( ( ( eyeDepth2 - ase_screenPosNorm.w ) / 0.0 ) );
			float FoamAlpha58 = ( _FoamColor.a * step( ( distanceDepth67 * _FoamCutoff * DepthFade34 ) , gradientNoise37 ) );
			float4 lerpResult57 = lerp( ( ( smoothstepResult80 * _CausticsColor ) + clampResult115 ) , FoamColor62 , FoamAlpha58);
			float4 lerpResult44 = lerp( NormalToSceneColor45 , lerpResult57 , lerpResult57.a);
			o.Albedo = lerpResult44.rgb;
			o.Alpha = 1;
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf Standard alpha:fade keepalpha fullforwardshadows exclude_path:deferred 

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
				SurfaceOutputStandard o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputStandard, o )
				surf( surfIN, o );
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
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
272;73;1265;655;1713.366;1033.633;3.222233;True;False
Node;AmplifyShaderEditor.ScreenPosInputsNode;3;-2467.848,-1726.549;Float;False;0;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ScreenDepthNode;2;-2230.636,-1729.374;Inherit;False;0;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenPosInputsNode;1;-2302.337,-1503.908;Float;True;0;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TimeNode;94;-2360.293,-678.4664;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;107;-2334.476,-520.1198;Inherit;False;Property;_WavesSpeed;WavesSpeed;15;0;Create;True;0;0;False;0;False;0,0;0,-0.3;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;31;-2376.491,-832.7329;Inherit;False;Property;_MovementSpeed;MovementSpeed;4;0;Create;True;0;0;False;0;False;0;-0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;100;-2046.216,-780.0699;Inherit;False;Property;_WavesScale;WavesScale;14;0;Create;True;0;0;False;0;False;0,0;0.5,1.5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TimeNode;28;-2381.216,-989.1924;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;96;-2040.19,-649.2031;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;18;-1898.815,-1501.05;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;19;-1531.616,-1479.018;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;29;-2061.113,-923.929;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;32;-2065.545,-1008.877;Inherit;False;Property;_Scale;Scale;5;0;Create;True;0;0;False;0;False;1;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;98;-1677.072,-699.3336;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;99;-1356.03,-703.2697;Inherit;True;MovementWaves;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;30;-1697.995,-974.0596;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;83;-364.0587,-538.4857;Inherit;False;Property;_WaveSpeed;WaveSpeed;10;0;Create;True;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;84;-399.8587,-682.2858;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;21;-1291.099,-1479.018;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;34;-1074.381,-1457.865;Inherit;True;DepthFade;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;82;-124.9957,-476.4642;Inherit;False;Property;_WaveScale;WaveScale;11;0;Create;True;0;0;False;0;False;0;40;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;81;-109.9988,-759.1941;Inherit;False;99;MovementWaves;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;33;-1376.953,-977.9956;Inherit;True;MovementNormal;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;85;-82.1587,-625.5858;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;20;-3132.271,93.35143;Inherit;False;Property;_Distance;Distance;0;0;Create;True;0;0;False;0;False;0;1.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;49;-2866.162,118.9783;Inherit;False;34;DepthFade;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;23;-581.7491,489.3047;Inherit;False;Property;_WaterDepth;WaterDepth;1;0;Create;True;0;0;False;0;False;0;6.9;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;90;155.738,-971.9819;Inherit;True;2;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;10;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.RangedFloatNode;64;-2773.094,744.4312;Inherit;False;Property;_ScaleFoam;ScaleFoam;9;0;Create;True;0;0;False;0;False;0;50;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;75;161.6875,-738.395;Inherit;False;2;0;1;3;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;10;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.GetLocalVarNode;35;-2847.483,652.035;Inherit;False;33;MovementNormal;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DepthFade;67;-2883.839,-17.47556;Inherit;False;True;False;True;2;1;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;51;-2845.913,214.6857;Inherit;False;Property;_FoamCutoff;FoamCutoff;7;0;Create;True;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;50;-2494.861,158.4571;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;92;398.4737,-918.8561;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;71;-384.217,477.3155;Inherit;False;WaterDepth;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;77;384.4242,-797.3549;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;37;-2557.441,654.0917;Inherit;True;Gradient;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;20;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;26;-85.2556,-59.19059;Inherit;False;Property;_Surface;Surface;3;1;[HDR];Create;True;0;0;False;0;False;0,0,0,0;0,0.5003328,0.6509434,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DepthFade;24;-119.4162,351.0277;Inherit;False;True;False;True;2;1;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;87;929.3078,-689.7717;Inherit;False;Property;_SmoothStepWaves;SmoothStepWaves;12;0;Create;True;0;0;False;0;False;0,1;0.04,0.06;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.FunctionNode;38;-2263.575,662.1403;Inherit;True;Normal From Height;-1;;1;1942fe2c5f1a1f94881a33d532e4afeb;0;1;20;FLOAT;0;False;2;FLOAT3;40;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;88;608.7521,-986.0427;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StepOpNode;54;-2216.156,304.8537;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;40;-2067.702,899.0491;Inherit;False;Property;_RefractionStrength;RefractionStrength;6;0;Create;True;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;56;-2280.912,-13.85786;Inherit;False;Property;_FoamColor;FoamColor;8;1;[HDR];Create;True;0;0;False;0;False;0,0,0,0.3882353;0.1249555,0.5333043,0.6792453,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;27;-88.64224,125.3831;Inherit;False;Property;_Depths;Depths;2;1;[HDR];Create;True;0;0;False;0;False;0,0,0,0;0,0.1056603,0.3962264,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;39;-1737.729,768.6216;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SmoothstepOpNode;80;945.27,-820.9938;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0.5;False;2;FLOAT;0.6;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;55;-1867.585,300.0309;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenPosInputsNode;42;-1758.539,556.9152;Float;False;0;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;25;243.9387,128.4645;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;89;636.1986,-700.6887;Inherit;False;Property;_CausticsColor;CausticsColor;13;1;[HDR];Create;True;0;0;False;0;False;1,1,1,1;0.2830189,0.2830189,0.2830189,0.1490196;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;74;976.4073,-523.077;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;62;-1989.046,-9.628838;Inherit;False;FoamColor;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ClampOpNode;115;411.4972,173.9321;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,1,1,1;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;58;-1644.228,289.8745;Inherit;False;FoamAlpha;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;41;-1449.782,750.6624;Inherit;True;2;2;0;FLOAT4;0,0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.GetLocalVarNode;59;293.3848,524.8758;Inherit;False;58;FoamAlpha;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenColorNode;43;-1178.803,743.4363;Inherit;False;Global;_GrabScreen0;Grab Screen 0;7;0;Create;True;0;0;False;0;False;Object;-1;False;False;1;0;FLOAT2;0,0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;63;294.1795,434.6692;Inherit;False;62;FoamColor;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;93;565.3182,179.8441;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;57;629.8159,366.0728;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;45;-922.7286,747.4343;Inherit;True;NormalToSceneColor;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;36;698.2927,113.8671;Inherit;False;45;NormalToSceneColor;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.BreakToComponentsNode;48;943.9664,402.8386;Inherit;True;COLOR;1;0;COLOR;0,0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.LerpOp;44;1296.784,162.4683;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;1670.955,131.4602;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;SH_Water;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;5;True;True;0;False;Transparent;;Transparent;ForwardOnly;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;5;True;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.3;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;2;0;3;0
WireConnection;96;0;94;1
WireConnection;96;1;107;0
WireConnection;18;0;2;0
WireConnection;18;1;1;4
WireConnection;19;0;18;0
WireConnection;29;0;28;1
WireConnection;29;1;31;0
WireConnection;98;0;100;0
WireConnection;98;1;96;0
WireConnection;99;0;98;0
WireConnection;30;0;32;0
WireConnection;30;1;29;0
WireConnection;21;0;19;0
WireConnection;34;0;21;0
WireConnection;33;0;30;0
WireConnection;85;0;84;2
WireConnection;85;1;83;0
WireConnection;90;0;81;0
WireConnection;90;1;85;0
WireConnection;90;2;82;0
WireConnection;75;0;81;0
WireConnection;75;1;85;0
WireConnection;75;2;82;0
WireConnection;67;0;20;0
WireConnection;50;0;67;0
WireConnection;50;1;51;0
WireConnection;50;2;49;0
WireConnection;92;0;90;0
WireConnection;71;0;23;0
WireConnection;77;0;75;0
WireConnection;37;0;35;0
WireConnection;37;1;64;0
WireConnection;24;0;71;0
WireConnection;38;20;37;0
WireConnection;88;0;92;0
WireConnection;88;1;77;0
WireConnection;54;0;50;0
WireConnection;54;1;37;0
WireConnection;39;0;38;40
WireConnection;39;1;40;0
WireConnection;80;0;88;0
WireConnection;80;1;87;1
WireConnection;80;2;87;2
WireConnection;55;0;56;4
WireConnection;55;1;54;0
WireConnection;25;0;26;0
WireConnection;25;1;27;0
WireConnection;25;2;24;0
WireConnection;74;0;80;0
WireConnection;74;1;89;0
WireConnection;62;0;56;0
WireConnection;115;0;25;0
WireConnection;58;0;55;0
WireConnection;41;0;42;0
WireConnection;41;1;39;0
WireConnection;43;0;41;0
WireConnection;93;0;74;0
WireConnection;93;1;115;0
WireConnection;57;0;93;0
WireConnection;57;1;63;0
WireConnection;57;2;59;0
WireConnection;45;0;43;0
WireConnection;48;0;57;0
WireConnection;44;0;36;0
WireConnection;44;1;57;0
WireConnection;44;2;48;3
WireConnection;0;0;44;0
ASEEND*/
//CHKSM=E863954CC00B22DF4C1C9C59A86A0CF85D3CAFB5