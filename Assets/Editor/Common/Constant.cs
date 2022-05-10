using System.IO;

public static class Constant
{
    // 目录分割符
    public static char Spt = Path.DirectorySeparatorChar;
    // 项目路径
    public static string ProjectPath = System.Environment.CurrentDirectory;
    // 项目Assets资源路径
    public static string AssetsPath = ProjectPath + $"{Spt}Assets";
    // 编辑器插件 辅助临时文件
    public static string TempPath = AssetsPath + $"{Spt}Editor{Spt}Temp";
    // 合并大 pbmessage.proto 的临时目录
    public static string TempOutPbmessageDir = TempPath + $"{Spt}OutPbmessage";
    // 合并大 pbmessage.proto 文件路径
    public static string TempOutPbmessagePath = TempOutPbmessageDir + $"{Spt}pbmessage.proto";
    // 输出的 pbmessage.cs 路径
    public static string PbmessageCsPath = AssetsPath + $"{Spt}Resources{Spt}Protos";
    // window protoc 解析器
    public static string ProtocWindow = ProjectPath + $"{Spt}Packages{Spt}Google.Protobuf.Tools.3.20.1{Spt}tools{Spt}windows_x64{Spt}protoc.exe";
    // mac protoc 解析器
    public static string ProtocMac = ProjectPath + $"{Spt}Packages{Spt}Google.Protobuf.Tools.3.20.1{Spt}tools{Spt}macosx_x64{Spt}protoc";
    // unix protoc 解析器
    public static string ProtocUnix = ProjectPath + $"{Spt}Packages{Spt}Google.Protobuf.Tools.3.20.1{Spt}tools{Spt}linux_x64{Spt}protoc";

    // 用户预设key
    public enum ePlayerPrefsKey
    {
        PROTOS_FOLDER_PATH
    }
}