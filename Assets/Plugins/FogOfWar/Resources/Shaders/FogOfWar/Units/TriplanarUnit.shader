Shader "UltimateFogOfWar/Units/TriplanarUnit"
{
	Properties
	{
		_DiffuseMap("Diffuse Map ", 2D) = "white" {}
		_TextureScale("Texture Scale",float) = 1
		_TriplanarBlendSharpness("Blend Sharpness",float) = 1
	}
		SubShader
	{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Lambert
		#include "../FogOfWarMath.cginc"
		#pragma multi_compile __  VerticalMode
		#pragma multi_compile __ FoWColor FoWAnimatedFog

		sampler2D _DiffuseMap;
		float _TextureScale;
		float _TriplanarBlendSharpness;

		struct Input
		{
			float3 worldPos;
			float3 worldNormal;
		};

		void surf(Input IN, inout SurfaceOutput o)
		{
			//FOG OF WAR
			fixed4 FoW = FoWIntensity(IN.worldPos);

			half2 yUV = IN.worldPos.xz / _TextureScale;
			half2 xUV = IN.worldPos.zy / _TextureScale;
			half2 zUV = IN.worldPos.xy / _TextureScale;
			half3 yDiff = tex2D(_DiffuseMap, yUV);
			half3 xDiff = tex2D(_DiffuseMap, xUV);
			half3 zDiff = tex2D(_DiffuseMap, zUV);
			half3 blendWeights = pow(abs(IN.worldNormal), _TriplanarBlendSharpness);
			blendWeights = blendWeights / (blendWeights.x + blendWeights.y + blendWeights.z);
			o.Albedo = (xDiff * blendWeights.x + yDiff * blendWeights.y + zDiff * blendWeights.z) * FoW.rgb;
		}
	ENDCG
	}
			Fallback "Diffuse"
}