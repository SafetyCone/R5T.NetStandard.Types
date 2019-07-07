using System;


namespace R5T.NetStandard
{
    public class ConsoleWrapper
    {
        #region Static

        public static ConsoleWrapper New()
        {
            var consoleWrapper = new ConsoleWrapper();
            return consoleWrapper;
        }

        #endregion


        public ConsoleWrapper()
        {
        }

        /// <summary>
        /// The fundamental console write operation.
        /// </summary>
        public void WriteLine(string format, params object[] values)
        {
            Console.WriteLine(format, values);
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
