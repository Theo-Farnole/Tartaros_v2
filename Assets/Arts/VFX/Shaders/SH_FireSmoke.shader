// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_FireSmoke"
{
	Properties
	{
		_Offset("Offset", Range( 0 , 1)) = 0
		_Contrast("Contrast", Range( 0 , 1)) = 0
		_Brightness("Brightness", Float) = 0
		_PaternSmoothStep("PaternSmoothStep", Vector) = (0,0.1,0,0)
		_PaternScale("PaternScale", Float) = 5
		_PaternMultiply("PaternMultiply", Float) = 2
		_PaternAngle("PaternAngle", Float) = 1
		_PaternSpeed1("PaternSpeed", Float) = 0.1
		_EmPower("EmPower", Float) = 2
		_Alpha0("Alpha0", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGINCLUDE
		#include "UnityShaderVariables.cginc"
		#include "UnityCG.cginc"
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 3.0
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
			float2 uv_texcoord;
			float3 worldPos;
			float3 worldNormal;
			INTERNAL_DATA
			float4 vertexColor : COLOR;
		};

		uniform float _EmPower;
		uniform float _Contrast;
		uniform float _PaternScale;
		uniform float _PaternAngle;
		uniform float _PaternSpeed1;
		uniform float2 _PaternSmoothStep;
		uniform float _Offset;
		uniform float _PaternMultiply;
		uniform float _Alpha0;
		uniform float _Brightness;


		float2 voronoihash315( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi315( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
		{
			float2 n = floor( v );
			float2 f = frac( v );
			float F1 = 8.0;
			float F2 = 8.0; float2 mg = 0;
			for ( int j = -1; j <= 1; j++ )
			{
				for ( int i = -1; i <= 1; i++ )
			 	{
			 		float2 g = float2( i, j );
			 		float2 o = voronoihash315( n + g );
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


		float2 voronoihash317( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi317( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
		{
			float2 n = floor( v );
			float2 f = frac( v );
			float F1 = 8.0;
			float F2 = 8.0; float2 mg = 0;
			for ( int j = -1; j <= 1; j++ )
			{
				for ( int i = -1; i <= 1; i++ )
			 	{
			 		float2 g = float2( i, j );
			 		float2 o = voronoihash317( n + g );
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
			
F1 = 8.0;
for ( int j = -2; j <= 2; j++ )
{
for ( int i = -2; i <= 2; i++ )
{
float2 g = mg + float2( i, j );
float2 o = voronoihash317( n + g );
		o = ( sin( time + o * 6.2831 ) * 0.5 + 0.5 ); float2 r = f - g - o;
float d = dot( 0.5 * ( r + mr ), normalize( r - mr ) );
F1 = min( F1, d );
}
}
return F1;
		}


		float2 voronoihash142( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi142( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
		{
			float2 n = floor( v );
			float2 f = frac( v );
			float F1 = 8.0;
			float F2 = 8.0; float2 mg = 0;
			for ( int j = -1; j <= 1; j++ )
			{
				for ( int i = -1; i <= 1; i++ )
			 	{
			 		float2 g = float2( i, j );
			 		float2 o = voronoihash142( n + g );
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
			for ( int j = -1; j <= 1; j++ )
			{
				for ( int i = -1; i <= 1; i++ )
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


		float2 voronoihash209( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi209( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
		{
			float2 n = floor( v );
			float2 f = frac( v );
			float F1 = 8.0;
			float F2 = 8.0; float2 mg = 0;
			for ( int j = -1; j <= 1; j++ )
			{
				for ( int i = -1; i <= 1; i++ )
			 	{
			 		float2 g = float2( i, j );
			 		float2 o = voronoihash209( n + g );
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


		float2 voronoihash229( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi229( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
		{
			float2 n = floor( v );
			float2 f = frac( v );
			float F1 = 8.0;
			float F2 = 8.0; float2 mg = 0;
			for ( int j = -1; j <= 1; j++ )
			{
				for ( int i = -1; i <= 1; i++ )
			 	{
			 		float2 g = float2( i, j );
			 		float2 o = voronoihash229( n + g );
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


		float2 voronoihash249( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi249( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
		{
			float2 n = floor( v );
			float2 f = frac( v );
			float F1 = 8.0;
			float F2 = 8.0; float2 mg = 0;
			for ( int j = -1; j <= 1; j++ )
			{
				for ( int i = -1; i <= 1; i++ )
			 	{
			 		float2 g = float2( i, j );
			 		float2 o = voronoihash249( n + g );
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


		float2 voronoihash269( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi269( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
		{
			float2 n = floor( v );
			float2 f = frac( v );
			float F1 = 8.0;
			float F2 = 8.0; float2 mg = 0;
			for ( int j = -1; j <= 1; j++ )
			{
				for ( int i = -1; i <= 1; i++ )
			 	{
			 		float2 g = float2( i, j );
			 		float2 o = voronoihash269( n + g );
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


		void surf( Input i , inout SurfaceOutputStandard o )
		{
			o.Normal = float3(0,0,1);
			float temp_output_342_0 = ( _Time.y * _PaternAngle );
			float time315 = temp_output_342_0;
			float2 temp_cast_0 = (( _Time.y * _PaternSpeed1 )).xx;
			float2 uv_TexCoord322 = i.uv_texcoord + temp_cast_0;
			float2 coords315 = uv_TexCoord322 * _PaternScale;
			float2 id315 = 0;
			float2 uv315 = 0;
			float voroi315 = voronoi315( coords315, time315, id315, uv315, 0 );
			float2 uv_TexCoord336 = i.uv_texcoord + float2( -0.5,-0.5 );
			float temp_output_340_0 = ( 1.0 - ( 2.63 * length( uv_TexCoord336 ) ) );
			float time317 = temp_output_342_0;
			float2 coords317 = uv_TexCoord322 * _PaternScale;
			float2 id317 = 0;
			float2 uv317 = 0;
			float fade317 = 0.5;
			float voroi317 = 0;
			float rest317 = 0;
			for( int it317 = 0; it317 <8; it317++ ){
			voroi317 += fade317 * voronoi317( coords317, time317, id317, uv317, 0 );
			rest317 += fade317;
			coords317 *= 2;
			fade317 *= 0.5;
			}//Voronoi317
			voroi317 /= rest317;
			float time142 = 0.0;
			float2 coords142 = i.uv_texcoord * 1.0;
			float2 id142 = 0;
			float2 uv142 = 0;
			float voroi142 = voronoi142( coords142, time142, id142, uv142, 0 );
			float smoothstepResult144 = smoothstep( _PaternSmoothStep.x , _PaternSmoothStep.y , voroi142);
			float Patern146 = ( ( step( voroi315 , temp_output_340_0 ) * step( voroi317 , temp_output_340_0 ) ) * ( ( 1.0 - smoothstepResult144 ) * 2.0 ) );
			float time152 = 0.0;
			float3 ase_worldPos = i.worldPos;
			#if defined(LIGHTMAP_ON) && UNITY_VERSION < 560 //aseld
			float3 ase_worldlightDir = 0;
			#else //aseld
			float3 ase_worldlightDir = normalize( UnityWorldSpaceLightDir( ase_worldPos ) );
			#endif //aseld
			float3 ase_worldNormal = WorldNormalVector( i, float3( 0, 0, 1 ) );
			float3 ase_worldTangent = WorldNormalVector( i, float3( 1, 0, 0 ) );
			float3 ase_worldBitangent = WorldNormalVector( i, float3( 0, 1, 0 ) );
			float3x3 ase_worldToTangent = float3x3( ase_worldTangent, ase_worldBitangent, ase_worldNormal );
			float3 LightDir122 = mul( ase_worldlightDir, ase_worldToTangent );
			float Offset165 = _Offset;
			float temp_output_166_0 = ( Offset165 * 0.5 );
			float2 coords152 = ( float3( i.uv_texcoord ,  0.0 ) + ( LightDir122 * temp_output_166_0 ) ).xy * 1.0;
			float2 id152 = 0;
			float2 uv152 = 0;
			float voroi152 = voronoi152( coords152, time152, id152, uv152, 0 );
			float smoothstepResult155 = smoothstep( 0.0 , 0.1 , voroi152);
			float PaternMult325 = _PaternMultiply;
			float lerpResult194 = lerp( Patern146 , ( 1.0 - ( ( Patern146 - ( ( 1.0 - smoothstepResult155 ) * PaternMult325 ) ) + 0.5 ) ) , 0.5);
			float Albedo1196 = saturate( lerpResult194 );
			float time209 = 0.0;
			float temp_output_202_0 = ( temp_output_166_0 * 0.5 );
			float2 coords209 = ( float3( i.uv_texcoord ,  0.0 ) + ( LightDir122 * temp_output_202_0 ) ).xy * 1.0;
			float2 id209 = 0;
			float2 uv209 = 0;
			float voroi209 = voronoi209( coords209, time209, id209, uv209, 0 );
			float smoothstepResult210 = smoothstep( 0.0 , 0.1 , voroi209);
			float lerpResult217 = lerp( Patern146 , ( 1.0 - ( ( Patern146 - ( ( 1.0 - smoothstepResult210 ) * PaternMult325 ) ) + 0.5 ) ) , 0.5);
			float Albedo2220 = saturate( lerpResult217 );
			float lerpResult283 = lerp( Albedo1196 , Albedo2220 , _Alpha0);
			float time229 = 0.0;
			float temp_output_222_0 = ( temp_output_202_0 * 0.5 );
			float2 coords229 = ( float3( i.uv_texcoord ,  0.0 ) + ( LightDir122 * temp_output_222_0 ) ).xy * 1.0;
			float2 id229 = 0;
			float2 uv229 = 0;
			float voroi229 = voronoi229( coords229, time229, id229, uv229, 0 );
			float smoothstepResult230 = smoothstep( 0.0 , 0.1 , voroi229);
			float lerpResult237 = lerp( Patern146 , ( 1.0 - ( ( Patern146 - ( ( 1.0 - smoothstepResult230 ) * PaternMult325 ) ) + 0.5 ) ) , 0.5);
			float Albedo3240 = saturate( lerpResult237 );
			float lerpResult281 = lerp( lerpResult283 , Albedo3240 , _Alpha0);
			float time249 = 0.0;
			float temp_output_242_0 = ( temp_output_222_0 * 0.5 );
			float2 coords249 = ( float3( i.uv_texcoord ,  0.0 ) + ( LightDir122 * temp_output_242_0 ) ).xy * 1.0;
			float2 id249 = 0;
			float2 uv249 = 0;
			float voroi249 = voronoi249( coords249, time249, id249, uv249, 0 );
			float smoothstepResult250 = smoothstep( 0.0 , 0.1 , voroi249);
			float lerpResult257 = lerp( Patern146 , ( 1.0 - ( ( Patern146 - ( ( 1.0 - smoothstepResult250 ) * PaternMult325 ) ) + 0.5 ) ) , 0.5);
			float Albedo4260 = saturate( lerpResult257 );
			float lerpResult284 = lerp( lerpResult281 , Albedo4260 , _Alpha0);
			float time269 = 0.0;
			float2 coords269 = ( float3( i.uv_texcoord ,  0.0 ) + ( LightDir122 * ( temp_output_242_0 * 0.5 ) ) ).xy * 1.0;
			float2 id269 = 0;
			float2 uv269 = 0;
			float voroi269 = voronoi269( coords269, time269, id269, uv269, 0 );
			float smoothstepResult270 = smoothstep( 0.0 , 0.1 , voroi269);
			float lerpResult277 = lerp( Patern146 , ( 1.0 - ( ( Patern146 - ( ( 1.0 - smoothstepResult270 ) * PaternMult325 ) ) + 0.5 ) ) , 0.5);
			float Albedo5280 = saturate( lerpResult277 );
			float lerpResult282 = lerp( lerpResult284 , Albedo5280 , _Alpha0);
			float Albedo185 = lerpResult282;
			#if defined(LIGHTMAP_ON) && ( UNITY_VERSION < 560 || ( defined(LIGHTMAP_SHADOW_MIXING) && !defined(SHADOWS_SHADOWMASK) && defined(SHADOWS_SCREEN) ) )//aselc
			float4 ase_lightColor = 0;
			#else //aselc
			float4 ase_lightColor = _LightColor0;
			#endif //aselc
			float4 Contrasted297 = ( float4( ( ( ( 1.0 - ( _Contrast * Albedo185 ) ) * _Brightness ) + ( ase_lightColor.rgb * ( ase_lightColor.a * 0.1 ) ) ) , 0.0 ) * i.vertexColor );
			o.Emission = ( _EmPower * Contrasted297 ).rgb;
			float Alpha306 = ( i.vertexColor.a * Patern146 );
			o.Alpha = Alpha306;
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf Standard alpha:fade keepalpha fullforwardshadows 

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
				float4 tSpace0 : TEXCOORD2;
				float4 tSpace1 : TEXCOORD3;
				float4 tSpace2 : TEXCOORD4;
				half4 color : COLOR0;
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
				o.color = v.color;
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
				surfIN.vertexColor = IN.color;
				SurfaceOutputStandard o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputStandard, o )
				surf( surfIN, o );
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
249;73;1146;655;2306.244;256.5211;1.3;True;False
Node;AmplifyShaderEditor.CommentaryNode;200;-2351.523,-3878.108;Inherit;False;3769.276;519.2332;Comment;21;166;149;126;165;124;125;127;152;155;153;154;190;191;192;193;194;195;197;196;324;325;Patern1;1,1,1,1;0;0
Node;AmplifyShaderEditor.WorldSpaceLightDirHlpNode;119;-4471.533,-1487.517;Inherit;False;False;1;0;FLOAT;0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;126;-2301.523,-3554.574;Inherit;False;Property;_Offset;Offset;2;0;Create;True;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldToTangentMatrix;121;-4475.018,-1284.369;Inherit;False;0;1;FLOAT3x3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;120;-4167.447,-1403.111;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3x3;0,0,0,1,1,1,1,0,1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;165;-2010.595,-3552.206;Inherit;False;Offset;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;336;-5328.266,-1983.893;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;-0.5,-0.5;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;344;-6300.498,-2129.199;Inherit;False;Property;_PaternSpeed1;PaternSpeed;10;0;Create;True;0;0;False;0;False;0.1;0.2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;323;-6314.687,-2372.556;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;166;-1774.677,-3491.874;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;201;-2335.596,-3131.636;Inherit;False;3769.276;519.2332;Comment;18;220;219;218;217;216;215;214;213;212;211;210;209;208;207;206;203;202;326;Patern2;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;343;-6008.203,-2174.167;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;337;-5061.939,-1981.526;Inherit;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;122;-3970.646,-1409.76;Inherit;False;LightDir;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;341;-6288.005,-2210.391;Inherit;False;Property;_PaternAngle;PaternAngle;9;0;Create;True;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;151;-4599.554,-1839.479;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;300;-4369.604,-1691.991;Inherit;False;Property;_PaternSmoothStep;PaternSmoothStep;5;0;Create;True;0;0;False;0;False;0,0.1;-0.02,0.04;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.GetLocalVarNode;124;-1871.477,-3670.117;Inherit;False;122;LightDir;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.VoronoiNode;142;-4342.262,-1838.099;Inherit;False;0;0;1;0;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;342;-6058.166,-2360.284;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;339;-4918.507,-2102.068;Inherit;False;2;2;0;FLOAT;2.63;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;322;-5819.999,-2582.733;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;206;-1855.55,-2923.646;Inherit;False;122;LightDir;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;301;-5712.433,-2211.794;Inherit;False;Property;_PaternScale;PaternScale;6;0;Create;True;0;0;False;0;False;5;1.57;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;202;-1758.75,-2745.403;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;221;-2342.667,-2367.93;Inherit;False;3769.276;519.2332;Comment;18;240;239;238;237;236;235;234;233;232;231;230;229;228;227;226;223;222;327;Patern3;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;125;-1641.138,-3622.374;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.OneMinusNode;340;-4836.468,-2169.263;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;144;-4127.078,-1843.742;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;207;-1625.211,-2875.903;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.VoronoiNode;317;-5321.562,-2326.75;Inherit;True;0;0;1;4;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;5;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.GetLocalVarNode;226;-1862.62,-2159.94;Inherit;False;122;LightDir;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.CommentaryNode;241;-2305.392,-1644.878;Inherit;False;3769.276;519.2332;Comment;18;260;259;258;257;256;255;254;253;252;251;250;249;248;247;246;243;242;328;Patern4;1,1,1,1;0;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;203;-1782.562,-3081.636;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VoronoiNode;315;-5330.418,-2598.533;Inherit;True;0;0;1;0;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;5;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;222;-1765.82,-1981.698;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;149;-1798.488,-3828.108;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.CommentaryNode;261;-2291.158,-919.0053;Inherit;False;3769.276;519.2332;Comment;18;280;279;278;277;276;275;274;273;272;271;270;269;268;267;266;263;262;329;Patern5;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;242;-1728.546,-1258.646;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.StepOpNode;332;-4620.916,-2264.527;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;208;-1355.67,-2899.385;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;227;-1632.281,-2112.197;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.OneMinusNode;143;-3818.112,-1823.608;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;223;-1789.631,-2317.93;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StepOpNode;330;-4543.414,-2493.355;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;127;-1371.597,-3645.856;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;246;-1825.346,-1436.888;Inherit;False;122;LightDir;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleAddOpNode;228;-1362.74,-2135.679;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;335;-4217.215,-2495.916;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;262;-1714.31,-532.7723;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;324;-875.4995,-3795.741;Inherit;False;Property;_PaternMultiply;PaternMultiply;8;0;Create;True;0;0;False;0;False;2;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;152;-1147.682,-3648.561;Inherit;False;0;0;1;0;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;247;-1595.007,-1389.146;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;243;-1790.139,-1587.322;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VoronoiNode;209;-1131.755,-2902.09;Inherit;False;0;0;1;0;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;145;-3611.322,-1827.163;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;266;-1811.11,-711.0152;Inherit;False;122;LightDir;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;263;-1738.121,-869.0052;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;210;-916.5709,-2907.734;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;321;-3357.287,-1993.759;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;155;-932.4973,-3654.205;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.1;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;229;-1138.825,-2138.384;Inherit;False;0;0;1;0;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SimpleAddOpNode;248;-1325.466,-1412.627;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;325;-681.8281,-3797.403;Inherit;False;PaternMult;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;267;-1580.771,-663.2723;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;146;-3111.535,-1998.669;Inherit;False;Patern;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;153;-623.5314,-3634.07;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;268;-1311.23,-686.7542;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;326;-618.0872,-3032.94;Inherit;False;325;PaternMult;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;249;-1101.551,-1415.333;Inherit;False;0;0;1;0;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SmoothstepOpNode;230;-923.6409,-2144.028;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.1;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;211;-607.6049,-2887.599;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;269;-1087.315,-689.4593;Inherit;False;0;0;1;0;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.GetLocalVarNode;197;-331.896,-3773.883;Inherit;False;146;Patern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;212;-400.8146,-2891.154;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;154;-416.7413,-3637.625;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;219;-316.9692,-3027.412;Inherit;False;146;Patern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;327;-641.0748,-2260.032;Inherit;False;325;PaternMult;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;231;-614.6749,-2123.893;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;250;-886.3667,-1420.976;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.1;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;328;-594.972,-1545.438;Inherit;False;325;PaternMult;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;190;-122.343,-3644.637;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;232;-407.8849,-2127.448;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;251;-577.4008,-1400.842;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;213;-106.4163,-2898.166;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;270;-872.1315,-695.1031;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.1;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;239;-324.0396,-2263.706;Inherit;False;146;Patern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;271;-563.1656,-674.9683;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;252;-370.6106,-1404.396;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;329;-588.6853,-797.3149;Inherit;False;325;PaternMult;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;191;191.7249,-3640.586;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;259;-286.7652,-1540.655;Inherit;False;146;Patern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;233;-113.4865,-2134.46;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;214;207.6516,-2894.115;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;253;-76.21219,-1411.408;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;215;496.3214,-2889.797;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;192;480.3947,-3636.268;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;216;622.1577,-2959.665;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;193;606.2311,-3706.136;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;272;-356.3757,-678.5233;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;279;-272.5303,-814.7813;Inherit;False;146;Patern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;234;200.5814,-2130.409;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;273;-61.97739,-685.5352;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;217;696.4213,-2937.497;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;235;489.251,-2126.091;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;194;680.4947,-3683.968;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;254;237.8557,-1407.357;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;236;615.0872,-2195.959;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;255;526.5254,-1403.04;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;195;943.8948,-3673.168;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;274;252.0906,-681.4842;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;218;959.8214,-2926.697;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;256;652.3617,-1472.907;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;237;689.3508,-2173.791;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;238;952.751,-2162.991;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;220;1190.681,-2931.099;Inherit;True;Albedo2;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;196;1174.754,-3677.57;Inherit;True;Albedo1;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;275;540.7606,-677.1663;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;257;726.6254,-1450.74;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;276;666.5969,-747.0342;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;277;740.8605,-724.8663;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;287;-1876.94,-59.9043;Inherit;False;220;Albedo2;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;258;990.0255,-1439.939;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;240;1183.611,-2167.393;Inherit;True;Albedo3;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;285;-1885.669,-167.0811;Inherit;False;196;Albedo1;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;348;-1836.731,385.3819;Inherit;False;Property;_Alpha0;Alpha0;12;0;Create;True;0;0;False;0;False;0;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;286;-1876.033,42.95316;Inherit;False;240;Albedo3;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;278;1004.261,-714.0662;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;260;1220.885,-1444.342;Inherit;True;Albedo4;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;283;-1488.345,-159.9161;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;280;1235.121,-718.4683;Inherit;True;Albedo5;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;281;-1484.771,-29.56247;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;288;-1880.69,146.7965;Inherit;False;260;Albedo4;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;284;-1477.807,110.8389;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;289;-1870.745,278.5089;Inherit;False;280;Albedo5;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;282;-1480.45,251.814;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;185;-1213.459,245.9742;Inherit;True;Albedo;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;291;-1754.602,702.2539;Inherit;False;185;Albedo;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;290;-1856.848,593.3399;Inherit;False;Property;_Contrast;Contrast;3;0;Create;True;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;311;-1347.501,1183.146;Inherit;False;Constant;_LightInfluence;LightInfluence;7;0;Create;True;0;0;False;0;False;0.1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;345;-1340.974,524.2319;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LightColorNode;309;-1471.92,986.8809;Inherit;True;0;3;COLOR;0;FLOAT3;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;295;-1161.931,786.4698;Inherit;False;Property;_Brightness;Brightness;4;0;Create;True;0;0;False;0;False;0;3;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;310;-1119.357,1070.406;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;293;-1169.461,676.9954;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;312;-938.8124,998.5411;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;294;-921.7027,727.1367;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;308;-324.4769,900.6047;Inherit;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;313;-557.8958,800.7015;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.VertexColorNode;302;-652.3303,-34.20877;Inherit;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;303;-651.1691,178.389;Inherit;True;146;Patern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;307;-30.48038,707.1512;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;304;-403.8887,107.0872;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;297;405.3263,693.8564;Inherit;False;Contrasted;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;199;64.48087,-111.6861;Inherit;True;297;Contrasted;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.CommentaryNode;305;-4410.34,-942.9617;Inherit;False;1448.008;1175.783;Comment;14;94;96;84;86;95;34;42;87;85;45;40;41;89;33;NOPE;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;347;85.81299,-221.4929;Inherit;False;Property;_EmPower;EmPower;11;0;Create;True;0;0;False;0;False;2;0.81;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;306;-123.5753,123.6082;Inherit;True;Alpha;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;96;-3155.332,-548.8635;Inherit;False;Property;_PaternStep;PaternStep;1;0;Create;True;0;0;False;0;False;0;-1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;296;166.558,832.7945;Inherit;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SmoothstepOpNode;94;-3244.51,-803.4586;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;95;-3497.288,-557.1368;Inherit;False;Constant;_Color4;Color 4;11;0;Create;True;0;0;False;0;False;1,1,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;87;-4148.62,71.82164;Inherit;False;Property;_UV_speed;UV_speed;0;0;Create;True;0;0;False;0;False;1,0;0.35,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.FunctionNode;40;-4066.186,-849.9737;Inherit;False;Radial Shear;-1;;5;c6dc9fc7fa9b08c4d95138f2ae88b526;0;4;1;FLOAT2;0,0;False;2;FLOAT2;0,0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;42;-4360.34,-661.8503;Inherit;False;Constant;_Vector4;Vector 4;3;0;Create;True;0;0;False;0;False;-0.5,-0.5;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.LengthOpNode;34;-3766.453,-847.8322;Inherit;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;41;-4352.28,-782.3263;Inherit;False;Constant;_Vector3;Vector 3;3;0;Create;True;0;0;False;0;False;0.5,0.5;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;338;-4078.333,-2187.166;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;346;408.813,-157.4929;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;314;-2961.44,-1856.916;Inherit;True;Property;_TextureSample0;Texture Sample 0;7;0;Create;True;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;86;-3918.135,-11.80408;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.OneMinusNode;45;-3580.721,-846.2964;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode;33;-4350.953,-892.9617;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TexCoordVertexDataNode;84;-4002.148,-263.2493;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TimeNode;85;-4189.322,-89.45642;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;292;-1457.39,647.0408;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;89;-3662.48,-130.0746;Inherit;True;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;299;342.5322,141.9599;Inherit;False;306;Alpha;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;107;647.999,-68.38998;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Tartaros/SH_FireSmoke;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;-0.16;True;True;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;120;0;119;0
WireConnection;120;1;121;0
WireConnection;165;0;126;0
WireConnection;166;0;165;0
WireConnection;343;0;323;2
WireConnection;343;1;344;0
WireConnection;337;0;336;0
WireConnection;122;0;120;0
WireConnection;142;0;151;0
WireConnection;342;0;323;2
WireConnection;342;1;341;0
WireConnection;339;1;337;0
WireConnection;322;1;343;0
WireConnection;202;0;166;0
WireConnection;125;0;124;0
WireConnection;125;1;166;0
WireConnection;340;0;339;0
WireConnection;144;0;142;0
WireConnection;144;1;300;1
WireConnection;144;2;300;2
WireConnection;207;0;206;0
WireConnection;207;1;202;0
WireConnection;317;0;322;0
WireConnection;317;1;342;0
WireConnection;317;2;301;0
WireConnection;315;0;322;0
WireConnection;315;1;342;0
WireConnection;315;2;301;0
WireConnection;222;0;202;0
WireConnection;242;0;222;0
WireConnection;332;0;317;0
WireConnection;332;1;340;0
WireConnection;208;0;203;0
WireConnection;208;1;207;0
WireConnection;227;0;226;0
WireConnection;227;1;222;0
WireConnection;143;0;144;0
WireConnection;330;0;315;0
WireConnection;330;1;340;0
WireConnection;127;0;149;0
WireConnection;127;1;125;0
WireConnection;228;0;223;0
WireConnection;228;1;227;0
WireConnection;335;0;330;0
WireConnection;335;1;332;0
WireConnection;262;0;242;0
WireConnection;152;0;127;0
WireConnection;247;0;246;0
WireConnection;247;1;242;0
WireConnection;209;0;208;0
WireConnection;145;0;143;0
WireConnection;210;0;209;0
WireConnection;321;0;335;0
WireConnection;321;1;145;0
WireConnection;155;0;152;0
WireConnection;229;0;228;0
WireConnection;248;0;243;0
WireConnection;248;1;247;0
WireConnection;325;0;324;0
WireConnection;267;0;266;0
WireConnection;267;1;262;0
WireConnection;146;0;321;0
WireConnection;153;0;155;0
WireConnection;268;0;263;0
WireConnection;268;1;267;0
WireConnection;249;0;248;0
WireConnection;230;0;229;0
WireConnection;211;0;210;0
WireConnection;269;0;268;0
WireConnection;212;0;211;0
WireConnection;212;1;326;0
WireConnection;154;0;153;0
WireConnection;154;1;325;0
WireConnection;231;0;230;0
WireConnection;250;0;249;0
WireConnection;190;0;197;0
WireConnection;190;1;154;0
WireConnection;232;0;231;0
WireConnection;232;1;327;0
WireConnection;251;0;250;0
WireConnection;213;0;219;0
WireConnection;213;1;212;0
WireConnection;270;0;269;0
WireConnection;271;0;270;0
WireConnection;252;0;251;0
WireConnection;252;1;328;0
WireConnection;191;0;190;0
WireConnection;233;0;239;0
WireConnection;233;1;232;0
WireConnection;214;0;213;0
WireConnection;253;0;259;0
WireConnection;253;1;252;0
WireConnection;215;0;214;0
WireConnection;192;0;191;0
WireConnection;216;0;219;0
WireConnection;193;0;197;0
WireConnection;272;0;271;0
WireConnection;272;1;329;0
WireConnection;234;0;233;0
WireConnection;273;0;279;0
WireConnection;273;1;272;0
WireConnection;217;0;216;0
WireConnection;217;1;215;0
WireConnection;235;0;234;0
WireConnection;194;0;193;0
WireConnection;194;1;192;0
WireConnection;254;0;253;0
WireConnection;236;0;239;0
WireConnection;255;0;254;0
WireConnection;195;0;194;0
WireConnection;274;0;273;0
WireConnection;218;0;217;0
WireConnection;256;0;259;0
WireConnection;237;0;236;0
WireConnection;237;1;235;0
WireConnection;238;0;237;0
WireConnection;220;0;218;0
WireConnection;196;0;195;0
WireConnection;275;0;274;0
WireConnection;257;0;256;0
WireConnection;257;1;255;0
WireConnection;276;0;279;0
WireConnection;277;0;276;0
WireConnection;277;1;275;0
WireConnection;258;0;257;0
WireConnection;240;0;238;0
WireConnection;278;0;277;0
WireConnection;260;0;258;0
WireConnection;283;0;285;0
WireConnection;283;1;287;0
WireConnection;283;2;348;0
WireConnection;280;0;278;0
WireConnection;281;0;283;0
WireConnection;281;1;286;0
WireConnection;281;2;348;0
WireConnection;284;0;281;0
WireConnection;284;1;288;0
WireConnection;284;2;348;0
WireConnection;282;0;284;0
WireConnection;282;1;289;0
WireConnection;282;2;348;0
WireConnection;185;0;282;0
WireConnection;345;0;290;0
WireConnection;345;1;291;0
WireConnection;310;0;309;2
WireConnection;310;1;311;0
WireConnection;293;0;345;0
WireConnection;312;0;309;1
WireConnection;312;1;310;0
WireConnection;294;0;293;0
WireConnection;294;1;295;0
WireConnection;313;0;294;0
WireConnection;313;1;312;0
WireConnection;307;0;313;0
WireConnection;307;1;308;0
WireConnection;304;0;302;4
WireConnection;304;1;303;0
WireConnection;297;0;307;0
WireConnection;306;0;304;0
WireConnection;94;0;45;0
WireConnection;94;1;96;0
WireConnection;94;2;95;0
WireConnection;40;1;33;0
WireConnection;40;2;41;0
WireConnection;40;4;42;0
WireConnection;34;0;40;0
WireConnection;346;0;347;0
WireConnection;346;1;199;0
WireConnection;86;0;85;2
WireConnection;86;1;87;0
WireConnection;45;0;34;0
WireConnection;292;0;290;0
WireConnection;89;0;84;0
WireConnection;89;1;86;0
WireConnection;107;2;346;0
WireConnection;107;9;299;0
ASEEND*/
//CHKSM=9FD0E5B926F1C442B4DDA38A6EA6C7F8BC24EFCC