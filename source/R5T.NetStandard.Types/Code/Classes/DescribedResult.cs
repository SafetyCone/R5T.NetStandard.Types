using System;
using System.Collections.Generic;
using System.Text;

namespace R5T.NetStandard
{
    public static class DescribedResult
    {
        public const string DefaultMessage = null;


        /// <summary>
        /// Creates a <see cref="DescribedResult{T}"/> with the <see cref="DescribedResult.DefaultMessage"/>.
        /// </summary>
        public static DescribedResult<T> FromValue<T>(T value)
        {
            var describedResult = new DescribedResult<T>(value, DescribedResult.DefaultMessage);
            return describedResult;
        }

        /// <summary>
        /// Creates a <see cref="DescribedResult{T}"/> with the given message.
        /// </summary>
        public static DescribedResult<T> FromValue<T>(T value, string message)
        {
            var describedResult = new DescribedResult<T>(value, message);
            return describedResult;
        }

        /// <summary>
        /// Returns the input <paramref name="message"/> if the given <paramref name="useMessage"/> is true, else returns the <see cref="DescribedResult.DefaultMessage"/>.
        /// </summary>
        public static string MessageOrDefault(bool useMessage, string message)
        {
            var messageOrDefaultMessage = useMessage ? message : DescribedResult.DefaultMessage;
            return messageOrDefaultMessage;
        }
    }


    /// <summary>
    /// What if you want to get both a result, and a description of a result? For example, you might have a function that provides a boolean output, but in the case where the boolean is false, you want to provide a reason.
    /// This is a specific case of the general case of wanting to return two values from a function.
    /// One way to do so is to use out-parameters. But what about when when you want to want to use a Func? Out- and ref-parameters are not part of the type parameter definition, so Func cannot specify these argument qualifiers.
    /// You could define your own delegate (source: https://stackoverflow.com/a/1283143):
    ///     delegate TResult MyDelegate{TIn,TOut,TResult}(TIn input, out TOut output);
    /// But that requires some work. Another way is to just return a single instance of a custom type containing both values from the function. Tuples make this easy.
    /// A <see cref="DescribedResult{T}"/> formalizes the case where you want to attach a message to a result.
    /// </summary>
    public class DescribedResult<T>
    {
        public T Value { get; }
        public string Message { get; }


        public DescribedResult(T value, string message)
        {
            this.Value = value;
            this.Message = message;
        }
    }
}
