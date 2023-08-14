using BenchmarkDotNet.Attributes;
using CommunityToolkit.HighPerformance;

namespace MemoryStreamBenchmark;

[MemoryDiagnoser]
public class DirectBenchmark
{
    private const int Size = 8192;

    private static readonly byte[] _source = new byte[Size];
    private static readonly byte[] _destination = new byte[Size];

    [Params(1, 8, 64, 128, 1024, 4096)]
    public int ChunkSize { get; set; }

    [Benchmark]
    public void CommunityToolkit()
    {
        using var stream = _source.AsMemory().AsStream();
        Consume(stream);
    }

    [Benchmark]
    public void MemoryStream()
    {
        using var stream = new MemoryStream(_source.ToArray());
        Consume(stream);
    }

    [Benchmark]
    public unsafe void UnmanagedMemoryStream()
    {
        fixed (byte* pointer = _source)
        {
            using var stream = new UnmanagedMemoryStream(pointer, _source.Length);
            Consume(stream);
        }
    }

    private void Consume(Stream stream)
    {
        while (stream.Read(_destination, 0, ChunkSize) > 0) { }
    }
}
