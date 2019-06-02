using System;


namespace R5T.NetStandard
{
    /// <summary>
    /// Describes an object.
    /// </summary>
    /// <remarks>
    /// The <see cref="IDescriber"/> interface differs from the <see cref="IStringSerializer{T}"/> interface in that description is uni-directional, object to string only, while serialization implies bi-directional object to string and string to object.
    /// </remarks>
    public interface IDescriber
    {
        string Describe(object obj);
    }

    /// <summary>
    /// Describes an object of type <typeparamref name="T"/>.
    /// </summary>
    public interface IDescriber<T>
    {
        string Describe(T obj);
    }
}
