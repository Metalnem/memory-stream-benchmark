using BenchmarkDotNet.Running;

namespace MemoryStreamBenchmark;

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<SystemTextJsonBenchmark>();
    }
}
