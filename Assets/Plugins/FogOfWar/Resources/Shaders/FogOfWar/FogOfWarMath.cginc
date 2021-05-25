float Remap(float value, float From1, float To1, float From2, float To2)
{
	return From2 + (value - From1) * (To2 - From2) / (To1 - From1);
}

sampler2D FogOfWar;
float LevelWidth;
float LevelHeight;
float Scale;
float4 Origin;

#if FoWColor
	fixed4 FogColor;
#endif

#if FoWAnimatedFog
	fixed4 FogColor;
	sampler2D FogNoise;
	fixed FogSpeed = 3;
	fixed FogTiling = 2;
	fixed FogIntensity = 1;

fixed AnimatedFog(float2 UV)
{
	UV *= FogTiling;
	fixed Color1 = tex2D(FogNoise, UV + _Time.x * float2(0.37327, -0.06882) * FogSpeed).r;
	fixed Color2 = tex2D(FogNoise, UV + _Time.x * float2(-0.69969, 0.20644) * FogSpeed).g;
	fixed Color3 = tex2D(FogNoise, UV + _Time.x * float2(-0.56252, -0.02358) * FogSpeed).b;
	fixed Color4 = tex2D(FogNoise, UV + _Time.x * float2(0.39665, 0.33471) * FogSpeed).a;
	fixed result = (Color1 * Color2 * Color3 * Color4) * FogIntensity;
	return result;
}
#endif

fixed4 FoWIntensity(float3 WorldPos)
{
	#if VerticalMode
		float2 UV = float2(Remap(WorldPos.x, Origin.x, Origin.x + LevelWidth * Scale, 0, 1), Remap(WorldPos.y, Origin.y, Origin.y + LevelHeight * Scale, 0, 1));
	#else
		float2 UV = float2(Remap(WorldPos.x, Origin.x, Origin.x + LevelWidth * Scale, 0, 1), Remap(WorldPos.z, Origin.z, Origin.z + LevelHeight * Scale, 0, 1));
	#endif

	fixed4 Fog = tex2D(FogOfWar, UV);

	#if FoWColor
		fixed4 FinalColor = lerp(FogColor, fixed4(1,1,1,1), Fog.g);
		FinalColor.a = Fog.g;
		return FinalColor;
	#endif

	#if FoWAnimatedFog
		fixed4 FinalColor = lerp(FogColor, fixed4(1,1,1,1), clamp(Fog.g + AnimatedFog(UV),0,1));
		FinalColor.a = Fog.g;
		return FinalColor;
	#endif

	Fog.rgba = Fog.g;
	return Fog;
}
