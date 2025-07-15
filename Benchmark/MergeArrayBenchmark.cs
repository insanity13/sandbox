using BenchmarkDotNet.Attributes;
using Sandbox.MergeArrays;

namespace Benchmark
{
    //[RPlotExporter]
    [MemoryDiagnoser]
    //[SimpleJob] // external-process execution
    //[InProcess] // in-process execution
    public class MergeArrayBenchmark
    {
        const int DATA_LENGTH = 1000;
        private static readonly Random _random = new(DateTime.Now.Millisecond);
        private IReadOnlyCollection<(int[] m1, int[] m2)> _testData;

        private static (int From, int To) _arrayLength = (0, 5000);
        private static (int From, int To) _arrayStart = (0, 9999);


        [GlobalSetup]
        public void Setup()
        {
            _testData = Enumerable.Range(0, DATA_LENGTH)
                          .Select(x => (
                            Enumerable.Range(_random.Next(_arrayStart.From, _arrayStart.To), _random.Next(_arrayLength.From, _arrayLength.To)).ToArray(),
                            Enumerable.Range(_random.Next(_arrayStart.From, _arrayStart.To), _random.Next(_arrayLength.From, _arrayLength.To)).ToArray()))
                          .ToArray();
        }

        [Benchmark]
        public void DimsFromDergachyVersion()
        { 
            foreach (var testItem in _testData)
                DimsFromDergachy.Merge(testItem.m1, testItem.m2).ToArray();
        }

        [Benchmark]
        public void Kreator22Version()
        {
            foreach (var testItem in _testData)
                Kreator22.Merge(testItem.m1, testItem.m2).ToArray();
        }

        [Benchmark]
        public void MySolutionVersion()
        {
            foreach (var testItem in _testData)
                MySolution.Union(testItem.m1, testItem.m2).ToArray();
        }
    }
}
