Shader "Hidden/UltimateFogOfWar/Debug/GUIDebug"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_ROpacity("R", Float) = 0
		_GOpacity("G", Float) = 0
		_BOpacity("B", Float) = 0
		_AOpacity("A", Float) = 0
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
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			fixed _ROpacity;
			fixed _GOpacity;
			fixed _BOpacity;
			fixed _AOpacity;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed tint = 
				col *= fixed4(_ROpacity * _AOpacity, _GOpacity, _BOpacity, 1);
				return col;
			}
			ENDCG
		}
	}
}
