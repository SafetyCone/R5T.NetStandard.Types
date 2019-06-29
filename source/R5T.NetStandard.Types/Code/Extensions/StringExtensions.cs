using System;
using System.Collections.Generic;


namespace R5T.NetStandard
{
    public static class StringExtensions
    {
        public static string Prefix(this string @string, string prefix)
        {
            var prefixedString = $"{prefix}{@string}";
            return prefixedString;
        }

        public static string Suffix(this string @string, string suffix)
        {
            var prefixedString = $"{@string}{suffix}";
            return prefixedString;
        }

        /// <summary>
        /// Determines whether the input <paramref name="string"/> begins with the input <paramref name="beginning"/>.
        /// </summary>
        public static bool BeginsWith(this string @string, string beginning)
        {
            if (@string.Length < beginning.Length)
            {
                return false;
            }

            var beginsWith = @string.Substring(0, beginning.Length) == beginning;
            return beginsWith;
        }

        public static string Append(this string @string, string appendix)
        {
            var output = @string + appendix;
            return output;
        }

        /// <summary>
        /// Returns a string of the specified length ending at the specified end-index.
        /// </summary>
        /// <param name="string">The string to sub-string.</param>
        /// <param name="endIndex">The last index in the string (zero-based, inclusive).</param>
        /// <param name="length">The number of characters to return.</param>
        public static string SubstringFromEnd(this string @string, int endIndex, int length)
        {
            var startIndex = endIndex - length + 1;

            var output = @string.Substring(startIndex, length);
            return output;
        }

        public static string SubstringFromEnd(this string @string, int endIndex)
        {
            var length = endIndex + 1;

            var output = @string.SubstringFromEnd(endIndex, length);
            return output;
        }
    }
}


namespace R5T.NetStandard.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Same as <see cref="Join(IEnumerable{string}, string)"/>.
        /// </summary>
        public static string Concatenate(this IEnumerable<string> strings, string separator)
        {
            var output = strings.Join(separator);
            return output;
        }

        /// <summary>
        /// The <see cref="String.Join(string, IEnumerable{string})"/> functionality as an extension method.
        /// </summary>
        public static string Join(this IEnumerable<string> strings, string separator)
        {
            var output = String.Join(separator, strings);
            return output;
        }
    }
}