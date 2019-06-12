using Hazelcast.IO.Serialization;

namespace HzCmdlet.model
{
    public class PortableFactory : IPortableFactory
    {
        public const int FactoryId = 456;
        
        public IPortable Create(int classId)
        {
            switch (classId)
            {
                case ComplexPortableKey.ClassId:
                    return new ComplexPortableKey();
                case ComplexPortableData.ClassId:
                    return new ComplexPortableData();
                default:
                    return null;
            }
        }

    }
}