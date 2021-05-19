// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_FireSmoke2"
{
	Properties
	{
		_Offset("Offset", Range( 0 , 1)) = 0
		_Contrast("Contrast", Range( 0 , 1)) = 0
		_Brightness("Brightness", Float) = 0
		_PaternSmoothStep("PaternSmoothStep", Vector) = (0,0.1,0,0)
		_PaternMultiply("PaternMultiply", Float) = 2
		_PaternAngle("PaternAngle", Float) = 1
		_PaternSpeed("PaternSpeed", Float) = 0.1
		_PaternScale("PaternScale", Vector) = (5,5,0,0)
		_EmPower("EmPower", Float) = 2
		_InverseLength("InverseLength", Float) = 0
		_SmoothSteps("SmoothSteps", Vector) = (0,0.5,0,0.5)
		_Tiling("Tiling", Float) = 2.15
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
		uniform float4 _SmoothSteps;
		uniform float2 _PaternScale;
		uniform float _PaternAngle;
		uniform float _PaternSpeed;
		uniform float _Tiling;
		uniform float _InverseLength;
		uniform float2 _PaternSmoothStep;
		uniform float _Offset;
		uniform float _PaternMultiply;
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


		void surf( Input i , inout SurfaceOutputStandard o )
		{
			o.Normal = float3(0,0,1);
			float temp_output_342_0 = ( _Time.y * _PaternAngle );
			float time315 = temp_output_342_0;
			float2 temp_cast_0 = (( _Time.y * _PaternSpeed )).xx;
			float2 uv_TexCoord322 = i.uv_texcoord + temp_cast_0;
			float2 coords315 = uv_TexCoord322 * _PaternScale.x;
			float2 id315 = 0;
			float2 uv315 = 0;
			float fade315 = 0.5;
			float voroi315 = 0;
			float rest315 = 0;
			for( int it315 = 0; it315 <8; it315++ ){
			voroi315 += fade315 * voronoi315( coords315, time315, id315, uv315, 0 );
			rest315 += fade315;
			coords315 *= 2;
			fade315 *= 0.5;
			}//Voronoi315
			voroi315 /= rest315;
			float smoothstepResult359 = smoothstep( _SmoothSteps.x , _SmoothSteps.y , voroi315);
			float2 temp_cast_1 = (_Tiling).xx;
			float2 temp_cast_2 = (( _Tiling / -2.0 )).xx;
			float2 uv_TexCoord336 = i.uv_texcoord * temp_cast_1 + temp_cast_2;
			float temp_output_337_0 = length( uv_TexCoord336 );
			float lerpResult357 = lerp( ( 1.0 - temp_output_337_0 ) , temp_output_337_0 , _InverseLength);
			float time317 = temp_output_342_0;
			float2 coords317 = uv_TexCoord322 * _PaternScale.y;
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
			float smoothstepResult360 = smoothstep( _SmoothSteps.z , _SmoothSteps.w , voroi317);
			float time142 = 0.0;
			float2 coords142 = i.uv_texcoord * 1.0;
			float2 id142 = 0;
			float2 uv142 = 0;
			float voroi142 = voronoi142( coords142, time142, id142, uv142, 0 );
			float smoothstepResult144 = smoothstep( _PaternSmoothStep.x , _PaternSmoothStep.y , voroi142);
			float Patern146 = ( ( step( smoothstepResult359 , lerpResult357 ) * step( smoothstepResult360 , lerpResult357 ) ) * ( ( 1.0 - smoothstepResult144 ) * 2.0 ) );
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
			float2 coords152 = ( float3( i.uv_texcoord ,  0.0 ) + ( LightDir122 * ( Offset165 * 0.5 ) ) ).xy * 1.0;
			float2 id152 = 0;
			float2 uv152 = 0;
			float voroi152 = voronoi152( coords152, time152, id152, uv152, 0 );
			float smoothstepResult155 = smoothstep( 0.0 , 0.1 , voroi152);
			float PaternMult325 = _PaternMultiply;
			float lerpResult194 = lerp( Patern146 , ( 1.0 - ( ( Patern146 - ( ( 1.0 - smoothstepResult155 ) * PaternMult325 ) ) + 0.5 ) ) , 0.5);
			float Albedo1196 = saturate( lerpResult194 );
			float Albedo185 = Albedo1196;
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
249;73;1146;655;6100.391;2777.406;1.480435;True;False
Node;AmplifyShaderEditor.RangedFloatNode;356;-6481.501,-1677.091;Inherit;False;Property;_Tiling;Tiling;12;0;Create;True;0;0;False;0;False;2.15;2.44;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;200;-1968.048,-1390.7;Inherit;False;3769.276;519.2332;Comment;21;166;149;126;165;124;125;127;152;155;153;154;190;191;192;193;194;195;197;196;324;325;Patern1;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;355;-6264.704,-1603.212;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;-2;False;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;323;-6860.778,-2315.273;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;344;-6846.588,-2071.916;Inherit;False;Property;_PaternSpeed;PaternSpeed;6;0;Create;True;0;0;False;0;False;0.1;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldSpaceLightDirHlpNode;119;-4593.736,-1514.249;Inherit;False;False;1;0;FLOAT;0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.WorldToTangentMatrix;121;-4597.221,-1311.101;Inherit;False;0;1;FLOAT3x3;0
Node;AmplifyShaderEditor.RangedFloatNode;126;-1919.771,-1067.166;Inherit;False;Property;_Offset;Offset;0;0;Create;True;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;343;-6554.293,-2116.884;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;120;-4289.65,-1429.843;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3x3;0,0,0,1,1,1,1,0,1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;336;-6082.234,-1697.551;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;-0.5,-0.5;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;341;-6834.095,-2153.108;Inherit;False;Property;_PaternAngle;PaternAngle;5;0;Create;True;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;342;-6604.256,-2303.001;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;322;-6366.089,-2525.45;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;122;-4092.848,-1436.492;Inherit;False;LightDir;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;151;-4777.875,-1872.446;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LengthOpNode;337;-5815.907,-1695.184;Inherit;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;165;-1627.12,-1064.798;Inherit;False;Offset;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;350;-6233.673,-2159.12;Inherit;False;Property;_PaternScale;PaternScale;7;0;Create;True;0;0;False;0;False;5,5;5,5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector4Node;361;-5367.384,-2400.627;Inherit;False;Property;_SmoothSteps;SmoothSteps;12;0;Create;True;0;0;False;0;False;0,0.5,0,0.5;0,0.5,-0.25,0.5;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;124;-1488.002,-1182.708;Inherit;False;122;LightDir;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;166;-1391.202,-1004.465;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;317;-5646.733,-2231.953;Inherit;True;0;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;5;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.VoronoiNode;315;-5655.588,-2503.736;Inherit;True;0;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;5;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.OneMinusNode;340;-5616.827,-1758.494;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;142;-4520.583,-1871.066;Inherit;False;0;0;1;0;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.RangedFloatNode;358;-5819.768,-1479.831;Inherit;False;Property;_InverseLength;InverseLength;11;0;Create;True;0;0;False;0;False;0;-0.03;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;300;-4591.573,-1718.723;Inherit;False;Property;_PaternSmoothStep;PaternSmoothStep;3;0;Create;True;0;0;False;0;False;0,0.1;-0.64,0.22;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SmoothstepOpNode;360;-5010.69,-2191.037;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.26;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;125;-1257.663,-1134.966;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;149;-1415.013,-1340.7;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;357;-5446.779,-1707.882;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;144;-4249.281,-1870.474;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;359;-5010.695,-2572.739;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.26;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;127;-988.1216,-1158.448;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.OneMinusNode;143;-3940.314,-1850.34;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StepOpNode;330;-4543.414,-2493.355;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StepOpNode;332;-4620.916,-2264.527;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;152;-764.2065,-1161.153;Inherit;False;0;0;1;0;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;335;-4217.215,-2495.916;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;145;-3733.524,-1853.895;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;321;-3357.287,-1993.759;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;155;-549.0217,-1166.797;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;324;-528.2186,-1311.952;Inherit;False;Property;_PaternMultiply;PaternMultiply;4;0;Create;True;0;0;False;0;False;2;0.79;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;153;-240.0558,-1146.662;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;146;-3111.535,-1998.669;Inherit;False;Patern;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;325;-298.3525,-1309.995;Inherit;False;PaternMult;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;197;40.3796,-1366.475;Inherit;True;146;Patern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;154;-33.26577,-1150.217;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;190;261.1326,-1157.229;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;191;575.2006,-1153.177;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;193;989.7062,-1218.728;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;192;863.87,-1148.86;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;194;1063.97,-1196.56;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;195;1327.37,-1185.76;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;196;1558.229,-1190.162;Inherit;True;Albedo1;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;185;1931.405,-1131.557;Inherit;True;Albedo;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;291;-1754.602,702.2539;Inherit;False;185;Albedo;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;290;-1856.848,593.3399;Inherit;False;Property;_Contrast;Contrast;1;0;Create;True;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;311;-1347.501,1183.146;Inherit;False;Constant;_LightInfluence;LightInfluence;7;0;Create;True;0;0;False;0;False;0.1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;345;-1340.974,524.2319;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LightColorNode;309;-1457.824,956.6749;Inherit;True;0;3;COLOR;0;FLOAT3;1;FLOAT;2
Node;AmplifyShaderEditor.OneMinusNode;293;-1169.461,676.9954;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;295;-1161.931,786.4698;Inherit;False;Property;_Brightness;Brightness;2;0;Create;True;0;0;False;0;False;0;3;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;310;-1119.357,1070.406;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;294;-921.7027,727.1367;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;312;-938.8124,998.5411;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.VertexColorNode;308;-324.4769,900.6047;Inherit;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;313;-557.8958,800.7015;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;303;-651.1691,178.389;Inherit;True;146;Patern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;302;-652.3303,-34.20877;Inherit;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;307;-30.48038,707.1512;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;297;407.34,693.8564;Inherit;False;Contrasted;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;304;-403.8887,107.0872;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;306;-123.5753,123.6082;Inherit;True;Alpha;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;347;85.81299,-221.4929;Inherit;False;Property;_EmPower;EmPower;9;0;Create;True;0;0;False;0;False;2;0.93;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;199;64.48087,-111.6861;Inherit;True;297;Contrasted;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SaturateNode;296;166.558,832.7945;Inherit;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;299;342.5322,141.9599;Inherit;False;306;Alpha;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector4Node;351;-6925.989,-1834.347;Inherit;False;Property;_TilingOffset;TilingOffset;8;0;Create;True;0;0;False;0;False;1,1,-0.5,-0.5;1,1,-0.5,-0.5;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;352;-6677.332,-1837.219;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;292;-1457.39,647.0408;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;346;408.813,-157.4929;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.DynamicAppendNode;353;-6682.531,-1733.22;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;107;647.999,-68.38998;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Tartaros/SH_FireSmoke2;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;-0.16;True;True;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;355;0;356;0
WireConnection;343;0;323;2
WireConnection;343;1;344;0
WireConnection;120;0;119;0
WireConnection;120;1;121;0
WireConnection;336;0;356;0
WireConnection;336;1;355;0
WireConnection;342;0;323;2
WireConnection;342;1;341;0
WireConnection;322;1;343;0
WireConnection;122;0;120;0
WireConnection;337;0;336;0
WireConnection;165;0;126;0
WireConnection;166;0;165;0
WireConnection;317;0;322;0
WireConnection;317;1;342;0
WireConnection;317;2;350;2
WireConnection;315;0;322;0
WireConnection;315;1;342;0
WireConnection;315;2;350;1
WireConnection;340;0;337;0
WireConnection;142;0;151;0
WireConnection;360;0;317;0
WireConnection;360;1;361;3
WireConnection;360;2;361;4
WireConnection;125;0;124;0
WireConnection;125;1;166;0
WireConnection;357;0;340;0
WireConnection;357;1;337;0
WireConnection;357;2;358;0
WireConnection;144;0;142;0
WireConnection;144;1;300;1
WireConnection;144;2;300;2
WireConnection;359;0;315;0
WireConnection;359;1;361;1
WireConnection;359;2;361;2
WireConnection;127;0;149;0
WireConnection;127;1;125;0
WireConnection;143;0;144;0
WireConnection;330;0;359;0
WireConnection;330;1;357;0
WireConnection;332;0;360;0
WireConnection;332;1;357;0
WireConnection;152;0;127;0
WireConnection;335;0;330;0
WireConnection;335;1;332;0
WireConnection;145;0;143;0
WireConnection;321;0;335;0
WireConnection;321;1;145;0
WireConnection;155;0;152;0
WireConnection;153;0;155;0
WireConnection;146;0;321;0
WireConnection;325;0;324;0
WireConnection;154;0;153;0
WireConnection;154;1;325;0
WireConnection;190;0;197;0
WireConnection;190;1;154;0
WireConnection;191;0;190;0
WireConnection;193;0;197;0
WireConnection;192;0;191;0
WireConnection;194;0;193;0
WireConnection;194;1;192;0
WireConnection;195;0;194;0
WireConnection;196;0;195;0
WireConnection;185;0;196;0
WireConnection;345;0;290;0
WireConnection;345;1;291;0
WireConnection;293;0;345;0
WireConnection;310;0;309;2
WireConnection;310;1;311;0
WireConnection;294;0;293;0
WireConnection;294;1;295;0
WireConnection;312;0;309;1
WireConnection;312;1;310;0
WireConnection;313;0;294;0
WireConnection;313;1;312;0
WireConnection;307;0;313;0
WireConnection;307;1;308;0
WireConnection;297;0;307;0
WireConnection;304;0;302;4
WireConnection;304;1;303;0
WireConnection;306;0;304;0
WireConnection;352;0;351;1
WireConnection;352;1;351;2
WireConnection;292;0;290;0
WireConnection;346;0;347;0
WireConnection;346;1;199;0
WireConnection;353;0;351;3
WireConnection;353;1;351;4
WireConnection;107;2;346;0
WireConnection;107;9;299;0
ASEEND*/
//CHKSM=02EE2AB8AD2E7CFF9A935FAEBF4CCCB029C64D32