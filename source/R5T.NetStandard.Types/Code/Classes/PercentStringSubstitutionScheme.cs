using System;
using System.Collections.Generic;


namespace R5T.NetStandard
{
    public class PercentStringSubstitutionScheme : IStringSubstitutionScheme
    {
        public const char SignifierChar = '%';
        public static readonly string Signifier = PercentStringSubstitutionScheme.SignifierChar.ToString(); // Beginning and ending signifier are the same.


        public string CreateSubstitutionToken(string value)
        {
            var substitutionToken = $@"{PercentStringSubstitutionScheme.Signifier}{value}{PercentStringSubstitutionScheme.Signifier}";
            return substitutionToken;
        }

        public bool FindSubstitution(string str, out Tuple<string, int> substitution, int startIndex = 0)
        {
            var tokenStartIndex = str.IndexOf(PercentStringSubstitutionScheme.Signifier);
            if (StringHelper.IsFound(tokenStartIndex))
            {
                var tokenEndIndex = str.IndexOf(PercentStringSubstitutionScheme.Signifier, tokenStartIndex + 1);
                if (StringHelper.IsFound(tokenEndIndex))
                {
                    var substitutionToken = str.Substring(tokenStartIndex, tokenEndIndex - tokenStartIndex);

                    substitution = Tuple.Create(substitutionToken, tokenStartIndex);
                    return true;
                }
            }

            substitution = null;
            return false;
        }

        public bool FindSubstitution(IEnumerable<string> substitutionTokens, string str, out Tuple<string, int> substitution, int startIndex = 0)
        {
            foreach (var substitutionToken in substitutionTokens)
            {
                var index = str.IndexOf(substitutionToken, startIndex);
                if (index != StringHelper.IndexOfNotFound)
                {
                    substitution = Tuple.Create(substitutionToken, index);
                    return true;
                }
            }

            substitution = null;
            return false;
        }
    }
}
