using System;
using System.IO;


namespace R5T.NetStandard
{
    public static class StringReaderExtensions
    {
        public static bool ReadLineIsEnd(this StringReader stringReader, out string line)
        {
            line = stringReader.ReadLine();

            var isEnd = line == StringReaderHelper.EndOfString;
            return isEnd;
        }
    }
}
