MsgPack for Unity
===

## Overview

An extension that makes [MsgPack-Cli](https://github.com/msgpack/MsgPack-Cli) easy to use for Unity.
For details on how to use MsgPack-Cli, please see [here](https://github.com/msgpack/msgpack-cli).

* Install with unitypackage
    * You can easily install MsgPack-Cli from [unitypackage](https://github.com/mob-sakai/MsgPack-Cli/raw/master/unity/MsgPack-Cli.unitypackage).
* Generate Serializer(for IL2CPP)
    * Generate serializers easily from menu, WITHOUT [mpu.exe](https://github.com/msgpack/msgpack-cli/wiki/Xamarin-and-Unity#generate-serializers).
        * Assembly mode : `GeneratedMsgPackSerializer.dll`
        * source code mode (Array / Map) : `GeneratedMsgPackSerializer/***.cs`
    * You can call `MsgPackGenerateSerializer.To***` from script or command-line.
    * ![image](https://user-images.githubusercontent.com/12690315/32209840-b23d98a0-be4d-11e7-94ed-1a6c67a382a2.png)
* MsgPack Viewer
    * Interchange editable json and MessagePack binary.
    * Analyze MessagePack binary to readable format.
    * Save and load MessagePack binary.
    * Convert json to MessagePack automatically. default is `Off`.
    * ![image](https://user-images.githubusercontent.com/12690315/32087322-014220f0-bb16-11e7-806e-1f59ae07677e.png)
    * Displays a parse error as following.  
    ![image](https://user-images.githubusercontent.com/12690315/32474021-b36f08d4-c3ad-11e7-8953-43d4a63f7be4.png)




## Requirement

* Unity5.5+ *(included Unity 2017.x)*
* No other SDK




## Usage

1. Download [MsgPack-Cli.unitypackage](https://github.com/mob-sakai/MsgPack-Cli/raw/master/unity/MsgPack-Cli.unitypackage) and install to your project.




## How to update MsgPack-Cli assembly (MsgPack.dll and MsgPack-Editor.dll)?

### Solution A: Using released dll

1. Download *.zip file from [MsgPack-Cli release page](https://github.com/msgpack/msgpack-cli/releases/).
1. Extract it.
1. Copy dlls file to the unity project.
    * Copy `unity/MsgPack.dll` to `Assets/MsgPack/MsgPack.dll`
    * Copy `net35/MsgPack.dll` to `Assets/MsgPack/MsgPack-Editor.dll`

### Solution B: Build dll with shell script (on Mac) 

1. Install latest `NuGet`, `Mono` and `.NET Core SDK`.
1. Run `UpdateMsgPackDll.sh` to build and copy dlls.

### Solution C: Build and copy dll manually

See [How to build](https://github.com/msgpack/msgpack-cli#how-to-build)




## How to generate unitypackage?

### Solution A: From menu

1. Open this unity project.
1. From menu, click `MsgPack > Export MsgPack-Cli.unitypackage`.

### Solution B: From command-line





## Release Notes

### ver.1.0.0-rc T.B.D.

* Update: MsgPack-Cli assembly version : 1.0.0-rc T.B.D. [defef75]
* Feature: Overridable request meta for each ApiRequest
* Feature: OnSuccess callback for ApiOperation
* Changed: Add default GetIvFromUid method

### ver.1.0.0-rc

* Update: MsgPack-Cli assembly version : 1.0.0-rc [9d51fe3]

### ver.1.0.0-beta2

* Update: MsgPack-Cli assembly version : 1.0.0-beta2 [ca751bb]
    * https://github.com/msgpack/msgpack-cli/releases/tag/1.0.0-beta2

### ver.0.9.2a

* Update: MsgPack-Cli assembly version : 0.9.2+ [b9c4903]
* Feature: Generate Serializer
* Feature: MsgPack Viewer
* Feature: Update MsgPack-Cli assembly using shell script




## See Also

* GitHub Page : https://github.com/mob-sakai/ApiSystem
* Issue tracker : https://github.com/mob-sakai/ApiSystem/issues