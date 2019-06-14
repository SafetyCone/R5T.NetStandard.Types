using System;

using R5T.NetStandard.Extensions;


namespace R5T.NetStandard
{
    public static class MessageHelper
    {
        /// <summary>
        /// One space between clauses (sentences).
        /// </summary>
        public const string DefaultClauseSeparator = " ";


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
            string DefaultFormatter(TValue x) => x.ToString();

            var message = MessageHelper.AllowedRange(minimum, minimumInclusive, maximum, maximumInclusive, DefaultFormatter);
            return message;
        }

        public static string AllowedRange<TValue>(TValue minimum, TValue maximum)
        {
            var defaultMinimumInclusive = true;
            var defaultMaximumInclusive = true;

            var message = MessageHelper.AllowedRange(minimum, defaultMinimumInclusive, maximum, defaultMaximumInclusive);
            return message;
        }

        public static string JoinClauses(params string[] clauses)
        {
            var message = MessageHelper.JoinClausesSpecifySeparator(MessageHelper.DefaultClauseSeparator, clauses);
            return message;
        }

        public static string JoinClausesSpecifySeparator(string clauseSeparator, params string[] clauses)
        {
            var message = clauses.Concatenate(MessageHelper.DefaultClauseSeparator);
            return message;
        }
    }
}
