// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_GloryGemsForeground"
{
	Properties
	{
		_Progress("Progress", Range( 0 , 1)) = 0.2037789
		[NoScaleOffset]_FXTexture("FX Texture", 2D) = "white" {}
		[NoScaleOffset][Normal]_DistortionNormal("Distortion Normal", 2D) = "bump" {}
		_EmptyPatern("EmptyPatern", 2D) = "white" {}
		_UncompletePatern("UncompletePatern", 2D) = "white" {}
		_CompletePatern("CompletePatern", 2D) = "white" {}
		_VoroScale("VoroScale", Float) = 5
		_NoiseScale("NoiseScale", Float) = 5
		_NoiseVariations("NoiseVariations", Vector) = (0.11,0.66,0.74,0)
		_AngleSpeed("AngleSpeed", Float) = 1
		_TextureOffset("TextureOffset", Vector) = (-0.93,-1.01,0,0)
		_TextureTiling("TextureTiling", Float) = 0.5
		_yOffset("yOffset", Float) = 1
		_yScale("yScale", Float) = 1

	}
	
	SubShader
	{
		
		
		Tags { "RenderType"="Opaque" }
	LOD 100

		CGINCLUDE
		#pragma target 3.0
		ENDCG
		Blend Off
		AlphaToMask Off
		Cull Back
		ColorMask RGBA
		ZWrite On
		ZTest LEqual
		Offset 0 , 0
		
		
		
		Pass
		{
			Name "Unlit"
			Tags { "LightMode"="ForwardBase" }
			CGPROGRAM

			

			#ifndef UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX
			//only defining to not throw compilation error over Unity 5.5
			#define UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input)
			#endif
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_instancing
			#include "UnityCG.cginc"
			#include "UnityStandardUtils.cginc"
			#include "UnityShaderVariables.cginc"


			struct appdata
			{
				float4 vertex : POSITION;
				float4 color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			
			struct v2f
			{
				float4 vertex : SV_POSITION;
				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				float3 worldPos : TEXCOORD0;
				#endif
				float4 ase_texcoord1 : TEXCOORD1;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			uniform float _Progress;
			uniform sampler2D _EmptyPatern;
			uniform float _TextureTiling;
			uniform float2 _TextureOffset;
			uniform sampler2D _DistortionNormal;
			uniform sampler2D _FXTexture;
			uniform float4 _FXTexture_ST;
			uniform float _yOffset;
			uniform float _yScale;
			uniform float3 _NoiseVariations;
			uniform float _VoroScale;
			uniform float _AngleSpeed;
			uniform float _NoiseScale;
			uniform sampler2D _UncompletePatern;
			uniform sampler2D _CompletePatern;
					float2 voronoihash12( float2 p )
					{
						
						p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
						return frac( sin( p ) *43758.5453);
					}
			
					float voronoi12( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
						 		float2 o = voronoihash12( n + g );
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
						return F2;
					}
			
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
			

			
			v2f vert ( appdata v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				UNITY_TRANSFER_INSTANCE_ID(v, o);

				o.ase_texcoord1.xy = v.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord1.zw = 0;
				float3 vertexValue = float3(0, 0, 0);
				#if ASE_ABSOLUTE_VERTEX_POS
				vertexValue = v.vertex.xyz;
				#endif
				vertexValue = vertexValue;
				#if ASE_ABSOLUTE_VERTEX_POS
				v.vertex.xyz = vertexValue;
				#else
				v.vertex.xyz += vertexValue;
				#endif
				o.vertex = UnityObjectToClipPos(v.vertex);

				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				#endif
				return o;
			}
			
			fixed4 frag (v2f i ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID(i);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);
				fixed4 finalColor;
				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				float3 WorldPosition = i.worldPos;
				#endif
				float2 temp_cast_0 = (_TextureTiling).xx;
				float2 texCoord322 = i.ase_texcoord1.xy * temp_cast_0 + _TextureOffset;
				float2 uv_FXTexture = i.ase_texcoord1.xy * _FXTexture_ST.xy + _FXTexture_ST.zw;
				float2 MainUvs222_g8 = uv_FXTexture;
				float4 tex2DNode65_g8 = tex2D( _DistortionNormal, MainUvs222_g8 );
				float4 appendResult82_g8 = (float4(0.0 , tex2DNode65_g8.g , 0.0 , tex2DNode65_g8.r));
				float2 temp_output_84_0_g8 = (UnpackScaleNormal( appendResult82_g8, 1.0 )).xy;
				float2 temp_output_71_0_g8 = ( temp_output_84_0_g8 + MainUvs222_g8 );
				float2 break291 = temp_output_71_0_g8;
				float temp_output_308_0 = ( _Progress + _yOffset );
				float temp_output_268_0 = (( 1.0 - ( break291.x + break291.y ) )*1.0 + ( temp_output_308_0 * _yScale ));
				float temp_output_106_0 = ( _Time.y * _AngleSpeed );
				float time12 = temp_output_106_0;
				float2 MainUvs222_g10 = uv_FXTexture;
				float4 tex2DNode65_g10 = tex2D( _DistortionNormal, MainUvs222_g10 );
				float4 appendResult82_g10 = (float4(0.0 , tex2DNode65_g10.g , 0.0 , tex2DNode65_g10.r));
				float2 temp_output_84_0_g10 = (UnpackScaleNormal( appendResult82_g10, temp_output_106_0 )).xy;
				float2 temp_output_71_0_g10 = ( temp_output_84_0_g10 + MainUvs222_g10 );
				float2 coords12 = temp_output_71_0_g10 * _VoroScale;
				float2 id12 = 0;
				float2 uv12 = 0;
				float fade12 = 0.5;
				float voroi12 = 0;
				float rest12 = 0;
				for( int it12 = 0; it12 <8; it12++ ){
				voroi12 += fade12 * voronoi12( coords12, time12, id12, uv12, 0 );
				rest12 += fade12;
				coords12 *= 2;
				fade12 *= 0.5;
				}//Voronoi12
				voroi12 /= rest12;
				float2 temp_cast_1 = (voroi12).xx;
				float gradientNoise305 = GradientNoise(temp_cast_1,_NoiseScale);
				gradientNoise305 = gradientNoise305*0.5 + 0.5;
				float smoothstepResult298 = smoothstep( gradientNoise305 , _NoiseVariations.x , temp_output_268_0);
				float smoothstepResult299 = smoothstep( _NoiseVariations.y , _NoiseVariations.z , smoothstepResult298);
				float temp_output_313_0 = saturate( ( 1.0 - ( ( 1.0 - temp_output_268_0 ) * smoothstepResult299 ) ) );
				
				
				finalColor = ( _Progress == 0.0 ? tex2D( _EmptyPatern, texCoord322 ) : ( ( ( 1.0 - temp_output_313_0 ) * tex2D( _UncompletePatern, texCoord322 ) ) + ( temp_output_313_0 * tex2D( _CompletePatern, texCoord322 ) ) ) );
				return finalColor;
			}
			ENDCG
		}
	}
	CustomEditor "ASEMaterialInspector"
	
	
}
/*ASEBEGIN
Version=18500
320;73;1288;655;2351.572;572.2155;1.6;True;False
Node;AmplifyShaderEditor.RangedFloatNode;107;-2517.818,45.11219;Inherit;False;Property;_AngleSpeed;AngleSpeed;15;0;Create;True;0;0;False;0;False;1;0.25;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;105;-2541.074,-182.9675;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;290;-2291.958,-722.6337;Inherit;False;UI-Sprite Effect Layer;1;;8;789bf62641c5cfe4ab7126850acc22b8;18,74,0,204,0,191,0,225,0,242,0,237,0,249,0,186,0,177,0,182,0,229,0,92,0,98,0,234,0,126,0,129,1,130,0,31,0;18;192;COLOR;1,1,1,1;False;39;COLOR;1,1,1,1;False;37;SAMPLER2D;;False;218;FLOAT2;0,0;False;239;FLOAT2;0,0;False;181;FLOAT2;0,0;False;75;SAMPLER2D;;False;80;FLOAT;1;False;183;FLOAT2;0,0;False;188;SAMPLER2D;;False;33;SAMPLER2D;;False;248;FLOAT2;0,0;False;233;SAMPLER2D;;False;101;SAMPLER2D;;False;57;FLOAT4;0,0,0,0;False;40;FLOAT;0;False;231;FLOAT;1;False;30;FLOAT;1;False;2;COLOR;0;FLOAT2;172
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;106;-2204.449,-159.2355;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;269;-1569.063,-461.5773;Inherit;False;Property;_yOffset;yOffset;22;0;Create;True;0;0;False;0;False;1;-0.9;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;229;-1634.922,-385.9976;Inherit;False;Property;_Progress;Progress;0;0;Create;True;0;0;False;0;False;0.2037789;0.47;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.BreakToComponentsNode;291;-1922.828,-698.4435;Inherit;False;FLOAT2;1;0;FLOAT2;0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SimpleAddOpNode;308;-1276.697,-389.3259;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;304;-1990.61,-262.5819;Inherit;False;UI-Sprite Effect Layer;1;;10;789bf62641c5cfe4ab7126850acc22b8;18,74,0,204,0,191,0,225,0,242,0,237,0,249,0,186,0,177,0,182,0,229,0,92,0,98,0,234,0,126,0,129,1,130,0,31,0;18;192;COLOR;1,1,1,1;False;39;COLOR;1,1,1,1;False;37;SAMPLER2D;;False;218;FLOAT2;0,0;False;239;FLOAT2;0,0;False;181;FLOAT2;0,0;False;75;SAMPLER2D;;False;80;FLOAT;18.88;False;183;FLOAT2;0,0;False;188;SAMPLER2D;;False;33;SAMPLER2D;;False;248;FLOAT2;0,0;False;233;SAMPLER2D;;False;101;SAMPLER2D;;False;57;FLOAT4;0,0,0,0;False;40;FLOAT;0;False;231;FLOAT;1;False;30;FLOAT;1;False;2;COLOR;0;FLOAT2;172
Node;AmplifyShaderEditor.RangedFloatNode;270;-1435.888,-536.9161;Inherit;False;Property;_yScale;yScale;23;0;Create;True;0;0;False;0;False;1;2.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;108;-1809.688,9.142045;Inherit;False;Property;_VoroScale;VoroScale;12;0;Create;True;0;0;False;0;False;5;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;292;-1630.21,-697.8014;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;306;-1789.148,136.0231;Inherit;False;Property;_NoiseScale;NoiseScale;13;0;Create;True;0;0;False;0;False;5;10;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;12;-1533.141,-129.0695;Inherit;True;0;0;1;1;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;5;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;315;-1061.357,-406.32;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;293;-1398.449,-715.8065;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;305;-1314.126,-136.6937;Inherit;True;Gradient;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;5;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector3Node;317;-1015.475,62.19574;Inherit;False;Property;_NoiseVariations;NoiseVariations;14;0;Create;True;0;0;False;0;False;0.11,0.66,0.74;0.11,0.66,0.74;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.ScaleAndOffsetNode;268;-1177.888,-660.9161;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT;-0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;298;-879.2562,-176.3049;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0.29;False;2;FLOAT;0.11;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;310;-576.7342,-654.3163;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;299;-597.2167,-186.4278;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0.66;False;2;FLOAT;0.74;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;302;-349.4804,-609.3824;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;324;-1215.509,775.7013;Inherit;False;Property;_TextureOffset;TextureOffset;18;0;Create;True;0;0;False;0;False;-0.93,-1.01;0.25,0.25;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.OneMinusNode;311;-122.3165,-739.985;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;323;-1256.799,643.453;Inherit;False;Property;_TextureTiling;TextureTiling;19;0;Create;True;0;0;False;0;False;0.5;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;322;-893.4789,659.6851;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;313;79.14156,-760.1373;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;320;-86.66355,623.0192;Inherit;True;Property;_CompletePatern;CompletePatern;10;0;Create;True;0;0;False;0;False;-1;None;d8dab14710df470488579ac1ebb3ba9b;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;230;301.8703,-796.6316;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;319;-97.34982,427.995;Inherit;True;Property;_UncompletePatern;UncompletePatern;9;0;Create;True;0;0;False;0;False;-1;None;87001556610511241963bd5f7ebb1cde;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;258;602.5726,-258.9635;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;109;592.8619,-564.9076;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;307;-101.2228,827.4;Inherit;True;Property;_EmptyPatern;EmptyPatern;8;0;Create;True;0;0;False;0;False;-1;None;3069996c2de2d3342837ab1e854bd86a;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;260;1042.452,-427.3679;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.CommentaryNode;318;-1074.978,263.1171;Inherit;False;309;234;Originals;1;316;;1,1,1,1;0;0
Node;AmplifyShaderEditor.ColorNode;271;397.1692,815.0867;Inherit;False;Property;_GemCompleteColor;GemCompleteColor;16;1;[HDR];Create;True;0;0;False;0;False;0,0.5,1,1;0,0.6226415,0.3647799,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;247;474.1717,-1251.184;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;2;False;2;FLOAT;1.44;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;248;-588.6959,-1175.441;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;100;False;1;FLOAT;0
Node;AmplifyShaderEditor.Compare;256;1727.507,-608.1601;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;0;False;2;COLOR;1,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;243;-79.54474,-1227.433;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;-5;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;231;-1176.138,-1632.335;Inherit;True;0;0;1;4;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;3;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.GradientNode;227;-1225.693,-984.6758;Inherit;False;0;2;2;1,1,1,0;0,0,0,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;251;-126.2767,-1076.426;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;-1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;239;-645.6906,-1636.056;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;252;371.0706,371.2616;Inherit;False;Property;_EmptyGemColor;EmptyGemColor;20;1;[HDR];Create;True;0;0;False;0;False;0.05126947,0.05951124,0.06847818,1;0,0.1320755,0.09108653,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LengthOpNode;225;-822.3137,-747.2774;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector3Node;316;-1024.978,313.1171;Inherit;False;Constant;_Originals;Originals;14;0;Create;True;0;0;False;0;False;0.11,0.66,0.74;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.NoiseGeneratorNode;236;-970.7796,-1635.871;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;1.2;False;1;FLOAT;0
Node;AmplifyShaderEditor.GradientSampleNode;228;-918.0097,-1005.465;Inherit;True;2;0;OBJECT;;False;1;FLOAT;0.38;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;232;-79.1679,-1623.824;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;250;-319.2767,-1205.426;Inherit;False;Property;_Shine;Shine;21;0;Create;True;0;0;False;0;False;5;0.25;-0.5;4;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;241;-614.6425,-1297.616;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.02;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;314;-1137.813,-875.7804;Inherit;False;Constant;_Float1;Float 1;14;0;Create;True;0;0;False;0;False;0.25;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;249;-779.858,-1150.193;Inherit;False;Property;_Patern;Patern;11;0;Create;True;0;0;False;0;False;2;3;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;327;-934.2749,885.5185;Inherit;False;UI-Sprite Effect Layer;1;;12;789bf62641c5cfe4ab7126850acc22b8;18,74,0,204,0,191,0,225,0,242,0,237,0,249,0,186,0,177,0,182,0,229,0,92,0,98,0,234,0,126,0,129,1,130,0,31,0;18;192;COLOR;1,1,1,1;False;39;COLOR;1,1,1,1;False;37;SAMPLER2D;;False;218;FLOAT2;0,0;False;239;FLOAT2;0,0;False;181;FLOAT2;0,0;False;75;SAMPLER2D;;False;80;FLOAT;-0.5;False;183;FLOAT2;0,0;False;188;SAMPLER2D;;False;33;SAMPLER2D;;False;248;FLOAT2;0,0;False;233;SAMPLER2D;;False;101;SAMPLER2D;;False;57;FLOAT4;0,0,0,0;False;40;FLOAT;0;False;231;FLOAT;1;False;30;FLOAT;1;False;2;COLOR;0;FLOAT2;172
Node;AmplifyShaderEditor.ColorNode;110;386.2997,585.2791;Inherit;False;Property;_UncompleteGemColor;UncompleteGemColor;17;1;[HDR];Create;True;0;0;False;0;False;0.07818743,0.4677838,0.3049874,1;0,0.6226415,0.3647799,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;238;-408.933,-1627.251;Inherit;True;Step Antialiasing;-1;;11;2a825e80dfb3290468194f83380797bd;0;2;1;FLOAT;0;False;2;FLOAT;0.63;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;240;-947.8895,-1353.157;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;159;2138.321,-495.9261;Float;False;True;-1;2;ASEMaterialInspector;100;1;Tartaros/SH_GloryGemsForeground;0770190933193b94aaa3065e307002fa;True;Unlit;0;0;Unlit;2;True;0;5;False;-1;10;False;-1;0;1;False;-1;0;False;-1;True;0;False;-1;0;False;-1;False;False;False;False;False;False;True;0;False;-1;True;0;False;-1;True;True;True;True;True;0;False;-1;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;True;1;False;-1;True;3;False;-1;True;True;0;False;-1;0;False;-1;True;1;RenderType=Opaque=RenderType;True;2;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=ForwardBase;False;0;;0;0;Standard;1;Vertex Position,InvertActionOnDeselection;1;0;1;True;False;;False;0
WireConnection;106;0;105;2
WireConnection;106;1;107;0
WireConnection;291;0;290;172
WireConnection;308;0;229;0
WireConnection;308;1;269;0
WireConnection;304;80;106;0
WireConnection;292;0;291;0
WireConnection;292;1;291;1
WireConnection;12;0;304;172
WireConnection;12;1;106;0
WireConnection;12;2;108;0
WireConnection;315;0;308;0
WireConnection;315;1;270;0
WireConnection;293;0;292;0
WireConnection;305;0;12;0
WireConnection;305;1;306;0
WireConnection;268;0;293;0
WireConnection;268;2;315;0
WireConnection;298;0;268;0
WireConnection;298;1;305;0
WireConnection;298;2;317;1
WireConnection;310;0;268;0
WireConnection;299;0;298;0
WireConnection;299;1;317;2
WireConnection;299;2;317;3
WireConnection;302;0;310;0
WireConnection;302;1;299;0
WireConnection;311;0;302;0
WireConnection;322;0;323;0
WireConnection;322;1;324;0
WireConnection;313;0;311;0
WireConnection;320;1;322;0
WireConnection;230;0;313;0
WireConnection;319;1;322;0
WireConnection;258;0;313;0
WireConnection;258;1;320;0
WireConnection;109;0;230;0
WireConnection;109;1;319;0
WireConnection;307;1;322;0
WireConnection;260;0;109;0
WireConnection;260;1;258;0
WireConnection;247;0;232;0
WireConnection;247;2;243;0
WireConnection;248;0;249;0
WireConnection;256;0;229;0
WireConnection;256;2;307;0
WireConnection;256;3;260;0
WireConnection;243;0;268;0
WireConnection;243;1;251;0
WireConnection;251;0;250;0
WireConnection;239;0;231;0
WireConnection;225;0;268;0
WireConnection;228;0;227;0
WireConnection;228;1;308;0
WireConnection;232;0;238;0
WireConnection;241;0;240;0
WireConnection;241;1;248;0
WireConnection;238;1;239;0
WireConnection;238;2;241;0
WireConnection;240;0;231;0
WireConnection;159;0;256;0
ASEEND*/
//CHKSM=E7E3D7DE6813B86DD53AABF771847114B2237477