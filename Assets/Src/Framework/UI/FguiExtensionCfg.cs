/*
 * @Author: mangit
 * @LastEditTime: 2022-06-20 20:13:45
 * @LastEditors: mangit
 * @Description: fgui扩展配置
 * @Date: 2022-06-16 21:01:09
 * @FilePath: /Assets/Src/Framework/UI/FguiExtensionCfg.cs
 */
using System;

public struct FguiExtensionCfg
{
    public eFUIPackage Package;
    public string ResName;
    public Type Type;

    public FguiExtensionCfg(eFUIPackage package, string resName, Type type)
    {
        Package = package;
        ResName = resName;
        Type = type;
    }
}