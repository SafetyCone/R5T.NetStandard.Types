using System;


namespace R5T.NetStandard
{
    public static class ArrayHelper
    {
        public static T[] FromSingle<T>(T item)
        {
            var output = new T[] { item };
            return output;
        }
    }
}
