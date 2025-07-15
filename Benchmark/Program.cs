using Benchmark;
using BenchmarkDotNet.Running;

//var keyboardSummary = BenchmarkRunner.Run<KeyboardBenchmark>();
var mergeArraySummary = BenchmarkRunner.Run<MergeArrayBenchmark>();
//var subArraySummary = BenchmarkRunner.Run<SubArraysBenchmark>(); 