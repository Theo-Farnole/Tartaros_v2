// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tartaros/SH_FogOfWar_V4"
{
	Properties
	{
		[HDR]_UndiscoveredColor("UndiscoveredColor", Color) = (0.0755705,0.0755705,0.0755705,1)
		[HDR]_DiscoveredColor("DiscoveredColor", Color) = (2,0.5866007,0,1)
		_TextureSample2("Texture Sample 2", 2D) = "white" {}
		_TextureSample3("Texture Sample 3", 2D) = "white" {}
		_OpacityLerp("OpacityLerp", Float) = 0.5
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" }
		Cull Back
		AlphaToMask On
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 5.0
		#pragma surface surf Standard alpha:fade keepalpha noshadow vertex:vertexDataFunc 
		struct Input
		{
			float4 vertexToFrag217;
		};

		uniform float4 _UndiscoveredColor;
		uniform sampler2D _TextureSample2;
		float4x4 unity_Projector;
		uniform float4 _DiscoveredColor;
		uniform sampler2D _TextureSample3;
		uniform float _OpacityLerp;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float4 ase_vertex4Pos = v.vertex;
			o.vertexToFrag217 = mul( unity_Projector, ase_vertex4Pos );
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 UV221 = ( (i.vertexToFrag217).xy / (i.vertexToFrag217).w );
			float4 DontClearMap562 = tex2D( _TextureSample2, UV221 );
			float4 albedo549 = ( ( _UndiscoveredColor * ( 1.0 - DontClearMap562 ) ) + ( DontClearMap562 * _DiscoveredColor ) );
			o.Albedo = albedo549.rgb;
			float4 ClearMap563 = tex2D( _TextureSample3, UV221 );
			float4 lerpResult589 = lerp( ( 1.0 - ClearMap563 ) , ( 1.0 - DontClearMap562 ) , _OpacityLerp);
			float4 opacityMask551 = lerpResult589;
			o.Alpha = opacityMask551.r;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
247;73;1289;655;9795.764;-856.3351;1.100798;True;False
Node;AmplifyShaderEditor.CommentaryNode;587;-9425.72,-790.5472;Inherit;False;1620.48;2603.372;Comment;11;541;573;568;544;551;582;569;571;588;589;590;BASE;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;571;-9366.449,-548.2471;Inherit;False;1129.634;557.287;Comment;5;517;518;525;562;563;Textures;1,1,1,1;0;0
Node;AmplifyShaderEditor.GetLocalVarNode;517;-9320.295,-463.7961;Inherit;False;221;UV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;518;-8942.871,-488.2471;Inherit;True;Property;_TextureSample2;Texture Sample 2;9;0;Create;True;0;0;False;0;False;-1;0be5428491ac8a04483b5bc91fb068f6;0be5428491ac8a04483b5bc91fb068f6;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.CommentaryNode;588;-9343.334,237.8856;Inherit;False;1426.271;663.9314;Comment;8;549;583;564;585;543;586;584;539;Colors State 2 & 3;1,1,1,1;0;0
Node;AmplifyShaderEditor.SamplerNode;525;-8920.61,-220.9604;Inherit;True;Property;_TextureSample3;Texture Sample 3;11;0;Create;True;0;0;False;0;False;-1;4f79457e6662c064cbf77b6bca8e6023;4f79457e6662c064cbf77b6bca8e6023;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;562;-8529.815,-460.0263;Inherit;False;DontClearMap;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;564;-9249.977,546.7511;Inherit;False;562;DontClearMap;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;563;-8526.872,-182.7406;Inherit;False;ClearMap;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;583;-8974.706,497.4805;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;539;-9293.334,287.8856;Inherit;False;Property;_UndiscoveredColor;UndiscoveredColor;4;1;[HDR];Create;True;0;0;False;0;False;0.0755705,0.0755705,0.0755705,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;584;-9284.673,694.8171;Inherit;False;Property;_DiscoveredColor;DiscoveredColor;5;1;[HDR];Create;True;0;0;False;0;False;2,0.5866007,0,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;573;-9392.229,1193.364;Inherit;False;563;ClearMap;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;568;-9402.412,1297.957;Inherit;False;562;DontClearMap;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;543;-8718.928,356.4404;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;590;-9207.227,1413.114;Inherit;False;Property;_OpacityLerp;OpacityLerp;16;0;Create;True;0;0;False;0;False;0.5;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;544;-9172.541,1197.022;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;586;-8720.429,647.3817;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;541;-9165.622,1300.072;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;589;-8928.04,1220.907;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;585;-8431.468,504.9303;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.CommentaryNode;561;-9926.223,-5482.976;Inherit;False;4998.767;3544.588;Comment;10;223;324;321;331;330;327;329;373;335;334;OLD;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;331;-8041.873,-4829.455;Inherit;False;2761.01;547.0185;Comment;13;191;292;189;126;240;245;237;326;269;328;323;332;338;RenderToEmission;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;223;-9761.454,-4905.689;Inherit;False;1386.459;466.5935;Comment;8;221;220;219;218;217;216;215;214;UV;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;551;-8233.945,1232.466;Inherit;True;opacityMask;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;549;-8160.062,501.1918;Inherit;True;albedo;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.CommentaryNode;324;-9341.652,-3030.582;Inherit;False;1151.406;850.3862;Comment;12;213;1;2;225;226;317;278;318;279;319;354;356;Textures;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;330;-8009.405,-3804.062;Inherit;False;2277.56;454.6017;Comment;9;372;249;242;333;277;231;236;238;229;RenderToOpacity;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;327;-7539.33,-2792.027;Inherit;False;1200.205;508.7923;Comment;7;293;297;296;264;294;265;325;ExteriorMap;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;321;-9715.055,-4021.989;Inherit;False;1323.613;483.8406;Comment;6;283;280;286;285;282;322;Voronoi;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;338;-6066.723,-4656.007;Inherit;False;InteriorMap;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.PosVertexDataNode;214;-9711.454,-4775.689;Inherit;False;1;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;323;-6654.913,-4765.335;Inherit;False;322;Voronoi;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;329;-5170.456,-3951.992;Inherit;True;Opacity;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;240;-6635.307,-4631.499;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;220;-8879.454,-4855.689;Inherit;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ScreenColorNode;293;-7489.331,-2738.534;Inherit;False;Global;_GrabScreen0;Grab Screen 0;17;0;Create;True;0;0;False;0;False;Object;-1;False;False;1;0;FLOAT2;0,0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;328;-5483.466,-4628.108;Inherit;False;Emission;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;242;-6540.612,-3748.933;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;225;-8420.476,-2967.053;Inherit;False;Revealated;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;216;-9503.454,-4855.689;Inherit;False;2;2;0;FLOAT4x4;0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.GradientSampleNode;279;-8797.915,-2509.578;Inherit;True;2;0;OBJECT;;False;1;FLOAT;0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;221;-8639.769,-4837.126;Float;False;UV;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;213;-9116.449,-2858.569;Inherit;False;221;UV;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Compare;191;-7733.972,-4542.469;Inherit;True;2;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;1;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;335;-5432.041,-2337.415;Inherit;False;329;Opacity;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;286;-9408.905,-3885.898;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;332;-6682.806,-4472.4;Inherit;False;SmoothRevelated;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LengthOpNode;317;-9291.652,-2434.196;Inherit;True;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;333;-6861.987,-3745.161;Inherit;False;332;SmoothRevelated;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;285;-9665.055,-3971.988;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;189;-7084.243,-4536.437;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;1;-8781.799,-2980.582;Inherit;True;Property;_TextureSample0;Texture Sample 0;2;0;Create;True;0;0;False;0;False;-1;0be5428491ac8a04483b5bc91fb068f6;0be5428491ac8a04483b5bc91fb068f6;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;296;-7264.977,-2733.78;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;229;-7959.405,-3737.746;Inherit;False;226;Discovered;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;322;-8640.496,-3785.105;Inherit;False;Voronoi;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;326;-6063.519,-4539.474;Inherit;False;325;ExteriorMap;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;582;-8605.982,1326.89;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;269;-5790.939,-4619.324;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.VertexColorNode;354;-9278.801,-2675.636;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;231;-7251.662,-3732.213;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;-0.33;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;219;-9119.454,-4855.689;Inherit;False;True;True;False;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;245;-6346.8,-4650.695;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;529;-11005.75,421.8217;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;2;-8782.138,-2768.432;Inherit;True;Property;_TextureSample1;Texture Sample 1;3;0;Create;True;0;0;False;0;False;-1;4f79457e6662c064cbf77b6bca8e6023;4f79457e6662c064cbf77b6bca8e6023;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;569;-8742.866,1134.6;Inherit;False;563;ClearMap;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;126;-7079.984,-4750.137;Inherit;False;Property;_RimColor;RimColor;0;1;[HDR];Create;True;0;0;False;0;False;2,0.5866007,0,1;1,1,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.UnityProjectorMatrixNode;215;-9711.454,-4855.689;Inherit;False;0;1;FLOAT4x4;0
Node;AmplifyShaderEditor.Vector3Node;282;-9658.691,-3799.438;Inherit;False;Property;_VoroController;VoroController;7;0;Create;True;0;0;False;0;False;0,1,1;1,50,2;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RegisterLocalVarNode;226;-8414.246,-2754.344;Inherit;False;Discovered;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.VertexToFragmentNode;217;-9359.454,-4855.689;Inherit;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;319;-8442.183,-2506.13;Inherit;False;Blur;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;249;-6161.699,-3743.019;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;218;-9119.454,-4775.689;Inherit;False;False;False;False;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;373;-5478.661,-3973.239;Inherit;False;372;RTO;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;297;-7485.978,-2568.78;Inherit;False;Property;_WorldPower;WorldPower;10;0;Create;True;0;0;False;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;356;-9056.745,-2343.717;Inherit;False;-1;;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;522;-11994.74,-32.15841;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.01;False;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;280;-9237.349,-3848.775;Inherit;True;0;0;1;3;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.RangedFloatNode;521;-11719.38,744.7164;Inherit;False;Property;_VoroPower;VoroPower;12;0;Create;True;0;0;False;0;False;1;0.92;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCGrayscale;294;-7087.73,-2742.027;Inherit;True;0;1;0;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;334;-5434.644,-2504.85;Inherit;False;328;Emission;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;528;-11821.7,-102.7468;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VoronoiNode;554;-11431.96,-257.8873;Inherit;True;0;0;1;0;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.ColorNode;264;-7110.053,-2495.235;Inherit;False;Property;_PaternColor;PaternColor;1;1;[HDR];Create;True;0;0;False;0;False;2,0.5866007,0,1;1,0.2627451,0,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VoronoiNode;519;-11948.29,535.9933;Inherit;True;0;0;1;0;6;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.Vector2Node;238;-7653.006,-3487.685;Inherit;False;Property;_DiscoveredStep;DiscoveredStep;6;0;Create;True;0;0;False;0;False;0,0;0,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;515;-12209.94,627.9275;Inherit;False;Property;_VoroScale;VoroScale;13;0;Create;True;0;0;False;0;False;1;10;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;558;-7475.092,452.0349;Inherit;False;551;opacityMask;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;325;-6563.125,-2629.853;Inherit;False;ExteriorMap;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.VoronoiNode;534;-11484.23,64.04618;Inherit;True;0;0;1;3;8;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.Compare;236;-7674.649,-3736.312;Inherit;True;2;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;1;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;283;-8812.328,-3779.729;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;277;-6855.077,-3612.937;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;265;-6821.107,-2617.363;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GradientNode;278;-9021.913,-2519.578;Inherit;False;0;2;2;0,0,0,0;1,1,1,1;1,0;1,1;0;1;OBJECT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;372;-5962.01,-3748.698;Inherit;False;RTO;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;292;-7373.685,-4449.108;Inherit;False;Property;_RevelatedPercent;RevelatedPercent;8;0;Create;True;0;0;False;0;False;0.5;0.84;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;318;-9068.852,-2416.948;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;531;-11182.65,167.0347;Inherit;False;Property;_SmoothStep;SmoothStep;15;0;Create;True;0;0;False;0;False;0,1;-0.36,0.7;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;524;-11548.19,521.2995;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;516;-12001.63,336.5852;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.2;False;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;513;-12240.92,30.94291;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;237;-7991.876,-4544.743;Inherit;False;225;Revealated;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;527;-11749.92,215.7315;Inherit;False;Property;_VoroScaleRim;VoroScaleRim;14;0;Create;True;0;0;False;0;False;1;500;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;538;-10938.87,1.00809;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0.2;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;552;-7479.916,215.3387;Inherit;False;549;albedo;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-6920.212,235.9775;Float;False;True;-1;7;ASEMaterialInspector;0;0;Standard;Tartaros/SH_FogOfWar_V4;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.01;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;2;5;False;-1;10;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;True;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;518;1;517;0
WireConnection;525;1;517;0
WireConnection;562;0;518;0
WireConnection;563;0;525;0
WireConnection;583;0;564;0
WireConnection;543;0;539;0
WireConnection;543;1;583;0
WireConnection;544;0;573;0
WireConnection;586;0;564;0
WireConnection;586;1;584;0
WireConnection;541;0;568;0
WireConnection;589;0;544;0
WireConnection;589;1;541;0
WireConnection;589;2;590;0
WireConnection;585;0;543;0
WireConnection;585;1;586;0
WireConnection;551;0;589;0
WireConnection;549;0;585;0
WireConnection;338;0;245;0
WireConnection;329;0;373;0
WireConnection;240;0;126;0
WireConnection;240;1;189;0
WireConnection;220;0;219;0
WireConnection;220;1;218;0
WireConnection;328;0;269;0
WireConnection;242;0;333;0
WireConnection;242;1;277;0
WireConnection;225;0;1;0
WireConnection;216;0;215;0
WireConnection;216;1;214;0
WireConnection;279;0;278;0
WireConnection;279;1;318;0
WireConnection;221;0;220;0
WireConnection;191;0;237;0
WireConnection;286;0;282;1
WireConnection;286;1;285;2
WireConnection;332;0;189;0
WireConnection;317;0;213;0
WireConnection;189;0;191;0
WireConnection;189;1;292;0
WireConnection;1;1;213;0
WireConnection;296;0;293;0
WireConnection;296;1;297;0
WireConnection;322;0;283;0
WireConnection;269;0;338;0
WireConnection;269;1;326;0
WireConnection;231;0;236;0
WireConnection;231;1;238;1
WireConnection;231;2;238;2
WireConnection;219;0;217;0
WireConnection;245;0;323;0
WireConnection;245;1;240;0
WireConnection;529;0;524;0
WireConnection;2;1;213;0
WireConnection;226;0;2;0
WireConnection;217;0;216;0
WireConnection;319;0;279;0
WireConnection;249;0;242;0
WireConnection;218;0;217;0
WireConnection;522;0;513;1
WireConnection;280;1;286;0
WireConnection;280;2;282;2
WireConnection;294;0;296;0
WireConnection;528;1;522;0
WireConnection;554;1;513;3
WireConnection;554;2;527;0
WireConnection;519;1;516;0
WireConnection;519;2;515;0
WireConnection;325;0;265;0
WireConnection;534;0;528;0
WireConnection;534;1;513;2
WireConnection;534;2;527;0
WireConnection;236;0;229;0
WireConnection;283;0;280;0
WireConnection;283;1;282;3
WireConnection;277;0;231;0
WireConnection;265;0;294;0
WireConnection;265;1;264;0
WireConnection;372;0;249;0
WireConnection;318;0;317;0
WireConnection;524;0;519;0
WireConnection;524;1;521;0
WireConnection;516;0;513;4
WireConnection;538;0;534;0
WireConnection;538;1;531;1
WireConnection;538;2;531;2
WireConnection;0;0;552;0
WireConnection;0;9;558;0
ASEEND*/
//CHKSM=C5D680D72FFFB56DE3CB2A2042AA2ECAF5AC1DA4