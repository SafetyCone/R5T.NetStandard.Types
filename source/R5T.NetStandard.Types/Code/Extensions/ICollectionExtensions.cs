using System;
using System.Collections.Generic;


namespace R5T.NetStandard.Extensions
{
    public static class ICollectionExtensions
    {
        public static IEnumerable<T> ExceptLast<T>(this ICollection<T> collection, int count)
        {
            var totalNumber = collection.Count;

            var maxCount = totalNumber - count;

            var counter = 0;
            foreach (var item in collection)
            {
                if(counter < maxCount)
                {
                    counter++;
                    yield return item;
                }
                else
                {
                    break;
                }
            }
        }

        public static IEnumerable<T> ExceptLast<T>(this ICollection<T> collection)
        {
            var output = collection.ExceptLast(1);
            return output;
        }
    }
}
