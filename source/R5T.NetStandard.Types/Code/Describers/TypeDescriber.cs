using System;


namespace R5T.NetStandard
{
    /// <summary>
    /// Describes a type using the <see cref="Type"/>'s <see cref="System.Reflection.MemberInfo.Name"/> property.
    /// </summary>
    public class TypeDescriber : IDescriber<Type>
    {
        public string Describe(Type type)
        {
            var description = type.Name;
            return description;
        }
    }
}
