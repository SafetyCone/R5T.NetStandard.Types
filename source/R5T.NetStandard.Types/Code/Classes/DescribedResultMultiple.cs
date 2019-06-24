using System;
using System.Collections.Generic;
using System.Linq;


namespace R5T.NetStandard
{
    public static class DescribedResultMultiple
    {
        public static readonly IEnumerable<string> DefaultMessages = Enumerable.Empty<string>();


        public static DescribedResultMultiple<T> FromValue<T>(T value)
        {
            var describedResult = new DescribedResultMultiple<T>(value, DescribedResultMultiple.DefaultMessages);
            return describedResult;
        }

        public static DescribedResultMultiple<T> FromValue<T>(T value, string message)
        {
            var describedResult = new DescribedResultMultiple<T>(value, message);
            return describedResult;
        }

        public static DescribedResultMultiple<T> FromValue<T>(T value, params string[] messages)
        {
            var describedResult = new DescribedResultMultiple<T>(value, messages);
            return describedResult;
        }

        public static DescribedResultMultiple<T> FromValue<T>(T value, IEnumerable<string> messages)
        {
            var describedResult = new DescribedResultMultiple<T>(value, messages);
            return describedResult;
        }
    }


    public class DescribedResultMultiple<T>
    {
        public T Value { get; }
        private List<string> Messages_Internal { get; } = new List<string>();
        public IEnumerable<string> Messages => this.Messages_Internal;


        public DescribedResultMultiple(T value, IEnumerable<string> messages)
        {
            this.Value = value;
            this.Messages_Internal.AddRange(messages);
        }

        public DescribedResultMultiple(T value, params string[] messages)
            : this(value, messages as IEnumerable<string>)
        {
        }
    }
}
