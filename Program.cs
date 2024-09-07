using BenchmarkDotNet.Running;
using BenchMarkJsonSerialization;

BenchmarkRunner.Run(typeof(BenchmarkSerializerMethods).Assembly);
