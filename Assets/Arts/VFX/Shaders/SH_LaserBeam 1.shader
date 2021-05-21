// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_LaserBeam 1"
{
	Properties
	{
		[HDR]_Color0("Color 0", Color) = (0.5688477,0,1,0)
		[HDR]_Color1("Color 1", Color) = (1,0.3057163,0,0)
		_RadialShear("RadialShear", Vector) = (10,10,0,0)
		_LaserStrength("LaserStrength", Float) = 0
		_LaserRimPatern("LaserRimPatern", Float) = 1
		_ShearOffset("ShearOffset", Vector) = (0.25,0.25,0,0)
		_LaserWidth("LaserWidth", Vector) = (0,0,0,0)
		_OffsetRimPattern("OffsetRimPattern", Vector) = (-5,0,0,0)
		_TilingRimPattern("TilingRimPattern", Vector) = (0,0,0,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Off
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard alpha:fade keepalpha noshadow 
		struct Input
		{
			float3 worldNormal;
			INTERNAL_DATA
			float3 worldPos;
			float2 uv_texcoord;
		};

		uniform float4 _LaserWidth;
		uniform float _LaserStrength;
		uniform float4 _Color1;
		uniform float4 _Color0;
		uniform float3 _TilingRimPattern;
		uniform float2 _RadialShear;
		uniform float2 _ShearOffset;
		uniform float2 _OffsetRimPattern;
		uniform float _LaserRimPatern;


		float2 voronoihash107( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi107( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash107( n + g );
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
			float3 ase_worldNormal = WorldNormalVector( i, float3( 0, 0, 1 ) );
			float3 ase_worldPos = i.worldPos;
			float3 temp_output_16_0_g7 = ( ase_worldPos * 100.0 );
			float3 crossY18_g7 = cross( ase_worldNormal , ddy( temp_output_16_0_g7 ) );
			float3 worldDerivativeX2_g7 = ddx( temp_output_16_0_g7 );
			float dotResult6_g7 = dot( crossY18_g7 , worldDerivativeX2_g7 );
			float crossYDotWorldDerivX34_g7 = abs( dotResult6_g7 );
			float4 temp_cast_0 = (( 1.0 - _LaserWidth.y )).xxxx;
			float temp_output_222_0 = ( ( 1.0 - i.uv_texcoord.y ) * i.uv_texcoord.y );
			float4 temp_cast_1 = (temp_output_222_0).xxxx;
			float4 color246 = IsGammaSpace() ? float4(1,1,1,1) : float4(1,1,1,1);
			float4 lerpResult239 = lerp( temp_cast_1 , color246 , float4( 0,0,0,0 ));
			float4 smoothstepResult250 = smoothstep( temp_cast_0 , float4( 1,1,1,1 ) , lerpResult239);
			float grayscale127 = Luminance(smoothstepResult250.rgb);
			float temp_output_229_0 = ( grayscale127 * _LaserStrength );
			float LaserCoreShape89 = temp_output_229_0;
			float3 temp_cast_3 = (LaserCoreShape89).xxx;
			float grayscale193 = Luminance(temp_cast_3);
			float temp_output_20_0_g7 = grayscale193;
			float3 crossX19_g7 = cross( ase_worldNormal , worldDerivativeX2_g7 );
			float3 break29_g7 = ( sign( crossYDotWorldDerivX34_g7 ) * ( ( ddx( temp_output_20_0_g7 ) * crossY18_g7 ) + ( ddy( temp_output_20_0_g7 ) * crossX19_g7 ) ) );
			float3 appendResult30_g7 = (float3(break29_g7.x , -break29_g7.y , break29_g7.z));
			float3 normalizeResult39_g7 = normalize( ( ( crossYDotWorldDerivX34_g7 * ase_worldNormal ) - appendResult30_g7 ) );
			o.Normal = normalizeResult39_g7;
			float4 temp_cast_4 = (( 1.0 - _LaserWidth.x )).xxxx;
			float4 temp_cast_5 = (( 1.0 - temp_output_222_0 )).xxxx;
			float4 lerpResult244 = lerp( temp_cast_5 , color246 , float4( 0,0,0,0 ));
			float4 smoothstepResult252 = smoothstep( temp_cast_4 , float4( 1,1,1,1 ) , lerpResult244);
			float grayscale245 = Luminance(smoothstepResult252.rgb);
			float4 temp_cast_7 = (( 1.0 - _LaserWidth.z )).xxxx;
			float4 smoothstepResult261 = smoothstep( temp_cast_7 , float4( 0.1981132,0.1981132,0.1981132,1 ) , lerpResult239);
			float4 temp_cast_8 = (temp_output_229_0).xxxx;
			float time107 = _Time.w;
			float3 ase_vertex3Pos = mul( unity_WorldToObject, float4( i.worldPos , 1 ) );
			float2 temp_cast_9 = (( ( ase_vertex3Pos.x + _TilingRimPattern.x ) + ( ase_vertex3Pos.y + _TilingRimPattern.y ) + ( ase_vertex3Pos.z + _TilingRimPattern.z ) )).xx;
			float2 temp_output_1_0_g8 = temp_cast_9;
			float2 temp_output_11_0_g8 = ( temp_output_1_0_g8 - float2( 0.5,0.5 ) );
			float2 break18_g8 = temp_output_11_0_g8;
			float2 appendResult19_g8 = (float2(break18_g8.y , -break18_g8.x));
			float dotResult12_g8 = dot( temp_output_11_0_g8 , temp_output_11_0_g8 );
			float2 uv_TexCoord108 = i.uv_texcoord * ( temp_output_1_0_g8 + ( appendResult19_g8 * ( dotResult12_g8 * _RadialShear ) ) + _ShearOffset ) + ( _OffsetRimPattern * _Time.y );
			float2 coords107 = uv_TexCoord108 * 1.0;
			float2 id107 = 0;
			float2 uv107 = 0;
			float fade107 = 0.5;
			float voroi107 = 0;
			float rest107 = 0;
			for( int it107 = 0; it107 <8; it107++ ){
			voroi107 += fade107 * voronoi107( coords107, time107, id107, uv107, 0 );
			rest107 += fade107;
			coords107 *= 2;
			fade107 *= 0.5;
			}//Voronoi107
			voroi107 /= rest107;
			float grayscale274 = Luminance(( ( ( ( grayscale245 * smoothstepResult261 ) - temp_cast_8 ) * _LaserWidth.w ) * ( voroi107 * _LaserRimPatern ) ).rgb);
			float LaserRimShape271 = grayscale274;
			o.Emission = ( ( _Color1 * LaserCoreShape89 ) + ( _Color0 * LaserRimShape271 * LaserRimShape271 ) ).rgb;
			float temp_output_91_0 = LaserCoreShape89;
			o.Alpha = temp_output_91_0;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
297;73;1213;552;2307.072;3120.46;1.371953;True;False
Node;AmplifyShaderEditor.CommentaryNode;30;-1915.972,-3894.345;Inherit;False;4099.005;1764.964;Comment;41;110;89;127;208;216;222;229;235;239;241;244;243;245;246;250;252;253;261;251;263;264;266;267;270;271;205;109;210;108;107;189;273;274;279;281;284;283;287;288;290;289;LASERSHAPE;1,1,1,1;0;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode;208;-1779.17,-3285.653;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;216;-1257.265,-3544.432;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;222;-1186.617,-3290.889;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;281;-1750.135,-2937.355;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;246;-1036.543,-3669.657;Inherit;False;Constant;_Color2;Color 2;8;0;Create;True;0;0;False;0;False;1,1,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector3Node;290;-1752.802,-2799.425;Inherit;False;Property;_TilingRimPattern;TilingRimPattern;11;0;Create;True;0;0;False;0;False;0,0,0;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.OneMinusNode;243;-945.7813,-3391.338;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector4Node;270;-845.3169,-2920.405;Inherit;False;Property;_LaserWidth;LaserWidth;9;0;Create;True;0;0;False;0;False;0,0,0,0;1,0.85,1,10;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;287;-1473.328,-2897.145;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;288;-1477.836,-2803.591;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;289;-1485.271,-2708.875;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;244;-678.791,-3545.59;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;-5,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;239;-789.5009,-3297.878;Inherit;True;3;0;COLOR;0.5,0,0,0;False;1;COLOR;1,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;251;-539.0348,-3030.052;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;266;-542.8231,-2963.437;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;109;-1468.469,-2432.588;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;250;-493.6425,-3260.217;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,1;False;2;COLOR;1,1,1,1;False;1;COLOR;0
Node;AmplifyShaderEditor.Vector2Node;110;-1443.464,-2581.002;Inherit;False;Property;_OffsetRimPattern;OffsetRimPattern;10;0;Create;True;0;0;False;0;False;-5,0;1,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleAddOpNode;284;-1266.5,-2763.551;Inherit;True;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;263;-535.9833,-2882.812;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;57;-1441.077,-2157.856;Inherit;False;Property;_RadialShear;RadialShear;4;0;Create;True;0;0;False;0;False;10,10;0,2;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SmoothstepOpNode;252;-396.1021,-3541.862;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0.5283019,0.5283019,0.5283019,1;False;2;COLOR;1,1,1,1;False;1;COLOR;0
Node;AmplifyShaderEditor.Vector2Node;58;-1456.676,-1994.056;Inherit;False;Property;_ShearOffset;ShearOffset;8;0;Create;True;0;0;False;0;False;0.25,0.25;-5,130;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.FunctionNode;56;-979.5363,-2272.582;Inherit;True;Radial Shear;-1;;8;c6dc9fc7fa9b08c4d95138f2ae88b526;0;4;1;FLOAT2;0,0;False;2;FLOAT2;0,0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SmoothstepOpNode;261;-276.248,-2933.141;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,1;False;2;COLOR;0.1981132,0.1981132,0.1981132,1;False;1;COLOR;0
Node;AmplifyShaderEditor.TFHCGrayscale;127;-195.9098,-3245.771;Inherit;True;0;1;0;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;235;50.34917,-3397.696;Inherit;False;Property;_LaserStrength;LaserStrength;5;0;Create;True;0;0;False;0;False;0;60;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;210;-1232.391,-2542.797;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TFHCGrayscale;245;-202.8484,-3610.828;Inherit;True;0;1;0;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;264;92.41144,-3067.726;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;108;-1034.34,-2575.625;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;229;209.9098,-3606.643;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;273;427.1549,-3361.583;Inherit;False;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.VoronoiNode;107;-671.0635,-2560.001;Inherit;True;2;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.RangedFloatNode;205;-234.7359,-2286.576;Inherit;False;Property;_LaserRimPatern;LaserRimPatern;6;0;Create;True;0;0;False;0;False;1;4.3;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;189;-102.3922,-2474.621;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;10;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;267;588.4796,-3180.719;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;1;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;241;755.6044,-2890.186;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.TFHCGrayscale;274;1078.55,-2993.796;Inherit;True;0;1;0;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;271;1427.267,-3184.507;Inherit;True;LaserRimShape;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;89;1424.105,-3457.344;Inherit;True;LaserCoreShape;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;33;-1693.186,178.2832;Inherit;False;Property;_Color0;Color 0;0;1;[HDR];Create;True;0;0;False;0;False;0.5688477,0,1,0;0.05990553,1,0,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;31;-1406.659,252.6218;Inherit;False;271;LaserRimShape;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;91;-309.8011,367.3091;Inherit;True;89;LaserCoreShape;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;36;-1695.54,-103.58;Inherit;False;Property;_Color1;Color 1;3;1;[HDR];Create;True;0;0;False;0;False;1,0.3057163,0,0;0.2981043,0.7811747,0.8207547,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;38;-1417.125,-3.288098;Inherit;False;89;LaserCoreShape;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;37;-1102.146,-98.03045;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.TFHCGrayscale;193;-41.08451,138.6413;Inherit;True;0;1;0;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;32;-1107.293,186.5453;Inherit;True;3;3;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.WorldPosInputsNode;279;-1861.899,-2590.752;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleAddOpNode;272;-675.4869,5.998731;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.Vector2Node;48;-59.75698,-1608.911;Inherit;False;Property;_UV_tiling;UV_tiling;2;0;Create;True;0;0;False;0;False;1,1;1,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;46;-352.5932,-1571.729;Inherit;False;Property;_UV_direction;UV_direction;1;0;Create;True;0;0;False;0;False;-1,0;-1,3;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TimeNode;45;-395.4768,-1423.881;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;59;577.3126,-1459.493;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;42;282.1682,-1546.545;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;43;786.6296,-1562.401;Inherit;True;UV;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;253;-1355.5,-3050.476;Inherit;False;Property;_RimTiling;RimTiling;7;0;Create;True;0;0;False;0;False;0,0;0.01,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;283;-1515.81,-3053.931;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;47;-69.78723,-1463.468;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.FunctionNode;194;264.9756,155.8619;Inherit;False;Normal From Height;-1;;7;1942fe2c5f1a1f94881a33d532e4afeb;0;1;20;FLOAT;0;False;2;FLOAT3;40;FLOAT3;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;746.5527,7.987968;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Tartaros/SH_LaserBeam 1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;216;0;208;2
WireConnection;222;0;216;0
WireConnection;222;1;208;2
WireConnection;243;0;222;0
WireConnection;287;0;281;1
WireConnection;287;1;290;1
WireConnection;288;0;281;2
WireConnection;288;1;290;2
WireConnection;289;0;281;3
WireConnection;289;1;290;3
WireConnection;244;0;243;0
WireConnection;244;1;246;0
WireConnection;239;0;222;0
WireConnection;239;1;246;0
WireConnection;251;0;270;1
WireConnection;266;0;270;2
WireConnection;250;0;239;0
WireConnection;250;1;266;0
WireConnection;284;0;287;0
WireConnection;284;1;288;0
WireConnection;284;2;289;0
WireConnection;263;0;270;3
WireConnection;252;0;244;0
WireConnection;252;1;251;0
WireConnection;56;1;284;0
WireConnection;56;3;57;0
WireConnection;56;4;58;0
WireConnection;261;0;239;0
WireConnection;261;1;263;0
WireConnection;127;0;250;0
WireConnection;210;0;110;0
WireConnection;210;1;109;2
WireConnection;245;0;252;0
WireConnection;264;0;245;0
WireConnection;264;1;261;0
WireConnection;108;0;56;0
WireConnection;108;1;210;0
WireConnection;229;0;127;0
WireConnection;229;1;235;0
WireConnection;273;0;264;0
WireConnection;273;1;229;0
WireConnection;107;0;108;0
WireConnection;107;1;109;4
WireConnection;189;0;107;0
WireConnection;189;1;205;0
WireConnection;267;0;273;0
WireConnection;267;1;270;4
WireConnection;241;0;267;0
WireConnection;241;1;189;0
WireConnection;274;0;241;0
WireConnection;271;0;274;0
WireConnection;89;0;229;0
WireConnection;37;0;36;0
WireConnection;37;1;38;0
WireConnection;193;0;91;0
WireConnection;32;0;33;0
WireConnection;32;1;31;0
WireConnection;32;2;31;0
WireConnection;272;0;37;0
WireConnection;272;1;32;0
WireConnection;42;0;48;0
WireConnection;42;1;47;0
WireConnection;43;0;42;0
WireConnection;47;0;46;0
WireConnection;47;1;45;2
WireConnection;194;20;193;0
WireConnection;0;1;194;0
WireConnection;0;2;272;0
WireConnection;0;9;91;0
ASEEND*/
//CHKSM=674894E6E442ABA59706CE01594F3AED65AE18DE