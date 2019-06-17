using System;

using Microsoft.Extensions.Logging;


namespace R5T.NetStandard
{
    public static class ILoggerExtensions
    {
        public static void LogAddingTransientService<TService>(this ILogger log)
        {
            log.LogAddingTransientService(typeof(TService));
        }

        public static void LogAddingTransientService(this ILogger log, Type type)
        {
            log.LogInformation($@"{type} - TRANSIENT. Adding service...");
        }

        public static void LogAddingScopedService<TService>(this ILogger log)
        {
            log.LogAddingScopedService(typeof(TService));
        }

        public static void LogAddingScopedService(this ILogger log, Type type)
        {
            log.LogInformation($@"{type} - SCOPED. Adding service...");
        }

        public static void LogAddingSingletonService<TService>(this ILogger log)
        {
            log.LogAddingSingletonService(typeof(TService));
        }

        public static void LogAddingSingletonService(this ILogger log, Type type)
        {
            log.LogInformation($@"{type} - SINGLETON. Adding service...");
        }

        public static void LogAddingService(this ILogger log, string serviceName)
        {
            log.LogInformation($@"{serviceName.ToUpperInvariant()} - Adding service...");
        }

        public static void LogBuiltServiceProvider(this ILogger log)
        {
            log.LogInformationEmphasis(@"Built service provider.");
        }

        public static void LogFunctionName(this ILogger log, string functionName)
        {
            log.LogInformation($@"{functionName}: Running function {functionName}.");
        }

        public static void LogInformationEmphasis(this ILogger log, string message)
        {
            var emphasizedMessage = $@"- {message} -";
            log.LogInformation(emphasizedMessage);
        }

        public static void LogInformationEmphasisDouble(this ILogger log, string message)
        {
            var emphasizedMessage = $@"--- {message} ---";
            log.LogInformation(emphasizedMessage);
        }

        public static void LogInformationEmphasisTriple(this ILogger log, string message)
        {
            var emphasizedMessage = $@"----- {message} -----";
            log.LogInformation(emphasizedMessage);
        }

        public static void LogStart(this ILogger log)
        {
            log.LogInformation(@"----- START -----");
        }

        public static void LogEnd(this ILogger log)
        {
            log.LogInformation(@"----- END -----");
        }

        public static void LogUse(this ILogger log, string serviceName)
        {
            log.LogInformation($@"{serviceName} - Using service.");
        }

        public static void LogVerifiedServiceOn<TService>(this ILogger log)
        {
            log.LogInformation($@"{typeof(TService).Name} - Verified service is on!");
        }

        public static void LogVerifiedServicesOn(this ILogger log)
        {
            log.LogInformation(@"- Verified services on. -");
        }
    }
}
