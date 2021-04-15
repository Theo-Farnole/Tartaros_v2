// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_Cristal"
{
	Properties
	{
		_FresnelBSP("FresnelBSP", Vector) = (0,1,1,0)
		_FresnelPower("FresnelPower", Float) = 0.5
		_Opacity("Opacity", Float) = 0.5
		[HDR]_Color2("Color 2", Color) = (0,1,1,0)
		[HDR]_Color1("Color 1", Color) = (0,0.5176471,1,0)
		_Glow("Glow", Float) = 1
		_RefractionStrength("RefractionStrength", Float) = 0
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "AlphaTest+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Off
		GrabPass{ }
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 5.0
		#if defined(UNITY_STEREO_INSTANCING_ENABLED) || defined(UNITY_STEREO_MULTIVIEW_ENABLED)
		#define ASE_DECLARE_SCREENSPACE_TEXTURE(tex) UNITY_DECLARE_SCREENSPACE_TEXTURE(tex);
		#else
		#define ASE_DECLARE_SCREENSPACE_TEXTURE(tex) UNITY_DECLARE_SCREENSPACE_TEXTURE(tex)
		#endif
		#pragma surface surf Standard keepalpha noshadow exclude_path:deferred 
		struct Input
		{
			float3 worldNormal;
			INTERNAL_DATA
			float3 worldPos;
			float4 screenPos;
		};

		ASE_DECLARE_SCREENSPACE_TEXTURE( _GrabTexture )
		uniform float3 _FresnelBSP;
		uniform float _RefractionStrength;
		uniform float4 _Color1;
		uniform float4 _Color2;
		uniform float _FresnelPower;
		uniform float _Opacity;
		uniform float _Glow;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			o.Normal = float3(0,0,1);
			float3 ase_worldPos = i.worldPos;
			float3 ase_worldViewDir = Unity_SafeNormalize( UnityWorldSpaceViewDir( ase_worldPos ) );
			float3 ase_worldNormal = WorldNormalVector( i, float3( 0, 0, 1 ) );
			float fresnelNdotV5 = dot( ase_worldNormal, ase_worldViewDir );
			float fresnelNode5 = ( _FresnelBSP.x + _FresnelBSP.y * pow( 1.0 - fresnelNdotV5, _FresnelBSP.z ) );
			float Fresnel13 = fresnelNode5;
			float3 FresnelWorldView26 = ( -( (WorldNormalVector( i , ase_worldViewDir )) * ( 0.1 + Fresnel13 ) ) * _RefractionStrength );
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float4 ase_screenPosNorm = ase_screenPos / ase_screenPos.w;
			ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
			float4 screenColor47 = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_GrabTexture,( float4( FresnelWorldView26 , 0.0 ) + ase_screenPosNorm ).xy);
			float4 SceneColor51 = screenColor47;
			float3 ase_vertex3Pos = mul( unity_WorldToObject, float4( i.worldPos , 1 ) );
			float3 temp_output_59_0 = ase_vertex3Pos;
			float temp_output_1_0_g1 = 1.0;
			float4 lerpResult21 = lerp( _Color1 , _Color2 , saturate( ( ( temp_output_59_0.y - temp_output_1_0_g1 ) / ( 0.0 - temp_output_1_0_g1 ) ) ));
			float4 FresnelColors28 = lerpResult21;
			float FresnelOpacity24 = saturate( ( ( Fresnel13 * _FresnelPower ) + _Opacity ) );
			float4 lerpResult17 = lerp( SceneColor51 , FresnelColors28 , FresnelOpacity24);
			o.Emission = ( lerpResult17 * _Glow ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
311;73;1297;610;1703.441;516.0851;1.835155;True;False
Node;AmplifyShaderEditor.Vector3Node;7;-3664.705,-604.78;Inherit;False;Property;_FresnelBSP;FresnelBSP;0;0;Create;True;0;0;False;0;False;0,1,1;0.1,1,5;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.FresnelNode;5;-3441.256,-621.6691;Inherit;True;Standard;WorldNormal;ViewDir;False;False;5;0;FLOAT3;0,0,1;False;4;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;5;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;13;-3103.58,-626.1163;Inherit;False;Fresnel;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ViewDirInputsCoordNode;2;-2469.742,-1113.609;Inherit;False;World;True;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.GetLocalVarNode;15;-2469.413,-916.7103;Inherit;False;13;Fresnel;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldNormalVector;1;-2236.266,-1102.31;Inherit;False;False;1;0;FLOAT3;0,0,1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleAddOpNode;4;-2251.083,-934.2622;Inherit;True;2;2;0;FLOAT;0.1;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3;-1922.81,-1102.29;Inherit;True;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.NegateNode;40;-1723.075,-1101.778;Inherit;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;42;-1535.874,-1026.378;Inherit;False;Property;_RefractionStrength;RefractionStrength;7;0;Create;True;0;0;False;0;False;0;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;41;-1258.971,-1099.178;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.PosVertexDataNode;58;-2782.763,222.1234;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;26;-1080.333,-1100.424;Inherit;False;FresnelWorldView;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;16;-2511.981,759.8619;Inherit;False;13;Fresnel;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;9;-2513.631,842.6693;Inherit;False;Property;_FresnelPower;FresnelPower;2;0;Create;True;0;0;False;0;False;0.5;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TransformPositionNode;59;-2544.851,213.0451;Inherit;False;Object;Object;False;Fast;True;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;11;-2237.049,945.4187;Inherit;False;Property;_Opacity;Opacity;3;0;Create;True;0;0;False;0;False;0.5;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;19;-2242.959,236.5084;Inherit;False;Inverse Lerp;-1;;1;09cbe79402f023141a4dc1fddd4c9511;0;3;1;FLOAT;1;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;8;-2235.429,824.1803;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;43;-2468.557,-608.169;Inherit;False;26;FresnelWorldView;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ScreenPosInputsNode;45;-2433.258,-509.838;Float;False;0;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;23;-1806.292,-87.09782;Inherit;False;Property;_Color1;Color 1;5;1;[HDR];Create;True;0;0;False;0;False;0,0.5176471,1,0;0,1,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;44;-2121.623,-601.6583;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleAddOpNode;10;-1963.45,823.8188;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;20;-2032.479,235.2594;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;22;-1804.807,89.7713;Inherit;False;Property;_Color2;Color 2;4;1;[HDR];Create;True;0;0;False;0;False;0,1,1,0;0,0,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ScreenColorNode;47;-1933.809,-610.0053;Inherit;False;Global;_GrabScreen0;Grab Screen 0;8;0;Create;True;0;0;False;0;False;Object;-1;False;False;1;0;FLOAT2;0,0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;21;-1528.408,197.3025;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SaturateNode;12;-1769.848,822.2186;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;28;-1188.051,186.8208;Inherit;False;FresnelColors;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;24;-1533.182,815.1075;Inherit;False;FresnelOpacity;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;51;-1712.863,-605.7356;Inherit;False;SceneColor;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;29;-933.8886,-101.3466;Inherit;False;28;FresnelColors;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;27;-917.2938,-197.366;Inherit;False;51;SceneColor;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;25;-919.5359,-18.07999;Inherit;False;24;FresnelOpacity;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;31;-617.1431,135.8338;Inherit;False;Property;_Glow;Glow;6;0;Create;True;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;17;-532.1486,-92.30312;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.Vector2Node;53;-2859.169,387.1372;Inherit;False;Property;_WorldPosLerpLimit;WorldPosLerpLimit;8;0;Create;True;0;0;False;0;False;1,-1;1,-2.07;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;30;-348.8124,-84.22574;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;39;33.12231,-154.4115;Float;False;True;-1;7;ASEMaterialInspector;0;0;Standard;Tartaros/SH_Cristal;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;False;0;False;Transparent;;AlphaTest;ForwardOnly;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;0;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0.01;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;1;-1;0;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;5;1;7;1
WireConnection;5;2;7;2
WireConnection;5;3;7;3
WireConnection;13;0;5;0
WireConnection;1;0;2;0
WireConnection;4;1;15;0
WireConnection;3;0;1;0
WireConnection;3;1;4;0
WireConnection;40;0;3;0
WireConnection;41;0;40;0
WireConnection;41;1;42;0
WireConnection;26;0;41;0
WireConnection;59;0;58;0
WireConnection;19;3;59;2
WireConnection;8;0;16;0
WireConnection;8;1;9;0
WireConnection;44;0;43;0
WireConnection;44;1;45;0
WireConnection;10;0;8;0
WireConnection;10;1;11;0
WireConnection;20;0;19;0
WireConnection;47;0;44;0
WireConnection;21;0;23;0
WireConnection;21;1;22;0
WireConnection;21;2;20;0
WireConnection;12;0;10;0
WireConnection;28;0;21;0
WireConnection;24;0;12;0
WireConnection;51;0;47;0
WireConnection;17;0;27;0
WireConnection;17;1;29;0
WireConnection;17;2;25;0
WireConnection;30;0;17;0
WireConnection;30;1;31;0
WireConnection;39;2;30;0
ASEEND*/
//CHKSM=CA0132112B6E42D077F9FC206BF8294BC5B6FA98