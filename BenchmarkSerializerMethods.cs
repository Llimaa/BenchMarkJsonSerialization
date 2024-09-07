using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace BenchMarkJsonSerialization;

[MemoryDiagnoser, RankColumn]
public class BenchmarkSerializerMethods
{
    private MemoryStream _memoryStream = default!;
    private Utf8JsonWriter _jsonWriter =default!;
    private IEnumerable<Person> _people = default!;

    [GlobalSetup]
    public void Setup()
    {
        var writerOptions = new JsonWriterOptions { Indented = false };
        _memoryStream = new MemoryStream();
        _jsonWriter = new Utf8JsonWriter(_memoryStream, writerOptions);
        _people = PeopleDataFake.GetPeople();
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        _memoryStream.Dispose();
        _jsonWriter.Dispose();
    }

    [Benchmark]
    public void SerializerDefault()
    {
        JsonSerializer.Serialize(_people);
    }

    [Benchmark]
    public void SerializerCustom()
    {
        JsonSerializer.Serialize(_people, PersonCustomContext.Default.PersonArray);
    }

    [Benchmark]
    public void SerializerCustomWithUtf8JsonWriter()
    {
        JsonSerializer.Serialize(_jsonWriter, _people, PersonCustomContext.Default.PersonArray);
        Encoding.UTF8.GetString(_memoryStream.GetBuffer(), 0, (int)_memoryStream.Length);

        _memoryStream.SetLength(0);
        _jsonWriter.Reset();
    }
}
