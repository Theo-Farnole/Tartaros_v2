Welcome to CTS - the Complete Terrain Shader!
================================

The CTS terrain shader is a profile driven shader, which means that you can generate as many profiles as you like, and apply them any time you want. 

CTS profiles keep their settings as you switch between design time and runtime. This allows you to configure your profile exactly the way you want in game, and retained the settings when you exit back to editor mode.

SETUP :

1. Set your lighting to linear / deferred for best visuals.
Window -> Procedural Worlds -> CTS -> Set Linear Deferred

2. Create a terrain and add your textures (CTS supports up to 16 textures).

3. Add CTS to your terrain.
Component -> CTS -> Add CTS To Terrain 
or
Window -> Procedural Worlds -> CTS -> Add CTS To Terrain

4. Create a new CTS profile and apply it to the terrain:
Window -> Procedural Worlds -> CTS -> Create And Apply Profile

5. Select your CTS Profile:
New profiles are created in the CTS / Profiles directory. You can apply an existing profile to a terrain by selecting it and hitting the 'Apply Profile' button. NOTE : Applying a profile will overwrite any textures that were previously stored in the terrain.

6. Edit your CTS Profile:
Select and apply the CTS profile. You can then edit the profile in the inspector and changes will be reflected into the terrain in real time. When the profile turns RED then you will need to re-bake your texures for the changes to be applied to your terrain. This only needs to be done when you make changes to the textures.

RENDERING PIPELINES:
If you plan to use rendering piplines (HDRP/LWRP/URP) in your project, you need to install additional packages from the package manager. Please install the EXACT Version of the SRP packages

SRP Version 4.8 in Unity 2018.3 & 2018.4
SRP Version 5.7.2 in Unity 2019.1
SRP Version 6.9.1 in Unity 2019.2
SRP Version 7.2.0 to 7.3.1 in Unity 2019.3

Choosing the right version is important, the shaders were specifically made for those versions and might not work correctly in different SRP versions!

When you change the rendering Pipeline, CTS should detect that and display a popup notification that you need to install different shaders to match the pipeline. You can then start the
shader installation process from 
Window -> Procedural Worlds -> CTS -> Install Shaders

If your terrain does not display correctly after the shader installation, try to re-apply the profile.

TERRAIN HOLES:
To use the Unity Terrain Holes feature together with CTS, activate the "Use Cutout" feature in the CTS component. It should then display terrain holes drawn with the terrain inspector. The original controls for cutouts / holes in CTS will still work, so you can use them in addition to the hole painting system.

FOOTSTEPS :
If you use an asset that relies on terrain splatmaps being present to control how your footsteps sound, please de-select 'Strip Textures' in your Optimisation Settings on your profile.

POST FX :
If you want to use the Post FX in the demos please install the Unity Post Processing Stack V2 from the package manager. (Window > Package Manager)

BUILDING:
You can optimize your terrain for build by disconnecting your CTS profile from the terrain for a build. You can find a "Disconnect profile" button on the CTS component.

Disconnecting a profile will:
-Create a persistent material in the Profiles\Material folder
-Create persistent copy of the terrain splatmaps in the Profiles\Splatmaps folder
-Remove references to the CTS profile, normal, color map and cutout mask texture
-Remove all splatmap prototypes / terrain layers from the terrain
-Remove all splatmaps from the terrain data object

This results in a terrain with as little texture references as possible for reduced build size / runtime memory usage / runtime material creation performance. If you want to continue working on your terrain, you can do so by reconnecting the CTS profile.

Connecting a profile will
-Re-apply the last used CTS profile to the terrain to restore a full editable state again (as before the disconnect)
-Restore all splatmap prototypes / terrain layers on the terrain (based on the CTS profile info)
-Restore the  profile, normal, color map and cutout mask texture in the CTS component
-Restore the terrain splatmaps in the terrain data object from the persistent copies

You can disconnect / reconnect via a button on the CTS component on the terrain, or perform these operation en masse with two new Window menu entries:

Disconnect ALL Terrains
Reconnect ALL Terrains

This system is limited in so far as that it relies on the associated files staying intact between disconnect and reconnect. If you would delete the persistent copies of the splatmaps for example, it is not possible to restore the splatmap again later on reconnect. It is recommended to use this only before/after a build and to back up your project first.

INCLUDING CTS SHADER VARIANTS IN THE BUILD:

Depending on how you build your project, it may be required to add the CTS shaders and their variants in your build manually. This would be the case if you can't see the terrain in a build or the terrain comes out pink.

To influence which shaders are included in a project, open the following window:

Edit > Project Settings > Graphics

Here you can add the CTS Shaders that your project uses in the "always included shader list". This will however compile all possible variants for this shader, which can take quite some time during building. 

An alternative would be to include only the required shader variants in a Shader variants file:
To do so, click the small "Clear" button at the bottom in the graphics window.
Leave the graphics window open and start the your project in the editor, and then visit all the scenes / terrains in your project that use a CTS shader. If you have 100 terrains in your project that all use the same shader type, visiting one of those terrains is enough. The goal is to "record" the used shader types in a scene with Unity.
You should see at the bottom of the graphics window that the number of tracked shaders increases as you run your project.
After you are done viewing all your scenes that you want to include in your build, you can click "Save To Asset" to put all of the recorded shader variants in a file and then you can put that file in the "Preloaded Shader" list.

To learn more about optimizing the included shader variants in a build, please visit: https://docs.unity3d.com/Manual/OptimizingShaderLoadTime.html

RUNTIME TERRAIN / MAP MAGIC SUPPORT :
Check out CTSRuntimeTerrainHelper.cs in the scripts directory. Details of how to use it have been added into the introduction. A proper Map Magic integration has been created by its author.

There currently is an issue with runtime switching profiles in a build when "Draw Instanced" is enabled. We assume this is either an Unity bug or "by design" regarding the instanced feature, but there is a workaround if needed: If you need to switch between CTS Profiles on an instanced terrain during runtime, you can build a dummy scene that includes instanced terrains with the required CTS profiles on them, and include the dummy scene in the build. The switch between the profiles in your actual scene should work then correctly.
SUBSTANCE SUPPORT:
CTS comes with built in support for Allegorithmics / Adobes Substance sytem. In Unity versions with native Substance support (below 2018.1) you can just assign substances in the Profile texture slots. In Unity versions without native Substance support (2018.1+) you will need to install the Allegorithmic Substance plugin from the asset store:
https://assetstore.unity.com/packages/tools/utilities/substance-in-unity-110555
Once the plugin is installed, you will be able to assign substances in the CTS Profile just as with native support before.

PERFORMANCE :
We have include some handy System Metrics and a FPS script in the Prefabs directory. It will tyically show less than half the framerate that Unity shows in the editor, but when we compared it against NVidia's FPS information it seemed a lot more accurate. Drag this into your scene to get a more realistic view of your runtime frame rate. In a runtime build you can also expect 2-4x better framerates that what we show in the editor.

WEATHER :
To add weather to your terrain select Window -> Procedural Worlds -> CTS -> Add Weather Manager. You can then use this interface to control how your terrain responds to different weather. If you are integrating via script, CTS will signal its presence via the CTS_PRESENT define.

World Manager API :
To add world manager API to your terrain select Window -> Procedural Worlds -> CTS -> Add World Manager API. You can control how your terrain responds to weather via the World Manager API. Learn more here : http://www.procedural-worlds.com/blog/wapi/

DEMOS : 
You can run the demos in the Demo directory. To take advantage of the post effects used you will also need to install the Unity Post Processing V2 Stack from the Package Manager (Window > Package Manager)

Please note: The demo scenes were created in Unity 2018.3 under usage of the Terrain Layer and Neighbor system. When you open these scenes in earlier versions of Unity you might run into issues because of this, this should however not impact the general functionality of CTS in any way.

HELP : 
CTS is self documenting, so to get help on any component, just hit the ? at the top of the component. Additional help and video tutorials can be found at http://www.procedural-worlds.com/cts/.

NOTE : 
Do not delete this readme file. It is used to locate where CTS has been placed in your project, and removing it will break CTS.

ABOUT : 
CTS is proudly bought to you by Bartlomiej Galas (Nature Manufacture) & Adam Goodrich (Procedural Worlds). Many thanks to the team at Amplify, Szymon Wojciak, Pawel Homenko and the CTS beta team for their help in bringing CTS to life!

Enjoy!!