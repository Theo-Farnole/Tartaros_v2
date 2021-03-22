// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "SH_CosmicSmoke"
{
	Properties
	{
		[HDR]_Color0("Color 0", Color) = (0,0.5719719,1,1)
		[HDR]_Color1("Color 1", Color) = (0,1,0.6669481,1)
		_VoroPaternScale("VoroPaternScale", Float) = 0.35
		_VoroBorderScale("VoroBorderScale", Float) = 1
		_BorderSpeed("BorderSpeed", Float) = 1
		_StepOutter("StepOutter", Float) = 2.5
		_OpacityFromPatern("OpacityFromPatern", Vector) = (0,20,0,0)
		_StepInner("StepInner", Vector) = (0,1,0,0)
		_PaternPower("PaternPower", Float) = 2.53
		_ColorSteps("ColorSteps", Vector) = (3,0.1,0,0)
		[HideInInspector] _tex3coord( "", 2D ) = "white" {}
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
		#pragma surface surf Unlit alpha:fade keepalpha noshadow 
		#undef TRANSFORM_TEX
		#define TRANSFORM_TEX(tex,name) float4(tex.xy * name##_ST.xy + name##_ST.zw, tex.z, tex.w)
		struct Input
		{
			float3 worldPos;
			float3 uv_tex3coord;
			float2 uv_texcoord;
			float4 vertexColor : COLOR;
		};

		uniform float4 _Color0;
		uniform float4 _ColorSteps;
		uniform float _VoroBorderScale;
		uniform float _BorderSpeed;
		uniform float _StepOutter;
		uniform float2 _StepInner;
		uniform float _VoroPaternScale;
		uniform float _PaternPower;
		uniform float4 _Color1;
		uniform float2 _OpacityFromPatern;


		float2 voronoihash20( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi20( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash20( n + g );
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


		float2 voronoihash1( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi1( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash1( n + g );
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


		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float time20 = ( _Time.y * _BorderSpeed );
			float3 break105 = ( float3(1,0.5,0) * _Time.y );
			float3 appendResult106 = (float3(sin( break105.x ) , break105.y , break105.z));
			float3 ase_worldPos = i.worldPos;
			float3 uvs3_TexCoord98 = i.uv_tex3coord;
			uvs3_TexCoord98.xy = i.uv_tex3coord.xy + ase_worldPos.xy;
			float3 uvs3_TexCoord72 = i.uv_tex3coord;
			uvs3_TexCoord72.xy = i.uv_tex3coord.xy + ( appendResult106 + uvs3_TexCoord98 ).xy;
			float3 MoveUV116 = uvs3_TexCoord72;
			float2 coords20 = MoveUV116.xy * _VoroBorderScale;
			float2 id20 = 0;
			float2 uv20 = 0;
			float fade20 = 0.5;
			float voroi20 = 0;
			float rest20 = 0;
			for( int it20 = 0; it20 <8; it20++ ){
			voroi20 += fade20 * voronoi20( coords20, time20, id20, uv20, 0 );
			rest20 += fade20;
			coords20 *= 2;
			fade20 *= 0.5;
			}//Voronoi20
			voroi20 /= rest20;
			float RoundZone17 = ( 1.0 - length( ( i.uv_texcoord + float2( -0.5,-0.5 ) ) ) );
			float smoothstepResult62 = smoothstep( 0.5 , 1.0 , RoundZone17);
			float smoothstepResult70 = smoothstep( voroi20 , ( voroi20 * _StepOutter ) , smoothstepResult62);
			float smoothstepResult83 = smoothstep( ( smoothstepResult70 * _StepInner.x ) , _StepInner.y , smoothstepResult70);
			float NoisedRound26 = ( smoothstepResult70 + smoothstepResult83 );
			float time1 = 0.0;
			float3 WorldUV129 = uvs3_TexCoord98;
			float2 coords1 = WorldUV129.xy * _VoroPaternScale;
			float2 id1 = 0;
			float2 uv1 = 0;
			float fade1 = 0.5;
			float voroi1 = 0;
			float rest1 = 0;
			for( int it1 = 0; it1 <7; it1++ ){
			voroi1 += fade1 * voronoi1( coords1, time1, id1, uv1, 0 );
			rest1 += fade1;
			coords1 *= 2;
			fade1 *= 0.5;
			}//Voronoi1
			voroi1 /= rest1;
			float temp_output_112_0 = ( RoundZone17 * _PaternPower );
			float Patern41 = ( ( NoisedRound26 + 0.0 ) * ( ( voroi1 * temp_output_112_0 ) + temp_output_112_0 ) );
			float smoothstepResult133 = smoothstep( _ColorSteps.x , _ColorSteps.y , Patern41);
			float smoothstepResult134 = smoothstep( _ColorSteps.z , _ColorSteps.w , Patern41);
			o.Emission = ( ( _Color0 * smoothstepResult133 ) + ( smoothstepResult134 * _Color1 ) ).rgb;
			float smoothstepResult52 = smoothstep( _OpacityFromPatern.x , _OpacityFromPatern.y , Patern41);
			float Opacity40 = ( i.vertexColor.a * smoothstepResult52 );
			o.Alpha = Opacity40;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
270;73;1265;601;1856.225;679.1102;2.699889;True;False
Node;AmplifyShaderEditor.TimeNode;89;-3767.876,-1936.782;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector3Node;137;-3780.795,-2155.127;Inherit;False;Constant;_Vector1;Vector 1;11;0;Create;True;0;0;False;0;False;1,0.5,0;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;97;-3511.375,-1988.045;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.BreakToComponentsNode;105;-3337.176,-1987.928;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SinOpNode;107;-3038.1,-1997.693;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;16;-3270.735,-1506.776;Inherit;False;990.4111;425.7622;Comment;6;17;13;10;11;5;12;RoundZone;1,1,1,1;0;0
Node;AmplifyShaderEditor.WorldPosInputsNode;71;-3145.431,-1806.972;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.DynamicAppendNode;106;-2846.9,-1990.995;Inherit;False;FLOAT3;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;98;-2919.35,-1791.056;Inherit;False;0;-1;3;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TexCoordVertexDataNode;5;-3220.735,-1456.776;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;12;-3175.839,-1338.103;Inherit;False;Constant;_Vector0;Vector 0;2;0;Create;True;0;0;False;0;False;-0.5,-0.5;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleAddOpNode;99;-2664.621,-1944.008;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleAddOpNode;11;-2978.238,-1370.603;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.LengthOpNode;10;-2841.569,-1369.663;Inherit;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;72;-2481.479,-1993.973;Inherit;False;0;-1;3;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TimeNode;22;-1888.578,-1462.41;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;13;-2661.154,-1370.868;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;116;-2232.698,-2000.903;Inherit;False;MoveUV;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;27;-1867.411,-1306.342;Inherit;False;Property;_BorderSpeed;BorderSpeed;4;0;Create;True;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;28;-1644.164,-1406.815;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;117;-1635.465,-1574.393;Inherit;False;116;MoveUV;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;17;-2491.85,-1375.07;Inherit;True;RoundZone;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;53;-1437.584,-1294.605;Inherit;False;Property;_VoroBorderScale;VoroBorderScale;3;0;Create;True;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;24;-1170.902,-1361.802;Inherit;False;Property;_StepOutter;StepOutter;5;0;Create;True;0;0;False;0;False;2.5;0.25;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;20;-1427.172,-1566.592;Inherit;True;0;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;10;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.GetLocalVarNode;18;-1766.686,-1846.488;Inherit;True;17;RoundZone;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;76;-973.0991,-1424.072;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;62;-1491.417,-1840.133;Inherit;True;3;0;FLOAT;0.32;False;1;FLOAT;0.5;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;86;-354.1373,-1384.821;Inherit;False;Property;_StepInner;StepInner;7;0;Create;True;0;0;False;0;False;0,1;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SmoothstepOpNode;70;-398.8772,-1622.557;Inherit;True;3;0;FLOAT;0.32;False;1;FLOAT;-0.17;False;2;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;79;-133.8432,-1444.527;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;129;-2653.117,-1777.572;Inherit;False;WorldUV;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SmoothstepOpNode;83;108.6008,-1488.816;Inherit;True;3;0;FLOAT;0.32;False;1;FLOAT;-0.17;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;42;-3261.907,-914.9611;Inherit;False;1442;823.9999;Comment;12;31;34;1;41;4;111;112;115;118;127;128;131;Patern;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleAddOpNode;85;466.0327,-1557.216;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;115;-2935.282,-236.0451;Inherit;False;Property;_PaternPower;PaternPower;8;0;Create;True;0;0;False;0;False;2.53;2.53;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;34;-3196.688,-326.4573;Inherit;True;17;RoundZone;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;4;-3180.685,-450.9655;Inherit;False;Property;_VoroPaternScale;VoroPaternScale;2;0;Create;True;0;0;False;0;False;0.35;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;118;-3171.273,-574.0144;Inherit;False;129;WorldUV;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;112;-2732.722,-311.5286;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;26;725.2785,-1563.937;Inherit;True;NoisedRound;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;1;-2898.428,-536.5865;Inherit;True;0;0;1;0;7;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;128;-2574.238,-456.7398;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;31;-2945.22,-786.3171;Inherit;True;26;NoisedRound;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;127;-2585.998,-610.4008;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;131;-2393.641,-416.9207;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;111;-2236.822,-566.1958;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;41;-2043.911,-576.9614;Inherit;True;Patern;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;46;-3241.177,59.58495;Inherit;False;1159.129;479.0177;Comment;6;52;51;40;36;44;37;Opacity;1,1,1,1;0;0
Node;AmplifyShaderEditor.GetLocalVarNode;44;-3179.711,326.6051;Inherit;False;41;Patern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;51;-2999.314,395.2199;Inherit;False;Property;_OpacityFromPatern;OpacityFromPatern;6;0;Create;True;0;0;False;0;False;0,20;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SmoothstepOpNode;52;-2754.215,331.2196;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0.47;False;2;FLOAT;1.23;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector4Node;135;-1049.975,149.3606;Inherit;False;Property;_ColorSteps;ColorSteps;9;0;Create;True;0;0;False;0;False;3,0.1,0,0;0,0,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;43;-970.9833,27.38192;Inherit;False;41;Patern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;37;-3181.628,139.6844;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;123;-860.9086,425.8483;Inherit;False;Property;_Color1;Color 1;1;1;[HDR];Create;True;0;0;False;0;False;0,1,0.6669481,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;36;-2566.33,239.0636;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;2;-934.962,-219.961;Inherit;False;Property;_Color0;Color 0;0;1;[HDR];Create;True;0;0;False;0;False;0,0.5719719,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;134;-701.9612,242.5293;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;133;-703.0802,100.6582;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;125;-421.776,226.3318;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;40;-2307.228,234.552;Inherit;False;Opacity;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3;-417.9213,-130.2245;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;122;246.4995,290.1445;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;126;560.5507,61.0423;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TangentVertexDataNode;7;1210.516,301.5765;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;23;-476.882,-1237.679;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.39;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;45;567.1671,303.417;Inherit;True;40;Opacity;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;9;1186.572,-2.221713;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleSubtractOpNode;124;197.0787,484.0463;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;60;-612.6577,-1920.819;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NormalVertexDataNode;6;1213.72,162.1727;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;82;48.0422,-1120.572;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;81;-151.5011,-1182.879;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;69;-1241.969,-2147.087;Inherit;True;3;0;FLOAT;0.32;False;1;FLOAT;0;False;2;FLOAT;0.47;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;78;-392.4756,-1889.885;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;25;-160.2648,-1858.935;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;8;1213.72,442.5831;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;868.8611,14.92953;Float;False;True;-1;2;ASEMaterialInspector;0;0;Unlit;SH_CosmicSmoke;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;97;0;137;0
WireConnection;97;1;89;2
WireConnection;105;0;97;0
WireConnection;107;0;105;0
WireConnection;106;0;107;0
WireConnection;106;1;105;1
WireConnection;106;2;105;2
WireConnection;98;1;71;0
WireConnection;99;0;106;0
WireConnection;99;1;98;0
WireConnection;11;0;5;0
WireConnection;11;1;12;0
WireConnection;10;0;11;0
WireConnection;72;1;99;0
WireConnection;13;0;10;0
WireConnection;116;0;72;0
WireConnection;28;0;22;2
WireConnection;28;1;27;0
WireConnection;17;0;13;0
WireConnection;20;0;117;0
WireConnection;20;1;28;0
WireConnection;20;2;53;0
WireConnection;76;0;20;0
WireConnection;76;1;24;0
WireConnection;62;0;18;0
WireConnection;70;0;62;0
WireConnection;70;1;20;0
WireConnection;70;2;76;0
WireConnection;79;0;70;0
WireConnection;79;1;86;1
WireConnection;129;0;98;0
WireConnection;83;0;70;0
WireConnection;83;1;79;0
WireConnection;83;2;86;2
WireConnection;85;0;70;0
WireConnection;85;1;83;0
WireConnection;112;0;34;0
WireConnection;112;1;115;0
WireConnection;26;0;85;0
WireConnection;1;0;118;0
WireConnection;1;2;4;0
WireConnection;128;0;1;0
WireConnection;128;1;112;0
WireConnection;127;0;31;0
WireConnection;131;0;128;0
WireConnection;131;1;112;0
WireConnection;111;0;127;0
WireConnection;111;1;131;0
WireConnection;41;0;111;0
WireConnection;52;0;44;0
WireConnection;52;1;51;1
WireConnection;52;2;51;2
WireConnection;36;0;37;4
WireConnection;36;1;52;0
WireConnection;134;0;43;0
WireConnection;134;1;135;3
WireConnection;134;2;135;4
WireConnection;133;0;43;0
WireConnection;133;1;135;1
WireConnection;133;2;135;2
WireConnection;125;0;134;0
WireConnection;125;1;123;0
WireConnection;40;0;36;0
WireConnection;3;0;2;0
WireConnection;3;1;133;0
WireConnection;126;0;3;0
WireConnection;126;1;125;0
WireConnection;82;0;81;4
WireConnection;0;2;126;0
WireConnection;0;9;45;0
ASEEND*/
//CHKSM=56FB4F269645E828065A9B8C70CF7189C9ED8F61