// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_SpawnerGate"
{
	Properties
	{
		_Opacity("Opacity", Float) = 0
		_Color("Color", Color) = (0,0.3473601,1,1)
		_ColorBorder("ColorBorder", Color) = (0,0.1399786,1,1)
		_PaternScale("PaternScale", Float) = 5
		_UVpos("UVpos", Vector) = (0,0,0,0)
		_OpacityPaternMult("OpacityPaternMult", Float) = 0
		_RotaSpeed("RotaSpeed", Float) = 0
		_AngleSpeed("AngleSpeed", Float) = 0
		_OpacityPaternStep("OpacityPaternStep", Vector) = (0,1,0,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Off
		CGPROGRAM
		#include "UnityCG.cginc"
		#include "UnityShaderVariables.cginc"
		#pragma target 5.0
		#pragma surface surf Standard alpha:fade keepalpha noshadow 
		struct Input
		{
			float4 screenPos;
			float3 worldPos;
			float2 uv_texcoord;
		};

		uniform float4 _Color;
		UNITY_DECLARE_DEPTH_TEXTURE( _CameraDepthTexture );
		uniform float4 _CameraDepthTexture_TexelSize;
		uniform float4 _ColorBorder;
		uniform float2 _OpacityPaternStep;
		uniform float _Opacity;
		uniform float _OpacityPaternMult;
		uniform float _PaternScale;
		uniform float _AngleSpeed;
		uniform float2 _UVpos;
		uniform float _RotaSpeed;


		float2 voronoihash63( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi63( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash63( n + g );
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
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float4 ase_screenPosNorm = ase_screenPos / ase_screenPos.w;
			ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
			float screenDepth4 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_screenPosNorm.xy ));
			float distanceDepth4 = ( screenDepth4 - LinearEyeDepth( ase_screenPosNorm.z ) ) / ( 1.0 );
			float DepthFade19 = distanceDepth4;
			float SecondDepthFade70 = ( distanceDepth4 / 1.1 );
			o.Emission = ( ( _Color * DepthFade19 ) + ( SecondDepthFade70 * _ColorBorder ) ).rgb;
			float Opacity18 = ( distanceDepth4 * _Opacity );
			float3 ase_vertex3Pos = mul( unity_WorldToObject, float4( i.worldPos , 1 ) );
			float time63 = ( _Time.y * _AngleSpeed );
			float2 uv_TexCoord66 = i.uv_texcoord + ase_vertex3Pos.xy;
			float cos64 = cos( ( _RotaSpeed * _Time.y ) );
			float sin64 = sin( ( _RotaSpeed * _Time.y ) );
			float2 rotator64 = mul( uv_TexCoord66 - _UVpos , float2x2( cos64 , -sin64 , sin64 , cos64 )) + _UVpos;
			float2 coords63 = rotator64 * _PaternScale;
			float2 id63 = 0;
			float2 uv63 = 0;
			float fade63 = 0.5;
			float voroi63 = 0;
			float rest63 = 0;
			for( int it63 = 0; it63 <8; it63++ ){
			voroi63 += fade63 * voronoi63( coords63, time63, id63, uv63, 0 );
			rest63 += fade63;
			coords63 *= 2;
			fade63 *= 0.5;
			}//Voronoi63
			voroi63 /= rest63;
			float smoothstepResult96 = smoothstep( _OpacityPaternStep.x , _OpacityPaternStep.y , ( Opacity18 * ( ( length( ase_vertex3Pos.z ) * _OpacityPaternMult ) * voroi63 ) ));
			o.Alpha = smoothstepResult96;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
247;73;1289;655;2733.942;986.319;1.445601;True;False
Node;AmplifyShaderEditor.CommentaryNode;22;-3973.62,-856.6982;Inherit;False;2865.027;1151.758;Comment;20;82;16;19;70;18;10;68;11;7;67;2;99;4;98;100;74;13;17;83;101;DEPTHs;1,1,1,1;0;0
Node;AmplifyShaderEditor.TimeNode;65;-1695.636,1476.631;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;92;-1427.974,1361.561;Inherit;False;Property;_RotaSpeed;RotaSpeed;8;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;84;-1518.953,1034.893;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DepthFade;4;-2228.535,-778.5673;Inherit;False;True;False;False;2;1;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;11;-1850.819,-476.8887;Inherit;False;Property;_Opacity;Opacity;0;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;93;-1582.793,1659.198;Inherit;False;Property;_AngleSpeed;AngleSpeed;9;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;94;-1259.954,1392.765;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;85;-1214.375,1655.816;Inherit;False;Property;_UVpos;UVpos;6;0;Create;True;0;0;False;0;False;0,0;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;66;-1228.675,1218.178;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleDivideOpNode;7;-1841.708,-631.3524;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;1.1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;95;-1256.353,1509.178;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;28;-895.1802,1639.112;Inherit;False;Property;_PaternScale;PaternScale;3;0;Create;True;0;0;False;0;False;5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;91;-910.5247,1224.223;Inherit;False;Property;_OpacityPaternMult;OpacityPaternMult;7;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;87;-1154.878,983.8857;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RotatorNode;64;-926.5691,1387.2;Inherit;True;3;0;FLOAT2;0,0;False;1;FLOAT2;0.5,0.5;False;2;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;-1623.233,-635.6326;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;19;-1448.632,-740.3369;Inherit;False;DepthFade;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;63;-577.5414,1412.114;Inherit;True;0;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;3.09;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.RegisterLocalVarNode;70;-1450.167,-357.2982;Inherit;False;SecondDepthFade;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;18;-1434.071,-549.6382;Inherit;False;Opacity;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;90;-691.6586,1184.746;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;21;-596.041,803.9842;Inherit;True;18;Opacity;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;76;-941.3947,19.13074;Inherit;False;70;SecondDepthFade;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;39;-911.9893,131.3112;Inherit;False;Property;_ColorBorder;ColorBorder;2;0;Create;True;0;0;False;0;False;0,0.1399786,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;20;-618.3138,-136.1492;Inherit;False;19;DepthFade;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;9;-626.2927,-329.1934;Inherit;False;Property;_Color;Color;1;0;Create;True;0;0;False;0;False;0,0.3473601,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;77;-313.3439,1347.818;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;97;-607.1168,1002.396;Inherit;False;Property;_OpacityPaternStep;OpacityPaternStep;10;0;Create;True;0;0;False;0;False;0,1;0,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;89;-72.26389,1126.172;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;62;-655.454,87.91733;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;8;-295.1043,-234.7433;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;99;-2466.521,10.51497;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;68;-1836.016,-290.2359;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DistanceOpNode;17;-2847.373,-666.2919;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;74;-2738.351,25.81056;Inherit;False;Property;_DepthFadeOffset2;DepthFadeOffset2;5;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;96;18.99746,947.9326;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;38;-42.80037,-87.99017;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.WorldSpaceCameraPos;82;-3821.428,-79.54491;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;13;-2885.613,-481.271;Inherit;False;Property;_DepthFadeOffset1;DepthFadeOffset1;4;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;100;-2605.805,-461.6243;Inherit;False;Property;_DepthOffset;DepthOffset;11;0;Create;True;0;0;False;0;False;0,0;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.CameraDepthFade;2;-2237.45,-610.1;Inherit;False;3;2;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CameraDepthFade;67;-2172.598,-443.2482;Inherit;False;3;2;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ObjectToWorldTransfNode;83;-3343.438,-333.3248;Inherit;False;1;0;FLOAT4;0,0,0,1;False;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector3Node;101;-3450.915,39.67116;Inherit;False;Property;_EyePositionFix;EyePositionFix;12;0;Create;True;0;0;False;0;False;0,0,0;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.PosVertexDataNode;16;-3194.18,-762.6729;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;98;-2653.718,-613.0563;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;664.2285,247.0926;Float;False;True;-1;7;ASEMaterialInspector;0;0;Standard;Tartaros/SH_SpawnerGate;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;94;0;92;0
WireConnection;94;1;65;2
WireConnection;66;1;84;0
WireConnection;7;0;4;0
WireConnection;95;0;65;2
WireConnection;95;1;93;0
WireConnection;87;0;84;3
WireConnection;64;0;66;0
WireConnection;64;1;85;0
WireConnection;64;2;94;0
WireConnection;10;0;4;0
WireConnection;10;1;11;0
WireConnection;19;0;4;0
WireConnection;63;0;64;0
WireConnection;63;1;95;0
WireConnection;63;2;28;0
WireConnection;70;0;7;0
WireConnection;18;0;10;0
WireConnection;90;0;87;0
WireConnection;90;1;91;0
WireConnection;77;0;90;0
WireConnection;77;1;63;0
WireConnection;89;0;21;0
WireConnection;89;1;77;0
WireConnection;62;0;76;0
WireConnection;62;1;39;0
WireConnection;8;0;9;0
WireConnection;8;1;20;0
WireConnection;99;0;17;0
WireConnection;99;1;74;0
WireConnection;68;0;4;0
WireConnection;68;1;67;0
WireConnection;17;0;16;0
WireConnection;17;1;83;0
WireConnection;96;0;89;0
WireConnection;96;1;97;1
WireConnection;96;2;97;2
WireConnection;38;0;8;0
WireConnection;38;1;62;0
WireConnection;2;2;101;0
WireConnection;2;0;98;0
WireConnection;2;1;100;1
WireConnection;67;2;101;0
WireConnection;67;0;99;0
WireConnection;67;1;100;2
WireConnection;83;0;101;0
WireConnection;98;0;17;0
WireConnection;98;1;13;0
WireConnection;0;2;38;0
WireConnection;0;9;96;0
ASEEND*/
//CHKSM=6900077FDFB38B9D2436C87D22F1B798C724D78F