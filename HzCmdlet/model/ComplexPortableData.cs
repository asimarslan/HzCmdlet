using Hazelcast.IO.Serialization;

namespace HzCmdlet.model
{
    public class ComplexPortableData : IPortable
    {
        public const int ClassId = 2;

        public long Id;
        public string Text0;
        public string Text1;
        public string Text2;
        public string Text3;
        public string Text4;
        public string Text5;
        public string Text6;
        public string Text7;
        public string Text8;
        public string Text9;
        

        public bool Boolean0;
        public bool Boolean1;
        public bool Boolean2;
        public bool Boolean3;
        public bool Boolean4;
        
        public long TimeStamp0;
        public long TimeStamp1;
        public long TimeStamp2;
        public long TimeStamp3;
        public long TimeStamp4;

        public string[] TextArray;
        public byte[] DataArray;
        
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
            Text5 = reader.ReadUTF("Text5");
            Text6 = reader.ReadUTF("Text6");
            Text7 = reader.ReadUTF("Text7");
            Text8 = reader.ReadUTF("Text8");
            Text9 = reader.ReadUTF("Text9");

            Boolean0 = reader.ReadBoolean("Boolean0");
            Boolean1 = reader.ReadBoolean("Boolean1");
            Boolean2 = reader.ReadBoolean("Boolean2");
            Boolean3 = reader.ReadBoolean("Boolean3");
            Boolean4 = reader.ReadBoolean("Boolean4");

            TimeStamp0 = reader.ReadLong("TimeStamp0");
            TimeStamp1 = reader.ReadLong("TimeStamp1");
            TimeStamp2 = reader.ReadLong("TimeStamp2");
            TimeStamp3 = reader.ReadLong("TimeStamp3");
            TimeStamp4 = reader.ReadLong("TimeStamp4");

            TextArray = reader.ReadUTFArray("TextArray");
            DataArray = reader.ReadByteArray("ByteArray");
        }

        public void WritePortable(IPortableWriter writer)
        {
            writer.WriteLong("Id", Id);
            
            writer.WriteUTF("Text0", Text0);
            writer.WriteUTF("Text1", Text1);
            writer.WriteUTF("Text2", Text2);
            writer.WriteUTF("Text3", Text3);
            writer.WriteUTF("Text4", Text4);
            writer.WriteUTF("Text5", Text5);
            writer.WriteUTF("Text6", Text6);
            writer.WriteUTF("Text7", Text7);
            writer.WriteUTF("Text8", Text8);
            writer.WriteUTF("Text9", Text9);
            
            writer.WriteBoolean("Boolean0", Boolean0);
            writer.WriteBoolean("Boolean1", Boolean1);
            writer.WriteBoolean("Boolean2", Boolean2);
            writer.WriteBoolean("Boolean3", Boolean3);
            writer.WriteBoolean("Boolean4", Boolean4);
            
            writer.WriteLong("TimeStamp0", TimeStamp0);
            writer.WriteLong("TimeStamp1", TimeStamp1);
            writer.WriteLong("TimeStamp2", TimeStamp2);
            writer.WriteLong("TimeStamp3", TimeStamp3);
            writer.WriteLong("TimeStamp4", TimeStamp4);
            
            writer.WriteUTFArray("TextArray", TextArray);
            writer.WriteByteArray("ByteArray", DataArray);
        }

        public override string ToString()
        {
            return $"{Id}";
        }
    }
}