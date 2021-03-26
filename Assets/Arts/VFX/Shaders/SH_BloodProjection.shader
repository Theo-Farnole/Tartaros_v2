// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_BloodProjection"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		[HDR]_Color1("Color 1", Color) = (0,0.5719719,1,1)
		[HDR]_Color0("Color 0", Color) = (0,1,0.6669481,1)
		_ColorSteps("ColorSteps", Vector) = (3,0.1,0,0)
		_ScalePatern("ScalePatern", Float) = 5
		_WorldOffsetDiv("WorldOffsetDiv", Float) = 0.39
		_PaternStep("PaternStep", Vector) = (0.5,0.62,0,0)
		_OpacityStep("OpacityStep", Vector) = (0,1,0,0)
		_BorderColor("BorderColor", Color) = (1,1,1,1)
		_BorderStep("BorderStep", Vector) = (0,1,0,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] _tex3coord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "Transparent+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		#undef TRANSFORM_TEX
		#define TRANSFORM_TEX(tex,name) float4(tex.xy * name##_ST.xy + name##_ST.zw, tex.z, tex.w)
		struct Input
		{
			float4 vertexColor : COLOR;
			float2 uv_texcoord;
			float3 worldPos;
			float3 uv_tex3coord;
		};

		uniform float4 _Color1;
		uniform float4 _ColorSteps;
		uniform float2 _PaternStep;
		uniform float _ScalePatern;
		uniform float _WorldOffsetDiv;
		uniform float4 _Color0;
		uniform float2 _BorderStep;
		uniform float2 _OpacityStep;
		uniform float4 _BorderColor;
		uniform float _Cutoff = 0.5;


		float2 voronoihash105( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi105( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash105( n + g );
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


		float2 voronoihash91( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi91( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash91( n + g );
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
			float4 temp_cast_0 = (_ColorSteps.x).xxxx;
			float4 temp_cast_1 = (_ColorSteps.y).xxxx;
			float RoundZone25 = ( 1.0 - length( ( i.uv_texcoord + float2( -0.5,-0.5 ) ) ) );
			float smoothstepResult101 = smoothstep( _PaternStep.x , _PaternStep.y , RoundZone25);
			float time105 = 0.0;
			float3 ase_worldPos = i.worldPos;
			float2 appendResult10 = (float2(ase_worldPos.x , ( ase_worldPos.y + ase_worldPos.z )));
			float3 uvs3_TexCoord18 = i.uv_tex3coord;
			uvs3_TexCoord18.xy = i.uv_tex3coord.xy + ( appendResult10 / _WorldOffsetDiv );
			float3 WorldUV21 = uvs3_TexCoord18;
			float2 coords105 = WorldUV21.xy * _ScalePatern;
			float2 id105 = 0;
			float2 uv105 = 0;
			float voroi105 = voronoi105( coords105, time105, id105, uv105, 0 );
			float smoothstepResult104 = smoothstep( 1.0 , 1.5 , ( ( 1.0 - voroi105 ) * 1.5 ));
			float time91 = -0.13;
			float2 coords91 = WorldUV21.xy * _ScalePatern;
			float2 id91 = 0;
			float2 uv91 = 0;
			float fade91 = 0.5;
			float voroi91 = 0;
			float rest91 = 0;
			for( int it91 = 0; it91 <8; it91++ ){
			voroi91 += fade91 * voronoi91( coords91, time91, id91, uv91, 0 );
			rest91 += fade91;
			coords91 *= 2;
			fade91 *= 0.5;
			}//Voronoi91
			voroi91 /= rest91;
			float smoothstepResult96 = smoothstep( 1.0 , 1.2 , ( ( 1.0 - voroi91 ) * 1.5 ));
			float4 Patern112 = ( i.vertexColor * ( ( smoothstepResult101 * ( 1.0 - smoothstepResult104 ) ) + ( smoothstepResult101 * ( 1.0 - smoothstepResult96 ) ) ) );
			float4 smoothstepResult80 = smoothstep( temp_cast_0 , temp_cast_1 , Patern112);
			float4 temp_output_85_0 = ( _Color1 * smoothstepResult80 );
			float4 temp_cast_4 = (_ColorSteps.z).xxxx;
			float4 temp_cast_5 = (_ColorSteps.w).xxxx;
			float4 smoothstepResult73 = smoothstep( temp_cast_4 , temp_cast_5 , Patern112);
			float4 temp_output_83_0 = ( ( smoothstepResult73 * _Color0 ) * Patern112 );
			float smoothstepResult128 = smoothstep( _OpacityStep.x , _OpacityStep.y , RoundZone25);
			float temp_output_122_0 = ( temp_output_85_0.a + temp_output_83_0.a + smoothstepResult128 );
			float smoothstepResult130 = smoothstep( _BorderStep.x , _BorderStep.y , temp_output_122_0);
			o.Emission = ( ( temp_output_85_0 + temp_output_83_0 ) + ( smoothstepResult130 * _BorderColor ) ).rgb;
			o.Metallic = ( smoothstepResult80 + smoothstepResult73 ).r;
			o.Alpha = 1;
			clip( temp_output_122_0 - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
253;73;1321;615;422.4864;-151.4667;1;True;False
Node;AmplifyShaderEditor.CommentaryNode;1;-5027.915,-1597.104;Inherit;False;1529.317;369.4531;Comment;7;117;21;18;10;7;4;118;UVs;1,1,1,1;0;0
Node;AmplifyShaderEditor.WorldPosInputsNode;4;-4957.292,-1510.225;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleAddOpNode;7;-4726.474,-1417.215;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;118;-4548.686,-1369.914;Inherit;False;Property;_WorldOffsetDiv;WorldOffsetDiv;7;0;Create;True;0;0;False;0;False;0.39;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;10;-4559.474,-1487.215;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;117;-4197.789,-1476.515;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.CommentaryNode;8;-6230.954,-1628.302;Inherit;False;1012.65;378.5044;Comment;6;25;22;19;16;13;12;RoundZone;1,1,1,1;0;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;18;-3994.044,-1485.235;Inherit;False;0;-1;3;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;21;-3742.279,-1492.165;Inherit;False;WorldUV;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode;12;-6180.954,-1578.302;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;13;-6176.881,-1435.717;Inherit;False;Constant;_Vector1;Vector 1;2;0;Create;True;0;0;False;0;False;-0.5,-0.5;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleAddOpNode;16;-5938.457,-1492.129;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;115;-5515.204,-233.3597;Inherit;False;21;WorldUV;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;116;-5517.987,-326.5844;Inherit;False;Property;_ScalePatern;ScalePatern;5;0;Create;True;0;0;False;0;False;5;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;105;-5130.663,-570.1491;Inherit;True;0;0;1;3;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;2.5;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.VoronoiNode;91;-5140.31,21.33423;Inherit;True;0;0;1;3;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;-0.13;False;2;FLOAT;2;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.LengthOpNode;19;-5801.788,-1491.189;Inherit;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;99;-4900.471,-496.952;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;22;-5621.373,-1492.394;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;92;-4917.695,22.93018;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;102;-4642.502,-488.6525;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;1.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;97;-4659.727,31.22964;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;1.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;25;-5452.07,-1496.596;Inherit;True;RoundZone;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;104;-4364.161,-464.9538;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT;1.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;120;-4905.073,-745.0256;Inherit;False;Property;_PaternStep;PaternStep;8;0;Create;True;0;0;False;0;False;0.5,0.62;0.5,0.62;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.GetLocalVarNode;100;-4907.035,-582.6954;Inherit;False;25;RoundZone;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;96;-4388.635,42.84497;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT;1.2;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;109;-4101.858,-461.7903;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;103;-4065.51,10.09464;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;101;-4633.566,-740.6281;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0.5;False;2;FLOAT;0.62;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;93;-3822.276,-84.8071;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0.51;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;106;-3839.365,-603.7097;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0.51;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;113;-3477.789,-523.5248;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;107;-3477.765,-331.5159;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;114;-3262.972,-442.5023;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;112;-2992.786,-434.6673;Inherit;False;Patern;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.CommentaryNode;65;-1700.851,-317.8405;Inherit;False;1523.412;910.0004;Comment;14;87;85;83;82;81;80;79;74;73;72;71;88;126;127;COLORS;1,1,1,1;0;0
Node;AmplifyShaderEditor.Vector4Node;71;-1650.851,101.4812;Inherit;False;Property;_ColorSteps;ColorSteps;4;0;Create;True;0;0;False;0;False;3,0.1,0,0;3,0.1,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;72;-1571.858,-20.49732;Inherit;False;112;Patern;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;74;-1461.785,377.9691;Inherit;False;Property;_Color0;Color 0;2;1;[HDR];Create;True;0;0;False;0;False;0,1,0.6669481,1;0,0.3430265,0.7169812,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;73;-1302.838,194.6501;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;81;-1022.652,178.4529;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;79;-1535.837,-267.8406;Inherit;False;Property;_Color1;Color 1;1;1;[HDR];Create;True;0;0;False;0;False;0,0.5719719,1,1;0.05913247,0.7169812,0,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;80;-1303.957,52.77903;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;82;-998.202,419.0131;Inherit;False;112;Patern;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;86;-564.1335,645.0436;Inherit;True;25;RoundZone;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;129;-537.4968,852.6488;Inherit;False;Property;_OpacityStep;OpacityStep;9;0;Create;True;0;0;False;0;False;0,1;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;83;-710.6662,297.3993;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;85;-1018.797,-178.1038;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.BreakToComponentsNode;127;-466.5876,329.9624;Inherit;False;COLOR;1;0;COLOR;0,0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.BreakToComponentsNode;126;-767.4377,-171.5691;Inherit;False;COLOR;1;0;COLOR;0,0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SmoothstepOpNode;128;-215.0124,754.631;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;122;-132.1593,336.5209;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;134;182.5136,472.4667;Inherit;False;Property;_BorderStep;BorderStep;11;0;Create;True;0;0;False;0;False;0,1;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.ColorNode;131;428.1678,593.8185;Inherit;False;Property;_BorderColor;BorderColor;10;0;Create;True;0;0;False;0;False;1,1,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;130;463.7441,425.9766;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;132;699.8552,578.2138;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;87;-400.4529,29.60032;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.CommentaryNode;64;-7515.284,-1704.288;Inherit;False;1159.129;479.0177;Comment;6;84;78;76;75;70;69;Opacity;1,1,1,1;0;0
Node;AmplifyShaderEditor.Vector2Node;70;-7273.422,-1368.653;Inherit;False;Property;_OpacityFromPatern;OpacityFromPatern;3;0;Create;True;0;0;False;0;False;0,1;0,0.5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;108;-5510.528,59.8527;Inherit;False;Property;_ScalePatern2;ScalePatern2;6;0;Create;True;0;0;False;0;False;5;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;98;-3396.541,-44.6603;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;75;-7455.735,-1624.189;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;76;-7028.324,-1432.653;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0.47,0,0,0;False;2;COLOR;1.23,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;133;654.77,109.3214;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;84;-6579.001,-1529.321;Inherit;False;Opacity;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;78;-6840.438,-1524.809;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;69;-7455.006,-1436.081;Inherit;False;112;Patern;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;88;-394.9426,-214.3879;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;1087.449,-24.60684;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Tartaros/SH_BloodProjection;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;False;TransparentCutout;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;7;0;4;2
WireConnection;7;1;4;3
WireConnection;10;0;4;1
WireConnection;10;1;7;0
WireConnection;117;0;10;0
WireConnection;117;1;118;0
WireConnection;18;1;117;0
WireConnection;21;0;18;0
WireConnection;16;0;12;0
WireConnection;16;1;13;0
WireConnection;105;0;115;0
WireConnection;105;2;116;0
WireConnection;91;0;115;0
WireConnection;91;2;116;0
WireConnection;19;0;16;0
WireConnection;99;0;105;0
WireConnection;22;0;19;0
WireConnection;92;0;91;0
WireConnection;102;0;99;0
WireConnection;97;0;92;0
WireConnection;25;0;22;0
WireConnection;104;0;102;0
WireConnection;96;0;97;0
WireConnection;109;0;104;0
WireConnection;103;0;96;0
WireConnection;101;0;100;0
WireConnection;101;1;120;1
WireConnection;101;2;120;2
WireConnection;93;0;101;0
WireConnection;93;1;103;0
WireConnection;106;0;101;0
WireConnection;106;1;109;0
WireConnection;107;0;106;0
WireConnection;107;1;93;0
WireConnection;114;0;113;0
WireConnection;114;1;107;0
WireConnection;112;0;114;0
WireConnection;73;0;72;0
WireConnection;73;1;71;3
WireConnection;73;2;71;4
WireConnection;81;0;73;0
WireConnection;81;1;74;0
WireConnection;80;0;72;0
WireConnection;80;1;71;1
WireConnection;80;2;71;2
WireConnection;83;0;81;0
WireConnection;83;1;82;0
WireConnection;85;0;79;0
WireConnection;85;1;80;0
WireConnection;127;0;83;0
WireConnection;126;0;85;0
WireConnection;128;0;86;0
WireConnection;128;1;129;1
WireConnection;128;2;129;2
WireConnection;122;0;126;3
WireConnection;122;1;127;3
WireConnection;122;2;128;0
WireConnection;130;0;122;0
WireConnection;130;1;134;1
WireConnection;130;2;134;2
WireConnection;132;0;130;0
WireConnection;132;1;131;0
WireConnection;87;0;85;0
WireConnection;87;1;83;0
WireConnection;76;0;69;0
WireConnection;76;1;70;1
WireConnection;76;2;70;2
WireConnection;133;0;87;0
WireConnection;133;1;132;0
WireConnection;84;0;78;0
WireConnection;78;0;75;4
WireConnection;78;1;76;0
WireConnection;88;0;80;0
WireConnection;88;1;73;0
WireConnection;0;2;133;0
WireConnection;0;3;88;0
WireConnection;0;10;122;0
ASEEND*/
//CHKSM=5CF3F7890EC3148F23B7A54BC3C218753DE75534