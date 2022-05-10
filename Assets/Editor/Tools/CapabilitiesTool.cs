using System;
public static class CapabilitiesTool
{
    public static bool isWindow()
    {
        System.OperatingSystem osInfo = Environment.OSVersion;
        return osInfo.Platform == PlatformID.Win32S
        || osInfo.Platform == PlatformID.Win32Windows
        || osInfo.Platform == PlatformID.Win32NT
        || osInfo.Platform == PlatformID.WinCE;
    }

    public static bool isMac()
    {
        System.OperatingSystem osInfo = Environment.OSVersion;
        return osInfo.Platform == PlatformID.MacOSX;
    }
}