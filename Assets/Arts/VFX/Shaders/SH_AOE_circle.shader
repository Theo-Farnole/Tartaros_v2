// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_AOE_circle"
{
	Properties
	{
		_VoroAngleSpeed("VoroAngleSpeed", Float) = 1
		[HDR]_Color("Color", Color) = (0,0.7453065,1,1)
		_Power("Power", Float) = 10
		[HDR]_Color2("Color 2", Color) = (0,0.7453065,1,1)
		_SmoothStep("SmoothStep", Vector) = (0.55,1,0,0)
		_VoroScale("VoroScale", Float) = 1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard alpha:fade keepalpha noshadow 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float4 _Color;
		uniform float _VoroScale;
		uniform float _VoroAngleSpeed;
		uniform float2 _SmoothStep;
		uniform float _Power;
		uniform float4 _Color2;


		float2 voronoihash86( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi86( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash86( n + g );
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
			float temp_output_87_0 = length( ( i.uv_texcoord + float2( -0.5,-0.5 ) ) );
			float time86 = ( _Time.y * _VoroAngleSpeed );
			float2 temp_cast_0 = (temp_output_87_0).xx;
			float2 coords86 = temp_cast_0 * _VoroScale;
			float2 id86 = 0;
			float2 uv86 = 0;
			float fade86 = 0.5;
			float voroi86 = 0;
			float rest86 = 0;
			for( int it86 = 0; it86 <8; it86++ ){
			voroi86 += fade86 * voronoi86( coords86, time86, id86, uv86, 0 );
			rest86 += fade86;
			coords86 *= 2;
			fade86 *= 0.5;
			}//Voronoi86
			voroi86 /= rest86;
			float temp_output_103_0 = ( 1.0 - ( saturate( ( temp_output_87_0 * voroi86 ) ) * 100.0 ) );
			float smoothstepResult99 = smoothstep( _SmoothStep.x , _SmoothStep.y , ( 1.0 - temp_output_87_0 ));
			float temp_output_105_0 = ( temp_output_103_0 * smoothstepResult99 );
			float temp_output_113_0 = ( saturate( temp_output_87_0 ) * _Power );
			o.Emission = ( ( _Color * temp_output_105_0 ) + ( ( ( temp_output_113_0 / temp_output_103_0 ) * temp_output_113_0 ) * _Color2 ) ).rgb;
			o.Alpha = temp_output_105_0;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
253;73;1321;615;-1692.406;-1931.517;1.859428;True;False
Node;AmplifyShaderEditor.TexCoordVertexDataNode;88;525.1668,1913.657;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;90;547.4256,2047.217;Inherit;False;Constant;_Vector0;Vector 0;0;0;Create;True;0;0;False;0;False;-0.5,-0.5;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TimeNode;91;885.5923,2245.768;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;92;933.2916,2411.125;Inherit;False;Property;_VoroAngleSpeed;VoroAngleSpeed;0;0;Create;True;0;0;False;0;False;1;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;89;816.1302,1975.667;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;108;962.2626,2509.006;Inherit;False;Property;_VoroScale;VoroScale;5;0;Create;True;0;0;False;0;False;1;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;93;1149.529,2333.216;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;87;1045.419,1978.086;Inherit;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;86;1337.748,2307.175;Inherit;True;2;0;1;3;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;-9.97;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;104;1584.477,1854.911;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;94;1850.612,1852.007;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;111;1885.999,2507.084;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;97;2084.232,1851.651;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;100;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;112;1893.5,2735.524;Inherit;False;Property;_Power;Power;2;0;Create;True;0;0;False;0;False;10;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;106;1596.708,2171.047;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;107;2160.737,2256.116;Inherit;False;Property;_SmoothStep;SmoothStep;4;0;Create;True;0;0;False;0;False;0.55,1;0.5,2.5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;113;2150.306,2557.681;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;103;2372.484,1851.417;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;99;2399.177,2169.792;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0.55;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;119;2625.9,2373.747;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;118;2996.948,2507.284;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;95;2727.645,1883.218;Inherit;False;Property;_Color;Color;1;1;[HDR];Create;True;0;0;False;0;False;0,0.7453065,1,1;0,5.178137,8.574187,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;105;2719.853,2100.827;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;110;3159.587,2821.668;Inherit;False;Property;_Color2;Color 2;2;1;[HDR];Create;True;0;0;False;0;False;0,0.7453065,1,1;0,0,2,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;96;3037.858,1885.717;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;115;3497.263,2719.475;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;114;2609.099,2814.07;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;122;2440.844,2669.639;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;109;3354.281,2008.975;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;116;2308.683,2842.097;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;3649.849,1902.565;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Tartaros/SH_AOE_circle;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;89;0;88;0
WireConnection;89;1;90;0
WireConnection;93;0;91;2
WireConnection;93;1;92;0
WireConnection;87;0;89;0
WireConnection;86;0;87;0
WireConnection;86;1;93;0
WireConnection;86;2;108;0
WireConnection;104;0;87;0
WireConnection;104;1;86;0
WireConnection;94;0;104;0
WireConnection;111;0;87;0
WireConnection;97;0;94;0
WireConnection;106;0;87;0
WireConnection;113;0;111;0
WireConnection;113;1;112;0
WireConnection;103;0;97;0
WireConnection;99;0;106;0
WireConnection;99;1;107;1
WireConnection;99;2;107;2
WireConnection;119;0;113;0
WireConnection;119;1;103;0
WireConnection;118;0;119;0
WireConnection;118;1;113;0
WireConnection;105;0;103;0
WireConnection;105;1;99;0
WireConnection;96;0;95;0
WireConnection;96;1;105;0
WireConnection;115;0;118;0
WireConnection;115;1;110;0
WireConnection;122;0;113;0
WireConnection;109;0;96;0
WireConnection;109;1;115;0
WireConnection;0;2;109;0
WireConnection;0;9;105;0
ASEEND*/
//CHKSM=43A1EDB13A85E1B8F1ECD381C95202E8986373D9