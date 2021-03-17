// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "SH_LaserTrail"
{
	Properties
	{
		[HDR]_Color0("Color 0", Color) = (0.5688477,0,1,0)
		[HDR]_Color1("Color 1", Color) = (1,0.3057163,0,0)
		_LaserStrength("LaserStrength", Float) = 10
		_LaserPower("LaserPower", Float) = 10
		_PaternScale1("PaternScale1", Float) = 0
		_PaternScale2("PaternScale2", Float) = 0
		_PaternSpeed("PaternSpeed", Float) = 0
		_PaternSpeed2("PaternSpeed2", Float) = 0
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_Depth("Depth", Float) = 10
		_STEP("STEP", Vector) = (2.84,1.15,0,0)
		_POWER("POWER", Vector) = (1,1,0,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Off
		Blend SrcAlpha OneMinusSrcAlpha
		
		CGPROGRAM
		#include "UnityCG.cginc"
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha noshadow 
		struct Input
		{
			float2 uv_texcoord;
			float4 screenPos;
			float3 viewDir;
		};

		uniform float2 _STEP;
		uniform float4 _Color1;
		uniform float _LaserStrength;
		uniform float _LaserPower;
		uniform sampler2D _TextureSample0;
		uniform float4 _TextureSample0_ST;
		uniform float2 _POWER;
		UNITY_DECLARE_DEPTH_TEXTURE( _CameraDepthTexture );
		uniform float4 _CameraDepthTexture_TexelSize;
		uniform float _Depth;
		uniform float _PaternScale2;
		uniform float _PaternSpeed;
		uniform float _PaternScale1;
		uniform float _PaternSpeed2;
		uniform float4 _Color0;


		struct Gradient
		{
			int type;
			int colorsLength;
			int alphasLength;
			float4 colors[8];
			float2 alphas[8];
		};


		Gradient NewGradient(int type, int colorsLength, int alphasLength, 
		float4 colors0, float4 colors1, float4 colors2, float4 colors3, float4 colors4, float4 colors5, float4 colors6, float4 colors7,
		float2 alphas0, float2 alphas1, float2 alphas2, float2 alphas3, float2 alphas4, float2 alphas5, float2 alphas6, float2 alphas7)
		{
			Gradient g;
			g.type = type;
			g.colorsLength = colorsLength;
			g.alphasLength = alphasLength;
			g.colors[ 0 ] = colors0;
			g.colors[ 1 ] = colors1;
			g.colors[ 2 ] = colors2;
			g.colors[ 3 ] = colors3;
			g.colors[ 4 ] = colors4;
			g.colors[ 5 ] = colors5;
			g.colors[ 6 ] = colors6;
			g.colors[ 7 ] = colors7;
			g.alphas[ 0 ] = alphas0;
			g.alphas[ 1 ] = alphas1;
			g.alphas[ 2 ] = alphas2;
			g.alphas[ 3 ] = alphas3;
			g.alphas[ 4 ] = alphas4;
			g.alphas[ 5 ] = alphas5;
			g.alphas[ 6 ] = alphas6;
			g.alphas[ 7 ] = alphas7;
			return g;
		}


		float4 SampleGradient( Gradient gradient, float time )
		{
			float3 color = gradient.colors[0].rgb;
			UNITY_UNROLL
			for (int c = 1; c < 8; c++)
			{
			float colorPos = saturate((time - gradient.colors[c-1].w) / (gradient.colors[c].w - gradient.colors[c-1].w)) * step(c, (float)gradient.colorsLength-1);
			color = lerp(color, gradient.colors[c].rgb, lerp(colorPos, step(0.01, colorPos), gradient.type));
			}
			#ifndef UNITY_COLORSPACE_GAMMA
			color = half3(GammaToLinearSpaceExact(color.r), GammaToLinearSpaceExact(color.g), GammaToLinearSpaceExact(color.b));
			#endif
			float alpha = gradient.alphas[0].x;
			UNITY_UNROLL
			for (int a = 1; a < 8; a++)
			{
			float alphaPos = saturate((time - gradient.alphas[a-1].y) / (gradient.alphas[a].y - gradient.alphas[a-1].y)) * step(a, (float)gradient.alphasLength-1);
			alpha = lerp(alpha, gradient.alphas[a].x, lerp(alphaPos, step(0.01, alphaPos), gradient.type));
			}
			return float4(color, alpha);
		}


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
			float3 temp_cast_0 = (_STEP.x).xxx;
			float3 temp_cast_1 = (_STEP.y).xxx;
			float3 temp_cast_2 = (( 1.0 - i.uv_texcoord.x )).xxx;
			float3 objToWorld373 = mul( unity_ObjectToWorld, float4( temp_cast_2, 1 ) ).xyz;
			float3 smoothstepResult413 = smoothstep( temp_cast_0 , temp_cast_1 , objToWorld373);
			float temp_output_222_0 = ( ( 1.0 - i.uv_texcoord.y ) * i.uv_texcoord.y );
			float2 uv_TextureSample0 = i.uv_texcoord * _TextureSample0_ST.xy + _TextureSample0_ST.zw;
			float4 tex2DNode337 = tex2D( _TextureSample0, uv_TextureSample0 );
			float4 temp_output_338_0 = ( temp_output_222_0 * tex2DNode337 );
			float4 LaserCoreShape89 = ( _LaserStrength * ( ( _LaserPower * temp_output_338_0 ) + ( temp_output_338_0 * float4( 0,0,0,0 ) ) ) );
			Gradient gradient423 = NewGradient( 0, 4, 4, float4( 0, 0, 0, 0 ), float4( 1, 1, 1, 0.2 ), float4( 1, 1, 1, 0.8 ), float4( 0, 0, 0, 1 ), 0, 0, 0, 0, float2( 0, 0 ), float2( 1, 0.2 ), float2( 1, 0.8 ), float2( 0, 1 ), 0, 0, 0, 0 );
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float4 ase_screenPosNorm = ase_screenPos / ase_screenPos.w;
			ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
			float clampDepth398 = Linear01Depth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_screenPosNorm.xy ));
			float temp_output_330_0 = ( _Time.w * _PaternSpeed );
			float time282 = temp_output_330_0;
			float2 coords282 = i.viewDir.xy * _PaternScale2;
			float2 id282 = 0;
			float2 uv282 = 0;
			float voroi282 = voronoi282( coords282, time282, id282, uv282, 0 );
			float time288 = temp_output_330_0;
			float2 coords288 = i.viewDir.xy * _PaternScale2;
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
			float2 coords289 = i.viewDir.xy * _PaternScale1;
			float2 id289 = 0;
			float2 uv289 = 0;
			float voroi289 = voronoi289( coords289, time289, id289, uv289, 0 );
			float time290 = temp_output_333_0;
			float2 coords290 = i.viewDir.xy * _PaternScale1;
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
			float FirePatern419 = temp_output_306_0;
			o.Emission = ( ( float4( smoothstepResult413 , 0.0 ) * ( _Color1 * LaserCoreShape89 ) ) + ( ( float4( smoothstepResult413 , 0.0 ) + ( 1.0 - SampleGradient( gradient423, length( ( _POWER * ( i.uv_texcoord + ( clampDepth398 * _Depth ) ) ) ) ) ) ) * ( FirePatern419 * _Color0 ) ) ).rgb;
			o.Alpha = smoothstepResult413.x;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
272;73;1265;549;991.1448;3527.378;1.758864;True;False
Node;AmplifyShaderEditor.CommentaryNode;30;-1915.972,-3894.345;Inherit;False;4099.005;1764.964;Comment;40;89;208;216;222;229;235;250;281;282;285;288;287;289;290;286;292;299;303;305;306;307;308;309;316;317;318;326;327;328;329;330;331;332;333;334;335;337;339;342;419;LASERSHAPE;1,1,1,1;0;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode;208;-1779.17,-3285.653;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;332;-1823.028,-2304.882;Inherit;False;Property;_PaternSpeed2;PaternSpeed2;14;0;Create;True;0;0;False;0;False;0;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;331;-1825.164,-2372.833;Inherit;False;Property;_PaternSpeed;PaternSpeed;13;0;Create;True;0;0;False;0;False;0;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;316;-1841.487,-2521.657;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;216;-1263.265,-3544.432;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;337;-943.068,-3593.45;Inherit;True;Property;_TextureSample0;Texture Sample 0;15;0;Create;True;0;0;False;0;False;-1;None;8c4a7fca2884fab419769ccc0355c0c1;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ScreenDepthNode;398;-1761.016,-350.5277;Inherit;False;1;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;401;-1755.892,-225.5628;Inherit;False;Property;_Depth;Depth;18;0;Create;True;0;0;False;0;False;10;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;222;-1289.253,-3290.889;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;333;-1570.681,-2366.478;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;327;-1505.163,-2682.3;Inherit;False;Property;_PaternScale2;PaternScale2;12;0;Create;True;0;0;False;0;False;0;50;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;330;-1567.475,-2451.811;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;326;-1327.061,-2336.049;Inherit;False;Property;_PaternScale1;PaternScale1;11;0;Create;True;0;0;False;0;False;0;50;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ViewDirInputsCoordNode;390;-2170.244,-2912.6;Inherit;True;World;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.VoronoiNode;289;-1080.318,-2689.576;Inherit;True;0;0;1;3;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.VoronoiNode;290;-1083.935,-2415.019;Inherit;True;0;0;1;3;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;402;-1487.136,-257.715;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;335;-16.23507,-3397.641;Inherit;False;Property;_LaserPower;LaserPower;7;0;Create;True;0;0;False;0;False;10;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;338;-709.7704,-3319.952;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode;351;-1457.145,-394.5881;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VoronoiNode;288;-1325.817,-2775.789;Inherit;True;0;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;2;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.VoronoiNode;282;-1322.2,-3050.347;Inherit;True;0;0;1;0;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;2;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SimpleDivideOpNode;305;-560.9979,-2440.399;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;307;-428.3354,-2961.24;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;292;-855.3932,-2505.052;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;287;-941.591,-2957.564;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;286;192.3902,-3109.662;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;334;215.3661,-3333.646;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.Vector2Node;416;-1103.136,-493.3528;Inherit;False;Property;_POWER;POWER;20;0;Create;True;0;0;False;0;False;1,1;0.5,0.5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleAddOpNode;399;-1213.057,-313.8852;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;303;-555.1653,-2703.49;Inherit;True;2;0;FLOAT;0.06;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;407;-1030.345,-343.5571;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode;376;-1769.137,-702.7045;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;308;540.5251,-3297.211;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;329;-298.1898,-2586.961;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;235;1268.631,-3402.54;Inherit;False;Property;_LaserStrength;LaserStrength;6;0;Create;True;0;0;False;0;False;10;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;306;-36.2245,-2700.539;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GradientNode;423;-860.4149,-494.1244;Inherit;False;0;4;4;0,0,0,0;1,1,1,0.2;1,1,1,0.8;0,0,0,1;0,0;1,0.2;1,0.8;0,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.LengthOpNode;374;-833.4839,-325.4431;Inherit;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;392;-1493.659,-712.6901;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;229;1526.599,-3334.905;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TransformPositionNode;373;-1208.717,-732.6713;Inherit;False;Object;World;False;Fast;True;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.Vector2Node;405;-1297.269,-590.4625;Inherit;False;Property;_STEP;STEP;19;0;Create;True;0;0;False;0;False;2.84,1.15;0,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.GradientSampleNode;422;-596.5632,-410.9704;Inherit;True;2;0;OBJECT;;False;1;FLOAT;0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;89;1895.67,-3310.998;Inherit;True;LaserCoreShape;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;419;302.2407,-2636.264;Inherit;True;FirePatern;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;33;-1693.186,178.2832;Inherit;False;Property;_Color0;Color 0;1;1;[HDR];Create;True;0;0;False;0;False;0.5688477,0,1,0;0.7924528,0.3476567,0,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;420;-1466.29,130.0744;Inherit;False;419;FirePatern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;428;-221.0001,-214.3522;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;38;-1441.242,11.35144;Inherit;False;89;LaserCoreShape;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;36;-1695.54,-103.58;Inherit;False;Property;_Color1;Color 1;4;1;[HDR];Create;True;0;0;False;0;False;1,0.3057163,0,0;0.7735849,0.232878,0.1569064,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;413;-791.618,-671.413;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0.98,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;421;-1088.632,165.6504;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;429;66.23302,-258.7216;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;37;-1102.146,-98.03045;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;410;-741.232,160.2725;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;379;-411.2563,-68.03891;Inherit;True;2;2;0;FLOAT3;0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;309;-1726.95,-2612.032;Inherit;False;43;UV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;57;213.353,-1241.54;Inherit;False;Property;_RadialShear;RadialShear;5;0;Create;True;0;0;False;0;False;10,10;10,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.GradientSampleNode;418;-406.8723,-832.5247;Inherit;True;2;0;OBJECT;;False;1;FLOAT;0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;341;-380.8774,877.9961;Inherit;False;Property;_OpacityTexture;OpacityTexture;16;0;Create;True;0;0;False;0;False;0;0.63;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;340;-48.53199,752.3534;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;42;282.1682,-1546.545;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;318;465.5068,-2723.571;Inherit;False;Property;_Lerp;Lerp;10;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;285;-1673.889,-2947.074;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GradientNode;417;-730.8641,-863.2281;Inherit;False;0;3;2;0,0,0,0;0.8823529,0.8823529,0.8823529,0.8823529;0,0,0,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.TFHCGrayscale;193;-491.9314,374.1961;Inherit;True;0;1;0;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;388;133.9561,-1418.755;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleAddOpNode;389;122.9388,-1525.255;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;91;-390.5686,678.5266;Inherit;True;339;Texture;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.ViewDirInputsCoordNode;382;-593.8947,-1232.928;Inherit;True;World;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.Vector2Node;48;-58.37362,-1608.911;Inherit;False;Property;_UV_tiling;UV_tiling;3;0;Create;True;0;0;False;0;False;1,1;1,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.WorldPosInputsNode;380;-270.33,-1145.627;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;344;-399.7965,1179.166;Inherit;False;Property;_OpacityPatern;OpacityPatern;17;0;Create;True;0;0;False;0;False;0;0.63;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;345;-409.4877,979.6968;Inherit;True;342;Patern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;46;-352.5932,-1571.729;Inherit;False;Property;_UV_direction;UV_direction;2;0;Create;True;0;0;False;0;False;-1,0;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RegisterLocalVarNode;339;-554.5593,-3573.255;Inherit;False;Texture;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;56;508.4454,-1266.877;Inherit;True;Radial Shear;-1;;10;c6dc9fc7fa9b08c4d95138f2ae88b526;0;4;1;FLOAT2;0,0;False;2;FLOAT2;0,0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;272;-75.10336,59.64999;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;342;-965.397,-3187.021;Inherit;False;Patern;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;281;860.4152,-2833.23;Inherit;False;Property;_SmoothStep;SmoothStep;8;0;Create;True;0;0;False;0;False;0,0.8;0,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleAddOpNode;328;92.87385,-2477.388;Inherit;True;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;404;419.3797,596.1302;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;59;577.3126,-1459.493;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;47;-69.78723,-1463.468;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;403;302.5865,343.1277;Inherit;True;89;LaserCoreShape;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;317;493.8606,-2919.47;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.2;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;43;786.6296,-1562.401;Inherit;True;UV;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;346;-67.4511,1053.524;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;343;198.1232,776.717;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;194;-185.8713,391.4167;Inherit;True;Normal From Height;-1;;11;1942fe2c5f1a1f94881a33d532e4afeb;0;1;20;FLOAT;0;False;2;FLOAT3;40;FLOAT3;0
Node;AmplifyShaderEditor.TimeNode;45;-395.4768,-1423.881;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;299;-1622.109,-2809.883;Inherit;False;Property;_Tiling;Tiling;9;0;Create;True;0;0;False;0;False;1,1;10,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.NormalVertexDataNode;312;-25.9142,-1074.08;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;250;1111.115,-3089.618;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;58;197.753,-1077.74;Inherit;False;Constant;_Vector1;Vector 1;7;0;Create;True;0;0;False;0;False;0.25,0.25;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;746.5527,7.987968;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;SH_LaserTrail;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;False;0;True;TransparentCutout;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;216;0;208;2
WireConnection;222;0;216;0
WireConnection;222;1;208;2
WireConnection;333;0;316;4
WireConnection;333;1;332;0
WireConnection;330;0;316;4
WireConnection;330;1;331;0
WireConnection;289;0;390;0
WireConnection;289;1;333;0
WireConnection;289;2;326;0
WireConnection;290;0;390;0
WireConnection;290;1;333;0
WireConnection;290;2;326;0
WireConnection;402;0;398;0
WireConnection;402;1;401;0
WireConnection;338;0;222;0
WireConnection;338;1;337;0
WireConnection;288;0;390;0
WireConnection;288;1;330;0
WireConnection;288;2;327;0
WireConnection;282;0;390;0
WireConnection;282;1;330;0
WireConnection;282;2;327;0
WireConnection;305;0;289;0
WireConnection;305;1;290;0
WireConnection;307;0;282;0
WireConnection;307;1;288;0
WireConnection;292;0;289;0
WireConnection;292;1;290;0
WireConnection;287;0;282;0
WireConnection;287;1;288;0
WireConnection;286;0;338;0
WireConnection;334;0;335;0
WireConnection;334;1;338;0
WireConnection;399;0;351;0
WireConnection;399;1;402;0
WireConnection;303;0;287;0
WireConnection;303;1;292;0
WireConnection;407;0;416;0
WireConnection;407;1;399;0
WireConnection;308;0;334;0
WireConnection;308;1;286;0
WireConnection;329;0;307;0
WireConnection;329;1;305;0
WireConnection;306;0;303;0
WireConnection;306;1;329;0
WireConnection;374;0;407;0
WireConnection;392;0;376;1
WireConnection;229;0;235;0
WireConnection;229;1;308;0
WireConnection;373;0;392;0
WireConnection;422;0;423;0
WireConnection;422;1;374;0
WireConnection;89;0;229;0
WireConnection;419;0;306;0
WireConnection;428;0;422;0
WireConnection;413;0;373;0
WireConnection;413;1;405;1
WireConnection;413;2;405;2
WireConnection;421;0;420;0
WireConnection;421;1;33;0
WireConnection;429;0;413;0
WireConnection;429;1;428;0
WireConnection;37;0;36;0
WireConnection;37;1;38;0
WireConnection;410;0;429;0
WireConnection;410;1;421;0
WireConnection;379;0;413;0
WireConnection;379;1;37;0
WireConnection;418;0;417;0
WireConnection;340;0;91;0
WireConnection;340;1;341;0
WireConnection;42;0;389;0
WireConnection;42;1;388;0
WireConnection;285;0;299;0
WireConnection;285;1;309;0
WireConnection;193;0;91;0
WireConnection;388;0;47;0
WireConnection;388;1;382;0
WireConnection;389;0;48;0
WireConnection;389;1;382;0
WireConnection;339;0;337;0
WireConnection;56;3;57;0
WireConnection;56;4;58;0
WireConnection;272;0;379;0
WireConnection;272;1;410;0
WireConnection;342;0;222;0
WireConnection;328;0;303;0
WireConnection;328;1;329;0
WireConnection;328;2;306;0
WireConnection;404;1;343;0
WireConnection;59;0;42;0
WireConnection;59;1;56;0
WireConnection;47;0;46;0
WireConnection;47;1;45;2
WireConnection;317;2;318;0
WireConnection;43;0;59;0
WireConnection;346;0;345;0
WireConnection;346;1;344;0
WireConnection;343;0;340;0
WireConnection;343;1;346;0
WireConnection;194;20;193;0
WireConnection;250;1;281;1
WireConnection;250;2;281;2
WireConnection;0;2;272;0
WireConnection;0;9;413;0
ASEEND*/
//CHKSM=34BD52E424BCB7585A8D84F5805B78C304031B5A