using System;
using System.Buffers;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using MessagePack;

namespace BufferWriterAndMessagePack
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ManualConfig();
            config.Add(Job.ShortRun);
            config.Add(MarkdownExporter.GitHub);
            config.Add(MemoryDiagnoser.Default);
            config.Add(ConsoleLogger.Default);
            config.Add(DefaultColumnProviders.Instance);
            config.Add(ThreadingDiagnoser.Default);
            BenchmarkRunner.Run<Program>(config);
        }

        [Benchmark]
        public void SerializeToBuffer()
        {
            var buffer = new ArrayBufferWriter<byte>();
            var obj = new SampleObject();
            for (var i = 0; i < 1000; i++)
            {
                buffer.Clear();
                MessagePackSerializer.Serialize(buffer, obj);
            }
        }

        [Benchmark]
        public void SerializeToArray()
        {
            var obj = new SampleObject();
            for (var i = 0; i < 1000; i++)
            {
                MessagePackSerializer.Serialize(obj);
            }
        }
        
        [Benchmark]
        public void SerializeToBufferLessTimes()
        {
            var buffer = new ArrayBufferWriter<byte>();
            var obj = new SampleObject();
            for (var i = 0; i < 3; i++)
            {
                buffer.Clear();
                MessagePackSerializer.Serialize(buffer, obj);
            }
        }

        [Benchmark]
        public void SerializeToArrayLessTimes()
        {
            var obj = new SampleObject();
            for (var i = 0; i < 3; i++)
            {
                MessagePackSerializer.Serialize(obj);
            }
        }

        [MessagePackObject(true)]
        public sealed class SampleObject
        {
            public string Name { get; set; } = string.Join("_", Enumerable.Repeat(Guid.NewGuid().ToString(), 100));
            public int Hoge { get; set; } = 100;
            public double Hoge2 { get; set; } = 0.248584;
            public DateTime DateTime { get; set; } = DateTime.Today;
        }
    }
}