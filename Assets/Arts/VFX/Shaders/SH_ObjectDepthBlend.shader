// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_ObjectDepthBlend"
{
	Properties
	{
		_falloff("falloff", Range( 0 , 10)) = 1
		_blendThickness("blendThickness", Range( 0 , 10)) = 1
		_noiseScale("noiseScale", Range( 0 , 1)) = 0.2
		_voroScale("voroScale", Float) = 10
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_Vector0("Vector 0", Vector) = (0,0,1,0)
		_TextureSample1("Texture Sample 1", 2D) = "white" {}
		_clamp1min("clamp1min", Vector) = (0,0,0,0)
		_clamp1max("clamp1max", Vector) = (1,0,0,0)
		_clamp2min("clamp2min", Vector) = (0,0,0,0)
		_clamp2max("clamp2max", Vector) = (1,0,0,0)
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IgnoreProjector" = "True" }
		Cull Back
		AlphaToMask On
		CGPROGRAM
		#pragma target 5.0
		#pragma surface surf Standard keepalpha noshadow exclude_path:deferred noambient novertexlights nolightmap  nodynlightmap nodirlightmap nofog nometa noforwardadd 
		struct Input
		{
			float3 worldPos;
			float3 worldNormal;
			INTERNAL_DATA
		};

		uniform sampler2D TB_NORMALS;
		uniform float TB_OFFSET_X;
		uniform float TB_OFFSET_Z;
		uniform float TB_SCALE;
		uniform float3 _Vector0;
		uniform sampler2D TB_DEPTH;
		uniform float TB_FARCLIP;
		uniform float TB_OFFSET_Y;
		uniform float _blendThickness;
		uniform float _noiseScale;
		uniform float _voroScale;
		uniform float4 _clamp1min;
		uniform float4 _clamp1max;
		uniform float _falloff;
		uniform float4 _clamp2min;
		uniform float4 _clamp2max;
		uniform sampler2D _TextureSample0;
		uniform sampler2D _TextureSample1;


		//https://www.shadertoy.com/view/XdXGW8
		float2 GradientNoiseDir( float2 x )
		{
			const float2 k = float2( 0.3183099, 0.3678794 );
			x = x * k + k.yx;
			return -1.0 + 2.0 * frac( 16.0 * k * frac( x.x * x.y * ( x.x + x.y ) ) );
		}
		
		float GradientNoise( float2 UV, float Scale )
		{
			float2 p = UV * Scale;
			float2 i = floor( p );
			float2 f = frac( p );
			float2 u = f * f * ( 3.0 - 2.0 * f );
			return lerp( lerp( dot( GradientNoiseDir( i + float2( 0.0, 0.0 ) ), f - float2( 0.0, 0.0 ) ),
					dot( GradientNoiseDir( i + float2( 1.0, 0.0 ) ), f - float2( 1.0, 0.0 ) ), u.x ),
					lerp( dot( GradientNoiseDir( i + float2( 0.0, 1.0 ) ), f - float2( 0.0, 1.0 ) ),
					dot( GradientNoiseDir( i + float2( 1.0, 1.0 ) ), f - float2( 1.0, 1.0 ) ), u.x ), u.y );
		}


		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float3 ase_worldPos = i.worldPos;
			float2 appendResult185 = (float2(ase_worldPos.x , ase_worldPos.z));
			float2 appendResult184 = (float2(TB_OFFSET_X , TB_OFFSET_Z));
			float2 RelativePos208 = ( ( appendResult185 - appendResult184 ) / TB_SCALE );
			float4 temp_cast_0 = (0.5).xxxx;
			float3 ase_worldNormal = WorldNormalVector( i, float3( 0, 0, 1 ) );
			float3 ase_worldTangent = WorldNormalVector( i, float3( 1, 0, 0 ) );
			float3 ase_worldBitangent = WorldNormalVector( i, float3( 0, 1, 0 ) );
			float3x3 ase_worldToTangent = float3x3( ase_worldTangent, ase_worldBitangent, ase_worldNormal );
			float WorldY179 = ase_worldPos.y;
			float4 temp_cast_4 = (WorldY179).xxxx;
			float4 temp_cast_5 = (TB_OFFSET_Y).xxxx;
			float gradientNoise219 = GradientNoise(( (ase_worldPos).xz * _noiseScale ),_voroScale);
			gradientNoise219 = gradientNoise219*0.5 + 0.5;
			float Noise221 = gradientNoise219;
			float4 clampResult200 = clamp( ( ( ( temp_cast_4 - ( tex2D( TB_DEPTH, RelativePos208 ) * TB_FARCLIP ) ) - temp_cast_5 ) / ( _blendThickness * Noise221 ) ) , _clamp1min , _clamp1max );
			float4 temp_cast_8 = (_falloff).xxxx;
			float4 clampResult202 = clamp( pow( clampResult200 , temp_cast_8 ) , _clamp2min , _clamp2max );
			float FinalRender210 = clampResult202.r;
			float4 lerpResult234 = lerp( float4( mul( ( ( tex2D( TB_NORMALS, RelativePos208 ) - temp_cast_0 ) * 2.0 ).rgb, ase_worldToTangent ) , 0.0 ) , float4( _Vector0 , 0.0 ) , FinalRender210);
			float4 Normal235 = lerpResult234;
			o.Normal = Normal235.rgb;
			float4 lerpResult236 = lerp( tex2D( _TextureSample0, RelativePos208 ) , tex2D( _TextureSample1, RelativePos208 ) , FinalRender210);
			float4 Albedo238 = lerpResult236;
			o.Albedo = Albedo238.rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
249;73;1146;575;423.1086;302.4065;1.713532;True;False
Node;AmplifyShaderEditor.CommentaryNode;189;-1062.406,798.1631;Inherit;False;1285.405;547.4659;;10;179;187;113;186;185;184;183;107;182;208;Relative Position;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;107;-997.4541,1199.376;Inherit;False;Global;TB_OFFSET_Z;TB_OFFSET_Z;9;0;Create;True;0;0;False;0;False;6.7;-50;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;183;-998.3153,1100.509;Inherit;False;Global;TB_OFFSET_X;TB_OFFSET_X;6;0;Create;True;0;0;False;0;False;-4;-50;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;182;-1012.406,937.8792;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.DynamicAppendNode;184;-702.078,1122.338;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;185;-697.5185,985.8763;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;186;-437.6367,1055.421;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;113;-464.3076,1207.878;Inherit;False;Global;TB_SCALE;TB_SCALE;4;0;Create;True;0;0;False;0;False;10;100;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;222;335.0146,794.5289;Inherit;False;1368.899;340.0792;;7;213;214;217;218;219;212;221;Noise;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;187;-170.5182,1093.81;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.WorldPosInputsNode;218;385.0146,849.6017;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SwizzleNode;212;612.5117,844.529;Inherit;False;FLOAT2;0;2;2;3;1;0;FLOAT3;0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;208;-6.915063,1096.628;Inherit;True;RelativePos;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;214;565.3335,1013.844;Inherit;False;Property;_noiseScale;noiseScale;4;0;Create;True;0;0;False;0;False;0.2;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;198;-1114.088,-108.519;Inherit;False;2864.63;644.3179;;22;223;206;195;210;205;202;201;200;207;199;197;196;192;193;190;194;209;224;252;253;255;254;Depth Blending;1,1,1,1;0;0
Node;AmplifyShaderEditor.GetLocalVarNode;209;-1004.097,24.15445;Inherit;False;208;RelativePos;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;217;897.9521,1019.608;Inherit;False;Property;_voroScale;voroScale;5;0;Create;True;0;0;False;0;False;10;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;213;893.0135,904.8278;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;190;-730.2277,-0.9934707;Inherit;True;Global;TB_DEPTH;TB_DEPTH;0;0;Create;True;0;0;False;0;False;-1;b39ddb9e2c956f648bfec9764b433cd8;b39ddb9e2c956f648bfec9764b433cd8;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;194;-606.9044,256.6099;Inherit;False;Global;TB_FARCLIP;TB_FARCLIP;15;0;Create;True;0;0;False;0;False;0;10;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;179;-702.6222,885.9939;Inherit;False;WorldY;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;219;1176.966,876.8483;Inherit;True;Gradient;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;10.9;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;221;1481.286,876.8795;Inherit;True;Noise;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;193;-255.0934,101.4034;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;192;-298.5931,-4.854303;Inherit;False;179;WorldY;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;196;-62.65209,94.82877;Inherit;False;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;195;-289.0852,252.1055;Inherit;False;Global;TB_OFFSET_Y;TB_OFFSET_Y;15;0;Create;True;0;0;False;0;False;0;-9.65;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;224;-264.8862,430.2132;Inherit;False;221;Noise;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;206;-361.3434,340.7914;Inherit;False;Property;_blendThickness;blendThickness;3;0;Create;True;0;0;False;0;False;1;1;0;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;223;135.9611,345.0091;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;197;133.1129,95.84952;Inherit;False;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.Vector4Node;253;321.0282,364.1233;Inherit;False;Property;_clamp1max;clamp1max;10;0;Create;True;0;0;False;0;False;1,0,0,0;1,0,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector4Node;252;324.8549,196.8081;Inherit;False;Property;_clamp1min;clamp1min;9;0;Create;True;0;0;False;0;False;0,0,0,0;0,0,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleDivideOpNode;199;348.5352,102.143;Inherit;False;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;207;414.5058,-21.22015;Inherit;False;Property;_falloff;falloff;2;0;Create;True;0;0;False;0;False;1;1;0;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;245;-1053.647,1535.502;Inherit;False;2067.176;389.942;;12;233;227;226;228;230;229;231;211;232;234;235;225;Normal;1,1,1,1;0;0
Node;AmplifyShaderEditor.ClampOpNode;200;556.5767,93.75394;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.Vector4Node;254;724.125,364.2602;Inherit;False;Property;_clamp2max;clamp2max;12;0;Create;True;0;0;False;0;False;1,0,0,0;1,0,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector4Node;255;722.2974,194.1177;Inherit;False;Property;_clamp2min;clamp2min;11;0;Create;True;0;0;False;0;False;0,0,0,0;0,0,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;233;-1003.646,1607.973;Inherit;False;208;RelativePos;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PowerNode;201;752.9077,94.56424;Inherit;False;False;2;0;COLOR;0,0,0,0;False;1;FLOAT;1;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;225;-752.4648,1585.502;Inherit;True;Global;TB_NORMALS;TB_NORMALS;1;0;Create;True;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ClampOpNode;202;954.2059,93.75455;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;227;-648.5608,1807.58;Inherit;False;Constant;_Float0;Float 0;6;0;Create;True;0;0;False;0;False;0.5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;226;-367.4729,1591.672;Inherit;False;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.BreakToComponentsNode;205;1196.967,98.24051;Inherit;False;COLOR;1;0;COLOR;0,0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.CommentaryNode;246;-1049.951,2145.353;Inherit;False;1436.779;559.6548;;6;244;241;242;243;236;238;Textures;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;228;-414.1018,1806.619;Inherit;False;Constant;_Float1;Float 1;6;0;Create;True;0;0;False;0;False;2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldToTangentMatrix;230;-202.4963,1806.066;Inherit;False;0;1;FLOAT3x3;0
Node;AmplifyShaderEditor.GetLocalVarNode;244;-999.9516,2329.561;Inherit;False;208;RelativePos;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;210;1486.544,109.8846;Inherit;True;FinalRender;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;229;-177.8292,1590.046;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;242;-640.0944,2195.353;Inherit;True;Property;_TextureSample0;Texture Sample 0;6;0;Create;True;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;211;319.8367,1785.475;Inherit;False;210;FinalRender;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;241;-558.1411,2611.901;Inherit;False;210;FinalRender;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;231;26.19437,1589.604;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT3x3;0,0,0,0,1,0,0,0,1;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;243;-641.4373,2415.028;Inherit;True;Property;_TextureSample1;Texture Sample 1;8;0;Create;True;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector3Node;232;58.53786,1741.444;Inherit;False;Property;_Vector0;Vector 0;7;0;Create;True;0;0;False;0;False;0,0,1;0,0,1;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.LerpOp;236;-60.6907,2400.387;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;234;556.2198,1592.875;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;235;770.5294,1585.933;Inherit;True;Normal;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;238;143.8269,2393.692;Inherit;True;Albedo;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;239;1160.23,2095.129;Inherit;True;238;Albedo;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;240;1153.248,2297.065;Inherit;True;235;Normal;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;117;1439.2,2220.073;Float;False;True;-1;7;ASEMaterialInspector;0;0;Standard;Tartaros/SH_ObjectDepthBlend;False;False;False;False;True;True;True;True;True;True;True;True;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;False;0;False;Opaque;;Geometry;ForwardOnly;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;0;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;1;-1;-1;-1;0;True;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;184;0;183;0
WireConnection;184;1;107;0
WireConnection;185;0;182;1
WireConnection;185;1;182;3
WireConnection;186;0;185;0
WireConnection;186;1;184;0
WireConnection;187;0;186;0
WireConnection;187;1;113;0
WireConnection;212;0;218;0
WireConnection;208;0;187;0
WireConnection;213;0;212;0
WireConnection;213;1;214;0
WireConnection;190;1;209;0
WireConnection;179;0;182;2
WireConnection;219;0;213;0
WireConnection;219;1;217;0
WireConnection;221;0;219;0
WireConnection;193;0;190;0
WireConnection;193;1;194;0
WireConnection;196;0;192;0
WireConnection;196;1;193;0
WireConnection;223;0;206;0
WireConnection;223;1;224;0
WireConnection;197;0;196;0
WireConnection;197;1;195;0
WireConnection;199;0;197;0
WireConnection;199;1;223;0
WireConnection;200;0;199;0
WireConnection;200;1;252;0
WireConnection;200;2;253;0
WireConnection;201;0;200;0
WireConnection;201;1;207;0
WireConnection;225;1;233;0
WireConnection;202;0;201;0
WireConnection;202;1;255;0
WireConnection;202;2;254;0
WireConnection;226;0;225;0
WireConnection;226;1;227;0
WireConnection;205;0;202;0
WireConnection;210;0;205;0
WireConnection;229;0;226;0
WireConnection;229;1;228;0
WireConnection;242;1;244;0
WireConnection;231;0;229;0
WireConnection;231;1;230;0
WireConnection;243;1;244;0
WireConnection;236;0;242;0
WireConnection;236;1;243;0
WireConnection;236;2;241;0
WireConnection;234;0;231;0
WireConnection;234;1;232;0
WireConnection;234;2;211;0
WireConnection;235;0;234;0
WireConnection;238;0;236;0
WireConnection;117;0;239;0
WireConnection;117;1;240;0
ASEEND*/
//CHKSM=7FEC3DA2A4F16A0D1C6EE20C7607E801F0990390