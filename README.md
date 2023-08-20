# Memory stream benchmark

Benchmark of various memory stream implementations:

- [CommunityToolkit.HighPerformance](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/high-performance/introduction)
- [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream)
- [UnmanagedMemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.unmanagedmemorystream)

## Direct comparison

```
BenchmarkDotNet v0.13.7, Windows 11 (10.0.22621.2134/22H2/2022Update/SunValley2) (Hyper-V)
AMD EPYC 7452, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 8.0.0 (8.0.23.37506), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.37506), X64 RyuJIT AVX2
```
|                Method | ChunkSize |         Mean |     Error |    StdDev |
|---------------------- |---------- |-------------:|----------:|----------:|
|      **CommunityToolkit** |         **1** |  **57,726.4 ns** |  **75.44 ns** |  **66.88 ns** |
|          MemoryStream |         1 |  21,367.6 ns | 200.65 ns | 187.68 ns |
| UnmanagedMemoryStream |         1 | 162,825.7 ns | 265.54 ns | 248.39 ns |
|      **CommunityToolkit** |         **8** |   **6,940.4 ns** |  **14.88 ns** |  **13.92 ns** |
|          MemoryStream |         8 |   7,255.4 ns |  53.83 ns |  42.03 ns |
| UnmanagedMemoryStream |         8 |  19,917.2 ns |  28.49 ns |  23.79 ns |
|      **CommunityToolkit** |        **64** |     **962.5 ns** |   **2.86 ns** |   **2.67 ns** |
|          MemoryStream |        64 |   1,723.4 ns |  15.24 ns |  13.51 ns |
| UnmanagedMemoryStream |        64 |   2,389.1 ns |   6.54 ns |   6.12 ns |
|      **CommunityToolkit** |       **128** |     **580.4 ns** |   **2.40 ns** |   **2.25 ns** |
|          MemoryStream |       128 |   1,210.5 ns |  14.18 ns |  12.57 ns |
| UnmanagedMemoryStream |       128 |   1,379.1 ns |  13.76 ns |  12.87 ns |
|      **CommunityToolkit** |      **1024** |     **198.1 ns** |   **0.69 ns** |   **0.61 ns** |
|          MemoryStream |      1024 |     625.2 ns |   8.57 ns |   7.60 ns |
| UnmanagedMemoryStream |      1024 |     308.1 ns |   0.80 ns |   0.74 ns |
|      **CommunityToolkit** |      **4096** |     **136.6 ns** |   **0.86 ns** |   **0.81 ns** |
|          MemoryStream |      4096 |     545.9 ns |   7.66 ns |   6.40 ns |
| UnmanagedMemoryStream |      4096 |     152.6 ns |   0.44 ns |   0.41 ns |

## System.Text.Json deserialization

```
BenchmarkDotNet v0.13.7, Windows 11 (10.0.22621.2134/22H2/2022Update/SunValley2) (Hyper-V)
AMD EPYC 7452, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.100-preview.7.23376.3
  [Host]     : .NET 8.0.0 (8.0.23.37506), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.37506), X64 RyuJIT AVX2
```
|                Method | Kilobytes |         Mean |     Error |    StdDev |
|---------------------- |---------- |-------------:|----------:|----------:|
|      **CommunityToolkit** |         **1** |     **13.06 μs** |  **0.043 μs** |  **0.036 μs** |
|          MemoryStream |         1 |     12.95 μs |  0.063 μs |  0.058 μs |
| UnmanagedMemoryStream |         1 |     12.92 μs |  0.038 μs |  0.036 μs |
|          ReadOnlySpan |         1 |     12.54 μs |  0.049 μs |  0.046 μs |
|      **CommunityToolkit** |        **10** |    **125.46 μs** |  **0.466 μs** |  **0.414 μs** |
|          MemoryStream |        10 |    124.52 μs |  0.889 μs |  0.832 μs |
| UnmanagedMemoryStream |        10 |    122.89 μs |  0.463 μs |  0.410 μs |
|          ReadOnlySpan |        10 |    122.24 μs |  0.354 μs |  0.331 μs |
|      **CommunityToolkit** |      **1000** | **16,402.36 μs** | **61.176 μs** | **51.085 μs** |
|          MemoryStream |      1000 | 14,592.26 μs | 27.642 μs | 25.856 μs |
| UnmanagedMemoryStream |      1000 | 15,451.47 μs | 66.320 μs | 62.036 μs |
|          ReadOnlySpan |      1000 | 14,497.31 μs | 55.765 μs | 49.434 μs |
