// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_GloryGemsBorder"
{
	Properties
	{
		_SquaredFadeInner("SquaredFadeInner", Float) = -2.62
		_AngleSpeed("AngleSpeed", Float) = 1
		_VoroScale("VoroScale", Float) = 5
		[HDR]_PaternColor("PaternColor", Color) = (0,2,1.678431,1)
		[HDR]_PaternColor2("PaternColor2", Color) = (0,0.6691291,0.8705506,1)
		_CircularLerp("CircularLerp", Float) = 0.98
		_CircularLerp1("CircularLerp", Float) = 0.98
		_ColorsLerp("ColorsLerp", Float) = 0.5

	}
	
	SubShader
	{
		
		
		Tags { "RenderType"="Opaque" }
	LOD 100

		CGINCLUDE
		#pragma target 3.0
		ENDCG
		Blend SrcAlpha OneMinusSrcAlpha
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

			uniform float _CircularLerp;
			uniform float4 _PaternColor;
			uniform float _CircularLerp1;
			uniform float4 _PaternColor2;
			uniform float _ColorsLerp;
			uniform float _SquaredFadeInner;
			uniform float _VoroScale;
			uniform float _AngleSpeed;
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
						return F1;
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
				float2 temp_cast_0 = (( _CircularLerp * 2.0 )).xx;
				float2 temp_cast_1 = (( _CircularLerp * -1.0 )).xx;
				float2 texCoord144 = i.ase_texcoord1.xy * temp_cast_0 + temp_cast_1;
				float2 temp_cast_2 = (( _CircularLerp1 * 2.0 )).xx;
				float2 temp_cast_3 = (( _CircularLerp1 * -1.0 )).xx;
				float2 texCoord221 = i.ase_texcoord1.xy * temp_cast_2 + temp_cast_3;
				float4 lerpResult140 = lerp( ( ( 1.0 - length( texCoord144 ) ) * _PaternColor ) , ( length( texCoord221 ) * _PaternColor2 ) , _ColorsLerp);
				float2 temp_cast_4 = (_SquaredFadeInner).xx;
				float2 texCoord2 = i.ase_texcoord1.xy * temp_cast_4 + float2( 0,0 );
				float2 temp_cast_5 = (_SquaredFadeInner).xx;
				float temp_output_69_0 = ( _SquaredFadeInner * -1.0 );
				float2 temp_cast_6 = (temp_output_69_0).xx;
				float2 texCoord57 = i.ase_texcoord1.xy * temp_cast_5 + temp_cast_6;
				float2 temp_cast_7 = (_SquaredFadeInner).xx;
				float2 appendResult68 = (float2(temp_output_69_0 , 0.0));
				float2 texCoord62 = i.ase_texcoord1.xy * temp_cast_7 + appendResult68;
				float2 temp_cast_8 = (_SquaredFadeInner).xx;
				float2 appendResult70 = (float2(0.0 , temp_output_69_0));
				float2 texCoord66 = i.ase_texcoord1.xy * temp_cast_8 + appendResult70;
				float SquaredFadeInner73 = ( ( length( texCoord2.x ) * length( texCoord2.y ) ) * ( length( texCoord57.x ) * length( texCoord57.y ) ) * ( length( texCoord62.x ) * length( texCoord62.y ) ) * ( length( texCoord66.x ) * length( texCoord66.y ) ) );
				float time12 = ( _Time.y * _AngleSpeed );
				float2 coords12 = i.ase_texcoord1.xy * _VoroScale;
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
				float temp_output_138_0 = ( SquaredFadeInner73 * voroi12 );
				float4 temp_output_150_0 = ( temp_output_138_0 * lerpResult140 );
				float4 temp_output_43_0 = ( lerpResult140 * temp_output_150_0 );
				
				
				finalColor = temp_output_43_0;
				return finalColor;
			}
			ENDCG
		}
	}
	CustomEditor "ASEMaterialInspector"
	
	
}
/*ASEBEGIN
Version=18500
320;73;1288;655;1202.738;338.7686;1;True;False
Node;AmplifyShaderEditor.RangedFloatNode;67;-6101.868,-3098.865;Inherit;False;Property;_SquaredFadeInner;SquaredFadeInner;1;0;Create;True;0;0;False;0;False;-2.62;-2.7;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;69;-5622.486,-2576.264;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;-1;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;68;-5310.952,-2637.455;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;70;-5305.009,-2520.15;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;66;-5088.236,-2336.487;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;4,1;False;1;FLOAT2;0,-4;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;2;-5113.251,-3899.833;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;4,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;155;-2096.549,-656.4332;Inherit;False;Property;_CircularLerp;CircularLerp;7;0;Create;True;0;0;False;0;False;0.98;0.16;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;62;-5085.624,-2828.474;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;4,4;False;1;FLOAT2;-4,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;57;-5115.864,-3407.845;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;4,1;False;1;FLOAT2;-4,-4;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LengthOpNode;54;-4762.406,-3536.834;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;3;-4751.4,-3793.74;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;59;-4732.167,-2957.463;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;63;-4734.779,-2465.476;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;27;-4759.795,-4028.822;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;218;-2313.959,-375.7234;Inherit;False;Property;_CircularLerp1;CircularLerp;8;0;Create;True;0;0;False;0;False;0.98;0.16;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;60;-4723.774,-2722.381;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;55;-4754.012,-3301.752;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;156;-1795.455,-616.5386;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;-1;False;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;64;-4726.386,-2230.394;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;154;-1792.152,-741.8371;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;144;-1537.662,-732.4458;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;2,4;False;1;FLOAT2;-1,-2;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;56;-4489.923,-3396.82;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;65;-4462.297,-2325.46;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;52;-4487.312,-3888.808;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;61;-4459.685,-2817.449;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;220;-2012.865,-335.8288;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;-1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;219;-2009.562,-461.1273;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;146;-1231.011,-730.3009;Inherit;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;107;-2578.04,1429.153;Inherit;False;Property;_AngleSpeed;AngleSpeed;2;0;Create;True;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;72;-3988.972,-3051.688;Inherit;True;4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;105;-2606.535,1278.536;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;221;-1755.072,-451.736;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;2,4;False;1;FLOAT2;-1,-2;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;110;-1182.005,-345.0533;Inherit;False;Property;_PaternColor;PaternColor;4;1;[HDR];Create;True;0;0;False;0;False;0,2,1.678431,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;108;-2282.122,1434.568;Inherit;False;Property;_VoroScale;VoroScale;3;0;Create;True;0;0;False;0;False;5;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;106;-2269.91,1302.268;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;73;-3626.357,-3070.214;Inherit;True;SquaredFadeInner;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;222;-1448.421,-449.5911;Inherit;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;147;-973.4014,-765.3445;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;151;-1253.83,35.66906;Inherit;False;Property;_PaternColor2;PaternColor2;5;1;[HDR];Create;True;0;0;False;0;False;0,0.6691291,0.8705506,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;109;-856.177,-346.9225;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.VoronoiNode;12;-1958.76,1039.332;Inherit;True;0;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;5;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.RangedFloatNode;223;-660.0436,37.92695;Inherit;False;Property;_ColorsLerp;ColorsLerp;13;0;Create;True;0;0;False;0;False;0.5;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;98;-2577.794,121.459;Inherit;True;73;SquaredFadeInner;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;153;-930.8674,12.46208;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;140;-382.4339,-288.4685;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0.8679245;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;138;-1551.872,579.757;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;150;-74.51268,-145.0812;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;87;-1913.741,-2801.75;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;4,4;False;1;FLOAT2;-4,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;43;267.3351,-143.6615;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;175;470.2348,-510.0428;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LengthOpNode;74;-1587.912,-4002.098;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;86;-1943.981,-3381.121;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;4,1;False;1;FLOAT2;-4,-4;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;94;-817.0896,-3024.964;Inherit;True;4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;96;-514.8232,-3008.313;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;80;-1318.04,-3370.096;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;90;-2139.07,-2610.731;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.LengthOpNode;75;-1579.517,-3767.016;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;88;-1290.414,-2298.736;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;76;-1315.43,-3862.084;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;171;716.4177,-338.9259;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LengthOpNode;78;-1590.523,-3510.11;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;79;-1582.13,-3275.028;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;82;-1551.891,-2695.657;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;83;-1287.803,-2790.725;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;95;-340.662,-2937.068;Inherit;True;SquaredFadeOuter;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;81;-1560.285,-2930.739;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;93;-2929.986,-3072.141;Inherit;False;Property;_SquaredFadeOuter;SquaredFadeOuter;0;0;Create;True;0;0;False;0;False;-2.7;-2.7;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;117;-680.9681,326.7274;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;89;-1916.353,-2309.763;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;4,1;False;1;FLOAT2;0,-4;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LengthOpNode;84;-1562.896,-2438.752;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;169;-1748.233,-1168.052;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;172;-1580.809,-1361.61;Inherit;False;Rounded Rectangle;-1;;4;8679f72f5be758f47babb3ba1d5f51d3;0;4;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StepOpNode;163;-1238.565,-1262.953;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;166;-975.2837,-1244.715;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;174;-2103.104,-1073.832;Inherit;False;Property;_SquareRadius;SquareRadius;11;0;Create;True;0;0;False;0;False;0.205716;0.77;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;165;-2109.143,-1168.848;Inherit;False;Property;_InnerThickness;InnerThickness;10;0;Create;True;0;0;False;0;False;0.205716;0.77;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;170;243.0707,-512.671;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;92;-2453.771,-2549.54;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;-1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;164;-2102.172,-1283.21;Inherit;False;Property;_Square1;Square1;9;0;Create;True;0;0;False;0;False;0.7430485;0.8;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;91;-2133.126,-2493.426;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;139;-1056.043,563.0513;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;97;-2625.945,347.8824;Inherit;True;95;SquaredFadeOuter;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;111;-2390.287,581.5598;Inherit;False;Property;_SmoothStep;SmoothStep;6;0;Create;True;0;0;False;0;False;-0.15;0.8;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;101;-1817.917,238.577;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.81;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;77;-1941.369,-3873.109;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;4,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;173;-1568.804,-1183.032;Inherit;False;Rounded Rectangle;-1;;5;8679f72f5be758f47babb3ba1d5f51d3;0;4;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;176;529.9268,-630.8008;Inherit;False;Property;_SquarePower;SquarePower;12;0;Create;True;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;85;-1554.504,-2203.67;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;159;972.6207,-138.2207;Float;False;True;-1;2;ASEMaterialInspector;100;1;Tartaros/SH_GloryGemsBorder;0770190933193b94aaa3065e307002fa;True;Unlit;0;0;Unlit;2;True;2;5;False;-1;10;False;-1;0;1;False;-1;0;False;-1;True;0;False;-1;0;False;-1;False;False;False;False;False;False;True;0;False;-1;True;0;False;-1;True;True;True;True;True;0;False;-1;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;True;1;False;-1;True;3;False;-1;True;True;0;False;-1;0;False;-1;True;1;RenderType=Opaque=RenderType;True;2;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=ForwardBase;False;0;;0;0;Standard;1;Vertex Position,InvertActionOnDeselection;1;0;1;True;False;;False;0
WireConnection;69;0;67;0
WireConnection;68;0;69;0
WireConnection;70;1;69;0
WireConnection;66;0;67;0
WireConnection;66;1;70;0
WireConnection;2;0;67;0
WireConnection;62;0;67;0
WireConnection;62;1;68;0
WireConnection;57;0;67;0
WireConnection;57;1;69;0
WireConnection;54;0;57;1
WireConnection;3;0;2;2
WireConnection;59;0;62;1
WireConnection;63;0;66;1
WireConnection;27;0;2;1
WireConnection;60;0;62;2
WireConnection;55;0;57;2
WireConnection;156;0;155;0
WireConnection;64;0;66;2
WireConnection;154;0;155;0
WireConnection;144;0;154;0
WireConnection;144;1;156;0
WireConnection;56;0;54;0
WireConnection;56;1;55;0
WireConnection;65;0;63;0
WireConnection;65;1;64;0
WireConnection;52;0;27;0
WireConnection;52;1;3;0
WireConnection;61;0;59;0
WireConnection;61;1;60;0
WireConnection;220;0;218;0
WireConnection;219;0;218;0
WireConnection;146;0;144;0
WireConnection;72;0;52;0
WireConnection;72;1;56;0
WireConnection;72;2;61;0
WireConnection;72;3;65;0
WireConnection;221;0;219;0
WireConnection;221;1;220;0
WireConnection;106;0;105;2
WireConnection;106;1;107;0
WireConnection;73;0;72;0
WireConnection;222;0;221;0
WireConnection;147;0;146;0
WireConnection;109;0;147;0
WireConnection;109;1;110;0
WireConnection;12;1;106;0
WireConnection;12;2;108;0
WireConnection;153;0;222;0
WireConnection;153;1;151;0
WireConnection;140;0;109;0
WireConnection;140;1;153;0
WireConnection;140;2;223;0
WireConnection;138;0;98;0
WireConnection;138;1;12;0
WireConnection;150;0;138;0
WireConnection;150;1;140;0
WireConnection;87;0;93;0
WireConnection;87;1;90;0
WireConnection;43;0;140;0
WireConnection;43;1;150;0
WireConnection;175;0;170;0
WireConnection;175;1;150;0
WireConnection;74;0;77;1
WireConnection;86;0;93;0
WireConnection;86;1;92;0
WireConnection;94;0;76;0
WireConnection;94;1;80;0
WireConnection;94;2;83;0
WireConnection;94;3;88;0
WireConnection;96;0;94;0
WireConnection;80;0;78;0
WireConnection;80;1;79;0
WireConnection;90;0;92;0
WireConnection;75;0;77;2
WireConnection;88;0;84;0
WireConnection;88;1;85;0
WireConnection;76;0;74;0
WireConnection;76;1;75;0
WireConnection;171;0;175;0
WireConnection;78;0;86;1
WireConnection;79;0;86;2
WireConnection;82;0;87;2
WireConnection;83;0;81;0
WireConnection;83;1;82;0
WireConnection;95;0;96;0
WireConnection;81;0;87;1
WireConnection;117;0;138;0
WireConnection;89;0;93;0
WireConnection;89;1;91;0
WireConnection;84;0;89;1
WireConnection;169;0;164;0
WireConnection;169;1;165;0
WireConnection;172;2;164;0
WireConnection;172;3;164;0
WireConnection;172;4;174;0
WireConnection;163;0;172;0
WireConnection;163;1;173;0
WireConnection;166;0;163;0
WireConnection;170;0;166;0
WireConnection;170;1;43;0
WireConnection;92;0;93;0
WireConnection;91;1;92;0
WireConnection;139;0;101;0
WireConnection;139;1;138;0
WireConnection;101;0;111;0
WireConnection;101;1;98;0
WireConnection;101;2;97;0
WireConnection;77;0;93;0
WireConnection;173;2;169;0
WireConnection;173;3;169;0
WireConnection;173;4;174;0
WireConnection;85;0;89;2
WireConnection;159;0;43;0
ASEEND*/
//CHKSM=8E32E433C2F3A059D72D6173428A3C576EE1E533