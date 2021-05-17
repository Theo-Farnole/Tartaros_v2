// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_DepthFade"
{
	Properties
	{
		_Dist("Dist", Float) = 2
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityCG.cginc"
		#pragma target 3.0
		#pragma surface surf Unlit alpha:fade keepalpha noshadow vertex:vertexDataFunc 
		struct Input
		{
			float4 screenPosition17;
		};

		UNITY_DECLARE_DEPTH_TEXTURE( _CameraDepthTexture );
		uniform float4 _CameraDepthTexture_TexelSize;
		uniform float _Dist;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float3 ase_vertex3Pos = v.vertex.xyz;
			float3 vertexPos17 = ase_vertex3Pos;
			float4 ase_screenPos17 = ComputeScreenPos( UnityObjectToClipPos( vertexPos17 ) );
			o.screenPosition17 = ase_screenPos17;
		}

		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float4 ase_screenPos17 = i.screenPosition17;
			float4 ase_screenPosNorm17 = ase_screenPos17 / ase_screenPos17.w;
			ase_screenPosNorm17.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm17.z : ase_screenPosNorm17.z * 0.5 + 0.5;
			float screenDepth17 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_screenPosNorm17.xy ));
			float distanceDepth17 = abs( ( screenDepth17 - LinearEyeDepth( ase_screenPosNorm17.z ) ) / ( _Dist ) );
			float3 temp_cast_0 = (distanceDepth17).xxx;
			o.Emission = temp_cast_0;
			o.Alpha = 1;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
277;73;1293;584;142.9886;689.0883;1.660736;True;False
Node;AmplifyShaderEditor.PosVertexDataNode;39;578.8879,-489.4653;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;18;680.3298,-59.19542;Inherit;False;Property;_Dist;Dist;4;0;Create;True;0;0;False;0;False;2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;35;539.3453,-323.1076;Inherit;False;Property;_yOffset;yOffset;6;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;40;797.084,-331.8141;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;41;891.0958,-530.7374;Inherit;False;FLOAT3;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;42;1305.173,-66.31268;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;10;-987.368,468.2063;Inherit;False;Property;_Offset;Offset;1;0;Create;True;0;0;False;0;False;0;41.58;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;38;563.7596,-630.3965;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.CameraWorldClipPlanes;3;-1035.507,35.06288;Inherit;False;Far;0;1;FLOAT4;0
Node;AmplifyShaderEditor.ColorNode;13;-5.960899,-346.7221;Inherit;False;Property;_Color;Color;2;1;[HDR];Create;True;0;0;False;0;False;1,0,0,1;0,0.8934026,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;14;299.7661,-158.5673;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.Vector2Node;16;0.5666955,70.2326;Inherit;False;Property;_SmoothStep;SmoothStep;3;0;Create;True;0;0;False;0;False;0,1;5,10;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SmoothstepOpNode;12;291.9497,77.58067;Inherit;False;3;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;2;FLOAT4;1,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RangedFloatNode;7;-201.4897,-154.964;Inherit;False;Property;_Multiply;Multiply;0;0;Create;True;0;0;False;0;False;0;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;5;-448.5557,77.80688;Inherit;True;2;0;FLOAT4;0,0,0,0;False;1;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.ScreenPosInputsNode;6;-1031.321,274.9003;Float;False;1;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector3Node;36;519.6761,-205.1903;Inherit;False;Property;_Vector0;Vector 0;7;0;Create;True;0;0;False;0;False;0,0,0;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.OneMinusNode;8;-200.8681,-24.89371;Inherit;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;4;-774.0148,-50.23723;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;9;8.731995,-84.09377;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;11;-738.5681,358.6063;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DepthFade;17;897.2925,-78.50391;Inherit;False;True;False;True;2;1;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;43;1002.919,21.7063;Inherit;False;Property;_Power;Power;5;0;Create;True;0;0;False;0;False;0.1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenDepthNode;1;-1052.157,-73.6676;Inherit;False;0;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;34;1537.942,-110.1421;Float;False;True;-1;2;ASEMaterialInspector;0;0;Unlit;Tartaros/SH_DepthFade;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;40;0;39;2
WireConnection;40;1;35;0
WireConnection;41;0;39;1
WireConnection;41;1;40;0
WireConnection;41;2;39;3
WireConnection;42;1;43;0
WireConnection;14;0;13;0
WireConnection;14;1;9;0
WireConnection;12;0;9;0
WireConnection;12;1;16;1
WireConnection;12;2;16;2
WireConnection;5;0;4;0
WireConnection;5;1;11;0
WireConnection;4;0;1;0
WireConnection;4;1;3;0
WireConnection;9;0;7;0
WireConnection;9;1;5;0
WireConnection;11;0;6;4
WireConnection;11;1;10;0
WireConnection;17;1;39;0
WireConnection;17;0;18;0
WireConnection;34;2;17;0
ASEEND*/
//CHKSM=1E243B05FB39CF867DC88E27E54CFC0C2AB5608E