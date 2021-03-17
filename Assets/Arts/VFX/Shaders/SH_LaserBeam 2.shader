// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_LaserBeam 2"
{
	Properties
	{
		_UV_direction("UV_direction", Vector) = (-1,0,0,0)
		_UV_tiling("UV_tiling", Vector) = (1,1,0,0)
		[HDR]_Color1("Color 1", Color) = (1,0.3057163,0,0)
		_LaserStrength("LaserStrength", Float) = 10
		_LaserPower("LaserPower", Float) = 10
		_Tiling("Tiling", Vector) = (1,1,0,0)
		_PaternScale1("PaternScale1", Float) = 0
		_PaternScale2("PaternScale2", Float) = 0
		_PaternSpeed("PaternSpeed", Float) = 0
		_PaternSpeed2("PaternSpeed2", Float) = 0
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_OpacityTexture("OpacityTexture", Float) = 0
		_OpacityPatern("OpacityPatern", Float) = 0
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
			float2 uv_texcoord;
		};

		uniform float4 _Color1;
		uniform float _LaserStrength;
		uniform float _LaserPower;
		uniform sampler2D _TextureSample0;
		uniform float4 _TextureSample0_ST;
		uniform float _PaternScale2;
		uniform float _PaternSpeed;
		uniform float2 _Tiling;
		uniform float2 _UV_tiling;
		uniform float2 _UV_direction;
		uniform float _PaternScale1;
		uniform float _PaternSpeed2;
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


		float2 voronoihash288( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi288( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash288( n + g );
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


		float2 voronoihash289( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi289( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash289( n + g );
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


		float2 voronoihash290( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi290( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash290( n + g );
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
			float temp_output_222_0 = ( ( 1.0 - i.uv_texcoord.y ) * i.uv_texcoord.y );
			float2 uv_TextureSample0 = i.uv_texcoord * _TextureSample0_ST.xy + _TextureSample0_ST.zw;
			float4 tex2DNode337 = tex2D( _TextureSample0, uv_TextureSample0 );
			float4 temp_output_338_0 = ( temp_output_222_0 * tex2DNode337 );
			float temp_output_330_0 = ( _Time.w * _PaternSpeed );
			float time282 = temp_output_330_0;
			float2 uv_TexCoord42 = i.uv_texcoord * _UV_tiling + ( _UV_direction * _Time.y );
			float2 UV43 = uv_TexCoord42;
			float2 uv_TexCoord285 = i.uv_texcoord * _Tiling + UV43;
			float2 coords282 = uv_TexCoord285 * _PaternScale2;
			float2 id282 = 0;
			float2 uv282 = 0;
			float voroi282 = voronoi282( coords282, time282, id282, uv282, 0 );
			float time288 = temp_output_330_0;
			float2 coords288 = uv_TexCoord285 * _PaternScale2;
			float2 id288 = 0;
			float2 uv288 = 0;
			float fade288 = 0.5;
			float voroi288 = 0;
			float rest288 = 0;
			for( int it288 = 0; it288 <8; it288++ ){
			voroi288 += fade288 * voronoi288( coords288, time288, id288, uv288, 0 );
			rest288 += fade288;
			coords288 *= 2;
			fade288 *= 0.5;
			}//Voronoi288
			voroi288 /= rest288;
			float temp_output_333_0 = ( _Time.w * _PaternSpeed2 );
			float time289 = temp_output_333_0;
			float2 coords289 = uv_TexCoord285 * _PaternScale1;
			float2 id289 = 0;
			float2 uv289 = 0;
			float voroi289 = voronoi289( coords289, time289, id289, uv289, 0 );
			float time290 = temp_output_333_0;
			float2 coords290 = uv_TexCoord285 * _PaternScale1;
			float2 id290 = 0;
			float2 uv290 = 0;
			float fade290 = 0.5;
			float voroi290 = 0;
			float rest290 = 0;
			for( int it290 = 0; it290 <8; it290++ ){
			voroi290 += fade290 * voronoi290( coords290, time290, id290, uv290, 0 );
			rest290 += fade290;
			coords290 *= 2;
			fade290 *= 0.5;
			}//Voronoi290
			voroi290 /= rest290;
			float temp_output_303_0 = ( ( voroi282 * voroi288 ) / ( voroi289 * voroi290 ) );
			float temp_output_329_0 = ( ( voroi282 / voroi288 ) / ( voroi289 / voroi290 ) );
			float temp_output_306_0 = ( temp_output_303_0 * temp_output_329_0 );
			float4 LaserCoreShape89 = ( _LaserStrength * ( ( _LaserPower * temp_output_338_0 ) + ( temp_output_338_0 * temp_output_306_0 ) ) );
			o.Emission = ( ( _Color1 * LaserCoreShape89 ) + float4( 0,0,0,0 ) ).rgb;
			float4 Texture339 = tex2DNode337;
			float Patern342 = temp_output_222_0;
			o.Alpha = ( ( Texture339 * _OpacityTexture ) + ( Patern342 * _OpacityPatern ) ).r;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
272;73;1265;549;630.9777;-257.0782;1.3;True;False
Node;AmplifyShaderEditor.TimeNode;45;-395.4768,-1423.881;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;46;-352.5932,-1571.729;Inherit;False;Property;_UV_direction;UV_direction;1;0;Create;True;0;0;False;0;False;-1,0;-1,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;47;-69.78723,-1463.468;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;48;-58.37362,-1608.911;Inherit;False;Property;_UV_tiling;UV_tiling;2;0;Create;True;0;0;False;0;False;1,1;1,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;42;282.1682,-1546.545;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;43;786.6296,-1562.401;Inherit;True;UV;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.CommentaryNode;30;-1915.972,-3894.345;Inherit;False;4099.005;1764.964;Comment;39;89;208;216;222;229;235;250;281;282;285;288;287;289;290;286;292;299;303;305;306;307;308;309;316;317;318;326;327;328;329;330;331;332;333;334;335;337;339;342;LASERSHAPE;1,1,1,1;0;0
Node;AmplifyShaderEditor.GetLocalVarNode;309;-1726.95,-2612.032;Inherit;False;43;UV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;299;-1622.109,-2809.883;Inherit;False;Property;_Tiling;Tiling;8;0;Create;True;0;0;False;0;False;1,1;5,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;332;-1823.028,-2304.882;Inherit;False;Property;_PaternSpeed2;PaternSpeed2;13;0;Create;True;0;0;False;0;False;0;3;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;331;-1825.164,-2372.833;Inherit;False;Property;_PaternSpeed;PaternSpeed;12;0;Create;True;0;0;False;0;False;0;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;316;-1841.487,-2521.657;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;326;-1327.061,-2336.049;Inherit;False;Property;_PaternScale1;PaternScale1;10;0;Create;True;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;285;-1673.889,-2947.074;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;333;-1570.681,-2366.478;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;327;-1505.163,-2682.3;Inherit;False;Property;_PaternScale2;PaternScale2;11;0;Create;True;0;0;False;0;False;0;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;330;-1567.475,-2451.811;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;288;-1325.817,-2775.789;Inherit;True;0;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;2;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.VoronoiNode;282;-1322.2,-3050.347;Inherit;True;0;0;1;0;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;2;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.TexCoordVertexDataNode;208;-1779.17,-3285.653;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VoronoiNode;290;-1083.935,-2415.019;Inherit;True;0;0;1;3;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.VoronoiNode;289;-1080.318,-2689.576;Inherit;True;0;0;1;3;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.OneMinusNode;216;-1257.265,-3544.432;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;305;-560.9979,-2440.399;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;287;-941.591,-2957.564;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;292;-855.3932,-2505.052;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;307;-428.3354,-2961.24;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;303;-555.1653,-2703.49;Inherit;True;2;0;FLOAT;0.06;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;337;-943.068,-3593.45;Inherit;True;Property;_TextureSample0;Texture Sample 0;14;0;Create;True;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;222;-1289.253,-3290.889;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;329;-298.1898,-2586.961;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;306;-36.2245,-2700.539;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;338;-709.7704,-3319.952;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;335;-16.23507,-3397.641;Inherit;False;Property;_LaserPower;LaserPower;6;0;Create;True;0;0;False;0;False;10;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;334;215.3661,-3333.646;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;286;192.3902,-3109.662;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;308;540.5251,-3297.211;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;235;1268.631,-3402.54;Inherit;False;Property;_LaserStrength;LaserStrength;5;0;Create;True;0;0;False;0;False;10;7.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;229;1526.599,-3334.905;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;89;1895.67,-3310.998;Inherit;True;LaserCoreShape;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;342;-965.397,-3187.021;Inherit;False;Patern;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;339;-554.5593,-3573.255;Inherit;False;Texture;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;38;-1441.242,11.35144;Inherit;False;89;LaserCoreShape;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;345;-325.7202,666.4793;Inherit;True;342;Patern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;36;-1695.54,-103.58;Inherit;False;Property;_Color1;Color 1;3;1;[HDR];Create;True;0;0;False;0;False;1,0.3057163,0,0;0.608554,0.4198113,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;91;-306.8011,365.3091;Inherit;True;339;Texture;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;344;-316.029,865.9489;Inherit;False;Property;_OpacityPatern;OpacityPatern;16;0;Create;True;0;0;False;0;False;0;0.63;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;341;-297.1099,564.7786;Inherit;False;Property;_OpacityTexture;OpacityTexture;15;0;Create;True;0;0;False;0;False;0;0.63;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;346;16.31637,740.3061;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;340;35.23547,439.1359;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;37;-1102.146,-98.03045;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;317;493.8606,-2919.47;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.2;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;318;465.5068,-2723.571;Inherit;False;Property;_Lerp;Lerp;9;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode;315;-80.51418,-1262.58;Inherit;False;0;3;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;32;-1107.293,186.5453;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.Vector2Node;58;197.753,-1077.74;Inherit;False;Constant;_Vector1;Vector 1;7;0;Create;True;0;0;False;0;False;0.25,0.25;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.ColorNode;33;-1693.186,178.2832;Inherit;False;Property;_Color0;Color 0;0;1;[HDR];Create;True;0;0;False;0;False;0.5688477,0,1,0;0.6792453,0,0.04528297,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;57;213.353,-1241.54;Inherit;False;Property;_RadialShear;RadialShear;4;0;Create;True;0;0;False;0;False;10,10;10,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.FunctionNode;194;264.9756,155.8619;Inherit;True;Normal From Height;-1;;9;1942fe2c5f1a1f94881a33d532e4afeb;0;1;20;FLOAT;0;False;2;FLOAT3;40;FLOAT3;0
Node;AmplifyShaderEditor.SimpleAddOpNode;343;267.3224,496.2781;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;272;-675.4869,5.998731;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.NormalVertexDataNode;312;-25.9142,-1074.08;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;56;508.4454,-1266.877;Inherit;True;Radial Shear;-1;;8;c6dc9fc7fa9b08c4d95138f2ae88b526;0;4;1;FLOAT2;0,0;False;2;FLOAT2;0,0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SmoothstepOpNode;250;1111.115,-3089.618;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCGrayscale;193;-41.08451,138.6413;Inherit;True;0;1;0;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;328;92.87385,-2477.388;Inherit;True;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;281;860.4152,-2833.23;Inherit;False;Property;_SmoothStep;SmoothStep;7;0;Create;True;0;0;False;0;False;0,0.8;0,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleAddOpNode;59;577.3126,-1459.493;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;746.5527,7.987968;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Tartaros/SH_LaserBeam 2;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;47;0;46;0
WireConnection;47;1;45;2
WireConnection;42;0;48;0
WireConnection;42;1;47;0
WireConnection;43;0;42;0
WireConnection;285;0;299;0
WireConnection;285;1;309;0
WireConnection;333;0;316;4
WireConnection;333;1;332;0
WireConnection;330;0;316;4
WireConnection;330;1;331;0
WireConnection;288;0;285;0
WireConnection;288;1;330;0
WireConnection;288;2;327;0
WireConnection;282;0;285;0
WireConnection;282;1;330;0
WireConnection;282;2;327;0
WireConnection;290;0;285;0
WireConnection;290;1;333;0
WireConnection;290;2;326;0
WireConnection;289;0;285;0
WireConnection;289;1;333;0
WireConnection;289;2;326;0
WireConnection;216;0;208;2
WireConnection;305;0;289;0
WireConnection;305;1;290;0
WireConnection;287;0;282;0
WireConnection;287;1;288;0
WireConnection;292;0;289;0
WireConnection;292;1;290;0
WireConnection;307;0;282;0
WireConnection;307;1;288;0
WireConnection;303;0;287;0
WireConnection;303;1;292;0
WireConnection;222;0;216;0
WireConnection;222;1;208;2
WireConnection;329;0;307;0
WireConnection;329;1;305;0
WireConnection;306;0;303;0
WireConnection;306;1;329;0
WireConnection;338;0;222;0
WireConnection;338;1;337;0
WireConnection;334;0;335;0
WireConnection;334;1;338;0
WireConnection;286;0;338;0
WireConnection;286;1;306;0
WireConnection;308;0;334;0
WireConnection;308;1;286;0
WireConnection;229;0;235;0
WireConnection;229;1;308;0
WireConnection;89;0;229;0
WireConnection;342;0;222;0
WireConnection;339;0;337;0
WireConnection;346;0;345;0
WireConnection;346;1;344;0
WireConnection;340;0;91;0
WireConnection;340;1;341;0
WireConnection;37;0;36;0
WireConnection;37;1;38;0
WireConnection;317;2;318;0
WireConnection;32;0;33;0
WireConnection;194;20;193;0
WireConnection;343;0;340;0
WireConnection;343;1;346;0
WireConnection;272;0;37;0
WireConnection;56;1;315;0
WireConnection;56;3;57;0
WireConnection;56;4;58;0
WireConnection;250;1;281;1
WireConnection;250;2;281;2
WireConnection;193;0;91;0
WireConnection;328;0;303;0
WireConnection;328;1;329;0
WireConnection;328;2;306;0
WireConnection;59;1;56;0
WireConnection;0;2;272;0
WireConnection;0;9;343;0
ASEEND*/
//CHKSM=9F192B29C224A28CF3BF1F8E6C56A04EBA63CEC0