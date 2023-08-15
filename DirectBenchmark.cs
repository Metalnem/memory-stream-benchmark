using BenchmarkDotNet.Attributes;
using CommunityToolkit.HighPerformance;
using Pipelines.Sockets.Unofficial;
using System.Runtime.InteropServices;

namespace MemoryStreamBenchmark;

public class DirectBenchmark
{
    private const int Size = 8192;

    private static readonly IntPtr _source = Marshal.AllocHGlobal(Size);
    private static readonly byte[] _destination = new byte[Size];

    [Params(1, 8, 64, 128, 1024, 4096)]
    public int ChunkSize { get; set; }

    [Benchmark]
    public unsafe void CommunityToolkit()
    {
        var pointer = (byte*)_source.ToPointer();
        var memory = new UnmanagedMemoryManager<byte>(pointer, Size);

        using var stream = memory.AsStream();
        Consume(stream);
    }

    [Benchmark]
    public void MemoryStream()
    {
        var buffer = new byte[Size];
        Marshal.Copy(_source, buffer, 0, Size);

        using var stream = new MemoryStream(buffer);
        Consume(stream);
    }

    [Benchmark]
    public unsafe void UnmanagedMemoryStream()
    {
        using var stream = new UnmanagedMemoryStream((byte*)_source.ToPointer(), Size);
        Consume(stream);
    }

    private void Consume(Stream stream)
    {
        while (stream.Read(_destination, 0, ChunkSize) > 0) { }
    }
}
