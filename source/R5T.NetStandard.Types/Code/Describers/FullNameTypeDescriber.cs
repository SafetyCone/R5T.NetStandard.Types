using System;


namespace R5T.NetStandard
{
    /// <summary>
    /// Describes a type using the <see cref="Type.FullName"/> property.
    /// </summary>
    public class FullNameTypeDescriber : IDescriber<Type>
    {
        public string Describe(Type type)
        {
            var description = type.FullName;
            return description;
        }
    }
}
