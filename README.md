<!--
 * @Author xiangqian
 * @Description 
 * @Date 2022-05-18 17:28:24
 * @FilePath: /README.md
-->
# meland-unity

meland client main project make by unity  

#### target platform

- window、mac
- webgl
- android、ios

#### use other library

- [GameFramework](https://github.com/EllanJiang/GameFramework)
- [Zenject](https://github.com/modesttree/Zenject)
- [UniTask](https://github.com/Cysharp/UniTask)
- [UnityWebSocket](https://github.com/psygames/UnityWebSocket)

#### related git repository

- [meland fork of GF](https://github.com/Meland-Inc/GameFramework)
- [meland fork of UGF](https://github.com/Meland-Inc/UnityGameFramework)
- [meland sharded core](https://github.com/Meland-Inc/meland-shared_unity_core)

---

### develop

#### environment

- git use LFS :<https://git-lfs.github.com/>
- 2021.3.1f1c1
  - form https://unity.cn/releases/lts
  - select 2021.3.1f1
  - will show 2021.3.1f1c1 in unityhub，if not, you should close network proxy
- vscode
  - enable setting config : "Format On Save"
  - extension:
    - [Unity Dev Pack](https://marketplace.visualstudio.com/items?itemName=fabriciohod.unity-dev-pack)
    - [Code Spell Checker](https://marketplace.visualstudio.com/items?itemName=streetsidesoftware.code-spell-checker)
    - [Error Lens](https://marketplace.visualstudio.com/items?itemName=usernamehw.errorlens)
    - [markdownlint](https://marketplace.visualstudio.com/items?itemName=DavidAnson.vscode-markdownlint)

#### coding conventions

- [main : C# code conventions](https://docs.microsoft.com/zh-cn/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [.net code conventions](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md?plain=1)
- [editorconfig](/.editorconfig)

#### startup

- clone repository
  - if you have not clone meland-unity, you can clone it by command:  ```git clone --recurse-submodules this_repository_url```
  - if you have cloned meland-unity,but not update git submodules, you can update it by command:  ```git submodule update --init --recursive```
- open with unity
- click NuGet->Restore Packages on unity menu
- open Lauch scene ,on Assets/Res/Scene/Lauch
- click 'play' to run the game
- glad you joined


#### devTool
- compile proto cs
  - Adding dependency tools
    - Find 'NuGet' in the Unity menu,click 'Restore Packages' option
  - Enable the execution permission of the mac compilation tool protoc on "meland-unity/Packages/Google.Protobuf.Tools.3.20.1/tools/macosx_x64/protoc"
  - Find 'devtool' in the Unity menu,click 'proto' option to open the window
  - Select the proto source file path, for example: .../bian_doc/pbmessage
  - click '开始转换'
