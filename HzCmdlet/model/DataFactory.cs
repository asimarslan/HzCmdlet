using System;

namespace HzCmdlet.model
{
    public static class DataFactory
    {
        public static ComplexPortableKey CreateComplexPortableKey(int id)
        {
            return new ComplexPortableKey(id, "abcdefgihjkl" + id);
            
        }
        
        public static ComplexPortableData CreateComplexPortableData(int id, int arraySize)
        {
            var s = "abcdefgihjkl" + id;
            return new ComplexPortableData
            {
                Id = id,
                Text0 = s,
                Text1 = s,
                Text2 = s,
                Text3 = s,
                Text4 = s,
                Text5 = s,
                Text6 = s,
                Text7 = s,
                Text8 = s,
                Text9 = s,
                Boolean0 = true,
                Boolean1 = true,
                Boolean2 = true,
                Boolean3 = false,
                Boolean4 = false,
                TimeStamp0 = 1L,
                TimeStamp1 = 1L,
                TimeStamp2 = 1L,
                TimeStamp3 = 1L,
                TimeStamp4 = 1L,
                TextArray = new string[arraySize],
                DataArray = new byte[arraySize]
            };
        }
    }
}