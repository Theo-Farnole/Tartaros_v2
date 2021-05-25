Shader "UltimateFogOfWar/Units/StaticGeometry" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_MetallicGlossMap("Metallic (& Gloss)", 2D) = "white" {}
		_FogOfWarFade("Fog of War reveal", Range(0,1)) = 1
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#include "../FogOfWarMath.cginc"
		#pragma multi_compile __  VerticalMode
		#pragma multi_compile __ FoWColor FoWAnimatedFog

		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _MetallicGlossMap;

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
		};

		fixed4 _Color;
		half _FogOfWarFade;

		void surf (Input IN, inout SurfaceOutputStandard o) 
		{
			//FOG OF WAR
			fixed4 FoW = FoWIntensity(IN.worldPos);

			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color * FoW;
			fixed4 m = tex2D(_MetallicGlossMap, IN.uv_MainTex);
			o.Albedo = c.rgb * _FogOfWarFade;
			o.Metallic = m.r * FoW.a;
			o.Smoothness = m.a * FoW.a;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
