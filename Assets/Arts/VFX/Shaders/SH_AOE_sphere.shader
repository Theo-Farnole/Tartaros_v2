// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_AOE_sphere"
{
	Properties
	{
		[HDR]_Color0("Color 0", Color) = (0,0,0,0)
		_Float0("Float 0", Float) = 100
		_BorderMult("BorderMult", Float) = 0.27
		_VoroPower("VoroPower", Float) = 5
		_SmoothStep("SmoothStep", Range( 0 , 1)) = 0
		_VoroScale("VoroScale", Float) = 5
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
			float3 worldPos;
			float2 uv_texcoord;
		};

		uniform float _BorderMult;
		uniform float _VoroScale;
		uniform float _Float0;
		uniform float _SmoothStep;
		uniform float _VoroPower;
		uniform float4 _Color0;


		float2 voronoihash71( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi71( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash71( n + g );
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


		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float3 ase_worldPos = i.worldPos;
			float temp_output_66_0 = step( ase_worldPos.y , _BorderMult );
			float time71 = ( _Float0 * _Time.x );
			float2 coords71 = i.uv_texcoord * _VoroScale;
			float2 id71 = 0;
			float2 uv71 = 0;
			float fade71 = 0.5;
			float voroi71 = 0;
			float rest71 = 0;
			for( int it71 = 0; it71 <8; it71++ ){
			voroi71 += fade71 * voronoi71( coords71, time71, id71, uv71, 0 );
			rest71 += fade71;
			coords71 *= 2;
			fade71 *= 0.5;
			}//Voronoi71
			voroi71 /= rest71;
			float4 temp_cast_0 = (_SmoothStep).xxxx;
			float4 temp_cast_1 = (temp_output_66_0).xxxx;
			Gradient gradient81 = NewGradient( 0, 2, 2, float4( 1, 1, 1, 0 ), float4( 0, 0, 0, 1 ), 0, 0, 0, 0, 0, 0, float2( 1, 0 ), float2( 1, 1 ), 0, 0, 0, 0, 0, 0 );
			float temp_output_56_0 = length( ase_worldPos.y );
			float4 smoothstepResult73 = smoothstep( temp_cast_0 , temp_cast_1 , SampleGradient( gradient81, temp_output_56_0 ));
			float4 SmoothBorder44 = ( temp_output_66_0 * ( ( voroi71 * smoothstepResult73 ) * _VoroPower ) );
			o.Emission = ( SmoothBorder44 * _Color0 ).rgb;
			o.Alpha = SmoothBorder44.r;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
275;73;1281;567;1665.969;466.3729;1.727257;True;False
Node;AmplifyShaderEditor.WorldPosInputsNode;69;-902.2793,-1511.74;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;38;-876.21,-1353.029;Inherit;False;Property;_BorderMult;BorderMult;7;0;Create;True;0;0;False;0;False;0.27;10;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;83;-451.5659,-1172.13;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;84;-309.167,-1256.532;Inherit;False;Property;_Float0;Float 0;5;0;Create;True;0;0;False;0;False;100;100;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GradientNode;81;-889.1164,-848.8813;Inherit;False;0;2;2;1,1,1,0;0,0,0,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.LengthOpNode;56;-1011.282,-1135.27;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GradientSampleNode;82;-669.9465,-848.6282;Inherit;True;2;0;OBJECT;;False;1;FLOAT;0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;86;-121.7692,-1274.501;Inherit;False;Property;_VoroScale;VoroScale;11;0;Create;True;0;0;False;0;False;5;20;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;80;-223.4195,-742.8612;Inherit;False;Property;_SmoothStep;SmoothStep;10;0;Create;True;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;85;-144.125,-1190.804;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StepOpNode;66;-698.1939,-1419.525;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;71;113.4134,-1293.063;Inherit;True;0;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;5;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SmoothstepOpNode;73;122.346,-933.1652;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0.5,0,0,0;False;2;COLOR;0.6,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;78;454.3695,-887.9811;Inherit;False;Property;_VoroPower;VoroPower;9;0;Create;True;0;0;False;0;False;5;10;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;74;402.3701,-1123.282;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;77;690.9698,-1131.081;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;79;1003.157,-1413.78;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;44;1202.873,-1424.406;Inherit;False;SmoothBorder;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;17;-525.7695,-32.48527;Inherit;False;Property;_Color0;Color 0;0;1;[HDR];Create;True;0;0;False;0;False;0,0,0,0;0,0.8588235,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;45;-430.298,-132.4738;Inherit;False;44;SmoothBorder;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SmoothstepOpNode;40;-917.6462,-580.2737;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;53;-1239.899,-1512.416;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;37;-1609.534,-613.0109;Inherit;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RangedFloatNode;54;-1398.31,-1308.671;Inherit;False;Property;_VertexVMax;VertexVMax;8;0;Create;True;0;0;False;0;False;0.38;2.45;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;67;-1096.164,-319.5786;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;63;-1415.983,-604.5284;Inherit;False;2;2;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.GradientNode;9;-3377.257,259.7852;Inherit;False;0;4;4;0,0,0,0;1,1,1,0.2;1,1,1,0.8;0,0,0,1;0,0;1,0.2;1,0.8;0,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.Vector2Node;13;-2898.353,-913.3781;Inherit;False;Property;_STEP;STEP;2;0;Create;True;0;0;False;0;False;2.84,1.15;-1,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.GradientSampleNode;14;-3113.405,342.9391;Inherit;True;2;0;OBJECT;;False;1;FLOAT;0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TransformPositionNode;68;-1253.135,-644.3098;Inherit;False;Object;World;False;Fast;True;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;20;-3837.997,603.5548;Inherit;False;Property;_POWER;POWER;3;0;Create;True;0;0;False;0;False;1.05;1.01;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;46;-1216.72,-930.037;Inherit;False;Border;-1;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.LengthOpNode;10;-3350.326,428.4664;Inherit;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenDepthNode;1;-2892.276,-613.683;Inherit;False;1;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CameraWorldClipPlanes;33;-2336.918,-679.7689;Inherit;False;Far;0;1;FLOAT4;0
Node;AmplifyShaderEditor.OneMinusNode;51;-686.639,-1128.293;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;47;-373.9774,215.2366;Inherit;True;44;SmoothBorder;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;7;-3525.086,488.3524;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.OneMinusNode;11;-3094.743,-1035.606;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode;4;-3816.518,409.7036;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.NormalVertexDataNode;70;-1276.567,-434.2499;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;24;-2967.361,-157.2915;Inherit;False;Property;_Speed;Speed;4;0;Create;True;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;16;-2392.702,-994.3287;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0.98,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;18;-216.3208,-89.81487;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;28;-2753.886,-200.3297;Inherit;False;27;Patern;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;25;-2351.722,-114.6596;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleSubtractOpNode;36;-1819.379,-615.8512;Inherit;True;2;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleAddOpNode;26;-2573.176,-156.7634;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.TransformPositionNode;12;-2809.801,-1055.587;Inherit;False;Object;World;False;Fast;True;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RegisterLocalVarNode;27;-2713.008,333.4799;Inherit;False;Patern;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StepOpNode;65;-2290.691,-449.2606;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;2;-2870.88,-494.142;Inherit;False;Property;_Depth;Depth;1;0;Create;True;0;0;False;0;False;10;-1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;30;-1754.813,-342.3809;Inherit;False;Property;_BorderOffset;BorderOffset;6;0;Create;True;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode;8;-3370.221,-1025.62;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;19;-3648.76,567.425;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;35;-2079.779,-642.3126;Inherit;True;2;2;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.TimeNode;21;-3109.76,-72.88941;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;29;-2063.335,-3.725688;Inherit;True;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3;-2637.378,-604.9419;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenDepthNode;31;-2350.194,-577.3696;Inherit;False;1;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;22;-2802.319,-91.56359;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Tartaros/SH_AOE_sphere;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;56;0;69;2
WireConnection;82;0;81;0
WireConnection;82;1;56;0
WireConnection;85;0;84;0
WireConnection;85;1;83;1
WireConnection;66;0;69;2
WireConnection;66;1;38;0
WireConnection;71;1;85;0
WireConnection;71;2;86;0
WireConnection;73;0;82;0
WireConnection;73;1;80;0
WireConnection;73;2;66;0
WireConnection;74;0;71;0
WireConnection;74;1;73;0
WireConnection;77;0;74;0
WireConnection;77;1;78;0
WireConnection;79;0;66;0
WireConnection;79;1;77;0
WireConnection;44;0;79;0
WireConnection;37;0;35;0
WireConnection;63;0;37;0
WireConnection;14;0;9;0
WireConnection;14;1;10;0
WireConnection;68;0;70;2
WireConnection;10;0;7;0
WireConnection;51;0;56;0
WireConnection;7;0;4;0
WireConnection;7;1;19;0
WireConnection;11;0;8;2
WireConnection;16;0;12;0
WireConnection;16;1;13;1
WireConnection;16;2;13;2
WireConnection;18;0;45;0
WireConnection;18;1;17;0
WireConnection;25;1;26;0
WireConnection;26;0;28;0
WireConnection;26;1;22;0
WireConnection;12;0;11;0
WireConnection;27;0;14;0
WireConnection;19;1;20;0
WireConnection;35;0;33;0
WireConnection;29;0;25;0
WireConnection;3;0;1;0
WireConnection;3;1;2;0
WireConnection;22;0;24;0
WireConnection;22;1;21;1
WireConnection;0;2;18;0
WireConnection;0;9;47;0
ASEEND*/
//CHKSM=41AE9ACCE59EF23D77618002FB9A19A88DAC6F2B