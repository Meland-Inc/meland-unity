// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: camera.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace MelandGame3 {

  /// <summary>Holder for reflection information generated from camera.proto</summary>
  public static partial class CameraReflection {

    #region Descriptor
    /// <summary>File descriptor for camera.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static CameraReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgxjYW1lcmEucHJvdG8SC01lbGFuZEdhbWUzGgx2ZWN0b3IucHJvdG8iaQoM",
            "Q2FtZXJhQ29uZmlnEhMKC2ZvbGxvd19yb2xlGAEgASgIEhYKDmNvbnRyb2xf",
            "Y2FtZXJhGAIgASgIEg4KBmJhbl91aRgDIAEoCBIcChRiYW5fem9uZV9pbnRl",
            "cmFjdGlvbhgEIAEoCCJEChBDYW1lcmFBY3Rpb25ab29tEhUKDXpvb21fbXVs",
            "dGlwbGUYASABKAISGQoRY2FtZXJhX3N0YW1wX3RpbWUYAiABKAMiewoQQ2Ft",
            "ZXJhQWN0aW9uTW92ZRIlCgdjdXJfcG9zGAEgASgLMhQuTWVsYW5kR2FtZTMu",
            "VmVjdG9yMxIlCgd0YXJfcG9zGAIgASgLMhQuTWVsYW5kR2FtZTMuVmVjdG9y",
            "MxIZChFjYW1lcmFfc3RhbXBfdGltZRgDIAEoAyqRAQoKQ2FtZXJhVHlwZRIg",
            "ChxDYW1lcmFUeXBlX0NhbWVyYVR5cGVDb2RlQ3RsEAASHQoZQ2FtZXJhVHlw",
            "ZV9DYW1lcmFUeXBlTG9jaxABEiAKHENhbWVyYVR5cGVfQ2FtZXJhVHlwZUZy",
            "ZWVkb20QAhIgChxDYW1lcmFUeXBlX0NhbWVyYVR5cGVQcmV2aWV3EAMq7AEK",
            "EENhbWVyYUFjdGlvblR5cGUSKQolQ2FtZXJhQWN0aW9uVHlwZV9DYW1lcmFB",
            "Y3Rpb25UeXBlTW92ZRAAEicKI0NhbWVyYUFjdGlvblR5cGVfQ2FtZXJhQWN0",
            "aW9uVHlwZVRwEAESKQolQ2FtZXJhQWN0aW9uVHlwZV9DYW1lcmFBY3Rpb25U",
            "eXBlWm9vbRACEiwKKENhbWVyYUFjdGlvblR5cGVfQ2FtZXJhQWN0aW9uVHlw",
            "ZVJlc3RvcmUQAxIrCidDYW1lcmFBY3Rpb25UeXBlX0NhbWVyYUFjdGlvblR5",
            "cGVDb25maWcQBGIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::MelandGame3.VectorReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::MelandGame3.CameraType), typeof(global::MelandGame3.CameraActionType), }, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::MelandGame3.CameraConfig), global::MelandGame3.CameraConfig.Parser, new[]{ "FollowRole", "ControlCamera", "BanUi", "BanZoneInteraction" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MelandGame3.CameraActionZoom), global::MelandGame3.CameraActionZoom.Parser, new[]{ "ZoomMultiple", "CameraStampTime" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MelandGame3.CameraActionMove), global::MelandGame3.CameraActionMove.Parser, new[]{ "CurPos", "TarPos", "CameraStampTime" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  /// <summary>
  ///????????????
  /// </summary>
  public enum CameraType {
    /// <summary>
    ///?????????????????????
    /// </summary>
    [pbr::OriginalName("CameraType_CameraTypeCodeCtl")] CameraTypeCodeCtl = 0,
    /// <summary>
    ///????????????
    /// </summary>
    [pbr::OriginalName("CameraType_CameraTypeLock")] CameraTypeLock = 1,
    /// <summary>
    ///????????????
    /// </summary>
    [pbr::OriginalName("CameraType_CameraTypeFreedom")] CameraTypeFreedom = 2,
    /// <summary>
    ///????????????
    /// </summary>
    [pbr::OriginalName("CameraType_CameraTypePreview")] CameraTypePreview = 3,
  }

  public enum CameraActionType {
    /// <summary>
    /// ????????????
    /// </summary>
    [pbr::OriginalName("CameraActionType_CameraActionTypeMove")] CameraActionTypeMove = 0,
    /// <summary>
    /// tp??????
    /// </summary>
    [pbr::OriginalName("CameraActionType_CameraActionTypeTp")] CameraActionTypeTp = 1,
    /// <summary>
    /// ????????????
    /// </summary>
    [pbr::OriginalName("CameraActionType_CameraActionTypeZoom")] CameraActionTypeZoom = 2,
    /// <summary>
    /// ????????????
    /// </summary>
    [pbr::OriginalName("CameraActionType_CameraActionTypeRestore")] CameraActionTypeRestore = 3,
    /// <summary>
    /// ????????????
    /// </summary>
    [pbr::OriginalName("CameraActionType_CameraActionTypeConfig")] CameraActionTypeConfig = 4,
  }

  #endregion

  #region Messages
  public sealed partial class CameraConfig : pb::IMessage<CameraConfig>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<CameraConfig> _parser = new pb::MessageParser<CameraConfig>(() => new CameraConfig());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<CameraConfig> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MelandGame3.CameraReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CameraConfig() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CameraConfig(CameraConfig other) : this() {
      followRole_ = other.followRole_;
      controlCamera_ = other.controlCamera_;
      banUi_ = other.banUi_;
      banZoneInteraction_ = other.banZoneInteraction_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CameraConfig Clone() {
      return new CameraConfig(this);
    }

    /// <summary>Field number for the "follow_role" field.</summary>
    public const int FollowRoleFieldNumber = 1;
    private bool followRole_;
    /// <summary>
    /// ????????????
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool FollowRole {
      get { return followRole_; }
      set {
        followRole_ = value;
      }
    }

    /// <summary>Field number for the "control_camera" field.</summary>
    public const int ControlCameraFieldNumber = 2;
    private bool controlCamera_;
    /// <summary>
    /// ????????????
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool ControlCamera {
      get { return controlCamera_; }
      set {
        controlCamera_ = value;
      }
    }

    /// <summary>Field number for the "ban_ui" field.</summary>
    public const int BanUiFieldNumber = 3;
    private bool banUi_;
    /// <summary>
    /// ??????ui???ui?????????
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool BanUi {
      get { return banUi_; }
      set {
        banUi_ = value;
      }
    }

    /// <summary>Field number for the "ban_zone_interaction" field.</summary>
    public const int BanZoneInteractionFieldNumber = 4;
    private bool banZoneInteraction_;
    /// <summary>
    /// ???????????????????????????
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool BanZoneInteraction {
      get { return banZoneInteraction_; }
      set {
        banZoneInteraction_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as CameraConfig);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(CameraConfig other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (FollowRole != other.FollowRole) return false;
      if (ControlCamera != other.ControlCamera) return false;
      if (BanUi != other.BanUi) return false;
      if (BanZoneInteraction != other.BanZoneInteraction) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (FollowRole != false) hash ^= FollowRole.GetHashCode();
      if (ControlCamera != false) hash ^= ControlCamera.GetHashCode();
      if (BanUi != false) hash ^= BanUi.GetHashCode();
      if (BanZoneInteraction != false) hash ^= BanZoneInteraction.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (FollowRole != false) {
        output.WriteRawTag(8);
        output.WriteBool(FollowRole);
      }
      if (ControlCamera != false) {
        output.WriteRawTag(16);
        output.WriteBool(ControlCamera);
      }
      if (BanUi != false) {
        output.WriteRawTag(24);
        output.WriteBool(BanUi);
      }
      if (BanZoneInteraction != false) {
        output.WriteRawTag(32);
        output.WriteBool(BanZoneInteraction);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (FollowRole != false) {
        output.WriteRawTag(8);
        output.WriteBool(FollowRole);
      }
      if (ControlCamera != false) {
        output.WriteRawTag(16);
        output.WriteBool(ControlCamera);
      }
      if (BanUi != false) {
        output.WriteRawTag(24);
        output.WriteBool(BanUi);
      }
      if (BanZoneInteraction != false) {
        output.WriteRawTag(32);
        output.WriteBool(BanZoneInteraction);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (FollowRole != false) {
        size += 1 + 1;
      }
      if (ControlCamera != false) {
        size += 1 + 1;
      }
      if (BanUi != false) {
        size += 1 + 1;
      }
      if (BanZoneInteraction != false) {
        size += 1 + 1;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(CameraConfig other) {
      if (other == null) {
        return;
      }
      if (other.FollowRole != false) {
        FollowRole = other.FollowRole;
      }
      if (other.ControlCamera != false) {
        ControlCamera = other.ControlCamera;
      }
      if (other.BanUi != false) {
        BanUi = other.BanUi;
      }
      if (other.BanZoneInteraction != false) {
        BanZoneInteraction = other.BanZoneInteraction;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            FollowRole = input.ReadBool();
            break;
          }
          case 16: {
            ControlCamera = input.ReadBool();
            break;
          }
          case 24: {
            BanUi = input.ReadBool();
            break;
          }
          case 32: {
            BanZoneInteraction = input.ReadBool();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            FollowRole = input.ReadBool();
            break;
          }
          case 16: {
            ControlCamera = input.ReadBool();
            break;
          }
          case 24: {
            BanUi = input.ReadBool();
            break;
          }
          case 32: {
            BanZoneInteraction = input.ReadBool();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class CameraActionZoom : pb::IMessage<CameraActionZoom>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<CameraActionZoom> _parser = new pb::MessageParser<CameraActionZoom>(() => new CameraActionZoom());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<CameraActionZoom> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MelandGame3.CameraReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CameraActionZoom() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CameraActionZoom(CameraActionZoom other) : this() {
      zoomMultiple_ = other.zoomMultiple_;
      cameraStampTime_ = other.cameraStampTime_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CameraActionZoom Clone() {
      return new CameraActionZoom(this);
    }

    /// <summary>Field number for the "zoom_multiple" field.</summary>
    public const int ZoomMultipleFieldNumber = 1;
    private float zoomMultiple_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public float ZoomMultiple {
      get { return zoomMultiple_; }
      set {
        zoomMultiple_ = value;
      }
    }

    /// <summary>Field number for the "camera_stamp_time" field.</summary>
    public const int CameraStampTimeFieldNumber = 2;
    private long cameraStampTime_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public long CameraStampTime {
      get { return cameraStampTime_; }
      set {
        cameraStampTime_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as CameraActionZoom);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(CameraActionZoom other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(ZoomMultiple, other.ZoomMultiple)) return false;
      if (CameraStampTime != other.CameraStampTime) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (ZoomMultiple != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(ZoomMultiple);
      if (CameraStampTime != 0L) hash ^= CameraStampTime.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (ZoomMultiple != 0F) {
        output.WriteRawTag(13);
        output.WriteFloat(ZoomMultiple);
      }
      if (CameraStampTime != 0L) {
        output.WriteRawTag(16);
        output.WriteInt64(CameraStampTime);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (ZoomMultiple != 0F) {
        output.WriteRawTag(13);
        output.WriteFloat(ZoomMultiple);
      }
      if (CameraStampTime != 0L) {
        output.WriteRawTag(16);
        output.WriteInt64(CameraStampTime);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (ZoomMultiple != 0F) {
        size += 1 + 4;
      }
      if (CameraStampTime != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(CameraStampTime);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(CameraActionZoom other) {
      if (other == null) {
        return;
      }
      if (other.ZoomMultiple != 0F) {
        ZoomMultiple = other.ZoomMultiple;
      }
      if (other.CameraStampTime != 0L) {
        CameraStampTime = other.CameraStampTime;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 13: {
            ZoomMultiple = input.ReadFloat();
            break;
          }
          case 16: {
            CameraStampTime = input.ReadInt64();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 13: {
            ZoomMultiple = input.ReadFloat();
            break;
          }
          case 16: {
            CameraStampTime = input.ReadInt64();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class CameraActionMove : pb::IMessage<CameraActionMove>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<CameraActionMove> _parser = new pb::MessageParser<CameraActionMove>(() => new CameraActionMove());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<CameraActionMove> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MelandGame3.CameraReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CameraActionMove() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CameraActionMove(CameraActionMove other) : this() {
      curPos_ = other.curPos_ != null ? other.curPos_.Clone() : null;
      tarPos_ = other.tarPos_ != null ? other.tarPos_.Clone() : null;
      cameraStampTime_ = other.cameraStampTime_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CameraActionMove Clone() {
      return new CameraActionMove(this);
    }

    /// <summary>Field number for the "cur_pos" field.</summary>
    public const int CurPosFieldNumber = 1;
    private global::MelandGame3.Vector3 curPos_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::MelandGame3.Vector3 CurPos {
      get { return curPos_; }
      set {
        curPos_ = value;
      }
    }

    /// <summary>Field number for the "tar_pos" field.</summary>
    public const int TarPosFieldNumber = 2;
    private global::MelandGame3.Vector3 tarPos_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::MelandGame3.Vector3 TarPos {
      get { return tarPos_; }
      set {
        tarPos_ = value;
      }
    }

    /// <summary>Field number for the "camera_stamp_time" field.</summary>
    public const int CameraStampTimeFieldNumber = 3;
    private long cameraStampTime_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public long CameraStampTime {
      get { return cameraStampTime_; }
      set {
        cameraStampTime_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as CameraActionMove);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(CameraActionMove other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(CurPos, other.CurPos)) return false;
      if (!object.Equals(TarPos, other.TarPos)) return false;
      if (CameraStampTime != other.CameraStampTime) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (curPos_ != null) hash ^= CurPos.GetHashCode();
      if (tarPos_ != null) hash ^= TarPos.GetHashCode();
      if (CameraStampTime != 0L) hash ^= CameraStampTime.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (curPos_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(CurPos);
      }
      if (tarPos_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(TarPos);
      }
      if (CameraStampTime != 0L) {
        output.WriteRawTag(24);
        output.WriteInt64(CameraStampTime);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (curPos_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(CurPos);
      }
      if (tarPos_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(TarPos);
      }
      if (CameraStampTime != 0L) {
        output.WriteRawTag(24);
        output.WriteInt64(CameraStampTime);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (curPos_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(CurPos);
      }
      if (tarPos_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(TarPos);
      }
      if (CameraStampTime != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(CameraStampTime);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(CameraActionMove other) {
      if (other == null) {
        return;
      }
      if (other.curPos_ != null) {
        if (curPos_ == null) {
          CurPos = new global::MelandGame3.Vector3();
        }
        CurPos.MergeFrom(other.CurPos);
      }
      if (other.tarPos_ != null) {
        if (tarPos_ == null) {
          TarPos = new global::MelandGame3.Vector3();
        }
        TarPos.MergeFrom(other.TarPos);
      }
      if (other.CameraStampTime != 0L) {
        CameraStampTime = other.CameraStampTime;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (curPos_ == null) {
              CurPos = new global::MelandGame3.Vector3();
            }
            input.ReadMessage(CurPos);
            break;
          }
          case 18: {
            if (tarPos_ == null) {
              TarPos = new global::MelandGame3.Vector3();
            }
            input.ReadMessage(TarPos);
            break;
          }
          case 24: {
            CameraStampTime = input.ReadInt64();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            if (curPos_ == null) {
              CurPos = new global::MelandGame3.Vector3();
            }
            input.ReadMessage(CurPos);
            break;
          }
          case 18: {
            if (tarPos_ == null) {
              TarPos = new global::MelandGame3.Vector3();
            }
            input.ReadMessage(TarPos);
            break;
          }
          case 24: {
            CameraStampTime = input.ReadInt64();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
