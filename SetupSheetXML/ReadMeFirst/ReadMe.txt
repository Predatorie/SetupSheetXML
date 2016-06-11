


This template is a standard C# class library project for use with Mastercam X9. The project 
has a reference to the NETHook3_0.dll located in the root directory of your Mastercam X9 installation. 
However, if you installed into a directory other than the default installation directory you may need to update the project 
reference to the NETHook3_0.dll in order for your project to compile.


The included ProjectSetup documents detail setup for building debuging a NETHook.

**NOTE: This NETHook class library targets the .NET 4.5 Framework x64 build.
**NOTE: Building will give a command copy error (post build step) until you rename the FT file to match that of your project
**NOTE: Make sure you are running Visual Studio in Administrator mode, see the ProjectSetup documents for instructions.


Visual Studio 2015 Free Community Edition is required.
https://www.visualstudio.com/downloads/download-visual-studio-vs


Recommend Visual Studio Add-ons:

NOTE: Make sure the version of StyleCOP supports VS 2015 before installing.

StyleCOP is free and recommended (we use it here at CNC Software)

https://stylecop.codeplex.com
StyleCop analyzes C# source code to enforce a set of style and consistency rules.
StyleCop provides value by enforcing a common set of style rules for C# code. 
StyleCop will continue to ship with a single, consistent set of rules, with minimal rule configuration allowed. 
Developers can implement their own rules if they so choose.


** POST BUILD STEP **

copy "$(TargetPath)" "C:\Program Files\mcamx9\chooks\$(TargetFileName)"
copy "$(ProjectDir)\FunctionTable\$(TargetName).ft" "C:\Program Files\mcamx9\chooks\$(TargetName).ft"


** DEBUGGING **

Start External Application -> C:\Program Files\mcamx9\Mastercam.exe

Working Directory -> C:\Program Files\mcamx9