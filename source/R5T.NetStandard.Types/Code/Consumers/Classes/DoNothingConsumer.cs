using System;


namespace R5T.NetStandard.Types
{
    public class DoNothingConsumer<T> : IConsumer<T>
    {
        public static DoNothingConsumer<T> Instance { get; } = new DoNothingConsumer<T>();


        public void Consume(T value)
        {
            // Do nothing.
        }
    }
}
