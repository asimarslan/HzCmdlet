using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Hazelcast.Client;
using Hazelcast.Config;
using Hazelcast.Core;
using HzCmdlet.model;

namespace HzCmdlet.cmdlets
{
    [Cmdlet(VerbsCommon.Get, "HzMap")]
    [OutputType(typeof(string))]
    public class MapCmdlet : Cmdlet
    {
        [Parameter] public string mapName;
        [Parameter] public string Operation;
        [Parameter] public int Count;
        [Parameter] public int ThreadCount;
        [Parameter] public IHazelcastInstance Client;


        private IMap<ComplexPortableKey, ComplexPortableData> Map;

        private long took;
        private ConcurrentDictionary<ComplexPortableKey, ComplexPortableData> generatedKeyValuePairs;
        private ICollection<ComplexPortableKey> generatedKeys;
        private ComplexPortableKey[] generatedKeysArray;

        protected override void BeginProcessing()
        {
            Map = Client.GetMap<ComplexPortableKey, ComplexPortableData>(mapName);
            generatedKeyValuePairs = GenerateKeyValuePairs();
            generatedKeys = generatedKeyValuePairs.Keys;
            generatedKeysArray = generatedKeyValuePairs.Keys.ToArray();
        }

        protected override void ProcessRecord()
        {
            var start = Stopwatch.StartNew();
            switch (Operation)
            {
                case "CLEAN":
                case "CLEAR":
                    Map.Clear();
                    break;
                case "FILL":
                    FillMap();
                    break;
                case "SIZE":
                    WriteObject(Map.Size());
                    break;
                case "QUERY":
                    Query();
                    break;
                case "GETALL":
                    GetAll();
                    break;
                case "GETALL-WITH-THREADS":
                    GetAllWithThreads();
                    break;
                case "TEST":
                    WriteObject("TEST");
                    break;
                default:
                    throw new ArgumentException("Unknown operation");
            }

            took = start.ElapsedMilliseconds;
        }

        private void Query()
        {
            Map.Values(Predicates.True());
        }

        private void FillMap()
        {
            Map.PutAll(generatedKeyValuePairs);
        }

        private void GetAll()
        {
            Map.GetAll(generatedKeys);
        }

        private void GetAllWithThreads()
        {
            var keys = generatedKeysArray;
            var results = new ConcurrentQueue<ComplexPortableData>();
            var mx = keys.Length / ThreadCount;
            var cde = new CountdownEvent(ThreadCount);
            var sw = new Stopwatch();
            sw.Start();

            for (var i = 0; i < ThreadCount; i++)
            {
                var t = new Thread(o =>
                {
                    var k = (int) o;
                    for (int j = 0; j < mx; j++)
                    {
                        results.Enqueue(Map.Get(keys[k * mx + j]));
                    }

                    cde.Signal();
                });
                t.Start(i);
            }

            cde.Wait();
            sw.Stop();
        }

        private ConcurrentDictionary<ComplexPortableKey, ComplexPortableData> GenerateKeyValuePairs()
        {
            var pairs = new ConcurrentDictionary<ComplexPortableKey, ComplexPortableData>();
            for (int i = 0; i < Count; i++)
            {
                var key = DataFactory.CreateComplexPortableKey(i);
                var value = DataFactory.CreateComplexPortableData(i, 1000);
                pairs.TryAdd(key, value);
            }
            return pairs;
        }


        protected override void EndProcessing()
        {
            WriteObject(took);
        }
    }
}