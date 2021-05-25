// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "UFoW/Template/UltimateFogOfWar_VERT_FRAG_TEMPLATE"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			//FOG OF WAR
			#include "../FogOfWarMath.cginc"
			#pragma multi_compile __ VerticalMode
			#pragma multi_compile __ FoWColor FoWAnimatedFog
			
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float3 worldPos : TEXCOORD2;//FOG OF WAR
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex);//FOG OF WAR
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);

				fixed4 FoW = FoWIntensity(i.worldPos);

				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				
				col.rgb *= FoW.rgb;

				return col;
			}
			ENDCG
		}
	}
}
