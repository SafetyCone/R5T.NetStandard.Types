using System;
using System.Collections.Generic;


namespace R5T.NetStandard.Extensions
{
    public static class ListExtensions
    {
        public static List<T> SortFluent<T>(this List<T> list)
        {
            list.Sort();

            return list;
        }

        public static List<T> SortFluent<T>(this List<T> list, Comparison<T> comparison)
        {
            list.Sort(comparison);

            return list;
        }

        public static List<T> SortFluent<T>(this List<T> list, IComparer<T> comparer)
        {
            list.Sort(comparer);

            return list;
        }

        public static List<T> SortFluent<T>(this List<T> list, int index, int count, IComparer<T> comparer)
        {
            list.Sort(index, count, comparer);

            return list;
        }
    }
}
