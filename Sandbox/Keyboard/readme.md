String length up to 20000

| Method                  | Mean        | Error     | StdDev    | Gen0     | Gen1   | Allocated  |
|------------------------ |------------:|----------:|----------:|---------:|-------:|-----------:|
| DimsFromDergachyVersion | 95,726.5 us | 561.36 us | 525.10 us | 666.6667 |      - | 5672.92 KB |
| Kreator22_1             |    367.0 us |   1.51 us |   1.26 us |  65.9180 | 0.4883 |  541.77 KB |
| Kreator22_2             |    670.3 us |   7.38 us |   6.16 us | 191.4063 | 3.9063 | 1564.92 KB |
| MySolutionVersion       |    122.0 us |   1.32 us |   1.10 us |  48.5840 |      - |  397.83 KB |


String length up to 20000

| Method                  | Mean         | Error      | StdDev     | Gen0      | Gen1      | Gen2      | Allocated |
|------------------------ |-------------:|-----------:|-----------:|----------:|----------:|----------:|----------:|
| DimsFromDergachyVersion | 5,840.082 ms | 37.6586 ms | 35.2259 ms | 5000.0000 | 3000.0000 | 3000.0000 |  51.72 MB |
| Kreator22_1             |     3.766 ms |  0.0239 ms |  0.0223 ms |  718.7500 |   78.1250 |         - |   5.75 MB |
| Kreator22_2             |     6.636 ms |  0.1267 ms |  0.1408 ms | 1937.5000 |  382.8125 |         - |  15.49 MB |
| MySolutionVersion       |     1.358 ms |  0.0226 ms |  0.0200 ms |  500.0000 |   37.1094 |         - |      4 MB |


MySolutionVersion turned out to be more efficient, as it traverses the string from the end.
Knowing the nature of the data, we can optimize the algorithm for memory and traverse the string twice. 
To allocate only the necessary memory.