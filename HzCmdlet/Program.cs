using System;
using Hazelcast.Client;
using Hazelcast.Config;
using HzCmdlet.model;

namespace HzCmdlet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cfg = new ClientConfig();
            cfg.GetNetworkConfig().AddAddress("127.0.0.1:5701");
//                cfg.GetSerializationConfig().AddPortableFactoryClass(PortableFactory.FactoryId, typeof(PortableFactory));

            var client = HazelcastClient.NewHazelcastClient(cfg);
            var map=client.GetMap<ComplexPortableKey, ComplexPortableData>("default");
            var key = DataFactory.CreateComplexPortableKey(1);
            map.Put(key, DataFactory.CreateComplexPortableData(1, 1));
            var val = map.Get(key);
            Console.WriteLine(val);

        }
    }
}