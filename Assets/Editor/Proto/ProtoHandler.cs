
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System;

public class ProtoHandler
{
    /// <summary>
    /// 转换开始
    /// </summary>
    /// <param name="protosPath"></param>
    public void Handle(string protosPath)
    {
        _ = CreateComposeProto(protosPath);
        CreateCs();
    }

    /// <summary>
    // proto3 CompileError : https://github.com/protobuf-net/protobuf-net/issues/60
    // pbmessage.proto:2383:3: "InputEvent" is already defined in "Bian".
    // pbmessage.proto:2383:3: Note that enum values use C++ scoping rules, meaning that enum values are siblings of their type, not children of it.Therefore, "InputEvent" must be unique within "Bian", not just within "EnvelopeType".
    // 为enum 添加前缀
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public string HandleCompileError(string content)
    {

        // enum 结构匹配
        Regex enumStructRegex = new(@"enum +\w+ +\{[\s\S\n]*?\}");
        // enum 名称匹配
        Regex enumNameRegex = new(@"enum +(\w+) +\{");
        MatchCollection matchs = enumStructRegex.Matches(content);
        foreach (Match match in matchs)
        {
            Match enumNameMatch = enumNameRegex.Match(match.Value);
            string enumName = enumNameMatch.Groups[1].ToString();
            // 为enum 的属性添加前缀
            string value = Regex.Replace(match.Value, @"(\w+) *= *\d+ *;", $"{enumName}_$0");
            // Debug.Log(value);
            // 替换原内容
            content = content.Replace(match.Value, value);
        }
        return content;
    }

    /// <summary>
    /// 把所有的子Proto文件，整合成一个大proto文件
    /// </summary>
    /// <param name="fullPath"></param>
    /// <returns></returns>
    public string CreateComposeProto(string fullPath)
    {
        if (!Directory.Exists(fullPath))
        {
            throw new System.Exception($"proto源文件路径不存在 ${fullPath}");
        }

        string content = "";
        content += "syntax = 'proto3';\r\n";
        content += "package Bian;\r\n";

        //获取指定路径下面的所有资源文件  
        DirectoryInfo direction = new(fullPath);
        FileInfo[] files = direction.GetFiles("*.proto", SearchOption.AllDirectories);

        for (int i = 0; i < files.Length; i++)
        {
            string eleContent = FileTool.ReadFile(files[i].FullName, System.Text.Encoding.UTF8);

            eleContent = HandleCompileError(eleContent);

            string[] contents = eleContent
            .Split("\n")
            .Where(content => content.IndexOf("import") != 0)
            .ToArray();
            eleContent = string.Join('\n', contents);

            eleContent = eleContent.Replace("syntax = 'proto3';", "");
            eleContent = eleContent.Replace("syntax = \"proto3\";", "");
            eleContent = eleContent.Replace("option go_package Bian;", "");
            eleContent = eleContent.Replace("package Bian;", "");

            content += "// ----- from " + files[i].Name + " ---- \n";
            content += eleContent + "\n";
        }

        FileTool.WriteFile(Constant.TempOutPbmessagePath, content, System.Text.Encoding.UTF8);
        return content;
    }

    /// <summary>
    /// 生成 pbmessage.cs 文件
    /// </summary>
    public void CreateCs()
    {
        string protoc = null;

        if (CapabilitiesTool.isWindow())
        {
            protoc = Constant.ProtocWindow;
        }
        else if (CapabilitiesTool.isMac())
        {
            protoc = Constant.ProtocMac;
        }
        else if (CapabilitiesTool.isUnix())
        {
            protoc = Constant.ProtocUnix;
        }

        if (!File.Exists(protoc))
        {
            throw new Exception($"protoc 编译工具不存在 ${protoc}");
        }

        CommandTool.ProcessCommand(protoc, $"--proto_path={Constant.TempOutPbmessageDir} pbmessage.proto --csharp_out {Constant.PbmessageCsPath}");
    }


}