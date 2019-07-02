using System;
using System.Collections.Generic;
using System.Linq;


namespace R5T.NetStandard
{
    public static class IEnumerableExtensions
    {
    }
}


namespace R5T.NetStandard.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Allows adding a few extra items to an enumerable.
        /// </summary>
        public static IEnumerable<T> And<T>(this IEnumerable<T> enumerable, params T[] extras)
        {
            foreach (var item in enumerable)
            {
                yield return item;
            }

            foreach (var item in extras)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Performs the specified action on each element of an enumerable.
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T element in source)
            {
                action(element);
            }
        }

        /// <summary>
        /// Applies the specified function on each element of an enumerable.
        /// </summary>
        public static IEnumerable<TOut> ForEach<TIn, TOut>(this IEnumerable<TIn> source, Func<TIn, TOut> func)
        {
            var output = source.Select(func);
            return output;
        }

        public static bool HasSingle<T>(this IEnumerable<T> source, Func<T, bool> predicate, out T value)
        {
            value = source.Where(predicate).SingleOrDefault();

            var output = value != default;
            return output;
        }

        public static bool HasSingle<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var output = source.HasSingle(predicate, out var dummy);
            return output;
        }

        public static T GetSingle<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var hasSingle = source.HasSingle(predicate, out var value);
            if(!hasSingle)
            {
                throw new InvalidOperationException("No value found.");
            }

            return value;
        }

        public static T AcquireSingle<T>(this IEnumerable<T> source, Func<T, bool> predicate, Func<T> constructor)
        {
            var hasSingle = source.HasSingle(predicate, out var value);
            if(hasSingle)
            {
                return value;
            }

            value = constructor();
            return value;
        }

        /// <summary>
        /// Perform an action on an <see cref="IEnumerable{T}"/> using a fluent API.
        /// </summary>
        public static IEnumerable<T> Fluent<T>(this IEnumerable<T> source, Action<IEnumerable<T>> action)
        {
            action(source);

            return source;
        }
    }
}