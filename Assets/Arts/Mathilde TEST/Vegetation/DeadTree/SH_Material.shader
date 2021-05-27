// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_Material"
{
	Properties
	{
		_Albedo("Albedo", 2D) = "white" {}
		_Roughness("Roughness", 2D) = "white" {}
		[Normal]_Normal("Normal", 2D) = "bump" {}
		_OC("OC", 2D) = "white" {}
		_Metallic("Metallic", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Normal;
		uniform float4 _Normal_ST;
		uniform sampler2D _Albedo;
		uniform float4 _Albedo_ST;
		uniform sampler2D _Metallic;
		uniform float4 _Metallic_ST;
		uniform sampler2D _Roughness;
		uniform float4 _Roughness_ST;
		uniform sampler2D _OC;
		uniform float4 _OC_ST;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Normal = i.uv_texcoord * _Normal_ST.xy + _Normal_ST.zw;
			o.Normal = UnpackNormal( tex2D( _Normal, uv_Normal ) );
			float2 uv_Albedo = i.uv_texcoord * _Albedo_ST.xy + _Albedo_ST.zw;
			o.Albedo = tex2D( _Albedo, uv_Albedo ).rgb;
			float2 uv_Metallic = i.uv_texcoord * _Metallic_ST.xy + _Metallic_ST.zw;
			o.Metallic = tex2D( _Metallic, uv_Metallic ).r;
			float2 uv_Roughness = i.uv_texcoord * _Roughness_ST.xy + _Roughness_ST.zw;
			o.Smoothness = ( 1.0 - tex2D( _Roughness, uv_Roughness ) ).r;
			float2 uv_OC = i.uv_texcoord * _OC_ST.xy + _OC_ST.zw;
			o.Occlusion = tex2D( _OC, uv_OC ).r;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
1920;6;1920;1013;636.2755;269.1467;1;True;False
Node;AmplifyShaderEditor.SamplerNode;268;-227.0228,208.5224;Inherit;True;Property;_Roughness;Roughness;7;0;Create;True;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleTimeNode;121;-9029.82,2310.624;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;96;-9151.884,1301.606;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GradientNode;242;-7967.513,-770.3665;Inherit;False;0;3;2;0.4509804,0.5019608,0.227451,0;0.1960784,0.6156863,0.6784314,0.5000076;0.6784314,0.1960784,0.6114826,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.LerpOp;26;-6756.686,-133.8388;Inherit;True;3;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;2;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.BreakToComponentsNode;126;-8768.82,2809.626;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SimpleDivideOpNode;112;-7817.681,1776.372;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;137;-7240.063,2856.842;Inherit;False;Constant;_Float4;Float 4;3;0;Create;True;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;23;-7711.758,263.5428;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;106;-8560.883,1708.607;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;128;-8463.903,3199.412;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;120;-7651.156,2623.372;Inherit;True;Property;_WindNoise;WindNoise;3;0;Create;True;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleTimeNode;21;-8375.758,547.5433;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;125;-9062.82,3044.626;Inherit;True;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;19;-8590.757,331.5428;Inherit;False;Property;_Frequency;Frequency;5;0;Create;True;0;0;False;0;False;5;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;122;-8690.819,2411.624;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;20;-8171.758,254.5428;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;136;-7381.063,2859.842;Inherit;False;Constant;_Float3;Float 3;3;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;127;-8494.82,2812.625;Inherit;True;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.Vector3Node;116;-7305.373,1397.074;Inherit;False;Constant;_Vector0;Vector 0;5;0;Create;True;0;0;False;0;False;0,0,1;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;107;-8950.948,2023.453;Inherit;False;Constant;_OffsetY;OffsetY;5;0;Create;True;0;0;False;0;False;6.7;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;90;-10180.28,1274.453;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.DynamicAppendNode;92;-9621.275,1474.453;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.OneMinusNode;275;493.7245,144.8533;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;266;137.9933,-223.6433;Inherit;True;Property;_Albedo;Albedo;6;0;Create;True;0;0;False;0;False;-1;None;716d7d666e4d52e4ba8e40e49d2b929c;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;139;-7252.063,2954.842;Inherit;False;Constant;_Float6;Float 6;3;0;Create;True;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;98;-8419.884,1237.606;Inherit;False;2;0;FLOAT4;0,0,0,0;False;1;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.TFHCRemapNode;135;-7077.29,2642.59;Inherit;False;5;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;1,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;115;-6936.395,1366.395;Inherit;False;3;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;2;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RangedFloatNode;140;-6985.21,3145.842;Inherit;False;Property;_Strenght;Strenght;4;0;Create;True;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;18;-8413.758,254.5428;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;113;-8024.681,2021.372;Inherit;False;Constant;_Blend;Blend;5;0;Create;True;0;0;False;0;False;10;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.BreakToComponentsNode;16;-8638.757,-14.45753;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.RangedFloatNode;138;-7391.063,2952.842;Inherit;False;Constant;_Float5;Float 5;3;0;Create;True;0;0;False;0;False;-1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;141;-6668.063,2952.842;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;132;-8452.82,3056.625;Inherit;False;Property;_WindPositionScale;WindPositionScale;0;0;Create;True;0;0;False;0;False;2;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;145;-8993.573,2567.814;Inherit;False;Property;_WindPeriod;WindPeriod;2;0;Create;True;0;0;False;0;False;2;0.2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;110;-8336.964,1665.535;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;17;-7170.759,-15.45753;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleAddOpNode;25;-7448.214,260.5288;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;111;-8051.681,1783.372;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;88;-8966.278,1045.454;Inherit;True;Reconstruct World Position From Depth;-1;;27;e7094bcbcc80eb140b2a3dbe6a861de8;0;0;1;FLOAT4;0
Node;AmplifyShaderEditor.RangedFloatNode;97;-9457.884,1045.607;Inherit;False;Constant;_lScale;lScale;5;0;Create;True;0;0;False;0;False;24;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TransformPositionNode;244;-2362.401,-1008.144;Inherit;False;Object;World;False;Fast;True;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.ColorNode;256;-631.8837,-1185.119;Inherit;False;Constant;_ColorBottom;Color Bottom;1;0;Create;True;0;0;False;0;False;0.4666667,0.5490196,0.3058824,1;0.4701756,0.5,0.2382075,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;27;-7004.554,151.2416;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleContrastOpNode;260;-546.5693,-558.837;Inherit;True;2;1;COLOR;0,0,0,0;False;0;FLOAT;5;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;101;-8165.884,1241.606;Inherit;False;2;2;0;FLOAT4;0,0,0,0;False;1;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.DynamicAppendNode;239;-1780.716,-1006.103;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;108;-8942.948,1815.454;Inherit;False;Constant;_DistanceScale;DistanceScale;5;0;Create;True;0;0;False;0;False;6;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;91;-9612.275,1191.453;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PosVertexDataNode;219;-9260.968,2812.336;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;9;-1471.601,-429.596;Inherit;False;Constant;_GradiantPowMul;Gradiant Pow Mul;1;0;Create;True;0;0;False;0;False;1.3,1;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;99;-8611.883,1337.606;Inherit;False;Constant;_Float1;Float 1;5;0;Create;True;0;0;False;0;False;0.2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;102;-8309.884,1359.606;Inherit;False;Constant;_Float2;Float 2;5;0;Create;True;0;0;False;0;False;2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;109;-8423.843,1938.209;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;15;-8891.165,-131.6736;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;104;-7813.884,1047.607;Inherit;False;2;2;0;FLOAT3x3;0,0,0,1,1,1,1,0,1;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RangedFloatNode;24;-7831.758,536.5433;Inherit;False;Property;_Ampl;Ampl;1;0;Create;True;0;0;False;0;False;0.2;0.2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;114;-7550.681,1785.372;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldToTangentMatrix;105;-8154.884,913.6064;Inherit;False;0;1;FLOAT3x3;0
Node;AmplifyShaderEditor.GradientSampleNode;241;-908.4866,-938.6013;Inherit;True;2;0;OBJECT;;False;1;FLOAT;0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.BreakToComponentsNode;235;-2094.715,-1006.103;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SamplerNode;273;73.72449,80.8533;Inherit;True;Property;_Metallic;Metallic;10;0;Create;True;0;0;False;0;False;-1;None;0b6c371e970495a4983da1851232fd93;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;270;146.7245,298.8533;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;134;-7931.233,2670.762;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;271;-251.2755,-110.6467;Inherit;True;Property;_Normal;Normal;8;1;[Normal];Create;True;0;0;False;0;False;-1;None;f8d8352e06f95e64ca0fb875864526ca;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;272;98.72449,493.8533;Inherit;True;Property;_OC;OC;9;0;Create;True;0;0;False;0;False;-1;None;87b1f4568203517468c785023eb8c649;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;131;-8130.819,2909.625;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;7;-1168.758,-566.3848;Inherit;False;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;240;-1781.581,-798.4515;Inherit;False;Constant;_Seed;Seed;16;0;Create;True;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;-975.9119,-558.8497;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;238;-1567.581,-924.4515;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SaturateNode;11;-785.7457,-553.2164;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GradientNode;265;-1087.608,-1287.692;Inherit;False;0;3;2;0.446428,0.5283019,0.2865789,0.1705959;0.4656868,0.5566038,0.2914293,0.5735256;0.4966926,0.5849056,0.3338376,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.RangedFloatNode;119;-8525.037,544.3043;Inherit;False;Constant;_Float0;Float 0;2;0;Create;True;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;95;-9427.884,1327.606;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.WorldNormalVector;89;-8915.972,1466.16;Inherit;True;False;1;0;FLOAT3;0,0,1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;93;-9935.275,1521.453;Inherit;False;Constant;_OffsetX;OffsetX;5;0;Create;True;0;0;False;0;False;-4;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GradientNode;262;-1300.307,-1606.39;Inherit;False;0;3;2;0.5557297,0.6132076,0.3037113,0.1794156;0.5795388,0.6415094,0.2935208,0.4941176;0.5942779,0.6037736,0.2876469,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.GradientNode;243;-1301.566,-1208.558;Inherit;False;0;2;2;0.5224332,0.5566038,0.2704254,0;0.4705883,0.5019608,0.2392157,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.GradientNode;264;-1301.712,-1539.943;Inherit;False;0;2;2;0.5224332,0.5566038,0.2704254,0;0.4705883,0.5019608,0.2392157,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.LerpOp;12;-214.2084,-949.785;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;94;-9925.275,1620.453;Inherit;False;Constant;_OffsetZ;OffsetZ;5;0;Create;True;0;0;False;0;False;-9;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;263;-646.4949,-1465.191;Inherit;False;Constant;_Color0;Color 0;1;0;Create;True;0;0;False;0;False;0.4701756,0.5,0.2382075,1;0.4701756,0.5,0.2382075,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;2;-1455.049,-606.2007;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;233;-1280.902,-927.2475;Inherit;True;Random Range;-1;;26;7b754edb8aebbfb4a9ace907af661cfc;0;3;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SinOpNode;22;-7926.758,256.5428;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;220;741.9141,51.1872;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Tartaros/SH_Material;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;96;0;95;0
WireConnection;96;1;97;0
WireConnection;26;0;15;0
WireConnection;26;1;17;0
WireConnection;26;2;27;2
WireConnection;126;0;219;0
WireConnection;112;0;111;0
WireConnection;112;1;113;0
WireConnection;23;0;22;0
WireConnection;23;1;24;0
WireConnection;106;0;89;1
WireConnection;106;1;108;0
WireConnection;128;0;126;0
WireConnection;128;1;126;2
WireConnection;120;1;134;0
WireConnection;21;0;119;0
WireConnection;122;0;121;0
WireConnection;122;1;145;0
WireConnection;20;0;18;0
WireConnection;20;1;21;0
WireConnection;127;0;126;0
WireConnection;127;1;126;2
WireConnection;92;0;93;0
WireConnection;92;1;94;0
WireConnection;98;0;88;0
WireConnection;98;1;99;0
WireConnection;135;0;120;0
WireConnection;135;1;136;0
WireConnection;135;2;137;0
WireConnection;135;3;138;0
WireConnection;135;4;139;0
WireConnection;115;0;104;0
WireConnection;115;1;116;0
WireConnection;115;2;114;0
WireConnection;18;0;16;0
WireConnection;18;1;19;0
WireConnection;16;0;15;0
WireConnection;110;0;90;2
WireConnection;110;1;106;0
WireConnection;17;0;25;0
WireConnection;17;1;25;0
WireConnection;17;2;16;2
WireConnection;25;0;16;1
WireConnection;25;1;23;0
WireConnection;111;0;110;0
WireConnection;111;1;109;0
WireConnection;260;1;11;0
WireConnection;101;0;98;0
WireConnection;101;1;102;0
WireConnection;239;0;235;0
WireConnection;239;1;235;2
WireConnection;91;0;90;1
WireConnection;91;1;90;3
WireConnection;109;0;107;0
WireConnection;109;1;108;0
WireConnection;104;0;105;0
WireConnection;104;1;101;0
WireConnection;114;0;112;0
WireConnection;241;0;265;0
WireConnection;241;1;233;0
WireConnection;235;0;244;0
WireConnection;270;0;268;0
WireConnection;134;0;122;0
WireConnection;134;1;131;0
WireConnection;131;0;128;0
WireConnection;131;1;132;0
WireConnection;7;0;2;2
WireConnection;7;1;9;1
WireConnection;10;0;7;0
WireConnection;10;1;9;2
WireConnection;238;0;239;0
WireConnection;238;1;240;0
WireConnection;11;0;10;0
WireConnection;95;0;91;0
WireConnection;95;1;92;0
WireConnection;89;0;96;0
WireConnection;12;0;263;0
WireConnection;12;1;241;0
WireConnection;12;2;260;0
WireConnection;233;1;238;0
WireConnection;22;0;20;0
WireConnection;220;0;266;0
WireConnection;220;1;271;0
WireConnection;220;3;273;0
WireConnection;220;4;270;0
WireConnection;220;5;272;0
ASEEND*/
//CHKSM=7C76BAE562A2F6C4FED2B56EEEC23401F305A3A1