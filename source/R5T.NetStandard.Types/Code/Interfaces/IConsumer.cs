using System;


namespace R5T.NetStandard
{
    /// <summary>
    /// Consumes instances of type <typeparamref name="T"/> for processing.
    /// Basically, an <see cref="Action{T}"/> as a type, not a delegate.
    /// For functions see <see cref="IProvider{T}"/>.
    /// </summary>
    public interface IConsumer<in T>
    {
        void Consume(T value);
    }

    /// <summary>
    /// Consumes paired instances of types <typeparamref name="T1"/> and <typeparamref name="T2"/> for processing.
    /// Basically, an <see cref="Action{T1, T2}"/> as a type, not a delegate.
    /// For functions see <see cref="IProvider{T}"/>.
    /// </summary>
    public interface IConsumer<in T1, in T2>
    {
        void Consume(T1 value1, T2 value2);
    }

    /// <summary>
    /// Consumes triplet instances of types <typeparamref name="T1"/>, <typeparamref name="T2"/>, and <typeparamref name="T3"/> for processing.
    /// Basically, an <see cref="Action{T1, T2, T3}"/> as a type, not a delegate.
    /// For functions see <see cref="IProvider{T}"/>.
    /// </summary>
    public interface IConsumer<in T1, in T2, in T3>
    {
        void Consume(T1 value1, T2 value2, T3 value3);
    }
}
