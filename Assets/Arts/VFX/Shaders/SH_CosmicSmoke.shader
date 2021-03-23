// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "SH_CosmicSmoke"
{
	Properties
	{
		[HDR]_Color0("Color 0", Color) = (0,0.5719719,1,1)
		[HDR]_Color1("Color 1", Color) = (0,1,0.6669481,1)
		_VoroPaternScale("VoroPaternScale", Float) = 0.35
		_VoroBorderScale("VoroBorderScale", Float) = 1
		_BorderSpeed("BorderSpeed", Float) = 1
		_StepOutter("StepOutter", Float) = 2.5
		_OpacityFromPatern("OpacityFromPatern", Vector) = (0,20,0,0)
		_StepInner("StepInner", Vector) = (0,1,0,0)
		_PaternPower("PaternPower", Float) = 2.53
		_ColorSteps("ColorSteps", Vector) = (3,0.1,0,0)
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_TextureStrength("TextureStrength", Float) = 0
		_TextureTiling("TextureTiling", Vector) = (1,1,0,0)
		_TextureSat("TextureSat", Float) = 0.1
		_StarsSpeedRatio("StarsSpeedRatio", Float) = 0.1
		[HideInInspector] _tex3coord( "", 2D ) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Unlit alpha:fade keepalpha noshadow 
		#undef TRANSFORM_TEX
		#define TRANSFORM_TEX(tex,name) float4(tex.xy * name##_ST.xy + name##_ST.zw, tex.z, tex.w)
		struct Input
		{
			float3 worldPos;
			float3 uv_tex3coord;
			float2 uv_texcoord;
			float4 vertexColor : COLOR;
		};

		uniform float4 _Color0;
		uniform float4 _ColorSteps;
		uniform float _VoroBorderScale;
		uniform float _BorderSpeed;
		uniform float _StepOutter;
		uniform float2 _StepInner;
		uniform float _VoroPaternScale;
		uniform float _PaternPower;
		uniform float4 _Color1;
		uniform sampler2D _TextureSample0;
		uniform float2 _TextureTiling;
		uniform float _StarsSpeedRatio;
		uniform float _TextureStrength;
		uniform float _TextureSat;
		uniform float2 _OpacityFromPatern;


		float2 voronoihash20( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi20( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash20( n + g );
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


		float2 voronoihash1( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi1( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash1( n + g );
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


		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float time20 = ( _Time.y * _BorderSpeed );
			float3 break105 = ( float3(1,0.5,0) * _Time.y );
			float3 appendResult106 = (float3(sin( break105.x ) , break105.y , break105.z));
			float3 ase_worldPos = i.worldPos;
			float2 appendResult143 = (float2(ase_worldPos.x , ( ase_worldPos.y + ase_worldPos.z )));
			float3 uvs3_TexCoord98 = i.uv_tex3coord;
			uvs3_TexCoord98.xy = i.uv_tex3coord.xy + appendResult143;
			float3 uvs3_TexCoord72 = i.uv_tex3coord;
			uvs3_TexCoord72.xy = i.uv_tex3coord.xy + ( appendResult106 + uvs3_TexCoord98 ).xy;
			float3 MoveUV116 = uvs3_TexCoord72;
			float2 coords20 = MoveUV116.xy * _VoroBorderScale;
			float2 id20 = 0;
			float2 uv20 = 0;
			float fade20 = 0.5;
			float voroi20 = 0;
			float rest20 = 0;
			for( int it20 = 0; it20 <8; it20++ ){
			voroi20 += fade20 * voronoi20( coords20, time20, id20, uv20, 0 );
			rest20 += fade20;
			coords20 *= 2;
			fade20 *= 0.5;
			}//Voronoi20
			voroi20 /= rest20;
			float RoundZone17 = ( 1.0 - length( ( i.uv_texcoord + float2( -0.5,-0.5 ) ) ) );
			float smoothstepResult62 = smoothstep( 0.5 , 1.0 , RoundZone17);
			float smoothstepResult70 = smoothstep( voroi20 , ( voroi20 * _StepOutter ) , smoothstepResult62);
			float smoothstepResult83 = smoothstep( ( smoothstepResult70 * _StepInner.x ) , _StepInner.y , smoothstepResult70);
			float NoisedRound26 = ( smoothstepResult70 + smoothstepResult83 );
			float time1 = 0.0;
			float3 WorldUV129 = uvs3_TexCoord98;
			float2 coords1 = WorldUV129.xy * _VoroPaternScale;
			float2 id1 = 0;
			float2 uv1 = 0;
			float fade1 = 0.5;
			float voroi1 = 0;
			float rest1 = 0;
			for( int it1 = 0; it1 <7; it1++ ){
			voroi1 += fade1 * voronoi1( coords1, time1, id1, uv1, 0 );
			rest1 += fade1;
			coords1 *= 2;
			fade1 *= 0.5;
			}//Voronoi1
			voroi1 /= rest1;
			float temp_output_112_0 = ( RoundZone17 * _PaternPower );
			float Patern41 = ( ( NoisedRound26 + 0.0 ) * ( ( voroi1 * temp_output_112_0 ) + temp_output_112_0 ) );
			float smoothstepResult133 = smoothstep( _ColorSteps.x , _ColorSteps.y , Patern41);
			float smoothstepResult134 = smoothstep( _ColorSteps.z , _ColorSteps.w , Patern41);
			float2 appendResult156 = (float2(ase_worldPos.x , ( ase_worldPos.y + ase_worldPos.z )));
			float2 uv_TexCoord145 = i.uv_texcoord * _TextureTiling + ( appendResult156 / _StarsSpeedRatio );
			float grayscale148 = Luminance(tex2D( _TextureSample0, uv_TexCoord145 ).rgb);
			float Texture147 = ( ( grayscale148 * _TextureStrength ) + _TextureSat );
			o.Emission = ( ( _Color0 * smoothstepResult133 ) + ( ( smoothstepResult134 * _Color1 ) * Texture147 ) ).rgb;
			float smoothstepResult52 = smoothstep( _OpacityFromPatern.x , _OpacityFromPatern.y , Patern41);
			float Opacity40 = ( i.vertexColor.a * smoothstepResult52 );
			o.Alpha = Opacity40;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
253;73;1321;615;7923.347;1147.051;1;True;False
Node;AmplifyShaderEditor.CommentaryNode;138;-5662.144,-2551.743;Inherit;False;1841.097;593.0708;Comment;14;89;137;97;105;107;71;106;98;99;72;116;129;142;143;UVs;1,1,1,1;0;0
Node;AmplifyShaderEditor.Vector3Node;137;-5612.145,-2501.742;Inherit;False;Constant;_Vector1;Vector 1;11;0;Create;True;0;0;False;0;False;1,0.5,0;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.TimeNode;89;-5599.226,-2283.397;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.WorldPosInputsNode;71;-5357.78,-2173.588;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;97;-5342.724,-2334.66;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.BreakToComponentsNode;105;-5168.525,-2334.543;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SimpleAddOpNode;142;-5126.962,-2080.578;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SinOpNode;107;-4869.45,-2344.308;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;143;-4959.962,-2150.578;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.CommentaryNode;16;-7418.688,-2011.565;Inherit;False;1012.65;378.5044;Comment;6;12;17;13;10;11;5;RoundZone;1,1,1,1;0;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;98;-4750.7,-2137.672;Inherit;False;0;-1;3;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TexCoordVertexDataNode;5;-7368.688,-1961.565;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;12;-7364.616,-1818.98;Inherit;False;Constant;_Vector0;Vector 0;2;0;Create;True;0;0;False;0;False;-0.5,-0.5;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.DynamicAppendNode;106;-4678.25,-2337.61;Inherit;False;FLOAT3;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleAddOpNode;99;-4495.971,-2290.623;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleAddOpNode;11;-7126.191,-1875.392;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.LengthOpNode;10;-6989.522,-1874.452;Inherit;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;139;-5655.202,-1239.259;Inherit;False;2700.028;661.0336;Comment;16;22;27;28;117;53;24;20;76;86;70;83;18;62;79;85;26;PATERN in;1,1,1,1;0;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;72;-4312.828,-2340.588;Inherit;False;0;-1;3;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;116;-4064.046,-2347.518;Inherit;False;MoveUV;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;27;-5584.035,-713.4949;Inherit;False;Property;_BorderSpeed;BorderSpeed;4;0;Create;True;0;0;False;0;False;1;0.2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;22;-5605.202,-869.563;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;13;-6809.107,-1875.657;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;53;-5154.208,-701.7579;Inherit;False;Property;_VoroBorderScale;VoroBorderScale;3;0;Create;True;0;0;False;0;False;1;0.25;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;17;-6639.804,-1879.859;Inherit;True;RoundZone;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;28;-5360.788,-813.9678;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;117;-5352.089,-981.546;Inherit;False;116;MoveUV;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.VoronoiNode;20;-5143.796,-973.7451;Inherit;True;0;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;10;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.GetLocalVarNode;18;-4921.75,-1189.259;Inherit;True;17;RoundZone;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;24;-4887.526,-768.9549;Inherit;False;Property;_StepOutter;StepOutter;5;0;Create;True;0;0;False;0;False;2.5;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;76;-4689.723,-831.225;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;62;-4646.48,-1182.904;Inherit;True;3;0;FLOAT;0.32;False;1;FLOAT;0.5;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;86;-4246.025,-763.3585;Inherit;False;Property;_StepInner;StepInner;7;0;Create;True;0;0;False;0;False;0,1;2,0.5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SmoothstepOpNode;70;-4290.765,-1001.094;Inherit;True;3;0;FLOAT;0.32;False;1;FLOAT;-0.17;False;2;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;151;-7754.324,-1094.72;Inherit;False;1991.562;503.7913;Comment;14;150;147;149;148;144;145;146;156;155;154;157;158;159;160;Texture;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;79;-4016.729,-846.0643;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;154;-7705.332,-826.9158;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SmoothstepOpNode;83;-3783.285,-867.3534;Inherit;True;3;0;FLOAT;0.32;False;1;FLOAT;-0.17;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;42;-5680.449,99.94173;Inherit;False;1442;823.9999;Comment;12;31;34;1;41;4;111;112;115;118;127;128;131;PATERN out;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;129;-4484.466,-2124.188;Inherit;False;WorldUV;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleAddOpNode;155;-7474.514,-733.9058;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;156;-7307.514,-803.9058;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;85;-3433.747,-998.8834;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;115;-5353.824,778.8577;Inherit;False;Property;_PaternPower;PaternPower;8;0;Create;True;0;0;False;0;False;2.53;1.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;160;-7304.347,-694.0508;Inherit;False;Property;_StarsSpeedRatio;StarsSpeedRatio;14;0;Create;True;0;0;False;0;False;0.1;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;4;-5599.227,563.9374;Inherit;False;Property;_VoroPaternScale;VoroPaternScale;2;0;Create;True;0;0;False;0;False;0.35;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;118;-5589.814,440.8885;Inherit;False;129;WorldUV;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;34;-5615.229,688.4454;Inherit;True;17;RoundZone;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;1;-5316.97,478.3164;Inherit;True;0;0;1;0;7;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SimpleDivideOpNode;159;-7090.347,-797.0508;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;26;-3198.173,-1004.026;Inherit;True;NoisedRound;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;112;-5151.264,703.3741;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;146;-7704.324,-997.9067;Inherit;False;Property;_TextureTiling;TextureTiling;12;0;Create;True;0;0;False;0;False;1,1;-3.5,-3.5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;128;-4992.78,558.1631;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;31;-5363.762,228.5859;Inherit;True;26;NoisedRound;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;145;-7483.324,-1015.907;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;127;-5004.54,404.5021;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;131;-4812.183,597.9822;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;144;-7226.324,-1043.646;Inherit;True;Property;_TextureSample0;Texture Sample 0;10;0;Create;True;0;0;False;0;False;-1;None;8650b8411ded8de418a4a18428f860ad;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TFHCGrayscale;148;-6790.218,-1044.507;Inherit;True;0;1;0;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;150;-6777.461,-796.6021;Inherit;False;Property;_TextureStrength;TextureStrength;11;0;Create;True;0;0;False;0;False;0;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;111;-4655.364,448.7071;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;149;-6529.104,-1039.544;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;157;-6480.605,-801.7933;Inherit;False;Property;_TextureSat;TextureSat;13;0;Create;True;0;0;False;0;False;0.1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;46;-7503.869,-212.2471;Inherit;False;1159.129;479.0177;Comment;6;52;51;40;36;44;37;Opacity;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;41;-4462.453,437.9415;Inherit;True;Patern;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;141;-2333.081,-1272.48;Inherit;False;1523.412;910.0004;Comment;12;152;45;126;125;3;133;134;2;123;135;43;153;COLORS;1,1,1,1;0;0
Node;AmplifyShaderEditor.GetLocalVarNode;43;-2204.088,-975.1367;Inherit;False;41;Patern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;51;-7262.007,123.3877;Inherit;False;Property;_OpacityFromPatern;OpacityFromPatern;6;0;Create;True;0;0;False;0;False;0,20;-0.1,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector4Node;135;-2283.081,-853.158;Inherit;False;Property;_ColorSteps;ColorSteps;9;0;Create;True;0;0;False;0;False;3,0.1,0,0;3,0.1,0,0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;44;-7442.403,54.77289;Inherit;False;41;Patern;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;158;-6264.92,-1041.699;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;37;-7444.32,-132.1476;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;52;-7016.908,59.38739;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0.47;False;2;FLOAT;1.23;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;147;-6020.413,-1047.015;Inherit;True;Texture;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;123;-2094.015,-576.6702;Inherit;False;Property;_Color1;Color 1;1;1;[HDR];Create;True;0;0;False;0;False;0,1,0.6669481,1;0,0.3430265,0.7169812,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;134;-1935.068,-759.9892;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;125;-1654.882,-776.1867;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SmoothstepOpNode;133;-1936.187,-901.8604;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;153;-1630.432,-535.6262;Inherit;False;147;Texture;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;36;-6829.023,-32.76849;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;2;-2168.067,-1222.48;Inherit;False;Property;_Color0;Color 0;0;1;[HDR];Create;True;0;0;False;0;False;0,0.5719719,1,1;0.05913247,0.7169812,0,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;152;-1342.896,-657.2401;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;40;-6569.922,-37.28009;Inherit;False;Opacity;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3;-1651.027,-1132.743;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.CommentaryNode;140;-500.3495,-1035.055;Inherit;False;313;482;Comment;1;0;CORE;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleAddOpNode;126;-1032.683,-925.0388;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;45;-1026.067,-682.6641;Inherit;True;40;Opacity;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-450.3494,-985.0546;Float;False;True;-1;2;ASEMaterialInspector;0;0;Unlit;SH_CosmicSmoke;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;97;0;137;0
WireConnection;97;1;89;2
WireConnection;105;0;97;0
WireConnection;142;0;71;2
WireConnection;142;1;71;3
WireConnection;107;0;105;0
WireConnection;143;0;71;1
WireConnection;143;1;142;0
WireConnection;98;1;143;0
WireConnection;106;0;107;0
WireConnection;106;1;105;1
WireConnection;106;2;105;2
WireConnection;99;0;106;0
WireConnection;99;1;98;0
WireConnection;11;0;5;0
WireConnection;11;1;12;0
WireConnection;10;0;11;0
WireConnection;72;1;99;0
WireConnection;116;0;72;0
WireConnection;13;0;10;0
WireConnection;17;0;13;0
WireConnection;28;0;22;2
WireConnection;28;1;27;0
WireConnection;20;0;117;0
WireConnection;20;1;28;0
WireConnection;20;2;53;0
WireConnection;76;0;20;0
WireConnection;76;1;24;0
WireConnection;62;0;18;0
WireConnection;70;0;62;0
WireConnection;70;1;20;0
WireConnection;70;2;76;0
WireConnection;79;0;70;0
WireConnection;79;1;86;1
WireConnection;83;0;70;0
WireConnection;83;1;79;0
WireConnection;83;2;86;2
WireConnection;129;0;98;0
WireConnection;155;0;154;2
WireConnection;155;1;154;3
WireConnection;156;0;154;1
WireConnection;156;1;155;0
WireConnection;85;0;70;0
WireConnection;85;1;83;0
WireConnection;1;0;118;0
WireConnection;1;2;4;0
WireConnection;159;0;156;0
WireConnection;159;1;160;0
WireConnection;26;0;85;0
WireConnection;112;0;34;0
WireConnection;112;1;115;0
WireConnection;128;0;1;0
WireConnection;128;1;112;0
WireConnection;145;0;146;0
WireConnection;145;1;159;0
WireConnection;127;0;31;0
WireConnection;131;0;128;0
WireConnection;131;1;112;0
WireConnection;144;1;145;0
WireConnection;148;0;144;0
WireConnection;111;0;127;0
WireConnection;111;1;131;0
WireConnection;149;0;148;0
WireConnection;149;1;150;0
WireConnection;41;0;111;0
WireConnection;158;0;149;0
WireConnection;158;1;157;0
WireConnection;52;0;44;0
WireConnection;52;1;51;1
WireConnection;52;2;51;2
WireConnection;147;0;158;0
WireConnection;134;0;43;0
WireConnection;134;1;135;3
WireConnection;134;2;135;4
WireConnection;125;0;134;0
WireConnection;125;1;123;0
WireConnection;133;0;43;0
WireConnection;133;1;135;1
WireConnection;133;2;135;2
WireConnection;36;0;37;4
WireConnection;36;1;52;0
WireConnection;152;0;125;0
WireConnection;152;1;153;0
WireConnection;40;0;36;0
WireConnection;3;0;2;0
WireConnection;3;1;133;0
WireConnection;126;0;3;0
WireConnection;126;1;152;0
WireConnection;0;2;126;0
WireConnection;0;9;45;0
ASEEND*/
//CHKSM=6510B53293B9C5A88953D50007C69AB0E3AFBB6F