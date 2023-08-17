# Memory stream benchmark

Benchmark of various memory stream implementations:

- [CommunityToolkit.HighPerformance](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/high-performance/introduction)
- [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream)
- [UnmanagedMemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.unmanagedmemorystream)

## Direct comparison

```
BenchmarkDotNet v0.13.7, macOS Catalina 10.15.6 (19G2021) [Darwin 19.6.0]
Intel Core i7-5557U CPU 3.10GHz (Broadwell), 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.100-preview.3.23178.7
  [Host]     : .NET 8.0.0 (8.0.23.17408), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.17408), X64 RyuJIT AVX2
```
|                Method | ChunkSize |         Mean |     Error |    StdDev |
|---------------------- |---------- |-------------:|----------:|----------:|
|      **CommunityToolkit** |         **1** |  **75,549.5 ns** | **137.54 ns** | **114.85 ns** |
|          MemoryStream |         1 |  37,948.5 ns | 158.39 ns | 132.27 ns |
| UnmanagedMemoryStream |         1 | 245,701.0 ns | 303.06 ns | 236.61 ns |
|      **CommunityToolkit** |         **8** |   **9,604.7 ns** |  **21.77 ns** |  **19.30 ns** |
|          MemoryStream |         8 |  12,151.4 ns |  46.19 ns |  38.57 ns |
| UnmanagedMemoryStream |         8 |  30,941.0 ns |  46.52 ns |  38.84 ns |
|      **CommunityToolkit** |        **64** |   **1,327.7 ns** |   **1.85 ns** |   **1.55 ns** |
|          MemoryStream |        64 |   2,560.2 ns |   8.21 ns |   6.86 ns |
| UnmanagedMemoryStream |        64 |   3,989.6 ns |   5.03 ns |   3.93 ns |
|      **CommunityToolkit** |       **128** |     **754.2 ns** |   **2.55 ns** |   **2.13 ns** |
|          MemoryStream |       128 |   1,901.4 ns |   6.30 ns |   5.26 ns |
| UnmanagedMemoryStream |       128 |   2,196.0 ns |   3.42 ns |   2.86 ns |
|      **CommunityToolkit** |      **1024** |     **218.7 ns** |   **0.67 ns** |   **0.56 ns** |
|          MemoryStream |      1024 |   1,208.8 ns |   3.06 ns |   2.55 ns |
| UnmanagedMemoryStream |      1024 |     377.2 ns |   0.48 ns |   0.38 ns |
|      **CommunityToolkit** |      **4096** |     **190.4 ns** |   **0.59 ns** |   **0.49 ns** |
|          MemoryStream |      4096 |   1,154.5 ns |   2.64 ns |   2.34 ns |
| UnmanagedMemoryStream |      4096 |     241.7 ns |   0.92 ns |   0.77 ns |

## YamlDotNet deserialization
