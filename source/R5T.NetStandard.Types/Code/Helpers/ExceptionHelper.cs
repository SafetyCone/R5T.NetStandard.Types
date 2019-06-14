using System;


namespace R5T.NetStandard
{
    public static class ExceptionHelper
    {
        /// <summary>
        /// Provides a message indicating that an instance was not of the expected type.
        /// </summary>
        public static string UnexpectedTypeExceptionMessage(Type unexpectedType)
        {
            var output = $"Unexpected type. Type {unexpectedType.FullName} was unexpected.";
            return output;
        }

        public static string UnexpectedTypeExceptionMessage<TUnexpectedType>(TUnexpectedType instance)
        {
            var unexpectedType = typeof(TUnexpectedType);

            var output = ExceptionHelper.UnexpectedTypeExceptionMessage(unexpectedType);
            return output;
        }

        /// <summary>
        /// Provides a message indicating that an instance was not of the expected type.
        /// </summary>
        public static string UnexpectedTypeExceptionMessage(Type expectedType, Type foundType)
        {
            var output = $"Unexpected type. Expected: {expectedType.FullName}, Found: {foundType.FullName}";
            return output;
        }

        /// <summary>
        /// Provides a message indicating that an instance was not of the expected type.
        /// </summary>
        public static string UnexpectedTypeExceptionMessage<TFound>(Type expectedType, TFound foundInstance)
        {
            var output = ExceptionHelper.UnexpectedTypeExceptionMessage(expectedType, foundInstance.GetType());
            return output;
        }

        /// <summary>
        /// Provides a message indicating that an instance was not of the expected type.
        /// </summary>
        public static string UnexpectedTypeExceptionMessage<TExpected>(object foundInstance)
        {
            var output = ExceptionHelper.UnexpectedTypeExceptionMessage(typeof(TExpected), foundInstance.GetType());
            return output;
        }

        /// <summary>
        /// Provides a message indicating that an object could not be cast to an expected type.
        /// </summary>
        public static string InvalidCastExceptionMessage(Type expectedType, object obj)
        {
            var output = $"Invalid cast. Allowed: {expectedType}, found: {obj.GetType().FullName}";
            return output;
        }

        /// <summary>
        /// Convenience method that provides a message indicating that an object could not be cast to an expected type.
        /// </summary>
        public static string InvalidCastExceptionMessage<TExpected>(object obj)
        {
            var expectedType = typeof(TExpected);

            var output = ExceptionHelper.InvalidCastExceptionMessage(expectedType, obj);
            return output;
        }

        public static string ArgumentOutOfRangeExceptionMessage(string formattedValue, string formattedMinimum, bool minimumInclusive, string formattedMaximum, bool maximumInclusive)
        {
            var allowedRangeClause = MessageHelper.AllowedRange(formattedMinimum, minimumInclusive, formattedMaximum, maximumInclusive);

            var message = MessageHelper.JoinClauses($"Argument out of range: {formattedValue}.", allowedRangeClause);
            return message;
        }

        public static string ArgumentOutOfRangeExceptionMessage<TValue>(TValue value, TValue minimum, bool minimumInclusive, TValue maximum, bool maximumInclusive, Func<TValue, string> formatter)
        {
            var formattedValue = formatter(value);
            var formattedMinimum = formatter(minimum);
            var formattedMaximum = formatter(maximum);

            var message = ExceptionHelper.ArgumentOutOfRangeExceptionMessage(formattedValue, formattedMinimum, minimumInclusive, formattedMaximum, maximumInclusive);
            return message;
        }

        public static string ArgumentOutOfRangeExceptionMessage<TValue>(TValue value, TValue minimum, bool minimumInclusive, TValue maximum, bool maximumInclusive)
        {
            string DefaultFormatter(TValue x) => x.ToString();

            var message = ExceptionHelper.ArgumentOutOfRangeExceptionMessage(value, minimum, minimumInclusive, maximum, maximumInclusive, DefaultFormatter);
            return message;
        }

        public static string ArgumentOutOfRangeExceptionMessage<TValue>(TValue value, TValue minimum, TValue maximum)
        {
            var defaultMinimumInclusive = true;
            var defaultMaximumInclusive = true;

            var message = ExceptionHelper.ArgumentOutOfRangeExceptionMessage(value, minimum, defaultMinimumInclusive, maximum, defaultMaximumInclusive);
            return message;
        }
    }
}
