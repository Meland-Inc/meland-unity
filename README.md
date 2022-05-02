# meland-unity
meland client main project make by unity  
#### target platform：
- window、mac
- webgl
- android、ios

#### use other library
- [GameFramework](https://github.com/EllanJiang/GameFramework)
- [Zenject](https://github.com/modesttree/Zenject)
#### related git repository
- [meland fork of GF](https://github.com/Meland-Inc/GameFramework)
- [meland fork of UGF](https://github.com/Meland-Inc/UnityGameFramework)
--- 
### develop
#### environment
- git use LFS :https://git-lfs.github.com/
- unity 2021.3.1f1
- vscode
  - enable setting config : "Format On Save"
  - extension: 
    - [Unity Dev Pack](https://marketplace.visualstudio.com/items?itemName=fabriciohod.unity-dev-pack)
    - [Code Spell Checker](https://marketplace.visualstudio.com/items?itemName=streetsidesoftware.code-spell-checker)
    - [Error Lens](https://marketplace.visualstudio.com/items?itemName=usernamehw.errorlens)
#### coding conventions
- [main : C# code conventions](https://docs.microsoft.com/zh-cn/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [.net code conventions](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md?plain=1)
- [editorconfig](/.editorconfig)
#### startup
- if you have not clone meland-unity, you can clone it by command:  ```git clone --recurse-submodules this_repository_url```
- if you have cloned meland-unity,but not update git submodules, you can update it by command:  ```git submodule update --init --recursive```
