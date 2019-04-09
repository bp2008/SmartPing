# SmartPing
A slightly improved version of the `Ping` class from .NET Core.

## Purpose
The standard [.NET Ping class](https://docs.microsoft.com/en-us/dotnet/api/system.net.networkinformation.ping?view=netframework-4.7.2) has a flaw.  It only delivers a valid `PingReply.RoundtripTime` value for replies with status == `IPStatus.Success`.  This is primarily a problem when using the `Ping` class to perform a traceroute, as most of the replies will have status `IPStatus.TtlExpired`.  In this case, the `Ping` class has a perfectly valid round-trip-time already measured, but intentionally throws it out and constructs the `PingReply` with a `RoundtripTime` of `0`.

[Microsoft does not care to change this.](https://visualstudio.uservoice.com/forums/121579-visual-studio-ide/suggestions/6365924-pingreply-include-the-roundtriptime-no-matter-the)

Many developers work around this issue by measuring the response time themselves using the [Stopwatch](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?view=netframework-4.7.2) class.  Unfortunately, this delivers a significantly less-accurate measure of response time, as you are also measuring the time required for your `Thread` to resume after receiving the ping reply.

This project is a nearly-identical copy of the `Ping` class, and supporting classes, from [.NET Core version 2.0.5](https://github.com/dotnet/corefx/releases/tag/v2.0.5). This version was chosen because it pre-dates several changes to the framework which made extracting the `Ping` class much more difficult.

These are the notable modifications:
1) Namespaces have been changed for reasons of compatibility.  The improved `Ping` class is located in the `SmartPing` namespace.
2) All ping replies contain the `RoundtripTime` property as measured by the native `Ping` implementation, even if the reply status was not "Success".
3) It only works on Windows OS.  While cross-platform implementations of `Ping` are available in .NET Core, they were removed from this project due to not understanding the build system that is required to handle them.

## Usage
[Download a release from the releases tab](https://github.com/bp2008/SmartPing/releases), or build SmartPing yourself.  Include the appropriate DLL as a reference in your .NET project.  Use classes in the `SmartPing` namespace instead of `System.Net.NetworkInformation`.  Two DLLs are provided in releases.
* SmartPing.dll - Targets .NET Standard 2.0
* SmartPingF.dll - Targets .NET Framework 4.6.2
