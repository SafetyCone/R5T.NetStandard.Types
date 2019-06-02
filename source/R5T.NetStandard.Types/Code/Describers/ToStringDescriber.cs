using System;


namespace R5T.NetStandard
{
    /// <summary>
    /// A simple <see cref="IDescriber"/> that simply calls <see cref="object.ToString"/>.
    /// </summary>
    public class ToStringDescriber : IDescriber
    {
        public string Describe(object obj)
        {
            var output = obj.ToString();
            return output;
        }
    }

    public class ToStringDescriber<T> : IDescriber<T>, IDescriber
    {
        public string Describe(object obj)
        {
            throw new NotImplementedException();
        }

        public string Describe(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
