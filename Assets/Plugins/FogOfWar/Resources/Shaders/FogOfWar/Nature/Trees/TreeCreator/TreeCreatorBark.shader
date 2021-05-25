// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "UFoW/Nature/Tree Creator Bark" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
    _Shininess ("Shininess", Range (0.01, 1)) = 0.078125
    _MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
    _BumpMap ("Normalmap", 2D) = "bump" {}
    _GlossMap ("Gloss (A)", 2D) = "black" {}

    // These are here only to provide default values
    _SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
    [HideInInspector] _TreeInstanceColor ("TreeInstanceColor", Vector) = (1,1,1,1)
    [HideInInspector] _TreeInstanceScale ("TreeInstanceScale", Vector) = (1,1,1,1)
    [HideInInspector] _SquashAmount ("Squash", Float) = 1
}

SubShader {
    Tags { "IgnoreProjector"="True" "RenderType"="TreeBark" }
    LOD 200

CGPROGRAM
#pragma surface surf BlinnPhong vertex:TreeVertBark addshadow nolightmap
#include "../../UFoW-UnityBuiltin3xTreeLibrary.cginc"
#include "../../../FogOfWarMath.cginc"
#pragma multi_compile __ FoWColor FoWAnimatedFog

sampler2D _MainTex;
sampler2D _BumpMap;
sampler2D _GlossMap;
half _Shininess;

struct Input {
    float2 uv_MainTex;
    fixed4 color : COLOR;
	float3 worldPos;
};

void surf (Input IN, inout SurfaceOutput o) {
    fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
	fixed4 FoW = FoWIntensity(IN.worldPos);
    o.Albedo = c.rgb * IN.color.rgb * FoW.rgb * IN.color.a;
    o.Gloss = tex2D(_GlossMap, IN.uv_MainTex).a;
    o.Alpha = c.a;
    o.Specular = _Shininess;
    o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex));
}
ENDCG
}

Dependency "OptimizedShader" = "Hidden/UFoW/Nature/Tree Creator Bark Optimized"
FallBack "Diffuse"
}
