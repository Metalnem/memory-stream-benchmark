# Memory stream benchmark

Benchmark of various memory stream implementations:

- [CommunityToolkit.HighPerformance](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/high-performance/introduction)
- [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream)
- [UnmanagedMemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.unmanagedmemorystream)

## Direct comparison

```
BenchmarkDotNet v0.13.7, Ubuntu 20.04.6 LTS (Focal Fossa)
AMD EPYC 7763, 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.400
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
```
|                Method | ChunkSize |        Mean |    Error |   StdDev |
|---------------------- |---------- |------------:|---------:|---------:|
|      **CommunityToolkit** |         **1** | **75,977.3 ns** |  **6.91 ns** |  **6.13 ns** |
|          MemoryStream |         1 | 36,271.9 ns | 49.85 ns | 41.62 ns |
| UnmanagedMemoryStream |         1 | 86,375.8 ns | 29.74 ns | 26.36 ns |
|      **CommunityToolkit** |         **8** |  **9,242.3 ns** |  **1.20 ns** |  **0.94 ns** |
|          MemoryStream |         8 | 10,512.8 ns | 11.58 ns | 10.26 ns |
| UnmanagedMemoryStream |         8 | 10,492.3 ns |  1.97 ns |  1.74 ns |
|      **CommunityToolkit** |        **64** |  **1,255.2 ns** |  **0.90 ns** |  **0.79 ns** |
|          MemoryStream |        64 |  1,940.1 ns |  7.35 ns |  6.88 ns |
| UnmanagedMemoryStream |        64 |  1,380.4 ns |  0.20 ns |  0.17 ns |
|      **CommunityToolkit** |       **128** |    **703.2 ns** |  **0.46 ns** |  **0.43 ns** |
|          MemoryStream |       128 |  1,342.3 ns |  4.11 ns |  3.64 ns |
| UnmanagedMemoryStream |       128 |    746.8 ns |  0.17 ns |  0.14 ns |
|      **CommunityToolkit** |      **1024** |    **216.5 ns** |  **0.52 ns** |  **0.48 ns** |
|          MemoryStream |      1024 |    857.4 ns |  2.04 ns |  1.59 ns |
| UnmanagedMemoryStream |      1024 |    223.0 ns |  0.17 ns |  0.14 ns |
|      **CommunityToolkit** |      **4096** |    **167.1 ns** |  **0.10 ns** |  **0.09 ns** |
|          MemoryStream |      4096 |    802.1 ns |  4.81 ns |  4.50 ns |
| UnmanagedMemoryStream |      4096 |    139.4 ns |  0.25 ns |  0.23 ns |

## System.Text.Json deserialization

```
BenchmarkDotNet v0.13.7, macOS Catalina 10.15.6 (19G2021) [Darwin 19.6.0]
Intel Core i7-5557U CPU 3.10GHz (Broadwell), 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.100-preview.3.23178.7
  [Host]     : .NET 8.0.0 (8.0.23.17408), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.17408), X64 RyuJIT AVX2
```
|                Method | Kilobytes |         Mean |      Error |     StdDev |
|---------------------- |---------- |-------------:|-----------:|-----------:|
|      **CommunityToolkit** |         **1** |     **30.18 μs** |   **0.090 μs** |   **0.070 μs** |
|          MemoryStream |         1 |     29.72 μs |   0.111 μs |   0.092 μs |
| UnmanagedMemoryStream |         1 |     29.28 μs |   0.083 μs |   0.069 μs |
|          ReadOnlySpan |         1 |     29.00 μs |   0.057 μs |   0.051 μs |
|      **CommunityToolkit** |        **10** |    **290.47 μs** |   **0.708 μs** |   **0.591 μs** |
|          MemoryStream |        10 |    293.57 μs |   1.006 μs |   0.840 μs |
| UnmanagedMemoryStream |        10 |    289.62 μs |   0.646 μs |   0.539 μs |
|          ReadOnlySpan |        10 |    286.21 μs |   0.797 μs |   0.666 μs |
|      **CommunityToolkit** |      **1000** | **32,434.78 μs** | **208.595 μs** | **174.186 μs** |
|          MemoryStream |      1000 | 32,277.46 μs | 519.029 μs | 485.500 μs |
| UnmanagedMemoryStream |      1000 | 32,245.63 μs | 274.492 μs | 243.330 μs |
|          ReadOnlySpan |      1000 | 31,148.95 μs | 230.826 μs | 215.915 μs |
