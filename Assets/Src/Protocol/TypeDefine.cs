// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: typeDefine.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace MelandGame3 {

  /// <summary>Holder for reflection information generated from typeDefine.proto</summary>
  public static partial class TypeDefineReflection {

    #region Descriptor
    /// <summary>File descriptor for typeDefine.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static TypeDefineReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChB0eXBlRGVmaW5lLnByb3RvEgtNZWxhbmRHYW1lMyrWBAoKRW50aXR5VHlw",
            "ZRIcChhFbnRpdHlUeXBlX0VudGl0eVR5cGVBbGwQABIiCh5FbnRpdHlUeXBl",
            "X0VudGl0eVR5cGVNYXBPYmplY3QQARIfChtFbnRpdHlUeXBlX0VudGl0eVR5",
            "cGVQbGF5ZXIQAhIcChhFbnRpdHlUeXBlX0VudGl0eVR5cGVOcGMQBBIgChxF",
            "bnRpdHlUeXBlX0VudGl0eVR5cGVNb25zdGVyEAgSJgoiRW50aXR5VHlwZV9F",
            "bnRpdHlUeXBlUmVzb3VyY2VQb2ludBAQEiYKIkVudGl0eVR5cGVfRW50aXR5",
            "VHlwZUZhbGxpbmdPYmplY3QQIBIhCh1FbnRpdHlUeXBlX0VudGl0eVR5cGVN",
            "YXRlcmlhbBBAEh0KGEVudGl0eVR5cGVfRW50aXR5VHlwZUJvdBCAARIkCh9F",
            "bnRpdHlUeXBlX0VudGl0eVR5cGVGYWxsaW5nQm94EIACEh8KGkVudGl0eVR5",
            "cGVfRW50aXR5VHlwZVZhcmlhEIAEEh8KGkVudGl0eVR5cGVfRW50aXR5VHlw",
            "ZVBsYW50EIAIEh0KGEVudGl0eVR5cGVfRW50aXR5VHlwZVBldBCAEBImCiFF",
            "bnRpdHlUeXBlX0VudGl0eVR5cGVTcGVjaWFsQnVpbGQQgCASIAobRW50aXR5",
            "VHlwZV9FbnRpdHlUeXBlUHVwcGV0EIBAEiIKHEVudGl0eVR5cGVfRW50aXR5",
            "VHlwZVRlcnJhaW4QgIABEh4KGEVudGl0eVR5cGVfRW50aXR5VHlwZU1heBCA",
            "gARiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::MelandGame3.EntityType), }, null, null));
    }
    #endregion

  }
  #region Enums
  /// <summary>
  /// bit ?????? 64??? [0001110001111000.....]
  /// </summary>
  public enum EntityType {
    [pbr::OriginalName("EntityType_EntityTypeAll")] EntityTypeAll = 0,
    /// <summary>
    /// ????????????
    /// </summary>
    [pbr::OriginalName("EntityType_EntityTypeMapObject")] EntityTypeMapObject = 1,
    /// <summary>
    /// ??????
    /// </summary>
    [pbr::OriginalName("EntityType_EntityTypePlayer")] EntityTypePlayer = 2,
    /// <summary>
    /// npc
    /// </summary>
    [pbr::OriginalName("EntityType_EntityTypeNpc")] EntityTypeNpc = 4,
    /// <summary>
    /// ??????
    /// </summary>
    [pbr::OriginalName("EntityType_EntityTypeMonster")] EntityTypeMonster = 8,
    /// <summary>
    /// ?????????
    /// </summary>
    [pbr::OriginalName("EntityType_EntityTypeResourcePoint")] EntityTypeResourcePoint = 16,
    /// <summary>
    /// ?????????
    /// </summary>
    [pbr::OriginalName("EntityType_EntityTypeFallingObject")] EntityTypeFallingObject = 32,
    /// <summary>
    /// ??????
    /// </summary>
    [pbr::OriginalName("EntityType_EntityTypeMaterial")] EntityTypeMaterial = 64,
    /// <summary>
    /// ???????????????
    /// </summary>
    [pbr::OriginalName("EntityType_EntityTypeBot")] EntityTypeBot = 128,
    /// <summary>
    /// ???????????????
    /// </summary>
    [pbr::OriginalName("EntityType_EntityTypeFallingBox")] EntityTypeFallingBox = 256,
    /// <summary>
    /// ????????????
    /// </summary>
    [pbr::OriginalName("EntityType_EntityTypeVaria")] EntityTypeVaria = 512,
    /// <summary>
    /// ???????????????
    /// </summary>
    [pbr::OriginalName("EntityType_EntityTypePlant")] EntityTypePlant = 1024,
    /// <summary>
    /// ???????????????????????? monster???
    /// </summary>
    [pbr::OriginalName("EntityType_EntityTypePet")] EntityTypePet = 2048,
    /// <summary>
    /// ????????????(???????????????)
    /// </summary>
    [pbr::OriginalName("EntityType_EntityTypeSpecialBuild")] EntityTypeSpecialBuild = 4096,
    /// <summary>
    /// ??????
    /// </summary>
    [pbr::OriginalName("EntityType_EntityTypePuppet")] EntityTypePuppet = 8192,
    /// <summary>
    /// ??????
    /// </summary>
    [pbr::OriginalName("EntityType_EntityTypeTerrain")] EntityTypeTerrain = 16384,
    /// <summary>
    /// ?????????
    /// </summary>
    [pbr::OriginalName("EntityType_EntityTypeMax")] EntityTypeMax = 65536,
  }

  #endregion

}

#endregion Designer generated code
