// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Leonidas Legacy/SH_fogOfWar"
{
	Properties
	{
		_VisibleRenderTexture("Visible Render Texture", 2D) = "white" {}
		_VisibleFogColor("Visible Fog Color", Color) = (0,0,0,0)
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 5.0
		#pragma surface surf Standard alpha:fade keepalpha noshadow vertex:vertexDataFunc 
		struct Input
		{
			float4 vertexToFrag88;
		};

		uniform float4 _VisibleFogColor;
		uniform sampler2D _VisibleRenderTexture;
		float4x4 unity_Projector;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float4 ase_vertex4Pos = v.vertex;
			o.vertexToFrag88 = mul( unity_Projector, ase_vertex4Pos );
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			o.Albedo = _VisibleFogColor.rgb;
			float2 UV92 = ( (i.vertexToFrag88).xy / (i.vertexToFrag88).w );
			float4 temp_cast_1 = (0.0).xxxx;
			float4 temp_cast_2 = (_VisibleFogColor.a).xxxx;
			float4 clampResult135 = clamp( ( 1.0 - tex2D( _VisibleRenderTexture, UV92 ) ) , temp_cast_1 , temp_cast_2 );
			o.Alpha = clampResult135.r;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
0;6;1920;1013;2194.361;338.2495;1;True;False
Node;AmplifyShaderEditor.PosVertexDataNode;86;-1165.384,-1084.507;Inherit;False;1;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.UnityProjectorMatrixNode;85;-1165.384,-1164.507;Inherit;False;0;1;FLOAT4x4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;87;-957.384,-1164.507;Inherit;False;2;2;0;FLOAT4x4;0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.VertexToFragmentNode;88;-813.384,-1164.507;Inherit;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.ComponentMaskNode;89;-573.384,-1164.507;Inherit;False;True;True;False;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ComponentMaskNode;90;-573.384,-1084.507;Inherit;False;False;False;False;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;91;-333.384,-1164.507;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;92;-54.47729,-1108.388;Float;False;UV;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;93;-1279.932,731.5161;Inherit;False;92;UV;1;0;OBJECT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TexturePropertyNode;1;-1496.318,87.39687;Float;True;Property;_VisibleRenderTexture;Visible Render Texture;0;0;Create;True;0;0;False;0;False;None;345988ec8432d6c4196126fe667cf4ac;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.SamplerNode;136;-1080.989,86.42647;Inherit;True;Property;_TextureSample2;Texture Sample 0;1;0;Create;True;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;138;-723.9076,92.40535;Inherit;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;5;-493.8613,-62.61094;Float;False;Property;_VisibleFogColor;Visible Fog Color;2;0;Create;True;0;0;False;0;False;0,0,0,0;0.06399996,0.06399996,0.06399996,0.6941177;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;133;-407.6093,200.3157;Inherit;False;Constant;_Float0;Float 0;3;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;135;-191.9917,90.4987;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;139;-1052.446,730.4573;Inherit;True;SH_FogOfWar_MergedRenderTextures;-1;;7;262719dec9990b343ac98842b2b6281c;0;3;18;SAMPLER2D;;False;13;SAMPLER2D;0;False;17;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;22;-1571.427,721.4028;Float;True;Property;_ReavaledRenderTexture;Reavaled Render Texture;1;0;Create;True;0;0;False;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;128;538.7816,-56.63128;Float;False;True;-1;7;ASEMaterialInspector;0;0;Standard;Leonidas Legacy/SH_fogOfWar;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;87;0;85;0
WireConnection;87;1;86;0
WireConnection;88;0;87;0
WireConnection;89;0;88;0
WireConnection;90;0;88;0
WireConnection;91;0;89;0
WireConnection;91;1;90;0
WireConnection;92;0;91;0
WireConnection;136;0;1;0
WireConnection;136;1;93;0
WireConnection;138;0;136;0
WireConnection;135;0;138;0
WireConnection;135;1;133;0
WireConnection;135;2;5;4
WireConnection;139;18;1;0
WireConnection;139;13;22;0
WireConnection;139;17;93;0
WireConnection;128;0;5;0
WireConnection;128;9;135;0
ASEEND*/
//CHKSM=973B7955B36C18FB447686C5FFAFEC390F6B8BDF