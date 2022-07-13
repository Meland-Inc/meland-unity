using System.IO;

public static class Constant
{
    // 目录分割符
    public static readonly char Spt = Path.DirectorySeparatorChar;
    // 项目路径
    public static readonly string ProjectPath = System.Environment.CurrentDirectory;
    // 项目Assets资源路径
    public static readonly string AssetsPath = Path.Combine(ProjectPath, "Assets");
    // 编辑器插件 辅助临时文件
    public static readonly string TempPath = Path.Combine(ProjectPath, "Temp");
    // protos 临时目录
    public static readonly string TempOutPbmessageDir = Path.Combine(TempPath, "OutPbmessage");
    // 输出的 pbmessage.cs 路径
    public static readonly string PbmessageCsPath = Path.Combine(AssetsPath, "Src/Protocol");
    // window protoc 解析器
    public static readonly string ProtocWindow = Path.Combine(ProjectPath, "Packages/Google.Protobuf.Tools.3.20.1/tools/windows_x64/protoc.exe");
    // mac protoc 解析器
    public static readonly string ProtocMac = Path.Combine(ProjectPath, "Packages/Google.Protobuf.Tools.3.20.1/tools/macosx_x64/protoc");
    // 通用的用于执行命令的sh文件
    public static readonly string CommonHandleSh = Path.Combine(AssetsPath, "Editor/Common/CommonBash.sh");
    // 系统的 /bin/sh 命令
    public static readonly string BinSh = Path.Combine("/bin/sh");

    // 用户预设key
    public enum ePlayerPrefsKey
    {
        PROTOS_FOLDER_PATH,
        SVN_CONFING_FOLDER_PATH
    }
}