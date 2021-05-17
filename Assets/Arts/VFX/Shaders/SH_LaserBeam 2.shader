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
		_Bottom("Bottom", Float) = 0.42
		_BottomImpactance("BottomImpactance", Float) = 0
		_PowerBot("PowerBot", Float) = 1.86
		_Widement("Widement", Float) = 0.13
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] _tex3coord( "", 2D ) = "white" {}
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
		uniform float _PowerBot;
		uniform float _Widement;
		uniform float _Bottom;
		uniform float _BottomImpactance;


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
			float4 temp_output_229_0 = ( _LaserStrength * ( temp_output_334_0 + clampResult348 ) );
			float4 Albedo373 = temp_output_229_0;
			o.Emission = ( ( _Color1 * Albedo373 ) + float4( 0,0,0,0 ) ).rgb;
			float2 temp_cast_2 = (_PowerBot).xx;
			float temp_output_359_0 = ( _PowerBot * -1.0 );
			float2 appendResult361 = (float2(temp_output_359_0 , ( ( _PowerBot + _Widement ) / -1.0 )));
			float2 uv_TexCoord355 = i.uv_texcoord * temp_cast_2 + appendResult361;
			float2 temp_cast_3 = (_PowerBot).xx;
			float2 appendResult385 = (float2(temp_output_359_0 , _Widement));
			float2 uv_TexCoord380 = i.uv_texcoord * temp_cast_3 + appendResult385;
			float4 temp_cast_4 = (( ( 1.0 - length( uv_TexCoord355 ) ) * ( 1.0 - length( uv_TexCoord380 ) ) )).xxxx;
			float4 LaserCoreShape89 = temp_output_229_0;
			float4 lerpResult365 = lerp( temp_cast_4 , LaserCoreShape89 , _Bottom);
			float4 Bottom368 = lerpResult365;
			float4 lerpResult375 = lerp( ( Albedo373 * _OpacityTexture ) , Bottom368 , _BottomImpactance);
			o.Alpha = lerpResult375.r;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
249;73;1146;575;36.51715;-81.77542;1;True;False
Node;AmplifyShaderEditor.TimeNode;45;-395.4768,-1423.881;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;46;-352.5932,-1571.729;Inherit;False;Property;_UV_direction;UV_direction;1;0;Create;True;0;0;False;0;False;-1,0;-1,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.CommentaryNode;30;-1915.972,-3894.345;Inherit;False;5043.442;1753.084;Comment;32;235;89;229;208;318;339;342;317;308;348;286;347;250;282;334;281;285;330;335;327;338;337;222;316;299;331;309;216;349;351;350;373;LASERSHAPE;1,1,1,1;0;0
Node;AmplifyShaderEditor.Vector2Node;48;-58.37362,-1608.911;Inherit;False;Property;_UV_tiling;UV_tiling;3;0;Create;True;0;0;False;0;False;1,1;-1,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;57;-55.6778,-1131.767;Inherit;False;Property;_RadialShear;RadialShear;5;0;Create;True;0;0;False;0;False;10,10;1,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;58;-64.44686,-1003.489;Inherit;False;Constant;_Vector1;Vector 1;7;0;Create;True;0;0;False;0;False;0.25,0.25;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TexCoordVertexDataNode;315;-342.7141,-1188.328;Inherit;False;0;3;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;47;-69.78723,-1463.468;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;42;282.1682,-1546.545;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;56;246.2455,-1192.625;Inherit;True;Radial Shear;-1;;12;c6dc9fc7fa9b08c4d95138f2ae88b526;0;4;1;FLOAT2;0,0;False;2;FLOAT2;0,0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;351;-1873.641,-3093.496;Inherit;False;Property;_TilingOffset;TilingOffset;11;0;Create;True;0;0;False;0;False;-1,-1;-1,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;350;-1886.166,-3220.152;Inherit;False;Property;_TilingWidth;TilingWidth;10;0;Create;True;0;0;False;0;False;1,3;1,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;349;-1598.073,-3114.822;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,-0.14;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;59;644.6029,-1317.952;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.OneMinusNode;216;-1517.084,-3506.595;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;43;907.2883,-1325.726;Inherit;True;UV;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;299;-1834.33,-2950.693;Inherit;False;Property;_Tiling;Tiling;9;0;Create;True;0;0;False;0;False;1,1;2,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;331;-1825.164,-2372.833;Inherit;False;Property;_PaternSpeed;PaternSpeed;14;0;Create;True;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;309;-1856.723,-2821.219;Inherit;False;43;UV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;337;-1134.168,-3560.95;Inherit;True;Property;_TextureSample0;Texture Sample 0;15;0;Create;True;0;0;False;0;False;-1;None;0000000000000000f000000000000000;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TimeNode;316;-1841.487,-2521.657;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;222;-1289.253,-3290.889;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;335;-16.23507,-3397.641;Inherit;False;Property;_LaserPower;LaserPower;7;0;Create;True;0;0;False;0;False;10;5.79;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;285;-1631.818,-2918.083;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;330;-1567.475,-2451.811;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;338;-682.4706,-3396.652;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;327;-1385.109,-2423.63;Inherit;False;Property;_PaternScale2;PaternScale2;13;0;Create;True;0;0;False;0;False;2;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;334;215.3661,-3333.646;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.Vector2Node;281;-817.2286,-2888.295;Inherit;False;Property;_SmoothStep;SmoothStep;8;0;Create;True;0;0;False;0;False;0,0.8;0.15,-0.19;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.VoronoiNode;282;-1104.695,-2947.087;Inherit;True;0;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;2;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.RangedFloatNode;358;-4669.651,-1590.212;Inherit;False;Property;_PowerBot;PowerBot;20;0;Create;True;0;0;False;0;False;1.86;7.02;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;388;-4829.248,-1341.675;Inherit;False;Property;_Widement;Widement;21;0;Create;True;0;0;False;0;False;0.13;-3.33;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;347;19.87125,-3167.999;Inherit;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SmoothstepOpNode;250;-594.0612,-2968.476;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;390;-4610.204,-1404.904;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;360;-4358.231,-1408.542;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;-1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;286;260.5454,-3055.539;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;359;-4364.695,-1499.824;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;-1;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;361;-4162.605,-1443.362;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;385;-4185.425,-1292.569;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ClampOpNode;348;516.2495,-3057.437;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,1,1,1;False;1;COLOR;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;380;-3823.535,-1298.603;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;-2,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;308;774.0504,-3297.211;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;235;825.5129,-3421.806;Inherit;False;Property;_LaserStrength;LaserStrength;6;0;Create;True;0;0;False;0;False;1;1.34;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;355;-3824.287,-1624.768;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;229;1105.958,-3318.85;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LengthOpNode;357;-3483.397,-1609.728;Inherit;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;381;-3482.645,-1283.563;Inherit;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;363;-3234.375,-1593.119;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;89;1533.815,-3496.944;Inherit;True;LaserCoreShape;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;382;-3233.623,-1266.954;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;367;-2148.461,-972.4424;Inherit;False;Property;_Bottom;Bottom;18;0;Create;True;0;0;False;0;False;0.42;1.56;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;366;-2471.546,-1047.566;Inherit;True;89;LaserCoreShape;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;379;-2890.241,-1383.882;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;373;2608.133,-3324.578;Inherit;True;Albedo;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;365;-1947.177,-1211.593;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0.64;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;36;-1695.54,-103.58;Inherit;False;Property;_Color1;Color 1;4;1;[HDR];Create;True;0;0;False;0;False;1,0.3057163,0,0;0.2981043,0.7811747,0.8207547,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;341;-476.9074,809.8203;Inherit;False;Property;_OpacityTexture;OpacityTexture;16;0;Create;True;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;91;-486.5985,610.3508;Inherit;True;373;Albedo;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;368;-1643.29,-1215.169;Inherit;False;Bottom;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;38;-1437.146,11.35144;Inherit;False;373;Albedo;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;376;-10.81433,518.9974;Inherit;False;Property;_BottomImpactance;BottomImpactance;19;0;Create;True;0;0;False;0;False;0;0.2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;369;-17.21301,420.9104;Inherit;False;368;Bottom;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;340;-144.5621,684.1776;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;37;-1102.146,-98.03045;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;345;-472.046,902.3923;Inherit;True;342;Patern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;339;-595.7593,-3558.154;Inherit;False;Texture;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;342;-793.8859,-3200.87;Inherit;False;Patern;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NormalVertexDataNode;312;-335.9307,-1001.195;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;317;1197.462,-2795.187;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.2;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;33;-1792.765,1021.051;Inherit;False;Property;_Color0;Color 0;0;1;[HDR];Create;True;0;0;False;0;False;0.5688477,0,1,0;0.6792453,0,0.04528297,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;318;1169.109,-2599.288;Inherit;False;Property;_Lerp;Lerp;12;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;375;468.8674,245.7233;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode;208;-1802.973,-3412.996;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;32;-1219.068,1000.668;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;356;-1457.112,1006.058;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;364;-2104.132,1006.901;Inherit;True;Rectangle;-1;;13;6b23e0c975270fb4084c354b2c83366a;0;3;1;FLOAT2;0,0;False;2;FLOAT;1;False;3;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;272;-381.3435,-26.42652;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;352;318.5137,951.5929;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;344;-462.3548,1101.862;Inherit;False;Property;_OpacityPatern;OpacityPatern;17;0;Create;True;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;387;-4578.591,-1280.704;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;346;-130.0095,976.219;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;746.5527,7.987968;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Tartaros/SH_LaserBeam 2;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;False;0;True;TransparentCutout;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;1;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;2;-1;-1;-1;0;True;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;47;0;46;0
WireConnection;47;1;45;2
WireConnection;42;0;48;0
WireConnection;42;1;47;0
WireConnection;56;1;315;0
WireConnection;56;3;57;0
WireConnection;56;4;58;0
WireConnection;349;0;350;0
WireConnection;349;1;351;0
WireConnection;59;0;42;0
WireConnection;59;1;56;0
WireConnection;216;0;349;2
WireConnection;43;0;59;0
WireConnection;222;0;216;0
WireConnection;222;1;349;2
WireConnection;285;0;299;0
WireConnection;285;1;309;0
WireConnection;330;0;316;4
WireConnection;330;1;331;0
WireConnection;338;0;222;0
WireConnection;338;1;337;0
WireConnection;334;0;335;0
WireConnection;334;1;338;0
WireConnection;282;0;285;0
WireConnection;282;1;330;0
WireConnection;282;2;327;0
WireConnection;347;0;334;0
WireConnection;250;0;282;0
WireConnection;250;1;281;1
WireConnection;250;2;281;2
WireConnection;390;0;358;0
WireConnection;390;1;388;0
WireConnection;360;0;390;0
WireConnection;286;0;347;0
WireConnection;286;1;250;0
WireConnection;359;0;358;0
WireConnection;361;0;359;0
WireConnection;361;1;360;0
WireConnection;385;0;359;0
WireConnection;385;1;388;0
WireConnection;348;0;286;0
WireConnection;380;0;358;0
WireConnection;380;1;385;0
WireConnection;308;0;334;0
WireConnection;308;1;348;0
WireConnection;355;0;358;0
WireConnection;355;1;361;0
WireConnection;229;0;235;0
WireConnection;229;1;308;0
WireConnection;357;0;355;0
WireConnection;381;0;380;0
WireConnection;363;0;357;0
WireConnection;89;0;229;0
WireConnection;382;0;381;0
WireConnection;379;0;363;0
WireConnection;379;1;382;0
WireConnection;373;0;229;0
WireConnection;365;0;379;0
WireConnection;365;1;366;0
WireConnection;365;2;367;0
WireConnection;368;0;365;0
WireConnection;340;0;91;0
WireConnection;340;1;341;0
WireConnection;37;0;36;0
WireConnection;37;1;38;0
WireConnection;339;0;222;0
WireConnection;342;0;222;0
WireConnection;317;2;318;0
WireConnection;375;0;340;0
WireConnection;375;1;369;0
WireConnection;375;2;376;0
WireConnection;272;0;37;0
WireConnection;346;0;345;0
WireConnection;346;1;344;0
WireConnection;0;2;272;0
WireConnection;0;9;375;0
ASEEND*/
//CHKSM=ADFCB355AFDF253724C5DC96D7DF8CB5A24B9825