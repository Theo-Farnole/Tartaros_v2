// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_RimeFire"
{
	Properties
	{
		[HDR]_Color("Color", Color) = (1,0,0,0)
		[HDR]_Color2("Color2", Color) = (0.8623142,0,1,0)
		_VerticalAlphaStrength("VerticalAlphaStrength", Float) = 1
		_Voro1Strength("Voro1Strength", Float) = 1
		_Voro1Scale("Voro1Scale", Float) = 2
		_VoroSpeed1("VoroSpeed1", Float) = 0
		_Tiling("Tiling", Float) = 0.28
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
		};

		uniform float4 _Color2;
		uniform float _Voro1Scale;
		uniform float _Tiling;
		uniform float _VoroSpeed1;
		uniform float _Voro1Strength;
		uniform float _VerticalAlphaStrength;
		uniform float4 _Color;


		float2 voronoihash4( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi4( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash4( n + g );
					o = ( sin( time + o * 6.2831 ) * 0.5 + 0.5 ); float2 r = f - g - o;
					float d = 0.5 * dot( r, r );
			 //		if( d<F1 ) {
			 //			F2 = F1;
			 			float h = smoothstep(0.0, 1.0, 0.5 + 0.5 * (F1 - d) / smoothness); F1 = lerp(F1, d, h) - smoothness * h * (1.0 - h);mg = g; mr = r; id = o;
			 //		} else if( d<F2 ) {
			 //			F2 = d;
			 //		}
			 	}
			}
			return F1;
		}


		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float time4 = _Time.z;
			float voronoiSmooth0 = 0.0;
			float2 temp_cast_0 = (_Tiling).xx;
			float2 appendResult90 = (float2(0.0 , ( _Time.y * _VoroSpeed1 )));
			float2 uv_TexCoord2 = i.uv_texcoord * temp_cast_0 + appendResult90;
			float2 coords4 = uv_TexCoord2 * _Voro1Scale;
			float2 id4 = 0;
			float2 uv4 = 0;
			float fade4 = 0.5;
			float voroi4 = 0;
			float rest4 = 0;
			for( int it4 = 0; it4 <4; it4++ ){
			voroi4 += fade4 * voronoi4( coords4, time4, id4, uv4, voronoiSmooth0 );
			rest4 += fade4;
			coords4 *= 2;
			fade4 *= 0.5;
			}//Voronoi4
			voroi4 /= rest4;
			float alphaVertical52 = ( ( 1.0 - length( i.uv_texcoord.y ) ) * _VerticalAlphaStrength );
			float2 uv_TexCoord174 = i.uv_texcoord * float2( 5,2.07 ) + float2( -2.5,0 );
			float PaternToAlpha156 = ( alphaVertical52 + ( 1.0 - length( uv_TexCoord174 ) ) );
			float temp_output_183_0 = ( saturate( ( voroi4 * _Voro1Strength ) ) * PaternToAlpha156 );
			float2 _Vector0 = float2(0.05,0.02);
			float temp_output_194_0 = step( temp_output_183_0 , _Vector0.x );
			float temp_output_198_0 = ( 1.0 - temp_output_194_0 );
			float temp_output_197_0 = ( temp_output_194_0 - step( temp_output_183_0 , _Vector0.y ) );
			float4 color46 = ( ( _Color2 * temp_output_198_0 ) + ( temp_output_197_0 * _Color ) );
			o.Emission = color46.rgb;
			float OpacityToCore182 = ( temp_output_198_0 + temp_output_197_0 );
			o.Alpha = OpacityToCore182;
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
311;73;1297;655;5965.087;760.8723;1.870581;True;False
Node;AmplifyShaderEditor.TextureCoordinatesNode;51;-4847.912,1055.759;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LengthOpNode;50;-4570.985,1102.073;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;98;-4340.475,1102.459;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;81;-4083.351,1230.938;Inherit;False;Property;_VerticalAlphaStrength;VerticalAlphaStrength;2;0;Create;True;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;94;-5941.566,229.69;Inherit;False;Property;_VoroSpeed1;VoroSpeed1;7;0;Create;True;0;0;False;0;False;0;-0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;88;-6152.363,27.52904;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;174;-3160.73,1204.46;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;5,2.07;False;1;FLOAT2;-2.5,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;80;-4046.599,1103.721;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;92;-5763.829,44.34221;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;175;-2902.872,1202.931;Inherit;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;52;-3789.051,1098.406;Inherit;True;alphaVertical;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;193;-5582.689,-161.1733;Inherit;False;Property;_Tiling;Tiling;9;0;Create;True;0;0;False;0;False;0.28;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;90;-5536.163,24.47124;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;66;-2730.276,926.3641;Inherit;True;52;alphaVertical;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;176;-2663.502,1198.291;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;200;-5057.184,-16.97843;Inherit;False;Constant;_Smoothness;Smoothness;11;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;78;-5046.665,-116.4272;Inherit;False;Property;_Voro1Scale;Voro1Scale;5;0;Create;True;0;0;False;0;False;2;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;2;-5350.79,-261.6204;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;6;-4717.896,-18.0717;Inherit;False;Property;_Voro1Strength;Voro1Strength;3;0;Create;True;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;4;-4813.371,-292.7812;Inherit;True;0;0;1;0;4;False;1;False;True;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;2;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SimpleAddOpNode;172;-2400.584,997.2526;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;5;-4497.906,-194.5927;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;156;-2115.627,1032.872;Inherit;False;PaternToAlpha;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;179;-4338.904,70.31859;Inherit;False;156;PaternToAlpha;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;8;-4268.694,-194.5929;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;183;-4067.36,-60.57362;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;199;-3509.449,279.9181;Inherit;False;Constant;_Vector0;Vector 0;10;0;Create;True;0;0;False;0;False;0.05,0.02;0.14,0.04;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.StepOpNode;194;-3486.396,-227.1913;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0.05;False;1;FLOAT;0
Node;AmplifyShaderEditor.StepOpNode;195;-3509.147,5.184366;Inherit;True;2;0;FLOAT;0.2;False;1;FLOAT;0.01;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;197;-3237.771,-77.69094;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;31;-3046.675,449.164;Inherit;False;Property;_Color;Color;0;1;[HDR];Create;True;0;0;False;0;False;1,0,0,0;0,0.6745098,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;64;-4324.983,-421.2985;Inherit;False;Property;_Color2;Color2;1;1;[HDR];Create;True;0;0;False;0;False;0.8623142,0,1,0;0,0.5756109,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;198;-3211.772,-188.1908;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;147;-2706.389,310.5412;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;27;-2748.295,-254.5787;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;173;-2379.375,49.29852;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;181;-2848.469,42.99206;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;46;-2092.448,45.88503;Inherit;True;color;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;182;-2686.815,44.71176;Inherit;True;OpacityToCore;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;184;-4041.824,65.7014;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;3;-4725.931,74.30931;Inherit;True;0;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;20;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SmoothstepOpNode;178;-3917.773,165.8984;Inherit;True;3;0;FLOAT;0.17;False;1;FLOAT;0;False;2;FLOAT;0.77;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;185;-4446.812,461.4578;Inherit;True;46;color;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;11;-4268.474,175.6332;Inherit;True;Simple;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;9;-4502.232,180.1946;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;95;-5932.783,336.8414;Inherit;False;Property;_VoroSpeed2;VoroSpeed2;8;0;Create;True;0;0;False;0;False;0;-0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;79;-4953.639,124.6315;Inherit;False;Property;_Voro2Scale;Voro2Scale;6;0;Create;True;0;0;False;0;False;20;1.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;160;-3885.991,-191.4162;Inherit;True;3;0;FLOAT;0.17;False;1;FLOAT;0;False;2;FLOAT;0.08;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;89;-5755.187,265.8203;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;49;-457.9221,320.6905;Inherit;False;182;OpacityToCore;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCGrayscale;76;-135.5875,458.2565;Inherit;True;0;1;0;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;48;-123.2184,171.4525;Inherit;False;46;color;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.DynamicAppendNode;91;-5534.552,238.0307;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;10;-4723.222,359.7156;Inherit;False;Property;_Voro2Strength;Voro2Strength;4;0;Create;True;0;0;False;0;False;0.75;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;93;-5335.548,43.49212;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleSubtractOpNode;177;-2185.086,-326.9911;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;189.7221,89.16941;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Tartaros/SH_RimeFire;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;True;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;50;0;51;2
WireConnection;98;0;50;0
WireConnection;80;0;98;0
WireConnection;80;1;81;0
WireConnection;92;0;88;2
WireConnection;92;1;94;0
WireConnection;175;0;174;0
WireConnection;52;0;80;0
WireConnection;90;1;92;0
WireConnection;176;0;175;0
WireConnection;2;0;193;0
WireConnection;2;1;90;0
WireConnection;4;0;2;0
WireConnection;4;1;88;3
WireConnection;4;2;78;0
WireConnection;4;3;200;0
WireConnection;172;0;66;0
WireConnection;172;1;176;0
WireConnection;5;0;4;0
WireConnection;5;1;6;0
WireConnection;156;0;172;0
WireConnection;8;0;5;0
WireConnection;183;0;8;0
WireConnection;183;1;179;0
WireConnection;194;0;183;0
WireConnection;194;1;199;1
WireConnection;195;0;183;0
WireConnection;195;1;199;2
WireConnection;197;0;194;0
WireConnection;197;1;195;0
WireConnection;198;0;194;0
WireConnection;147;0;197;0
WireConnection;147;1;31;0
WireConnection;27;0;64;0
WireConnection;27;1;198;0
WireConnection;173;0;27;0
WireConnection;173;1;147;0
WireConnection;181;0;198;0
WireConnection;181;1;197;0
WireConnection;46;0;173;0
WireConnection;182;0;181;0
WireConnection;184;0;179;0
WireConnection;184;1;11;0
WireConnection;3;0;93;0
WireConnection;3;1;88;3
WireConnection;3;2;79;0
WireConnection;178;0;184;0
WireConnection;11;0;9;0
WireConnection;9;0;3;0
WireConnection;9;1;10;0
WireConnection;160;0;183;0
WireConnection;89;0;88;2
WireConnection;89;1;95;0
WireConnection;91;1;89;0
WireConnection;93;0;193;0
WireConnection;93;1;91;0
WireConnection;0;2;48;0
WireConnection;0;9;49;0
ASEEND*/
//CHKSM=9F947594E63C3AC10FC26B4297A3C1D97207A779