using System.Text.Json.Serialization;

namespace BenchMarkJsonSerialization;

[JsonSerializable(typeof(Person[]))]
internal partial class PersonCustomContext : JsonSerializerContext { }
