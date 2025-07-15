using BenchmarkDotNet.Attributes;
using Sandbox.Keyboard;

namespace Benchmark
{
    //[RPlotExporter]
    [MemoryDiagnoser]
    //[SimpleJob] // external-process execution
    //[InProcess] // in-process execution
    public class KeyboardBenchmark
    {
        const int DATA_LENGTH = 100;

        /// <summary>
        /// English alphabet in upper and lower case, 
        /// where each letter occurs in multiples of its frequency of use in the English language, and the string is randomly shuffled.
        /// </summary>
        const string CHARS = "TEAoinshrdlcumwfgypbvkjxqzSHDLMORCFGINUWYBPVKJXQZeatEATeatioshrdlcumwfgypbvkjxqz";
        private static readonly Random _random = new(DateTime.Now.Millisecond);
        private IReadOnlyCollection<string> _testData; 


        [GlobalSetup]
        public void Setup()
        {
            _testData = [.. Enumerable.Range(0, DATA_LENGTH).Select(x => GenerateString(_random.Next(5, 2000)))];
        }

        [Benchmark]
        public void DimsFromDergachyVersion()
        { 
            foreach (var testItem in _testData)
                DimsFromDergachy.UnEscapeString(testItem);
        }

        [Benchmark]
        public void Kreator22_1()
        {
            foreach (var testItem in _testData)
                Kreator22.Print1(testItem);
        }

        [Benchmark]
        public void Kreator22_2()
        {
            foreach (var testItem in _testData)
                Kreator22.Print2(testItem);
        }

        [Benchmark]
        public void MySolutionVersion()
        {
            foreach (var testItem in _testData)
                MySolution.GetBrokenKeyboard(testItem);
        }

        private static string GenerateString(int length) => new([.. Enumerable.Repeat(CHARS, length).Select(s => s[_random.Next(s.Length)])]);
    }
}
