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
			float2 uv_texcoord;
			float4 vertexToFrag217;
			float4 screenPos;
		};

		uniform float3 _VoroController;
		uniform float4 _RimColor;
		uniform float _RevelatedPercent;
		uniform sampler2D _TextureSample0;
		float4x4 unity_Projector;
		ASE_DECLARE_SCREENSPACE_TEXTURE( _GrabTexture )
		uniform float _WorldPower;
		uniform float4 _PaternColor;
		uniform float2 _DiscoveredStep;
		uniform sampler2D _TextureSample1;


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
			float Voronoi322 = ( voroi280 * _VoroController.z );
			float2 UV221 = ( (i.vertexToFrag217).xy / (i.vertexToFrag217).w );
			float4 Revealated225 = tex2D( _TextureSample0, UV221 );
			float smoothstepResult189 = smoothstep( _RevelatedPercent , 2.0 , ( Revealated225.r > float4( 0,0,0,0 ) ? 1.0 : 0.0 ));
			float4 InteriorMap338 = ( Voronoi322 * ( _RimColor * smoothstepResult189 ) );
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float4 ase_grabScreenPos = ASE_ComputeGrabScreenPos( ase_screenPos );
			float4 screenColor293 = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_GrabTexture,ase_grabScreenPos.xy/ase_grabScreenPos.w);
			float grayscale294 = Luminance(( screenColor293 * _WorldPower ).rgb);
			float4 ExteriorMap325 = ( grayscale294 * _PaternColor );
			float4 Emission328 = ( InteriorMap338 + ExteriorMap325 );
			o.Emission = Emission328.rgb;
			float SmoothRevelated332 = smoothstepResult189;
			float4 Discovered226 = tex2D( _TextureSample1, UV221 );
			float smoothstepResult231 = smoothstep( _DiscoveredStep.x , _DiscoveredStep.y , ( Discovered226.r > float4( 0,0,0,0 ) ? 1.0 : 0.0 ));
			float RTO372 = ( 1.0 - ( SmoothRevelated332 / ( 1.0 - smoothstepResult231 ) ) );
			float Opacity329 = RTO372;
			o.Alpha = Opacity329;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
259;73;1311;594;2833.621;380.7674;1.3;True;False
Node;AmplifyShaderEditor.CommentaryNode;223;-7936.725,-2904.063;Inherit;False;1386.459;466.5935;Comment;8;221;220;219;218;217;216;215;214;UV;1,1,1,1;0;0
Node;AmplifyShaderEditor.PosVertexDataNode;214;-7886.725,-2774.063;Inherit;False;1;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.UnityProjectorMatrixNode;215;-7886.725,-2854.063;Inherit;False;0;1;FLOAT4x4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;216;-7678.725,-2854.063;Inherit;False;2;2;0;FLOAT4x4;0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.VertexToFragmentNode;217;-7534.725,-2854.063;Inherit;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.ComponentMaskNode;219;-7294.725,-2854.063;Inherit;False;True;True;False;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ComponentMaskNode;218;-7294.725,-2774.063;Inherit;False;False;False;False;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;220;-7054.725,-2854.063;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;221;-6775.817,-2797.945;Float;False;UV;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.CommentaryNode;324;-7852.944,-1151.373;Inherit;False;1151.406;850.3862;Comment;12;213;1;2;225;226;317;278;318;279;319;354;356;Textures;1,1,1,1;0;0
Node;AmplifyShaderEditor.GetLocalVarNode;213;-7627.741,-979.3597;Inherit;False;221;UV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;1;-7293.091,-1101.373;Inherit;True;Property;_TextureSample0;Texture Sample 0;2;0;Create;True;0;0;False;0;False;-1;0be5428491ac8a04483b5bc91fb068f6;0be5428491ac8a04483b5bc91fb068f6;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.CommentaryNode;321;-7907.498,-2065.818;Inherit;False;1323.613;483.8406;Comment;6;283;280;286;285;282;322;Voronoi;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;331;-5967.258,-2916.072;Inherit;False;2761.01;547.0185;Comment;13;191;292;189;126;240;245;237;326;269;328;323;332;338;RenderToEmission;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;225;-6931.768,-1087.844;Inherit;False;Revealated;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;2;-7293.429,-889.2233;Inherit;True;Property;_TextureSample1;Texture Sample 1;3;0;Create;True;0;0;False;0;False;-1;4f79457e6662c064cbf77b6bca8e6023;4f79457e6662c064cbf77b6bca8e6023;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;226;-6925.538,-875.1351;Inherit;False;Discovered;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;237;-5917.261,-2631.36;Inherit;False;225;Revealated;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.CommentaryNode;330;-5943.798,-1548.382;Inherit;False;2277.56;454.6017;Comment;9;372;249;242;333;277;231;236;238;229;RenderToOpacity;1,1,1,1;0;0
Node;AmplifyShaderEditor.TimeNode;285;-7857.498,-2015.817;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector3Node;282;-7851.134,-1843.266;Inherit;False;Property;_VoroController;VoroController;5;0;Create;True;0;0;False;0;False;0,1,1;1,50,2;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.CommentaryNode;327;-7858.792,74.72477;Inherit;False;1200.205;508.7923;Comment;7;293;297;296;264;294;265;325;ExteriorMap;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;292;-5299.07,-2535.725;Inherit;False;Property;_RevelatedPercent;RevelatedPercent;6;0;Create;True;0;0;False;0;False;0.5;0.84;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;286;-7601.348,-1929.727;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;229;-5893.798,-1482.066;Inherit;False;226;Discovered;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.Compare;191;-5659.357,-2629.086;Inherit;True;2;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;1;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Compare;236;-5609.042,-1480.632;Inherit;True;2;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;1;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;297;-7805.44,297.9722;Inherit;False;Property;_WorldPower;WorldPower;7;0;Create;True;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;238;-5587.399,-1232.005;Inherit;False;Property;_DiscoveredStep;DiscoveredStep;4;0;Create;True;0;0;False;0;False;0,0;0,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SmoothstepOpNode;189;-5009.628,-2623.054;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;280;-7429.792,-1892.604;Inherit;True;0;0;1;3;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.ScreenColorNode;293;-7808.792,128.2178;Inherit;False;Global;_GrabScreen0;Grab Screen 0;17;0;Create;True;0;0;False;0;False;Object;-1;False;False;1;0;FLOAT2;0,0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;283;-7004.771,-1823.558;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;231;-5186.055,-1476.533;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;-0.33;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;332;-4608.191,-2559.017;Inherit;False;SmoothRevelated;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;296;-7584.439,132.9721;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;264;-7429.515,371.517;Inherit;False;Property;_PaternColor;PaternColor;1;1;[HDR];Create;True;0;0;False;0;False;2,0.5866007,0,1;1,0.2627451,0,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;322;-6832.94,-1828.934;Inherit;False;Voronoi;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;126;-5005.369,-2836.755;Inherit;False;Property;_RimColor;RimColor;0;1;[HDR];Create;True;0;0;False;0;False;2,0.5866007,0,1;1,1,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;333;-4796.38,-1489.481;Inherit;False;332;SmoothRevelated;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;277;-4789.47,-1357.257;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCGrayscale;294;-7407.193,124.7248;Inherit;True;0;1;0;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;242;-4475.005,-1493.253;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;265;-7140.569,249.3891;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;240;-4560.692,-2718.116;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;323;-4580.298,-2851.953;Inherit;False;322;Voronoi;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;249;-4096.092,-1487.339;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;325;-6882.587,236.8995;Inherit;False;ExteriorMap;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;245;-4272.185,-2737.313;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;326;-3988.903,-2626.091;Inherit;False;325;ExteriorMap;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;338;-3992.107,-2742.625;Inherit;False;InteriorMap;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;372;-3896.402,-1493.018;Inherit;False;RTO;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;269;-3716.323,-2705.942;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;373;-4323.178,813.1854;Inherit;False;372;RTO;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;329;-3860.244,878.2062;Inherit;True;Opacity;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;328;-3408.85,-2714.726;Inherit;False;Emission;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.Vector4Node;495;-4674.325,1068.846;Inherit;False;Property;_Vector0;Vector 0;10;0;Create;True;0;0;False;0;False;0,0,0,0;0,0,0,1;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;482;-5746.72,1280.457;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;-0.5,-0.5;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;341;-4877.936,1247.889;Inherit;False;Property;_BLEND;BLEND;8;0;Create;True;0;0;False;0;False;0;-0.49;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;319;-6953.475,-626.9216;Inherit;False;Blur;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TFHCRemapNode;487;-4398.092,910.6319;Inherit;True;5;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;1,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GradientSampleNode;279;-7309.207,-630.3686;Inherit;True;2;0;OBJECT;;False;1;FLOAT;0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;334;-1621.804,-395.3838;Inherit;False;328;Emission;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.LengthOpNode;317;-7802.944,-554.9871;Inherit;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GradientNode;278;-7533.207,-640.3686;Inherit;False;0;2;2;0,0,0,0;1,1,1,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.GetLocalVarNode;477;-4402.139,1271.759;Inherit;False;322;Voronoi;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;354;-7790.092,-796.4268;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;489;-4343.888,1127.489;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;478;-5182.577,1353.521;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;480;-4939.463,963.3247;Inherit;False;325;ExteriorMap;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;359;-4333.75,-919.5455;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;335;-1619.201,-227.9485;Inherit;False;329;Opacity;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.DesaturateOpNode;469;-4805.391,1971.075;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.OneMinusNode;490;-4350.888,1196.489;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;476;-4938.552,889.9127;Inherit;False;338;InteriorMap;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;356;-7568.038,-464.5083;Inherit;False;-1;;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;318;-7580.144,-537.7385;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;488;-4878.568,1094.209;Inherit;False;Property;_MINMAX;MINMAX;9;0;Create;True;0;0;False;0;False;0,0;0.97,1.05;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.LengthOpNode;483;-5555.662,1483.296;Inherit;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;502;-1897.621,-187.0675;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.Vector4Node;499;-2312.323,165.2326;Inherit;False;Property;_VertexOffsetRemap;VertexOffsetRemap;11;0;Create;True;0;0;False;0;False;0,1,0,1;0,1,0,1;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TFHCRemapNode;498;-2017.221,169.1326;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;496;-4037.905,885.0628;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;504;-2145.921,-79.16742;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;503;-2387.722,-16.76744;Inherit;False;Property;_yOffset;yOffset;12;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.NormalVertexDataNode;497;-2426.845,-230.9651;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LuminanceNode;472;-4521.902,1864.498;Inherit;False;1;0;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-1355.587,-436.8273;Float;False;True;-1;7;ASEMaterialInspector;0;0;Standard;Tartaros/SH_FogOfWar_V3;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.01;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;2;5;False;-1;10;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;True;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;216;0;215;0
WireConnection;216;1;214;0
WireConnection;217;0;216;0
WireConnection;219;0;217;0
WireConnection;218;0;217;0
WireConnection;220;0;219;0
WireConnection;220;1;218;0
WireConnection;221;0;220;0
WireConnection;1;1;213;0
WireConnection;225;0;1;0
WireConnection;2;1;213;0
WireConnection;226;0;2;0
WireConnection;286;0;282;1
WireConnection;286;1;285;2
WireConnection;191;0;237;0
WireConnection;236;0;229;0
WireConnection;189;0;191;0
WireConnection;189;1;292;0
WireConnection;280;1;286;0
WireConnection;280;2;282;2
WireConnection;283;0;280;0
WireConnection;283;1;282;3
WireConnection;231;0;236;0
WireConnection;231;1;238;1
WireConnection;231;2;238;2
WireConnection;332;0;189;0
WireConnection;296;0;293;0
WireConnection;296;1;297;0
WireConnection;322;0;283;0
WireConnection;277;0;231;0
WireConnection;294;0;296;0
WireConnection;242;0;333;0
WireConnection;242;1;277;0
WireConnection;265;0;294;0
WireConnection;265;1;264;0
WireConnection;240;0;126;0
WireConnection;240;1;189;0
WireConnection;249;0;242;0
WireConnection;325;0;265;0
WireConnection;245;0;323;0
WireConnection;245;1;240;0
WireConnection;338;0;245;0
WireConnection;372;0;249;0
WireConnection;269;0;338;0
WireConnection;269;1;326;0
WireConnection;329;0;373;0
WireConnection;328;0;269;0
WireConnection;319;0;279;0
WireConnection;487;0;476;0
WireConnection;487;1;495;1
WireConnection;487;2;495;2
WireConnection;487;3;480;0
WireConnection;487;4;495;4
WireConnection;279;0;278;0
WireConnection;279;1;318;0
WireConnection;317;0;213;0
WireConnection;478;0;483;0
WireConnection;478;1;341;0
WireConnection;318;0;317;0
WireConnection;483;0;482;0
WireConnection;502;0;497;1
WireConnection;502;1;504;0
WireConnection;502;2;497;3
WireConnection;498;1;499;1
WireConnection;498;2;499;2
WireConnection;498;3;499;3
WireConnection;498;4;499;4
WireConnection;496;1;487;0
WireConnection;504;0;497;2
WireConnection;504;1;503;0
WireConnection;0;2;334;0
WireConnection;0;9;335;0
ASEEND*/
//CHKSM=C1D8FCB59245894BEF713BCDB06AC93123BF9202