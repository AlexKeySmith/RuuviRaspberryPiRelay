using BenchmarkDotNet.Attributes;
using RuuviRaspberryPiRelay.RuuviDataParser;

namespace RuuviDataParser.Benchmarks
{
    [MemoryDiagnoser]
    public class TemperatureParserBenchmarks 
    {
        
        private readonly byte[] testData =  Convert.FromHexString("0512FC5394C37C0004FFFC040CAC364200CDCBB8334C884F");

        
        public TemperatureParserBenchmarks()
        {
            
        }


        [Benchmark]
        
        public void BenchmarkLinq()
        {
            Parser.GetTemperature(testData);

        }


        [Benchmark]
        public void BenchmarkSpread()
        {
            Parser.GetTemperatureSpread(testData);

        }

        [Benchmark]
        public void BenchmarkSpan()
        {
            Parser.GetTemperatureSpan(testData);

        }
        
    }
}