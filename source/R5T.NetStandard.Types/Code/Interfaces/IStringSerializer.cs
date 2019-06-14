using System;


namespace R5T.NetStandard
{
    /// <summary>
    /// De/serializes an object to a string.
    /// </summary>
    /// <remarks>
    /// The formatting details are left unspecified.
    /// The <see cref="IStringSerializer{T}"/> interfaces differs from the IDescriber interface in that description is uni-directional, object to string only, while serialization implies bi-directional, object to string and string to object.
    /// Description also implies lossy serialization, while serialization implies that all object information is captured.
    /// </remarks>
    public interface IStringSerializer<T>
    {
        /// <summary>
        /// Deserializes an object from a string.
        /// </summary>
        T Deserialize(string value);

        /// <summary>
        /// Serializes an object to a string.
        /// </summary>
        string Serialize(T obj);
    }
}
