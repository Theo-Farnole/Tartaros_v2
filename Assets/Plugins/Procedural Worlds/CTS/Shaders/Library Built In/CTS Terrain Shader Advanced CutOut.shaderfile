Shader "CTS/CTS Terrain Shader Advanced CutOut"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_Geological_Tiling_Close("Geological_Tiling_Close", Range( 0 , 1000)) = 87
		_Geological_Tiling_Far("Geological_Tiling_Far", Range( 0 , 1000)) = 87
		_Geological_Map_Offset_Far("Geological_Map_Offset _Far", Range( 0 , 1)) = 1
		_Texture_Glitter("Texture_Glitter", 2D) = "black" {}
		_Global_Color_Map_Far_Power("Global_Color_Map_Far_Power", Range( 0 , 10)) = 5
		_Geological_Map_Offset_Close("Geological_Map_Offset _Close", Range( 0 , 1)) = 1
		_Global_Color_Opacity_Power("Global_Color_Opacity_Power", Range( 0 , 1)) = 0
		_Gliter_Color_Power("Gliter_Color_Power", Range( 0 , 2)) = 0.8
		_Global_Color_Map_Close_Power("Global_Color_Map_Close_Power", Range( 0 , 10)) = 0.1
		_Geological_Map_Close_Power("Geological_Map_Close_Power", Range( 0 , 2)) = 0
		_Glitter_Noise_Threshold("Glitter_Noise_Threshold", Range( 0 , 1)) = 0.991
		_Geological_Map_Far_Power("Geological_Map_Far_Power", Range( 0 , 2)) = 1
		_UV_Mix_Power("UV_Mix_Power", Range( 0.01 , 10)) = 4
		_Glitter_Specular("Glitter_Specular", Range( 0 , 3)) = 0.2
		_UV_Mix_Start_Distance("UV_Mix_Start_Distance", Range( 0 , 100000)) = 400
		_Perlin_Normal_Tiling_Close("Perlin_Normal_Tiling_Close", Range( 0.01 , 1000)) = 40
		_Glitter_Smoothness("Glitter_Smoothness", Range( 0 , 1)) = 0.9
		_Perlin_Normal_Tiling_Far("Perlin_Normal_Tiling_Far", Range( 0.01 , 1000)) = 40
		_Perlin_Normal_Power("Perlin_Normal_Power", Range( 0 , 2)) = 1
		_Perlin_Normal_Power_Close("Perlin_Normal_Power_Close", Range( 0 , 1)) = 0.5
		_Terrain_Smoothness("Terrain_Smoothness", Range( 0 , 2)) = 1
		_Terrain_Specular("Terrain_Specular", Range( 0 , 3)) = 1
		_Texture_4_AO_Power("Texture_4_AO_Power", Range( 0 , 1)) = 1
		_Texture_15_AO_Power("Texture_15_AO_Power", Range( 0 , 1)) = 1
		_Texture_3_AO_Power("Texture_3_AO_Power", Range( 0 , 1)) = 1
		_Texture_8_AO_Power("Texture_8_AO_Power", Range( 0 , 1)) = 1
		_Texture_6_AO_Power("Texture_6_AO_Power", Range( 0 , 1)) = 1
		_Texture_16_AO_Power("Texture_16_AO_Power", Range( 0 , 1)) = 1
		_Texture_7_AO_Power("Texture_7_AO_Power", Range( 0 , 1)) = 1
		_Texture_5_AO_Power("Texture_5_AO_Power", Range( 0 , 1)) = 1
		_Texture_12_AO_Power("Texture_12_AO_Power", Range( 0 , 1)) = 1
		_Texture_1_AO_Power("Texture_1_AO_Power", Range( 0 , 1)) = 1
		_Texture_11_AO_Power("Texture_11_AO_Power", Range( 0 , 1)) = 1
		_Texture_10_AO_Power("Texture_10_AO_Power", Range( 0 , 1)) = 1
		_Texture_13_AO_Power("Texture_13_AO_Power", Range( 0 , 1)) = 1
		_Texture_14_AO_Power("Texture_14_AO_Power", Range( 0 , 1)) = 1
		_Texture_2_AO_Power("Texture_2_AO_Power", Range( 0 , 1)) = 1
		_Texture_9_AO_Power("Texture_9_AO_Power", Range( 0 , 1)) = 1
		_Global_Normalmap_Power("Global_Normalmap_Power", Range( 0 , 10)) = 0
		_Texture_1_Tiling("Texture_1_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_2_Tiling("Texture_2_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_3_Tiling("Texture_3_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_4_Tiling("Texture_4_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_5_Tiling("Texture_5_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_6_Tiling("Texture_6_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_7_Tiling("Texture_7_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_8_Tiling("Texture_8_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_9_Tiling("Texture_9_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_10_Tiling("Texture_10_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_11_Tiling("Texture_11_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_12_Tiling("Texture_12_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_13_Tiling("Texture_13_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_14_Tiling("Texture_14_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_15_Tiling("Texture_15_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_16_Tiling("Texture_16_Tiling", Range( 0.0001 , 100)) = 15
		_Texture_1_Far_Multiplier("Texture_1_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_2_Far_Multiplier("Texture_2_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_3_Far_Multiplier("Texture_3_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_4_Far_Multiplier("Texture_4_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_5_Far_Multiplier("Texture_5_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_6_Far_Multiplier("Texture_6_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_7_Far_Multiplier("Texture_7_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_8_Far_Multiplier("Texture_8_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_9_Far_Multiplier("Texture_9_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_10_Far_Multiplier("Texture_10_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_11_Far_Multiplier("Texture_11_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_12_Far_Multiplier("Texture_12_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_13_Far_Multiplier("Texture_13_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_Array_Normal("Texture_Array_Normal", 2DArray ) = "" {}
		_Texture_14_Far_Multiplier("Texture_14_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_15_Far_Multiplier("Texture_15_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_16_Far_Multiplier("Texture_16_Far_Multiplier", Range( 0 , 10)) = 3
		_Texture_1_Perlin_Power("Texture_1_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_2_Perlin_Power("Texture_2_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_3_Perlin_Power("Texture_3_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_4_Perlin_Power("Texture_4_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_5_Perlin_Power("Texture_5_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_6_Perlin_Power("Texture_6_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_7_Perlin_Power("Texture_7_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_8_Perlin_Power("Texture_8_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_9_Perlin_Power("Texture_9_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_10_Perlin_Power("Texture_10_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_11_Perlin_Power("Texture_11_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_12_Perlin_Power("Texture_12_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_13_Perlin_Power("Texture_13_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_14_Perlin_Power("Texture_14_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_15_Perlin_Power("Texture_15_Perlin_Power", Range( 0 , 2)) = 0
		_Texture_16_Perlin_Power("Texture_16_Perlin_Power", Range( 0 , 2)) = 0
		_Snow_Heightmap_Depth("Snow_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_1_Heightmap_Depth("Texture_1_Heightmap_Depth", Range( 0 , 10)) = 1
		_Snow_Height_Contrast("Snow_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_14_Height_Contrast("Texture_14_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_16_Height_Contrast("Texture_16_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_15_Height_Contrast("Texture_15_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_9_Height_Contrast("Texture_9_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_13_Height_Contrast("Texture_13_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_10_Height_Contrast("Texture_10_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_11_Height_Contrast("Texture_11_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_12_Height_Contrast("Texture_12_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_6_Height_Contrast("Texture_6_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_8_Height_Contrast("Texture_8_Height_Contrast", Range( 0 , 10)) = 1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		_Texture_7_Height_Contrast("Texture_7_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_3_Height_Contrast("Texture_3_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_5_Height_Contrast("Texture_5_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_4_Height_Contrast("Texture_4_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_1_Height_Contrast("Texture_1_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_2_Height_Contrast("Texture_2_Height_Contrast", Range( 0 , 10)) = 1
		_Texture_2_Heightmap_Depth("Texture_2_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_3_Heightmap_Depth("Texture_3_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_4_Heightmap_Depth("Texture_4_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_5_Heightmap_Depth("Texture_5_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_6_Heightmap_Depth("Texture_6_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_7_Heightmap_Depth("Texture_7_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_8_Tesselation_Depth("Texture_8_Tesselation_Depth", Range( 0 , 10)) = 1
		_Texture_9_Heightmap_Depth("Texture_9_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_10_Heightmap_Depth("Texture_10_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_11_Heightmap_Depth("Texture_11_Heightmap_Depth", Range( 0 , 10)) = 0
		_Texture_12_Heightmap_Depth("Texture_12_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_13_Heightmap_Depth("Texture_13_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_14_Heightmap_Depth("Texture_14_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_15_Heightmap_Depth("Texture_15_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_16_Heightmap_Depth("Texture_16_Heightmap_Depth", Range( 0 , 10)) = 1
		_Texture_3_Heightblend_Far("Texture_3_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_1_Heightblend_Far("Texture_1_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_4_Heightblend_Far("Texture_4_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_9_Heightblend_Far("Texture_9_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_15_Heightblend_Far("Texture_15_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_16_Heightblend_Far("Texture_16_Heightblend_Far", Range( 1 , 10)) = 5
		_Snow_Heightblend_Far("Snow_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_14_Heightblend_Far("Texture_14_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_13_Heightblend_Far("Texture_13_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_12_Heightblend_Far("Texture_12_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_16_Heightblend_Close("Texture_16_Heightblend_Close", Range( 1 , 10)) = 5
		_Texture_15_Heightblend_Close("Texture_15_Heightblend_Close", Range( 1 , 10)) = 5
		_Texture_11_Heightblend_Far("Texture_11_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_13_Heightblend_Close("Texture_13_Heightblend_Close", Range( 1 , 10)) = 5
		_Snow_Heightblend_Close("Snow_Heightblend_Close", Range( 1 , 10)) = 5
		_Texture_14_Heightblend_Close("Texture_14_Heightblend_Close", Range( 1 , 10)) = 5
		_Texture_12_Heightblend_Close("Texture_12_Heightblend_Close", Range( 1 , 10)) = 5
		_Texture_10_Heightblend_Far("Texture_10_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_11_Heightblend_Close("Texture_11_Heightblend_Close", Range( 1 , 10)) = 5
		_Texture_8_Heightblend_Far("Texture_8_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_10_Heightblend_Close("Texture_10_Heightblend_Close", Range( 1 , 10)) = 5
		_Texture_2_Heightblend_Far("Texture_2_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_9_Heightblend_Close("Texture_9_Heightblend_Close", Range( 1 , 10)) = 5
		_Texture_7_Heightblend_Far("Texture_7_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_8_Heightblend_Close("Texture_8_Heightblend_Close", Range( 1 , 10)) = 5
		_Texture_7_Heightblend_Close("Texture_7_Heightblend_Close", Range( 1 , 10)) = 5
		_Texture_6_Heightblend_Far("Texture_6_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_5_Heightblend_Far("Texture_5_Heightblend_Far", Range( 1 , 10)) = 5
		_Texture_Snow_Average("Texture_Snow_Average", Vector) = (0,0,0,0)
		_Texture_6_Heightblend_Close("Texture_6_Heightblend_Close", Range( 1 , 10)) = 5
		_Texture_3_Heightblend_Close("Texture_3_Heightblend_Close", Range( 1 , 10)) = 5
		_Texture_5_Heightblend_Close("Texture_5_Heightblend_Close", Range( 1 , 10)) = 5
		_Remove_Vert_Height("Remove_Vert_Height", Range( -10000 , 10000)) = -1000
		_Texture_2_Heightblend_Close("Texture_2_Heightblend_Close", Range( 1 , 10)) = 5
		_Texture_1_Heightblend_Close("Texture_1_Heightblend_Close", Range( 1 , 10)) = 5
		_Texture_4_Heightblend_Close("Texture_4_Heightblend_Close", Range( 1 , 10)) = 5
		_Texture_1_Geological_Power("Texture_1_Geological_Power", Range( 0 , 2)) = 1
		_Texture_2_Geological_Power("Texture_2_Geological_Power", Range( 0 , 2)) = 1
		_Texture_3_Geological_Power("Texture_3_Geological_Power", Range( 0 , 2)) = 1
		_Texture_4_Geological_Power("Texture_4_Geological_Power", Range( 0 , 2)) = 1
		_Texture_5_Geological_Power("Texture_5_Geological_Power", Range( 0 , 2)) = 1
		_Texture_6_Geological_Power("Texture_6_Geological_Power", Range( 0 , 2)) = 1
		_Texture_7_Geological_Power("Texture_7_Geological_Power", Range( 0 , 2)) = 1
		_Texture_8_Geological_Power("Texture_8_Geological_Power", Range( 0 , 2)) = 1
		_Texture_9_Geological_Power("Texture_9_Geological_Power", Range( 0 , 2)) = 1
		_Texture_10_Geological_Power("Texture_10_Geological_Power", Range( 0 , 2)) = 1
		_Texture_11_Geological_Power("Texture_11_Geological_Power", Range( 0 , 2)) = 1
		_Texture_12_Geological_Power("Texture_12_Geological_Power", Range( 0 , 2)) = 1
		_Texture_13_Geological_Power("Texture_13_Geological_Power", Range( 0 , 2)) = 1
		_Texture_14_Geological_Power("Texture_14_Geological_Power", Range( 0 , 2)) = 1
		_Texture_15_Geological_Power("Texture_15_Geological_Power", Range( 0 , 2)) = 1
		_Texture_16_Geological_Power("Texture_16_Geological_Power", Range( 0 , 2)) = 1
		_Snow_Specular("Snow_Specular", Range( 0 , 3)) = 1
		_Snow_Normal_Scale("Snow_Normal_Scale", Range( 0 , 5)) = 1
		_Snow_Blend_Normal("Snow_Blend_Normal", Range( 0 , 1)) = 0.8
		_Snow_Amount("Snow_Amount", Range( 0 , 2)) = 0
		_Snow_Tiling("Snow_Tiling", Range( 0.001 , 20)) = 15
		_Snow_Tiling_Far_Multiplier("Snow_Tiling_Far_Multiplier", Range( 0.001 , 20)) = 1
		_Snow_Perlin_Power("Snow_Perlin_Power", Range( 0 , 2)) = 0
		_Snow_Noise_Power("Snow_Noise_Power", Range( 0 , 1)) = 1
		_Snow_Noise_Tiling("Snow_Noise_Tiling", Range( 0.001 , 1)) = 0.02
		_Snow_Min_Height("Snow_Min_Height", Range( -1000 , 10000)) = -1000
		_Snow_Min_Height_Blending("Snow_Min_Height_Blending", Range( 0 , 500)) = 1
		_Snow_Maximum_Angle("Snow_Maximum_Angle", Range( 0.001 , 180)) = 30
		_Snow_Maximum_Angle_Hardness("Snow_Maximum_Angle_Hardness", Range( 0.001 , 10)) = 1
		_Texture_1_Snow_Reduction("Texture_1_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_2_Snow_Reduction("Texture_2_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_3_Snow_Reduction("Texture_3_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_4_Snow_Reduction("Texture_4_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_5_Snow_Reduction("Texture_5_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_6_Snow_Reduction("Texture_6_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_7_Snow_Reduction("Texture_7_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_8_Snow_Reduction("Texture_8_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_Array_Albedo("Texture_Array_Albedo", 2DArray ) = "" {}
		_Texture_9_Snow_Reduction("Texture_9_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_10_Snow_Reduction("Texture_10_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_11_Snow_Reduction("Texture_11_Snow_Reduction", Range( 0 , 1)) = 0
		_Snow_Color("Snow_Color", Vector) = (1,1,1,1)
		_Texture_12_Snow_Reduction("Texture_12_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_13_Snow_Reduction("Texture_13_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_14_Snow_Reduction("Texture_14_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_15_Snow_Reduction("Texture_15_Snow_Reduction", Range( 0 , 1)) = 0
		_Texture_16_Snow_Reduction("Texture_16_Snow_Reduction", Range( 0 , 1)) = 0
		_Snow_Ambient_Occlusion_Power("Snow_Ambient_Occlusion_Power", Range( 0 , 1)) = 1
		_Ambient_Occlusion_Power("Ambient_Occlusion_Power", Range( 0 , 1)) = 1
		[Toggle(_USE_AO_ON)] _Use_AO("Use_AO", Float) = 0
		_Texture_2_Triplanar("Texture_2_Triplanar", Range( 0 , 1)) = 0
		_Texture_16_Triplanar("Texture_16_Triplanar", Range( 0 , 1)) = 0
		_Texture_15_Triplanar("Texture_15_Triplanar", Range( 0 , 1)) = 0
		_Texture_10_Color("Texture_10_Color", Vector) = (1,1,1,1)
		_Texture_9_Color("Texture_9_Color", Vector) = (1,1,1,1)
		_Texture_12_Color("Texture_12_Color", Vector) = (1,1,1,1)
		_Texture_11_Color("Texture_11_Color", Vector) = (1,1,1,1)
		_Texture_13_Color("Texture_13_Color", Vector) = (1,1,1,1)
		_Texture_14_Color("Texture_14_Color", Vector) = (1,1,1,1)
		_Global_Color_Map("Global_Color_Map", 2D) = "white" {}
		_TerrainHolesTexture("Holes Map (RGB)", 2D) = "white" {}
		_Texture_16_Color("Texture_16_Color", Vector) = (1,1,1,1)
		_Texture_15_Color("Texture_15_Color", Vector) = (1,1,1,1)
		_Texture_8_Color("Texture_8_Color", Vector) = (1,1,1,1)
		_Texture_7_Color("Texture_7_Color", Vector) = (1,1,1,1)
		_Texture_4_Color("Texture_4_Color", Vector) = (1,1,1,1)
		_Texture_6_Color("Texture_6_Color", Vector) = (1,1,1,1)
		_Texture_5_Color("Texture_5_Color", Vector) = (1,1,1,1)
		_Texture_3_Color("Texture_3_Color", Vector) = (1,1,1,1)
		_Texture_1_Color("Texture_1_Color", Vector) = (1,1,1,1)
		_Texture_2_Color("Texture_2_Color", Vector) = (1,1,1,1)
		_Texture_12_Triplanar("Texture_12_Triplanar", Range( 0 , 1)) = 0
		_Texture_14_Triplanar("Texture_14_Triplanar", Range( 0 , 1)) = 0
		_Texture_13_Triplanar("Texture_13_Triplanar", Range( 0 , 1)) = 0
		_Texture_11_Triplanar("Texture_11_Triplanar", Range( 0 , 1)) = 0
		_Texture_9_Triplanar("Texture_9_Triplanar", Range( 0 , 1)) = 0
		_Texture_10_Triplanar("Texture_10_Triplanar", Range( 0 , 1)) = 0
		_Texture_8_Triplanar("Texture_8_Triplanar", Range( 0 , 1)) = 0
		[Toggle(_USE_AO_TEXTURE_ON)] _Use_AO_Texture("Use_AO_Texture", Float) = 0
		_Texture_7_Triplanar("Texture_7_Triplanar", Range( 0 , 1)) = 0
		_Texture_6_Triplanar("Texture_6_Triplanar", Range( 0 , 1)) = 0
		_Texture_Geological_Map("Texture_Geological_Map", 2D) = "white" {}
		_Texture_5_Triplanar("Texture_5_Triplanar", Range( 0 , 1)) = 0
		_Texture_4_Triplanar("Texture_4_Triplanar", Range( 0 , 1)) = 0
		_Texture_3_Triplanar("Texture_3_Triplanar", Range( 0 , 1)) = 0
		_Texture_1_Triplanar("Texture_1_Triplanar", Range( 0 , 1)) = 0
		_Texture_1_Albedo_Index("Texture_1_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_2_Albedo_Index("Texture_2_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_3_Normal_Index("Texture_3_Normal_Index", Range( -1 , 100)) = -1
		_Texture_1_H_AO_Index("Texture_1_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_5_Normal_Index("Texture_5_Normal_Index", Range( -1 , 100)) = -1
		_Texture_6_Albedo_Index("Texture_6_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_6_H_AO_Index("Texture_6_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_8_Albedo_Index("Texture_8_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_16_H_AO_Index("Texture_16_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_16_Albedo_Index("Texture_16_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_14_Normal_Index("Texture_14_Normal_Index", Range( -1 , 100)) = -1
		_Texture_13_Albedo_Index("Texture_13_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_12_Albedo_Index("Texture_12_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_11_H_AO_Index("Texture_11_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_10_Albedo_Index("Texture_10_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_9_Albedo_Index("Texture_9_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_9_Normal_Index("Texture_9_Normal_Index", Range( -1 , 100)) = -1
		_Texture_11_Albedo_Index("Texture_11_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_9_H_AO_Index("Texture_9_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_10_Normal_Index("Texture_10_Normal_Index", Range( -1 , 100)) = -1
		_Texture_10_H_AO_Index("Texture_10_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_11_Normal_Index("Texture_11_Normal_Index", Range( -1 , 100)) = -1
		_Texture_13_Normal_Index("Texture_13_Normal_Index", Range( -1 , 100)) = -1
		_Texture_12_Normal_Index("Texture_12_Normal_Index", Range( -1 , 100)) = -1
		_Texture_12_H_AO_Index("Texture_12_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_13_H_AO_Index("Texture_13_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_14_Albedo_Index("Texture_14_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_14_H_AO_Index("Texture_14_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_15_Albedo_Index("Texture_15_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_15_Normal_Index("Texture_15_Normal_Index", Range( -1 , 100)) = -1
		_Texture_15_H_AO_Index("Texture_15_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_16_Normal_Index("Texture_16_Normal_Index", Range( -1 , 100)) = -1
		_Texture_7_Normal_Index("Texture_7_Normal_Index", Range( -1 , 100)) = -1
		_Texture_8_H_AO_Index("Texture_8_H_AO_Index", Range( -1 , 100)) = 31.57005
		_Texture_8_Normal_Index("Texture_8_Normal_Index", Range( -1 , 100)) = -1
		_Texture_7_H_AO_Index("Texture_7_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_7_Albedo_Index("Texture_7_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_6_Normal_Index("Texture_6_Normal_Index", Range( -1 , 100)) = -1
		_Texture_5_H_AO_Index("Texture_5_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_4_H_AO_Index("Texture_4_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_4_Normal_Index("Texture_4_Normal_Index", Range( -1 , 100)) = -1
		_Texture_5_Albedo_Index("Texture_5_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_4_Albedo_Index("Texture_4_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_3_H_AO_Index("Texture_3_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_3_Albedo_Index("Texture_3_Albedo_Index", Range( -1 , 100)) = -1
		_Texture_2_H_AO_Index("Texture_2_H_AO_Index", Range( -1 , 100)) = -1
		_Texture_2_Normal_Index("Texture_2_Normal_Index", Range( -1 , 100)) = -1
		_Texture_1_Normal_Index("Texture_1_Normal_Index", Range( -1 , 100)) = -1
		_Texture_1_Normal_Power("Texture_1_Normal_Power", Range( 0 , 2)) = 1
		_Texture_2_Normal_Power("Texture_2_Normal_Power", Range( 0 , 2)) = 1
		_Texture_3_Normal_Power("Texture_3_Normal_Power", Range( 0 , 2)) = 1
		_Texture_4_Normal_Power("Texture_4_Normal_Power", Range( 0 , 2)) = 1
		_Texture_5_Normal_Power("Texture_5_Normal_Power", Range( 0 , 2)) = 1
		_Texture_6_Normal_Power("Texture_6_Normal_Power", Range( 0 , 2)) = 1
		_Texture_7_Normal_Power("Texture_7_Normal_Power", Range( 0 , 2)) = 1
		_Texture_8_Normal_Power("Texture_8_Normal_Power", Range( 0 , 2)) = 1
		_Texture_9_Normal_Power("Texture_9_Normal_Power", Range( 0 , 2)) = 1
		_Texture_10_Normal_Power("Texture_10_Normal_Power", Range( 0 , 2)) = 1
		_Texture_11_Normal_Power("Texture_11_Normal_Power", Range( 0 , 2)) = 1
		_Texture_12_Normal_Power("Texture_12_Normal_Power", Range( 0 , 2)) = 1
		_Texture_13_Normal_Power("Texture_13_Normal_Power", Range( 0 , 2)) = 1
		_Texture_14_Normal_Power("Texture_14_Normal_Power", Range( 0 , 2)) = 1
		_Texture_15_Normal_Power("Texture_15_Normal_Power", Range( 0 , 2)) = 1
		_Texture_16_Normal_Power("Texture_16_Normal_Power", Range( 0 , 2)) = 1
		_Texture_Splat_1("Texture_Splat_1", 2D) = "black" {}
		_Texture_Splat_2("Texture_Splat_2", 2D) = "black" {}
		_Texture_Splat_3("Texture_Splat_3", 2D) = "black" {}
		_Texture_Splat_4("Texture_Splat_4", 2D) = "black" {}
		_Global_Normal_Map("Global_Normal_Map", 2D) = "bump" {}
		_Texture_Snow_Normal_Index("Texture_Snow_Normal_Index", Range( -1 , 100)) = -1
		_Texture_Snow_Index("Texture_Snow_Index", Range( -1 , 100)) = -1
		_Texture_Snow_H_AO_Index("Texture_Snow_H_AO_Index", Range( -1 , 100)) = -1
		_Global_Color_Map_Scale("Global_Color_Map_Scale", Float) = 1
		_Global_Color_Map_Offset("Global_Color_Map_Offset", Vector) = (0,0,0,0)
		_Texture_Perlin_Normal_Index("Texture_Perlin_Normal_Index", Range( -1 , 100)) = -1
		_Glitter_Refreshing_Speed("Glitter_Refreshing_Speed", Range( 0 , 7)) = 4
		_Glitter_Tiling("Glitter_Tiling", Range( 0 , 100)) = 3
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "Geometry-100" }
		Cull Back
		ZTest LEqual
		CGINCLUDE
		#include "UnityStandardUtils.cginc"
		#include "UnityShaderVariables.cginc"
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 3.5
		#pragma multi_compile __ _USE_AO_ON
		#pragma multi_compile __ _USE_AO_TEXTURE_ON
		#pragma instancing_options assumeuniformscaling nomatrices nolightprobe nolightmap forwardadd  
		#include "TerrainSplatmapCommonCTS.cginc"
		#pragma multi_compile_instancing
		#ifdef UNITY_PASS_SHADOWCASTER
			#undef INTERNAL_DATA
			#undef WorldReflectionVector
			#undef WorldNormalVector
			#define INTERNAL_DATA half3 internalSurfaceTtoW0; half3 internalSurfaceTtoW1; half3 internalSurfaceTtoW2;
			#define WorldReflectionVector(data,normal) reflect (data.worldRefl, half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal)))
			#define WorldNormalVector(data,normal) half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal))
		#endif

		uniform UNITY_DECLARE_TEX2DARRAY( _Texture_Array_Normal );
		uniform half _Perlin_Normal_Tiling_Close;
		uniform half _Texture_Perlin_Normal_Index;
		uniform half _Perlin_Normal_Power_Close;
		uniform half _Perlin_Normal_Tiling_Far;
		uniform half _Perlin_Normal_Power;
		uniform half _UV_Mix_Start_Distance;
		uniform half _UV_Mix_Power;
		uniform half _Texture_16_Perlin_Power;
		uniform sampler2D _Texture_Splat_4;
		uniform half _Texture_15_Perlin_Power;
		uniform half _Texture_14_Perlin_Power;
		uniform half _Texture_13_Perlin_Power;
		uniform half _Texture_12_Perlin_Power;
		uniform sampler2D _Texture_Splat_3;
		uniform half _Texture_11_Perlin_Power;
		uniform half _Texture_10_Perlin_Power;
		uniform half _Texture_9_Perlin_Power;
		uniform half _Texture_8_Perlin_Power;
		uniform sampler2D _Texture_Splat_2;
		uniform half _Texture_7_Perlin_Power;
		uniform half _Texture_6_Perlin_Power;
		uniform half _Texture_5_Perlin_Power;
		uniform half _Texture_1_Perlin_Power;
		uniform sampler2D _Texture_Splat_1;
		uniform half _Texture_2_Perlin_Power;
		uniform half _Texture_4_Perlin_Power;
		uniform half _Texture_3_Perlin_Power;
		uniform half _Snow_Perlin_Power;
		uniform half _Texture_1_H_AO_Index;
		uniform half _Texture_1_Triplanar;
		uniform UNITY_DECLARE_TEX2DARRAY( _Texture_Array_Albedo );
		uniform half _Texture_1_Tiling;
		uniform half _Texture_1_Far_Multiplier;
		uniform half _Texture_1_Height_Contrast;
		uniform half _Texture_1_Heightmap_Depth;
		uniform half _Texture_2_Heightmap_Depth;
		uniform half _Texture_2_H_AO_Index;
		uniform half _Texture_2_Triplanar;
		uniform half _Texture_2_Tiling;
		uniform half _Texture_2_Far_Multiplier;
		uniform half _Texture_2_Height_Contrast;
		uniform half _Texture_3_Heightmap_Depth;
		uniform half _Texture_3_H_AO_Index;
		uniform half _Texture_3_Triplanar;
		uniform half _Texture_3_Tiling;
		uniform half _Texture_3_Far_Multiplier;
		uniform half _Texture_3_Height_Contrast;
		uniform half _Texture_4_Heightmap_Depth;
		uniform half _Texture_4_H_AO_Index;
		uniform half _Texture_4_Triplanar;
		uniform half _Texture_4_Tiling;
		uniform half _Texture_4_Far_Multiplier;
		uniform half _Texture_4_Height_Contrast;
		uniform half _Texture_5_Heightmap_Depth;
		uniform half _Texture_5_H_AO_Index;
		uniform half _Texture_5_Triplanar;
		uniform half _Texture_5_Tiling;
		uniform half _Texture_5_Far_Multiplier;
		uniform half _Texture_5_Height_Contrast;
		uniform half _Texture_6_Heightmap_Depth;
		uniform half _Texture_6_H_AO_Index;
		uniform half _Texture_6_Triplanar;
		uniform half _Texture_6_Tiling;
		uniform half _Texture_6_Far_Multiplier;
		uniform half _Texture_6_Height_Contrast;
		uniform half _Texture_7_Heightmap_Depth;
		uniform half _Texture_7_H_AO_Index;
		uniform half _Texture_7_Triplanar;
		uniform half _Texture_7_Tiling;
		uniform half _Texture_7_Far_Multiplier;
		uniform half _Texture_7_Height_Contrast;
		uniform half _Texture_8_Tesselation_Depth;
		uniform half _Texture_8_H_AO_Index;
		uniform half _Texture_8_Triplanar;
		uniform half _Texture_8_Tiling;
		uniform half _Texture_8_Far_Multiplier;
		uniform half _Texture_8_Height_Contrast;
		uniform half _Texture_9_Heightmap_Depth;
		uniform half _Texture_9_H_AO_Index;
		uniform half _Texture_9_Triplanar;
		uniform half _Texture_9_Tiling;
		uniform half _Texture_9_Far_Multiplier;
		uniform half _Texture_9_Height_Contrast;
		uniform half _Texture_10_Heightmap_Depth;
		uniform half _Texture_10_H_AO_Index;
		uniform half _Texture_10_Triplanar;
		uniform half _Texture_10_Tiling;
		uniform half _Texture_10_Far_Multiplier;
		uniform half _Texture_10_Height_Contrast;
		uniform half _Texture_11_Heightmap_Depth;
		uniform half _Texture_11_H_AO_Index;
		uniform half _Texture_11_Triplanar;
		uniform half _Texture_11_Tiling;
		uniform half _Texture_11_Far_Multiplier;
		uniform half _Texture_11_Height_Contrast;
		uniform half _Texture_12_Heightmap_Depth;
		uniform half _Texture_12_H_AO_Index;
		uniform half _Texture_12_Triplanar;
		uniform half _Texture_12_Tiling;
		uniform half _Texture_12_Far_Multiplier;
		uniform half _Texture_12_Height_Contrast;
		uniform half _Texture_12_Heightblend_Close;
		uniform half _Texture_12_Heightblend_Far;
		uniform half _Texture_13_Heightmap_Depth;
		uniform half _Texture_13_H_AO_Index;
		uniform half _Texture_13_Triplanar;
		uniform half _Texture_13_Tiling;
		uniform half _Texture_13_Far_Multiplier;
		uniform half _Texture_13_Height_Contrast;
		uniform half _Texture_14_Heightmap_Depth;
		uniform half _Texture_14_H_AO_Index;
		uniform half _Texture_14_Triplanar;
		uniform half _Texture_14_Tiling;
		uniform half _Texture_14_Far_Multiplier;
		uniform half _Texture_14_Height_Contrast;
		uniform half _Texture_15_Heightmap_Depth;
		uniform half _Texture_15_H_AO_Index;
		uniform half _Texture_15_Triplanar;
		uniform half _Texture_15_Tiling;
		uniform half _Texture_15_Far_Multiplier;
		uniform half _Texture_15_Height_Contrast;
		uniform half _Texture_16_Heightmap_Depth;
		uniform half _Texture_16_H_AO_Index;
		uniform half _Texture_16_Triplanar;
		uniform half _Texture_16_Tiling;
		uniform half _Texture_16_Far_Multiplier;
		uniform half _Texture_16_Height_Contrast;
		uniform half _Texture_Snow_H_AO_Index;
		uniform half _Snow_Tiling;
		uniform half _Snow_Tiling_Far_Multiplier;
		uniform half _Snow_Height_Contrast;
		uniform half _Snow_Heightmap_Depth;
		uniform half _Snow_Amount;
		uniform half _Snow_Noise_Tiling;
		uniform half _Snow_Noise_Power;
		uniform half _Snow_Maximum_Angle_Hardness;
		uniform half _Snow_Maximum_Angle;
		uniform half _Snow_Min_Height;
		uniform half _Snow_Min_Height_Blending;
		uniform half _Texture_16_Snow_Reduction;
		uniform half _Texture_15_Snow_Reduction;
		uniform half _Texture_13_Snow_Reduction;
		uniform half _Texture_12_Snow_Reduction;
		uniform half _Texture_11_Snow_Reduction;
		uniform half _Texture_9_Snow_Reduction;
		uniform half _Texture_8_Snow_Reduction;
		uniform half _Texture_7_Snow_Reduction;
		uniform half _Texture_5_Snow_Reduction;
		uniform half _Texture_1_Snow_Reduction;
		uniform half _Texture_2_Snow_Reduction;
		uniform half _Texture_3_Snow_Reduction;
		uniform half _Texture_4_Snow_Reduction;
		uniform half _Texture_6_Snow_Reduction;
		uniform half _Texture_10_Snow_Reduction;
		uniform half _Texture_14_Snow_Reduction;
		uniform half _Snow_Heightblend_Close;
		uniform half _Snow_Heightblend_Far;
		uniform half _Texture_13_Heightblend_Close;
		uniform half _Texture_13_Heightblend_Far;
		uniform half _Texture_14_Heightblend_Close;
		uniform half _Texture_14_Heightblend_Far;
		uniform half _Texture_15_Heightblend_Close;
		uniform half _Texture_15_Heightblend_Far;
		uniform half _Texture_16_Heightblend_Close;
		uniform half _Texture_16_Heightblend_Far;
		uniform half _Texture_9_Heightblend_Close;
		uniform half _Texture_9_Heightblend_Far;
		uniform half _Texture_10_Heightblend_Close;
		uniform half _Texture_10_Heightblend_Far;
		uniform half _Texture_11_Heightblend_Close;
		uniform half _Texture_11_Heightblend_Far;
		uniform half _Texture_5_Heightblend_Close;
		uniform half _Texture_5_Heightblend_Far;
		uniform half _Texture_6_Heightblend_Close;
		uniform half _Texture_6_Heightblend_Far;
		uniform half _Texture_7_Heightblend_Close;
		uniform half _Texture_7_Heightblend_Far;
		uniform half _Texture_8_Heightblend_Close;
		uniform half _Texture_8_Heightblend_Far;
		uniform half _Texture_1_Heightblend_Close;
		uniform half _Texture_1_Heightblend_Far;
		uniform half _Texture_2_Heightblend_Close;
		uniform half _Texture_2_Heightblend_Far;
		uniform half _Texture_3_Heightblend_Close;
		uniform half _Texture_3_Heightblend_Far;
		uniform half _Texture_4_Heightblend_Close;
		uniform half _Texture_4_Heightblend_Far;
		uniform half _Texture_1_Normal_Index;
		uniform half _Texture_1_Normal_Power;
		uniform half _Texture_2_Normal_Index;
		uniform half _Texture_2_Normal_Power;
		uniform half _Texture_3_Normal_Power;
		uniform half _Texture_3_Normal_Index;
		uniform half _Texture_4_Normal_Power;
		uniform half _Texture_4_Normal_Index;
		uniform half _Texture_5_Normal_Power;
		uniform half _Texture_5_Normal_Index;
		uniform half _Texture_6_Normal_Power;
		uniform half _Texture_6_Normal_Index;
		uniform half _Texture_7_Normal_Power;
		uniform half _Texture_7_Normal_Index;
		uniform half _Texture_8_Normal_Power;
		uniform half _Texture_8_Normal_Index;
		uniform half _Texture_9_Normal_Index;
		uniform half _Texture_9_Normal_Power;
		uniform half _Texture_10_Normal_Index;
		uniform half _Texture_10_Normal_Power;
		uniform half _Texture_11_Normal_Power;
		uniform half _Texture_11_Normal_Index;
		uniform half _Texture_12_Normal_Power;
		uniform half _Texture_12_Normal_Index;
		uniform half _Texture_13_Normal_Power;
		uniform half _Texture_13_Normal_Index;
		uniform half _Texture_14_Normal_Index;
		uniform half _Texture_14_Normal_Power;
		uniform half _Texture_15_Normal_Index;
		uniform half _Texture_15_Normal_Power;
		uniform half _Texture_16_Normal_Index;
		uniform half _Texture_16_Normal_Power;
		uniform half _Texture_Snow_Normal_Index;
		uniform half _Snow_Normal_Scale;
		uniform half _Snow_Blend_Normal;
		uniform half _Global_Normalmap_Power;
		uniform sampler2D _Global_Normal_Map;
		uniform half _Global_Color_Map_Close_Power;
		uniform half _Global_Color_Map_Far_Power;
		uniform sampler2D _Global_Color_Map;
		uniform half2 _Global_Color_Map_Offset;
		uniform half _Global_Color_Map_Scale;
		uniform half _Global_Color_Opacity_Power;
		uniform half _Texture_1_Albedo_Index;
		uniform half4 _Texture_1_Color;
		uniform half _Texture_2_Albedo_Index;
		uniform half4 _Texture_2_Color;
		uniform half _Texture_3_Albedo_Index;
		uniform half4 _Texture_3_Color;
		uniform half _Texture_4_Albedo_Index;
		uniform half4 _Texture_4_Color;
		uniform half _Texture_5_Albedo_Index;
		uniform half4 _Texture_5_Color;
		uniform half _Texture_6_Albedo_Index;
		uniform half4 _Texture_6_Color;
		uniform half _Texture_7_Albedo_Index;
		uniform half4 _Texture_7_Color;
		uniform half _Texture_8_Albedo_Index;
		uniform half4 _Texture_8_Color;
		uniform half _Texture_9_Albedo_Index;
		uniform half4 _Texture_9_Color;
		uniform half _Texture_10_Albedo_Index;
		uniform half4 _Texture_10_Color;
		uniform half _Texture_11_Albedo_Index;
		uniform half4 _Texture_11_Color;
		uniform half _Texture_12_Albedo_Index;
		uniform half4 _Texture_12_Color;
		uniform half _Texture_13_Albedo_Index;
		uniform half4 _Texture_13_Color;
		uniform half _Texture_14_Albedo_Index;
		uniform half4 _Texture_14_Color;
		uniform half _Texture_15_Albedo_Index;
		uniform half4 _Texture_15_Color;
		uniform half _Texture_16_Albedo_Index;
		uniform half4 _Texture_16_Color;
		uniform sampler2D _Texture_Geological_Map;
		uniform half _Geological_Map_Offset_Close;
		uniform half _Geological_Tiling_Close;
		uniform half _Geological_Map_Close_Power;
		uniform half _Geological_Tiling_Far;
		uniform half _Geological_Map_Offset_Far;
		uniform half _Geological_Map_Far_Power;
		uniform half _Texture_16_Geological_Power;
		uniform half _Texture_15_Geological_Power;
		uniform half _Texture_14_Geological_Power;
		uniform half _Texture_13_Geological_Power;
		uniform half _Texture_12_Geological_Power;
		uniform half _Texture_11_Geological_Power;
		uniform half _Texture_10_Geological_Power;
		uniform half _Texture_9_Geological_Power;
		uniform half _Texture_8_Geological_Power;
		uniform half _Texture_7_Geological_Power;
		uniform half _Texture_6_Geological_Power;
		uniform half _Texture_5_Geological_Power;
		uniform half _Texture_1_Geological_Power;
		uniform half _Texture_2_Geological_Power;
		uniform half _Texture_4_Geological_Power;
		uniform half _Texture_3_Geological_Power;
		uniform half _Texture_Snow_Index;
		uniform half4 _Texture_Snow_Average;
		uniform half4 _Snow_Color;
		uniform half _Gliter_Color_Power;
		uniform half _Glitter_Refreshing_Speed;
		uniform sampler2D _Texture_Glitter;
		uniform half _Glitter_Tiling;
		uniform half _Glitter_Noise_Threshold;
		uniform half _Terrain_Specular;
		uniform half _Snow_Specular;
		uniform half _Glitter_Specular;
		uniform half _Terrain_Smoothness;
		uniform half _Glitter_Smoothness;
		uniform half _Ambient_Occlusion_Power;
		uniform half _Texture_1_AO_Power;
		uniform half _Texture_2_AO_Power;
		uniform half _Texture_3_AO_Power;
		uniform half _Texture_4_AO_Power;
		uniform half _Texture_5_AO_Power;
		uniform half _Texture_6_AO_Power;
		uniform half _Texture_7_AO_Power;
		uniform half _Texture_8_AO_Power;
		uniform half _Texture_9_AO_Power;
		uniform half _Texture_10_AO_Power;
		uniform half _Texture_11_AO_Power;
		uniform half _Texture_12_AO_Power;
		uniform half _Texture_13_AO_Power;
		uniform half _Texture_14_AO_Power;
		uniform half _Texture_15_AO_Power;
		uniform half _Texture_16_AO_Power;
		uniform half _Snow_Ambient_Occlusion_Power;
		uniform sampler2D _TerrainHolesTexture;
		uniform float4 _TerrainHolesTexture_ST;
		uniform half _Remove_Vert_Height;
		uniform float _Cutoff = 0.5;


		float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }

		float snoise( float2 v )
		{
			const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
			float2 i = floor( v + dot( v, C.yy ) );
			float2 x0 = v - i + dot( i, C.xx );
			float2 i1;
			i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
			float4 x12 = x0.xyxy + C.xxzz;
			x12.xy -= i1;
			i = mod2D289( i );
			float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
			float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
			m = m * m;
			m = m * m;
			float3 x = 2.0 * frac( p * C.www ) - 1.0;
			float3 h = abs( x ) - 0.5;
			float3 ox = floor( x + 0.5 );
			float3 a0 = x - ox;
			m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
			float3 g;
			g.x = a0.x * x0.x + h.x * x0.y;
			g.yz = a0.yz * x12.xz + h.yz * x12.yw;
			return 130.0 * dot( m, g );
		}


		inline half MyCustomExpression8016( inout half3 In0 )
		{
			return UNITY_MATRIX_IT_MV[2].xyz;
		}


		void surf( Input i , inout SurfaceOutputStandardSpecular o )
		{
			float3 ase_worldPos = i.worldPos;
			float3 break8068 = ase_worldPos;
			float2 appendResult8003 = (half2(break8068.x , break8068.z));
			half2 Top_Bottom1999 = appendResult8003;
			float4 texArray6256 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(( Top_Bottom1999 / _Perlin_Normal_Tiling_Close ), _Texture_Perlin_Normal_Index)  );
			float2 appendResult11_g999 = (half2(texArray6256.w , texArray6256.y));
			float2 temp_output_4_0_g999 = ( ( ( appendResult11_g999 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Perlin_Normal_Power_Close );
			float2 break8_g999 = temp_output_4_0_g999;
			float dotResult5_g999 = dot( temp_output_4_0_g999 , temp_output_4_0_g999 );
			float temp_output_9_0_g999 = sqrt( ( 1.0 - saturate( dotResult5_g999 ) ) );
			float3 appendResult20_g999 = (half3(break8_g999.x , break8_g999.y , temp_output_9_0_g999));
			float4 texArray4374 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(( Top_Bottom1999 / _Perlin_Normal_Tiling_Far ), _Texture_Perlin_Normal_Index)  );
			float2 appendResult11_g998 = (half2(texArray4374.w , texArray4374.y));
			float2 temp_output_4_0_g998 = ( ( ( appendResult11_g998 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Perlin_Normal_Power );
			float2 break8_g998 = temp_output_4_0_g998;
			float dotResult5_g998 = dot( temp_output_4_0_g998 , temp_output_4_0_g998 );
			float temp_output_9_0_g998 = sqrt( ( 1.0 - saturate( dotResult5_g998 ) ) );
			float3 appendResult20_g998 = (half3(break8_g998.x , break8_g998.y , temp_output_9_0_g998));
			float3 break7977 = abs( ( ase_worldPos - _WorldSpaceCameraPos ) );
			float clampResult297 = clamp( pow( ( max( max( break7977.x , break7977.y ) , break7977.z ) / _UV_Mix_Start_Distance ) , _UV_Mix_Power ) , 0.0 , 1.0 );
			half UVmixDistance636 = clampResult297;
			float3 lerpResult6257 = lerp( appendResult20_g999 , appendResult20_g998 , UVmixDistance636);
			half4 tex2DNode4371 = tex2D( _Texture_Splat_4, i.uv_texcoord );
			half Splat4_A2546 = tex2DNode4371.a;
			half Splat4_B2545 = tex2DNode4371.b;
			half Splat4_G2544 = tex2DNode4371.g;
			half Splat4_R2543 = tex2DNode4371.r;
			half4 tex2DNode4370 = tex2D( _Texture_Splat_3, i.uv_texcoord );
			half Splat3_A2540 = tex2DNode4370.a;
			half Splat3_B2539 = tex2DNode4370.b;
			half Splat3_G2538 = tex2DNode4370.g;
			half Splat3_R2537 = tex2DNode4370.r;
			half4 tex2DNode4369 = tex2D( _Texture_Splat_2, i.uv_texcoord );
			half Splat2_A2109 = tex2DNode4369.a;
			half Splat2_B2108 = tex2DNode4369.b;
			half Splat2_G2107 = tex2DNode4369.g;
			half Splat2_R2106 = tex2DNode4369.r;
			half4 tex2DNode4368 = tex2D( _Texture_Splat_1, i.uv_texcoord );
			half Splat1_R1438 = tex2DNode4368.r;
			half Splat1_G1441 = tex2DNode4368.g;
			half Splat1_A1491 = tex2DNode4368.a;
			half Splat1_B1442 = tex2DNode4368.b;
			float clampResult3775 = clamp( ( ( _Texture_16_Perlin_Power * Splat4_A2546 ) + ( ( _Texture_15_Perlin_Power * Splat4_B2545 ) + ( ( _Texture_14_Perlin_Power * Splat4_G2544 ) + ( ( _Texture_13_Perlin_Power * Splat4_R2543 ) + ( ( _Texture_12_Perlin_Power * Splat3_A2540 ) + ( ( _Texture_11_Perlin_Power * Splat3_B2539 ) + ( ( _Texture_10_Perlin_Power * Splat3_G2538 ) + ( ( _Texture_9_Perlin_Power * Splat3_R2537 ) + ( ( _Texture_8_Perlin_Power * Splat2_A2109 ) + ( ( _Texture_7_Perlin_Power * Splat2_B2108 ) + ( ( _Texture_6_Perlin_Power * Splat2_G2107 ) + ( ( _Texture_5_Perlin_Power * Splat2_R2106 ) + ( ( _Texture_1_Perlin_Power * Splat1_R1438 ) + ( ( _Texture_2_Perlin_Power * Splat1_G1441 ) + ( ( _Texture_4_Perlin_Power * Splat1_A1491 ) + ( _Texture_3_Perlin_Power * Splat1_B1442 ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) , 0.0 , 1.0 );
			float3 lerpResult3776 = lerp( float3( 0,0,1 ) , lerpResult6257 , clampResult3775);
			float3 lerpResult3906 = lerp( float3( 0,0,1 ) , lerpResult6257 , ( _Snow_Perlin_Power * 0.5 ));
			float temp_output_3830_0 = ( 1.0 / _Texture_1_Tiling );
			float2 appendResult3284 = (half2(temp_output_3830_0 , temp_output_3830_0));
			float2 temp_output_3275_0 = ( Top_Bottom1999 * appendResult3284 );
			float4 texArray7282 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3275_0, _Texture_1_H_AO_Index)  );
			float2 appendResult7808 = (half2(texArray7282.y , texArray7282.w));
			float2 temp_output_3298_0 = ( temp_output_3275_0 / _Texture_1_Far_Multiplier );
			float4 texArray5491 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3298_0, _Texture_1_H_AO_Index)  );
			float2 appendResult7806 = (half2(texArray5491.y , 1.0));
			float2 lerpResult6611 = lerp( appendResult7808 , appendResult7806 , UVmixDistance636);
			half3 ase_worldNormal = WorldNormalVector( i, half3( 0, 0, 1 ) );
			NormalForWorld(ase_worldNormal, i.tc.zw);
			float3 clampResult6387 = clamp( pow( ( ase_worldNormal * ase_worldNormal ) , 25.0 ) , float3( -1,-1,-1 ) , float3( 1,1,1 ) );
			half3 BlendComponents91 = clampResult6387;
			float2 appendResult8005 = (half2(break8068.z , break8068.y));
			half2 Front_Back1991 = appendResult8005;
			float2 temp_output_3279_0 = ( Front_Back1991 * appendResult3284 );
			float4 texArray7804 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3279_0, _Texture_1_H_AO_Index)  );
			float2 appendResult7810 = (half2(texArray7804.y , texArray7804.w));
			float2 appendResult8004 = (half2(break8068.x , break8068.y));
			half2 Left_Right2003 = appendResult8004;
			float2 temp_output_3277_0 = ( Left_Right2003 * appendResult3284 );
			float4 texArray7283 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3277_0, _Texture_1_H_AO_Index)  );
			float2 appendResult7809 = (half2(texArray7283.y , texArray7283.w));
			float3 weightedBlendVar7286 = BlendComponents91;
			float2 weightedAvg7286 = ( ( weightedBlendVar7286.x*appendResult7810 + weightedBlendVar7286.y*appendResult7808 + weightedBlendVar7286.z*appendResult7809 )/( weightedBlendVar7286.x + weightedBlendVar7286.y + weightedBlendVar7286.z ) );
			float2 temp_output_3296_0 = ( temp_output_3279_0 / _Texture_1_Far_Multiplier );
			float4 texArray5486 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3296_0, _Texture_1_H_AO_Index)  );
			float2 appendResult7805 = (half2(texArray5486.y , 1.0));
			float2 temp_output_3297_0 = ( temp_output_3277_0 / _Texture_1_Far_Multiplier );
			float4 texArray5489 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3297_0, _Texture_1_H_AO_Index)  );
			float2 appendResult7807 = (half2(texArray5489.y , 1.0));
			float3 weightedBlendVar6394 = BlendComponents91;
			float2 weightedAvg6394 = ( ( weightedBlendVar6394.x*appendResult7805 + weightedBlendVar6394.y*appendResult7806 + weightedBlendVar6394.z*appendResult7807 )/( weightedBlendVar6394.x + weightedBlendVar6394.y + weightedBlendVar6394.z ) );
			float2 lerpResult5478 = lerp( weightedAvg7286 , weightedAvg6394 , UVmixDistance636);
			half2 ifLocalVar6609 = 0;
			UNITY_BRANCH 
			if( _Texture_1_Triplanar == 1.0 )
				ifLocalVar6609 = lerpResult5478;
			else
				ifLocalVar6609 = lerpResult6611;
			half2 ifLocalVar7731 = 0;
			UNITY_BRANCH 
			if( _Texture_1_H_AO_Index > -1.0 )
				ifLocalVar7731 = ifLocalVar6609;
			half2 Texture_1_H5480 = ifLocalVar7731;
			float2 break7905 = Texture_1_H5480;
			float temp_output_5544_0 = ( pow( break7905.x , _Texture_1_Height_Contrast ) * _Texture_1_Heightmap_Depth );
			float temp_output_3831_0 = ( 1.0 / _Texture_2_Tiling );
			float2 appendResult3349 = (half2(temp_output_3831_0 , temp_output_3831_0));
			float2 temp_output_3343_0 = ( Top_Bottom1999 * appendResult3349 );
			float4 texArray7293 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3343_0, _Texture_2_H_AO_Index)  );
			float2 appendResult7814 = (half2(texArray7293.y , texArray7293.w));
			float2 temp_output_3345_0 = ( temp_output_3343_0 / _Texture_2_Far_Multiplier );
			float4 texArray5533 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3345_0, _Texture_2_H_AO_Index)  );
			float2 appendResult7924 = (half2(texArray5533.y , 1.0));
			float2 lerpResult6616 = lerp( appendResult7814 , appendResult7924 , UVmixDistance636);
			float2 temp_output_3344_0 = ( Front_Back1991 * appendResult3349 );
			float4 texArray7304 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3344_0, _Texture_2_H_AO_Index)  );
			float2 appendResult7816 = (half2(texArray7304.y , texArray7304.w));
			float2 temp_output_3379_0 = ( Left_Right2003 * appendResult3349 );
			float4 texArray7294 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3379_0, _Texture_2_H_AO_Index)  );
			float2 appendResult7815 = (half2(texArray7294.y , texArray7294.w));
			float3 weightedBlendVar7300 = BlendComponents91;
			float2 weightedAvg7300 = ( ( weightedBlendVar7300.x*appendResult7816 + weightedBlendVar7300.y*appendResult7814 + weightedBlendVar7300.z*appendResult7815 )/( weightedBlendVar7300.x + weightedBlendVar7300.y + weightedBlendVar7300.z ) );
			float2 temp_output_3346_0 = ( temp_output_3344_0 / _Texture_2_Far_Multiplier );
			float4 texArray5530 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3346_0, _Texture_2_H_AO_Index)  );
			float2 appendResult7813 = (half2(texArray5530.y , 1.0));
			float2 temp_output_3352_0 = ( temp_output_3379_0 / _Texture_2_Far_Multiplier );
			float4 texArray5532 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3352_0, _Texture_2_H_AO_Index)  );
			float2 appendResult7925 = (half2(texArray5532.y , 1.0));
			float3 weightedBlendVar6400 = BlendComponents91;
			float2 weightedAvg6400 = ( ( weightedBlendVar6400.x*appendResult7813 + weightedBlendVar6400.y*appendResult7924 + weightedBlendVar6400.z*appendResult7925 )/( weightedBlendVar6400.x + weightedBlendVar6400.y + weightedBlendVar6400.z ) );
			float2 lerpResult5525 = lerp( weightedAvg7300 , weightedAvg6400 , UVmixDistance636);
			half2 ifLocalVar6614 = 0;
			UNITY_BRANCH 
			if( _Texture_2_Triplanar == 1.0 )
				ifLocalVar6614 = lerpResult5525;
			else
				ifLocalVar6614 = lerpResult6616;
			half2 ifLocalVar7734 = 0;
			UNITY_BRANCH 
			if( _Texture_2_H_AO_Index > -1.0 )
				ifLocalVar7734 = ifLocalVar6614;
			half2 Texture_2_H5497 = ifLocalVar7734;
			float2 break7906 = Texture_2_H5497;
			float temp_output_5545_0 = ( _Texture_2_Heightmap_Depth * pow( break7906.x , _Texture_2_Height_Contrast ) );
			float temp_output_3832_0 = ( 1.0 / _Texture_3_Tiling );
			float2 appendResult3415 = (half2(temp_output_3832_0 , temp_output_3832_0));
			float2 temp_output_3410_0 = ( Top_Bottom1999 * appendResult3415 );
			float4 texArray7310 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3410_0, _Texture_3_H_AO_Index)  );
			float2 appendResult7817 = (half2(texArray7310.y , texArray7310.w));
			float2 temp_output_3412_0 = ( temp_output_3410_0 / _Texture_3_Far_Multiplier );
			float4 texArray5586 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3412_0, _Texture_3_H_AO_Index)  );
			float2 appendResult7927 = (half2(texArray5586.y , 1.0));
			float2 lerpResult6622 = lerp( appendResult7817 , appendResult7927 , UVmixDistance636);
			float2 temp_output_3411_0 = ( Front_Back1991 * appendResult3415 );
			float4 texArray7311 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3411_0, _Texture_3_H_AO_Index)  );
			float2 appendResult7819 = (half2(texArray7311.y , texArray7311.w));
			float2 temp_output_3441_0 = ( Left_Right2003 * appendResult3415 );
			float4 texArray7305 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3441_0, _Texture_3_H_AO_Index)  );
			float2 appendResult7818 = (half2(texArray7305.y , texArray7305.w));
			float3 weightedBlendVar7308 = BlendComponents91;
			float2 weightedAvg7308 = ( ( weightedBlendVar7308.x*appendResult7819 + weightedBlendVar7308.y*appendResult7817 + weightedBlendVar7308.z*appendResult7818 )/( weightedBlendVar7308.x + weightedBlendVar7308.y + weightedBlendVar7308.z ) );
			float2 temp_output_3413_0 = ( temp_output_3411_0 / _Texture_3_Far_Multiplier );
			float4 texArray5560 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3413_0, _Texture_3_H_AO_Index)  );
			float2 appendResult7926 = (half2(texArray5560.y , 1.0));
			float2 temp_output_3418_0 = ( temp_output_3441_0 / _Texture_3_Far_Multiplier );
			float4 texArray5572 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3418_0, _Texture_3_H_AO_Index)  );
			float2 appendResult7928 = (half2(texArray5572.y , 1.0));
			float3 weightedBlendVar6407 = BlendComponents91;
			float2 weightedAvg6407 = ( ( weightedBlendVar6407.x*appendResult7926 + weightedBlendVar6407.y*appendResult7927 + weightedBlendVar6407.z*appendResult7928 )/( weightedBlendVar6407.x + weightedBlendVar6407.y + weightedBlendVar6407.z ) );
			float2 lerpResult5563 = lerp( weightedAvg7308 , weightedAvg6407 , UVmixDistance636);
			half2 ifLocalVar6620 = 0;
			UNITY_BRANCH 
			if( _Texture_3_Triplanar == 1.0 )
				ifLocalVar6620 = lerpResult5563;
			else
				ifLocalVar6620 = lerpResult6622;
			half2 ifLocalVar7736 = 0;
			UNITY_BRANCH 
			if( _Texture_3_H_AO_Index > -1.0 )
				ifLocalVar7736 = ifLocalVar6620;
			half2 Texture_3_H5581 = ifLocalVar7736;
			float2 break7907 = Texture_3_H5581;
			float temp_output_5590_0 = ( _Texture_3_Heightmap_Depth * pow( break7907.x , _Texture_3_Height_Contrast ) );
			float temp_output_3833_0 = ( 1.0 / _Texture_4_Tiling );
			float2 appendResult3482 = (half2(temp_output_3833_0 , temp_output_3833_0));
			float2 temp_output_3477_0 = ( Top_Bottom1999 * appendResult3482 );
			float4 texArray7322 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3477_0, _Texture_4_H_AO_Index)  );
			float2 appendResult7826 = (half2(texArray7322.y , texArray7322.w));
			float2 temp_output_3479_0 = ( temp_output_3477_0 / _Texture_4_Far_Multiplier );
			float4 texArray5615 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3479_0, _Texture_4_H_AO_Index)  );
			float2 appendResult7930 = (half2(texArray5615.y , 1.0));
			float2 lerpResult6628 = lerp( appendResult7826 , appendResult7930 , UVmixDistance636);
			float2 temp_output_3478_0 = ( Front_Back1991 * appendResult3482 );
			float4 texArray7323 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3478_0, _Texture_4_H_AO_Index)  );
			float2 appendResult7828 = (half2(texArray7323.y , texArray7323.w));
			float2 temp_output_3508_0 = ( Left_Right2003 * appendResult3482 );
			float4 texArray7317 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3508_0, _Texture_4_H_AO_Index)  );
			float2 appendResult7827 = (half2(texArray7317.y , texArray7317.w));
			float3 weightedBlendVar7320 = BlendComponents91;
			float2 weightedAvg7320 = ( ( weightedBlendVar7320.x*appendResult7828 + weightedBlendVar7320.y*appendResult7826 + weightedBlendVar7320.z*appendResult7827 )/( weightedBlendVar7320.x + weightedBlendVar7320.y + weightedBlendVar7320.z ) );
			float2 temp_output_3480_0 = ( temp_output_3478_0 / _Texture_4_Far_Multiplier );
			float4 texArray5596 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3480_0, _Texture_4_H_AO_Index)  );
			float2 appendResult7929 = (half2(texArray5596.y , 1.0));
			float2 temp_output_3485_0 = ( temp_output_3508_0 / _Texture_4_Far_Multiplier );
			float4 texArray5604 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3485_0, _Texture_4_H_AO_Index)  );
			float2 appendResult7931 = (half2(texArray5604.y , 1.0));
			float3 weightedBlendVar6414 = BlendComponents91;
			float2 weightedAvg6414 = ( ( weightedBlendVar6414.x*appendResult7929 + weightedBlendVar6414.y*appendResult7930 + weightedBlendVar6414.z*appendResult7931 )/( weightedBlendVar6414.x + weightedBlendVar6414.y + weightedBlendVar6414.z ) );
			float2 lerpResult5629 = lerp( weightedAvg7320 , weightedAvg6414 , UVmixDistance636);
			half2 ifLocalVar6626 = 0;
			UNITY_BRANCH 
			if( _Texture_4_Triplanar == 1.0 )
				ifLocalVar6626 = lerpResult5629;
			else
				ifLocalVar6626 = lerpResult6628;
			half2 ifLocalVar7738 = 0;
			UNITY_BRANCH 
			if( _Texture_4_H_AO_Index > -1.0 )
				ifLocalVar7738 = ifLocalVar6626;
			half2 Texture_4_H5631 = ifLocalVar7738;
			float2 break7908 = Texture_4_H5631;
			float temp_output_6118_0 = ( _Texture_4_Heightmap_Depth * pow( break7908.x , _Texture_4_Height_Contrast ) );
			float4 layeredBlendVar7775 = tex2DNode4368;
			float layeredBlend7775 = ( lerp( lerp( lerp( lerp( 0.0 , temp_output_5544_0 , layeredBlendVar7775.x ) , temp_output_5545_0 , layeredBlendVar7775.y ) , temp_output_5590_0 , layeredBlendVar7775.z ) , temp_output_6118_0 , layeredBlendVar7775.w ) );
			float temp_output_4397_0 = ( 1.0 / _Texture_5_Tiling );
			float2 appendResult4399 = (half2(temp_output_4397_0 , temp_output_4397_0));
			float2 temp_output_4416_0 = ( Top_Bottom1999 * appendResult4399 );
			float4 texArray7334 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4416_0, _Texture_5_H_AO_Index)  );
			float2 appendResult7832 = (half2(texArray7334.y , texArray7334.w));
			float2 temp_output_4440_0 = ( temp_output_4416_0 / _Texture_5_Far_Multiplier );
			float4 texArray5655 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4440_0, _Texture_5_H_AO_Index)  );
			float2 appendResult7933 = (half2(texArray5655.y , 1.0));
			float2 lerpResult6634 = lerp( appendResult7832 , appendResult7933 , UVmixDistance636);
			float2 temp_output_4400_0 = ( Front_Back1991 * appendResult4399 );
			float4 texArray7335 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4400_0, _Texture_5_H_AO_Index)  );
			float2 appendResult7834 = (half2(texArray7335.y , texArray7335.w));
			float2 temp_output_4413_0 = ( Left_Right2003 * appendResult4399 );
			float4 texArray7329 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4413_0, _Texture_5_H_AO_Index)  );
			float2 appendResult7833 = (half2(texArray7329.y , texArray7329.w));
			float3 weightedBlendVar7332 = BlendComponents91;
			float2 weightedAvg7332 = ( ( weightedBlendVar7332.x*appendResult7834 + weightedBlendVar7332.y*appendResult7832 + weightedBlendVar7332.z*appendResult7833 )/( weightedBlendVar7332.x + weightedBlendVar7332.y + weightedBlendVar7332.z ) );
			float2 temp_output_4436_0 = ( temp_output_4400_0 / _Texture_5_Far_Multiplier );
			float4 texArray5636 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4436_0, _Texture_5_H_AO_Index)  );
			float2 appendResult7932 = (half2(texArray5636.x , 1.0));
			float2 temp_output_4437_0 = ( temp_output_4413_0 / _Texture_5_Far_Multiplier );
			float4 texArray5644 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4437_0, _Texture_5_H_AO_Index)  );
			float2 appendResult7934 = (half2(texArray5644.y , 1.0));
			float3 weightedBlendVar6421 = BlendComponents91;
			float2 weightedAvg6421 = ( ( weightedBlendVar6421.x*appendResult7932 + weightedBlendVar6421.y*appendResult7933 + weightedBlendVar6421.z*appendResult7934 )/( weightedBlendVar6421.x + weightedBlendVar6421.y + weightedBlendVar6421.z ) );
			float2 lerpResult5669 = lerp( weightedAvg7332 , weightedAvg6421 , UVmixDistance636);
			half2 ifLocalVar6632 = 0;
			UNITY_BRANCH 
			if( _Texture_5_Triplanar == 1.0 )
				ifLocalVar6632 = lerpResult5669;
			else
				ifLocalVar6632 = lerpResult6634;
			half2 ifLocalVar7742 = 0;
			UNITY_BRANCH 
			if( _Texture_5_H_AO_Index > -1.0 )
				ifLocalVar7742 = ifLocalVar6632;
			half2 Texture_5_H5671 = ifLocalVar7742;
			float2 break7910 = Texture_5_H5671;
			float temp_output_6120_0 = ( _Texture_5_Heightmap_Depth * pow( break7910.x , _Texture_5_Height_Contrast ) );
			float temp_output_4469_0 = ( 1.0 / _Texture_6_Tiling );
			float2 appendResult4471 = (half2(temp_output_4469_0 , temp_output_4469_0));
			float2 temp_output_4485_0 = ( Top_Bottom1999 * appendResult4471 );
			float4 texArray7346 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4485_0, _Texture_6_H_AO_Index)  );
			float2 appendResult7838 = (half2(texArray7346.y , texArray7346.w));
			float2 temp_output_4507_0 = ( temp_output_4485_0 / _Texture_6_Far_Multiplier );
			float4 texArray5695 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4507_0, _Texture_6_H_AO_Index)  );
			float2 appendResult7936 = (half2(texArray5695.y , 1.0));
			float2 lerpResult6640 = lerp( appendResult7838 , appendResult7936 , UVmixDistance636);
			float2 temp_output_4472_0 = ( Front_Back1991 * appendResult4471 );
			float4 texArray7347 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4472_0, _Texture_6_H_AO_Index)  );
			float2 appendResult7840 = (half2(texArray7347.y , texArray7347.w));
			float2 temp_output_4483_0 = ( Left_Right2003 * appendResult4471 );
			float4 texArray7341 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4483_0, _Texture_6_H_AO_Index)  );
			float2 appendResult7839 = (half2(texArray7341.y , texArray7341.w));
			float3 weightedBlendVar7344 = BlendComponents91;
			float2 weightedAvg7344 = ( ( weightedBlendVar7344.x*appendResult7840 + weightedBlendVar7344.y*appendResult7838 + weightedBlendVar7344.z*appendResult7839 )/( weightedBlendVar7344.x + weightedBlendVar7344.y + weightedBlendVar7344.z ) );
			float2 temp_output_4503_0 = ( temp_output_4472_0 / _Texture_6_Far_Multiplier );
			float4 texArray5676 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4503_0, _Texture_6_H_AO_Index)  );
			float2 appendResult7935 = (half2(texArray5676.y , 1.0));
			float2 temp_output_4504_0 = ( temp_output_4483_0 / _Texture_6_Far_Multiplier );
			float4 texArray5684 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4504_0, _Texture_6_H_AO_Index)  );
			float2 appendResult7937 = (half2(texArray5684.y , 1.0));
			float3 weightedBlendVar6428 = BlendComponents91;
			float2 weightedAvg6428 = ( ( weightedBlendVar6428.x*appendResult7935 + weightedBlendVar6428.y*appendResult7936 + weightedBlendVar6428.z*appendResult7937 )/( weightedBlendVar6428.x + weightedBlendVar6428.y + weightedBlendVar6428.z ) );
			float2 lerpResult5709 = lerp( weightedAvg7344 , weightedAvg6428 , UVmixDistance636);
			half2 ifLocalVar6638 = 0;
			UNITY_BRANCH 
			if( _Texture_6_Triplanar == 1.0 )
				ifLocalVar6638 = lerpResult5709;
			else
				ifLocalVar6638 = lerpResult6640;
			half2 ifLocalVar7746 = 0;
			UNITY_BRANCH 
			if( _Texture_6_H_AO_Index > -1.0 )
				ifLocalVar7746 = ifLocalVar6638;
			half2 Texture_6_H5711 = ifLocalVar7746;
			float2 break7911 = Texture_6_H5711;
			float temp_output_6126_0 = ( _Texture_6_Heightmap_Depth * pow( break7911.x , _Texture_6_Height_Contrast ) );
			float temp_output_4543_0 = ( 1.0 / _Texture_7_Tiling );
			float2 appendResult4545 = (half2(temp_output_4543_0 , temp_output_4543_0));
			float2 temp_output_4559_0 = ( Top_Bottom1999 * appendResult4545 );
			float4 texArray7358 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4559_0, _Texture_7_H_AO_Index)  );
			float2 appendResult7844 = (half2(texArray7358.y , texArray7358.w));
			float2 temp_output_4581_0 = ( temp_output_4559_0 / _Texture_7_Far_Multiplier );
			float4 texArray5735 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4581_0, _Texture_7_H_AO_Index)  );
			float2 appendResult7939 = (half2(texArray5735.y , 1.0));
			float2 lerpResult6646 = lerp( appendResult7844 , appendResult7939 , UVmixDistance636);
			float2 temp_output_4546_0 = ( Front_Back1991 * appendResult4545 );
			float4 texArray7359 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4546_0, _Texture_7_H_AO_Index)  );
			float2 appendResult7846 = (half2(texArray7359.y , texArray7359.w));
			float2 temp_output_4557_0 = ( Left_Right2003 * appendResult4545 );
			float4 texArray7353 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4557_0, _Texture_7_H_AO_Index)  );
			float2 appendResult7845 = (half2(texArray7353.y , texArray7353.w));
			float3 weightedBlendVar7356 = BlendComponents91;
			float2 weightedAvg7356 = ( ( weightedBlendVar7356.x*appendResult7846 + weightedBlendVar7356.y*appendResult7844 + weightedBlendVar7356.z*appendResult7845 )/( weightedBlendVar7356.x + weightedBlendVar7356.y + weightedBlendVar7356.z ) );
			float2 temp_output_4577_0 = ( temp_output_4546_0 / _Texture_7_Far_Multiplier );
			float4 texArray5716 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4577_0, _Texture_7_H_AO_Index)  );
			float2 appendResult7938 = (half2(texArray5716.y , 1.0));
			float2 temp_output_4578_0 = ( temp_output_4557_0 / _Texture_7_Far_Multiplier );
			float4 texArray5724 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4578_0, _Texture_7_H_AO_Index)  );
			float2 appendResult7940 = (half2(texArray5724.y , 1.0));
			float3 weightedBlendVar6435 = BlendComponents91;
			float2 weightedAvg6435 = ( ( weightedBlendVar6435.x*appendResult7938 + weightedBlendVar6435.y*appendResult7939 + weightedBlendVar6435.z*appendResult7940 )/( weightedBlendVar6435.x + weightedBlendVar6435.y + weightedBlendVar6435.z ) );
			float2 lerpResult5749 = lerp( weightedAvg7356 , weightedAvg6435 , UVmixDistance636);
			half2 ifLocalVar6644 = 0;
			UNITY_BRANCH 
			if( _Texture_7_Triplanar == 1.0 )
				ifLocalVar6644 = lerpResult5749;
			else
				ifLocalVar6644 = lerpResult6646;
			half2 ifLocalVar7748 = 0;
			UNITY_BRANCH 
			if( _Texture_7_H_AO_Index > -1.0 )
				ifLocalVar7748 = ifLocalVar6644;
			half2 Texture_7_H5751 = ifLocalVar7748;
			float2 break7912 = Texture_7_H5751;
			float temp_output_6132_0 = ( _Texture_7_Heightmap_Depth * pow( break7912.x , _Texture_7_Height_Contrast ) );
			float temp_output_4617_0 = ( 1.0 / _Texture_8_Tiling );
			float2 appendResult4619 = (half2(temp_output_4617_0 , temp_output_4617_0));
			float2 temp_output_4633_0 = ( Top_Bottom1999 * appendResult4619 );
			float4 texArray7370 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4633_0, _Texture_8_H_AO_Index)  );
			float2 appendResult7850 = (half2(texArray7370.y , texArray7370.w));
			float2 temp_output_4655_0 = ( temp_output_4633_0 / _Texture_8_Far_Multiplier );
			float4 texArray5775 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4655_0, _Texture_8_H_AO_Index)  );
			float2 appendResult7942 = (half2(texArray5775.y , 1.0));
			float2 lerpResult6652 = lerp( appendResult7850 , appendResult7942 , UVmixDistance636);
			float2 temp_output_4620_0 = ( Front_Back1991 * appendResult4619 );
			float4 texArray7371 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4620_0, _Texture_8_H_AO_Index)  );
			float2 appendResult7852 = (half2(texArray7371.y , texArray7371.w));
			float2 temp_output_4631_0 = ( Left_Right2003 * appendResult4619 );
			float4 texArray7365 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4631_0, _Texture_8_H_AO_Index)  );
			float2 appendResult7851 = (half2(texArray7365.y , texArray7365.w));
			float3 weightedBlendVar7368 = BlendComponents91;
			float2 weightedAvg7368 = ( ( weightedBlendVar7368.x*appendResult7852 + weightedBlendVar7368.y*appendResult7850 + weightedBlendVar7368.z*appendResult7851 )/( weightedBlendVar7368.x + weightedBlendVar7368.y + weightedBlendVar7368.z ) );
			float2 temp_output_4651_0 = ( temp_output_4620_0 / _Texture_8_Far_Multiplier );
			float4 texArray5756 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4651_0, _Texture_8_H_AO_Index)  );
			float2 appendResult7941 = (half2(texArray5756.y , 1.0));
			float2 temp_output_4652_0 = ( temp_output_4631_0 / _Texture_8_Far_Multiplier );
			float4 texArray5764 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4652_0, _Texture_8_H_AO_Index)  );
			float2 appendResult7943 = (half2(texArray5764.y , 1.0));
			float3 weightedBlendVar6442 = BlendComponents91;
			float2 weightedAvg6442 = ( ( weightedBlendVar6442.x*appendResult7941 + weightedBlendVar6442.y*appendResult7942 + weightedBlendVar6442.z*appendResult7943 )/( weightedBlendVar6442.x + weightedBlendVar6442.y + weightedBlendVar6442.z ) );
			float2 lerpResult5789 = lerp( weightedAvg7368 , weightedAvg6442 , UVmixDistance636);
			half2 ifLocalVar6650 = 0;
			UNITY_BRANCH 
			if( _Texture_8_Triplanar == 1.0 )
				ifLocalVar6650 = lerpResult5789;
			else
				ifLocalVar6650 = lerpResult6652;
			half2 ifLocalVar7753 = 0;
			UNITY_BRANCH 
			if( _Texture_8_H_AO_Index > -1.0 )
				ifLocalVar7753 = ifLocalVar6650;
			half2 Texture_8_H5791 = ifLocalVar7753;
			float2 break7913 = Texture_8_H5791;
			float temp_output_6138_0 = ( _Texture_8_Tesselation_Depth * pow( break7913.x , _Texture_8_Height_Contrast ) );
			float4 layeredBlendVar7776 = tex2DNode4369;
			float layeredBlend7776 = ( lerp( lerp( lerp( lerp( layeredBlend7775 , temp_output_6120_0 , layeredBlendVar7776.x ) , temp_output_6126_0 , layeredBlendVar7776.y ) , temp_output_6132_0 , layeredBlendVar7776.z ) , temp_output_6138_0 , layeredBlendVar7776.w ) );
			float temp_output_4703_0 = ( 1.0 / _Texture_9_Tiling );
			float2 appendResult4736 = (half2(temp_output_4703_0 , temp_output_4703_0));
			float2 temp_output_4712_0 = ( Top_Bottom1999 * appendResult4736 );
			float4 texArray7382 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4712_0, _Texture_9_H_AO_Index)  );
			float2 appendResult7856 = (half2(texArray7382.y , texArray7382.w));
			float2 temp_output_4721_0 = ( temp_output_4712_0 / _Texture_9_Far_Multiplier );
			float4 texArray5811 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4721_0, _Texture_9_H_AO_Index)  );
			half2 temp_cast_0 = (texArray5811.y).xx;
			float2 lerpResult6670 = lerp( appendResult7856 , temp_cast_0 , UVmixDistance636);
			float2 temp_output_4706_0 = ( Front_Back1991 * appendResult4736 );
			float4 texArray7383 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4706_0, _Texture_9_H_AO_Index)  );
			float2 appendResult7858 = (half2(texArray7383.y , texArray7383.w));
			float2 temp_output_4761_0 = ( Left_Right2003 * appendResult4736 );
			float4 texArray7377 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4761_0, _Texture_9_H_AO_Index)  );
			float2 appendResult7857 = (half2(texArray7377.y , texArray7377.w));
			float3 weightedBlendVar7380 = BlendComponents91;
			float2 weightedAvg7380 = ( ( weightedBlendVar7380.x*appendResult7858 + weightedBlendVar7380.y*appendResult7856 + weightedBlendVar7380.z*appendResult7857 )/( weightedBlendVar7380.x + weightedBlendVar7380.y + weightedBlendVar7380.z ) );
			float2 temp_output_4718_0 = ( temp_output_4706_0 / _Texture_9_Far_Multiplier );
			float4 texArray5796 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4718_0, _Texture_9_H_AO_Index)  );
			float2 appendResult7944 = (half2(texArray5796.y , 1.0));
			float2 appendResult7945 = (half2(texArray5811.y , 1.0));
			float2 temp_output_4844_0 = ( temp_output_4761_0 / _Texture_9_Far_Multiplier );
			float4 texArray5806 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4844_0, _Texture_9_H_AO_Index)  );
			float2 appendResult7946 = (half2(texArray5806.y , 1.0));
			float3 weightedBlendVar6449 = BlendComponents91;
			float2 weightedAvg6449 = ( ( weightedBlendVar6449.x*appendResult7944 + weightedBlendVar6449.y*appendResult7945 + weightedBlendVar6449.z*appendResult7946 )/( weightedBlendVar6449.x + weightedBlendVar6449.y + weightedBlendVar6449.z ) );
			float2 lerpResult5830 = lerp( weightedAvg7380 , weightedAvg6449 , UVmixDistance636);
			half2 ifLocalVar6668 = 0;
			UNITY_BRANCH 
			if( _Texture_9_Triplanar == 1.0 )
				ifLocalVar6668 = lerpResult5830;
			else
				ifLocalVar6668 = lerpResult6670;
			half2 ifLocalVar7771 = 0;
			UNITY_BRANCH 
			if( _Texture_9_H_AO_Index > -1.0 )
				ifLocalVar7771 = ifLocalVar6668;
			half2 Texture_9_H5832 = ifLocalVar7771;
			float2 break7915 = Texture_9_H5832;
			float temp_output_6144_0 = ( _Texture_9_Heightmap_Depth * pow( break7915.x , _Texture_9_Height_Contrast ) );
			float temp_output_4734_0 = ( 1.0 / _Texture_10_Tiling );
			float2 appendResult4738 = (half2(temp_output_4734_0 , temp_output_4734_0));
			float2 temp_output_4793_0 = ( Top_Bottom1999 * appendResult4738 );
			float4 texArray7394 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4793_0, _Texture_10_H_AO_Index)  );
			float2 appendResult7862 = (half2(texArray7394.y , texArray7394.w));
			float2 temp_output_4879_0 = ( temp_output_4793_0 / _Texture_10_Far_Multiplier );
			float4 texArray5851 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4879_0, _Texture_10_H_AO_Index)  );
			float2 appendResult7948 = (half2(texArray5851.y , 1.0));
			float2 lerpResult6664 = lerp( appendResult7862 , appendResult7948 , UVmixDistance636);
			float2 temp_output_4742_0 = ( Front_Back1991 * appendResult4738 );
			float4 texArray7395 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4742_0, _Texture_10_H_AO_Index)  );
			float2 appendResult7864 = (half2(texArray7395.y , texArray7395.w));
			float2 temp_output_4785_0 = ( Left_Right2003 * appendResult4738 );
			float4 texArray7389 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4785_0, _Texture_10_H_AO_Index)  );
			float2 appendResult7863 = (half2(texArray7389.y , texArray7389.w));
			float3 weightedBlendVar7392 = BlendComponents91;
			float2 weightedAvg7392 = ( ( weightedBlendVar7392.x*appendResult7864 + weightedBlendVar7392.y*appendResult7862 + weightedBlendVar7392.z*appendResult7863 )/( weightedBlendVar7392.x + weightedBlendVar7392.y + weightedBlendVar7392.z ) );
			float2 temp_output_4873_0 = ( temp_output_4742_0 / _Texture_10_Far_Multiplier );
			float4 texArray5836 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4873_0, _Texture_10_H_AO_Index)  );
			float2 appendResult7947 = (half2(texArray5836.y , 1.0));
			float2 temp_output_4859_0 = ( temp_output_4785_0 / _Texture_10_Far_Multiplier );
			float4 texArray5846 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4859_0, _Texture_10_H_AO_Index)  );
			float2 appendResult7949 = (half2(texArray5846.y , 1.0));
			float3 weightedBlendVar6456 = BlendComponents91;
			float2 weightedAvg6456 = ( ( weightedBlendVar6456.x*appendResult7947 + weightedBlendVar6456.y*appendResult7948 + weightedBlendVar6456.z*appendResult7949 )/( weightedBlendVar6456.x + weightedBlendVar6456.y + weightedBlendVar6456.z ) );
			float2 lerpResult5870 = lerp( weightedAvg7392 , weightedAvg6456 , UVmixDistance636);
			half2 ifLocalVar6662 = 0;
			UNITY_BRANCH 
			if( _Texture_10_Triplanar == 1.0 )
				ifLocalVar6662 = lerpResult5870;
			else
				ifLocalVar6662 = lerpResult6664;
			half2 ifLocalVar7769 = 0;
			UNITY_BRANCH 
			if( _Texture_10_H_AO_Index > -1.0 )
				ifLocalVar7769 = ifLocalVar6662;
			half2 Texture_10_H5872 = ifLocalVar7769;
			float2 break7916 = Texture_10_H5872;
			float temp_output_6150_0 = ( _Texture_10_Heightmap_Depth * pow( break7916.x , _Texture_10_Height_Contrast ) );
			float temp_output_4739_0 = ( 1.0 / _Texture_11_Tiling );
			float2 appendResult4741 = (half2(temp_output_4739_0 , temp_output_4739_0));
			float2 temp_output_4817_0 = ( Top_Bottom1999 * appendResult4741 );
			float4 texArray7406 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4817_0, _Texture_11_H_AO_Index)  );
			float2 appendResult7868 = (half2(texArray7406.y , texArray7406.w));
			float2 temp_output_4904_0 = ( temp_output_4817_0 / _Texture_11_Far_Multiplier );
			float4 texArray5891 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4904_0, _Texture_11_H_AO_Index)  );
			float2 appendResult7951 = (half2(texArray5891.y , 1.0));
			float2 lerpResult6658 = lerp( appendResult7868 , appendResult7951 , UVmixDistance636);
			float2 temp_output_4748_0 = ( Front_Back1991 * appendResult4741 );
			float4 texArray7407 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4748_0, _Texture_11_H_AO_Index)  );
			float2 appendResult7870 = (half2(texArray7407.y , texArray7407.w));
			float2 temp_output_4795_0 = ( Left_Right2003 * appendResult4741 );
			float4 texArray7401 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4795_0, _Texture_11_H_AO_Index)  );
			float2 appendResult7869 = (half2(texArray7401.y , texArray7401.w));
			float3 weightedBlendVar7404 = BlendComponents91;
			float2 weightedAvg7404 = ( ( weightedBlendVar7404.x*appendResult7870 + weightedBlendVar7404.y*appendResult7868 + weightedBlendVar7404.z*appendResult7869 )/( weightedBlendVar7404.x + weightedBlendVar7404.y + weightedBlendVar7404.z ) );
			float2 temp_output_4890_0 = ( temp_output_4748_0 / _Texture_11_Far_Multiplier );
			float4 texArray5876 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4890_0, _Texture_11_H_AO_Index)  );
			float2 appendResult7950 = (half2(texArray5876.y , 1.0));
			float2 temp_output_4892_0 = ( temp_output_4795_0 / _Texture_11_Far_Multiplier );
			float4 texArray5886 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4892_0, _Texture_11_H_AO_Index)  );
			float2 appendResult7952 = (half2(texArray5886.y , 1.0));
			float3 weightedBlendVar6463 = BlendComponents91;
			float2 weightedAvg6463 = ( ( weightedBlendVar6463.x*appendResult7950 + weightedBlendVar6463.y*appendResult7951 + weightedBlendVar6463.z*appendResult7952 )/( weightedBlendVar6463.x + weightedBlendVar6463.y + weightedBlendVar6463.z ) );
			float2 lerpResult5910 = lerp( weightedAvg7404 , weightedAvg6463 , UVmixDistance636);
			half2 ifLocalVar6656 = 0;
			UNITY_BRANCH 
			if( _Texture_11_Triplanar == 1.0 )
				ifLocalVar6656 = lerpResult5910;
			else
				ifLocalVar6656 = lerpResult6658;
			half2 ifLocalVar7767 = 0;
			UNITY_BRANCH 
			if( _Texture_11_H_AO_Index > -1.0 )
				ifLocalVar7767 = ifLocalVar6656;
			half2 Texture_11_H5912 = ifLocalVar7767;
			float2 break7917 = Texture_11_H5912;
			float temp_output_6156_0 = ( _Texture_11_Heightmap_Depth * pow( break7917.x , _Texture_11_Height_Contrast ) );
			float temp_output_4745_0 = ( 1.0 / _Texture_12_Tiling );
			float2 appendResult4751 = (half2(temp_output_4745_0 , temp_output_4745_0));
			float2 temp_output_4849_0 = ( Top_Bottom1999 * appendResult4751 );
			float4 texArray7418 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4849_0, _Texture_12_H_AO_Index)  );
			float2 appendResult7874 = (half2(texArray7418.y , texArray7418.w));
			float2 temp_output_4932_0 = ( temp_output_4849_0 / _Texture_12_Far_Multiplier );
			float4 texArray5931 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4932_0, _Texture_12_H_AO_Index)  );
			float2 appendResult7954 = (half2(texArray5931.y , 1.0));
			float2 lerpResult6676 = lerp( appendResult7874 , appendResult7954 , UVmixDistance636);
			float2 temp_output_4758_0 = ( Front_Back1991 * appendResult4751 );
			float4 texArray7419 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4758_0, _Texture_12_H_AO_Index)  );
			float2 appendResult7876 = (half2(texArray7419.y , texArray7419.w));
			float2 temp_output_4830_0 = ( Left_Right2003 * appendResult4751 );
			float4 texArray7413 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4830_0, _Texture_12_H_AO_Index)  );
			float2 appendResult7875 = (half2(texArray7413.y , texArray7413.w));
			float3 weightedBlendVar7416 = BlendComponents91;
			float2 weightedAvg7416 = ( ( weightedBlendVar7416.x*appendResult7876 + weightedBlendVar7416.y*appendResult7874 + weightedBlendVar7416.z*appendResult7875 )/( weightedBlendVar7416.x + weightedBlendVar7416.y + weightedBlendVar7416.z ) );
			float2 temp_output_4916_0 = ( temp_output_4758_0 / _Texture_12_Far_Multiplier );
			float4 texArray5916 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4916_0, _Texture_12_H_AO_Index)  );
			float2 appendResult7953 = (half2(texArray5916.y , 1.0));
			float2 temp_output_4910_0 = ( temp_output_4830_0 / _Texture_12_Far_Multiplier );
			float4 texArray5926 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4910_0, _Texture_12_H_AO_Index)  );
			float2 appendResult7955 = (half2(texArray5926.y , 1.0));
			float3 weightedBlendVar6470 = BlendComponents91;
			float2 weightedAvg6470 = ( ( weightedBlendVar6470.x*appendResult7953 + weightedBlendVar6470.y*appendResult7954 + weightedBlendVar6470.z*appendResult7955 )/( weightedBlendVar6470.x + weightedBlendVar6470.y + weightedBlendVar6470.z ) );
			float2 lerpResult5950 = lerp( weightedAvg7416 , weightedAvg6470 , UVmixDistance636);
			half2 ifLocalVar6674 = 0;
			UNITY_BRANCH 
			if( _Texture_12_Triplanar == 1.0 )
				ifLocalVar6674 = lerpResult5950;
			else
				ifLocalVar6674 = lerpResult6676;
			half2 ifLocalVar7765 = 0;
			UNITY_BRANCH 
			if( _Texture_12_H_AO_Index > -1.0 )
				ifLocalVar7765 = ifLocalVar6674;
			half2 Texture_12_H5952 = ifLocalVar7765;
			float2 break7918 = Texture_12_H5952;
			float lerpResult7254 = lerp( _Texture_12_Heightblend_Close , _Texture_12_Heightblend_Far , UVmixDistance636);
			float HeightMask6228 = saturate(pow(((( _Texture_12_Heightmap_Depth * pow( break7918.x , _Texture_12_Height_Contrast ) )*Splat3_A2540)*4)+(Splat3_A2540*2),lerpResult7254));
			float4 layeredBlendVar7777 = tex2DNode4370;
			float layeredBlend7777 = ( lerp( lerp( lerp( lerp( layeredBlend7776 , temp_output_6144_0 , layeredBlendVar7777.x ) , temp_output_6150_0 , layeredBlendVar7777.y ) , temp_output_6156_0 , layeredBlendVar7777.z ) , HeightMask6228 , layeredBlendVar7777.w ) );
			float temp_output_5125_0 = ( 1.0 / _Texture_13_Tiling );
			float2 appendResult5027 = (half2(temp_output_5125_0 , temp_output_5125_0));
			float2 temp_output_5037_0 = ( Top_Bottom1999 * appendResult5027 );
			float4 texArray7430 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5037_0, _Texture_13_H_AO_Index)  );
			float2 appendResult7880 = (half2(texArray7430.y , texArray7430.w));
			float2 temp_output_5112_0 = ( temp_output_5037_0 / _Texture_13_Far_Multiplier );
			float4 texArray5971 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5112_0, _Texture_13_H_AO_Index)  );
			float2 appendResult7957 = (half2(texArray5971.y , 1.0));
			float2 lerpResult6682 = lerp( appendResult7880 , appendResult7957 , UVmixDistance636);
			float2 temp_output_5025_0 = ( Front_Back1991 * appendResult5027 );
			float4 texArray7431 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5025_0, _Texture_13_H_AO_Index)  );
			float2 appendResult7882 = (half2(texArray7431.y , texArray7431.w));
			float2 temp_output_5035_0 = ( Left_Right2003 * appendResult5027 );
			float4 texArray7425 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5035_0, _Texture_13_H_AO_Index)  );
			float2 appendResult7881 = (half2(texArray7425.y , texArray7425.w));
			float3 weightedBlendVar7428 = BlendComponents91;
			float2 weightedAvg7428 = ( ( weightedBlendVar7428.x*appendResult7882 + weightedBlendVar7428.y*appendResult7880 + weightedBlendVar7428.z*appendResult7881 )/( weightedBlendVar7428.x + weightedBlendVar7428.y + weightedBlendVar7428.z ) );
			float2 temp_output_5123_0 = ( temp_output_5025_0 / _Texture_13_Far_Multiplier );
			float4 texArray5956 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5123_0, _Texture_13_H_AO_Index)  );
			float2 appendResult7956 = (half2(texArray5956.y , 1.0));
			float2 temp_output_5124_0 = ( temp_output_5035_0 / _Texture_13_Far_Multiplier );
			float4 texArray5966 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5124_0, _Texture_13_H_AO_Index)  );
			float2 appendResult7958 = (half2(texArray5966.y , 1.0));
			float3 weightedBlendVar6477 = BlendComponents91;
			float2 weightedAvg6477 = ( ( weightedBlendVar6477.x*appendResult7956 + weightedBlendVar6477.y*appendResult7957 + weightedBlendVar6477.z*appendResult7958 )/( weightedBlendVar6477.x + weightedBlendVar6477.y + weightedBlendVar6477.z ) );
			float2 lerpResult5990 = lerp( weightedAvg7428 , weightedAvg6477 , UVmixDistance636);
			half2 ifLocalVar6680 = 0;
			UNITY_BRANCH 
			if( _Texture_13_Triplanar == 1.0 )
				ifLocalVar6680 = lerpResult5990;
			else
				ifLocalVar6680 = lerpResult6682;
			half2 ifLocalVar7761 = 0;
			UNITY_BRANCH 
			if( _Texture_13_H_AO_Index > -1.0 )
				ifLocalVar7761 = ifLocalVar6680;
			half2 Texture_13_H5992 = ifLocalVar7761;
			float2 break7920 = Texture_13_H5992;
			float temp_output_6168_0 = ( _Texture_13_Heightmap_Depth * pow( break7920.x , _Texture_13_Height_Contrast ) );
			float temp_output_5006_0 = ( 1.0 / _Texture_14_Tiling );
			float2 appendResult5033 = (half2(temp_output_5006_0 , temp_output_5006_0));
			float2 temp_output_5022_0 = ( Top_Bottom1999 * appendResult5033 );
			float4 texArray7442 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5022_0, _Texture_14_H_AO_Index)  );
			float2 appendResult7886 = (half2(texArray7442.y , texArray7442.w));
			float2 temp_output_5172_0 = ( temp_output_5022_0 / _Texture_14_Far_Multiplier );
			float4 texArray6011 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5172_0, _Texture_14_H_AO_Index)  );
			float2 appendResult7960 = (half2(texArray6011.y , 1.0));
			float2 lerpResult6688 = lerp( appendResult7886 , appendResult7960 , UVmixDistance636);
			float2 temp_output_5009_0 = ( Front_Back1991 * appendResult5033 );
			float4 texArray7443 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5009_0, _Texture_14_H_AO_Index)  );
			float2 appendResult7888 = (half2(texArray7443.y , texArray7443.w));
			float2 temp_output_5010_0 = ( Left_Right2003 * appendResult5033 );
			float4 texArray7437 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5010_0, _Texture_14_H_AO_Index)  );
			float2 appendResult7887 = (half2(texArray7437.y , texArray7437.w));
			float3 weightedBlendVar7440 = BlendComponents91;
			float2 weightedAvg7440 = ( ( weightedBlendVar7440.x*appendResult7888 + weightedBlendVar7440.y*appendResult7886 + weightedBlendVar7440.z*appendResult7887 )/( weightedBlendVar7440.x + weightedBlendVar7440.y + weightedBlendVar7440.z ) );
			float2 temp_output_5238_0 = ( temp_output_5009_0 / _Texture_14_Far_Multiplier );
			float4 texArray5996 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5238_0, _Texture_14_H_AO_Index)  );
			float2 appendResult7959 = (half2(texArray5996.y , 1.0));
			float2 temp_output_5233_0 = ( temp_output_5010_0 / _Texture_14_Far_Multiplier );
			float4 texArray6006 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5233_0, _Texture_14_H_AO_Index)  );
			float2 appendResult7961 = (half2(texArray6006.y , 1.0));
			float3 weightedBlendVar6484 = BlendComponents91;
			float2 weightedAvg6484 = ( ( weightedBlendVar6484.x*appendResult7959 + weightedBlendVar6484.y*appendResult7960 + weightedBlendVar6484.z*appendResult7961 )/( weightedBlendVar6484.x + weightedBlendVar6484.y + weightedBlendVar6484.z ) );
			float2 lerpResult6030 = lerp( weightedAvg7440 , weightedAvg6484 , UVmixDistance636);
			half2 ifLocalVar6686 = 0;
			UNITY_BRANCH 
			if( _Texture_14_Triplanar == 1.0 )
				ifLocalVar6686 = lerpResult6030;
			else
				ifLocalVar6686 = lerpResult6688;
			half2 ifLocalVar7759 = 0;
			UNITY_BRANCH 
			if( _Texture_14_H_AO_Index > -1.0 )
				ifLocalVar7759 = ifLocalVar6686;
			half2 Texture_14_H6032 = ifLocalVar7759;
			float2 break7921 = Texture_14_H6032;
			float temp_output_6174_0 = ( _Texture_14_Heightmap_Depth * pow( break7921.x , _Texture_14_Height_Contrast ) );
			float temp_output_5210_0 = ( 1.0 / _Texture_15_Tiling );
			float2 appendResult5212 = (half2(temp_output_5210_0 , temp_output_5210_0));
			float2 temp_output_5226_0 = ( Top_Bottom1999 * appendResult5212 );
			float4 texArray7454 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5226_0, _Texture_15_H_AO_Index)  );
			float2 appendResult7892 = (half2(texArray7454.y , texArray7454.w));
			float2 temp_output_5190_0 = ( temp_output_5226_0 / _Texture_15_Far_Multiplier );
			float4 texArray6051 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5190_0, _Texture_15_H_AO_Index)  );
			float2 appendResult7963 = (half2(texArray6051.y , 1.0));
			float2 lerpResult6694 = lerp( appendResult7892 , appendResult7963 , UVmixDistance636);
			float2 temp_output_5213_0 = ( Front_Back1991 * appendResult5212 );
			float4 texArray7455 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5213_0, _Texture_15_H_AO_Index)  );
			float2 appendResult7894 = (half2(texArray7455.y , texArray7455.w));
			float2 temp_output_5224_0 = ( Left_Right2003 * appendResult5212 );
			float4 texArray7449 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5224_0, _Texture_15_H_AO_Index)  );
			float2 appendResult7893 = (half2(texArray7449.y , texArray7449.w));
			float3 weightedBlendVar7452 = BlendComponents91;
			float2 weightedAvg7452 = ( ( weightedBlendVar7452.x*appendResult7894 + weightedBlendVar7452.y*appendResult7892 + weightedBlendVar7452.z*appendResult7893 )/( weightedBlendVar7452.x + weightedBlendVar7452.y + weightedBlendVar7452.z ) );
			float2 temp_output_5248_0 = ( temp_output_5213_0 / _Texture_15_Far_Multiplier );
			float4 texArray6036 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5248_0, _Texture_15_H_AO_Index)  );
			float2 appendResult7962 = (half2(texArray6036.y , 1.0));
			float2 temp_output_5249_0 = ( temp_output_5224_0 / _Texture_15_Far_Multiplier );
			float4 texArray6046 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5249_0, _Texture_15_H_AO_Index)  );
			float2 appendResult7964 = (half2(texArray6046.y , 1.0));
			float3 weightedBlendVar6491 = BlendComponents91;
			float2 weightedAvg6491 = ( ( weightedBlendVar6491.x*appendResult7962 + weightedBlendVar6491.y*appendResult7963 + weightedBlendVar6491.z*appendResult7964 )/( weightedBlendVar6491.x + weightedBlendVar6491.y + weightedBlendVar6491.z ) );
			float2 lerpResult6070 = lerp( weightedAvg7452 , weightedAvg6491 , UVmixDistance636);
			half2 ifLocalVar6692 = 0;
			UNITY_BRANCH 
			if( _Texture_15_Triplanar == 1.0 )
				ifLocalVar6692 = lerpResult6070;
			else
				ifLocalVar6692 = lerpResult6694;
			half2 ifLocalVar7757 = 0;
			UNITY_BRANCH 
			if( _Texture_15_H_AO_Index > -1.0 )
				ifLocalVar7757 = ifLocalVar6692;
			half2 Texture_15_H6072 = ifLocalVar7757;
			float2 break7922 = Texture_15_H6072;
			float temp_output_6180_0 = ( _Texture_15_Heightmap_Depth * pow( break7922.x , _Texture_15_Height_Contrast ) );
			float temp_output_5075_0 = ( 1.0 / _Texture_16_Tiling );
			float2 appendResult5078 = (half2(temp_output_5075_0 , temp_output_5075_0));
			float2 temp_output_5083_0 = ( Top_Bottom1999 * appendResult5078 );
			float4 texArray7466 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5083_0, _Texture_16_H_AO_Index)  );
			float2 appendResult7898 = (half2(texArray7466.y , texArray7466.w));
			float2 temp_output_5153_0 = ( temp_output_5083_0 / _Texture_16_Far_Multiplier );
			float4 texArray6091 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5153_0, _Texture_16_H_AO_Index)  );
			float2 appendResult7966 = (half2(texArray6091.y , 1.0));
			float2 lerpResult6700 = lerp( appendResult7898 , appendResult7966 , UVmixDistance636);
			float2 temp_output_5079_0 = ( Front_Back1991 * appendResult5078 );
			float4 texArray7467 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5079_0, _Texture_16_H_AO_Index)  );
			float2 appendResult7900 = (half2(texArray7467.y , texArray7467.w));
			float2 temp_output_5085_0 = ( Left_Right2003 * appendResult5078 );
			float4 texArray7461 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5085_0, _Texture_16_H_AO_Index)  );
			float2 appendResult7899 = (half2(texArray7461.y , texArray7461.w));
			float3 weightedBlendVar7464 = BlendComponents91;
			float2 weightedAvg7464 = ( ( weightedBlendVar7464.x*appendResult7900 + weightedBlendVar7464.y*appendResult7898 + weightedBlendVar7464.z*appendResult7899 )/( weightedBlendVar7464.x + weightedBlendVar7464.y + weightedBlendVar7464.z ) );
			float2 temp_output_5147_0 = ( temp_output_5079_0 / _Texture_16_Far_Multiplier );
			float4 texArray6076 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5147_0, _Texture_16_H_AO_Index)  );
			float2 appendResult7965 = (half2(texArray6076.y , 1.0));
			float2 temp_output_5146_0 = ( temp_output_5085_0 / _Texture_16_Far_Multiplier );
			float4 texArray6086 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5146_0, _Texture_16_H_AO_Index)  );
			float2 appendResult7967 = (half2(texArray6086.y , 1.0));
			float3 weightedBlendVar6498 = BlendComponents91;
			float2 weightedAvg6498 = ( ( weightedBlendVar6498.x*appendResult7965 + weightedBlendVar6498.y*appendResult7966 + weightedBlendVar6498.z*appendResult7967 )/( weightedBlendVar6498.x + weightedBlendVar6498.y + weightedBlendVar6498.z ) );
			float2 lerpResult6110 = lerp( weightedAvg7464 , weightedAvg6498 , UVmixDistance636);
			half2 ifLocalVar6698 = 0;
			UNITY_BRANCH 
			if( _Texture_16_Triplanar == 1.0 )
				ifLocalVar6698 = lerpResult6110;
			else
				ifLocalVar6698 = lerpResult6700;
			half2 ifLocalVar7755 = 0;
			UNITY_BRANCH 
			if( _Texture_16_H_AO_Index > -1.0 )
				ifLocalVar7755 = ifLocalVar6698;
			half2 Texture_16_H6112 = ifLocalVar7755;
			float2 break7923 = Texture_16_H6112;
			float temp_output_6186_0 = ( _Texture_16_Heightmap_Depth * pow( break7923.x , _Texture_16_Height_Contrast ) );
			float4 layeredBlendVar7778 = tex2DNode4371;
			float layeredBlend7778 = ( lerp( lerp( lerp( lerp( layeredBlend7777 , temp_output_6168_0 , layeredBlendVar7778.x ) , temp_output_6174_0 , layeredBlendVar7778.y ) , temp_output_6180_0 , layeredBlendVar7778.z ) , temp_output_6186_0 , layeredBlendVar7778.w ) );
			float2 temp_output_3893_0 = ( Top_Bottom1999 / _Snow_Tiling );
			float4 texArray7491 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3893_0, _Texture_Snow_H_AO_Index)  );
			float4 texArray6270 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(( temp_output_3893_0 / _Snow_Tiling_Far_Multiplier ), _Texture_Snow_H_AO_Index)  );
			float lerpResult7273 = lerp( texArray7491.y , texArray6270.y , UVmixDistance636);
			half ifLocalVar7801 = 0;
			UNITY_BRANCH 
			if( _Texture_Snow_H_AO_Index > -1.0 )
				ifLocalVar7801 = ( pow( lerpResult7273 , _Snow_Height_Contrast ) * _Snow_Heightmap_Depth );
			float temp_output_6545_0 = ( layeredBlend7778 + ifLocalVar7801 );
			float clampResult6546 = clamp( temp_output_6545_0 , 0.0 , temp_output_6545_0 );
			float clampResult7176 = clamp( clampResult6546 , 0.0 , 1.0 );
			float simplePerlin2D8071 = snoise( ( Top_Bottom1999 * _Snow_Noise_Tiling ) );
			float lerpResult4310 = lerp( 1.0 , simplePerlin2D8071 , ( _Snow_Noise_Power * 0.1 ));
			float clampResult1354 = clamp( ase_worldNormal.y , 0.0 , 0.9999 );
			float temp_output_1349_0 = ( _Snow_Maximum_Angle / 90.0 );
			float clampResult1347 = clamp( ( clampResult1354 - ( 1.0 - temp_output_1349_0 ) ) , 0.0 , 2.0 );
			half SnowSlope1352 = ( clampResult1347 * ( 1.0 / temp_output_1349_0 ) );
			float clampResult6569 = clamp( ( 1.0 - ( _Snow_Maximum_Angle_Hardness * 0.05 ) ) , 0.01 , 1.0 );
			float clampResult4146 = clamp( pow( ( ( _Snow_Amount * ( 0.1 - ( _Snow_Maximum_Angle_Hardness * 0.005 ) ) ) * SnowSlope1352 ) , clampResult6569 ) , 0.0 , 1.0 );
			float temp_output_3751_0 = ( ( 1.0 - _Snow_Min_Height ) + ase_worldPos.y );
			float clampResult4220 = clamp( ( temp_output_3751_0 + 1.0 ) , 0.0 , 1.0 );
			float clampResult4260 = clamp( ( ( 1.0 - ( ( temp_output_3751_0 + _Snow_Min_Height_Blending ) / temp_output_3751_0 ) ) + -0.5 ) , 0.0 , 1.0 );
			float clampResult4263 = clamp( ( clampResult4220 + clampResult4260 ) , 0.0 , 1.0 );
			float lerpResult3759 = lerp( 0.0 , ( ( _Snow_Amount * lerpResult4310 ) * clampResult4146 ) , clampResult4263);
			float clampResult4298 = clamp( lerpResult3759 , 0.0 , 2.0 );
			float lerpResult7277 = lerp( _Snow_Heightblend_Close , _Snow_Heightblend_Far , UVmixDistance636);
			float HeightMask6539 = saturate(pow(((( 1.0 - clampResult7176 )*( clampResult4298 * ( 1.0 - ( ( _Texture_16_Snow_Reduction * Splat4_A2546 ) + ( ( _Texture_15_Snow_Reduction * Splat4_B2545 ) + ( ( ( _Texture_13_Snow_Reduction * Splat4_R2543 ) + ( ( _Texture_12_Snow_Reduction * Splat3_A2540 ) + ( ( _Texture_11_Snow_Reduction * Splat3_B2539 ) + ( ( ( _Texture_9_Snow_Reduction * Splat3_R2537 ) + ( ( _Texture_8_Snow_Reduction * Splat2_A2109 ) + ( ( _Texture_7_Snow_Reduction * Splat2_B2108 ) + ( ( ( _Texture_5_Snow_Reduction * Splat2_R2106 ) + ( ( _Texture_1_Snow_Reduction * Splat1_R1438 ) + ( ( _Texture_2_Snow_Reduction * Splat1_G1441 ) + ( ( _Texture_3_Snow_Reduction * Splat1_B1442 ) + ( _Texture_4_Snow_Reduction * Splat1_A1491 ) ) ) ) ) + ( _Texture_6_Snow_Reduction * Splat2_G2107 ) ) ) ) ) + ( _Texture_10_Snow_Reduction * Splat3_G2538 ) ) ) ) ) + ( _Texture_14_Snow_Reduction * Splat4_G2544 ) ) ) ) ) ))*4)+(( clampResult4298 * ( 1.0 - ( ( _Texture_16_Snow_Reduction * Splat4_A2546 ) + ( ( _Texture_15_Snow_Reduction * Splat4_B2545 ) + ( ( ( _Texture_13_Snow_Reduction * Splat4_R2543 ) + ( ( _Texture_12_Snow_Reduction * Splat3_A2540 ) + ( ( _Texture_11_Snow_Reduction * Splat3_B2539 ) + ( ( ( _Texture_9_Snow_Reduction * Splat3_R2537 ) + ( ( _Texture_8_Snow_Reduction * Splat2_A2109 ) + ( ( _Texture_7_Snow_Reduction * Splat2_B2108 ) + ( ( ( _Texture_5_Snow_Reduction * Splat2_R2106 ) + ( ( _Texture_1_Snow_Reduction * Splat1_R1438 ) + ( ( _Texture_2_Snow_Reduction * Splat1_G1441 ) + ( ( _Texture_3_Snow_Reduction * Splat1_B1442 ) + ( _Texture_4_Snow_Reduction * Splat1_A1491 ) ) ) ) ) + ( _Texture_6_Snow_Reduction * Splat2_G2107 ) ) ) ) ) + ( _Texture_10_Snow_Reduction * Splat3_G2538 ) ) ) ) ) + ( _Texture_14_Snow_Reduction * Splat4_G2544 ) ) ) ) ) )*2),lerpResult7277));
			float3 lerpResult6503 = lerp( lerpResult3776 , lerpResult3906 , HeightMask6539);
			float lerpResult7258 = lerp( _Texture_13_Heightblend_Close , _Texture_13_Heightblend_Far , UVmixDistance636);
			float HeightMask6231 = saturate(pow(((temp_output_6168_0*Splat4_R2543)*4)+(Splat4_R2543*2),lerpResult7258));
			float lerpResult7261 = lerp( _Texture_14_Heightblend_Close , _Texture_14_Heightblend_Far , UVmixDistance636);
			float HeightMask6234 = saturate(pow(((temp_output_6174_0*Splat4_G2544)*4)+(Splat4_G2544*2),lerpResult7261));
			float lerpResult7265 = lerp( _Texture_15_Heightblend_Close , _Texture_15_Heightblend_Far , UVmixDistance636);
			float HeightMask6237 = saturate(pow(((temp_output_6180_0*Splat4_B2545)*4)+(Splat4_B2545*2),lerpResult7265));
			float lerpResult7269 = lerp( _Texture_16_Heightblend_Close , _Texture_16_Heightblend_Far , UVmixDistance636);
			float HeightMask6240 = saturate(pow(((temp_output_6186_0*Splat4_A2546)*4)+(Splat4_A2546*2),lerpResult7269));
			float4 appendResult6533 = (half4(HeightMask6231 , HeightMask6234 , HeightMask6237 , HeightMask6240));
			float lerpResult7242 = lerp( _Texture_9_Heightblend_Close , _Texture_9_Heightblend_Far , UVmixDistance636);
			float HeightMask6219 = saturate(pow(((temp_output_6144_0*Splat3_R2537)*4)+(Splat3_R2537*2),lerpResult7242));
			float lerpResult7246 = lerp( _Texture_10_Heightblend_Close , _Texture_10_Heightblend_Far , UVmixDistance636);
			float HeightMask6222 = saturate(pow(((temp_output_6150_0*Splat3_G2538)*4)+(Splat3_G2538*2),lerpResult7246));
			float lerpResult7250 = lerp( _Texture_11_Heightblend_Close , _Texture_11_Heightblend_Far , UVmixDistance636);
			float HeightMask6225 = saturate(pow(((temp_output_6156_0*Splat3_B2539)*4)+(Splat3_B2539*2),lerpResult7250));
			float4 appendResult6529 = (half4(HeightMask6219 , HeightMask6222 , HeightMask6225 , HeightMask6228));
			float lerpResult7226 = lerp( _Texture_5_Heightblend_Close , _Texture_5_Heightblend_Far , UVmixDistance636);
			float HeightMask6205 = saturate(pow(((temp_output_6120_0*Splat2_R2106)*4)+(Splat2_R2106*2),lerpResult7226));
			float lerpResult7230 = lerp( _Texture_6_Heightblend_Close , _Texture_6_Heightblend_Far , UVmixDistance636);
			float HeightMask6208 = saturate(pow(((temp_output_6126_0*Splat2_G2107)*4)+(Splat2_G2107*2),lerpResult7230));
			float lerpResult7234 = lerp( _Texture_7_Heightblend_Close , _Texture_7_Heightblend_Far , UVmixDistance636);
			float HeightMask6211 = saturate(pow(((temp_output_6132_0*Splat2_B2108)*4)+(Splat2_B2108*2),lerpResult7234));
			float lerpResult7238 = lerp( _Texture_8_Heightblend_Close , _Texture_8_Heightblend_Far , UVmixDistance636);
			float HeightMask6214 = saturate(pow(((temp_output_6138_0*Splat2_A2109)*4)+(Splat2_A2109*2),lerpResult7238));
			float4 appendResult6524 = (half4(HeightMask6205 , HeightMask6208 , HeightMask6211 , HeightMask6214));
			float lerpResult7218 = lerp( _Texture_1_Heightblend_Close , _Texture_1_Heightblend_Far , UVmixDistance636);
			float HeightMask6196 = saturate(pow(((temp_output_5544_0*Splat1_R1438)*4)+(Splat1_R1438*2),lerpResult7218));
			float lerpResult7222 = lerp( _Texture_2_Heightblend_Close , _Texture_2_Heightblend_Far , UVmixDistance636);
			float HeightMask6515 = saturate(pow(((temp_output_5545_0*Splat1_G1441)*4)+(Splat1_G1441*2),lerpResult7222));
			float lerpResult7214 = lerp( _Texture_3_Heightblend_Close , _Texture_3_Heightblend_Far , UVmixDistance636);
			float HeightMask6516 = saturate(pow(((temp_output_5590_0*Splat1_B1442)*4)+(Splat1_B1442*2),lerpResult7214));
			float lerpResult7211 = lerp( _Texture_4_Heightblend_Close , _Texture_4_Heightblend_Far , UVmixDistance636);
			float HeightMask6203 = saturate(pow(((temp_output_6118_0*Splat1_A1491)*4)+(Splat1_A1491*2),lerpResult7211));
			float4 appendResult6517 = (half4(HeightMask6196 , HeightMask6515 , HeightMask6516 , HeightMask6203));
			float4 texArray3300 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3275_0, _Texture_1_Normal_Index)  );
			float2 appendResult11_g933 = (half2(texArray3300.w , texArray3300.y));
			float2 temp_output_4_0_g933 = ( ( ( appendResult11_g933 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_1_Normal_Power );
			float2 break8_g933 = temp_output_4_0_g933;
			float dotResult5_g933 = dot( temp_output_4_0_g933 , temp_output_4_0_g933 );
			float temp_output_9_0_g933 = sqrt( ( 1.0 - saturate( dotResult5_g933 ) ) );
			float3 appendResult20_g933 = (half3(break8_g933.x , break8_g933.y , temp_output_9_0_g933));
			float3 temp_output_6989_0 = appendResult20_g933;
			float4 texArray3299 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3279_0, _Texture_1_Normal_Index)  );
			float2 appendResult11_g442 = (half2(texArray3299.w , texArray3299.y));
			float2 temp_output_4_0_g442 = ( ( ( appendResult11_g442 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_1_Normal_Power * -1.0 ) );
			float2 break8_g442 = temp_output_4_0_g442;
			float dotResult5_g442 = dot( temp_output_4_0_g442 , temp_output_4_0_g442 );
			float temp_output_9_0_g442 = sqrt( ( 1.0 - saturate( dotResult5_g442 ) ) );
			float3 appendResult21_g442 = (half3(break8_g442.y , break8_g442.x , temp_output_9_0_g442));
			float3 appendResult6857 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float4 texArray3301 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3277_0, _Texture_1_Normal_Index)  );
			float2 appendResult11_g448 = (half2(texArray3301.w , texArray3301.y));
			float2 temp_output_4_0_g448 = ( ( ( appendResult11_g448 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_1_Normal_Power );
			float2 break8_g448 = temp_output_4_0_g448;
			float dotResult5_g448 = dot( temp_output_4_0_g448 , temp_output_4_0_g448 );
			float temp_output_9_0_g448 = sqrt( ( 1.0 - saturate( dotResult5_g448 ) ) );
			float3 appendResult20_g448 = (half3(break8_g448.x , break8_g448.y , temp_output_9_0_g448));
			float3 appendResult6860 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar6393 = BlendComponents91;
			float3 weightedAvg6393 = ( ( weightedBlendVar6393.x*( appendResult21_g442 * appendResult6857 ) + weightedBlendVar6393.y*temp_output_6989_0 + weightedBlendVar6393.z*( appendResult20_g448 * appendResult6860 ) )/( weightedBlendVar6393.x + weightedBlendVar6393.y + weightedBlendVar6393.z ) );
			half3 ifLocalVar6606 = 0;
			UNITY_BRANCH 
			if( _Texture_1_Triplanar == 1.0 )
				ifLocalVar6606 = weightedAvg6393;
			else
				ifLocalVar6606 = temp_output_6989_0;
			half3 EmptyNRM7781 = half3(0,0,1);
			half3 ifLocalVar7594 = 0;
			UNITY_BRANCH 
			if( _Texture_1_Normal_Index <= -1.0 )
				ifLocalVar7594 = EmptyNRM7781;
			else
				ifLocalVar7594 = ifLocalVar6606;
			half3 Normal_1569 = ifLocalVar7594;
			float4 texArray3350 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3343_0, _Texture_2_Normal_Index)  );
			float2 appendResult11_g932 = (half2(texArray3350.w , texArray3350.y));
			float2 temp_output_4_0_g932 = ( ( ( appendResult11_g932 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_2_Normal_Power );
			float2 break8_g932 = temp_output_4_0_g932;
			float dotResult5_g932 = dot( temp_output_4_0_g932 , temp_output_4_0_g932 );
			float temp_output_9_0_g932 = sqrt( ( 1.0 - saturate( dotResult5_g932 ) ) );
			float3 appendResult20_g932 = (half3(break8_g932.x , break8_g932.y , temp_output_9_0_g932));
			float3 temp_output_6992_0 = appendResult20_g932;
			float4 texArray3384 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3344_0, _Texture_2_Normal_Index)  );
			float2 appendResult11_g444 = (half2(texArray3384.w , texArray3384.y));
			float2 temp_output_4_0_g444 = ( ( ( appendResult11_g444 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_2_Normal_Power * -1.0 ) );
			float2 break8_g444 = temp_output_4_0_g444;
			float dotResult5_g444 = dot( temp_output_4_0_g444 , temp_output_4_0_g444 );
			float temp_output_9_0_g444 = sqrt( ( 1.0 - saturate( dotResult5_g444 ) ) );
			float3 appendResult21_g444 = (half3(break8_g444.y , break8_g444.x , temp_output_9_0_g444));
			float3 appendResult6864 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float4 texArray3351 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3379_0, _Texture_2_Normal_Index)  );
			float2 appendResult11_g445 = (half2(texArray3351.w , texArray3351.y));
			float2 temp_output_4_0_g445 = ( ( ( appendResult11_g445 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_2_Normal_Power );
			float2 break8_g445 = temp_output_4_0_g445;
			float dotResult5_g445 = dot( temp_output_4_0_g445 , temp_output_4_0_g445 );
			float temp_output_9_0_g445 = sqrt( ( 1.0 - saturate( dotResult5_g445 ) ) );
			float3 appendResult20_g445 = (half3(break8_g445.x , break8_g445.y , temp_output_9_0_g445));
			float3 appendResult6867 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar6401 = BlendComponents91;
			float3 weightedAvg6401 = ( ( weightedBlendVar6401.x*( appendResult21_g444 * appendResult6864 ) + weightedBlendVar6401.y*temp_output_6992_0 + weightedBlendVar6401.z*( appendResult20_g445 * appendResult6867 ) )/( weightedBlendVar6401.x + weightedBlendVar6401.y + weightedBlendVar6401.z ) );
			half3 ifLocalVar6613 = 0;
			UNITY_BRANCH 
			if( _Texture_2_Triplanar == 1.0 )
				ifLocalVar6613 = weightedAvg6401;
			else
				ifLocalVar6613 = temp_output_6992_0;
			half3 ifLocalVar7600 = 0;
			UNITY_BRANCH 
			if( _Texture_2_Normal_Index <= -1.0 )
				ifLocalVar7600 = EmptyNRM7781;
			else
				ifLocalVar7600 = ifLocalVar6613;
			half3 Normal_23361 = ifLocalVar7600;
			float4 texArray3416 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3410_0, _Texture_3_Normal_Index)  );
			float2 appendResult11_g939 = (half2(texArray3416.w , texArray3416.y));
			float2 temp_output_4_0_g939 = ( ( ( appendResult11_g939 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_3_Normal_Power );
			float2 break8_g939 = temp_output_4_0_g939;
			float dotResult5_g939 = dot( temp_output_4_0_g939 , temp_output_4_0_g939 );
			float temp_output_9_0_g939 = sqrt( ( 1.0 - saturate( dotResult5_g939 ) ) );
			float3 appendResult20_g939 = (half3(break8_g939.x , break8_g939.y , temp_output_9_0_g939));
			float3 temp_output_6995_0 = appendResult20_g939;
			float4 texArray3445 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3411_0, _Texture_3_Normal_Index)  );
			float2 appendResult11_g443 = (half2(texArray3445.w , texArray3445.y));
			float2 temp_output_4_0_g443 = ( ( ( appendResult11_g443 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_3_Normal_Power * -1.0 ) );
			float2 break8_g443 = temp_output_4_0_g443;
			float dotResult5_g443 = dot( temp_output_4_0_g443 , temp_output_4_0_g443 );
			float temp_output_9_0_g443 = sqrt( ( 1.0 - saturate( dotResult5_g443 ) ) );
			float3 appendResult21_g443 = (half3(break8_g443.y , break8_g443.x , temp_output_9_0_g443));
			float3 appendResult6871 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float4 texArray3417 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3441_0, _Texture_3_Normal_Index)  );
			float2 appendResult11_g441 = (half2(texArray3417.w , texArray3417.y));
			float2 temp_output_4_0_g441 = ( ( ( appendResult11_g441 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_3_Normal_Power );
			float2 break8_g441 = temp_output_4_0_g441;
			float dotResult5_g441 = dot( temp_output_4_0_g441 , temp_output_4_0_g441 );
			float temp_output_9_0_g441 = sqrt( ( 1.0 - saturate( dotResult5_g441 ) ) );
			float3 appendResult20_g441 = (half3(break8_g441.x , break8_g441.y , temp_output_9_0_g441));
			float3 appendResult6874 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar6408 = BlendComponents91;
			float3 weightedAvg6408 = ( ( weightedBlendVar6408.x*( appendResult21_g443 * appendResult6871 ) + weightedBlendVar6408.y*temp_output_6995_0 + weightedBlendVar6408.z*( appendResult20_g441 * appendResult6874 ) )/( weightedBlendVar6408.x + weightedBlendVar6408.y + weightedBlendVar6408.z ) );
			half3 ifLocalVar6619 = 0;
			UNITY_BRANCH 
			if( _Texture_3_Triplanar == 1.0 )
				ifLocalVar6619 = weightedAvg6408;
			else
				ifLocalVar6619 = temp_output_6995_0;
			half3 ifLocalVar7604 = 0;
			UNITY_BRANCH 
			if( _Texture_3_Normal_Power <= -1.0 )
				ifLocalVar7604 = EmptyNRM7781;
			else
				ifLocalVar7604 = ifLocalVar6619;
			half3 Normal_33452 = ifLocalVar7604;
			float4 texArray3483 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3477_0, _Texture_4_Normal_Index)  );
			float2 appendResult11_g934 = (half2(texArray3483.w , texArray3483.y));
			float2 temp_output_4_0_g934 = ( ( ( appendResult11_g934 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_4_Normal_Power );
			float2 break8_g934 = temp_output_4_0_g934;
			float dotResult5_g934 = dot( temp_output_4_0_g934 , temp_output_4_0_g934 );
			float temp_output_9_0_g934 = sqrt( ( 1.0 - saturate( dotResult5_g934 ) ) );
			float3 appendResult20_g934 = (half3(break8_g934.x , break8_g934.y , temp_output_9_0_g934));
			float3 temp_output_6998_0 = appendResult20_g934;
			float4 texArray3512 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3478_0, _Texture_4_Normal_Index)  );
			float2 appendResult11_g446 = (half2(texArray3512.w , texArray3512.y));
			float2 temp_output_4_0_g446 = ( ( ( appendResult11_g446 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_4_Normal_Power * -1.0 ) );
			float2 break8_g446 = temp_output_4_0_g446;
			float dotResult5_g446 = dot( temp_output_4_0_g446 , temp_output_4_0_g446 );
			float temp_output_9_0_g446 = sqrt( ( 1.0 - saturate( dotResult5_g446 ) ) );
			float3 appendResult21_g446 = (half3(break8_g446.y , break8_g446.x , temp_output_9_0_g446));
			float3 appendResult6878 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float4 texArray3484 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3508_0, _Texture_4_Normal_Index)  );
			float2 appendResult11_g447 = (half2(texArray3484.w , texArray3484.y));
			float2 temp_output_4_0_g447 = ( ( ( appendResult11_g447 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_4_Normal_Power );
			float2 break8_g447 = temp_output_4_0_g447;
			float dotResult5_g447 = dot( temp_output_4_0_g447 , temp_output_4_0_g447 );
			float temp_output_9_0_g447 = sqrt( ( 1.0 - saturate( dotResult5_g447 ) ) );
			float3 appendResult20_g447 = (half3(break8_g447.x , break8_g447.y , temp_output_9_0_g447));
			float3 appendResult6881 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar6415 = BlendComponents91;
			float3 weightedAvg6415 = ( ( weightedBlendVar6415.x*( appendResult21_g446 * appendResult6878 ) + weightedBlendVar6415.y*temp_output_6998_0 + weightedBlendVar6415.z*( appendResult20_g447 * appendResult6881 ) )/( weightedBlendVar6415.x + weightedBlendVar6415.y + weightedBlendVar6415.z ) );
			half3 ifLocalVar6625 = 0;
			UNITY_BRANCH 
			if( _Texture_4_Triplanar == 1.0 )
				ifLocalVar6625 = weightedAvg6415;
			else
				ifLocalVar6625 = temp_output_6998_0;
			half3 ifLocalVar7610 = 0;
			UNITY_BRANCH 
			if( _Texture_4_Normal_Power <= -1.0 )
				ifLocalVar7610 = EmptyNRM7781;
			else
				ifLocalVar7610 = ifLocalVar6625;
			half3 Normal_43519 = ifLocalVar7610;
			float4 layeredBlendVar7722 = appendResult6517;
			float3 layeredBlend7722 = ( lerp( lerp( lerp( lerp( float3( 0,0,0 ) , Normal_1569 , layeredBlendVar7722.x ) , Normal_23361 , layeredBlendVar7722.y ) , Normal_33452 , layeredBlendVar7722.z ) , Normal_43519 , layeredBlendVar7722.w ) );
			float4 texArray4424 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4416_0, _Texture_5_Normal_Index)  );
			float2 appendResult11_g976 = (half2(texArray4424.w , texArray4424.y));
			float2 temp_output_4_0_g976 = ( ( ( appendResult11_g976 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_5_Normal_Power );
			float2 break8_g976 = temp_output_4_0_g976;
			float dotResult5_g976 = dot( temp_output_4_0_g976 , temp_output_4_0_g976 );
			float temp_output_9_0_g976 = sqrt( ( 1.0 - saturate( dotResult5_g976 ) ) );
			float3 appendResult20_g976 = (half3(break8_g976.x , break8_g976.y , temp_output_9_0_g976));
			float3 temp_output_7001_0 = appendResult20_g976;
			float4 texArray4417 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4400_0, _Texture_5_Normal_Index)  );
			float2 appendResult11_g930 = (half2(texArray4417.w , texArray4417.y));
			float2 temp_output_4_0_g930 = ( ( ( appendResult11_g930 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_5_Normal_Power * -1.0 ) );
			float2 break8_g930 = temp_output_4_0_g930;
			float dotResult5_g930 = dot( temp_output_4_0_g930 , temp_output_4_0_g930 );
			float temp_output_9_0_g930 = sqrt( ( 1.0 - saturate( dotResult5_g930 ) ) );
			float3 appendResult21_g930 = (half3(break8_g930.y , break8_g930.x , temp_output_9_0_g930));
			float3 appendResult6885 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float4 texArray4422 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4413_0, _Texture_5_Normal_Index)  );
			float2 appendResult11_g940 = (half2(texArray4422.w , texArray4422.y));
			float2 temp_output_4_0_g940 = ( ( ( appendResult11_g940 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_5_Normal_Power );
			float2 break8_g940 = temp_output_4_0_g940;
			float dotResult5_g940 = dot( temp_output_4_0_g940 , temp_output_4_0_g940 );
			float temp_output_9_0_g940 = sqrt( ( 1.0 - saturate( dotResult5_g940 ) ) );
			float3 appendResult20_g940 = (half3(break8_g940.x , break8_g940.y , temp_output_9_0_g940));
			float3 appendResult6888 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar6422 = BlendComponents91;
			float3 weightedAvg6422 = ( ( weightedBlendVar6422.x*( appendResult21_g930 * appendResult6885 ) + weightedBlendVar6422.y*temp_output_7001_0 + weightedBlendVar6422.z*( appendResult20_g940 * appendResult6888 ) )/( weightedBlendVar6422.x + weightedBlendVar6422.y + weightedBlendVar6422.z ) );
			half3 ifLocalVar6631 = 0;
			UNITY_BRANCH 
			if( _Texture_5_Triplanar == 1.0 )
				ifLocalVar6631 = weightedAvg6422;
			else
				ifLocalVar6631 = temp_output_7001_0;
			half3 ifLocalVar7614 = 0;
			UNITY_BRANCH 
			if( _Texture_5_Normal_Power <= -1.0 )
				ifLocalVar7614 = EmptyNRM7781;
			else
				ifLocalVar7614 = ifLocalVar6631;
			half3 Normal_54456 = ifLocalVar7614;
			float4 texArray4493 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4485_0, _Texture_6_Normal_Index)  );
			float2 appendResult11_g969 = (half2(texArray4493.w , texArray4493.y));
			float2 temp_output_4_0_g969 = ( ( ( appendResult11_g969 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_6_Normal_Power );
			float2 break8_g969 = temp_output_4_0_g969;
			float dotResult5_g969 = dot( temp_output_4_0_g969 , temp_output_4_0_g969 );
			float temp_output_9_0_g969 = sqrt( ( 1.0 - saturate( dotResult5_g969 ) ) );
			float3 appendResult20_g969 = (half3(break8_g969.x , break8_g969.y , temp_output_9_0_g969));
			float3 temp_output_7004_0 = appendResult20_g969;
			float4 texArray4486 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4472_0, _Texture_6_Normal_Index)  );
			float2 appendResult11_g943 = (half2(texArray4486.w , texArray4486.y));
			float2 temp_output_4_0_g943 = ( ( ( appendResult11_g943 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_6_Normal_Power * -1.0 ) );
			float2 break8_g943 = temp_output_4_0_g943;
			float dotResult5_g943 = dot( temp_output_4_0_g943 , temp_output_4_0_g943 );
			float temp_output_9_0_g943 = sqrt( ( 1.0 - saturate( dotResult5_g943 ) ) );
			float3 appendResult21_g943 = (half3(break8_g943.y , break8_g943.x , temp_output_9_0_g943));
			float3 appendResult6892 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float4 texArray4491 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4483_0, _Texture_6_Normal_Index)  );
			float2 appendResult11_g929 = (half2(texArray4491.w , texArray4491.y));
			float2 temp_output_4_0_g929 = ( ( ( appendResult11_g929 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_6_Normal_Power );
			float2 break8_g929 = temp_output_4_0_g929;
			float dotResult5_g929 = dot( temp_output_4_0_g929 , temp_output_4_0_g929 );
			float temp_output_9_0_g929 = sqrt( ( 1.0 - saturate( dotResult5_g929 ) ) );
			float3 appendResult20_g929 = (half3(break8_g929.x , break8_g929.y , temp_output_9_0_g929));
			float3 appendResult6895 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar6429 = BlendComponents91;
			float3 weightedAvg6429 = ( ( weightedBlendVar6429.x*( appendResult21_g943 * appendResult6892 ) + weightedBlendVar6429.y*temp_output_7004_0 + weightedBlendVar6429.z*( appendResult20_g929 * appendResult6895 ) )/( weightedBlendVar6429.x + weightedBlendVar6429.y + weightedBlendVar6429.z ) );
			half3 ifLocalVar6637 = 0;
			UNITY_BRANCH 
			if( _Texture_6_Triplanar == 1.0 )
				ifLocalVar6637 = weightedAvg6429;
			else
				ifLocalVar6637 = temp_output_7004_0;
			half3 ifLocalVar7618 = 0;
			UNITY_BRANCH 
			if( _Texture_6_Normal_Power <= -1.0 )
				ifLocalVar7618 = EmptyNRM7781;
			else
				ifLocalVar7618 = ifLocalVar6637;
			half3 Normal_64537 = ifLocalVar7618;
			float4 texArray4567 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4559_0, _Texture_7_Normal_Index)  );
			float2 appendResult11_g971 = (half2(texArray4567.w , texArray4567.y));
			float2 temp_output_4_0_g971 = ( ( ( appendResult11_g971 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_7_Normal_Power );
			float2 break8_g971 = temp_output_4_0_g971;
			float dotResult5_g971 = dot( temp_output_4_0_g971 , temp_output_4_0_g971 );
			float temp_output_9_0_g971 = sqrt( ( 1.0 - saturate( dotResult5_g971 ) ) );
			float3 appendResult20_g971 = (half3(break8_g971.x , break8_g971.y , temp_output_9_0_g971));
			float3 temp_output_7007_0 = appendResult20_g971;
			float4 texArray4560 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4546_0, _Texture_7_Normal_Index)  );
			float2 appendResult11_g944 = (half2(texArray4560.w , texArray4560.y));
			float2 temp_output_4_0_g944 = ( ( ( appendResult11_g944 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_7_Normal_Power * -1.0 ) );
			float2 break8_g944 = temp_output_4_0_g944;
			float dotResult5_g944 = dot( temp_output_4_0_g944 , temp_output_4_0_g944 );
			float temp_output_9_0_g944 = sqrt( ( 1.0 - saturate( dotResult5_g944 ) ) );
			float3 appendResult21_g944 = (half3(break8_g944.y , break8_g944.x , temp_output_9_0_g944));
			float3 appendResult6899 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float4 texArray4565 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4557_0, _Texture_7_Normal_Index)  );
			float2 appendResult11_g942 = (half2(texArray4565.w , texArray4565.y));
			float2 temp_output_4_0_g942 = ( ( ( appendResult11_g942 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_7_Normal_Power );
			float2 break8_g942 = temp_output_4_0_g942;
			float dotResult5_g942 = dot( temp_output_4_0_g942 , temp_output_4_0_g942 );
			float temp_output_9_0_g942 = sqrt( ( 1.0 - saturate( dotResult5_g942 ) ) );
			float3 appendResult20_g942 = (half3(break8_g942.x , break8_g942.y , temp_output_9_0_g942));
			float3 appendResult6902 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar6436 = BlendComponents91;
			float3 weightedAvg6436 = ( ( weightedBlendVar6436.x*( appendResult21_g944 * appendResult6899 ) + weightedBlendVar6436.y*temp_output_7007_0 + weightedBlendVar6436.z*( appendResult20_g942 * appendResult6902 ) )/( weightedBlendVar6436.x + weightedBlendVar6436.y + weightedBlendVar6436.z ) );
			half3 ifLocalVar6643 = 0;
			UNITY_BRANCH 
			if( _Texture_7_Triplanar == 1.0 )
				ifLocalVar6643 = weightedAvg6436;
			else
				ifLocalVar6643 = temp_output_7007_0;
			half3 ifLocalVar7622 = 0;
			UNITY_BRANCH 
			if( _Texture_7_Normal_Power <= -1.0 )
				ifLocalVar7622 = EmptyNRM7781;
			else
				ifLocalVar7622 = ifLocalVar6643;
			half3 Normal_74615 = ifLocalVar7622;
			float4 texArray4641 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4633_0, _Texture_8_Normal_Index)  );
			float2 appendResult11_g975 = (half2(texArray4641.w , texArray4641.y));
			float2 temp_output_4_0_g975 = ( ( ( appendResult11_g975 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_8_Normal_Power );
			float2 break8_g975 = temp_output_4_0_g975;
			float dotResult5_g975 = dot( temp_output_4_0_g975 , temp_output_4_0_g975 );
			float temp_output_9_0_g975 = sqrt( ( 1.0 - saturate( dotResult5_g975 ) ) );
			float3 appendResult20_g975 = (half3(break8_g975.x , break8_g975.y , temp_output_9_0_g975));
			float3 temp_output_7010_0 = appendResult20_g975;
			float4 texArray4634 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4620_0, _Texture_8_Normal_Index)  );
			float2 appendResult11_g941 = (half2(texArray4634.w , texArray4634.y));
			float2 temp_output_4_0_g941 = ( ( ( appendResult11_g941 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_8_Normal_Power * -1.0 ) );
			float2 break8_g941 = temp_output_4_0_g941;
			float dotResult5_g941 = dot( temp_output_4_0_g941 , temp_output_4_0_g941 );
			float temp_output_9_0_g941 = sqrt( ( 1.0 - saturate( dotResult5_g941 ) ) );
			float3 appendResult21_g941 = (half3(break8_g941.y , break8_g941.x , temp_output_9_0_g941));
			float3 appendResult6906 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float4 texArray4639 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4631_0, _Texture_8_Normal_Index)  );
			float2 appendResult11_g935 = (half2(texArray4639.w , texArray4639.y));
			float2 temp_output_4_0_g935 = ( ( ( appendResult11_g935 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_8_Normal_Power );
			float2 break8_g935 = temp_output_4_0_g935;
			float dotResult5_g935 = dot( temp_output_4_0_g935 , temp_output_4_0_g935 );
			float temp_output_9_0_g935 = sqrt( ( 1.0 - saturate( dotResult5_g935 ) ) );
			float3 appendResult20_g935 = (half3(break8_g935.x , break8_g935.y , temp_output_9_0_g935));
			float3 appendResult6909 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar6443 = BlendComponents91;
			float3 weightedAvg6443 = ( ( weightedBlendVar6443.x*( appendResult21_g941 * appendResult6906 ) + weightedBlendVar6443.y*temp_output_7010_0 + weightedBlendVar6443.z*( appendResult20_g935 * appendResult6909 ) )/( weightedBlendVar6443.x + weightedBlendVar6443.y + weightedBlendVar6443.z ) );
			half3 ifLocalVar6649 = 0;
			UNITY_BRANCH 
			if( _Texture_8_Triplanar == 1.0 )
				ifLocalVar6649 = weightedAvg6443;
			else
				ifLocalVar6649 = temp_output_7010_0;
			half3 ifLocalVar7626 = 0;
			UNITY_BRANCH 
			if( _Texture_8_Normal_Power <= -1.0 )
				ifLocalVar7626 = EmptyNRM7781;
			else
				ifLocalVar7626 = ifLocalVar6649;
			half3 Normal_84690 = ifLocalVar7626;
			float4 layeredBlendVar7724 = appendResult6524;
			float3 layeredBlend7724 = ( lerp( lerp( lerp( lerp( layeredBlend7722 , Normal_54456 , layeredBlendVar7724.x ) , Normal_64537 , layeredBlendVar7724.y ) , Normal_74615 , layeredBlendVar7724.z ) , Normal_84690 , layeredBlendVar7724.w ) );
			float4 texArray4788 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4712_0, _Texture_9_Normal_Index)  );
			float2 appendResult11_g987 = (half2(texArray4788.w , texArray4788.y));
			float2 temp_output_4_0_g987 = ( ( ( appendResult11_g987 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_9_Normal_Power );
			float2 break8_g987 = temp_output_4_0_g987;
			float dotResult5_g987 = dot( temp_output_4_0_g987 , temp_output_4_0_g987 );
			float temp_output_9_0_g987 = sqrt( ( 1.0 - saturate( dotResult5_g987 ) ) );
			float3 appendResult20_g987 = (half3(break8_g987.x , break8_g987.y , temp_output_9_0_g987));
			float3 temp_output_7034_0 = appendResult20_g987;
			float4 texArray5285 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4706_0, _Texture_9_Normal_Index)  );
			float2 appendResult11_g970 = (half2(texArray5285.x , texArray5285.y));
			float2 temp_output_4_0_g970 = ( ( ( appendResult11_g970 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_9_Normal_Power * -1.0 ) );
			float2 break8_g970 = temp_output_4_0_g970;
			float dotResult5_g970 = dot( temp_output_4_0_g970 , temp_output_4_0_g970 );
			float temp_output_9_0_g970 = sqrt( ( 1.0 - saturate( dotResult5_g970 ) ) );
			float3 appendResult21_g970 = (half3(break8_g970.y , break8_g970.x , temp_output_9_0_g970));
			float3 appendResult6962 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float4 texArray4783 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4761_0, _Texture_9_Normal_Index)  );
			float2 appendResult11_g972 = (half2(texArray4783.w , texArray4783.y));
			float2 temp_output_4_0_g972 = ( ( ( appendResult11_g972 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_9_Normal_Power );
			float2 break8_g972 = temp_output_4_0_g972;
			float dotResult5_g972 = dot( temp_output_4_0_g972 , temp_output_4_0_g972 );
			float temp_output_9_0_g972 = sqrt( ( 1.0 - saturate( dotResult5_g972 ) ) );
			float3 appendResult20_g972 = (half3(break8_g972.x , break8_g972.y , temp_output_9_0_g972));
			float3 appendResult6965 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar6450 = BlendComponents91;
			float3 weightedAvg6450 = ( ( weightedBlendVar6450.x*( appendResult21_g970 * appendResult6962 ) + weightedBlendVar6450.y*temp_output_7034_0 + weightedBlendVar6450.z*( appendResult20_g972 * appendResult6965 ) )/( weightedBlendVar6450.x + weightedBlendVar6450.y + weightedBlendVar6450.z ) );
			half3 ifLocalVar6667 = 0;
			UNITY_BRANCH 
			if( _Texture_9_Triplanar == 1.0 )
				ifLocalVar6667 = weightedAvg6450;
			else
				ifLocalVar6667 = temp_output_7034_0;
			half3 ifLocalVar7631 = 0;
			UNITY_BRANCH 
			if( _Texture_9_Normal_Index <= -1.0 )
				ifLocalVar7631 = EmptyNRM7781;
			else
				ifLocalVar7631 = ifLocalVar6667;
			half3 Normal_94897 = ifLocalVar7631;
			float4 texArray4822 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4793_0, _Texture_10_Normal_Index)  );
			float2 appendResult11_g988 = (half2(texArray4822.w , texArray4822.y));
			float2 temp_output_4_0_g988 = ( ( ( appendResult11_g988 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_10_Normal_Power );
			float2 break8_g988 = temp_output_4_0_g988;
			float dotResult5_g988 = dot( temp_output_4_0_g988 , temp_output_4_0_g988 );
			float temp_output_9_0_g988 = sqrt( ( 1.0 - saturate( dotResult5_g988 ) ) );
			float3 appendResult20_g988 = (half3(break8_g988.x , break8_g988.y , temp_output_9_0_g988));
			float3 temp_output_7031_0 = appendResult20_g988;
			float4 texArray4798 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4742_0, _Texture_10_Normal_Index)  );
			float2 appendResult11_g974 = (half2(texArray4798.w , texArray4798.y));
			float2 temp_output_4_0_g974 = ( ( ( appendResult11_g974 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_10_Normal_Power * -1.0 ) );
			float2 break8_g974 = temp_output_4_0_g974;
			float dotResult5_g974 = dot( temp_output_4_0_g974 , temp_output_4_0_g974 );
			float temp_output_9_0_g974 = sqrt( ( 1.0 - saturate( dotResult5_g974 ) ) );
			float3 appendResult21_g974 = (half3(break8_g974.y , break8_g974.x , temp_output_9_0_g974));
			float3 appendResult6955 = (half3(ase_worldNormal.x , 1.0 , -1.0));
			float4 texArray4791 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4785_0, _Texture_10_Normal_Index)  );
			float2 appendResult11_g966 = (half2(texArray4791.w , texArray4791.y));
			float2 temp_output_4_0_g966 = ( ( ( appendResult11_g966 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_10_Normal_Power );
			float2 break8_g966 = temp_output_4_0_g966;
			float dotResult5_g966 = dot( temp_output_4_0_g966 , temp_output_4_0_g966 );
			float temp_output_9_0_g966 = sqrt( ( 1.0 - saturate( dotResult5_g966 ) ) );
			float3 appendResult20_g966 = (half3(break8_g966.x , break8_g966.y , temp_output_9_0_g966));
			float3 appendResult6958 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar6457 = BlendComponents91;
			float3 weightedAvg6457 = ( ( weightedBlendVar6457.x*( appendResult21_g974 * appendResult6955 ) + weightedBlendVar6457.y*temp_output_7031_0 + weightedBlendVar6457.z*( appendResult20_g966 * appendResult6958 ) )/( weightedBlendVar6457.x + weightedBlendVar6457.y + weightedBlendVar6457.z ) );
			half3 ifLocalVar6661 = 0;
			UNITY_BRANCH 
			if( _Texture_10_Triplanar == 1.0 )
				ifLocalVar6661 = weightedAvg6457;
			else
				ifLocalVar6661 = temp_output_7031_0;
			half3 ifLocalVar7637 = 0;
			UNITY_BRANCH 
			if( _Texture_10_Normal_Index <= -1.0 )
				ifLocalVar7637 = EmptyNRM7781;
			else
				ifLocalVar7637 = ifLocalVar6661;
			half3 Normal_104918 = ifLocalVar7637;
			float4 texArray4856 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4817_0, _Texture_11_Normal_Index)  );
			float2 appendResult11_g986 = (half2(texArray4856.w , texArray4856.y));
			float2 temp_output_4_0_g986 = ( ( ( appendResult11_g986 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_11_Normal_Power );
			float2 break8_g986 = temp_output_4_0_g986;
			float dotResult5_g986 = dot( temp_output_4_0_g986 , temp_output_4_0_g986 );
			float temp_output_9_0_g986 = sqrt( ( 1.0 - saturate( dotResult5_g986 ) ) );
			float3 appendResult20_g986 = (half3(break8_g986.x , break8_g986.y , temp_output_9_0_g986));
			float3 temp_output_7028_0 = appendResult20_g986;
			float4 texArray4828 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4748_0, _Texture_11_Normal_Index)  );
			float2 appendResult11_g968 = (half2(texArray4828.w , texArray4828.y));
			float2 temp_output_4_0_g968 = ( ( ( appendResult11_g968 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_11_Normal_Power * -1.0 ) );
			float2 break8_g968 = temp_output_4_0_g968;
			float dotResult5_g968 = dot( temp_output_4_0_g968 , temp_output_4_0_g968 );
			float temp_output_9_0_g968 = sqrt( ( 1.0 - saturate( dotResult5_g968 ) ) );
			float3 appendResult21_g968 = (half3(break8_g968.y , break8_g968.x , temp_output_9_0_g968));
			float3 appendResult6948 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float4 texArray4811 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4795_0, _Texture_11_Normal_Index)  );
			float2 appendResult11_g973 = (half2(texArray4811.w , texArray4811.y));
			float2 temp_output_4_0_g973 = ( ( ( appendResult11_g973 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_11_Normal_Power );
			float2 break8_g973 = temp_output_4_0_g973;
			float dotResult5_g973 = dot( temp_output_4_0_g973 , temp_output_4_0_g973 );
			float temp_output_9_0_g973 = sqrt( ( 1.0 - saturate( dotResult5_g973 ) ) );
			float3 appendResult20_g973 = (half3(break8_g973.x , break8_g973.y , temp_output_9_0_g973));
			float3 appendResult6951 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar6464 = BlendComponents91;
			float3 weightedAvg6464 = ( ( weightedBlendVar6464.x*( appendResult21_g968 * appendResult6948 ) + weightedBlendVar6464.y*temp_output_7028_0 + weightedBlendVar6464.z*( appendResult20_g973 * appendResult6951 ) )/( weightedBlendVar6464.x + weightedBlendVar6464.y + weightedBlendVar6464.z ) );
			half3 ifLocalVar6655 = 0;
			UNITY_BRANCH 
			if( _Texture_11_Triplanar == 1.0 )
				ifLocalVar6655 = weightedAvg6464;
			else
				ifLocalVar6655 = temp_output_7028_0;
			half3 ifLocalVar7641 = 0;
			UNITY_BRANCH 
			if( _Texture_11_Normal_Power <= -1.0 )
				ifLocalVar7641 = EmptyNRM7781;
			else
				ifLocalVar7641 = ifLocalVar6655;
			half3 Normal_114948 = ifLocalVar7641;
			float4 texArray4870 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4849_0, _Texture_12_Normal_Index)  );
			float2 appendResult11_g992 = (half2(texArray4870.w , texArray4870.y));
			float2 temp_output_4_0_g992 = ( ( ( appendResult11_g992 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_12_Normal_Power );
			float2 break8_g992 = temp_output_4_0_g992;
			float dotResult5_g992 = dot( temp_output_4_0_g992 , temp_output_4_0_g992 );
			float temp_output_9_0_g992 = sqrt( ( 1.0 - saturate( dotResult5_g992 ) ) );
			float3 appendResult20_g992 = (half3(break8_g992.x , break8_g992.y , temp_output_9_0_g992));
			float3 temp_output_7025_0 = appendResult20_g992;
			float4 texArray4850 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4758_0, _Texture_12_Normal_Index)  );
			float2 appendResult11_g965 = (half2(texArray4850.w , texArray4850.y));
			float2 temp_output_4_0_g965 = ( ( ( appendResult11_g965 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_12_Normal_Power * -1.0 ) );
			float2 break8_g965 = temp_output_4_0_g965;
			float dotResult5_g965 = dot( temp_output_4_0_g965 , temp_output_4_0_g965 );
			float temp_output_9_0_g965 = sqrt( ( 1.0 - saturate( dotResult5_g965 ) ) );
			float3 appendResult21_g965 = (half3(break8_g965.y , break8_g965.x , temp_output_9_0_g965));
			float3 appendResult6941 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float4 texArray4852 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_4830_0, _Texture_12_Normal_Index)  );
			float2 appendResult11_g967 = (half2(texArray4852.w , texArray4852.y));
			float2 temp_output_4_0_g967 = ( ( ( appendResult11_g967 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_12_Normal_Power );
			float2 break8_g967 = temp_output_4_0_g967;
			float dotResult5_g967 = dot( temp_output_4_0_g967 , temp_output_4_0_g967 );
			float temp_output_9_0_g967 = sqrt( ( 1.0 - saturate( dotResult5_g967 ) ) );
			float3 appendResult20_g967 = (half3(break8_g967.x , break8_g967.y , temp_output_9_0_g967));
			float3 appendResult6944 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar6471 = BlendComponents91;
			float3 weightedAvg6471 = ( ( weightedBlendVar6471.x*( appendResult21_g965 * appendResult6941 ) + weightedBlendVar6471.y*temp_output_7025_0 + weightedBlendVar6471.z*( appendResult20_g967 * appendResult6944 ) )/( weightedBlendVar6471.x + weightedBlendVar6471.y + weightedBlendVar6471.z ) );
			half3 ifLocalVar6673 = 0;
			UNITY_BRANCH 
			if( _Texture_12_Triplanar == 1.0 )
				ifLocalVar6673 = weightedAvg6471;
			else
				ifLocalVar6673 = temp_output_7025_0;
			half3 ifLocalVar7645 = 0;
			UNITY_BRANCH 
			if( _Texture_12_Normal_Power <= -1.0 )
				ifLocalVar7645 = EmptyNRM7781;
			else
				ifLocalVar7645 = ifLocalVar6673;
			half3 Normal_124962 = ifLocalVar7645;
			float4 layeredBlendVar7725 = appendResult6529;
			float3 layeredBlend7725 = ( lerp( lerp( lerp( lerp( layeredBlend7724 , Normal_94897 , layeredBlendVar7725.x ) , Normal_104918 , layeredBlendVar7725.y ) , Normal_114948 , layeredBlendVar7725.z ) , Normal_124962 , layeredBlendVar7725.w ) );
			float4 texArray5120 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5037_0, _Texture_13_Normal_Index)  );
			float2 appendResult11_g995 = (half2(texArray5120.w , texArray5120.y));
			float2 temp_output_4_0_g995 = ( ( ( appendResult11_g995 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_13_Normal_Power );
			float2 break8_g995 = temp_output_4_0_g995;
			float dotResult5_g995 = dot( temp_output_4_0_g995 , temp_output_4_0_g995 );
			float temp_output_9_0_g995 = sqrt( ( 1.0 - saturate( dotResult5_g995 ) ) );
			float3 appendResult20_g995 = (half3(break8_g995.x , break8_g995.y , temp_output_9_0_g995));
			float3 temp_output_7022_0 = appendResult20_g995;
			float4 texArray5127 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5025_0, _Texture_13_Normal_Index)  );
			float2 appendResult11_g983 = (half2(texArray5127.w , texArray5127.y));
			float2 temp_output_4_0_g983 = ( ( ( appendResult11_g983 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_13_Normal_Power * -1.0 ) );
			float2 break8_g983 = temp_output_4_0_g983;
			float dotResult5_g983 = dot( temp_output_4_0_g983 , temp_output_4_0_g983 );
			float temp_output_9_0_g983 = sqrt( ( 1.0 - saturate( dotResult5_g983 ) ) );
			float3 appendResult21_g983 = (half3(break8_g983.y , break8_g983.x , temp_output_9_0_g983));
			float3 appendResult6934 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float4 texArray5109 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5035_0, _Texture_13_Normal_Index)  );
			float2 appendResult11_g984 = (half2(texArray5109.w , texArray5109.y));
			float2 temp_output_4_0_g984 = ( ( ( appendResult11_g984 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_13_Normal_Power );
			float2 break8_g984 = temp_output_4_0_g984;
			float dotResult5_g984 = dot( temp_output_4_0_g984 , temp_output_4_0_g984 );
			float temp_output_9_0_g984 = sqrt( ( 1.0 - saturate( dotResult5_g984 ) ) );
			float3 appendResult20_g984 = (half3(break8_g984.x , break8_g984.y , temp_output_9_0_g984));
			float3 appendResult6937 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar6478 = BlendComponents91;
			float3 weightedAvg6478 = ( ( weightedBlendVar6478.x*( appendResult21_g983 * appendResult6934 ) + weightedBlendVar6478.y*temp_output_7022_0 + weightedBlendVar6478.z*( appendResult20_g984 * appendResult6937 ) )/( weightedBlendVar6478.x + weightedBlendVar6478.y + weightedBlendVar6478.z ) );
			half3 ifLocalVar6679 = 0;
			UNITY_BRANCH 
			if( _Texture_13_Triplanar == 1.0 )
				ifLocalVar6679 = weightedAvg6478;
			else
				ifLocalVar6679 = temp_output_7022_0;
			half3 ifLocalVar7649 = 0;
			UNITY_BRANCH 
			if( _Texture_13_Normal_Power <= -1.0 )
				ifLocalVar7649 = EmptyNRM7781;
			else
				ifLocalVar7649 = ifLocalVar6679;
			half3 Normal_135059 = ifLocalVar7649;
			float4 texArray5178 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5022_0, _Texture_14_Normal_Index)  );
			float2 appendResult11_g994 = (half2(texArray5178.w , texArray5178.y));
			float2 temp_output_4_0_g994 = ( ( ( appendResult11_g994 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_14_Normal_Power );
			float2 break8_g994 = temp_output_4_0_g994;
			float dotResult5_g994 = dot( temp_output_4_0_g994 , temp_output_4_0_g994 );
			float temp_output_9_0_g994 = sqrt( ( 1.0 - saturate( dotResult5_g994 ) ) );
			float3 appendResult20_g994 = (half3(break8_g994.x , break8_g994.y , temp_output_9_0_g994));
			float3 temp_output_7019_0 = appendResult20_g994;
			float4 texArray5017 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5009_0, _Texture_14_Normal_Index)  );
			float2 appendResult11_g982 = (half2(texArray5017.w , texArray5017.y));
			float2 temp_output_4_0_g982 = ( ( ( appendResult11_g982 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_14_Normal_Power * -1.0 ) );
			float2 break8_g982 = temp_output_4_0_g982;
			float dotResult5_g982 = dot( temp_output_4_0_g982 , temp_output_4_0_g982 );
			float temp_output_9_0_g982 = sqrt( ( 1.0 - saturate( dotResult5_g982 ) ) );
			float3 appendResult21_g982 = (half3(break8_g982.y , break8_g982.x , temp_output_9_0_g982));
			float3 appendResult6927 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float4 texArray5170 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5010_0, _Texture_14_Normal_Index)  );
			float2 appendResult11_g981 = (half2(texArray5170.w , texArray5170.y));
			float2 temp_output_4_0_g981 = ( ( ( appendResult11_g981 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_14_Normal_Power );
			float2 break8_g981 = temp_output_4_0_g981;
			float dotResult5_g981 = dot( temp_output_4_0_g981 , temp_output_4_0_g981 );
			float temp_output_9_0_g981 = sqrt( ( 1.0 - saturate( dotResult5_g981 ) ) );
			float3 appendResult20_g981 = (half3(break8_g981.x , break8_g981.y , temp_output_9_0_g981));
			float3 appendResult6930 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar6485 = BlendComponents91;
			float3 weightedAvg6485 = ( ( weightedBlendVar6485.x*( appendResult21_g982 * appendResult6927 ) + weightedBlendVar6485.y*temp_output_7019_0 + weightedBlendVar6485.z*( appendResult20_g981 * appendResult6930 ) )/( weightedBlendVar6485.x + weightedBlendVar6485.y + weightedBlendVar6485.z ) );
			half3 ifLocalVar6685 = 0;
			UNITY_BRANCH 
			if( _Texture_14_Triplanar == 1.0 )
				ifLocalVar6685 = weightedAvg6485;
			else
				ifLocalVar6685 = temp_output_7019_0;
			half3 ifLocalVar7653 = 0;
			UNITY_BRANCH 
			if( _Texture_14_Normal_Index <= -1.0 )
				ifLocalVar7653 = EmptyNRM7781;
			else
				ifLocalVar7653 = ifLocalVar6685;
			half3 Normal_145196 = ifLocalVar7653;
			float4 texArray5246 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5226_0, _Texture_15_Normal_Index)  );
			float2 appendResult11_g993 = (half2(texArray5246.w , texArray5246.y));
			float2 temp_output_4_0_g993 = ( ( ( appendResult11_g993 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_15_Normal_Power );
			float2 break8_g993 = temp_output_4_0_g993;
			float dotResult5_g993 = dot( temp_output_4_0_g993 , temp_output_4_0_g993 );
			float temp_output_9_0_g993 = sqrt( ( 1.0 - saturate( dotResult5_g993 ) ) );
			float3 appendResult20_g993 = (half3(break8_g993.x , break8_g993.y , temp_output_9_0_g993));
			float3 temp_output_7016_0 = appendResult20_g993;
			float4 texArray5227 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5213_0, _Texture_15_Normal_Index)  );
			float2 appendResult11_g990 = (half2(texArray5227.w , texArray5227.y));
			float2 temp_output_4_0_g990 = ( ( ( appendResult11_g990 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_15_Normal_Power * -1.0 ) );
			float2 break8_g990 = temp_output_4_0_g990;
			float dotResult5_g990 = dot( temp_output_4_0_g990 , temp_output_4_0_g990 );
			float temp_output_9_0_g990 = sqrt( ( 1.0 - saturate( dotResult5_g990 ) ) );
			float3 appendResult21_g990 = (half3(break8_g990.y , break8_g990.x , temp_output_9_0_g990));
			float3 appendResult6920 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float4 texArray5250 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5224_0, _Texture_15_Normal_Index)  );
			float2 appendResult11_g989 = (half2(texArray5250.w , texArray5250.y));
			float2 temp_output_4_0_g989 = ( ( ( appendResult11_g989 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_15_Normal_Power );
			float2 break8_g989 = temp_output_4_0_g989;
			float dotResult5_g989 = dot( temp_output_4_0_g989 , temp_output_4_0_g989 );
			float temp_output_9_0_g989 = sqrt( ( 1.0 - saturate( dotResult5_g989 ) ) );
			float3 appendResult20_g989 = (half3(break8_g989.x , break8_g989.y , temp_output_9_0_g989));
			float3 appendResult6923 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar6492 = BlendComponents91;
			float3 weightedAvg6492 = ( ( weightedBlendVar6492.x*( appendResult21_g990 * appendResult6920 ) + weightedBlendVar6492.y*temp_output_7016_0 + weightedBlendVar6492.z*( appendResult20_g989 * appendResult6923 ) )/( weightedBlendVar6492.x + weightedBlendVar6492.y + weightedBlendVar6492.z ) );
			half3 ifLocalVar6691 = 0;
			UNITY_BRANCH 
			if( _Texture_15_Triplanar == 1.0 )
				ifLocalVar6691 = weightedAvg6492;
			else
				ifLocalVar6691 = temp_output_7016_0;
			half3 ifLocalVar7657 = 0;
			UNITY_BRANCH 
			if( _Texture_15_Normal_Index <= -1.0 )
				ifLocalVar7657 = EmptyNRM7781;
			else
				ifLocalVar7657 = ifLocalVar6691;
			half3 Normal_155280 = ifLocalVar7657;
			float4 texArray5099 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5083_0, _Texture_16_Normal_Index)  );
			float2 appendResult11_g996 = (half2(texArray5099.w , texArray5099.y));
			float2 temp_output_4_0_g996 = ( ( ( appendResult11_g996 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_16_Normal_Power );
			float2 break8_g996 = temp_output_4_0_g996;
			float dotResult5_g996 = dot( temp_output_4_0_g996 , temp_output_4_0_g996 );
			float temp_output_9_0_g996 = sqrt( ( 1.0 - saturate( dotResult5_g996 ) ) );
			float3 appendResult20_g996 = (half3(break8_g996.x , break8_g996.y , temp_output_9_0_g996));
			float3 temp_output_7013_0 = appendResult20_g996;
			float4 texArray5082 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5079_0, _Texture_16_Normal_Index)  );
			float2 appendResult11_g985 = (half2(texArray5082.w , texArray5082.y));
			float2 temp_output_4_0_g985 = ( ( ( appendResult11_g985 * float2( 2,2 ) ) + float2( -1,-1 ) ) * ( _Texture_16_Normal_Power * -1.0 ) );
			float2 break8_g985 = temp_output_4_0_g985;
			float dotResult5_g985 = dot( temp_output_4_0_g985 , temp_output_4_0_g985 );
			float temp_output_9_0_g985 = sqrt( ( 1.0 - saturate( dotResult5_g985 ) ) );
			float3 appendResult21_g985 = (half3(break8_g985.y , break8_g985.x , temp_output_9_0_g985));
			float3 appendResult6913 = (half3(ase_worldNormal.x , -1.0 , 1.0));
			float4 texArray4731 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_5085_0, _Texture_16_Normal_Index)  );
			float2 appendResult11_g991 = (half2(texArray4731.w , texArray4731.y));
			float2 temp_output_4_0_g991 = ( ( ( appendResult11_g991 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Texture_16_Normal_Power );
			float2 break8_g991 = temp_output_4_0_g991;
			float dotResult5_g991 = dot( temp_output_4_0_g991 , temp_output_4_0_g991 );
			float temp_output_9_0_g991 = sqrt( ( 1.0 - saturate( dotResult5_g991 ) ) );
			float3 appendResult20_g991 = (half3(break8_g991.x , break8_g991.y , temp_output_9_0_g991));
			float3 appendResult6916 = (half3(1.0 , ( ase_worldNormal.z * -1.0 ) , 1.0));
			float3 weightedBlendVar6499 = BlendComponents91;
			float3 weightedAvg6499 = ( ( weightedBlendVar6499.x*( appendResult21_g985 * appendResult6913 ) + weightedBlendVar6499.y*temp_output_7013_0 + weightedBlendVar6499.z*( appendResult20_g991 * appendResult6916 ) )/( weightedBlendVar6499.x + weightedBlendVar6499.y + weightedBlendVar6499.z ) );
			half3 ifLocalVar6697 = 0;
			UNITY_BRANCH 
			if( _Texture_16_Triplanar == 1.0 )
				ifLocalVar6697 = weightedAvg6499;
			else
				ifLocalVar6697 = temp_output_7013_0;
			half3 ifLocalVar7662 = 0;
			UNITY_BRANCH 
			if( _Texture_16_Normal_Index <= -1.0 )
				ifLocalVar7662 = EmptyNRM7781;
			else
				ifLocalVar7662 = ifLocalVar6697;
			half3 Normal_164696 = ifLocalVar7662;
			float4 layeredBlendVar7726 = appendResult6533;
			float3 layeredBlend7726 = ( lerp( lerp( lerp( lerp( layeredBlend7725 , Normal_135059 , layeredBlendVar7726.x ) , Normal_145196 , layeredBlendVar7726.y ) , Normal_155280 , layeredBlendVar7726.z ) , Normal_164696 , layeredBlendVar7726.w ) );
			float3 normalizeResult3900 = normalize( layeredBlend7726 );
			float4 texArray4382 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Normal, float3(temp_output_3893_0, _Texture_Snow_Normal_Index)  );
			float2 appendResult11_g997 = (half2(texArray4382.w , texArray4382.y));
			float2 temp_output_4_0_g997 = ( ( ( appendResult11_g997 * float2( 2,2 ) ) + float2( -1,-1 ) ) * _Snow_Normal_Scale );
			float2 break8_g997 = temp_output_4_0_g997;
			float dotResult5_g997 = dot( temp_output_4_0_g997 , temp_output_4_0_g997 );
			float temp_output_9_0_g997 = sqrt( ( 1.0 - saturate( dotResult5_g997 ) ) );
			float3 appendResult20_g997 = (half3(break8_g997.x , break8_g997.y , temp_output_9_0_g997));
			half3 ifLocalVar7798 = 0;
			UNITY_BRANCH 
			if( _Texture_Snow_Normal_Index <= -1.0 )
				ifLocalVar7798 = EmptyNRM7781;
			else
				ifLocalVar7798 = appendResult20_g997;
			float3 lerpResult6554 = lerp( normalizeResult3900 , ifLocalVar7798 , _Snow_Blend_Normal);
			float3 lerpResult3741 = lerp( normalizeResult3900 , lerpResult6554 , HeightMask6539);
			float3 lerpResult939 = lerp( lerpResult3741 , UnpackScaleNormal( tex2D( _Global_Normal_Map, i.uv_texcoord ), _Global_Normalmap_Power ) , UVmixDistance636);
			float3 normalizeResult3901 = normalize( lerpResult939 );
			float3 temp_output_4100_0 = BlendNormals( lerpResult6503 , normalizeResult3901 );
			o.Normal = temp_output_4100_0;
			float lerpResult7983 = lerp( _Global_Color_Map_Close_Power , _Global_Color_Map_Far_Power , UVmixDistance636);
			half4 tex2DNode7984 = tex2D( _Global_Color_Map, ( _Global_Color_Map_Offset + ( _Global_Color_Map_Scale * i.uv_texcoord ) ) );
			float clampResult8065 = clamp( ( tex2DNode7984.a + ( 1.0 - _Global_Color_Opacity_Power ) ) , 0.0 , 1.0 );
			float2 appendResult7986 = (half2(1.0 , ( lerpResult7983 * clampResult8065 )));
			float4 texArray3292 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3275_0, _Texture_1_Albedo_Index)  );
			float4 texArray3293 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3298_0, _Texture_1_Albedo_Index)  );
			float4 lerpResult6608 = lerp( texArray3292 , texArray3293 , UVmixDistance636);
			float4 texArray3287 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3279_0, _Texture_1_Albedo_Index)  );
			float4 texArray3294 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3277_0, _Texture_1_Albedo_Index)  );
			float3 weightedBlendVar6389 = BlendComponents91;
			float4 weightedAvg6389 = ( ( weightedBlendVar6389.x*texArray3287 + weightedBlendVar6389.y*texArray3292 + weightedBlendVar6389.z*texArray3294 )/( weightedBlendVar6389.x + weightedBlendVar6389.y + weightedBlendVar6389.z ) );
			float4 texArray3291 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3296_0, _Texture_1_Albedo_Index)  );
			float4 texArray3295 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3297_0, _Texture_1_Albedo_Index)  );
			float3 weightedBlendVar6390 = BlendComponents91;
			float4 weightedAvg6390 = ( ( weightedBlendVar6390.x*texArray3291 + weightedBlendVar6390.y*texArray3293 + weightedBlendVar6390.z*texArray3295 )/( weightedBlendVar6390.x + weightedBlendVar6390.y + weightedBlendVar6390.z ) );
			float4 lerpResult1767 = lerp( weightedAvg6389 , weightedAvg6390 , UVmixDistance636);
			half4 ifLocalVar6607 = 0;
			UNITY_BRANCH 
			if( _Texture_1_Triplanar == 1.0 )
				ifLocalVar6607 = lerpResult1767;
			else
				ifLocalVar6607 = lerpResult6608;
			half4 ifLocalVar7593 = 0;
			UNITY_BRANCH 
			if( _Texture_1_Albedo_Index > -1.0 )
				ifLocalVar7593 = ( ifLocalVar6607 * _Texture_1_Color );
			half4 Texture_1_Final950 = ifLocalVar7593;
			float4 texArray3338 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3343_0, _Texture_2_Albedo_Index)  );
			float4 texArray3339 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3345_0, _Texture_2_Albedo_Index)  );
			float4 lerpResult6617 = lerp( texArray3338 , texArray3339 , UVmixDistance636);
			float4 texArray3355 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3344_0, _Texture_2_Albedo_Index)  );
			float4 texArray3341 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3379_0, _Texture_2_Albedo_Index)  );
			float3 weightedBlendVar6396 = BlendComponents91;
			float4 weightedAvg6396 = ( ( weightedBlendVar6396.x*texArray3355 + weightedBlendVar6396.y*texArray3338 + weightedBlendVar6396.z*texArray3341 )/( weightedBlendVar6396.x + weightedBlendVar6396.y + weightedBlendVar6396.z ) );
			float4 texArray3356 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3346_0, _Texture_2_Albedo_Index)  );
			float4 texArray3342 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3352_0, _Texture_2_Albedo_Index)  );
			float3 weightedBlendVar6398 = BlendComponents91;
			float4 weightedAvg6398 = ( ( weightedBlendVar6398.x*texArray3356 + weightedBlendVar6398.y*texArray3339 + weightedBlendVar6398.z*texArray3342 )/( weightedBlendVar6398.x + weightedBlendVar6398.y + weightedBlendVar6398.z ) );
			float4 lerpResult3333 = lerp( weightedAvg6396 , weightedAvg6398 , UVmixDistance636);
			half4 ifLocalVar6612 = 0;
			UNITY_BRANCH 
			if( _Texture_2_Triplanar == 1.0 )
				ifLocalVar6612 = lerpResult3333;
			else
				ifLocalVar6612 = lerpResult6617;
			half4 ifLocalVar7599 = 0;
			UNITY_BRANCH 
			if( _Texture_2_Albedo_Index > -1.0 )
				ifLocalVar7599 = ( ifLocalVar6612 * _Texture_2_Color );
			half4 Texture_2_Final3385 = ifLocalVar7599;
			float4 texArray3405 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3410_0, _Texture_3_Albedo_Index)  );
			float4 texArray3406 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3412_0, _Texture_3_Albedo_Index)  );
			float4 lerpResult6623 = lerp( texArray3405 , texArray3406 , UVmixDistance636);
			float4 texArray3419 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3411_0, _Texture_3_Albedo_Index)  );
			float4 texArray3408 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3441_0, _Texture_3_Albedo_Index)  );
			float3 weightedBlendVar6403 = BlendComponents91;
			float4 weightedAvg6403 = ( ( weightedBlendVar6403.x*texArray3419 + weightedBlendVar6403.y*texArray3405 + weightedBlendVar6403.z*texArray3408 )/( weightedBlendVar6403.x + weightedBlendVar6403.y + weightedBlendVar6403.z ) );
			float4 texArray3420 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3413_0, _Texture_3_Albedo_Index)  );
			float4 texArray3409 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3418_0, _Texture_3_Albedo_Index)  );
			float3 weightedBlendVar6405 = BlendComponents91;
			float4 weightedAvg6405 = ( ( weightedBlendVar6405.x*texArray3420 + weightedBlendVar6405.y*texArray3406 + weightedBlendVar6405.z*texArray3409 )/( weightedBlendVar6405.x + weightedBlendVar6405.y + weightedBlendVar6405.z ) );
			float4 lerpResult3400 = lerp( weightedAvg6403 , weightedAvg6405 , UVmixDistance636);
			half4 ifLocalVar6618 = 0;
			UNITY_BRANCH 
			if( _Texture_3_Triplanar == 1.0 )
				ifLocalVar6618 = lerpResult3400;
			else
				ifLocalVar6618 = lerpResult6623;
			half4 ifLocalVar7603 = 0;
			UNITY_BRANCH 
			if( _Texture_3_Albedo_Index > -1.0 )
				ifLocalVar7603 = ( ifLocalVar6618 * _Texture_3_Color );
			half4 Texture_3_Final3451 = ifLocalVar7603;
			float4 texArray3472 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3477_0, _Texture_4_Albedo_Index)  );
			float4 texArray3473 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3479_0, _Texture_4_Albedo_Index)  );
			float4 lerpResult6629 = lerp( texArray3472 , texArray3473 , UVmixDistance636);
			float4 texArray3486 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3478_0, _Texture_4_Albedo_Index)  );
			float4 texArray3475 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3508_0, _Texture_4_Albedo_Index)  );
			float3 weightedBlendVar6410 = BlendComponents91;
			float4 weightedAvg6410 = ( ( weightedBlendVar6410.x*texArray3486 + weightedBlendVar6410.y*texArray3472 + weightedBlendVar6410.z*texArray3475 )/( weightedBlendVar6410.x + weightedBlendVar6410.y + weightedBlendVar6410.z ) );
			float4 texArray3487 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3480_0, _Texture_4_Albedo_Index)  );
			float4 texArray3476 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3485_0, _Texture_4_Albedo_Index)  );
			float3 weightedBlendVar6412 = BlendComponents91;
			float4 weightedAvg6412 = ( ( weightedBlendVar6412.x*texArray3487 + weightedBlendVar6412.y*texArray3473 + weightedBlendVar6412.z*texArray3476 )/( weightedBlendVar6412.x + weightedBlendVar6412.y + weightedBlendVar6412.z ) );
			float4 lerpResult3467 = lerp( weightedAvg6410 , weightedAvg6412 , UVmixDistance636);
			half4 ifLocalVar6624 = 0;
			UNITY_BRANCH 
			if( _Texture_4_Triplanar == 1.0 )
				ifLocalVar6624 = lerpResult3467;
			else
				ifLocalVar6624 = lerpResult6629;
			half4 ifLocalVar7608 = 0;
			UNITY_BRANCH 
			if( _Texture_4_Albedo_Index > -1.0 )
				ifLocalVar7608 = ( ifLocalVar6624 * _Texture_4_Color );
			half4 Texture_4_Final3518 = ifLocalVar7608;
			float4 layeredBlendVar6512 = appendResult6517;
			float4 layeredBlend6512 = ( lerp( lerp( lerp( lerp( float4( 0,0,0,0 ) , Texture_1_Final950 , layeredBlendVar6512.x ) , Texture_2_Final3385 , layeredBlendVar6512.y ) , Texture_3_Final3451 , layeredBlendVar6512.z ) , Texture_4_Final3518 , layeredBlendVar6512.w ) );
			float4 texArray4450 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4416_0, _Texture_5_Albedo_Index)  );
			float4 texArray4445 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4440_0, _Texture_5_Albedo_Index)  );
			float4 lerpResult6635 = lerp( texArray4450 , texArray4445 , UVmixDistance636);
			float4 texArray4442 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4400_0, _Texture_5_Albedo_Index)  );
			float4 texArray4443 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4413_0, _Texture_5_Albedo_Index)  );
			float3 weightedBlendVar6417 = BlendComponents91;
			float4 weightedAvg6417 = ( ( weightedBlendVar6417.x*texArray4442 + weightedBlendVar6417.y*texArray4450 + weightedBlendVar6417.z*texArray4443 )/( weightedBlendVar6417.x + weightedBlendVar6417.y + weightedBlendVar6417.z ) );
			float4 texArray4444 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4436_0, _Texture_5_Albedo_Index)  );
			float4 texArray4439 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4437_0, _Texture_5_Albedo_Index)  );
			float3 weightedBlendVar6419 = BlendComponents91;
			float4 weightedAvg6419 = ( ( weightedBlendVar6419.x*texArray4444 + weightedBlendVar6419.y*texArray4445 + weightedBlendVar6419.z*texArray4439 )/( weightedBlendVar6419.x + weightedBlendVar6419.y + weightedBlendVar6419.z ) );
			float4 lerpResult4466 = lerp( weightedAvg6417 , weightedAvg6419 , UVmixDistance636);
			half4 ifLocalVar6630 = 0;
			UNITY_BRANCH 
			if( _Texture_5_Triplanar == 1.0 )
				ifLocalVar6630 = lerpResult4466;
			else
				ifLocalVar6630 = lerpResult6635;
			half4 ifLocalVar7613 = 0;
			UNITY_BRANCH 
			if( _Texture_5_Albedo_Index > -1.0 )
				ifLocalVar7613 = ( ifLocalVar6630 * _Texture_5_Color );
			half4 Texture_5_Final4396 = ifLocalVar7613;
			float4 texArray4517 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4485_0, _Texture_6_Albedo_Index)  );
			float4 texArray4512 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4507_0, _Texture_6_Albedo_Index)  );
			float4 lerpResult6641 = lerp( texArray4517 , texArray4512 , UVmixDistance636);
			float4 texArray4509 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4472_0, _Texture_6_Albedo_Index)  );
			float4 texArray4510 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4483_0, _Texture_6_Albedo_Index)  );
			float3 weightedBlendVar6424 = BlendComponents91;
			float4 weightedAvg6424 = ( ( weightedBlendVar6424.x*texArray4509 + weightedBlendVar6424.y*texArray4517 + weightedBlendVar6424.z*texArray4510 )/( weightedBlendVar6424.x + weightedBlendVar6424.y + weightedBlendVar6424.z ) );
			float4 texArray4511 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4503_0, _Texture_6_Albedo_Index)  );
			float4 texArray4506 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4504_0, _Texture_6_Albedo_Index)  );
			float3 weightedBlendVar6426 = BlendComponents91;
			float4 weightedAvg6426 = ( ( weightedBlendVar6426.x*texArray4511 + weightedBlendVar6426.y*texArray4512 + weightedBlendVar6426.z*texArray4506 )/( weightedBlendVar6426.x + weightedBlendVar6426.y + weightedBlendVar6426.z ) );
			float4 lerpResult4532 = lerp( weightedAvg6424 , weightedAvg6426 , UVmixDistance636);
			half4 ifLocalVar6636 = 0;
			UNITY_BRANCH 
			if( _Texture_6_Triplanar == 1.0 )
				ifLocalVar6636 = lerpResult4532;
			else
				ifLocalVar6636 = lerpResult6641;
			half4 ifLocalVar7617 = 0;
			UNITY_BRANCH 
			if( _Texture_6_Albedo_Index > -1.0 )
				ifLocalVar7617 = ( ifLocalVar6636 * _Texture_6_Color );
			half4 Texture_6_Final4536 = ifLocalVar7617;
			float4 texArray4591 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4559_0, _Texture_7_Albedo_Index)  );
			float4 texArray4586 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4581_0, _Texture_7_Albedo_Index)  );
			float4 lerpResult6647 = lerp( texArray4591 , texArray4586 , UVmixDistance636);
			float4 texArray4583 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4546_0, _Texture_7_Albedo_Index)  );
			float4 texArray4584 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4557_0, _Texture_7_Albedo_Index)  );
			float3 weightedBlendVar6431 = BlendComponents91;
			float4 weightedAvg6431 = ( ( weightedBlendVar6431.x*texArray4583 + weightedBlendVar6431.y*texArray4591 + weightedBlendVar6431.z*texArray4584 )/( weightedBlendVar6431.x + weightedBlendVar6431.y + weightedBlendVar6431.z ) );
			float4 texArray4585 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4577_0, _Texture_7_Albedo_Index)  );
			float4 texArray4580 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4578_0, _Texture_7_Albedo_Index)  );
			float3 weightedBlendVar6433 = BlendComponents91;
			float4 weightedAvg6433 = ( ( weightedBlendVar6433.x*texArray4585 + weightedBlendVar6433.y*texArray4586 + weightedBlendVar6433.z*texArray4580 )/( weightedBlendVar6433.x + weightedBlendVar6433.y + weightedBlendVar6433.z ) );
			float4 lerpResult4606 = lerp( weightedAvg6431 , weightedAvg6433 , UVmixDistance636);
			half4 ifLocalVar6642 = 0;
			UNITY_BRANCH 
			if( _Texture_7_Triplanar == 1.0 )
				ifLocalVar6642 = lerpResult4606;
			else
				ifLocalVar6642 = lerpResult6647;
			half4 ifLocalVar7621 = 0;
			UNITY_BRANCH 
			if( _Texture_7_Albedo_Index > -1.0 )
				ifLocalVar7621 = ( ifLocalVar6642 * _Texture_7_Color );
			half4 Texture_7_Final4614 = ifLocalVar7621;
			float4 texArray4665 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4633_0, _Texture_8_Albedo_Index)  );
			float4 texArray4660 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4655_0, _Texture_8_Albedo_Index)  );
			float4 lerpResult6653 = lerp( texArray4665 , texArray4660 , UVmixDistance636);
			float4 texArray4657 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4620_0, _Texture_8_Albedo_Index)  );
			float4 texArray4658 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4631_0, _Texture_8_Albedo_Index)  );
			float3 weightedBlendVar6438 = BlendComponents91;
			float4 weightedAvg6438 = ( ( weightedBlendVar6438.x*texArray4657 + weightedBlendVar6438.y*texArray4665 + weightedBlendVar6438.z*texArray4658 )/( weightedBlendVar6438.x + weightedBlendVar6438.y + weightedBlendVar6438.z ) );
			float4 texArray4659 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4651_0, _Texture_8_Albedo_Index)  );
			float4 texArray4654 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4652_0, _Texture_8_Albedo_Index)  );
			float3 weightedBlendVar6440 = BlendComponents91;
			float4 weightedAvg6440 = ( ( weightedBlendVar6440.x*texArray4659 + weightedBlendVar6440.y*texArray4660 + weightedBlendVar6440.z*texArray4654 )/( weightedBlendVar6440.x + weightedBlendVar6440.y + weightedBlendVar6440.z ) );
			float4 lerpResult4680 = lerp( weightedAvg6438 , weightedAvg6440 , UVmixDistance636);
			half4 ifLocalVar6648 = 0;
			UNITY_BRANCH 
			if( _Texture_8_Triplanar == 1.0 )
				ifLocalVar6648 = lerpResult4680;
			else
				ifLocalVar6648 = lerpResult6653;
			half4 ifLocalVar7625 = 0;
			UNITY_BRANCH 
			if( _Texture_8_Albedo_Index > -1.0 )
				ifLocalVar7625 = ( ifLocalVar6648 * _Texture_8_Color );
			half4 Texture_8_Final4689 = ifLocalVar7625;
			float4 layeredBlendVar6520 = appendResult6524;
			float4 layeredBlend6520 = ( lerp( lerp( lerp( lerp( layeredBlend6512 , Texture_5_Final4396 , layeredBlendVar6520.x ) , Texture_6_Final4536 , layeredBlendVar6520.y ) , Texture_7_Final4614 , layeredBlendVar6520.z ) , Texture_8_Final4689 , layeredBlendVar6520.w ) );
			float4 texArray4723 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4712_0, _Texture_9_Albedo_Index)  );
			float4 texArray4889 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4721_0, _Texture_9_Albedo_Index)  );
			float4 lerpResult6671 = lerp( texArray4723 , texArray4889 , UVmixDistance636);
			float4 texArray5286 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4706_0, _Texture_9_Albedo_Index)  );
			float4 texArray4858 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4761_0, _Texture_9_Albedo_Index)  );
			float3 weightedBlendVar6445 = BlendComponents91;
			float4 weightedAvg6445 = ( ( weightedBlendVar6445.x*texArray5286 + weightedBlendVar6445.y*texArray4723 + weightedBlendVar6445.z*texArray4858 )/( weightedBlendVar6445.x + weightedBlendVar6445.y + weightedBlendVar6445.z ) );
			float4 texArray4719 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4718_0, _Texture_9_Albedo_Index)  );
			float4 texArray4865 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4844_0, _Texture_9_Albedo_Index)  );
			float3 weightedBlendVar6447 = BlendComponents91;
			float4 weightedAvg6447 = ( ( weightedBlendVar6447.x*texArray4719 + weightedBlendVar6447.y*texArray4889 + weightedBlendVar6447.z*texArray4865 )/( weightedBlendVar6447.x + weightedBlendVar6447.y + weightedBlendVar6447.z ) );
			float4 lerpResult4976 = lerp( weightedAvg6445 , weightedAvg6447 , UVmixDistance636);
			half4 ifLocalVar6666 = 0;
			UNITY_BRANCH 
			if( _Texture_9_Triplanar == 1.0 )
				ifLocalVar6666 = lerpResult4976;
			else
				ifLocalVar6666 = lerpResult6671;
			half4 ifLocalVar7630 = 0;
			UNITY_BRANCH 
			if( _Texture_9_Albedo_Index > -1.0 )
				ifLocalVar7630 = ( ifLocalVar6666 * _Texture_9_Color );
			half4 Texture_9_Final4987 = ifLocalVar7630;
			float4 texArray4899 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4793_0, _Texture_10_Albedo_Index)  );
			float4 texArray4913 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4879_0, _Texture_10_Albedo_Index)  );
			float4 lerpResult6665 = lerp( texArray4899 , texArray4913 , UVmixDistance636);
			float4 texArray4886 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4742_0, _Texture_10_Albedo_Index)  );
			float4 texArray4877 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4785_0, _Texture_10_Albedo_Index)  );
			float3 weightedBlendVar6452 = BlendComponents91;
			float4 weightedAvg6452 = ( ( weightedBlendVar6452.x*texArray4886 + weightedBlendVar6452.y*texArray4899 + weightedBlendVar6452.z*texArray4877 )/( weightedBlendVar6452.x + weightedBlendVar6452.y + weightedBlendVar6452.z ) );
			float4 texArray4894 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4873_0, _Texture_10_Albedo_Index)  );
			float4 texArray4878 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4859_0, _Texture_10_Albedo_Index)  );
			float3 weightedBlendVar6454 = BlendComponents91;
			float4 weightedAvg6454 = ( ( weightedBlendVar6454.x*texArray4894 + weightedBlendVar6454.y*texArray4913 + weightedBlendVar6454.z*texArray4878 )/( weightedBlendVar6454.x + weightedBlendVar6454.y + weightedBlendVar6454.z ) );
			float4 lerpResult4983 = lerp( weightedAvg6452 , weightedAvg6454 , UVmixDistance636);
			half4 ifLocalVar6660 = 0;
			UNITY_BRANCH 
			if( _Texture_10_Triplanar == 1.0 )
				ifLocalVar6660 = lerpResult4983;
			else
				ifLocalVar6660 = lerpResult6665;
			half4 ifLocalVar7634 = 0;
			UNITY_BRANCH 
			if( _Texture_10_Albedo_Index > -1.0 )
				ifLocalVar7634 = ( ifLocalVar6660 * _Texture_10_Color );
			half4 Texture_10_Final4994 = ifLocalVar7634;
			float4 texArray4928 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4817_0, _Texture_11_Albedo_Index)  );
			float4 texArray4923 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4904_0, _Texture_11_Albedo_Index)  );
			float4 lerpResult6659 = lerp( texArray4928 , texArray4923 , UVmixDistance636);
			float4 texArray4917 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4748_0, _Texture_11_Albedo_Index)  );
			float4 texArray4911 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4795_0, _Texture_11_Albedo_Index)  );
			float3 weightedBlendVar6459 = BlendComponents91;
			float4 weightedAvg6459 = ( ( weightedBlendVar6459.x*texArray4917 + weightedBlendVar6459.y*texArray4928 + weightedBlendVar6459.z*texArray4911 )/( weightedBlendVar6459.x + weightedBlendVar6459.y + weightedBlendVar6459.z ) );
			float4 texArray4898 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4890_0, _Texture_11_Albedo_Index)  );
			float4 texArray4914 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4892_0, _Texture_11_Albedo_Index)  );
			float3 weightedBlendVar6461 = BlendComponents91;
			float4 weightedAvg6461 = ( ( weightedBlendVar6461.x*texArray4898 + weightedBlendVar6461.y*texArray4923 + weightedBlendVar6461.z*texArray4914 )/( weightedBlendVar6461.x + weightedBlendVar6461.y + weightedBlendVar6461.z ) );
			float4 lerpResult4988 = lerp( weightedAvg6459 , weightedAvg6461 , UVmixDistance636);
			half4 ifLocalVar6654 = 0;
			UNITY_BRANCH 
			if( _Texture_11_Triplanar == 1.0 )
				ifLocalVar6654 = lerpResult4988;
			else
				ifLocalVar6654 = lerpResult6659;
			half4 ifLocalVar7640 = 0;
			UNITY_BRANCH 
			if( _Texture_11_Albedo_Index > -1.0 )
				ifLocalVar7640 = ( ifLocalVar6654 * _Texture_11_Color );
			half4 Texture_11_Final4996 = ifLocalVar7640;
			float4 texArray4954 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4849_0, _Texture_12_Albedo_Index)  );
			float4 texArray4952 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4932_0, _Texture_12_Albedo_Index)  );
			float4 lerpResult6677 = lerp( texArray4954 , texArray4952 , UVmixDistance636);
			float4 texArray4926 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4758_0, _Texture_12_Albedo_Index)  );
			float4 texArray4927 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4830_0, _Texture_12_Albedo_Index)  );
			float3 weightedBlendVar6466 = BlendComponents91;
			float4 weightedAvg6466 = ( ( weightedBlendVar6466.x*texArray4926 + weightedBlendVar6466.y*texArray4954 + weightedBlendVar6466.z*texArray4927 )/( weightedBlendVar6466.x + weightedBlendVar6466.y + weightedBlendVar6466.z ) );
			float4 texArray4919 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4916_0, _Texture_12_Albedo_Index)  );
			float4 texArray4931 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_4910_0, _Texture_12_Albedo_Index)  );
			float3 weightedBlendVar6468 = BlendComponents91;
			float4 weightedAvg6468 = ( ( weightedBlendVar6468.x*texArray4919 + weightedBlendVar6468.y*texArray4952 + weightedBlendVar6468.z*texArray4931 )/( weightedBlendVar6468.x + weightedBlendVar6468.y + weightedBlendVar6468.z ) );
			float4 lerpResult4993 = lerp( weightedAvg6466 , weightedAvg6468 , UVmixDistance636);
			half4 ifLocalVar6672 = 0;
			UNITY_BRANCH 
			if( _Texture_12_Triplanar == 1.0 )
				ifLocalVar6672 = lerpResult4993;
			else
				ifLocalVar6672 = lerpResult6677;
			half4 ifLocalVar7644 = 0;
			UNITY_BRANCH 
			if( _Texture_12_Albedo_Index > -1.0 )
				ifLocalVar7644 = ( ifLocalVar6672 * _Texture_12_Color );
			half4 Texture_12_Final4997 = ifLocalVar7644;
			float4 layeredBlendVar6528 = appendResult6529;
			float4 layeredBlend6528 = ( lerp( lerp( lerp( lerp( layeredBlend6520 , Texture_9_Final4987 , layeredBlendVar6528.x ) , Texture_10_Final4994 , layeredBlendVar6528.y ) , Texture_11_Final4996 , layeredBlendVar6528.z ) , Texture_12_Final4997 , layeredBlendVar6528.w ) );
			float4 texArray5043 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5037_0, _Texture_13_Albedo_Index)  );
			float4 texArray5034 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5112_0, _Texture_13_Albedo_Index)  );
			float4 lerpResult6683 = lerp( texArray5043 , texArray5034 , UVmixDistance636);
			float4 texArray5128 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5025_0, _Texture_13_Albedo_Index)  );
			float4 texArray5129 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5035_0, _Texture_13_Albedo_Index)  );
			float3 weightedBlendVar6473 = BlendComponents91;
			float4 weightedAvg6473 = ( ( weightedBlendVar6473.x*texArray5128 + weightedBlendVar6473.y*texArray5043 + weightedBlendVar6473.z*texArray5129 )/( weightedBlendVar6473.x + weightedBlendVar6473.y + weightedBlendVar6473.z ) );
			float4 texArray5130 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5123_0, _Texture_13_Albedo_Index)  );
			float4 texArray5121 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5124_0, _Texture_13_Albedo_Index)  );
			float3 weightedBlendVar6475 = BlendComponents91;
			float4 weightedAvg6475 = ( ( weightedBlendVar6475.x*texArray5130 + weightedBlendVar6475.y*texArray5034 + weightedBlendVar6475.z*texArray5121 )/( weightedBlendVar6475.x + weightedBlendVar6475.y + weightedBlendVar6475.z ) );
			float4 lerpResult5054 = lerp( weightedAvg6473 , weightedAvg6475 , UVmixDistance636);
			half4 ifLocalVar6678 = 0;
			UNITY_BRANCH 
			if( _Texture_13_Triplanar == 1.0 )
				ifLocalVar6678 = lerpResult5054;
			else
				ifLocalVar6678 = lerpResult6683;
			half4 ifLocalVar7648 = 0;
			UNITY_BRANCH 
			if( _Texture_13_Albedo_Index > -1.0 )
				ifLocalVar7648 = ( ifLocalVar6678 * _Texture_13_Color );
			half4 Texture_13_Final5058 = ifLocalVar7648;
			float4 texArray5202 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5022_0, _Texture_14_Albedo_Index)  );
			float4 texArray5171 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5172_0, _Texture_14_Albedo_Index)  );
			float4 lerpResult6689 = lerp( texArray5202 , texArray5171 , UVmixDistance636);
			float4 texArray5168 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5009_0, _Texture_14_Albedo_Index)  );
			float4 texArray5239 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5010_0, _Texture_14_Albedo_Index)  );
			float3 weightedBlendVar6480 = BlendComponents91;
			float4 weightedAvg6480 = ( ( weightedBlendVar6480.x*texArray5168 + weightedBlendVar6480.y*texArray5202 + weightedBlendVar6480.z*texArray5239 )/( weightedBlendVar6480.x + weightedBlendVar6480.y + weightedBlendVar6480.z ) );
			float4 texArray5205 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5238_0, _Texture_14_Albedo_Index)  );
			float4 texArray5241 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5233_0, _Texture_14_Albedo_Index)  );
			float3 weightedBlendVar6482 = BlendComponents91;
			float4 weightedAvg6482 = ( ( weightedBlendVar6482.x*texArray5205 + weightedBlendVar6482.y*texArray5171 + weightedBlendVar6482.z*texArray5241 )/( weightedBlendVar6482.x + weightedBlendVar6482.y + weightedBlendVar6482.z ) );
			float4 lerpResult5197 = lerp( weightedAvg6480 , weightedAvg6482 , UVmixDistance636);
			half4 ifLocalVar6684 = 0;
			UNITY_BRANCH 
			if( _Texture_14_Triplanar == 1.0 )
				ifLocalVar6684 = lerpResult5197;
			else
				ifLocalVar6684 = lerpResult6689;
			half4 ifLocalVar7652 = 0;
			UNITY_BRANCH 
			if( _Texture_14_Albedo_Index > -1.0 )
				ifLocalVar7652 = ( ifLocalVar6684 * _Texture_14_Color );
			half4 Texture_14_Final5163 = ifLocalVar7652;
			float4 texArray5259 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5226_0, _Texture_15_Albedo_Index)  );
			float4 texArray5272 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5190_0, _Texture_15_Albedo_Index)  );
			float4 lerpResult6695 = lerp( texArray5259 , texArray5272 , UVmixDistance636);
			float4 texArray5182 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5213_0, _Texture_15_Albedo_Index)  );
			float4 texArray5189 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5224_0, _Texture_15_Albedo_Index)  );
			float3 weightedBlendVar6487 = BlendComponents91;
			float4 weightedAvg6487 = ( ( weightedBlendVar6487.x*texArray5182 + weightedBlendVar6487.y*texArray5259 + weightedBlendVar6487.z*texArray5189 )/( weightedBlendVar6487.x + weightedBlendVar6487.y + weightedBlendVar6487.z ) );
			float4 texArray5188 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5248_0, _Texture_15_Albedo_Index)  );
			float4 texArray5247 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5249_0, _Texture_15_Albedo_Index)  );
			float3 weightedBlendVar6489 = BlendComponents91;
			float4 weightedAvg6489 = ( ( weightedBlendVar6489.x*texArray5188 + weightedBlendVar6489.y*texArray5272 + weightedBlendVar6489.z*texArray5247 )/( weightedBlendVar6489.x + weightedBlendVar6489.y + weightedBlendVar6489.z ) );
			float4 lerpResult5279 = lerp( weightedAvg6487 , weightedAvg6489 , UVmixDistance636);
			half4 ifLocalVar6690 = 0;
			UNITY_BRANCH 
			if( _Texture_15_Triplanar == 1.0 )
				ifLocalVar6690 = lerpResult5279;
			else
				ifLocalVar6690 = lerpResult6695;
			half4 ifLocalVar7656 = 0;
			UNITY_BRANCH 
			if( _Texture_15_Albedo_Index > -1.0 )
				ifLocalVar7656 = ( ifLocalVar6690 * _Texture_15_Color );
			half4 Texture_15_Final5270 = ifLocalVar7656;
			float4 texArray5139 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5083_0, _Texture_16_Albedo_Index)  );
			float4 texArray5143 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5153_0, _Texture_16_Albedo_Index)  );
			float4 lerpResult6701 = lerp( texArray5139 , texArray5143 , UVmixDistance636);
			float4 texArray5150 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5079_0, _Texture_16_Albedo_Index)  );
			float4 texArray5145 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5085_0, _Texture_16_Albedo_Index)  );
			float3 weightedBlendVar6494 = BlendComponents91;
			float4 weightedAvg6494 = ( ( weightedBlendVar6494.x*texArray5150 + weightedBlendVar6494.y*texArray5139 + weightedBlendVar6494.z*texArray5145 )/( weightedBlendVar6494.x + weightedBlendVar6494.y + weightedBlendVar6494.z ) );
			float4 texArray5144 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5147_0, _Texture_16_Albedo_Index)  );
			float4 texArray5154 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_5146_0, _Texture_16_Albedo_Index)  );
			float3 weightedBlendVar6496 = BlendComponents91;
			float4 weightedAvg6496 = ( ( weightedBlendVar6496.x*texArray5144 + weightedBlendVar6496.y*texArray5143 + weightedBlendVar6496.z*texArray5154 )/( weightedBlendVar6496.x + weightedBlendVar6496.y + weightedBlendVar6496.z ) );
			float4 lerpResult5104 = lerp( weightedAvg6494 , weightedAvg6496 , UVmixDistance636);
			half4 ifLocalVar6696 = 0;
			UNITY_BRANCH 
			if( _Texture_16_Triplanar == 1.0 )
				ifLocalVar6696 = lerpResult5104;
			else
				ifLocalVar6696 = lerpResult6701;
			half4 ifLocalVar7661 = 0;
			UNITY_BRANCH 
			if( _Texture_16_Albedo_Index > -1.0 )
				ifLocalVar7661 = ( ifLocalVar6696 * _Texture_16_Color );
			half4 Texture_16_Final5094 = ifLocalVar7661;
			float4 layeredBlendVar6532 = appendResult6533;
			float4 layeredBlend6532 = ( lerp( lerp( lerp( lerp( layeredBlend6528 , Texture_13_Final5058 , layeredBlendVar6532.x ) , Texture_14_Final5163 , layeredBlendVar6532.y ) , Texture_15_Final5270 , layeredBlendVar6532.z ) , Texture_16_Final5094 , layeredBlendVar6532.w ) );
			float4 break3856 = layeredBlend6532;
			float3 appendResult3857 = (half3(break3856.x , break3856.y , break3856.z));
			float3 appendResult7985 = (half3(tex2DNode7984.r , tex2DNode7984.g , tex2DNode7984.b));
			float2 weightedBlendVar7987 = appendResult7986;
			float3 weightedAvg7987 = ( ( weightedBlendVar7987.x*appendResult3857 + weightedBlendVar7987.y*appendResult7985 )/( weightedBlendVar7987.x + weightedBlendVar7987.y ) );
			half2 temp_cast_1 = (( _Geological_Map_Offset_Close + ( ase_worldPos.y / _Geological_Tiling_Close ) )).xx;
			half4 tex2DNode6968 = tex2D( _Texture_Geological_Map, temp_cast_1 );
			float3 appendResult6970 = (half3(tex2DNode6968.r , tex2DNode6968.g , tex2DNode6968.b));
			half2 temp_cast_2 = (( ( ase_worldPos.y / _Geological_Tiling_Far ) + _Geological_Map_Offset_Far )).xx;
			half4 tex2DNode6969 = tex2D( _Texture_Geological_Map, temp_cast_2 );
			float3 appendResult6971 = (half3(tex2DNode6969.r , tex2DNode6969.g , tex2DNode6969.b));
			float3 lerpResult1315 = lerp( ( ( appendResult6970 + float3( -0.3,-0.3,-0.3 ) ) * _Geological_Map_Close_Power ) , ( ( appendResult6971 + float3( -0.3,-0.3,-0.3 ) ) * _Geological_Map_Far_Power ) , UVmixDistance636);
			half3 blendOpSrc4362 = weightedAvg7987;
			half3 blendOpDest4362 = ( lerpResult1315 * ( ( _Texture_16_Geological_Power * Splat4_A2546 ) + ( ( _Texture_15_Geological_Power * Splat4_B2545 ) + ( ( _Texture_14_Geological_Power * Splat4_G2544 ) + ( ( _Texture_13_Geological_Power * Splat4_R2543 ) + ( ( _Texture_12_Geological_Power * Splat3_A2540 ) + ( ( _Texture_11_Geological_Power * Splat3_B2539 ) + ( ( _Texture_10_Geological_Power * Splat3_G2538 ) + ( ( _Texture_9_Geological_Power * Splat3_R2537 ) + ( ( _Texture_8_Geological_Power * Splat2_A2109 ) + ( ( _Texture_7_Geological_Power * Splat2_B2108 ) + ( ( _Texture_6_Geological_Power * Splat2_G2107 ) + ( ( _Texture_5_Geological_Power * Splat2_R2106 ) + ( ( _Texture_1_Geological_Power * Splat1_R1438 ) + ( ( _Texture_2_Geological_Power * Splat1_G1441 ) + ( ( _Texture_4_Geological_Power * Splat1_A1491 ) + ( _Texture_3_Geological_Power * Splat1_B1442 ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) ) );
			float4 texArray4378 = UNITY_SAMPLE_TEX2DARRAY(_Texture_Array_Albedo, float3(temp_output_3893_0, _Texture_Snow_Index)  );
			float4 lerpResult1416 = lerp( texArray4378 , _Texture_Snow_Average , UVmixDistance636);
			half4 ifLocalVar7802 = 0;
			UNITY_BRANCH 
			if( _Texture_Snow_Index > -1.0 )
				ifLocalVar7802 = ( lerpResult1416 * _Snow_Color );
			float4 break1409 = ifLocalVar7802;
			float3 appendResult1410 = (half3(break1409.x , break1409.y , break1409.z));
			half3 In08016 = float3( 0,0,0 );
			half localMyCustomExpression8016 = MyCustomExpression8016( In08016 );
			float3 break8017 = _WorldSpaceCameraPos;
			float temp_output_8022_0 = ( _Glitter_Refreshing_Speed * ( ( localMyCustomExpression8016 * 10.0 ) + ( break8017.x + break8017.y + break8017.z ) ) );
			float temp_output_8024_0 = ( 0.0 + temp_output_8022_0 );
			float clampResult8041 = clamp( sin( ( temp_output_8024_0 * 0.1 ) ) , 0.0 , 1.0 );
			float2 temp_output_8029_0 = ( Top_Bottom1999 * ( 1.0 / _Glitter_Tiling ) );
			float2 break8061 = temp_output_8029_0;
			float2 appendResult8060 = (half2(break8061.y , break8061.x));
			half4 tex2DNode8044 = tex2D( _Texture_Glitter, ( appendResult8060 + float2( 0.37,0.67 ) ) );
			float2 panner8031 = ( ( temp_output_8022_0 * 0.01 ) * float2( 1,1 ) + temp_output_8029_0);
			float cos8032 = cos( sin( ( temp_output_8024_0 * 0.0001 ) ) );
			float sin8032 = sin( sin( ( temp_output_8024_0 * 0.0001 ) ) );
			float2 rotator8032 = mul( panner8031 - float2( 0.5,0.5 ) , float2x2( cos8032 , -sin8032 , sin8032 , cos8032 )) + float2( 0.5,0.5 );
			float clampResult8045 = clamp( pow( tex2D( _Texture_Glitter, ( ( rotator8032 + temp_output_8029_0 ) * float2( 0.2,0.2 ) ) ).r , ( 1.0 - _Glitter_Noise_Threshold ) ) , 0.0 , 1.0 );
			float lerpResult8048 = lerp(  ( clampResult8041 - 0.2 > 0.0 ? tex2D( _Texture_Glitter, temp_output_8029_0 ).r : clampResult8041 - 0.2 <= 0.0 && clampResult8041 + 0.2 >= 0.0 ? tex2DNode8044.r : tex2DNode8044.r )  , 0.6 , clampResult8045);
			float clampResult8051 = clamp( pow( lerpResult8048 , 100.0 ) , 0.0 , 1.0 );
			float temp_output_8056_0 = ( _Gliter_Color_Power * clampResult8051 );
			float3 lerpResult1356 = lerp( ( saturate( ( blendOpSrc4362 + blendOpDest4362 ) )) , ( appendResult1410 + temp_output_8056_0 ) , HeightMask6539);
			o.Albedo = lerpResult1356;
			float3 clampResult6245 = clamp( appendResult1410 , float3( 0,0,0 ) , float3( 0.5,0.5,0.5 ) );
			half3 temp_cast_3 = (_Glitter_Specular).xxx;
			float clampResult8052 = clamp( temp_output_8056_0 , 0.0 , 1.0 );
			float3 lerpResult8057 = lerp( ( clampResult6245 * _Snow_Specular ) , temp_cast_3 , clampResult8052);
			float3 lerpResult4040 = lerp( ( ( appendResult3857 * float3( 0.3,0.3,0.3 ) ) * _Terrain_Specular ) , lerpResult8057 , HeightMask6539);
			o.Specular = lerpResult4040;
			float lerpResult8058 = lerp( break1409.w , _Glitter_Smoothness , clampResult8052);
			float lerpResult3951 = lerp( ( break3856.w * _Terrain_Smoothness ) , lerpResult8058 , HeightMask6539);
			o.Smoothness = lerpResult3951;
			float temp_output_6501_0 = ( 1.0 - _Ambient_Occlusion_Power );
			float clampResult6709 = clamp( ( ( 1.0 + temp_output_4100_0.y ) * 0.5 ) , temp_output_6501_0 , 1.0 );
			float clampResult6284 = clamp( break7905.y , ( 1.0 - _Texture_1_AO_Power ) , 1.0 );
			float clampResult6290 = clamp( break7906.y , ( 1.0 - _Texture_2_AO_Power ) , 1.0 );
			float clampResult6295 = clamp( break7907.y , ( 1.0 - _Texture_3_AO_Power ) , 1.0 );
			float clampResult6300 = clamp( break7908.y , ( 1.0 - _Texture_4_AO_Power ) , 1.0 );
			float4 layeredBlendVar7673 = appendResult6517;
			float layeredBlend7673 = ( lerp( lerp( lerp( lerp( 0.0 , clampResult6284 , layeredBlendVar7673.x ) , clampResult6290 , layeredBlendVar7673.y ) , clampResult6295 , layeredBlendVar7673.z ) , clampResult6300 , layeredBlendVar7673.w ) );
			float clampResult6305 = clamp( break7910.y , ( 1.0 - _Texture_5_AO_Power ) , 1.0 );
			float clampResult6310 = clamp( break7911.y , ( 1.0 - _Texture_6_AO_Power ) , 1.0 );
			float clampResult6315 = clamp( break7912.y , ( 1.0 - _Texture_7_AO_Power ) , 1.0 );
			float clampResult6320 = clamp( break7913.y , ( 1.0 - _Texture_8_AO_Power ) , 1.0 );
			float4 layeredBlendVar7714 = appendResult6524;
			float layeredBlend7714 = ( lerp( lerp( lerp( lerp( layeredBlend7673 , clampResult6305 , layeredBlendVar7714.x ) , clampResult6310 , layeredBlendVar7714.y ) , clampResult6315 , layeredBlendVar7714.z ) , clampResult6320 , layeredBlendVar7714.w ) );
			float clampResult6325 = clamp( break7915.y , ( 1.0 - _Texture_9_AO_Power ) , 1.0 );
			float clampResult6330 = clamp( break7916.y , ( 1.0 - _Texture_10_AO_Power ) , 1.0 );
			float clampResult6335 = clamp( break7917.y , ( 1.0 - _Texture_11_AO_Power ) , 1.0 );
			float clampResult6340 = clamp( break7918.y , ( 1.0 - _Texture_12_AO_Power ) , 1.0 );
			float4 layeredBlendVar7715 = appendResult6529;
			float layeredBlend7715 = ( lerp( lerp( lerp( lerp( layeredBlend7714 , clampResult6325 , layeredBlendVar7715.x ) , clampResult6330 , layeredBlendVar7715.y ) , clampResult6335 , layeredBlendVar7715.z ) , clampResult6340 , layeredBlendVar7715.w ) );
			float clampResult6345 = clamp( break7920.y , ( 1.0 - _Texture_13_AO_Power ) , 1.0 );
			float clampResult6350 = clamp( break7921.y , ( 1.0 - _Texture_14_AO_Power ) , 1.0 );
			float clampResult6355 = clamp( break7922.y , ( 1.0 - _Texture_15_AO_Power ) , 1.0 );
			float clampResult6360 = clamp( break7923.y , ( 1.0 - _Texture_16_AO_Power ) , 1.0 );
			float4 layeredBlendVar7716 = appendResult6533;
			float layeredBlend7716 = ( lerp( lerp( lerp( lerp( layeredBlend7715 , clampResult6345 , layeredBlendVar7716.x ) , clampResult6350 , layeredBlendVar7716.y ) , clampResult6355 , layeredBlendVar7716.z ) , clampResult6360 , layeredBlendVar7716.w ) );
			float lerpResult7968 = lerp( texArray7491.w , 1.0 , UVmixDistance636);
			float clampResult6536 = clamp( lerpResult7968 , ( 1.0 - _Snow_Ambient_Occlusion_Power ) , 1.0 );
			half ifLocalVar7711 = 0;
			UNITY_BRANCH 
			if( _Texture_Snow_H_AO_Index > -1.0 )
				ifLocalVar7711 = clampResult6536;
			float lerpResult6364 = lerp( layeredBlend7716 , ifLocalVar7711 , HeightMask6539);
			float clampResult6502 = clamp( lerpResult6364 , temp_output_6501_0 , 1.0 );
			#ifdef _USE_AO_TEXTURE_ON
				float staticSwitch7665 = clampResult6502;
			#else
				float staticSwitch7665 = clampResult6709;
			#endif
			#ifdef _USE_AO_ON
				float staticSwitch7666 = staticSwitch7665;
			#else
				float staticSwitch7666 = 1.0;
			#endif
			o.Occlusion = staticSwitch7666;
			o.Alpha = 1;
			float2 uv_TerrainHolesTexture = i.uv_texcoord * _TerrainHolesTexture_ST.xy + _TerrainHolesTexture_ST.zw;
			float clampResult7995 = clamp( ( ase_worldPos.y + ( 0.0 - _Remove_Vert_Height ) ) , 0.0 , 1.0 );
			clip( ( tex2D( _TerrainHolesTexture, uv_TerrainHolesTexture ).r * clampResult7995 ) - _Cutoff );
			MixedNormal(o.Normal, i.tc.zw);

		}

		ENDCG
		CGPROGRAM
		#pragma surface surf StandardSpecular keepalpha fullforwardshadows vertex:SplatmapVert

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.5
			#pragma multi_compile_shadowcaster
			#pragma multi_compile UNITY_PASS_SHADOWCASTER
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			#include "HLSLSupport.cginc"
			#if ( SHADER_API_D3D11 || SHADER_API_GLCORE || SHADER_API_GLES || SHADER_API_GLES3 || SHADER_API_METAL || SHADER_API_VULKAN )
				#define CAN_SKIP_VPOS
			#endif
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityPBSLighting.cginc"
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float2 customPack1 : TEXCOORD1;
				float4 tSpace0 : TEXCOORD2;
				float4 tSpace1 : TEXCOORD3;
				float4 tSpace2 : TEXCOORD4;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			v2f vert( appdata_full v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_INITIALIZE_OUTPUT( v2f, o );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				Input customInputData;
				SplatmapVert(v, customInputData);
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				half3 worldTangent = UnityObjectToWorldDir( v.tangent.xyz );
				half tangentSign = v.tangent.w * unity_WorldTransformParams.w;
				half3 worldBinormal = cross( worldNormal, worldTangent ) * tangentSign;
				o.tSpace0 = float4( worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x );
				o.tSpace1 = float4( worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y );
				o.tSpace2 = float4( worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z );
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				return o;
			}
			half4 frag( v2f IN
			#if !defined( CAN_SKIP_VPOS )
			, UNITY_VPOS_TYPE vpos : VPOS
			#endif
			) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				Input surfIN;
				UNITY_INITIALIZE_OUTPUT( Input, surfIN );
				surfIN.uv_texcoord = IN.customPack1.xy;
				float3 worldPos = float3( IN.tSpace0.w, IN.tSpace1.w, IN.tSpace2.w );
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				surfIN.worldPos = worldPos;
				surfIN.worldNormal = float3( IN.tSpace0.z, IN.tSpace1.z, IN.tSpace2.z );
				surfIN.internalSurfaceTtoW0 = IN.tSpace0.xyz;
				surfIN.internalSurfaceTtoW1 = IN.tSpace1.xyz;
				surfIN.internalSurfaceTtoW2 = IN.tSpace2.xyz;
				SurfaceOutputStandardSpecular o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputStandardSpecular, o )
				surf( surfIN, o );
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
		UsePass "Hidden/Nature/Terrain/Utilities/PICKING"
		 UsePass "Hidden/Nature/Terrain/Utilities/SELECTION"

	}

	Dependency "BaseMapShader"="CTS/CTS Terrain Shader Advanced LOD CutOut"
	Fallback "Diffuse"
}