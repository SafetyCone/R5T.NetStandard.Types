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
            var output = @string.Suffix(appendix);
            return output;
        }

        /// <summary>
        /// Returns the input string, except without the first specified number of characters (a positive integer).
        /// </summary>
        public static string ExceptFirst(this string @string, int numberOfCharacters)
        {
            var output = @string.Substring(numberOfCharacters);
            return output;
        }

        /// <summary>
        /// Returns the input string, except without the first character.
        /// </summary>
        public static string ExceptFirst(this string @string)
        {
            var output = @string.ExceptFirst(1);
            return output;
        }

        /// <summary>
        /// Returns the input string, except without the last specified number of characters (a positive integer).
        /// </summary>
        public static string ExceptLast(this string @string, int numberOfCharacters)
        {
            var output = @string.Substring(0, @string.Length - numberOfCharacters);
            return output;
        }

        /// <summary>
        /// Returns the input string, except without the last character.
        /// </summary>
        public static string ExceptLast(this string @string)
        {
            var output = @string.ExceptLast(1);
            return output;
        }

        /// <summary>
        /// An ease-of-use overload that allows using a single string as the separator (instead of a full string array).
        /// </summary>
        public static string[] Split(this string @string, string separator, StringSplitOptions stringSplitOptions = StringSplitOptions.None)
        {
            var output = @string.Split(new string[] { separator }, stringSplitOptions);
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