// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)
#define TERRAIN_INSTANCED_PERPIXEL_NORMAL


#ifndef TERRAIN_SPLATMAP_COMMON_CGINC_INCLUDED
#define TERRAIN_SPLATMAP_COMMON_CGINC_INCLUDED


//#define TERRAIN_INSTANCED_PERPIXEL_NORMAL
#define _NORMALMAP
#ifdef _NORMALMAP
#define _TERRAIN_NORMAL_MAP
#endif

#ifdef UNITY_PASS_SHADOWCASTER
#undef INTERNAL_DATA
#undef WorldReflectionVector
#undef WorldNormalVector
#define INTERNAL_DATA half3 internalSurfaceTtoW0; half3 internalSurfaceTtoW1; half3 internalSurfaceTtoW2;
#define WorldReflectionVector(data,normal) reflect (data.worldRefl, half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal)))
#define WorldNormalVector(data,normal) half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal))
#endif

struct Input
{
	float4 tc;
	float3 worldPos;
	half2 uv_texcoord;
	float3 worldNormal;
	float3 robNormal;
	INTERNAL_DATA
	UNITY_FOG_COORDS(1)


};

#if defined(UNITY_INSTANCING_ENABLED) && !defined(SHADER_API_D3D11_9X)
sampler2D _TerrainHeightmapTexture;
sampler2D _TerrainNormalmapTexture;
float4    _TerrainHeightmapRecipSize;   // float4(1.0f/width, 1.0f/height, 1.0f/(width-1), 1.0f/(height-1))
float4    _TerrainHeightmapScale;       // float4(hmScale.x, hmScale.y / (float)(kMaxHeight), hmScale.z, 0.0f)
#endif

UNITY_INSTANCING_BUFFER_START(Terrain)
UNITY_DEFINE_INSTANCED_PROP(float4, _TerrainPatchInstanceData) // float4(xBase, yBase, skipScale, ~)
UNITY_INSTANCING_BUFFER_END(Terrain)

#ifdef _NORMALMAP
sampler2D _Normal0, _Normal1, _Normal2, _Normal3;
float _NormalScale0, _NormalScale1, _NormalScale2, _NormalScale3;
#endif

#if defined(TERRAIN_BASE_PASS) && defined(UNITY_PASS_META)
// When we render albedo for GI baking, we actually need to take the ST
float4 _MainTex_ST;
#endif

void SplatmapVert(inout appdata_full v, out Input data)
{
	UNITY_INITIALIZE_OUTPUT(Input, data);

#if defined(UNITY_INSTANCING_ENABLED) && !defined(SHADER_API_D3D11_9X)

	float2 patchVertex = v.vertex.xy;
	float4 instanceData = UNITY_ACCESS_INSTANCED_PROP(Terrain, _TerrainPatchInstanceData);

	float4 uvscale = instanceData.z * _TerrainHeightmapRecipSize;
	float4 uvoffset = instanceData.xyxy * uvscale;
	uvoffset.xy += 0.5f * _TerrainHeightmapRecipSize.xy;
	float2 sampleCoords = (patchVertex.xy * uvscale.xy + uvoffset.xy);

	float hm = UnpackHeightmap(tex2Dlod(_TerrainHeightmapTexture, float4(sampleCoords, 0, 0)));
	v.vertex.xz = (patchVertex.xy + instanceData.xy) * _TerrainHeightmapScale.xz * instanceData.z;  //(x + xBase) * hmScale.x * skipScale;
	v.vertex.y = hm * _TerrainHeightmapScale.y;
	v.vertex.w = 1.0f;

	v.texcoord.xy = (patchVertex.xy * uvscale.zw + uvoffset.zw);
	v.texcoord3 = v.texcoord2 = v.texcoord1 = v.texcoord;

#ifdef TERRAIN_INSTANCED_PERPIXEL_NORMAL
	v.normal = float3(0, 1, 0); // TODO: reconstruct the tangent space in the pixel shader. Seems to be hard with surface shader especially when other attributes are packed together with tSpace.
 
	data.tc.zw = sampleCoords;
#else
	float3 nor = tex2Dlod(_TerrainNormalmapTexture, float4(sampleCoords, 0, 0)).xyz;
	v.normal = 2.0f * nor - 1.0f;
#endif

#endif

	v.tangent.xyz = cross(v.normal, float3(0, 0, 1));
	v.tangent.w = -1;

	data.tc.xy = v.texcoord;
#ifdef TERRAIN_BASE_PASS
#ifdef UNITY_PASS_META
	data.tc.xy = v.texcoord * _MainTex_ST.xy + _MainTex_ST.zw;
#endif
#else
	float4 pos = UnityObjectToClipPos(v.vertex);
	UNITY_TRANSFER_FOG(data, pos);
#endif
}


void MixedNormal(inout float3 normalIN, float2 sampleCoords)
{
#if defined(UNITY_INSTANCING_ENABLED) && defined(TERRAIN_INSTANCED_PERPIXEL_NORMAL)
	fixed3 mixedNormal = normalIN;

	float3 geomNormal = normalize(tex2D(_TerrainNormalmapTexture, sampleCoords).xyz * 2 - 1);
	float3 geomTangent = normalize(cross(geomNormal, float3(0, 0, 1)));
	float3 geomBitangent = normalize(cross(geomTangent, geomNormal));

	mixedNormal = mixedNormal.x * geomTangent
		+ mixedNormal.y * geomBitangent
		+ mixedNormal.z * geomNormal;


	mixedNormal = mixedNormal.xzy;

	normalIN = mixedNormal;
#endif
}

void NormalForWorld(inout float3 normalIN, float2 sampleCoords)
{
#if defined(UNITY_INSTANCING_ENABLED) && defined(TERRAIN_INSTANCED_PERPIXEL_NORMAL)
	normalIN = normalize(tex2D(_TerrainNormalmapTexture, sampleCoords).xyz * 2 - 1);
#endif

}


#endif // TERRAIN_SPLATMAP_COMMON_CGINC_INCLUDED



//fixed3 mixedNormal = temp_output_4100_0;
//#if defined(UNITY_INSTANCING_ENABLED) && !defined(SHADER_API_D3D11_9X) && defined(TERRAIN_INSTANCED_PERPIXEL_NORMAL)
//float3 geomNormal = normalize(tex2D(_TerrainNormalmapTexture, i.tc.zw).xyz * 2 - 1);
//#ifdef _NORMALMAP
//float3 geomTangent = normalize(cross(geomNormal, float3(0, 0, 1)));
//float3 geomBitangent = normalize(cross(geomTangent, geomNormal));
//mixedNormal = mixedNormal.x * geomTangent
//+ mixedNormal.y * geomBitangent
//+ mixedNormal.z * geomNormal;
//#else
//mixedNormal = geomNormal;
//#endif
//mixedNormal = mixedNormal.xzy;
//#endif
//o.Normal = mixedNormal;