// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Leonidas Legacy/SH_fogOfWar"
{
	Properties
	{
		_VisibleRenderTexture("Visible Render Texture", 2D) = "white" {}
		_ReavaledRenderTexture("Reavaled Render Texture", 2D) = "white" {}
		_VisibleFogColor("Visible Fog Color", Color) = (0,0,0,0)
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" }
		Cull Back
		AlphaToMask On
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard alpha:fade keepalpha noshadow vertex:vertexDataFunc 
		struct Input
		{
			float4 vertexToFrag88;
		};

		uniform float4 _VisibleFogColor;
		uniform sampler2D _ReavaledRenderTexture;
		float4x4 unity_Projector;
		uniform sampler2D _VisibleRenderTexture;

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
			float2 temp_output_17_0_g6 = UV92;
			float temp_output_116_0 = min( _VisibleFogColor.a , ( 1.0 - ( tex2D( _ReavaledRenderTexture, temp_output_17_0_g6 ).r + (tex2D( _VisibleRenderTexture, temp_output_17_0_g6 ).r*0.5 + 0.0) ) ) );
			o.Alpha = temp_output_116_0;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
1920;0;957;1019;873.4396;479.7037;1.401712;True;False
Node;AmplifyShaderEditor.PosVertexDataNode;86;-1165.384,-1084.507;Inherit;False;1;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.UnityProjectorMatrixNode;85;-1165.384,-1164.507;Inherit;False;0;1;FLOAT4x4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;87;-957.384,-1164.507;Inherit;False;2;2;0;FLOAT4x4;0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.VertexToFragmentNode;88;-813.384,-1164.507;Inherit;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.ComponentMaskNode;90;-573.384,-1084.507;Inherit;False;False;False;False;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;89;-573.384,-1164.507;Inherit;False;True;True;False;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;91;-333.384,-1164.507;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;92;-54.47729,-1108.388;Float;False;UV;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TexturePropertyNode;22;-1457.804,102.1081;Float;True;Property;_ReavaledRenderTexture;Reavaled Render Texture;1;0;Create;True;0;0;False;0;False;None;513bae1006164414fa79719fd4bfe4cd;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.GetLocalVarNode;93;-1248.199,381.4355;Inherit;False;92;UV;1;0;OBJECT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TexturePropertyNode;1;-1457.896,-224.8671;Float;True;Property;_VisibleRenderTexture;Visible Render Texture;0;0;Create;True;0;0;False;0;False;None;345988ec8432d6c4196126fe667cf4ac;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.FunctionNode;112;-885.8787,102.3848;Inherit;True;SH_FogOfWar_MergedRenderTextures;-1;;6;262719dec9990b343ac98842b2b6281c;0;3;18;SAMPLER2D;;False;13;SAMPLER2D;0;False;17;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;5;-359.6971,-170.224;Float;False;Property;_VisibleFogColor;Visible Fog Color;2;0;Create;True;0;0;False;0;False;0,0,0,0;0.06399998,0.06399998,0.06399998,0.6941177;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMinOpNode;116;-217.4386,110.4172;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;120;205.2612,123.3455;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Leonidas Legacy/SH_fogOfWar;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;1;-1;-1;-1;0;True;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;87;0;85;0
WireConnection;87;1;86;0
WireConnection;88;0;87;0
WireConnection;90;0;88;0
WireConnection;89;0;88;0
WireConnection;91;0;89;0
WireConnection;91;1;90;0
WireConnection;92;0;91;0
WireConnection;112;18;1;0
WireConnection;112;13;22;0
WireConnection;112;17;93;0
WireConnection;116;0;5;4
WireConnection;116;1;112;0
WireConnection;120;0;5;0
WireConnection;120;9;116;0
WireConnection;120;10;116;0
ASEEND*/
//CHKSM=C19E85D8894BDA90AD873A6FACE5CA8FA291574A