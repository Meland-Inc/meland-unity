
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System;
using UnityEngine;

public class ProtoHandler
{
    /// <summary>
    /// 转换开始
    /// </summary>
    /// <param name="protosPath"></param>
    public void Handle(string protosPath)
    {
        try
        {
            Debug.Log(".*proto文件: 开始转换");
            CreatePreHandleProto(protosPath);
            CreateCs();
            Debug.Log(".*proto文件: 转换成功");
        }
        catch (Exception ex)
        {
            Debug.LogError($".*proto文件:  转换失败 ${ex.Message}");
        }

    }

    /// <summary>
    // proto3 CompileError : https://github.com/protobuf-net/protobuf-net/issues/60
    // pbmessage.proto:2383:3: "InputEvent" is already defined in "Bian".
    // pbmessage.proto:2383:3: Note that enum values use C++ scoping rules, meaning that enum values are siblings of their type, not children of it.Therefore, "InputEvent" must be unique within "Bian", not just within "EnvelopeType".
    // 为enum 添加前缀
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public string HandleProtoEnumCompileError(string content)
    {

        // enum 结构匹配
        Regex enumStructRegex = new(@"enum +\w+ *\{[\s\S\n]*?\}");
        // enum 名称匹配
        Regex enumNameRegex = new(@"enum +(\w+) *\{");
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
    /// 创建预处理的Protos文件 ： 遍历proto文件，处理enum重复问题,写入临时目录,准备convert处理
    /// </summary>
    /// <param name="fullPath"></param>
    /// <returns></returns>
    private void CreatePreHandleProto(string fullPath)
    {
        if (!Directory.Exists(fullPath))
        {
            throw new System.Exception($"proto源文件路径不存在 ${fullPath}");
        }
        //获取指定路径下面的所有资源文件  
        DirectoryInfo direction = new(fullPath);
        FileInfo[] files = direction.GetFiles("*.proto", SearchOption.AllDirectories);

        for (int i = 0; i < files.Length; i++)
        {
            string eleContent = FileTool.ReadFileText(files[i].FullName, System.Text.Encoding.UTF8);
            eleContent = HandleProtoEnumCompileError(eleContent);

            string content = "";
            content += "syntax = 'proto3';\r\n";
            content += "package MelandGame3;\r\n";
            eleContent = eleContent.Replace("syntax = 'proto3';", "");
            eleContent = eleContent.Replace("syntax = \"proto3\";", "");
            eleContent = eleContent.Replace("option go_package MelandGame3;", "");
            eleContent = eleContent.Replace("package MelandGame3;", "");

            content += eleContent + "\n";

            string outputFullFileName = $"{Constant.TempOutPbmessageDir}{Constant.Spt}{files[i].Name}";
            FileTool.WriteFile(outputFullFileName, content, System.Text.Encoding.UTF8);
            Debug.Log($".*proto文件: 创建临时文件 pbmessage.proto => {outputFullFileName}");
        }

    }

    /// <summary>
    /// 生成 pbmessage.cs 文件
    /// </summary>
    private void CreateCs()
    {
        string protoc = null;

        if (CapabilitiesTool.IsWindow())
        {
            protoc = Constant.ProtocWindow;
        }
        else if (CapabilitiesTool.IsMac())
        {
            protoc = Constant.ProtocMac;
        }

        if (!File.Exists(protoc))
        {
            throw new Exception($"protoc 编译工具不存在 ${protoc}");
        }

        CommandTool.ProcessCommand(protoc, $"--proto_path={Constant.TempOutPbmessageDir} \"{Constant.TempOutPbmessageDir}{Constant.Spt}*.proto\" --csharp_out {Constant.PbmessageCsPath}");

        Debug.Log($".*proto文件: 生成最终文件 Pbmessage.cs => {Constant.PbmessageCsPath}");
    }


}