// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "SH_Grass_01"
{
	Properties
	{
		_WindStrenght("Wind Strenght", Float) = 0.3
		_WindDensity("Wind Density", Float) = 0.7
		[HDR]_Vector1("Vector 1", Vector) = (6,0,0,0)
		_Speed("Speed", Float) = 0.2
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha noshadow vertex:vertexDataFunc 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float _Speed;
		uniform float2 _Vector1;
		uniform float _WindDensity;
		uniform float _WindStrenght;


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


		float4 CalculateContrast( float contrastValue, float4 colorTarget )
		{
			float t = 0.5 * ( 1.0 - contrastValue );
			return mul( float4x4( contrastValue,0,0,t, 0,contrastValue,0,t, 0,0,contrastValue,t, 0,0,0,1 ), colorTarget );
		}

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float3 ase_vertex3Pos = v.vertex.xyz;
			float mulTime205 = _Time.y * _Speed;
			float simplePerlin2D211 = snoise( (ase_vertex3Pos*1.0 + float3( ( mulTime205 * _Vector1 ) ,  0.0 )).xy*_WindDensity );
			simplePerlin2D211 = simplePerlin2D211*0.5 + 0.5;
			float3 break191 = ase_vertex3Pos;
			float temp_output_216_0 = ( ( ( simplePerlin2D211 - 0.2 ) * _WindStrenght ) + break191.x );
			float4 appendResult195 = (float4(temp_output_216_0 , temp_output_216_0 , break191.z , 0.0));
			float2 temp_cast_3 = (0.5).xx;
			float2 temp_cast_4 = (0.5).xx;
			float2 uv_TexCoord194 = v.texcoord.xy * temp_cast_3 + temp_cast_4;
			float4 lerpResult193 = lerp( float4( ase_vertex3Pos , 0.0 ) , appendResult195 , float4( uv_TexCoord194, 0.0 , 0.0 ));
			v.vertex.xyz += lerpResult193.xyz;
			v.vertex.w = 1;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float4 color256 = IsGammaSpace() ? float4(0.4701756,0.5,0.2382075,1) : float4(0.1874671,0.2140411,0.04628224,1);
			Gradient gradient243 = NewGradient( 0, 3, 2, float4( 0.5557297, 0.6132076, 0.3037113, 0.1794156 ), float4( 0.5795388, 0.6415094, 0.2935208, 0.4941176 ), float4( 0.5942779, 0.6037736, 0.2876469, 1 ), 0, 0, 0, 0, 0, float2( 1, 0 ), float2( 1, 1 ), 0, 0, 0, 0, 0, 0 );
			float3 objToWorld244 = mul( unity_ObjectToWorld, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float3 break235 = objToWorld244;
			float2 appendResult239 = (float2(break235.x , break235.z));
			float dotResult4_g8 = dot( ( appendResult239 + 1.0 ) , float2( 12.9898,78.233 ) );
			float lerpResult10_g8 = lerp( 0.0 , 1.0 , frac( ( sin( dotResult4_g8 ) * 43758.55 ) ));
			float2 _GradiantPowMul = float2(1.3,1);
			float4 temp_cast_0 = (saturate( ( pow( i.uv_texcoord.y , _GradiantPowMul.x ) * _GradiantPowMul.y ) )).xxxx;
			float4 lerpResult12 = lerp( color256 , SampleGradient( gradient243, lerpResult10_g8 ) , CalculateContrast(5.0,temp_cast_0));
			o.Albedo = lerpResult12.rgb;
			float temp_output_6_0 = 0.0;
			o.Metallic = temp_output_6_0;
			o.Smoothness = temp_output_6_0;
			o.Alpha = 1;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
-1920;8;1882;993;2397.201;1887.794;1.261069;True;False
Node;AmplifyShaderEditor.RangedFloatNode;218;-2267.658,1223.281;Inherit;False;Property;_Speed;Speed;9;0;Create;True;0;0;False;0;False;0.2;0.2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;205;-2074.645,1223.753;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;206;-2059.645,1357.753;Inherit;False;Property;_Vector1;Vector 1;8;1;[HDR];Create;True;0;0;False;0;False;6,0;6,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;207;-1780.675,1234.499;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PosVertexDataNode;197;-1812.431,475.5296;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;209;-1241.215,1320.176;Inherit;False;Property;_WindDensity;Wind Density;7;0;Create;True;0;0;False;0;False;0.7;0.8;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ScaleAndOffsetNode;210;-1453.972,1071.996;Inherit;True;3;0;FLOAT3;0,0,0;False;1;FLOAT;1;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TransformPositionNode;244;-2063.58,-483.1878;Inherit;False;Object;World;False;Fast;True;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.TextureCoordinatesNode;2;-1156.227,-81.24406;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.NoiseGeneratorNode;211;-1033.972,1072.996;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.BreakToComponentsNode;235;-1795.894,-481.146;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.RangedFloatNode;212;-746.9717,1156.996;Inherit;False;Constant;_Float9;Float 9;8;0;Create;True;0;0;False;0;False;0.2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;9;-1172.779,95.36067;Inherit;False;Constant;_GradiantPowMul;Gradiant Pow Mul;1;0;Create;True;0;0;False;0;False;1.3,1;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.PowerNode;7;-869.9365,-41.42813;Inherit;False;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;239;-1481.894,-481.146;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;240;-1482.759,-273.4948;Inherit;False;Constant;_Seed;Seed;16;0;Create;True;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;214;-582.9716,1072.996;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;213;-355.2112,1316.785;Inherit;False;Property;_WindStrenght;Wind Strenght;5;0;Create;True;0;0;False;0;False;0.3;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;-677.0905,-33.89298;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;238;-1268.759,-399.4948;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.BreakToComponentsNode;191;-1481.025,582.7454;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;215;-107.9713,1072.996;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;11;-486.9244,-28.25968;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;233;-982.0804,-402.2909;Inherit;True;Random Range;-1;;8;7b754edb8aebbfb4a9ace907af661cfc;0;3;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.GradientNode;243;-1185.647,-1630.158;Inherit;False;0;3;2;0.5557297,0.6132076,0.3037113,0.1794156;0.5795388,0.6415094,0.2935208,0.4941176;0.5942779,0.6037736,0.2876469,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.RangedFloatNode;217;-135.2079,860.7947;Inherit;False;Constant;_Float8;Float 8;14;0;Create;True;0;0;False;0;False;0.5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;216;153.0112,1107.5;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;256;-301.6553,-647.5991;Inherit;False;Constant;_ColorBottom;Color Bottom;1;0;Create;True;0;0;False;0;False;0.4701756,0.5,0.2382075,1;0.4701756,0.5,0.2382075,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleContrastOpNode;260;-247.748,-33.88028;Inherit;True;2;1;COLOR;0,0,0,0;False;0;FLOAT;5;False;1;COLOR;0
Node;AmplifyShaderEditor.GradientSampleNode;241;-664.8021,-416.4721;Inherit;True;2;0;OBJECT;;False;1;FLOAT;0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;194;104.7911,828.9993;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;195;-92.0261,591.7454;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;122;-8690.819,2411.624;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;193;322.0462,473.3646;Inherit;True;3;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;2;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.Vector3Node;116;-7305.373,1397.074;Inherit;False;Constant;_Vector0;Vector 0;5;0;Create;True;0;0;False;0;False;0,0,1;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;137;-7240.063,2856.842;Inherit;False;Constant;_Float4;Float 4;3;0;Create;True;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;26;-6756.686,-133.8388;Inherit;True;3;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;2;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RangedFloatNode;107;-8950.948,2023.453;Inherit;False;Constant;_OffsetY;OffsetY;5;0;Create;True;0;0;False;0;False;6.7;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.BreakToComponentsNode;16;-8638.757,-14.45753;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.DynamicAppendNode;92;-9621.275,1474.453;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleTimeNode;21;-8375.758,547.5433;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.GradientNode;242;-7967.513,-770.3665;Inherit;False;0;3;2;0.4509804,0.5019608,0.227451,0;0.1960784,0.6156863,0.6784314,0.5000076;0.6784314,0.1960784,0.6114826,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;125;-9062.82,3044.626;Inherit;True;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleSubtractOpNode;111;-8051.681,1783.372;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;140;-6985.21,3145.842;Inherit;False;Property;_Strenght;Strenght;4;0;Create;True;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;121;-9029.82,2310.624;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;97;-9457.884,1045.607;Inherit;False;Constant;_lScale;lScale;5;0;Create;True;0;0;False;0;False;24;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;94;-9925.275,1620.453;Inherit;False;Constant;_OffsetZ;OffsetZ;5;0;Create;True;0;0;False;0;False;-9;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;128;-8463.903,3199.412;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldToTangentMatrix;105;-8154.884,913.6064;Inherit;False;0;1;FLOAT3x3;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;96;-9151.884,1301.606;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;17;-7170.759,-15.45753;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;131;-8130.819,2909.625;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;12;84.6129,-424.8283;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;119;-8525.037,544.3043;Inherit;False;Constant;_Float0;Float 0;2;0;Create;True;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;99;-8611.883,1337.606;Inherit;False;Constant;_Float1;Float 1;5;0;Create;True;0;0;False;0;False;0.2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;18;-8413.758,254.5428;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;113;-8024.681,2021.372;Inherit;False;Constant;_Blend;Blend;5;0;Create;True;0;0;False;0;False;10;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;108;-8942.948,1815.454;Inherit;False;Constant;_DistanceScale;DistanceScale;5;0;Create;True;0;0;False;0;False;6;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;135;-7077.29,2642.59;Inherit;False;5;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;1,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;6;482.0359,176.3397;Inherit;False;Constant;_Zero;Zero;1;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;25;-7448.214,260.5288;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;219;-9260.968,2812.336;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;139;-7252.063,2954.842;Inherit;False;Constant;_Float6;Float 6;3;0;Create;True;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;136;-7381.063,2859.842;Inherit;False;Constant;_Float3;Float 3;3;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;109;-8423.843,1938.209;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;145;-8993.573,2567.814;Inherit;False;Property;_WindPeriod;WindPeriod;2;0;Create;True;0;0;False;0;False;2;0.2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;134;-7931.233,2670.762;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;141;-6668.063,2952.842;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;138;-7391.063,2952.842;Inherit;False;Constant;_Float5;Float 5;3;0;Create;True;0;0;False;0;False;-1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;19;-8590.757,331.5428;Inherit;False;Property;_Frequency;Frequency;6;0;Create;True;0;0;False;0;False;5;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldNormalVector;89;-8915.972,1466.16;Inherit;True;False;1;0;FLOAT3;0,0,1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;132;-8452.82,3056.625;Inherit;False;Property;_WindPositionScale;WindPositionScale;0;0;Create;True;0;0;False;0;False;2;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;88;-8966.278,1045.454;Inherit;True;Reconstruct World Position From Depth;-1;;9;e7094bcbcc80eb140b2a3dbe6a861de8;0;0;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;101;-8165.884,1241.606;Inherit;False;2;2;0;FLOAT4;0,0,0,0;False;1;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.BreakToComponentsNode;126;-8768.82,2809.626;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SimpleDivideOpNode;112;-7817.681,1776.372;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;24;-7831.758,536.5433;Inherit;False;Property;_Ampl;Ampl;1;0;Create;True;0;0;False;0;False;0.2;0.2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;27;-7004.554,151.2416;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;23;-7711.758,263.5428;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GradientNode;261;-1003.404,-569.7642;Inherit;False;0;3;2;0.8301887,0.2182383,0.1605553,0.1470665;0.9150943,0.1424439,0.7624308,0.4705882;0,0.6993538,0.9811321,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.ClampOpNode;114;-7550.681,1785.372;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;95;-9427.884,1327.606;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;20;-8171.758,254.5428;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;106;-8560.883,1708.607;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;110;-8336.964,1665.535;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;98;-8419.884,1237.606;Inherit;False;2;0;FLOAT4;0,0,0,0;False;1;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;104;-7813.884,1047.607;Inherit;False;2;2;0;FLOAT3x3;0,0,0,1,1,1,1,0,1;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SamplerNode;120;-7651.156,2623.372;Inherit;True;Property;_WindNoise;WindNoise;3;0;Create;True;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;102;-8309.884,1359.606;Inherit;False;Constant;_Float2;Float 2;5;0;Create;True;0;0;False;0;False;2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;90;-10180.28,1274.453;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.DynamicAppendNode;91;-9612.275,1191.453;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.LerpOp;115;-6936.395,1366.395;Inherit;False;3;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;2;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.DynamicAppendNode;127;-8494.82,2812.625;Inherit;True;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.PosVertexDataNode;15;-8891.165,-131.6736;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SinOpNode;22;-7926.758,256.5428;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;93;-9935.275,1521.453;Inherit;False;Constant;_OffsetX;OffsetX;5;0;Create;True;0;0;False;0;False;-4;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;220;727.802,81.42783;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;SH_Grass_01;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;False;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;205;0;218;0
WireConnection;207;0;205;0
WireConnection;207;1;206;0
WireConnection;210;0;197;0
WireConnection;210;2;207;0
WireConnection;211;0;210;0
WireConnection;211;1;209;0
WireConnection;235;0;244;0
WireConnection;7;0;2;2
WireConnection;7;1;9;1
WireConnection;239;0;235;0
WireConnection;239;1;235;2
WireConnection;214;0;211;0
WireConnection;214;1;212;0
WireConnection;10;0;7;0
WireConnection;10;1;9;2
WireConnection;238;0;239;0
WireConnection;238;1;240;0
WireConnection;191;0;197;0
WireConnection;215;0;214;0
WireConnection;215;1;213;0
WireConnection;11;0;10;0
WireConnection;233;1;238;0
WireConnection;216;0;215;0
WireConnection;216;1;191;0
WireConnection;260;1;11;0
WireConnection;241;0;243;0
WireConnection;241;1;233;0
WireConnection;194;0;217;0
WireConnection;194;1;217;0
WireConnection;195;0;216;0
WireConnection;195;1;216;0
WireConnection;195;2;191;2
WireConnection;122;0;121;0
WireConnection;122;1;145;0
WireConnection;193;0;197;0
WireConnection;193;1;195;0
WireConnection;193;2;194;0
WireConnection;26;0;15;0
WireConnection;26;1;17;0
WireConnection;26;2;27;2
WireConnection;16;0;15;0
WireConnection;92;0;93;0
WireConnection;92;1;94;0
WireConnection;21;0;119;0
WireConnection;111;0;110;0
WireConnection;111;1;109;0
WireConnection;128;0;126;0
WireConnection;128;1;126;2
WireConnection;96;0;95;0
WireConnection;96;1;97;0
WireConnection;17;0;25;0
WireConnection;17;1;25;0
WireConnection;17;2;16;2
WireConnection;131;0;128;0
WireConnection;131;1;132;0
WireConnection;12;0;256;0
WireConnection;12;1;241;0
WireConnection;12;2;260;0
WireConnection;18;0;16;0
WireConnection;18;1;19;0
WireConnection;135;0;120;0
WireConnection;135;1;136;0
WireConnection;135;2;137;0
WireConnection;135;3;138;0
WireConnection;135;4;139;0
WireConnection;25;0;16;1
WireConnection;25;1;23;0
WireConnection;109;0;107;0
WireConnection;109;1;108;0
WireConnection;134;0;122;0
WireConnection;134;1;131;0
WireConnection;89;0;96;0
WireConnection;101;0;98;0
WireConnection;101;1;102;0
WireConnection;126;0;219;0
WireConnection;112;0;111;0
WireConnection;112;1;113;0
WireConnection;23;0;22;0
WireConnection;23;1;24;0
WireConnection;114;0;112;0
WireConnection;95;0;91;0
WireConnection;95;1;92;0
WireConnection;20;0;18;0
WireConnection;20;1;21;0
WireConnection;106;0;89;1
WireConnection;106;1;108;0
WireConnection;110;0;90;2
WireConnection;110;1;106;0
WireConnection;98;0;88;0
WireConnection;98;1;99;0
WireConnection;104;0;105;0
WireConnection;104;1;101;0
WireConnection;120;1;134;0
WireConnection;91;0;90;1
WireConnection;91;1;90;3
WireConnection;115;0;104;0
WireConnection;115;1;116;0
WireConnection;115;2;114;0
WireConnection;127;0;126;0
WireConnection;127;1;126;2
WireConnection;22;0;20;0
WireConnection;220;0;12;0
WireConnection;220;3;6;0
WireConnection;220;4;6;0
WireConnection;220;11;193;0
ASEEND*/
//CHKSM=8E69D63C8BFB332ED5C379F3F8E1C90816F26EC0