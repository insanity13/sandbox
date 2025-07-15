using BenchmarkDotNet.Attributes;
using Sandbox.SubArrays;

namespace Benchmark
{
    //[RPlotExporter]
    [MemoryDiagnoser]
    //[SimpleJob] // external-process execution
    //[InProcess] // in-process execution
    public class SubArraysBenchmark
    {
        const int DATA_LENGTH = 10000;
        private static (int From, int To) _arrayLength = (0, 5000);
        private static (int From, int To) _arrayStart = (0, 9999);
        private static readonly Random _random = new(DateTime.Now.Millisecond);
        private IReadOnlyCollection<int[]> _testData; 


        [GlobalSetup]
        public void Setup()
        {
            _testData = Enumerable.Range(0, DATA_LENGTH)
                .Select(x => 
                    Enumerable.Range(0, _random.Next(_arrayLength.From, _arrayLength.To))
                .Select(x => _random.Next(_arrayStart.From, _arrayStart.To)).ToArray()).ToArray();
        }

        [Benchmark]
        public void DimsFromDergachyVersion()
        { 
            foreach (var testItem in _testData)
                DimsFromDergachy.GetMaxSum(testItem);
        }

        [Benchmark]
        public void DenisNP_Version()
        {
            foreach (var testItem in _testData)
                DenisNP.GetMaxSum(testItem);
        }

        [Benchmark]
        public void MySolutionVersion()
        {
            foreach (var testItem in _testData)
                MySolution.GetMaxSum(testItem);
        }
    }
}
