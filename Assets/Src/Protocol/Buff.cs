// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: buff.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Bian {

  /// <summary>Holder for reflection information generated from buff.proto</summary>
  public static partial class BuffReflection {

    #region Descriptor
    /// <summary>File descriptor for buff.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static BuffReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgpidWZmLnByb3RvEgRCaWFuIrIBCgxCdWZmU2V0dGluZ3MSDwoHYnVmZl9p",
            "ZBgBIAEoBRIpCgtlZmZlY3RfdHlwZRgCIAEoDjIULkJpYW4uQnVmZkVmZmVj",
            "dFR5cGUSEAoIZ3JvdXBfaWQYAyABKAUSFgoOZ3JvdXBfcHJpb3JpdHkYBCAB",
            "KAUSDgoGcGFyYW1zGAUgAygFEhIKCnRvdGFsX3RpbWUYBiABKAUSGAoQdHJp",
            "Z2dlcl9pbnRlcnZhbBgHIAEoBSItCgpFbnRpdHlCdWZmEg8KB2J1ZmZfaWQY",
            "ASABKAUSDgoGZW5kX21zGAIgASgJKu4CCg5CdWZmRWZmZWN0VHlwZRIkCiBC",
            "dWZmRWZmZWN0VHlwZV9CdWZmRWZmZWN0VW5rbm93bhAAEiIKHkJ1ZmZFZmZl",
            "Y3RUeXBlX0J1ZmZFZmZlY3RTdWJIcBABEiIKHkJ1ZmZFZmZlY3RUeXBlX0J1",
            "ZmZFZmZlY3RBZGRIcBACEiYKIkJ1ZmZFZmZlY3RUeXBlX0J1ZmZFZmZlY3RT",
            "dWJIdW5ncnkQAxImCiJCdWZmRWZmZWN0VHlwZV9CdWZmRWZmZWN0QWRkSHVu",
            "Z3J5EAQSJwojQnVmZkVmZmVjdFR5cGVfQnVmZkVmZmVjdFN1YlRoaXJzdHkQ",
            "BRInCiNCdWZmRWZmZWN0VHlwZV9CdWZmRWZmZWN0QWRkVGhpcnN0eRAGEiUK",
            "IUJ1ZmZFZmZlY3RUeXBlX0J1ZmZFZmZlY3RTdWJTcGVlZBAHEiUKIUJ1ZmZF",
            "ZmZlY3RUeXBlX0J1ZmZFZmZlY3RBZGRTcGVlZBAIYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::Bian.BuffEffectType), }, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Bian.BuffSettings), global::Bian.BuffSettings.Parser, new[]{ "BuffId", "EffectType", "GroupId", "GroupPriority", "Params", "TotalTime", "TriggerInterval" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Bian.EntityBuff), global::Bian.EntityBuff.Parser, new[]{ "BuffId", "EndMs" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  /// <summary>
  /// buff效果类型.
  /// </summary>
  public enum BuffEffectType {
    /// <summary>
    ///未知类型，不处理
    /// </summary>
    [pbr::OriginalName("BuffEffectType_BuffEffectUnknown")] BuffEffectUnknown = 0,
    /// <summary>
    ///随时间减血
    /// </summary>
    [pbr::OriginalName("BuffEffectType_BuffEffectSubHp")] BuffEffectSubHp = 1,
    /// <summary>
    ///随时间加血  
    /// </summary>
    [pbr::OriginalName("BuffEffectType_BuffEffectAddHp")] BuffEffectAddHp = 2,
    /// <summary>
    ///随时间减饥饿度(deprecated)
    /// </summary>
    [pbr::OriginalName("BuffEffectType_BuffEffectSubHungry")] BuffEffectSubHungry = 3,
    /// <summary>
    ///随时间加饥饿度(deprecated)
    /// </summary>
    [pbr::OriginalName("BuffEffectType_BuffEffectAddHungry")] BuffEffectAddHungry = 4,
    /// <summary>
    ///随时间减饥渴度(deprecated)
    /// </summary>
    [pbr::OriginalName("BuffEffectType_BuffEffectSubThirsty")] BuffEffectSubThirsty = 5,
    /// <summary>
    ///随时间加饥渴度(deprecated)
    /// </summary>
    [pbr::OriginalName("BuffEffectType_BuffEffectAddThirsty")] BuffEffectAddThirsty = 6,
    /// <summary>
    ///减速
    /// </summary>
    [pbr::OriginalName("BuffEffectType_BuffEffectSubSpeed")] BuffEffectSubSpeed = 7,
    /// <summary>
    ///加速  
    /// </summary>
    [pbr::OriginalName("BuffEffectType_BuffEffectAddSpeed")] BuffEffectAddSpeed = 8,
  }

  #endregion

  #region Messages
  /// <summary>
  /// buff模板
  /// </summary>
  public sealed partial class BuffSettings : pb::IMessage<BuffSettings>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<BuffSettings> _parser = new pb::MessageParser<BuffSettings>(() => new BuffSettings());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<BuffSettings> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Bian.BuffReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public BuffSettings() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public BuffSettings(BuffSettings other) : this() {
      buffId_ = other.buffId_;
      effectType_ = other.effectType_;
      groupId_ = other.groupId_;
      groupPriority_ = other.groupPriority_;
      params_ = other.params_.Clone();
      totalTime_ = other.totalTime_;
      triggerInterval_ = other.triggerInterval_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public BuffSettings Clone() {
      return new BuffSettings(this);
    }

    /// <summary>Field number for the "buff_id" field.</summary>
    public const int BuffIdFieldNumber = 1;
    private int buffId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int BuffId {
      get { return buffId_; }
      set {
        buffId_ = value;
      }
    }

    /// <summary>Field number for the "effect_type" field.</summary>
    public const int EffectTypeFieldNumber = 2;
    private global::Bian.BuffEffectType effectType_ = global::Bian.BuffEffectType.BuffEffectUnknown;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Bian.BuffEffectType EffectType {
      get { return effectType_; }
      set {
        effectType_ = value;
      }
    }

    /// <summary>Field number for the "group_id" field.</summary>
    public const int GroupIdFieldNumber = 3;
    private int groupId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int GroupId {
      get { return groupId_; }
      set {
        groupId_ = value;
      }
    }

    /// <summary>Field number for the "group_priority" field.</summary>
    public const int GroupPriorityFieldNumber = 4;
    private int groupPriority_;
    /// <summary>
    ///优先级(越大优先级越高)
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int GroupPriority {
      get { return groupPriority_; }
      set {
        groupPriority_ = value;
      }
    }

    /// <summary>Field number for the "params" field.</summary>
    public const int ParamsFieldNumber = 5;
    private static readonly pb::FieldCodec<int> _repeated_params_codec
        = pb::FieldCodec.ForInt32(42);
    private readonly pbc::RepeatedField<int> params_ = new pbc::RepeatedField<int>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<int> Params {
      get { return params_; }
    }

    /// <summary>Field number for the "total_time" field.</summary>
    public const int TotalTimeFieldNumber = 6;
    private int totalTime_;
    /// <summary>
    ///总持续时间
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int TotalTime {
      get { return totalTime_; }
      set {
        totalTime_ = value;
      }
    }

    /// <summary>Field number for the "trigger_interval" field.</summary>
    public const int TriggerIntervalFieldNumber = 7;
    private int triggerInterval_;
    /// <summary>
    ///触发间隔  
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int TriggerInterval {
      get { return triggerInterval_; }
      set {
        triggerInterval_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as BuffSettings);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(BuffSettings other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (BuffId != other.BuffId) return false;
      if (EffectType != other.EffectType) return false;
      if (GroupId != other.GroupId) return false;
      if (GroupPriority != other.GroupPriority) return false;
      if(!params_.Equals(other.params_)) return false;
      if (TotalTime != other.TotalTime) return false;
      if (TriggerInterval != other.TriggerInterval) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (BuffId != 0) hash ^= BuffId.GetHashCode();
      if (EffectType != global::Bian.BuffEffectType.BuffEffectUnknown) hash ^= EffectType.GetHashCode();
      if (GroupId != 0) hash ^= GroupId.GetHashCode();
      if (GroupPriority != 0) hash ^= GroupPriority.GetHashCode();
      hash ^= params_.GetHashCode();
      if (TotalTime != 0) hash ^= TotalTime.GetHashCode();
      if (TriggerInterval != 0) hash ^= TriggerInterval.GetHashCode();
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
      if (BuffId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(BuffId);
      }
      if (EffectType != global::Bian.BuffEffectType.BuffEffectUnknown) {
        output.WriteRawTag(16);
        output.WriteEnum((int) EffectType);
      }
      if (GroupId != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(GroupId);
      }
      if (GroupPriority != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(GroupPriority);
      }
      params_.WriteTo(output, _repeated_params_codec);
      if (TotalTime != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(TotalTime);
      }
      if (TriggerInterval != 0) {
        output.WriteRawTag(56);
        output.WriteInt32(TriggerInterval);
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
      if (BuffId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(BuffId);
      }
      if (EffectType != global::Bian.BuffEffectType.BuffEffectUnknown) {
        output.WriteRawTag(16);
        output.WriteEnum((int) EffectType);
      }
      if (GroupId != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(GroupId);
      }
      if (GroupPriority != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(GroupPriority);
      }
      params_.WriteTo(ref output, _repeated_params_codec);
      if (TotalTime != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(TotalTime);
      }
      if (TriggerInterval != 0) {
        output.WriteRawTag(56);
        output.WriteInt32(TriggerInterval);
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
      if (BuffId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(BuffId);
      }
      if (EffectType != global::Bian.BuffEffectType.BuffEffectUnknown) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) EffectType);
      }
      if (GroupId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(GroupId);
      }
      if (GroupPriority != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(GroupPriority);
      }
      size += params_.CalculateSize(_repeated_params_codec);
      if (TotalTime != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(TotalTime);
      }
      if (TriggerInterval != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(TriggerInterval);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(BuffSettings other) {
      if (other == null) {
        return;
      }
      if (other.BuffId != 0) {
        BuffId = other.BuffId;
      }
      if (other.EffectType != global::Bian.BuffEffectType.BuffEffectUnknown) {
        EffectType = other.EffectType;
      }
      if (other.GroupId != 0) {
        GroupId = other.GroupId;
      }
      if (other.GroupPriority != 0) {
        GroupPriority = other.GroupPriority;
      }
      params_.Add(other.params_);
      if (other.TotalTime != 0) {
        TotalTime = other.TotalTime;
      }
      if (other.TriggerInterval != 0) {
        TriggerInterval = other.TriggerInterval;
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
            BuffId = input.ReadInt32();
            break;
          }
          case 16: {
            EffectType = (global::Bian.BuffEffectType) input.ReadEnum();
            break;
          }
          case 24: {
            GroupId = input.ReadInt32();
            break;
          }
          case 32: {
            GroupPriority = input.ReadInt32();
            break;
          }
          case 42:
          case 40: {
            params_.AddEntriesFrom(input, _repeated_params_codec);
            break;
          }
          case 48: {
            TotalTime = input.ReadInt32();
            break;
          }
          case 56: {
            TriggerInterval = input.ReadInt32();
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
            BuffId = input.ReadInt32();
            break;
          }
          case 16: {
            EffectType = (global::Bian.BuffEffectType) input.ReadEnum();
            break;
          }
          case 24: {
            GroupId = input.ReadInt32();
            break;
          }
          case 32: {
            GroupPriority = input.ReadInt32();
            break;
          }
          case 42:
          case 40: {
            params_.AddEntriesFrom(ref input, _repeated_params_codec);
            break;
          }
          case 48: {
            TotalTime = input.ReadInt32();
            break;
          }
          case 56: {
            TriggerInterval = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class EntityBuff : pb::IMessage<EntityBuff>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<EntityBuff> _parser = new pb::MessageParser<EntityBuff>(() => new EntityBuff());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<EntityBuff> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Bian.BuffReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public EntityBuff() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public EntityBuff(EntityBuff other) : this() {
      buffId_ = other.buffId_;
      endMs_ = other.endMs_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public EntityBuff Clone() {
      return new EntityBuff(this);
    }

    /// <summary>Field number for the "buff_id" field.</summary>
    public const int BuffIdFieldNumber = 1;
    private int buffId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int BuffId {
      get { return buffId_; }
      set {
        buffId_ = value;
      }
    }

    /// <summary>Field number for the "end_ms" field.</summary>
    public const int EndMsFieldNumber = 2;
    private string endMs_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string EndMs {
      get { return endMs_; }
      set {
        endMs_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as EntityBuff);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(EntityBuff other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (BuffId != other.BuffId) return false;
      if (EndMs != other.EndMs) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (BuffId != 0) hash ^= BuffId.GetHashCode();
      if (EndMs.Length != 0) hash ^= EndMs.GetHashCode();
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
      if (BuffId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(BuffId);
      }
      if (EndMs.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(EndMs);
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
      if (BuffId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(BuffId);
      }
      if (EndMs.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(EndMs);
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
      if (BuffId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(BuffId);
      }
      if (EndMs.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(EndMs);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(EntityBuff other) {
      if (other == null) {
        return;
      }
      if (other.BuffId != 0) {
        BuffId = other.BuffId;
      }
      if (other.EndMs.Length != 0) {
        EndMs = other.EndMs;
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
            BuffId = input.ReadInt32();
            break;
          }
          case 18: {
            EndMs = input.ReadString();
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
            BuffId = input.ReadInt32();
            break;
          }
          case 18: {
            EndMs = input.ReadString();
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
