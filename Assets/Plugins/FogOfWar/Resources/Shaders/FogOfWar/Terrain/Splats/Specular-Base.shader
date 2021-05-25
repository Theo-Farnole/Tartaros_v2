// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Hidden/TerrainEngine/Splatmap/UFoW-Specular-Base" {
    Properties {
        _SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
        _Shininess ("Shininess", Range (0.03, 1)) = 0.078125
        _MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}

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
        #pragma surface surf BlinnPhong
		#include "../../FogOfWarMath.cginc"
		#pragma multi_compile __ FoWColor FoWAnimatedFog

        sampler2D _MainTex;
        half _Shininess;

        struct Input {
            float2 uv_MainTex;
			float3 worldPos;
        };

        void surf (Input IN, inout SurfaceOutput o) {
            fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
			
			fixed4 FoW = FoWIntensity(IN.worldPos);

            o.Albedo = tex.rgb * FoW.rgb;
            o.Gloss = tex.a * FoW.a;
            o.Alpha = 1.0f * FoW.a;
            o.Specular = _Shininess * FoW.a;
        }
        ENDCG
    }

    //FallBack "Legacy Shaders/Specular"
}
