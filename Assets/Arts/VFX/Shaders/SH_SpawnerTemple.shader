// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_SpawnerTemple"
{
	Properties
	{
		[HDR]_Color1("Color 1", Color) = (0,0.5719719,1,1)
		[HDR]_Color0("Color 0", Color) = (0,1,0.6669481,1)
		_VoroPaternScale("VoroPaternScale", Float) = 0.35
		_VoroBorderScale("VoroBorderScale", Float) = 1
		_BorderSpeed("BorderSpeed", Float) = 1
		_StepOutter("StepOutter", Float) = 2.5
		_OpacityFromPatern("OpacityFromPatern", Vector) = (0,20,0,0)
		_StepInner("StepInner", Vector) = (0,1,0,0)
		_PaternPower("PaternPower", Float) = 2.53
		_ColorSteps("ColorSteps", Vector) = (3,0.1,0,0)
		_UV_tiling("UV_tiling", Vector) = (1,1,1,0)
		_DepthDist("DepthDist", Float) = 0
		_SmoothDepth("SmoothDepth", Vector) = (0,0,0,0)
		[HideInInspector] _tex3coord( "", 2D ) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Off
		CGPROGRAM
		#include "UnityCG.cginc"
		#include "UnityShaderVariables.cginc"
		#pragma target 5.0
		#pragma surface surf Standard alpha:fade keepalpha noshadow 
		#undef TRANSFORM_TEX
		#define TRANSFORM_TEX(tex,name) float4(tex.xy * name##_ST.xy + name##_ST.zw, tex.z, tex.w)
		struct Input
		{
			float4 screenPos;
			float3 worldPos;
			float3 uv_tex3coord;
			float2 uv_texcoord;
			float4 vertexColor : COLOR;
		};

		uniform float2 _SmoothDepth;
		UNITY_DECLARE_DEPTH_TEXTURE( _CameraDepthTexture );
		uniform float4 _CameraDepthTexture_TexelSize;
		uniform float _DepthDist;
		uniform float4 _Color1;
		uniform float4 _ColorSteps;
		uniform float _VoroBorderScale;
		uniform float _BorderSpeed;
		uniform float3 _UV_tiling;
		uniform float _StepOutter;
		uniform float2 _StepInner;
		uniform float _VoroPaternScale;
		uniform float _PaternPower;
		uniform float4 _Color0;
		uniform float2 _OpacityFromPatern;


		float2 voronoihash225( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi225( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash225( n + g );
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


		float2 voronoihash241( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi241( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash241( n + g );
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
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float4 ase_screenPosNorm = ase_screenPos / ase_screenPos.w;
			ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
			float screenDepth268 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_screenPosNorm.xy ));
			float distanceDepth268 = abs( ( screenDepth268 - LinearEyeDepth( ase_screenPosNorm.z ) ) / ( _DepthDist ) );
			float smoothstepResult278 = smoothstep( _SmoothDepth.x , _SmoothDepth.y , distanceDepth268);
			float time225 = ( _Time.y * _BorderSpeed );
			float3 ase_worldPos = i.worldPos;
			float2 appendResult211 = (float2(ase_worldPos.x , ( ase_worldPos.y + ase_worldPos.z )));
			float3 uvs3_TexCoord212 = i.uv_tex3coord;
			uvs3_TexCoord212.xy = i.uv_tex3coord.xy + appendResult211;
			float3 uvs3_TexCoord216 = i.uv_tex3coord;
			uvs3_TexCoord216.xy = i.uv_tex3coord.xy * _UV_tiling.xy + uvs3_TexCoord212.xy;
			float3 MoveUV217 = uvs3_TexCoord216;
			float2 coords225 = MoveUV217.xy * _VoroBorderScale;
			float2 id225 = 0;
			float2 uv225 = 0;
			float fade225 = 0.5;
			float voroi225 = 0;
			float rest225 = 0;
			for( int it225 = 0; it225 <8; it225++ ){
			voroi225 += fade225 * voronoi225( coords225, time225, id225, uv225, 0 );
			rest225 += fade225;
			coords225 *= 2;
			fade225 *= 0.5;
			}//Voronoi225
			voroi225 /= rest225;
			float RoundZone202 = ( 1.0 - length( ( i.uv_texcoord + float2( -0.5,-0.5 ) ) ) );
			float smoothstepResult229 = smoothstep( 0.5 , 1.0 , RoundZone202);
			float smoothstepResult230 = smoothstep( voroi225 , ( voroi225 * _StepOutter ) , smoothstepResult229);
			float smoothstepResult233 = smoothstep( ( smoothstepResult230 * _StepInner.x ) , _StepInner.y , smoothstepResult230);
			float NoisedRound240 = ( smoothstepResult230 + smoothstepResult233 );
			float time241 = 0.0;
			float3 WorldUV219 = uvs3_TexCoord212;
			float2 coords241 = WorldUV219.xy * _VoroPaternScale;
			float2 id241 = 0;
			float2 uv241 = 0;
			float fade241 = 0.5;
			float voroi241 = 0;
			float rest241 = 0;
			for( int it241 = 0; it241 <7; it241++ ){
			voroi241 += fade241 * voronoi241( coords241, time241, id241, uv241, 0 );
			rest241 += fade241;
			coords241 *= 2;
			fade241 *= 0.5;
			}//Voronoi241
			voroi241 /= rest241;
			float temp_output_239_0 = ( RoundZone202 * _PaternPower );
			float Patern246 = ( ( NoisedRound240 + 0.0 ) * ( ( voroi241 * temp_output_239_0 ) + temp_output_239_0 ) );
			float smoothstepResult260 = smoothstep( _ColorSteps.x , _ColorSteps.y , Patern246);
			float smoothstepResult257 = smoothstep( _ColorSteps.z , _ColorSteps.w , Patern246);
			o.Emission = ( ( smoothstepResult278 * ( _Color1 * smoothstepResult260 ) ) + ( ( smoothstepResult257 * _Color0 ) * ( 1.0 - smoothstepResult278 ) ) ).rgb;
			float smoothstepResult252 = smoothstep( _OpacityFromPatern.x , _OpacityFromPatern.y , Patern246);
			float Opacity254 = ( i.vertexColor.a * smoothstepResult252 );
			o.Alpha = Opacity254;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
348;73;1187;613;1874.434;101.0026;2.574445;True;False
Node;AmplifyShaderEditor.CommentaryNode;203;1961.504,-2149.448;Inherit;False;1841.097;593.0708;Comment;8;219;217;216;212;211;209;206;204;UVs;1,1,1,1;0;0
Node;AmplifyShaderEditor.WorldPosInputsNode;206;2265.504,-1765.448;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleAddOpNode;209;2489.504,-1669.448;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;196;3527.234,1853.784;Inherit;False;1012.65;378.5044;Comment;6;202;201;200;199;198;197;RoundZone;1,1,1,1;0;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode;197;3577.234,1903.784;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;211;2665.504,-1733.448;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;198;3581.306,2046.369;Inherit;False;Constant;_Vector1;Vector 1;2;0;Create;True;0;0;False;0;False;-0.5,-0.5;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleAddOpNode;199;3819.731,1989.957;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector3Node;204;2278.731,-1948.939;Inherit;False;Property;_UV_tiling;UV_tiling;10;0;Create;True;0;0;False;0;False;1,1,1;-1,1,1;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.TextureCoordinatesNode;212;2873.504,-1733.448;Inherit;False;0;-1;3;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LengthOpNode;200;3956.4,1990.897;Inherit;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;216;3305.504,-1925.448;Inherit;False;0;-1;3;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.CommentaryNode;215;1961.504,-837.4479;Inherit;False;2700.028;661.0336;Comment;16;240;234;233;232;231;230;229;228;227;226;225;224;223;222;221;220;PATERN in;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;217;3561.504,-1941.448;Inherit;False;MoveUV;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.OneMinusNode;201;4136.813,1989.692;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;221;2009.504,-453.4479;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;220;2041.504,-309.4479;Inherit;False;Property;_BorderSpeed;BorderSpeed;4;0;Create;True;0;0;False;0;False;1;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;223;2249.504,-405.4479;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;224;2265.504,-565.4479;Inherit;False;217;MoveUV;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;202;4306.116,1985.49;Inherit;True;RoundZone;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;222;2457.504,-293.4479;Inherit;False;Property;_VoroBorderScale;VoroBorderScale;3;0;Create;True;0;0;False;0;False;1;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;226;2697.504,-773.4479;Inherit;True;202;RoundZone;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;227;2729.504,-357.4479;Inherit;False;Property;_StepOutter;StepOutter;5;0;Create;True;0;0;False;0;False;2.5;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;225;2473.504,-565.4479;Inherit;True;0;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;10;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;228;2921.504,-421.4479;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;229;2969.504,-773.4479;Inherit;True;3;0;FLOAT;0.32;False;1;FLOAT;0.5;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;231;3369.504,-357.4479;Inherit;False;Property;_StepInner;StepInner;7;0;Create;True;0;0;False;0;False;0,1;1,0.5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SmoothstepOpNode;230;3321.504,-597.4479;Inherit;True;3;0;FLOAT;0.32;False;1;FLOAT;-0.17;False;2;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;232;3593.504,-437.4479;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;219;3181.243,-1720.245;Inherit;False;WorldUV;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SmoothstepOpNode;233;3833.504,-453.4479;Inherit;True;3;0;FLOAT;0.32;False;1;FLOAT;-0.17;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;218;1945.504,506.5521;Inherit;False;1442;823.9999;Comment;12;247;246;245;244;243;242;241;239;238;237;236;235;PATERN out;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleAddOpNode;234;4185.504,-597.4479;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;237;2009.504,1098.552;Inherit;True;202;RoundZone;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;238;2025.504,842.5521;Inherit;False;219;WorldUV;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;236;2025.504,970.5521;Inherit;False;Property;_VoroPaternScale;VoroPaternScale;2;0;Create;True;0;0;False;0;False;0.35;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;235;2265.504,1194.552;Inherit;False;Property;_PaternPower;PaternPower;8;0;Create;True;0;0;False;0;False;2.53;1.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;240;4425.504,-597.4479;Inherit;True;NoisedRound;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;239;2473.504,1114.552;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;241;2297.504,890.5521;Inherit;True;0;0;1;0;7;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.GetLocalVarNode;247;2249.504,634.5521;Inherit;True;240;NoisedRound;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;242;2617.504,970.5521;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;244;2809.504,1002.552;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;243;2617.504,810.5521;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;245;2969.504,858.5521;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;248;2079.199,1746.325;Inherit;False;1159.129;479.0177;Comment;6;254;253;252;251;250;249;Opacity;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;246;3161.504,842.5521;Inherit;True;Patern;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;269;-1146.99,1114.901;Inherit;False;Property;_DepthDist;DepthDist;11;0;Create;True;0;0;False;0;False;0;0.15;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;255;-1059.204,108.1779;Inherit;False;1523.412;910.0004;Comment;12;267;266;265;264;263;261;260;259;258;257;256;281;COLORS;1,1,1,1;0;0
Node;AmplifyShaderEditor.Vector4Node;256;-1009.204,527.5;Inherit;False;Property;_ColorSteps;ColorSteps;9;0;Create;True;0;0;False;0;False;3,0.1,0,0;3,-0.5,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;249;2140.665,2013.345;Inherit;False;246;Patern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;279;-927.7193,1215.955;Inherit;False;Property;_SmoothDepth;SmoothDepth;12;0;Create;True;0;0;False;0;False;0,0;-2,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;250;2321.061,2081.959;Inherit;False;Property;_OpacityFromPatern;OpacityFromPatern;6;0;Create;True;0;0;False;0;False;0,20;0,2;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.GetLocalVarNode;267;-930.2109,405.5213;Inherit;False;246;Patern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.DepthFade;268;-960.118,1099.726;Inherit;False;True;False;True;2;1;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;259;-894.1899,158.1779;Inherit;False;Property;_Color1;Color 1;0;1;[HDR];Create;True;0;0;False;0;False;0,0.5719719,1,1;0,1,0.7496002,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;278;-678.4515,1100.72;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;260;-662.3101,478.7976;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;252;2566.16,2017.959;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0.47;False;2;FLOAT;1.23;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;257;-661.1909,620.6687;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;251;2138.748,1826.424;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;258;-820.1377,803.9876;Inherit;False;Property;_Color0;Color 0;1;1;[HDR];Create;True;0;0;False;0;False;0,1,0.6669481,1;1,1,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;253;2754.046,1925.803;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;264;-377.1495,247.915;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;261;-381.0045,604.4713;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;276;-460.6996,1098.422;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;254;3013.147,1921.292;Inherit;False;Opacity;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;263;-69.0183,723.4178;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;281;-27.92522,212.1623;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;265;247.8107,697.9938;Inherit;True;254;Opacity;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;266;241.1948,455.6192;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;687.3802,384.0729;Float;False;True;-1;7;ASEMaterialInspector;0;0;Standard;Tartaros/SH_SpawnerTemple;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;209;0;206;2
WireConnection;209;1;206;3
WireConnection;211;0;206;1
WireConnection;211;1;209;0
WireConnection;199;0;197;0
WireConnection;199;1;198;0
WireConnection;212;1;211;0
WireConnection;200;0;199;0
WireConnection;216;0;204;0
WireConnection;216;1;212;0
WireConnection;217;0;216;0
WireConnection;201;0;200;0
WireConnection;223;0;221;2
WireConnection;223;1;220;0
WireConnection;202;0;201;0
WireConnection;225;0;224;0
WireConnection;225;1;223;0
WireConnection;225;2;222;0
WireConnection;228;0;225;0
WireConnection;228;1;227;0
WireConnection;229;0;226;0
WireConnection;230;0;229;0
WireConnection;230;1;225;0
WireConnection;230;2;228;0
WireConnection;232;0;230;0
WireConnection;232;1;231;1
WireConnection;219;0;212;0
WireConnection;233;0;230;0
WireConnection;233;1;232;0
WireConnection;233;2;231;2
WireConnection;234;0;230;0
WireConnection;234;1;233;0
WireConnection;240;0;234;0
WireConnection;239;0;237;0
WireConnection;239;1;235;0
WireConnection;241;0;238;0
WireConnection;241;2;236;0
WireConnection;242;0;241;0
WireConnection;242;1;239;0
WireConnection;244;0;242;0
WireConnection;244;1;239;0
WireConnection;243;0;247;0
WireConnection;245;0;243;0
WireConnection;245;1;244;0
WireConnection;246;0;245;0
WireConnection;268;0;269;0
WireConnection;278;0;268;0
WireConnection;278;1;279;1
WireConnection;278;2;279;2
WireConnection;260;0;267;0
WireConnection;260;1;256;1
WireConnection;260;2;256;2
WireConnection;252;0;249;0
WireConnection;252;1;250;1
WireConnection;252;2;250;2
WireConnection;257;0;267;0
WireConnection;257;1;256;3
WireConnection;257;2;256;4
WireConnection;253;0;251;4
WireConnection;253;1;252;0
WireConnection;264;0;259;0
WireConnection;264;1;260;0
WireConnection;261;0;257;0
WireConnection;261;1;258;0
WireConnection;276;0;278;0
WireConnection;254;0;253;0
WireConnection;263;0;261;0
WireConnection;263;1;276;0
WireConnection;281;0;278;0
WireConnection;281;1;264;0
WireConnection;266;0;281;0
WireConnection;266;1;263;0
WireConnection;0;2;266;0
WireConnection;0;9;265;0
ASEEND*/
//CHKSM=5F9301818A121832403F200C15EF6B79C65C11FD