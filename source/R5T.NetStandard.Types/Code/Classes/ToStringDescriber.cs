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
}
