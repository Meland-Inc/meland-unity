// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: monster.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace MelandGame3 {

  /// <summary>Holder for reflection information generated from monster.proto</summary>
  public static partial class MonsterReflection {

    #region Descriptor
    /// <summary>File descriptor for monster.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static MonsterReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg1tb25zdGVyLnByb3RvEgtNZWxhbmRHYW1lMxoLbW9kZWwucHJvdG8aDHdp",
            "ZGdldC5wcm90byKOAwoPTW9uc3RlclNldHRpbmdzEgsKA2NpZBgBIAEoBRIM",
            "CgRuYW1lGAIgASgJEhMKC2JvZHlfcmFkaXVzGAMgASgFEi0KCGF0dF90eXBl",
            "GAQgASgOMhsuTWVsYW5kR2FtZTMuTW9uc3RlckF0dFR5cGUSGQoRbG9ja19l",
            "bmVteV9yYWRpdXMYBSABKAUSEwoLY29tYmF0X2Rpc3QYBiABKAUSDwoHZHJv",
            "cF9pZBgHIAEoBRIWCg5za2lsbF9zZXF1ZW5jZRgIIAMoBRIrCgdwcm9maWxl",
            "GAogASgLMhouTWVsYW5kR2FtZTMuRW50aXR5UHJvZmlsZRIkCgd3aWRnZXRz",
            "GFogAygLMhMuTWVsYW5kR2FtZTMuV2lkZ2V0Eg4KBmZyYW1lcxhbIAMoBRIs",
            "CgVhbmltcxhcIAEoCzIdLk1lbGFuZEdhbWUzLkVudGl0eUFuaW1hdGlvbnMS",
            "MgoOZW50aXR5X3ByZWxvYWQYXSABKAsyGi5NZWxhbmRHYW1lMy5FbnRpdHlQ",
            "cmVsb2FkYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::MelandGame3.ModelReflection.Descriptor, global::MelandGame3.WidgetReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::MelandGame3.MonsterSettings), global::MelandGame3.MonsterSettings.Parser, new[]{ "Cid", "Name", "BodyRadius", "AttType", "LockEnemyRadius", "CombatDist", "DropId", "SkillSequence", "Profile", "Widgets", "Frames", "Anims", "EntityPreload" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// ????????????.
  /// </summary>
  public sealed partial class MonsterSettings : pb::IMessage<MonsterSettings>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<MonsterSettings> _parser = new pb::MessageParser<MonsterSettings>(() => new MonsterSettings());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<MonsterSettings> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MelandGame3.MonsterReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public MonsterSettings() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public MonsterSettings(MonsterSettings other) : this() {
      cid_ = other.cid_;
      name_ = other.name_;
      bodyRadius_ = other.bodyRadius_;
      attType_ = other.attType_;
      lockEnemyRadius_ = other.lockEnemyRadius_;
      combatDist_ = other.combatDist_;
      dropId_ = other.dropId_;
      skillSequence_ = other.skillSequence_.Clone();
      profile_ = other.profile_ != null ? other.profile_.Clone() : null;
      widgets_ = other.widgets_.Clone();
      frames_ = other.frames_.Clone();
      anims_ = other.anims_ != null ? other.anims_.Clone() : null;
      entityPreload_ = other.entityPreload_ != null ? other.entityPreload_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public MonsterSettings Clone() {
      return new MonsterSettings(this);
    }

    /// <summary>Field number for the "cid" field.</summary>
    public const int CidFieldNumber = 1;
    private int cid_;
    /// <summary>
    /// ?????? id
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Cid {
      get { return cid_; }
      set {
        cid_ = value;
      }
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 2;
    private string name_ = "";
    /// <summary>
    /// ??????
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "body_radius" field.</summary>
    public const int BodyRadiusFieldNumber = 3;
    private int bodyRadius_;
    /// <summary>
    /// ????????????(??????)
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int BodyRadius {
      get { return bodyRadius_; }
      set {
        bodyRadius_ = value;
      }
    }

    /// <summary>Field number for the "att_type" field.</summary>
    public const int AttTypeFieldNumber = 4;
    private global::MelandGame3.MonsterAttType attType_ = global::MelandGame3.MonsterAttType.MonsterAttTypeUnknown;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::MelandGame3.MonsterAttType AttType {
      get { return attType_; }
      set {
        attType_ = value;
      }
    }

    /// <summary>Field number for the "lock_enemy_radius" field.</summary>
    public const int LockEnemyRadiusFieldNumber = 5;
    private int lockEnemyRadius_;
    /// <summary>
    /// ????????????
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int LockEnemyRadius {
      get { return lockEnemyRadius_; }
      set {
        lockEnemyRadius_ = value;
      }
    }

    /// <summary>Field number for the "combat_dist" field.</summary>
    public const int CombatDistFieldNumber = 6;
    private int combatDist_;
    /// <summary>
    /// ????????????
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CombatDist {
      get { return combatDist_; }
      set {
        combatDist_ = value;
      }
    }

    /// <summary>Field number for the "drop_id" field.</summary>
    public const int DropIdFieldNumber = 7;
    private int dropId_;
    /// <summary>
    /// ????????????ID
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int DropId {
      get { return dropId_; }
      set {
        dropId_ = value;
      }
    }

    /// <summary>Field number for the "skill_sequence" field.</summary>
    public const int SkillSequenceFieldNumber = 8;
    private static readonly pb::FieldCodec<int> _repeated_skillSequence_codec
        = pb::FieldCodec.ForInt32(66);
    private readonly pbc::RepeatedField<int> skillSequence_ = new pbc::RepeatedField<int>();
    /// <summary>
    ///????????????
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<int> SkillSequence {
      get { return skillSequence_; }
    }

    /// <summary>Field number for the "profile" field.</summary>
    public const int ProfileFieldNumber = 10;
    private global::MelandGame3.EntityProfile profile_;
    /// <summary>
    /// ??????????????????
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::MelandGame3.EntityProfile Profile {
      get { return profile_; }
      set {
        profile_ = value;
      }
    }

    /// <summary>Field number for the "widgets" field.</summary>
    public const int WidgetsFieldNumber = 90;
    private static readonly pb::FieldCodec<global::MelandGame3.Widget> _repeated_widgets_codec
        = pb::FieldCodec.ForMessage(722, global::MelandGame3.Widget.Parser);
    private readonly pbc::RepeatedField<global::MelandGame3.Widget> widgets_ = new pbc::RepeatedField<global::MelandGame3.Widget>();
    /// <summary>
    /// ????????????
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::MelandGame3.Widget> Widgets {
      get { return widgets_; }
    }

    /// <summary>Field number for the "frames" field.</summary>
    public const int FramesFieldNumber = 91;
    private static readonly pb::FieldCodec<int> _repeated_frames_codec
        = pb::FieldCodec.ForInt32(730);
    private readonly pbc::RepeatedField<int> frames_ = new pbc::RepeatedField<int>();
    /// <summary>
    /// ?????????(??????)
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<int> Frames {
      get { return frames_; }
    }

    /// <summary>Field number for the "anims" field.</summary>
    public const int AnimsFieldNumber = 92;
    private global::MelandGame3.EntityAnimations anims_;
    /// <summary>
    /// ??????
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::MelandGame3.EntityAnimations Anims {
      get { return anims_; }
      set {
        anims_ = value;
      }
    }

    /// <summary>Field number for the "entity_preload" field.</summary>
    public const int EntityPreloadFieldNumber = 93;
    private global::MelandGame3.EntityPreload entityPreload_;
    /// <summary>
    /// ??????????????????
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::MelandGame3.EntityPreload EntityPreload {
      get { return entityPreload_; }
      set {
        entityPreload_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as MonsterSettings);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(MonsterSettings other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Cid != other.Cid) return false;
      if (Name != other.Name) return false;
      if (BodyRadius != other.BodyRadius) return false;
      if (AttType != other.AttType) return false;
      if (LockEnemyRadius != other.LockEnemyRadius) return false;
      if (CombatDist != other.CombatDist) return false;
      if (DropId != other.DropId) return false;
      if(!skillSequence_.Equals(other.skillSequence_)) return false;
      if (!object.Equals(Profile, other.Profile)) return false;
      if(!widgets_.Equals(other.widgets_)) return false;
      if(!frames_.Equals(other.frames_)) return false;
      if (!object.Equals(Anims, other.Anims)) return false;
      if (!object.Equals(EntityPreload, other.EntityPreload)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Cid != 0) hash ^= Cid.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (BodyRadius != 0) hash ^= BodyRadius.GetHashCode();
      if (AttType != global::MelandGame3.MonsterAttType.MonsterAttTypeUnknown) hash ^= AttType.GetHashCode();
      if (LockEnemyRadius != 0) hash ^= LockEnemyRadius.GetHashCode();
      if (CombatDist != 0) hash ^= CombatDist.GetHashCode();
      if (DropId != 0) hash ^= DropId.GetHashCode();
      hash ^= skillSequence_.GetHashCode();
      if (profile_ != null) hash ^= Profile.GetHashCode();
      hash ^= widgets_.GetHashCode();
      hash ^= frames_.GetHashCode();
      if (anims_ != null) hash ^= Anims.GetHashCode();
      if (entityPreload_ != null) hash ^= EntityPreload.GetHashCode();
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
      if (Cid != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Cid);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Name);
      }
      if (BodyRadius != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(BodyRadius);
      }
      if (AttType != global::MelandGame3.MonsterAttType.MonsterAttTypeUnknown) {
        output.WriteRawTag(32);
        output.WriteEnum((int) AttType);
      }
      if (LockEnemyRadius != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(LockEnemyRadius);
      }
      if (CombatDist != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(CombatDist);
      }
      if (DropId != 0) {
        output.WriteRawTag(56);
        output.WriteInt32(DropId);
      }
      skillSequence_.WriteTo(output, _repeated_skillSequence_codec);
      if (profile_ != null) {
        output.WriteRawTag(82);
        output.WriteMessage(Profile);
      }
      widgets_.WriteTo(output, _repeated_widgets_codec);
      frames_.WriteTo(output, _repeated_frames_codec);
      if (anims_ != null) {
        output.WriteRawTag(226, 5);
        output.WriteMessage(Anims);
      }
      if (entityPreload_ != null) {
        output.WriteRawTag(234, 5);
        output.WriteMessage(EntityPreload);
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
      if (Cid != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Cid);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Name);
      }
      if (BodyRadius != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(BodyRadius);
      }
      if (AttType != global::MelandGame3.MonsterAttType.MonsterAttTypeUnknown) {
        output.WriteRawTag(32);
        output.WriteEnum((int) AttType);
      }
      if (LockEnemyRadius != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(LockEnemyRadius);
      }
      if (CombatDist != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(CombatDist);
      }
      if (DropId != 0) {
        output.WriteRawTag(56);
        output.WriteInt32(DropId);
      }
      skillSequence_.WriteTo(ref output, _repeated_skillSequence_codec);
      if (profile_ != null) {
        output.WriteRawTag(82);
        output.WriteMessage(Profile);
      }
      widgets_.WriteTo(ref output, _repeated_widgets_codec);
      frames_.WriteTo(ref output, _repeated_frames_codec);
      if (anims_ != null) {
        output.WriteRawTag(226, 5);
        output.WriteMessage(Anims);
      }
      if (entityPreload_ != null) {
        output.WriteRawTag(234, 5);
        output.WriteMessage(EntityPreload);
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
      if (Cid != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Cid);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (BodyRadius != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(BodyRadius);
      }
      if (AttType != global::MelandGame3.MonsterAttType.MonsterAttTypeUnknown) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) AttType);
      }
      if (LockEnemyRadius != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(LockEnemyRadius);
      }
      if (CombatDist != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(CombatDist);
      }
      if (DropId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(DropId);
      }
      size += skillSequence_.CalculateSize(_repeated_skillSequence_codec);
      if (profile_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Profile);
      }
      size += widgets_.CalculateSize(_repeated_widgets_codec);
      size += frames_.CalculateSize(_repeated_frames_codec);
      if (anims_ != null) {
        size += 2 + pb::CodedOutputStream.ComputeMessageSize(Anims);
      }
      if (entityPreload_ != null) {
        size += 2 + pb::CodedOutputStream.ComputeMessageSize(EntityPreload);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(MonsterSettings other) {
      if (other == null) {
        return;
      }
      if (other.Cid != 0) {
        Cid = other.Cid;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.BodyRadius != 0) {
        BodyRadius = other.BodyRadius;
      }
      if (other.AttType != global::MelandGame3.MonsterAttType.MonsterAttTypeUnknown) {
        AttType = other.AttType;
      }
      if (other.LockEnemyRadius != 0) {
        LockEnemyRadius = other.LockEnemyRadius;
      }
      if (other.CombatDist != 0) {
        CombatDist = other.CombatDist;
      }
      if (other.DropId != 0) {
        DropId = other.DropId;
      }
      skillSequence_.Add(other.skillSequence_);
      if (other.profile_ != null) {
        if (profile_ == null) {
          Profile = new global::MelandGame3.EntityProfile();
        }
        Profile.MergeFrom(other.Profile);
      }
      widgets_.Add(other.widgets_);
      frames_.Add(other.frames_);
      if (other.anims_ != null) {
        if (anims_ == null) {
          Anims = new global::MelandGame3.EntityAnimations();
        }
        Anims.MergeFrom(other.Anims);
      }
      if (other.entityPreload_ != null) {
        if (entityPreload_ == null) {
          EntityPreload = new global::MelandGame3.EntityPreload();
        }
        EntityPreload.MergeFrom(other.EntityPreload);
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
            Cid = input.ReadInt32();
            break;
          }
          case 18: {
            Name = input.ReadString();
            break;
          }
          case 24: {
            BodyRadius = input.ReadInt32();
            break;
          }
          case 32: {
            AttType = (global::MelandGame3.MonsterAttType) input.ReadEnum();
            break;
          }
          case 40: {
            LockEnemyRadius = input.ReadInt32();
            break;
          }
          case 48: {
            CombatDist = input.ReadInt32();
            break;
          }
          case 56: {
            DropId = input.ReadInt32();
            break;
          }
          case 66:
          case 64: {
            skillSequence_.AddEntriesFrom(input, _repeated_skillSequence_codec);
            break;
          }
          case 82: {
            if (profile_ == null) {
              Profile = new global::MelandGame3.EntityProfile();
            }
            input.ReadMessage(Profile);
            break;
          }
          case 722: {
            widgets_.AddEntriesFrom(input, _repeated_widgets_codec);
            break;
          }
          case 730:
          case 728: {
            frames_.AddEntriesFrom(input, _repeated_frames_codec);
            break;
          }
          case 738: {
            if (anims_ == null) {
              Anims = new global::MelandGame3.EntityAnimations();
            }
            input.ReadMessage(Anims);
            break;
          }
          case 746: {
            if (entityPreload_ == null) {
              EntityPreload = new global::MelandGame3.EntityPreload();
            }
            input.ReadMessage(EntityPreload);
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
            Cid = input.ReadInt32();
            break;
          }
          case 18: {
            Name = input.ReadString();
            break;
          }
          case 24: {
            BodyRadius = input.ReadInt32();
            break;
          }
          case 32: {
            AttType = (global::MelandGame3.MonsterAttType) input.ReadEnum();
            break;
          }
          case 40: {
            LockEnemyRadius = input.ReadInt32();
            break;
          }
          case 48: {
            CombatDist = input.ReadInt32();
            break;
          }
          case 56: {
            DropId = input.ReadInt32();
            break;
          }
          case 66:
          case 64: {
            skillSequence_.AddEntriesFrom(ref input, _repeated_skillSequence_codec);
            break;
          }
          case 82: {
            if (profile_ == null) {
              Profile = new global::MelandGame3.EntityProfile();
            }
            input.ReadMessage(Profile);
            break;
          }
          case 722: {
            widgets_.AddEntriesFrom(ref input, _repeated_widgets_codec);
            break;
          }
          case 730:
          case 728: {
            frames_.AddEntriesFrom(ref input, _repeated_frames_codec);
            break;
          }
          case 738: {
            if (anims_ == null) {
              Anims = new global::MelandGame3.EntityAnimations();
            }
            input.ReadMessage(Anims);
            break;
          }
          case 746: {
            if (entityPreload_ == null) {
              EntityPreload = new global::MelandGame3.EntityPreload();
            }
            input.ReadMessage(EntityPreload);
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
