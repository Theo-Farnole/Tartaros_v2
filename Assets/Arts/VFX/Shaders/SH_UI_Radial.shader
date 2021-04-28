// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_UI_Radial"
{
	Properties
	{
		_AngleSpeed("AngleSpeed", Float) = 0.5
		_VoroScale("VoroScale", Float) = 3
		_NoiseScale("NoiseScale", Float) = 2
		[HDR]_PaternColor("PaternColor", Color) = (1,1,1,0)
		_RotationSpeed("RotationSpeed", Float) = 1
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_SmoothStep("SmoothStep", Vector) = (0,1,0,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}

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
				float4 ase_color : COLOR;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			uniform sampler2D _TextureSample0;
			uniform float4 _TextureSample0_ST;
			uniform float2 _SmoothStep;
			uniform float _VoroScale;
			uniform float _AngleSpeed;
			uniform float _RotationSpeed;
			uniform float _NoiseScale;
			uniform float4 _PaternColor;
					float2 voronoihash10( float2 p )
					{
						
						p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
						return frac( sin( p ) *43758.5453);
					}
			
					float voronoi10( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
						 		float2 o = voronoihash10( n + g );
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
			
			float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }
			float snoise( float2 v )
			{
				const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
				float2 i = floor( v + dot( v, C.yy ) );
				float2 x0 = v - i + dot( i, C.xx );
				float2 i1;
				i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
				float4 x12 = x0.xyxy + C.xxzz;
				x12.xy -= i1;
				i = mod2D289( i );
				float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
				float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
				m = m * m;
				m = m * m;
				float3 x = 2.0 * frac( p * C.www ) - 1.0;
				float3 h = abs( x ) - 0.5;
				float3 ox = floor( x + 0.5 );
				float3 a0 = x - ox;
				m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
				float3 g;
				g.x = a0.x * x0.x + h.x * x0.y;
				g.yz = a0.yz * x12.xz + h.yz * x12.yw;
				return 130.0 * dot( m, g );
			}
			

			
			v2f vert ( appdata v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				UNITY_TRANSFER_INSTANCE_ID(v, o);

				o.ase_texcoord1.xy = v.ase_texcoord.xy;
				o.ase_color = v.color;
				
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
				float2 uv_TextureSample0 = i.ase_texcoord1.xy * _TextureSample0_ST.xy + _TextureSample0_ST.zw;
				float time10 = ( _Time.y * _AngleSpeed );
				float2 texCoord31 = i.ase_texcoord1.xy * float2( 1,1 ) + float2( -0.5,-0.5 );
				float cos30 = cos( ( _Time.y * -0.1 * _RotationSpeed ) );
				float sin30 = sin( ( _Time.y * -0.1 * _RotationSpeed ) );
				float2 rotator30 = mul( texCoord31 - float2( 0,0 ) , float2x2( cos30 , -sin30 , sin30 , cos30 )) + float2( 0,0 );
				float2 coords10 = rotator30 * _VoroScale;
				float2 id10 = 0;
				float2 uv10 = 0;
				float fade10 = 0.5;
				float voroi10 = 0;
				float rest10 = 0;
				for( int it10 = 0; it10 <4; it10++ ){
				voroi10 += fade10 * voronoi10( coords10, time10, id10, uv10, 0 );
				rest10 += fade10;
				coords10 *= 2;
				fade10 *= 0.5;
				}//Voronoi10
				voroi10 /= rest10;
				float2 temp_cast_0 = (voroi10).xx;
				float simplePerlin2D22 = snoise( temp_cast_0*_NoiseScale );
				simplePerlin2D22 = simplePerlin2D22*0.5 + 0.5;
				float smoothstepResult12 = smoothstep( _SmoothStep.x , _SmoothStep.y , simplePerlin2D22);
				
				
				finalColor = ( tex2D( _TextureSample0, uv_TextureSample0 ) * ( i.ase_color + ( smoothstepResult12 * _PaternColor ) ) );
				return finalColor;
			}
			ENDCG
		}
	}
	CustomEditor "ASEMaterialInspector"
	
	
}
/*ASEBEGIN
Version=18500
322;73;1295;655;3754.541;195.0298;1.723598;True;False
Node;AmplifyShaderEditor.RangedFloatNode;33;-2680.602,717.7524;Inherit;False;Property;_RotationSpeed;RotationSpeed;4;0;Create;True;0;0;False;0;False;1;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;23;-2832.726,133.979;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;25;-2506.852,257.6926;Inherit;False;Property;_AngleSpeed;AngleSpeed;0;0;Create;True;0;0;False;0;False;0.5;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;31;-2874.606,454.376;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;-0.5,-0.5;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;32;-2480.721,647.3027;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;-0.1;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;26;-2506.504,353.1167;Inherit;False;Property;_VoroScale;VoroScale;1;0;Create;True;0;0;False;0;False;3;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;24;-2251.656,150.4096;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RotatorNode;30;-2272.519,455.343;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;27;-1962.197,465.6346;Inherit;False;Property;_NoiseScale;NoiseScale;2;0;Create;True;0;0;False;0;False;2;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;10;-1985.876,182.206;Inherit;True;0;0;1;3;4;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;3;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.NoiseGeneratorNode;22;-1693.414,187.3496;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;37;-1649.565,505.3159;Inherit;False;Property;_SmoothStep;SmoothStep;6;0;Create;True;0;0;False;0;False;0,1;-0.5,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SmoothstepOpNode;12;-1416.908,184.0058;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0.3;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;28;-1141.688,466.2753;Inherit;False;Property;_PaternColor;PaternColor;3;1;[HDR];Create;True;0;0;False;0;False;1,1,1,0;0.05780543,0.2462014,0.1046165,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;29;-770.3121,311.8419;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.VertexColorNode;2;-857.6131,-88.7903;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;5;-489.7065,25.36704;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;34;-508.5066,-259.4747;Inherit;True;Property;_TextureSample0;Texture Sample 0;5;0;Create;True;0;0;False;0;False;-1;None;4b488b12a2818574c9af4434d4708483;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;36;-53.54678,-38.29427;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SmoothstepOpNode;13;-1146.776,186.306;Inherit;True;3;0;FLOAT;1;False;1;FLOAT;0;False;2;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;4;245.7934,-38.89014;Float;False;True;-1;2;ASEMaterialInspector;100;1;Tartaros/SH_UI_Radial;0770190933193b94aaa3065e307002fa;True;Unlit;0;0;Unlit;2;True;2;5;False;-1;10;False;-1;0;1;False;-1;0;False;-1;True;0;False;-1;0;False;-1;False;False;False;False;False;False;True;0;False;-1;True;0;False;-1;True;True;True;True;True;0;False;-1;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;True;1;False;-1;True;3;False;-1;True;True;0;False;-1;0;False;-1;True;1;RenderType=Opaque=RenderType;True;2;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;1;LightMode=ForwardBase;False;0;;0;0;Standard;1;Vertex Position,InvertActionOnDeselection;1;0;1;True;False;;False;0
WireConnection;32;0;23;2
WireConnection;32;2;33;0
WireConnection;24;0;23;2
WireConnection;24;1;25;0
WireConnection;30;0;31;0
WireConnection;30;2;32;0
WireConnection;10;0;30;0
WireConnection;10;1;24;0
WireConnection;10;2;26;0
WireConnection;22;0;10;0
WireConnection;22;1;27;0
WireConnection;12;0;22;0
WireConnection;12;1;37;1
WireConnection;12;2;37;2
WireConnection;29;0;12;0
WireConnection;29;1;28;0
WireConnection;5;0;2;0
WireConnection;5;1;29;0
WireConnection;36;0;34;0
WireConnection;36;1;5;0
WireConnection;13;0;12;0
WireConnection;4;0;36;0
ASEEND*/
//CHKSM=4456F254338883362678CC4046AD9DF1E8EEF0B1