// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "UFoW/UltimateFogOfWar_Fog_Only"
{
	Properties
	{
	}
	SubShader
	{
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
		Blend Zero SrcColor
		Cull Off Lighting Off ZWrite Off
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			//FOG OF WAR
			#include "../FogOfWarMath.cginc"
			#pragma multi_compile __ VerticalMode
			#pragma multi_compile __ FoWColor FoWAnimatedFog

			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 worldPos : TEXCOORD0;//FOG OF WAR
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex);//FOG OF WAR
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 FoW = FoWIntensity(i.worldPos);

				return FoW;//FOG OF WAR
			}
			ENDCG
		}
	}
}
