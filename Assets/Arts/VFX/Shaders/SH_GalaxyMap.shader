// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_GalaxyMap"
{
	Properties
	{
		_VoroScale("VoroScale", Float) = 5
		_Voro2Scale("Voro2Scale", Float) = 5
		_Voro2Power("Voro2Power", Float) = 5
		_OpacityPower("OpacityPower", Float) = 5
		[HDR]_FresnelColor2("FresnelColor2", Color) = (2,2,2,1)
		_FresnelBSP("FresnelBSP", Vector) = (0,1,1,0)
		_Voro2AngleSpeed("Voro2AngleSpeed", Float) = 10
		_Voro2Speed("Voro2Speed", Vector) = (1,0,0,0)
		_Voro1Speed("Voro1Speed", Vector) = (1,0,0,0)
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_TextureStrength("TextureStrength", Float) = 10
		_StarScale("StarScale", Float) = 10
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGINCLUDE
		#include "UnityShaderVariables.cginc"
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 3.0
		struct Input
		{
			float2 uv_texcoord;
			float3 worldPos;
			float3 worldNormal;
		};

		uniform float _TextureStrength;
		uniform sampler2D _TextureSample0;
		uniform float2 _Voro1Speed;
		uniform float _StarScale;
		uniform float4 _FresnelColor2;
		uniform float3 _FresnelBSP;
		uniform float _Voro2Scale;
		uniform float _Voro2AngleSpeed;
		uniform float2 _Voro2Speed;
		uniform float _Voro2Power;
		uniform float _VoroScale;
		uniform float _OpacityPower;


		float2 voronoihash164( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi164( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash164( n + g );
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
float2 o = voronoihash164( n + g );
		o = ( sin( time + o * 6.2831 ) * 0.5 + 0.5 ); float2 r = f - g - o;
float d = dot( 0.5 * ( r + mr ), normalize( r - mr ) );
F1 = min( F1, d );
}
}
return F1;
		}


		float2 voronoihash39( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi39( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash39( n + g );
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
			float2 uv_TexCoord204 = i.uv_texcoord + ( _Voro1Speed * _Time.x );
			float3 ase_worldPos = i.worldPos;
			float3 ase_worldViewDir = normalize( UnityWorldSpaceViewDir( ase_worldPos ) );
			float3 ase_worldNormal = i.worldNormal;
			float fresnelNdotV176 = dot( ase_worldNormal, ase_worldViewDir );
			float fresnelNode176 = ( _FresnelBSP.x + _FresnelBSP.y * pow( 1.0 - fresnelNdotV176, _FresnelBSP.z ) );
			float time164 = ( _Time.x * _Voro2AngleSpeed );
			float2 uv_TexCoord173 = i.uv_texcoord + ( _Voro2Speed * _Time.x );
			float2 coords164 = uv_TexCoord173 * _Voro2Scale;
			float2 id164 = 0;
			float2 uv164 = 0;
			float voroi164 = voronoi164( coords164, time164, id164, uv164, 0 );
			o.Emission = ( float4( 0,0,0,0 ) + ( _TextureStrength * tex2D( _TextureSample0, ( ( 1.0 - uv_TexCoord204 ) * _StarScale ) ) ) + ( _FresnelColor2 * pow( ( fresnelNode176 * voroi164 ) , _Voro2Power ) ) ).rgb;
			float3 _FresneClBSP = float3(0,1,1);
			float fresnelNdotV53 = dot( ase_worldNormal, ase_worldViewDir );
			float fresnelNode53 = ( _FresneClBSP.x + _FresneClBSP.y * pow( 1.0 - fresnelNdotV53, _FresneClBSP.z ) );
			float time39 = _Time.y;
			float2 coords39 = i.uv_texcoord * _VoroScale;
			float2 id39 = 0;
			float2 uv39 = 0;
			float voroi39 = voronoi39( coords39, time39, id39, uv39, 0 );
			o.Alpha = pow( ( fresnelNode53 * voroi39 ) , _OpacityPower );
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
				float3 worldPos : TEXCOORD2;
				float3 worldNormal : TEXCOORD3;
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
				o.worldNormal = worldNormal;
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				o.worldPos = worldPos;
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
				float3 worldPos = IN.worldPos;
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				surfIN.worldPos = worldPos;
				surfIN.worldNormal = IN.worldNormal;
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
253;73;1321;655;3091.144;1215.012;1.35615;True;False
Node;AmplifyShaderEditor.Vector2Node;202;-4173.877,-820.0046;Inherit;False;Property;_Voro1Speed;Voro1Speed;11;0;Create;True;0;0;False;0;False;1,0;0.5,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TimeNode;201;-4206.897,-644.9796;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;174;-4104.95,940.3779;Inherit;False;Property;_Voro2Speed;Voro2Speed;10;0;Create;True;0;0;False;0;False;1,0;-0.5,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TimeNode;169;-4137.97,1115.403;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;185;-3573.697,1152.855;Inherit;False;Property;_Voro2AngleSpeed;Voro2AngleSpeed;9;0;Create;True;0;0;False;0;False;10;20;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;155;-3554.023,984.288;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;168;-3843.75,1002.095;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;203;-3912.677,-744.0109;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector3Node;175;-4100.994,466.6049;Inherit;False;Property;_FresnelBSP;FresnelBSP;8;0;Create;True;0;0;False;0;False;0,1,1;0,100,25;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.TextureCoordinatesNode;204;-3679.075,-752.6078;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;173;-3698.251,816.8845;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;184;-3210.401,1041.679;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;154;-3216.395,807.4669;Inherit;False;Property;_Voro2Scale;Voro2Scale;2;0;Create;True;0;0;False;0;False;5;25;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;197;-3322.979,-603.3958;Inherit;False;Property;_StarScale;StarScale;15;0;Create;True;0;0;False;0;False;10;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;191;-3327.26,-702.8658;Inherit;False;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.FresnelNode;176;-3803.381,441.4043;Inherit;True;Standard;WorldNormal;ViewDir;False;False;5;0;FLOAT3;0,0,1;False;4;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;1.3;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;164;-3001.156,772.7167;Inherit;True;2;0;1;4;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.RangedFloatNode;43;-4215.419,9.399624;Inherit;False;Property;_VoroScale;VoroScale;1;0;Create;True;0;0;False;0;False;5;10;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;162;-2589.765,658.0302;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;59;-4290.45,139.134;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;192;-3128.581,-663.5776;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;2;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector3Node;57;-4248.632,-336.7924;Inherit;False;Constant;_FresneClBSP;FresneClBSP;8;0;Create;True;0;0;False;0;False;0,1,1;1.58,-1.85,0.31;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;159;-2371.98,906.0334;Inherit;False;Property;_Voro2Power;Voro2Power;4;0;Create;True;0;0;False;0;False;5;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;157;-2636.437,410.6891;Inherit;False;Property;_FresnelColor2;FresnelColor2;7;1;[HDR];Create;True;0;0;False;0;False;2,2,2,1;0,1.480169,2.670157,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;187;-2627.733,-706.7203;Inherit;True;Property;_TextureSample0;Texture Sample 0;12;0;Create;True;0;0;False;0;False;-1;None;873b5faacc4840e4db5741bbf1b2ba6c;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VoronoiNode;39;-4000.179,-25.35066;Inherit;True;0;0;1;3;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.RangedFloatNode;196;-2004.996,-761.5972;Inherit;False;Property;_TextureStrength;TextureStrength;14;0;Create;True;0;0;False;0;False;10;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FresnelNode;53;-3951.018,-361.9929;Inherit;True;Standard;WorldNormal;ViewDir;False;False;5;0;FLOAT3;0,0,1;False;4;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;1.3;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;160;-2155.787,570.5393;Inherit;True;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;180;-1827.269,156.3563;Inherit;False;Property;_OpacityPower;OpacityPower;5;0;Create;True;0;0;False;0;False;5;0.01;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;45;-3198.947,-181.2765;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;199;-1716.449,-687.6928;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;161;-1516.725,293.7035;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;52;-3116.118,228.4765;Inherit;False;Property;_VoroPower;VoroPower;3;0;Create;True;0;0;False;0;False;5;1.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ViewDirInputsCoordNode;30;-3166.834,-1208.908;Inherit;False;World;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.TextureCoordinatesNode;211;-2453.411,-938.3514;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;188;-985.4041,-664.1815;Inherit;True;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;210;-2410.237,-1093.511;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT2;0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;212;-2652.349,-920.818;Inherit;False;Property;_TextureScale;TextureScale;16;0;Create;True;0;0;False;0;False;0;9.66;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;213;-2393.414,-1218.086;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.PowerNode;181;-1556.301,-160.8795;Inherit;True;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;51;-2835.932,41.90764;Inherit;True;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;38;-2702.964,-1185.396;Inherit;True;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.Vector3Node;36;-3292.4,-886.8184;Inherit;False;Property;_CubemapNormal;CubemapNormal;6;0;Create;True;0;0;False;0;False;0,1,0;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.NormalVertexDataNode;35;-3307.864,-1036.131;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;208;-2852.588,-906.853;Inherit;False;Property;_TextureTiling;TextureTiling;13;0;Create;True;0;0;False;0;False;1,1;1,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;37;-2996.022,-968.2857;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SamplerNode;34;-2179.919,-1216.869;Inherit;True;Property;_CubeMap;CubeMap;0;1;[HDR];Create;True;0;0;False;0;False;-1;None;c00aef93713f9c341a7899a35042a78f;True;0;False;white;LockedToCube;False;Object;-1;Auto;Cube;8;0;SAMPLERCUBE;;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-695.3407,-501.041;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Tartaros/SH_GalaxyMap;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;True;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;168;0;174;0
WireConnection;168;1;169;1
WireConnection;203;0;202;0
WireConnection;203;1;201;1
WireConnection;204;1;203;0
WireConnection;173;1;168;0
WireConnection;184;0;155;1
WireConnection;184;1;185;0
WireConnection;191;0;204;0
WireConnection;176;1;175;1
WireConnection;176;2;175;2
WireConnection;176;3;175;3
WireConnection;164;0;173;0
WireConnection;164;1;184;0
WireConnection;164;2;154;0
WireConnection;162;0;176;0
WireConnection;162;1;164;0
WireConnection;192;0;191;0
WireConnection;192;1;197;0
WireConnection;187;1;192;0
WireConnection;39;1;59;2
WireConnection;39;2;43;0
WireConnection;53;1;57;1
WireConnection;53;2;57;2
WireConnection;53;3;57;3
WireConnection;160;0;162;0
WireConnection;160;1;159;0
WireConnection;45;0;53;0
WireConnection;45;1;39;0
WireConnection;199;0;196;0
WireConnection;199;1;187;0
WireConnection;161;0;157;0
WireConnection;161;1;160;0
WireConnection;188;1;199;0
WireConnection;188;2;161;0
WireConnection;210;0;30;0
WireConnection;210;1;211;0
WireConnection;213;0;210;0
WireConnection;213;1;212;0
WireConnection;181;0;45;0
WireConnection;181;1;180;0
WireConnection;51;1;52;0
WireConnection;38;1;37;0
WireConnection;37;0;35;0
WireConnection;37;1;36;0
WireConnection;34;1;213;0
WireConnection;0;2;188;0
WireConnection;0;9;181;0
ASEEND*/
//CHKSM=8D576A2A1E2692A84FC0C5C2806A0AC67A62ECBD