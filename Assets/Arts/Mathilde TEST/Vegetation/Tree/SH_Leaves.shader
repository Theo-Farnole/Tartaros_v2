// Upgrade NOTE: upgraded instancing buffer 'TartarosSH_Leaves' to new syntax.

// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_Leaves"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_VertexPosition("VertexPosition", Float) = 0
		_ScaleVoronoi("ScaleVoronoi", Float) = 3
		_yPosStrength("yPosStrength", Float) = 0
		_WindDirection("WindDirection", Float) = 0
		_BendStrength("BendStrength", Float) = 1
		_SpeedWind("SpeedWind", Float) = 1
		[HideInInspector]_EnableFakeFoWProjection("EnableFakeFoWProjection", Range( 0 , 1)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Background+0" "IgnoreProjector" = "True" }
		Cull Off
		CGINCLUDE
		#include "UnityShaderVariables.cginc"
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 3.0
		#pragma multi_compile_instancing
		struct Input
		{
			float3 worldPos;
			float2 uv_texcoord;
		};

		uniform float _WindDirection;
		uniform float _ScaleVoronoi;
		uniform float _SpeedWind;
		uniform float _BendStrength;
		uniform float _VertexPosition;
		uniform float _yPosStrength;
		uniform sampler2D _TextureSample0;
		uniform float _Cutoff = 0.5;

		UNITY_INSTANCING_BUFFER_START(TartarosSH_Leaves)
			UNITY_DEFINE_INSTANCED_PROP(float, _EnableFakeFoWProjection)
#define _EnableFakeFoWProjection_arr TartarosSH_Leaves
		UNITY_INSTANCING_BUFFER_END(TartarosSH_Leaves)


		float2 voronoihash320( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi320( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash320( n + g );
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


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float3 ase_vertexNormal = v.normal.xyz;
			float time320 = ( _Time.y * _SpeedWind );
			float3 ase_worldPos = mul( unity_ObjectToWorld, v.vertex );
			float2 coords320 = ( ase_worldPos * _BendStrength ).xy * _ScaleVoronoi;
			float2 id320 = 0;
			float2 uv320 = 0;
			float voroi320 = voronoi320( coords320, time320, id320, uv320, 0 );
			float temp_output_324_0 = ( ( ase_vertexNormal.y * voroi320 ) * _VertexPosition );
			float2 temp_cast_1 = (temp_output_324_0).xx;
			float2 temp_cast_2 = (temp_output_324_0).xx;
			float4 appendResult326 = (float4(temp_cast_1 , temp_cast_2));
			float4 break328 = mul( appendResult326, unity_ObjectToWorld );
			float4 appendResult331 = (float4(break328.x , _yPosStrength , break328.z , 0.0));
			float3 rotatedValue332 = RotateAroundAxis( float3( 0,0,0 ), appendResult331.xyz, float3( 0,0,0 ), _WindDirection );
			v.vertex.xyz += rotatedValue332;
			v.vertex.w = 1;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float _EnableFakeFoWProjection_Instance = UNITY_ACCESS_INSTANCED_PROP(_EnableFakeFoWProjection_arr, _EnableFakeFoWProjection);
			float4 color345 = IsGammaSpace() ? float4(0.092,0.092,0.092,1) : float4(0.008825832,0.008825832,0.008825832,1);
			Gradient gradient261 = NewGradient( 1, 3, 2, float4( 0.7686275, 0.4431373, 0.2980392, 0.3617609 ), float4( 0.3137255, 0.4705883, 0.2313726, 0.7058824 ), float4( 0.7058824, 0.5490196, 0.3019608, 1 ), 0, 0, 0, 0, 0, float2( 1, 0 ), float2( 1, 1 ), 0, 0, 0, 0, 0, 0 );
			float3 objToWorld244 = mul( unity_ObjectToWorld, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float3 break235 = objToWorld244;
			float2 appendResult239 = (float2(break235.x , break235.z));
			float dotResult4_g14 = dot( ( appendResult239 + 1.0 ) , float2( 12.9898,78.233 ) );
			float lerpResult10_g14 = lerp( 0.0 , 1.0 , frac( ( sin( dotResult4_g14 ) * 43758.55 ) ));
			float4 tex2DNode263 = tex2D( _TextureSample0, i.uv_texcoord );
			float4 ifLocalVar343 = 0;
			if( _EnableFakeFoWProjection_Instance >= 1.0 )
				ifLocalVar343 = color345;
			else
				ifLocalVar343 = ( SampleGradient( gradient261, lerpResult10_g14 ) * tex2DNode263 );
			o.Albedo = ifLocalVar343.rgb;
			float temp_output_6_0 = 0.0;
			o.Metallic = temp_output_6_0;
			o.Smoothness = temp_output_6_0;
			o.Alpha = tex2DNode263.a;
			clip( tex2DNode263.a - _Cutoff );
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf Standard keepalpha fullforwardshadows vertex:vertexDataFunc 

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#pragma multi_compile_shadowcaster
			#pragma multi_compile UNITY_PASS_SHADOWCASTER
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			#include "HLSLSupport.cginc"
			#if ( SHADER_API_D3D11 || SHADER_API_GLCORE || SHADER_API_GLES || SHADER_API_GLES3 || SHADER_API_METAL || SHADER_API_VULKAN )
				#define CAN_SKIP_VPOS
			#endif
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityPBSLighting.cginc"
			sampler3D _DitherMaskLOD;
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float2 customPack1 : TEXCOORD1;
				float3 worldPos : TEXCOORD2;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};
			v2f vert( appdata_full v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_INITIALIZE_OUTPUT( v2f, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				Input customInputData;
				vertexDataFunc( v, customInputData );
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				o.worldPos = worldPos;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				return o;
			}
			half4 frag( v2f IN
			#if !defined( CAN_SKIP_VPOS )
			, UNITY_VPOS_TYPE vpos : VPOS
			#endif
			) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				Input surfIN;
				UNITY_INITIALIZE_OUTPUT( Input, surfIN );
				surfIN.uv_texcoord = IN.customPack1.xy;
				float3 worldPos = IN.worldPos;
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				surfIN.worldPos = worldPos;
				SurfaceOutputStandard o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputStandard, o )
				surf( surfIN, o );
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				half alphaRef = tex3D( _DitherMaskLOD, float3( vpos.xy * 0.25, o.Alpha * 0.9375 ) ).a;
				clip( alphaRef - 0.01 );
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
1920;32;1680;989;203.012;1034.964;1;True;False
Node;AmplifyShaderEditor.WorldPosInputsNode;316;-2559.701,539.9136;Inherit;True;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.TimeNode;333;-2504.804,203.9042;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;335;-2299.804,392.9042;Inherit;False;Property;_SpeedWind;SpeedWind;13;0;Create;True;0;0;False;0;False;1;0.6;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;317;-2249.413,747.4236;Inherit;False;Property;_BendStrength;BendStrength;12;0;Create;True;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;318;-1987.629,549.6597;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;334;-2027.804,254.9042;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;319;-1991.109,825.9546;Inherit;False;Property;_ScaleVoronoi;ScaleVoronoi;9;0;Create;True;0;0;False;0;False;3;3;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;320;-1703.693,549.4056;Inherit;True;0;0;1;0;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.NormalVertexDataNode;321;-1505.224,316.7786;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TransformPositionNode;244;-1441.439,-228.1953;Inherit;False;Object;World;False;Fast;True;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;322;-1331.186,763.9877;Inherit;False;Property;_VertexPosition;VertexPosition;8;0;Create;True;0;0;False;0;False;0;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.BreakToComponentsNode;235;-1173.753,-226.1534;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;323;-1338.607,517.1187;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;324;-1107.777,646.4417;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;240;-860.6177,-18.50237;Inherit;False;Constant;_Seed;Seed;16;0;Create;True;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;239;-859.7527,-226.1534;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ObjectToWorldMatrixNode;325;-909.2344,783.9366;Inherit;False;0;1;FLOAT4x4;0
Node;AmplifyShaderEditor.DynamicAppendNode;326;-857.4594,624.7086;Inherit;False;FLOAT4;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT2;0,0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleAddOpNode;238;-646.6176,-144.5022;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GradientNode;261;-394.2625,-314.7717;Inherit;False;1;3;2;0.7686275,0.4431373,0.2980392,0.3617609;0.3137255,0.4705883,0.2313726,0.7058824;0.7058824,0.5490196,0.3019608,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;327;-633.2654,689.2776;Inherit;False;2;2;0;FLOAT4;0,0,0,0;False;1;FLOAT4x4;0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1;False;1;FLOAT4;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;272;-282.0938,311.2066;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;233;-372.9389,-147.2983;Inherit;True;Random Range;-1;;14;7b754edb8aebbfb4a9ace907af661cfc;0;3;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;329;-377.5885,852.0137;Inherit;False;Property;_yPosStrength;yPosStrength;10;0;Create;True;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.BreakToComponentsNode;328;-429.2883,689.2776;Inherit;False;FLOAT4;1;0;FLOAT4;0,0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.CommentaryNode;346;302.988,-770.6504;Inherit;False;657;518.6859;Fog of War projection doesn't work well on leaves. So we fake it. ;4;336;343;337;345;;1,1,1,1;0;0
Node;AmplifyShaderEditor.GradientSampleNode;241;-55.66067,-161.4795;Inherit;True;2;0;OBJECT;;False;1;FLOAT;0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;263;-21.20799,281.296;Inherit;True;Property;_TextureSample0;Texture Sample 0;7;0;Create;True;0;0;False;0;False;-1;None;2b5498663217d494db5aa4c80a61a5b9;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;337;423.988,-627.9645;Inherit;False;Constant;_FakeFoWActivationThreshold;FakeFoWActivationThreshold;15;0;Create;True;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;331;-66.9196,696.7866;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RangedFloatNode;336;447.9786,-720.6504;Inherit;False;InstancedProperty;_EnableFakeFoWProjection;EnableFakeFoWProjection;14;0;Create;True;0;0;False;1;HideInInspector;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;345;352.988,-463.9645;Inherit;False;Constant;_FakeFoWProjectionColor;FakeFoWProjectionColor;15;0;Create;True;0;0;False;0;False;0.092,0.092,0.092,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;270;492.4433,-160.1625;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;330;-71.58659,863.7786;Inherit;False;Property;_WindDirection;WindDirection;11;0;Create;True;0;0;False;0;False;0;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;109;-8423.843,1938.209;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;-657.3669,-1218.565;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;99;-8611.883,1337.606;Inherit;False;Constant;_Float1;Float 1;5;0;Create;True;0;0;False;0;False;0.2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;9;-1153.055,-1089.311;Inherit;False;Constant;_GradiantPowMul;Gradiant Pow Mul;1;0;Create;True;0;0;False;0;False;1.3,1;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;132;-8452.82,3056.625;Inherit;False;Property;_WindPositionScale;WindPositionScale;1;0;Create;True;0;0;False;0;False;2;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;7;-850.2123,-1226.1;Inherit;False;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleContrastOpNode;260;-283.024,-1215.552;Inherit;True;2;1;COLOR;0,0,0,0;False;0;FLOAT;5;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;256;-254.7985,-1436.335;Inherit;False;Constant;_ColorBottom;Color Bottom;1;0;Create;True;0;0;False;0;False;0.4701756,0.5,0.2382075,1;0.4701756,0.5,0.2382075,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;94;-9925.275,1620.453;Inherit;False;Constant;_OffsetZ;OffsetZ;5;0;Create;True;0;0;False;0;False;-9;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GradientNode;242;-7967.513,-770.3665;Inherit;False;0;3;2;0.4509804,0.5019608,0.227451,0;0.1960784,0.6156863,0.6784314,0.5000076;0.6784314,0.1960784,0.6114826,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;95;-9427.884,1327.606;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;138;-7391.063,2952.842;Inherit;False;Constant;_Float5;Float 5;3;0;Create;True;0;0;False;0;False;-1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;134;-7931.233,2670.762;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;102;-8309.884,1359.606;Inherit;False;Constant;_Float2;Float 2;5;0;Create;True;0;0;False;0;False;2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;93;-9935.275,1521.453;Inherit;False;Constant;_OffsetX;OffsetX;5;0;Create;True;0;0;False;0;False;-4;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;20;-8171.758,254.5428;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;135;-7077.29,2642.59;Inherit;False;5;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;1,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.WorldNormalVector;89;-8915.972,1466.16;Inherit;True;False;1;0;FLOAT3;0,0,1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;23;-7711.758,263.5428;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ConditionalIfNode;343;769.988,-649.9645;Inherit;False;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;141;-6668.063,2952.842;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;145;-8993.573,2567.814;Inherit;False;Property;_WindPeriod;WindPeriod;3;0;Create;True;0;0;False;0;False;2;0.2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;2;-1136.503,-1265.916;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;91;-9612.275,1191.453;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;108;-8942.948,1815.454;Inherit;False;Constant;_DistanceScale;DistanceScale;5;0;Create;True;0;0;False;0;False;6;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;21;-8375.758,547.5433;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;24;-7831.758,536.5433;Inherit;False;Property;_Ampl;Ampl;2;0;Create;True;0;0;False;0;False;0.2;0.2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;11;-467.2007,-1212.932;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;12;197.3185,-1285.781;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;113;-8024.681,2021.372;Inherit;False;Constant;_Blend;Blend;5;0;Create;True;0;0;False;0;False;10;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;97;-9457.884,1045.607;Inherit;False;Constant;_lScale;lScale;5;0;Create;True;0;0;False;0;False;24;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;111;-8051.681,1783.372;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.BreakToComponentsNode;16;-8638.757,-14.45753;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.DynamicAppendNode;17;-7170.759,-15.45753;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.WorldToTangentMatrix;105;-8154.884,913.6064;Inherit;False;0;1;FLOAT3x3;0
Node;AmplifyShaderEditor.DynamicAppendNode;127;-8494.82,2812.625;Inherit;True;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;27;-7004.554,151.2416;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;88;-8966.278,1045.454;Inherit;True;Reconstruct World Position From Depth;-1;;15;e7094bcbcc80eb140b2a3dbe6a861de8;0;0;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;98;-8419.884,1237.606;Inherit;False;2;0;FLOAT4;0,0,0,0;False;1;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.LerpOp;115;-6936.395,1366.395;Inherit;False;3;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;2;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.ClampOpNode;114;-7550.681,1785.372;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.GradientNode;243;-1185.647,-1630.158;Inherit;False;0;3;2;0.5557297,0.6132076,0.3037113,0.1794156;0.5874742,0.6509434,0.3039783,0.4941176;0.5943396,0.5922174,0.2663314,0.8176547;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;128;-8463.903,3199.412;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;120;-7651.156,2623.372;Inherit;True;Property;_WindNoise;WindNoise;4;0;Create;True;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector3Node;116;-7305.373,1397.074;Inherit;False;Constant;_Vector0;Vector 0;5;0;Create;True;0;0;False;0;False;0,0,1;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SinOpNode;22;-7926.758,256.5428;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;219;-9260.968,2812.336;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;92;-9621.275,1474.453;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;96;-9151.884,1301.606;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;136;-7381.063,2859.842;Inherit;False;Constant;_Float3;Float 3;3;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.BreakToComponentsNode;126;-8768.82,2809.626;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.RangedFloatNode;140;-6985.21,3145.842;Inherit;False;Property;_Strenght;Strenght;5;0;Create;True;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;119;-8525.037,544.3043;Inherit;False;Constant;_Float0;Float 0;2;0;Create;True;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;122;-8690.819,2411.624;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;18;-8413.758,254.5428;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;6;693.0359,222.3397;Inherit;False;Constant;_Zero;Zero;1;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;137;-7240.063,2856.842;Inherit;False;Constant;_Float4;Float 4;3;0;Create;True;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;90;-10180.28,1274.453;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.WorldPosInputsNode;125;-9062.82,3044.626;Inherit;True;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;19;-8590.757,331.5428;Inherit;False;Property;_Frequency;Frequency;6;0;Create;True;0;0;False;0;False;5;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;139;-7252.063,2954.842;Inherit;False;Constant;_Float6;Float 6;3;0;Create;True;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;101;-8165.884,1241.606;Inherit;False;2;2;0;FLOAT4;0,0,0,0;False;1;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;112;-7817.681,1776.372;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;131;-8130.819,2909.625;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;107;-8950.948,2023.453;Inherit;False;Constant;_OffsetY;OffsetY;5;0;Create;True;0;0;False;0;False;6.7;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;26;-6756.686,-133.8388;Inherit;True;3;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;2;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;110;-8336.964,1665.535;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;104;-7813.884,1047.607;Inherit;False;2;2;0;FLOAT3x3;0,0,0,1,1,1,1,0,1;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RotateAboutAxisNode;332;213.7387,724.4467;Inherit;False;False;4;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleAddOpNode;25;-7448.214,260.5288;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;106;-8560.883,1708.607;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;121;-9029.82,2310.624;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;15;-8891.165,-131.6736;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;273;895.6949,148.1376;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Tartaros/SH_Leaves;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;True;Transparent;;Background;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;318;0;316;0
WireConnection;318;1;317;0
WireConnection;334;0;333;2
WireConnection;334;1;335;0
WireConnection;320;0;318;0
WireConnection;320;1;334;0
WireConnection;320;2;319;0
WireConnection;235;0;244;0
WireConnection;323;0;321;2
WireConnection;323;1;320;0
WireConnection;324;0;323;0
WireConnection;324;1;322;0
WireConnection;239;0;235;0
WireConnection;239;1;235;2
WireConnection;326;0;324;0
WireConnection;326;2;324;0
WireConnection;238;0;239;0
WireConnection;238;1;240;0
WireConnection;327;0;326;0
WireConnection;327;1;325;0
WireConnection;233;1;238;0
WireConnection;328;0;327;0
WireConnection;241;0;261;0
WireConnection;241;1;233;0
WireConnection;263;1;272;0
WireConnection;331;0;328;0
WireConnection;331;1;329;0
WireConnection;331;2;328;2
WireConnection;270;0;241;0
WireConnection;270;1;263;0
WireConnection;109;0;107;0
WireConnection;109;1;108;0
WireConnection;10;0;7;0
WireConnection;10;1;9;2
WireConnection;7;0;2;2
WireConnection;7;1;9;1
WireConnection;260;1;11;0
WireConnection;95;0;91;0
WireConnection;95;1;92;0
WireConnection;134;0;122;0
WireConnection;134;1;131;0
WireConnection;20;0;18;0
WireConnection;20;1;21;0
WireConnection;135;0;120;0
WireConnection;135;1;136;0
WireConnection;135;2;137;0
WireConnection;135;3;138;0
WireConnection;135;4;139;0
WireConnection;89;0;96;0
WireConnection;23;0;22;0
WireConnection;23;1;24;0
WireConnection;343;0;336;0
WireConnection;343;1;337;0
WireConnection;343;2;345;0
WireConnection;343;3;345;0
WireConnection;343;4;270;0
WireConnection;91;0;90;1
WireConnection;91;1;90;3
WireConnection;21;0;119;0
WireConnection;11;0;10;0
WireConnection;12;0;256;0
WireConnection;12;1;241;0
WireConnection;12;2;260;0
WireConnection;111;0;110;0
WireConnection;111;1;109;0
WireConnection;16;0;15;0
WireConnection;17;0;25;0
WireConnection;17;1;25;0
WireConnection;17;2;16;2
WireConnection;127;0;126;0
WireConnection;127;1;126;2
WireConnection;98;0;88;0
WireConnection;98;1;99;0
WireConnection;115;0;104;0
WireConnection;115;1;116;0
WireConnection;115;2;114;0
WireConnection;114;0;112;0
WireConnection;128;0;126;0
WireConnection;128;1;126;2
WireConnection;120;1;134;0
WireConnection;22;0;20;0
WireConnection;92;0;93;0
WireConnection;92;1;94;0
WireConnection;96;0;95;0
WireConnection;96;1;97;0
WireConnection;126;0;219;0
WireConnection;122;0;121;0
WireConnection;122;1;145;0
WireConnection;18;0;16;0
WireConnection;18;1;19;0
WireConnection;101;0;98;0
WireConnection;101;1;102;0
WireConnection;112;0;111;0
WireConnection;112;1;113;0
WireConnection;131;0;128;0
WireConnection;131;1;132;0
WireConnection;26;0;15;0
WireConnection;26;1;17;0
WireConnection;26;2;27;2
WireConnection;110;0;90;2
WireConnection;110;1;106;0
WireConnection;104;0;105;0
WireConnection;104;1;101;0
WireConnection;332;1;330;0
WireConnection;332;3;331;0
WireConnection;25;0;16;1
WireConnection;25;1;23;0
WireConnection;106;0;89;1
WireConnection;106;1;108;0
WireConnection;273;0;343;0
WireConnection;273;3;6;0
WireConnection;273;4;6;0
WireConnection;273;9;263;4
WireConnection;273;10;263;4
WireConnection;273;11;332;0
ASEEND*/
//CHKSM=0148B7DEA711727009038A8E7434732FDF18C4B6