Data length 100, array size up to 5000

| Method                  | Mean      | Error     | StdDev    | Allocated |
|------------------------ |----------:|----------:|----------:|----------:|
| DimsFromDergachyVersion | 13.838 ms | 0.0287 ms | 0.0268 ms |   84032 B |
| DenisNP_Version         | 40.036 ms | 0.4174 ms | 0.3700 ms |   96032 B |
| MySolutionVersion       |  4.447 ms | 0.0335 ms | 0.0313 ms |      32 B |

Data length 1000, array size up to 500

| Method                  | Mean       | Error    | StdDev   | Gen0    | Allocated |
|------------------------ |-----------:|---------:|---------:|--------:|----------:|
| DimsFromDergachyVersion | 2,808.4 us |  5.08 us |  4.50 us | 19.5313 |  167968 B |
| DenisNP_Version         | 7,958.2 us | 42.16 us | 39.44 us | 15.6250 |  191808 B |
| MySolutionVersion       |   898.1 us | 10.85 us | 10.15 us |       - |      32 B |


Data length 5000, array size up to 1000

| Method                  | Mean      | Error     | StdDev    | Gen0    | Allocated |
|------------------------ |----------:|----------:|----------:|--------:|----------:|
| DimsFromDergachyVersion | 27.065 ms | 0.0228 ms | 0.0202 ms | 93.7500 |  839936 B |
| DenisNP_Version         | 79.534 ms | 0.3393 ms | 0.3174 ms |       - |  959584 B |
| MySolutionVersion       |  8.913 ms | 0.0088 ms | 0.0082 ms |       - |      32 B |


Data length 10000, array size up to 5000

| Method                  | Mean      | Error    | StdDev   | Allocated |
|------------------------ |----------:|---------:|---------:|----------:|
| DimsFromDergachyVersion | 270.15 ms | 0.192 ms | 0.160 ms | 1679904 B |
| DenisNP_Version         | 776.53 ms | 1.303 ms | 1.155 ms | 1919808 B |
| MySolutionVersion       |  88.59 ms | 0.225 ms | 0.199 ms |      32 B |