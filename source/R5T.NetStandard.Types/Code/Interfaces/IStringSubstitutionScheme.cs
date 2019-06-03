using System;
using System.Collections.Generic;


namespace R5T.NetStandard
{
    /// <summary>
    /// Encapsulates the behavior of creating, finding, and via extension methods, interpreting substitution-tokens within strings.
    /// </summary>
    /// <remarks>
    /// String substitutions are very useful. Within a string, if a substitution-token sub-string is found, that sub-string is then replaced with another string, the substitution.
    /// Because string substitutions are so useful, they are used nearly everywhere. For example, a special name for a directory in a path is replaced with the actual path of that directory.
    /// But because string substitutions are used everywhere, there are an infinite variety of schemes for implementing string substitutions. The main requirement of a string substitution scheme is to be able to distinguish a substitution-token from the content in which it is embedded.
    /// This is hard because both the substitution-token and the content are just characters in a string. Thus substitution-tokens are generally wrapped in special character strings that signify their beginning and ending. A mechanism by which a these signifiers can be taken literally (i.e. not treated as token signifiers, or escaped) is also generally provided.
    /// However, because extra effort is required to escape these special signifying character strings, unlikely character strings are usually chosen to be signifiers. The question then becomes what character strings are unlikely? Since this depends on the problem domain, a plethora of signifier schemes exist; as many schemes as there are domains.
    /// There is one commonality between all the various schemes: the wrapping of a value in signifiers to become a substitution-token. Thus it's worth encapsulating this common behavior in a common implementation.
    /// But, because there are so many schemes, with so many choices of beginning and ending signifiers, it's worth abstracting away any implementation details with an interface.
    /// </remarks>
    public interface IStringSubstitutionScheme
    {
        /// <summary>
        /// Given a substituion value, creates a substitution-token by wrapping the value in the beginning and ending signifiers of the scheme.
        /// </summary>
        string CreateSubstitutionToken(string value);

        /// <summary>
        /// Given a target string to search, finds the first substitution-token after the start-index.
        /// Returns true if a substitution is found, and the out substitution parameter contains the substitution-token and index in the string where the substitution-token began.
        /// Otherwise false and null.
        /// A start-index allows repeated search of the whole target string.
        /// </summary>
        bool FindSubstitution(string target, out Tuple<string, int> substitution, int startIndex = 0);

        /// <summary>
        /// Given all possible substitution-tokens, and a target string to search, finds the first substitution-token after the start-index.
        /// Returns true if a substitution-token is found, and the out substitution parameter contains the substitution-token and index in the string where the substitution-token began.
        /// Otherwise, false and null.
        /// A start-index allows repeated search of the whole target string.
        /// </summary>
        bool FindSubstitution(IEnumerable<string> substitutionTokens, string target, out Tuple<string, int> substitution, int startIndex = 0);
    }
}
