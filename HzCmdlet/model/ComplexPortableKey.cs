using Hazelcast.IO.Serialization;

namespace HzCmdlet.model
{
    public class ComplexPortableKey : IPortable
    {
        public const int ClassId = 1;
        public long Id;
        public string Text0;
        public string Text1;
        public string Text2;
        public string Text3;
        public string Text4;

        public ComplexPortableKey(){}
        
        public ComplexPortableKey(long id, string text) : this(id, text, text, text, text, text){}
        
        public ComplexPortableKey(long id, string text0, string text1, string text2, string text3, string text4)
        {
            Id = id;
            Text0 = text0;
            Text1 = text1;
            Text2 = text2;
            Text3 = text3;
            Text4 = text4;
        }

        public int GetClassId()
        {
            return ClassId;
        }

        public int GetFactoryId()
        {
            return PortableFactory.FactoryId;
        }

        public void ReadPortable(IPortableReader reader)
        {
            Id = reader.ReadLong("Id");
            Text0 = reader.ReadUTF("Text0");
            Text1 = reader.ReadUTF("Text1");
            Text2 = reader.ReadUTF("Text2");
            Text3 = reader.ReadUTF("Text3");
            Text4 = reader.ReadUTF("Text4");
        }

        public void WritePortable(IPortableWriter writer)
        {
            writer.WriteLong("Id", Id);
            writer.WriteUTF("Text0", Text0);
            writer.WriteUTF("Text1", Text1);
            writer.WriteUTF("Text2", Text2);
            writer.WriteUTF("Text3", Text3);
            writer.WriteUTF("Text4", Text4);
        }
    }
}