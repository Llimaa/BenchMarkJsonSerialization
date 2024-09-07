# BenchMarkJsonSerialization
Benchmark para avaliar o desempenho na serialização de JSON em .NET.


### Tecnologias utilizadas :hammer_and_wrench: 

- ``C#``
- ``.NET``
- ``Benchmark``


### Benchmark :test_tube:
Comparação entre a serialização convencional, serialização com Source Generation e serialização com Source Generation + Utf8JsonWriter.
Para esse benchMark vamos gerar uma massa de dados de 1M.

| Method                             | Mean       | Error    | StdDev   | Rank | Gen0       | Gen1      | Gen2      | Allocated |
|----------------------------------- |-----------:|---------:|---------:|-----:|-----------:|----------:|----------:|----------:|
| SerializerDefault                  | 1,361.0 ms | 14.35 ms | 11.98 ms |    3 | 57000.0000 | 3000.0000 | 2000.0000 |   2.07 GB |
| SerializerCustom                   | 1,118.6 ms | 22.04 ms | 32.30 ms |    2 | 57000.0000 | 3000.0000 | 2000.0000 |   2.07 GB |
| SerializerCustomWithUtf8JsonWriter |   926.6 ms |  4.60 ms |  3.59 ms |    1 | 55000.0000 |         - |         - |   1.07 GB |


### Executar Benchmark :hammer_and_wrench: 
Para executar o Benchmark localmente em sua máquina, clone o repositório do projeto e execute o seguinte comando:
```bash
  dotnet run --configuration Release 
```


### Documentações de apoio :book:
[Reflection versus source generation in System.Text.Json](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/reflection-vs-source-generation?pivots=dotnet-8-0)

[JsonSerializerContext Classe](https://learn.microsoft.com/pt-br/dotnet/api/system.text.json.serialization.jsonserializercontext?view=net-8.0)
