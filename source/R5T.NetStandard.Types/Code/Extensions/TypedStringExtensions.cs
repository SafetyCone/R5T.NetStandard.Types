using System;
using System.Collections.Generic;
using System.Linq;


namespace R5T.NetStandard
{
    public static class TypedStringExtensions
    {
        /// <summary>
        /// Concatenates <see cref="TypedString"/>s placing the specified <paramref name="separator"/> between each string value.
        /// No separator is placed at the beginning or the end of the string.
        /// </summary>
        public static string Join(this IEnumerable<TypedString> typedStrings, string separator)
        {
            var values = typedStrings.Select(x => x.Value);

            var joinedString = String.Join(separator, values);
            return joinedString;
        }
    }
}
