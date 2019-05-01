using System;


namespace R5T.NetStandard
{
    /// <summary>
    /// Provides an instance of a specified type.
    /// Basically, a <see cref="Func{TResult}"/> as a type, not a delegate.
    /// For actions see <see cref="IConsumer{T}"/>.
    /// </summary>
    public interface IProvider<T>
    {
        T Provide();
    }

    /// <summary>
    /// Provides an instance of a specified output type, given an instance of a specified input type.
    /// Basically, a <see cref="Func{T, TResult}"/> as a type, not a delegate.
    /// For actions see <see cref="IConsumer{T}"/>.
    /// </summary>
    public interface IProvider<TOut, in TIn>
    {
        TOut Provide(TIn @in);
    }

    /// <summary>
    /// Provides an instance of a specified output type, given an instance of a specified input type.
    /// Basically, a <see cref="Func{T1, T2, TResult}"/> as a type, not a delegate.
    /// For actions see <see cref="IConsumer{T}"/>.
    /// </summary>
    public interface IProvider<out TOut, in TIn1, in TIn2>
    {
        TOut Provide(TIn1 in1, TIn2 in2);
    }
}
