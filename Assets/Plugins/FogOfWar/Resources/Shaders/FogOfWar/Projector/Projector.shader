// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "UltimateFogOfWar/Projectors/Projector"
{
	Properties
	{
		
	}
	SubShader
	{
		ZWrite Off
		ColorMask RGB
		Blend DstColor Zero
		Offset -1, -1
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			sampler2D _FogOfWar;

			struct v2f {
				float4 uvShadow : TEXCOORD0;
				float4 uvFalloff : TEXCOORD1;
				UNITY_FOG_COORDS(2)
				float4 pos : SV_POSITION;
			};

			float4x4 unity_Projector;
			float4x4 unity_ProjectorClip;

			v2f vert(float4 vertex : POSITION)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(vertex);
				o.uvShadow = mul(unity_Projector, vertex);
				o.uvFalloff = mul(unity_ProjectorClip, vertex);
				UNITY_TRANSFER_FOG(o, o.pos);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 texS = tex2Dproj(_FogOfWar, UNITY_PROJ_COORD(i.uvShadow));
				fixed4 Fog = fixed4(texS.g, texS.g, texS.g, 1);
				return Fog;
			}
			ENDCG
		}
	}
}
