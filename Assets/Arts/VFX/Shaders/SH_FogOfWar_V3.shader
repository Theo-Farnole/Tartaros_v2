// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_FogOfWar_V3"
{
	Properties
	{
		[HDR]_RimColor("RimColor", Color) = (2,0.5866007,0,1)
		[HDR]_RimColor2("RimColor2", Color) = (2,0.5866007,0,1)
		[HDR]_PaternColor("PaternColor", Color) = (2,0.5866007,0,1)
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_TextureSample1("Texture Sample 1", 2D) = "white" {}
		_RevelatedStep("RevelatedStep", Vector) = (0,0,0,0)
		_DiscoveredStep("DiscoveredStep", Vector) = (0,0,0,0)
		_Opacity("Opacity", Float) = 0
		_PaternSpeed("PaternSpeed", Float) = 0
		_VoroScale("VoroScale", Float) = 0
		_NoiseScale("NoiseScale", Float) = 0
		_PaternPower("PaternPower", Float) = 1
		_STEP("STEP", Float) = 0
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
		};

		uniform float _STEP;
		uniform float2 _DiscoveredStep;
		uniform sampler2D _TextureSample1;
		float4x4 unity_Projector;
		uniform float4 _RimColor;
		uniform float4 _PaternColor;
		uniform float _VoroScale;
		uniform float _PaternSpeed;
		uniform float _NoiseScale;
		uniform float _PaternPower;
		uniform float2 _RevelatedStep;
		uniform sampler2D _TextureSample0;
		uniform float4 _RimColor2;
		uniform float _Opacity;


		float2 voronoihash250( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi250( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash250( n + g );
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


		float2 UnityGradientNoiseDir( float2 p )
		{
			p = fmod(p , 289);
			float x = fmod((34 * p.x + 1) * p.x , 289) + p.y;
			x = fmod( (34 * x + 1) * x , 289);
			x = frac( x / 41 ) * 2 - 1;
			return normalize( float2(x - floor(x + 0.5 ), abs( x ) - 0.5 ) );
		}
		
		float UnityGradientNoise( float2 UV, float Scale )
		{
			float2 p = UV * Scale;
			float2 ip = floor( p );
			float2 fp = frac( p );
			float d00 = dot( UnityGradientNoiseDir( ip ), fp );
			float d01 = dot( UnityGradientNoiseDir( ip + float2( 0, 1 ) ), fp - float2( 0, 1 ) );
			float d10 = dot( UnityGradientNoiseDir( ip + float2( 1, 0 ) ), fp - float2( 1, 0 ) );
			float d11 = dot( UnityGradientNoiseDir( ip + float2( 1, 1 ) ), fp - float2( 1, 1 ) );
			fp = fp * fp * fp * ( fp * ( fp * 6 - 15 ) + 10 );
			return lerp( lerp( d00, d01, fp.y ), lerp( d10, d11, fp.y ), fp.x ) + 0.5;
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float4 ase_vertex4Pos = v.vertex;
			o.vertexToFrag217 = mul( unity_Projector, ase_vertex4Pos );
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float4 temp_cast_0 = (_STEP).xxxx;
			float2 UV221 = ( (i.vertexToFrag217).xy / (i.vertexToFrag217).w );
			float4 Discovered226 = tex2D( _TextureSample1, UV221 );
			float smoothstepResult231 = smoothstep( _DiscoveredStep.x , _DiscoveredStep.y , ( Discovered226.r > float4( 0,0,0,0 ) ? 1.0 : 0.0 ));
			float4 smoothstepResult271 = smoothstep( temp_cast_0 , float4( 0,0,0,0 ) , ( smoothstepResult231 * _RimColor ));
			float time250 = ( _PaternSpeed * _Time.y );
			float2 coords250 = UV221 * _VoroScale;
			float2 id250 = 0;
			float2 uv250 = 0;
			float fade250 = 0.5;
			float voroi250 = 0;
			float rest250 = 0;
			for( int it250 = 0; it250 <8; it250++ ){
			voroi250 += fade250 * voronoi250( coords250, time250, id250, uv250, 0 );
			rest250 += fade250;
			coords250 *= 2;
			fade250 *= 0.5;
			}//Voronoi250
			voroi250 /= rest250;
			float2 temp_cast_2 = (voroi250).xx;
			float gradientNoise251 = UnityGradientNoise(temp_cast_2,_NoiseScale);
			gradientNoise251 = gradientNoise251*0.5 + 0.5;
			float VoroPatern257 = gradientNoise251;
			float4 Revealated225 = tex2D( _TextureSample0, UV221 );
			float smoothstepResult189 = smoothstep( _RevelatedStep.x , _RevelatedStep.y , ( Revealated225.r > float4( 0,0,0,0 ) ? 1.0 : 0.0 ));
			o.Emission = ( ( smoothstepResult271 + ( _PaternColor * ( VoroPatern257 * _PaternPower ) ) ) + ( ( smoothstepResult231 / smoothstepResult189 ) * _RimColor2 ) ).rgb;
			o.Alpha = ( ( 1.0 - Discovered226 ) * _Opacity ).r;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
361;73;1175;655;4475.312;881.2747;2.248948;True;False
Node;AmplifyShaderEditor.CommentaryNode;223;-4745.449,-1430.237;Inherit;False;1403.906;332;Comment;8;215;214;216;217;219;218;220;221;UV;1,1,1,1;0;0
Node;AmplifyShaderEditor.PosVertexDataNode;214;-4695.449,-1300.237;Inherit;False;1;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.UnityProjectorMatrixNode;215;-4695.449,-1380.237;Inherit;False;0;1;FLOAT4x4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;216;-4487.449,-1380.237;Inherit;False;2;2;0;FLOAT4x4;0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.VertexToFragmentNode;217;-4343.449,-1380.237;Inherit;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.ComponentMaskNode;218;-4103.449,-1300.237;Inherit;False;False;False;False;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;219;-4103.449,-1380.237;Inherit;False;True;True;False;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;220;-3863.449,-1380.237;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;221;-3584.543,-1324.118;Float;False;UV;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TimeNode;252;-4674.683,696.8667;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;254;-4643.213,601.1608;Inherit;False;Property;_PaternSpeed;PaternSpeed;9;0;Create;True;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;213;-6076.811,-796.9301;Inherit;False;221;UV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;2;-5745.764,-706.7936;Inherit;True;Property;_TextureSample1;Texture Sample 1;5;0;Create;True;0;0;False;0;False;-1;4f79457e6662c064cbf77b6bca8e6023;4f79457e6662c064cbf77b6bca8e6023;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;255;-4178.403,730.7984;Inherit;False;Property;_VoroScale;VoroScale;10;0;Create;True;0;0;False;0;False;0;50;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;256;-4181.576,584.2789;Inherit;False;221;UV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;253;-4405.764,648.1625;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;250;-3880.718,622.2245;Inherit;True;0;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.RangedFloatNode;270;-3679.135,868.7646;Inherit;False;Property;_NoiseScale;NoiseScale;11;0;Create;True;0;0;False;0;False;0;-1.35;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;226;-5377.873,-692.7055;Inherit;False;Discovered;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;1;-5745.426,-918.9437;Inherit;True;Property;_TextureSample0;Texture Sample 0;4;0;Create;True;0;0;False;0;False;-1;0be5428491ac8a04483b5bc91fb068f6;0be5428491ac8a04483b5bc91fb068f6;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.NoiseGeneratorNode;251;-3552.171,616.3232;Inherit;True;Gradient;True;True;2;0;FLOAT2;0,0;False;1;FLOAT;-3.33;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;225;-5384.103,-905.4141;Inherit;False;Revealated;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;229;-4831.109,-388.2329;Inherit;False;226;Discovered;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;257;-3178.896,614.9394;Inherit;False;VoroPatern;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Compare;236;-4520.307,-406.472;Inherit;True;2;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;1;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;237;-4837.023,-696.8419;Inherit;False;225;Revealated;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.Vector2Node;238;-4507.228,-185.5435;Inherit;False;Property;_DiscoveredStep;DiscoveredStep;7;0;Create;True;0;0;False;0;False;0,0;5,2;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;268;-3847.956,466.6853;Inherit;False;Property;_PaternPower;PaternPower;12;0;Create;True;0;0;False;0;False;1;0.48;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;126;-3459.763,-443.3059;Inherit;False;Property;_RimColor;RimColor;1;1;[HDR];Create;True;0;0;False;0;False;2,0.5866007,0,1;1,1,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;263;-3864.738,387.4758;Inherit;False;257;VoroPatern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;239;-4027.547,-728.6877;Inherit;False;Property;_RevelatedStep;RevelatedStep;6;0;Create;True;0;0;False;0;False;0,0;0.5,2;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SmoothstepOpNode;231;-4101.539,-269.6966;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;-0.33;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Compare;191;-4534.77,-673.7101;Inherit;True;2;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;1;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;267;-3564.556,419.8852;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;189;-3751.116,-817.9445;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;272;-2977.955,-471.3864;Inherit;False;Property;_STEP;STEP;13;0;Create;True;0;0;False;0;False;0;0.41;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;264;-3626.163,215.351;Inherit;False;Property;_PaternColor;PaternColor;3;1;[HDR];Create;True;0;0;False;0;False;2,0.5866007,0,1;1.152941,0.2980392,0,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;240;-2969.256,-574.7225;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SmoothstepOpNode;271;-2731.554,-503.3861;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;244;-3453.567,-232.1517;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;246;-2599.796,-68.77177;Inherit;False;226;Discovered;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;186;-3623.895,11.57821;Inherit;False;Property;_RimColor2;RimColor2;2;1;[HDR];Create;True;0;0;False;0;False;2,0.5866007,0,1;0,0,0,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;265;-3355.793,275.0695;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;249;-2351.91,-64.577;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;245;-2966.779,-132.9359;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;269;-2485.884,-380.1586;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;248;-2572.794,10.11936;Inherit;False;Property;_Opacity;Opacity;8;0;Create;True;0;0;False;0;False;0;0.75;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;247;-2132.461,-64.79519;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;243;-2241.97,-335.731;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;242;-3318.329,-821.1846;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;163;-3860.376,-420.4363;Inherit;False;Property;_RimPower;RimPower;0;0;Create;True;0;0;False;0;False;1;5.07;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-1913.502,-270.4979;Float;False;True;-1;7;ASEMaterialInspector;0;0;Standard;Tartaros/SH_FogOfWar_V3;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.01;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;True;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;216;0;215;0
WireConnection;216;1;214;0
WireConnection;217;0;216;0
WireConnection;218;0;217;0
WireConnection;219;0;217;0
WireConnection;220;0;219;0
WireConnection;220;1;218;0
WireConnection;221;0;220;0
WireConnection;2;1;213;0
WireConnection;253;0;254;0
WireConnection;253;1;252;2
WireConnection;250;0;256;0
WireConnection;250;1;253;0
WireConnection;250;2;255;0
WireConnection;226;0;2;0
WireConnection;1;1;213;0
WireConnection;251;0;250;0
WireConnection;251;1;270;0
WireConnection;225;0;1;0
WireConnection;257;0;251;0
WireConnection;236;0;229;0
WireConnection;231;0;236;0
WireConnection;231;1;238;1
WireConnection;231;2;238;2
WireConnection;191;0;237;0
WireConnection;267;0;263;0
WireConnection;267;1;268;0
WireConnection;189;0;191;0
WireConnection;189;1;239;1
WireConnection;189;2;239;2
WireConnection;240;0;231;0
WireConnection;240;1;126;0
WireConnection;271;0;240;0
WireConnection;271;1;272;0
WireConnection;244;0;231;0
WireConnection;244;1;189;0
WireConnection;265;0;264;0
WireConnection;265;1;267;0
WireConnection;249;0;246;0
WireConnection;245;0;244;0
WireConnection;245;1;186;0
WireConnection;269;0;271;0
WireConnection;269;1;265;0
WireConnection;247;0;249;0
WireConnection;247;1;248;0
WireConnection;243;0;269;0
WireConnection;243;1;245;0
WireConnection;0;2;243;0
WireConnection;0;9;247;0
ASEEND*/
//CHKSM=FAFAF1697E3A8F014D214EA80DA6E94E4C5BD4D9