using System;
using System.Threading;


namespace R5T.NetStandard
{
    /// <summary>
    /// An improved version of <see cref="Console"/> that allows for client code to synchronize access.
    /// </summary>
    public static class ConsoleSynchronization
    {
        private static readonly object LockObject = new object();


        public static ConsoleSynchronizationContext GetContext()
        {
            Monitor.Enter(ConsoleSynchronization.LockObject);

            var synchronizationToken = new ConsoleSynchronizationContext(ConsoleSynchronization.LockObject);
            return synchronizationToken;
        }

        public static void Write(string value)
        {
            lock (ConsoleSynchronization.LockObject)
            {
                Console.Write(value);
            }
        }

        public static void WriteLine(string value)
        {
            lock (ConsoleSynchronization.LockObject)
            {
                Console.WriteLine(value);
            }
        }

        public static void WriteLine()
        {
            ConsoleSynchronization.WriteLine(String.Empty);
        }
    }
}
