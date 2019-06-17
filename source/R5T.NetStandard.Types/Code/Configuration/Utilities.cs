using System;

using R5T.NetStandard.Extensions;


namespace R5T.NetStandard.Configuration
{
    public static class Utilities
    {
        /// <summary>
        /// Provides the default configuration path key token separator.
        /// Note that this functionality is alreayd provided by <see cref="Microsoft.Extensions.Configuration.ConfigurationPath.KeyDelimiter"/>.
        /// </summary>
        public const char DefaultConfigurationPathKeyTokenSeparatorChar = ':';
        public static string DefaultConfigurationPathKeyTokenSeparator { get; } = Utilities.DefaultConfigurationPathKeyTokenSeparatorChar.ToString();

        public const string ConfigurationValueNotFoundValue = null;


        /// <summary>
        /// Gets a configuration path key (example: 'SectionA:Key1').
        /// Note that this functionality is alreayd provided by <see cref="Microsoft.Extensions.Configuration.ConfigurationPath.Combine(string[])"/>.
        /// </summary>
        public static string GetConfigurationPathKey(params string[] keyTokens)
        {
            var output = keyTokens.Join(Utilities.DefaultConfigurationPathKeyTokenSeparator);
            return output;
        }
    }
}
