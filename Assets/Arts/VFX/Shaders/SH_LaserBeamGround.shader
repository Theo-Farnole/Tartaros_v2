// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_LaserBeamGround"
{
	Properties
	{
		_UV_direction("UV_direction", Vector) = (-1,0,0,0)
		_UV_tiling("UV_tiling", Vector) = (1,1,0,0)
		[HDR]_Color1("Color 1", Color) = (1,0.3057163,0,0)
		_RadialShear("RadialShear", Vector) = (10,10,0,0)
		_LaserStrength("LaserStrength", Float) = 10
		_SmoothStep("SmoothStep", Vector) = (0,0.8,0,0)
		_Tiling("Tiling", Vector) = (1,1,0,0)
		_PaternScale2("PaternScale2", Float) = 0
		_PaternSpeed("PaternSpeed", Float) = 0
		_OpacityPatern("OpacityPatern", Float) = 0
		_LaserSmoothStep("LaserSmoothStep", Vector) = (0,0,0,0)
		_LerpPatern("LerpPatern", Float) = 0
		_PaternLerpSmooth("PaternLerpSmooth", Vector) = (0,0,0,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] _tex3coord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Off
		Blend SrcAlpha DstAlpha
		
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
		uniform float2 _LaserSmoothStep;
		uniform float _LerpPatern;
		uniform float2 _SmoothStep;
		uniform float _PaternScale2;
		uniform float _PaternSpeed;
		uniform float2 _Tiling;
		uniform float2 _UV_tiling;
		uniform float2 _UV_direction;
		uniform float2 _RadialShear;
		uniform float2 _PaternLerpSmooth;
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
			float2 uv_TexCoord353 = i.uv_texcoord * float2( 2,2 ) + float2( -1,-1 );
			float lerpResult357 = lerp( ( 1.0 - length( uv_TexCoord353 ) ) , length( uv_TexCoord353 ) , _LerpPatern);
			float smoothstepResult354 = smoothstep( _LaserSmoothStep.x , _LaserSmoothStep.y , lerpResult357);
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
			float clampResult348 = clamp( ( ( 1.0 - smoothstepResult354 ) * smoothstepResult250 ) , 0.0 , 1.0 );
			float temp_output_350_0 = ( 1.0 - lerpResult357 );
			float smoothstepResult362 = smoothstep( _PaternLerpSmooth.x , _PaternLerpSmooth.y , temp_output_350_0);
			float LaserCoreShape89 = ( _LaserStrength * ( 1.0 - ( smoothstepResult354 + clampResult348 + smoothstepResult362 ) ) );
			o.Emission = ( ( _Color1 * LaserCoreShape89 ) + float4( 0,0,0,0 ) ).rgb;
			float Patern342 = temp_output_350_0;
			o.Alpha = ( Patern342 * _OpacityPatern );
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
249;73;1306;655;103.8512;3478.617;1.126283;True;False
Node;AmplifyShaderEditor.TimeNode;45;-395.4768,-1423.881;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;46;-352.5932,-1571.729;Inherit;False;Property;_UV_direction;UV_direction;1;0;Create;True;0;0;False;0;False;-1,0;1,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TexCoordVertexDataNode;315;-80.51418,-1262.58;Inherit;False;0;3;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;57;213.353,-1241.54;Inherit;False;Property;_RadialShear;RadialShear;5;0;Create;True;0;0;False;0;False;10,10;1,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;48;-58.37362,-1608.911;Inherit;False;Property;_UV_tiling;UV_tiling;3;0;Create;True;0;0;False;0;False;1,1;1,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;58;197.753,-1077.74;Inherit;False;Constant;_Vector1;Vector 1;7;0;Create;True;0;0;False;0;False;0.25,0.25;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;47;-69.78723,-1463.468;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;42;282.1682,-1546.545;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;56;508.4454,-1266.877;Inherit;True;Radial Shear;-1;;12;c6dc9fc7fa9b08c4d95138f2ae88b526;0;4;1;FLOAT2;0,0;False;2;FLOAT2;0,0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.CommentaryNode;30;-1915.972,-3894.345;Inherit;False;4099.005;1764.964;Comment;36;89;208;216;229;235;250;281;282;285;286;299;308;309;316;317;318;327;330;331;334;335;337;339;342;347;348;351;352;353;354;355;357;350;360;362;363;LASERSHAPE;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleAddOpNode;59;577.3126,-1459.493;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;353;-1806.543,-3437.939;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;2,2;False;1;FLOAT2;-1,-1;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LengthOpNode;352;-1526.308,-3483.711;Inherit;False;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;43;786.6296,-1562.401;Inherit;True;UV;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TimeNode;316;-1841.487,-2521.657;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LengthOpNode;351;-1524.669,-3385.337;Inherit;False;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;331;-1825.164,-2372.833;Inherit;False;Property;_PaternSpeed;PaternSpeed;12;0;Create;True;0;0;False;0;False;0;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;216;-1386.163,-3535.69;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;360;-1534.233,-3256.06;Inherit;False;Property;_LerpPatern;LerpPatern;17;0;Create;True;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;309;-1825.425,-2646.631;Inherit;False;43;UV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;299;-1809.712,-2796.671;Inherit;False;Property;_Tiling;Tiling;9;0;Create;True;0;0;False;0;False;1,1;1,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;355;-471.5057,-3240.208;Inherit;False;Property;_LaserSmoothStep;LaserSmoothStep;16;0;Create;True;0;0;False;0;False;0,0;0.9,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;327;-1563.224,-2263.286;Inherit;False;Property;_PaternScale2;PaternScale2;11;0;Create;True;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;285;-1467.16,-2739.955;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;330;-1567.475,-2451.811;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;357;-1188.065,-3415.554;Inherit;True;3;0;FLOAT;1.03;False;1;FLOAT;-3.3;False;2;FLOAT;3.23;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;281;-864.7897,-2423.25;Inherit;False;Property;_SmoothStep;SmoothStep;8;0;Create;True;0;0;False;0;False;0,0.8;0,0.5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.VoronoiNode;282;-1092.32,-2519.243;Inherit;True;0;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;2;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SmoothstepOpNode;354;-201.4403,-3309.501;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;250;-594.0611,-2516.642;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;347;110.1429,-3207.47;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;286;420.7759,-3034.768;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;363;410.3298,-3536.138;Inherit;False;Property;_PaternLerpSmooth;PaternLerpSmooth;18;0;Create;True;0;0;False;0;False;0,0;1,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.OneMinusNode;350;-919.9327,-3138.268;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;348;677.889,-3036.666;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;362;680.9379,-3386.468;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0.89;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;308;934.2808,-3276.44;Inherit;True;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;356;1267.521,-3201.183;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;235;1268.631,-3402.54;Inherit;False;Property;_LaserStrength;LaserStrength;6;0;Create;True;0;0;False;0;False;10;1.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;229;1526.599,-3334.905;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;89;1895.67,-3310.998;Inherit;True;LaserCoreShape;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;36;-1695.54,-103.58;Inherit;False;Property;_Color1;Color 1;4;1;[HDR];Create;True;0;0;False;0;False;1,0.3057163,0,0;2,0.8727273,0,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;38;-1441.242,11.35144;Inherit;False;89;LaserCoreShape;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;342;-711.578,-3077.06;Inherit;False;Patern;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;37;-1102.146,-98.03045;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;344;-316.029,865.9489;Inherit;False;Property;_OpacityPatern;OpacityPatern;15;0;Create;True;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;345;-325.7202,666.4793;Inherit;True;342;Patern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;334;94.36098,-3712.445;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NormalVertexDataNode;312;-25.9142,-1074.08;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TexCoordVertexDataNode;208;-1826.717,-3234.826;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;32;-1107.293,186.5453;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;318;1169.109,-2599.288;Inherit;False;Property;_Lerp;Lerp;10;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;91;-306.8011,365.3091;Inherit;True;339;Texture;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;337;-887.1485,-3750.455;Inherit;True;Property;_TextureSample0;Texture Sample 0;13;0;Create;True;0;0;False;0;False;-1;None;0000000000000000f000000000000000;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;346;16.31637,740.3061;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;33;-1693.186,178.2832;Inherit;False;Property;_Color0;Color 0;0;1;[HDR];Create;True;0;0;False;0;False;0.5688477,0,1,0;0.6792453,0,0.04528297,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;335;-167.0532,-3716.814;Inherit;False;Property;_LaserPower;LaserPower;7;0;Create;True;0;0;False;0;False;10;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;341;-297.1099,564.7786;Inherit;False;Property;_OpacityTexture;OpacityTexture;14;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;339;-554.5593,-3573.255;Inherit;False;Texture;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;338;-709.7704,-3319.952;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;340;35.23547,439.1359;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;343;202.7224,414.5781;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;272;-675.4869,5.998731;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;317;1197.462,-2795.187;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.2;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;746.5527,7.987968;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Tartaros/SH_LaserBeamGround;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;False;0;True;TransparentCutout;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;1;5;False;-1;7;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;2;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;47;0;46;0
WireConnection;47;1;45;2
WireConnection;42;0;48;0
WireConnection;42;1;47;0
WireConnection;56;1;315;0
WireConnection;56;3;57;0
WireConnection;56;4;58;0
WireConnection;59;0;42;0
WireConnection;59;1;56;0
WireConnection;352;0;353;0
WireConnection;43;0;59;0
WireConnection;351;0;353;0
WireConnection;216;0;352;0
WireConnection;285;0;299;0
WireConnection;285;1;309;0
WireConnection;330;0;316;4
WireConnection;330;1;331;0
WireConnection;357;0;216;0
WireConnection;357;1;351;0
WireConnection;357;2;360;0
WireConnection;282;0;285;0
WireConnection;282;1;330;0
WireConnection;282;2;327;0
WireConnection;354;0;357;0
WireConnection;354;1;355;1
WireConnection;354;2;355;2
WireConnection;250;0;282;0
WireConnection;250;1;281;1
WireConnection;250;2;281;2
WireConnection;347;0;354;0
WireConnection;286;0;347;0
WireConnection;286;1;250;0
WireConnection;350;0;357;0
WireConnection;348;0;286;0
WireConnection;362;0;350;0
WireConnection;362;1;363;1
WireConnection;362;2;363;2
WireConnection;308;0;354;0
WireConnection;308;1;348;0
WireConnection;308;2;362;0
WireConnection;356;0;308;0
WireConnection;229;0;235;0
WireConnection;229;1;356;0
WireConnection;89;0;229;0
WireConnection;342;0;350;0
WireConnection;37;0;36;0
WireConnection;37;1;38;0
WireConnection;334;0;335;0
WireConnection;32;0;33;0
WireConnection;346;0;345;0
WireConnection;346;1;344;0
WireConnection;339;0;337;0
WireConnection;338;1;337;0
WireConnection;340;0;91;0
WireConnection;340;1;341;0
WireConnection;272;0;37;0
WireConnection;317;2;318;0
WireConnection;0;2;272;0
WireConnection;0;9;346;0
ASEEND*/
//CHKSM=6B501479E6604BBA02DC5E0EEB99431E26C8ADAA