// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Cascade3D"
{
	Properties
	{
		[HDR]_RipplesColor("RipplesColor", Color) = (0,0.7686272,1,1)
		_RippleSpeed("RippleSpeed", Vector) = (0,0.2,0,0)
		_VoroSpeed("VoroSpeed", Float) = 2
		_VoroScale("VoroScale", Float) = 10
		_RippleAmount("RippleAmount", Float) = 2
		_VertexOffset("VertexOffset", Float) = 2
		_BottomStrength("BottomStrength", Float) = 30
		_NoiseScale("NoiseScale", Float) = 20
		_BottomBrightness("BottomBrightness", Float) = 3
		_NoiseStrength("NoiseStrength", Float) = 0
		[HideInInspector] _tex3coord( "", 2D ) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Off
		CGINCLUDE
		#include "UnityShaderVariables.cginc"
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
		#undef TRANSFORM_TEX
		#define TRANSFORM_TEX(tex,name) float4(tex.xy * name##_ST.xy + name##_ST.zw, tex.z, tex.w)
		struct Input
		{
			float4 vertexColor : COLOR;
			float3 uv_tex3coord;
			float2 uv_texcoord;
			float3 worldNormal;
			INTERNAL_DATA
		};

		uniform float _VoroScale;
		uniform float _VoroSpeed;
		uniform float2 _RippleSpeed;
		uniform float _RippleAmount;
		uniform float _NoiseScale;
		uniform float _NoiseStrength;
		uniform float _BottomStrength;
		uniform float _BottomBrightness;
		uniform float _VertexOffset;
		uniform float4 _RipplesColor;


		float2 voronoihash9( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi9( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash9( n + g );
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


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float time9 = ( _Time.y * _VoroSpeed );
			float3 temp_output_6_0 = ( v.texcoord.xyz + float3( ( _RippleSpeed * _Time.y ) ,  0.0 ) );
			float2 coords9 = temp_output_6_0.xy * _VoroScale;
			float2 id9 = 0;
			float2 uv9 = 0;
			float fade9 = 0.5;
			float voroi9 = 0;
			float rest9 = 0;
			for( int it9 = 0; it9 <2; it9++ ){
			voroi9 += fade9 * voronoi9( coords9, time9, id9, uv9, 0 );
			rest9 += fade9;
			coords9 *= 2;
			fade9 *= 0.5;
			}//Voronoi9
			voroi9 /= rest9;
			float Voronoi87 = (0.1 + (pow( voroi9 , _RippleAmount ) - 0.0) * (1.0 - 0.1) / (1.0 - 0.0));
			float simplePerlin2D28 = snoise( temp_output_6_0.xy*_NoiseScale );
			simplePerlin2D28 = simplePerlin2D28*0.5 + 0.5;
			float4 ase_vertexTangent = v.tangent;
			float BottomStr88 = (0.0 + (( ( simplePerlin2D28 * _NoiseStrength ) * pow( ( ( 1.0 - v.texcoord.xy.y ) * ( 1.0 - ase_vertexTangent.xyz.y ) ) , _BottomStrength ) ) - 0.0) * (_BottomBrightness - 0.0) / (1.0 - 0.0));
			float temp_output_31_0 = ( Voronoi87 + BottomStr88 );
			float3 ase_vertexNormal = v.normal.xyz;
			v.vertex.xyz += ( temp_output_31_0 * _VertexOffset * ase_vertexNormal );
			v.vertex.w = 1;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			o.Normal = float3(0,0,1);
			float time9 = ( _Time.y * _VoroSpeed );
			float3 temp_output_6_0 = ( i.uv_tex3coord + float3( ( _RippleSpeed * _Time.y ) ,  0.0 ) );
			float2 coords9 = temp_output_6_0.xy * _VoroScale;
			float2 id9 = 0;
			float2 uv9 = 0;
			float fade9 = 0.5;
			float voroi9 = 0;
			float rest9 = 0;
			for( int it9 = 0; it9 <2; it9++ ){
			voroi9 += fade9 * voronoi9( coords9, time9, id9, uv9, 0 );
			rest9 += fade9;
			coords9 *= 2;
			fade9 *= 0.5;
			}//Voronoi9
			voroi9 /= rest9;
			float Voronoi87 = (0.1 + (pow( voroi9 , _RippleAmount ) - 0.0) * (1.0 - 0.1) / (1.0 - 0.0));
			float simplePerlin2D28 = snoise( temp_output_6_0.xy*_NoiseScale );
			simplePerlin2D28 = simplePerlin2D28*0.5 + 0.5;
			float3 ase_worldTangent = WorldNormalVector( i, float3( 1, 0, 0 ) );
			float4 ase_vertexTangent = mul( unity_WorldToObject, float4( ase_worldTangent, 0 ) );
			float BottomStr88 = (0.0 + (( ( simplePerlin2D28 * _NoiseStrength ) * pow( ( ( 1.0 - i.uv_texcoord.y ) * ( 1.0 - ase_vertexTangent.xyz.y ) ) , _BottomStrength ) ) - 0.0) * (_BottomBrightness - 0.0) / (1.0 - 0.0));
			float temp_output_31_0 = ( Voronoi87 + BottomStr88 );
			o.Emission = ( i.vertexColor * ( _RipplesColor * temp_output_31_0 ) ).rgb;
			o.Alpha = 1;
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf Standard alpha:fade keepalpha fullforwardshadows vertex:vertexDataFunc 

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
				float3 customPack1 : TEXCOORD1;
				float2 customPack2 : TEXCOORD2;
				float4 tSpace0 : TEXCOORD3;
				float4 tSpace1 : TEXCOORD4;
				float4 tSpace2 : TEXCOORD5;
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
				vertexDataFunc( v, customInputData );
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				half3 worldTangent = UnityObjectToWorldDir( v.tangent.xyz );
				half tangentSign = v.tangent.w * unity_WorldTransformParams.w;
				half3 worldBinormal = cross( worldNormal, worldTangent ) * tangentSign;
				o.tSpace0 = float4( worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x );
				o.tSpace1 = float4( worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y );
				o.tSpace2 = float4( worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z );
				o.customPack1.xyz = customInputData.uv_tex3coord;
				o.customPack1.xyz = v.texcoord;
				o.customPack2.xy = customInputData.uv_texcoord;
				o.customPack2.xy = v.texcoord;
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
				surfIN.uv_tex3coord = IN.customPack1.xyz;
				surfIN.uv_texcoord = IN.customPack2.xy;
				float3 worldPos = float3( IN.tSpace0.w, IN.tSpace1.w, IN.tSpace2.w );
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
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
312;73;1172;646;3199.208;777.1782;1.906529;True;False
Node;AmplifyShaderEditor.CommentaryNode;84;-2542.596,-764.6003;Inherit;False;2064.862;576.7454;Comment;13;87;20;10;11;2;6;9;77;5;4;1;3;7;Voronoi;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;85;-2683.237,-27.00903;Inherit;False;2926.585;628.645;Comment;21;93;92;88;30;27;53;25;28;103;96;100;26;98;99;102;94;95;101;105;106;107;BottomStrength;1,1,1,1;0;0
Node;AmplifyShaderEditor.Vector2Node;3;-2493.496,-653.1629;Inherit;False;Property;_RippleSpeed;RippleSpeed;1;0;Create;True;0;0;False;0;False;0,0.2;0,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TimeNode;7;-2513.837,-526.1436;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;5;-2253.996,-556.7314;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TangentVertexDataNode;94;-2016.929,272.5554;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TexCoordVertexDataNode;77;-2098.674,-687.9247;Inherit;False;0;3;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TexCoordVertexDataNode;95;-2634.112,190.4408;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;103;-1579.95,138.7689;Inherit;False;Property;_NoiseScale;NoiseScale;7;0;Create;True;0;0;False;0;False;20;2.21;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1;-2494.971,-367.8565;Inherit;False;Property;_VoroSpeed;VoroSpeed;2;0;Create;True;0;0;False;0;False;2;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;98;-1732.434,196.8779;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;99;-1763.434,293.8779;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;6;-1864.917,-583.8026;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT2;0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;2;-1869.079,-393.0303;Inherit;False;Property;_VoroScale;VoroScale;3;0;Create;True;0;0;False;0;False;10;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;96;-1586.434,275.8779;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;4;-2257.549,-459.6161;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;28;-1411.123,69.65017;Inherit;True;Simplex2D;True;True;2;0;FLOAT2;0,0;False;1;FLOAT;20;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;26;-1616.722,450.4378;Inherit;False;Property;_BottomStrength;BottomStrength;6;0;Create;True;0;0;False;0;False;30;1.57;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;106;-1178.737,166.7519;Inherit;False;Property;_NoiseStrength;NoiseStrength;9;0;Create;True;0;0;False;0;False;0;0.04;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;107;-1055.856,82.27563;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;9;-1670.793,-481.0547;Inherit;True;2;0;1;0;2;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.PowerNode;25;-1378.759,349.1871;Inherit;True;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;11;-1462.809,-393.5601;Inherit;False;Property;_RippleAmount;RippleAmount;4;0;Create;True;0;0;False;0;False;2;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;10;-1234.026,-479.764;Inherit;True;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;53;-638.3714,197.0841;Inherit;False;Property;_BottomBrightness;BottomBrightness;8;0;Create;True;0;0;False;0;False;3;9.14;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;27;-864.3497,103.9343;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;20;-922.9005,-481.3763;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0.1;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;30;-391.181,106.133;Inherit;True;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;87;-695.9137,-485.2476;Inherit;False;Voronoi;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;88;-84.58542,100.4352;Inherit;False;BottomStr;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;86;513.8255,764.4315;Inherit;False;87;Voronoi;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;89;514.0189,853.4998;Inherit;False;88;BottomStr;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;15;746.1805,393.3784;Inherit;False;Property;_RipplesColor;RipplesColor;0;1;[HDR];Create;True;0;0;False;0;False;0,0.7686272,1,1;0.244927,0.8912578,1.207547,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;31;747.8627,777.9861;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;37;1049.345,844.2968;Inherit;False;Property;_VertexOffset;VertexOffset;5;0;Create;True;0;0;False;0;False;2;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;13;1064.601,396.2743;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.NormalVertexDataNode;80;1041.802,927.0549;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VertexColorNode;16;1048.322,210.2002;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;14;1290.323,336.9182;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.DynamicAppendNode;92;-1844.944,416.5063;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.BreakToComponentsNode;93;-2191.125,414.9934;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;36;1288.2,774.9714;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TimeNode;101;-2643.191,41.09045;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;105;-2383.195,114.4934;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;102;-2222.637,69.0426;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;100;-1996.318,64.73669;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;2000.086,287.935;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Cascade3D;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;True;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;True;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;5;0;3;0
WireConnection;5;1;7;2
WireConnection;98;0;95;2
WireConnection;99;0;94;2
WireConnection;6;0;77;0
WireConnection;6;1;5;0
WireConnection;96;0;98;0
WireConnection;96;1;99;0
WireConnection;4;0;7;2
WireConnection;4;1;1;0
WireConnection;28;0;6;0
WireConnection;28;1;103;0
WireConnection;107;0;28;0
WireConnection;107;1;106;0
WireConnection;9;0;6;0
WireConnection;9;1;4;0
WireConnection;9;2;2;0
WireConnection;25;0;96;0
WireConnection;25;1;26;0
WireConnection;10;0;9;0
WireConnection;10;1;11;0
WireConnection;27;0;107;0
WireConnection;27;1;25;0
WireConnection;20;0;10;0
WireConnection;30;0;27;0
WireConnection;30;4;53;0
WireConnection;87;0;20;0
WireConnection;88;0;30;0
WireConnection;31;0;86;0
WireConnection;31;1;89;0
WireConnection;13;0;15;0
WireConnection;13;1;31;0
WireConnection;14;0;16;0
WireConnection;14;1;13;0
WireConnection;92;0;93;0
WireConnection;92;1;93;1
WireConnection;92;2;93;2
WireConnection;36;0;31;0
WireConnection;36;1;37;0
WireConnection;36;2;80;0
WireConnection;105;0;101;2
WireConnection;105;1;95;2
WireConnection;102;0;95;1
WireConnection;102;1;105;0
WireConnection;100;1;102;0
WireConnection;0;2;14;0
WireConnection;0;11;36;0
ASEEND*/
//CHKSM=0D7B97FABA95B07A5167D95814202E214D7C27E7