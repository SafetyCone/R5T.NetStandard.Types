using System;


namespace R5T.NetStandard
{
    public static class Describer
    {
        /// <summary>
        /// The default <see cref="IDescriber"/> (the <see cref="ToStringDescriber"/>).
        /// </summary>
        public static readonly IDescriber Default = new ToStringDescriber();
    }


    /// <summary>
    /// Base-class for <see cref="IDescriber{T}"/> implementations that also implement <see cref="IDescriber"/>.
    /// This takes care of type-checking the input <see cref="object"/> instance and throwing an <see cref="AggregateException"/> if the instance is not of type <typeparamref name="T"/>.
    /// </summary>
    public abstract class Describer<T> : IDescriber<T>, IDescriber
    {
        public string Describe(object obj)
        {
            if (obj is T objAsT)
            {
                var description = this.Describe_Implementation(objAsT);
                return description;
            }

            throw new ArgumentException($"Invalid type. Expected: {typeof(T).FullName}, found: {obj.GetType().FullName}.", nameof(obj));
        }

        public string Describe(T obj)
        {
            var description = this.Describe_Implementation(obj);
            return description;
        }

        protected abstract string Describe_Implementation(T obj);
    }
}
