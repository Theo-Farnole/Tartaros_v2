// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Hidden/TerrainEngine/Splatmap/UFow-Standard-Base" {
    Properties {
        _MainTex ("Base (RGB) Smoothness (A)", 2D) = "white" {}
        _MetallicTex ("Metallic (R)", 2D) = "white" {}

        // used in fallback on old cards
        _Color ("Main Color", Color) = (1,1,1,1)
    }

    SubShader {
        Tags {
            "RenderType" = "Opaque"
            "Queue" = "Geometry-100"
        }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0
        // needs more than 8 texcoords
        #pragma exclude_renderers gles
        #include "UnityPBSLighting.cginc"
		#include "../../FogOfWarMath.cginc"
		#pragma multi_compile __ FoWColor FoWAnimatedFog

        sampler2D _MainTex;
        sampler2D _MetallicTex;

        struct Input {
            float2 uv_MainTex;
			float3 worldPos;
        };

        void surf (Input IN, inout SurfaceOutputStandard o) {
            half4 c = tex2D (_MainTex, IN.uv_MainTex);
			
			fixed4 FoW = FoWIntensity(IN.worldPos);

            o.Albedo = c.rgb * FoW.rgb;
            o.Alpha = 1;
            o.Smoothness = c.a * FoW.a;
            o.Metallic = tex2D (_MetallicTex, IN.uv_MainTex).r * FoW.a;
        }

        ENDCG
    }

    FallBack "Diffuse"
}
