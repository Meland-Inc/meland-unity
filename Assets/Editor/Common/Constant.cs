using System.IO;

public static class Constant
{
    public static char Spt = Path.DirectorySeparatorChar;
    public static string ProjectPath = System.Environment.CurrentDirectory;
    public static string AssetsPath = ProjectPath + $"{Spt}Assets";
    public static string TempPath = AssetsPath + $"{Spt}Editor{Spt}Temp";
    public static string TempOutPbmessageDir = TempPath + $"{Spt}OutPbmessage";
    public static string TempOutPbmessagePath = TempOutPbmessageDir + $"{Spt}pbmessage.proto";
    public static string PbmessageCsPath = AssetsPath + $"{Spt}Resources{Spt}Protos";
    public static string ProtocWindow = ProjectPath + $"{Spt}Packages{Spt}Google.Protobuf.Tools.3.20.1{Spt}tools{Spt}windows_x64{Spt}protoc.exe";
    public static string ProtocMac = ProjectPath + $"{Spt}Packages{Spt}Google.Protobuf.Tools.3.20.1{Spt}tools{Spt}macosx_x64{Spt}protoc";

    // 用户预设key
    public enum ePlayerPrefsKey
    {
        PROTOS_FOLDER_PATH
    }
}