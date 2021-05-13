// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "SH_Grass_01"
{
	Properties
	{
		_ColorBottom("Color Bottom", Color) = (0.2799579,0.3113208,0.142444,1)
		_ColorTop("Color Top", Color) = (0.4506861,0.5,0.2287736,1)
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

		uniform float4 _ColorBottom;
		uniform float4 _ColorTop;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float3 ase_vertex3Pos = v.vertex.xyz;
			float3 break16 = ase_vertex3Pos;
			float4 appendResult17 = (float4(break16.x , ( break16.y + ( sin( ( ( break16.x * 5.0 ) + _Time.y ) ) * 0.2 ) ) , break16.z , 0.0));
			float4 lerpResult26 = lerp( float4( ase_vertex3Pos , 0.0 ) , appendResult17 , v.texcoord.xy.y);
			v.vertex.xyz = lerpResult26.xyz;
			v.vertex.w = 1;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 _GradiantPowMul = float2(1,1);
			float4 lerpResult12 = lerp( _ColorBottom , _ColorTop , ( 1.0 - saturate( ( pow( i.uv_texcoord.y , _GradiantPowMul.x ) * _GradiantPowMul.y ) ) ));
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
-1893;204;1920;1013;2706.524;-3605.226;1;True;False
Node;AmplifyShaderEditor.PosVertexDataNode;15;-2040.544,377.1682;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.BreakToComponentsNode;16;-1788.138,494.3844;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.RangedFloatNode;119;-1674.417,1053.146;Inherit;False;Constant;_Float0;Float 0;2;0;Create;True;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;19;-1740.138,840.3845;Inherit;False;Constant;_Frequency;Frequency;1;0;Create;True;0;0;False;0;False;5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;18;-1563.138,763.3845;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;21;-1525.138,1056.385;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;2;-1250.609,-83.49741;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;20;-1321.138,763.3845;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;9;-1267.161,93.10725;Inherit;False;Constant;_GradiantPowMul;Gradiant Pow Mul;1;0;Create;True;0;0;False;0;False;1,1;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SinOpNode;22;-1076.138,765.3845;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;24;-981.1377,1045.385;Inherit;False;Constant;_Ampl;Ampl;1;0;Create;True;0;0;False;0;False;0.2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;7;-964.3184,-43.6815;Inherit;False;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;-771.4728,-36.14654;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;23;-861.1378,772.3845;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;11;-581.3068,-30.51332;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;25;-597.5936,769.3704;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;13;-444.1129,-258.1858;Inherit;False;Property;_ColorTop;Color Top;1;0;Create;True;0;0;False;0;False;0.4506861,0.5,0.2287736,1;0.6288295,0.6792453,0.3364186,1;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;14;-405.7677,-22.3598;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;27;-153.9341,660.0833;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;17;-320.1386,493.3844;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.ColorNode;1;-454.4027,-474.6962;Inherit;False;Property;_ColorBottom;Color Bottom;0;0;Create;True;0;0;False;0;False;0.2799579,0.3113208,0.142444,1;0.4643067,0.5,0.2334905,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleSubtractOpNode;95;-2776.088,2045.739;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;6;482.0359,176.3397;Inherit;False;Constant;_Zero;Zero;1;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;91;-2960.48,1909.586;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;112;-1165.885,2494.504;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector3Node;116;-653.577,2115.206;Inherit;False;Constant;_Vector0;Vector 0;5;0;Create;True;0;0;False;0;False;0,0,1;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.ClampOpNode;114;-898.8853,2503.504;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;92;-2969.48,2192.586;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;97;-2806.088,1763.739;Inherit;False;Constant;_lScale;lScale;5;0;Create;True;0;0;False;0;False;24;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldToTangentMatrix;105;-1503.088,1631.739;Inherit;False;0;1;FLOAT3x3;0
Node;AmplifyShaderEditor.LerpOp;26;93.93378,375.0031;Inherit;True;3;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;2;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;96;-2500.088,2019.739;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;120;-1715.124,3562.65;Inherit;True;Property;_WindNoise;WindNoise;2;0;Create;True;0;0;False;0;False;-1;ee26f74768b09234b8cb0876d287f3b3;ee26f74768b09234b8cb0876d287f3b3;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;122;-1934.524,3786.226;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;123;-2236.524,3857.226;Inherit;False;Constant;_WindPeriod;WindPeriod;3;0;Create;True;0;0;False;0;False;2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;121;-2273.524,3685.226;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;98;-1768.088,1955.739;Inherit;False;2;0;FLOAT4;0,0,0,0;False;1;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.WorldPosInputsNode;90;-3528.48,1992.586;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;94;-3273.48,2338.586;Inherit;False;Constant;_OffsetZ;OffsetZ;5;0;Create;True;0;0;False;0;False;-9;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldNormalVector;89;-2263.076,2184.292;Inherit;True;False;1;0;FLOAT3;0,0,1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;107;-2299.152,2741.586;Inherit;False;Constant;_OffsetY;OffsetY;5;0;Create;True;0;0;False;0;False;6.7;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;111;-1399.885,2501.504;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;101;-1514.088,1959.739;Inherit;False;2;2;0;FLOAT4;0,0,0,0;False;1;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.FunctionNode;88;-2314.484,1763.587;Inherit;True;Reconstruct World Position From Depth;-1;;1;e7094bcbcc80eb140b2a3dbe6a861de8;0;0;1;FLOAT4;0
Node;AmplifyShaderEditor.RangedFloatNode;113;-1372.885,2739.504;Inherit;False;Constant;_Blend;Blend;5;0;Create;True;0;0;False;0;False;10;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;102;-1658.088,2077.739;Inherit;False;Constant;_Float2;Float 2;5;0;Create;True;0;0;False;0;False;2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;110;-1685.168,2383.667;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;109;-1772.047,2656.341;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;12;-58.78067,-253.2736;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;108;-2291.152,2533.586;Inherit;False;Constant;_DistanceScale;DistanceScale;5;0;Create;True;0;0;False;0;False;6;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;104;-1162.088,1765.739;Inherit;False;2;2;0;FLOAT3x3;0,0,0,1,1,1,1,0,1;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RangedFloatNode;93;-3283.48,2239.586;Inherit;False;Constant;_OffsetX;OffsetX;5;0;Create;True;0;0;False;0;False;-4;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;115;-284.5995,2084.527;Inherit;False;3;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;2;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;106;-1909.088,2426.739;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;99;-1960.088,2055.739;Inherit;False;Constant;_Float1;Float 1;5;0;Create;True;0;0;False;0;False;0.2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;118;-753.2893,1555.935;Inherit;False;myVarName;-1;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.WorldPosInputsNode;125;-2310.524,4179.227;Inherit;True;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.BreakToComponentsNode;126;-2051.524,4182.227;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;117;727.802,82.59897;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;SH_Grass_01;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;False;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Absolute;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;16;0;15;0
WireConnection;18;0;16;0
WireConnection;18;1;19;0
WireConnection;21;0;119;0
WireConnection;20;0;18;0
WireConnection;20;1;21;0
WireConnection;22;0;20;0
WireConnection;7;0;2;2
WireConnection;7;1;9;1
WireConnection;10;0;7;0
WireConnection;10;1;9;2
WireConnection;23;0;22;0
WireConnection;23;1;24;0
WireConnection;11;0;10;0
WireConnection;25;0;16;1
WireConnection;25;1;23;0
WireConnection;14;0;11;0
WireConnection;17;0;16;0
WireConnection;17;1;25;0
WireConnection;17;2;16;2
WireConnection;95;0;91;0
WireConnection;95;1;92;0
WireConnection;91;0;90;1
WireConnection;91;1;90;3
WireConnection;112;0;111;0
WireConnection;112;1;113;0
WireConnection;114;0;112;0
WireConnection;92;0;93;0
WireConnection;92;1;94;0
WireConnection;26;0;15;0
WireConnection;26;1;17;0
WireConnection;26;2;27;2
WireConnection;96;0;95;0
WireConnection;96;1;97;0
WireConnection;122;0;121;0
WireConnection;122;1;123;0
WireConnection;98;0;88;0
WireConnection;98;1;99;0
WireConnection;89;0;96;0
WireConnection;111;0;110;0
WireConnection;111;1;109;0
WireConnection;101;0;98;0
WireConnection;101;1;102;0
WireConnection;110;0;90;2
WireConnection;110;1;106;0
WireConnection;109;0;107;0
WireConnection;109;1;108;0
WireConnection;12;0;1;0
WireConnection;12;1;13;0
WireConnection;12;2;14;0
WireConnection;104;0;105;0
WireConnection;104;1;101;0
WireConnection;115;0;104;0
WireConnection;115;1;116;0
WireConnection;115;2;114;0
WireConnection;106;0;89;1
WireConnection;106;1;108;0
WireConnection;126;0;125;0
WireConnection;117;0;12;0
WireConnection;117;3;6;0
WireConnection;117;4;6;0
WireConnection;117;11;26;0
ASEEND*/
//CHKSM=17173F68721A81BD0C31EB3D2356CC7ACC1295C7