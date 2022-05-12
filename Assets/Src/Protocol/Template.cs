// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: template.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Bian {

  /// <summary>Holder for reflection information generated from template.proto</summary>
  public static partial class TemplateReflection {

    #region Descriptor
    /// <summary>File descriptor for template.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static TemplateReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg50ZW1wbGF0ZS5wcm90bxIEQmlhbiIrCghJbml0SXRlbRIOCgZpdGVtSWQY",
            "ASABKAUSDwoHaXRlbU51bRgCIAEoBSLYAQoQVGVtcGxhdGVTZXR0aW5ncxIK",
            "CgJpZBgBIAEoAxIQCghzY2VuZV9pZBgCIAEoBRINCgVpdGVtcxgDIAMoBRIZ",
            "ChFib3RfY29kZV90ZW1wbGF0ZRgEIAEoCRIWCg5tYW5vcl90ZW1wbGF0ZRgF",
            "IAEoBRIWCg5zY2VuZV90ZW1wbGF0ZRgGIAEoCRIkCgxzaG9ydGN1dF9kZWYY",
            "ByADKAsyDi5CaWFuLkluaXRJdGVtEhgKEG1hcF90ZW1wbGF0ZV90YWcYCCAB",
            "KAUSDAoEbmFtZRgJIAEoCWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Bian.InitItem), global::Bian.InitItem.Parser, new[]{ "ItemId", "ItemNum" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Bian.TemplateSettings), global::Bian.TemplateSettings.Parser, new[]{ "Id", "SceneId", "Items", "BotCodeTemplate", "ManorTemplate", "SceneTemplate", "ShortcutDef", "MapTemplateTag", "Name" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// 道具
  /// </summary>
  public sealed partial class InitItem : pb::IMessage<InitItem>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<InitItem> _parser = new pb::MessageParser<InitItem>(() => new InitItem());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<InitItem> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Bian.TemplateReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public InitItem() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public InitItem(InitItem other) : this() {
      itemId_ = other.itemId_;
      itemNum_ = other.itemNum_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public InitItem Clone() {
      return new InitItem(this);
    }

    /// <summary>Field number for the "itemId" field.</summary>
    public const int ItemIdFieldNumber = 1;
    private int itemId_;
    /// <summary>
    /// 道具id
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int ItemId {
      get { return itemId_; }
      set {
        itemId_ = value;
      }
    }

    /// <summary>Field number for the "itemNum" field.</summary>
    public const int ItemNumFieldNumber = 2;
    private int itemNum_;
    /// <summary>
    /// 道具数量
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int ItemNum {
      get { return itemNum_; }
      set {
        itemNum_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as InitItem);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(InitItem other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ItemId != other.ItemId) return false;
      if (ItemNum != other.ItemNum) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (ItemId != 0) hash ^= ItemId.GetHashCode();
      if (ItemNum != 0) hash ^= ItemNum.GetHashCode();
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
      if (ItemId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(ItemId);
      }
      if (ItemNum != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(ItemNum);
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
      if (ItemId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(ItemId);
      }
      if (ItemNum != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(ItemNum);
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
      if (ItemId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ItemId);
      }
      if (ItemNum != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ItemNum);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(InitItem other) {
      if (other == null) {
        return;
      }
      if (other.ItemId != 0) {
        ItemId = other.ItemId;
      }
      if (other.ItemNum != 0) {
        ItemNum = other.ItemNum;
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
            ItemId = input.ReadInt32();
            break;
          }
          case 16: {
            ItemNum = input.ReadInt32();
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
            ItemId = input.ReadInt32();
            break;
          }
          case 16: {
            ItemNum = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  /// <summary>
  /// 游戏模板
  /// </summary>
  public sealed partial class TemplateSettings : pb::IMessage<TemplateSettings>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<TemplateSettings> _parser = new pb::MessageParser<TemplateSettings>(() => new TemplateSettings());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<TemplateSettings> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Bian.TemplateReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TemplateSettings() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TemplateSettings(TemplateSettings other) : this() {
      id_ = other.id_;
      sceneId_ = other.sceneId_;
      items_ = other.items_.Clone();
      botCodeTemplate_ = other.botCodeTemplate_;
      manorTemplate_ = other.manorTemplate_;
      sceneTemplate_ = other.sceneTemplate_;
      shortcutDef_ = other.shortcutDef_.Clone();
      mapTemplateTag_ = other.mapTemplateTag_;
      name_ = other.name_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TemplateSettings Clone() {
      return new TemplateSettings(this);
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 1;
    private long id_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public long Id {
      get { return id_; }
      set {
        id_ = value;
      }
    }

    /// <summary>Field number for the "scene_id" field.</summary>
    public const int SceneIdFieldNumber = 2;
    private int sceneId_;
    /// <summary>
    /// 地图id
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int SceneId {
      get { return sceneId_; }
      set {
        sceneId_ = value;
      }
    }

    /// <summary>Field number for the "items" field.</summary>
    public const int ItemsFieldNumber = 3;
    private static readonly pb::FieldCodec<int> _repeated_items_codec
        = pb::FieldCodec.ForInt32(26);
    private readonly pbc::RepeatedField<int> items_ = new pbc::RepeatedField<int>();
    /// <summary>
    /// 物品模板
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<int> Items {
      get { return items_; }
    }

    /// <summary>Field number for the "bot_code_template" field.</summary>
    public const int BotCodeTemplateFieldNumber = 4;
    private string botCodeTemplate_ = "";
    /// <summary>
    /// 机器人代码模板
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string BotCodeTemplate {
      get { return botCodeTemplate_; }
      set {
        botCodeTemplate_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "manor_template" field.</summary>
    public const int ManorTemplateFieldNumber = 5;
    private int manorTemplate_;
    /// <summary>
    /// 领地模板
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int ManorTemplate {
      get { return manorTemplate_; }
      set {
        manorTemplate_ = value;
      }
    }

    /// <summary>Field number for the "scene_template" field.</summary>
    public const int SceneTemplateFieldNumber = 6;
    private string sceneTemplate_ = "";
    /// <summary>
    /// 地图模板(非地编铺设的模板数据)
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string SceneTemplate {
      get { return sceneTemplate_; }
      set {
        sceneTemplate_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "shortcut_def" field.</summary>
    public const int ShortcutDefFieldNumber = 7;
    private static readonly pb::FieldCodec<global::Bian.InitItem> _repeated_shortcutDef_codec
        = pb::FieldCodec.ForMessage(58, global::Bian.InitItem.Parser);
    private readonly pbc::RepeatedField<global::Bian.InitItem> shortcutDef_ = new pbc::RepeatedField<global::Bian.InitItem>();
    /// <summary>
    /// 快捷栏默认物品
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::Bian.InitItem> ShortcutDef {
      get { return shortcutDef_; }
    }

    /// <summary>Field number for the "map_template_tag" field.</summary>
    public const int MapTemplateTagFieldNumber = 8;
    private int mapTemplateTag_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int MapTemplateTag {
      get { return mapTemplateTag_; }
      set {
        mapTemplateTag_ = value;
      }
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 9;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as TemplateSettings);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(TemplateSettings other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (SceneId != other.SceneId) return false;
      if(!items_.Equals(other.items_)) return false;
      if (BotCodeTemplate != other.BotCodeTemplate) return false;
      if (ManorTemplate != other.ManorTemplate) return false;
      if (SceneTemplate != other.SceneTemplate) return false;
      if(!shortcutDef_.Equals(other.shortcutDef_)) return false;
      if (MapTemplateTag != other.MapTemplateTag) return false;
      if (Name != other.Name) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Id != 0L) hash ^= Id.GetHashCode();
      if (SceneId != 0) hash ^= SceneId.GetHashCode();
      hash ^= items_.GetHashCode();
      if (BotCodeTemplate.Length != 0) hash ^= BotCodeTemplate.GetHashCode();
      if (ManorTemplate != 0) hash ^= ManorTemplate.GetHashCode();
      if (SceneTemplate.Length != 0) hash ^= SceneTemplate.GetHashCode();
      hash ^= shortcutDef_.GetHashCode();
      if (MapTemplateTag != 0) hash ^= MapTemplateTag.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
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
      if (Id != 0L) {
        output.WriteRawTag(8);
        output.WriteInt64(Id);
      }
      if (SceneId != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(SceneId);
      }
      items_.WriteTo(output, _repeated_items_codec);
      if (BotCodeTemplate.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(BotCodeTemplate);
      }
      if (ManorTemplate != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(ManorTemplate);
      }
      if (SceneTemplate.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(SceneTemplate);
      }
      shortcutDef_.WriteTo(output, _repeated_shortcutDef_codec);
      if (MapTemplateTag != 0) {
        output.WriteRawTag(64);
        output.WriteInt32(MapTemplateTag);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(74);
        output.WriteString(Name);
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
      if (Id != 0L) {
        output.WriteRawTag(8);
        output.WriteInt64(Id);
      }
      if (SceneId != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(SceneId);
      }
      items_.WriteTo(ref output, _repeated_items_codec);
      if (BotCodeTemplate.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(BotCodeTemplate);
      }
      if (ManorTemplate != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(ManorTemplate);
      }
      if (SceneTemplate.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(SceneTemplate);
      }
      shortcutDef_.WriteTo(ref output, _repeated_shortcutDef_codec);
      if (MapTemplateTag != 0) {
        output.WriteRawTag(64);
        output.WriteInt32(MapTemplateTag);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(74);
        output.WriteString(Name);
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
      if (Id != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(Id);
      }
      if (SceneId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(SceneId);
      }
      size += items_.CalculateSize(_repeated_items_codec);
      if (BotCodeTemplate.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(BotCodeTemplate);
      }
      if (ManorTemplate != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ManorTemplate);
      }
      if (SceneTemplate.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(SceneTemplate);
      }
      size += shortcutDef_.CalculateSize(_repeated_shortcutDef_codec);
      if (MapTemplateTag != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(MapTemplateTag);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(TemplateSettings other) {
      if (other == null) {
        return;
      }
      if (other.Id != 0L) {
        Id = other.Id;
      }
      if (other.SceneId != 0) {
        SceneId = other.SceneId;
      }
      items_.Add(other.items_);
      if (other.BotCodeTemplate.Length != 0) {
        BotCodeTemplate = other.BotCodeTemplate;
      }
      if (other.ManorTemplate != 0) {
        ManorTemplate = other.ManorTemplate;
      }
      if (other.SceneTemplate.Length != 0) {
        SceneTemplate = other.SceneTemplate;
      }
      shortcutDef_.Add(other.shortcutDef_);
      if (other.MapTemplateTag != 0) {
        MapTemplateTag = other.MapTemplateTag;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
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
            Id = input.ReadInt64();
            break;
          }
          case 16: {
            SceneId = input.ReadInt32();
            break;
          }
          case 26:
          case 24: {
            items_.AddEntriesFrom(input, _repeated_items_codec);
            break;
          }
          case 34: {
            BotCodeTemplate = input.ReadString();
            break;
          }
          case 40: {
            ManorTemplate = input.ReadInt32();
            break;
          }
          case 50: {
            SceneTemplate = input.ReadString();
            break;
          }
          case 58: {
            shortcutDef_.AddEntriesFrom(input, _repeated_shortcutDef_codec);
            break;
          }
          case 64: {
            MapTemplateTag = input.ReadInt32();
            break;
          }
          case 74: {
            Name = input.ReadString();
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
            Id = input.ReadInt64();
            break;
          }
          case 16: {
            SceneId = input.ReadInt32();
            break;
          }
          case 26:
          case 24: {
            items_.AddEntriesFrom(ref input, _repeated_items_codec);
            break;
          }
          case 34: {
            BotCodeTemplate = input.ReadString();
            break;
          }
          case 40: {
            ManorTemplate = input.ReadInt32();
            break;
          }
          case 50: {
            SceneTemplate = input.ReadString();
            break;
          }
          case 58: {
            shortcutDef_.AddEntriesFrom(ref input, _repeated_shortcutDef_codec);
            break;
          }
          case 64: {
            MapTemplateTag = input.ReadInt32();
            break;
          }
          case 74: {
            Name = input.ReadString();
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