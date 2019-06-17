using System;
using System.Threading;


namespace R5T.NetStandard
{
    public class ConsoleSynchronizationContext : IDisposable
    {
        private object SynchronizationValue { get; set; }


        internal ConsoleSynchronizationContext(object synchronizationValue)
        {
            this.SynchronizationValue = synchronizationValue;
        }

        public void Dispose()
        {
            Monitor.Exit(this.SynchronizationValue);
        }

        public void Write(string value)
        {
            lock (this.SynchronizationValue)
            {
                Console.Write(value);
            }
        }

        public void WriteLine(string value)
        {
            lock (this.SynchronizationValue)
            {
                Console.WriteLine(value);
            }
        }

        public void WriteLine()
        {
            this.WriteLine(String.Empty);
        }
    }
}
