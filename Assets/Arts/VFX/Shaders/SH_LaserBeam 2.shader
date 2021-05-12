// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_LaserBeam 2"
{
	Properties
	{
		_UV_direction("UV_direction", Vector) = (-1,0,0,0)
		_UV_tiling("UV_tiling", Vector) = (1,1,0,0)
		[HDR]_Color1("Color 1", Color) = (1,0.3057163,0,0)
		_RadialShear("RadialShear", Vector) = (10,10,0,0)
		_LaserStrength("LaserStrength", Float) = 1
		_LaserPower("LaserPower", Float) = 10
		_SmoothStep("SmoothStep", Vector) = (0,0.8,0,0)
		_Tiling("Tiling", Vector) = (1,1,0,0)
		_TilingWidth("TilingWidth", Vector) = (1,3,0,0)
		_TilingOffset("TilingOffset", Vector) = (-1,-1,0,0)
		_PaternScale2("PaternScale2", Float) = 2
		_PaternSpeed("PaternSpeed", Float) = 1
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_OpacityTexture("OpacityTexture", Float) = 1
		_OpacityPatern("OpacityPatern", Float) = 1
		[HideInInspector] _tex3coord( "", 2D ) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Off
		Blend SrcAlpha OneMinusSrcAlpha
		BlendOp Add
		AlphaToMask On
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha noshadow 
		#undef TRANSFORM_TEX
		#define TRANSFORM_TEX(tex,name) float4(tex.xy * name##_ST.xy + name##_ST.zw, tex.z, tex.w)
		struct Input
		{
			float2 uv_texcoord;
			float3 uv_tex3coord;
		};

		uniform float4 _Color1;
		uniform float _LaserStrength;
		uniform float _LaserPower;
		uniform float2 _TilingWidth;
		uniform float2 _TilingOffset;
		uniform sampler2D _TextureSample0;
		uniform float4 _TextureSample0_ST;
		uniform float2 _SmoothStep;
		uniform float _PaternScale2;
		uniform float _PaternSpeed;
		uniform float2 _Tiling;
		uniform float2 _UV_tiling;
		uniform float2 _UV_direction;
		uniform float2 _RadialShear;
		uniform float _OpacityTexture;
		uniform float _OpacityPatern;


		float2 voronoihash282( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi282( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash282( n + g );
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
			float2 uv_TexCoord349 = i.uv_texcoord * _TilingWidth + _TilingOffset;
			float temp_output_222_0 = ( ( 1.0 - uv_TexCoord349.y ) * uv_TexCoord349.y );
			float2 uv_TextureSample0 = i.uv_texcoord * _TextureSample0_ST.xy + _TextureSample0_ST.zw;
			float4 temp_output_334_0 = ( _LaserPower * ( temp_output_222_0 * tex2D( _TextureSample0, uv_TextureSample0 ) ) );
			float time282 = ( _Time.w * _PaternSpeed );
			float2 uv_TexCoord42 = i.uv_texcoord * _UV_tiling + ( _UV_direction * _Time.y );
			float2 temp_output_1_0_g12 = i.uv_tex3coord.xy;
			float2 temp_output_11_0_g12 = ( temp_output_1_0_g12 - float2( 0.5,0.5 ) );
			float2 break18_g12 = temp_output_11_0_g12;
			float2 appendResult19_g12 = (float2(break18_g12.y , -break18_g12.x));
			float dotResult12_g12 = dot( temp_output_11_0_g12 , temp_output_11_0_g12 );
			float2 UV43 = ( uv_TexCoord42 + ( temp_output_1_0_g12 + ( appendResult19_g12 * ( dotResult12_g12 * _RadialShear ) ) + float2( 0.25,0.25 ) ) );
			float2 uv_TexCoord285 = i.uv_texcoord * _Tiling + UV43;
			float2 coords282 = uv_TexCoord285 * _PaternScale2;
			float2 id282 = 0;
			float2 uv282 = 0;
			float fade282 = 0.5;
			float voroi282 = 0;
			float rest282 = 0;
			for( int it282 = 0; it282 <8; it282++ ){
			voroi282 += fade282 * voronoi282( coords282, time282, id282, uv282, 0 );
			rest282 += fade282;
			coords282 *= 2;
			fade282 *= 0.5;
			}//Voronoi282
			voroi282 /= rest282;
			float smoothstepResult250 = smoothstep( _SmoothStep.x , _SmoothStep.y , voroi282);
			float4 clampResult348 = clamp( ( ( 1.0 - temp_output_334_0 ) * smoothstepResult250 ) , float4( 0,0,0,0 ) , float4( 1,1,1,1 ) );
			float4 LaserCoreShape89 = ( _LaserStrength * ( temp_output_334_0 + clampResult348 ) );
			o.Emission = ( ( _Color1 * LaserCoreShape89 ) + float4( 0,0,0,0 ) ).rgb;
			float Patern342 = temp_output_222_0;
			o.Alpha = ( ( LaserCoreShape89 * _OpacityTexture ) + ( Patern342 * _OpacityPatern ) ).r;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
247;73;1289;602;820.0615;-4.209564;1.506697;True;False
Node;AmplifyShaderEditor.TimeNode;45;-395.4768,-1423.881;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;46;-352.5932,-1571.729;Inherit;False;Property;_UV_direction;UV_direction;1;0;Create;True;0;0;False;0;False;-1,0;-1,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.CommentaryNode;30;-1915.972,-3894.345;Inherit;False;4099.005;1764.964;Comment;31;89;208;216;222;229;235;250;281;282;285;286;299;308;309;316;317;318;327;330;331;334;335;337;339;342;347;348;338;350;349;351;LASERSHAPE;1,1,1,1;0;0
Node;AmplifyShaderEditor.Vector2Node;48;-58.37362,-1608.911;Inherit;False;Property;_UV_tiling;UV_tiling;3;0;Create;True;0;0;False;0;False;1,1;-1.04,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;57;-55.6778,-1131.767;Inherit;False;Property;_RadialShear;RadialShear;5;0;Create;True;0;0;False;0;False;10,10;1,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;58;-64.44686,-1003.489;Inherit;False;Constant;_Vector1;Vector 1;7;0;Create;True;0;0;False;0;False;0.25,0.25;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TexCoordVertexDataNode;315;-342.7141,-1188.328;Inherit;False;0;3;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;47;-69.78723,-1463.468;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;350;-1886.166,-3220.152;Inherit;False;Property;_TilingWidth;TilingWidth;10;0;Create;True;0;0;False;0;False;1,3;2,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;351;-1873.641,-3093.496;Inherit;False;Property;_TilingOffset;TilingOffset;11;0;Create;True;0;0;False;0;False;-1,-1;2,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.FunctionNode;56;246.2455,-1192.625;Inherit;True;Radial Shear;-1;;12;c6dc9fc7fa9b08c4d95138f2ae88b526;0;4;1;FLOAT2;0,0;False;2;FLOAT2;0,0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;42;282.1682,-1546.545;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;59;644.6029,-1317.952;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;349;-1598.073,-3114.822;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,-0.14;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;216;-1517.084,-3506.595;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;43;907.2883,-1325.726;Inherit;True;UV;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;222;-1289.253,-3290.889;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;331;-1825.164,-2372.833;Inherit;False;Property;_PaternSpeed;PaternSpeed;14;0;Create;True;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;316;-1841.487,-2521.657;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;299;-1834.33,-2950.693;Inherit;False;Property;_Tiling;Tiling;9;0;Create;True;0;0;False;0;False;1,1;2,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SamplerNode;337;-1134.168,-3560.95;Inherit;True;Property;_TextureSample0;Texture Sample 0;15;0;Create;True;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;309;-1856.723,-2821.219;Inherit;False;43;UV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;327;-1385.109,-2423.63;Inherit;False;Property;_PaternScale2;PaternScale2;13;0;Create;True;0;0;False;0;False;2;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;335;-16.23507,-3397.641;Inherit;False;Property;_LaserPower;LaserPower;7;0;Create;True;0;0;False;0;False;10;4.62;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;330;-1567.475,-2451.811;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;285;-1631.818,-2918.083;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;338;-682.4706,-3396.652;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;334;215.3661,-3333.646;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.VoronoiNode;282;-1104.695,-2947.087;Inherit;True;0;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;2;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.Vector2Node;281;-817.2286,-2888.295;Inherit;False;Property;_SmoothStep;SmoothStep;8;0;Create;True;0;0;False;0;False;0,0.8;-0.05,0.39;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SmoothstepOpNode;250;-594.0612,-2968.476;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;347;19.87125,-3167.999;Inherit;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;286;260.5454,-3055.539;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ClampOpNode;348;516.2495,-3057.437;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,1,1,1;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;235;1268.631,-3402.54;Inherit;False;Property;_LaserStrength;LaserStrength;6;0;Create;True;0;0;False;0;False;1;1.07;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;308;774.0504,-3297.211;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;229;1526.599,-3334.905;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;342;-793.8859,-3200.87;Inherit;False;Patern;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;89;1895.67,-3310.998;Inherit;True;LaserCoreShape;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;345;-325.7202,666.4793;Inherit;True;342;Patern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;91;-306.8011,365.3091;Inherit;True;89;LaserCoreShape;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;36;-1695.54,-103.58;Inherit;False;Property;_Color1;Color 1;4;1;[HDR];Create;True;0;0;False;0;False;1,0.3057163,0,0;1,0.4966864,0.3254717,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;344;-316.029,865.9489;Inherit;False;Property;_OpacityPatern;OpacityPatern;17;0;Create;True;0;0;False;0;False;1;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;38;-1441.242,11.35144;Inherit;False;89;LaserCoreShape;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;341;-297.1099,564.7786;Inherit;False;Property;_OpacityTexture;OpacityTexture;16;0;Create;True;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;340;35.23547,439.1359;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;346;16.31637,740.3061;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;37;-1102.146,-98.03045;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;343;267.3224,496.2781;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;317;1197.462,-2795.187;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.2;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;33;-1693.186,178.2832;Inherit;False;Property;_Color0;Color 0;0;1;[HDR];Create;True;0;0;False;0;False;0.5688477,0,1,0;0.6792453,0,0.04528297,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.NormalVertexDataNode;312;-335.9307,-1001.195;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;272;-675.4869,5.998731;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;318;1169.109,-2599.288;Inherit;False;Property;_Lerp;Lerp;12;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;352;342.0204,364.7435;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;339;-595.7593,-3558.154;Inherit;False;Texture;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;32;-1107.293,186.5453;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode;208;-1802.973,-3412.996;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;746.5527,7.987968;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Tartaros/SH_LaserBeam 2;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;False;0;True;TransparentCutout;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;1;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;2;-1;-1;-1;0;True;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;47;0;46;0
WireConnection;47;1;45;2
WireConnection;56;1;315;0
WireConnection;56;3;57;0
WireConnection;56;4;58;0
WireConnection;42;0;48;0
WireConnection;42;1;47;0
WireConnection;59;0;42;0
WireConnection;59;1;56;0
WireConnection;349;0;350;0
WireConnection;349;1;351;0
WireConnection;216;0;349;2
WireConnection;43;0;59;0
WireConnection;222;0;216;0
WireConnection;222;1;349;2
WireConnection;330;0;316;4
WireConnection;330;1;331;0
WireConnection;285;0;299;0
WireConnection;285;1;309;0
WireConnection;338;0;222;0
WireConnection;338;1;337;0
WireConnection;334;0;335;0
WireConnection;334;1;338;0
WireConnection;282;0;285;0
WireConnection;282;1;330;0
WireConnection;282;2;327;0
WireConnection;250;0;282;0
WireConnection;250;1;281;1
WireConnection;250;2;281;2
WireConnection;347;0;334;0
WireConnection;286;0;347;0
WireConnection;286;1;250;0
WireConnection;348;0;286;0
WireConnection;308;0;334;0
WireConnection;308;1;348;0
WireConnection;229;0;235;0
WireConnection;229;1;308;0
WireConnection;342;0;222;0
WireConnection;89;0;229;0
WireConnection;340;0;91;0
WireConnection;340;1;341;0
WireConnection;346;0;345;0
WireConnection;346;1;344;0
WireConnection;37;0;36;0
WireConnection;37;1;38;0
WireConnection;343;0;340;0
WireConnection;343;1;346;0
WireConnection;317;2;318;0
WireConnection;272;0;37;0
WireConnection;339;0;222;0
WireConnection;32;0;33;0
WireConnection;0;2;272;0
WireConnection;0;9;343;0
ASEEND*/
//CHKSM=599F88D6A9BDEE70F0E9C5C412ABADFCFD45ECE6