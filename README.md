# Memory stream benchmark

Benchmark of various memory stream implementations:

- [CommunityToolkit.HighPerformance](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/high-performance/introduction)
- [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream)
- [UnmanagedMemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.unmanagedmemorystream)

```
BenchmarkDotNet v0.13.7, macOS Catalina 10.15.6 (19G2021) [Darwin 19.6.0]
Intel Core i7-5557U CPU 3.10GHz (Broadwell), 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.100-preview.3.23178.7
  [Host]     : .NET 8.0.0 (8.0.23.17408), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.17408), X64 RyuJIT AVX2
```
|                Method | ChunkSize |         Mean |     Error |    StdDev |   Gen0 | Allocated |
|---------------------- |---------- |-------------:|----------:|----------:|-------:|----------:|
|      **CommunityToolkit** |         **1** |  **75,696.1 ns** | **355.88 ns** | **297.18 ns** |      **-** |      **88 B** |
|          MemoryStream |         1 |  38,021.0 ns | 109.79 ns |  85.71 ns | 3.9063 |    8280 B |
| UnmanagedMemoryStream |         1 | 245,536.2 ns | 306.69 ns | 239.45 ns |      - |      88 B |
|      **CommunityToolkit** |         **8** |   **9,578.5 ns** |  **12.47 ns** |  **10.41 ns** | **0.0305** |      **88 B** |
|          MemoryStream |         8 |  12,169.5 ns |  53.77 ns |  47.67 ns | 3.9520 |    8280 B |
| UnmanagedMemoryStream |         8 |  30,870.3 ns |  23.07 ns |  19.26 ns |      - |      88 B |
|      **CommunityToolkit** |        **64** |   **1,327.2 ns** |   **3.46 ns** |   **2.89 ns** | **0.0420** |      **88 B** |
|          MemoryStream |        64 |   2,577.7 ns |   6.68 ns |   5.58 ns | 3.9520 |    8280 B |
| UnmanagedMemoryStream |        64 |   3,988.9 ns |   5.17 ns |   4.32 ns | 0.0381 |      88 B |
|      **CommunityToolkit** |       **128** |     **755.0 ns** |   **0.96 ns** |   **0.75 ns** | **0.0420** |      **88 B** |
|          MemoryStream |       128 |   1,856.3 ns |   5.22 ns |   4.08 ns | 3.9520 |    8280 B |
| UnmanagedMemoryStream |       128 |   2,072.7 ns |   2.87 ns |   2.55 ns | 0.0420 |      88 B |
|      **CommunityToolkit** |      **1024** |     **256.0 ns** |   **0.54 ns** |   **0.48 ns** | **0.0420** |      **88 B** |
|          MemoryStream |      1024 |   1,244.7 ns |  12.11 ns |  10.73 ns | 3.9520 |    8280 B |
| UnmanagedMemoryStream |      1024 |     441.0 ns |   2.12 ns |   1.98 ns | 0.0420 |      88 B |
|      **CommunityToolkit** |      **4096** |     **239.6 ns** |   **0.59 ns** |   **0.52 ns** | **0.0420** |      **88 B** |
|          MemoryStream |      4096 |   1,151.3 ns |  19.35 ns |  23.04 ns | 3.9520 |    8280 B |
| UnmanagedMemoryStream |      4096 |     262.8 ns |   0.59 ns |   0.46 ns | 0.0420 |      88 B |
