// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: ProtoFootprintCollection.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Sentinal2Utilities.Tile.Proto {

  /// <summary>Holder for reflection information generated from ProtoFootprintCollection.proto</summary>
  public static partial class ProtoFootprintCollectionReflection {

    #region Descriptor
    /// <summary>File descriptor for ProtoFootprintCollection.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ProtoFootprintCollectionReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ch5Qcm90b0Zvb3RwcmludENvbGxlY3Rpb24ucHJvdG8SCHMyYS50aWxlIrAC",
            "ChhQcm90b0Zvb3RwcmludENvbGxlY3Rpb24SDwoHS01MRmlsZRgBIAEoCRIT",
            "CgtDb21waWxlRGF0ZRgCIAEoBBJFCgpGb290cHJpbnRzGAMgAygLMjEuczJh",
            "LnRpbGUuUHJvdG9Gb290cHJpbnRDb2xsZWN0aW9uLlByb3RvRm9vdHByaW50",
            "GjYKD1Byb3RvQ29vcmRpbmF0ZRIQCghMYXRpdHVkZRgBIAEoARIRCglMb25n",
            "aXR1ZGUYAiABKAEabwoOUHJvdG9Gb290cHJpbnQSFAoMVGlsZVBvc2l0aW9u",
            "GAEgASgJEkcKC2Nvb3JkaW5hdGVzGAIgAygLMjIuczJhLnRpbGUuUHJvdG9G",
            "b290cHJpbnRDb2xsZWN0aW9uLlByb3RvQ29vcmRpbmF0ZUIgqgIdU2VudGlu",
            "YWwyVXRpbGl0aWVzLlRpbGUuUHJvdG9iBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Sentinal2Utilities.Tile.Proto.ProtoFootprintCollection), global::Sentinal2Utilities.Tile.Proto.ProtoFootprintCollection.Parser, new[]{ "KMLFile", "CompileDate", "Footprints" }, null, null, null, new pbr::GeneratedClrTypeInfo[] { new pbr::GeneratedClrTypeInfo(typeof(global::Sentinal2Utilities.Tile.Proto.ProtoFootprintCollection.Types.ProtoCoordinate), global::Sentinal2Utilities.Tile.Proto.ProtoFootprintCollection.Types.ProtoCoordinate.Parser, new[]{ "Latitude", "Longitude" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Sentinal2Utilities.Tile.Proto.ProtoFootprintCollection.Types.ProtoFootprint), global::Sentinal2Utilities.Tile.Proto.ProtoFootprintCollection.Types.ProtoFootprint.Parser, new[]{ "TilePosition", "Coordinates" }, null, null, null, null)})
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class ProtoFootprintCollection : pb::IMessage<ProtoFootprintCollection> {
    private static readonly pb::MessageParser<ProtoFootprintCollection> _parser = new pb::MessageParser<ProtoFootprintCollection>(() => new ProtoFootprintCollection());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ProtoFootprintCollection> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Sentinal2Utilities.Tile.Proto.ProtoFootprintCollectionReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ProtoFootprintCollection() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ProtoFootprintCollection(ProtoFootprintCollection other) : this() {
      kMLFile_ = other.kMLFile_;
      compileDate_ = other.compileDate_;
      footprints_ = other.footprints_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ProtoFootprintCollection Clone() {
      return new ProtoFootprintCollection(this);
    }

    /// <summary>Field number for the "KMLFile" field.</summary>
    public const int KMLFileFieldNumber = 1;
    private string kMLFile_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string KMLFile {
      get { return kMLFile_; }
      set {
        kMLFile_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "CompileDate" field.</summary>
    public const int CompileDateFieldNumber = 2;
    private ulong compileDate_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ulong CompileDate {
      get { return compileDate_; }
      set {
        compileDate_ = value;
      }
    }

    /// <summary>Field number for the "Footprints" field.</summary>
    public const int FootprintsFieldNumber = 3;
    private static readonly pb::FieldCodec<global::Sentinal2Utilities.Tile.Proto.ProtoFootprintCollection.Types.ProtoFootprint> _repeated_footprints_codec
        = pb::FieldCodec.ForMessage(26, global::Sentinal2Utilities.Tile.Proto.ProtoFootprintCollection.Types.ProtoFootprint.Parser);
    private readonly pbc::RepeatedField<global::Sentinal2Utilities.Tile.Proto.ProtoFootprintCollection.Types.ProtoFootprint> footprints_ = new pbc::RepeatedField<global::Sentinal2Utilities.Tile.Proto.ProtoFootprintCollection.Types.ProtoFootprint>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Sentinal2Utilities.Tile.Proto.ProtoFootprintCollection.Types.ProtoFootprint> Footprints {
      get { return footprints_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ProtoFootprintCollection);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ProtoFootprintCollection other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (KMLFile != other.KMLFile) return false;
      if (CompileDate != other.CompileDate) return false;
      if(!footprints_.Equals(other.footprints_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (KMLFile.Length != 0) hash ^= KMLFile.GetHashCode();
      if (CompileDate != 0UL) hash ^= CompileDate.GetHashCode();
      hash ^= footprints_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (KMLFile.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(KMLFile);
      }
      if (CompileDate != 0UL) {
        output.WriteRawTag(16);
        output.WriteUInt64(CompileDate);
      }
      footprints_.WriteTo(output, _repeated_footprints_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (KMLFile.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(KMLFile);
      }
      if (CompileDate != 0UL) {
        size += 1 + pb::CodedOutputStream.ComputeUInt64Size(CompileDate);
      }
      size += footprints_.CalculateSize(_repeated_footprints_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ProtoFootprintCollection other) {
      if (other == null) {
        return;
      }
      if (other.KMLFile.Length != 0) {
        KMLFile = other.KMLFile;
      }
      if (other.CompileDate != 0UL) {
        CompileDate = other.CompileDate;
      }
      footprints_.Add(other.footprints_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            KMLFile = input.ReadString();
            break;
          }
          case 16: {
            CompileDate = input.ReadUInt64();
            break;
          }
          case 26: {
            footprints_.AddEntriesFrom(input, _repeated_footprints_codec);
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the ProtoFootprintCollection message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      public sealed partial class ProtoCoordinate : pb::IMessage<ProtoCoordinate> {
        private static readonly pb::MessageParser<ProtoCoordinate> _parser = new pb::MessageParser<ProtoCoordinate>(() => new ProtoCoordinate());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<ProtoCoordinate> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor {
          get { return global::Sentinal2Utilities.Tile.Proto.ProtoFootprintCollection.Descriptor.NestedTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor {
          get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ProtoCoordinate() {
          OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ProtoCoordinate(ProtoCoordinate other) : this() {
          latitude_ = other.latitude_;
          longitude_ = other.longitude_;
          _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ProtoCoordinate Clone() {
          return new ProtoCoordinate(this);
        }

        /// <summary>Field number for the "Latitude" field.</summary>
        public const int LatitudeFieldNumber = 1;
        private double latitude_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public double Latitude {
          get { return latitude_; }
          set {
            latitude_ = value;
          }
        }

        /// <summary>Field number for the "Longitude" field.</summary>
        public const int LongitudeFieldNumber = 2;
        private double longitude_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public double Longitude {
          get { return longitude_; }
          set {
            longitude_ = value;
          }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
          return Equals(other as ProtoCoordinate);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(ProtoCoordinate other) {
          if (ReferenceEquals(other, null)) {
            return false;
          }
          if (ReferenceEquals(other, this)) {
            return true;
          }
          if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Latitude, other.Latitude)) return false;
          if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Longitude, other.Longitude)) return false;
          return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
          int hash = 1;
          if (Latitude != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Latitude);
          if (Longitude != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Longitude);
          if (_unknownFields != null) {
            hash ^= _unknownFields.GetHashCode();
          }
          return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString() {
          return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output) {
          if (Latitude != 0D) {
            output.WriteRawTag(9);
            output.WriteDouble(Latitude);
          }
          if (Longitude != 0D) {
            output.WriteRawTag(17);
            output.WriteDouble(Longitude);
          }
          if (_unknownFields != null) {
            _unknownFields.WriteTo(output);
          }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
          int size = 0;
          if (Latitude != 0D) {
            size += 1 + 8;
          }
          if (Longitude != 0D) {
            size += 1 + 8;
          }
          if (_unknownFields != null) {
            size += _unknownFields.CalculateSize();
          }
          return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(ProtoCoordinate other) {
          if (other == null) {
            return;
          }
          if (other.Latitude != 0D) {
            Latitude = other.Latitude;
          }
          if (other.Longitude != 0D) {
            Longitude = other.Longitude;
          }
          _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input) {
          uint tag;
          while ((tag = input.ReadTag()) != 0) {
            switch(tag) {
              default:
                _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                break;
              case 9: {
                Latitude = input.ReadDouble();
                break;
              }
              case 17: {
                Longitude = input.ReadDouble();
                break;
              }
            }
          }
        }

      }

      public sealed partial class ProtoFootprint : pb::IMessage<ProtoFootprint> {
        private static readonly pb::MessageParser<ProtoFootprint> _parser = new pb::MessageParser<ProtoFootprint>(() => new ProtoFootprint());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<ProtoFootprint> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor {
          get { return global::Sentinal2Utilities.Tile.Proto.ProtoFootprintCollection.Descriptor.NestedTypes[1]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor {
          get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ProtoFootprint() {
          OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ProtoFootprint(ProtoFootprint other) : this() {
          tilePosition_ = other.tilePosition_;
          coordinates_ = other.coordinates_.Clone();
          _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ProtoFootprint Clone() {
          return new ProtoFootprint(this);
        }

        /// <summary>Field number for the "TilePosition" field.</summary>
        public const int TilePositionFieldNumber = 1;
        private string tilePosition_ = "";
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string TilePosition {
          get { return tilePosition_; }
          set {
            tilePosition_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
          }
        }

        /// <summary>Field number for the "coordinates" field.</summary>
        public const int CoordinatesFieldNumber = 2;
        private static readonly pb::FieldCodec<global::Sentinal2Utilities.Tile.Proto.ProtoFootprintCollection.Types.ProtoCoordinate> _repeated_coordinates_codec
            = pb::FieldCodec.ForMessage(18, global::Sentinal2Utilities.Tile.Proto.ProtoFootprintCollection.Types.ProtoCoordinate.Parser);
        private readonly pbc::RepeatedField<global::Sentinal2Utilities.Tile.Proto.ProtoFootprintCollection.Types.ProtoCoordinate> coordinates_ = new pbc::RepeatedField<global::Sentinal2Utilities.Tile.Proto.ProtoFootprintCollection.Types.ProtoCoordinate>();
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public pbc::RepeatedField<global::Sentinal2Utilities.Tile.Proto.ProtoFootprintCollection.Types.ProtoCoordinate> Coordinates {
          get { return coordinates_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
          return Equals(other as ProtoFootprint);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(ProtoFootprint other) {
          if (ReferenceEquals(other, null)) {
            return false;
          }
          if (ReferenceEquals(other, this)) {
            return true;
          }
          if (TilePosition != other.TilePosition) return false;
          if(!coordinates_.Equals(other.coordinates_)) return false;
          return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
          int hash = 1;
          if (TilePosition.Length != 0) hash ^= TilePosition.GetHashCode();
          hash ^= coordinates_.GetHashCode();
          if (_unknownFields != null) {
            hash ^= _unknownFields.GetHashCode();
          }
          return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString() {
          return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output) {
          if (TilePosition.Length != 0) {
            output.WriteRawTag(10);
            output.WriteString(TilePosition);
          }
          coordinates_.WriteTo(output, _repeated_coordinates_codec);
          if (_unknownFields != null) {
            _unknownFields.WriteTo(output);
          }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
          int size = 0;
          if (TilePosition.Length != 0) {
            size += 1 + pb::CodedOutputStream.ComputeStringSize(TilePosition);
          }
          size += coordinates_.CalculateSize(_repeated_coordinates_codec);
          if (_unknownFields != null) {
            size += _unknownFields.CalculateSize();
          }
          return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(ProtoFootprint other) {
          if (other == null) {
            return;
          }
          if (other.TilePosition.Length != 0) {
            TilePosition = other.TilePosition;
          }
          coordinates_.Add(other.coordinates_);
          _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input) {
          uint tag;
          while ((tag = input.ReadTag()) != 0) {
            switch(tag) {
              default:
                _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                break;
              case 10: {
                TilePosition = input.ReadString();
                break;
              }
              case 18: {
                coordinates_.AddEntriesFrom(input, _repeated_coordinates_codec);
                break;
              }
            }
          }
        }

      }

    }
    #endregion

  }

  #endregion

}

#endregion Designer generated code