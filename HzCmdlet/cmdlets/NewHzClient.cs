using System.Management.Automation;
using Hazelcast.Client;
using Hazelcast.Config;
using Hazelcast.Core;
using HzCmdlet.model;

namespace HzCmdlet.cmdlets
{
    [Cmdlet(VerbsCommon.New, "HazelcastClient")]
    [OutputType(typeof(IHazelcastInstance))]
    public class NewHzClient : Cmdlet
    {
        [Parameter] public string ConfigXml;

        [Parameter] public string Address;

        protected override void ProcessRecord()
        {
            IHazelcastInstance client;
            if (ConfigXml != null)
            {
                client = HazelcastClient.NewHazelcastClient(ConfigXml);
            }
            else
            {
                var cfg = new ClientConfig();
                cfg.GetNetworkConfig().AddAddress(Address);
                cfg.GetSerializationConfig().AddPortableFactoryClass(PortableFactory.FactoryId, typeof(PortableFactory));

                client = HazelcastClient.NewHazelcastClient(cfg);
            }

            WriteObject(client);
        }
    }
}