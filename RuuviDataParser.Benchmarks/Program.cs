// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using RuuviDataParser.Benchmarks;

Console.WriteLine("Hello, World!");


var summary = BenchmarkRunner.Run<TemperatureParserBenchmarks>();