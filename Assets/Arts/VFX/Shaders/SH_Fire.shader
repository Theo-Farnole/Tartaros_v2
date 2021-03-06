// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_Fire"
{
	Properties
	{
		_SmoothStepParticleShape("SmoothStepParticleShape", Vector) = (0.9,1,0,0)
		_SmoothStepVoronoi("SmoothStepVoronoi", Vector) = (0.9,1,0,0)
		[HDR]_Color("Color", Color) = (1,0.2889685,0,1)
		_NoiseSpeed("NoiseSpeed", Vector) = (0,-0.1,0,0)
		_VoroSpeed("VoroSpeed", Vector) = (-0.1,-0.5,0,0)
		_VoroPower("VoroPower", Float) = 0.5
		_VoroScale("VoroScale", Float) = 5
		_NoiseScale("NoiseScale", Float) = 10
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGINCLUDE
		#include "UnityShaderVariables.cginc"
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 3.0
		struct Input
		{
			float2 uv_texcoord;
			float4 vertexColor : COLOR;
		};

		uniform float _NoiseScale;
		uniform float2 _NoiseSpeed;
		uniform float2 _SmoothStepVoronoi;
		uniform float _VoroScale;
		uniform float2 _VoroSpeed;
		uniform float _VoroPower;
		uniform float2 _SmoothStepParticleShape;
		uniform float4 _Color;


		float2 voronoihash52( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi52( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash52( n + g );
					o = ( sin( time + o * 6.2831 ) * 0.5 + 0.5 ); float2 r = f - g - o;
					float d = 0.707 * sqrt(dot( r, r ));
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


		float2 voronoihash31( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi31( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
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
			 		float2 o = voronoihash31( n + g );
					o = ( sin( time + o * 6.2831 ) * 0.5 + 0.5 ); float2 r = f - g - o;
					float d = 0.707 * sqrt(dot( r, r ));
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


		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 temp_output_20_0 = ( _NoiseSpeed * _Time.x );
			float time52 = temp_output_20_0.x;
			float2 coords52 = i.uv_texcoord * _NoiseScale;
			float2 id52 = 0;
			float2 uv52 = 0;
			float fade52 = 0.5;
			float voroi52 = 0;
			float rest52 = 0;
			for( int it52 = 0; it52 <8; it52++ ){
			voroi52 += fade52 * voronoi52( coords52, time52, id52, uv52, 0 );
			rest52 += fade52;
			coords52 *= 2;
			fade52 *= 0.5;
			}//Voronoi52
			voroi52 /= rest52;
			float2 temp_output_29_0 = ( _Time.x * _VoroSpeed );
			float time31 = temp_output_29_0.x;
			float2 coords31 = i.uv_texcoord * _VoroScale;
			float2 id31 = 0;
			float2 uv31 = 0;
			float fade31 = 0.5;
			float voroi31 = 0;
			float rest31 = 0;
			for( int it31 = 0; it31 <8; it31++ ){
			voroi31 += fade31 * voronoi31( coords31, time31, id31, uv31, 0 );
			rest31 += fade31;
			coords31 *= 2;
			fade31 *= 0.5;
			}//Voronoi31
			voroi31 /= rest31;
			float smoothstepResult45 = smoothstep( _SmoothStepVoronoi.x , _SmoothStepVoronoi.y , pow( voroi31 , _VoroPower ));
			float time1 = 0.0;
			float2 temp_cast_2 = (voroi52).xx;
			float2 lerpResult21 = lerp( i.uv_texcoord , temp_cast_2 , 0.1);
			float2 DistortionUV24 = lerpResult21;
			float2 coords1 = DistortionUV24 * 1.0;
			float2 id1 = 0;
			float2 uv1 = 0;
			float voroi1 = voronoi1( coords1, time1, id1, uv1, 0 );
			float smoothstepResult4 = smoothstep( _SmoothStepParticleShape.x , _SmoothStepParticleShape.y , ( 1.0 - voroi1 ));
			float ParticleShape6 = smoothstepResult4;
			float temp_output_37_0 = ( ( voroi52 * smoothstepResult45 ) * ParticleShape6 );
			float4 ColoredParticle14 = ( temp_output_37_0 * _Color );
			o.Emission = ColoredParticle14.rgb;
			float Opacity53 = ( i.vertexColor.a * temp_output_37_0 );
			o.Alpha = Opacity53;
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf Standard alpha:fade keepalpha fullforwardshadows 

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
				half4 color : COLOR0;
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
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				o.worldPos = worldPos;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				o.color = v.color;
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
				surfIN.vertexColor = IN.color;
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
348;73;1187;613;3.636849;1261.559;1.121559;True;False
Node;AmplifyShaderEditor.CommentaryNode;26;-1809.932,-1309.341;Inherit;False;2898.819;937.7482;Comment;23;35;24;21;23;22;34;33;29;30;28;31;16;17;20;18;19;40;39;45;46;38;52;54;DISTORTION & COLOR;1,1,1,1;0;0
Node;AmplifyShaderEditor.Vector2Node;19;-1744.417,-1153.127;Inherit;False;Property;_NoiseSpeed;NoiseSpeed;3;0;Create;True;0;0;False;0;False;0,-0.1;0,5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TimeNode;18;-1762.883,-981.7828;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;20;-1496.247,-1084.145;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;40;-1032.716,-1041.94;Inherit;False;Property;_NoiseScale;NoiseScale;7;0;Create;True;0;0;False;0;False;10;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;52;-457.5503,-1232.842;Inherit;True;0;1;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;11.02;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.TexCoordVertexDataNode;22;210.0807,-1256.19;Inherit;False;0;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;23;224.6779,-1011.13;Inherit;False;Constant;_DistortionAmount;DistortionAmount;3;0;Create;True;0;0;False;0;False;0.1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;21;515.0506,-1152.883;Inherit;True;3;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.CommentaryNode;7;-1797.654,-215.8135;Inherit;False;1619.899;369.5872;Comment;8;27;6;4;5;2;1;44;43;ParticleShape;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;24;817.3798,-1158.905;Inherit;False;DistortionUV;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;28;-1742.971,-788.9092;Inherit;False;Property;_VoroSpeed;VoroSpeed;4;0;Create;True;0;0;False;0;False;-0.1,-0.5;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.GetLocalVarNode;27;-1738.557,-156.1866;Inherit;False;24;DistortionUV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;39;-1255.781,-712.1921;Inherit;False;Property;_VoroScale;VoroScale;6;0;Create;True;0;0;False;0;False;5;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;29;-1495.586,-804.2618;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.VoronoiNode;1;-1490.787,-150.5061;Inherit;True;0;0;1;0;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.Vector2Node;5;-991.1619,-73.80931;Inherit;False;Property;_SmoothStepParticleShape;SmoothStepParticleShape;0;0;Create;True;0;0;False;0;False;0.9,1;0.9,0.95;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;34;-815.8193,-809.465;Inherit;False;Property;_VoroPower;VoroPower;5;0;Create;True;0;0;False;0;False;0.5;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;31;-1009.008,-889.727;Inherit;True;0;1;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;2;False;2;FLOAT;5;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.OneMinusNode;2;-1211.156,-149.1521;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;33;-633.0078,-890.2274;Inherit;True;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;46;-645.0087,-605.6695;Inherit;False;Property;_SmoothStepVoronoi;SmoothStepVoronoi;1;0;Create;True;0;0;False;0;False;0.9,1;0,0.5;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SmoothstepOpNode;4;-675.6032,-147.4897;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0.9;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;38;-28.9826,-928.6812;Inherit;False;1098.57;523.1811;Comment;7;14;12;37;13;36;53;55;COLOR;1,1,1,0;0;0
Node;AmplifyShaderEditor.SmoothstepOpNode;45;-345.0006,-662.8925;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0.9;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;6;-400.6453,-152.0527;Inherit;False;ParticleShape;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;35;-176.8621,-898.9221;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;36;21.0174,-773.3967;Inherit;False;6;ParticleShape;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;37;339.8778,-878.6812;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;13;345.2534,-617.5001;Inherit;False;Property;_Color;Color;2;1;[HDR];Create;True;0;0;False;0;False;1,0.2889685,0,1;4.237095,2.37366,0.9095334,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VertexColorNode;54;761.397,-1057.698;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;628.5272,-752.6095;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;55;770.2396,-881.3499;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;53;900.202,-887.8619;Inherit;False;Opacity;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;14;842.5878,-755.8681;Inherit;False;ColoredParticle;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;43;-1695.397,-27.56097;Inherit;False;Property;_Angle;Angle;8;0;Create;True;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;17;-1264.14,-1233.892;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.NoiseGeneratorNode;16;-802.7523,-1238.234;Inherit;True;Simplex3D;True;False;2;0;FLOAT3;0,0,0;False;1;FLOAT;10;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;30;-1317.587,-849.6887;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;10;631.1529,188.8001;Inherit;False;53;Opacity;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;44;-1689.397,56.43903;Inherit;False;Property;_Scale;Scale;9;0;Create;True;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;15;639.4277,25.18324;Inherit;False;14;ColoredParticle;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;956.7457,-21.44326;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Tartaros/SH_Fire;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;True;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;20;0;19;0
WireConnection;20;1;18;1
WireConnection;52;1;20;0
WireConnection;52;2;40;0
WireConnection;21;0;22;0
WireConnection;21;1;52;0
WireConnection;21;2;23;0
WireConnection;24;0;21;0
WireConnection;29;0;18;1
WireConnection;29;1;28;0
WireConnection;1;0;27;0
WireConnection;31;1;29;0
WireConnection;31;2;39;0
WireConnection;2;0;1;0
WireConnection;33;0;31;0
WireConnection;33;1;34;0
WireConnection;4;0;2;0
WireConnection;4;1;5;1
WireConnection;4;2;5;2
WireConnection;45;0;33;0
WireConnection;45;1;46;1
WireConnection;45;2;46;2
WireConnection;6;0;4;0
WireConnection;35;0;52;0
WireConnection;35;1;45;0
WireConnection;37;0;35;0
WireConnection;37;1;36;0
WireConnection;12;0;37;0
WireConnection;12;1;13;0
WireConnection;55;0;54;4
WireConnection;55;1;37;0
WireConnection;53;0;55;0
WireConnection;14;0;12;0
WireConnection;17;0;20;0
WireConnection;17;1;20;0
WireConnection;16;0;17;0
WireConnection;16;1;40;0
WireConnection;30;1;29;0
WireConnection;0;2;15;0
WireConnection;0;9;10;0
ASEEND*/
//CHKSM=15E9C7CD1AD50CE5BFE97A1880450A291EEBE44C