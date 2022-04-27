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
        /// Wraps this object instance into an IEnumerable&lt;T&gt;
        /// consisting of a single item.
        /// </summary>
        /// <typeparam name="T"> Type of the object. </typeparam>
        /// <param name="item"> The instance that will be wrapped. </param>
        /// <returns> An IEnumerable&lt;T&gt; consisting of a single item. </returns>
        // From: https://stackoverflow.com/questions/1577822/passing-a-single-item-as-ienumerablet
        public static IEnumerable<T> ToEnumerable<T>(this T item)
        {
            yield return item;
        }

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

        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            var output = source.Count() < 1;
            return output;
        }

        public static bool HasSingle<T>(this IEnumerable<T> source, Func<T, bool> predicate, out T value)
        {
            value = source.Where(predicate).SingleOrDefault();

            var output = !value.Equals(default(T));
            return output;
        }

        public static bool HasSingle<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var output = source.HasSingle(predicate, out _);
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