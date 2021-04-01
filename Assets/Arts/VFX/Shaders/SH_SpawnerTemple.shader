// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_SpawnerTemple"
{
	Properties
	{
		_Opacity("Opacity", Float) = 0
		_Color("Color", Color) = (0,0.3473601,1,1)
		_ColorBorder("ColorBorder", Color) = (0,0.1399786,1,1)
		_PaternScale("PaternScale", Float) = 5
		_DepthFadeOffset1("DepthFadeOffset1", Float) = 0
		_DepthFadeOffset2("DepthFadeOffset2", Float) = 0
		_UVpos("UVpos", Vector) = (0,0,0,0)
		_OpacityPaternMult("OpacityPaternMult", Float) = 0
		_RotaSpeed("RotaSpeed", Float) = 0
		_AngleSpeed("AngleSpeed", Float) = 0
		_OpacityPaternStep("OpacityPaternStep", Vector) = (0,1,0,0)
		_DepthOffset("DepthOffset", Vector) = (0,0,0,0)
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
		#pragma surface surf Standard alpha:fade keepalpha noshadow vertex:vertexDataFunc 
		struct Input
		{
			float4 screenPos;
			float3 worldPos;
			float customSurfaceDepth2;
			float customSurfaceDepth67;
			float2 uv_texcoord;
		};

		uniform float4 _Color;
		UNITY_DECLARE_DEPTH_TEXTURE( _CameraDepthTexture );
		uniform float4 _CameraDepthTexture_TexelSize;
		uniform float _DepthFadeOffset1;
		uniform float2 _DepthOffset;
		uniform float _DepthFadeOffset2;
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


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float3 customSurfaceDepth2 = _WorldSpaceCameraPos;
			o.customSurfaceDepth2 = -UnityObjectToViewPos( customSurfaceDepth2 ).z;
			float3 customSurfaceDepth67 = _WorldSpaceCameraPos;
			o.customSurfaceDepth67 = -UnityObjectToViewPos( customSurfaceDepth67 ).z;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float4 ase_screenPosNorm = ase_screenPos / ase_screenPos.w;
			ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
			float screenDepth4 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_screenPosNorm.xy ));
			float distanceDepth4 = ( screenDepth4 - LinearEyeDepth( ase_screenPosNorm.z ) ) / ( 1.0 );
			float3 ase_vertex3Pos = mul( unity_WorldToObject, float4( i.worldPos , 1 ) );
			float4 transform83 = mul(unity_ObjectToWorld,float4( _WorldSpaceCameraPos , 0.0 ));
			float temp_output_17_0 = distance( float4( ase_vertex3Pos , 0.0 ) , transform83 );
			float cameraDepthFade2 = (( i.customSurfaceDepth2 -_ProjectionParams.y - _DepthOffset.x ) / ( temp_output_17_0 * _DepthFadeOffset1 ));
			float temp_output_7_0 = ( distanceDepth4 / cameraDepthFade2 );
			float DepthFade19 = temp_output_7_0;
			float cameraDepthFade67 = (( i.customSurfaceDepth67 -_ProjectionParams.y - _DepthOffset.y ) / ( temp_output_17_0 * _DepthFadeOffset2 ));
			float SecondDepthFade70 = ( distanceDepth4 / cameraDepthFade67 );
			o.Emission = ( ( _Color * DepthFade19 ) + ( SecondDepthFade70 * _ColorBorder ) ).rgb;
			float Opacity18 = ( temp_output_7_0 * _Opacity );
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
232;73;1323;655;5212.586;1251.363;3.140443;True;False
Node;AmplifyShaderEditor.CommentaryNode;22;-3975.62,-856.6982;Inherit;False;1980.943;1028.676;Comment;17;18;10;19;11;7;4;2;17;13;16;68;70;74;82;83;98;100;DEPTHs;1,1,1,1;0;0
Node;AmplifyShaderEditor.WorldSpaceCameraPos;82;-3916.383,-59.69961;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.ObjectToWorldTransfNode;83;-3636.02,-56.17384;Inherit;False;1;0;FLOAT4;0,0,0,1;False;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PosVertexDataNode;16;-3893.62,-666.3617;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DistanceOpNode;17;-3546.813,-569.9807;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;13;-3585.053,-384.9597;Inherit;False;Property;_DepthFadeOffset1;DepthFadeOffset1;4;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;74;-3586.672,-300.2835;Inherit;False;Property;_DepthFadeOffset2;DepthFadeOffset2;5;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;100;-3247.746,-102.1867;Inherit;False;Property;_DepthOffset;DepthOffset;11;0;Create;True;0;0;False;0;False;0,0;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;98;-3353.158,-516.7451;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;99;-3314.842,-315.5791;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;84;-770.1393,1223.618;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.CameraDepthFade;2;-3188.479,-610.1;Inherit;False;3;2;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;65;-946.8217,1665.356;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;92;-679.1595,1550.286;Inherit;False;Property;_RotaSpeed;RotaSpeed;8;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DepthFade;4;-3179.564,-778.5673;Inherit;False;True;False;False;2;1;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.CameraDepthFade;67;-3125.292,-394.9477;Inherit;False;3;2;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;7;-2794.182,-631.3524;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;11;-2801.847,-476.8887;Inherit;False;Property;_Opacity;Opacity;0;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;93;-833.9786,1847.923;Inherit;False;Property;_AngleSpeed;AngleSpeed;9;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;94;-511.1396,1581.49;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;85;-465.5611,1844.541;Inherit;False;Property;_UVpos;UVpos;6;0;Create;True;0;0;False;0;False;0,0;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;66;-479.8609,1406.903;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;28;-146.3659,1827.837;Inherit;False;Property;_PaternScale;PaternScale;3;0;Create;True;0;0;False;0;False;5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;95;-507.5387,1697.903;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;91;-161.7104,1412.948;Inherit;False;Property;_OpacityPaternMult;OpacityPaternMult;7;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;87;-406.0638,1172.611;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RotatorNode;64;-177.7549,1575.925;Inherit;True;3;0;FLOAT2;0,0;False;1;FLOAT2;0.5,0.5;False;2;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;68;-2787.044,-290.2359;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;-2559.806,-543.114;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;18;-2385.1,-549.6382;Inherit;False;Opacity;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;63;171.2727,1600.839;Inherit;True;0;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;3.09;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.RegisterLocalVarNode;70;-2392.523,-399.2203;Inherit;False;SecondDepthFade;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;19;-2399.661,-740.3369;Inherit;False;DepthFade;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;90;57.15559,1373.471;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;9;-412.9338,52.12882;Inherit;False;Property;_Color;Color;1;0;Create;True;0;0;False;0;False;0,0.3473601,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;76;-728.0358,400.453;Inherit;False;70;SecondDepthFade;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;39;-698.6304,512.6335;Inherit;False;Property;_ColorBorder;ColorBorder;2;0;Create;True;0;0;False;0;False;0,0.1399786,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;20;-404.9549,245.173;Inherit;False;19;DepthFade;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;77;435.4702,1536.543;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;21;152.7731,992.7096;Inherit;True;18;Opacity;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;8;-81.7454,146.579;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;62;-442.0951,469.2396;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.Vector2Node;97;141.6973,1191.121;Inherit;False;Property;_OpacityPaternStep;OpacityPaternStep;10;0;Create;True;0;0;False;0;False;0,1;0,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;89;676.5502,1314.897;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;96;767.8115,1136.658;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;38;170.5585,293.3321;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;664.2285,247.0926;Float;False;True;-1;7;ASEMaterialInspector;0;0;Standard;Tartaros/SH_SpawnerTemple;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;83;0;82;0
WireConnection;17;0;16;0
WireConnection;17;1;83;0
WireConnection;98;0;17;0
WireConnection;98;1;13;0
WireConnection;99;0;17;0
WireConnection;99;1;74;0
WireConnection;2;2;82;0
WireConnection;2;0;98;0
WireConnection;2;1;100;1
WireConnection;67;2;82;0
WireConnection;67;0;99;0
WireConnection;67;1;100;2
WireConnection;7;0;4;0
WireConnection;7;1;2;0
WireConnection;94;0;92;0
WireConnection;94;1;65;2
WireConnection;66;1;84;0
WireConnection;95;0;65;2
WireConnection;95;1;93;0
WireConnection;87;0;84;3
WireConnection;64;0;66;0
WireConnection;64;1;85;0
WireConnection;64;2;94;0
WireConnection;68;0;4;0
WireConnection;68;1;67;0
WireConnection;10;0;7;0
WireConnection;10;1;11;0
WireConnection;18;0;10;0
WireConnection;63;0;64;0
WireConnection;63;1;95;0
WireConnection;63;2;28;0
WireConnection;70;0;68;0
WireConnection;19;0;7;0
WireConnection;90;0;87;0
WireConnection;90;1;91;0
WireConnection;77;0;90;0
WireConnection;77;1;63;0
WireConnection;8;0;9;0
WireConnection;8;1;20;0
WireConnection;62;0;76;0
WireConnection;62;1;39;0
WireConnection;89;0;21;0
WireConnection;89;1;77;0
WireConnection;96;0;89;0
WireConnection;96;1;97;1
WireConnection;96;2;97;2
WireConnection;38;0;8;0
WireConnection;38;1;62;0
WireConnection;0;2;38;0
WireConnection;0;9;96;0
ASEEND*/
//CHKSM=C7C8AFAF12D236A2D07F814DB9406BD8DAD5C895