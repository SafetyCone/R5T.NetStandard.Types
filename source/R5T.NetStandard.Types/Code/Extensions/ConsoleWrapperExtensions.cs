using System;
using System.Collections.Generic;

using R5T.NetStandard.Extensions;


namespace R5T.NetStandard
{
    public static class ConsoleWrapperExtensions
    {
        public static void WriteLines(this ConsoleWrapper console, IEnumerable<string> lines)
        {
            lines.ForEach(line =>
            {
                console.WriteLine(line);
            });
        }
    }
}
