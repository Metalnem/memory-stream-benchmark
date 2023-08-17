using BenchmarkDotNet.Attributes;
using CommunityToolkit.HighPerformance;
using Pipelines.Sockets.Unofficial;
using System.Runtime.InteropServices;
using YamlDotNet.RepresentationModel;

namespace MemoryStreamBenchmark;

public class YamlDotNetBenchmark
{
    private IntPtr _pointer;
    private int _length;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var yaml = File.ReadAllBytes("Invoice.yml");
        var handle = GCHandle.Alloc(yaml, GCHandleType.Pinned);

        _pointer = handle.AddrOfPinnedObject();
        _length = yaml.Length;
    }

    [Benchmark]
    public unsafe void CommunityToolkit()
    {
        var memory = new UnmanagedMemoryManager<byte>((byte*)_pointer, _length);

        Consume(memory.AsStream());
    }

    [Benchmark]
    public void MemoryStream()
    {
        var buffer = new byte[_length];
        Marshal.Copy(_pointer, buffer, 0, _length);

        Consume(new MemoryStream(buffer));
    }

    [Benchmark]
    public unsafe void UnmanagedMemoryStream()
    {
        Consume(new UnmanagedMemoryStream((byte*)_pointer, _length));
    }

    private void Consume(Stream stream)
    {
        using var reader = new StreamReader(stream);
        new YamlStream().Load(reader);
    }
}
