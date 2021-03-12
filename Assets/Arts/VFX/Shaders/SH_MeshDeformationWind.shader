// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "SH_MeshDeformationWind"
{
	Properties
	{
		_EdgeLength ( "Edge length", Range( 2, 50 ) ) = 15
		_Albedo("Albedo", 2D) = "white" {}
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_Normal("Normal", 2D) = "bump" {}
		_VertexPosition("VertexPosition", Float) = 0
		[HDR]_AlbedoColor("AlbedoColor", Color) = (2,1.003922,0,0.1)
		_yPosStrength("yPosStrength", Float) = 0
		_WindDirection("WindDirection", Float) = 0
		_BendStrength("BendStrength", Float) = 1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "AlphaTest+0" "IgnoreProjector" = "True" }
		Cull Off
		Blend SrcAlpha OneMinusSrcAlpha
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#include "Tessellation.cginc"
		#pragma target 4.6
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows vertex:vertexDataFunc tessellate:tessFunction 
		struct Input
		{
			float3 worldPos;
			float2 uv_texcoord;
		};

		uniform float _WindDirection;
		uniform float _BendStrength;
		uniform float _VertexPosition;
		uniform float _yPosStrength;
		uniform sampler2D _Normal;
		uniform float4 _Normal_ST;
		uniform float4 _AlbedoColor;
		uniform sampler2D _Albedo;
		uniform float4 _Albedo_ST;
		SamplerState sampler_Albedo;
		uniform float _Cutoff = 0.5;
		uniform float _EdgeLength;


		float3 RotateAroundAxis( float3 center, float3 original, float3 u, float angle )
		{
			original -= center;
			float C = cos( angle );
			float S = sin( angle );
			float t = 1 - C;
			float m00 = t * u.x * u.x + C;
			float m01 = t * u.x * u.y - S * u.z;
			float m02 = t * u.x * u.z + S * u.y;
			float m10 = t * u.x * u.y + S * u.z;
			float m11 = t * u.y * u.y + C;
			float m12 = t * u.y * u.z - S * u.x;
			float m20 = t * u.x * u.z - S * u.y;
			float m21 = t * u.y * u.z + S * u.x;
			float m22 = t * u.z * u.z + C;
			float3x3 finalMatrix = float3x3( m00, m01, m02, m10, m11, m12, m20, m21, m22 );
			return mul( finalMatrix, original ) + center;
		}


		float4 tessFunction( appdata_full v0, appdata_full v1, appdata_full v2 )
		{
			return UnityEdgeLengthBasedTess (v0.vertex, v1.vertex, v2.vertex, _EdgeLength);
		}

		void vertexDataFunc( inout appdata_full v )
		{
			float3 ase_vertexNormal = v.normal.xyz;
			float3 ase_worldPos = mul( unity_ObjectToWorld, v.vertex );
			float temp_output_61_0 = ( ( ase_vertexNormal.y * cos( ( ( ( ase_worldPos.x + ase_worldPos.z ) * _BendStrength ) + _Time.y ) ) ) * _VertexPosition );
			float4 appendResult62 = (float4(temp_output_61_0 , 0.0 , temp_output_61_0 , 0.0));
			float4 break67 = mul( appendResult62, unity_ObjectToWorld );
			float4 appendResult68 = (float4(break67.x , _yPosStrength , break67.z , 0.0));
			float3 rotatedValue70 = RotateAroundAxis( float3( 0,0,0 ), appendResult68.xyz, float3( 0,0,0 ), _WindDirection );
			float3 Deformation36 = rotatedValue70;
			v.vertex.xyz += Deformation36;
			v.vertex.w = 1;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Normal = i.uv_texcoord * _Normal_ST.xy + _Normal_ST.zw;
			float4 _Remap = float4(0,1,-1,1);
			float3 temp_cast_0 = (_Remap.x).xxx;
			float3 temp_cast_1 = (_Remap.y).xxx;
			float3 temp_cast_2 = (_Remap.z).xxx;
			float3 temp_cast_3 = (_Remap.w).xxx;
			float3 Normal15 = (temp_cast_2 + (UnpackNormal( tex2D( _Normal, uv_Normal ) ) - temp_cast_0) * (temp_cast_3 - temp_cast_2) / (temp_cast_1 - temp_cast_0));
			o.Normal = Normal15;
			float2 uv_Albedo = i.uv_texcoord * _Albedo_ST.xy + _Albedo_ST.zw;
			float4 tex2DNode1 = tex2D( _Albedo, uv_Albedo );
			float4 RGB__TextureAlbedo8 = ( _AlbedoColor * tex2DNode1 );
			o.Albedo = RGB__TextureAlbedo8.rgb;
			float Metallic9 = _AlbedoColor.a;
			o.Metallic = Metallic9;
			o.Alpha = 1;
			float OpacityMask10 = tex2DNode1.a;
			clip( OpacityMask10 - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
258;73;1214;646;5338.951;2659.49;5.98054;True;False
Node;AmplifyShaderEditor.CommentaryNode;74;-3164.533,-1873.998;Inherit;False;3440.671;679.001;Comment;20;54;55;17;56;58;57;59;60;64;61;62;65;66;69;67;71;68;70;36;73;DEFORMATION;1,1,1,1;0;0
Node;AmplifyShaderEditor.WorldPosInputsNode;54;-3114.533,-1640.403;Inherit;True;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleAddOpNode;55;-2798.82,-1617.077;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;17;-3026.866,-1392.603;Inherit;False;Property;_BendStrength;BendStrength;12;0;Create;True;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;58;-2525.765,-1472.206;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;56;-2544.072,-1625.117;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;57;-2183.32,-1589.38;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CosOpNode;59;-2018.068,-1499.776;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NormalVertexDataNode;73;-2072.667,-1823.998;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;60;-1848.735,-1582.868;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;64;-1887.629,-1410.789;Inherit;False;Property;_VertexPosition;VertexPosition;8;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;61;-1664.22,-1528.335;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ObjectToWorldMatrixNode;65;-1465.677,-1390.84;Inherit;False;0;1;FLOAT4x4;0
Node;AmplifyShaderEditor.DynamicAppendNode;62;-1413.902,-1550.068;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;66;-1189.708,-1485.499;Inherit;False;2;2;0;FLOAT4;0,0,0,0;False;1;FLOAT4x4;0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1;False;1;FLOAT4;0
Node;AmplifyShaderEditor.CommentaryNode;76;-1790.052,-887.6209;Inherit;False;884.2656;459.4633;Comment;4;7;2;6;15;NORMAL;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;69;-934.0311,-1322.763;Inherit;False;Property;_yPosStrength;yPosStrength;10;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.BreakToComponentsNode;67;-985.7309,-1485.499;Inherit;False;FLOAT4;1;0;FLOAT4;0,0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.CommentaryNode;75;-2914.186,-883.9906;Inherit;False;883.4763;457.7732;Comment;6;1;4;3;8;9;10;ALBEDO;1,1,1,1;0;0
Node;AmplifyShaderEditor.SamplerNode;1;-2864.186,-656.2177;Inherit;True;Property;_Albedo;Albedo;5;0;Create;True;0;0;False;0;False;-1;78b00181d387822498c24b1dd194dc76;78b00181d387822498c24b1dd194dc76;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;4;-2809.792,-833.9906;Inherit;False;Property;_AlbedoColor;AlbedoColor;9;1;[HDR];Create;True;0;0;False;0;False;2,1.003922,0,0.1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;71;-628.0292,-1310.998;Inherit;False;Property;_WindDirection;WindDirection;11;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;68;-623.3622,-1477.99;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SamplerNode;2;-1740.052,-837.621;Inherit;True;Property;_Normal;Normal;7;0;Create;True;0;0;False;0;False;-1;4ca70df55688f7043a13af3d8b551669;4ca70df55688f7043a13af3d8b551669;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector4Node;7;-1613.847,-640.1575;Inherit;False;Constant;_Remap;Remap;4;0;Create;True;0;0;False;0;False;0,1,-1,1;0,0,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TFHCRemapNode;6;-1357.81,-720.4103;Inherit;False;5;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;1,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;1,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3;-2509.292,-709.5909;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RotateAboutAxisNode;70;-342.7039,-1450.33;Inherit;False;False;4;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;15;-1129.785,-726.102;Inherit;False;Normal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.CommentaryNode;77;-515.5389,-941.8622;Inherit;False;554.5905;579.6022;Comment;6;12;13;11;37;14;0;CORE;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;9;-2282.454,-733.7008;Inherit;False;Metallic;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;8;-2287.709,-813.0291;Inherit;False;RGB__TextureAlbedo;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;36;52.13901,-1451.943;Inherit;False;Deformation;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;10;-2513.279,-556.3196;Inherit;False;OpacityMask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;14;-439.6676,-817.486;Inherit;False;15;Normal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;12;-436.4502,-734.9435;Inherit;False;9;Metallic;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;13;-423.5149,-597.2374;Inherit;False;10;OpacityMask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;11;-465.5387,-891.8622;Inherit;False;8;RGB__TextureAlbedo;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;37;-455.8811,-507.2691;Inherit;False;36;Deformation;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-215.9481,-833.26;Float;False;True;-1;6;ASEMaterialInspector;0;0;Standard;SH_MeshDeformationWind;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;False;Transparent;;AlphaTest;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;True;2;15;10;25;False;0.5;True;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;6;-1;-1;0;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;55;0;54;1
WireConnection;55;1;54;3
WireConnection;56;0;55;0
WireConnection;56;1;17;0
WireConnection;57;0;56;0
WireConnection;57;1;58;2
WireConnection;59;0;57;0
WireConnection;60;0;73;2
WireConnection;60;1;59;0
WireConnection;61;0;60;0
WireConnection;61;1;64;0
WireConnection;62;0;61;0
WireConnection;62;2;61;0
WireConnection;66;0;62;0
WireConnection;66;1;65;0
WireConnection;67;0;66;0
WireConnection;68;0;67;0
WireConnection;68;1;69;0
WireConnection;68;2;67;2
WireConnection;6;0;2;0
WireConnection;6;1;7;1
WireConnection;6;2;7;2
WireConnection;6;3;7;3
WireConnection;6;4;7;4
WireConnection;3;0;4;0
WireConnection;3;1;1;0
WireConnection;70;1;71;0
WireConnection;70;3;68;0
WireConnection;15;0;6;0
WireConnection;9;0;4;4
WireConnection;8;0;3;0
WireConnection;36;0;70;0
WireConnection;10;0;1;4
WireConnection;0;0;11;0
WireConnection;0;1;14;0
WireConnection;0;3;12;0
WireConnection;0;10;13;0
WireConnection;0;11;37;0
ASEEND*/
//CHKSM=EFD5428F1F7691F7DCAE7D4CDB567D4B8C0413C1