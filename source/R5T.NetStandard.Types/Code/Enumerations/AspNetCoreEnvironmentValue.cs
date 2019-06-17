using System;


namespace R5T.NetStandard
{
    /// <summary>
    /// An enumeration of the built-in and logical ASP.NET Core environment values.
    /// </summary>
    public enum AspNetCoreEnvironmentValue
    {
        /// <summary>
        /// Indicates that code should take no action, and allow whatever was going to happen by default to happen.
        /// </summary>
        Default = 0,
        /// <summary>
        /// Indicates an unset ASP.NET Core environment variable.
        /// </summary>
        None,
        Development,
        Staging,
        Production,
    }


    public static class AspNetCoreEnvironmentValueExtensions
    {
        public const string DefaultString = @"Default";
        public const string NoneString = @"None";
        public const string DevelopmentString = @"Development";
        public const string StagingString = @"Staging";
        public const string ProductionString = @"Production";


        public static string ToStringStandard(this AspNetCoreEnvironmentValue aspNetCoreEnvironment)
        {
            switch (aspNetCoreEnvironment)
            {
                case AspNetCoreEnvironmentValue.Default:
                    return AspNetCoreEnvironmentValueExtensions.DefaultString;

                case AspNetCoreEnvironmentValue.None:
                    return AspNetCoreEnvironmentValueExtensions.NoneString;

                case AspNetCoreEnvironmentValue.Development:
                    return AspNetCoreEnvironmentValueExtensions.DevelopmentString;

                case AspNetCoreEnvironmentValue.Staging:
                    return AspNetCoreEnvironmentValueExtensions.StagingString;

                case AspNetCoreEnvironmentValue.Production:
                    return AspNetCoreEnvironmentValueExtensions.ProductionString;

                default:
                    throw new Exception(EnumHelper.UnexpectedEnumerationValueMessage(aspNetCoreEnvironment));
            }
        }

        public static string Describe(this AspNetCoreEnvironmentValue aspNetCoreEnvironment)
        {
            var output = $@"ASP.NET Core Environment: {aspNetCoreEnvironment.ToStringStandard()}";
            return output;
        }
    }
}
