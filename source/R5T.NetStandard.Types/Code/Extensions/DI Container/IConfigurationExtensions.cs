using System;
using System.Linq;

using Microsoft.Extensions.Configuration;

using ConfigurationUtilities = R5T.NetStandard.Configuration.Utilities;


namespace R5T.NetStandard
{
    public static class IConfigurationExtensions
    {
        public static bool ContainsKey(this IConfiguration configuration, string key)
        {
            var value = configuration[key];

            var output = value != ConfigurationUtilities.ConfigurationValueNotFoundValue;
            return output;
        }

        public static bool Exists(this IConfiguration configuration, string key)
        {
            var output = configuration.ContainsKey(key);
            return output;
        }

        /// <summary>
        /// Tests whether a configuration has no children.
        /// </summary>
        public static bool IsEmpty(this IConfiguration configuration)
        {
            var children = configuration.GetChildren();

            var childCount = children.Count();

            var isEmpty = childCount < 1;
            return isEmpty;
        }
    }
}
