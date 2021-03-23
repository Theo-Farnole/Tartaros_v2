// Upgrade NOTE: upgraded instancing buffer 'Props' to new syntax.

Shader "Environment Starter/Standard Intersection Mask" {
	Properties {
		[Header(Standard Shader Setup)]
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5

		_BumpScale("Scale", Float) = 1.0
        [NoScaleOffset]_BumpMap("Normal Map", 2D) = "bump" {}
 
		_Metallic ("Metallic", Range(0,1)) = 0.0

		[NoScaleOffset]_OcclusionMap("Occlusion", 2D) = "white" {}
		_OcclusionStrength("AO Strength", Range(0.0, 1.0)) = 1.0

		[HDR]_EmissionColor("Emission Color", Color) = (0,0,0,0)
		[NoScaleOffset]_EmissionMap("Emission", 2D) = "black" {}

		[Header(Intersection Settings)]
		_IntersectionThresholdMax("Intersection Threshold Max", Float) = 0.09 //Max difference for intersections
		_IntersectionPow("Intersection Power", Float) = 5.78
		_DepthFactor("Depth Factor", Float) = 0.06

		[Header(Intersection Maps)]
		_IntersectionColor("Intersection Color", Color) = (1,1,1,1)
		[NoScaleOffset]_IntersectionMap("Intersection Albedo(RGB), Blend (A)", 2D) = "black" {}
		[NoScaleOffset]_IntersectionBump("IntersectionNormal", 2D) = "bump" {}

		[Header(Mask Tweaks)]
		_IntersectionScale("Intersection Scale", Float) = 1.0
		_MaskMult("Mask Multiplier", Float) = 1
		_MaskPow("Mask Power", Float) = 1
		_YOffset("Y Offset", Float) = 0

		[Header(Vertex Modification)]
		_TargetNormal("Target Normal (XYZ), Strength (W)", Vector) = (0, 1, 0, 1)
		_InflateGround("Inflate Ground", Float) = 35

		[Header(Snow Settings)]
		[Toggle]_SnowMode ("Add Snow", float) = 1
		_SnowMult("Snow Mask Multiplier", Float) = 3
		_SnowPow("Snow Mask Power", Float) = -5

		[Header(Vertex Color Settings)]
		[Toggle]_RedAdd ("Red adds to Intersection", float) = 0
		[Toggle]_GreenSub ("Green subtracts from Intersection", float) = 0
		[Toggle]_BlueInflate ("Blue adds to Inflation", float) = 0
		[Toggle]_AlphaDeflate ("Alpha deflates", float) = 0

	}
	
	SubShader {
		Tags { "RenderType"="Opaque" "Queue"="Geometry" }
		LOD 200
		ZWrite On
		CGPROGRAM
		#pragma surface surf Standard vertex:vert addshadow
		#pragma target 3.0
		#pragma shader_feature _SNOWMODE_ON
		#pragma shader_feature _REDADD_ON
		#pragma shader_feature _GREENSUB_ON
		#pragma shader_feature _BLUEINFLATE_ON
		#pragma shader_feature _ALPHADEFLATE_ON

		sampler2D _MainTex, _ColorFlow, _BumpMap , _OcclusionMap, _EmissionMap, _IntersectionMap, _IntersectionBump;
		float4 _TargetNormal;

		struct Input {
			float2 uv_MainTex;
			float2 uv_IntersectionMap;
			float3 worldSpacePosition : TEXCOORD2;
			float4 color: COLOR;
			float3 worldNormal; INTERNAL_DATA
		};

		half _Glossiness, _BumpScale, _Metallic, _OcclusionStrength, _IntersectionThresholdMax, _IntersectionPow, _DepthFactor, _IntersectionScale, _MaskMult, _MaskPow, _SnowMult, _SnowPow;
		fixed4 _Color, _EmissionColor, _IntersectionColor;
		half _IntersectionThresholdMaxNormal, _IntersectionPowNormal, _DepthFactorNormal, _InflateGround, _YOffset;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void vert(inout appdata_full v, out Input o)
		{
			_IntersectionThresholdMax = abs(_IntersectionThresholdMax);
			_DepthFactor = abs(_DepthFactor);

			UNITY_INITIALIZE_OUTPUT(Input, o);
			//world space position
			o.worldSpacePosition = mul(unity_ObjectToWorld, v.vertex);

			float4 pos = UnityObjectToClipPos(v.vertex);

			float blendMask = saturate(pow(saturate(_DepthFactor * o.worldSpacePosition.y + _YOffset) / _IntersectionThresholdMax, _IntersectionPow));

			
			#ifdef _BLUEINFLATE_ON
				blendMask = blendMask - v.color.b;
			#endif

			#ifdef _ALPHADEFLATE_ON
				blendMask = blendMask + v.color.a;
			#endif

			blendMask = saturate(blendMask);

			float3 worldNormal = UnityObjectToWorldNormal(v.normal);

			v.normal = normalize(lerp(mul(unity_WorldToObject, float4(_TargetNormal.xyz, 1)).xyz, v.normal, saturate(blendMask + (1 - saturate(_TargetNormal.w)))));
			
			v.vertex = mul(unity_ObjectToWorld, v.vertex);

			v.vertex.xz += (_InflateGround / 100)* worldNormal.xz * (1 - blendMask);

			o.worldSpacePosition = v.vertex;

			v.vertex = mul(unity_WorldToObject, v.vertex);

		}

		void surf (Input IN, inout SurfaceOutputStandard o) {

			//intersecion mapping
			float2 intersectionUVs = IN.worldSpacePosition.xz * _IntersectionScale;
			fixed4 intersectionMap = tex2D(_IntersectionMap, intersectionUVs) * _IntersectionColor;
			fixed3 intersectionBump = UnpackNormal(tex2D(_IntersectionBump, intersectionUVs));
			_IntersectionThresholdMax = abs(_IntersectionThresholdMax);
			_DepthFactor = abs(_DepthFactor);

			//vertex color influence

			fixed vertColorInfluence = 0;

			//base texture composition
			fixed4 baseAlbedo = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			fixed3 baseNormal = lerp(half3(0, 0, 1), UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex)), _BumpScale);
			fixed baseOcclusion = lerp(1, tex2D(_OcclusionMap, IN.uv_MainTex).r, _OcclusionStrength);
			fixed3 baseEmission = tex2D(_EmissionMap, IN.uv_MainTex) * _EmissionColor;

			float diff = 1 - saturate(pow(saturate(_DepthFactor * IN.worldSpacePosition.y + _YOffset) / _IntersectionThresholdMax, _IntersectionPow));
			
			o.Normal = normalize(baseNormal);
			
			#ifdef _REDADD_ON
				vertColorInfluence += IN.color.r;
			#endif

			#ifdef _GREENSUB_ON
				vertColorInfluence -= IN.color.g;
			#endif
			diff = saturate(diff + vertColorInfluence);

			diff = saturate(diff + diff *(pow(intersectionMap.a * 2, 3) * 2.0 - 1.0));

			diff = saturate(pow(diff * _MaskMult, _MaskPow));

			//composite snow mask
			#ifdef _SNOWMODE_ON
				float3 worldNormal = normalize(WorldNormalVector(IN, o.Normal));
				float snowMask = 1 - saturate(pow(dot(worldNormal, normalize(_TargetNormal.xyz)) * _SnowMult, -abs(_SnowPow)));

				diff = saturate(diff + snowMask * worldNormal.g);
			#endif

			o.Albedo = lerp(baseAlbedo.rgb, intersectionMap.rgb, diff);
			o.Smoothness = lerp(_Glossiness, 0, diff);
			o.Metallic = _Metallic;
			o.Normal = normalize(lerp(baseNormal, intersectionBump, diff));
			o.Occlusion = lerp(baseOcclusion, 1, diff);
			o.Emission = lerp(baseEmission, 0, diff);
			o.Alpha =  baseAlbedo.a;
		}
		ENDCG
	}
	FallBack "Legacy Shaders/VertexLit"
}
