// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_FogOfWar_V2"
{
	Properties
	{
		_RimPower("RimPower", Float) = 1
		_RimPower2("RimPower2", Float) = 1
		_FarExplored("FarExplored", Range( 0 , 1)) = 0.2
		[HDR]_VoroColor("VoroColor", Color) = (2,0.5866007,0,1)
		[HDR]_RimColor("RimColor", Color) = (2,0.5866007,0,1)
		[HDR]_RimColor2("RimColor2", Color) = (2,0.5866007,0,1)
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_TextureSample1("Texture Sample 1", 2D) = "white" {}
		_VoroPower("VoroPower", Float) = 1
		_VoroScale("VoroScale", Float) = 1
		_VoroScaleRim("VoroScaleRim", Float) = 1
		_SmoothStep("SmoothStep", Vector) = (0,1,0,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		AlphaToMask On
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 5.0
		#pragma surface surf Standard alpha:fade keepalpha noshadow vertex:vertexDataFunc 
		struct Input
		{
			float4 vertexToFrag217;
			float2 uv_texcoord;
		};

		uniform sampler2D _TextureSample0;
		float4x4 unity_Projector;
		uniform float _FarExplored;
		uniform sampler2D _TextureSample1;
		uniform float _RimPower;
		uniform float4 _RimColor;
		uniform float _VoroScaleRim;
		uniform float2 _SmoothStep;
		uniform float4 _RimColor2;
		uniform float _VoroScale;
		uniform float _VoroPower;
		uniform float4 _VoroColor;
		uniform float _RimPower2;


		float2 voronoihash170( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi170( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash170( n + g );
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
			return (F2 + F1) * 0.5;
		}


		float2 voronoihash33( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi33( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash33( n + g );
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
			float4 ase_vertex4Pos = v.vertex;
			o.vertexToFrag217 = mul( unity_Projector, ase_vertex4Pos );
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 UV221 = ( (i.vertexToFrag217).xy / (i.vertexToFrag217).w );
			float4 tex2DNode1 = tex2D( _TextureSample0, UV221 );
			float4 temp_output_109_0 = ( tex2DNode1 * _FarExplored );
			float4 tex2DNode2 = tex2D( _TextureSample1, UV221 );
			float4 temp_output_95_0 = ( temp_output_109_0 - tex2DNode2 );
			float4 temp_cast_0 = (_RimPower).xxxx;
			float4 smoothstepResult157 = smoothstep( temp_output_95_0 , temp_cast_0 , tex2DNode1);
			float time170 = _Time.y;
			float2 temp_cast_1 = (( _Time.x * 0.01 )).xx;
			float2 uv_TexCoord179 = i.uv_texcoord + temp_cast_1;
			float2 coords170 = uv_TexCoord179 * _VoroScaleRim;
			float2 id170 = 0;
			float2 uv170 = 0;
			float fade170 = 0.5;
			float voroi170 = 0;
			float rest170 = 0;
			for( int it170 = 0; it170 <8; it170++ ){
			voroi170 += fade170 * voronoi170( coords170, time170, id170, uv170, 0 );
			rest170 += fade170;
			coords170 *= 2;
			fade170 *= 0.5;
			}//Voronoi170
			voroi170 /= rest170;
			float smoothstepResult183 = smoothstep( _SmoothStep.x , _SmoothStep.y , voroi170);
			float time33 = ( _Time.w * 0.2 );
			float2 coords33 = i.uv_texcoord * _VoroScale;
			float2 id33 = 0;
			float2 uv33 = 0;
			float fade33 = 0.5;
			float voroi33 = 0;
			float rest33 = 0;
			for( int it33 = 0; it33 <6; it33++ ){
			voroi33 += fade33 * voronoi33( coords33, time33, id33, uv33, 0 );
			rest33 += fade33;
			coords33 *= 2;
			fade33 *= 0.5;
			}//Voronoi33
			voroi33 /= rest33;
			float4 temp_output_106_0 = ( ( voroi33 * _VoroPower ) * _VoroColor );
			float4 temp_cast_4 = (( temp_output_95_0.r > temp_output_106_0.r ? 0.5 : 0.0 )).xxxx;
			float4 temp_cast_5 = (_RimPower2).xxxx;
			float4 smoothstepResult189 = smoothstep( temp_cast_4 , temp_cast_5 , tex2DNode1);
			float4 albedo129 = ( ( smoothstepResult157 * _RimColor * voroi170 ) + ( smoothstepResult183 * _RimColor2 * smoothstepResult189 ) );
			float4 emission25 = ( tex2DNode1 > tex2DNode2 ? float4( 0,0,0,0 ) : temp_output_106_0 );
			o.Emission = ( albedo129 + emission25 ).rgb;
			float4 opacityMask28 = ( ( ( 1.0 - temp_output_95_0 ) * ( 1.0 - tex2DNode2 ) ) - temp_output_109_0 );
			o.Alpha = opacityMask28.r;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
361;73;1175;655;569.5257;275.9752;1.023705;True;False
Node;AmplifyShaderEditor.UnityProjectorMatrixNode;215;-4695.449,-1380.237;Inherit;False;0;1;FLOAT4x4;0
Node;AmplifyShaderEditor.PosVertexDataNode;214;-4695.449,-1300.237;Inherit;False;1;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;216;-4487.449,-1380.237;Inherit;False;2;2;0;FLOAT4x4;0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.VertexToFragmentNode;217;-4343.449,-1380.237;Inherit;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.ComponentMaskNode;219;-4103.449,-1380.237;Inherit;False;True;True;False;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ComponentMaskNode;218;-4103.449,-1300.237;Inherit;False;False;False;False;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;220;-3863.449,-1380.237;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TimeNode;172;-4007.082,1138.473;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;221;-3584.543,-1324.118;Float;False;UV;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;213;-3635.874,-320.6354;Inherit;False;221;UV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;44;-3976.104,1735.458;Inherit;False;Property;_VoroScale;VoroScale;9;0;Create;True;0;0;False;0;False;1;10;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;211;-3767.795,1444.116;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.2;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;32;-3291.777,-538.0788;Inherit;False;2631.71;740.6705;Comment;15;28;2;1;89;95;101;105;109;110;157;129;166;124;163;188;Border + Mask;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;110;-2910.814,-338.4965;Inherit;False;Property;_FarExplored;FarExplored;2;0;Create;True;0;0;False;0;False;0.2;0.131;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;33;-3714.457,1643.524;Inherit;True;0;0;1;0;6;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.RangedFloatNode;37;-3485.545,1852.247;Inherit;False;Property;_VoroPower;VoroPower;8;0;Create;True;0;0;False;0;False;1;0.92;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;1;-3234.475,-482.6619;Inherit;True;Property;_TextureSample0;Texture Sample 0;6;0;Create;True;0;0;False;0;False;-1;0be5428491ac8a04483b5bc91fb068f6;0be5428491ac8a04483b5bc91fb068f6;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;109;-2528.13,-411.4054;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0.2;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;2;-3240.035,-272.0996;Inherit;True;Property;_TextureSample1;Texture Sample 1;7;0;Create;True;0;0;False;0;False;-1;4f79457e6662c064cbf77b6bca8e6023;4f79457e6662c064cbf77b6bca8e6023;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;38;-3314.359,1628.83;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;86;-3059.473,1715.907;Inherit;False;Property;_VoroColor;VoroColor;3;1;[HDR];Create;True;0;0;False;0;False;2,0.5866007,0,1;0.06603771,0.0541195,0.04890529,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;180;-3760.902,1075.372;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.01;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;106;-2771.91,1529.352;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;179;-3587.861,1004.784;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;171;-3516.084,1323.262;Inherit;False;Property;_VoroScaleRim;VoroScaleRim;10;0;Create;True;0;0;False;0;False;1;500;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;95;-2285.734,-339.3806;Inherit;True;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;163;-2009.436,-13.42048;Inherit;False;Property;_RimPower;RimPower;0;0;Create;True;0;0;False;0;False;1;0.51;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;190;-1675.672,648.548;Inherit;False;Property;_RimPower2;RimPower2;1;0;Create;True;0;0;False;0;False;1;-0.24;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Compare;191;-2229.329,331.1467;Inherit;True;2;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0.5;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;170;-3205.831,1164.149;Inherit;True;0;0;1;3;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.Vector2Node;212;-2948.812,1274.565;Inherit;False;Property;_SmoothStep;SmoothStep;13;0;Create;True;0;0;False;0;False;0,1;-0.36,0.7;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SmoothstepOpNode;157;-1653.164,-41.73531;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0.1,0,0,0;False;2;COLOR;1,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;126;-1790.549,435.1479;Inherit;False;Property;_RimColor;RimColor;4;1;[HDR];Create;True;0;0;False;0;False;2,0.5866007,0,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;183;-2972.084,1043.685;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0.2;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;189;-1397.97,397.9376;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0.1,0,0,0;False;2;COLOR;1,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;186;-1463.397,751.7726;Inherit;False;Property;_RimColor2;RimColor2;5;1;[HDR];Create;True;0;0;False;0;False;2,0.5866007,0,1;2,0.5291212,0,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;105;-1910.486,-134.0016;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;101;-1893.135,-234.6247;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;124;-1222.82,75.7209;Inherit;False;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;187;-1058.872,590.2142;Inherit;True;3;3;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;89;-1660.135,-285.5605;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.Compare;136;-2518.109,1428.138;Inherit;True;2;4;0;COLOR;0,0,0,0;False;1;COLOR;1,1,1,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;188;-1005.05,87.06678;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;25;-2193.974,1517.811;Inherit;False;emission;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;166;-1351.341,-409.7413;Inherit;True;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;129;-738.8383,8.746912;Inherit;True;albedo;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;28;-872.4095,-256.4525;Inherit;True;opacityMask;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;26;-117.9727,-45.79696;Inherit;False;25;emission;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;130;-83.67262,-143.3907;Inherit;False;129;albedo;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;185;-2648.753,1034.562;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;158;-2867.308,844.6288;Inherit;False;Property;_SmoothRim;SmoothRim;11;0;Create;True;0;0;False;0;False;0;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;83;-169.2354,99.87907;Inherit;False;28;opacityMask;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;222;201.3244,-48.71274;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.Vector4Node;192;-530.2692,-422.2649;Inherit;False;Property;_Compare;Compare;12;0;Create;True;0;0;False;0;False;1,0,0.5,0;1,0,0.5,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VoronoiNode;182;-3198.126,849.643;Inherit;True;0;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;175;-2592.321,870.0673;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;340.8144,-116.3136;Float;False;True;-1;7;ASEMaterialInspector;0;0;Standard;Tartaros/SH_FogOfWar_V2;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.01;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;True;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;216;0;215;0
WireConnection;216;1;214;0
WireConnection;217;0;216;0
WireConnection;219;0;217;0
WireConnection;218;0;217;0
WireConnection;220;0;219;0
WireConnection;220;1;218;0
WireConnection;221;0;220;0
WireConnection;211;0;172;4
WireConnection;33;1;211;0
WireConnection;33;2;44;0
WireConnection;1;1;213;0
WireConnection;109;0;1;0
WireConnection;109;1;110;0
WireConnection;2;1;213;0
WireConnection;38;0;33;0
WireConnection;38;1;37;0
WireConnection;180;0;172;1
WireConnection;106;0;38;0
WireConnection;106;1;86;0
WireConnection;179;1;180;0
WireConnection;95;0;109;0
WireConnection;95;1;2;0
WireConnection;191;0;95;0
WireConnection;191;1;106;0
WireConnection;170;0;179;0
WireConnection;170;1;172;2
WireConnection;170;2;171;0
WireConnection;157;0;1;0
WireConnection;157;1;95;0
WireConnection;157;2;163;0
WireConnection;183;0;170;0
WireConnection;183;1;212;1
WireConnection;183;2;212;2
WireConnection;189;0;1;0
WireConnection;189;1;191;0
WireConnection;189;2;190;0
WireConnection;105;0;2;0
WireConnection;101;0;95;0
WireConnection;124;0;157;0
WireConnection;124;1;126;0
WireConnection;124;2;170;0
WireConnection;187;0;183;0
WireConnection;187;1;186;0
WireConnection;187;2;189;0
WireConnection;89;0;101;0
WireConnection;89;1;105;0
WireConnection;136;0;1;0
WireConnection;136;1;2;0
WireConnection;136;3;106;0
WireConnection;188;0;124;0
WireConnection;188;1;187;0
WireConnection;25;0;136;0
WireConnection;166;0;89;0
WireConnection;166;1;109;0
WireConnection;129;0;188;0
WireConnection;28;0;166;0
WireConnection;222;0;130;0
WireConnection;222;1;26;0
WireConnection;182;1;172;3
WireConnection;182;2;171;0
WireConnection;175;0;185;0
WireConnection;175;1;158;0
WireConnection;0;2;222;0
WireConnection;0;9;83;0
ASEEND*/
//CHKSM=64A26B64DCCE2456BD4247F31D1287FDB9051F96