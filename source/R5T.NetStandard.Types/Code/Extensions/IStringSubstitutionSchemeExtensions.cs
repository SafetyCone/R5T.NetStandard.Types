using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using R5T.NetStandard.Extensions;


namespace R5T.NetStandard
{
    public static class IStringSubstitutionSchemeExtensions
    {
        /// <summary>
        /// Given a mapping of items-by-value, produces a mapping of items-by-substitution-token.
        /// </summary>
        public static Dictionary<string, T> PerformTokenization<T>(this IStringSubstitutionScheme stringSubstitutionScheme, Dictionary<string, T> itemsByValue)
        {
            var itemsBySubstitutionToken = itemsByValue.ToDictionary(x => stringSubstitutionScheme.CreateSubstitutionToken(x.Key), x => x.Value);
            return itemsBySubstitutionToken;
        }

        /// <summary>
        /// Given a mapping of items-by-value, adds item-by-substitution-token pairs to the specified destination mapping of items-by-substitution-token.
        /// </summary>
        public static void PerformTokenization<T>(this IStringSubstitutionScheme stringSubstitutionScheme, Dictionary<string, T> itemsByValue, Dictionary<string, T> destination)
        {
            itemsByValue.ForEach(x => destination.Add(stringSubstitutionScheme.CreateSubstitutionToken(x.Key), x.Value));
        }

        /// <summary>
        /// Interprets a target string by performing any substitutions using the provided substitution-tokens and a function for getting the substitution for a given substitution-token.
        /// Recursively searches for substitution-tokens within the substitutions of prior substitution-tokens.
        /// </summary>
        public static string InterpretRecursively(this IStringSubstitutionScheme stringSubstitutionScheme, IEnumerable<string> substitutionTokens, Func<string, string> substitutionForTokenProvider, string target)
        {
            if (stringSubstitutionScheme.FindSubstitution(substitutionTokens, target, out var substitution))
            {
                var builder = new StringBuilder(target);
                do
                {
                    builder.Remove(substitution.Item2, substitution.Item1.Length);

                    var value = substitutionForTokenProvider(substitution.Item1);
                    builder.Insert(substitution.Item2, value);

                    var updatedStr = builder.ToString();
                    stringSubstitutionScheme.FindSubstitution(substitutionTokens, updatedStr, out substitution);
                }
                while (substitution != null);

                var interpretedStr = builder.ToString();
                return interpretedStr;
            }
            else
            {
                return target;
            }
        }

        /// <summary>
        /// Interprets a target string by performing any substitutions using the provided substitution-tokens and a function for getting the substitution for a given substitution-token.
        /// Performs a single-pass replacement of substitutions (i.e. substitution-tokens within the substitutions for prior substitution-tokens will not be replaced).
        /// </summary>
        public static string InterpretSinglePass(this IStringSubstitutionScheme stringSubstitutionScheme, IEnumerable<string> substitutionTokens, Func<string, string> substitutionForTokenProvider, string target)
        {
            var startIndex = 0;

            if (stringSubstitutionScheme.FindSubstitution(substitutionTokens, target, out var substitution, startIndex))
            {
                var builder = new StringBuilder(target);
                do
                {
                    builder.Remove(substitution.Item2, substitution.Item1.Length);

                    var value = substitutionForTokenProvider(substitution.Item1);
                    builder.Insert(substitution.Item2, value);

                    startIndex += value.Length;

                    stringSubstitutionScheme.FindSubstitution(substitutionTokens, target, out substitution, startIndex);
                }
                while (substitution != null);

                var interpretedStr = builder.ToString();
                return interpretedStr;
            }
            else
            {
                return target;
            }
        }

        /// <summary>
        /// Interprets a target string by performing any substitutions using the provided substitution-tokens and a function for getting the substitution for a given substitution-token.
        /// This default interpretation method uses recursive interpretation.
        /// </summary>
        public static string Interpret(this IStringSubstitutionScheme stringSubstitutionScheme, IEnumerable<string> substitutionTokens, Func<string, string> substitutionForTokenProvider, string target)
        {
            var output = stringSubstitutionScheme.InterpretRecursively(substitutionTokens, substitutionForTokenProvider, target);
            return output;
        }

        /// <summary>
        /// Interprets a target string by performing any substitutions using the provided mapping of substitution-tokens to substitutions.
        /// </summary>
        public static string Interpret(this IStringSubstitutionScheme stringSubstitutionScheme, Dictionary<string, string> substitutionsByToken, string target)
        {
            var output = stringSubstitutionScheme.Interpret(substitutionsByToken.Keys,
                (substitutionToken) =>
                {
                    var substitution = substitutionsByToken[substitutionToken];
                    return substitution;
                },
                target);

            return output;
        }
    }
}
