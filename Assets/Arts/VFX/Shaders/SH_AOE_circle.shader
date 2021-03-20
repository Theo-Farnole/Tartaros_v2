// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_AOE_circle"
{
	Properties
	{
		_VoroScale("VoroScale", Vector) = (5,5,5,5)
		[HDR]_Color("Color", Color) = (1,0.6351262,0,0)
		[HDR]_Color2("Color 2", Color) = (1,0.02020948,0,0)
		_TextureMovement("TextureMovement", Vector) = (0,0,0,0)
		_AngleSpeedMult("AngleSpeedMult", Float) = 1.1
		_lerp("lerp", Range( 0 , 1)) = 0
		_PowerRound("PowerRound", Vector) = (1.52,0.73,0,0)
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
		uniform float2 _PowerRound;
		uniform float4 _VoroScale;
		uniform float _AngleSpeedMult;
		uniform float2 _TextureMovement;
		uniform float4 _Color2;
		uniform float _lerp;


		float2 voronoihash11( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi11( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash11( n + g );
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
			float2 uv_TexCoord9 = i.uv_texcoord + float2( -0.5,-0.5 );
			float smoothstepResult17 = smoothstep( 0.5 , 1.0 , ( 1.0 - length( uv_TexCoord9 ) ));
			float smoothstepResult83 = smoothstep( ( 1.0 - ( _PowerRound.x * smoothstepResult17 ) ) , _PowerRound.y , smoothstepResult17);
			float temp_output_70_0 = ( _Time.y * _AngleSpeedMult );
			float temp_output_48_0 = ( temp_output_70_0 * _AngleSpeedMult );
			float time11 = temp_output_48_0;
			float2 uv_TexCoord31 = i.uv_texcoord + ( _TextureMovement * _Time.y );
			float2 coords11 = uv_TexCoord31 * _VoroScale.y;
			float2 id11 = 0;
			float2 uv11 = 0;
			float voroi11 = voronoi11( coords11, time11, id11, uv11, 0 );
			float4 lerpResult59 = lerp( ( _Color * saturate( smoothstepResult83 ) ) , ( saturate( ( smoothstepResult17 * voroi11 ) ) * _Color2 ) , _lerp);
			o.Emission = lerpResult59.rgb;
			o.Alpha = smoothstepResult17;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
275;73;1281;567;1118.356;-699.531;1.335085;True;False
Node;AmplifyShaderEditor.TextureCoordinatesNode;9;-1331.085,807.7964;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;-0.5,-0.5;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LengthOpNode;8;-1118.773,806.1107;Inherit;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;34;-2669.419,1167.651;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;51;-2271.472,1735.69;Inherit;False;Property;_AngleSpeedMult;AngleSpeedMult;6;0;Create;True;0;0;False;0;False;1.1;1.2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;37;-2683.234,992.1426;Inherit;False;Property;_TextureMovement;TextureMovement;5;0;Create;True;0;0;False;0;False;0,0;0.05,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.OneMinusNode;16;-816.2192,1185.347;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;70;-2178.732,1421.737;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;35;-2410.995,1130.338;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SmoothstepOpNode;17;-625.8201,1188.147;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0.5;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;84;-595.0027,898.4587;Inherit;False;Property;_PowerRound;PowerRound;11;0;Create;True;0;0;False;0;False;1.52,0.73;1.52,0.73;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;31;-1865.454,1257.307;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;85;-445.4731,933.1709;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;48;-2087.708,1557.564;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector4Node;10;-1714.625,1513.624;Inherit;False;Property;_VoroScale;VoroScale;0;0;Create;True;0;0;False;0;False;5,5,5,5;5,10,1,5;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VoronoiNode;11;-1314.595,1353.626;Inherit;True;0;0;1;3;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.OneMinusNode;82;-323.32,1043.886;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;76;-346.9654,1527.683;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;83;-298.8857,822.8206;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.62;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;79;576.4626,1398.575;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;38;898.4083,1391.145;Inherit;False;Property;_Color2;Color 2;4;1;[HDR];Create;True;0;0;False;0;False;1,0.02020948,0,0;0,1,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;64;370.7567,1008.236;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;24;772.9845,854.4688;Inherit;False;Property;_Color;Color;3;1;[HDR];Create;True;0;0;False;0;False;1,0.6351262,0,0;0,0.2076418,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;22;1224.333,921.659;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;40;1205.566,1346.957;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;60;1520.592,1561.547;Inherit;False;Property;_lerp;lerp;7;0;Create;True;0;0;False;0;False;0;0.5;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;18;1159.631,1791.991;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;6.28;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;69;-2596.359,1785.673;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;33;-2221.066,1287.881;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;74;1239.018,1637.196;Inherit;False;Property;_Step;Step;10;0;Create;True;0;0;False;0;False;0;-36.62;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;77;1158.346,2022.501;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;6.28;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;49;-1931.564,1655.393;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;19;933.7761,1930.133;Inherit;False;Property;_PowerFlame;PowerFlame;1;0;Create;True;0;0;False;0;False;5;100;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;45;883.713,1712.125;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;61;-317.0247,1771.832;Inherit;False;Property;_SmoothStep;SmoothStep;8;0;Create;True;0;0;False;0;False;0,0;0.1,-2;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SmoothstepOpNode;73;1429.451,1646.41;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;67;-2600.528,1587.652;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;81;591.161,1186.944;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0.39;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;66;-2599.851,1491.994;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector4Node;65;-2928.225,1609.214;Inherit;False;Property;_VoroSpeed;VoroSpeed;9;0;Create;True;0;0;False;0;False;0,0,0,0;1,1,2,1;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;26;-2413.039,1524.542;Inherit;False;Property;_VertexPos;VertexPos;2;0;Create;True;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;21;131.4515,1059.836;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode;4;-1320.319,533.5559;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VertexColorNode;6;-1312.046,-60.08935;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PosVertexDataNode;2;-1316.182,243.9727;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.NormalVertexDataNode;5;-1318.25,105.3867;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;68;-2603.156,1682.54;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TangentVertexDataNode;3;-1314.114,388.7641;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;50;-1782.943,1781.44;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;43;107.3847,1653.411;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;1;-1311.399,1083.079;Inherit;True;2;0;1;3;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SimpleAddOpNode;75;1724.31,1040.01;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;59;1739.521,1274.68;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0.8207547;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;15;-349.7452,1280.108;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;7;-1120.617,584.3985;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;2308.412,1241.644;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Tartaros/SH_AOE_circle;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;8;0;9;0
WireConnection;16;0;8;0
WireConnection;70;0;34;2
WireConnection;70;1;51;0
WireConnection;35;0;37;0
WireConnection;35;1;34;2
WireConnection;17;0;16;0
WireConnection;31;1;35;0
WireConnection;85;0;84;1
WireConnection;85;1;17;0
WireConnection;48;0;70;0
WireConnection;48;1;51;0
WireConnection;11;0;31;0
WireConnection;11;1;48;0
WireConnection;11;2;10;2
WireConnection;82;0;85;0
WireConnection;76;0;17;0
WireConnection;76;1;11;0
WireConnection;83;0;17;0
WireConnection;83;1;82;0
WireConnection;83;2;84;2
WireConnection;79;0;76;0
WireConnection;64;0;83;0
WireConnection;22;0;24;0
WireConnection;22;1;64;0
WireConnection;40;0;79;0
WireConnection;40;1;38;0
WireConnection;18;1;19;0
WireConnection;69;0;34;2
WireConnection;69;1;65;4
WireConnection;77;0;19;0
WireConnection;49;0;48;0
WireConnection;49;1;51;0
WireConnection;67;0;34;2
WireConnection;67;1;65;2
WireConnection;66;0;34;2
WireConnection;66;1;65;1
WireConnection;68;0;34;2
WireConnection;68;1;65;3
WireConnection;50;0;49;0
WireConnection;50;1;51;0
WireConnection;1;0;31;0
WireConnection;1;1;70;0
WireConnection;1;2;10;1
WireConnection;59;0;22;0
WireConnection;59;1;40;0
WireConnection;59;2;60;0
WireConnection;15;0;17;0
WireConnection;15;1;1;0
WireConnection;7;0;4;2
WireConnection;0;2;59;0
WireConnection;0;9;17;0
ASEEND*/
//CHKSM=1C5EEEFC8FF99825D2F92A4D7E57296F51D836CA