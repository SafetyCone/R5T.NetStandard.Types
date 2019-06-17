using System;


namespace R5T.NetStandard
{
    public static class DescribedResultExtensions
    {
        public static bool HasMessage<T>(this DescribedResult<T> describedResult)
        {
            bool hasMessage = describedResult.Message == DescribedResult.DefaultMessage;
            return hasMessage;
        }
    }
}
