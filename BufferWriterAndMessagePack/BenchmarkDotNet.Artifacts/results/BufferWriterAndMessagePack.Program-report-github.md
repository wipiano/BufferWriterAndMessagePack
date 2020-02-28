``` ini

BenchmarkDotNet=v0.12.0, OS=ubuntu 19.10
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.101
  [Host]   : .NET Core 3.1.1 (CoreCLR 4.700.19.60701, CoreFX 4.700.19.60801), X64 RyuJIT
  ShortRun : .NET Core 3.1.1 (CoreCLR 4.700.19.60701, CoreFX 4.700.19.60801), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                     Method |       Mean |       Error |    StdDev | Completed Work Items | Lock Contentions |    Gen 0 |   Gen 1 | Gen 2 |  Allocated |
|--------------------------- |-----------:|------------:|----------:|---------------------:|-----------------:|---------:|--------:|------:|-----------:|
|          SerializeToBuffer | 699.975 us |  64.2239 us | 3.5203 us |               0.0020 |                - |   3.9063 |       - |     - |   28.49 KB |
|           SerializeToArray | 891.722 us | 130.2987 us | 7.1421 us |               0.0020 |                - | 602.5391 | 15.6250 |     - | 3696.75 KB |
| SerializeToBufferLessTimes |   6.247 us |   0.8087 us | 0.0443 us |               0.0000 |                - |   4.6463 |  0.3052 |     - |   28.49 KB |
|  SerializeToArrayLessTimes |   6.593 us |   1.8579 us | 0.1018 us |               0.0000 |                - |   4.5853 |  0.2594 |     - |    28.1 KB |
