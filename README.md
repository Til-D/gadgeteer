Gadgeteer
=========

Hardware Hacks with MS Gadgeteer

Requirements
-----------
- FEZ Spider Starter Kit (GHI Electronics) (retail price: $249.95)
- Visual Studio C# Express with Gadgeteer package and .NET Micro Framework

Gadgeteer Installation
-----------
1. Follow installation steps: http://www.ghielectronics.com/support/dotnet-micro-framework
	- install MS Visual C# Express 2010
	- install MS .NET Micro Framework 4.2. QFE2 SDK
	- install GHI NETMF v4.2 and .NET Gadgeteer Package
2. Connect Mainboard to USB Client DP
3. Connect USB Client DP to computer
4. Point drivers to correct source, if not correctly auto-detected: C:\Program Files (x86)\GHI Electronics\GHI Premium NETMF v4.2 SDK\USB Drivers\GHI_NETMF_Interface (http://www.tinyclr.com/forum/topic?id=9388)

Contents
-----------
1. SimpleTouchConsole: simple component setup using a T35 display and displaying touch position on the touchscreen using a label

2. pirCam: pirCam uses a PIR motion sensor to trigger the camera to take a picture and display it on a T35 display
