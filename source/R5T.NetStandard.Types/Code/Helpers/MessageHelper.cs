using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using R5T.NetStandard.Extensions;


namespace R5T.NetStandard
{
    public static class MessageHelper
    {
        /// <summary>
        /// One space between clauses (sentences).
        /// </summary>
        public const string DefaultClauseSeparator = " ";


        public static string DefaultFormatter<TValue>(TValue x)
        {
            var output = x.ToString();
            return output;
        }

        public static string AllowedRange(string formattedMinimum, bool minimumInclusive, string formattedMaximum, bool maximumInclusive)
        {
            var minimumInclusiveSymbol = minimumInclusive ? '[' : '(';
            var maximumInclusiveSymbol = maximumInclusive ? ']' : ')';

            var message = $"Allowed range: {minimumInclusiveSymbol}{formattedMinimum}, {formattedMaximum}{maximumInclusiveSymbol}";
            return message;
        }

        public static string AllowedRange<TValue>(TValue minimum, bool minimumInclusive, TValue maximum, bool maximumInclusive, Func<TValue, string> formatter)
        {
            var formattedMinimum = formatter(minimum);
            var formattedMaximum = formatter(maximum);

            var message = MessageHelper.AllowedRange(formattedMinimum, minimumInclusive, formattedMaximum, maximumInclusive);
            return message;
        }

        public static string AllowedRange<TValue>(TValue minimum, bool minimumInclusive, TValue maximum, bool maximumInclusive)
        {
            var message = MessageHelper.AllowedRange(minimum, minimumInclusive, maximum, maximumInclusive, MessageHelper.DefaultFormatter);
            return message;
        }

        /// <summary>
        /// Returns a message explaining that a value must be within the range from <paramref name="minimum"/> to <paramref name="maximum"/>, inclusive.
        /// </summary>
        public static string AllowedRange<TValue>(TValue minimum, TValue maximum)
        {
            var defaultMinimumInclusive = true;
            var defaultMaximumInclusive = true;

            var message = MessageHelper.AllowedRange(minimum, defaultMinimumInclusive, maximum, defaultMaximumInclusive);
            return message;
        }

        public static string AllowedValues(IEnumerable<string> valueStrings)
        {
            var builder = new StringBuilder("Allowed values:");
            foreach (var valueString in valueStrings)
            {
                builder.Append($"\n{valueString}");
            }

            var output = builder.ToString();
            return output;
        }

        public static string AllowedValues<TValue>(IEnumerable<TValue> values, Func<TValue, string> formatter)
        {
            var valueStrings = values.Select(x => formatter(x));

            var output = MessageHelper.AllowedValues(valueStrings);
            return output;
        }

        public static string AllowedValues<TValue>(IEnumerable<TValue> values)
        {
            var output = MessageHelper.AllowedValues(values, MessageHelper.DefaultFormatter);
            return output;
        }

        public static string JoinClauses(params string[] clauses)
        {
            var message = MessageHelper.JoinClausesSpecifySeparator(MessageHelper.DefaultClauseSeparator, clauses);
            return message;
        }

        public static string JoinClausesSpecifySeparator(string clauseSeparator, params string[] clauses)
        {
            var message = clauses.Concatenate(clauseSeparator);
            return message;
        }
    }
}
