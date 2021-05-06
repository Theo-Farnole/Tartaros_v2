// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_FogOfWar_V3"
{
	Properties
	{
		[HDR]_RimColor("RimColor", Color) = (2,0.5866007,0,1)
		[HDR]_PaternColor("PaternColor", Color) = (2,0.5866007,0,1)
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_TextureSample1("Texture Sample 1", 2D) = "white" {}
		_DiscoveredStep("DiscoveredStep", Vector) = (0,0,0,0)
		_STEP("STEP", Float) = 0
		_VoroController("VoroController", Vector) = (0,1,1,0)
		_RevelatedPercent("RevelatedPercent", Float) = 0.5
		_WorldPower("WorldPower", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		AlphaToMask On
		GrabPass{ }
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 5.0
		#if defined(UNITY_STEREO_INSTANCING_ENABLED) || defined(UNITY_STEREO_MULTIVIEW_ENABLED)
		#define ASE_DECLARE_SCREENSPACE_TEXTURE(tex) UNITY_DECLARE_SCREENSPACE_TEXTURE(tex);
		#else
		#define ASE_DECLARE_SCREENSPACE_TEXTURE(tex) UNITY_DECLARE_SCREENSPACE_TEXTURE(tex)
		#endif
		#pragma surface surf Standard alpha:fade keepalpha noshadow vertex:vertexDataFunc 
		struct Input
		{
			float4 vertexToFrag217;
			float2 uv_texcoord;
			float4 screenPos;
		};

		float4x4 unity_Projector;
		uniform float3 _VoroController;
		uniform float _RevelatedPercent;
		uniform sampler2D _TextureSample0;
		uniform float4 _RimColor;
		ASE_DECLARE_SCREENSPACE_TEXTURE( _GrabTexture )
		uniform float _WorldPower;
		uniform float4 _PaternColor;
		uniform float2 _DiscoveredStep;
		uniform sampler2D _TextureSample1;
		uniform float _STEP;


		struct Gradient
		{
			int type;
			int colorsLength;
			int alphasLength;
			float4 colors[8];
			float2 alphas[8];
		};


		Gradient NewGradient(int type, int colorsLength, int alphasLength, 
		float4 colors0, float4 colors1, float4 colors2, float4 colors3, float4 colors4, float4 colors5, float4 colors6, float4 colors7,
		float2 alphas0, float2 alphas1, float2 alphas2, float2 alphas3, float2 alphas4, float2 alphas5, float2 alphas6, float2 alphas7)
		{
			Gradient g;
			g.type = type;
			g.colorsLength = colorsLength;
			g.alphasLength = alphasLength;
			g.colors[ 0 ] = colors0;
			g.colors[ 1 ] = colors1;
			g.colors[ 2 ] = colors2;
			g.colors[ 3 ] = colors3;
			g.colors[ 4 ] = colors4;
			g.colors[ 5 ] = colors5;
			g.colors[ 6 ] = colors6;
			g.colors[ 7 ] = colors7;
			g.alphas[ 0 ] = alphas0;
			g.alphas[ 1 ] = alphas1;
			g.alphas[ 2 ] = alphas2;
			g.alphas[ 3 ] = alphas3;
			g.alphas[ 4 ] = alphas4;
			g.alphas[ 5 ] = alphas5;
			g.alphas[ 6 ] = alphas6;
			g.alphas[ 7 ] = alphas7;
			return g;
		}


		float4 SampleGradient( Gradient gradient, float time )
		{
			float3 color = gradient.colors[0].rgb;
			UNITY_UNROLL
			for (int c = 1; c < 8; c++)
			{
			float colorPos = saturate((time - gradient.colors[c-1].w) / (gradient.colors[c].w - gradient.colors[c-1].w)) * step(c, (float)gradient.colorsLength-1);
			color = lerp(color, gradient.colors[c].rgb, lerp(colorPos, step(0.01, colorPos), gradient.type));
			}
			#ifndef UNITY_COLORSPACE_GAMMA
			color = half3(GammaToLinearSpaceExact(color.r), GammaToLinearSpaceExact(color.g), GammaToLinearSpaceExact(color.b));
			#endif
			float alpha = gradient.alphas[0].x;
			UNITY_UNROLL
			for (int a = 1; a < 8; a++)
			{
			float alphaPos = saturate((time - gradient.alphas[a-1].y) / (gradient.alphas[a].y - gradient.alphas[a-1].y)) * step(a, (float)gradient.alphasLength-1);
			alpha = lerp(alpha, gradient.alphas[a].x, lerp(alphaPos, step(0.01, alphaPos), gradient.type));
			}
			return float4(color, alpha);
		}


		float2 voronoihash280( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi280( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash280( n + g );
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


		inline float4 ASE_ComputeGrabScreenPos( float4 pos )
		{
			#if UNITY_UV_STARTS_AT_TOP
			float scale = -1.0;
			#else
			float scale = 1.0;
			#endif
			float4 o = pos;
			o.y = pos.w * 0.5f;
			o.y = ( pos.y - o.y ) * _ProjectionParams.x * scale + o.y;
			return o;
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float4 ase_vertex4Pos = v.vertex;
			o.vertexToFrag217 = mul( unity_Projector, ase_vertex4Pos );
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			Gradient gradient278 = NewGradient( 0, 2, 2, float4( 0, 0, 0, 0 ), float4( 1, 1, 1, 1 ), 0, 0, 0, 0, 0, 0, float2( 1, 0 ), float2( 1, 1 ), 0, 0, 0, 0, 0, 0 );
			float2 UV221 = ( (i.vertexToFrag217).xy / (i.vertexToFrag217).w );
			float4 Blur319 = SampleGradient( gradient278, ( 1.0 - length( UV221 ) ) );
			float time280 = ( _VoroController.x * _Time.y );
			float2 coords280 = i.uv_texcoord * _VoroController.y;
			float2 id280 = 0;
			float2 uv280 = 0;
			float fade280 = 0.5;
			float voroi280 = 0;
			float rest280 = 0;
			for( int it280 = 0; it280 <8; it280++ ){
			voroi280 += fade280 * voronoi280( coords280, time280, id280, uv280, 0 );
			rest280 += fade280;
			coords280 *= 2;
			fade280 *= 0.5;
			}//Voronoi280
			voroi280 /= rest280;
			float4 Revealated225 = tex2D( _TextureSample0, UV221 );
			float smoothstepResult189 = smoothstep( _RevelatedPercent , 2.0 , ( Revealated225.r != float4( 0,0,0,0 ) ? 1.0 : 0.0 ));
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float4 ase_grabScreenPos = ASE_ComputeGrabScreenPos( ase_screenPos );
			float4 screenColor293 = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_GrabTexture,ase_grabScreenPos.xy/ase_grabScreenPos.w);
			float grayscale294 = Luminance(( screenColor293 * _WorldPower ).rgb);
			o.Emission = ( Blur319 * ( ( ( voroi280 * _VoroController.z ) * ( smoothstepResult189 * _RimColor ) ) + ( grayscale294 * _PaternColor ) ) ).rgb;
			float4 Discovered226 = tex2D( _TextureSample1, UV221 );
			float smoothstepResult231 = smoothstep( _DiscoveredStep.x , _DiscoveredStep.y , ( Discovered226.r != float4( 0,0,0,0 ) ? 1.0 : 0.0 ));
			o.Alpha = ( 1.0 - ( ( smoothstepResult189 / ( 1.0 - smoothstepResult231 ) ) * _STEP ) );
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
291;73;1244;594;3571.859;1071.085;2.047888;True;False
Node;AmplifyShaderEditor.CommentaryNode;223;-5589.707,-1764.013;Inherit;False;1386.459;466.5935;Comment;8;221;220;219;218;217;216;215;214;UV;1,1,1,1;0;0
Node;AmplifyShaderEditor.PosVertexDataNode;214;-5539.707,-1634.013;Inherit;False;1;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.UnityProjectorMatrixNode;215;-5539.707,-1714.013;Inherit;False;0;1;FLOAT4x4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;216;-5331.707,-1714.013;Inherit;False;2;2;0;FLOAT4x4;0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.VertexToFragmentNode;217;-5187.707,-1714.013;Inherit;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.ComponentMaskNode;219;-4947.707,-1714.013;Inherit;False;True;True;False;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ComponentMaskNode;218;-4947.707,-1634.013;Inherit;False;False;False;False;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;220;-4707.707,-1714.013;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;221;-4428.8,-1657.894;Float;False;UV;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;213;-6076.811,-796.9301;Inherit;False;221;UV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;1;-5745.426,-918.9437;Inherit;True;Property;_TextureSample0;Texture Sample 0;3;0;Create;True;0;0;False;0;False;-1;0be5428491ac8a04483b5bc91fb068f6;0be5428491ac8a04483b5bc91fb068f6;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;2;-5745.764,-706.7936;Inherit;True;Property;_TextureSample1;Texture Sample 1;4;0;Create;True;0;0;False;0;False;-1;4f79457e6662c064cbf77b6bca8e6023;4f79457e6662c064cbf77b6bca8e6023;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;225;-5384.103,-905.4141;Inherit;False;Revealated;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;226;-5377.873,-692.7055;Inherit;False;Discovered;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.Vector3Node;282;-4105.378,-1106.134;Inherit;False;Property;_VoroController;VoroController;12;0;Create;True;0;0;False;0;False;0,1,1;1,50,2;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.GetLocalVarNode;229;-4831.109,-388.2329;Inherit;False;226;Discovered;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.TimeNode;285;-4111.741,-1278.683;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;237;-4837.023,-696.8419;Inherit;False;225;Revealated;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;292;-4182.315,-811.8371;Inherit;False;Property;_RevelatedPercent;RevelatedPercent;13;0;Create;True;0;0;False;0;False;0.5;0.84;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Compare;191;-4539.77,-672.7101;Inherit;True;1;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;1;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;297;-3947.395,183.7091;Inherit;False;Property;_WorldPower;WorldPower;14;0;Create;True;0;0;False;0;False;0;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;286;-3855.592,-1192.595;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Compare;236;-4522.307,-406.472;Inherit;True;1;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;1;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenColorNode;293;-3950.747,13.95478;Inherit;False;Global;_GrabScreen0;Grab Screen 0;17;0;Create;True;0;0;False;0;False;Object;-1;False;False;1;0;FLOAT2;0,0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LengthOpNode;317;-6255.279,-372.5575;Inherit;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;238;-4243.358,-12.68188;Inherit;False;Property;_DiscoveredStep;DiscoveredStep;5;0;Create;True;0;0;False;0;False;0,0;0,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SmoothstepOpNode;189;-3751.116,-816.9445;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;296;-3726.395,18.70908;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;126;-3582.416,-511.799;Inherit;False;Property;_RimColor;RimColor;1;1;[HDR];Create;True;0;0;False;0;False;2,0.5866007,0,1;1,1,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VoronoiNode;280;-3684.036,-1155.472;Inherit;True;0;0;1;3;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.GradientNode;278;-5985.542,-457.9389;Inherit;False;0;2;2;0,0,0,0;1,1,1,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.OneMinusNode;318;-6032.479,-355.3089;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;231;-4029.353,-275.3956;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;-0.33;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;277;-3597.334,-274.1305;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;283;-3109.53,-921.207;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GradientSampleNode;279;-5761.542,-447.9389;Inherit;True;2;0;OBJECT;;False;1;FLOAT;0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;264;-3571.471,257.254;Inherit;False;Property;_PaternColor;PaternColor;2;1;[HDR];Create;True;0;0;False;0;False;2,0.5866007,0,1;1,0.2627451,0,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TFHCGrayscale;294;-3549.149,10.46179;Inherit;True;0;1;0;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;240;-3157.582,-550.0991;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;319;-5405.81,-444.4919;Inherit;False;Blur;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;272;-2584.514,-135.4205;Inherit;False;Property;_STEP;STEP;10;0;Create;True;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;242;-3207.466,-308.5356;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;245;-2918.615,-596.2161;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;265;-3282.525,135.126;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;276;-2357.773,-207.4732;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;269;-2335.394,-408.2131;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;316;-2369.664,-537.742;Inherit;False;319;Blur;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;256;-4198.074,779.5576;Inherit;False;221;UV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;263;-4597.747,414.1618;Inherit;False;257;VoroPatern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;250;-3896.216,817.5032;Inherit;True;0;0;1;3;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.RangedFloatNode;268;-4592.965,496.3714;Inherit;False;Property;_PaternPower;PaternPower;9;0;Create;True;0;0;False;0;False;1;0.09;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;291;-4703.464,-270.0932;Inherit;False;Constant;_Float0;Float 0;17;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;249;-2158.969,-201.5305;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;239;-4162.512,-594.7971;Inherit;False;Constant;_RevelatedStep;RevelatedStep;6;0;Create;True;0;0;False;0;False;0,0;0.7,2;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;255;-4193.901,926.0771;Inherit;False;Property;_VoroScale;VoroScale;7;0;Create;True;0;0;False;0;False;0;50;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;320;-2052.326,-460.8146;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;257;-2856.236,821.6508;Inherit;False;VoroPatern;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;163;-3860.376,-420.4363;Inherit;False;Property;_RimPower;RimPower;0;0;Create;True;0;0;False;0;False;1;5.07;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;270;-3694.633,1064.043;Inherit;False;Property;_NoiseScale;NoiseScale;8;0;Create;True;0;0;False;0;False;0;-1.35;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;254;-4658.711,796.4395;Inherit;False;Property;_PaternSpeed;PaternSpeed;6;0;Create;True;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;267;-4297.564,446.5712;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;274;-3064.604,823.5759;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;275;-3280.416,895.1229;Inherit;False;Property;_PaternSteps;PaternSteps;11;0;Create;True;0;0;False;0;False;0,0;0.85,0.86;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;253;-4421.262,843.4412;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;251;-3567.669,811.6019;Inherit;True;Gradient;True;True;2;0;FLOAT2;0,0;False;1;FLOAT;-3.33;False;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;252;-4690.181,892.1454;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-1355.587,-436.8273;Float;False;True;-1;7;ASEMaterialInspector;0;0;Standard;Tartaros/SH_FogOfWar_V3;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.01;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;True;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;216;0;215;0
WireConnection;216;1;214;0
WireConnection;217;0;216;0
WireConnection;219;0;217;0
WireConnection;218;0;217;0
WireConnection;220;0;219;0
WireConnection;220;1;218;0
WireConnection;221;0;220;0
WireConnection;1;1;213;0
WireConnection;2;1;213;0
WireConnection;225;0;1;0
WireConnection;226;0;2;0
WireConnection;191;0;237;0
WireConnection;286;0;282;1
WireConnection;286;1;285;2
WireConnection;236;0;229;0
WireConnection;317;0;213;0
WireConnection;189;0;191;0
WireConnection;189;1;292;0
WireConnection;296;0;293;0
WireConnection;296;1;297;0
WireConnection;280;1;286;0
WireConnection;280;2;282;2
WireConnection;318;0;317;0
WireConnection;231;0;236;0
WireConnection;231;1;238;1
WireConnection;231;2;238;2
WireConnection;277;0;231;0
WireConnection;283;0;280;0
WireConnection;283;1;282;3
WireConnection;279;0;278;0
WireConnection;279;1;318;0
WireConnection;294;0;296;0
WireConnection;240;0;189;0
WireConnection;240;1;126;0
WireConnection;319;0;279;0
WireConnection;242;0;189;0
WireConnection;242;1;277;0
WireConnection;245;0;283;0
WireConnection;245;1;240;0
WireConnection;265;0;294;0
WireConnection;265;1;264;0
WireConnection;276;0;242;0
WireConnection;276;1;272;0
WireConnection;269;0;245;0
WireConnection;269;1;265;0
WireConnection;250;0;256;0
WireConnection;250;1;253;0
WireConnection;250;2;255;0
WireConnection;249;0;276;0
WireConnection;320;0;316;0
WireConnection;320;1;269;0
WireConnection;257;0;274;0
WireConnection;267;0;263;0
WireConnection;267;1;268;0
WireConnection;274;0;251;0
WireConnection;274;1;275;1
WireConnection;274;2;275;2
WireConnection;253;0;254;0
WireConnection;253;1;252;2
WireConnection;251;0;250;0
WireConnection;251;1;270;0
WireConnection;0;2;320;0
WireConnection;0;9;249;0
ASEEND*/
//CHKSM=63826DAA603428D3B955AF83373B3C6743CF2174