using BenchmarkDotNet.Attributes;
using CommunityToolkit.HighPerformance;
using Pipelines.Sockets.Unofficial;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace MemoryStreamBenchmark;

public class SystemTextJsonBenchmark
{
    private IntPtr _pointer;
    private int _length;

    [Params(1, 10, 1000)]
    public int Kilobytes { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        var items = new List<Item>();

        for (int i = 0; i < 15 * Kilobytes; ++i)
        {
            items.Add(new Item());
        }

        var json = JsonSerializer.Serialize(items);
        var bytes = Encoding.UTF8.GetBytes(json);
        var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);

        _pointer = handle.AddrOfPinnedObject();
        _length = bytes.Length;
    }

    [Benchmark]
    public unsafe void CommunityToolkit()
    {
        var memory = new UnmanagedMemoryManager<byte>((byte*)_pointer, _length);

        using var stream = memory.AsStream();
        JsonSerializer.Deserialize<List<Item>>(stream);
    }

    [Benchmark]
    public void MemoryStream()
    {
        var buffer = new byte[_length];
        Marshal.Copy(_pointer, buffer, 0, _length);

        using var stream = new MemoryStream(buffer);
        JsonSerializer.Deserialize<List<Item>>(stream);
    }

    [Benchmark]
    public unsafe void UnmanagedMemoryStream()
    {
        using var stream = new UnmanagedMemoryStream((byte*)_pointer, _length);
        JsonSerializer.Deserialize<List<Item>>(stream);
    }

    [Benchmark]
    public unsafe void ReadOnlySpan()
    {
        var span = new ReadOnlySpan<byte>((byte*)_pointer, _length);
        JsonSerializer.Deserialize<List<Item>>(span);
    }
}
